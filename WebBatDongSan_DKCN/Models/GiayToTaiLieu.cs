using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("GiayTo_TaiLieu")]
public partial class GiayToTaiLieu
{
    [Key]
    [Column("id_giayto_tailieu")]
    public int IdGiaytoTailieu { get; set; }

   
    [Column("ten_giayto_tailieu")]
    [StringLength(100)]
    [Display(Name = "Tên Tài Liệu")]
    public string? TenGiaytoTailieu { get; set; }

    [InverseProperty("IdGiaytoTailieuNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
