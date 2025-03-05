using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("LoaiBDS")]
public partial class LoaiBd
{
    [Key]
    [Column("id_loaibds")]
    public int IdLoaibds { get; set; }

   
    [Column("ten_loaibds")]
    [StringLength(100)]
    [Display(Name = "Tên Loại BĐS")]
    public string? TenLoaibds { get; set; }

    [InverseProperty("IdLoaibdsNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
