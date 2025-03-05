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
    public class PhuongXasADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public PhuongXasADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/PhuongXasAD
        public async Task<IActionResult> Index()
        {
            var BatDongSanDKCNContext = _context.PhuongXas.Include(p => p.IdQuanhuyenNavigation);
            return View(await BatDongSanDKCNContext.ToListAsync());
        }

        // GET: Admin/PhuongXasAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongXa = await _context.PhuongXas
                .Include(p => p.IdQuanhuyenNavigation)
                .FirstOrDefaultAsync(m => m.IdPhuongxa == id);
            if (phuongXa == null)
            {
                return NotFound();
            }

            return View(phuongXa);
        }

        // GET: Admin/PhuongXasAD/Create
        public IActionResult Create()
        {
            ViewData["IdQuanhuyen"] = new SelectList(_context.QuanHuyens, "IdQuanhuyen", "TenQuanhuyen");
            return View();
        }

        // POST: Admin/PhuongXasAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPhuongxa,TenPhuongxa,IdQuanhuyen")] PhuongXa phuongXa)
        {
            ModelState.Remove("IdQuanhuyenNavigation");
            if (ModelState.IsValid)
            {
                _context.Add(phuongXa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdQuanhuyen"] = new SelectList(_context.QuanHuyens, "IdQuanhuyen", "TenQuanhuyen", phuongXa.IdQuanhuyen);
            return View(phuongXa);
        }

        // GET: Admin/PhuongXasAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongXa = await _context.PhuongXas.FindAsync(id);
            if (phuongXa == null)
            {
                return NotFound();
            }
            ViewData["IdQuanhuyen"] = new SelectList(_context.QuanHuyens, "IdQuanhuyen", "TenQuanhuyen", phuongXa.IdQuanhuyen);
            return View(phuongXa);
        }

        // POST: Admin/PhuongXasAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhuongxa,TenPhuongxa,IdQuanhuyen")] PhuongXa phuongXa)
        {
            ModelState.Remove("IdQuanhuyenNavigation");
            if (id != phuongXa.IdPhuongxa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phuongXa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhuongXaExists(phuongXa.IdPhuongxa))
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
            ViewData["IdQuanhuyen"] = new SelectList(_context.QuanHuyens, "IdQuanhuyen", "TenQuanhuyen", phuongXa.IdQuanhuyen);
            return View(phuongXa);
        }

        // GET: Admin/PhuongXasAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongXa = await _context.PhuongXas
                .Include(p => p.IdQuanhuyenNavigation)
                .FirstOrDefaultAsync(m => m.IdPhuongxa == id);
            if (phuongXa == null)
            {
                return NotFound();
            }

            return View(phuongXa);
        }

        // POST: Admin/PhuongXasAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phuongXa = await _context.PhuongXas.FindAsync(id);
            if (phuongXa != null)
            {
                _context.PhuongXas.Remove(phuongXa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhuongXaExists(int id)
        {
            return _context.PhuongXas.Any(e => e.IdPhuongxa == id);
        }
    }
}
