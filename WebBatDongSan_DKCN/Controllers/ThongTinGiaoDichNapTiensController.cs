using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBatDongSan_DKCN.Models;
using WebBatDongSan_DKCN.ViewModels;
using System.Security.Claims;


namespace WebBatDongSan_DKCN.Controllers
{
    public class ThongTinGiaoDichNapTiensController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public ThongTinGiaoDichNapTiensController(BatDongSanDKCNContext context)
        {
            _context = context;
        }
        // Hiển thị danh sách nạp tiền của một user cụ thể với thông báo
        [HttpGet]
        public async Task<IActionResult> DanhSachLichSuNapTien()
        {
            // Lấy UserId từ session
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                TempData["ThongBao"] = "Không thể xác định người dùng đang đăng nhập.";
                return RedirectToAction("Login", "Account"); // Redirect nếu không tìm thấy UserId trong session
            }

            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var thongTinGiaoDichNapTiens = await _context.ThongTinGiaoDichNapTiens
                .Where(t => t.IdUser == userId.Value)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            TempData["ThongBao"] = thongTinGiaoDichNapTiens.Any()
                ? "Danh sách lịch sử nạp tiền được tải thành công."
                : "Không tìm thấy giao dịch nào cho người dùng này.";

            var viewModel = new ThongTinGiaoDichNapTiensViewModels
            {
                ThongTinGiaoDichNapTiens = thongTinGiaoDichNapTiens,
                Menus = menus
            };

            return View(viewModel);
        }


    }
}
