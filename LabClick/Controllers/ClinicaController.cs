using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace LabClick.Controllers
{
    [Authorize(Roles = "Administrador, Laboratorio")]
    public class ClinicaController : Controller
    {
        private sql_LabClickEntities db = new sql_LabClickEntities();
        // GET: Clinica
        public ActionResult Index()
        {
            return View(db.CLINICA.ToList());
        }
        // GET: Clinica/Details/5
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLINICA Clinica = db.CLINICA.Find(id);
            if (Clinica == null)
            {
                return HttpNotFound();
            }
            return View(Clinica);
        }

        // GET: Clinica/Create
        public ActionResult Criar()
        {
            ViewBag.id_laboratorio = new SelectList(db.LABORATORIO, "id", "nome_laboratorio");
            return View();
        }

        // POST: Clinica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(CLINICA clinica,HttpPostedFileBase file, int id_lab)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = System.IO.Path.Combine(Server.MapPath("~/Content/Uploads/Logos/"), _FileName);
                    file.SaveAs(_path);
                    clinica.logotipo = "/Content/Uploads/Logos/" + _FileName;
                }
                catch (Exception ex)
                {
                    TempData["MensagemErro"] = ex.Message;
                }
                /* Inserindo Informações do Laboratório */
                clinica.data_inserido = DateTime.Now;
                clinica.data_modificado = DateTime.Now;
                clinica.id_laboratorio = id_lab;

                db.CLINICA.Add(clinica);
                /* Salva para depois salvar com o id do Clinica */
                db.SaveChanges();
                /* Inserindo Informações de Login */
                LOGIN login = new LOGIN();
                login.nome = clinica.nome_clinica;
                login.email = clinica.email;
                login.senha = RandomNumber(999999);
                login.data_inserido = DateTime.Now;
                login.data_modificado = DateTime.Now;
                login.id_clinica = clinica.id;
                login.perfil = "Clinica";
                db.LOGIN.Add(login);
                /* Salvando */
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(clinica);
        }

        // GET: Clinica/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLINICA Clinica = db.CLINICA.Find(id);
            if (Clinica == null)
            {
                return HttpNotFound();
            }
            return View(Clinica);
        }

        // POST: Clinica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CLINICA Clinica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Clinica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Clinica);
        }

        // GET: Clinica/Deletar/5
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLINICA clinica = db.CLINICA.Find(id);
            if (clinica == null)
            {
                return HttpNotFound();
            }
            return View(clinica);
        }

        // POST: Clinica/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarConfirmado(int id)
        {
            CLINICA clinica = db.CLINICA.Find(id);
            db.CLINICA.Remove(clinica);
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
        private string RandomNumber(int size)
        {
            Random num = new Random();

            return num.Next(size).ToString("D6");
        }
    }
}