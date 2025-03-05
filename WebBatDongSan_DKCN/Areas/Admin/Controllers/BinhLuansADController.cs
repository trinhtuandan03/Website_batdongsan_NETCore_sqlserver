using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBatDongSan_DKCN.Models;

namespace WebBatDongSan_DKCN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "3")]
    public class BinhLuansADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public BinhLuansADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/BinhLuansAD
        public async Task<IActionResult> Index()
        {
            var BatDongSanDKCNContext = _context.BinhLuans.Include(b => b.IdBaivietNavigation).Include(b => b.IdSanphamNavigation).Include(b => b.IdUserNavigation);
            return View(await BatDongSanDKCNContext.ToListAsync());
        }

        // GET: Admin/BinhLuansAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuans
                .Include(b => b.IdBaivietNavigation)
                .Include(b => b.IdSanphamNavigation)
                .Include(b => b.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdBinhluan == id);
            if (binhLuan == null)
            {
                return NotFound();
            }

            return View(binhLuan);
        }

        // GET: Admin/BinhLuansAD/Create
        public IActionResult Create()
        {
            ViewData["IdBaiviet"] = new SelectList(_context.BaiViets, "IdBaiviet", "TieuDe");
            ViewData["IdSanpham"] = new SelectList(_context.SanPhams, "IdSanpham", "TieuDeSanpham");
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "HoTen");
            return View();
        }

        // POST: Admin/BinhLuansAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBinhluan,NoiDung,IdSanpham,IdBaiviet,NgayTao,IdUser")] BinhLuan binhLuan)
        {


            ModelState.Remove("IdBaivietNavigation");
            ModelState.Remove("IdSanphamNavigation");
            ModelState.Remove("IdUserNavigation");
            if (ModelState.IsValid)
            {
                _context.Add(binhLuan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBaiviet"] = new SelectList(_context.BaiViets, "IdBaiviet", "TieuDe", binhLuan.IdBaiviet);
            ViewData["IdSanpham"] = new SelectList(_context.SanPhams, "IdSanpham", "TieuDeSanpham", binhLuan.IdSanpham);
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "HoTen", binhLuan.IdUser);
            return View(binhLuan);
        }

        // GET: Admin/BinhLuansAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuans.FindAsync(id);
            if (binhLuan == null)
            {
                return NotFound();
            }
            ViewData["IdBaiviet"] = new SelectList(_context.BaiViets, "IdBaiviet", "TieuDe", binhLuan.IdBaiviet);
            ViewData["IdSanpham"] = new SelectList(_context.SanPhams, "IdSanpham", "TieuDeSanpham", binhLuan.IdSanpham);
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "HoTen", binhLuan.IdUser);
            return View(binhLuan);
        }

        // POST: Admin/BinhLuansAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBinhluan,NoiDung,IdSanpham,IdBaiviet,NgayTao,IdUser")] BinhLuan binhLuan)
        {
            ModelState.Remove("IdBaivietNavigation");
            ModelState.Remove("IdSanphamNavigation");
            ModelState.Remove("IdUserNavigation");
            if (id != binhLuan.IdBinhluan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binhLuan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinhLuanExists(binhLuan.IdBinhluan))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBaiviet"] = new SelectList(_context.BaiViets, "IdBaiviet", "TieuDe", binhLuan.IdBaiviet);
            ViewData["IdSanpham"] = new SelectList(_context.SanPhams, "IdSanpham", "TieuDeSanpham", binhLuan.IdSanpham);
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "HoTen", binhLuan.IdUser);
            return View(binhLuan);
        }

        // GET: Admin/BinhLuansAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuans
                .Include(b => b.IdBaivietNavigation)
                .Include(b => b.IdSanphamNavigation)
                .Include(b => b.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdBinhluan == id);
            if (binhLuan == null)
            {
                return NotFound();
            }

            return View(binhLuan);
        }

        // POST: Admin/BinhLuansAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var binhLuan = await _context.BinhLuans.FindAsync(id);
            if (binhLuan != null)
            {
                _context.BinhLuans.Remove(binhLuan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinhLuanExists(int id)
        {
            return _context.BinhLuans.Any(e => e.IdBinhluan == id);
        }
    }
}
