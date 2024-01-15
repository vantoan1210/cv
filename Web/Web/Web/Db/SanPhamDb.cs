using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.Models;


namespace Web.Db
{
    public partial class SanPhamDb
    {
        public List<SanPham> SanPhamList()
        {
            List<SanPham> result = new List<SanPham>();

            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM SanPham";
                result = context.Database.SqlQuery<SanPham>(sql, "").ToList();
            }
            return result;
        }
        public List<SanPham> LaySanPhamTheoMaDanhMuc(int madanhmuc)
        {
            List<SanPham> result = new List<SanPham>();
            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM SanPham WHERE MaDanhMuc = @MaDanhMuc";
                result = context.Database.SqlQuery<SanPham>(sql, new SqlParameter("@MaDanhMuc", madanhmuc)).ToList();
            }
            return result;
        }
        public List<SanPham> LaySanPhamTheoMaLoaiSP(int maLoaiSP) 
        {
            List<SanPham> result = new List<SanPham>();
            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM SanPham WHERE MaLoaiSanPham = @MaLoaiSanPham";
                result = context.Database.SqlQuery<SanPham>(sql, new SqlParameter("@MaLoaiSanPham", maLoaiSP)).ToList();
            }
            return result;
        }
        public SanPham LaySanPhamTheoID(int ID)
        {
            SanPham result = null;

            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM SanPham WHERE ID = @ID";
                result = context.Database.SqlQuery<SanPham>(sql, new SqlParameter("@ID", ID)).SingleOrDefault();
            }
            return result;
        }
        public SanPham LaySanPhamTheoIDS(int? ID)
        {
            SanPham result = null;

            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM SanPham WHERE ID = @ID";
                result = context.Database.SqlQuery<SanPham>(sql, new SqlParameter("@ID", ID)).SingleOrDefault();
            }
            return result;
        }
        public List<SanPham> SearchSanPham(string name)
        {
            List<SanPham> result = new List<SanPham>();
            using (WebDecorEntities context = new WebDecorEntities())
            {
                string sql = "SELECT * FROM SanPham WHERE Name LIKE '%' + @Name + '%'";
                result = context.Database.SqlQuery<SanPham>(sql, new SqlParameter("@Name", name)).ToList();
            }
            return result;
        }
    }
}