USE VinWonders_Management;
GO

-- ==========================================================
-- 1. DỮ LIỆU BẢNG CHA (Hạng Thành Viên, Khu Vực, Ca Làm Việc)
-- ==========================================================
INSERT INTO HangThanhVien (MaHang, TenHang, DiemToiThieu, TiLeGiamGia) VALUES
('HTV01', N'Thành viên Chuẩn', 0, 0),
('HTV02', N'Thành viên Bạc', 1000, 5.00),
('HTV03', N'Thành viên Vàng', 5000, 10.00),
('HTV04', N'Thành viên Kim Cương', 10000, 15.00);

INSERT INTO KhuVuc (MaKhuVuc, TenKhuVuc, MoTa, GioMoCua, GioDongCua) VALUES
('KV01', N'Khu Cảm Giác Mạnh', N'Tập trung các trò chơi mạo hiểm', '08:00', '22:00'),
('KV02', N'Công Viên Nước', N'Khu vui chơi dưới nước', '09:00', '18:00'),
('KV03', N'Khu Gia Đình & Trẻ Em', N'Phù hợp cho gia đình có trẻ nhỏ', '08:00', '22:00');

INSERT INTO CaLamViec (MaCa, TenCa, GioBatDau, GioKetThuc) VALUES
('CA01', N'Ca Sáng', '07:30', '15:30'),
('CA02', N'Ca Chiều', '15:00', '22:30'),
('CA03', N'Ca Tối (Bảo vệ)', '22:00', '06:00'),
('CA04', N'Ca Hành Chính', '08:00', '17:00'),
('CA05', N'Ca Gãy (F&B)', '10:00', '14:00');

-- ==========================================================
-- 2. DỮ LIỆU TÀI KHOẢN VÀ NHÂN VIÊN
-- ==========================================================
INSERT INTO TaiKhoan (MaTaiKhoan, TenDangNhap, MatKhau, QuyenTruyCap, TrangThai) VALUES
('TK01', 'admin', 'admin123', 'Admin', 1),
('TK02', 'thungan01', '123456', 'ThuNgan', 1),
('TK03', 'quanly01', '123456', 'QuanLy', 1),
('TK04', 'thungan02', '123456', 'ThuNgan', 1),
('TK05', 'quanly02', '123456', 'QuanLy', 1);

INSERT INTO NhanVien (MaNhanVien, MaTaiKhoan, HoTen, GioTinh, NgaySinh, SoDienThoai, Email, CCCD, ViTri, Luong, NgayVaoLam) VALUES
-- 3 nhân viên cũ đã được bổ sung thêm CCCD
('NV01', 'TK01', N'Nguyễn Quản Trị', N'Nam', '1990-01-01', '0901234567', 'admin@vinwonders.com', '079000000001', N'Quản trị hệ thống', 25000000, '2020-01-01'),
('NV02', 'TK02', N'Trần Thu Ngân', N'Nữ', '1998-05-15', '0987654321', 'thungan1@vinwonders.com', '079000000002', N'Thu ngân quầy vé', 10000000, '2023-05-01'),
('NV03', 'TK03', N'Lê Trưởng Ca', N'Nam', '1992-08-20', '0911222333', 'quanly1@vinwonders.com', '079000000003', N'Quản lý vận hành', 18000000, '2021-02-15'),

-- 5 nhân viên mới của bạn giữ nguyên
('NV04', 'TK04', N'Lê Thị Thu', N'Nữ', '2000-10-10', '0988777666', 'thungan02@vinwonders.com', '079123456789', N'Thu ngân quầy vé', 9500000, '2023-06-01'),
('NV05', 'TK05', N'Trần Văn Sếp', N'Nam', '1985-02-28', '0912345678', 'quanly02@vinwonders.com', '079987654321', N'Quản lý khu nước', 20000000, '2020-05-15'),
('NV06', NULL, N'Bùi Văn Bảo', N'Nam', '1975-08-14', '0909090909', NULL, '079111222333', N'Bảo vệ', 7000000, '2022-01-01'),
('NV07', NULL, N'Nguyễn Thị Tấm', N'Nữ', '1980-04-30', '0933333333', NULL, '079444555666', N'Nhân viên vệ sinh', 6500000, '2021-11-20'),
('NV08', NULL, N'Đặng Văn Chơi', N'Nam', '1995-12-12', '0977777777', NULL, '079777888999', N'Vận hành trò chơi', 8500000, '2022-03-10');

-- ==========================================================
-- THÊM 95 NHÂN VIÊN MỚI (TỪ ẢNH VINPEARL/VINWONDERS)
-- ==========================================================
INSERT INTO NhanVien (MaNhanVien, MaTaiKhoan, HoTen, GioTinh, NgaySinh, SoDienThoai, Email, CCCD, ViTri, Luong, NgayVaoLam) VALUES
('NV21430001', NULL, N'Nguyễn Văn An', N'Nam', '1995-02-15', '0912000001', 'nguyenvanan1@gmail.com', '079100000001', N'Tổ trưởng Phục vụ', 12000000, '2023-01-10'),
('NV21430002', NULL, N'Trần Thị Bình', N'Nữ', '1998-05-20', '0912000002', 'tranthibinh2@gmail.com', '079100000002', N'Tổ trưởng Kỹ thuật ME', 13500000, '2022-04-12'),
('NV21430003', NULL, N'Lê Minh Châu', N'Nữ', '2000-08-10', '0912000003', 'leminhchau3@gmail.com', '079100000003', N'Chuyên viên Phục vụ Cao cấp', 11000000, '2023-06-15'),
('NV21430004', NULL, N'Phạm Hữu Dũng', N'Nam', '1992-11-25', '0912000004', 'phamhuudung4@gmail.com', '079100000004', N'Đầu bếp Cao cấp Âu/Bánh', 18000000, '2021-02-28'),
('NV21430005', NULL, N'Hoàng Thị Giang', N'Nữ', '1997-01-05', '0912000005', 'hoangthigiang5@gmail.com', '079100000005', N'Đầu bếp Âu/Lạnh', 15000000, '2021-11-11'),
('NV21430006', NULL, N'Vũ Hải Hà', N'Nữ', '1999-07-14', '0912000006', 'vuhaiha6@gmail.com', '079100000006', N'Nhân viên Tạp vụ', 6500000, '2024-01-05'),
('NV21430007', NULL, N'Võ Văn Hùng', N'Nam', '1994-03-30', '0912000007', 'vovanhung7@gmail.com', '079100000007', N'Nhân viên Kỹ thuật', 9500000, '2022-09-09'),
('NV21430008', NULL, N'Đặng Thanh Hương', N'Nữ', '1996-12-12', '0912000008', 'dangthanhhuong8@gmail.com', '079100000008', N'Nhân viên Lễ tân/SC', 8500000, '2023-03-22'),
('NV21430009', NULL, N'Bùi Khắc Khang', N'Nam', '1991-04-18', '0912000009', 'buikhackhang9@gmail.com', '079100000009', N'Nhân viên Hành lý', 7500000, '2021-07-30'),
('NV21430010', NULL, N'Đỗ Thị Linh', N'Nữ', '2001-09-22', '0912000010', 'dothilinh10@gmail.com', '079100000010', N'Nhân viên Đón tiếp Nhà hàng/Tiền sảnh', 8000000, '2023-10-10'),

('NV21430011', NULL, N'Nguyễn Ngọc Mai', N'Nữ', '1998-02-14', '0912000011', 'nguyenngocmai11@gmail.com', '079100000011', N'Nhân viên Pha chế (Rượu)', 10000000, '2022-12-01'),
('NV21430012', NULL, N'Trần Xuân Nam', N'Nam', '1993-06-08', '0912000012', 'tranxuannam12@gmail.com', '079100000012', N'Nhân viên Phục vụ (Buffet/Room)', 7000000, '2024-02-15'),
('NV21430013', NULL, N'Lê Thị Oanh', N'Nữ', '1995-10-19', '0912000013', 'lethioanh13@gmail.com', '079100000013', N'Nhân viên Giặt là (Ca đêm)', 8500000, '2023-08-08'),
('NV21430014', NULL, N'Phạm Tuấn Phong', N'Nam', '1990-12-25', '0912000014', 'phamtuanphong14@gmail.com', '079100000014', N'Nhân viên Bảo mẫu', 9000000, '2021-05-18'),
('NV21430015', NULL, N'Hoàng Lệ Quyên', N'Nữ', '1997-04-30', '0912000015', 'hoanglequyen15@gmail.com', '079100000015', N'Đội trưởng Kỹ thuật', 14000000, '2022-03-25'),
('NV21430016', NULL, N'Vũ Trường Sơn', N'Nam', '1992-08-15', '0912000016', 'vutruongson16@gmail.com', '079100000016', N'Tổ trưởng Lễ tân - Thu ngân', 12500000, '2021-10-10'),
('NV21430017', NULL, N'Võ Thu Trang', N'Nữ', '2000-01-20', '0912000017', 'vothutrang17@gmail.com', '079100000017', N'Tổ trưởng Housekeeping', 11500000, '2023-11-20'),
('NV21430018', NULL, N'Đặng Quốc Tuấn', N'Nam', '1994-05-12', '0912000018', 'dangquoctuan18@gmail.com', '079100000018', N'Tổ trưởng Kỹ thuật BM/ME', 14500000, '2020-12-12'),
('NV21430019', NULL, N'Bùi Phương Uyên', N'Nữ', '1996-09-05', '0912000019', 'buiphuonguyen19@gmail.com', '079100000019', N'Tổ trưởng Bảo dưỡng cỏ & CQMT', 13000000, '2022-07-07'),
('NV21430020', NULL, N'Đỗ Quang Vinh', N'Nam', '1991-03-28', '0912000020', 'doquangvinh20@gmail.com', '079100000020', N'Nhân viên Lễ tân - Thu ngân', 8500000, '2021-04-14'),

