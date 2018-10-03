using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabClick.Api.Controllers
{
    [RoutePrefix("laboratorio")]
    public class LaboratorioController : ApiController
    {
        private LaboratorioRepository _repository = new LaboratorioRepository();

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage PostTeste(Laboratorio laboratorio)
        {
            if (laboratorio == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _repository.Add(laboratorio);

                return Request.CreateResponse(HttpStatusCode.OK, laboratorio);
            }
            catch (System.Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    $"Falha ao incluir o Laboratorio.\n{ex.Message}");
            }

        }

        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var laboratorios = _repository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, laboratorios);
        }
    }
}
