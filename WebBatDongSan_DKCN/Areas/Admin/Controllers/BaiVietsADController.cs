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
    public class BaiVietsADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public BaiVietsADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/BaiVietsAD
        public async Task<IActionResult> Index()
        {
            var BatDongSanDKCNContext = _context.BaiViets.Include(b => b.IdLoaibaivietNavigation).Include(b => b.IdTrangthaiNavigation).Include(b => b.IdUserNavigation);
            return View(await BatDongSanDKCNContext.ToListAsync());
        }

        // GET: Admin/BaiVietsAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiViet = await _context.BaiViets
                .Include(b => b.IdLoaibaivietNavigation)
                .Include(b => b.IdTrangthaiNavigation)
                .Include(b => b.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdBaiviet == id);
            if (baiViet == null)
            {
                return NotFound();
            }

            return View(baiViet);
        }

        // GET: Admin/BaiVietsAD/Create
        public IActionResult Create()
        {
            ViewData["IdLoaibaiviet"] = new SelectList(_context.LoaiBaiViets, "IdLoaibaiviet", "Tenloaibaiviet");
            ViewData["IdTrangthai"] = new SelectList(_context.TrangThais, "IdTrangthai", "TenTrangthai");
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "HoTen");
            return View();
        }

        // POST: Admin/BaiVietsAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBaiviet,TieuDe,NoiDung,NgayTao,IdUser,IdLoaibaiviet,IdTrangthai")] BaiViet baiViet)
        {
            // Loại bỏ các navigation properties khỏi ModelState
            ModelState.Remove("IdLoaibaivietNavigation");
            ModelState.Remove("IdTrangthaiNavigation");
            ModelState.Remove("IdUserNavigation");
            if (ModelState.IsValid)
            {
                _context.Add(baiViet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaibaiviet"] = new SelectList(_context.LoaiBaiViets, "IdLoaibaiviet", "Tenloaibaiviet", baiViet.IdLoaibaiviet);
            ViewData["IdTrangthai"] = new SelectList(_context.TrangThais, "IdTrangthai", "TenTrangthai", baiViet.IdTrangthai);
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "HoTen", baiViet.IdUser);
            return View(baiViet);
        }

        // GET: Admin/BaiVietsAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiViet = await _context.BaiViets.FindAsync(id);
            if (baiViet == null)
            {
                return NotFound();
            }
            ViewData["IdLoaibaiviet"] = new SelectList(_context.LoaiBaiViets, "IdLoaibaiviet", "Tenloaibaiviet", baiViet.IdLoaibaiviet);
            ViewData["IdTrangthai"] = new SelectList(_context.TrangThais, "IdTrangthai", "TenTrangthai", baiViet.IdTrangthai);
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "HoTen", baiViet.IdUser);
            return View(baiViet);
        }

        // POST: Admin/BaiVietsAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBaiviet,TieuDe,NoiDung,NgayTao,IdUser,IdLoaibaiviet,IdTrangthai")] BaiViet baiViet)
        {
            if (id != baiViet.IdBaiviet)
            {
                return NotFound();
            }
            // Loại bỏ các navigation properties khỏi ModelState
            ModelState.Remove("IdLoaibaivietNavigation");
            ModelState.Remove("IdTrangthaiNavigation");
            ModelState.Remove("IdUserNavigation");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baiViet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaiVietExists(baiViet.IdBaiviet))
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
            ViewData["IdLoaibaiviet"] = new SelectList(_context.LoaiBaiViets, "IdLoaibaiviet", "Tenloaibaiviet", baiViet.IdLoaibaiviet);
            ViewData["IdTrangthai"] = new SelectList(_context.TrangThais, "IdTrangthai", "TenTrangthai", baiViet.IdTrangthai);
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "HoTen", baiViet.IdUser);
            return View(baiViet);
        }

        // GET: Admin/BaiVietsAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiViet = await _context.BaiViets
                .Include(b => b.IdLoaibaivietNavigation)
                .Include(b => b.IdTrangthaiNavigation)
                .Include(b => b.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdBaiviet == id);
            if (baiViet == null)
            {
                return NotFound();
            }

            return View(baiViet);
        }

        // POST: Admin/BaiVietsAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baiViet = await _context.BaiViets.FindAsync(id);
            if (baiViet != null)
            {
                _context.BaiViets.Remove(baiViet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaiVietExists(int id)
        {
            return _context.BaiViets.Any(e => e.IdBaiviet == id);
        }
    }
}
