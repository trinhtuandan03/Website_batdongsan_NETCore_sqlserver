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
    public class GiayToTaiLieuxADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public GiayToTaiLieuxADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/GiayToTaiLieuxAD
        public async Task<IActionResult> Index()
        {
            return View(await _context.GiayToTaiLieus.ToListAsync());
        }

        // GET: Admin/GiayToTaiLieuxAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giayToTaiLieu = await _context.GiayToTaiLieus
                .FirstOrDefaultAsync(m => m.IdGiaytoTailieu == id);
            if (giayToTaiLieu == null)
            {
                return NotFound();
            }

            return View(giayToTaiLieu);
        }

        // GET: Admin/GiayToTaiLieuxAD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/GiayToTaiLieuxAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGiaytoTailieu,TenGiaytoTailieu")] GiayToTaiLieu giayToTaiLieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giayToTaiLieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giayToTaiLieu);
        }

        // GET: Admin/GiayToTaiLieuxAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giayToTaiLieu = await _context.GiayToTaiLieus.FindAsync(id);
            if (giayToTaiLieu == null)
            {
                return NotFound();
            }
            return View(giayToTaiLieu);
        }

        // POST: Admin/GiayToTaiLieuxAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGiaytoTailieu,TenGiaytoTailieu")] GiayToTaiLieu giayToTaiLieu)
        {
            if (id != giayToTaiLieu.IdGiaytoTailieu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giayToTaiLieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiayToTaiLieuExists(giayToTaiLieu.IdGiaytoTailieu))
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
            return View(giayToTaiLieu);
        }

        // GET: Admin/GiayToTaiLieuxAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giayToTaiLieu = await _context.GiayToTaiLieus
                .FirstOrDefaultAsync(m => m.IdGiaytoTailieu == id);
            if (giayToTaiLieu == null)
            {
                return NotFound();
            }

            return View(giayToTaiLieu);
        }

        // POST: Admin/GiayToTaiLieuxAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giayToTaiLieu = await _context.GiayToTaiLieus.FindAsync(id);
            if (giayToTaiLieu != null)
            {
                _context.GiayToTaiLieus.Remove(giayToTaiLieu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiayToTaiLieuExists(int id)
        {
            return _context.GiayToTaiLieus.Any(e => e.IdGiaytoTailieu == id);
        }
    }
}
