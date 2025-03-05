using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebBatDongSan_DKCN.Models;

namespace WebBatDongSan_DKCN.ViewModels
{
    public class HomeViewModel
    {
        public List<Menu> Menus { get; set; }
        public List<SanPham> SanPhams { get; set; }

        public List<PhanHoiNapTienMomo> PhanHoiNapTienMomos { get; set; }
        // Thông tin thanh toán từ người dùng

        public decimal? UpdatedUserAmount { get; set; } // Số tiền người dùng sau khi nạp tiền

        public string? FullName { get; set; }
        public string? OrderId { get; set; }
        public string? OrderInfo { get; set; }
        public decimal? Amount { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<NguoiDung> NguoiDungs { get; set; }
        //---------------------------------------------------------------
        public List<SanPham> SanPhamNhaMatTien { get; set; }
        public List<SanPham> SanPhamNhaChungCu { get; set; }

        public string TenLoaiNhaMatTien { get; set; }
        public string TenLoaiNhaChungCu { get; set; }

    }
}