('NV21430021', NULL, N'Nguyễn Hải Yến', N'Nữ', '1999-11-11', '0912000021', 'nguyenhaiyen21@gmail.com', '079100000021', N'Nhân viên Bảo dưỡng cỏ', 7500000, '2023-05-05'),
('NV21430022', NULL, N'Trần Văn Bách', N'Nam', '1985-02-20', '0912000022', 'tranvanbach22@gmail.com', '079100000022', N'Trưởng bộ phận Nhân sự', 22000000, '2019-08-15'),
('NV21430023', NULL, N'Lê Kim Cúc', N'Nữ', '1998-07-07', '0912000023', 'lekimcuc23@gmail.com', '079100000023', N'Tổ trưởng Cứu hộ', 12000000, '2022-06-20'),
('NV21430024', NULL, N'Phạm Tiến Đạt', N'Nam', '1993-10-15', '0912000024', 'phamtiendat24@gmail.com', '079100000024', N'Chuyên viên Kinh doanh', 15000000, '2021-09-09'),
('NV21430025', NULL, N'Hoàng Thị Én', N'Nữ', '1995-12-01', '0912000025', 'hoangthien25@gmail.com', '079100000025', N'Nhân viên Housekeeping/Cây xanh', 7000000, '2023-01-25'),
('NV21430026', NULL, N'Vũ Đình Giao', N'Nam', '1997-03-08', '0912000026', 'vudinhgiao26@gmail.com', '079100000026', N'Nhân viên Hướng dẫn', 8000000, '2022-11-11'),
('NV21430027', NULL, N'Võ Cẩm Hiền', N'Nữ', '2000-06-25', '0912000027', 'vocamhien27@gmail.com', '079100000027', N'Nhân viên Cứu hộ', 8500000, '2024-03-10'),
('NV21430028', NULL, N'Đặng Văn Kiên', N'Nam', '1992-09-30', '0912000028', 'dangvankien28@gmail.com', '079100000028', N'TBP Tổ chức Sự kiện', 20000000, '2020-05-15'),
('NV21430029', NULL, N'Bùi Thị Liễu', N'Nữ', '1994-01-14', '0912000029', 'buithilieu29@gmail.com', '079100000029', N'Nhân viên Bán hàng', 7500000, '2023-08-20'),
('NV21430030', NULL, N'Đỗ Nhật Minh', N'Nam', '1996-04-10', '0912000030', 'donhatminh30@gmail.com', '079100000030', N'Nhân viên Cây xanh', 7000000, '2021-12-05'),

('NV21430031', NULL, N'Nguyễn Ái Nữ', N'Nữ', '1988-08-22', '0912000031', 'nguyenainu31@gmail.com', '079100000031', N'Trưởng Bộ phận Công viên nước', 25000000, '2019-10-10'),
('NV21430032', NULL, N'Trần Đức Phú', N'Nam', '1991-11-05', '0912000032', 'tranducphu32@gmail.com', '079100000032', N'Trợ lý Tổng Quản lý', 23000000, '2020-02-28'),
('NV21430033', NULL, N'Lê Diễm Quỳnh', N'Nữ', '1993-02-18', '0912000033', 'lediemquynh33@gmail.com', '079100000033', N'Bếp trưởng', 22000000, '2021-04-15'),
('NV21430034', NULL, N'Phạm Cao Sáng', N'Nam', '1995-07-30', '0912000034', 'phamcaosang34@gmail.com', '079100000034', N'Tổ trưởng Kiểm soát cổng', 12000000, '2022-09-05'),
('NV21430035', NULL, N'Hoàng Bích Tâm', N'Nữ', '1997-10-12', '0912000035', 'hoangbichtam35@gmail.com', '079100000035', N'Chuyên viên Nhân sự(Quan hệ Lao động)', 14000000, '2023-01-20'),
('NV21430036', NULL, N'Vũ Quốc Uy', N'Nam', '1999-01-25', '0912000036', 'vuquocuy36@gmail.com', '079100000036', N'Chuyên viên Hành chính (Kỹ thuật)', 13500000, '2024-02-10'),
('NV21430037', NULL, N'Võ Hà Vi', N'Nữ', '2001-05-09', '0912000037', 'vohavi37@gmail.com', '079100000037', N'Nhân viên Chăm sóc Động vật Thuỷ cung', 9500000, '2023-07-15'),
('NV21430038', NULL, N'Đặng Khắc Việt', N'Nam', '1994-08-21', '0912000038', 'dangkhacviet38@gmail.com', '079100000038', N'Nhân viên Lễ tân Thu ngân', 8500000, '2021-11-25'),
('NV21430039', NULL, N'Bùi Tường Vy', N'Nữ', '1996-12-04', '0912000039', 'buituongvy39@gmail.com', '079100000039', N'Đầu bếp Cao cấp Á/Âu', 17000000, '2022-03-30'),
('NV21430040', NULL, N'Đỗ Hoàng Xuân', N'Nam', '1990-03-17', '0912000040', 'dohoangxuan40@gmail.com', '079100000040', N'Đầu bếp Á/Âu', 14500000, '2020-08-08'),

('NV21430041', NULL, N'Nguyễn Thị Yến', N'Nữ', '1998-06-29', '0912000041', 'nguyenthiyen41@gmail.com', '079100000041', N'Nhân viên Cứu hộ/ Thợ lặn', 10500000, '2023-04-12'),
('NV21430042', NULL, N'Trần Bảo Ân', N'Nam', '1992-09-10', '0912000042', 'tranbaoan42@gmail.com', '079100000042', N'Nhân viên Phục vụ', 7000000, '2021-06-05'),
('NV21430043', NULL, N'Lê Mai Bích', N'Nữ', '1995-11-22', '0912000043', 'lemaibich43@gmail.com', '079100000043', N'Nhân viên Biểu diễn Động vật', 11000000, '2022-10-18'),
('NV21430044', NULL, N'Phạm Tiến Công', N'Nam', '1997-02-05', '0912000044', 'phamtiencong44@gmail.com', '079100000044', N'Kỹ thuật viên Thú y', 12500000, '2023-09-22'),
('NV21430045', NULL, N'Hoàng Thùy Dương', N'Nữ', '1999-05-18', '0912000045', 'hoangthuyduong45@gmail.com', '079100000045', N'Đầu bếp Bếp Á', 13000000, '2024-01-30'),
('NV21430046', NULL, N'Vũ Thành Đạt', N'Nam', '1991-08-30', '0912000046', 'vuthanhdat46@gmail.com', '079100000046', N'Tổ trưởng PA/ Buồng Phòng', 11500000, '2020-11-15'),
('NV21430047', NULL, N'Võ Lan Phương', N'Nữ', '1993-12-12', '0912000047', 'volanphuong47@gmail.com', '079100000047', N'Đầu bếp Cao cấp Âu/ Ấn/ Lạnh', 17500000, '2021-02-20'),
('NV21430048', NULL, N'Đặng Hữu Phước', N'Nam', '1996-03-26', '0912000048', 'danghuuphuoc48@gmail.com', '079100000048', N'Đầu bếp Á/ Âu/ Ấn/Lạnh/ ALC/ Canteen', 16000000, '2022-05-10'),
('NV21430049', NULL, N'Bùi Thu Cúc', N'Nữ', '1998-07-09', '0912000049', 'buithucuc49@gmail.com', '079100000049', N'Nhân viên Đón tiếp/ Service Centre', 8500000, '2023-08-25'),
('NV21430050', NULL, N'Đỗ Thái Học', N'Nam', '2000-10-21', '0912000050', 'dothaihoc50@gmail.com', '079100000050', N'Nhân viên Phục vụ ALC/Buffet', 7500000, '2024-03-05'),

('NV21430051', NULL, N'Nguyễn Hồng Hoa', N'Nữ', '1994-01-02', '0912000051', 'nguyenhonghoa51@gmail.com', '079100000051', N'Nhân viên Kỹ thuật Bảo trì/ATAS', 10500000, '2022-12-12'),
('NV21430052', NULL, N'Trần Minh Khang', N'Nam', '1990-04-16', '0912000052', 'tranminhkhang52@gmail.com', '079100000052', N'Tổ trưởng Phục vụ', 12000000, '2021-07-28'),
('NV21430053', NULL, N'Lê Trúc Ly', N'Nữ', '1992-06-28', '0912000053', 'letrucly53@gmail.com', '079100000053', N'Tổ trưởng Kỹ thuật ME', 13500000, '2020-09-10'),
('NV21430054', NULL, N'Phạm Hoàng Long', N'Nam', '1995-10-10', '0912000054', 'phamhoanglong54@gmail.com', '079100000054', N'Chuyên viên Phục vụ Cao cấp', 11000000, '2022-01-20'),
('NV21430055', NULL, N'Hoàng Nguyệt Nga', N'Nữ', '1997-01-23', '0912000055', 'hoangnguyetnga55@gmail.com', '079100000055', N'Đầu bếp Cao cấp Âu/Bánh', 18000000, '2023-04-05'),
('NV21430056', NULL, N'Vũ Hữu Nghĩa', N'Nam', '1999-04-06', '0912000056', 'vuhuunghia56@gmail.com', '079100000056', N'Đầu bếp Âu/Lạnh', 15000000, '2024-02-18'),
('NV21430057', NULL, N'Võ Kim Oanh', N'Nữ', '1991-07-19', '0912000057', 'vokimoanh57@gmail.com', '079100000057', N'Nhân viên Tạp vụ', 6500000, '2020-10-30'),
('NV21430058', NULL, N'Đặng Thanh Phong', N'Nam', '1993-10-31', '0912000058', 'dangthanhphong58@gmail.com', '079100000058', N'Nhân viên Kỹ thuật', 9500000, '2021-12-15'),
('NV21430059', NULL, N'Bùi Thị Quyên', N'Nữ', '1996-02-12', '0912000059', 'buithiquyen59@gmail.com', '079100000059', N'Nhân viên Lễ tân/SC', 8500000, '2023-03-01'),
('NV21430060', NULL, N'Đỗ Thái Sơn', N'Nam', '1998-05-26', '0912000060', 'dothaison60@gmail.com', '079100000060', N'Nhân viên Hành lý', 7500000, '2022-06-14'),

('NV21430061', NULL, N'Nguyễn Thủy Tiên', N'Nữ', '2000-09-08', '0912000061', 'nguyenthuytien61@gmail.com', '079100000061', N'Nhân viên Đón tiếp Nhà hàng/Tiền sảnh', 8000000, '2023-11-20'),
('NV21430062', NULL, N'Trần Anh Tuấn', N'Nam', '1989-12-21', '0912000062', 'trananhtuan62@gmail.com', '079100000062', N'Nhân viên Pha chế (Rượu)', 10000000, '2019-05-10'),
('NV21430063', NULL, N'Lê Tú Uyên', N'Nữ', '1992-03-05', '0912000063', 'letuuyen63@gmail.com', '079100000063', N'Nhân viên Phục vụ (Buffet/Room)', 7000000, '2021-08-25'),
('NV21430064', NULL, N'Phạm Quang Vinh', N'Nam', '1994-06-17', '0912000064', 'phamquangvinh64@gmail.com', '079100000064', N'Nhân viên Giặt là (Ca đêm)', 8500000, '2022-10-05'),
('NV21430065', NULL, N'Hoàng Yến Vy', N'Nữ', '1996-09-29', '0912000065', 'hoangyenvy65@gmail.com', '079100000065', N'Nhân viên Bảo mẫu', 9000000, '2023-01-15'),
('NV21430066', NULL, N'Vũ Ngọc Anh', N'Nam', '1998-12-11', '0912000066', 'vungocanh66@gmail.com', '079100000066', N'Đội trưởng Kỹ thuật', 14000000, '2024-04-22'),
('NV21430067', NULL, N'Võ Mỹ Duyên', N'Nữ', '1990-03-25', '0912000067', 'vomyduyen67@gmail.com', '079100000067', N'Tổ trưởng Lễ tân - Thu ngân', 12500000, '2020-07-07'),
('NV21430068', NULL, N'Đặng Trọng Cảnh', N'Nam', '1993-07-08', '0912000068', 'dangtrongcanh68@gmail.com', '079100000068', N'Tổ trưởng Housekeeping', 11500000, '2021-09-18'),
('NV21430069', NULL, N'Bùi Hoài Thu', N'Nữ', '1995-10-20', '0912000069', 'buihoaithu69@gmail.com', '079100000069', N'Tổ trưởng Kỹ thuật BM/ME', 14500000, '2022-11-28'),
('NV21430070', NULL, N'Đỗ Chí Kiên', N'Nam', '1997-01-02', '0912000070', 'dochikien70@gmail.com', '079100000070', N'Tổ trưởng Bảo dưỡng cỏ & CQMT', 13000000, '2023-05-10'),

