using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("TinhThanh")]
public partial class TinhThanh
{
    [Key]
    [Column("id_tinhthanh")]
    public int IdTinhthanh { get; set; }

   
    [Column("Ten_tinhthanh")]
    [StringLength(100)]
    [Display(Name = "Tỉnh Thành")]
    public string? TenTinhthanh { get; set; }

    [InverseProperty("IdTinhthanhNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<QuanHuyen> QuanHuyens { get; set; } = new List<QuanHuyen>();

    [InverseProperty("IdTinhthanhNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
