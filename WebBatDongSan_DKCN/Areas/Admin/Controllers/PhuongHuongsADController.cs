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
    public class PhuongHuongsADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public PhuongHuongsADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/PhuongHuongsAD
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhuongHuongs.ToListAsync());
        }

        // GET: Admin/PhuongHuongsAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongHuong = await _context.PhuongHuongs
                .FirstOrDefaultAsync(m => m.IdPhuonghuong == id);
            if (phuongHuong == null)
            {
                return NotFound();
            }

            return View(phuongHuong);
        }

        // GET: Admin/PhuongHuongsAD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhuongHuongsAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPhuonghuong,TenPhuonghuong")] PhuongHuong phuongHuong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phuongHuong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phuongHuong);
        }

        // GET: Admin/PhuongHuongsAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongHuong = await _context.PhuongHuongs.FindAsync(id);
            if (phuongHuong == null)
            {
                return NotFound();
            }
            return View(phuongHuong);
        }

        // POST: Admin/PhuongHuongsAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhuonghuong,TenPhuonghuong")] PhuongHuong phuongHuong)
        {
            if (id != phuongHuong.IdPhuonghuong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phuongHuong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhuongHuongExists(phuongHuong.IdPhuonghuong))
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
            return View(phuongHuong);
        }

        // GET: Admin/PhuongHuongsAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongHuong = await _context.PhuongHuongs
                .FirstOrDefaultAsync(m => m.IdPhuonghuong == id);
            if (phuongHuong == null)
            {
                return NotFound();
            }

            return View(phuongHuong);
        }

        // POST: Admin/PhuongHuongsAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phuongHuong = await _context.PhuongHuongs.FindAsync(id);
            if (phuongHuong != null)
            {
                _context.PhuongHuongs.Remove(phuongHuong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhuongHuongExists(int id)
        {
            return _context.PhuongHuongs.Any(e => e.IdPhuonghuong == id);
        }
    }
}