('NV21430071', NULL, N'Nguyễn Nhã Phương', N'Nữ', '1999-04-15', '0912000071', 'nguyennhaphuong71@gmail.com', '079100000071', N'Nhân viên Lễ tân - Thu ngân', 8500000, '2024-01-20'),
('NV21430072', NULL, N'Trần Công Lý', N'Nam', '1991-07-27', '0912000072', 'trancongly72@gmail.com', '079100000072', N'Nhân viên Bảo dưỡng cỏ', 7500000, '2021-12-05'),
('NV21430073', NULL, N'Lê Hồng Nhung', N'Nữ', '1993-10-09', '0912000073', 'lehongnhung73@gmail.com', '079100000073', N'Tổ trưởng Cứu hộ', 12000000, '2022-02-14'),
('NV21430074', NULL, N'Phạm Tiến Minh', N'Nam', '1996-01-22', '0912000074', 'phamtienminh74@gmail.com', '079100000074', N'Chuyên viên Kinh doanh', 15000000, '2023-06-25'),
('NV21430075', NULL, N'Hoàng Cẩm Tú', N'Nữ', '1998-04-05', '0912000075', 'hoangcamtu75@gmail.com', '079100000075', N'Nhân viên Housekeeping/Cây xanh', 7000000, '2023-09-09'),
('NV21430076', NULL, N'Vũ Đình Bảo', N'Nam', '2000-07-18', '0912000076', 'vudinhbao76@gmail.com', '079100000076', N'Nhân viên Hướng dẫn', 8000000, '2024-03-30'),
('NV21430077', NULL, N'Võ Diệp Thảo', N'Nữ', '1989-10-30', '0912000077', 'vodiepthao77@gmail.com', '079100000077', N'Nhân viên Cứu hộ', 8500000, '2020-01-10'),
('NV21430078', NULL, N'Đặng Gia Huy', N'Nam', '1992-02-12', '0912000078', 'danggiahuy78@gmail.com', '079100000078', N'TBP Tổ chức Sự kiện', 20000000, '2021-04-20'),
('NV21430079', NULL, N'Bùi Phương Trinh', N'Nữ', '1994-05-25', '0912000079', 'buiphuongtrinh79@gmail.com', '079100000079', N'Nhân viên Bán hàng', 7500000, '2022-08-15'),
('NV21430080', NULL, N'Đỗ Trọng Hiếu', N'Nam', '1996-08-07', '0912000080', 'dotronghieu80@gmail.com', '079100000080', N'Nhân viên Cây xanh', 7000000, '2023-11-11'),

('NV21430081', NULL, N'Nguyễn Thanh Trúc', N'Nữ', '1998-11-20', '0912000081', 'nguyenthanhtruc81@gmail.com', '079100000081', N'Tổ trưởng Kiểm soát cổng', 12000000, '2024-02-05'),
('NV21430082', NULL, N'Trần Minh Vương', N'Nam', '1990-02-01', '0912000082', 'tranminhvuong82@gmail.com', '079100000082', N'Chuyên viên Nhân sự(Quan hệ Lao động)', 14000000, '2020-06-18'),
('NV21430083', NULL, N'Lê Bích Ngọc', N'Nữ', '1992-05-14', '0912000083', 'lebichngoc83@gmail.com', '079100000083', N'Chuyên viên Hành chính (Kỹ thuật)', 13500000, '2021-10-22'),
('NV21430084', NULL, N'Phạm Tiến Luân', N'Nam', '1994-08-27', '0912000084', 'phamtienluan84@gmail.com', '079100000084', N'Nhân viên Chăm sóc Động vật Thuỷ cung', 9500000, '2022-12-08'),
('NV21430085', NULL, N'Hoàng Lan Hương', N'Nữ', '1997-12-09', '0912000085', 'hoanglanhuong85@gmail.com', '079100000085', N'Nhân viên Lễ tân Thu ngân', 8500000, '2023-04-14'),
('NV21430086', NULL, N'Vũ Hữu Phước', N'Nam', '1999-03-23', '0912000086', 'vuhuuphuoc86@gmail.com', '079100000086', N'Đầu bếp Cao cấp Á/Âu', 17000000, '2024-01-25'),
('NV21430087', NULL, N'Võ Thanh Tâm', N'Nữ', '1991-06-05', '0912000087', 'vothanhtam87@gmail.com', '079100000087', N'Đầu bếp Á/Âu', 14500000, '2020-09-09'),
('NV21430088', NULL, N'Đặng Quang Hải', N'Nam', '1993-09-17', '0912000088', 'dangquanghai88@gmail.com', '079100000088', N'Nhân viên Cứu hộ/ Thợ lặn', 10500000, '2021-11-20'),
('NV21430089', NULL, N'Bùi Tố Như', N'Nữ', '1995-12-30', '0912000089', 'buitonhu89@gmail.com', '079100000089', N'Nhân viên Phục vụ', 7000000, '2023-02-10'),
('NV21430090', NULL, N'Đỗ Thanh Tùng', N'Nam', '1998-04-12', '0912000090', 'dothanhtung90@gmail.com', '079100000090', N'Nhân viên Biểu diễn Động vật', 11000000, '2024-05-01'),

('NV21430091', NULL, N'Nguyễn Quỳnh Như', N'Nữ', '2000-07-25', '0912000091', 'nguyenquynhnhu91@gmail.com', '079100000091', N'Kỹ thuật viên Thú y', 12500000, '2023-08-18'),
('NV21430092', NULL, N'Trần Văn Đạt', N'Nam', '1989-10-07', '0912000092', 'tranvandat92@gmail.com', '079100000092', N'Đầu bếp Bếp Á', 13000000, '2019-12-22'),
('NV21430093', NULL, N'Lê Thu Hoài', N'Nữ', '1992-01-19', '0912000093', 'lethuhoai93@gmail.com', '079100000093', N'Tổ trưởng PA/ Buồng Phòng', 11500000, '2021-03-05'),
('NV21430094', NULL, N'Phạm Đăng Khoa', N'Nam', '1994-04-02', '0912000094', 'phamdangkhoa94@gmail.com', '079100000094', N'Nhân viên Đón tiếp/ Service Centre', 8500000, '2022-07-15'),
('NV21430095', NULL, N'Hoàng Mỹ Linh', N'Nữ', '1996-07-15', '0912000095', 'hoangmylinh95@gmail.com', '079100000095', N'Nhân viên Phục vụ ALC/Buffet', 7500000, '2023-10-28');
GO

-- ==========================================================
-- 3. DỮ LIỆU KHÁCH HÀNG (Cho màn hình tạo Hóa Đơn)
-- ==========================================================
INSERT INTO KhachHang (MaKhachHang, MaHang, HoTen, LoaiKhach, NgaySinh, DiaChi, SoDienThoai, Email, DiemTichLuy) VALUES
-- 3 Khách hàng cũ đã được chèn thêm 2 giá trị NULL cho (NgaySinh, DiaChi)
('KH01', 'HTV01', N'Khách Vãng Lai', N'Cá nhân', NULL, NULL, '0000000000', NULL, 0), 
('KH02', 'HTV02', N'Phạm Văn B', N'Cá nhân', NULL, NULL, '0933444555', 'vanb@gmail.com', 1200),
('KH03', 'HTV03', N'Đoàn Công Ty ABC', N'Khách đoàn', NULL, NULL, '0944555666', 'contact@abc.com', 5500),

-- 5 Khách hàng mới giữ nguyên
('KH04', 'HTV01', N'Hoàng Văn Hùng', N'Cá nhân', '1990-05-20', N'Quận 1, TP.HCM', '0901112223', 'hunghv@gmail.com', 500),
('KH05', 'HTV02', N'Trương Thu Hà', N'Cá nhân', '1988-11-11', N'Nha Trang, Khánh Hòa', '0982223334', 'hatruong@yahoo.com', 2500),
('KH06', 'HTV04', N'Trần Đại Gia', N'Cá nhân', '1970-01-01', N'Quận 7, TP.HCM', '0999999999', 'daigia@vip.com', 15000),
('KH07', 'HTV03', N'Trường THPT Lê Hồng Phong', N'Khách đoàn', NULL, N'Quận 5, TP.HCM', '0283838383', 'contact@lhp.edu.vn', 8000),
('KH08', 'HTV01', N'Công ty Du lịch Hạnh Phúc', N'Khách đoàn', NULL, N'Đà Nẵng', '0236123456', 'booking@hanhphuctravel.vn', 0);

