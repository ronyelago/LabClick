using LabClick.Domain.Entities;
using System.Collections.Generic;

namespace LabClick.Domain.Data.Interfaces
{
    public interface ITesteRepository : IRepositoryBase<Teste>
    {
        ICollection<Teste> GetAllByPacienteId(int pacienteId);
    }
}
