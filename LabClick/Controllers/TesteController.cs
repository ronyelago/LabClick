using AutoMapper;
using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
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
            //if (teste.Status == "Aguardando análise")
            //{
            //    teste.Status = "Em análise";
            //    repository.Update(teste);
            //}

            var testeViewModel = Mapper.Map<TesteViewModel>(teste);

            return View(testeViewModel);
        }

        [HttpPost]
        public ActionResult GerarLaudo(TesteViewModel testeViewModel)
        {
            if (testeViewModel.Laudo.Resultado == "Indeterminado")
            {
                testeViewModel.Laudo.Resultado += $": {testeViewModel.IndeterminadoDescricao}";
            }

            var laudoRepository = new LaudoRepository();

            //Altera o Status do Teste para "Análise concluída"
            Teste teste = repository.GetById(testeViewModel.Id);
            teste.Status = "Análise concluída";
            repository.Update(teste);

            //Geração do Laudo
            Laudo laudo = testeViewModel.Laudo;
            laudo.Id = testeViewModel.Id;
            laudo.DataCadastro = DateTime.Now;



            


            //PdfDocument to byte array
            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream);
                laudo.Documento = stream.ToArray();

                //Salva o laudo do teste
                //laudoRepository.Add(laudo);

                return File(stream.ToArray(), "application/pdf");

            }
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