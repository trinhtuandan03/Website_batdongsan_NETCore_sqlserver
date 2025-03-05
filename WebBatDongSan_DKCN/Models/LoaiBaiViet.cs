using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("LoaiBaiViet")]
public partial class LoaiBaiViet
{
    [Key]
    [Column("id_loaibaiviet")]
    public int IdLoaibaiviet { get; set; }

   
    [Column("tenloaibaiviet")]
    [StringLength(100)]
    [Display(Name = "Tên Loại Bài Viết")]
    public string? Tenloaibaiviet { get; set; }

    [InverseProperty("IdLoaibaivietNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<BaiViet> BaiViets { get; set; } = new List<BaiViet>();
}