-- ==========================================================
-- THÊM 45 KHÁCH HÀNG MỚI 
-- ==========================================================
INSERT INTO KhachHang (MaKhachHang, MaHang, HoTen, LoaiKhach, NgaySinh, DiaChi, SoDienThoai, Email, DiemTichLuy) VALUES
-- Khách cá nhân
('KH22570001', 'HTV01', N'Nguyễn Tuấn Anh', N'Cá nhân', '1995-10-20', N'Quận 1, TP.HCM', '0912000001', 'nguyentuananh1@gmail.com', 150),
('KH22570002', 'HTV02', N'Trần Thanh Bình', N'Cá nhân', '1998-05-12', N'Quận 3, TP.HCM', '0912000002', 'tranthanhbinh2@gmail.com', 1200),
('KH22570003', 'HTV01', N'Lê Thị Cẩm', N'Cá nhân', '2000-01-15', N'Tân Bình, TP.HCM', '0912000003', 'lethicam3@gmail.com', 300),
('KH22570004', 'HTV03', N'Phạm Minh Duy', N'Cá nhân', '1992-11-08', N'Đống Đa, Hà Nội', '0912000004', 'phamminhduy4@gmail.com', 5600),
('KH22570005', 'HTV04', N'Hoàng Thị Yến', N'Cá nhân', '1985-07-22', N'Hải Châu, Đà Nẵng', '0912000005', 'hoangthiyen5@gmail.com', 15000),
('KH22570006', 'HTV02', N'Vũ Hải Đăng', N'Cá nhân', '1997-03-30', N'Nha Trang, Khánh Hòa', '0912000006', 'vuhaidang6@gmail.com', 2100),
('KH22570007', 'HTV01', N'Võ Thị Ngọc', N'Cá nhân', '1999-09-09', N'Quận 10, TP.HCM', '0912000007', 'vothingoc7@gmail.com', 800),
('KH22570008', 'HTV01', N'Đặng Quốc Bảo', N'Cá nhân', '1994-12-12', N'Biên Hòa, Đồng Nai', '0912000008', 'dangquocbao8@gmail.com', 450),
('KH22570009', 'HTV03', N'Bùi Thanh Trúc', N'Cá nhân', '1991-04-18', N'Quận 7, TP.HCM', '0912000009', 'buithanhtruc9@gmail.com', 6200),
('KH22570010', 'HTV02', N'Đỗ Thái Hà', N'Cá nhân', '2001-08-25', N'Thủ Đức, TP.HCM', '0912000010', 'dothaiha10@gmail.com', 1800),
('KH22570011', 'HTV01', N'Nguyễn Hoàng Nam', N'Cá nhân', '1996-02-14', N'Cầu Giấy, Hà Nội', '0912000011', 'nguyenhoangnam11@gmail.com', 900),
('KH22570012', 'HTV04', N'Trần Ngọc Lan', N'Cá nhân', '1988-06-05', N'Quận 1, TP.HCM', '0912000012', 'tranngoclan12@gmail.com', 12500),
('KH22570013', 'HTV02', N'Lê Quang Phước', N'Cá nhân', '1993-10-19', N'Gò Vấp, TP.HCM', '0912000013', 'lequangphuoc13@gmail.com', 2700),
('KH22570014', 'HTV01', N'Phạm Thùy Linh', N'Cá nhân', '1995-12-25', N'Vũng Tàu', '0912000014', 'phamthuylinh14@gmail.com', 600),
('KH22570015', 'HTV03', N'Hoàng Văn Lộc', N'Cá nhân', '1990-04-30', N'Bình Thạnh, TP.HCM', '0912000015', 'hoangvanloc15@gmail.com', 7100),
('KH22570016', 'HTV01', N'Vũ Thu Phương', N'Cá nhân', '1998-08-15', N'Quận 4, TP.HCM', '0912000016', 'vuthuphuong16@gmail.com', 200),
('KH22570017', 'HTV02', N'Võ Đình Trọng', N'Cá nhân', '2000-01-20', N'Dĩ An, Bình Dương', '0912000017', 'vodinhtrong17@gmail.com', 1400),
('KH22570018', 'HTV01', N'Đặng Lan Anh', N'Cá nhân', '1994-05-12', N'Quận 5, TP.HCM', '0912000018', 'danglananh18@gmail.com', 850),
('KH22570019', 'HTV03', N'Bùi Tấn Phát', N'Cá nhân', '1996-09-05', N'Thanh Xuân, Hà Nội', '0912000019', 'buitanphat19@gmail.com', 8900),
('KH22570020', 'HTV01', N'Đỗ Minh Châu', N'Cá nhân', '1991-03-28', N'Sơn Trà, Đà Nẵng', '0912000020', 'dominhchau20@gmail.com', 400),
('KH22570021', 'HTV02', N'Nguyễn Thanh Tùng', N'Cá nhân', '1999-11-11', N'Quận 8, TP.HCM', '0912000021', 'nguyenthanhtung21@gmail.com', 2200),
('KH22570022', 'HTV04', N'Trần Gia Huy', N'Cá nhân', '1982-02-20', N'Quận 2, TP.HCM', '0912000022', 'trangiahuy22@gmail.com', 18000),
('KH22570023', 'HTV01', N'Lê Minh Tuấn', N'Cá nhân', '1997-07-07', N'Tân Phú, TP.HCM', '0912000023', 'leminhtuan23@gmail.com', 500),
('KH22570024', 'HTV03', N'Phạm Cẩm Tiên', N'Cá nhân', '1993-10-15', N'Hoàn Kiếm, Hà Nội', '0912000024', 'phamcamtien24@gmail.com', 5300),
('KH22570025', 'HTV02', N'Hoàng Trung Kiên', N'Cá nhân', '1995-12-01', N'Huế', '0912000025', 'hoangtrungkien25@gmail.com', 3100),
('KH22570026', 'HTV01', N'Vũ Ngọc Cảnh', N'Cá nhân', '1992-03-08', N'Quận 11, TP.HCM', '0912000026', 'vungoccanh26@gmail.com', 750),
('KH22570027', 'HTV01', N'Võ Hà My', N'Cá nhân', '2001-06-25', N'Bình Chánh, TP.HCM', '0912000027', 'vohamy27@gmail.com', 100),
('KH22570028', 'HTV04', N'Đặng Xuân Bách', N'Cá nhân', '1975-09-30', N'Quận 7, TP.HCM', '0912000028', 'dangxuanbach28@gmail.com', 21000),
('KH22570029', 'HTV02', N'Bùi Hoài Thu', N'Cá nhân', '1994-01-14', N'Hội An, Quảng Nam', '0912000029', 'buihoaithu29@gmail.com', 1100),
('KH22570030', 'HTV01', N'Đỗ Trọng Hiếu', N'Cá nhân', '1996-04-10', N'Phú Nhuận, TP.HCM', '0912000030', 'dotronghieu30@gmail.com', 950),

-- Khách đoàn (Công ty, Trường học, Tổ chức)
('KH22570031', 'HTV03', N'Công ty CP Đầu Tư Xây Dựng Bình Minh', N'Khách đoàn', NULL, N'Quận 1, TP.HCM', '0912000031', 'binhminhcorp31@gmail.com', 8500),
('KH22570032', 'HTV04', N'Ngân hàng Thương Mại Phương Đông', N'Khách đoàn', NULL, N'Quận 3, TP.HCM', '0912000032', 'phuongdongbank32@gmail.com', 16000),
('KH22570033', 'HTV02', N'Trường Đại học Bách Khoa', N'Khách đoàn', NULL, N'Quận 10, TP.HCM', '0912000033', 'bachkhoauni33@gmail.com', 4500),
('KH22570034', 'HTV01', N'Công ty TNHH Phần mềm Alpha', N'Khách đoàn', NULL, N'Tân Bình, TP.HCM', '0912000034', 'alphasoftware34@gmail.com', 800),
('KH22570035', 'HTV03', N'Trường THPT Chuyên Trần Đại Nghĩa', N'Khách đoàn', NULL, N'Quận 1, TP.HCM', '0912000035', 'trandainghiaschool35@gmail.com', 7200),
('KH22570036', 'HTV02', N'CLB Kỹ Năng Sống Trẻ', N'Khách đoàn', NULL, N'Đà Nẵng', '0912000036', 'kynangsongtre36@gmail.com', 2500),
('KH22570037', 'HTV04', N'Tập đoàn Bất Động Sản Vạn Xuân', N'Khách đoàn', NULL, N'Hà Nội', '0912000037', 'vanxuancorp37@gmail.com', 22000),
('KH22570038', 'HTV01', N'Trung tâm Anh Ngữ Apollo', N'Khách đoàn', NULL, N'Bình Thạnh, TP.HCM', '0912000038', 'apolloenglish38@gmail.com', 500),
('KH22570039', 'HTV03', N'Công ty CP Thực Phẩm Xanh', N'Khách đoàn', NULL, N'Cần Thơ', '0912000039', 'thucphamxanh39@gmail.com', 6100),
('KH22570040', 'HTV02', N'Đoàn Thanh Niên Phường 5', N'Khách đoàn', NULL, N'Quận 5, TP.HCM', '0912000040', 'doanthanhnienp540@gmail.com', 1900),
('KH22570041', 'HTV03', N'Công ty Du Lịch Vietravel', N'Khách đoàn', NULL, N'Quận 3, TP.HCM', '0912000041', 'vietravelbooking41@gmail.com', 9500),
('KH22570042', 'HTV01', N'Trường Mầm Non Hướng Dương', N'Khách đoàn', NULL, N'Gò Vấp, TP.HCM', '0912000042', 'mamnonhuongduong42@gmail.com', 300),
('KH22570043', 'HTV04', N'Công ty TNHH Điện Tử Samsung', N'Khách đoàn', NULL, N'Thủ Đức, TP.HCM', '0912000043', 'samsungvn43@gmail.com', 14000),
('KH22570044', 'HTV02', N'Hội Liên Hiệp Phụ Nữ Tỉnh Bình Dương', N'Khách đoàn', NULL, N'Bình Dương', '0912000044', 'hoiphunubd44@gmail.com', 3300),
('KH22570045', 'HTV01', N'CLB Cầu Lông Sài Gòn', N'Khách đoàn', NULL, N'Quận 10, TP.HCM', '0912000045', 'caulongsg45@gmail.com', 700);
GO

-- ==========================================================
-- 4. DỮ LIỆU LOẠI VÉ (Đúng theo góp ý của giáo viên)
-- ==========================================================
INSERT INTO LoaiVe (MaLoaiVe, TenLoaiVe, PhanLoai, GiaVe, BaoGomAnUong, MoTa) VALUES
('LV01', N'Vé Vào Cổng Người Lớn', N'Người lớn', 950000, 0, N'Dành cho khách hàng cao từ 140cm trở lên'),
('LV02', N'Vé Vào Cổng Trẻ Em', N'Trẻ em', 700000, 0, N'Dành cho khách hàng cao từ 100cm - 140cm'),
('LV03', N'Vé Vào Cổng Cao Tuổi', N'Người cao tuổi', 700000, 0, N'Dành cho khách hàng từ 60 tuổi trở lên');

-- ==========================================================
-- THÊM CÁC LOẠI VÉ VÀ COMBO MỚI TỪ HÌNH ẢNH (MÃ TỰ ĐỘNG THEO THỜI GIAN)
-- ==========================================================
INSERT INTO LoaiVe (MaLoaiVe, TenLoaiVe, PhanLoai, GiaVe, BaoGomAnUong, MoTa) VALUES
-- Các vé/combo kết hợp Safari (Ảnh 1)
('LV23150001', N'Combo VinWonders & Safari (Người lớn)', N'Combo', 1500000, 0, N'Dành cho khách cao từ 1,4m trở lên. Vui chơi tại 2 khu công viên.'),
('LV23150002', N'Combo VinWonders & Safari (Trẻ em)', N'Combo', 1100000, 0, N'Dành cho khách cao từ 1m đến 1,4m. Vui chơi tại 2 khu công viên.'),
('LV23150003', N'Combo VinWonders & Safari (Cao tuổi)', N'Combo', 1100000, 0, N'Dành cho khách hàng trên 60 tuổi. Vui chơi tại 2 khu công viên.'),

