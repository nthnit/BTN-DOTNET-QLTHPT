-- =============================================
-- Dữ liệu mẫu cho Hệ thống Quản lý THPT
-- =============================================

USE QLTHPT_DB;
GO

-- =============================================
-- Thêm Năm học
-- =============================================
INSERT INTO NamHoc (TenNamHoc, NgayBatDau, NgayKetThuc, HienHanh) VALUES
(N'2023-2024', '2023-09-01', '2024-06-30', 1),
(N'2024-2025', '2024-09-01', '2025-06-30', 0);
GO

-- =============================================
-- Thêm Học kỳ
-- =============================================
INSERT INTO HocKy (TenHK, Hky, MaNamHoc, NgayBatDau, NgayKetThuc) VALUES
(N'Học kỳ 1 năm học 2023-2024', 1, 1, '2023-09-01', '2024-01-15'),
(N'Học kỳ 2 năm học 2023-2024', 2, 1, '2024-01-16', '2024-06-30'),
(N'Học kỳ 1 năm học 2024-2025', 1, 2, '2024-09-01', '2025-01-15'),
(N'Học kỳ 2 năm học 2024-2025', 2, 2, '2025-01-16', '2025-06-30');
GO

-- =============================================
-- Thêm Môn học
-- =============================================
INSERT INTO MonHoc (TenMH, SoTiet, HeSo, LoaiMon, Khoi) VALUES
(N'Toán', 105, 2, N'Bắt buộc', 0),
(N'Ngữ văn', 105, 2, N'Bắt buộc', 0),
(N'Tiếng Anh', 105, 2, N'Bắt buộc', 0),
(N'Vật lý', 70, 1, N'Bắt buộc', 0),
(N'Hóa học', 70, 1, N'Bắt buộc', 0),
(N'Sinh học', 70, 1, N'Bắt buộc', 0),
(N'Lịch sử', 70, 1, N'Bắt buộc', 0),
(N'Địa lý', 70, 1, N'Bắt buộc', 0),
(N'Giáo dục công dân', 35, 1, N'Bắt buộc', 0),
(N'Công nghệ', 35, 1, N'Bắt buộc', 0),
(N'Tin học', 35, 1, N'Bắt buộc', 0),
(N'Thể dục', 70, 1, N'Bắt buộc', 0);
GO

-- =============================================
-- Thêm Giáo viên
-- =============================================
INSERT INTO GiaoVien (HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, CMND, ChuyenMon, TrinhDo, NgayVaoLam, ChucVu, TrangThai) VALUES
(N'Nguyễn Văn An', '1980-05-15', N'Nam', N'Hà Nội', '0912345678', 'nguyenvanan@email.com', '001234567890', N'Toán học', N'Thạc sĩ', '2005-09-01', N'Giáo viên', N'Đang làm việc'),
(N'Trần Thị Bình', '1982-08-20', N'Nữ', N'Hà Nội', '0912345679', 'tranthibinh@email.com', '001234567891', N'Ngữ văn', N'Thạc sĩ', '2006-09-01', N'Giáo viên', N'Đang làm việc'),
(N'Lê Văn Cường', '1979-03-10', N'Nam', N'Hà Nội', '0912345680', 'levancuong@email.com', '001234567892', N'Tiếng Anh', N'Cử nhân', '2004-09-01', N'Tổ trưởng', N'Đang làm việc'),
(N'Phạm Thị Dung', '1985-11-25', N'Nữ', N'Hà Nội', '0912345681', 'phamthidung@email.com', '001234567893', N'Vật lý', N'Thạc sĩ', '2008-09-01', N'Giáo viên', N'Đang làm việc'),
(N'Hoàng Văn Em', '1983-07-30', N'Nam', N'Hà Nội', '0912345682', 'hoangvanem@email.com', '001234567894', N'Hóa học', N'Cử nhân', '2007-09-01', N'Giáo viên', N'Đang làm việc');
GO

-- =============================================
-- Thêm Lớp học
-- =============================================
INSERT INTO LopHoc (TenLop, Khoi, SiSo, MaGVCN, MaNamHoc, PhongHoc) VALUES
(N'10A1', 10, 40, 1, 1, N'A101'),
(N'10A2', 10, 38, 2, 1, N'A102'),
(N'11A1', 11, 35, 3, 1, N'A201'),
(N'11A2', 11, 37, 4, 1, N'A202'),
(N'12A1', 12, 33, 5, 1, N'A301'),
(N'12A2', 12, 36, 1, 1, N'A302');
GO

-- =============================================
-- Thêm Học sinh (Mẫu cho lớp 10A1)
-- =============================================
INSERT INTO HocSinh (HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, DanToc, TonGiao, HoTenPhuHuynh, SoDienThoaiPH, NgheNghiepPH, MaLop, TrangThai, NgayNhapHoc) VALUES
(N'Nguyễn Thị Anh', '2008-01-15', N'Nữ', N'Hà Nội', '0987654321', 'nguyenthianh@email.com', N'Kinh', N'Không', N'Nguyễn Văn A', '0912111111', N'Công nhân', 1, N'Đang học', '2023-09-01'),
(N'Trần Văn Bình', '2008-03-20', N'Nam', N'Hà Nội', '0987654322', 'tranvanbinh@email.com', N'Kinh', N'Không', N'Trần Văn B', '0912111112', N'Nông dân', 1, N'Đang học', '2023-09-01'),
(N'Lê Thị Cúc', '2008-05-10', N'Nữ', N'Hà Nội', '0987654323', 'lethicuc@email.com', N'Kinh', N'Phật giáo', N'Lê Văn C', '0912111113', N'Giáo viên', 1, N'Đang học', '2023-09-01'),
(N'Phạm Văn Dũng', '2008-07-25', N'Nam', N'Hà Nội', '0987654324', 'phamvandung@email.com', N'Kinh', N'Không', N'Phạm Văn D', '0912111114', N'Kinh doanh', 1, N'Đang học', '2023-09-01'),
(N'Hoàng Thị Em', '2008-09-30', N'Nữ', N'Hà Nội', '0987654325', 'hoangthiem@email.com', N'Kinh', N'Công giáo', N'Hoàng Văn E', '0912111115', N'Bác sĩ', 1, N'Đang học', '2023-09-01');
GO

PRINT 'Sample data inserted successfully!';
