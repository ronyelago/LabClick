using AutoMapper;
using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using LabClick.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace LabClick.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteRepository repository = new PacienteRepository();

        // GET: Paciente
        public ActionResult Index()
        {
            List<Paciente> pacientes = new List<Paciente>();

            if (Session["LaboratorioId"] != null)
            {
                pacientes = repository.GetByLabId((int)(Session["LaboratorioId"]));
            }

            else if (Session["ClinicaId"] != null)
            {
                pacientes = repository.GetByClinicaId((int)(Session["ClinicaId"]));
            }

            else
            {
                pacientes = repository.GetAll().ToList();
            }

            var pacientesViewModel = Mapper.Map<List<PacienteViewModel>>(pacientes);

            return View(pacientesViewModel);
        }

        // GET: Paciente/Criar
        public ActionResult Criar()
        {
            return View();
        }

        //// GET: Paciente/Editar/5
        //public ActionResult Editar(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PACIENTE paciente = db.PACIENTE.Find(id);
        //    if (paciente == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(paciente);
        //}

        //// POST: Paciente/Editar/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Editar(PACIENTE paciente)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(paciente).State = EntityState.Modified;
        //        paciente.data_modificado = DateTime.Now;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(paciente);
        //}

        //// GET: Paciente/Delete/5
        //public ActionResult Deletar(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PACIENTE paciente = db.PACIENTE.Find(id);
        //    if (paciente == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(paciente);
        //}

        //// POST: Paciente/Delete/5
        //[HttpPost, ActionName("Deletar")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var _userlogged = LabClick.Models.Util.RetornaID(System.Web.HttpContext.Current.User.Identity.Name);

        //    PACIENTE paciente = db.PACIENTE.Find(id);
        //    db.PACIENTE.Remove(paciente);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}
        //// GET: Paciente
        //public ActionResult Lista()
        //{
        //    return View(db.PACIENTE.ToList());
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