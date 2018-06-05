using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabClick.Api.Controllers
{
    [RoutePrefix("endereco")]
    public class EnderecoController : ApiController
    {
        private EnderecoRepository _repository = new EnderecoRepository();

        [Route("enderecos")]
        public HttpResponseMessage GetEnderecos()
        {
            var enderecos = _repository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, enderecos);
        }

        [Route("getById")]
        public HttpResponseMessage GetById(int id)
        {
            var endereco = _repository.GetById(id);

            if (endereco == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, endereco);
        }

        [HttpPost]
        [Route("enderecos")]
        public HttpResponseMessage PostEndereco(Endereco endereco)
        {
            if (endereco == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _repository.Add(endereco);

                int id = endereco.Id;

                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    $"Falha ao incluir o endereço. {ex.Message}");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}