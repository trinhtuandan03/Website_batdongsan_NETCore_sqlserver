using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBatDongSan_DKCN.Models;
using WebBatDongSan_DKCN.ViewModels;

namespace WebBatDongSan_DKCN.Controllers
{
    public class DSBaiVietSanPhamController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public DSBaiVietSanPhamController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        //Task #01. Tính năng Xem Danh Sách Bài Viết Của Người Dùng
        [HttpGet]
        public async Task<IActionResult> DanhSachBaiVietUser()
        {
            // Lấy UserId từ session
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                TempData["ThongBao"] = "Không thể xác định người dùng đang đăng nhập.";
                return RedirectToAction("Login", "Account"); // Redirect nếu không tìm thấy UserId trong session
            }
            // Load danh sách menu
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();

            // Load Danh Sách Bài Viết theo userId
            var baiViets = await _context.BaiViets
             .Where(m => m.IdUser == userId.Value)
             .Include(m => m.IdLoaibaivietNavigation) // Loại Bài Viết
             .Include(m => m.IdTrangthaiNavigation)   // Trạng Thái
             .OrderByDescending(m => m.NgayTao)
             .ToListAsync();


            // Set thông báo
            TempData["ThongBao"] = baiViets.Any()
                  ? "Danh sách bài viết được tải thành công."
                  : "Không tìm thấy bài viết nào cho người dùng này.";

            // Tạo ViewModel
            var viewModel = new DSBaiVietSanPhamViewModels
            {
                BaiViets = baiViets,
                Menus = menus
            };

            return View(viewModel);
        }

        //Task #02. Tính năng Xem Danh Sách Sản Phẩm Của Người Dùng
        [HttpGet]
        public async Task<IActionResult> DanhSachSanPhamUser()
        {
            // Lấy UserId từ session
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                TempData["ThongBao"] = "Không thể xác định người dùng đang đăng nhập.";
                return RedirectToAction("Login", "Account"); // Redirect nếu không tìm thấy UserId trong session
            }
            // Load danh sách menu
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();

            // Load Danh Sách Sản Phẩm theo userId
            var sanPhams = await _context.SanPhams
             .Where(m => m.IdUser == userId.Value)
             .Include(m => m.IdTrangthaiNavigation) // Include Trang Thai navigation property
             .OrderByDescending(m => m.NgayDang)
             .ToListAsync();

            // Set thông báo
            TempData["ThongBao"] = sanPhams.Any()
               ? "Danh sách sản phẩm được tải thành công."
               : "Không tìm thấy sản phẩm nào cho người dùng này.";

            // Tạo ViewModel
            var viewModel = new DSBaiVietSanPhamViewModels
            {
                SanPhams = sanPhams,
                Menus = menus
            };

            return View(viewModel);
        }
    }
}
