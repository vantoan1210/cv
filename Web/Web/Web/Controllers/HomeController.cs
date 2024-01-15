using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Web.Db;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private SanPhamDb sanPhamDb = new SanPhamDb();
        private DanhMucSanPhamDb danhMucSanPhamDb = new DanhMucSanPhamDb();
        private LoaiSanPhamDb loaiSanPhamDb = new LoaiSanPhamDb();
        private ChiTietSPDb chiTietSPDb = new ChiTietSPDb();
        private GioHangDb gioHangDb = new GioHangDb();
        public ActionResult Index()
        {
            List<SanPham> listSanPham = sanPhamDb.SanPhamList();
            List<SanPham> listSanPhamByID = sanPhamDb.LaySanPhamTheoMaDanhMuc(1);
            List<SanPham> listSanPhamBan = sanPhamDb.LaySanPhamTheoMaDanhMuc(7);
            List<SanPham> listSanPhamTheoMaLoaiSP = sanPhamDb.LaySanPhamTheoMaLoaiSP(5);
            if (Session["UserID"] != null)
            {
                List<GioHang> listGioHang = gioHangDb.GioHang((int)Session["UserID"]);

                if (listGioHang != null)
                {
                    int tongSanPham = listGioHang.Count;
                    ViewBag.giohang = tongSanPham;
                }
            }
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            ViewBag.listSanPham = listSanPham;
            ViewBag.listSanPhamByID = listSanPhamByID;
            ViewBag.listSanPhamTheoMaLoaiSP = listSanPhamTheoMaLoaiSP;
            ViewBag.listSanPhamBan = listSanPhamBan;

            return View();
        }
        [HttpGet]
        [Route("Shop")]
        public ActionResult Shop(int? madanhmuc, int? maLoaiSP)
        {
            if (madanhmuc.HasValue)
            {
                List<SanPham> listSanPham = sanPhamDb.LaySanPhamTheoMaDanhMuc(madanhmuc.Value);
                DanhMucSanPham tenDM = danhMucSanPhamDb.LayDanhMucTheoMaDanhMuc(madanhmuc.Value);
                ViewBag.tenDm = tenDM;
                ViewBag.listSanPham = listSanPham;
            }
            else if (maLoaiSP.HasValue)
            {
                List<SanPham> listSanPham = sanPhamDb.LaySanPhamTheoMaLoaiSP(maLoaiSP.Value);
                LoaiSanPham tenLoai = loaiSanPhamDb.LayLoaiSanPhamTheoMaLoai(maLoaiSP.Value);
                ViewBag.tenLoai = tenLoai;
                ViewBag.listSanPham = listSanPham;
            }
            else
            {
                List<SanPham> listSanPham = sanPhamDb.SanPhamList();
                ViewBag.listSanPham = listSanPham;
            }

            List<DanhMucSanPham> listDMSanPham = danhMucSanPhamDb.LayDMSanPham();
            List<LoaiSanPham> listLoaiSP = loaiSanPhamDb.LayLoaiSanPham();

            ViewBag.listDMSanPham = listDMSanPham;
            ViewBag.listLoaiSP = listLoaiSP;

            return View("Shop");
        }
        [HttpGet]
        [Route("ShopList")]
        public ActionResult ShopList(int? madanhmuc, int? maLoaiSP, int? ID, string search)
        {
            if (madanhmuc.HasValue)
            {
                List<SanPham> listSanPham = sanPhamDb.LaySanPhamTheoMaDanhMuc(madanhmuc.Value);
                DanhMucSanPham tenDM = danhMucSanPhamDb.LayDanhMucTheoMaDanhMuc(madanhmuc.Value);
                ViewBag.tenDm = tenDM;
                ViewBag.listSanPham = listSanPham;
            }
            else if (maLoaiSP.HasValue)
            {
                List<SanPham> listSanPham = sanPhamDb.LaySanPhamTheoMaLoaiSP(maLoaiSP.Value);
                LoaiSanPham tenLoai = loaiSanPhamDb.LayLoaiSanPhamTheoMaLoai(maLoaiSP.Value);
                ViewBag.tenLoai = tenLoai;
                ViewBag.listSanPham = listSanPham;
            }
            else if (!string.IsNullOrEmpty(search))
            {
                List<SanPham> listSanPham = sanPhamDb.SearchSanPham(search);
                ViewBag.listSanPham = listSanPham;
            }
            else
            {
                List<SanPham> listSanPham = sanPhamDb.SanPhamList();
                ViewBag.listSanPham = listSanPham;
            }

            List<DanhMucSanPham> listDMSanPham = danhMucSanPhamDb.LayDMSanPham();
            List<LoaiSanPham> listLoaiSP = loaiSanPhamDb.LayLoaiSanPham();

            ViewBag.listDMSanPham = listDMSanPham;
            ViewBag.listLoaiSP = listLoaiSP;

            return View("ShopList");
        }
        public ActionResult ThongTinSanPham(int ID)
        {
            SanPham sanPhamTheoID = sanPhamDb.LaySanPhamTheoID(ID);
            List<SanPham> listSanPham = sanPhamDb.SanPhamList();
            List<ChiTietSanPham> chiTietSanPhams = chiTietSPDb.ChiTietSPTheoMaSP(ID);
            DanhMucSanPham dmSanPham = danhMucSanPhamDb.LayDanhMucTheoMaDanhMuc(sanPhamTheoID.MaDanhMuc);
            LoaiSanPham loaiSanPham = loaiSanPhamDb.LayLoaiSanPhamTheoMaLoai(sanPhamTheoID.MaLoaiSanPham);
            ViewBag.loaiSanPham = loaiSanPham;
            ViewBag.dmSanPham = dmSanPham;
            ViewBag.chiTietSanPhams = chiTietSanPhams;
            ViewBag.listSanPham = listSanPham;
            ViewBag.sanPham = sanPhamTheoID;
            string a = sanPhamTheoID.MoTa;

            return View();
        }
        public ActionResult KetQuaTimKiem(string search)
        {
            List<SanPham> listSanPham = sanPhamDb.SanPhamList();
            var ketQua = listSanPham.Where(sp => sp.Name.Contains(search)).ToList();
            if (ketQua != null) ViewBag.KetQuaTimKiem = ketQua;

            return View("KetQuaTimKiem");
        }
        [HttpPost]
        public ActionResult AddToCart(int sanPhamID)
        {
            using (WebDecorEntities context = new WebDecorEntities())
            {
                string insertSql = "INSERT INTO GioHang (IDSanPham, SoLuong, UserID) VALUES (@sanPhamID, 1, @UserID)";
                SqlParameter[] parameters =
                {
                        new SqlParameter("@sanPhamID", sanPhamID),
                        new SqlParameter("@UserID", Session["UserID"])
                };
                context.Database.ExecuteSqlCommand(insertSql, parameters);
            }
            return Json(new { success = true });
        }
        [HttpPost]
        public ActionResult AddToCarts(int sanPhamID, int soLuong)
        {
            using (WebDecorEntities context = new WebDecorEntities())
            {
                string insertSql = "INSERT INTO GioHang (IDSanPham, SoLuong, UserID) VALUES (@sanPhamID, @soLuong, @UserID)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@sanPhamID", sanPhamID),
                    new SqlParameter("@soLuong", soLuong),
                    new SqlParameter("@UserID", Session["UserID"])
                };
                context.Database.ExecuteSqlCommand(insertSql, parameters);
            }
            return Json(new { success = true });
         }

        public ActionResult Gioithieu()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult ChinhSachBanHang()
        {
            return View();
        }
    }
}