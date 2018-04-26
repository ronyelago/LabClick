using LabClick.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabClick.Database.Repositories
{
    public class LoginRepository : BaseRepository<LOGIN>
    {
        protected sql_LabClickEntities db;
        public LoginRepository()
        {
            db = new sql_LabClickEntities();

        }
       
    }
}