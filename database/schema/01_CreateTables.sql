-- =============================================
-- Script tạo Database cho Hệ thống Quản lý THPT
-- =============================================

USE master;
GO

-- Tạo database nếu chưa tồn tại
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QLTHPT_DB')
BEGIN
    CREATE DATABASE QLTHPT_DB;
END
GO

USE QLTHPT_DB;
GO

-- =============================================
-- Bảng NamHoc - Quản lý năm học
-- =============================================
CREATE TABLE NamHoc (
    MaNamHoc INT PRIMARY KEY IDENTITY(1,1),
    TenNamHoc NVARCHAR(50) NOT NULL UNIQUE,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    HienHanh BIT DEFAULT 0,
    CONSTRAINT CHK_NamHoc_NgayHopLe CHECK (NgayKetThuc > NgayBatDau)
);
GO

-- =============================================
-- Bảng HocKy - Quản lý học kỳ
-- =============================================
CREATE TABLE HocKy (
    MaHK INT PRIMARY KEY IDENTITY(1,1),
    TenHK NVARCHAR(50) NOT NULL,
    Hky INT NOT NULL CHECK (Hky IN (1, 2)),
    MaNamHoc INT NOT NULL,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    CONSTRAINT FK_HocKy_NamHoc FOREIGN KEY (MaNamHoc) REFERENCES NamHoc(MaNamHoc),
    CONSTRAINT CHK_HocKy_NgayHopLe CHECK (NgayKetThuc > NgayBatDau)
);
GO

-- =============================================
-- Bảng GiaoVien - Quản lý thông tin giáo viên
-- =============================================
CREATE TABLE GiaoVien (
    MaGV INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    DiaChi NVARCHAR(200),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    CMND VARCHAR(20) UNIQUE,
    ChuyenMon NVARCHAR(100),
    TrinhDo NVARCHAR(50),
    NgayVaoLam DATE,
    ChucVu NVARCHAR(50),
    TrangThai NVARCHAR(50) DEFAULT N'Đang làm việc' CHECK (TrangThai IN (N'Đang làm việc', N'Đã nghỉ'))
);
GO

-- =============================================
-- Bảng LopHoc - Quản lý lớp học
-- =============================================
CREATE TABLE LopHoc (
    MaLop INT PRIMARY KEY IDENTITY(1,1),
    TenLop NVARCHAR(50) NOT NULL,
    Khoi INT NOT NULL CHECK (Khoi IN (10, 11, 12)),
    SiSo INT DEFAULT 0,
    MaGVCN INT,
    MaNamHoc INT NOT NULL,
    PhongHoc NVARCHAR(50),
    CONSTRAINT FK_LopHoc_GiaoVien FOREIGN KEY (MaGVCN) REFERENCES GiaoVien(MaGV),
    CONSTRAINT FK_LopHoc_NamHoc FOREIGN KEY (MaNamHoc) REFERENCES NamHoc(MaNamHoc),
    CONSTRAINT UQ_LopHoc_TenLop_NamHoc UNIQUE (TenLop, MaNamHoc)
);
GO

-- =============================================
-- Bảng HocSinh - Quản lý thông tin học sinh
-- =============================================
CREATE TABLE HocSinh (
    MaHS INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    DiaChi NVARCHAR(200),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    CMND VARCHAR(20) UNIQUE,
    DanToc NVARCHAR(50),
    TonGiao NVARCHAR(50),
    HoTenPhuHuynh NVARCHAR(100),
    SoDienThoaiPH VARCHAR(15),
    NgheNghiepPH NVARCHAR(100),
    MaLop INT,
    TrangThai NVARCHAR(50) DEFAULT N'Đang học' CHECK (TrangThai IN (N'Đang học', N'Đã tốt nghiệp', N'Thôi học', N'Bảo lưu')),
    NgayNhapHoc DATE,
    CONSTRAINT FK_HocSinh_LopHoc FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop)
);
GO

