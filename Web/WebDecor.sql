USE [WebDecor]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 11/4/2023 8:00:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](32) NULL,
	[Password] [nvarchar](32) NULL,
	[name] [nvarchar](84) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucSanPham]    Script Date: 11/4/2023 8:00:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucSanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](200) NULL,
 CONSTRAINT [PK_DanhMucSanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 11/4/2023 8:00:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaGiaoDich] [int] NULL,
	[TrangThai] [nvarchar](50) NULL,
	[DonViVanchuyen] [nvarchar](200) NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoDich]    Script Date: 11/4/2023 8:00:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoDich](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[PhuongThucThanhToan] [nvarchar](50) NULL,
	[ThongTinThanhToan] [nvarchar](200) NULL,
	[SoLuong] [int] NULL,
	[MaSanPham] [int] NULL,
	[TongGiaTien] [float] NULL,
 CONSTRAINT [PK_GiaoDich] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 11/4/2023 8:00:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/4/2023 8:00:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaLoaiSanPham] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Gia] [float] NULL,
	[GiamGia] [float] NULL,
	[SoLuong] [int] NULL,
	[LinkHinhAnh] [nvarchar](200) NULL,
	[MaDanhMuc] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/4/2023 8:00:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Phone] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DanhMucSanPham] ON 

INSERT [dbo].[DanhMucSanPham] ([ID], [TenDanhMuc]) VALUES (1, N'Đồ Trang Trí Phòng Khách')
INSERT [dbo].[DanhMucSanPham] ([ID], [TenDanhMuc]) VALUES (2, N'Đồ Trang Trí Phòng Ngủ')
INSERT [dbo].[DanhMucSanPham] ([ID], [TenDanhMuc]) VALUES (3, N'Đồ Phong Thủy')
INSERT [dbo].[DanhMucSanPham] ([ID], [TenDanhMuc]) VALUES (5, N'Đồ Trang Trí Để Bàn ')
INSERT [dbo].[DanhMucSanPham] ([ID], [TenDanhMuc]) VALUES (6, N'Đồ Treo Tường')
INSERT [dbo].[DanhMucSanPham] ([ID], [TenDanhMuc]) VALUES (7, N'Bàn Console')
SET IDENTITY_INSERT [dbo].[DanhMucSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([ID], [Name]) VALUES (1, N'Bình Hoa')
INSERT [dbo].[LoaiSanPham] ([ID], [Name]) VALUES (2, N'Mô Hình')
INSERT [dbo].[LoaiSanPham] ([ID], [Name]) VALUES (3, N'Đèn Ngủ')
INSERT [dbo].[LoaiSanPham] ([ID], [Name]) VALUES (4, N'Đồ Cổ')
INSERT [dbo].[LoaiSanPham] ([ID], [Name]) VALUES (5, N'Đồng hồ treo tường')
INSERT [dbo].[LoaiSanPham] ([ID], [Name]) VALUES (6, N'Đồng hồ để bàn')
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (1, 1, N'Bình hoa gốm sứ gắn chim vẹt', 1960000, 10, 2, N'bh-01.jpg', 5)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (2, 1, N'Bình cắm hoa chim vẹt', 2590000, 0, 3, N'bh-02.jpg', 5)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (3, 1, N'Bình cắm hoa decor', 1360000, 0, 1, N'bh-03.jpg', 5)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (4, 1, N'Bình hoa thủy tinh tráng men', 2170000, 0, 5, N'bh-04.jpg', 5)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (5, 2, N'Tượng thiên nga nghệ thuật ', 2350000, 0, 2, N'mh-01.jpg', 5)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (6, 2, N'Tượng ếch tập Yoga', 990000, 0, 0, N'mh-02.jpg', 5)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (7, 2, N'Mô hình đầu linh dương ', 590000, 0, 0, N'mh-03.jpg', 5)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (8, 2, N'Đồng hồ để bàn ', 2450000, 0, 0, N'mh-04.jpg', 5)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (9, 1, N'Bộ bình hoa cao cấp', 2950000, 10, 2, N'bh-05.jpg', 1)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (10, 2, N'Tượng hươu sang trọng', 5990000, 5, 2, N'mh-07.jpg', 1)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (11, 2, N'Tượng phi hành gia', 4700000, 0, 1, N'mh-08.jpg', 1)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (12, 2, N'Tượng thiên thần phong cách sang trọng', 800000, 2, 1, N'mh-09.jpg', 1)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (13, 4, N'Máy hát cổ trang trí phòng khách ưu chuộng', 3700000, 0, 1, N'dc-01.jpg', 1)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (14, 3, N'Đèn ngủ phong cách Bắc Âu', 2500000, 0, 1, N'dn-01.jpg', 1)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (15, 2, N'Đôi chim uyên ương trang trí bắt mắt', 6990000, 5, 1, N'mh-10.jpg', 1)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (16, 2, N'Mèo trang trí để sàn phòng khách', 2500000, 0, 1, N'mh-11.jpg', 1)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (17, 5, N'Đồng hồ treo tường cây hoa khảm trai CD1835

', 5990000, 0, 1, N'dht-01.jpg', 6)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (18, 5, N'Đồng hồ treo tường tối giản trang trí', 2800000, 0, 1, N'dht-02.jpg', 6)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (19, 5, N'Đồng hồ treo tường kiểu Bắc Âu CD1834', 3300000, 0, 1, N'dht-03.jpg', 6)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (20, 5, N'Đồng hồ bằng đồng sang trọng CD1833', 4600000, 0, 1, N'dht-04.jpg', 6)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (21, 5, N'Đồng hồ treo tường 3D cao cấp', 5000000, 0, 1, N'dht-05.jpg', 6)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (22, 5, N'Đồng hồ treo tường hình học đẹp', 4200000, 0, 1, N'dht-06.jpg', 6)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (23, 5, N'Đồng hồ treo tường không số CD1817', 3100000, 0, 1, N'dht-07.jpg', 6)
INSERT [dbo].[SanPham] ([ID], [MaLoaiSanPham], [Name], [Gia], [GiamGia], [SoLuong], [LinkHinhAnh], [MaDanhMuc]) VALUES (24, 5, N'Đồng hồ treo tường sáng tạo CD1809', 3500000, 0, 1, N'dht-08.jpg', 6)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Name], [Email], [Address], [Password], [Phone]) VALUES (2, N'Nguyễn Văn B', N'a', N'a', N'a', 916631372)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
