using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;

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
            gfx.DrawImage(XImage.FromFile(HostingEnvironment.MapPath(@"~\Content\styles\images\body.PNG")), 20, 220, 570, 380);

            Stream str = new MemoryStream(testeImagem.Imagem);
            XImage xImage = XImage.FromStream(str);
            gfx.DrawImage(xImage, 100, 290, 150, 150);

            if (laudo.ResultadoDetalhes != null)
            {
                if (laudo.Resultado == "Indeterminado")
                {
                    gfx.DrawString(laudo.ResultadoDetalhes, font, XBrushes.Black, 70, 520, XStringFormats.Default);
                }
                else
                {
                    gfx.DrawString(laudo.ResultadoDetalhes, font, XBrushes.Black, 145, 520, XStringFormats.Default);
                }
            }

            if (laudo.Observacoes != null)
            {
                XTextFormatter tf = new XTextFormatter(gfx);
                XRect rect = new XRect(80, 530, 200, 30);
                gfx.DrawRectangle(XBrushes.Transparent, rect);
                tf.DrawString(laudo.Observacoes, font, XBrushes.Black, rect, XStringFormats.TopLeft);
            }

            if (laudo.Resultado == "Positivo")
            {
                gfx.DrawImage(XImage.FromFile(HostingEnvironment.MapPath(@"~\Content\styles\images\positivo.PNG")), 110, 470, 130, 30);
            }
            else if (laudo.Resultado == "Negativo")
            {
                gfx.DrawImage(XImage.FromFile(HostingEnvironment.MapPath(@"~\Content\styles\images\negativo.PNG")), 120, 470, 120, 30);
            }
            else
            {
                gfx.DrawImage(XImage.FromFile(HostingEnvironment.MapPath(@"~\Content\styles\images\indeterminado.PNG")), 120, 470, 120, 20);
            }

            //Footer
            Stream footerStream = new MemoryStream(laboratorio.ImagemFooter);
            XImage footerImage = XImage.FromStream(footerStream);
            gfx.DrawImage(footerImage, 30, 700, 550, 130);
            gfx.DrawString(laboratorio.Email, new XFont("Comic Sans", 10), XBrushes.MidnightBlue, 450, 40);
            gfx.DrawImage(XImage.FromFile(HostingEnvironment.MapPath(@"~\Content\styles\images\header.PNG")), 20, 100, 570, 70);

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
            gfx.DrawString($"Data do Teste: {teste.DataCadastro}", font,
                XBrushes.Black, 410, 120, XStringFormats.Default);
            gfx.DrawString($"QR Code do Teste: {teste.Code}", font,
                XBrushes.Black, 410, 130, XStringFormats.Default);

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
