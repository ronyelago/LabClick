using LabClick.Domain.Entities;

namespace LabClick.Domain.Data.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario GetByEmail(string email);
    }
}
