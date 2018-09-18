using LabClick.Domain.Entities;

namespace LabClick.Domain.Data.Interfaces
{
    public interface ITesteImagemRepository : IRepositoryBase<TesteImagem>
    {
        TesteImagem GetByTesteId(int testeId);
    }
}
