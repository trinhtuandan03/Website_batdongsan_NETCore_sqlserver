using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("LoaiTin")]
public partial class LoaiTin
{
    [Key]
    [Column("id_loaitin")]
    public int IdLoaitin { get; set; }

   
    [Column("ten_loaitin")]
    [StringLength(100)]
    [Display(Name = "Tên Loại Tin")]
    public string? TenLoaitin { get; set; }

    [InverseProperty("IdLoaitinNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
