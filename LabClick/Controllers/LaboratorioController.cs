//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using LabClick.Database;
//using LabClick.Repository;

//namespace LabClick.Controllers
//{
//    [Authorize(Roles = "Administrador")]
//    public class LaboratorioController : Controller
//    {
//        private sql_LabClickEntities db = new sql_LabClickEntities();
//        // GET: Laboratorio
//        public ActionResult Index()
//        {
//            return View(db.LABORATORIO.ToList());
//        }

//        // GET: Clinica/Detalhes/5
//        public ActionResult Detalhes(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            LABORATORIO laboratorio = db.LABORATORIO.Find(id);
//            if (laboratorio == null)
//            {
//                return HttpNotFound();
//            }
//            return View(laboratorio);
//        }
//        public ActionResult Criar()
//        {
//            return View();
//        }
//        // POST: Laboratorio/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Criar(LABORATORIO laboratorio)
//        {
//            if (ModelState.IsValid)
//            {
//                /* Inserindo Informações do Laboratório */
//                laboratorio.data_inserido = DateTime.Now;
//                laboratorio.data_modificado = DateTime.Now;
//                db.LABORATORIO.Add(laboratorio);
//                /* Salva para depois salvar com o id do Laboratorio */
//                db.SaveChanges();
//                /* Inserindo Informações de Login */
//                LOGIN login = new LOGIN();
//                login.nome = laboratorio.nome_laboratorio;
//                login.email = laboratorio.email;
//                login.senha = RandomNumber(999999);
//                login.data_inserido = DateTime.Now;
//                login.data_modificado = DateTime.Now;
//                login.id_laboratorio = laboratorio.id;
//                login.perfil = "Laboratorio";
//                db.LOGIN.Add(login);
//                /* Salvando */
//                db.SaveChanges();
//                return RedirectToAction("Index");

//            }

//            return View(laboratorio);
//        }
//        // GET: Laboratorio/Editar/5
//        public ActionResult Editar(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            LABORATORIO laboratorio = db.LABORATORIO.Find(id);
//            if (laboratorio == null)
//            {
//                return HttpNotFound();
//            }
//            return View(laboratorio);
//        }

//        // POST: Laboratorio/Editar/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Editar(LABORATORIO laboratorio)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(laboratorio).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(laboratorio);
//        }

//        // GET: Laboratorio/Deletar/5
//        public ActionResult Deletar(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            LABORATORIO laboratorio = db.LABORATORIO.Find(id);
//            if (laboratorio == null)
//            {
//                return HttpNotFound();
//            }
//            return View(laboratorio);
//        }

//        // POST: Laboratorio/Deltar/5
//        [HttpPost, ActionName("Deletar")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeletarConfirmado(int id)
//        {
//            LABORATORIO laboratorio = db.LABORATORIO.Find(id);
//            db.LABORATORIO.Remove(laboratorio);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//        private string RandomNumber(int size)
//        {
//            Random num = new Random();

//            return num.Next(size).ToString("D6");
//        }
//    }
//}