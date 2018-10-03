using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LabClick.Services.Services
{
    public class LaudoServices
    {
        private readonly LaudoRepository repository;

        public LaudoServices()
        {
            repository = new LaudoRepository();
        }

        public void New(Laudo laudo)

        {
            repository.Add(laudo);
        }

        public void Update(Laudo laudo)
        {
            repository.Update(laudo);
        }

        public Laudo GetById(int id)
        {
            return repository.GetById(id);
        }

        public List<Laudo> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public void Delete(Laudo laudo)
        {
            repository.Remove(laudo);
        }

        public PdfDocument GerarLaudoPdf(Laboratorio laboratorio, Teste teste, TesteImagem testeImagem, Laudo laudo)
        {
            #region Geração do PDF (Laudo)
            //*******************************************************
            PdfDocument document = new PdfDocument();

            // Create a font
            XFont font = new XFont("Arial", 8);

            // Create a new page
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //Logo e Footer
            Stream logoStream = new MemoryStream(laboratorio.ImagemLogo);
            XImage logoImage = XImage.FromStream(logoStream);
            gfx.DrawImage(logoImage, 20, 20, 210, 80);

            Stream footerStream = new MemoryStream(laboratorio.ImagemFooter);
            XImage footerImage = XImage.FromStream(footerStream);
            gfx.DrawImage(footerImage, 30, 690, 560, 80);

            gfx.DrawImage(XImage.FromFile(@"C:\Jobs\labclick\LabClick\Content\styles\images\LaborLabisLogo.png"), 20, 20, 210, 80);
            gfx.DrawImage(XImage.FromFile(@"C:\Jobs\labclick\Imagens\rodape.PNG"), 30, 690, 560, 80);


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
            gfx.DrawString($"Idade: {DateTimeToAge(teste.Paciente.DataNascimento)} anos", font,
                XBrushes.Black, 35, 160, XStringFormats.Default);
            gfx.DrawString($"Cidade: {teste.Paciente.Endereco.Cidade}", font,
                XBrushes.Black, 35, 170, XStringFormats.Default);
            gfx.DrawString($"CEP: {teste.Paciente.Endereco.Cep}", font,
                XBrushes.Black, 35, 180, XStringFormats.Default);
            gfx.DrawString($"CPF: {teste.Paciente.Cpf}", font,
                XBrushes.Black, 214, 150, XStringFormats.Default);
            gfx.DrawString($"Sexo: {teste.Paciente.Sexo}", font,
                XBrushes.Black, 214, 160, XStringFormats.Default);
            gfx.DrawString($"UF: {teste.Paciente.Endereco.UF}", font,
                XBrushes.Black, 214, 170, XStringFormats.Default);

            //Dados do Teste
            gfx.DrawString($"Data do Teste: {teste.DataCadastro}", font,
                XBrushes.Black, 316, 150, XStringFormats.Default);

            //Resultado e Imagem do Teste

            gfx.DrawImage(XImage.FromFile(@"C:\Jobs\labclick\Imagens\Resultado.PNG"), 40, 220, 75, 17);

            Stream str = new MemoryStream(testeImagem.Imagem);
            XImage xImage = XImage.FromStream(str);
            gfx.DrawImage(xImage, 40, 250, 300, 100);

            gfx.DrawString($"{laudo.Resultado}", font,
                XBrushes.Black, 40, 500);
            gfx.DrawString($"{laudo.ResultadoDetalhes}", font,
                XBrushes.Black, 40, 520);

            #endregion

            return document;
        }

        public int DateTimeToAge(DateTime dateOfBirth)
        {
            int years = DateTime.Now.Year - dateOfBirth.Year;

            if ((dateOfBirth.Month > DateTime.Now.Month)
                    || (dateOfBirth.Month == DateTime.Now.Month
                    && dateOfBirth.Day > DateTime.Now.Day))
            {
                years--;
            }

            return years;
        }
    }
}
