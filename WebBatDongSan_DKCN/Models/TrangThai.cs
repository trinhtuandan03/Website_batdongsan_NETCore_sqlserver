using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("TrangThai")]
public partial class TrangThai
{
    [Key]
    [Column("id_trangthai")]
    public int IdTrangthai { get; set; }

   
    [Column("ten_trangthai")]
    [Display(Name = "Trạng Thái")]
    public string? TenTrangthai { get; set; }

    [InverseProperty("IdTrangthaiNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<BaiViet> BaiViets { get; set; } = new List<BaiViet>();

    [InverseProperty("IdTrangthaiNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
