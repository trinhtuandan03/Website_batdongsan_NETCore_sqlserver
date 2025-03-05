using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebBatDongSan_DKCN.Models;

public partial class BatDongSanDKCNContext : DbContext
{
    public BatDongSanDKCNContext()
    {
    }

    public BatDongSanDKCNContext(DbContextOptions<BatDongSanDKCNContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiViet> BaiViets { get; set; }

    public virtual DbSet<BinhLuan> BinhLuans { get; set; }

    public virtual DbSet<DuongPho> DuongPhos { get; set; }

    public virtual DbSet<GiayToTaiLieu> GiayToTaiLieus { get; set; }

    public virtual DbSet<LichSuGiaoDich> LichSuGiaoDiches { get; set; }

    public virtual DbSet<LienHe> LienHes { get; set; }

    public virtual DbSet<LoaiBaiViet> LoaiBaiViets { get; set; }

    public virtual DbSet<LoaiBd> LoaiBds { get; set; }

    public virtual DbSet<LoaiTaiKhoanUser> LoaiTaiKhoanUsers { get; set; }

    public virtual DbSet<LoaiTin> LoaiTins { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MomoCreatePaymentResponse> MomoCreatePaymentResponses { get; set; }

    public virtual DbSet<MomoOption> MomoOptions { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<PhanHoiNapTienMomo> PhanHoiNapTienMomos { get; set; }

    public virtual DbSet<PhuongHuong> PhuongHuongs { get; set; }

    public virtual DbSet<PhuongXa> PhuongXas { get; set; }

    public virtual DbSet<QuanHuyen> QuanHuyens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<ThongTinGiaoDichNapTien> ThongTinGiaoDichNapTiens { get; set; }

    public virtual DbSet<TinhThanh> TinhThanhs { get; set; }

    public virtual DbSet<TrangThai> TrangThais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BatDongSanDKCN;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Command Timeout=300");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiViet>(entity =>
        {
            entity.Property(e => e.IdLoaibaiviet).HasComment("Loại Bài Viết");
            entity.Property(e => e.IdTrangthai).HasComment("Trạng Thái");
            entity.Property(e => e.IdUser).HasComment("Họ Tên");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày Tạo");
            entity.Property(e => e.NoiDung).HasComment("Nội Dung");
            entity.Property(e => e.TieuDe).HasComment("Tiêu Đề");

            entity.HasOne(d => d.IdLoaibaivietNavigation).WithMany(p => p.BaiViets).HasConstraintName("FK_BaiViet_LoaiBaiViet");

            entity.HasOne(d => d.IdTrangthaiNavigation).WithMany(p => p.BaiViets).HasConstraintName("FK_BaiViet_TrangThai");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.BaiViets).HasConstraintName("FK_BaiViet_NguoiDung");
        });

        modelBuilder.Entity<BinhLuan>(entity =>
        {
            entity.Property(e => e.IdBaiviet).HasComment("Bài Viết");
            entity.Property(e => e.IdSanpham).HasComment("Sản Phẩm");
            entity.Property(e => e.IdUser).HasComment("Tên Người Dùng");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày Tạo");
            entity.Property(e => e.NoiDung).HasComment("Nội Dung");

            entity.HasOne(d => d.BinhLuanCha).WithMany(p => p.InverseBinhLuanCha).HasConstraintName("FK_BinhLuan_BinhLuan");

            entity.HasOne(d => d.IdBaivietNavigation).WithMany(p => p.BinhLuans).HasConstraintName("FK_BinhLuan_BaiViet");

            entity.HasOne(d => d.IdSanphamNavigation).WithMany(p => p.BinhLuans).HasConstraintName("FK_BinhLuan_SanPham");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.BinhLuans).HasConstraintName("FK_BinhLuan_NguoiDung");
        });

        modelBuilder.Entity<DuongPho>(entity =>
        {
            entity.Property(e => e.IdPhuongxa).HasComment("Phường Xã");
            entity.Property(e => e.TenDuongpho).HasComment("Đường Phố");

            entity.HasOne(d => d.IdPhuongxaNavigation).WithMany(p => p.DuongPhos).HasConstraintName("FK_DuongPho_PhuongXa");
        });

        modelBuilder.Entity<GiayToTaiLieu>(entity =>
        {
            entity.Property(e => e.TenGiaytoTailieu).HasComment("Tên Tài Liệu");
        });

