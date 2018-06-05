﻿using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabClick.Api.Controllers
{
    [RoutePrefix("paciente")]
    public class PacientesController : ApiController
    {
        private PacienteRepository _repository = new PacienteRepository();

        [Route("pacientes")]
        public HttpResponseMessage GetPacientes()
        {
            var pacientes = _repository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, pacientes);
        }

        [Route("getById={id}")]
        public HttpResponseMessage GetPaciente(int id)
        {
            Paciente paciente = _repository.GetById(id);

            if (paciente == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, paciente);
        }

        [Route("getByName={name}")]
        public HttpResponseMessage GetByName(string name)
        {
            List<Paciente> pacientes = _repository.GetByName(name);

            if (pacientes.Count < 1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, pacientes);
        }

        [HttpPost]
        [Route("pacientes")]
        public HttpResponseMessage PostTeste(Paciente paciente)
        {
            if (paciente == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _repository.Add(paciente);

                return Request.CreateResponse(HttpStatusCode.OK, paciente);
            }
            catch (System.Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    $"Falha ao incluir o Teste.\n{ex.Message}");
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}