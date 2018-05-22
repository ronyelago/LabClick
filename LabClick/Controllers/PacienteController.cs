using LabClick.Database;
using LabClick.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace LabClick.Controllers
{
    public class PacienteController : Controller
    {
        private sql_LabClickEntities db = new sql_LabClickEntities();
        // GET: Paciente
        public ActionResult Index()
        {
             var id_cli = Util.RetornaID_Clinica(System.Web.HttpContext.Current.User.Identity.Name);
             return View(Util.Lista_Pacientes(id_cli));
        }
        public ActionResult IndexLab()
        {
            var id_lab = Util.RetornaID_Laboratorio(System.Web.HttpContext.Current.User.Identity.Name);
            return View(Util.Lista_Pacientes_Lab(id_lab));
        }
        // GET: Paciente/Detalhes/Testes Parcial View
        public ActionResult ListagemTestes(int? id)
        {
            var Teste = db.TESTE.Include(t => t.EXAME).Include(t => t.CLINICA).Include(t => t.PACIENTE).Where(t => t.id_paciente == id);

            return View(Teste.ToList());

        }
        
        // GET: Paciente/Criar
        public ActionResult Criar()
        {
            return View();
        }

        // POST: Paciente/Criar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(PACIENTE paciente, int id_clinica)
        {
            if (ModelState.IsValid)
            {
                paciente.data_inserido = DateTime.Now;
                paciente.data_modificado = DateTime.Now;
                paciente.cpf = FormatCnpjCpf.SemFormatacao(paciente.cpf);
                db.PACIENTE.Add(paciente);
                db.SaveChanges();

                return RedirectToAction("Criado", "Paciente", new { id = paciente.id });
            }

            return RedirectToAction("Criado", "Paciente", new { id = paciente.id });
        }
        public ActionResult Criado(int? id)
        {
            ViewBag.cadastrado = id;
            return View();
        }

        // GET: Paciente/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE paciente = db.PACIENTE.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Paciente/Editar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(PACIENTE paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                paciente.data_modificado = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }
        public ActionResult ListaPacientes(int? id)
        {
            return View(Util.Lista_Pacientes(id));
        }

        // GET: Paciente/Delete/5
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE paciente = db.PACIENTE.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var _userlogged = LabClick.Models.Util.RetornaID(System.Web.HttpContext.Current.User.Identity.Name);

            PACIENTE paciente = db.PACIENTE.Find(id);
            db.PACIENTE.Remove(paciente);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: Paciente
        public ActionResult Lista()
        {
            return View(db.PACIENTE.ToList());
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