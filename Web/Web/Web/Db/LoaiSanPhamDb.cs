using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Db
{
    public partial class LoaiSanPhamDb
    {
        public List<LoaiSanPham> LayLoaiSanPham()
        {
            List<LoaiSanPham> result = new List<LoaiSanPham>();

            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM LoaiSanPham";
                result = context.Database.SqlQuery<LoaiSanPham>(sql, "").ToList();
            }
            return result;
        }
        public LoaiSanPham LayLoaiSanPhamTheoMaLoai(int? ID)
        {
            LoaiSanPham result = null;

            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM LoaiSanPham WHERE ID = @ID";
                result = context.Database.SqlQuery<LoaiSanPham>(sql, new SqlParameter("@ID", ID)).SingleOrDefault();
            }
            return result;
        }
    }
}