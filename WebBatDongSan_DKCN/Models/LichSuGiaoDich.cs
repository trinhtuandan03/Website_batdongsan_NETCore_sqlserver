using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("LichSuGiaoDich")]
public partial class LichSuGiaoDich
{
    [Key]
    [Column("Id_GiaoDich")]
    public int IdGiaoDich { get; set; }

    [Column("id_User")]
    public int? IdUser { get; set; }

   
    [Column("id_baiviet")]
    [Display(Name = "Bài Viết")]
    public int? IdBaiviet { get; set; }

   
    [Column("id_sanpham")]
    [Display(Name = "Sản Phẩm")]
    public int? IdSanpham { get; set; }

    [Column("so_tien", TypeName = "decimal(18, 2)")]
    public decimal? SoTien { get; set; }

    [Column("Loai_Giao_Dich")]
    [StringLength(255)]
    public string? LoaiGiaoDich { get; set; }

    [Column("Thoi_Gian_Giao_Dich", TypeName = "datetime")]
    public DateTime? ThoiGianGiaoDich { get; set; }

    [ForeignKey("IdBaiviet")]
    [InverseProperty("LichSuGiaoDiches")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual BaiViet IdBaivietNavigation { get; set; }

    [ForeignKey("IdSanpham")]
    [InverseProperty("LichSuGiaoDiches")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual SanPham IdSanphamNavigation { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("LichSuGiaoDiches")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual NguoiDung IdUserNavigation { get; set; }
}
