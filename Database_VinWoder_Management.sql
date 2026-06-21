-- =================================================================
-- KHOI TAO DATABASE: VinWonders Management (Ban Chuan - Final)
-- =================================================================
CREATE DATABASE VinWonders_Management;
GO

USE VinWonders_Management;
GO

-- =================================================================
-- NHOM 1: DANH SACH CAC BANG GOC
-- =================================================================
CREATE TABLE TaiKhoan (
    MaTaiKhoan NVARCHAR(10) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(255) NOT NULL,
    QuyenTruyCap NVARCHAR(20) NOT NULL, -- Admin, QuanLy, ThuNgan
    TrangThai BIT DEFAULT 1, 
    NgayTao DATETIME DEFAULT GETDATE()
);

CREATE TABLE HangThanhVien (
    MaHang NVARCHAR(10) PRIMARY KEY,
    TenHang NVARCHAR(50) NOT NULL, 
    DiemToiThieu INT NOT NULL CHECK (DiemToiThieu >= 0),
    TiLeGiamGia DECIMAL(5,2) CHECK (TiLeGiamGia >= 0 AND TiLeGiamGia <= 100)
);

CREATE TABLE KhuVuc (
    MaKhuVuc NVARCHAR(10) PRIMARY KEY,
    TenKhuVuc NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(500),
    GioMoCua TIME,
    GioDongCua TIME
);

CREATE TABLE CaLamViec (
    MaCa NVARCHAR(10) PRIMARY KEY,
    TenCa NVARCHAR(50) NOT NULL,
    GioBatDau TIME NOT NULL,
    GioKetThuc TIME NOT NULL
);

CREATE TABLE SuKien (
    MaSuKien NVARCHAR(10) PRIMARY KEY,
    TenSuKien NVARCHAR(100) NOT NULL, 
    MoTa NVARCHAR(500),
    NgayBatDau DATETIME NOT NULL,
    NgayKetThuc DATETIME NOT NULL,
    MaGiamGia NVARCHAR(20) UNIQUE, 
    PhanTramGiam DECIMAL(5,2), 
    GiamToiDa DECIMAL(18,2), 
    TrangThai BIT DEFAULT 1 
);

-- =================================================================
-- NHOM 2: DANH SACH CAC BANG CAP 1
-- =================================================================

CREATE TABLE KhachHang (
    MaKhachHang NVARCHAR(10) PRIMARY KEY,
    MaHang NVARCHAR(10) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    LoaiKhach NVARCHAR(50) DEFAULT N'Cá nhân', -- 'Cá nhân' hoặc 'Khách đoàn'
    NgaySinh DATE,
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(100),
    DiemTichLuy INT DEFAULT 0,
    FOREIGN KEY (MaHang) REFERENCES HangThanhVien(MaHang)
);

CREATE TABLE NhanVien (
    MaNhanVien NVARCHAR(10) PRIMARY KEY,
    MaTaiKhoan NVARCHAR(10) NULL, -- Liên kết 1-1 với Tài Khoản
    HoTen NVARCHAR(50) NOT NULL,
    GioTinh NVARCHAR(3),
    NgaySinh DATE,
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(50),
    CCCD NVARCHAR(12),
    ViTri NVARCHAR(50), 
    Luong DECIMAL(18,2),
    NgayVaoLam DATE,
    FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan(MaTaiKhoan)
);

CREATE TABLE TroChoi (
    MaTroChoi NVARCHAR(10) PRIMARY KEY,
    MaKhuVuc NVARCHAR(10) NOT NULL,
    TenTroChoi NVARCHAR(100) NOT NULL,
    PhanLoai NVARCHAR(50),
    ChieuCaoToiThieu INT, 
    DoTuoiToiThieu INT, 
    SucChua INT,
    TrangThai NVARCHAR(50), 
    FOREIGN KEY (MaKhuVuc) REFERENCES KhuVuc(MaKhuVuc)
);

CREATE TABLE CuaHang (
    MaCuaHang NVARCHAR(10) PRIMARY KEY,
    MaKhuVuc NVARCHAR(10) NOT NULL,
    TenCuaHang NVARCHAR(100) NOT NULL,
    LoaiCuaHang NVARCHAR(50), -- VD: Quầy Fastfood, Nhà hàng Buffet, Quầy Lưu niệm
    TrangThai NVARCHAR(50) DEFAULT N'Đang hoạt động',
    FOREIGN KEY (MaKhuVuc) REFERENCES KhuVuc(MaKhuVuc)
);

CREATE TABLE LoaiVe (
    MaLoaiVe NVARCHAR(10) PRIMARY KEY,
    TenLoaiVe NVARCHAR(100) NOT NULL,
    PhanLoai NVARCHAR(50), -- Vé vào cổng, Vé trọn gói, Combo ăn trưa
    GiaVe DECIMAL(18,2) NOT NULL,
    BaoGomAnUong BIT DEFAULT 0, 
    MoTa NVARCHAR(255)
);

-- =================================================================
-- NHOM 3: BẢNG TRUNG GIAN & DỊCH VỤ F&B
-- =================================================================

CREATE TABLE QuyenLoiVe_TroChoi (
    MaLoaiVe NVARCHAR(10) NOT NULL,
    MaTroChoi NVARCHAR(10) NOT NULL,
    PRIMARY KEY (MaLoaiVe, MaTroChoi),
    FOREIGN KEY (MaLoaiVe) REFERENCES LoaiVe(MaLoaiVe),
    FOREIGN KEY (MaTroChoi) REFERENCES TroChoi(MaTroChoi)
);

