using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Threading.Tasks;
using WebBatDongSan_DKCN.Models;
using WebBatDongSan_DKCN.ViewModels;

namespace WebBatDongSan_DK.Controllers
{
    public class BaiVietController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public BaiVietController(BatDongSanDKCNContext context)
        {
            _context = context;
        }
        [HttpGet]
        //Task #01. Tính năng Xem Danh Sách Bài Viết
        public async Task<IActionResult> DanhSachBaiViet()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var baiViets = await _context.BaiViets.ToListAsync();

            var viewModel = new BaiVietsViewModels
            {
                BaiViets = baiViets,
                Menus = menus
            };
            return View(viewModel);
        }
        //Task #01. Tính năng Xem Chi tiết bài Viết
        // Thêm mới ChiTietBaiViet để ChiTietBaiViet.cshtml sử dụng để xem Chi Tiết Bài Viết chi-tiet-bai-viet
        public async Task<IActionResult> ChiTietBaiViet(int id)
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var binhluans = await _context.BinhLuans.OrderBy(m => m.IdBinhluan).ToListAsync();
            var baiViet = _context.BaiViets.Include(bv => bv.BinhLuans).FirstOrDefault(bv => bv.IdBaiviet == id);

            if (baiViet == null)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = "Product Error",
                };
                return View("Error", errorViewModel);
            }

            var viewModel = new BaiVietsViewModels
            {
                BaiViets = new List<BaiViet> { baiViet },
                Menus = menus,
                BinhLuans = baiViet.BinhLuans.OrderBy(bl => bl.NgayTao).ToList()
            };

            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> ThemBaiViet()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var baiViets = await _context.BaiViets.ToListAsync();
            var loaiBaiviet = await _context.LoaiBaiViets.OrderBy(m => m.Tenloaibaiviet).ToListAsync();
            var nguoidung = await _context.NguoiDungs.OrderBy(m => m.HoTen).ToListAsync();
            var trangthai = await _context.TrangThais.OrderBy(m => m.TenTrangthai).ToListAsync();


            var viewModel = new BaiVietsViewModels
            {
                Menus = menus,
                BaiViets = baiViets,
                loaiBaiViets = loaiBaiviet,
                nguoiDungs = nguoidung,
                trangThais = trangthai,

            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemBaiViet(BaiVietsViewModels model)
        {
            var viewModel = new BaiVietsViewModels
            {
                ThemBaiViet = model.ThemBaiViet,
                // Sao chép giá trị id vào Selected
                SelectedLoaiBaiViet = model.SelectedLoaiBaiViet,
            };

            if (!ModelState.IsValid)
            {
                // Lấy IdUser từ session (ID người dùng sau khi đăng nhập)
                var userId = HttpContext.Session.GetInt32("UserId");
                if (userId.HasValue)
                {
                    model.ThemBaiViet.IdUser = userId.Value; // Lưu IdUser của người dùng vào SanPham

                    // Lấy thông tin người dùng
                    var user = await _context.NguoiDungs.FindAsync(userId.Value);
                    if (user != null)
                    {
                        const decimal soTienTru = 10000m;

                        // Kiểm tra số dư
                        if (user.SoTien >= soTienTru)
                        {
                            // Trừ 10.000 VND từ số dư của người dùng
                            user.SoTien -= soTienTru;

                            //==============
                            // Lưu bài viết mới vào cơ sở dữ liệu (BaiViet)
                            model.ThemBaiViet.IdLoaibaiviet = model.SelectedLoaiBaiViet;
                            model.ThemBaiViet.IdTrangthai = 1;

                            _context.BaiViets.Add(model.ThemBaiViet);
                            await _context.SaveChangesAsync();

                            // Nhận ID BaiViet mới được thêm vào (LichSuGiaoDich)
                            int newBaiVietId = model.ThemBaiViet.IdBaiviet;
                            //==============


                            // Ghi lịch sử giao dịch
                            var giaoDich = new LichSuGiaoDich
                            {
                                IdUser = userId.Value,
                                IdBaiviet = newBaiVietId,
                                SoTien = -soTienTru,
                                LoaiGiaoDich = "Trừ tiền khi thêm bài viết",
                                ThoiGianGiaoDich = DateTime.Now
                            };

                            _context.LichSuGiaoDiches.Add(giaoDich);
                            _context.NguoiDungs.Update(user);

                            // Lưu thay đổi vào cơ sở dữ liệu
                            await _context.SaveChangesAsync();

                            // Cập nhật Claims với số tiền mới
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                                new Claim(ClaimTypes.Name, user.TenTruyCap),
                                new Claim(ClaimTypes.Role, user.LoaiTaiKhoanId.ToString()),
                                new Claim("SoTien", user.SoTien.ToString()) // Cập nhật SoTien mới vào Claim
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var authProperties = new AuthenticationProperties { };
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                            TempData["ThongBao"] = "Bài viết đã được thêm thành công. Số dư của bạn đã bị trừ 10.000 VND.";
                            return Redirect("/bai-viet");
                        }
                        else
                        {
                            TempData["ThongBao"] = "Số dư không đủ để thêm bài viết.";
                            return RedirectToAction("Index", "BaiViet");
                        }
                    }
                    else
                    {
                        TempData["ThongBao"] = "Không tìm thấy thông tin người dùng.";
                        return RedirectToAction("Index", "Home");
                    }
                }
               
            }

            return View(viewModel);
        }
        // Partial View for Menu

        // Add a new comment or reply
        [HttpPost]
        public IActionResult LuuBinhLuan(int idBaiViet, string noiDung, int? idBinhLuanCha)
        {
            if (string.IsNullOrWhiteSpace(noiDung))
            {
                TempData["Error"] = "Nội dung bình luận không được để trống!";
                return RedirectToAction("ChiTietBaiViet", new { id = idBaiViet });
            }

            // Lấy IdUser từ session (ID người dùng sau khi đăng nhập)
            //var userId = HttpContext.Session.GetInt32("UserId");
            //if (!userId.HasValue)
            //{
            //    TempData["Error"] = "Bạn cần đăng nhập để thực hiện bình luận.";
            //    return Redirect("/dang-nhap"); // Redirect đến trang đăng nhập nếu cần
            //}

            var binhLuan = new BinhLuan
            {
                IdBaiviet = idBaiViet,
                NoiDung = noiDung,
                NgayTao = DateTime.Now,
                IdUser = 1, // Replace with logged-in user ID
                //IdUser = userId.Value,
                BinhLuanChaId = idBinhLuanCha
            };

            _context.BinhLuans.Add(binhLuan);
            _context.SaveChanges();

            return RedirectToAction("ChiTietBaiViet", new { id = idBaiViet });
        }

        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }

        // Partial View for Blog
        public async Task<IActionResult> _BlogPartial()
        {
            return PartialView();
        }
    }
}