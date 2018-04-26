using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabClick.Database;
using LabClick.Repository;
using System.IO;

namespace LabClick.Controllers
{
    public class ResultadoController : Controller
    {
        private sql_LabClickEntities db = new sql_LabClickEntities();
        // GET: Resultado
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GerarPDF(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESULTADO resultado = db.RESULTADO.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            return View(resultado);
        }
        [HttpPost, ActionName("GerarPDF")]
        [ValidateAntiForgeryToken]
        public ActionResult GeracaoPdf(int id)
        {
            
            /*from e in db.TESTE
                   join a in db.LABORATORIO
                   on e.id_clinica equals login_id
                   join p in db.PACIENTE
                   on e.id_paciente equals p.id
                   where e.status == "Em avaliação"
                   select e*/
            var dados = (from res in db.RESULTADO
                         join tes in db.TESTE
                         on res.id_teste equals tes.id
                         join exa in db.EXAME
                         on res.id_exame equals exa.id
                         join pac in db.PACIENTE
                         on tes.id_paciente equals pac.id
                         join cli in db.CLINICA
                         on pac.id_clinica equals cli.id
                         join lab in db.LABORATORIO
                         on cli.id_laboratorio equals lab.id
                         where res.id == id
                         select new  {
                             idres = res.id,
                             nomelab = lab.nome_laboratorio,
                             assinaturalab = lab.assinatura,
                             nomeclinica = cli.nome_clinica,
                             cepclinica = cli.cep,
                             endclinica = cli.endereco,
                             clicid = cli.cidade,
                             cliuf = cli.estado,
                             clicnpj = cli.CNPJ,
                             clilogo = cli.logotipo,
                             descexam = exa.descricao,
                             laudado = res.laudo,
                             tabela = res.tabela,
                             nomepac = pac.nome_paciente

                         }).SingleOrDefault();

            using (var doc = new PdfSharp.Pdf.PdfDocument())
            {
                var page = doc.AddPage();
                var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);
                var font = new PdfSharp.Drawing.XFont("Verdana", 12);

                string imageheader = Server.MapPath(dados.clilogo);

                graphics.DrawImage(PdfSharp.Drawing.XImage.FromFile(imageheader), 10, 0);

                textFormatter.DrawString("Nome Clinica:" + dados.nomeclinica, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(200, 30, page.Width, page.Height));
                textFormatter.DrawString("Endereço:" + dados.endclinica, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(200, 50, page.Width, page.Height));
                textFormatter.DrawString("CEP:" + dados.cepclinica, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(200, 70, page.Width, page.Height));
                 
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;

                string imagefooter = Server.MapPath(dados.assinaturalab);
                graphics.DrawImage(PdfSharp.Drawing.XImage.FromFile(imagefooter), 0, 730);
                
                
                string filename = "LabClickLaudoN"+dados.idres+".pdf";
                doc.Save(System.IO.Path.Combine(Server.MapPath("/Content/Uploads/Laudos/"+filename)));
                RESULTADO resultado = db.RESULTADO.Find(id);
                resultado.documento = "/Content/Uploads/Laudos/" + filename;
                db.Entry(resultado).State = EntityState.Modified;
                db.SaveChanges();               
                
                

                TempData["pdfcriado"] = "Pdf criado com sucesso!";
            }
            
            return View();
        }
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESULTADO Resultado = db.RESULTADO.Find(id);
            if (Resultado == null)
            {
                return HttpNotFound();
            }
            return View(Resultado);
        }

        // GET: Resultado/Create
        public ActionResult Create()
        {
            ViewBag.id_exame = new SelectList(db.EXAME, "id", "nome_exame");
            return View();
        }
    }
}