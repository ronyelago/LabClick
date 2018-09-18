using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabClick.Api.Controllers
{
    [RoutePrefix("imagem")]
    public class TesteImagemController : ApiController
    {
        private readonly TesteImagemRepository repository = new TesteImagemRepository();

        [Route("getByTesteId={testeId}")]
        public HttpResponseMessage GetByTesteId(int testeId)
        {
            var imagemTeste = repository.GetByTesteId(testeId);

            return Request.CreateResponse(HttpStatusCode.OK, imagemTeste);
        }

        [Route("new")]
        public HttpResponseMessage New(TesteImagem testeImagem)
        {
            if (testeImagem == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                repository.Add(testeImagem);

                int id = testeImagem.Id;

                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    $"Falha ao incluir a imagem do teste. {ex.Message}");
            }
        }
    }
}