        modelBuilder.Entity<LichSuGiaoDich>(entity =>
        {
            entity.Property(e => e.IdBaiviet).HasComment("Bài Viết");
            entity.Property(e => e.IdSanpham).HasComment("Sản Phẩm");
            entity.Property(e => e.ThoiGianGiaoDich).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdBaivietNavigation).WithMany(p => p.LichSuGiaoDiches).HasConstraintName("FK_LichSuGiaoDich_BaiViet");

            entity.HasOne(d => d.IdSanphamNavigation).WithMany(p => p.LichSuGiaoDiches).HasConstraintName("FK_LichSuGiaoDich_SanPham");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LichSuGiaoDiches).HasConstraintName("FK_LichSuGiaoDich_NguoiDung");
        });

        modelBuilder.Entity<LienHe>(entity =>
        {
            entity.Property(e => e.Email).HasComment("Email");
            entity.Property(e => e.HoTen).HasComment("Họ Tên");
            entity.Property(e => e.IdUser).HasComment("Mã Người Dùng");
            entity.Property(e => e.NoiDung).HasComment("Nội Dung");
            entity.Property(e => e.ThoiGianGui)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Thời Gian Gửi");
            entity.Property(e => e.TieuDe).HasComment("Tiêu Đề");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LienHes).HasConstraintName("FK_LienHe_NguoiDung");
        });

        modelBuilder.Entity<LoaiBaiViet>(entity =>
        {
            entity.Property(e => e.Tenloaibaiviet).HasComment("Tên Loại Bài Viết");
        });

        modelBuilder.Entity<LoaiBd>(entity =>
        {
            entity.Property(e => e.TenLoaibds).HasComment("Tên Loại BĐS");
        });

        modelBuilder.Entity<LoaiTaiKhoanUser>(entity =>
        {
            entity.HasKey(e => e.IdLoaitk).HasName("PK_LoaiTaiKhoan");

            entity.Property(e => e.TenLoaitk).HasComment("Tên loại Tài Khoản");
        });

        modelBuilder.Entity<LoaiTin>(entity =>
        {
            entity.Property(e => e.TenLoaitin).HasComment("Tên Loại Tin");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.Property(e => e.Hide).HasComment("Quyền");
            entity.Property(e => e.Link).HasComment("Link ");
            entity.Property(e => e.Order).HasComment("Id Oder");
            entity.Property(e => e.Title).HasComment("Tên Menu");
        });

        modelBuilder.Entity<MomoCreatePaymentResponse>(entity =>
        {
            entity.HasKey(e => e.IdMomoCreatePayment).HasName("PK__MomoCrea__08341F805EBF337C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.MomoCreatePaymentResponses).HasConstraintName("FK_MomoCreatePaymentResponse_NguoiDung");
        });

        modelBuilder.Entity<MomoOption>(entity =>
        {
            entity.HasKey(e => e.IdMomoOption).HasName("PK__MomoOpti__3697E37E6C81EE11");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.MomoOptions).HasConstraintName("FK_MomoOption_NguoiDung");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.Property(e => e.Email).HasComment("Email");
            entity.Property(e => e.HoTen).HasComment("Họ tên");
            entity.Property(e => e.LoaiTaiKhoanId).HasComment("Loại Tài Khoản");
            entity.Property(e => e.MatKhau).HasComment("Mật Khẩu");
            entity.Property(e => e.NgayDangky)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày Đăng Ký");
            entity.Property(e => e.Sdt).HasComment("SĐT");
            entity.Property(e => e.SoTien).HasComment("Số Tiền");
            entity.Property(e => e.TenTruyCap).HasComment("Tên Truy Cập");

            entity.HasOne(d => d.LoaiTaiKhoan).WithMany(p => p.NguoiDungs).HasConstraintName("FK_NguoiDung_LoaiTaiKhoanUser1");
        });

        modelBuilder.Entity<PhanHoiNapTienMomo>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.OrderInfo).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.PhanHoiNapTienMomos).HasConstraintName("FK_PhanHoiNapTienMomo_NguoiDung");
        });

        modelBuilder.Entity<PhuongHuong>(entity =>
        {
            entity.Property(e => e.TenPhuonghuong).HasComment("Phương Hướng");
        });

        modelBuilder.Entity<PhuongXa>(entity =>
        {
            entity.HasOne(d => d.IdQuanhuyenNavigation).WithMany(p => p.PhuongXas).HasConstraintName("FK_PhuongXa_QuanHuyen");
        });

        modelBuilder.Entity<QuanHuyen>(entity =>
        {
            entity.Property(e => e.IdTinhthanh).HasComment("Tỉnh Thành");
            entity.Property(e => e.TenQuanhuyen).HasComment("Quận Huyện");

            entity.HasOne(d => d.IdTinhthanhNavigation).WithMany(p => p.QuanHuyens).HasConstraintName("FK_QuanHuyen_TinhThanh");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.Property(e => e.Chieudai).HasComment("Chiều Dài");
            entity.Property(e => e.Chieungang).HasComment("Chiều Ngang");
            entity.Property(e => e.ChoDeXeHoi).HasComment("Chỗ Để Xe");
            entity.Property(e => e.DiaChi).HasComment("Địa Chỉ");
            entity.Property(e => e.DienTich).HasComment("Diện Tích");
            entity.Property(e => e.GiaSanPham).HasComment("Giá ");
            entity.Property(e => e.IdDuongpho).HasComment("Đường Phố");
            entity.Property(e => e.IdGiaytoTailieu).HasComment("Giấy Tờ - Tài liệu");
            entity.Property(e => e.IdLoaibds).HasComment("Loại BĐS");
            entity.Property(e => e.IdLoaitin).HasComment("Loại Tin");
            entity.Property(e => e.IdPhuonghuong).HasComment("Phương Hướng");
            entity.Property(e => e.IdPhuongxa).HasComment("Phường Xã");
            entity.Property(e => e.IdQuanhuyen).HasComment("Quận Huyện");
            entity.Property(e => e.IdTinhthanh).HasComment("Tỉnh Thành");
            entity.Property(e => e.IdTrangthai).HasComment("Trạng Thái");
            entity.Property(e => e.IdUser).HasComment("Người Dùng");
            entity.Property(e => e.Img1).HasComment("Ảnh 1");
            entity.Property(e => e.Img2).HasComment("Ảnh 2");
            entity.Property(e => e.Img3).HasComment("Ảnh 3");
            entity.Property(e => e.Img4).HasComment("Ảnh 4");
            entity.Property(e => e.Img5).HasComment("Ảnh 5");
            entity.Property(e => e.MoTaSanpham).HasComment("Mô Tả");
            entity.Property(e => e.NgayDang)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày Đăng");
            entity.Property(e => e.NhaBep).HasComment("Nhà Bếp");
            entity.Property(e => e.PhongAn).HasComment("Phòng Ăn");
            entity.Property(e => e.SanThuong).HasComment("Sân Thượng");
            entity.Property(e => e.SoLau).HasComment("Số Lầu");
            entity.Property(e => e.SoPhongNgu).HasComment("Số Phòng Ngủ");
            entity.Property(e => e.TieuDeSanpham).HasComment("Tiêu Đề");

            entity.HasOne(d => d.IdDuongphoNavigation).WithMany(p => p.SanPhams).HasConstraintName("FK_SanPham_DuongPho");

            entity.HasOne(d => d.IdGiaytoTailieuNavigation).WithMany(p => p.SanPhams).HasConstraintName("FK_SanPham_GiayTo_TaiLieu");

            entity.HasOne(d => d.IdLoaibdsNavigation).WithMany(p => p.SanPhams).HasConstraintName("FK_SanPham_LoaiBDS");

            entity.HasOne(d => d.IdLoaitinNavigation).WithMany(p => p.SanPhams).HasConstraintName("FK_SanPham_LoaiTin");

            entity.HasOne(d => d.IdPhuonghuongNavigation).WithMany(p => p.SanPhams).HasConstraintName("FK_SanPham_PhuongHuong");

            entity.HasOne(d => d.IdPhuongxaNavigation).WithMany(p => p.SanPhams).HasConstraintName("FK_SanPham_PhuongXa");

            entity.HasOne(d => d.IdQuanhuyenNavigation).WithMany(p => p.SanPhams).HasConstraintName("FK_SanPham_QuanHuyen");

            entity.HasOne(d => d.IdTinhthanhNavigation).WithMany(p => p.SanPhams).HasConstraintName("FK_SanPham_TinhThanh");

            entity.HasOne(d => d.IdTrangthaiNavigation).WithMany(p => p.SanPhams).HasConstraintName("FK_SanPham_TrangThai");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.SanPhams).HasConstraintName("FK_SanPham_NguoiDung");
        });

        modelBuilder.Entity<ThongTinGiaoDichNapTien>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.OrderInfo).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.ThongTinGiaoDichNapTiens).HasConstraintName("FK_ThongTinGiaoDichNapTien_NguoiDung");
        });

        modelBuilder.Entity<TinhThanh>(entity =>
        {
            entity.Property(e => e.TenTinhthanh).HasComment("Tỉnh Thành");
        });

        modelBuilder.Entity<TrangThai>(entity =>
        {
            entity.Property(e => e.TenTrangthai).HasComment("Trạng Thái");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
