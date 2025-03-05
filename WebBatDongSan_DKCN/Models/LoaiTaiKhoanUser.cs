using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("LoaiTaiKhoanUser")]
public partial class LoaiTaiKhoanUser
{
    [Key]
    [Column("id_loaitk")]
    public int IdLoaitk { get; set; }

   
    [Column("ten_loaitk")]
    [StringLength(50)]
    [Display(Name = "Tên loại Tài Khoản")]
    public string? TenLoaitk { get; set; }

    [InverseProperty("LoaiTaiKhoan")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<NguoiDung> NguoiDungs { get; set; } = new List<NguoiDung>();
}
