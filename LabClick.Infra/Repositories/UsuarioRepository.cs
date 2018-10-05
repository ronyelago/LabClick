using LabClick.Domain.Data.Interfaces;
using LabClick.Domain.Entities;
using System.Linq;

namespace LabClick.Infra.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario GetByEmail(string email)
        {
            var user = Db.Usuario.FirstOrDefault(u => u.Email == email);

            return user;
        }
    }
}
