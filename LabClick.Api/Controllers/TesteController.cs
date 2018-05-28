using LabClick.Domain.Data.Repositories;
using LabClick.Domain.Entities;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabClick.Api.Controllers
{
    public class TesteController : ApiController
    {
        private TesteRepository _repository = new TesteRepository();

        [Route("testes")]
        public HttpResponseMessage GetTestes()
        {
            var testes = _repository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, testes);
        }

        [Route("getTesteById/{id}")]
        public HttpResponseMessage GetTesteById(int id)
        {
            var teste = _repository.GetById(id);

            return Request.CreateResponse(HttpStatusCode.OK, teste);
        }

        [HttpPost]
        [Route("testes")]
        public HttpResponseMessage PostTeste(Teste teste)
        {
            if (teste == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _repository.Add(teste);

                return Request.CreateResponse(HttpStatusCode.OK, teste);
            }
            catch (System.Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, 
                    $"Falha ao incluir o Teste.\n{ex.Message}" );
            }

        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
        }
    }
}