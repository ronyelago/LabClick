using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace LabClick.Services.Services
{
    public class PacienteServices
    {
        private readonly PacienteRepository repository;

        public PacienteServices()
        {
            repository = new PacienteRepository();
        }

        public void New(Paciente paciente)

        {
            repository.Add(paciente);
        }

        public void Update(Paciente paciente)
        {
            repository.Update(paciente);
        }

        public Paciente GetById(int id)
        {
            return repository.GetById(id);
        }

        public List<Paciente> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public void Delete(Paciente paciente)
        {
            repository.Remove(paciente);
        }

        public List<Paciente> GetByLabId(int id)
        {
            return repository.GetByLabId(id);
        }

        public List<Paciente> GetByName(string name)
        {
            return repository.GetByName(name);
        }
    }
}
