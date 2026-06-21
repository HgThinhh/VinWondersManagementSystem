-- =================================================================
-- BỘ STORED PROCEDURE ĐÃ ĐỒNG BỘ UNICODE (NVARCHAR) CHUẨN FINAL
-- =================================================================

USE VinWonders_Management;
GO

-- =================================================================
-- 1. STORED PROCEDURES: PHÂN HỆ TÀI KHOẢN & NHÂN VIÊN
-- =================================================================

-- 1.1. Đăng nhập hệ thống (Kiểm tra tài khoản hoạt động)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Login')
    DROP PROCEDURE sp_Login;
GO
CREATE PROCEDURE sp_Login
    @TenDangNhap VARCHAR(50),
    @MatKhau VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT nv.*, tk.QuyenTruyCap, tk.TrangThai AS TrangThaiTaiKhoan
    FROM NhanVien nv
    INNER JOIN TaiKhoan tk ON nv.MaTaiKhoan = tk.MaTaiKhoan
    WHERE tk.TenDangNhap = @TenDangNhap AND tk.MatKhau = @MatKhau AND tk.TrangThai = 1;
END;
GO

-- 1.2. Thêm mới Nhân viên
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_NhanVien')
    DROP PROCEDURE sp_Insert_NhanVien;
GO
CREATE PROCEDURE sp_Insert_NhanVien
    @MaNhanVien NVARCHAR(10),
    @MaTaiKhoan NVARCHAR(10) = NULL,
    @HoTen NVARCHAR(50),         -- Đồng bộ NVARCHAR
    @GioTinh NVARCHAR(3),        -- Đồng bộ NVARCHAR
    @NgaySinh DATE,
    @SoDienThoai VARCHAR(15),
    @Email NVARCHAR(50),
    @CCCD VARCHAR(12),
    @ViTri NVARCHAR(50),         -- Đồng bộ NVARCHAR
    @Luong DECIMAL(18,2),
    @NgayVaoLam DATE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO NhanVien (MaNhanVien, MaTaiKhoan, HoTen, GioTinh, NgaySinh, SoDienThoai, Email, CCCD, ViTri, Luong, NgayVaoLam)
    VALUES (@MaNhanVien, @MaTaiKhoan, @HoTen, @GioTinh, @NgaySinh, @SoDienThoai, @Email, @CCCD, @ViTri, @Luong, @NgayVaoLam);
END;
GO

-- 1.3. Cập nhật thông tin Nhân viên
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_NhanVien')
    DROP PROCEDURE sp_Update_NhanVien;
GO
CREATE PROCEDURE sp_Update_NhanVien
    @MaNhanVien NVARCHAR(10),
    @HoTen NVARCHAR(50),
    @GioTinh NVARCHAR(3),
    @NgaySinh DATE,
    @SoDienThoai VARCHAR(15),
    @Email NVARCHAR(50),
    @CCCD VARCHAR(12),
    @ViTri NVARCHAR(50),
    @Luong DECIMAL(18,2),
    @NgayVaoLam DATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE NhanVien
    SET HoTen = @HoTen, GioTinh = @GioTinh, NgaySinh = @NgaySinh, 
        SoDienThoai = @SoDienThoai, Email = @Email, CCCD = @CCCD, 
        ViTri = @ViTri, Luong = @Luong, NgayVaoLam = @NgayVaoLam
    WHERE MaNhanVien = @MaNhanVien;
END;
GO

-- 1.4. Lấy tất cả Nhân viên
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_NhanVien')
    DROP PROCEDURE sp_GetAll_NhanVien;
GO
CREATE PROCEDURE sp_GetAll_NhanVien
AS
BEGIN
    SET NOCOUNT ON;
    SELECT nv.*, tk.TenDangNhap, tk.QuyenTruyCap
    FROM NhanVien nv
    LEFT JOIN TaiKhoan tk ON nv.MaTaiKhoan = tk.MaTaiKhoan;
END;
GO

-- 1.5. Xóa Nhân Viên
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_NhanVien') DROP PROCEDURE sp_Delete_NhanVien;
GO
CREATE PROCEDURE sp_Delete_NhanVien @MaNhanVien NVARCHAR(10)
AS BEGIN SET NOCOUNT ON; DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien; END;
GO

-- =================================================================
-- 2. STORED PROCEDURES: PHÂN HỆ KHÁCH HÀNG
-- =================================================================

-- 2.1. Thêm mới Khách hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_KhachHang')
    DROP PROCEDURE sp_Insert_KhachHang;
GO
CREATE PROCEDURE sp_Insert_KhachHang
    @MaKhachHang NVARCHAR(10),
    @MaHang NVARCHAR(10) = NULL,
    @HoTen NVARCHAR(100),       -- Đồng bộ NVARCHAR
    @LoaiKhach NVARCHAR(50),     -- 'Cá nhân' hoặc 'Khách đoàn'
    @NgaySinh DATE = NULL,
    @DiaChi NVARCHAR(255) = NULL, -- Đổi thành NVARCHAR chứa địa chỉ tiếng Việt
    @SoDienThoai VARCHAR(15) = NULL,
    @Email VARCHAR(100) = NULL,
    @DiemTichLuy INT = 0
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO KhachHang (MaKhachHang, MaHang, HoTen, LoaiKhach, NgaySinh, DiaChi, SoDienThoai, Email, DiemTichLuy)
    VALUES (@MaKhachHang, @MaHang, @HoTen, @LoaiKhach, @NgaySinh, @DiaChi, @SoDienThoai, @Email, @DiemTichLuy);
END;
GO

-- 2.2. Cập nhật Khách hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_KhachHang')
    DROP PROCEDURE sp_Update_KhachHang;
GO
CREATE PROCEDURE sp_Update_KhachHang
    @MaKhachHang NVARCHAR(10),
    @MaHang NVARCHAR(10) = NULL,
    @HoTen NVARCHAR(100),
    @LoaiKhach NVARCHAR(50),
    @NgaySinh DATE = NULL,
    @DiaChi NVARCHAR(255) = NULL,
    @SoDienThoai VARCHAR(15) = NULL,
    @Email VARCHAR(100) = NULL,
    @DiemTichLuy INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE KhachHang
    SET MaHang = @MaHang, HoTen = @HoTen, LoaiKhach = @LoaiKhach, NgaySinh = @NgaySinh,
        DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email, DiemTichLuy = @DiemTichLuy
    WHERE MaKhachHang = @MaKhachHang;
END;
GO

-- 2.3. Lấy toàn bộ danh sách Khách hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_KhachHang')
    DROP PROCEDURE sp_GetAll_KhachHang;
GO
CREATE PROCEDURE sp_GetAll_KhachHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT kh.*, htv.TenHang, htv.TiLeGiamGia
    FROM KhachHang kh
    LEFT JOIN HangThanhVien htv ON kh.MaHang = htv.MaHang;
END;
GO

-- 2.4. Xóa Khách Hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_KhachHang') DROP PROCEDURE sp_Delete_KhachHang;
GO
CREATE PROCEDURE sp_Delete_KhachHang @MaKhachHang NVARCHAR(10)
AS BEGIN SET NOCOUNT ON; DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang; END;
GO

-- =================================================================
-- 3. STORED PROCEDURES: QUẢN LÝ LOẠI VÉ
-- =================================================================

-- 3.1. Thêm mới Loại Vé
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_LoaiVe')
    DROP PROCEDURE sp_Insert_LoaiVe;
