using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebBatDongSan_DKCN.ViewModels;
using WebBatDongSan_DKCN.Models;
using WebBatDongSan_DKCN.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace WebBatDongSan_DK.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMomoService _momoService;
        private readonly BatDongSanDKCNContext _context;

        public HomeController(BatDongSanDKCNContext context, IMomoService momoService)
        {
            _momoService = momoService;
            _context = context;
        }
        //Task #01. Tính năng trang chủ 
        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var sanPhams = await _context.SanPhams.ToListAsync();

            var sanPhamNhaMatTien = await _context.SanPhams.Where(sp => sp.IdLoaibds == 1).ToListAsync();
            var tenLoaiNhaMatTien = await _context.LoaiBds.Where(lb => lb.IdLoaibds == 1).Select(lb => lb.TenLoaibds).FirstOrDefaultAsync();

            var sanPhamNhaChungCu = await _context.SanPhams.Where(sp => sp.IdLoaibds == 1).ToListAsync();
            var tenLoaiNhaChungCu = await _context.LoaiBds.Where(lb => lb.IdLoaibds == 1).Select(lb => lb.TenLoaibds).FirstOrDefaultAsync();

            var viewModel = new HomeViewModel
            {
                Menus = menus,
                SanPhams = sanPhams,
                SanPhamNhaMatTien = sanPhamNhaMatTien,
                SanPhamNhaChungCu = sanPhamNhaChungCu,
                TenLoaiNhaMatTien = tenLoaiNhaMatTien,
                TenLoaiNhaChungCu = tenLoaiNhaChungCu
            };

            return View(viewModel);
        }

        public async Task<IActionResult> CreatePaymentUrl()
        {
            // Tạo view model để truyền dữ liệu cho form
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            // Lấy thông tin Hoten từ ession
            var hoTen = HttpContext.Session.GetString("HoTen");
            var viewModel = new HomeViewModel
            {
                FullName = hoTen,
                Menus = menus,
            };
            return View(viewModel);
        }

        [HttpPost]
        [Route("CreatePaymentUrl")]
        public async Task<IActionResult> CreatePaymentUrl(ThongTinGiaoDichNapTien model)
        {
            var response = await _momoService.CreatePaymentAsync(model);
            // Chuyển hướng người dùng tới trang thanh toán Momo với mã QR
            return Redirect(response.PayUrl); // Redirect đến URL thanh toán của Momo
        }


        [HttpGet]
        public async Task<IActionResult> PaymentCallBack()
        {
            // Lấy dữ liệu menu từ cơ sở dữ liệu
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();

            // Xử lý phản hồi thanh toán từ Momo
            var response = _momoService.PaymentExecuteAsync(HttpContext.Request.Query);

            // Cập nhật thông tin thanh toán vào người dùng
            var userId = HttpContext.Session.GetInt32("UserId");
            var user = await _context.NguoiDungs.FirstOrDefaultAsync(u => u.IdUser == userId);

            if (user != null)
            {
            
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
            }

            // Tạo ViewModel để truyền dữ liệu vào View
            var viewModel = new HomeViewModel
            {
                Menus = menus,
                PhanHoiNapTienMomos = new List<PhanHoiNapTienMomo> { response },
                OrderId = response.OrderId,
                OrderInfo = response.OrderInfo,
                Amount = response.Amount,
                CreatedAt = response.CreatedAt
            };

            // Trả về View với ViewModel chứa dữ liệu thanh toán và menu
            return View(viewModel);
        }

        //--------------------------------------------------------------

        public async Task<IActionResult> ThongTinThanhVien()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new HomeViewModel
            {
                Menus = menus,      
            };
            return View(viewModel);
        }


        public async Task<IActionResult> _SlidePartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> _ProductPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> _BlogPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }

       
    }
}