-- Trải nghiệm & Vé Nửa Ngày/Sau 16h
('LV23150004', N'Trải nghiệm làm "Nhân viên vườn thú nhí"', N'Trải nghiệm', 300000, 0, N'Bé hóa thân thành nhân viên sở thú nhí, chăm sóc tương tác động vật (1 tiếng)'),
('LV23150005', N'[Nửa ngày] Cáp treo + Tata Show + Xông hơi Aquafield (2 tiếng)', N'Combo', 400000, 0, N'Thư giãn Aquafield, thưởng thức Tata Show, di chuyển cáp treo 2 chiều'),
('LV23150006', N'Combo Happy Hour: Cáp treo + Buffet tối + Tata Show', N'Combo', 620000, 1, N'Cáp treo ngắm hoàng hôn, Buffet tối, Tata Show và 2 lượt VinBus'),
('LV23150007', N'Vé vào cửa sau 16h00', N'Người lớn', 700000, 0, N'Vé vào khu vui chơi sau 16h00, cáp treo 2 chiều, 2 lượt VinBus'),
('LV23150008', N'Sunset Combo: Vé vào cửa sau 16h + Buffet tối', N'Combo', 1000000, 1, N'Cáp treo ngắm hoàng hôn, vui chơi sau 16h, Buffet tối tại nhà hàng'),

-- Vé Tiêu Chuẩn & Có dịch vụ đi kèm
('LV23150009', N'Vé Vào Cửa Tiêu Chuẩn', N'Người lớn', 1050000, 0, N'Vé vào khu vui chơi 1 lần, cáp treo 2 chiều, 2 lượt VinBus'),
('LV23150010', N'Vé vào cửa + Xe điện Buggy | Tặng Kem', N'Combo', 1140000, 1, N'Vé vào cửa 1 lần, sử dụng xe điện nội khu, tặng 01 kem, 2 lượt VinBus'),
('LV23150011', N'Vé vào cửa + Fastpass Cáp Treo (01 chiều bờ - đảo)', N'Combo', 1150000, 0, N'Vé vào cửa 1 lần, ưu tiên lối đi cáp treo 1 chiều bờ ra đảo'),
('LV23150012', N'Combo Vé Vào Cửa + Voucher ẩm thực 250K', N'Combo', 1235000, 1, N'Vé vào cửa 1 lần, tặng voucher ẩm thực trị giá 250k, 2 lượt VinBus'),
('LV23150013', N'Vé vào cửa + Mũ Thú Xinh Xắn', N'Combo', 1290000, 0, N'Vé vào cửa 1 lần, cáp treo 2 chiều, tặng mũ thú xinh xắn'),

-- Vé Dài Ngày & Combo Cao Cấp
('LV23150014', N'Vé vào cửa 02 ngày ra vào không giới hạn', N'Người lớn', 1350000, 0, N'Vé vào khu vui chơi & cáp treo không giới hạn trong 2 ngày, 2 lượt VinBus/ngày'),
('LV23150015', N'Combo Vé vào cửa + Xông hơi chuẩn Hàn Aquafield không giới hạn', N'Combo', 1400000, 0, N'Cáp treo 2 chiều, xông hơi Aquafield không giới hạn, vui chơi cả ngày'),
('LV23150016', N'Combo Vé vào cửa + Cáp Treo + Dịch vụ Premium Buffet', N'Combo', 1450000, 1, N'Vé vào cửa 1 lần, cáp treo 2 chiều, Buffet set hải sản cao cấp'),
('LV23150017', N'Vé vào cửa + Buggy + Zipline (kèm fastpass ưu tiên)', N'Combo', 1500000, 0, N'Vé vào cửa 1 lần, trải nghiệm Zipline lối ưu tiên, sử dụng xe Buggy'),
('LV23150018', N'Vé vào cửa + Buggy + Fastpass 3 game hot', N'Combo', 1500000, 0, N'Vé vào cửa 1 lần, ưu tiên: Trượt núi, Tata River, Rạp phim bay, kèm xe Buggy'),
('LV23150019', N'Vé vào cửa 03 ngày ra vào không giới hạn', N'Người lớn', 1600000, 0, N'Vé vào khu vui chơi & cáp treo không giới hạn trong 3 ngày, 2 lượt VinBus/ngày'),
('LV23150020', N'Vé vào cửa + Cáp Treo + Premium Buffet + Xông hơi Aquafield', N'Combo', 1600000, 1, N'Vé vào cửa 1 lần, cáp treo 2 chiều, Buffet trưa cao cấp, xông hơi 2 tiếng'),
('LV23150021', N'[2 ngày] Vui chơi Công Viên x Đảo Hòn Tằm kèm Buffet Trưa', N'Combo', 1800000, 1, N'Công viên kỷ lục, bãi biển thiên đường & Buffet trưa, cano và cáp treo'),
('LV23150022', N'[02 Người Lớn] Combo Vé vào cửa + Xe điện Buggy + Kem | Tặng 01 Túi Tote', N'Gia đình', 2280000, 1, N'Combo 02 vé người lớn, dịch vụ xe Buggy, tặng Kem và 01 túi Tote');
GO

-- ==========================================================
-- 5. DỮ LIỆU TRÒ CHƠI & QUYỀN LỢI VÉ
-- ==========================================================
INSERT INTO TroChoi (MaTroChoi, MaKhuVuc, TenTroChoi, PhanLoai, ChieuCaoToiThieu, DoTuoiToiThieu, SucChua, TrangThai) VALUES
('TC01', 'KV01', N'Tàu Lượn Siêu Tốc', N'Cảm giác mạnh', 130, 14, 24, N'Đang hoạt động'),
('TC02', 'KV01', N'Đu Quay Dây Văng', N'Cảm giác mạnh', 120, 12, 30, N'Đang hoạt động'),
('TC03', 'KV02', N'Đường Trượt Lốc Xoáy', N'Trò chơi nước', 140, 14, 4, N'Đang hoạt động'),
('TC04', 'KV03', N'Vòng Quay Ngựa Gỗ', N'Trò chơi gia đình', 0, 3, 20, N'Đang hoạt động');

-- ==========================================================
-- THÊM 96 TRÒ CHƠI MỚI VÀO CÁC KHU VỰC
-- ==========================================================
INSERT INTO TroChoi (MaTroChoi, MaKhuVuc, TenTroChoi, PhanLoai, ChieuCaoToiThieu, DoTuoiToiThieu, SucChua, TrangThai) VALUES
-- Khu Vực 1: Cảm giác mạnh (32 trò)
('TC23220001', 'KV01', N'Cơn Thịnh Nộ Của Zeus', N'Cảm giác mạnh', 140, 14, 24, N'Đang hoạt động'),
('TC23220002', 'KV01', N'Tháp Rơi Tự Do 50m', N'Cảm giác mạnh', 130, 12, 16, N'Đang hoạt động'),
('TC23220003', 'KV01', N'Vòng Quay 360 Độ', N'Cảm giác mạnh', 140, 14, 20, N'Đang hoạt động'),
('TC23220004', 'KV01', N'Đĩa Bay Ma Thuật', N'Cảm giác mạnh', 130, 12, 30, N'Đang hoạt động'),
('TC23220005', 'KV01', N'Tàu Lượn Bóng Tối', N'Cảm giác mạnh', 130, 14, 24, N'Bảo trì'),
('TC23220006', 'KV01', N'Phi Long Thần Tốc', N'Cảm giác mạnh', 140, 15, 20, N'Đang hoạt động'),
('TC23220007', 'KV01', N'Mắt Đại Bàng', N'Cảm giác mạnh', 120, 10, 40, N'Đang hoạt động'),
('TC23220008', 'KV01', N'Vòng Xoáy Tử Thần', N'Cảm giác mạnh', 140, 15, 12, N'Đang hoạt động'),
('TC23220009', 'KV01', N'Cỗ Máy Thời Gian', N'Cảm giác mạnh', 130, 12, 24, N'Đang hoạt động'),
('TC23220010', 'KV01', N'Tàu Hải Tặc Khổng Lồ', N'Cảm giác mạnh', 120, 10, 50, N'Đang hoạt động'),
('TC23220011', 'KV01', N'Ván Trượt Không Gian', N'Cảm giác mạnh', 130, 12, 16, N'Đang hoạt động'),
('TC23220012', 'KV01', N'Bạch Tuộc Cuồng Nộ', N'Cảm giác mạnh', 120, 10, 32, N'Đang hoạt động'),
('TC23220013', 'KV01', N'Rơi Tự Do Không Trọng Lực', N'Cảm giác mạnh', 140, 14, 12, N'Đang hoạt động'),
('TC23220014', 'KV01', N'Bước Nhảy Không Gian', N'Cảm giác mạnh', 130, 12, 20, N'Bảo trì'),
('TC23220015', 'KV01', N'Thử Thách Trọng Lực', N'Cảm giác mạnh', 140, 15, 24, N'Đang hoạt động'),
('TC23220016', 'KV01', N'Cơn Lốc Sa Mạc', N'Cảm giác mạnh', 130, 12, 30, N'Đang hoạt động'),
('TC23220017', 'KV01', N'Tàu Vũ Trụ', N'Cảm giác mạnh', 120, 10, 40, N'Đang hoạt động'),
('TC23220018', 'KV01', N'Mũi Khoan Lõi Trái Đất', N'Cảm giác mạnh', 140, 14, 16, N'Đang hoạt động'),
('TC23220019', 'KV01', N'Cầu Treo Mạo Hiểm', N'Cảm giác mạnh', 120, 10, 10, N'Đang hoạt động'),
('TC23220020', 'KV01', N'Thung Lũng Khủng Long', N'Cảm giác mạnh', 110, 8, 50, N'Đang hoạt động'),
('TC23220021', 'KV01', N'Trượt Núi Alpine Coaster', N'Cảm giác mạnh', 130, 12, 2, N'Đang hoạt động'),
('TC23220022', 'KV01', N'Đu Quay Dây Văng Cực Đại', N'Cảm giác mạnh', 140, 14, 40, N'Đang hoạt động'),
('TC23220023', 'KV01', N'Mê Cung Kinh Hoàng', N'Cảm giác mạnh', 130, 15, 20, N'Đang hoạt động'),
('TC23220024', 'KV01', N'Zipline Xuyên Rừng', N'Cảm giác mạnh', 130, 12, 1, N'Đang hoạt động'),
('TC23220025', 'KV01', N'Cuồng Phong Xoáy', N'Cảm giác mạnh', 140, 14, 24, N'Bảo trì'),
('TC23220026', 'KV01', N'Sóng Thần Đổ Bộ', N'Cảm giác mạnh', 130, 12, 30, N'Đang hoạt động'),
('TC23220027', 'KV01', N'Vòng Quay Sinh Tử', N'Cảm giác mạnh', 140, 16, 12, N'Đang hoạt động'),
('TC23220028', 'KV01', N'Đua Xe Tốc Độ F1', N'Cảm giác mạnh', 140, 15, 8, N'Đang hoạt động'),
('TC23220029', 'KV01', N'Cú Lừa Ma Thuật', N'Cảm giác mạnh', 120, 10, 20, N'Đang hoạt động'),
('TC23220030', 'KV01', N'Tàu Cứu Hộ Mạo Hiểm', N'Cảm giác mạnh', 130, 12, 24, N'Đang hoạt động'),
('TC23220031', 'KV01', N'Phi Thuyền Mất Lái', N'Cảm giác mạnh', 140, 14, 16, N'Đang hoạt động'),
('TC23220032', 'KV01', N'Quả Lắc Khổng Lồ', N'Cảm giác mạnh', 130, 14, 30, N'Đang hoạt động'),

