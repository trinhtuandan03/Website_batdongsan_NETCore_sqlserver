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
    public class TinhThanhsADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public TinhThanhsADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/TinhThanhsAD
        public async Task<IActionResult> Index()
        {
            return View(await _context.TinhThanhs.ToListAsync());
        }

        // GET: Admin/TinhThanhsAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinhThanh = await _context.TinhThanhs
                .FirstOrDefaultAsync(m => m.IdTinhthanh == id);
            if (tinhThanh == null)
            {
                return NotFound();
            }

            return View(tinhThanh);
        }

        // GET: Admin/TinhThanhsAD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TinhThanhsAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTinhthanh,TenTinhthanh")] TinhThanh tinhThanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinhThanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tinhThanh);
        }

        // GET: Admin/TinhThanhsAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinhThanh = await _context.TinhThanhs.FindAsync(id);
            if (tinhThanh == null)
            {
                return NotFound();
            }
            return View(tinhThanh);
        }

        // POST: Admin/TinhThanhsAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTinhthanh,TenTinhthanh")] TinhThanh tinhThanh)
        {
            if (id != tinhThanh.IdTinhthanh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinhThanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinhThanhExists(tinhThanh.IdTinhthanh))
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
            return View(tinhThanh);
        }

        // GET: Admin/TinhThanhsAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinhThanh = await _context.TinhThanhs
                .FirstOrDefaultAsync(m => m.IdTinhthanh == id);
            if (tinhThanh == null)
            {
                return NotFound();
            }

            return View(tinhThanh);
        }

        // POST: Admin/TinhThanhsAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tinhThanh = await _context.TinhThanhs.FindAsync(id);
            if (tinhThanh != null)
            {
                _context.TinhThanhs.Remove(tinhThanh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinhThanhExists(int id)
        {
            return _context.TinhThanhs.Any(e => e.IdTinhthanh == id);
        }
    }
}
