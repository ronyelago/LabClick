﻿using System.Collections.Generic;
using System.Linq;
using LabClick.Domain.Data.Interfaces;
using LabClick.Domain.Entities;

namespace LabClick.Infra.Repositories
{
    public class ExameRepository : RepositoryBase<Exame>, IExameRepository
    {
        public List<Exame> GetExamsPerClinic(int id)
        {
           

            return new List<Exame> { };
        }
    }
}
