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

        public ActionResult Testes()
        {
            var testes = repository.GetAllByUserId((int)(Session["Id"]));
            List<TesteViewModel> testesViewModel = Mapper.Map<List<TesteViewModel>>(testes);

            return View(testesViewModel);
        }

        public ActionResult AnalisarTeste(int id)
        {
            Teste teste = repository.GetById(id);

            if (teste == null)
            {
                return HttpNotFound();
            }

            var testeViewModel = Mapper.Map<TesteViewModel>(teste);

            return View(testeViewModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Avaliar(Teste teste, string laudo, string observacao, string vindeterminado, HttpPostedFileBase file)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        db.Entry(teste).State = EntityState.Modified;
        //        db.SaveChanges();

        //        RESULTADO resultado = new RESULTADO();
        //        if (file == null)
        //        {
        //            resultado.tabela = null;
        //        }
        //        else
        //        {
        //            try
        //            {

        //                string _FileName = Path.GetFileName(file.FileName);
        //                string _path = System.IO.Path.Combine(Server.MapPath("~/Content/Uploads/Laudos/"), _FileName);
        //                file.SaveAs(_path);
        //                resultado.tabela = "/Content/Uploads/Laudos/" + _FileName;
        //            }
        //            catch (Exception ex)
        //            {
        //                TempData["MensagemErro"] = ex.Message;
        //            }
        //        }
        //        resultado.id_exame = teste.id_exame;
        //        resultado.id_teste = teste.id;
        //        resultado.laudo = laudo + " " + vindeterminado;
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