GO
CREATE PROCEDURE sp_Insert_LoaiVe
    @MaLoaiVe NVARCHAR(10),
    @TenLoaiVe NVARCHAR(100),   -- Đồng bộ NVARCHAR
    @PhanLoai NVARCHAR(50),     -- Vé vào cổng, Vé trọn gói...
    @GiaVe DECIMAL(18,2),
    @BaoGomAnUong BIT = 0,
    @MoTa NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO LoaiVe (MaLoaiVe, TenLoaiVe, PhanLoai, GiaVe, BaoGomAnUong, MoTa)
    VALUES (@MaLoaiVe, @TenLoaiVe, @PhanLoai, @GiaVe, @BaoGomAnUong, @MoTa);
END;
GO

-- 3.2. Lấy danh sách Loại Vé
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_LoaiVe')
    DROP PROCEDURE sp_GetAll_LoaiVe;
GO
CREATE PROCEDURE sp_GetAll_LoaiVe
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM LoaiVe;
END;
GO
-- 3.3. Xóa Loại Vé
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_LoaiVe') DROP PROCEDURE sp_Delete_LoaiVe;
GO
CREATE PROCEDURE sp_Delete_LoaiVe @MaLoaiVe NVARCHAR(10)
AS BEGIN SET NOCOUNT ON; DELETE FROM LoaiVe WHERE MaLoaiVe = @MaLoaiVe; END;
GO
-- 3.4. Cập nhật Loại Vé
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_LoaiVe')
    DROP PROCEDURE sp_Update_LoaiVe;
GO
CREATE PROCEDURE sp_Update_LoaiVe
    @MaLoaiVe NVARCHAR(10),
    @TenLoaiVe NVARCHAR(100),
    @PhanLoai NVARCHAR(50),
    @GiaVe DECIMAL(18,2),
    @BaoGomAnUong BIT,
    @MoTa NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE LoaiVe
    SET TenLoaiVe = @TenLoaiVe, PhanLoai = @PhanLoai, GiaVe = @GiaVe,
        BaoGomAnUong = @BaoGomAnUong, MoTa = @MoTa
    WHERE MaLoaiVe = @MaLoaiVe;
END;
GO
-- =================================================================
-- 4. STORED PROCEDURES: NGHIỆP VỤ HÓA ĐƠN VÀ PHÁT HÀNH VÉ
-- =================================================================

-- 4.1. Thêm mới Hóa đơn bán vé (FIX TRIỆT ĐỂ LỖI TIẾNG VIỆT ?)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_HoaDonVe')
    DROP PROCEDURE sp_Insert_HoaDonVe;
GO
CREATE PROCEDURE sp_Insert_HoaDonVe
    @MaHoaDon NVARCHAR(10),
    @MaKhachHang NVARCHAR(10),
    @MaNhanVien NVARCHAR(10),
    @MaSuKien NVARCHAR(10) = NULL,
    @ChietKhauDoan DECIMAL(18,2) = 0,
    @TongTien DECIMAL(18,2),
    @PhuongThucThanhToan NVARCHAR(50), -- Sửa thành NVARCHAR để nhận N'Tiền mặt'
    @TrangThai NVARCHAR(50)            -- Sửa thành NVARCHAR để nhận N'Đã thanh toán'
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO HoaDonVe (MaHoaDon, MaKhachHang, MaNhanVien, MaSuKien, NgayMua, ChietKhauDoan, TongTien, PhuongThucThanhToan, TrangThai)
    VALUES (@MaHoaDon, @MaKhachHang, @MaNhanVien, @MaSuKien, GETDATE(), @ChietKhauDoan, @TongTien, @PhuongThucThanhToan, @TrangThai);
    
    -- Cập nhật điểm tích lũy cho khách hàng (10k = 1đ)
    -- Yêu cầu: Khách hàng phải có số điện thoại mới được tích điểm
    IF @MaKhachHang IS NOT NULL AND @MaKhachHang <> ''
    BEGIN
        IF EXISTS (SELECT 1 FROM KhachHang WHERE MaKhachHang = @MaKhachHang AND SoDienThoai IS NOT NULL AND LTRIM(RTRIM(SoDienThoai)) <> '')
        BEGIN
            DECLARE @DiemCong INT;
            SET @DiemCong = CAST((@TongTien / 10000) AS INT);
            
            UPDATE KhachHang
            SET DiemTichLuy = ISNULL(DiemTichLuy, 0) + @DiemCong
            WHERE MaKhachHang = @MaKhachHang;
            
            -- Cập nhật Hạng Thành Viên dựa trên điểm tích lũy mới
            UPDATE KhachHang
            SET MaHang = (
                SELECT TOP 1 MaHang 
                FROM HangThanhVien 
                WHERE DiemToiThieu <= KhachHang.DiemTichLuy 
                ORDER BY DiemToiThieu DESC
            )
            WHERE MaKhachHang = @MaKhachHang;
        END
    END
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_HoaDonVe')
    DROP PROCEDURE sp_Delete_HoaDonVe;
GO
CREATE PROCEDURE sp_Delete_HoaDonVe
    @MaHoaDon NVARCHAR(20)
AS
BEGIN
    DELETE FROM HoaDonVe WHERE MaHoaDon = @MaHoaDon;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_HoaDonVe')
    DROP PROCEDURE sp_Update_HoaDonVe;
GO
CREATE PROCEDURE sp_Update_HoaDonVe
    @MaHoaDon NVARCHAR(20),
    @MaKhachHang NVARCHAR(20),
    @MaNhanVien NVARCHAR(20),
    @MaSuKien NVARCHAR(20),
    @ChietKhauDoan DECIMAL(18,2),
    @TongTien DECIMAL(18,2),
    @PhuongThucThanhToan NVARCHAR(50),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    UPDATE HoaDonVe
    SET MaKhachHang = @MaKhachHang,
        MaNhanVien = @MaNhanVien,
        MaSuKien = @MaSuKien,
        ChietKhauDoan = @ChietKhauDoan,
        TongTien = @TongTien,
        PhuongThucThanhToan = @PhuongThucThanhToan,
        TrangThai = @TrangThai
    WHERE MaHoaDon = @MaHoaDon;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Search_HoaDonVe')
    DROP PROCEDURE sp_Search_HoaDonVe;
GO
CREATE PROCEDURE sp_Search_HoaDonVe
    @TuKhoa NVARCHAR(100)
AS
BEGIN
    SELECT * FROM HoaDonVe 
    WHERE MaHoaDon LIKE '%' + @TuKhoa + '%' OR MaKhachHang LIKE '%' + @TuKhoa + '%';
END
GO

-- 4.2. Thêm từng vé đơn lẻ vào hệ thống (Khi nhấn Thanh toán trên GUI)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_Ve')
    DROP PROCEDURE sp_Insert_Ve;
GO
CREATE PROCEDURE sp_Insert_Ve
    @MaVe NVARCHAR(10),
    @MaHoaDon NVARCHAR(10),
    @MaLoaiVe NVARCHAR(10),
    @DonGia DECIMAL(18,2),
    @NgaySuDung DATE,
    @DaSuDung BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Ve (MaVe, MaHoaDon, MaLoaiVe, DonGia, NgaySuDung, DaSuDung)
    VALUES (@MaVe, @MaHoaDon, @MaLoaiVe, @DonGia, @NgaySuDung, @DaSuDung);
END;
GO

-- 4.3. Đổ danh sách Hóa đơn lên màn hình chính DataGridView
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_HoaDonVe')
    DROP PROCEDURE sp_GetAll_HoaDonVe;
