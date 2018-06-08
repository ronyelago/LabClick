using System.Collections.Generic;
using System.Linq;
using LabClick.Domain.Data.Interfaces;
using LabClick.Domain.Entities;

namespace LabClick.Infra.Repositories
{
    public class TesteRepository : RepositoryBase<Teste>, ITesteRepository
    {
        public ICollection<Teste> GetAllByPacienteId(int pacienteId)
        {
            return Db.Teste.Where(t => t.PacienteId == pacienteId).ToList();
        }
    }
}
