using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("DuongPho")]
public partial class DuongPho
{
    [Key]
    [Column("id_duongpho")]
    public int IdDuongpho { get; set; }

   
    [Column("Ten_duongpho")]
    [StringLength(100)]
    [Display(Name = "Đường Phố")]
    public string? TenDuongpho { get; set; }

   
    [Column("id_phuongxa")]
    [Display(Name = "Phường Xã")]
    public int? IdPhuongxa { get; set; }

    [ForeignKey("IdPhuongxa")]
    [InverseProperty("DuongPhos")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual PhuongXa IdPhuongxaNavigation { get; set; }

    [InverseProperty("IdDuongphoNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
