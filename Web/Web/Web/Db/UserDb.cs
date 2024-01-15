using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Db
{
    public partial class UserDb
    {
        public List<User> GetUsersByID(int ID)
        {
            List<User> result = new List<User>();

            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM Users WHERE ID = @ID";
                result = context.Database.SqlQuery<User>(sql, new SqlParameter("@ID", ID)).ToList();
            }

            return result;
        }
    }
}