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
    public class KhachHangController : Controller
    {
        private ThongTinKhachHangDb thongTinKhachHangDb = new ThongTinKhachHangDb();
        private GioHangDb gioHangDb = new GioHangDb();
        private SanPhamDb sanPhamDb = new SanPhamDb();
        public ActionResult Index(int id)
        {
            ThongTinKhachHang khachHang = thongTinKhachHangDb.LayThongTinKhachHangTheoUserID(id);
            if (khachHang != null) ViewBag.khachHang = khachHang;

            return View();
        }
        #region Đăng Kí và Đăng Nhập
        public ActionResult DangNhap()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            else if (TempData["FailedMessage"] != null)
            {
                ViewBag.FailedMessage = TempData["FailedMessage"];
            }


            return View();
        }
        public ActionResult DangKi()
        {
            if (TempData["FailedMessage"] != null)
            {
                ViewBag.FailedMessage = TempData["FailedMessage"];
            }
            return View();
        }
        [HttpPost]
        public ActionResult LuuThongTinDangKi(string tenDangNhap, string matKhau, string nhapLaiMatKhau)
        {

            if (matKhau != nhapLaiMatKhau)
            {
                TempData["FailedMessage"] = "Mat khau khong khop vui long thuc hien lai!";
                return RedirectToAction("DangKi");
            }
            using (WebDecorEntities context = new WebDecorEntities())
            {
                if (context.Users.Any(u => u.Name == tenDangNhap))
                {
                    TempData["FailedMessage"] = "Ten dang nhap da ton tai! Vui long nhap ten khac.";
                    return RedirectToAction("DangKi");
                }
                else
                {
                    string insertSql = "INSERT INTO Users (Name, Password) VALUES (@Name, @Password)";
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Name", tenDangNhap),
                        new SqlParameter("@Password", matKhau)
                    };
                    context.Database.ExecuteSqlCommand(insertSql, parameters);
                }
            }
            TempData["SuccessMessage"] = "Dang ki thanh cong!";
            return RedirectToAction("DangNhap");
        }
        [HttpPost]
        public ActionResult XuLyDangNhap(string tenDangNhap, string matKhau)
        {
            using (WebDecorEntities context = new WebDecorEntities())
            {
                var user = context.Users.FirstOrDefault(u => u.Name == tenDangNhap && u.Password == matKhau);
                if (user != null)
                {
                    Session["UserID"] = user.ID;
                    TempData["SuccessMessage"] = "Dang nhap thanh cong.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["FailedMessage"] = "Dang nhap khong thanh cong. Vui long kiem tra lai ten dang nhap hoac mat khau";
                    return RedirectToAction("DangNhap");
                }
            }
        }
        #endregion

        [HttpPost]
        public ActionResult LuuThongTinKhachHang(string tenKhachHang, string soDienThoai, string email, string diaChiNhanHang)
        {
            using (WebDecorEntities context = new WebDecorEntities())
            {

                string insertSql = "INSERT INTO ThongTinKhachHang (TenKhachHang, SoDienThoai, Email, DiaChiNhanHang, UserID) VALUES (@tenKhachHang, @soDienThoai, @email, @diaChiNhanHang, @UserID)";
                SqlParameter[] parameters =
                {
                        new SqlParameter("@tenKhachHang", tenKhachHang),
                        new SqlParameter("@soDienThoai", soDienThoai),
                        new SqlParameter("@email", email),
                        new SqlParameter("@diaChiNhanHang", diaChiNhanHang),
                        new SqlParameter("@UserID", Session["UserID"])
                };
                context.Database.ExecuteSqlCommand(insertSql, parameters);
            }
            return RedirectToAction("Index", new { id = Session["UserID"] });
        }
        [HttpPost]
        public ActionResult CapNhatThongTinKhachHang(string tenKhachHang, string soDienThoai, string email, string diaChiNhanHang)
        {
            using (WebDecorEntities context = new WebDecorEntities())
            {

                string updateSql = "UPDATE ThongTinKhachHang SET TenKhachHang = @tenKhachHang, SoDienThoai = @soDienThoai, Email = @email, DiaChiNhanHang = @diaChiNhanHang WHERE UserID = @UserID";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@tenKhachHang", tenKhachHang),
                    new SqlParameter("@soDienThoai", soDienThoai),
                    new SqlParameter("@email", email),
                    new SqlParameter("@diaChiNhanHang", diaChiNhanHang),
                    new SqlParameter("@UserID", Session["UserID"])
                };
                context.Database.ExecuteSqlCommand(updateSql, parameters);
            }
            return RedirectToAction("Index", new { id = Session["UserID"] });
        }

        [HttpPost]
        public ActionResult DangXuat()
        {
            if (Session["UserID"] != null)
            {
                Session.Remove("UserID");
                TempData["Success"] = "Dang Xuat Thanh Cong.";
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ThongTinThanhToan(int id)
        {
            List<GioHang> gioHangs = gioHangDb.GioHang(id);
            List<SanPham> sanPhams = new List<SanPham>();
            List<GioHang> gh = new List<GioHang>();
            if (gioHangs != null)
            {
                foreach (var giohang in gioHangs)
                {
                    if (giohang != null)
                    {
                        SanPham sanPham = sanPhamDb.LaySanPhamTheoIDS(giohang.IDSanPham);
                        sanPhams.Add(sanPham);
                        gh.Add(giohang);
                    }
                }
                ViewBag.gh = gh;
                ViewBag.sanPhams = sanPhams;
            }

            return View();
        }
        [HttpPost]
        public ActionResult RemoveFromCart(int ID)
        {
            try
            {
                using (WebDecorEntities context = new WebDecorEntities())
                {
                    var userID = Session["UserID"];

                    if (userID != null)
                    {
                        string deleteSql = "DELETE FROM GioHang WHERE ID = @ID AND UserID = @userID";
                        SqlParameter[] parameters =
                        {
                    new SqlParameter("@ID", ID),
                    new SqlParameter("@userID", userID)
                };

                        context.Database.ExecuteSqlCommand(deleteSql, parameters);
                    }
                }

                return RedirectToAction("ThongTinThanhToan", new { id = Session["UserID"] });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult LuuThongTinThanhToan(string hotennguoinhan, string diachi, string sodienthoai, string ghichu, string tongtien, string phuongthucthanhtoan)
        {
            using (WebDecorEntities context = new WebDecorEntities())
            {
                string updateSql = "INSERT INTO GiaoDich (UserID, HoTenNguoiNhan, DiaChiNhanHang, SoDienThoai, Ghichu, PhuongThucThanhToan, TongTien) VALUES (@UserID,@hoTenNguoiNhan, @diachi, @soDienThoai, @ghichu,@phuongthucthanhtoan,@tongtien)";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@UserID", Session["UserID"]),
                    new SqlParameter("@hoTenNguoiNhan", hotennguoinhan),
                    new SqlParameter("@diachi", diachi),
                    new SqlParameter("@soDienThoai", sodienthoai),
                    new SqlParameter("@ghichu", ghichu),
                    new SqlParameter("@tongtien", tongtien),
                    new SqlParameter("@phuongthucthanhtoan", phuongthucthanhtoan)
                };
                context.Database.ExecuteSqlCommand(updateSql, parameters);
                int userId = (int)Session["UserID"];
                var gioHangItems = context.GioHangs.Where(gh => gh.UserID == userId).ToList();

                foreach (var gioHangItem in gioHangItems)
                {
                    string insertChiTietGiaoDichSql = "INSERT INTO ChiTietGiaoDich (IDSanPham, SoLuong, UserID) VALUES (@sanPhamID, @soLuong, @UserID)";

                    SqlParameter[] parametersChiTiet =
                    {
                        new SqlParameter("@sanPhamID", gioHangItem.IDSanPham),
                        new SqlParameter("@soLuong", gioHangItem.SoLuong),
                        new SqlParameter("@UserID", gioHangItem.UserID)
                    };
                    context.Database.ExecuteSqlCommand(insertChiTietGiaoDichSql, parametersChiTiet);
                }
            }
            XoaGioHang((int)Session["UserID"]);
            return RedirectToAction("Index", "Home");
        }

        private void XoaGioHang(int userId)
        {
            using (WebDecorEntities context = new WebDecorEntities())
            {
                if (userId != null)
                {
                    string deleteSql = "DELETE FROM GioHang WHERE UserID = @userID";
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@userID", userId)
                    };
                    context.Database.ExecuteSqlCommand(deleteSql, parameters);
                }
            }
        }

        public ActionResult TinhTrangDonHang(int id)
        {
            return View();
        }
    }
}