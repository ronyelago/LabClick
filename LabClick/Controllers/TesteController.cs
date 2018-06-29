using AutoMapper;
using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using LabClick.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
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
            if (teste.Status == "Aguardando análise")
            {
                teste.Status = "Em análise";
                repository.Update(teste);
            }

            var testeViewModel = Mapper.Map<TesteViewModel>(teste);

            return View(testeViewModel);
        }

        [HttpPost]
        public ActionResult GerarLaudo(TesteViewModel testeViewModel)
        {
            var laudoRepository = new LaudoRepository();

            //Altera o Status do Teste para "Análise concluída"
            var teste = repository.GetById(testeViewModel.Id);
            teste.Status = "Análise concluída";
            repository.Update(teste);

            Laudo laudo = testeViewModel.Laudo;
            laudo.Id = testeViewModel.Id;
            laudo.DataCadastro = DateTime.Now;

            laudoRepository.Add(laudo);

            //Geração de PDF - posteriormente abstrair para outra classe
            using (var doc = new PdfSharp.Pdf.PdfDocument())
            {
                var page = doc.AddPage();
                var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);
                var font = new PdfSharp.Drawing.XFont("Arial", 14);
            }


                return View(laudo);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Avaliar(Teste teste, string laudo, string observacao, string vindeterminado, HttpPostedFileBase file)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        repository.Update(teste);

        //        Resultado resultado = new Resultado();

        //        if (file == null)
        //        {
        //            resultado.Tabela = null;
        //        }
        //        else
        //        {
        //            try
        //            {

        //                string _FileName = Path.GetFileName(file.FileName);
        //                string _path = System.IO.Path.Combine(Server.MapPath("~/Content/Uploads/Laudos/"), _FileName);
        //                file.SaveAs(_path);
        //                resultado.Tabela = "/Content/Uploads/Laudos/" + _FileName;
        //            }
        //            catch (Exception ex)
        //            {
        //                TempData["MensagemErro"] = ex.Message;
        //            }
        //        }
        //        resultado.ExameId = teste.ExameId;
        //        resultado.TesteId = teste.Id;
        //        resultado.Laudo = laudo + " " + vindeterminado;
        //        resultado.observacao = observacao;
        //        resultado.data_inserido = DateTime.Now;
        //        resultado.documento = null;
        //        db.RESULTADO.Add(resultado);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.id_exame = new SelectList(db.EXAME, "id", "nome_exame", teste.id_exame);
        //    ViewBag.id_laboratorio = new SelectList(db.LABORATORIO, "id", "nome_clinica", teste.id_clinica);
        //    ViewBag.id_paciente = new SelectList(db.PACIENTE, "id", "nome_paciente", teste.id_paciente);

        //    return View(teste);
        //}

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