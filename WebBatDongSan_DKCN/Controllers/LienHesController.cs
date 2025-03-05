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
    public class LienHesController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public LienHesController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> LienHe()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();

            // Lấy thông tin từ session
            var hoTen = HttpContext.Session.GetString("HoTen");
            var email = HttpContext.Session.GetString("Email");

            var viewModel = new LienHesViewModels
            {
                Menus = menus,
                GuiLienHe = new LienHe
                {
                    HoTen = hoTen, // Truyền giá trị họ tên vào GuiLienHe hiện thị trên LienHe.cshtml
                    Email = email  // Truyền giá trị email vào GuiLienHe hiện thị trên LienHe.cshtml
                }
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LienHe(LienHesViewModels model)
        {

            var viewModel = new LienHesViewModels
            {
                GuiLienHe = model.GuiLienHe,
            };
            if (!ModelState.IsValid)
            {
                // Lấy IdUser từ session (ID người dùng sau khi đăng nhập)
                var userId = HttpContext.Session.GetInt32("UserId");
                if (userId.HasValue)
                {
                    model.GuiLienHe.IdUser = userId.Value; // Lưu IdUser của người dùng vào thông tin liên hệ
                }
                _context.LienHes.Add(viewModel.GuiLienHe);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Gửi liên hệ thành công!";
                return Redirect("/lien-he");

            }
            return View(model);
        }

    }
}