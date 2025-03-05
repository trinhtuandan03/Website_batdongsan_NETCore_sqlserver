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
    public class LichSuGiaoDichesController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public LichSuGiaoDichesController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        //Task #01. Tính năng Xem Danh Sách Lịch Sử Giao Dich Đăng Sản Phẩm và Bài Viết
        [HttpGet]
        public async Task<IActionResult> DanhSachLichSuGiaoDich()
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

            // Load lịch sử giao dịch theo userId
            var lichSuGiaoDiches = await _context.LichSuGiaoDiches
                .Where(gd => gd.IdUser == userId.Value)
                .OrderByDescending(gd => gd.ThoiGianGiaoDich)
                .ToListAsync();

            // Set thông báo
            TempData["ThongBao"] = lichSuGiaoDiches.Any()
                ? "Danh sách lịch sử giao dịch được tải thành công."
                : "Không tìm thấy giao dịch nào cho người dùng này.";

            // Tạo ViewModel
            var viewModel = new LichSuGiaoDichesViewModels
            {
                LichSuGiaoDiches = lichSuGiaoDiches,
                Menus = menus
            };

            return View(viewModel);
        }
    }
}
