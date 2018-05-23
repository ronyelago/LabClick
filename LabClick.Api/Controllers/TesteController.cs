using LabClick.Domain.Data.Repositories;
using LabClick.Domain.Entities;
using System.Web.Http;

namespace LabClick.Api.Controllers
{
    [RoutePrefix("api/Teste")]
    public class TesteController : ApiController
    {
        private readonly TesteRepository _testeRepository = new TesteRepository();

        public Teste Get(int id)
        {
            return _testeRepository.GetById(id);
        }
    }
}