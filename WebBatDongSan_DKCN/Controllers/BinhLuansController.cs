using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBatDongSan_DKCN.Models;

namespace WebBatDongSan_DKCN.Controllers
{
    public class BinhLuansController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public BinhLuansController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: BinhLuans
        public async Task<IActionResult> Index()
        {
            var batDongSanDKCNContext = _context.BinhLuans.Include(b => b.BinhLuanCha).Include(b => b.IdBaivietNavigation).Include(b => b.IdSanphamNavigation).Include(b => b.IdUserNavigation);
            return View(await batDongSanDKCNContext.ToListAsync());
        }

        // GET: BinhLuans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuans
                .Include(b => b.BinhLuanCha)
                .Include(b => b.IdBaivietNavigation)
                .Include(b => b.IdSanphamNavigation)
                .Include(b => b.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdBinhluan == id);
            if (binhLuan == null)
            {
                return NotFound();
            }

            return View(binhLuan);
        }

        // GET: BinhLuans/Create
        public IActionResult Create()
        {
            ViewData["BinhLuanChaId"] = new SelectList(_context.BinhLuans, "IdBinhluan", "IdBinhluan");
            ViewData["IdBaiviet"] = new SelectList(_context.BaiViets, "IdBaiviet", "IdBaiviet");
            ViewData["IdSanpham"] = new SelectList(_context.SanPhams, "IdSanpham", "IdSanpham");
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "IdUser");
            return View();
        }

        // POST: BinhLuans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBinhluan,NoiDung,IdSanpham,IdBaiviet,NgayTao,IdUser,BinhLuanChaId")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(binhLuan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BinhLuanChaId"] = new SelectList(_context.BinhLuans, "IdBinhluan", "IdBinhluan", binhLuan.BinhLuanChaId);
            ViewData["IdBaiviet"] = new SelectList(_context.BaiViets, "IdBaiviet", "IdBaiviet", binhLuan.IdBaiviet);
            ViewData["IdSanpham"] = new SelectList(_context.SanPhams, "IdSanpham", "IdSanpham", binhLuan.IdSanpham);
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "IdUser", binhLuan.IdUser);
            return View(binhLuan);
        }

        // GET: BinhLuans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuans.FindAsync(id);
            if (binhLuan == null)
            {
                return NotFound();
            }
            ViewData["BinhLuanChaId"] = new SelectList(_context.BinhLuans, "IdBinhluan", "IdBinhluan", binhLuan.BinhLuanChaId);
            ViewData["IdBaiviet"] = new SelectList(_context.BaiViets, "IdBaiviet", "IdBaiviet", binhLuan.IdBaiviet);
            ViewData["IdSanpham"] = new SelectList(_context.SanPhams, "IdSanpham", "IdSanpham", binhLuan.IdSanpham);
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "IdUser", binhLuan.IdUser);
            return View(binhLuan);
        }

        // POST: BinhLuans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBinhluan,NoiDung,IdSanpham,IdBaiviet,NgayTao,IdUser,BinhLuanChaId")] BinhLuan binhLuan)
        {
            if (id != binhLuan.IdBinhluan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binhLuan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinhLuanExists(binhLuan.IdBinhluan))
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
            ViewData["BinhLuanChaId"] = new SelectList(_context.BinhLuans, "IdBinhluan", "IdBinhluan", binhLuan.BinhLuanChaId);
            ViewData["IdBaiviet"] = new SelectList(_context.BaiViets, "IdBaiviet", "IdBaiviet", binhLuan.IdBaiviet);
            ViewData["IdSanpham"] = new SelectList(_context.SanPhams, "IdSanpham", "IdSanpham", binhLuan.IdSanpham);
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "IdUser", binhLuan.IdUser);
            return View(binhLuan);
        }

        // GET: BinhLuans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuans
                .Include(b => b.BinhLuanCha)
                .Include(b => b.IdBaivietNavigation)
                .Include(b => b.IdSanphamNavigation)
                .Include(b => b.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdBinhluan == id);
            if (binhLuan == null)
            {
                return NotFound();
            }

            return View(binhLuan);
        }

        // POST: BinhLuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var binhLuan = await _context.BinhLuans.FindAsync(id);
            if (binhLuan != null)
            {
                _context.BinhLuans.Remove(binhLuan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinhLuanExists(int id)
        {
            return _context.BinhLuans.Any(e => e.IdBinhluan == id);
        }
    }
}
