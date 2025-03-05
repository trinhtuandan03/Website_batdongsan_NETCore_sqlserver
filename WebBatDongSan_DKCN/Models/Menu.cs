using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("Menu")]
public partial class Menu
{
    [Key]
    [Column("id_menu")]
    public int IdMenu { get; set; }

   
    [Column("title")]
    [StringLength(50)]
    [Display(Name = "Tên Menu")]
    public string? Title { get; set; }

   
    [Column("order")]
    [Display(Name = "Id Oder")]
    public int? Order { get; set; }

   
    [Column("link")]
    [StringLength(255)]
    [Display(Name = "Link ")]
    public string? Link { get; set; }

   
    [Column("hide")]
    [Display(Name = "Quyền")]
    public int? Hide { get; set; }
}
