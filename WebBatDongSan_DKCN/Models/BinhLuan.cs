using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("BinhLuan")]
public partial class BinhLuan
{
    [Key]
    [Column("id_binhluan")]
    public int IdBinhluan { get; set; }

   
    [Column("noi_dung")]
    [Display(Name = "Nội Dung")]
    public string? NoiDung { get; set; }

   
    [Column("id_sanpham")]
    [Display(Name = "Sản Phẩm")]
    public int? IdSanpham { get; set; }

   
    [Column("id_baiviet")]
    [Display(Name = "Bài Viết")]
    public int? IdBaiviet { get; set; }

   
    [Column("ngay_tao", TypeName = "datetime")]
    [Display(Name = "Ngày Tạo")]
    public DateTime? NgayTao { get; set; }

   
    [Column("id_User")]
    [Display(Name = "Tên Người Dùng")]
    public int? IdUser { get; set; }

    [Column("binh_luan_cha_id")]
    public int? BinhLuanChaId { get; set; }

    [ForeignKey("BinhLuanChaId")]
    [InverseProperty("InverseBinhLuanCha")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual BinhLuan BinhLuanCha { get; set; }

    [ForeignKey("IdBaiviet")]
    [InverseProperty("BinhLuans")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual BaiViet IdBaivietNavigation { get; set; }

    [ForeignKey("IdSanpham")]
    [InverseProperty("BinhLuans")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual SanPham IdSanphamNavigation { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("BinhLuans")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual NguoiDung IdUserNavigation { get; set; }

    [InverseProperty("BinhLuanCha")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<BinhLuan> InverseBinhLuanCha { get; set; } = new List<BinhLuan>();
}
