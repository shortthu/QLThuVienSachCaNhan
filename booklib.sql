USE [master]
GO
/****** Object:  Database [BookLibraryManagement]    Script Date: 03/12/24 20:25:41 ******/
CREATE DATABASE [BookLibraryManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookLibraryManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BookLibraryManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookLibraryManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BookLibraryManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BookLibraryManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookLibraryManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookLibraryManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookLibraryManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookLibraryManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookLibraryManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookLibraryManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookLibraryManagement] SET  MULTI_USER 
GO
ALTER DATABASE [BookLibraryManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookLibraryManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookLibraryManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookLibraryManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookLibraryManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookLibraryManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BookLibraryManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [BookLibraryManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BookLibraryManagement]
GO
/****** Object:  Table [dbo].[LichSuMuon]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuMuon](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Sach] [int] NOT NULL,
	[ID_Muon] [int] NOT NULL,
	[HinhThuc] [smallint] NOT NULL,
	[ThoiGian] [datetime] NOT NULL,
 CONSTRAINT [PK_LichSu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Muon]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Muon](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[SoDienThoai] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Muon] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNhaXuatBan] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LoaiSach] [int] NOT NULL,
	[ID_TheLoai] [int] NOT NULL,
	[TenSach] [nvarchar](100) NOT NULL,
	[ID_TacGia] [int] NULL,
	[NamXuatBan] [nchar](4) NULL,
	[ID_NhaXuatBan] [int] NULL,
	[ViTri] [nvarchar](50) NULL,
	[TrangThai] [smallint] NOT NULL,
	[GhiChu] [ntext] NULL,
	[ID_Muon] [int] NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenTacGia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenTheLoai] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LichSuMuon]  WITH CHECK ADD  CONSTRAINT [FK_LichSuMuon_Muon] FOREIGN KEY([ID_Muon])
REFERENCES [dbo].[Muon] ([ID])
GO
ALTER TABLE [dbo].[LichSuMuon] CHECK CONSTRAINT [FK_LichSuMuon_Muon]
GO
ALTER TABLE [dbo].[LichSuMuon]  WITH CHECK ADD  CONSTRAINT [FK_LichSuMuon_Sach] FOREIGN KEY([ID_Sach])
REFERENCES [dbo].[Sach] ([ID])
GO
ALTER TABLE [dbo].[LichSuMuon] CHECK CONSTRAINT [FK_LichSuMuon_Sach]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_Muon] FOREIGN KEY([ID_Muon])
REFERENCES [dbo].[Muon] ([ID])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_Muon]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NhaXuatBan] FOREIGN KEY([ID_NhaXuatBan])
REFERENCES [dbo].[NhaXuatBan] ([ID])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_NhaXuatBan]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TacGia] FOREIGN KEY([ID_TacGia])
REFERENCES [dbo].[TacGia] ([ID])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TacGia]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TheLoai] FOREIGN KEY([ID_TheLoai])
REFERENCES [dbo].[TheLoai] ([ID])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TheLoai]
GO
/****** Object:  StoredProcedure [dbo].[Author_GetAll]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Author_GetAll]
AS
SELECT * FROM TacGia
GO
/****** Object:  StoredProcedure [dbo].[Author_InsertUpdateDelete]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- TÁC GIẢ
CREATE PROCEDURE [dbo].[Author_InsertUpdateDelete]
	@ID int output,
	@TenTacGia nvarchar(50),
	@Action int
AS
-- Thêm
IF @Action = 0
BEGIN
	INSERT INTO [TacGia] ([TenTacGia])
	VALUES (@TenTacGia)

	SELECT @ID = SCOPE_IDENTITY();
END
-- Sửa
ELSE IF @Action = 1
BEGIN
	UPDATE [TacGia] SET [TenTacGia] = @TenTacGia
	WHERE ID = @ID
END
-- Xoá
ELSE IF @Action = 2
BEGIN
	DELETE FROM [TacGia] WHERE [ID] = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[Book_GetAll]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Book_GetAll]
AS
SELECT * FROM Sach
GO
/****** Object:  StoredProcedure [dbo].[Book_GetAllHistory]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Book_GetAllHistory]
AS
SELECT * FROM Sach WHERE TrangThai = 3
GO
/****** Object:  StoredProcedure [dbo].[Book_GetAllPresent]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Book_GetAllPresent]
AS
SELECT * FROM Sach WHERE TrangThai < 3
GO
/****** Object:  StoredProcedure [dbo].[Book_InsertUpdateDelete]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Book_InsertUpdateDelete]
	@ID int output,
	@LoaiSach int,
	@ID_TheLoai int,
	@TenSach nvarchar(100),
	@ID_TacGia int = null,
	@NamXuatBan nchar(4) = null,
	@ID_NhaXuatBan int = null,
	@ViTri nvarchar(50) = null,
	@TrangThai smallint = null,
	@GhiChu ntext = null,
	@ID_Muon int = null,
	@Action int
AS
-- Thêm
IF @Action = 0
BEGIN
	INSERT INTO [Sach]
	([LoaiSach], [ID_TheLoai], [TenSach], [ID_TacGia], 
	[NamXuatBan], [ID_NhaXuatBan], [ViTri], [TrangThai], [GhiChu], [ID_Muon])
	VALUES (@LoaiSach, @ID_TheLoai, @TenSach, @ID_TacGia, 
	@NamXuatBan, @ID_NhaXuatBan, @ViTri, @TrangThai, @GhiChu, @ID_Muon)

	SELECT @ID = SCOPE_IDENTITY();
END
-- Sửa
ELSE IF @Action = 1
BEGIN
	UPDATE [Sach] 
	SET [LoaiSach] = @LoaiSach, [ID_TheLoai] = @ID_TheLoai, [TenSach] = @TenSach,
	[ID_TacGia] = @ID_TacGia, [NamXuatBan] = @NamXuatBan, [ID_NhaXuatBan] = @ID_NhaXuatBan,
	[ViTri] = @ViTri, [TrangThai] = @TrangThai, [GhiChu] = @GhiChu, [ID_Muon] = @ID_Muon
	WHERE ID = @ID
END
-- Xoá
ELSE IF @Action = 2
BEGIN
	DELETE FROM [Sach] WHERE [ID] = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[Borrow_GetAll]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Borrow_GetAll]
AS
SELECT * FROM Muon
GO
/****** Object:  StoredProcedure [dbo].[Borrow_InsertUpdateDelete]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Borrow_InsertUpdateDelete]
	@ID int output,
	@Ten nvarchar(50),
	@SoDienThoai nchar(10),
	@Action int
AS
-- Thêm
IF @Action = 0
BEGIN
	INSERT INTO [Muon] ([Ten], [SoDienThoai])
	VALUES (@Ten, @SoDienThoai)

	SELECT @ID = SCOPE_IDENTITY();
END
-- Sửa
ELSE IF @Action = 1
BEGIN
	UPDATE [Muon] SET [Ten] = @Ten, [SoDienThoai] = @SoDienThoai
	WHERE ID = @ID
END
-- Xoá
ELSE IF @Action = 2
BEGIN
	DELETE FROM [Muon] WHERE [ID] = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[BorrowHistory_GetAll]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrowHistory_GetAll]
AS
SELECT * FROM LichSuMuon
GO
/****** Object:  StoredProcedure [dbo].[BorrowHistory_InsertUpdateDelete]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrowHistory_InsertUpdateDelete]
	@ID int output,
	@ID_Sach int,
	@ID_Muon int,
	@HinhThuc smallint,
	@ThoiGian datetime,
	@Action int
AS
-- Thêm
IF @Action = 0
BEGIN
	INSERT INTO [LichSuMuon] ([ID_Sach], [ID_Muon], [HinhThuc], [ThoiGian])
	VALUES (@ID_Sach, @ID_Muon, @HinhThuc, @ThoiGian)

	SELECT @ID = SCOPE_IDENTITY();
END
-- Sửa
ELSE IF @Action = 1
BEGIN
	UPDATE [LichSuMuon] SET [ID_Sach] = @ID_Sach, [ID_Muon] = @ID_Muon, [HinhThuc] = @HinhThuc,
	[ThoiGian] = @ThoiGian
	WHERE ID = @ID
END
-- Xoá
ELSE IF @Action = 2
BEGIN
	DELETE FROM [LichSuMuon] WHERE [ID] = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[Category_GetAll]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Category_GetAll]
AS
SELECT * FROM TheLoai
GO
/****** Object:  StoredProcedure [dbo].[Category_InsertUpdateDelete]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- THỂ LOẠI
CREATE PROCEDURE [dbo].[Category_InsertUpdateDelete]
	@ID int output,
	@TenTheLoai nvarchar(50),
	@Action int
AS
-- Thêm
IF @Action = 0
BEGIN
	INSERT INTO [TheLoai] ([TenTheLoai])
	VALUES (@TenTheLoai)

	SELECT @ID = SCOPE_IDENTITY();
END
-- Sửa
ELSE IF @Action = 1
BEGIN
	UPDATE [TheLoai] SET [TenTheLoai] = @TenTheLoai
	WHERE ID = @ID
END
-- Xoá
ELSE IF @Action = 2
BEGIN
	DELETE FROM [TheLoai] WHERE [ID] = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[InsertAuthor]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertAuthor]
	@ID int output,
	@TenTacGia nvarchar(50)
AS
INSERT INTO [TacGia] ([TenTacGia])
VALUES (@TenTacGia)

SELECT @ID = SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[InsertBook]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertBook]
	@ID int output,
	@LoaiSach int,
	@ID_TheLoai int,
	@TenSach nvarchar(100),
	@ID_TacGia int,
	@NamXuatBan nchar(4),
	@ID_NhaXuatBan int,
	@ViTri nvarchar(50),
	@TenTrangThai smallint,
	@GhiChu ntext
AS
INSERT INTO [Sach]
([LoaiSach], [ID_TheLoai], [TenSach], [ID_TacGia], [NamXuatBan], [ID_NhaXuatBan], 
[ViTri], [TenTrangThai], [GhiChu])
VALUES (@LoaiSach, @ID_TheLoai, @TenSach, @ID_TacGia, @NamXuatBan, @ID_NhaXuatBan, 
		@ViTri, @TenTrangThai, @GhiChu)

SELECT @ID = SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[InsertCategory]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCategory]
	@ID int output,
	@TenTheLoai nvarchar(50)
AS
INSERT INTO [TheLoai] ([TenTheLoai])
VALUES (@TenTheLoai)

SELECT @ID = SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[InsertPublisher]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertPublisher]
	@ID int output,
	@TenNhaXuatBan nvarchar(50)
AS
INSERT INTO [NhaXuatBan] ([TenNhaXuatBan])
VALUES (@TenNhaXuatBan)

SELECT @ID = SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[Publisher_GetAll]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Thủ tục lấy tất cả dữ liệu các bảng
CREATE PROCEDURE [dbo].[Publisher_GetAll]
AS
SELECT * FROM NhaXuatBan
GO
/****** Object:  StoredProcedure [dbo].[Publisher_InsertUpdateDelete]    Script Date: 03/12/24 20:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Thủ tục thêm, xoá sửa các bảng
-- NHÀ XUẤT BẢN
CREATE PROCEDURE [dbo].[Publisher_InsertUpdateDelete]
	@ID int output,
	@TenNhaXuatBan nvarchar(50),
	@Action int
AS
-- Thêm
IF @Action = 0
BEGIN
	INSERT INTO [NhaXuatBan] ([TenNhaXuatBan])
	VALUES (@TenNhaXuatBan)

	SELECT @ID = SCOPE_IDENTITY();
END
-- Sửa
ELSE IF @Action = 1
BEGIN
	UPDATE [NhaXuatBan] SET [TenNhaXuatBan] = @TenNhaXuatBan
	WHERE ID = @ID
END
-- Xoá
ELSE IF @Action = 2
BEGIN
	DELETE FROM [NhaXuatBan] WHERE [ID] = @ID
END
GO
USE [master]
GO
ALTER DATABASE [BookLibraryManagement] SET  READ_WRITE 
GO
