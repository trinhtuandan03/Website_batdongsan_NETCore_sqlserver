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
    public class QuanHuyensADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public QuanHuyensADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/QuanHuyensAD
        public async Task<IActionResult> Index()
        {
            var batDongSanDKCNContext = _context.QuanHuyens.Include(q => q.IdTinhthanhNavigation);
            return View(await batDongSanDKCNContext.ToListAsync());
        }

        // GET: Admin/QuanHuyensAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanHuyen = await _context.QuanHuyens
                .Include(q => q.IdTinhthanhNavigation)
                .FirstOrDefaultAsync(m => m.IdQuanhuyen == id);
            if (quanHuyen == null)
            {
                return NotFound();
            }

            return View(quanHuyen);
        }

        // GET: Admin/QuanHuyensAD/Create
        public IActionResult Create()
        {
            ViewData["IdTinhthanh"] = new SelectList(_context.TinhThanhs, "IdTinhthanh", "TenTinhthanh");
            return View();
        }

        // POST: Admin/QuanHuyensAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdQuanhuyen,TenQuanhuyen,IdTinhthanh")] QuanHuyen quanHuyen)
        {
            ModelState.Remove("IdTinhthanhNavigation");
            if (ModelState.IsValid)
            {
                _context.Add(quanHuyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTinhthanh"] = new SelectList(_context.TinhThanhs, "IdTinhthanh", "TenTinhthanh", quanHuyen.IdTinhthanh);
            return View(quanHuyen);
        }

        // GET: Admin/QuanHuyensAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanHuyen = await _context.QuanHuyens.FindAsync(id);
            if (quanHuyen == null)
            {
                return NotFound();
            }
            ViewData["IdTinhthanh"] = new SelectList(_context.TinhThanhs, "IdTinhthanh", "TenTinhthanh", quanHuyen.IdTinhthanh);
            return View(quanHuyen);
        }

        // POST: Admin/QuanHuyensAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdQuanhuyen,TenQuanhuyen,IdTinhthanh")] QuanHuyen quanHuyen)
        {
            ModelState.Remove("IdTinhthanhNavigation");
            if (id != quanHuyen.IdQuanhuyen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanHuyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanHuyenExists(quanHuyen.IdQuanhuyen))
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
            ViewData["IdTinhthanh"] = new SelectList(_context.TinhThanhs, "IdTinhthanh", "TenTinhthanh", quanHuyen.IdTinhthanh);
            return View(quanHuyen);
        }

        // GET: Admin/QuanHuyensAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanHuyen = await _context.QuanHuyens
                .Include(q => q.IdTinhthanhNavigation)
                .FirstOrDefaultAsync(m => m.IdQuanhuyen == id);
            if (quanHuyen == null)
            {
                return NotFound();
            }

            return View(quanHuyen);
        }

        // POST: Admin/QuanHuyensAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quanHuyen = await _context.QuanHuyens.FindAsync(id);
            if (quanHuyen != null)
            {
                _context.QuanHuyens.Remove(quanHuyen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanHuyenExists(int id)
        {
            return _context.QuanHuyens.Any(e => e.IdQuanhuyen == id);
        }
    }
}
