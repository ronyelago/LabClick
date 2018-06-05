using LabClick.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LabClick.Infra.Repositories
{
    public class PacienteRepository : RepositoryBase<Paciente>
    {
        public List<Paciente> GetByName(string name)
        {
            var pacientes = (from p in Db.Paciente
                             where p.Nome.Contains(name)
                             select p).ToList();

            return pacientes;
        }
    }
}
