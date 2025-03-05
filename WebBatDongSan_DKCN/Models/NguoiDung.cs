using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("NguoiDung")]
public partial class NguoiDung
{
    [Key]
    [Column("id_User")]
    public int IdUser { get; set; }

   
    [Column("ten_truy_cap")]
    [StringLength(50)]
    [Display(Name = "Tên Truy Cập")]
    public string? TenTruyCap { get; set; }

   
    [Column("mat_khau")]
    [StringLength(255)]
    [Display(Name = "Mật Khẩu")]
    public string? MatKhau { get; set; }

   
    [Column("ho_ten")]
    [StringLength(100)]
    [Display(Name = "Họ tên")]
    public string? HoTen { get; set; }

   
    [Column("sdt")]
    [StringLength(50)]
    [Display(Name = "SĐT")]
    public string? Sdt { get; set; }

   
    [Column("email")]
    [StringLength(100)]
    [Display(Name = "Email")]
    public string? Email { get; set; }

   
    [Column("loai_tai_khoan_id")]
    [Display(Name = "Loại Tài Khoản")]
    public int? LoaiTaiKhoanId { get; set; }

   
    [Column("ngay_dangky", TypeName = "datetime")]
    [Display(Name = "Ngày Đăng Ký")]
    public DateTime? NgayDangky { get; set; }

   
    [Column("so_tien", TypeName = "decimal(18, 2)")]
    [Display(Name = "Số Tiền")]
    public decimal? SoTien { get; set; }

    [InverseProperty("IdUserNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<BaiViet> BaiViets { get; set; } = new List<BaiViet>();

    [InverseProperty("IdUserNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    [InverseProperty("IdUserNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<LichSuGiaoDich> LichSuGiaoDiches { get; set; } = new List<LichSuGiaoDich>();

    [InverseProperty("IdUserNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<LienHe> LienHes { get; set; } = new List<LienHe>();

    [ForeignKey("LoaiTaiKhoanId")]
    [InverseProperty("NguoiDungs")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual LoaiTaiKhoanUser LoaiTaiKhoan { get; set; }

    [InverseProperty("IdUserNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<MomoCreatePaymentResponse> MomoCreatePaymentResponses { get; set; } = new List<MomoCreatePaymentResponse>();

    [InverseProperty("IdUserNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<MomoOption> MomoOptions { get; set; } = new List<MomoOption>();

    [InverseProperty("IdUserNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<PhanHoiNapTienMomo> PhanHoiNapTienMomos { get; set; } = new List<PhanHoiNapTienMomo>();

    [InverseProperty("IdUserNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();

    [InverseProperty("IdUserNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<ThongTinGiaoDichNapTien> ThongTinGiaoDichNapTiens { get; set; } = new List<ThongTinGiaoDichNapTien>();
}
