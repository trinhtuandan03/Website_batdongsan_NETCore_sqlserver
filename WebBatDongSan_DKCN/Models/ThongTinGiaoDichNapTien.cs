using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("ThongTinGiaoDichNapTien")]
public partial class ThongTinGiaoDichNapTien
{
    [Key]
    [Column("id_ThongTinGiaoDichNapTien")]
    public int IdThongTinGiaoDichNapTien { get; set; }

    [StringLength(1000)]
    public string? FullName { get; set; }

    [StringLength(1000)]
    public string? OrderId { get; set; }

    [StringLength(1000)]
    public string? OrderInfo { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Amount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("id_User")]
    public int? IdUser { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("ThongTinGiaoDichNapTiens")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual NguoiDung IdUserNavigation { get; set; }
}
