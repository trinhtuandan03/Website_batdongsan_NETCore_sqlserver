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
    public class LoaiBdsADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public LoaiBdsADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiBdsAD
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiBds.ToListAsync());
        }

        // GET: Admin/LoaiBdsAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiBd = await _context.LoaiBds
                .FirstOrDefaultAsync(m => m.IdLoaibds == id);
            if (loaiBd == null)
            {
                return NotFound();
            }

            return View(loaiBd);
        }

        // GET: Admin/LoaiBdsAD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiBdsAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoaibds,TenLoaibds")] LoaiBd loaiBd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiBd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiBd);
        }

        // GET: Admin/LoaiBdsAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiBd = await _context.LoaiBds.FindAsync(id);
            if (loaiBd == null)
            {
                return NotFound();
            }
            return View(loaiBd);
        }

        // POST: Admin/LoaiBdsAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoaibds,TenLoaibds")] LoaiBd loaiBd)
        {
            if (id != loaiBd.IdLoaibds)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiBd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiBdExists(loaiBd.IdLoaibds))
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
            return View(loaiBd);
        }

        // GET: Admin/LoaiBdsAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiBd = await _context.LoaiBds
                .FirstOrDefaultAsync(m => m.IdLoaibds == id);
            if (loaiBd == null)
            {
                return NotFound();
            }

            return View(loaiBd);
        }

        // POST: Admin/LoaiBdsAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiBd = await _context.LoaiBds.FindAsync(id);
            if (loaiBd != null)
            {
                _context.LoaiBds.Remove(loaiBd);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiBdExists(int id)
        {
            return _context.LoaiBds.Any(e => e.IdLoaibds == id);
        }
    }
}
