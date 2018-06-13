using LabClick.Domain.Data.Interfaces;
using LabClick.Domain.Entities;
using System.Linq;

namespace LabClick.Infra.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario GetByEmail(string email)
        {
            return Db.Usuario.FirstOrDefault(u => u.Email == email);
        }
    }
}
