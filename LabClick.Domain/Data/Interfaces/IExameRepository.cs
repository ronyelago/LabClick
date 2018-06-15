using LabClick.Domain.Entities;
using System.Collections.Generic;

namespace LabClick.Domain.Data.Interfaces
{
    public interface IExameRepository : IRepositoryBase<Exame>
    {
        List<Exame> GetExamsPerClinic(int id);
    }
}
