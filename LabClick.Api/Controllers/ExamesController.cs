using LabClick.Infra.Repositories;
using System.Web.Http;

namespace LabClick.Api.Controllers
{
    [RoutePrefix("exame")]
    public class ExamesController : ApiController
    {
        private readonly ExameRepository _repository = new ExameRepository();


    }
}
