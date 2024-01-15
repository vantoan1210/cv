using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Db
{
    public partial class GioHangDb
    {
        public List<GioHang> GioHang(int userID)
        {
            List<GioHang> result = new List<GioHang>();
            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM GioHang WHERE UserID = @UserID";
                result = context.Database.SqlQuery<GioHang>(sql, new SqlParameter("@UserID", userID)).ToList();
            }
            return result;
        }
    }
}