-- Thủ tục lấy tất cả dữ liệu các bảng
CREATE PROCEDURE [dbo].[Publisher_GetAll]
AS
SELECT * FROM NhaXuatBan
GO

CREATE PROCEDURE [dbo].[Book_GetAll]
AS
SELECT * FROM Sach
GO

CREATE PROCEDURE [dbo].[Author_GetAll]
AS
SELECT * FROM TacGia
GO

CREATE PROCEDURE [dbo].[Category_GetAll]
AS
SELECT * FROM TheLoai
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
	@ID_TacGia int,
	@NamXuatBan nchar(4),
	@ID_NhaXuatBan int,
	@ViTri nvarchar(50),
	@TenTrangThai smallint,
	@GhiChu ntext,
	@Action int
AS
-- Thêm
IF @Action = 0
BEGIN
	INSERT INTO [Sach]
	([LoaiSach], [ID_TheLoai], [TenSach], [ID_TacGia], 
	[NamXuatBan], [ID_NhaXuatBan], [ViTri], [TenTrangThai], [GhiChu])
	VALUES (@LoaiSach, @ID_TheLoai, @TenSach, @ID_TacGia, 
	@NamXuatBan, @ID_NhaXuatBan, @ViTri, @TenTrangThai, @GhiChu)

	SELECT @ID = SCOPE_IDENTITY();
END
-- Sửa
ELSE IF @Action = 1
BEGIN
	UPDATE [Sach] 
	SET [LoaiSach] = @LoaiSach, [ID_TheLoai] = @ID_TheLoai, [TenSach] = @TenSach,
	[ID_TacGia] = @ID_TacGia, [NamXuatBan] = @NamXuatBan, [ID_NhaXuatBan] = @ID_NhaXuatBan,
	[ViTri] = @ViTri, [TenTrangThai] = @TenTrangThai, [GhiChu] = @GhiChu
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

--CREATE PROCEDURE [InsertCategory]
--	@ID int output,
--	@TenTheLoai nvarchar(50)
--AS
--INSERT INTO [TheLoai] ([TenTheLoai])
--VALUES (@TenTheLoai)

--SELECT @ID = SCOPE_IDENTITY();
--GO

--CREATE PROCEDURE [InsertAuthor]
--	@ID int output,
--	@TenTacGia nvarchar(50)
--AS
--INSERT INTO [TacGia] ([TenTacGia])
--VALUES (@TenTacGia)

--SELECT @ID = SCOPE_IDENTITY();
--GO

--CREATE PROCEDURE [InsertPublisher]
--	@ID int output,
--	@TenNhaXuatBan nvarchar(50)
--AS
--INSERT INTO [NhaXuatBan] ([TenNhaXuatBan])
--VALUES (@TenNhaXuatBan)

--SELECT @ID = SCOPE_IDENTITY();
--GO

--CREATE PROCEDURE [InsertBook]
--	@ID int output,
--	@LoaiSach int,
--	@ID_TheLoai int,
--	@TenSach nvarchar(100),
--	@ID_TacGia int,
--	@NamXuatBan nchar(4),
--	@ID_NhaXuatBan int,
--	@ViTri nvarchar(50),
--	@TenTrangThai smallint,
--	@GhiChu ntext
--AS
--INSERT INTO [Sach]
--([LoaiSach], [ID_TheLoai], [TenSach], [ID_TacGia], [NamXuatBan], [ID_NhaXuatBan], 
--[ViTri], [TenTrangThai], [GhiChu])
--VALUES (@LoaiSach, @ID_TheLoai, @TenSach, @ID_TacGia, @NamXuatBan, @ID_NhaXuatBan, 
--		@ViTri, @TenTrangThai, @GhiChu)

--SELECT @ID = SCOPE_IDENTITY();
--GO
