using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S3Train.Service;
using S3Train.Domain;

namespace S3Train.Service
{
    public class Account
    {
        private ApplicationDbContext db = null;

        public Account()
        {
            db = new ApplicationDbContext();
        }
        public bool Login(string Email, string Password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Username", Email),
                new SqlParameter("@Password", Password)
            };
            var res = db.Database.SqlQuery<bool>("Account_Login @Username, @Password", sqlParams).SingleOrDefault();
            return res;
        }
    }
}
