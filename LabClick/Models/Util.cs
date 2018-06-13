//using System;
//using System.Data;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;

//namespace LabClick.Models
//{
//    public class Util
//    {

//        public static string validaSenha(string senha, string codVerificador)
//        {
//            string password = senha;
//            string salt = codVerificador;

//            MD5 md5 = new MD5CryptoServiceProvider();
//            byte[] bytes = md5.ComputeHash(Encoding.Unicode.GetBytes(password + salt));
//            string result = BitConverter.ToString(bytes).Replace("-", string.Empty);
//            return result;
//        }
//        public static int RetornaID(string nome)
//        {

//            sql_LabClickEntities db = new sql_LabClickEntities();
//            var id_retorno = (from u in db.LOGIN where u.email == nome select u).Single();

//            return id_retorno.id;
//        }
//        public static int RetornaID_Clinica(string nome)
//        {

//            sql_LabClickEntities db = new sql_LabClickEntities();
//            var id_retorno = (from u in db.LOGIN
//                              where u.email == nome
//                              select u).Single();

//            return Convert.ToInt32(id_retorno.id_clinica);

//        }
//        public static object RetornaPaciente(int? id)
//        {
//            sql_LabClickEntities db = new sql_LabClickEntities();
//            var result = (from u in db.PACIENTE
//                          where u.id == id
//                          select u).Single();
//            return (result);
//        }
//        public static int RetornaID_Laboratorio(string nome)
//        {

//            sql_LabClickEntities db = new sql_LabClickEntities();
//            var id_retorno = (from u in db.LOGIN where u.email == nome select u).Single();

//            return Convert.ToInt32(id_retorno.id_laboratorio);
//        }
//        public static int BuscaTestes(int login_id)
//        {
//            sql_LabClickEntities db = new sql_LabClickEntities();
//            var res = 0;
//            res = (from e in db.TESTE
//                   join a in db.LABORATORIO
//                   on e.id_clinica equals login_id
//                   join p in db.PACIENTE
//                   on e.id_paciente equals p.id
//                   where e.status == "Em avaliação"
//                   select e).Count();

//            return (res);

//        }
//        public static int BuscaPacientes_Laudos(int login_id)
//        {
//            sql_LabClickEntities db = new sql_LabClickEntities();
//            var res = 0;
//            res = (from e in db.TESTE
//                   join a in db.LABORATORIO
//                   on e.id_clinica equals login_id
//                   join p in db.PACIENTE
//                   on e.id_paciente equals p.id
//                   where e.status == "Finalizado"
//                   select e).Count();

//            return (res);

//        }
//        public static int RetornaResultado(int id)
//        {
//            sql_LabClickEntities db = new sql_LabClickEntities();
//            var query = (from r in db.RESULTADO
//                         where r.id_teste == id
//                         select r).Single();

//            return Convert.ToInt32(query.id);
//        }
//        public static object Lista_Pacientes_Lab(int? id)
//        {
//            /*select * from paciente p
//            inner join clinica c on c.id = p.id_clinica
//            inner join laboratorio l on l.id = c.id_laboratorio*/
//            sql_LabClickEntities db = new sql_LabClickEntities();
//            var query = (from p in db.PACIENTE
//                         join c in db.CLINICA
//                         on p.id_clinica equals c.id
//                         join l in db.LABORATORIO
//                         on c.id_laboratorio equals l.id
//                         select p).ToList();

//            return (query);
//        }
//        public static object Lista_Pacientes(int? id)
//        {

//            sql_LabClickEntities db = new sql_LabClickEntities();
//            var query = (from e in db.PACIENTE
//                         where e.id_clinica == id
//                         select e).ToList();

//            return (query);

//        }
//        public static int ContaTeste(int? id)
//        {
//            sql_LabClickEntities db = new sql_LabClickEntities();
//            var query = (from t in db.TESTE
//                         where t.id_paciente == id
//                         && t.status == "Em avaliação"
//                         select t).Count();

//            return (query);
//        }
//        public static int ContaTesteF(int? id)
//        {
//            sql_LabClickEntities db = new sql_LabClickEntities();
//            var query = (from t in db.TESTE
//                         where t.id_paciente == id
//                         && t.status == "Finalizado"
//                         select t).Count();

//            return (query);
//        }

//    }
//}