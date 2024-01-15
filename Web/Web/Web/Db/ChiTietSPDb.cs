using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Db
{
    public partial class ChiTietSPDb {
        public List<ChiTietSanPham> ChiTietSPTheoMaSP(int ID)
        {
            List<ChiTietSanPham> result = new List<ChiTietSanPham>();

            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM ChiTietSanPham WHERE MaSanPham = @ID";
                result = context.Database.SqlQuery<ChiTietSanPham>(sql, new SqlParameter("@ID", ID)).ToList();
            }
            return result;
        }
    }
}