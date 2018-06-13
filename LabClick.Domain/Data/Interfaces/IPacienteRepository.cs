using LabClick.Domain.Entities;
using System.Collections.Generic;

namespace LabClick.Domain.Data.Interfaces
{
    public interface IPacienteRepository : IRepositoryBase<Paciente>
    {
        List<Paciente> GetByName(string name);
        List<Paciente> GetByLabId(int id);
    }
}
