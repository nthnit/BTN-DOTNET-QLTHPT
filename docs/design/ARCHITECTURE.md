# Tài liệu Thiết kế Hệ thống QLTHPT

## 1. Tổng quan kiến trúc

### 1.1. Kiến trúc tổng thể
Hệ thống được thiết kế theo mô hình 3 tầng (3-tier architecture):

- **Presentation Layer (UI)**: Tầng giao diện người dùng sử dụng Windows Forms
- **Business Logic Layer (BLL)**: Tầng xử lý logic nghiệp vụ
- **Data Access Layer (DAL)**: Tầng truy cập dữ liệu

### 1.2. Các thành phần chính

#### QLTHPT.Models
Chứa các entity classes, DTOs và ViewModels:
- **Entities**: Các class ánh xạ trực tiếp với bảng trong database
- **DTOs**: Data Transfer Objects để truyền dữ liệu giữa các tầng
- **ViewModels**: Models dành cho UI layer

#### QLTHPT.DAL
Chứa logic truy cập dữ liệu:
- **DbContext**: Quản lý kết nối database
- **Repositories**: Implement Repository Pattern cho từng entity

#### QLTHPT.BLL
Chứa business logic:
- Validation dữ liệu
- Tính toán điểm trung bình
- Xếp loại học lực
- Logic nghiệp vụ phức tạp

#### QLTHPT.UI
Giao diện người dùng:
- **Forms**: Các form chính của ứng dụng
- **Controls**: User controls tùy chỉnh
- **Utils**: Các class tiện ích

## 2. Thiết kế Database

### 2.1. Các bảng chính

#### NamHoc
Quản lý năm học (2023-2024, 2024-2025...)

#### HocKy
Quản lý học kỳ trong năm học (HK1, HK2)

#### GiaoVien
Quản lý thông tin giáo viên

#### LopHoc
Quản lý lớp học (10A1, 11B2...)

#### HocSinh
Quản lý thông tin học sinh

#### MonHoc
Quản lý các môn học (Toán, Lý, Hóa...)

#### Diem
Quản lý điểm số của học sinh

#### PhanCongGiangDay
Quản lý phân công giảng dạy

### 2.2. Mối quan hệ

```
NamHoc (1) ----< (n) HocKy
NamHoc (1) ----< (n) LopHoc
GiaoVien (1) ----< (n) LopHoc (Chủ nhiệm)
GiaoVien (1) ----< (n) PhanCongGiangDay
LopHoc (1) ----< (n) HocSinh
LopHoc (1) ----< (n) PhanCongGiangDay
MonHoc (1) ----< (n) PhanCongGiangDay
MonHoc (1) ----< (n) Diem
HocSinh (1) ----< (n) Diem
HocKy (1) ----< (n) Diem
HocKy (1) ----< (n) PhanCongGiangDay
```

## 3. Quy tắc nghiệp vụ

### 3.1. Quản lý điểm
- Điểm miệng, 15 phút, 1 tiết, giữa kỳ, cuối kỳ: 0-10
- Điểm trung bình môn = (ΣĐiểm miệng + 2×ΣĐiểm 15p + 3×ΣĐiểm 1 tiết + 3×Điểm giữa kỳ + 3×Điểm cuối kỳ) / Tổng hệ số
- Điểm trung bình học kỳ = Tổng (Điểm TB môn × Hệ số môn) / Tổng hệ số

### 3.2. Xếp loại học lực
- Giỏi: Điểm TB >= 8.0 và không có môn nào < 6.5
- Khá: Điểm TB >= 6.5 và không có môn nào < 5.0
- Trung bình: Điểm TB >= 5.0 và không có môn nào < 3.5
- Yếu: Điểm TB < 5.0 hoặc có môn < 3.5

### 3.3. Quy định khác
- Mỗi lớp có tối đa 45 học sinh
- Mỗi giáo viên chỉ làm chủ nhiệm 1 lớp/năm học
- Học sinh phải có đủ điểm các môn mới được lên lớp

## 4. Các pattern được sử dụng

### 4.1. Repository Pattern
Tách biệt logic truy cập dữ liệu khỏi business logic

### 4.2. DTO Pattern
Truyền dữ liệu giữa các tầng một cách hiệu quả

### 4.3. Factory Pattern (optional)
Tạo các đối tượng phức tạp

## 5. Security

### 5.1. Bảo mật dữ liệu
- Sử dụng Parameterized Queries để tránh SQL Injection
- Mã hóa password (nếu có chức năng đăng nhập)
- Phân quyền theo vai trò (Admin, Giáo viên, Học sinh)

### 5.2. Validation
- Validate dữ liệu ở cả UI và BLL layer
- Kiểm tra ràng buộc toàn vẹn dữ liệu

## 6. Performance

### 6.1. Indexing
- Index các khóa ngoại
- Index các cột thường xuyên được query

### 6.2. Caching (optional)
- Cache dữ liệu tham chiếu (danh sách môn học, năm học...)

## 7. Mở rộng tương lai

- Thêm module quản lý tài chính (học phí)
- Module quản lý thư viện
- Module quản lý thời khóa biểu
- Tích hợp với hệ thống phụ huynh online
- Mobile app cho phụ huynh và học sinh