GO
CREATE PROCEDURE sp_GetAll_HoaDonVe
AS
BEGIN
    SET NOCOUNT ON;
    SELECT hdv.*, kh.HoTen AS TenKhachHang, nv.HoTen AS TenNhanVien, sk.TenSuKien
    FROM HoaDonVe hdv
    INNER JOIN KhachHang kh ON hdv.MaKhachHang = kh.MaKhachHang
    INNER JOIN NhanVien nv ON hdv.MaNhanVien = nv.MaNhanVien
    LEFT JOIN SuKien sk ON hdv.MaSuKien = sk.MaSuKien
    ORDER BY hdv.NgayMua DESC;
END;
GO

-- 4.4. Lấy chi tiết các vé thuộc một hóa đơn cụ thể (Xem danh sách vé đã mua)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetVe_ByHoaDon')
    DROP PROCEDURE sp_GetVe_ByHoaDon;
GO
CREATE PROCEDURE sp_GetVe_ByHoaDon
    @MaHoaDon NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT v.*, lv.TenLoaiVe, lv.PhanLoai
    FROM Ve v
    INNER JOIN LoaiVe lv ON v.MaLoaiVe = lv.MaLoaiVe
    WHERE v.MaHoaDon = @MaHoaDon;
END;
GO

-- 4.5. Quét vé vào cổng (Cập nhật trạng thái sử dụng vé)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_QuetVeVaoCong')
    DROP PROCEDURE sp_QuetVeVaoCong;
GO
CREATE PROCEDURE sp_QuetVeVaoCong
    @MaVe NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Ve 
    SET DaSuDung = 1 
    WHERE MaVe = @MaVe AND DaSuDung = 0;
END;
GO

-- =================================================================
-- 5. STORED PROCEDURES: QUẢN LÝ TRÒ CHƠI
-- =================================================================

-- 5.1. Thêm mới Trò Chơi
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_TroChoi')
    DROP PROCEDURE sp_Insert_TroChoi;
GO
CREATE PROCEDURE sp_Insert_TroChoi
    @MaTroChoi NVARCHAR(10),
    @MaKhuVuc NVARCHAR(10),
    @TenTroChoi NVARCHAR(100),   -- Đồng bộ NVARCHAR
    @PhanLoai NVARCHAR(50) = NULL,
    @ChieuCaoToiThieu INT = NULL,
    @DoTuoiToiThieu INT = NULL,
    @SucChua INT = NULL,
    @TrangThai NVARCHAR(50) = N'Đang hoạt động'
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO TroChoi (MaTroChoi, MaKhuVuc, TenTroChoi, PhanLoai, ChieuCaoToiThieu, DoTuoiToiThieu, SucChua, TrangThai)
    VALUES (@MaTroChoi, @MaKhuVuc, @TenTroChoi, @PhanLoai, @ChieuCaoToiThieu, @DoTuoiToiThieu, @SucChua, @TrangThai);
END;
GO

-- 5.2. Cập nhật Trò Chơi
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_TroChoi')
    DROP PROCEDURE sp_Update_TroChoi;
GO
CREATE PROCEDURE sp_Update_TroChoi
    @MaTroChoi NVARCHAR(10),
    @MaKhuVuc NVARCHAR(10),
    @TenTroChoi NVARCHAR(100),
    @PhanLoai NVARCHAR(50),
    @ChieuCaoToiThieu INT,
    @DoTuoiToiThieu INT,
    @SucChua INT,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE TroChoi
    SET MaKhuVuc = @MaKhuVuc, TenTroChoi = @TenTroChoi, PhanLoai = @PhanLoai,
        ChieuCaoToiThieu = @ChieuCaoToiThieu, DoTuoiToiThieu = @DoTuoiToiThieu,
        SucChua = @SucChua, TrangThai = @TrangThai
    WHERE MaTroChoi = @MaTroChoi;
END;
GO

-- 5.3. Lấy tất cả Trò chơi
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_TroChoi')
    DROP PROCEDURE sp_GetAll_TroChoi;
GO
CREATE PROCEDURE sp_GetAll_TroChoi
AS
BEGIN
    SET NOCOUNT ON;
    SELECT tc.*, kv.TenKhuVuc
    FROM TroChoi tc
    INNER JOIN KhuVuc kv ON tc.MaKhuVuc = kv.MaKhuVuc;
END;
GO

-- 5.4. Xóa Trò Chơi
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_TroChoi') DROP PROCEDURE sp_Delete_TroChoi;
GO
CREATE PROCEDURE sp_Delete_TroChoi @MaTroChoi NVARCHAR(10)
AS BEGIN SET NOCOUNT ON; DELETE FROM TroChoi WHERE MaTroChoi = @MaTroChoi; END;
GO
-- =================================================================
-- 6. STORED PROCEDURES: QUẢN LÝ GIAN HÀNG & SẢN PHẨM (F&B)
-- =================================================================

-- 6.1. Thêm mới Sản phẩm
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_SanPham')
    DROP PROCEDURE sp_Insert_SanPham;
GO
CREATE PROCEDURE sp_Insert_SanPham
    @MaSanPham NVARCHAR(10),
    @MaCuaHang NVARCHAR(10),
    @TenSanPham NVARCHAR(100),   -- Đồng bộ NVARCHAR
    @LoaiSanPham NVARCHAR(50) = NULL,
    @GiaBan DECIMAL(18,2),
    @TrangThaiBan NVARCHAR(50) = N'Còn hàng'
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO SanPham (MaSanPham, MaCuaHang, TenSanPham, LoaiSanPham, GiaBan, TrangThaiBan)
    VALUES (@MaSanPham, @MaCuaHang, @TenSanPham, @LoaiSanPham, @GiaBan, @TrangThaiBan);
END;
GO

-- 6.2. Cập nhật Sản phẩm
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_SanPham')
    DROP PROCEDURE sp_Update_SanPham;
GO
CREATE PROCEDURE sp_Update_SanPham
    @MaSanPham NVARCHAR(10),
    @MaCuaHang NVARCHAR(10),
    @TenSanPham NVARCHAR(100),
    @LoaiSanPham NVARCHAR(50),
    @GiaBan DECIMAL(18,2),
    @TrangThaiBan NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE SanPham
    SET MaCuaHang = @MaCuaHang, TenSanPham = @TenSanPham, LoaiSanPham = @LoaiSanPham,
        GiaBan = @GiaBan, TrangThaiBan = @TrangThaiBan
    WHERE MaSanPham = @MaSanPham;
END;
GO

-- 6.3. Lấy toàn bộ Sản phẩm (F&B và Lưu niệm)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_SanPham')
    DROP PROCEDURE sp_GetAll_SanPham;
GO
CREATE PROCEDURE sp_GetAll_SanPham
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sp.*, ch.TenCuaHang
    FROM SanPham sp
    INNER JOIN CuaHang ch ON sp.MaCuaHang = ch.MaCuaHang;
END;
GO
-- 6.4. Xóa Sản Phẩm
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_SanPham') DROP PROCEDURE sp_Delete_SanPham;
GO
CREATE PROCEDURE sp_Delete_SanPham @MaSanPham NVARCHAR(10)
AS BEGIN SET NOCOUNT ON; DELETE FROM SanPham WHERE MaSanPham = @MaSanPham; END;
GO
-- =================================================================
-- 7. STORED PROCEDURES: QUẢN LÝ KHEN THƯỞNG & KỶ LUẬT (MỚI THÊM)
-- =================================================================

-- 7.1. Thêm quyết định Thưởng / Phạt nhân viên
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_KhenThuongKyLuat')
    DROP PROCEDURE sp_Insert_KhenThuongKyLuat;
