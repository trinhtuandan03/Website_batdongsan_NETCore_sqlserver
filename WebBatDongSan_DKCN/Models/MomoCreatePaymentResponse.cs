using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("MomoCreatePaymentResponse")]
public partial class MomoCreatePaymentResponse
{
    [Key]
    [Column("id_momo_create_payment")]
    public int IdMomoCreatePayment { get; set; }

    [StringLength(1000)]
    public string? RequestId { get; set; }

    public int? ErrorCode { get; set; }

    [StringLength(1000)]
    public string? OrderId { get; set; }

    [StringLength(1000)]
    public string? Message { get; set; }

    [StringLength(1000)]
    public string? LocalMessage { get; set; }

    [StringLength(1000)]
    public string? RequestType { get; set; }

    [StringLength(1000)]
    public string? PayUrl { get; set; }

    [StringLength(1000)]
    public string? Signature { get; set; }

    [StringLength(1000)]
    public string? QrCodeUrl { get; set; }

    [StringLength(1000)]
    public string? Deeplink { get; set; }

    [StringLength(1000)]
    public string? DeeplinkWebInApp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("id_User")]
    public int? IdUser { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("MomoCreatePaymentResponses")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual NguoiDung IdUserNavigation { get; set; }
}
