using AutoMapper;
using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using LabClick.ViewModel;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Support;
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
        public ActionResult GerarLaudo(TesteViewModel testeViewModel, string indeterminado)
        {
            var laudoRepository = new LaudoRepository();

            //Altera o Status do Teste para "Análise concluída"
            Teste teste = repository.GetById(testeViewModel.Id);
            teste.Status = "Análise concluída";
            repository.Update(teste);

            Laudo laudo = testeViewModel.Laudo;
            laudo.Id = testeViewModel.Id;
            laudo.DataCadastro = DateTime.Now;

            //Geração de PDF - posteriormente abstrair para outra classe
            PdfDocument document = new PdfDocument();

            // Create a font
            XFont font = new XFont("Arial", 8);

            // Create a new page
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //Logo
            gfx.DrawImage(XImage.FromFile(@"C:\Jobs\labclick\LabClick\Content\styles\images\LaborLabisLogo.png"), 20, 20, 210, 80);
            gfx.DrawString("WWW.LABORLABIS.COM.BR", new XFont("Comic Sans", 10), XBrushes.MidnightBlue, 450, 70);

            //Desenho Cabeçalho
            gfx.DrawLine(XPens.MidnightBlue, 40, 135, 572, 135);
            gfx.DrawLine(XPens.MidnightBlue, 40, 135, 40, 200);
            gfx.DrawLine(XPens.MidnightBlue, 40, 200, 572, 200);
            gfx.DrawLine(XPens.MidnightBlue, 572, 200, 572, 135);
            gfx.DrawLine(XPens.MidnightBlue, 204, 135, 204, 200);
            gfx.DrawLine(XPens.MidnightBlue, 408, 135, 408, 200);

            //Paciente
            gfx.DrawString($"Nome: {teste.Paciente.Nome}", font,
              XBrushes.Black, 50, 150, XStringFormats.Default);
            gfx.DrawString($"Idade: {teste.Paciente.DataNascimento}", font,
                XBrushes.Black, 50, 160, XStringFormats.Default);
            gfx.DrawString($"Cidade: {teste.Paciente.Endereco.Cidade}", font,
                XBrushes.Black, 50, 170, XStringFormats.Default);
            gfx.DrawString($"CEP: {teste.Paciente.Endereco.Cep}", font,
                XBrushes.Black, 50, 180, XStringFormats.Default);
            gfx.DrawString($"CPF: {teste.Paciente.Cpf}", font,
                XBrushes.Black, 250, 150, XStringFormats.Default);

            //Área e Imagem do Teste

            gfx.DrawImage(XImage.FromFile(@"C:\Jobs\labclick\LabClick\Content\styles\images\Resultado.png"), 40, 230, 15, 15);

            Stream str = new MemoryStream(teste.Imagem);
            XImage xImage = XImage.FromStream(str);
            gfx.DrawImage(xImage, 40, 250, 300, 100);




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