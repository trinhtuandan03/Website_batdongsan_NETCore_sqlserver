using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("PhuongXa")]
public partial class PhuongXa
{
    [Key]
    [Column("id_phuongxa")]
    public int IdPhuongxa { get; set; }

    [Column("Ten_phuongxa")]
    [StringLength(100)]
    public string? TenPhuongxa { get; set; }

    [Column("id_quanhuyen")]
    public int? IdQuanhuyen { get; set; }

    [InverseProperty("IdPhuongxaNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<DuongPho> DuongPhos { get; set; } = new List<DuongPho>();

    [ForeignKey("IdQuanhuyen")]
    [InverseProperty("PhuongXas")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual QuanHuyen IdQuanhuyenNavigation { get; set; }

    [InverseProperty("IdPhuongxaNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
