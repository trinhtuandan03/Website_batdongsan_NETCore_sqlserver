using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebBatDongSan_DKCN.Models;
using WebBatDongSan_DKCN.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Reflection.Metadata;



namespace WebBatDongSan_DKCN.Controllers
{
    public class SanPhamsController : Controller
    {
        private readonly BatDongSanDKCNContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SanPhamsController(BatDongSanDKCNContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: SanPhams
        public async Task<IActionResult> DanhSachSanPham()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var sanPhams = await _context.SanPhams.ToListAsync();

            var binhluans = await _context.BinhLuans.OrderBy(m => m.IdBinhluan).ToListAsync();
            var duongphos = await _context.DuongPhos.OrderBy(m => m.TenDuongpho).ToListAsync();
            var giaytotailieu = await _context.GiayToTaiLieus.OrderBy(m => m.TenGiaytoTailieu).ToListAsync();
            var loaibds = await _context.LoaiBds.OrderBy(m => m.TenLoaibds).ToListAsync();
            var loaitins = await _context.LoaiTins.OrderBy(m => m.TenLoaitin).ToListAsync();
            var phuonghuongs = await _context.PhuongHuongs.OrderBy(m => m.TenPhuonghuong).ToListAsync();
            var phuongXas = await _context.PhuongXas.OrderBy(m => m.TenPhuongxa).ToListAsync();
            var quanHuyens = await _context.QuanHuyens.OrderBy(m => m.TenQuanhuyen).ToListAsync();
            var tinhThanhs = await _context.TinhThanhs.OrderBy(m => m.TenTinhthanh).ToListAsync();
            var trangthai = await _context.TrangThais.OrderBy(m => m.TenTrangthai).ToListAsync();
            var nguoidung = await _context.NguoiDungs.OrderBy(m => m.HoTen).ToListAsync();

            var viewModel = new SanPhamsViewModel
            {
                Menus = menus,
                SanPhams = sanPhams,

                binhLuans = binhluans,
                duongPhos = duongphos,
                giayToTaiLieus = giaytotailieu,
                loaiBds = loaibds,
                loaiTins = loaitins,
                phuongHuongs = phuonghuongs,
                phuongXas = phuongXas,
                quanHuyens = quanHuyens,
                tinhThanhs = tinhThanhs,
                trangThais = trangthai,
                nguoiDungs = nguoidung,

            };
            return View(viewModel);
        }

        //GET: SanPhams/ChiTietSanPham/5
        public async Task<IActionResult> ChiTietSanPham(string slug, int id)
            {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var sanPhams = await _context.SanPhams.FindAsync(id);
            var relatedSanPhams = await _context.SanPhams.Where(s => s.IdLoaibds == sanPhams.IdLoaibds && s.IdSanpham != id).Take(3).ToListAsync();

            var binhluans = await _context.BinhLuans.OrderBy(m => m.IdBinhluan).ToListAsync();
            var duongphos = await _context.DuongPhos.OrderBy(m => m.TenDuongpho).ToListAsync();
            var giaytotailieu = await _context.GiayToTaiLieus.OrderBy(m => m.TenGiaytoTailieu).ToListAsync();
            var loaibds = await _context.LoaiBds.OrderBy(m => m.TenLoaibds).ToListAsync();
            var loaitins = await _context.LoaiTins.OrderBy(m => m.TenLoaitin).ToListAsync();
            var phuonghuongs = await _context.PhuongHuongs.OrderBy(m => m.TenPhuonghuong).ToListAsync();
            var phuongXas = await _context.PhuongXas.OrderBy(m => m.TenPhuongxa).ToListAsync();
            var quanHuyens = await _context.QuanHuyens.OrderBy(m => m.TenQuanhuyen).ToListAsync();
            var tinhThanhs = await _context.TinhThanhs.OrderBy(m => m.TenTinhthanh).ToListAsync();
            var trangthai = await _context.TrangThais.OrderBy(m => m.TenTrangthai).ToListAsync();
            var nguoidung = await _context.NguoiDungs.OrderBy(m => m.HoTen).ToListAsync();

            if (sanPhams == null)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = "Product Error",
                };
                return View("Error", errorViewModel);
            }
            // Lấy thông tin người dùng tương ứng với sản phẩm
            var nguoiDungCuaSanPham = nguoidung.FirstOrDefault(nd => nd.IdUser == sanPhams.IdUser);
            string sdtNguoiDung = nguoiDungCuaSanPham?.Sdt; // Lấy số điện thoại của người dùng
            var viewModel = new SanPhamsViewModel
            {
                Menus = menus,

                BinhLuans = sanPhams.BinhLuans.OrderBy(bl => bl.NgayTao).ToList(),
                duongPhos = duongphos,
                giayToTaiLieus = giaytotailieu,
                loaiBds = loaibds,
                loaiTins = loaitins,
                phuongHuongs = phuonghuongs,
                phuongXas = phuongXas,
                quanHuyens = quanHuyens,
                tinhThanhs = tinhThanhs,
                trangThais = trangthai,
                nguoiDungs = nguoidung,

                SanPhams = new List<SanPham> { sanPhams },
                RelatedSanPhams = relatedSanPhams,
                Sdt = sdtNguoiDung

            };