GO
CREATE PROCEDURE sp_Insert_KhenThuongKyLuat
    @MaKTKL NVARCHAR(10),
    @MaNhanVien NVARCHAR(10),
    @Loai NVARCHAR(50),          -- 'Khen thưởng' hoặc 'Kỷ luật'
    @LyDo NVARCHAR(500),         -- Lưu lý do tiếng Việt có dấu
    @SoTien DECIMAL(18,2) = 0
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO KhenThuongKyLuat (MaKTKL, MaNhanVien, Loai, LyDo, SoTien, NgayQuyetDinh)
    VALUES (@MaKTKL, @MaNhanVien, @Loai, @LyDo, @SoTien, GETDATE());
END;
GO

-- 7.2. Lấy toàn bộ danh sách Thưởng / Phạt để quản lý kiểm tra
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_KhenThuongKyLuat')
    DROP PROCEDURE sp_GetAll_KhenThuongKyLuat;
GO
CREATE PROCEDURE sp_GetAll_KhenThuongKyLuat
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ktkl.*, nv.HoTen AS TenNhanVien
    FROM KhenThuongKyLuat ktkl
    INNER JOIN NhanVien nv ON ktkl.MaNhanVien = nv.MaNhanVien
    ORDER BY ktkl.NgayQuyetDinh DESC;
END;
GO
-- Xóa Quyết định Khen Thưởng / Kỷ Luật
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_KhenThuongKyLuat') DROP PROCEDURE sp_Delete_KhenThuongKyLuat;
GO
CREATE PROCEDURE sp_Delete_KhenThuongKyLuat
    @MaKTKL NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM KhenThuongKyLuat WHERE MaKTKL = @MaKTKL;
END;
GO
-- =================================================================
-- 8. STORED PROCEDURES: QUẢN LÝ KHU VỰC
-- =================================================================

-- Thêm Khu Vực
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_KhuVuc') DROP PROCEDURE sp_Insert_KhuVuc;
GO
CREATE PROCEDURE sp_Insert_KhuVuc
    @MaKhuVuc NVARCHAR(10),
    @TenKhuVuc NVARCHAR(100),
    @MoTa NVARCHAR(255),
    @GioMoCua TIME = NULL,
    @GioDongCua TIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO KhuVuc (MaKhuVuc, TenKhuVuc, MoTa, GioMoCua, GioDongCua)
    VALUES (@MaKhuVuc, @TenKhuVuc, @MoTa, @GioMoCua, @GioDongCua);
END;
GO

-- Cập nhật Khu Vực
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_KhuVuc') DROP PROCEDURE sp_Update_KhuVuc;
GO
CREATE PROCEDURE sp_Update_KhuVuc
    @MaKhuVuc NVARCHAR(10),
    @TenKhuVuc NVARCHAR(100),
    @MoTa NVARCHAR(255),
    @GioMoCua TIME,
    @GioDongCua TIME
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE KhuVuc
    SET TenKhuVuc = @TenKhuVuc, MoTa = @MoTa, GioMoCua = @GioMoCua, GioDongCua = @GioDongCua
    WHERE MaKhuVuc = @MaKhuVuc;
END;
GO

-- Xóa Khu Vực
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_KhuVuc') DROP PROCEDURE sp_Delete_KhuVuc;
GO
CREATE PROCEDURE sp_Delete_KhuVuc
    @MaKhuVuc NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM KhuVuc WHERE MaKhuVuc = @MaKhuVuc;
END;
GO

-- Lấy danh sách khu vực
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_KhuVuc') 
    DROP PROCEDURE sp_GetAll_KhuVuc;
GO

CREATE PROCEDURE sp_GetAll_KhuVuc
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        k.*, 
        -- Đếm tổng số trò chơi có mã khu vực khớp với mã khu vực hiện tại
        (SELECT COUNT(MaTroChoi) FROM TroChoi t WHERE t.MaKhuVuc = k.MaKhuVuc) AS TongSoTroChoi,
        (SELECT COUNT(MaCuaHang) FROM CuaHang ch WHERE ch.MaKhuVuc = k.MaKhuVuc) AS TongSoCuaHang
    FROM KhuVuc k;
END;
GO
-- =================================================================
-- 9. STORED PROCEDURES: QUẢN LÝ CỬA HÀNG
-- =================================================================

-- Thêm Cửa Hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_CuaHang') DROP PROCEDURE sp_Insert_CuaHang;
GO
CREATE PROCEDURE sp_Insert_CuaHang
    @MaCuaHang NVARCHAR(10),
    @MaKhuVuc NVARCHAR(10),
    @TenCuaHang NVARCHAR(100),
    @LoaiCuaHang NVARCHAR(50),
    @TrangThai NVARCHAR(50) = N'Đang hoạt động'
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO CuaHang (MaCuaHang, MaKhuVuc, TenCuaHang, LoaiCuaHang, TrangThai)
    VALUES (@MaCuaHang, @MaKhuVuc, @TenCuaHang, @LoaiCuaHang, @TrangThai);
END;
GO

-- Cập nhật Cửa Hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_CuaHang') DROP PROCEDURE sp_Update_CuaHang;
GO
CREATE PROCEDURE sp_Update_CuaHang
    @MaCuaHang NVARCHAR(10),
    @MaKhuVuc NVARCHAR(10),
    @TenCuaHang NVARCHAR(100),
    @LoaiCuaHang NVARCHAR(50),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE CuaHang
    SET MaKhuVuc = @MaKhuVuc, TenCuaHang = @TenCuaHang, LoaiCuaHang = @LoaiCuaHang, TrangThai = @TrangThai
    WHERE MaCuaHang = @MaCuaHang;
END;
GO

-- Xóa Cửa Hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_CuaHang') DROP PROCEDURE sp_Delete_CuaHang;
GO
CREATE PROCEDURE sp_Delete_CuaHang
    @MaCuaHang NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM CuaHang WHERE MaCuaHang = @MaCuaHang;
END;
GO

-- Lấy danh sách Cửa Hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_CuaHang') DROP PROCEDURE sp_GetAll_CuaHang;
GO
CREATE PROCEDURE sp_GetAll_CuaHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ch.*, kv.TenKhuVuc,
    (SELECT COUNT(MaCuaHang) FROM SanPham sp WHERE sp.MaCuaHang = ch.MaCuaHang) AS TongSoSanPham
    FROM CuaHang ch
    INNER JOIN KhuVuc kv ON ch.MaKhuVuc = kv.MaKhuVuc;
