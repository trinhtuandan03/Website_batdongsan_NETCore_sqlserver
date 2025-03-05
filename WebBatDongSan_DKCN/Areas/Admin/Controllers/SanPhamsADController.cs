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
    public class SanPhamsADController : Controller
    {
        private readonly BatDongSanDKCNContext _context;

        public SanPhamsADController(BatDongSanDKCNContext context)
        {
            _context = context;
        }

        // GET: Admin/SanPhamsAD
        public async Task<IActionResult> Index()
        {
            var batDongSanDKCNContext = _context.SanPhams.Include(s => s.IdDuongphoNavigation).Include(s => s.IdGiaytoTailieuNavigation).Include(s => s.IdLoaibdsNavigation).Include(s => s.IdLoaitinNavigation).Include(s => s.IdPhuonghuongNavigation).Include(s => s.IdPhuongxaNavigation).Include(s => s.IdQuanhuyenNavigation).Include(s => s.IdTinhthanhNavigation).Include(s => s.IdTrangthaiNavigation).Include(s => s.IdUserNavigation);
            return View(await batDongSanDKCNContext.ToListAsync());
        }

        // GET: Admin/SanPhamsAD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.IdDuongphoNavigation)
                .Include(s => s.IdGiaytoTailieuNavigation)
                .Include(s => s.IdLoaibdsNavigation)
                .Include(s => s.IdLoaitinNavigation)
                .Include(s => s.IdPhuonghuongNavigation)
                .Include(s => s.IdPhuongxaNavigation)
                .Include(s => s.IdQuanhuyenNavigation)
                .Include(s => s.IdTinhthanhNavigation)
                .Include(s => s.IdTrangthaiNavigation)
                .Include(s => s.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdSanpham == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: Admin/SanPhamsAD/Create
        public IActionResult Create()
        {
            ViewData["IdDuongpho"] = new SelectList(_context.DuongPhos, "IdDuongpho", "IdDuongpho");
            ViewData["IdGiaytoTailieu"] = new SelectList(_context.GiayToTaiLieus, "IdGiaytoTailieu", "IdGiaytoTailieu");
            ViewData["IdLoaibds"] = new SelectList(_context.LoaiBds, "IdLoaibds", "IdLoaibds");
            ViewData["IdLoaitin"] = new SelectList(_context.LoaiTins, "IdLoaitin", "IdLoaitin");
            ViewData["IdPhuonghuong"] = new SelectList(_context.PhuongHuongs, "IdPhuonghuong", "IdPhuonghuong");
            ViewData["IdPhuongxa"] = new SelectList(_context.PhuongXas, "IdPhuongxa", "IdPhuongxa");
            ViewData["IdQuanhuyen"] = new SelectList(_context.QuanHuyens, "IdQuanhuyen", "IdQuanhuyen");
            ViewData["IdTinhthanh"] = new SelectList(_context.TinhThanhs, "IdTinhthanh", "IdTinhthanh");
            ViewData["IdTrangthai"] = new SelectList(_context.TrangThais, "IdTrangthai", "IdTrangthai");
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "IdUser");
            return View();
        }

        // POST: Admin/SanPhamsAD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSanpham,TieuDeSanpham,MoTaSanpham,GiaSanPham,DienTich,NgayDang,Img1,Img2,Img3,Img4,Img5,IdUser,IdGiaytoTailieu,IdLoaitin,IdLoaibds,IdTinhthanh,IdQuanhuyen,IdPhuongxa,Chieungang,Chieudai,SoLau,SoPhongNgu,PhongAn,NhaBep,SanThuong,ChoDeXeHoi,DiaChi,IdDuongpho,IdPhuonghuong,IdTrangthai")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDuongpho"] = new SelectList(_context.DuongPhos, "IdDuongpho", "IdDuongpho", sanPham.IdDuongpho);
            ViewData["IdGiaytoTailieu"] = new SelectList(_context.GiayToTaiLieus, "IdGiaytoTailieu", "IdGiaytoTailieu", sanPham.IdGiaytoTailieu);
            ViewData["IdLoaibds"] = new SelectList(_context.LoaiBds, "IdLoaibds", "IdLoaibds", sanPham.IdLoaibds);
            ViewData["IdLoaitin"] = new SelectList(_context.LoaiTins, "IdLoaitin", "IdLoaitin", sanPham.IdLoaitin);
            ViewData["IdPhuonghuong"] = new SelectList(_context.PhuongHuongs, "IdPhuonghuong", "IdPhuonghuong", sanPham.IdPhuonghuong);
            ViewData["IdPhuongxa"] = new SelectList(_context.PhuongXas, "IdPhuongxa", "IdPhuongxa", sanPham.IdPhuongxa);
            ViewData["IdQuanhuyen"] = new SelectList(_context.QuanHuyens, "IdQuanhuyen", "IdQuanhuyen", sanPham.IdQuanhuyen);
            ViewData["IdTinhthanh"] = new SelectList(_context.TinhThanhs, "IdTinhthanh", "IdTinhthanh", sanPham.IdTinhthanh);
            ViewData["IdTrangthai"] = new SelectList(_context.TrangThais, "IdTrangthai", "IdTrangthai", sanPham.IdTrangthai);
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "IdUser", sanPham.IdUser);
            return View(sanPham);
        }

        // GET: Admin/SanPhamsAD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["IdDuongpho"] = new SelectList(_context.DuongPhos, "IdDuongpho", "IdDuongpho", sanPham.IdDuongpho);
            ViewData["IdGiaytoTailieu"] = new SelectList(_context.GiayToTaiLieus, "IdGiaytoTailieu", "IdGiaytoTailieu", sanPham.IdGiaytoTailieu);
            ViewData["IdLoaibds"] = new SelectList(_context.LoaiBds, "IdLoaibds", "IdLoaibds", sanPham.IdLoaibds);
            ViewData["IdLoaitin"] = new SelectList(_context.LoaiTins, "IdLoaitin", "IdLoaitin", sanPham.IdLoaitin);
            ViewData["IdPhuonghuong"] = new SelectList(_context.PhuongHuongs, "IdPhuonghuong", "IdPhuonghuong", sanPham.IdPhuonghuong);
            ViewData["IdPhuongxa"] = new SelectList(_context.PhuongXas, "IdPhuongxa", "IdPhuongxa", sanPham.IdPhuongxa);
            ViewData["IdQuanhuyen"] = new SelectList(_context.QuanHuyens, "IdQuanhuyen", "IdQuanhuyen", sanPham.IdQuanhuyen);
            ViewData["IdTinhthanh"] = new SelectList(_context.TinhThanhs, "IdTinhthanh", "IdTinhthanh", sanPham.IdTinhthanh);
            ViewData["IdTrangthai"] = new SelectList(_context.TrangThais, "IdTrangthai", "IdTrangthai", sanPham.IdTrangthai);
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "IdUser", sanPham.IdUser);
            return View(sanPham);
        }

        // POST: Admin/SanPhamsAD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSanpham,TieuDeSanpham,MoTaSanpham,GiaSanPham,DienTich,NgayDang,Img1,Img2,Img3,Img4,Img5,IdUser,IdGiaytoTailieu,IdLoaitin,IdLoaibds,IdTinhthanh,IdQuanhuyen,IdPhuongxa,Chieungang,Chieudai,SoLau,SoPhongNgu,PhongAn,NhaBep,SanThuong,ChoDeXeHoi,DiaChi,IdDuongpho,IdPhuonghuong,IdTrangthai")] SanPham sanPham)
        {
            if (id != sanPham.IdSanpham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.IdSanpham))
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
            ViewData["IdDuongpho"] = new SelectList(_context.DuongPhos, "IdDuongpho", "IdDuongpho", sanPham.IdDuongpho);
            ViewData["IdGiaytoTailieu"] = new SelectList(_context.GiayToTaiLieus, "IdGiaytoTailieu", "IdGiaytoTailieu", sanPham.IdGiaytoTailieu);
            ViewData["IdLoaibds"] = new SelectList(_context.LoaiBds, "IdLoaibds", "IdLoaibds", sanPham.IdLoaibds);
            ViewData["IdLoaitin"] = new SelectList(_context.LoaiTins, "IdLoaitin", "IdLoaitin", sanPham.IdLoaitin);
            ViewData["IdPhuonghuong"] = new SelectList(_context.PhuongHuongs, "IdPhuonghuong", "IdPhuonghuong", sanPham.IdPhuonghuong);
            ViewData["IdPhuongxa"] = new SelectList(_context.PhuongXas, "IdPhuongxa", "IdPhuongxa", sanPham.IdPhuongxa);
            ViewData["IdQuanhuyen"] = new SelectList(_context.QuanHuyens, "IdQuanhuyen", "IdQuanhuyen", sanPham.IdQuanhuyen);
            ViewData["IdTinhthanh"] = new SelectList(_context.TinhThanhs, "IdTinhthanh", "IdTinhthanh", sanPham.IdTinhthanh);
            ViewData["IdTrangthai"] = new SelectList(_context.TrangThais, "IdTrangthai", "IdTrangthai", sanPham.IdTrangthai);
            ViewData["IdUser"] = new SelectList(_context.NguoiDungs, "IdUser", "IdUser", sanPham.IdUser);
            return View(sanPham);
        }

        // GET: Admin/SanPhamsAD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.IdDuongphoNavigation)
                .Include(s => s.IdGiaytoTailieuNavigation)
                .Include(s => s.IdLoaibdsNavigation)
                .Include(s => s.IdLoaitinNavigation)
                .Include(s => s.IdPhuonghuongNavigation)
                .Include(s => s.IdPhuongxaNavigation)
                .Include(s => s.IdQuanhuyenNavigation)
                .Include(s => s.IdTinhthanhNavigation)
                .Include(s => s.IdTrangthaiNavigation)
                .Include(s => s.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdSanpham == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Admin/SanPhamsAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham != null)
            {
                _context.SanPhams.Remove(sanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.IdSanpham == id);
        }
    }
}
