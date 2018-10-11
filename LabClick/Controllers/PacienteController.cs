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
        private readonly TesteRepository testeRepository = new TesteRepository();

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

        public ActionResult ListaExames(int pacienteId)
        {
            var exames = testeRepository.GetAllByPacienteId(pacienteId);

            return View(exames);
        }

        // GET: Paciente/Criar
        public ActionResult Criar()
        {
            return View();
        }

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