-- Khu Vực 2: Công viên nước (32 trò)
('TC23220033', 'KV02', N'Dòng Sông Lười', N'Trò chơi nước', 0, 0, 500, N'Đang hoạt động'),
('TC23220034', 'KV02', N'Bể Tạo Sóng Olymipic', N'Trò chơi nước', 0, 0, 1000, N'Đang hoạt động'),
('TC23220035', 'KV02', N'Ống Trượt Siêu Tốc', N'Trò chơi nước', 120, 10, 1, N'Đang hoạt động'),
('TC23220036', 'KV02', N'Sóng Thần Hawaii', N'Trò chơi nước', 130, 12, 4, N'Đang hoạt động'),
('TC23220037', 'KV02', N'Hố Đen Vũ Trụ', N'Trò chơi nước', 130, 12, 2, N'Bảo trì'),
('TC23220038', 'KV02', N'Đĩa Bay Nước', N'Trò chơi nước', 120, 10, 4, N'Đang hoạt động'),
('TC23220039', 'KV02', N'Bể Sục Jacuzzi', N'Trò chơi nước', 0, 0, 50, N'Đang hoạt động'),
('TC23220040', 'KV02', N'Đường Trượt Phao Đôi', N'Trò chơi nước', 110, 8, 2, N'Đang hoạt động'),
('TC23220041', 'KV02', N'Cơn Lốc Nhiệt Đới', N'Trò chơi nước', 120, 10, 4, N'Đang hoạt động'),
('TC23220042', 'KV02', N'Máng Trượt Boomerang', N'Trò chơi nước', 130, 12, 6, N'Đang hoạt động'),
('TC23220043', 'KV02', N'Vòi Rồng Biển Sâu', N'Trò chơi nước', 120, 10, 2, N'Đang hoạt động'),
('TC23220044', 'KV02', N'Hồ Bơi Vô Cực', N'Trò chơi nước', 0, 0, 200, N'Đang hoạt động'),
('TC23220045', 'KV02', N'Khu Vui Chơi Nước Trẻ Em', N'Trò chơi nước', 80, 3, 150, N'Đang hoạt động'),
('TC23220046', 'KV02', N'Đường Trượt 6 Làn', N'Trò chơi nước', 110, 8, 6, N'Đang hoạt động'),
('TC23220047', 'KV02', N'Ống Trượt Bóng Tối', N'Trò chơi nước', 120, 10, 1, N'Bảo trì'),
('TC23220048', 'KV02', N'Bể Bơi Massage', N'Trò chơi nước', 0, 12, 30, N'Đang hoạt động'),
('TC23220049', 'KV02', N'Vòng Xoáy Đại Dương', N'Trò chơi nước', 120, 10, 4, N'Đang hoạt động'),
('TC23220050', 'KV02', N'Trượt Nước Tự Do 90 Độ', N'Trò chơi nước', 140, 15, 1, N'Đang hoạt động'),
('TC23220051', 'KV02', N'Thác Nước Cầu Vồng', N'Trò chơi nước', 0, 0, 100, N'Đang hoạt động'),
('TC23220052', 'KV02', N'Hồ Bơi Kình Ngư', N'Trò chơi nước', 130, 12, 50, N'Đang hoạt động'),
('TC23220053', 'KV02', N'Sông Ngầm Thám Hiểm', N'Trò chơi nước', 100, 6, 20, N'Đang hoạt động'),
('TC23220054', 'KV02', N'Cuộc Đua Tốc Độ Nước', N'Trò chơi nước', 120, 10, 8, N'Đang hoạt động'),
('TC23220055', 'KV02', N'Đảo Hải Tặc Nhí', N'Trò chơi nước', 90, 4, 80, N'Đang hoạt động'),
('TC23220056', 'KV02', N'Pháo Đài Nước', N'Trò chơi nước', 100, 5, 60, N'Đang hoạt động'),
('TC23220057', 'KV02', N'Ống Trượt Xoắn Ốc', N'Trò chơi nước', 110, 8, 1, N'Bảo trì'),
('TC23220058', 'KV02', N'Mưa Nhân Tạo', N'Trò chơi nước', 0, 0, 100, N'Đang hoạt động'),
('TC23220059', 'KV02', N'Biển Chết Thu Nhỏ', N'Trò chơi nước', 0, 10, 40, N'Đang hoạt động'),
('TC23220060', 'KV02', N'Đường Trượt Mãng Xà', N'Trò chơi nước', 130, 12, 2, N'Đang hoạt động'),
('TC23220061', 'KV02', N'Bể Lặn San Hô', N'Trò chơi nước', 120, 12, 20, N'Đang hoạt động'),
('TC23220062', 'KV02', N'Đường Trượt Bạch Tuộc', N'Trò chơi nước', 100, 6, 8, N'Đang hoạt động'),
('TC23220063', 'KV02', N'Thung Lũng Nước Bí Ẩn', N'Trò chơi nước', 110, 8, 30, N'Đang hoạt động'),
('TC23220064', 'KV02', N'Trận Chiến Pháo Nước', N'Trò chơi nước', 90, 5, 40, N'Đang hoạt động'),

-- Khu Vực 3: Gia đình & Trẻ em (32 trò)
('TC23220065', 'KV03', N'Xe Đụng Gia Đình', N'Trò chơi gia đình', 100, 5, 30, N'Đang hoạt động'),
('TC23220066', 'KV03', N'Rạp Phim 4D', N'Trò chơi gia đình', 0, 3, 50, N'Đang hoạt động'),
('TC23220067', 'KV03', N'Tàu Hỏa Tham Quan', N'Trò chơi gia đình', 0, 0, 40, N'Đang hoạt động'),
('TC23220068', 'KV03', N'Vòng Quay Mặt Trời', N'Trò chơi gia đình', 0, 0, 200, N'Đang hoạt động'),
('TC23220069', 'KV03', N'Lâu Đài Phép Thuật', N'Trò chơi gia đình', 0, 2, 80, N'Bảo trì'),
('TC23220070', 'KV03', N'Nhà Banh Khổng Lồ', N'Trò chơi gia đình', 80, 2, 100, N'Đang hoạt động'),
('TC23220071', 'KV03', N'Tàu Cướp Biển Nhí', N'Trò chơi gia đình', 90, 4, 20, N'Đang hoạt động'),
('TC23220072', 'KV03', N'Đu Quay Khinh Khí Cầu', N'Trò chơi gia đình', 90, 4, 32, N'Đang hoạt động'),
('TC23220073', 'KV03', N'Lái Xe Mô Phỏng', N'Trò chơi gia đình', 100, 5, 10, N'Đang hoạt động'),
('TC23220074', 'KV03', N'Vườn Thú Tương Tác', N'Trò chơi gia đình', 0, 0, 150, N'Đang hoạt động'),
('TC23220075', 'KV03', N'Mê Cung Gương', N'Trò chơi gia đình', 0, 4, 40, N'Đang hoạt động'),
('TC23220076', 'KV03', N'Rạp Phim Bay Lơ Lửng', N'Trò chơi gia đình', 110, 6, 60, N'Đang hoạt động'),
('TC23220077', 'KV03', N'Thủy Cung Thu Nhỏ', N'Trò chơi gia đình', 0, 0, 200, N'Đang hoạt động'),
('TC23220078', 'KV03', N'Biểu Diễn Nàng Tiên Cá', N'Trò chơi gia đình', 0, 0, 300, N'Đang hoạt động'),
('TC23220079', 'KV03', N'Chuyến Tàu Tuổi Thơ', N'Trò chơi gia đình', 80, 3, 24, N'Bảo trì'),
('TC23220080', 'KV03', N'Phi Tiêu Trúng Thưởng', N'Trò chơi gia đình', 0, 5, 20, N'Đang hoạt động'),
('TC23220081', 'KV03', N'Câu Cá Thiếu Nhi', N'Trò chơi gia đình', 0, 3, 30, N'Đang hoạt động'),
('TC23220082', 'KV03', N'Đua Xe Mini Nhí', N'Trò chơi gia đình', 90, 4, 12, N'Đang hoạt động'),
('TC23220083', 'KV03', N'Lắp Ráp Lego Khổng Lồ', N'Trò chơi gia đình', 0, 2, 50, N'Đang hoạt động'),
('TC23220084', 'KV03', N'Ngôi Nhà Ma Ám (Kid)', N'Trò chơi gia đình', 100, 6, 20, N'Đang hoạt động'),
('TC23220085', 'KV03', N'Vườn Hoa Kỳ Diệu', N'Trò chơi gia đình', 0, 0, 200, N'Đang hoạt động'),
('TC23220086', 'KV03', N'Khu Rừng Bí Mật', N'Trò chơi gia đình', 0, 0, 100, N'Đang hoạt động'),
('TC23220087', 'KV03', N'Nhảy Trampoline', N'Trò chơi gia đình', 90, 4, 40, N'Đang hoạt động'),
('TC23220088', 'KV03', N'Thành Phố Nghề Nghiệp', N'Trò chơi gia đình', 100, 5, 80, N'Đang hoạt động'),
('TC23220089', 'KV03', N'Cốc Xoay Trà Chiều', N'Trò chơi gia đình', 90, 3, 24, N'Đang hoạt động'),
('TC23220090', 'KV03', N'Xích Đu Cổ Tích', N'Trò chơi gia đình', 0, 2, 16, N'Đang hoạt động'),
('TC23220091', 'KV03', N'Vẽ Tranh Cát Tương Tác', N'Trò chơi gia đình', 0, 3, 30, N'Bảo trì'),
('TC23220092', 'KV03', N'Cầu Trượt Ánh Sáng', N'Trò chơi gia đình', 90, 4, 15, N'Đang hoạt động'),
('TC23220093', 'KV03', N'Cuộc Đua Rùa & Thỏ', N'Trò chơi gia đình', 80, 3, 20, N'Đang hoạt động'),
('TC23220094', 'KV03', N'Khám Phá Rừng Amazon', N'Trò chơi gia đình', 100, 5, 40, N'Đang hoạt động'),
('TC23220095', 'KV03', N'Vòng Lặp Cầu Vồng', N'Trò chơi gia đình', 90, 4, 16, N'Đang hoạt động'),
('TC23220096', 'KV03', N'Tàu Lượn Gia Đình', N'Trò chơi gia đình', 110, 6, 20, N'Đang hoạt động');
GO

