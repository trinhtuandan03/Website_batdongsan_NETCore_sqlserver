using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("BaiViet")]
public partial class BaiViet
{
    [Key]
    [Column("id_baiviet")]
    public int IdBaiviet { get; set; }

   
    [Column("tieu_de")]
    [StringLength(255)]
    [Display(Name = "Tiêu Đề")]
    public string? TieuDe { get; set; }

   
    [Column("noi_dung")]
    [Display(Name = "Nội Dung")]
    public string? NoiDung { get; set; }

   
    [Column("ngay_tao", TypeName = "datetime")]
    [Display(Name = "Ngày Tạo")]
    public DateTime? NgayTao { get; set; }

   
    [Column("id_User")]
    [Display(Name = "Họ Tên")]
    public int? IdUser { get; set; }

   
    [Column("id_loaibaiviet")]
    [Display(Name = "Loại Bài Viết")]
    public int? IdLoaibaiviet { get; set; }

   
    [Column("id_trangthai")]
    [Display(Name = "Trạng Thái")]
    public int? IdTrangthai { get; set; }

    [InverseProperty("IdBaivietNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    [ForeignKey("IdLoaibaiviet")]
    [InverseProperty("BaiViets")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual LoaiBaiViet IdLoaibaivietNavigation { get; set; }

    [ForeignKey("IdTrangthai")]
    [InverseProperty("BaiViets")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual TrangThai IdTrangthaiNavigation { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("BaiViets")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual NguoiDung IdUserNavigation { get; set; }

    [InverseProperty("IdBaivietNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<LichSuGiaoDich> LichSuGiaoDiches { get; set; } = new List<LichSuGiaoDich>();
}
