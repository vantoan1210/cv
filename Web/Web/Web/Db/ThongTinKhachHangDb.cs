using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Db
{
    public partial class ThongTinKhachHangDb
    {
        public ThongTinKhachHang LayThongTinKhachHangTheoUserID(int ID)
        {
            ThongTinKhachHang result = null;

            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM ThongTinKhachHang WHERE UserID = @ID";
                result = context.Database.SqlQuery<ThongTinKhachHang>(sql, new SqlParameter("@ID", ID)).SingleOrDefault();
            }
            return result;
        }

    }
}