-- =============================================
-- Bảng MonHoc - Quản lý môn học
-- =============================================
CREATE TABLE MonHoc (
    MaMH INT PRIMARY KEY IDENTITY(1,1),
    TenMH NVARCHAR(100) NOT NULL UNIQUE,
    SoTiet INT NOT NULL,
    HeSo INT DEFAULT 1,
    LoaiMon NVARCHAR(50) CHECK (LoaiMon IN (N'Bắt buộc', N'Tự chọn')),
    Khoi INT CHECK (Khoi IN (0, 10, 11, 12)) -- 0: Áp dụng cho tất cả các khối
);
GO

-- =============================================
-- Bảng PhanCongGiangDay - Phân công giảng dạy
-- =============================================
CREATE TABLE PhanCongGiangDay (
    MaPC INT PRIMARY KEY IDENTITY(1,1),
    MaGV INT NOT NULL,
    MaMH INT NOT NULL,
    MaLop INT NOT NULL,
    MaHK INT NOT NULL,
    CONSTRAINT FK_PhanCong_GiaoVien FOREIGN KEY (MaGV) REFERENCES GiaoVien(MaGV),
    CONSTRAINT FK_PhanCong_MonHoc FOREIGN KEY (MaMH) REFERENCES MonHoc(MaMH),
    CONSTRAINT FK_PhanCong_LopHoc FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop),
    CONSTRAINT FK_PhanCong_HocKy FOREIGN KEY (MaHK) REFERENCES HocKy(MaHK),
    CONSTRAINT UQ_PhanCong UNIQUE (MaGV, MaMH, MaLop, MaHK)
);
GO

-- =============================================
-- Bảng Diem - Quản lý điểm số
-- =============================================
CREATE TABLE Diem (
    MaDiem INT PRIMARY KEY IDENTITY(1,1),
    MaHS INT NOT NULL,
    MaMH INT NOT NULL,
    MaHK INT NOT NULL,
    DiemMieng DECIMAL(3,1) CHECK (DiemMieng >= 0 AND DiemMieng <= 10),
    Diem15Phut DECIMAL(3,1) CHECK (Diem15Phut >= 0 AND Diem15Phut <= 10),
    Diem1Tiet DECIMAL(3,1) CHECK (Diem1Tiet >= 0 AND Diem1Tiet <= 10),
    DiemGiuaKy DECIMAL(3,1) CHECK (DiemGiuaKy >= 0 AND DiemGiuaKy <= 10),
    DiemCuoiKy DECIMAL(3,1) CHECK (DiemCuoiKy >= 0 AND DiemCuoiKy <= 10),
    DiemTrungBinh DECIMAL(3,1) CHECK (DiemTrungBinh >= 0 AND DiemTrungBinh <= 10),
    CONSTRAINT FK_Diem_HocSinh FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS),
    CONSTRAINT FK_Diem_MonHoc FOREIGN KEY (MaMH) REFERENCES MonHoc(MaMH),
    CONSTRAINT FK_Diem_HocKy FOREIGN KEY (MaHK) REFERENCES HocKy(MaHK),
    CONSTRAINT UQ_Diem UNIQUE (MaHS, MaMH, MaHK)
);
GO

-- =============================================
-- Tạo Index để tối ưu truy vấn
-- =============================================
CREATE INDEX IX_HocSinh_MaLop ON HocSinh(MaLop);
CREATE INDEX IX_HocSinh_TrangThai ON HocSinh(TrangThai);
CREATE INDEX IX_Diem_MaHS ON Diem(MaHS);
CREATE INDEX IX_Diem_MaMH ON Diem(MaMH);
CREATE INDEX IX_Diem_MaHK ON Diem(MaHK);
CREATE INDEX IX_PhanCongGiangDay_MaGV ON PhanCongGiangDay(MaGV);
CREATE INDEX IX_PhanCongGiangDay_MaLop ON PhanCongGiangDay(MaLop);
GO

PRINT 'Database schema created successfully!';
