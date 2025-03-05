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
    public class LoaiTinsADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public LoaiTinsADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiTinsAD
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiTins.ToListAsync());
        }

        // GET: Admin/LoaiTinsAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiTin = await _context.LoaiTins
                .FirstOrDefaultAsync(m => m.IdLoaitin == id);
            if (loaiTin == null)
            {
                return NotFound();
            }

            return View(loaiTin);
        }

        // GET: Admin/LoaiTinsAD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiTinsAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoaitin,TenLoaitin")] LoaiTin loaiTin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiTin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiTin);
        }

        // GET: Admin/LoaiTinsAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiTin = await _context.LoaiTins.FindAsync(id);
            if (loaiTin == null)
            {
                return NotFound();
            }
            return View(loaiTin);
        }

        // POST: Admin/LoaiTinsAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoaitin,TenLoaitin")] LoaiTin loaiTin)
        {
            if (id != loaiTin.IdLoaitin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiTin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiTinExists(loaiTin.IdLoaitin))
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
            return View(loaiTin);
        }

        // GET: Admin/LoaiTinsAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiTin = await _context.LoaiTins
                .FirstOrDefaultAsync(m => m.IdLoaitin == id);
            if (loaiTin == null)
            {
                return NotFound();
            }

            return View(loaiTin);
        }

        // POST: Admin/LoaiTinsAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiTin = await _context.LoaiTins.FindAsync(id);
            if (loaiTin != null)
            {
                _context.LoaiTins.Remove(loaiTin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiTinExists(int id)
        {
            return _context.LoaiTins.Any(e => e.IdLoaitin == id);
        }
    }
}
