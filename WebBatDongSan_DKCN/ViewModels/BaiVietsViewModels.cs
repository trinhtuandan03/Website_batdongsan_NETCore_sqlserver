using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebBatDongSan_DKCN.Models;

namespace WebBatDongSan_DKCN.ViewModels
{
    public class BaiVietsViewModels
    {
        public List<BaiViet> BaiViets { get; set; }
        public List<Menu> Menus { get; set; }
        public List<LoaiBaiViet> loaiBaiViets { get; set; }
        public List<TrangThai> trangThais { get; set; }
        public List<NguoiDung> nguoiDungs { get; set; }

        public BaiViet ThemBaiViet { get; set; }
        //----------------------------------------------------
        public List<BinhLuan> BinhLuans { get; set; }
        //----------------------------------------------------
        public int? SelectedLoaiBaiViet { get; set; }
        //----------------------------------------------------
        // Thêm lịch sử giao dịch
        public List<LichSuGiaoDich> LichSuGiaoDiches { get; set; }  
        // Thuộc tính mới theo dõi số dư
        public decimal UserBalance { get; set; }
        public BaiVietsViewModels()
        {
            ThemBaiViet = new BaiViet();

            BaiViets = new List<BaiViet>();
            loaiBaiViets = new List<LoaiBaiViet>();
            nguoiDungs = new List<NguoiDung>();
            BinhLuans = new List<BinhLuan> { };
            LichSuGiaoDiches = new List<LichSuGiaoDich>();
        }
    }
}

