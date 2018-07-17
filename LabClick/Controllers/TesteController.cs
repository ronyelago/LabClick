using AutoMapper;
using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using LabClick.Services.Services;
using LabClick.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace LabClick.Controllers
{
    public class TesteController : Controller
    {
        private readonly TesteRepository repository = new TesteRepository();
        private readonly LaudoServices laudoService = new LaudoServices();

        //Listagem de todos os testes ordenados por data de cadastro
        public ActionResult Testes()
        {
            var testes = repository.GetAllByUserId((int)(Session["Id"]));
            List<TesteViewModel> testesViewModel = Mapper.Map<List<TesteViewModel>>(testes);

            return View(testesViewModel);
        }

        //Exibe o teste selecionado para análise
        public ActionResult AnalisarTeste(int id)
        {
            Teste teste = repository.GetById(id);

            if (teste == null)
            {
                return HttpNotFound();
            }

            //Altera o Status do Teste para "Em análise"
            if (teste.Status == "Aguardando análise")
            {
                teste.Status = "Em análise";
                repository.Update(teste);
            }

            var testeViewModel = Mapper.Map<TesteViewModel>(teste);
            testeViewModel.Target = "_self";

            return View(testeViewModel);
        }

        [HttpPost]
        public ActionResult GerarLaudo(TesteViewModel testeViewModel)
        {
            Teste teste = repository.GetById(testeViewModel.Id);
            
            //Geração do Laudo
            Laudo laudo = testeViewModel.Laudo;
            laudo.Id = teste.Id;
            laudo.DataCadastro = DateTime.Now;
            laudo.ResultadoDetalhes = testeViewModel.ResultadoDetalhes;

            if (testeViewModel.Laudo.Resultado == "Indeterminado")
            {
                teste.Status = "Pendente";
                teste.Laudo = laudo;
                repository.Update(teste);

                return RedirectToAction("Testes");
            }

            testeViewModel.Target = "_blank";
            var document = laudoService.GerarLaudoPdf(teste, laudo);

            //PdfDocument to byte array
            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream);
                laudo.Documento = stream.ToArray();

                teste.Laudo = laudo;
                teste.Status = "Concluído";
                teste.LaudoOk = true;

                repository.Update(teste);

                return File(stream.ToArray(), "application/pdf");
            }
        }

        public ActionResult ViewPdf(int id)
        {
            var pdf = repository.GetById(id).Laudo.Documento;

            return File(pdf, "application/pdf");
        }
 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}