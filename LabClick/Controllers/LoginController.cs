using LabClick.Domain.Entities;
using LabClick.Infra.Repositories;
using System.Web.Mvc;
using System.Web.Security;

namespace LabClick.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioRepository _repository = new UsuarioRepository();

        [AllowAnonymous]
        // GET: Login
        // <param name="returnURL"></param>
        // <returns></returns>
        // GET: Login
        public ActionResult Index(string returnURL)
        {
            ViewBag.ReturnUrl = returnURL;
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                var user = _repository.GetByEmail(usuario.Email);

                /*Verificar se a variavel vLogin está vazia. Isso pode ocorrer caso o usuário não existe. 
                Caso não exista ele vai cair na condição else.*/
                if (user != null)
                {      /*Código abaixo verifica se a senha digitada no site é igual a senha que está sendo retornada 
                            do banco. Caso não cai direto no else*/
                    if (Equals(user.Senha, usuario.Senha))
                    {
                        FormsAuthentication.SetAuthCookie(user.Email, false);
                        if (Url.IsLocalUrl(returnUrl)
                        && returnUrl.Length > 1
                        && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//")
                        && returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        /*código abaixo cria uma session para armazenar o nome do usuário*/
                        Session["Nome"] = user.Nome;
                        /*código abaixo cria uma session para armazenar o id do usuário*/
                        Session["Id"] = user.Id;
                        //código abaixo cria uma session para armazenar o laboratório do usuário
                        Session["LaboratorioId"] = user.LaboratorioId;
                        //código abaixo cria uma session para armazenar o perfil do usuário
                        Session["Perfil"] = user.Perfil;

                        /*retorna para a tela inicial do Home*/
                        if (user.Perfil == "Administrador")

                            return RedirectToAction("Index", "Dashboard");

                        else if (user.Perfil == "Laboratorio")
                        {
                            ViewBag.usuario = "Laboratorio";
                            return RedirectToAction("IndexLab", "Paciente");
                        }
                        else if (user.Perfil == "Clinica")
                        {
                            ViewBag.usuario = "Clinica";
                            return RedirectToAction("Index", "Dashboard");
                        }
                        return RedirectToAction("Index", "Login");
                    }
                    /*Else responsável da validação da senha*/
                    else
                    {
                        /*Escreve na tela a mensagem de erro informada*/
                        ModelState.AddModelError("", "Senha informada Inválida!!!");
                        /*Retorna a tela de login*/
                        return View(new Usuario());
                    }
                }
                /*Else responsável por verificar se o usuário existe*/
                else
                {
                    /*Escreve na tela a mensagem de erro informada*/
                    ModelState.AddModelError("", "E-mail informado inválido!!!");
                    /*Retorna a tela de login*/
                    return View(new Usuario());
                }
                
            }
            /*Caso os campos não esteja de acordo com a solicitação retorna a tela de login com as mensagem dos campos*/
            return View(usuario);
        }
    }
}
