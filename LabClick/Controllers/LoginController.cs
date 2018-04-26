using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabClick.Database;
using LabClick.Repository;
using System.Web.Security;

namespace LabClick.Controllers
{
    public class LoginController : Controller
    {
        private sql_LabClickEntities db = new sql_LabClickEntities();
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
        public ActionResult Index(LOGIN login, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                using (sql_LabClickEntities db = new sql_LabClickEntities())
                {
                    var vLogin = db.LOGIN.Where(p => p.email.Equals(login.email)).FirstOrDefault();

                    /*Verificar se a variavel vLogin está vazia. Isso pode ocorrer caso o usuário não existe. 
                    Caso não exista ele vai cair na condição else.*/
                    if (vLogin != null)
                    {      /*Código abaixo verifica se a senha digitada no site é igual a senha que está sendo retornada 
                             do banco. Caso não cai direto no else*/
                        if (Equals(vLogin.senha, login.senha))
                        {
                            FormsAuthentication.SetAuthCookie(vLogin.email, false);
                            if (Url.IsLocalUrl(returnUrl)
                            && returnUrl.Length > 1
                            && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//")
                            && returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }
                            /*código abaixo cria uma session para armazenar o nome do usuário*/
                            Session["Nome"] = vLogin.nome;
                            /*código abaixo cria uma session para armazenar o sobrenome do usuário*/
                            Session["idusuario"] = vLogin.id;
                            /*retorna para a tela inicial do Home*/
                            if (vLogin.perfil == "Administrador")

                                return RedirectToAction("Index", "Dashboard");

                            else if (vLogin.perfil == "Laboratorio")
                            {
                                ViewBag.usuario = "Laboratorio";
                                return RedirectToAction("IndexLab", "Paciente");
                            }
                            else if (vLogin.perfil == "Clinica")
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
                            return View(new LOGIN());
                        }
                    }
                    /*Else responsável por verificar se o usuário existe*/
                    else
                    {
                        /*Escreve na tela a mensagem de erro informada*/
                        ModelState.AddModelError("", "E-mail informado inválido!!!");
                        /*Retorna a tela de login*/
                        return View(new LOGIN());
                    }
                }
            }
            /*Caso os campos não esteja de acordo com a solicitação retorna a tela de login com as mensagem dos campos*/
            return View(login);
        }
       
        [AllowAnonymous]
        // GET: Login
        // <param name="returnURL"></param>
        // <returns></returns>
        public ActionResult App(string returnURL)
        {
            ViewBag.ReturnUrl = returnURL;
            Session.Abandon();
            return View();
        }
        [HttpPost]
        public ActionResult App(LOGIN login, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                using (sql_LabClickEntities db = new sql_LabClickEntities())
                {
                    var vLogin = db.LOGIN.Where(p => p.email.Equals(login.email)).FirstOrDefault();

                    /*Verificar se a variavel vLogin está vazia. Isso pode ocorrer caso o usuário não existe. 
                    Caso não exista ele vai cair na condição else.*/
                    if (vLogin != null)
                    {      /*Código abaixo verifica se a senha digitada no site é igual a senha que está sendo retornada 
                             do banco. Caso não cai direto no else*/
                        if (Equals(vLogin.senha, login.senha))
                        {
                            FormsAuthentication.SetAuthCookie(vLogin.email, false);
                            if (Url.IsLocalUrl(returnUrl)
                            && returnUrl.Length > 1
                            && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//")
                            && returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }
                            /*código abaixo cria uma session para armazenar o nome do usuário*/
                            Session["Nome"] = vLogin.nome;
                            /*código abaixo cria uma session para armazenar o sobrenome do usuário*/
                            Session["idusuario"] = vLogin.id;
                            /*retorna para a tela inicial do Home*/
                            if (vLogin.perfil == "Administrador")

                                return RedirectToAction("Index", "Dashboard");

                            else if (vLogin.perfil == "Laboratorio")
                            {
                                Session["Usuario"] = vLogin.id_laboratorio;
                                return RedirectToAction("Index", "Dashboard");
                            }
                            else if (vLogin.perfil == "Clinica")
                            {
                                Session["Usuario"] = vLogin.id_clinica;
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
                            return View(new LOGIN());
                        }
                    }
                    /*Else responsável por verificar se o usuário existe*/
                    else
                    {
                        /*Escreve na tela a mensagem de erro informada*/
                        ModelState.AddModelError("", "E-mail informado Inválido!!!");
                        /*Retorna a tela de login*/
                        return View(new LOGIN());
                    }
                }
            }
            /*Caso os campos não esteja de acordo com a solicitação retorna a tela de login com as mensagem dos campos*/
            return View(login);
        }         
    }
}
