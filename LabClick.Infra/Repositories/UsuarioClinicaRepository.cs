using LabClick.Domain.Data.Interfaces;
using LabClick.Domain.Entities;
using System.Data.Entity;
using System.Linq;

namespace LabClick.Infra.Repositories
{
    public class UsuarioClinicaRepository : RepositoryBase<UsuarioClinica>, IUsuarioClinicaRepository
    {
        public UsuarioClinica GetByEmail(string email)
        {
            var user = Db.UsuarioClinica.Include(u => u.Clinica)
                           .FirstOrDefault(u => u.Email == email);

            return user;
        }
    }
}