-- Áp dụng logic quyền lợi: Chỉ có LV02 và LV03 mới được chơi trò chơi
INSERT INTO QuyenLoiVe_TroChoi (MaLoaiVe, MaTroChoi) VALUES
('LV02', 'TC01'), ('LV02', 'TC02'), ('LV02', 'TC03'), ('LV02', 'TC04'), -- Trọn gói chơi hết
('LV03', 'TC01'), ('LV03', 'TC02'), ('LV03', 'TC03'), ('LV03', 'TC04'); -- Combo chơi hết
-- Lưu ý: Không Insert LV01 vào bảng này vì Vé Tham Quan không được chơi trò chơi.

-- ==========================================================
-- CẤP QUYỀN LỢI CHO LV02 VÀ LV03 (ĐƯỢC CHƠI TẤT CẢ 96 TRÒ NÀY)
-- ==========================================================
INSERT INTO QuyenLoiVe_TroChoi (MaLoaiVe, MaTroChoi) VALUES
-- Cấp quyền cho loại vé LV02 (Trẻ em - 96 trò)
('LV02', 'TC23220001'), ('LV02', 'TC23220002'), ('LV02', 'TC23220003'), ('LV02', 'TC23220004'),
('LV02', 'TC23220005'), ('LV02', 'TC23220006'), ('LV02', 'TC23220007'), ('LV02', 'TC23220008'),
('LV02', 'TC23220009'), ('LV02', 'TC23220010'), ('LV02', 'TC23220011'), ('LV02', 'TC23220012'),
('LV02', 'TC23220013'), ('LV02', 'TC23220014'), ('LV02', 'TC23220015'), ('LV02', 'TC23220016'),
('LV02', 'TC23220017'), ('LV02', 'TC23220018'), ('LV02', 'TC23220019'), ('LV02', 'TC23220020'),
('LV02', 'TC23220021'), ('LV02', 'TC23220022'), ('LV02', 'TC23220023'), ('LV02', 'TC23220024'),
('LV02', 'TC23220025'), ('LV02', 'TC23220026'), ('LV02', 'TC23220027'), ('LV02', 'TC23220028'),
('LV02', 'TC23220029'), ('LV02', 'TC23220030'), ('LV02', 'TC23220031'), ('LV02', 'TC23220032'),
('LV02', 'TC23220033'), ('LV02', 'TC23220034'), ('LV02', 'TC23220035'), ('LV02', 'TC23220036'),
('LV02', 'TC23220037'), ('LV02', 'TC23220038'), ('LV02', 'TC23220039'), ('LV02', 'TC23220040'),
('LV02', 'TC23220041'), ('LV02', 'TC23220042'), ('LV02', 'TC23220043'), ('LV02', 'TC23220044'),
('LV02', 'TC23220045'), ('LV02', 'TC23220046'), ('LV02', 'TC23220047'), ('LV02', 'TC23220048'),
('LV02', 'TC23220049'), ('LV02', 'TC23220050'), ('LV02', 'TC23220051'), ('LV02', 'TC23220052'),
('LV02', 'TC23220053'), ('LV02', 'TC23220054'), ('LV02', 'TC23220055'), ('LV02', 'TC23220056'),
('LV02', 'TC23220057'), ('LV02', 'TC23220058'), ('LV02', 'TC23220059'), ('LV02', 'TC23220060'),
('LV02', 'TC23220061'), ('LV02', 'TC23220062'), ('LV02', 'TC23220063'), ('LV02', 'TC23220064'),
('LV02', 'TC23220065'), ('LV02', 'TC23220066'), ('LV02', 'TC23220067'), ('LV02', 'TC23220068'),
('LV02', 'TC23220069'), ('LV02', 'TC23220070'), ('LV02', 'TC23220071'), ('LV02', 'TC23220072'),
('LV02', 'TC23220073'), ('LV02', 'TC23220074'), ('LV02', 'TC23220075'), ('LV02', 'TC23220076'),
('LV02', 'TC23220077'), ('LV02', 'TC23220078'), ('LV02', 'TC23220079'), ('LV02', 'TC23220080'),
('LV02', 'TC23220081'), ('LV02', 'TC23220082'), ('LV02', 'TC23220083'), ('LV02', 'TC23220084'),
('LV02', 'TC23220085'), ('LV02', 'TC23220086'), ('LV02', 'TC23220087'), ('LV02', 'TC23220088'),
('LV02', 'TC23220089'), ('LV02', 'TC23220090'), ('LV02', 'TC23220091'), ('LV02', 'TC23220092'),
('LV02', 'TC23220093'), ('LV02', 'TC23220094'), ('LV02', 'TC23220095'), ('LV02', 'TC23220096'),

-- Cấp quyền cho loại vé LV03 (Cao tuổi - 96 trò)
('LV03', 'TC23220001'), ('LV03', 'TC23220002'), ('LV03', 'TC23220003'), ('LV03', 'TC23220004'),
('LV03', 'TC23220005'), ('LV03', 'TC23220006'), ('LV03', 'TC23220007'), ('LV03', 'TC23220008'),
('LV03', 'TC23220009'), ('LV03', 'TC23220010'), ('LV03', 'TC23220011'), ('LV03', 'TC23220012'),
('LV03', 'TC23220013'), ('LV03', 'TC23220014'), ('LV03', 'TC23220015'), ('LV03', 'TC23220016'),
('LV03', 'TC23220017'), ('LV03', 'TC23220018'), ('LV03', 'TC23220019'), ('LV03', 'TC23220020'),
('LV03', 'TC23220021'), ('LV03', 'TC23220022'), ('LV03', 'TC23220023'), ('LV03', 'TC23220024'),
('LV03', 'TC23220025'), ('LV03', 'TC23220026'), ('LV03', 'TC23220027'), ('LV03', 'TC23220028'),
('LV03', 'TC23220029'), ('LV03', 'TC23220030'), ('LV03', 'TC23220031'), ('LV03', 'TC23220032'),
('LV03', 'TC23220033'), ('LV03', 'TC23220034'), ('LV03', 'TC23220035'), ('LV03', 'TC23220036'),
('LV03', 'TC23220037'), ('LV03', 'TC23220038'), ('LV03', 'TC23220039'), ('LV03', 'TC23220040'),
('LV03', 'TC23220041'), ('LV03', 'TC23220042'), ('LV03', 'TC23220043'), ('LV03', 'TC23220044'),
('LV03', 'TC23220045'), ('LV03', 'TC23220046'), ('LV03', 'TC23220047'), ('LV03', 'TC23220048'),
('LV03', 'TC23220049'), ('LV03', 'TC23220050'), ('LV03', 'TC23220051'), ('LV03', 'TC23220052'),
('LV03', 'TC23220053'), ('LV03', 'TC23220054'), ('LV03', 'TC23220055'), ('LV03', 'TC23220056'),
('LV03', 'TC23220057'), ('LV03', 'TC23220058'), ('LV03', 'TC23220059'), ('LV03', 'TC23220060'),
('LV03', 'TC23220061'), ('LV03', 'TC23220062'), ('LV03', 'TC23220063'), ('LV03', 'TC23220064'),
('LV03', 'TC23220065'), ('LV03', 'TC23220066'), ('LV03', 'TC23220067'), ('LV03', 'TC23220068'),
('LV03', 'TC23220069'), ('LV03', 'TC23220070'), ('LV03', 'TC23220071'), ('LV03', 'TC23220072'),
('LV03', 'TC23220073'), ('LV03', 'TC23220074'), ('LV03', 'TC23220075'), ('LV03', 'TC23220076'),
('LV03', 'TC23220077'), ('LV03', 'TC23220078'), ('LV03', 'TC23220079'), ('LV03', 'TC23220080'),
('LV03', 'TC23220081'), ('LV03', 'TC23220082'), ('LV03', 'TC23220083'), ('LV03', 'TC23220084'),
('LV03', 'TC23220085'), ('LV03', 'TC23220086'), ('LV03', 'TC23220087'), ('LV03', 'TC23220088'),
('LV03', 'TC23220089'), ('LV03', 'TC23220090'), ('LV03', 'TC23220091'), ('LV03', 'TC23220092'),
('LV03', 'TC23220093'), ('LV03', 'TC23220094'), ('LV03', 'TC23220095'), ('LV03', 'TC23220096');
GO

-- ==========================================================
-- 6. DỮ LIỆU DỊCH VỤ CỬA HÀNG & F&B (Món ăn, Nước uống)
-- ==========================================================
INSERT INTO CuaHang (MaCuaHang, MaKhuVuc, TenCuaHang, LoaiCuaHang, TrangThai) VALUES
('CH01', 'KV01', N'Quầy Fastfood Thần Tốc', N'Quầy Fastfood', N'Đang hoạt động'),
('CH02', 'KV03', N'Nhà Hàng Buffet Lâu Đài', N'Nhà hàng Buffet', N'Đang hoạt động'),
('CH03', 'KV02', N'Quầy Lưu Niệm Đại Dương', N'Quầy Lưu niệm', N'Đang hoạt động');

INSERT INTO SanPham (MaSanPham, MaCuaHang, TenSanPham, LoaiSanPham, GiaBan, TrangThaiBan) VALUES
('SP01', 'CH01', N'Combo Gà Rán Khoai Tây', N'Món chính', 95000, N'Còn hàng'),
('SP02', 'CH01', N'Nước Ngọt Cola Size L', N'Đồ uống', 35000, N'Còn hàng'),
('SP03', 'CH02', N'Buffet Trưa Người Lớn', N'Dịch vụ F&B', 350000, N'Còn hàng'),
('SP04', 'CH03', N'Gấu Bông VinWonders', N'Lưu niệm', 150000, N'Còn hàng'),
('SP05', 'CH01', N'Xúc Xích Nướng Đức', N'Ăn vặt', 45000, N'Hết hàng');

