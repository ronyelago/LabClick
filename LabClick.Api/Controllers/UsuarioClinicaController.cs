using LabClick.Infra.Repositories;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabClick.Api.Controllers
{
    [RoutePrefix("usuarioclinica")]
    public class UsuarioClinicaController : ApiController
    {
        private readonly UsuarioClinicaRepository repository = new UsuarioClinicaRepository();

        [Route("GetByUserEmail={email}")]
        public HttpResponseMessage GetByUserEmail(string email)
        {
            var user = repository.GetByEmail(email);

            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
