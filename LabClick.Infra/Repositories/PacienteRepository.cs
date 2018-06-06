using LabClick.Domain.Data.Interfaces;
using LabClick.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LabClick.Infra.Repositories
{
    public class PacienteRepository : RepositoryBase<Paciente>, IPacienteRepository
    {
        public List<Paciente> GetByName(string name)
        {
            var pacientes = Db.Paciente.Where(p => p.Nome.Contains(name)).ToList();

            return pacientes;
        }
    }
}