            return View(viewModel);
        }

        // GET: SanPhams/ThemSanPham
        [HttpGet]
        public async Task<IActionResult> ThemSanPham()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var sanPhams = await _context.SanPhams.ToListAsync();

            var binhluans = await _context.BinhLuans.OrderBy(m => m.IdBinhluan).ToListAsync();
            var duongphos = await _context.DuongPhos.OrderBy(m => m.TenDuongpho).ToListAsync();
            var giaytotailieu = await _context.GiayToTaiLieus.OrderBy(m => m.TenGiaytoTailieu).ToListAsync();
            var loaibds = await _context.LoaiBds.OrderBy(m => m.TenLoaibds).ToListAsync();
            var loaitins = await _context.LoaiTins.OrderBy(m => m.TenLoaitin).ToListAsync();
            var phuonghuongs = await _context.PhuongHuongs.OrderBy(m => m.TenPhuonghuong).ToListAsync();
            var phuongXas = await _context.PhuongXas.OrderBy(m => m.TenPhuongxa).ToListAsync();
            var quanHuyens = await _context.QuanHuyens.OrderBy(m => m.TenQuanhuyen).ToListAsync();
            var tinhThanhs = await _context.TinhThanhs.OrderBy(m => m.TenTinhthanh).ToListAsync();
            var trangthai = await _context.TrangThais.OrderBy(m => m.TenTrangthai).ToListAsync();
            var nguoidung = await _context.NguoiDungs.OrderBy(m => m.HoTen).ToListAsync();

            var viewModel = new SanPhamsViewModel
            {
                Menus = menus,
                SanPhams = sanPhams,

                binhLuans = binhluans,
                duongPhos = duongphos,
                giayToTaiLieus = giaytotailieu,
                loaiBds = loaibds,
                loaiTins = loaitins,
                phuongHuongs = phuonghuongs,
                phuongXas = phuongXas,
                quanHuyens = quanHuyens,
                tinhThanhs = tinhThanhs,
                trangThais = trangthai,
                nguoiDungs = nguoidung,

            };
            return View(viewModel);
        }

        // POST: SanPhams/ThemSanPham
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemSanPham(SanPhamsViewModel model)
        {
            var viewModel = new SanPhamsViewModel
            {
                ThemSanPham = model.ThemSanPham,
                // Sao chép giá trị id vào Selected
                SelectedLoaiBds = model.SelectedLoaiBds,
                SelectedTailieu = model.SelectedTailieu,
                SelectedLoaiTin = model.SelectedLoaiTin,

                SelectedTinhThanhs = model.SelectedTinhThanhs,
                SelectedQuanHuyens = model.SelectedQuanHuyens,
                SelectedPhuongXas = model.SelectedPhuongXas,
                SelectedDuongPhos = model.SelectedDuongPhos,
                SelectedPhuongHuongs = model.SelectedPhuongHuongs,

                HinhAnhs = model.HinhAnhs
            };
            if (!ModelState.IsValid)
            {
                // Lấy IdUser từ session (ID người dùng sau khi đăng nhập)
                var userId = HttpContext.Session.GetInt32("UserId");
                if (userId.HasValue)
                {
                    model.ThemSanPham.IdUser = userId.Value; // Lưu IdUser của người dùng vào SanPham

                    // Lấy thông tin người dùng
                    var user = await _context.NguoiDungs.FindAsync(userId.Value);
                    if (user != null)
                    {
                        const decimal soTienTru = 10000m;

                        // Kiểm tra số dư
                        if (user.SoTien >= soTienTru)
                        {
                            // Trừ 10.000 VND từ số dư của người dùng
                            user.SoTien -= soTienTru;

                            //==============
                            // Lưu ảnh vào thư mục wwwroot/images/sanpham
                            // Lưu hình ảnh
                            if (model.HinhAnhs != null && model.HinhAnhs.Any())
                            {
                                var imagePaths = await SaveImagesAsync(model.HinhAnhs, "sanpham");

                                model.ThemSanPham.Img1 = Path.GetFileName(imagePaths.ElementAtOrDefault(0));
                                model.ThemSanPham.Img2 = Path.GetFileName(imagePaths.ElementAtOrDefault(1));
                                model.ThemSanPham.Img3 = Path.GetFileName(imagePaths.ElementAtOrDefault(2));
                                model.ThemSanPham.Img4 = Path.GetFileName(imagePaths.ElementAtOrDefault(3));
                                model.ThemSanPham.Img5 = Path.GetFileName(imagePaths.ElementAtOrDefault(4));
                            }

                            // Lưu giá trị id đã chọn vào các cột của bảng SanPhams
                            model.ThemSanPham.IdLoaibds = model.SelectedLoaiBds;
                            model.ThemSanPham.IdGiaytoTailieu = model.SelectedTailieu;
                            model.ThemSanPham.IdLoaitin = model.SelectedLoaiTin;
                            model.ThemSanPham.IdTinhthanh = model.SelectedTinhThanhs;
                            model.ThemSanPham.IdQuanhuyen = model.SelectedQuanHuyens;
                            model.ThemSanPham.IdPhuongxa = model.SelectedPhuongXas;
                            model.ThemSanPham.IdDuongpho = model.SelectedDuongPhos;
                            model.ThemSanPham.IdPhuonghuong = model.SelectedPhuongHuongs;
                            // Đặt giá trị mặc định cho IdTrangthai
                            model.ThemSanPham.IdTrangthai = 1;


                            // Xử lý lưu giá trị checkbox
                            model.ThemSanPham.PhongAn = model.PhongAn ? "Có" : "Không";
                            model.ThemSanPham.NhaBep = model.NhaBep ? "Có" : "Không";
                            model.ThemSanPham.SanThuong = model.SanThuong ? "Có" : "Không";
                            model.ThemSanPham.ChoDeXeHoi = model.ChoDeXeHoi ? "Có" : "Không";

                            _context.SanPhams.Add(viewModel.ThemSanPham);
                            await _context.SaveChangesAsync();

                            // Nhận ID BaiViet mới được thêm vào (LichSuGiaoDich)
                            int newSanPhamId = model.ThemSanPham.IdSanpham;
                            //==============


                            // Ghi lịch sử giao dịch
                            var giaoDich = new LichSuGiaoDich
                            {
                                IdUser = userId.Value,
                                IdSanpham = newSanPhamId,
                                SoTien = -soTienTru,
                                LoaiGiaoDich = "Trừ tiền khi thêm Sản Phẩm",
                                ThoiGianGiaoDich = DateTime.Now
                            };

                            _context.LichSuGiaoDiches.Add(giaoDich);
                            _context.NguoiDungs.Update(user);

                            // Lưu thay đổi vào cơ sở dữ liệu
                            await _context.SaveChangesAsync();

                            // Cập nhật Claims với số tiền mới
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                                new Claim(ClaimTypes.Name, user.TenTruyCap),
                                new Claim(ClaimTypes.Role, user.LoaiTaiKhoanId.ToString()),
                                new Claim("SoTien", user.SoTien.ToString()) // Cập nhật SoTien mới vào Claim
                            };
                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var authProperties = new AuthenticationProperties { };
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                            TempData["ThongBao"] = "Sản Phẩm đã được thêm thành công. Số dư của bạn đã bị trừ 10.000 VND.";
                            return Redirect("/them-san-pham");
                        }
                        else
                        {
                            TempData["ThongBao"] = "Số dư không đủ để thêm Sản Phẩm.";
                            return RedirectToAction("ThemSanPham", "SanPhams");
                        }
                    }
                    else
                    {
                        TempData["ThongBao"] = "Không tìm thấy thông tin người dùng.";
                        return RedirectToAction("ThemSanPham", "SanPhams");
                    }
                }

            }        
            return View(viewModel);
        }
        //SaveImage
        private async Task<List<string>> SaveImagesAsync(List<IFormFile> images, string subFolder)
        {
            var imagePaths = new List<string>();

            try
            {
                foreach (var image in images.Take(5)) // Tối đa 5 ảnh
                {
                    if (image != null && image.Length > 0)
                    {
                        // Tạo tên tệp duy nhất bằng cách sử dụng GUID + Timestamp
                        var uniqueFileName = $"{Guid.NewGuid()}_{DateTime.UtcNow:yyyyMMddHHmmss}{Path.GetExtension(image.FileName)}";
                        var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", subFolder);

                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        var filePath = Path.Combine(uploadPath, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }
                        imagePaths.Add($"/images/{subFolder}/{uniqueFileName}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu ảnh: {ex.Message}");
            }

            return imagePaths;
        }

        //----------------------------------
        // Add a new comment or reply
        [HttpPost]
        public IActionResult LuuBinhLuan(int idSanPham, string noiDung, int? idBinhLuanCha)
        {
            if (string.IsNullOrWhiteSpace(noiDung))
            {
                TempData["Error"] = "Nội dung bình luận không được để trống!";
                return RedirectToAction("ChiTietBaiViet", new { id = idSanPham });
            }

            // Lấy IdUser từ session (ID người dùng sau khi đăng nhập)
            //var userId = HttpContext.Session.GetInt32("UserId");
            //if (!userId.HasValue)
            //{
            //    TempData["Error"] = "Bạn cần đăng nhập để thực hiện bình luận.";
            //    return Redirect("/dang-nhap"); // Redirect đến trang đăng nhập nếu cần
            //}

            var binhLuan = new BinhLuan
            {
                IdSanpham = idSanPham,
                NoiDung = noiDung,
                NgayTao = DateTime.Now,
                IdUser = 1, // Replace with logged-in user ID
                //IdUser = userId.Value,
                BinhLuanChaId = idBinhLuanCha
            };

            _context.BinhLuans.Add(binhLuan);
            _context.SaveChanges();

            return RedirectToAction("ChiTietSanPham", new { id = idSanPham });
        }
    }
}

