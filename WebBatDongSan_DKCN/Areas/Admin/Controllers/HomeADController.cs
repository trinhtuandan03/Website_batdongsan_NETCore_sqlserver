using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebBatDongSan_DKCN.Models;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DK.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "3")]
    public class HomeADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public HomeADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: /Admin/BaiVietAD/Index
        public async Task<IActionResult> Index()
        {
            return View();
        }


        // POST: /Admin/BaiVietAD/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
        {
           
            return View();
        }

        public async Task<IActionResult> Edit()
        {

            return View();
        }

        public async Task<IActionResult> Details()
        {

            return View();
        }

        public async Task<IActionResult> Delete()
        {
            return View();
        }
    }
}
