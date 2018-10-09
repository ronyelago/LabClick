using LabClick.Infra.Repositories;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabClick.Api.Controllers
{
    [RoutePrefix("user")]
    public class UsuarioController : ApiController
    {
        private UsuarioRepository repository = new UsuarioRepository();

        [HttpGet]
        [Route("GetByEmail={email}")]
        public HttpResponseMessage GetByEmail(string email)
        {
            var usuario = repository.GetByEmail(email);

            if (usuario == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }
    }
}
