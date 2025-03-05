using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("QuanHuyen")]
public partial class QuanHuyen
{
    [Key]
    [Column("id_quanhuyen")]
    public int IdQuanhuyen { get; set; }

   
    [Column("Ten_quanhuyen")]
    [StringLength(100)]
    [Display(Name = "Quận Huyện")]
    public string? TenQuanhuyen { get; set; }

   
    [Column("id_tinhthanh")]
    [Display(Name = "Tỉnh Thành")]
    public int? IdTinhthanh { get; set; }

    [ForeignKey("IdTinhthanh")]
    [InverseProperty("QuanHuyens")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual TinhThanh IdTinhthanhNavigation { get; set; }

    [InverseProperty("IdQuanhuyenNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<PhuongXa> PhuongXas { get; set; } = new List<PhuongXa>();

    [InverseProperty("IdQuanhuyenNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