CREATE TABLE SanPham (
    MaSanPham NVARCHAR(10) PRIMARY KEY,
    MaCuaHang NVARCHAR(10) NOT NULL,
    TenSanPham NVARCHAR(100) NOT NULL,
    LoaiSanPham NVARCHAR(50), -- VD: Món chính, Đồ uống, Lưu niệm
    GiaBan DECIMAL(18,2) NOT NULL,
    TrangThaiBan NVARCHAR(50) DEFAULT N'Còn hàng', -- Khắc phục lỗi logic "Tồn kho"
    FOREIGN KEY (MaCuaHang) REFERENCES CuaHang(MaCuaHang)
);

-- =================================================================
-- NHOM 4: NGHIỆP VỤ HÓA ĐƠN VÀ THANH TOÁN
-- =================================================================

CREATE TABLE HoaDonVe (
    MaHoaDon NVARCHAR(10) PRIMARY KEY,
    MaKhachHang NVARCHAR(10) NOT NULL,
    MaNhanVien NVARCHAR(10) NOT NULL, 
    MaSuKien NVARCHAR(10) NULL,
    NgayMua DATETIME DEFAULT GETDATE(),
    ChietKhauDoan DECIMAL(18,2) DEFAULT 0,
    SoLuong INT,
    TongTien DECIMAL(18,2) NOT NULL,
    PhuongThucThanhToan NVARCHAR(50),
    TrangThai NVARCHAR(50),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaSuKien) REFERENCES SuKien(MaSuKien)
);

CREATE TABLE Ve (
    MaVe NVARCHAR(10) PRIMARY KEY,
    MaHoaDon NVARCHAR(10) NOT NULL, -- Liên kết trực tiếp để biết vé này thuộc hóa đơn nào
    MaLoaiVe NVARCHAR(10) NOT NULL, -- Cần biết vé này là loại vé gì (người lớn, trẻ em, combo...)
    DonGia DECIMAL(18,2) NOT NULL,  -- QUAN TRỌNG: Lưu lại giá vé tại thời điểm bán để đối soát doanh thu
    NgaySuDung DATE,
    DaSuDung BIT DEFAULT 0, 
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDonVe(MaHoaDon),
    FOREIGN KEY (MaLoaiVe) REFERENCES LoaiVe(MaLoaiVe)
);

CREATE TABLE HoaDonCuaHang (
    MaHDCH NVARCHAR(10) PRIMARY KEY,
    MaCuaHang NVARCHAR(10) NOT NULL,
    MaKhachHang NVARCHAR(10) NOT NULL,
    MaNhanVien NVARCHAR(10) NOT NULL, -- Ai thu tiền ở cửa hàng?
    TongTien DECIMAL(18,2) NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaCuaHang) REFERENCES CuaHang(MaCuaHang),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
    
CREATE TABLE ChiTietHDCH (
    MaCTHDCH NVARCHAR(10) PRIMARY KEY,
    MaHDCH NVARCHAR(10) NOT NULL,
    MaSanPham NVARCHAR(10) NOT NULL,
    SoLuong INT NOT NULL,
    GiaBan DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (MaHDCH) REFERENCES HoaDonCuaHang(MaHDCH),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);

-- =================================================================
-- NHOM 5: QUẢN LÝ CA LÀM & BẢO TRÌ
-- =================================================================

CREATE TABLE LichLamViec (
    MaLich NVARCHAR(10) PRIMARY KEY,
    MaNhanVien NVARCHAR(10) NOT NULL,
    MaCa NVARCHAR(10) NOT NULL,
    NgayLamViec DATE NOT NULL,
    ViTriPhanCong NVARCHAR(100),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaCa) REFERENCES CaLamViec(MaCa)
);

CREATE TABLE KhenThuongKyLuat (
    MaKTKL NVARCHAR(10) PRIMARY KEY,
    MaNhanVien NVARCHAR(10) NOT NULL,
    Loai NVARCHAR(50) NOT NULL, -- Điền: 'Khen thưởng' hoặc 'Kỷ luật'
    LyDo NVARCHAR(500) NOT NULL,
    SoTien DECIMAL(18,2) DEFAULT 0, -- Có thể cộng thêm (thưởng) hoặc trừ đi (phạt) vào lương
    NgayQuyetDinh DATE DEFAULT GETDATE(),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE BaoTriTroChoi (
    MaBaoTri NVARCHAR(10) PRIMARY KEY,
    MaTroChoi NVARCHAR(10) NOT NULL,
    MaNhanVien NVARCHAR(10) NOT NULL, 
    NgayBatDau DATE NOT NULL,
    NgayDuKienXong DATE,
    MoTaLoi NVARCHAR(500), 
    ChiPhiBaoTri DECIMAL(18,2) CHECK (ChiPhiBaoTri >= 0),
    TrangThai NVARCHAR(50), 
    FOREIGN KEY (MaTroChoi) REFERENCES TroChoi(MaTroChoi),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO

-- Tạo một UNIQUE INDEX có điều kiện (Filtered Index) - ĐÂY LÀ CHÌA KHÓA!
CREATE UNIQUE NONCLUSTERED INDEX UQ_NhanVien_MaTaiKhoan
ON NhanVien(MaTaiKhoan)
WHERE MaTaiKhoan IS NOT NULL; -- Chỉ báo lỗi trùng khi giá trị khác NULL
GO
