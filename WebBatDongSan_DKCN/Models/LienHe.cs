using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("LienHe")]
public partial class LienHe
{
    [Key]
    [Column("id_lienHe")]
    public int IdLienHe { get; set; }

   
    [Column("tieu_de")]
    [StringLength(255)]
    [Display(Name = "Tiêu Đề")]
    public string? TieuDe { get; set; }

   
    [Column("noi_dung")]
    [Display(Name = "Nội Dung")]
    public string? NoiDung { get; set; }

   
    [Column("thoi_gian_gui", TypeName = "datetime")]
    [Display(Name = "Thời Gian Gửi")]
    public DateTime? ThoiGianGui { get; set; }

   
    [Column("id_User")]
    [Display(Name = "Mã Người Dùng")]
    public int? IdUser { get; set; }

   
    [Column("ho_ten")]
    [StringLength(100)]
    [Display(Name = "Họ Tên")]
    public string? HoTen { get; set; }

   
    [Column("email")]
    [StringLength(100)]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("LienHes")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual NguoiDung IdUserNavigation { get; set; }
}
