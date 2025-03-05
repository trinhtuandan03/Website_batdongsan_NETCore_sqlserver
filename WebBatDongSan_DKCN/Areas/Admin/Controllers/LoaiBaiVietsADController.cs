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
    public class LoaiBaiVietsADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public LoaiBaiVietsADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiBaiVietsAD
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiBaiViets.ToListAsync());
        }

        // GET: Admin/LoaiBaiVietsAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiBaiViet = await _context.LoaiBaiViets
                .FirstOrDefaultAsync(m => m.IdLoaibaiviet == id);
            if (loaiBaiViet == null)
            {
                return NotFound();
            }

            return View(loaiBaiViet);
        }

        // GET: Admin/LoaiBaiVietsAD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiBaiVietsAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoaibaiviet,Tenloaibaiviet")] LoaiBaiViet loaiBaiViet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiBaiViet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiBaiViet);
        }

        // GET: Admin/LoaiBaiVietsAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiBaiViet = await _context.LoaiBaiViets.FindAsync(id);
            if (loaiBaiViet == null)
            {
                return NotFound();
            }
            return View(loaiBaiViet);
        }

        // POST: Admin/LoaiBaiVietsAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoaibaiviet,Tenloaibaiviet")] LoaiBaiViet loaiBaiViet)
        {
            if (id != loaiBaiViet.IdLoaibaiviet)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiBaiViet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiBaiVietExists(loaiBaiViet.IdLoaibaiviet))
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
            return View(loaiBaiViet);
        }

        // GET: Admin/LoaiBaiVietsAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiBaiViet = await _context.LoaiBaiViets
                .FirstOrDefaultAsync(m => m.IdLoaibaiviet == id);
            if (loaiBaiViet == null)
            {
                return NotFound();
            }

            return View(loaiBaiViet);
        }

        // POST: Admin/LoaiBaiVietsAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiBaiViet = await _context.LoaiBaiViets.FindAsync(id);
            if (loaiBaiViet != null)
            {
                _context.LoaiBaiViets.Remove(loaiBaiViet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiBaiVietExists(int id)
        {
            return _context.LoaiBaiViets.Any(e => e.IdLoaibaiviet == id);
        }
    }
}
