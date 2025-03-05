using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("MomoOption")]
public partial class MomoOption
{
    [Key]
    [Column("id_momo_option")]
    public int IdMomoOption { get; set; }

    [StringLength(1000)]
    public string? MomoApiUrl { get; set; }

    [StringLength(1000)]
    public string? SecretKey { get; set; }

    [StringLength(1000)]
    public string? AccessKey { get; set; }

    [StringLength(1000)]
    public string? ReturnUrl { get; set; }

    [StringLength(1000)]
    public string? NotifyUrl { get; set; }

    [StringLength(1000)]
    public string? PartnerCode { get; set; }

    [StringLength(1000)]
    public string? RequestType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("id_User")]
    public int? IdUser { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("MomoOptions")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual NguoiDung IdUserNavigation { get; set; }
}