END;
GO
-- =================================================================
-- 10. STORED PROCEDURES: QUẢN LÝ SỰ KIỆN
-- =================================================================

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_SuKien') DROP PROCEDURE sp_Insert_SuKien;
GO
CREATE PROCEDURE sp_Insert_SuKien
    @MaSuKien NVARCHAR(10),
    @TenSuKien NVARCHAR(100),
    @MoTa NVARCHAR(500),
    @NgayBatDau DATETIME,
    @NgayKetThuc DATETIME,
    @MaGiamGia NVARCHAR(50) = NULL,
    @PhanTramGiam DECIMAL(5,2) = NULL,
    @GiamToiDa DECIMAL(18,2) = NULL,
    @TrangThai BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO SuKien (MaSuKien, TenSuKien, MoTa, NgayBatDau, NgayKetThuc, MaGiamGia, PhanTramGiam, GiamToiDa, TrangThai)
    VALUES (@MaSuKien, @TenSuKien, @MoTa, @NgayBatDau, @NgayKetThuc, @MaGiamGia, @PhanTramGiam, @GiamToiDa, @TrangThai);
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_SuKien') DROP PROCEDURE sp_Update_SuKien;
GO
CREATE PROCEDURE sp_Update_SuKien
    @MaSuKien NVARCHAR(10),
    @TenSuKien NVARCHAR(100),
    @MoTa NVARCHAR(500),
    @NgayBatDau DATETIME,
    @NgayKetThuc DATETIME,
    @MaGiamGia NVARCHAR(50),
    @PhanTramGiam DECIMAL(5,2),
    @GiamToiDa DECIMAL(18,2),
    @TrangThai BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE SuKien
    SET TenSuKien = @TenSuKien, MoTa = @MoTa, NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc,
        MaGiamGia = @MaGiamGia, PhanTramGiam = @PhanTramGiam, GiamToiDa = @GiamToiDa, TrangThai = @TrangThai
    WHERE MaSuKien = @MaSuKien;
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_SuKien') DROP PROCEDURE sp_Delete_SuKien;
GO
CREATE PROCEDURE sp_Delete_SuKien
    @MaSuKien NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM SuKien WHERE MaSuKien = @MaSuKien;
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_SuKien') DROP PROCEDURE sp_GetAll_SuKien;
GO
CREATE PROCEDURE sp_GetAll_SuKien
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM SuKien;
END;
GO
-- =================================================================
-- 11. STORED PROCEDURES: QUẢN LÝ HẠNG THÀNH VIÊN
-- =================================================================

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_HangThanhVien') DROP PROCEDURE sp_Insert_HangThanhVien;
GO
CREATE PROCEDURE sp_Insert_HangThanhVien
    @MaHang NVARCHAR(10),
    @TenHang NVARCHAR(50),
    @DiemToiThieu INT,
    @TiLeGiamGia DECIMAL(5,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO HangThanhVien (MaHang, TenHang, DiemToiThieu, TiLeGiamGia)
    VALUES (@MaHang, @TenHang, @DiemToiThieu, @TiLeGiamGia);
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_HangThanhVien') DROP PROCEDURE sp_Update_HangThanhVien;
GO
CREATE PROCEDURE sp_Update_HangThanhVien
    @MaHang NVARCHAR(10),
    @TenHang NVARCHAR(50),
    @DiemToiThieu INT,
    @TiLeGiamGia DECIMAL(5,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE HangThanhVien
    SET TenHang = @TenHang, DiemToiThieu = @DiemToiThieu, TiLeGiamGia = @TiLeGiamGia
    WHERE MaHang = @MaHang;
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_HangThanhVien') DROP PROCEDURE sp_Delete_HangThanhVien;
GO
CREATE PROCEDURE sp_Delete_HangThanhVien
    @MaHang NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM HangThanhVien WHERE MaHang = @MaHang;
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_HangThanhVien') DROP PROCEDURE sp_GetAll_HangThanhVien;
GO
CREATE PROCEDURE sp_GetAll_HangThanhVien
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM HangThanhVien;
END;
GO
-- =================================================================
-- 12. STORED PROCEDURES: ĐĂNG KÝ THÀNH VIÊN
-- =================================================================

--IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_DangKyThanhVien') DROP PROCEDURE sp_Insert_DangKyThanhVien;
--GO
--CREATE PROCEDURE sp_Insert_DangKyThanhVien
--    @MaDangKy NVARCHAR(10),
--    @NgayDangKy DATE,
--    @DiaDiemDangKy NVARCHAR(100)
--AS
--BEGIN
--    SET NOCOUNT ON;
--    INSERT INTO DangKyThanhVien (MaDangKy, NgayDangKy, DiaDiemDangKy)
--    VALUES (@MaDangKy, @NgayDangKy, @DiaDiemDangKy);
--END;
--GO

--IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_DangKyThanhVien') DROP PROCEDURE sp_Update_DangKyThanhVien;
--GO
--CREATE PROCEDURE sp_Update_DangKyThanhVien
--    @MaDangKy NVARCHAR(10),
--    @NgayDangKy DATE,
--    @DiaDiemDangKy NVARCHAR(100)
--AS
--BEGIN
--    SET NOCOUNT ON;
--    UPDATE DangKyThanhVien
--    SET NgayDangKy = @NgayDangKy, DiaDiemDangKy = @DiaDiemDangKy
--    WHERE MaDangKy = @MaDangKy;
--END;
--GO

--IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_DangKyThanhVien') DROP PROCEDURE sp_Delete_DangKyThanhVien;
--GO
--CREATE PROCEDURE sp_Delete_DangKyThanhVien
--    @MaDangKy NVARCHAR(10)
--AS
--BEGIN
--    SET NOCOUNT ON;
--    DELETE FROM DangKyThanhVien WHERE MaDangKy = @MaDangKy;
--END;
--GO

--IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_DangKyThanhVien') DROP PROCEDURE sp_GetAll_DangKyThanhVien;
--GO
--CREATE PROCEDURE sp_GetAll_DangKyThanhVien
--AS
--BEGIN
--    SET NOCOUNT ON;
--    SELECT * FROM DangKyThanhVien;
--END;
--GO
-- =================================================================
-- 13. STORED PROCEDURES: QUẢN LÝ CA LÀM VIỆC
-- =================================================================

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_CaLamViec') DROP PROCEDURE sp_Insert_CaLamViec;
GO
CREATE PROCEDURE sp_Insert_CaLamViec
    @MaCa NVARCHAR(10),
    @TenCa NVARCHAR(50),
    @GioBatDau TIME,
    @GioKetThuc TIME
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO CaLamViec (MaCa, TenCa, GioBatDau, GioKetThuc)
    VALUES (@MaCa, @TenCa, @GioBatDau, @GioKetThuc);
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_CaLamViec') DROP PROCEDURE sp_Update_CaLamViec;
GO
CREATE PROCEDURE sp_Update_CaLamViec
    @MaCa NVARCHAR(10),
    @TenCa NVARCHAR(50),
    @GioBatDau TIME,
    @GioKetThuc TIME
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE CaLamViec
    SET TenCa = @TenCa, GioBatDau = @GioBatDau, GioKetThuc = @GioKetThuc
    WHERE MaCa = @MaCa;
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_CaLamViec') DROP PROCEDURE sp_Delete_CaLamViec;
GO
CREATE PROCEDURE sp_Delete_CaLamViec
    @MaCa NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM CaLamViec WHERE MaCa = @MaCa;
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_CaLamViec') DROP PROCEDURE sp_GetAll_CaLamViec;
GO
CREATE PROCEDURE sp_GetAll_CaLamViec
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM CaLamViec;
END;
GO
-- =================================================================
-- 14. STORED PROCEDURES: QUẢN LÝ LỊCH LÀM VIỆC
-- =================================================================

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_LichLamViec') DROP PROCEDURE sp_Insert_LichLamViec;
GO
CREATE PROCEDURE sp_Insert_LichLamViec
    @MaLich NVARCHAR(10),
    @MaNhanVien NVARCHAR(10),
    @MaCa NVARCHAR(10),
    @NgayLamViec DATE,
    @ViTriPhanCong NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO LichLamViec (MaLich, MaNhanVien, MaCa, NgayLamViec, ViTriPhanCong)
    VALUES (@MaLich, @MaNhanVien, @MaCa, @NgayLamViec, @ViTriPhanCong);
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_LichLamViec') DROP PROCEDURE sp_Update_LichLamViec;
GO
CREATE PROCEDURE sp_Update_LichLamViec
    @MaLich NVARCHAR(10),
    @MaNhanVien NVARCHAR(10),
    @MaCa NVARCHAR(10),
    @NgayLamViec DATE,
    @ViTriPhanCong NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE LichLamViec
    SET MaNhanVien = @MaNhanVien, MaCa = @MaCa, NgayLamViec = @NgayLamViec, ViTriPhanCong = @ViTriPhanCong
    WHERE MaLich = @MaLich;
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_LichLamViec') DROP PROCEDURE sp_Delete_LichLamViec;
GO
CREATE PROCEDURE sp_Delete_LichLamViec
    @MaLich NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM LichLamViec WHERE MaLich = @MaLich;
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_LichLamViec')
    DROP PROCEDURE sp_GetAll_LichLamViec;
GO

CREATE PROCEDURE sp_GetAll_LichLamViec
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        l.MaLich,
        l.MaNhanVien,
        nv.HoTen AS TenNhanVien,
        nv.ViTri AS ChucVuGoc,
        l.MaCa,
        c.TenCa,
        -- Ghép giờ làm việc hiển thị cho gọn (Ví dụ: 07:30 - 15:30)
        (LEFT(CONVERT(VARCHAR, c.GioBatDau, 108), 5) + ' - ' + LEFT(CONVERT(VARCHAR, c.GioKetThuc, 108), 5)) AS KhungGio,
        l.NgayLamViec,
        l.ViTriPhanCong
    FROM LichLamViec l
    INNER JOIN NhanVien nv ON l.MaNhanVien = nv.MaNhanVien
    INNER JOIN CaLamViec c ON l.MaCa = c.MaCa
    ORDER BY l.NgayLamViec DESC, c.GioBatDau ASC; -- Lịch mới nhất hiện lên đầu
END;
GO
-- =================================================================
-- 15 STORED PROCEDURES: QUẢN LÝ HÓA ĐƠN CỬA HÀNG
-- =================================================================

-- Thêm Hóa Đơn Cửa Hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_HoaDonCuaHang') DROP PROCEDURE sp_Insert_HoaDonCuaHang;
GO
CREATE PROCEDURE sp_Insert_HoaDonCuaHang
    @MaHDCH NVARCHAR(10),
    @MaCuaHang NVARCHAR(10),
    @MaKhachHang NVARCHAR(10),
    @MaNhanVien NVARCHAR(10),
    @TongTien DECIMAL(18,2)
AS BEGIN
    INSERT INTO HoaDonCuaHang (MaHDCH, MaCuaHang, MaKhachHang, MaNhanVien, TongTien)
    VALUES (@MaHDCH, @MaCuaHang, @MaKhachHang, @MaNhanVien, @TongTien);
END;
GO

-- Cập nhật Hóa Đơn Cửa Hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_HoaDonCuaHang') DROP PROCEDURE sp_Update_HoaDonCuaHang;
GO
CREATE PROCEDURE sp_Update_HoaDonCuaHang
    @MaHDCH NVARCHAR(10),
    @MaCuaHang NVARCHAR(10),
    @MaKhachHang NVARCHAR(10),
    @MaNhanVien NVARCHAR(10),
    @TongTien DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE HoaDonCuaHang
    SET MaCuaHang = @MaCuaHang, MaKhachHang = @MaKhachHang, MaNhanVien = @MaNhanVien, TongTien = @TongTien
    WHERE MaHDCH = @MaHDCH;
END;
GO

-- Xóa Hóa Đơn Cửa Hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_HoaDonCuaHang') DROP PROCEDURE sp_Delete_HoaDonCuaHang;
GO
CREATE PROCEDURE sp_Delete_HoaDonCuaHang
    @MaHDCH NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM HoaDonCuaHang WHERE MaHDCH = @MaHDCH;
END;
GO

-- Lấy danh sách Hóa Đơn Cửa Hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_HoaDonCuaHang') DROP PROCEDURE sp_GetAll_HoaDonCuaHang;
GO
CREATE PROCEDURE sp_GetAll_HoaDonCuaHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT hd.*, kh.HoTen AS TenKhachHang, kh.SoDienThoai, nv.HoTen AS TenNhanVien
    FROM HoaDonCuaHang hd
    INNER JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
    INNER JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
END;
GO
-- =================================================================
-- 16 STORED PROCEDURES: CHI TIẾT HÓA ĐƠN CỬA HÀNG
-- =================================================================

-- Thêm Chi Tiết Hóa Đơn Cửa Hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_ChiTietHDCH') DROP PROCEDURE sp_Insert_ChiTietHDCH;
GO
CREATE PROCEDURE sp_Insert_ChiTietHDCH
    @MaCTHDCH NVARCHAR(10),
    @MaHDCH NVARCHAR(10),
    @MaSanPham NVARCHAR(10),
    @SoLuong INT,
    @DonGia DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ChiTietHDCH (MaCTHDCH, MaHDCH, MaSanPham, SoLuong, GiaBan)
    VALUES (@MaCTHDCH, @MaHDCH, @MaSanPham, @SoLuong, @DonGia);
END;
GO

-- Cập nhật Chi Tiết Hóa Đơn Cửa Hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_ChiTietHDCH') DROP PROCEDURE sp_Update_ChiTietHDCH;
GO
CREATE PROCEDURE sp_Update_ChiTietHDCH
    @MaCTHDCH NVARCHAR(10),
    @MaHDCH NVARCHAR(10),
    @MaSanPham NVARCHAR(10),
    @SoLuong INT,
    @GiaBan DECIMAL(18,2),
    @ThanhTien DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE ChiTietHDCH
    SET MaHDCH = @MaHDCH, MaSanPham = @MaSanPham, SoLuong = @SoLuong, GiaBan = @GiaBan
    WHERE MaCTHDCH = @MaCTHDCH;
END;
GO

-- Xóa Chi Tiết Hóa Đơn Cửa Hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_ChiTietHDCH') DROP PROCEDURE sp_Delete_ChiTietHDCH;
GO
CREATE PROCEDURE sp_Delete_ChiTietHDCH
    @MaCTHDCH NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM ChiTietHDCH WHERE MaCTHDCH = @MaCTHDCH;
END;
GO

-- Lấy chi tiết sản phẩm theo mã hóa đơn cửa hàng
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetChiTiet_ByHDCH') DROP PROCEDURE sp_GetChiTiet_ByHDCH;
GO
CREATE PROCEDURE sp_GetChiTiet_ByHDCH
    @MaHDCH NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ct.*, sp.TenSanPham, sp.LoaiSanPham
    FROM ChiTietHDCH ct
    INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
    WHERE ct.MaHDCH = @MaHDCH;
END;
GO
-- =================================================================
-- 17 STORED PROCEDURES: QUẢN LÝ BẢO TRÌ TRÒ CHƠI
-- =================================================================

-- Thêm Bảo Trì Trò Chơi
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insert_BaoTriTroChoi') DROP PROCEDURE sp_Insert_BaoTriTroChoi;
GO
CREATE PROCEDURE sp_Insert_BaoTriTroChoi
    @MaBaoTri NVARCHAR(10),
    @MaTroChoi NVARCHAR(10),
    @MaNhanVien NVARCHAR(10),
    @NgayBatDau DATE,
    @NgayDuKienXong DATE = NULL,
    @MoTaLoi NVARCHAR(500) = NULL,
    @ChiPhiBaoTri DECIMAL(18,2) = NULL,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO BaoTriTroChoi (MaBaoTri, MaTroChoi, MaNhanVien, NgayBatDau, NgayDuKienXong, MoTaLoi, ChiPhiBaoTri, TrangThai)
    VALUES (@MaBaoTri, @MaTroChoi, @MaNhanVien, @NgayBatDau, @NgayDuKienXong, @MoTaLoi, @ChiPhiBaoTri, @TrangThai);
END;
GO

-- Cập nhật Bảo Trì Trò Chơi
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_BaoTriTroChoi') DROP PROCEDURE sp_Update_BaoTriTroChoi;
GO
CREATE PROCEDURE sp_Update_BaoTriTroChoi
    @MaBaoTri NVARCHAR(10),
    @MaTroChoi NVARCHAR(10),
    @MaNhanVien NVARCHAR(10),
    @NgayBatDau DATE,
    @NgayDuKienXong DATE = NULL,
    @MoTaLoi NVARCHAR(500) = NULL,
    @ChiPhiBaoTri DECIMAL(18,2) = NULL,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE BaoTriTroChoi
    SET MaTroChoi = @MaTroChoi, MaNhanVien = @MaNhanVien, NgayBatDau = @NgayBatDau, 
        NgayDuKienXong = @NgayDuKienXong, MoTaLoi = @MoTaLoi, ChiPhiBaoTri = @ChiPhiBaoTri, TrangThai = @TrangThai
    WHERE MaBaoTri = @MaBaoTri;
END;
GO

-- Xóa Bảo Trì Trò Chơi
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_BaoTriTroChoi') DROP PROCEDURE sp_Delete_BaoTriTroChoi;
GO
CREATE PROCEDURE sp_Delete_BaoTriTroChoi
    @MaBaoTri NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM BaoTriTroChoi WHERE MaBaoTri = @MaBaoTri;
END;
GO

-- Lấy danh sách Bảo Trì Trò Chơi (Kèm tên trò chơi và tên nhân viên để hiển thị lên GridView)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_BaoTriTroChoi') DROP PROCEDURE sp_GetAll_BaoTriTroChoi;
GO
CREATE PROCEDURE sp_GetAll_BaoTriTroChoi
AS
BEGIN
    SET NOCOUNT ON;
    SELECT bt.*, tc.TenTroChoi, nv.HoTen AS TenNhanVien
    FROM BaoTriTroChoi bt
    INNER JOIN TroChoi tc ON bt.MaTroChoi = tc.MaTroChoi
    INNER JOIN NhanVien nv ON bt.MaNhanVien = nv.MaNhanVien
    ORDER BY bt.NgayBatDau DESC;
END;
GO

-- =================================================================
-- 17 STORED PROCEDURES: LỊCH LÀM VIỆC (UPDATE)
-- =================================================================
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetLichLamViecMatrix')
    DROP PROCEDURE sp_GetLichLamViecMatrix;
GO

CREATE PROCEDURE sp_GetLichLamViecMatrix
    @NgayDauTuan DATE -- Truyền ngày Thứ 2 của tuần muốn xem lịch xuống
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Tính toán ngày kết thúc tuần (Chủ nhật)
    DECLARE @NgayCuoiTuan DATE = DATEADD(DAY, 6, @NgayDauTuan);

    SELECT 
        HoTen AS [Tên NV],
        ISNULL([Thứ 2], '') AS [Thứ 2],
        ISNULL([Thứ 3], '') AS [Thứ 3],
        ISNULL([Thứ 4], '') AS [Thứ 4],
        ISNULL([Thứ 5], '') AS [Thứ 5],
        ISNULL([Thứ 6], '') AS [Thứ 6],
        ISNULL([Thứ 7], '') AS [Thứ 7],
        ISNULL([Chủ Nhật], '') AS [Chủ Nhật]
    FROM 
    (
        SELECT 
            nv.HoTen,
            -- Xác định xem ngày đó thuộc Thứ mấy trong tuần
            CASE DATEPART(WEEKDAY, l.NgayLamViec)
                WHEN 2 THEN N'Thứ 2'
                WHEN 3 THEN N'Thứ 3'
                WHEN 4 THEN N'Thứ 4'
                WHEN 5 THEN N'Thứ 5'
                WHEN 6 THEN N'Thứ 6'
                WHEN 7 THEN N'Thứ 7'
                WHEN 1 THEN N'Chủ Nhật'
            END AS ThuTrongTuan,
            c.TenCa -- Giá trị hiển thị vào ô giao cắt (Ví dụ: Sáng, Chiều, Tối)
        FROM NhanVien nv
        INNER JOIN LichLamViec l ON nv.MaNhanVien = l.MaNhanVien
        INNER JOIN CaLamViec c ON l.MaCa = c.MaCa
        WHERE l.NgayLamViec BETWEEN @NgayDauTuan AND @NgayCuoiTuan
    ) AS SourceTable
    PIVOT
    (
        MAX(TenCa)
        FOR ThuTrongTuan IN ([Thứ 2], [Thứ 3], [Thứ 4], [Thứ 5], [Thứ 6], [Thứ 7], [Chủ Nhật])
    ) AS PivotTable;
END;
GO
-- =================================================================
-- 18 STORED PROCEDURES: VÉ
-- =================================================================
-- 1. Get All Ve
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAll_Ve')
    DROP PROCEDURE sp_GetAll_Ve;
GO
CREATE PROCEDURE sp_GetAll_Ve
AS
BEGIN
    SELECT * FROM Ve;
END
GO
-- 2. Delete Ve
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Delete_Ve')
    DROP PROCEDURE sp_Delete_Ve;
GO
CREATE PROCEDURE sp_Delete_Ve
    @MaVe NVARCHAR(20)
AS
BEGIN
    DELETE FROM Ve WHERE MaVe = @MaVe;
END
GO
-- 3. Update Ve
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Update_Ve')
    DROP PROCEDURE sp_Update_Ve;
GO
CREATE PROCEDURE sp_Update_Ve
    @MaVe NVARCHAR(20),
    @MaHoaDon NVARCHAR(20),
    @MaLoaiVe NVARCHAR(20),
    @DonGia DECIMAL(18,2),
    @NgaySuDung DATETIME,
    @DaSuDung BIT
AS
BEGIN
    UPDATE Ve
    SET MaHoaDon = @MaHoaDon,
        MaLoaiVe = @MaLoaiVe,
        DonGia = @DonGia,
        NgaySuDung = @NgaySuDung,
        DaSuDung = @DaSuDung
    WHERE MaVe = @MaVe;
END
GO
-- 4. Search Ve
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Search_Ve')
    DROP PROCEDURE sp_Search_Ve;
GO
CREATE PROCEDURE sp_Search_Ve
    @TuKhoa NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Ve 
    WHERE MaVe LIKE '%' + @TuKhoa + '%' OR MaHoaDon LIKE '%' + @TuKhoa + '%';
END
GO

-- =================================================================
-- 18 STORED PROCEDURES: LẤY THÔNG TIN CHI TIẾT HÓA ĐƠN & VÉ
-- =================================================================
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_LayThongTinChiTietHoaDon')
    DROP PROCEDURE sp_LayThongTinChiTietHoaDon;
GO
CREATE PROCEDURE sp_LayThongTinChiTietHoaDon
    @MaHoaDon VARCHAR(50) -- Nhớ sửa kiểu dữ liệu này nếu DB của bạn dùng INT hoặc kiểu khác
AS
BEGIN
    -- SET NOCOUNT ON giúp tăng hiệu suất bằng cách chặn thông báo số dòng bị ảnh hưởng
    SET NOCOUNT ON; 

    SELECT 
        kh.HoTen AS TenKhachHang, 
        kh.SoDienThoai,
        nv.HoTen AS TenNhanVien, 
        hd.NgayMua, 
        hd.TongTien 
    FROM HoaDonVe hd
    INNER JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
    INNER JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
    WHERE hd.MaHoaDon = @MaHoaDon;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_LayDanhSachVeThuocHoaDon')
    DROP PROCEDURE sp_LayDanhSachVeThuocHoaDon;
GO
CREATE PROCEDURE sp_LayDanhSachVeThuocHoaDon
    @MaHoaDon VARCHAR(50) -- Giữ nguyên kiểu dữ liệu bạn đang dùng
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        lv.TenLoaiVe, 
        lv.GiaVe, 
        COUNT(v.MaVe) AS SoLuong, 
        (lv.GiaVe * COUNT(v.MaVe)) AS TongTien
    FROM Ve v
    INNER JOIN LoaiVe lv ON v.MaLoaiVe = lv.MaLoaiVe
    WHERE v.MaHoaDon = @MaHoaDon
    GROUP BY 
        lv.TenLoaiVe, 
        lv.GiaVe;
END
GO

-- =================================================================
-- 19 STORED PROCEDURES: DASHBOARD (THỐNG KÊ)
-- =================================================================

-- Lấy 4 chỉ số tổng quan
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Dashboard_GetStats') DROP PROCEDURE sp_Dashboard_GetStats;
GO
CREATE PROCEDURE sp_Dashboard_GetStats
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @TongVeBan INT = (SELECT ISNULL(SUM(SoLuong), 0) FROM HoaDonVe);
    DECLARE @KhachHangMoi INT = (SELECT COUNT(*) FROM KhachHang);
    DECLARE @DoanhThuVe DECIMAL(18,2) = (SELECT ISNULL(SUM(TongTien), 0) FROM HoaDonVe);
    DECLARE @DoanhThuCuaHang DECIMAL(18,2) = (SELECT ISNULL(SUM(TongTien), 0) FROM HoaDonCuaHang);
    
    SELECT 
        @TongVeBan AS TongVeBan, 
        @KhachHangMoi AS KhachHangMoi, 
        @DoanhThuVe AS DoanhThuVe, 
        @DoanhThuCuaHang AS DoanhThuCuaHang;
END;
GO

-- Lấy doanh thu theo ngày trong 1 tháng (Line Chart)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Dashboard_GetRevenueByMonth') DROP PROCEDURE sp_Dashboard_GetRevenueByMonth;
GO
CREATE PROCEDURE sp_Dashboard_GetRevenueByMonth
    @Thang INT,
    @Nam INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Tính doanh thu gộp từ vé và cửa hàng theo từng ngày
    SELECT 
        DAY(Ngay) AS Ngay,
        SUM(TongDoanhThu) AS DoanhThu
    FROM (
        SELECT NgayMua AS Ngay, TongTien AS TongDoanhThu FROM HoaDonVe WHERE MONTH(NgayMua) = @Thang AND YEAR(NgayMua) = @Nam
        UNION ALL
        SELECT NgayTao AS Ngay, TongTien AS TongDoanhThu FROM HoaDonCuaHang WHERE MONTH(NgayTao) = @Thang AND YEAR(NgayTao) = @Nam
    ) AS DoanhThuGop
    GROUP BY DAY(Ngay)
    ORDER BY DAY(Ngay);
END;
GO

-- Lấy thống kê loại vé bán ra trong tháng (Donut Chart)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Dashboard_GetTicketTypes') DROP PROCEDURE sp_Dashboard_GetTicketTypes;
GO
CREATE PROCEDURE sp_Dashboard_GetTicketTypes
    @Thang INT,
    @Nam INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        lv.TenLoaiVe, 
        COUNT(v.MaVe) AS SoLuong
    FROM Ve v
    INNER JOIN LoaiVe lv ON v.MaLoaiVe = lv.MaLoaiVe
    INNER JOIN HoaDonVe hd ON v.MaHoaDon = hd.MaHoaDon
    WHERE MONTH(hd.NgayMua) = @Thang AND YEAR(hd.NgayMua) = @Nam
    GROUP BY lv.TenLoaiVe;
END;
GO

-- Lấy hóa đơn gần đây (15 hóa đơn mới nhất)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Dashboard_GetRecentInvoices') DROP PROCEDURE sp_Dashboard_GetRecentInvoices;
GO
CREATE PROCEDURE sp_Dashboard_GetRecentInvoices
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 15
        hd.MaHoaDon AS MaHD,
        kh.HoTen AS KhachHang,
        hd.SoLuong AS SoVe,
        hd.TongTien,
        hd.TrangThai
    FROM HoaDonVe hd
    INNER JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
    ORDER BY hd.NgayMua DESC;
END;
GO
-- =================================================================
-- 19 STORED PROCEDURES: DASHBOARD (THỐNG KÊ)
-- =================================================================

-- Lấy 4 chỉ số tổng quan
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Dashboard_GetStats') DROP PROCEDURE sp_Dashboard_GetStats;
GO
CREATE PROCEDURE sp_Dashboard_GetStats
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @TongVeBan INT = (SELECT ISNULL(SUM(SoLuong), 0) FROM HoaDonVe);
    DECLARE @KhachHangMoi INT = (SELECT COUNT(*) FROM KhachHang);
    DECLARE @DoanhThuVe DECIMAL(18,2) = (SELECT ISNULL(SUM(TongTien), 0) FROM HoaDonVe);
    DECLARE @DoanhThuCuaHang DECIMAL(18,2) = (SELECT ISNULL(SUM(TongTien), 0) FROM HoaDonCuaHang);
    
    SELECT 
        @TongVeBan AS TongVeBan, 
        @KhachHangMoi AS KhachHangMoi, 
        @DoanhThuVe AS DoanhThuVe, 
        @DoanhThuCuaHang AS DoanhThuCuaHang;
END;
GO

-- Lấy doanh thu theo ngày trong 1 tháng (Line Chart)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Dashboard_GetRevenueByMonth') DROP PROCEDURE sp_Dashboard_GetRevenueByMonth;
GO
CREATE PROCEDURE sp_Dashboard_GetRevenueByMonth
    @Thang INT,
    @Nam INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Tính doanh thu gộp từ vé và cửa hàng theo từng ngày
    SELECT 
        DAY(Ngay) AS Ngay,
        SUM(TongDoanhThu) AS DoanhThu
    FROM (
        SELECT NgayMua AS Ngay, TongTien AS TongDoanhThu FROM HoaDonVe WHERE MONTH(NgayMua) = @Thang AND YEAR(NgayMua) = @Nam
        UNION ALL
        SELECT NgayTao AS Ngay, TongTien AS TongDoanhThu FROM HoaDonCuaHang WHERE MONTH(NgayTao) = @Thang AND YEAR(NgayTao) = @Nam
    ) AS DoanhThuGop
    GROUP BY DAY(Ngay)
    ORDER BY DAY(Ngay);
END;
GO

-- Lấy thống kê loại vé bán ra trong tháng (Donut Chart)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Dashboard_GetTicketTypes') DROP PROCEDURE sp_Dashboard_GetTicketTypes;
GO
CREATE PROCEDURE sp_Dashboard_GetTicketTypes
    @Thang INT,
    @Nam INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        lv.TenLoaiVe, 
        COUNT(v.MaVe) AS SoLuong
    FROM Ve v
    INNER JOIN LoaiVe lv ON v.MaLoaiVe = lv.MaLoaiVe
    INNER JOIN HoaDonVe hd ON v.MaHoaDon = hd.MaHoaDon
    WHERE MONTH(hd.NgayMua) = @Thang AND YEAR(hd.NgayMua) = @Nam
    GROUP BY lv.TenLoaiVe;
END;
GO

-- Lấy hóa đơn gần đây (15 hóa đơn mới nhất)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Dashboard_GetRecentInvoices') DROP PROCEDURE sp_Dashboard_GetRecentInvoices;
GO
CREATE PROCEDURE sp_Dashboard_GetRecentInvoices
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 15
        hd.MaHoaDon AS MaHD,
        kh.HoTen AS KhachHang,
        hd.SoLuong AS SoVe,
        hd.TongTien,
        hd.TrangThai
    FROM HoaDonVe hd
    INNER JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
    ORDER BY hd.NgayMua DESC;
END;
GO
