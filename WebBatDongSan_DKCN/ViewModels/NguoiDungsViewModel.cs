using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using WebBatDongSan_DKCN.Models;

namespace WebBatDongSan_DKCN.ViewModels
{
    public class NguoiDungsViewModel
    {
        public List<Menu> Menus { get; set; }
        public List<NguoiDung> nguoiDungs { get; set; }
        public NguoiDung DangKy { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        public string Sdt { get; set; }
        public decimal? SoTien { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
        public string TenTruyCap { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [Compare("MatKhau", ErrorMessage = "Mật khẩu không khớp.")]
        [DataType(DataType.Password)]
        public string ConfirmMatKhau { get; set; }

        public int LoaiTaiKhoanId { get; set; }

        public List<LoaiTaiKhoanUser> LoaiTaiKhoanUsers { get; set; }
        public int SelectedLoaiTaiKhoanId { get; set; } // Thêm một thuộc tính để lưu giữ id của loại tài khoản đã chọn

        public int IdUser { get; set; }

        public NguoiDungsViewModel()
        {
            DangKy = new NguoiDung();
            LoaiTaiKhoanUsers = new List<LoaiTaiKhoanUser>();
        }
    }
}