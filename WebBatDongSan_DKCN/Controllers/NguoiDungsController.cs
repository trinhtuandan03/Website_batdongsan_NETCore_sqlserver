using Microsoft.AspNetCore.Mvc;
using WebBatDongSan_DKCN.Models;
using WebBatDongSan_DKCN.ViewModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;


namespace WebBatDongSan_DKCN.Controllers
{
    public class NguoiDungsController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public NguoiDungsController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // Task #01. Tính năng Đăng Ký Tài Khoản
        [HttpGet]
        public async Task<IActionResult> DangKy()
        {
            var loaiTaiKhoans = await _context.LoaiTaiKhoanUsers.Where(m => m.IdLoaitk == 1 || m.IdLoaitk == 2).OrderBy(m => m.TenLoaitk).ToListAsync();

            var viewModel = new NguoiDungsViewModel
            {
                LoaiTaiKhoanUsers = loaiTaiKhoans,
            };
            ViewBag.HideMenuAndFooter = true;
            return View(viewModel);
        }

        // Cập nhật UserController.cs, thêm hàm xử lý cho sự kiện đăng ký.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DangKy(NguoiDungsViewModel model)
        {
            var loaiTaiKhoans = await _context.LoaiTaiKhoanUsers.OrderBy(m => m.TenLoaitk).ToListAsync();

            var viewModel = new NguoiDungsViewModel
            {
                LoaiTaiKhoanUsers = loaiTaiKhoans,
                DangKy = model.DangKy,
                SelectedLoaiTaiKhoanId = model.SelectedLoaiTaiKhoanId // Sao chép giá trị id loại tài khoản đã chọn từ form
            };
            if (!ModelState.IsValid)
            {
                var existingUser = await _context.NguoiDungs.FirstOrDefaultAsync(u => u.TenTruyCap == model.DangKy.TenTruyCap);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập đã tồn tại.";
                    return View(viewModel);
                }
                model.DangKy.MatKhau = BCrypt.Net.BCrypt.HashPassword(model.DangKy.MatKhau); // Băm mật khẩu trước khi lưu vào cơ sở dữ liệu
                // Lưu giá trị id loại tài khoản đã chọn vào cột loai_tai_khoan_id của bảng NguoiDung
                model.DangKy.LoaiTaiKhoanId = model.SelectedLoaiTaiKhoanId;
                _context.NguoiDungs.Add(model.DangKy);
                await _context.SaveChangesAsync();
                //return RedirectToAction("Login", "User");
                return Redirect("/dang-nhap");
            }
            return View(viewModel);
        }

        //------------------------------------------------------------------------------
        // Task #02. Tính năng Đăng nhập tài Khoản
        [HttpGet]
        public async Task<IActionResult> DangNhap()
        {
            ViewBag.HideMenuAndFooter = true;
            return View();
        }
        // Thêm hàm xử lý cho sự kiện đăng nhập.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DangNhap(NguoiDungsViewModel model)
        {
            var viewModel = new NguoiDungsViewModel
            {
                DangKy = model.DangKy,
            };
            if (model.DangKy != null)
            {
                var user = await _context.NguoiDungs.FirstOrDefaultAsync(u => u.TenTruyCap == model.DangKy.TenTruyCap);
                if (user != null && BCrypt.Net.BCrypt.Verify(model.DangKy.MatKhau, user.MatKhau)) // Kiểm tra mật khẩu băm
                {
                    // Lưu thông tin người dùng vào session
                    HttpContext.Session.SetInt32("UserId", user.IdUser);
                    HttpContext.Session.SetString("TenTruyCap", user.TenTruyCap ?? ""); // Lưu tên truy cập
                    HttpContext.Session.SetString("HoTen", user.HoTen ?? "");          // Lưu họ tên
                    HttpContext.Session.SetString("Email", user.Email ?? "");          // Lưu email
                    HttpContext.Session.SetString("SDT", user.Sdt ?? "");               // Lưu email
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()), // Lưu IdUser của người dùng vào claim // Tạo Biến để lưu trữ IdUser của người dùng sau khi đăng nhập
                        new Claim(ClaimTypes.Name, user.TenTruyCap),
                        new Claim(ClaimTypes.Role, user.LoaiTaiKhoanId.ToString()),
                        new Claim("SoTien", user.SoTien?.ToString() ?? "0") // Lưu SoTien vào claim
                    };
                    var claimsIdentity = new ClaimsIdentity(
                     claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                    };
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                    if (user != null && user.LoaiTaiKhoanId.ToString() == "3") // Chuyển đổi LoaiTaiKhoanId sang kiểu string trước khi so sánh
                    {
                        return Redirect("/Admin");
                        //return RedirectToAction("Index", "_LayoutAdmin", new { area = "Admin" }); // Chuyển hướng đến trang admin nếu có LoaiTaiKhoanId == "3"
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }
        //Task #04. Tính năng đăng xuất
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        //------------------------------------------------------------------------------
        // Task #03. Tính năng xem thông tin người dùng
        [HttpGet]
        public async Task<IActionResult> ThongTinNguoiDung()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var user = await _context.NguoiDungs.FirstOrDefaultAsync(u => u.IdUser == userId);
            var loaiTaiKhoanUsers = await _context.LoaiTaiKhoanUsers.ToListAsync();

            // Lấy dữ liệu menu từ cơ sở dữ liệu
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();

            var viewModel = new NguoiDungsViewModel
            {
                Menus = menus,
                DangKy = user,
                LoaiTaiKhoanUsers = loaiTaiKhoanUsers
            };
            return View(viewModel);
        }



        //--------------------------------------------------------------
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> _BlogPartial()
        {
            return PartialView();
        }
    }
}
