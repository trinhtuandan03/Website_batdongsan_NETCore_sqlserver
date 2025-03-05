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
    public class LoaiTaiKhoanUsersADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public LoaiTaiKhoanUsersADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiTaiKhoanUsersAD
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiTaiKhoanUsers.ToListAsync());
        }

        // GET: Admin/LoaiTaiKhoanUsersAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiTaiKhoanUser = await _context.LoaiTaiKhoanUsers
                .FirstOrDefaultAsync(m => m.IdLoaitk == id);
            if (loaiTaiKhoanUser == null)
            {
                return NotFound();
            }

            return View(loaiTaiKhoanUser);
        }

        // GET: Admin/LoaiTaiKhoanUsersAD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiTaiKhoanUsersAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoaitk,TenLoaitk")] LoaiTaiKhoanUser loaiTaiKhoanUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiTaiKhoanUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiTaiKhoanUser);
        }

        // GET: Admin/LoaiTaiKhoanUsersAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiTaiKhoanUser = await _context.LoaiTaiKhoanUsers.FindAsync(id);
            if (loaiTaiKhoanUser == null)
            {
                return NotFound();
            }
            return View(loaiTaiKhoanUser);
        }

        // POST: Admin/LoaiTaiKhoanUsersAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoaitk,TenLoaitk")] LoaiTaiKhoanUser loaiTaiKhoanUser)
        {
            if (id != loaiTaiKhoanUser.IdLoaitk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiTaiKhoanUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiTaiKhoanUserExists(loaiTaiKhoanUser.IdLoaitk))
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
            return View(loaiTaiKhoanUser);
        }

        // GET: Admin/LoaiTaiKhoanUsersAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiTaiKhoanUser = await _context.LoaiTaiKhoanUsers
                .FirstOrDefaultAsync(m => m.IdLoaitk == id);
            if (loaiTaiKhoanUser == null)
            {
                return NotFound();
            }

            return View(loaiTaiKhoanUser);
        }

        // POST: Admin/LoaiTaiKhoanUsersAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiTaiKhoanUser = await _context.LoaiTaiKhoanUsers.FindAsync(id);
            if (loaiTaiKhoanUser != null)
            {
                _context.LoaiTaiKhoanUsers.Remove(loaiTaiKhoanUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiTaiKhoanUserExists(int id)
        {
            return _context.LoaiTaiKhoanUsers.Any(e => e.IdLoaitk == id);
        }
    }
}