-- ==========================================================
-- 7. DỮ LIỆU MẪU HÓA ĐƠN & VÉ (Test hiển thị lên DataGridView)
-- ==========================================================
-- Hóa đơn 1: Bán cho khách vãng lai, mua 2 vé trọn gói
INSERT INTO HoaDonVe (MaHoaDon, MaKhachHang, MaNhanVien, TongTien, PhuongThucThanhToan, TrangThai) VALUES
('HDV001', 'KH01', 'NV02', 1700000, N'Tiền mặt', N'Đã thanh toán');

INSERT INTO Ve (MaVe, MaHoaDon, MaLoaiVe, DonGia, NgaySuDung, DaSuDung) VALUES
('V0001', 'HDV001', 'LV02', 850000, CAST(GETDATE() AS DATE), 0),
('V0002', 'HDV001', 'LV02', 850000, CAST(GETDATE() AS DATE), 0);

-- Hóa đơn 2: Bán cho khách đoàn, mua 5 vé Combo (Có chiết khấu 10% = 600k)
INSERT INTO HoaDonVe (MaHoaDon, MaKhachHang, MaNhanVien, ChietKhauDoan, TongTien, PhuongThucThanhToan, TrangThai) VALUES
('HDV002', 'KH03', 'NV02', 600000, 5400000, N'Chuyển khoản', N'Đã thanh toán');

INSERT INTO Ve (MaVe, MaHoaDon, MaLoaiVe, DonGia, NgaySuDung, DaSuDung) VALUES
('V0003', 'HDV002', 'LV03', 1200000, CAST(GETDATE() AS DATE), 1), -- Đã quét vé cổng
('V0004', 'HDV002', 'LV03', 1200000, CAST(GETDATE() AS DATE), 1),
('V0005', 'HDV002', 'LV03', 1200000, CAST(GETDATE() AS DATE), 0),
('V0006', 'HDV002', 'LV03', 1200000, CAST(GETDATE() AS DATE), 0),
('V0007', 'HDV002', 'LV03', 1200000, CAST(GETDATE() AS DATE), 0);

-- ==========================================================
-- SCRIPT TỰ ĐỘNG SINH 198 HÓA ĐƠN & VÉ (TỪ THÁNG 1 ĐẾN THÁNG 5)
-- Mã giả lập chuẩn theo định dạng C#: "HDV" + DateTime.Now.ToString("HHmmssff")
-- ==========================================================

DECLARE @Counter INT = 1;
DECLARE @MaHD VARCHAR(20), @MaVe VARCHAR(20);
DECLARE @KhachHang VARCHAR(20), @NhanVien VARCHAR(20), @LoaiVe VARCHAR(20);
DECLARE @Gia FLOAT;
DECLARE @PhuongThuc NVARCHAR(50);
DECLARE @RandomDate DATETIME;
DECLARE @DaSuDung BIT;

-- Bắt đầu vòng lặp tạo 498 bản ghi
WHILE @Counter <= 498
BEGIN
    -- 1. Random ngày từ 01/01/2026 đến 31/05/2026 (khoảng 151 ngày)
    SET @RandomDate = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 151, '2026-01-01');
    -- Random thêm Giờ, Phút, Giây để dữ liệu đa dạng hơn
    SET @RandomDate = DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % 86400, @RandomDate);
    -- Cộng thêm Counter vào Millisecond để đảm bảo đuôi 'ff' không bao giờ bị trùng
    SET @RandomDate = DATEADD(MILLISECOND, (ABS(CHECKSUM(NEWID())) % 900) + @Counter, @RandomDate);

    -- 2. Tạo mã Hóa đơn và mã Vé theo đúng thời gian Random ở trên
    SET @MaHD = 'HDV' + FORMAT(@RandomDate, 'HHmmssf');
    SET @MaVe = 'V' + FORMAT(@RandomDate, 'HHmmssff');

    -- 3. Lấy ngẫu nhiên 1 Khách Hàng (từ KH01 đến KH08)
    SET @KhachHang = 'KH0' + CAST((ABS(CHECKSUM(NEWID())) % 8) + 1 AS VARCHAR);

    -- 4. Lấy ngẫu nhiên 1 Nhân Viên (từ NV01 đến NV05)
    SET @NhanVien = 'NV0' + CAST((ABS(CHECKSUM(NEWID())) % 5) + 1 AS VARCHAR);

    -- 5. Lấy ngẫu nhiên Loại Vé & set Giá tiền tương ứng
    DECLARE @RandVe INT = ABS(CHECKSUM(NEWID())) % 4;
    IF @RandVe = 0 BEGIN SET @LoaiVe = 'LV01'; SET @Gia = 950000; END
    ELSE IF @RandVe = 1 BEGIN SET @LoaiVe = 'LV02'; SET @Gia = 700000; END
    ELSE IF @RandVe = 2 BEGIN SET @LoaiVe = 'LV03'; SET @Gia = 700000; END
    ELSE BEGIN SET @LoaiVe = 'LV23150009'; SET @Gia = 1050000; END -- Vé tiêu chuẩn mới tạo

    -- 6. Random Phương thức thanh toán
    SET @PhuongThuc = CHOOSE((ABS(CHECKSUM(NEWID())) % 3) + 1, N'Tiền mặt', N'Chuyển khoản', N'Thẻ tín dụng');

    -- 7. Random Trạng thái vé (1 = Đã sử dụng qua cổng, 0 = Chưa sử dụng)
    SET @DaSuDung = ABS(CHECKSUM(NEWID())) % 2;

    -- ================= THỰC THI INSERT ================= --

    -- Thêm vào bảng Hóa Đơn (Đã bổ sung biến @RandomDate cho cột NgayMua)
    INSERT INTO HoaDonVe (MaHoaDon, MaKhachHang, MaNhanVien, NgayMua, TongTien, PhuongThucThanhToan, TrangThai)
    VALUES (@MaHD, @KhachHang, @NhanVien, @RandomDate, @Gia, @PhuongThuc, N'Đã thanh toán');

    -- Thêm vào bảng Vé (Lấy phần Date của @RandomDate làm Ngày Sử Dụng)
    INSERT INTO Ve (MaVe, MaHoaDon, MaLoaiVe, DonGia, NgaySuDung, DaSuDung)
    VALUES (@MaVe, @MaHD, @LoaiVe, @Gia, CAST(@RandomDate AS DATE), @DaSuDung);

    -- Tăng biến đếm
    SET @Counter = @Counter + 1;
END;
GO

-- ==========================================================
-- 5. THÊM LỊCH LÀM VIỆC (Test giao diện DataGridView Lịch làm việc)
-- ==========================================================
-- Lưu ý: Bạn có thể đổi ngày '2026-05-25' thành ngày hiện tại để test dễ hơn
INSERT INTO LichLamViec (MaLich, MaNhanVien, MaCa, NgayLamViec, ViTriPhanCong) VALUES
('LLV001', 'NV02', 'CA01', '2026-05-25', N'Quầy vé Cổng chính'),
('LLV002', 'NV04', 'CA02', '2026-05-25', N'Quầy vé Cổng chính'),
('LLV003', 'NV05', 'CA04', '2026-05-25', N'Văn phòng Quản lý Khu 2'),
('LLV004', 'NV06', 'CA03', '2026-05-25', N'Tuần tra Cổng phụ'),
('LLV005', 'NV07', 'CA01', '2026-05-25', N'Vệ sinh khu nhà hàng'),
('LLV006', 'NV08', 'CA02', '2026-05-25', N'Trực Tàu lượn siêu tốc'),

('LLV007', 'NV02', 'CA02', '2026-05-26', N'Quầy vé Cổng chính'),
('LLV008', 'NV04', 'CA01', '2026-05-26', N'Quầy vé Cổng chính'),
('LLV009', 'NV08', 'CA01', '2026-05-26', N'Trực Đu quay dây văng'),

('LLV010', 'NV02', 'CA01', '2026-05-27', N'Quầy vé Cổng chính'),
('LLV011', 'NV06', 'CA04', '2026-05-28', N'Tuần tra Cổng chính'),
('LLV012', 'NV07', 'CA02', '2026-05-29', N'Vệ sinh khu vui chơi'),
('LLV013', 'NV08', 'CA02', '2026-05-30', N'Trực Tàu lượn siêu tốc'),
('LLV014', 'NV05', 'CA04', '2026-05-31', N'Giám sát chung');
GO

-- ==========================================================
-- 6. THÊM DỮ LIỆU BẢO TRÌ TRÒ CHƠI
-- ==========================================================
INSERT INTO BaoTriTroChoi (MaBaoTri, MaTroChoi, MaNhanVien, NgayBatDau, NgayDuKienXong, MoTaLoi, ChiPhiBaoTri, TrangThai) VALUES
('BT001', 'TC23220005', 'NV01', '2026-05-15', '2026-06-15', N'Bảo dưỡng định kỳ hệ thống ray trượt', 15000000, N'Đang kiểm tra'),
('BT002', 'TC23220014', 'NV02', '2026-05-20', '2026-06-05', N'Thay thế vòng bi và cáp treo', 8500000, N'Đang kiểm tra'),
('BT003', 'TC23220025', 'NV03', '2026-05-25', '2026-06-10', N'Kiểm tra và sửa chữa hệ thống phanh thủy lực', 12000000, N'Đang kiểm tra');
GO

-- ==========================================================
-- 7. XÓA BẢN GHI BẢO TRÌ (Mẫu Test Data Xóa Dữ Liệu Bảo Trì)
-- ==========================================================
-- DELETE FROM BaoTriTroChoi WHERE MaBaoTri = 'BT003';
-- GO

-- ==========================================================
-- 8. THÊM STORED PROCEDURE CHO BÁO CÁO CHI PHÍ BẢO TRÌ
-- ==========================================================
IF OBJECT_ID('sp_GetBaoTriTroChoiTheoNgay', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetBaoTriTroChoiTheoNgay;
GO

CREATE PROCEDURE sp_GetBaoTriTroChoiTheoNgay
    @TuNgay DATETIME,
    @DenNgay DATETIME
AS
BEGIN
    SELECT b.MaBaoTri, t.TenTroChoi, n.HoTen AS TenNhanVien, b.NgayBatDau, b.NgayDuKienXong, b.MoTaLoi, b.ChiPhiBaoTri, b.TrangThai
    FROM BaoTriTroChoi b
    JOIN TroChoi t ON b.MaTroChoi = t.MaTroChoi
    JOIN NhanVien n ON b.MaNhanVien = n.MaNhanVien
    WHERE b.NgayBatDau >= @TuNgay AND b.NgayBatDau <= @DenNgay
END
GO