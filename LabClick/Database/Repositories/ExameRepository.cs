using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LabClick.Database.Repositories
{
    public class ExameRepository
    {
        protected sql_LabClickEntities db;
        public ExameRepository()
        {
            db = new sql_LabClickEntities();
        }
        public void Salvar_Exame(EXAME model)
        {
            EXAME exame = new EXAME();
            exame.data_inserido = DateTime.Now;
            exame.data_modificado = DateTime.Now;
            db.EXAME.Add(exame);
            db.SaveChanges();
           

        }    
        
               
    }
}