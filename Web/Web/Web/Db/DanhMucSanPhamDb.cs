using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Db
{
    public partial class DanhMucSanPhamDb
    {
        public List<DanhMucSanPham> LayDMSanPham()
        {
            List<DanhMucSanPham> result = new List<DanhMucSanPham>();

            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM DanhMucSanPham";
                result = context.Database.SqlQuery<DanhMucSanPham>(sql, "").ToList();
            }
            return result;
        }
        public DanhMucSanPham LayDanhMucTheoMaDanhMuc(int? ID)
        {
            DanhMucSanPham result = null;

            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM DanhMucSanPham WHERE ID = @ID";
                result = context.Database.SqlQuery<DanhMucSanPham>(sql, new SqlParameter("@ID", ID)).SingleOrDefault();
            }
            return result;
        }
    }
}