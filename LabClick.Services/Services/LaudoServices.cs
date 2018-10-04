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

            //Logo
            Stream logoStream = new MemoryStream(laboratorio.ImagemLogo);
            XImage logoImage = XImage.FromStream(logoStream);
            gfx.DrawImage(logoImage, 20, 10, 210, 80);

            //Body
            gfx.DrawImage(XImage.FromFile(@"C:\Jobs\labclick\LabClick\Content\styles\images\body.PNG"), 20, 220, 570, 380);

            //Footer
            Stream footerStream = new MemoryStream(laboratorio.ImagemFooter);
            XImage footerImage = XImage.FromStream(footerStream);
            gfx.DrawImage(footerImage, 30, 630, 550, 130);

            gfx.DrawString("WWW.LABORLABIS.COM.BR", new XFont("Comic Sans", 10), XBrushes.MidnightBlue, 450, 40);

            gfx.DrawImage(XImage.FromFile(@"C:\Jobs\labclick\LabClick\Content\styles\images\header.PNG"), 20, 100, 570, 70);

            //Dados do Paciente
            gfx.DrawString($"Nome: {teste.Paciente.Nome}", font,
              XBrushes.Black, 35, 120, XStringFormats.Default);
            gfx.DrawString($"Idade: {DateTimeToAge(teste.Paciente.DataNascimento)} anos", font,
                XBrushes.Black, 35, 130, XStringFormats.Default);
            gfx.DrawString($"Cidade: {teste.Paciente.Endereco.Cidade}", font,
                XBrushes.Black, 35, 140, XStringFormats.Default);
            gfx.DrawString($"CEP: {teste.Paciente.Endereco.Cep}", font,
                XBrushes.Black, 35, 150, XStringFormats.Default);
            gfx.DrawString($"CPF: {teste.Paciente.Cpf}", font,
                XBrushes.Black, 244, 120, XStringFormats.Default);
            gfx.DrawString($"Sexo: {teste.Paciente.Sexo}", font,
                XBrushes.Black, 244, 130, XStringFormats.Default);
            gfx.DrawString($"UF: {teste.Paciente.Endereco.UF}", font,
                XBrushes.Black, 244, 140, XStringFormats.Default);

            //Dados do Teste
            gfx.DrawString($"Data do Teste: {teste.DataCadastro}", font,
                XBrushes.Black, 410, 120, XStringFormats.Default);

            //Resultado e Imagem do Teste

            //gfx.DrawImage(XImage.FromFile(@"C:\Jobs\labclick\Imagens\Resultado.PNG"), 40, 220, 75, 17);

            //Stream str = new MemoryStream(testeImagem.Imagem);
            //XImage xImage = XImage.FromStream(str);
            //gfx.DrawImage(xImage, 40, 250, 200, 200);

            //gfx.DrawString($"{laudo.Resultado}", font,
            //    XBrushes.Black, 40, 500);
            //gfx.DrawString($"{laudo.ResultadoDetalhes}", font,
            //    XBrushes.Black, 40, 520);

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
