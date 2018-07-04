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

            #region Geração do PDF
            //Geração de PDF - posteriormente abstrair para outra classe
            PdfDocument document = new PdfDocument();

            // Create a font
            XFont font = new XFont("Arial", 8);

            // Create a new page
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //Logo e email
            gfx.DrawImage(XImage.FromFile(@"C:\Jobs\labclick\LabClick\Content\styles\images\LaborLabisLogo.png"), 20, 20, 210, 80);
            gfx.DrawString("WWW.LABORLABIS.COM.BR", new XFont("Comic Sans", 10), XBrushes.MidnightBlue, 450, 70);

            //Desenho Cabeçalho
            //Linha superior
            gfx.DrawLine(XPens.MidnightBlue, 25, 135, 587, 135);
            //Linha lateral esquerda
            gfx.DrawLine(XPens.MidnightBlue, 25, 135, 25, 200);
            //Linha inferior
            gfx.DrawLine(XPens.MidnightBlue, 25, 200, 587, 200);
            //Linha lateral direita
            gfx.DrawLine(XPens.MidnightBlue, 587, 200, 587, 135);
            //linha interna esquerda
            gfx.DrawLine(XPens.MidnightBlue, 306, 135, 306, 200);
            //linha interna direita
            gfx.DrawLine(XPens.MidnightBlue, 445, 135, 445, 200);

            //Dados do Paciente
            gfx.DrawString($"Nome: {teste.Paciente.Nome}", font,
              XBrushes.Black, 35, 150, XStringFormats.Default);
            gfx.DrawString($"Idade: {testeViewModel.IdadePaciente} anos", font,
                XBrushes.Black, 35, 160, XStringFormats.Default);
            gfx.DrawString($"Cidade: {teste.Paciente.Endereco.Cidade}", font,
                XBrushes.Black, 35, 170, XStringFormats.Default);
            gfx.DrawString($"CEP: {teste.Paciente.Endereco.Cep}", font,
                XBrushes.Black, 35, 180, XStringFormats.Default);
            gfx.DrawString($"CPF: {teste.Paciente.Cpf}", font,
                XBrushes.Black, 214, 150, XStringFormats.Default);

            //Área e Imagem do Teste

            gfx.DrawImage(XImage.FromFile(@"C:\Jobs\labclick\Imagens\Resultado.PNG"), 40, 220, 75, 17);

            Stream str = new MemoryStream(teste.Imagem);
            XImage xImage = XImage.FromStream(str);
            gfx.DrawImage(xImage, 40, 250, 300, 100);

            //Rodapé e assinatura
            gfx.DrawImage(XImage.FromFile(@"C:\Jobs\labclick\Imagens\rodape.PNG"), 30, 690, 560, 80);

            #endregion


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