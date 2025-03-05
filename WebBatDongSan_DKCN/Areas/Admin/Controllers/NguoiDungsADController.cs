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
    public class NguoiDungsADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public NguoiDungsADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/NguoiDungsAD
        public async Task<IActionResult> Index()
        {
            var BatDongSanDKCNContext = _context.NguoiDungs.Include(n => n.LoaiTaiKhoan);
            return View(await BatDongSanDKCNContext.ToListAsync());
        }

        // GET: Admin/NguoiDungsAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDungs
                .Include(n => n.LoaiTaiKhoan)
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungsAD/Create
        public IActionResult Create()
        {
            ViewData["LoaiTaiKhoanId"] = new SelectList(_context.LoaiTaiKhoanUsers, "IdLoaitk", "TenLoaitk");
            return View();
        }

        // POST: Admin/NguoiDungsAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,TenTruyCap,MatKhau,HoTen,Sdt,Email,LoaiTaiKhoanId,NgayDangky,SoTien")] NguoiDung nguoiDung)
        {

            ModelState.Remove("LoaiTaiKhoan");
           
            if (ModelState.IsValid)
            {
                _context.Add(nguoiDung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiTaiKhoanId"] = new SelectList(_context.LoaiTaiKhoanUsers, "IdLoaitk", "TenLoaitk", nguoiDung.LoaiTaiKhoanId);
            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungsAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }
            ViewData["LoaiTaiKhoanId"] = new SelectList(_context.LoaiTaiKhoanUsers, "IdLoaitk", "TenLoaitk", nguoiDung.LoaiTaiKhoanId);
            return View(nguoiDung);
        }

        // POST: Admin/NguoiDungsAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,TenTruyCap,MatKhau,HoTen,Sdt,Email,LoaiTaiKhoanId,NgayDangky,SoTien")] NguoiDung nguoiDung)
        {
            if (id != nguoiDung.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoiDung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiDungExists(nguoiDung.IdUser))
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
            ViewData["LoaiTaiKhoanId"] = new SelectList(_context.LoaiTaiKhoanUsers, "IdLoaitk", "TenLoaitk", nguoiDung.LoaiTaiKhoanId);
            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungsAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDungs
                .Include(n => n.LoaiTaiKhoan)
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        // POST: Admin/NguoiDungsAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ModelState.Remove("LoaiTaiKhoan");

            var nguoiDung = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDung != null)
            {
                _context.NguoiDungs.Remove(nguoiDung);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiDungExists(int id)
        {
            return _context.NguoiDungs.Any(e => e.IdUser == id);
        }
    }
}
