-- Thủ tục lấy tất cả dữ liệu các bảng
CREATE PROCEDURE [dbo].[Publisher_GetAll]
AS
SELECT * FROM NhaXuatBan
GO

CREATE PROCEDURE [dbo].[Book_GetAll]
AS
SELECT * FROM Sach
GO

CREATE PROCEDURE [dbo].[Book_GetAllPresent]
AS
SELECT * FROM Sach WHERE TrangThai < 3
GO

CREATE PROCEDURE [dbo].[Book_GetAllHistory]
AS
SELECT * FROM Sach WHERE TrangThai = 3
GO

CREATE PROCEDURE [dbo].[Author_GetAll]
AS
SELECT * FROM TacGia
GO

CREATE PROCEDURE [dbo].[Category_GetAll]
AS
SELECT * FROM TheLoai
GO

CREATE PROCEDURE [dbo].[Borrow_GetAll]
AS
SELECT * FROM Muon
GO

CREATE PROCEDURE [dbo].[BorrowHistory_GetAll]
AS
SELECT * FROM LichSuMuon
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

-- SÁCH
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

