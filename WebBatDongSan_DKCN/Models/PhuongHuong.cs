using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("PhuongHuong")]
public partial class PhuongHuong
{
    [Key]
    [Column("id_phuonghuong")]
    public int IdPhuonghuong { get; set; }

   
    [Column("ten_phuonghuong")]
    [StringLength(100)]
    [Display(Name = "Phương Hướng")]
    public string? TenPhuonghuong { get; set; }

    [InverseProperty("IdPhuonghuongNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
