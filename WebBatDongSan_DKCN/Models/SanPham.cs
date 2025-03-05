using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

[Table("SanPham")]
public partial class SanPham
{
    [Key]
    [Column("id_sanpham")]
    public int IdSanpham { get; set; }

   
    [Column("tieu_de_sanpham")]
    [StringLength(100)]
    [Display(Name = "Tiêu Đề")]
    public string? TieuDeSanpham { get; set; }

   
    [Column("mo_ta_sanpham")]
    [Display(Name = "Mô Tả")]
    public string? MoTaSanpham { get; set; }

   
    [Column("gia_san_pham")]
    [Display(Name = "Giá ")]
    public double? GiaSanPham { get; set; }

   
    [Column("dien_tich")]
    [Display(Name = "Diện Tích")]
    public double? DienTich { get; set; }

   
    [Column("ngay_dang", TypeName = "datetime")]
    [Display(Name = "Ngày Đăng")]
    public DateTime? NgayDang { get; set; }

   
    [Column("IMG1")]
    [StringLength(255)]
    [Unicode(false)]
    [Display(Name = "Ảnh 1")]
    public string? Img1 { get; set; }

   
    [Column("IMG2")]
    [StringLength(255)]
    [Unicode(false)]
    [Display(Name = "Ảnh 2")]
    public string? Img2 { get; set; }

   
    [Column("IMG3")]
    [StringLength(255)]
    [Unicode(false)]
    [Display(Name = "Ảnh 3")]
    public string? Img3 { get; set; }

   
    [Column("IMG4")]
    [StringLength(255)]
    [Unicode(false)]
    [Display(Name = "Ảnh 4")]
    public string? Img4 { get; set; }

   
    [Column("IMG5")]
    [StringLength(255)]
    [Unicode(false)]
    [Display(Name = "Ảnh 5")]
    public string? Img5 { get; set; }

   
    [Column("id_User")]
    [Display(Name = "Người Dùng")]
    public int? IdUser { get; set; }

   
    [Column("id_giayto_tailieu")]
    [Display(Name = "Giấy Tờ - Tài liệu")]
    public int? IdGiaytoTailieu { get; set; }

   
    [Column("id_loaitin")]
    [Display(Name = "Loại Tin")]
    public int? IdLoaitin { get; set; }

   
    [Column("id_loaibds")]
    [Display(Name = "Loại BĐS")]
    public int? IdLoaibds { get; set; }

   
    [Column("id_tinhthanh")]
    [Display(Name = "Tỉnh Thành")]
    public int? IdTinhthanh { get; set; }

   
    [Column("id_quanhuyen")]
    [Display(Name = "Quận Huyện")]
    public int? IdQuanhuyen { get; set; }

   
    [Column("id_phuongxa")]
    [Display(Name = "Phường Xã")]
    public int? IdPhuongxa { get; set; }

   
    [Column("chieungang")]
    [StringLength(10)]
    [Display(Name = "Chiều Ngang")]
    public string? Chieungang { get; set; }

   
    [Column("chieudai")]
    [StringLength(10)]
    [Display(Name = "Chiều Dài")]
    public string? Chieudai { get; set; }

   
    [Column("so_lau")]
    [Display(Name = "Số Lầu")]
    public int? SoLau { get; set; }

   
    [Column("so_phong_ngu")]
    [StringLength(10)]
    [Display(Name = "Số Phòng Ngủ")]
    public string? SoPhongNgu { get; set; }

   
    [Column("phong_an")]
    [StringLength(10)]
    [Display(Name = "Phòng Ăn")]
    public string? PhongAn { get; set; }

   
    [Column("nha_bep")]
    [StringLength(10)]
    [Display(Name = "Nhà Bếp")]
    public string? NhaBep { get; set; }

   
    [Column("san_thuong")]
    [StringLength(10)]
    [Display(Name = "Sân Thượng")]
    public string? SanThuong { get; set; }

   
    [Column("cho_de_xe_hoi")]
    [StringLength(10)]
    [Display(Name = "Chỗ Để Xe")]
    public string? ChoDeXeHoi { get; set; }

   
    [Column("dia_chi")]
    [StringLength(100)]
    [Display(Name = "Địa Chỉ")]
    public string? DiaChi { get; set; }

   
    [Column("id_duongpho")]
    [Display(Name = "Đường Phố")]
    public int? IdDuongpho { get; set; }

   
    [Column("id_phuonghuong")]
    [Display(Name = "Phương Hướng")]
    public int? IdPhuonghuong { get; set; }

   
    [Column("id_trangthai")]
    [Display(Name = "Trạng Thái")]
    public int? IdTrangthai { get; set; }

    [InverseProperty("IdSanphamNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    [ForeignKey("IdDuongpho")]
    [InverseProperty("SanPhams")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual DuongPho IdDuongphoNavigation { get; set; }

    [ForeignKey("IdGiaytoTailieu")]
    [InverseProperty("SanPhams")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual GiayToTaiLieu IdGiaytoTailieuNavigation { get; set; }

    [ForeignKey("IdLoaibds")]
    [InverseProperty("SanPhams")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual LoaiBd IdLoaibdsNavigation { get; set; }

    [ForeignKey("IdLoaitin")]
    [InverseProperty("SanPhams")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual LoaiTin IdLoaitinNavigation { get; set; }

    [ForeignKey("IdPhuonghuong")]
    [InverseProperty("SanPhams")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual PhuongHuong IdPhuonghuongNavigation { get; set; }

    [ForeignKey("IdPhuongxa")]
    [InverseProperty("SanPhams")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual PhuongXa IdPhuongxaNavigation { get; set; }

    [ForeignKey("IdQuanhuyen")]
    [InverseProperty("SanPhams")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual QuanHuyen IdQuanhuyenNavigation { get; set; }

    [ForeignKey("IdTinhthanh")]
    [InverseProperty("SanPhams")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual TinhThanh IdTinhthanhNavigation { get; set; }

    [ForeignKey("IdTrangthai")]
    [InverseProperty("SanPhams")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual TrangThai IdTrangthaiNavigation { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("SanPhams")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual NguoiDung IdUserNavigation { get; set; }

    [InverseProperty("IdSanphamNavigation")]
    [NotMapped] // Exclude navigation properties from database mapping
    public virtual ICollection<LichSuGiaoDich> LichSuGiaoDiches { get; set; } = new List<LichSuGiaoDich>();
}
