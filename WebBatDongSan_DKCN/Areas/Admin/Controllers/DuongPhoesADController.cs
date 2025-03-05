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
    public class DuongPhoesADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public DuongPhoesADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/DuongPhoesAD
        public async Task<IActionResult> Index()
        {
            var BatDongSanDKCNContext = _context.DuongPhos.Include(d => d.IdPhuongxaNavigation);
            return View(await BatDongSanDKCNContext.ToListAsync());
        }

        // GET: Admin/DuongPhoesAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duongPho = await _context.DuongPhos
                .Include(d => d.IdPhuongxaNavigation)
                .FirstOrDefaultAsync(m => m.IdDuongpho == id);
            if (duongPho == null)
            {
                return NotFound();
            }

            return View(duongPho);
        }

        // GET: Admin/DuongPhoesAD/Create
        public IActionResult Create()
        {
            ViewData["IdPhuongxa"] = new SelectList(_context.PhuongXas, "IdPhuongxa", "TenPhuongxa");
            return View();
        }

        // POST: Admin/DuongPhoesAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDuongpho,TenDuongpho,IdPhuongxa")] DuongPho duongPho)
        {
            ModelState.Remove("IdPhuongxaNavigation");
            if (ModelState.IsValid)
            {
                _context.Add(duongPho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPhuongxa"] = new SelectList(_context.PhuongXas, "IdPhuongxa", "TenPhuongxa", duongPho.IdPhuongxa);
            return View(duongPho);
        }

        // GET: Admin/DuongPhoesAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duongPho = await _context.DuongPhos.FindAsync(id);
            if (duongPho == null)
            {
                return NotFound();
            }
            ViewData["IdPhuongxa"] = new SelectList(_context.PhuongXas, "IdPhuongxa", "TenPhuongxa", duongPho.IdPhuongxa);
            return View(duongPho);
        }

        // POST: Admin/DuongPhoesAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDuongpho,TenDuongpho,IdPhuongxa")] DuongPho duongPho)
        {
            ModelState.Remove("IdPhuongxaNavigation");
            if (id != duongPho.IdDuongpho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duongPho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuongPhoExists(duongPho.IdDuongpho))
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
            ViewData["IdPhuongxa"] = new SelectList(_context.PhuongXas, "IdPhuongxa", "TenPhuongxa", duongPho.IdPhuongxa);
            return View(duongPho);
        }

        // GET: Admin/DuongPhoesAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duongPho = await _context.DuongPhos
                .Include(d => d.IdPhuongxaNavigation)
                .FirstOrDefaultAsync(m => m.IdDuongpho == id);
            if (duongPho == null)
            {
                return NotFound();
            }

            return View(duongPho);
        }

        // POST: Admin/DuongPhoesAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duongPho = await _context.DuongPhos.FindAsync(id);
            if (duongPho != null)
            {
                _context.DuongPhos.Remove(duongPho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuongPhoExists(int id)
        {
            return _context.DuongPhos.Any(e => e.IdDuongpho == id);
        }
    }
}
