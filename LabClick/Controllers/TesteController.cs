using AutoMapper;
using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using LabClick.Services.Services;
using LabClick.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace LabClick.Controllers
{
    public class TesteController : Controller
    {
        private readonly TesteRepository testeRepository = new TesteRepository();
        private readonly LaudoServices laudoService = new LaudoServices();
        private readonly TesteImagemRepository testeImagemRepository = new TesteImagemRepository();
        private readonly LaboratorioRepository laboratorioRepository = new LaboratorioRepository();
        private readonly PacienteRepository pacienteRepository = new PacienteRepository();

        //Listagem de todos os testes ordenados por data de cadastro
        public ActionResult Testes()
        {
            List<Teste> testes = new List<Teste>();

            if (Session["LaboratorioId"] != null)
            {
                testes = testeRepository.GetAllByUserLabId((int)(Session["LaboratorioId"])).ToList();
            }

            else if (Session["ClinicaId"] != null)
            {
                testes = testeRepository.GetAllByUserClinicaId((int)(Session["ClinicaId"])).ToList();
            }

            else
            {
                testes = testeRepository.GetAll().ToList();
            }

            List<TesteViewModel> testesViewModel = Mapper.Map<List<TesteViewModel>>(testes);

            return View(testesViewModel);
        }

        //Exibe o teste selecionado para análise
        public ActionResult AnalisarTeste(int id)
        {
            Teste teste = testeRepository.GetById(id);
            var testeImagem = testeImagemRepository.GetByTesteId(id);

            if (teste == null)
            {
                return HttpNotFound();
            }

            //Altera o Status do Teste para "Em análise"
            if (teste.Status == "Aguardando análise")
            {
                teste.Status = "Em análise";
                testeRepository.Update(teste);
            }

            var testeViewModel = Mapper.Map<TesteViewModel>(teste);
            testeViewModel.Imagem = testeImagem.Imagem;

            return View(testeViewModel);
        }

        [HttpPost]
        public ActionResult GerarLaudo(TesteViewModel testeViewModel)
        {
            Teste teste = testeRepository.GetById(testeViewModel.Id);
            TesteImagem testeImagem = testeImagemRepository.GetByTesteId(testeViewModel.Id);
            Laboratorio laboratorio = laboratorioRepository.GetById((int)(Session["LaboratorioId"]));
            Paciente paciente = pacienteRepository.GetByIdWithAddress(testeViewModel.PacienteId);

            //Geração do Laudo
            Laudo laudo = new Laudo { Id = teste.Id };
            laudo.DataCadastro = DateTime.Now;

            teste.Resultado = testeViewModel.Resultado;
            teste.Observacoes = testeViewModel.Observacoes;

            if (testeViewModel.Resultado == "Positivo")
            {
                teste.ResultadoDetalhes = testeViewModel.PositivoDetalhes;
            }
            else if (testeViewModel.Resultado == "Indeterminado")
            {
                teste.ResultadoDetalhes = testeViewModel.IndeterminadoDetalhes;
            }

            var document = laudoService.GerarLaudoPdf(laboratorio, teste, testeImagem, paciente);

            //PdfDocument to byte array--
            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream);
                laudo.Documento = stream.ToArray();

                teste.Laudo = laudo;
                teste.Status = "Concluído";
                teste.LaudoOk = true;

                testeRepository.Update(teste);

                return File(stream.ToArray(), "application/pdf");
            }
        }

        public ActionResult ViewPdf(int id)
        {
            var pdf = testeRepository.GetById(id).Laudo.Documento;

            return File(pdf, "application/pdf");
        }
 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                testeRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}