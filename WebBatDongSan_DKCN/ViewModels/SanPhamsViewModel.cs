using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebBatDongSan_DKCN.Models;

namespace WebBatDongSan_DKCN.ViewModels
{
    public class SanPhamsViewModel
    {
        public List<Menu> Menus { get; set; }
        public List<SanPham> RelatedSanPhams { get; set; } //để chứa các sản phẩm liên quan:    
        public List<SanPham> SanPhams { get; set; }
        public SanPham ThemSanPham { get; set; }
        public List<BinhLuan> binhLuans { get; set; }
        public List<DuongPho> duongPhos { get; set; }
        public List<GiayToTaiLieu> giayToTaiLieus { get; set; }
        public List<LoaiBd> loaiBds { get; set; }
        public List<LoaiTin> loaiTins { get; set; }
        public List<PhuongHuong> phuongHuongs { get; set; }
        public List<PhuongXa> phuongXas { get; set; }
        public List<QuanHuyen> quanHuyens { get; set; }
        public List<TinhThanh> tinhThanhs { get; set; }
        public List<TrangThai> trangThais { get; set; }
        public List<NguoiDung> nguoiDungs { get; set; }
      


        public string? Sdt { get; set; }
        public string? Img1 { get; set; }
        public string? Img2 { get; set; }
        public string? Img3 { get; set; }
        public string? Img4 { get; set; }
        public string? Img5 { get; set; }

        public string IdLoaitin { get; set; }
        public string IdLoaibds { get; set; }
        public int IdGiaytoTailieu { get; set; }
        public int IdPhuongxa { get; set; }
        public string IdQuanhuyen { get; set; }
        public string IdTinhthanh { get; set; }
        public List<IFormFile> HinhAnhs { get; set; } = new List<IFormFile>();



        // Thuộc tính lưu giá trị checkbox
        public bool PhongAn { get; set; } = false;
        public bool NhaBep { get; set; } = false;
        public bool SanThuong { get; set; } = false;
        public bool ChoDeXeHoi { get; set; } = false;

        // Thuộc tính Selected
        public int? SelectedLoaiBds { get; set; }// Thêm một thuộc tính để lưu giữ id 
        public int? SelectedTailieu { get; set; }
        public int? SelectedLoaiTin { get; set; }

        public int? SelectedTinhThanhs { get; set; }
        public int? SelectedQuanHuyens { get; set; }
        public int SelectedPhuongXas { get; set; }
        public int? SelectedDuongPhos { get; set; }
        public int SelectedPhuongHuongs { get; set; }

        //----------------------------------------------------

        // Thêm lịch sử giao dịch
        public List<LichSuGiaoDich> LichSuGiaoDiches { get; set; }
        // Thuộc tính mới theo dõi số dư
        public decimal UserBalance { get; set; }

        public List<BinhLuan> BinhLuans { get; set; }
        public SanPhamsViewModel()
        {
            ThemSanPham = new SanPham();
            Menus = new List<Menu>();
            RelatedSanPhams = new List<SanPham>();
            SanPhams = new List<SanPham>();
            duongPhos = new List<DuongPho>();
            giayToTaiLieus = new List<GiayToTaiLieu>();
            loaiBds = new List<LoaiBd>();
            loaiTins = new List<LoaiTin>();
            phuongHuongs = new List<PhuongHuong>();
            phuongXas = new List<PhuongXa>();
            quanHuyens = new List<QuanHuyen>();
            tinhThanhs = new List<TinhThanh>();
            nguoiDungs = new List<NguoiDung>();
            BinhLuans = new List<BinhLuan> { };
            LichSuGiaoDiches = new List<LichSuGiaoDich>();
        }
    }
}



