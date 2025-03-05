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
    public class LienHesADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public LienHesADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/LienHesAD
        public async Task<IActionResult> Index()
        {
            var batDongSanDKCNContext = _context.LienHes.Include(l => l.IdUserNavigation);
            return View(await batDongSanDKCNContext.ToListAsync());
        }

        // GET: Admin/LienHesAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lienHe = await _context.LienHes
                .Include(l => l.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdLienHe == id);
            if (lienHe == null)
            {
                return NotFound();
            }

            return View(lienHe);
        }

        // GET: Admin/LienHesAD/Create
        public IActionResult Create()
        {
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "TenTruyCap");
            return View();
        }

        // POST: Admin/LienHesAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLienHe,TieuDe,NoiDung,ThoiGianGui,IdUser,HoTen,Email")] LienHe lienHe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lienHe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "TenTruyCap", lienHe.IdUser);
            return View(lienHe);
        }

        // GET: Admin/LienHesAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lienHe = await _context.LienHes.FindAsync(id);
            if (lienHe == null)
            {
                return NotFound();
            }
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "TenTruyCap", lienHe.IdUser);
            return View(lienHe);
        }

        // POST: Admin/LienHesAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLienHe,TieuDe,NoiDung,ThoiGianGui,IdUser,HoTen,Email")] LienHe lienHe)
        {
            if (id != lienHe.IdLienHe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lienHe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LienHeExists(lienHe.IdLienHe))
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
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "TenTruyCap", lienHe.IdUser);
            return View(lienHe);
        }

        // GET: Admin/LienHesAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lienHe = await _context.LienHes
                .Include(l => l.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdLienHe == id);
            if (lienHe == null)
            {
                return NotFound();
            }

            return View(lienHe);
        }

        // POST: Admin/LienHesAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lienHe = await _context.LienHes.FindAsync(id);
            if (lienHe != null)
            {
                _context.LienHes.Remove(lienHe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LienHeExists(int id)
        {
            return _context.LienHes.Any(e => e.IdLienHe == id);
        }
    }
}
