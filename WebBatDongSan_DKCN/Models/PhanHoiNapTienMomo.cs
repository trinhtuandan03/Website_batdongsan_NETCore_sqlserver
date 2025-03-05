using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("PhanHoiNapTienMomo")]
public partial class PhanHoiNapTienMomo
{
    [Key]
    [Column("id_PhanHoiNapTienMomo")]
    public int IdPhanHoiNapTienMomo { get; set; }

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
    [InverseProperty("PhanHoiNapTienMomos")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual NguoiDung IdUserNavigation { get; set; }
}
