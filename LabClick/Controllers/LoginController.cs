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
            Session["Id"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                var user = _repository.GetByEmail(usuario.Email);

                if (user != null)
                {      
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

                        Session["Nome"] = user.Nome;
                        Session["Id"] = user.Id;
                        Session["Perfil"] = user.Perfil;

                        if (user is UsuarioLaboratorio)
                        {
                            UsuarioLaboratorio userLab = user as UsuarioLaboratorio;
                            Session["LaboratorioId"] = userLab.LaboratorioId;

                            ViewBag.usuario = "Laboratorio";
                            return RedirectToAction("Testes", "Teste");
                        }

                        else if (user is UsuarioClinica)
                        {
                            UsuarioClinica userClinica = user as UsuarioClinica;
                            Session["ClinicaId"] = userClinica.ClinicaId;

                            ViewBag.usuario = "Clinica";
                            return RedirectToAction("Index", "Paciente");
                        }

                        else
                        {
                            return RedirectToAction("Index", "Dashboard");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Senha informada Inválida.");
                        return View(new Usuario());
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-mail informado inválido.");
                    return View(new Usuario());
                }
                
            }
            
            return View(usuario);
        }
    }
}
