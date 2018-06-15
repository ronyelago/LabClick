//using LabClick.Infra.Repositories;
//using System;
//using System.Data.Entity;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;

//namespace LabClick.Controllers
//{
//    public class TesteController : Controller
//    {
//        private TesteRepository repository = new TesteRepository();

//        // GET: Teste
//        public ActionResult Index()
//        {
//            var Teste = db.TESTE.Include(t => t.EXAME).Include(t => t.CLINICA).Include(t => t.PACIENTE);

//            return View(Teste.ToList());
//        }

//        public ActionResult Criar(int? id)

//        {

//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            PACIENTE paciente = db.PACIENTE.Find(id);
//            if (paciente == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.paciente = Util.RetornaPaciente(id);
//            ViewBag.id_exame = new SelectList(db.EXAME, "id", "nome_exame");
//            ViewBag.id_clinica = new SelectList(db.CLINICA, "id", "nome_clinica");

//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Criar(TESTE teste, HttpPostedFileBase file)
//        {

//            if (ModelState.IsValid)
//            {

//                try
//                {

//                    string _FileName = Path.GetFileName(file.FileName);
//                    string _path = System.IO.Path.Combine(Server.MapPath("~/Content/Uploads"), _FileName);
//                    file.SaveAs(_path);
//                    teste.imagem_teste = "/Content/Uploads/" + _FileName;
//                }
//                catch (Exception ex)
//                {
//                    TempData["MensagemErro"] = ex.Message;
//                }
//                teste.status = "Em avaliação";
//                teste.data_inserido = DateTime.Now;
//                db.TESTE.Add(teste);
//                db.SaveChanges();

//                return RedirectToAction("Index", "Paciente");

//            }

//            ViewBag.id_exame = new SelectList(db.EXAME, "id", "nome_exame", teste.id_exame);
//            ViewBag.id_clinica = new SelectList(db.CLINICA, "id", "nome_laboratorio", teste.id_clinica);

//            return RedirectToAction("Index", "Paciente");
//        }

//        // GET: Teste/Edit/5
//        public ActionResult Avaliar(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            TESTE teste = db.TESTE.Find(id);
//            if (teste == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.id_exame = new SelectList(db.EXAME, "id", "nome_exame", teste.id_exame);
//            ViewBag.id_laboratorio = new SelectList(db.LABORATORIO, "id", "nome_clinica", teste.id_clinica);
//            ViewBag.id_paciente = new SelectList(db.PACIENTE, "id", "nome_paciente", teste.id_paciente);
//            return View(teste);
//        }

//        // POST: Teste/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Avaliar(TESTE teste, string laudo, string observacao, string vindeterminado, HttpPostedFileBase file)
//        {
//            if (ModelState.IsValid)
//            {

//                db.Entry(teste).State = EntityState.Modified;
//                db.SaveChanges();

//                RESULTADO resultado = new RESULTADO();
//                if (file == null)
//                {
//                    resultado.tabela = null;
//                }
//                else
//                {
//                    try
//                    {

//                        string _FileName = Path.GetFileName(file.FileName);
//                        string _path = System.IO.Path.Combine(Server.MapPath("~/Content/Uploads/Laudos/"), _FileName);
//                        file.SaveAs(_path);
//                        resultado.tabela = "/Content/Uploads/Laudos/" + _FileName;
//                    }
//                    catch (Exception ex)
//                    {
//                        TempData["MensagemErro"] = ex.Message;
//                    }
//                }
//                resultado.id_exame = teste.id_exame;
//                resultado.id_teste = teste.id;
//                resultado.laudo = laudo + " " + vindeterminado;
//                resultado.observacao = observacao;
//                resultado.data_inserido = DateTime.Now;
//                resultado.documento = null;
//                db.RESULTADO.Add(resultado);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.id_exame = new SelectList(db.EXAME, "id", "nome_exame", teste.id_exame);
//            ViewBag.id_laboratorio = new SelectList(db.LABORATORIO, "id", "nome_clinica", teste.id_clinica);
//            ViewBag.id_paciente = new SelectList(db.PACIENTE, "id", "nome_paciente", teste.id_paciente);

//            return View(teste);
//        }
//        // GET: Teste/Detalhes/5
//        public ActionResult Detalhes(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            TESTE Teste = db.TESTE.Find(id);
//            if (Teste == null)
//            {
//                return HttpNotFound();
//            }
//            return View(Teste);
//        }
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}