﻿using AutoMapper;
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
        private readonly LaudoRepository laudoRepository = new LaudoRepository();
        private readonly EnderecoRepository enderecoRepository = new EnderecoRepository();

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

            PacienteViewModel pacientesViewModel = new PacienteViewModel
            {
                Pacientes = pacientes
            };

            return View(pacientesViewModel);
        }

        public ActionResult PesquisarPaciente(string nome)
        {
            var viewModel = new PacienteViewModel
            {
                Pacientes = repository.GetByName(nome)
            };

            return PartialView("PacientesPartial", viewModel);
        }

        public ActionResult ListaExames(int pacienteId)
        {
            var exames = testeRepository.GetAllByPacienteId(pacienteId);

            return View(exames);
        }

        public ActionResult VerExame(int testeId)
        {
            var pdf = laudoRepository.GetById(testeId);

            return File(pdf.Documento, "application/pdf");
        }

        public ActionResult NovoPaciente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovoPaciente(NovoPacienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Paciente paciente = Mapper.Map<Paciente>(model);
                    paciente.ClinicaId = (int)Session["clinicaId"];

                    repository.Add(paciente);
                }
                catch (System.Exception)
                {
                    return View();
                }
            }

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