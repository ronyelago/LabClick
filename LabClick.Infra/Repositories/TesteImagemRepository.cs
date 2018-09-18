using LabClick.Domain.Data.Interfaces;
using LabClick.Domain.Entities;
using System.Linq;

namespace LabClick.Infra.Repositories
{
    public class TesteImagemRepository : RepositoryBase<TesteImagem>, ITesteImagemRepository
    {
        public TesteImagem GetByTesteId(int testeId)
        {
            var testeImagem = Db.TesteImagem.FirstOrDefault(i => i.TesteId == testeId);

            return testeImagem;
        }
    }
}
