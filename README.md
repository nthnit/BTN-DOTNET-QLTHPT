# Hệ thống Quản lý Trường Trung học Phổ thông (QLTHPT)

Bài tập nhóm học phần Lập trình .NET - Hệ thống quản lý trường THPT tại Việt Nam

## 📋 Giới thiệu

Hệ thống Quản lý Trường Trung học Phổ thông là một ứng dụng Windows Forms được phát triển bằng C# (.NET Framework) nhằm hỗ trợ quản lý các hoạt động chính của một trường THPT tại Việt Nam.

## 🎯 Tính năng chính

### 1. Quản lý Học sinh
- Thêm, sửa, xóa thông tin học sinh
- Tìm kiếm và lọc học sinh theo nhiều tiêu chí
- Quản lý hồ sơ học sinh (thông tin cá nhân, gia đình, liên hệ)
- Chuyển lớp, chuyển trường

### 2. Quản lý Giáo viên
- Quản lý thông tin giáo viên
- Phân công giảng dạy môn học
- Quản lý chủ nhiệm lớp
- Lịch sử công tác

### 3. Quản lý Lớp học
- Tạo và quản lý danh sách lớp học
- Phân bổ học sinh vào lớp
- Quản lý sĩ số lớp
- Thông tin giáo viên chủ nhiệm

### 4. Quản lý Môn học
- Danh sách môn học theo khối lớp
- Hệ số điểm môn học
- Phân loại môn học (Bắt buộc, Tự chọn)

### 5. Quản lý Điểm
- Nhập điểm: Miệng, 15 phút, 1 tiết, Học kỳ
- Tính điểm trung bình môn, học kỳ, năm học
- Xếp loại học lực

### 6. Quản lý Học kỳ/Năm học
- Tạo và quản lý học kỳ, năm học
- Cấu hình thời gian học kỳ

### 7. Báo cáo & Thống kê
- Báo cáo kết quả học tập theo lớp, khối
- Thống kê học sinh giỏi, khá, trung bình, yếu
- Báo cáo tổng kết học kỳ, năm học
- Xuất file Excel, PDF

## 🏗️ Kiến trúc hệ thống

Dự án được tổ chức theo mô hình 3 tầng (3-tier architecture):

```
QLTHPT/
│
├── src/
│   ├── QLTHPT.UI/              # Presentation Layer (Windows Forms)
│   │   ├── Forms/              # Các form giao diện
│   │   │   ├── HocSinh/        # Forms quản lý học sinh
│   │   │   ├── GiaoVien/       # Forms quản lý giáo viên
│   │   │   ├── LopHoc/         # Forms quản lý lớp học
│   │   │   ├── MonHoc/         # Forms quản lý môn học
│   │   │   ├── Diem/           # Forms quản lý điểm
│   │   │   ├── HocKy/          # Forms quản lý học kỳ
│   │   │   ├── KetQua/         # Forms xem kết quả
│   │   │   └── BaoCao/         # Forms báo cáo
│   │   ├── Controls/           # User controls tùy chỉnh
│   │   ├── Utils/              # Các class tiện ích UI
│   │   └── Resources/          # Hình ảnh, icons, tài nguyên
│   │
│   ├── QLTHPT.BLL/             # Business Logic Layer
│   │   ├── HocSinh/            # Business logic học sinh
│   │   ├── GiaoVien/           # Business logic giáo viên
│   │   ├── LopHoc/             # Business logic lớp học
│   │   ├── MonHoc/             # Business logic môn học
│   │   ├── Diem/               # Business logic điểm
│   │   └── HocKy/              # Business logic học kỳ
│   │
│   ├── QLTHPT.DAL/             # Data Access Layer
│   │   ├── Repositories/       # Repository pattern
│   │   └── DbContext/          # Database context
│   │
│   └── QLTHPT.Models/          # Data Models
│       ├── Entities/           # Entity classes (ánh xạ DB)
│       ├── DTOs/               # Data Transfer Objects
│       └── ViewModels/         # ViewModels cho UI
│
├── database/
│   ├── schema/                 # Database schema scripts
│   ├── stored-procedures/      # Stored procedures
│   └── sample-data/            # Dữ liệu mẫu
│
├── docs/
│   ├── design/                 # Tài liệu thiết kế
│   ├── user-guide/             # Hướng dẫn sử dụng
│   └── api/                    # Tài liệu API (nếu có)
│
└── tests/                      # Unit tests và Integration tests
```

## 🔧 Công nghệ sử dụng

- **Framework**: .NET Framework 4.7.2 hoặc cao hơn
- **UI**: Windows Forms
- **Database**: SQL Server (hoặc SQL Server Express)
- **ORM**: ADO.NET hoặc Entity Framework
- **Báo cáo**: Crystal Reports hoặc ReportViewer

## 📦 Yêu cầu hệ thống

### Yêu cầu phát triển
- Visual Studio 2019/2022
- .NET Framework 4.7.2 SDK trở lên
- SQL Server 2016 trở lên (hoặc SQL Server Express)
- Windows 10/11

### Yêu cầu triển khai
- .NET Framework 4.7.2 Runtime
- SQL Server hoặc SQL Server Express
- Windows 7 trở lên

## 🚀 Hướng dẫn cài đặt

### 1. Clone repository
```bash
git clone https://github.com/nthnit/BTN-DOTNET-QLTHPT.git
cd BTN-DOTNET-QLTHPT
```

### 2. Cấu hình Database
- Tạo database mới trong SQL Server
- Chạy script tạo schema trong thư mục `database/schema/`
- (Tùy chọn) Chạy script dữ liệu mẫu trong `database/sample-data/`

### 3. Cấu hình Connection String
- Mở file `src/QLTHPT.UI/App.config`
- Cập nhật connection string với thông tin SQL Server của bạn:
```xml
<connectionStrings>
  <add name="QLTHPTConnection" 
       connectionString="Data Source=YOUR_SERVER;Initial Catalog=QLTHPT_DB;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4. Build và chạy
- Mở file `QLTHPT.sln` trong Visual Studio
- Build solution (Ctrl + Shift + B)
- Chạy project QLTHPT.UI (F5)

## 👥 Nhóm phát triển

- Thành viên 1: [Tên] - [Vai trò]
- Thành viên 2: [Tên] - [Vai trò]
- Thành viên 3: [Tên] - [Vai trò]

## 📝 License

Dự án này được phát triển cho mục đích học tập tại [Tên trường].

## 📞 Liên hệ

- Email: [Email liên hệ]
- GitHub: https://github.com/nthnit/BTN-DOTNET-QLTHPT
