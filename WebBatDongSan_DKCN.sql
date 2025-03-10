USE [master]
GO
/****** Object:  Database [BatDongSanDKCN]    Script Date: 19/12/2024 00:51:40 ******/
CREATE DATABASE [BatDongSanDKCN]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BatDongSanDKCN', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BatDongSanDKCN.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BatDongSanDKCN_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BatDongSanDKCN_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BatDongSanDKCN] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BatDongSanDKCN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BatDongSanDKCN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET ARITHABORT OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BatDongSanDKCN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BatDongSanDKCN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BatDongSanDKCN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BatDongSanDKCN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET RECOVERY FULL 
GO
ALTER DATABASE [BatDongSanDKCN] SET  MULTI_USER 
GO
ALTER DATABASE [BatDongSanDKCN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BatDongSanDKCN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BatDongSanDKCN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BatDongSanDKCN] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BatDongSanDKCN] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BatDongSanDKCN', N'ON'
GO
USE [BatDongSanDKCN]
GO
/****** Object:  Table [dbo].[BaiViet]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiViet](
	[id_baiviet] [int] IDENTITY(1,1) NOT NULL,
	[tieu_de] [nvarchar](255) NULL,
	[noi_dung] [nvarchar](max) NULL,
	[ngay_tao] [datetime] NULL CONSTRAINT [DF_BaiViet_ngay_tao]  DEFAULT (getdate()),
	[id_User] [int] NULL,
	[id_loaibaiviet] [int] NULL,
	[id_trangthai] [int] NULL,
 CONSTRAINT [PK_BaiViet] PRIMARY KEY CLUSTERED 
(
	[id_baiviet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BinhLuan]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinhLuan](
	[id_binhluan] [int] IDENTITY(1,1) NOT NULL,
	[noi_dung] [nvarchar](max) NULL,
	[id_sanpham] [int] NULL,
	[id_baiviet] [int] NULL,
	[ngay_tao] [datetime] NULL,
	[id_User] [int] NULL,
	[binh_luan_cha_id] [int] NULL,
 CONSTRAINT [PK_BinhLuan] PRIMARY KEY CLUSTERED 
(
	[id_binhluan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DuongPho]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DuongPho](
	[id_duongpho] [int] IDENTITY(1,1) NOT NULL,
	[Ten_duongpho] [nvarchar](100) NULL,
	[id_phuongxa] [int] NULL,
 CONSTRAINT [PK_DuongPho] PRIMARY KEY CLUSTERED 
(
	[id_duongpho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiayTo_TaiLieu]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiayTo_TaiLieu](
	[id_giayto_tailieu] [int] IDENTITY(1,1) NOT NULL,
	[ten_giayto_tailieu] [nvarchar](100) NULL,
 CONSTRAINT [PK_GiayTo_TaiLieu] PRIMARY KEY CLUSTERED 
(
	[id_giayto_tailieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichSuGiaoDich]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuGiaoDich](
	[Id_GiaoDich] [int] IDENTITY(1,1) NOT NULL,
	[id_User] [int] NULL,
	[id_baiviet] [int] NULL,
	[id_sanpham] [int] NULL,
	[so_tien] [decimal](18, 2) NULL,
	[Loai_Giao_Dich] [nvarchar](255) NULL,
	[Thoi_Gian_Giao_Dich] [datetime] NULL CONSTRAINT [DF_LichSuGiaoDich_ThoiGian]  DEFAULT (getdate()),
 CONSTRAINT [PK_LichSuGiaoDich] PRIMARY KEY CLUSTERED 
(
	[Id_GiaoDich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LienHe]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LienHe](
	[id_lienHe] [int] IDENTITY(1,1) NOT NULL,
	[tieu_de] [nvarchar](255) NULL,
	[noi_dung] [nvarchar](max) NULL,
	[thoi_gian_gui] [datetime] NULL,
	[id_User] [int] NULL,
	[ho_ten] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
 CONSTRAINT [PK_LienHe] PRIMARY KEY CLUSTERED 
(
	[id_lienHe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiBaiViet]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiBaiViet](
	[id_loaibaiviet] [int] IDENTITY(1,1) NOT NULL,
	[tenloaibaiviet] [nvarchar](100) NULL,
 CONSTRAINT [PK_LoaiBaiViet] PRIMARY KEY CLUSTERED 
(
	[id_loaibaiviet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiBDS]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiBDS](
	[id_loaibds] [int] IDENTITY(1,1) NOT NULL,
	[ten_loaibds] [nvarchar](100) NULL,
 CONSTRAINT [PK_LoaiBDS] PRIMARY KEY CLUSTERED 
(
	[id_loaibds] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiTaiKhoanUser]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTaiKhoanUser](
	[id_loaitk] [int] IDENTITY(1,1) NOT NULL,
	[ten_loaitk] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiTaiKhoan] PRIMARY KEY CLUSTERED 
(
	[id_loaitk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiTin]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTin](
	[id_loaitin] [int] IDENTITY(1,1) NOT NULL,
	[ten_loaitin] [nvarchar](100) NULL,
 CONSTRAINT [PK_LoaiTin] PRIMARY KEY CLUSTERED 
(
	[id_loaitin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[id_menu] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[order] [int] NULL,
	[link] [nvarchar](255) NULL,
	[hide] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[id_menu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MomoCreatePaymentResponse]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MomoCreatePaymentResponse](
	[id_momo_create_payment] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [nvarchar](1000) NULL,
	[ErrorCode] [int] NULL,
	[OrderId] [nvarchar](1000) NULL,
	[Message] [nvarchar](1000) NULL,
	[LocalMessage] [nvarchar](1000) NULL,
	[RequestType] [nvarchar](1000) NULL,
	[PayUrl] [nvarchar](1000) NULL,
	[Signature] [nvarchar](1000) NULL,
	[QrCodeUrl] [nvarchar](1000) NULL,
	[Deeplink] [nvarchar](1000) NULL,
	[DeeplinkWebInApp] [nvarchar](1000) NULL,
	[CreatedAt] [datetime] NOT NULL CONSTRAINT [DF__MomoCreat__Creat__29221CFB]  DEFAULT (getdate()),
	[id_User] [int] NULL,
 CONSTRAINT [PK__MomoCrea__08341F805EBF337C] PRIMARY KEY CLUSTERED 
(
	[id_momo_create_payment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MomoOption]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MomoOption](
	[id_momo_option] [int] IDENTITY(1,1) NOT NULL,
	[MomoApiUrl] [nvarchar](1000) NULL,
	[SecretKey] [nvarchar](1000) NULL,
	[AccessKey] [nvarchar](1000) NULL,
	[ReturnUrl] [nvarchar](1000) NULL,
	[NotifyUrl] [nvarchar](1000) NULL,
	[PartnerCode] [nvarchar](1000) NULL,
	[RequestType] [nvarchar](1000) NULL,
	[CreatedAt] [datetime] NOT NULL CONSTRAINT [DF__MomoOptio__Creat__2EDAF651]  DEFAULT (getdate()),
	[id_User] [int] NULL,
 CONSTRAINT [PK__MomoOpti__3697E37E6C81EE11] PRIMARY KEY CLUSTERED 
(
	[id_momo_option] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[id_User] [int] IDENTITY(1,1) NOT NULL,
	[ten_truy_cap] [nvarchar](50) NULL,
	[mat_khau] [nvarchar](255) NULL,
	[ho_ten] [nvarchar](100) NULL,
	[sdt] [nvarchar](50) NULL,
	[email] [nvarchar](100) NULL,
	[loai_tai_khoan_id] [int] NULL,
	[ngay_dangky] [datetime] NULL CONSTRAINT [DF_NguoiDung_ngay_dangky]  DEFAULT (getdate()),
	[so_tien] [decimal](18, 2) NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[id_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhanHoiNapTienMomo]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanHoiNapTienMomo](
	[id_PhanHoiNapTienMomo] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [nvarchar](1000) NULL,
	[OrderInfo] [nvarchar](1000) NULL CONSTRAINT [DF_PhanHoiNapTienMomo_OrderInfo]  DEFAULT (getdate()),
	[Amount] [decimal](18, 2) NULL,
	[CreatedAt] [datetime] NOT NULL CONSTRAINT [DF_PhanHoiNapTienMomo_CreatedAt]  DEFAULT (getdate()),
	[id_User] [int] NULL,
 CONSTRAINT [PK_PhanHoiNapTienMomo] PRIMARY KEY CLUSTERED 
(
	[id_PhanHoiNapTienMomo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhuongHuong]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhuongHuong](
	[id_phuonghuong] [int] IDENTITY(1,1) NOT NULL,
	[ten_phuonghuong] [nvarchar](100) NULL,
 CONSTRAINT [PK_PhuongHuong] PRIMARY KEY CLUSTERED 
(
	[id_phuonghuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhuongXa]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhuongXa](
	[id_phuongxa] [int] IDENTITY(1,1) NOT NULL,
	[Ten_phuongxa] [nvarchar](100) NULL,
	[id_quanhuyen] [int] NULL,
 CONSTRAINT [PK_PhuongXa] PRIMARY KEY CLUSTERED 
(
	[id_phuongxa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuanHuyen]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanHuyen](
	[id_quanhuyen] [int] IDENTITY(1,1) NOT NULL,
	[Ten_quanhuyen] [nvarchar](100) NULL,
	[id_tinhthanh] [int] NULL,
 CONSTRAINT [PK_QuanHuyen] PRIMARY KEY CLUSTERED 
(
	[id_quanhuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SanPham](
	[id_sanpham] [int] IDENTITY(1,1) NOT NULL,
	[tieu_de_sanpham] [nvarchar](100) NULL,
	[mo_ta_sanpham] [nvarchar](max) NULL,
	[gia_san_pham] [float] NULL,
	[dien_tich] [float] NULL,
	[ngay_dang] [datetime] NULL CONSTRAINT [DF_SanPham_ngay_dang]  DEFAULT (getdate()),
	[IMG1] [varchar](255) NULL,
	[IMG2] [varchar](255) NULL,
	[IMG3] [varchar](255) NULL,
	[IMG4] [varchar](255) NULL,
	[IMG5] [varchar](255) NULL,
	[id_User] [int] NULL,
	[id_giayto_tailieu] [int] NULL,
	[id_loaitin] [int] NULL,
	[id_loaibds] [int] NULL,
	[id_tinhthanh] [int] NULL,
	[id_quanhuyen] [int] NULL,
	[id_phuongxa] [int] NULL,
	[chieungang] [nvarchar](10) NULL,
	[chieudai] [nvarchar](10) NULL,
	[so_lau] [int] NULL,
	[so_phong_ngu] [nvarchar](10) NULL,
	[phong_an] [nvarchar](10) NULL,
	[nha_bep] [nvarchar](10) NULL,
	[san_thuong] [nvarchar](10) NULL,
	[cho_de_xe_hoi] [nvarchar](10) NULL,
	[dia_chi] [nvarchar](100) NULL,
	[id_duongpho] [int] NULL,
	[id_phuonghuong] [int] NULL,
	[id_trangthai] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[id_sanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongTinGiaoDichNapTien]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinGiaoDichNapTien](
	[id_ThongTinGiaoDichNapTien] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](1000) NULL,
	[OrderId] [nvarchar](1000) NULL,
	[OrderInfo] [nvarchar](1000) NULL CONSTRAINT [DF__NapTien__ngay_na__31B762FC]  DEFAULT (getdate()),
	[Amount] [decimal](18, 2) NULL,
	[CreatedAt] [datetime] NOT NULL CONSTRAINT [DF_ThongTinGiaoDichNapTien_CreatedAt]  DEFAULT (getdate()),
	[id_User] [int] NULL,
 CONSTRAINT [PK_ThongTinGiaoDichNapTien] PRIMARY KEY CLUSTERED 
(
	[id_ThongTinGiaoDichNapTien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TinhThanh]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhThanh](
	[id_tinhthanh] [int] IDENTITY(1,1) NOT NULL,
	[Ten_tinhthanh] [nvarchar](100) NULL,
 CONSTRAINT [PK_TinhThanh] PRIMARY KEY CLUSTERED 
(
	[id_tinhthanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrangThai]    Script Date: 19/12/2024 00:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThai](
	[id_trangthai] [int] IDENTITY(1,1) NOT NULL,
	[ten_trangthai] [nvarchar](max) NULL,
 CONSTRAINT [PK_TrangThai] PRIMARY KEY CLUSTERED 
(
	[id_trangthai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BaiViet] ON 

INSERT [dbo].[BaiViet] ([id_baiviet], [tieu_de], [noi_dung], [ngay_tao], [id_User], [id_loaibaiviet], [id_trangthai]) VALUES (1, N'Bài viết 1', N'Nội dung bài viết 1', CAST(N'2024-06-08 04:04:26.197' AS DateTime), 1, 1, 1)
INSERT [dbo].[BaiViet] ([id_baiviet], [tieu_de], [noi_dung], [ngay_tao], [id_User], [id_loaibaiviet], [id_trangthai]) VALUES (2, N'Bài viết 1', N'Nội dung bài viết 1', CAST(N'2024-06-08 04:04:26.000' AS DateTime), 1, 1, 1)
INSERT [dbo].[BaiViet] ([id_baiviet], [tieu_de], [noi_dung], [ngay_tao], [id_User], [id_loaibaiviet], [id_trangthai]) VALUES (7, N'Tuấn Đan', N'Nhà Đẹp quá quá đẹp', CAST(N'2024-11-18 03:13:00.000' AS DateTime), 2, 3, 2)
SET IDENTITY_INSERT [dbo].[BaiViet] OFF
SET IDENTITY_INSERT [dbo].[DuongPho] ON 

INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (1, N'Đại Lộ Đông Tây', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (2, N'Đường Alexandre', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (3, N'Đường Bà Huyện Thanh Quan', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (4, N'Đường Bà Lê Chân', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (5, N'Đường Bến Chương Dương', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (6, N'Đường Bùi Thị Xuân', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (7, N'Đường Bùi Viện', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (8, N'Đường Cách Mạng Tháng Tám', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (9, N'Đường Calmette', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (10, N'Đường Camex', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (11, N'Đường Cao Bá Nhạ', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (12, N'Đường Cao Bá Quát', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (13, N'Đường Cây Điệp', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (14, N'Đường Chu Mạnh Trinh', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (15, N'Đường Cô Bắc', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (16, N'Đường Cô Giang', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (17, N'Đường Cống Quỳnh', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (18, N'Đường Công Trường Lam Sơn', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (19, N'Đường Công Trường Mê Linh', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (20, N'Đường Công Trường Quốc Tế', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (21, N'Đường Công Xã Paris', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (22, N'Đường Đặng Dung', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (23, N'Đường Đặng Tất', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (24, N'Đường Đặng Thị Nhu', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (25, N'Đường Đặng Trần Côn', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (26, N'Đường Đề Thám', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (27, N'Đường Điện Biên Phủ', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (28, N'Đường Đinh Công Tráng', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (29, N'Đường Đinh Tiên Hoàng', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (30, N'Đường Đỗ Quang Đẩu', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (31, N'Đường Đông Du', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (32, N'Đường Đồng Khởi', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (33, N'Đường Hai Bà Trưng', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (34, N'Đường Hải Triều', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (35, N'Đường Hàm Nghi', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (36, N'Đường Hàn Thuyên', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (37, N'Đường Hồ Hảo Hớn', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (38, N'Đường Hồ Huấn Nghiệp', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (39, N'Đường Hồ Tùng Mậu', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (40, N'Đường Hòa Hưng', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (41, N'Đường Hòa Mỹ', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (42, N'Đường Hoàng Diệu', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (43, N'Đường Hoàng Hoa Thám', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (44, N'Đường Hoàng Sa', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (45, N'Đường Huyền Quang', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (46, N'Đường Huyền Trân Công Chúa', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (47, N'Đường Huỳnh Khương An', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (48, N'Đường Huỳnh Khương Ninh', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (49, N'Đường Huỳnh Thúc Kháng', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (50, N'Đường Ký Con', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (51, N'Đường Lãnh Binh Thăng', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (52, N'Đường Lê Anh Xuân', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (53, N'Đường Lê Công Kiều', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (54, N'Đường Lê Duẩn', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (55, N'Đường Lê Đức Thọ', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (56, N'Đường Lê Hồng Phong', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (57, N'Đường Lê Lai', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (58, N'Đường Lê Lợi', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (59, N'Đường Lê Quý Đôn', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (60, N'Đường Lê Thánh Tôn', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (61, N'Đường Lê Thị Hồng Gấm', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (62, N'Đường Lê Thị Riêng', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (63, N'Đường Lê Văn Hưu', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (64, N'Đường Lương Hữu Khánh', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (65, N'Đường Lưu Văn Lang', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (66, N'Đường Lý Chính Thắng', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (67, N'Đường Lý Tự Trọng', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (68, N'Đường Lý Văn Phức', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (69, N'Đường Mã Lộ', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (70, N'Đường Mạc Đĩnh Chi', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (71, N'Đường Mạc Thị Bưởi', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (72, N'Đường Mai Thị Lựu', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (73, N'Đường Nam Kỳ Khởi Nghĩa', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (75, N'Đường Nam Quốc Cang', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (76, N'Đường Ngô Đức Kế', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (77, N'Đường Ngô Văn Năm', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (78, N'Đường Nguyễn An Ninh', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (79, N'Đường Nguyễn Bỉnh Khiêm', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (80, N'Đường Nguyễn Cảnh Chân', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (81, N'Đường Nguyễn Công Trứ', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (82, N'Đường Nguyễn Cư Trinh', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (83, N'Đường Nguyễn Đình Chiểu', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (84, N'Đường Nguyễn Doãn Khanh', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (85, N'Đường Nguyễn Du', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (86, N'Đường Nguyễn Huệ', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (87, N'Đường Nguyễn Hữu Cảnh', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (88, N'Đường Nguyễn Hữu Cầu', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (89, N'Đường Nguyễn Hữu Nghĩa', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (90, N'Đường Nguyễn Huy Tự', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (91, N'Đường Nguyễn Khắc Nhu', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (92, N'Đường Nguyễn Phi Khanh', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (93, N'Đường Nguyễn Siêu', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (94, N'Đường Nguyễn Thái Bình', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (95, N'Đường Nguyễn Thái Học', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (96, N'Đường Nguyễn Thành Ý', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (97, N'Đường Nguyễn Thị Diệu', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (98, N'Đường Nguyễn Thị Lắng', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (99, N'Đường Nguyễn Thị Minh Khai', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (100, N'Đường Nguyễn Thị Nghĩa', 1)
GO
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (101, N'Đường Nguyễn Thiệp', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (102, N'Đường Nguyễn Trãi', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (103, N'Đường Nguyễn Trung Ngạn', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (104, N'Đường Nguyễn Trung Trực', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (105, N'Đường Nguyễn Văn Bình', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (106, N'Đường Nguyễn Văn Chiêm', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (107, N'Đường Nguyễn Văn Cừ', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (108, N'Đường Nguyễn Văn Đại', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (109, N'Đường Nguyễn Văn Giai', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (110, N'Đường Nguyễn Văn Linh', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (111, N'Đường Nguyễn Văn Mai', 1)
INSERT [dbo].[DuongPho] ([id_duongpho], [Ten_duongpho], [id_phuongxa]) VALUES (112, N'Đường Nguyễn Văn Nguyễn', 1)
SET IDENTITY_INSERT [dbo].[DuongPho] OFF
SET IDENTITY_INSERT [dbo].[GiayTo_TaiLieu] ON 

INSERT [dbo].[GiayTo_TaiLieu] ([id_giayto_tailieu], [ten_giayto_tailieu]) VALUES (1, N'Sổ đỏ/ Sổ hồng')
INSERT [dbo].[GiayTo_TaiLieu] ([id_giayto_tailieu], [ten_giayto_tailieu]) VALUES (2, N'Giấy tờ hợp lệ')
INSERT [dbo].[GiayTo_TaiLieu] ([id_giayto_tailieu], [ten_giayto_tailieu]) VALUES (3, N'Giấy phép XD')
INSERT [dbo].[GiayTo_TaiLieu] ([id_giayto_tailieu], [ten_giayto_tailieu]) VALUES (4, N'Giấy phép KD')
SET IDENTITY_INSERT [dbo].[GiayTo_TaiLieu] OFF
SET IDENTITY_INSERT [dbo].[LichSuGiaoDich] ON 

INSERT [dbo].[LichSuGiaoDich] ([Id_GiaoDich], [id_User], [id_baiviet], [id_sanpham], [so_tien], [Loai_Giao_Dich], [Thoi_Gian_Giao_Dich]) VALUES (6, 2, NULL, 71, CAST(-10000.00 AS Decimal(18, 2)), N'Trừ tiền khi thêm bài viết', CAST(N'2024-12-18 06:49:42.470' AS DateTime))
INSERT [dbo].[LichSuGiaoDich] ([Id_GiaoDich], [id_User], [id_baiviet], [id_sanpham], [so_tien], [Loai_Giao_Dich], [Thoi_Gian_Giao_Dich]) VALUES (7, 2, NULL, 72, CAST(-10000.00 AS Decimal(18, 2)), N'Trừ tiền khi thêm Sản Phẩm', CAST(N'2024-12-18 06:56:00.280' AS DateTime))
SET IDENTITY_INSERT [dbo].[LichSuGiaoDich] OFF
SET IDENTITY_INSERT [dbo].[LoaiBaiViet] ON 

INSERT [dbo].[LoaiBaiViet] ([id_loaibaiviet], [tenloaibaiviet]) VALUES (1, N'Tin Tức')
INSERT [dbo].[LoaiBaiViet] ([id_loaibaiviet], [tenloaibaiviet]) VALUES (2, N'Chia Sẻ')
INSERT [dbo].[LoaiBaiViet] ([id_loaibaiviet], [tenloaibaiviet]) VALUES (3, N'Tư Vấn')
SET IDENTITY_INSERT [dbo].[LoaiBaiViet] OFF
SET IDENTITY_INSERT [dbo].[LoaiBDS] ON 

INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (1, N'Nhà mặt tiền')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (2, N'Nhà trong hẻm')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (3, N'Biệt thự, nhà liền kề')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (4, N'Căn hộ chung cư')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (5, N'Phòng trọ, nhà trọ')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (6, N'Văn phòng')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (7, N'Kho, xưởng')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (8, N'Nhà hàng, khách sạn')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (9, N'Shop, kiot, quán')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (10, N'Trang trại')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (11, N'Mặt bằng')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (12, N'Đất thổ cư, đất ở')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (13, N'Đất nền, liền kề, đất dự án')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (14, N'Đất nông, lâm nghiệp')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (15, N'Các loại khác')
INSERT [dbo].[LoaiBDS] ([id_loaibds], [ten_loaibds]) VALUES (16, N'Dự Án')
SET IDENTITY_INSERT [dbo].[LoaiBDS] OFF
SET IDENTITY_INSERT [dbo].[LoaiTaiKhoanUser] ON 

INSERT [dbo].[LoaiTaiKhoanUser] ([id_loaitk], [ten_loaitk]) VALUES (1, N'Cá nhân')
INSERT [dbo].[LoaiTaiKhoanUser] ([id_loaitk], [ten_loaitk]) VALUES (2, N'Nhà môi giới')
INSERT [dbo].[LoaiTaiKhoanUser] ([id_loaitk], [ten_loaitk]) VALUES (3, N'Admin')
SET IDENTITY_INSERT [dbo].[LoaiTaiKhoanUser] OFF
SET IDENTITY_INSERT [dbo].[LoaiTin] ON 

INSERT [dbo].[LoaiTin] ([id_loaitin], [ten_loaitin]) VALUES (1, N'Cần bán')
INSERT [dbo].[LoaiTin] ([id_loaitin], [ten_loaitin]) VALUES (2, N'Cho thuê')
INSERT [dbo].[LoaiTin] ([id_loaitin], [ten_loaitin]) VALUES (3, N'Cần mua')
SET IDENTITY_INSERT [dbo].[LoaiTin] OFF
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([id_menu], [title], [order], [link], [hide]) VALUES (1, N'Trang Chủ', 1, N'trang-chu', 0)
INSERT [dbo].[Menu] ([id_menu], [title], [order], [link], [hide]) VALUES (2, N'Nhà Đất Bán', 2, N'nha-dat-ban', 0)
INSERT [dbo].[Menu] ([id_menu], [title], [order], [link], [hide]) VALUES (3, N'Nhà Đất Cho Thuê', 3, N'nha-dat-cho-thue', 0)
INSERT [dbo].[Menu] ([id_menu], [title], [order], [link], [hide]) VALUES (4, N'Thành Viên Nhóm', 4, N'thanh-vien-nhom', 0)
INSERT [dbo].[Menu] ([id_menu], [title], [order], [link], [hide]) VALUES (5, N'Bài Viết', 5, N'bai-viet', 0)
INSERT [dbo].[Menu] ([id_menu], [title], [order], [link], [hide]) VALUES (6, N'Liên Hệ', 6, N'lien-he', 0)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[MomoCreatePaymentResponse] ON 

INSERT [dbo].[MomoCreatePaymentResponse] ([id_momo_create_payment], [RequestId], [ErrorCode], [OrderId], [Message], [LocalMessage], [RequestType], [PayUrl], [Signature], [QrCodeUrl], [Deeplink], [DeeplinkWebInApp], [CreatedAt], [id_User]) VALUES (64, N'638692913067539091', 0, N'638692913067539091', N'Success', N'Thành công', N'captureMoMoWallet', N'https://test-payment.momo.vn/v2/gateway/pay?s=8f5950c25bb661539ca1bee510feed0fe22df62b8b9fbc24d0ac401bd68ab6aa&t=TU9NT3w2Mzg2OTI5MTMwNjc1MzkwOTE', N'23481d91d52ec072627688c7a5651996b021843256d5ded45bab02ede504ae7a', N'momo://app?action=payWithApp&isScanQR=true&serviceType=qr&sid=TU9NT3w2Mzg2OTI5MTMwNjc1MzkwOTE&v=3.0', N'momo://app?action=payWithApp&isScanQR=false&serviceType=app&sid=TU9NT3w2Mzg2OTI5MTMwNjc1MzkwOTE&v=3.0', N'https://test-payment.momo.vn/gw_payment/waiting//momo//?type=webinapp&action=payment&requestId=638692913067539091&billId=638692913067539091&partnerCode=MOMO&partnerName=MoMo Payment&amount=10000&description=Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK&notifyUrl=https://localhost:5001/Home/MomoNotify&returnUrl=https://localhost:5001/Home/PaymentCallBack&code=momo&extraData=eyJzaWduYXR1cmUiOiJlYTQ4YzkxOTYzMjg1NDJmODU0YWJhZTYzYWFiYmMzYmY4YmNjOWEyYzQ2ZGQ3M2U2MjhhNjk3OWFhYWVlZDY5In0=&signature=ea48c9196328542f854abae63aabbc3bf8bcc9a2c46dd73e628a6979aaaeed69', CAST(N'2024-12-08 21:48:26.963' AS DateTime), NULL)
INSERT [dbo].[MomoCreatePaymentResponse] ([id_momo_create_payment], [RequestId], [ErrorCode], [OrderId], [Message], [LocalMessage], [RequestType], [PayUrl], [Signature], [QrCodeUrl], [Deeplink], [DeeplinkWebInApp], [CreatedAt], [id_User]) VALUES (65, N'638693210664425772', 0, N'638693210664425772', N'Success', N'Thành công', N'captureMoMoWallet', N'https://test-payment.momo.vn/v2/gateway/pay?s=f6c64dcc6c946e0dfdeeccf62298161470f209aaa396a079fc4bed2489d3699d&t=TU9NT3w2Mzg2OTMyMTA2NjQ0MjU3NzI', N'3d872db9f30cf990d1392b28b391cb9dc462a01b33f8a7d96d74dba49c37a459', N'momo://app?action=payWithApp&isScanQR=true&serviceType=qr&sid=TU9NT3w2Mzg2OTMyMTA2NjQ0MjU3NzI&v=3.0', N'momo://app?action=payWithApp&isScanQR=false&serviceType=app&sid=TU9NT3w2Mzg2OTMyMTA2NjQ0MjU3NzI&v=3.0', N'https://test-payment.momo.vn/gw_payment/waiting//momo//?type=webinapp&action=payment&requestId=638693210664425772&billId=638693210664425772&partnerCode=MOMO&partnerName=MoMo Payment&amount=10000&description=Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK&notifyUrl=https://localhost:5001/Home/MomoNotify&returnUrl=https://localhost:5001/Home/PaymentCallBack&code=momo&extraData=eyJzaWduYXR1cmUiOiJhNDBhZjMwMGZjMGQ3Y2M2ZmEzNzhjZTdlM2QzYTc5ODE1ZjA1NzAxZmMyOWQwNmM1NTc0NzgyZmVlOTRjMjM1In0=&signature=a40af300fc0d7cc6fa378ce7e3d3a79815f05701fc29d06c5574782fee94c235', CAST(N'2024-12-09 06:04:29.347' AS DateTime), NULL)
INSERT [dbo].[MomoCreatePaymentResponse] ([id_momo_create_payment], [RequestId], [ErrorCode], [OrderId], [Message], [LocalMessage], [RequestType], [PayUrl], [Signature], [QrCodeUrl], [Deeplink], [DeeplinkWebInApp], [CreatedAt], [id_User]) VALUES (66, N'638693265916662146', 0, N'638693265916662146', N'Success', N'Thành công', N'captureMoMoWallet', N'https://test-payment.momo.vn/v2/gateway/pay?s=e8e150dfbd42435eb270402666c0e34d8fb0e798ddf3b2e09f4c22ea4a483103&t=TU9NT3w2Mzg2OTMyNjU5MTY2NjIxNDY', N'8b1ffec8d138ff72c1f273052b85b59d6f6009b17ebdb88b389fa038c39b7f64', N'momo://app?action=payWithApp&isScanQR=true&serviceType=qr&sid=TU9NT3w2Mzg2OTMyNjU5MTY2NjIxNDY&v=3.0', N'momo://app?action=payWithApp&isScanQR=false&serviceType=app&sid=TU9NT3w2Mzg2OTMyNjU5MTY2NjIxNDY&v=3.0', N'https://test-payment.momo.vn/gw_payment/waiting//momo//?type=webinapp&action=payment&requestId=638693265916662146&billId=638693265916662146&partnerCode=MOMO&partnerName=MoMo Payment&amount=10000&description=Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK&notifyUrl=https://localhost:5001/Home/MomoNotify&returnUrl=https://localhost:5001/Home/PaymentCallBack&code=momo&extraData=eyJzaWduYXR1cmUiOiIwMmExMjYzNDY5M2YyMTdhMTVjMTlkMWU4MTA0ZWMxZTJlZTU2YmFiNDA5ZjlhOGIxY2E4YzU5MzdkMWRhNWM4In0=&signature=02a12634693f217a15c19d1e8104ec1e2ee56bab409f9a8b1ca8c5937d1da5c8', CAST(N'2024-12-09 07:36:32.880' AS DateTime), NULL)
INSERT [dbo].[MomoCreatePaymentResponse] ([id_momo_create_payment], [RequestId], [ErrorCode], [OrderId], [Message], [LocalMessage], [RequestType], [PayUrl], [Signature], [QrCodeUrl], [Deeplink], [DeeplinkWebInApp], [CreatedAt], [id_User]) VALUES (67, N'638695012207428323', 0, N'638695012207428323', N'Success', N'Thành công', N'captureMoMoWallet', N'https://test-payment.momo.vn/v2/gateway/pay?s=28a872a1e133d514da0097345bf0293f7ba6afb86b82825f55171c1a72d55781&t=TU9NT3w2Mzg2OTUwMTIyMDc0MjgzMjM', N'bde4b465466587636241e6a9b12c21dcbc0dad7481da09d0111103f83fdc5273', N'momo://app?action=payWithApp&isScanQR=true&serviceType=qr&sid=TU9NT3w2Mzg2OTUwMTIyMDc0MjgzMjM&v=3.0', N'momo://app?action=payWithApp&isScanQR=false&serviceType=app&sid=TU9NT3w2Mzg2OTUwMTIyMDc0MjgzMjM&v=3.0', N'https://test-payment.momo.vn/gw_payment/waiting//momo//?type=webinapp&action=payment&requestId=638695012207428323&billId=638695012207428323&partnerCode=MOMO&partnerName=MoMo Payment&amount=10000&description=Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK&notifyUrl=https://localhost:5001/Home/MomoNotify&returnUrl=https://localhost:5001/Home/PaymentCallBack&code=momo&extraData=eyJzaWduYXR1cmUiOiI3ZDljYzYyMTg5MmI1NGM1N2Q5MTQ0YWU0OTU3OGNmMmU2YjljYzEyMDQ4ODFjNGZlZjFiZjY5ZDQxN2ZiNGNiIn0=&signature=7d9cc621892b54c57d9144ae49578cf2e6b9cc1204881c4fef1bf69d417fb4cb', CAST(N'2024-12-11 08:07:02.527' AS DateTime), NULL)
INSERT [dbo].[MomoCreatePaymentResponse] ([id_momo_create_payment], [RequestId], [ErrorCode], [OrderId], [Message], [LocalMessage], [RequestType], [PayUrl], [Signature], [QrCodeUrl], [Deeplink], [DeeplinkWebInApp], [CreatedAt], [id_User]) VALUES (68, N'638695013230992758', 0, N'638695013230992758', N'Success', N'Thành công', N'captureMoMoWallet', N'https://test-payment.momo.vn/v2/gateway/pay?s=ea2e6c8d8d5d2509c3b971a70ba9b727271f242bbae248bc8635341c42cf16a7&t=TU9NT3w2Mzg2OTUwMTMyMzA5OTI3NTg', N'94e4e75ab26b25f11be9cd21e087f6105350bca092f3d4f7881e015f38606331', N'momo://app?action=payWithApp&isScanQR=true&serviceType=qr&sid=TU9NT3w2Mzg2OTUwMTMyMzA5OTI3NTg&v=3.0', N'momo://app?action=payWithApp&isScanQR=false&serviceType=app&sid=TU9NT3w2Mzg2OTUwMTMyMzA5OTI3NTg&v=3.0', N'https://test-payment.momo.vn/gw_payment/waiting//momo//?type=webinapp&action=payment&requestId=638695013230992758&billId=638695013230992758&partnerCode=MOMO&partnerName=MoMo Payment&amount=100000&description=Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK&notifyUrl=https://localhost:5001/Home/MomoNotify&returnUrl=https://localhost:5001/Home/PaymentCallBack&code=momo&extraData=eyJzaWduYXR1cmUiOiI4ZTBlZDJlNmZmOTY1YWJlMzk1MjRkNDc4NGEyODMyYzI1YjkyOWFmOWVkMjc3NDQyNGY1MWU2MTA1NDBiNjg3In0=&signature=8e0ed2e6ff965abe39524d4784a2832c25b929af9ed2774424f51e610540b687', CAST(N'2024-12-11 08:08:44.747' AS DateTime), NULL)
INSERT [dbo].[MomoCreatePaymentResponse] ([id_momo_create_payment], [RequestId], [ErrorCode], [OrderId], [Message], [LocalMessage], [RequestType], [PayUrl], [Signature], [QrCodeUrl], [Deeplink], [DeeplinkWebInApp], [CreatedAt], [id_User]) VALUES (69, N'638695273969293273', 0, N'638695273969293273', N'Success', N'Thành công', N'captureMoMoWallet', N'https://test-payment.momo.vn/v2/gateway/pay?s=538fde91eb7ad784175809b77f97b06fd63ebd80a8b04786b75e4c1e572cf35b&t=TU9NT3w2Mzg2OTUyNzM5NjkyOTMyNzM', N'75ae0fd8cc1697f6148534a6eab7c91c12142eb3500e4e5fc932bc5445443e28', N'momo://app?action=payWithApp&isScanQR=true&serviceType=qr&sid=TU9NT3w2Mzg2OTUyNzM5NjkyOTMyNzM&v=3.0', N'momo://app?action=payWithApp&isScanQR=false&serviceType=app&sid=TU9NT3w2Mzg2OTUyNzM5NjkyOTMyNzM&v=3.0', N'https://test-payment.momo.vn/gw_payment/waiting//momo//?type=webinapp&action=payment&requestId=638695273969293273&billId=638695273969293273&partnerCode=MOMO&partnerName=MoMo Payment&amount=20000&description=Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK&notifyUrl=https://localhost:5001/Home/MomoNotify&returnUrl=https://localhost:5001/Home/PaymentCallBack&code=momo&extraData=eyJzaWduYXR1cmUiOiIxMzZhMDFhNjlkYzZiNDI1ZWY0NjJlNmFkZDEyZDdjZWQ2OTMzY2RkYmUwYjNkYjk4YjU2ODE2YWRkNDZjZmViIn0=&signature=136a01a69dc6b425ef462e6add12d7ced6933cddbe0b3db98b56816add46cfeb', CAST(N'2024-12-11 15:23:17.397' AS DateTime), 2)
INSERT [dbo].[MomoCreatePaymentResponse] ([id_momo_create_payment], [RequestId], [ErrorCode], [OrderId], [Message], [LocalMessage], [RequestType], [PayUrl], [Signature], [QrCodeUrl], [Deeplink], [DeeplinkWebInApp], [CreatedAt], [id_User]) VALUES (70, N'638700769141564070', 0, N'638700769141564070', N'Success', N'Thành công', N'captureMoMoWallet', N'https://test-payment.momo.vn/v2/gateway/pay?s=b7234cbc4bc4bbf9245fe200ec786ee1d42130ff5307ff13db8f7004e3965a2e&t=TU9NT3w2Mzg3MDA3NjkxNDE1NjQwNzA', N'387c01ab1d4ff828291b0b381b2db132a9bb46847f151bae63f0586b107a0e18', N'momo://app?action=payWithApp&isScanQR=true&serviceType=qr&sid=TU9NT3w2Mzg3MDA3NjkxNDE1NjQwNzA&v=3.0', N'momo://app?action=payWithApp&isScanQR=false&serviceType=app&sid=TU9NT3w2Mzg3MDA3NjkxNDE1NjQwNzA&v=3.0', N'https://test-payment.momo.vn/gw_payment/waiting//momo//?type=webinapp&action=payment&requestId=638700769141564070&billId=638700769141564070&partnerCode=MOMO&partnerName=MoMo Payment&amount=120000&description=Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK&notifyUrl=https://localhost:5001/Home/MomoNotify&returnUrl=https://localhost:5001/Home/PaymentCallBack&code=momo&extraData=eyJzaWduYXR1cmUiOiIzMGQxNDMyOGU2ZGQ0MmQ0ZDIxZGM0ZWJiNjc1Yjg2YTc4MTgwOTdkNWIyMWUwNDA0NWMwNzM2M2UyMDM4Mjg3In0=&signature=30d14328e6dd42d4d21dc4ebb675b86a7818097d5b21e04045c07363e2038287', CAST(N'2024-12-18 00:01:54.663' AS DateTime), 2)
INSERT [dbo].[MomoCreatePaymentResponse] ([id_momo_create_payment], [RequestId], [ErrorCode], [OrderId], [Message], [LocalMessage], [RequestType], [PayUrl], [Signature], [QrCodeUrl], [Deeplink], [DeeplinkWebInApp], [CreatedAt], [id_User]) VALUES (71, N'638701327504061285', 0, N'638701327504061285', N'Success', N'Thành công', N'captureMoMoWallet', N'https://test-payment.momo.vn/v2/gateway/pay?s=4bcb0cd2c689725654ee296af8efd8057093dee9ff4cb37d56d2c9a1a9a00cbc&t=TU9NT3w2Mzg3MDEzMjc1MDQwNjEyODU', N'aaf397b2bce8ffae3b753e3097558d7f64120c7e23eb2e281ef1677351d8b9b7', N'momo://app?action=payWithApp&isScanQR=true&serviceType=qr&sid=TU9NT3w2Mzg3MDEzMjc1MDQwNjEyODU&v=3.0', N'momo://app?action=payWithApp&isScanQR=false&serviceType=app&sid=TU9NT3w2Mzg3MDEzMjc1MDQwNjEyODU&v=3.0', N'https://test-payment.momo.vn/gw_payment/waiting//momo//?type=webinapp&action=payment&requestId=638701327504061285&billId=638701327504061285&partnerCode=MOMO&partnerName=MoMo Payment&amount=10000&description=Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK&notifyUrl=https://localhost:5001/Home/MomoNotify&returnUrl=https://localhost:5001/Home/PaymentCallBack&code=momo&extraData=eyJzaWduYXR1cmUiOiI0Zjc3YjU2NTQ5MjM5N2ZiMDYzNTU1YmMxZmI1NDMwZGZkYTk5YmVhMTNmYzg2MDJkN2QwZWZmNzY5YzgwNWQ2In0=&signature=4f77b565492397fb063555bc1fb5430dfda99bea13fc8602d7d0eff769c805d6', CAST(N'2024-12-18 15:32:31.453' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[MomoCreatePaymentResponse] OFF
SET IDENTITY_INSERT [dbo].[MomoOption] ON 

INSERT [dbo].[MomoOption] ([id_momo_option], [MomoApiUrl], [SecretKey], [AccessKey], [ReturnUrl], [NotifyUrl], [PartnerCode], [RequestType], [CreatedAt], [id_User]) VALUES (63, N'https://test-payment.momo.vn/gw_payment/transactionProcessor', N'K951B6PE1waDMi640xX08PD3vg6EkVlz', N'F8BBA842ECF85', N'https://localhost:5001/Home/PaymentCallBack', N'https://localhost:5001/Home/MomoNotify', N'MOMO', N'captureMoMoWallet', CAST(N'2024-12-08 21:48:26.967' AS DateTime), NULL)
INSERT [dbo].[MomoOption] ([id_momo_option], [MomoApiUrl], [SecretKey], [AccessKey], [ReturnUrl], [NotifyUrl], [PartnerCode], [RequestType], [CreatedAt], [id_User]) VALUES (64, N'https://test-payment.momo.vn/gw_payment/transactionProcessor', N'K951B6PE1waDMi640xX08PD3vg6EkVlz', N'F8BBA842ECF85', N'https://localhost:5001/Home/PaymentCallBack', N'https://localhost:5001/Home/MomoNotify', N'MOMO', N'captureMoMoWallet', CAST(N'2024-12-09 06:04:29.417' AS DateTime), NULL)
INSERT [dbo].[MomoOption] ([id_momo_option], [MomoApiUrl], [SecretKey], [AccessKey], [ReturnUrl], [NotifyUrl], [PartnerCode], [RequestType], [CreatedAt], [id_User]) VALUES (65, N'https://test-payment.momo.vn/gw_payment/transactionProcessor', N'K951B6PE1waDMi640xX08PD3vg6EkVlz', N'F8BBA842ECF85', N'https://localhost:5001/Home/PaymentCallBack', N'https://localhost:5001/Home/MomoNotify', N'MOMO', N'captureMoMoWallet', CAST(N'2024-12-09 07:36:32.990' AS DateTime), NULL)
INSERT [dbo].[MomoOption] ([id_momo_option], [MomoApiUrl], [SecretKey], [AccessKey], [ReturnUrl], [NotifyUrl], [PartnerCode], [RequestType], [CreatedAt], [id_User]) VALUES (66, N'https://test-payment.momo.vn/gw_payment/transactionProcessor', N'K951B6PE1waDMi640xX08PD3vg6EkVlz', N'F8BBA842ECF85', N'https://localhost:5001/Home/PaymentCallBack', N'https://localhost:5001/Home/MomoNotify', N'MOMO', N'captureMoMoWallet', CAST(N'2024-12-11 08:07:02.577' AS DateTime), NULL)
INSERT [dbo].[MomoOption] ([id_momo_option], [MomoApiUrl], [SecretKey], [AccessKey], [ReturnUrl], [NotifyUrl], [PartnerCode], [RequestType], [CreatedAt], [id_User]) VALUES (67, N'https://test-payment.momo.vn/gw_payment/transactionProcessor', N'K951B6PE1waDMi640xX08PD3vg6EkVlz', N'F8BBA842ECF85', N'https://localhost:5001/Home/PaymentCallBack', N'https://localhost:5001/Home/MomoNotify', N'MOMO', N'captureMoMoWallet', CAST(N'2024-12-11 08:08:44.747' AS DateTime), NULL)
INSERT [dbo].[MomoOption] ([id_momo_option], [MomoApiUrl], [SecretKey], [AccessKey], [ReturnUrl], [NotifyUrl], [PartnerCode], [RequestType], [CreatedAt], [id_User]) VALUES (68, N'https://test-payment.momo.vn/gw_payment/transactionProcessor', N'K951B6PE1waDMi640xX08PD3vg6EkVlz', N'F8BBA842ECF85', N'https://localhost:5001/Home/PaymentCallBack', N'https://localhost:5001/Home/MomoNotify', N'MOMO', N'captureMoMoWallet', CAST(N'2024-12-11 15:23:17.473' AS DateTime), 2)
INSERT [dbo].[MomoOption] ([id_momo_option], [MomoApiUrl], [SecretKey], [AccessKey], [ReturnUrl], [NotifyUrl], [PartnerCode], [RequestType], [CreatedAt], [id_User]) VALUES (69, N'https://test-payment.momo.vn/gw_payment/transactionProcessor', N'K951B6PE1waDMi640xX08PD3vg6EkVlz', N'F8BBA842ECF85', N'https://localhost:5001/Home/PaymentCallBack', N'https://localhost:5001/Home/MomoNotify', N'MOMO', N'captureMoMoWallet', CAST(N'2024-12-18 00:01:54.710' AS DateTime), 2)
INSERT [dbo].[MomoOption] ([id_momo_option], [MomoApiUrl], [SecretKey], [AccessKey], [ReturnUrl], [NotifyUrl], [PartnerCode], [RequestType], [CreatedAt], [id_User]) VALUES (70, N'https://test-payment.momo.vn/gw_payment/transactionProcessor', N'K951B6PE1waDMi640xX08PD3vg6EkVlz', N'F8BBA842ECF85', N'https://localhost:5001/Home/PaymentCallBack', N'https://localhost:5001/Home/MomoNotify', N'MOMO', N'captureMoMoWallet', CAST(N'2024-12-18 15:32:31.663' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[MomoOption] OFF
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([id_User], [ten_truy_cap], [mat_khau], [ho_ten], [sdt], [email], [loai_tai_khoan_id], [ngay_dangky], [so_tien]) VALUES (1, N'admin', N'123456', N'Trịnh Tuấn Đan', N'0336656538', N'trinhtuandan@gmail.com', 3, CAST(N'2024-06-08 16:45:45.810' AS DateTime), NULL)
INSERT [dbo].[NguoiDung] ([id_User], [ten_truy_cap], [mat_khau], [ho_ten], [sdt], [email], [loai_tai_khoan_id], [ngay_dangky], [so_tien]) VALUES (2, N'tuandan', N'$2a$11$4NZfgmQ1hcWffvY0./qtiOIyu3YEqPuKUP36TmS3Ja4..C9llHVlG', N'trịnh tuấn đann', N'0336656538', N'trinhtuandan1601@gmail.com', 1, NULL, CAST(310000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguoiDung] ([id_User], [ten_truy_cap], [mat_khau], [ho_ten], [sdt], [email], [loai_tai_khoan_id], [ngay_dangky], [so_tien]) VALUES (3, N'admin1', N'$2a$11$A8Dd6SgbJ6CpNvuN.hQcwOWnjh3IJtVrUmLewpLVD9R7apge95mQm', N'trịnh tuấn đan1', N'0336656538', N'trinhtuandan1601@gmail.com', 3, NULL, NULL)
INSERT [dbo].[NguoiDung] ([id_User], [ten_truy_cap], [mat_khau], [ho_ten], [sdt], [email], [loai_tai_khoan_id], [ngay_dangky], [so_tien]) VALUES (9, N'user1', N'$2a$11$vEVMnErXTg8QQKH3Hodm7.BgbarkYCvXgrhp/nBpFr2XwOWKxnsEO', N'Trịnh Tuấn Đan2', N'0932516720', N'trinhtuandan1601@gmail.com', 2, NULL, NULL)
INSERT [dbo].[NguoiDung] ([id_User], [ten_truy_cap], [mat_khau], [ho_ten], [sdt], [email], [loai_tai_khoan_id], [ngay_dangky], [so_tien]) VALUES (10, N'admin2', N'$2a$11$YxxcmpwGfOEmB6gQKGf01eFXHtreCuPPf8iIJTOYk2eOlk/CmAPLy', N'Trịnh Tuấn Đan', N'0932516720', N'trinhtuandan1601@gmail.com', 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
SET IDENTITY_INSERT [dbo].[PhanHoiNapTienMomo] ON 

INSERT [dbo].[PhanHoiNapTienMomo] ([id_PhanHoiNapTienMomo], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (40, N'638692913067539091', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-12-08 21:48:26.987' AS DateTime), NULL)
INSERT [dbo].[PhanHoiNapTienMomo] ([id_PhanHoiNapTienMomo], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (41, N'638693210664425772', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-12-09 06:04:29.890' AS DateTime), NULL)
INSERT [dbo].[PhanHoiNapTienMomo] ([id_PhanHoiNapTienMomo], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (42, N'638693265916662146', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-12-09 07:36:33.693' AS DateTime), NULL)
INSERT [dbo].[PhanHoiNapTienMomo] ([id_PhanHoiNapTienMomo], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (43, N'638695012207428323', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-12-11 08:07:02.883' AS DateTime), NULL)
INSERT [dbo].[PhanHoiNapTienMomo] ([id_PhanHoiNapTienMomo], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (44, N'638695013230992758', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(100000.00 AS Decimal(18, 2)), CAST(N'2024-12-11 08:08:44.763' AS DateTime), NULL)
INSERT [dbo].[PhanHoiNapTienMomo] ([id_PhanHoiNapTienMomo], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (45, N'638695273969293273', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(20000.00 AS Decimal(18, 2)), CAST(N'2024-12-11 15:23:17.930' AS DateTime), 2)
INSERT [dbo].[PhanHoiNapTienMomo] ([id_PhanHoiNapTienMomo], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (46, N'638700769141564070', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(120000.00 AS Decimal(18, 2)), CAST(N'2024-12-18 00:01:54.820' AS DateTime), 2)
INSERT [dbo].[PhanHoiNapTienMomo] ([id_PhanHoiNapTienMomo], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (47, N'638701327504061285', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-12-18 15:32:33.027' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[PhanHoiNapTienMomo] OFF
SET IDENTITY_INSERT [dbo].[PhuongHuong] ON 

INSERT [dbo].[PhuongHuong] ([id_phuonghuong], [ten_phuonghuong]) VALUES (1, N'Không xác định')
INSERT [dbo].[PhuongHuong] ([id_phuonghuong], [ten_phuonghuong]) VALUES (2, N'Đông')
INSERT [dbo].[PhuongHuong] ([id_phuonghuong], [ten_phuonghuong]) VALUES (3, N'Tây')
INSERT [dbo].[PhuongHuong] ([id_phuonghuong], [ten_phuonghuong]) VALUES (4, N'Nam')
INSERT [dbo].[PhuongHuong] ([id_phuonghuong], [ten_phuonghuong]) VALUES (5, N'Bắc')
INSERT [dbo].[PhuongHuong] ([id_phuonghuong], [ten_phuonghuong]) VALUES (6, N'Đông Nam')
INSERT [dbo].[PhuongHuong] ([id_phuonghuong], [ten_phuonghuong]) VALUES (7, N'Đông Bắc')
INSERT [dbo].[PhuongHuong] ([id_phuonghuong], [ten_phuonghuong]) VALUES (8, N'Tây Nam')
INSERT [dbo].[PhuongHuong] ([id_phuonghuong], [ten_phuonghuong]) VALUES (9, N'Tây Bắc')
SET IDENTITY_INSERT [dbo].[PhuongHuong] OFF
SET IDENTITY_INSERT [dbo].[PhuongXa] ON 

INSERT [dbo].[PhuongXa] ([id_phuongxa], [Ten_phuongxa], [id_quanhuyen]) VALUES (1, N'Phường Bến Nghé', 1)
INSERT [dbo].[PhuongXa] ([id_phuongxa], [Ten_phuongxa], [id_quanhuyen]) VALUES (2, N'Phường Bến Thành', 1)
INSERT [dbo].[PhuongXa] ([id_phuongxa], [Ten_phuongxa], [id_quanhuyen]) VALUES (3, N'Phường Cầu Kho', 1)
INSERT [dbo].[PhuongXa] ([id_phuongxa], [Ten_phuongxa], [id_quanhuyen]) VALUES (4, N'Phường Cầu Ông Lãnh', 1)
INSERT [dbo].[PhuongXa] ([id_phuongxa], [Ten_phuongxa], [id_quanhuyen]) VALUES (5, N'Phường Cô Giang', 1)
INSERT [dbo].[PhuongXa] ([id_phuongxa], [Ten_phuongxa], [id_quanhuyen]) VALUES (6, N'Phường Đa Kao', 1)
INSERT [dbo].[PhuongXa] ([id_phuongxa], [Ten_phuongxa], [id_quanhuyen]) VALUES (7, N'Phường Nguyễn Công Trứ', 1)
INSERT [dbo].[PhuongXa] ([id_phuongxa], [Ten_phuongxa], [id_quanhuyen]) VALUES (8, N'Phường Nguyễn Cư Trinh', 1)
INSERT [dbo].[PhuongXa] ([id_phuongxa], [Ten_phuongxa], [id_quanhuyen]) VALUES (9, N'Phường Nguyễn Thái Bình', 1)
INSERT [dbo].[PhuongXa] ([id_phuongxa], [Ten_phuongxa], [id_quanhuyen]) VALUES (10, N'Phường Phạm Ngũ Lão', 1)
INSERT [dbo].[PhuongXa] ([id_phuongxa], [Ten_phuongxa], [id_quanhuyen]) VALUES (11, N'Phường Tân Định', 1)
SET IDENTITY_INSERT [dbo].[PhuongXa] OFF
SET IDENTITY_INSERT [dbo].[QuanHuyen] ON 

INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (1, N'Quận 1', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (2, N'Quận 2', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (3, N'Quận 3', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (4, N'Quận 4', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (5, N'Quận 5', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (6, N'Quận 6', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (7, N'Quận 7', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (8, N'Quận 8', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (9, N'Quận 9', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (10, N'Quận 10', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (11, N'Quận 11', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (12, N'Quận 12', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (13, N'Quận Bình Tân', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (14, N'Quận Bình Thạnh', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (15, N'Quận Gò Vấp', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (16, N'Quận Phú Nhuận', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (17, N'Quận Tân Bình', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (18, N'Quận Tân Phú', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (19, N'Thành phố Thủ Đức', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (20, N'Huyện Bình Chánh', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (21, N'Huyện Cần Giờ', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (22, N'Huyện Củ Chi', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (23, N'Huyện Hóc Môn', 2)
INSERT [dbo].[QuanHuyen] ([id_quanhuyen], [Ten_quanhuyen], [id_tinhthanh]) VALUES (24, N'Huyện Nhà Bè', 2)
SET IDENTITY_INSERT [dbo].[QuanHuyen] OFF
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([id_sanpham], [tieu_de_sanpham], [mo_ta_sanpham], [gia_san_pham], [dien_tich], [ngay_dang], [IMG1], [IMG2], [IMG3], [IMG4], [IMG5], [id_User], [id_giayto_tailieu], [id_loaitin], [id_loaibds], [id_tinhthanh], [id_quanhuyen], [id_phuongxa], [chieungang], [chieudai], [so_lau], [so_phong_ngu], [phong_an], [nha_bep], [san_thuong], [cho_de_xe_hoi], [dia_chi], [id_duongpho], [id_phuonghuong], [id_trangthai]) VALUES (1, N'NHÀ MẶT TIỀN KINH DOANH - ĐANG CHO THUÊ 8tr / tháng - GIÁ 800 triệu - SỔ HỒNG RIÊNG', N'NHÀ MẶT TIỀN KINH DOANH - ĐANG CHO THUÊ 8tr / tháng - GIÁ 800 triệu - SỔ HỒNG RIÊNG', 12, 12, CAST(N'2024-06-08 04:04:26.000' AS DateTime), N'ccabb1d5-21a6-43ce-8170-22fccd63a7ab.png', N'img-1.jpg', N'img-1.jpg', N'img-1.jpg', N'img-1.jpg', 1, 1, 1, 1, 2, 1, 1, N'12', N'12', 1, NULL, N'1', N'1', N'1', N'1', N'Hoàng Hữu Nam', 1, 1, 1)
INSERT [dbo].[SanPham] ([id_sanpham], [tieu_de_sanpham], [mo_ta_sanpham], [gia_san_pham], [dien_tich], [ngay_dang], [IMG1], [IMG2], [IMG3], [IMG4], [IMG5], [id_User], [id_giayto_tailieu], [id_loaitin], [id_loaibds], [id_tinhthanh], [id_quanhuyen], [id_phuongxa], [chieungang], [chieudai], [so_lau], [so_phong_ngu], [phong_an], [nha_bep], [san_thuong], [cho_de_xe_hoi], [dia_chi], [id_duongpho], [id_phuonghuong], [id_trangthai]) VALUES (2, N'khanh NHÀ MẶT TIỀN KINH DOANH - ĐANG CHO THUÊ 8tr / tháng - GIÁ 800 triệu - SỔ HỒNG RIÊNG', N'NHÀ MẶT TIỀN KINH DOANH - ĐANG CHO THUÊ 8tr / tháng - GIÁ 800 triệu - SỔ HỒNG RIÊNG', 12, 12, CAST(N'2024-06-08 04:04:26.000' AS DateTime), N'ccabb1d5-21a6-43ce-8170-22fccd63a7ab.png', N'img-1.jpg', N'img-1.jpg', N'img-1.jpg', N'img-1.jpg', 1, 1, 1, 1, 1, 1, 1, N'12', N'12', 1, NULL, N'1', N'1', N'1', N'1', N'Hoàng Hữu Nam', 1, 1, 1)
INSERT [dbo].[SanPham] ([id_sanpham], [tieu_de_sanpham], [mo_ta_sanpham], [gia_san_pham], [dien_tich], [ngay_dang], [IMG1], [IMG2], [IMG3], [IMG4], [IMG5], [id_User], [id_giayto_tailieu], [id_loaitin], [id_loaibds], [id_tinhthanh], [id_quanhuyen], [id_phuongxa], [chieungang], [chieudai], [so_lau], [so_phong_ngu], [phong_an], [nha_bep], [san_thuong], [cho_de_xe_hoi], [dia_chi], [id_duongpho], [id_phuonghuong], [id_trangthai]) VALUES (3, N'Khanh Dan NHÀ MẶT TIỀN KINH DOANH - ĐANG CHO THUÊ 8tr / tháng - GIÁ 800 triệu - SỔ HỒNG RIÊNG', N'NHÀ MẶT TIỀN KINH DOANH - ĐANG CHO THUÊ 8tr / tháng - GIÁ 800 triệu - SỔ HỒNG RIÊNG', 12, 12, CAST(N'2024-06-08 04:04:26.000' AS DateTime), N'ccabb1d5-21a6-43ce-8170-22fccd63a7ab.png', N'img-1.jpg', N'img-1.jpg', N'img-1.jpg', N'img-1.jpg', 1, 1, 1, 1, 1, 1, 1, N'12', N'12', 1, NULL, N'1', N'1', N'1', N'1', N'Hoàng Hữu Nam', 1, 1, 1)
INSERT [dbo].[SanPham] ([id_sanpham], [tieu_de_sanpham], [mo_ta_sanpham], [gia_san_pham], [dien_tich], [ngay_dang], [IMG1], [IMG2], [IMG3], [IMG4], [IMG5], [id_User], [id_giayto_tailieu], [id_loaitin], [id_loaibds], [id_tinhthanh], [id_quanhuyen], [id_phuongxa], [chieungang], [chieudai], [so_lau], [so_phong_ngu], [phong_an], [nha_bep], [san_thuong], [cho_de_xe_hoi], [dia_chi], [id_duongpho], [id_phuonghuong], [id_trangthai]) VALUES (67, N'NHÀ MẶT TIỀN KINH DOANH - ĐANG CHO THUÊ 8tr / tháng - GIÁ 800 triệu - SỔ HỒNG RIÊNG', N'NHÀ MẶT TIỀN KINH DOANH - ĐANG CHO THUÊ 8tr / tháng - GIÁ 800 triệu - SỔ HỒNG RIÊNG', 12, 12, CAST(N'2024-12-11 05:56:12.190' AS DateTime), N'ccabb1d5-21a6-43ce-8170-22fccd63a7ab.png', N'585e6288-45ab-4f8c-a9fa-5a6799e5d4d2.jpg', N'e4abaa7d-54eb-4925-b4bc-bc11c8ba788c.jpg', N'0d4d43b8-5d2c-4a38-98ee-f7f28b934d6f.jpg', N'116b2bd7-14eb-4c18-b4bb-f6c8abf76e92.png', 1, 4, 1, 15, 6, 20, 1, N'12', N'12', 12, N'12', N'Có', N'Có', N'Có', N'Có', N'12', 1, 5, 1)
INSERT [dbo].[SanPham] ([id_sanpham], [tieu_de_sanpham], [mo_ta_sanpham], [gia_san_pham], [dien_tich], [ngay_dang], [IMG1], [IMG2], [IMG3], [IMG4], [IMG5], [id_User], [id_giayto_tailieu], [id_loaitin], [id_loaibds], [id_tinhthanh], [id_quanhuyen], [id_phuongxa], [chieungang], [chieudai], [so_lau], [so_phong_ngu], [phong_an], [nha_bep], [san_thuong], [cho_de_xe_hoi], [dia_chi], [id_duongpho], [id_phuonghuong], [id_trangthai]) VALUES (68, N'NHÀ MẶT TIỀN KINH DOANH - ĐANG CHO THUÊ 8tr / tháng - GIÁ 800 triệu - SỔ HỒNG RIÊNG', N'NHÀ MẶT TIỀN KINH DOANH - ĐANG CHO THUÊ 8tr / tháng - GIÁ 800 triệu - SỔ HỒNG RIÊNG', 13, 13, CAST(N'2024-12-11 06:05:41.193' AS DateTime), N'b628de23-0ace-489c-a9a0-0c74c3249b1e_20241210230540.png', N'273e5eea-de5e-4615-a30f-6c472a42160d_20241210230540.jpg', N'886fcc5c-cfb7-455e-b2fd-6d65a91617ce_20241210230540.jpg', N'bbed4beb-7678-4db2-aa85-d6bf41ba35a6_20241210230540.jpg', N'84008526-6adb-4547-8714-ab5bf3c583ed_20241210230540.png', 1, 2, 1, 15, 7, 20, 2, N'13', N'13', 13, N'13', N'Có', N'Có', N'Có', N'Có', N'13', 1, 7, 1)
INSERT [dbo].[SanPham] ([id_sanpham], [tieu_de_sanpham], [mo_ta_sanpham], [gia_san_pham], [dien_tich], [ngay_dang], [IMG1], [IMG2], [IMG3], [IMG4], [IMG5], [id_User], [id_giayto_tailieu], [id_loaitin], [id_loaibds], [id_tinhthanh], [id_quanhuyen], [id_phuongxa], [chieungang], [chieudai], [so_lau], [so_phong_ngu], [phong_an], [nha_bep], [san_thuong], [cho_de_xe_hoi], [dia_chi], [id_duongpho], [id_phuonghuong], [id_trangthai]) VALUES (69, N'NHÀ MẶT TIỀN KINH DOANH - ĐANG CHO THUÊ 8tr / tháng - GIÁ 800 triệu - SỔ HỒNG RIÊNG', N'NHÀ MẶT TIỀN KINH DOANH - ĐANG CHO THUÊ 8tr / tháng - GIÁ 800 triệu - SỔ HỒNG RIÊNG', 12, 12, CAST(N'2024-12-11 06:16:36.820' AS DateTime), N'51f6540b-7bb2-40bc-b14d-3deba137ec42_20241210231635.png', N'c45e8716-f142-4706-9be2-48d93aa48887_20241210231635.jpg', N'fa95297f-ccc0-44ba-9218-d3bdd889fb49_20241210231635.jpg', N'8fd6354e-3932-4ab6-97f3-6b4cd0e93619_20241210231635.jpg', N'c75abba4-5f44-452a-8817-0d3628271bfd_20241210231635.png', 2, 3, 3, 4, 7, 21, 2, N'12', N'12', 12, N'12', N'Có', N'Có', N'Có', N'Có', N'12', 2, 7, 1)
INSERT [dbo].[SanPham] ([id_sanpham], [tieu_de_sanpham], [mo_ta_sanpham], [gia_san_pham], [dien_tich], [ngay_dang], [IMG1], [IMG2], [IMG3], [IMG4], [IMG5], [id_User], [id_giayto_tailieu], [id_loaitin], [id_loaibds], [id_tinhthanh], [id_quanhuyen], [id_phuongxa], [chieungang], [chieudai], [so_lau], [so_phong_ngu], [phong_an], [nha_bep], [san_thuong], [cho_de_xe_hoi], [dia_chi], [id_duongpho], [id_phuonghuong], [id_trangthai]) VALUES (71, N'haha', N'123', 12, 12, CAST(N'2024-12-18 06:49:42.400' AS DateTime), N'9c07b46e-04f2-4ab5-bcec-2c0a010b7a15_20241217234942.jpg', N'37afdd0b-5fe3-4620-a8ad-fd9bc26bfa3f_20241217234942.jpg', N'c1b40614-07c6-4f12-ab22-bd2f621b767a_20241217234942.jpg', N'4e29882c-e49b-437d-94ce-d8a4b6d7e4a1_20241217234942.jpg', N'f8ee9145-fe12-4b5d-aaff-2134f82bc686_20241217234942.jpg', 2, 3, 3, 15, 7, 20, 1, N'12', N'12', 12, N'12', N'Có', N'Không', N'Có', N'Có', N'12', 1, 2, 1)
INSERT [dbo].[SanPham] ([id_sanpham], [tieu_de_sanpham], [mo_ta_sanpham], [gia_san_pham], [dien_tich], [ngay_dang], [IMG1], [IMG2], [IMG3], [IMG4], [IMG5], [id_User], [id_giayto_tailieu], [id_loaitin], [id_loaibds], [id_tinhthanh], [id_quanhuyen], [id_phuongxa], [chieungang], [chieudai], [so_lau], [so_phong_ngu], [phong_an], [nha_bep], [san_thuong], [cho_de_xe_hoi], [dia_chi], [id_duongpho], [id_phuonghuong], [id_trangthai]) VALUES (72, N'haha', N'12', 12, 12, CAST(N'2024-12-18 06:56:00.173' AS DateTime), N'13ea3cb2-0708-4249-a48e-c5035d1aa758_20241217235559.jpg', N'217e4808-d5b7-43f2-8a5f-1a7c9fc8685e_20241217235559.jpg', N'11fe7189-599f-4a47-b74d-2a3e3bad7e06_20241217235559.jpg', N'b1188d6c-abb2-4b5c-b605-3c58124bede1_20241217235559.jpg', N'ea8dfd93-5bf7-44eb-9f61-0ce1f68f3b44_20241217235559.jpg', 2, 3, 3, 4, 9, 20, 2, N'12', N'12', 12, N'12', N'Không', N'Có', N'Có', N'Có', N'12', 2, 2, 1)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
SET IDENTITY_INSERT [dbo].[ThongTinGiaoDichNapTien] ON 

INSERT [dbo].[ThongTinGiaoDichNapTien] ([id_ThongTinGiaoDichNapTien], [FullName], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (68, N'trịnh tuấn đann', N'638692913067539091', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-12-09 04:48:26.980' AS DateTime), 2)
INSERT [dbo].[ThongTinGiaoDichNapTien] ([id_ThongTinGiaoDichNapTien], [FullName], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (69, N'trịnh tuấn đann', N'638693210664425772', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-12-09 13:04:29.800' AS DateTime), 2)
INSERT [dbo].[ThongTinGiaoDichNapTien] ([id_ThongTinGiaoDichNapTien], [FullName], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (70, N'trịnh tuấn đann', N'638693265916662146', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-12-09 14:36:33.573' AS DateTime), 2)
INSERT [dbo].[ThongTinGiaoDichNapTien] ([id_ThongTinGiaoDichNapTien], [FullName], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (71, N'trịnh tuấn đann', N'638695012207428323', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-12-11 15:07:02.833' AS DateTime), 2)
INSERT [dbo].[ThongTinGiaoDichNapTien] ([id_ThongTinGiaoDichNapTien], [FullName], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (72, N'trịnh tuấn đann', N'638695013230992758', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(100000.00 AS Decimal(18, 2)), CAST(N'2024-12-11 15:08:44.760' AS DateTime), 2)
INSERT [dbo].[ThongTinGiaoDichNapTien] ([id_ThongTinGiaoDichNapTien], [FullName], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (73, N'trịnh tuấn đann', N'638695273969293273', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(20000.00 AS Decimal(18, 2)), CAST(N'2024-12-11 22:23:17.863' AS DateTime), 2)
INSERT [dbo].[ThongTinGiaoDichNapTien] ([id_ThongTinGiaoDichNapTien], [FullName], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (74, N'trịnh tuấn đann', N'638700769141564070', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(120000.00 AS Decimal(18, 2)), CAST(N'2024-12-18 07:01:54.803' AS DateTime), 2)
INSERT [dbo].[ThongTinGiaoDichNapTien] ([id_ThongTinGiaoDichNapTien], [FullName], [OrderId], [OrderInfo], [Amount], [CreatedAt], [id_User]) VALUES (75, N'trịnh tuấn đann', N'638701327504061285', N'Khách hàng: trịnh tuấn đann. Nội dung: Thanh toán tại Web Bất Động Sản DK', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-12-18 22:32:32.863' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[ThongTinGiaoDichNapTien] OFF
SET IDENTITY_INSERT [dbo].[TinhThanh] ON 

INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (1, N'Hà Nội')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (2, N'Hồ Chí Minh')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (3, N'Đà Nẵng')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (4, N'Hải Phòng')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (5, N'Cần Thơ')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (6, N'An Giang')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (7, N'Bà Rịa-Vũng Tàu')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (8, N'Bạc Liêu')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (9, N'Bắc Cạn')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (10, N'Bắc Giang')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (11, N'Bắc Ninh')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (12, N'Bến Tre')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (13, N'Bình Dương')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (14, N'Bình Định')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (15, N'Bình Phước')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (16, N'Bình Thuận')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (17, N'Cà Mau')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (18, N'Cao Bằng')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (19, N'Đắk Lắk')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (20, N'Đăk Nông')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (21, N'Điện Biên')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (22, N'Đồng Nai')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (23, N'Đồng Tháp')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (24, N'Gia Lai')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (25, N'Hà Giang')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (26, N'Hà Nam')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (27, N'Hà Tĩnh')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (28, N'Hải Dương')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (29, N'Hậu Giang')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (30, N'Hòa Bình')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (31, N'Hưng Yên')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (32, N'Khánh Hòa')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (33, N'Kiên Giang')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (34, N'Kon Tum')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (35, N'Lai Châu')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (36, N'Lâm Đồng')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (37, N'Lạng Sơn')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (38, N'Lào Cai')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (39, N'Long An')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (40, N'Nam Định')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (41, N'Nghệ An')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (42, N'Ninh Bình')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (43, N'Ninh Thuận')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (44, N'Phú Thọ')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (45, N'Phú Yên')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (46, N'Quảng Bình')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (47, N'Quảng Nam')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (48, N'Quảng Ngãi')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (49, N'Quảng Ninh')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (50, N'Quảng Trị')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (51, N'Sóc Trăng')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (52, N'Sơn La')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (53, N'Tây Ninh')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (54, N'Thái Bình')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (55, N'Thái Nguyên')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (56, N'Thanh Hóa')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (57, N'Thừa Thiên-Huế')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (58, N'Tiền Giang')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (59, N'Trà Vinh')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (60, N'Tuyên Quang')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (61, N'Vĩnh Long')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (62, N'Vĩnh Phúc')
INSERT [dbo].[TinhThanh] ([id_tinhthanh], [Ten_tinhthanh]) VALUES (63, N'Yên Bái')
SET IDENTITY_INSERT [dbo].[TinhThanh] OFF
SET IDENTITY_INSERT [dbo].[TrangThai] ON 

INSERT [dbo].[TrangThai] ([id_trangthai], [ten_trangthai]) VALUES (1, N'Đã duyệt')
INSERT [dbo].[TrangThai] ([id_trangthai], [ten_trangthai]) VALUES (2, N'Chờ duyệt')
INSERT [dbo].[TrangThai] ([id_trangthai], [ten_trangthai]) VALUES (3, N'Bị từ chối')
INSERT [dbo].[TrangThai] ([id_trangthai], [ten_trangthai]) VALUES (4, N'Đang chờ duyệt')
INSERT [dbo].[TrangThai] ([id_trangthai], [ten_trangthai]) VALUES (5, N'Đã ẩn')
SET IDENTITY_INSERT [dbo].[TrangThai] OFF
ALTER TABLE [dbo].[BinhLuan] ADD  CONSTRAINT [DF_BinhLuan_ngay_tao]  DEFAULT (getdate()) FOR [ngay_tao]
GO
ALTER TABLE [dbo].[LienHe] ADD  CONSTRAINT [DF_LienHe_thoi_gian_gui]  DEFAULT (getdate()) FOR [thoi_gian_gui]
GO
ALTER TABLE [dbo].[BaiViet]  WITH CHECK ADD  CONSTRAINT [FK_BaiViet_LoaiBaiViet] FOREIGN KEY([id_loaibaiviet])
REFERENCES [dbo].[LoaiBaiViet] ([id_loaibaiviet])
GO
ALTER TABLE [dbo].[BaiViet] CHECK CONSTRAINT [FK_BaiViet_LoaiBaiViet]
GO
ALTER TABLE [dbo].[BaiViet]  WITH CHECK ADD  CONSTRAINT [FK_BaiViet_NguoiDung] FOREIGN KEY([id_User])
REFERENCES [dbo].[NguoiDung] ([id_User])
GO
ALTER TABLE [dbo].[BaiViet] CHECK CONSTRAINT [FK_BaiViet_NguoiDung]
GO
ALTER TABLE [dbo].[BaiViet]  WITH CHECK ADD  CONSTRAINT [FK_BaiViet_TrangThai] FOREIGN KEY([id_trangthai])
REFERENCES [dbo].[TrangThai] ([id_trangthai])
GO
ALTER TABLE [dbo].[BaiViet] CHECK CONSTRAINT [FK_BaiViet_TrangThai]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_BaiViet] FOREIGN KEY([id_baiviet])
REFERENCES [dbo].[BaiViet] ([id_baiviet])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_BaiViet]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_BinhLuan] FOREIGN KEY([binh_luan_cha_id])
REFERENCES [dbo].[BinhLuan] ([id_binhluan])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_BinhLuan]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_NguoiDung] FOREIGN KEY([id_User])
REFERENCES [dbo].[NguoiDung] ([id_User])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_NguoiDung]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_SanPham] FOREIGN KEY([id_sanpham])
REFERENCES [dbo].[SanPham] ([id_sanpham])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_SanPham]
GO
ALTER TABLE [dbo].[DuongPho]  WITH CHECK ADD  CONSTRAINT [FK_DuongPho_PhuongXa] FOREIGN KEY([id_phuongxa])
REFERENCES [dbo].[PhuongXa] ([id_phuongxa])
GO
ALTER TABLE [dbo].[DuongPho] CHECK CONSTRAINT [FK_DuongPho_PhuongXa]
GO
ALTER TABLE [dbo].[LichSuGiaoDich]  WITH CHECK ADD  CONSTRAINT [FK_LichSuGiaoDich_BaiViet] FOREIGN KEY([id_baiviet])
REFERENCES [dbo].[BaiViet] ([id_baiviet])
GO
ALTER TABLE [dbo].[LichSuGiaoDich] CHECK CONSTRAINT [FK_LichSuGiaoDich_BaiViet]
GO
ALTER TABLE [dbo].[LichSuGiaoDich]  WITH CHECK ADD  CONSTRAINT [FK_LichSuGiaoDich_NguoiDung] FOREIGN KEY([id_User])
REFERENCES [dbo].[NguoiDung] ([id_User])
GO
ALTER TABLE [dbo].[LichSuGiaoDich] CHECK CONSTRAINT [FK_LichSuGiaoDich_NguoiDung]
GO
ALTER TABLE [dbo].[LichSuGiaoDich]  WITH CHECK ADD  CONSTRAINT [FK_LichSuGiaoDich_SanPham] FOREIGN KEY([id_sanpham])
REFERENCES [dbo].[SanPham] ([id_sanpham])
GO
ALTER TABLE [dbo].[LichSuGiaoDich] CHECK CONSTRAINT [FK_LichSuGiaoDich_SanPham]
GO
ALTER TABLE [dbo].[LienHe]  WITH CHECK ADD  CONSTRAINT [FK_LienHe_NguoiDung] FOREIGN KEY([id_User])
REFERENCES [dbo].[NguoiDung] ([id_User])
GO
ALTER TABLE [dbo].[LienHe] CHECK CONSTRAINT [FK_LienHe_NguoiDung]
GO
ALTER TABLE [dbo].[MomoCreatePaymentResponse]  WITH CHECK ADD  CONSTRAINT [FK_MomoCreatePaymentResponse_NguoiDung] FOREIGN KEY([id_User])
REFERENCES [dbo].[NguoiDung] ([id_User])
GO
ALTER TABLE [dbo].[MomoCreatePaymentResponse] CHECK CONSTRAINT [FK_MomoCreatePaymentResponse_NguoiDung]
GO
ALTER TABLE [dbo].[MomoOption]  WITH CHECK ADD  CONSTRAINT [FK_MomoOption_NguoiDung] FOREIGN KEY([id_User])
REFERENCES [dbo].[NguoiDung] ([id_User])
GO
ALTER TABLE [dbo].[MomoOption] CHECK CONSTRAINT [FK_MomoOption_NguoiDung]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_LoaiTaiKhoanUser1] FOREIGN KEY([loai_tai_khoan_id])
REFERENCES [dbo].[LoaiTaiKhoanUser] ([id_loaitk])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_LoaiTaiKhoanUser1]
GO
ALTER TABLE [dbo].[PhanHoiNapTienMomo]  WITH CHECK ADD  CONSTRAINT [FK_PhanHoiNapTienMomo_NguoiDung] FOREIGN KEY([id_User])
REFERENCES [dbo].[NguoiDung] ([id_User])
GO
ALTER TABLE [dbo].[PhanHoiNapTienMomo] CHECK CONSTRAINT [FK_PhanHoiNapTienMomo_NguoiDung]
GO
ALTER TABLE [dbo].[PhuongXa]  WITH CHECK ADD  CONSTRAINT [FK_PhuongXa_QuanHuyen] FOREIGN KEY([id_quanhuyen])
REFERENCES [dbo].[QuanHuyen] ([id_quanhuyen])
GO
ALTER TABLE [dbo].[PhuongXa] CHECK CONSTRAINT [FK_PhuongXa_QuanHuyen]
GO
ALTER TABLE [dbo].[QuanHuyen]  WITH CHECK ADD  CONSTRAINT [FK_QuanHuyen_TinhThanh] FOREIGN KEY([id_tinhthanh])
REFERENCES [dbo].[TinhThanh] ([id_tinhthanh])
GO
ALTER TABLE [dbo].[QuanHuyen] CHECK CONSTRAINT [FK_QuanHuyen_TinhThanh]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_DuongPho] FOREIGN KEY([id_duongpho])
REFERENCES [dbo].[DuongPho] ([id_duongpho])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_DuongPho]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_GiayTo_TaiLieu] FOREIGN KEY([id_giayto_tailieu])
REFERENCES [dbo].[GiayTo_TaiLieu] ([id_giayto_tailieu])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_GiayTo_TaiLieu]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiBDS] FOREIGN KEY([id_loaibds])
REFERENCES [dbo].[LoaiBDS] ([id_loaibds])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiBDS]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiTin] FOREIGN KEY([id_loaitin])
REFERENCES [dbo].[LoaiTin] ([id_loaitin])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiTin]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NguoiDung] FOREIGN KEY([id_User])
REFERENCES [dbo].[NguoiDung] ([id_User])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NguoiDung]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_PhuongHuong] FOREIGN KEY([id_phuonghuong])
REFERENCES [dbo].[PhuongHuong] ([id_phuonghuong])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_PhuongHuong]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_PhuongXa] FOREIGN KEY([id_phuongxa])
REFERENCES [dbo].[PhuongXa] ([id_phuongxa])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_PhuongXa]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_QuanHuyen] FOREIGN KEY([id_quanhuyen])
REFERENCES [dbo].[QuanHuyen] ([id_quanhuyen])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_QuanHuyen]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_TinhThanh] FOREIGN KEY([id_tinhthanh])
REFERENCES [dbo].[TinhThanh] ([id_tinhthanh])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_TinhThanh]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_TrangThai] FOREIGN KEY([id_trangthai])
REFERENCES [dbo].[TrangThai] ([id_trangthai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_TrangThai]
GO
ALTER TABLE [dbo].[ThongTinGiaoDichNapTien]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinGiaoDichNapTien_NguoiDung] FOREIGN KEY([id_User])
REFERENCES [dbo].[NguoiDung] ([id_User])
GO
ALTER TABLE [dbo].[ThongTinGiaoDichNapTien] CHECK CONSTRAINT [FK_ThongTinGiaoDichNapTien_NguoiDung]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tiêu Đề' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaiViet', @level2type=N'COLUMN',@level2name=N'tieu_de'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nội Dung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaiViet', @level2type=N'COLUMN',@level2name=N'noi_dung'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày Tạo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaiViet', @level2type=N'COLUMN',@level2name=N'ngay_tao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Họ Tên' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaiViet', @level2type=N'COLUMN',@level2name=N'id_User'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Loại Bài Viết' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaiViet', @level2type=N'COLUMN',@level2name=N'id_loaibaiviet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Trạng Thái' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaiViet', @level2type=N'COLUMN',@level2name=N'id_trangthai'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaiViet', @level2type=N'CONSTRAINT',@level2name=N'FK_BaiViet_LoaiBaiViet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nội Dung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BinhLuan', @level2type=N'COLUMN',@level2name=N'noi_dung'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sản Phẩm' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BinhLuan', @level2type=N'COLUMN',@level2name=N'id_sanpham'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bài Viết' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BinhLuan', @level2type=N'COLUMN',@level2name=N'id_baiviet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày Tạo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BinhLuan', @level2type=N'COLUMN',@level2name=N'ngay_tao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tên Người Dùng' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BinhLuan', @level2type=N'COLUMN',@level2name=N'id_User'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Đường Phố' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DuongPho', @level2type=N'COLUMN',@level2name=N'Ten_duongpho'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Phường Xã' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DuongPho', @level2type=N'COLUMN',@level2name=N'id_phuongxa'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tên Tài Liệu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GiayTo_TaiLieu', @level2type=N'COLUMN',@level2name=N'ten_giayto_tailieu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bài Viết' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LichSuGiaoDich', @level2type=N'COLUMN',@level2name=N'id_baiviet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sản Phẩm' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LichSuGiaoDich', @level2type=N'COLUMN',@level2name=N'id_sanpham'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tiêu Đề' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LienHe', @level2type=N'COLUMN',@level2name=N'tieu_de'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nội Dung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LienHe', @level2type=N'COLUMN',@level2name=N'noi_dung'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Thời Gian Gửi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LienHe', @level2type=N'COLUMN',@level2name=N'thoi_gian_gui'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mã Người Dùng' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LienHe', @level2type=N'COLUMN',@level2name=N'id_User'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Họ Tên' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LienHe', @level2type=N'COLUMN',@level2name=N'ho_ten'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LienHe', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tên Loại Bài Viết' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoaiBaiViet', @level2type=N'COLUMN',@level2name=N'tenloaibaiviet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tên Loại BĐS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoaiBDS', @level2type=N'COLUMN',@level2name=N'ten_loaibds'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tên loại Tài Khoản' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoaiTaiKhoanUser', @level2type=N'COLUMN',@level2name=N'ten_loaitk'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tên Loại Tin' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoaiTin', @level2type=N'COLUMN',@level2name=N'ten_loaitin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tên Menu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id Oder' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Link ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'link'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quyền' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'hide'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tên Truy Cập' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NguoiDung', @level2type=N'COLUMN',@level2name=N'ten_truy_cap'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mật Khẩu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NguoiDung', @level2type=N'COLUMN',@level2name=N'mat_khau'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Họ tên' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NguoiDung', @level2type=N'COLUMN',@level2name=N'ho_ten'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SĐT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NguoiDung', @level2type=N'COLUMN',@level2name=N'sdt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NguoiDung', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Loại Tài Khoản' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NguoiDung', @level2type=N'COLUMN',@level2name=N'loai_tai_khoan_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày Đăng Ký' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NguoiDung', @level2type=N'COLUMN',@level2name=N'ngay_dangky'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Số Tiền' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NguoiDung', @level2type=N'COLUMN',@level2name=N'so_tien'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Phương Hướng' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PhuongHuong', @level2type=N'COLUMN',@level2name=N'ten_phuonghuong'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quận Huyện' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuanHuyen', @level2type=N'COLUMN',@level2name=N'Ten_quanhuyen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tỉnh Thành' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuanHuyen', @level2type=N'COLUMN',@level2name=N'id_tinhthanh'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tiêu Đề' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'tieu_de_sanpham'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mô Tả' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'mo_ta_sanpham'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Giá ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'gia_san_pham'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Diện Tích' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'dien_tich'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày Đăng' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'ngay_dang'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ảnh 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'IMG1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ảnh 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'IMG2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ảnh 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'IMG3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ảnh 4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'IMG4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ảnh 5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'IMG5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Người Dùng' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'id_User'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Giấy Tờ - Tài liệu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'id_giayto_tailieu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Loại Tin' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'id_loaitin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Loại BĐS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'id_loaibds'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tỉnh Thành' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'id_tinhthanh'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quận Huyện' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'id_quanhuyen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Phường Xã' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'id_phuongxa'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chiều Ngang' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'chieungang'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chiều Dài' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'chieudai'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Số Lầu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'so_lau'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Số Phòng Ngủ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'so_phong_ngu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Phòng Ăn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'phong_an'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nhà Bếp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'nha_bep'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sân Thượng' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'san_thuong'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chỗ Để Xe' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'cho_de_xe_hoi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Địa Chỉ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'dia_chi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Đường Phố' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'id_duongpho'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Phương Hướng' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'id_phuonghuong'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Trạng Thái' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SanPham', @level2type=N'COLUMN',@level2name=N'id_trangthai'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tỉnh Thành' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TinhThanh', @level2type=N'COLUMN',@level2name=N'Ten_tinhthanh'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Trạng Thái' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TrangThai', @level2type=N'COLUMN',@level2name=N'ten_trangthai'
GO
USE [master]
GO
ALTER DATABASE [BatDongSanDKCN] SET  READ_WRITE 
GO
