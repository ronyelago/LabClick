using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabClick.Database;
using LabClick.Repository;


namespace LabClick.Controllers
{
    [Authorize(Roles = "Administrador, Laboratorio, Clinica")]
    public class ExameController : Controller
    {
        private sql_LabClickEntities db = new sql_LabClickEntities();
        // GET: Exame
        public ActionResult Index()
        {
            var id_cli = LabClick.Models.Util.RetornaID_Clinica(System.Web.HttpContext.Current.User.Identity.Name);
            var Exame = db.EXAME.Where(e => e.id_clinica == id_cli);
            return View(Exame.ToList());

        }
        // GET: Exame/Details/5
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXAME Exame = db.EXAME.Find(id);
            if (Exame == null)
            {
                return HttpNotFound();
            }
            return View(Exame);
        }
        public ActionResult Criar()
        {
            ViewBag.id_clinica = new SelectList(db.CLINICA, "id", "nome_clinica");
            return View();
        }

        // POST: Exame/Criar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(EXAME exame, int id_clinica)
        {
            if (ModelState.IsValid)
            {
                exame.data_inserido = DateTime.Now;
                exame.data_modificado = DateTime.Now;
                exame.id_clinica = id_clinica;
                db.EXAME.Add(exame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_clinica = new SelectList(db.CLINICA, "id", "nome_clinica", exame.id_clinica);
            return View(exame);
        }
        // GET: Exame/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXAME exame = db.EXAME.Find(id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_clinica = new SelectList(db.CLINICA, "id", "nome_clinica", exame.id_clinica);
            return View(exame);
        }

        // POST: Exame/Editar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(EXAME exame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exame).State = EntityState.Modified;
                exame.data_modificado = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_clinica = new SelectList(db.CLINICA, "id", "nome_clinica", exame.id_clinica);
            return View(exame);
        }

        // GET: Exame/Deletar/5
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXAME exame = db.EXAME.Find(id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        // POST: Exame/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarConfirmado(int id)
        {
            EXAME exame = db.EXAME.Find(id);
            db.EXAME.Remove(exame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}