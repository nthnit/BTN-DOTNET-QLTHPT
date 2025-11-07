# Database Scripts

Thư mục này chứa tất cả các scripts SQL cho database.

## Cấu trúc

### schema/
Scripts tạo cấu trúc database:
- `01_CreateTables.sql` - Tạo tất cả các bảng
- `02_CreateViews.sql` - Tạo views (nếu cần)
- `03_CreateStoredProcedures.sql` - Tạo stored procedures
- `04_CreateTriggers.sql` - Tạo triggers (nếu cần)

### sample-data/
Scripts chứa dữ liệu mẫu để test:
- `01_InsertSampleData.sql` - Dữ liệu mẫu cơ bản

### stored-procedures/
Stored procedures riêng lẻ (tùy chọn):
- Có thể tách các stored procedures phức tạp vào các file riêng

## Hướng dẫn sử dụng

### 1. Tạo Database mới
```sql
-- Chạy trong SQL Server Management Studio
USE master;
CREATE DATABASE QLTHPT_DB;
```

### 2. Chạy Scripts theo thứ tự
```
1. schema/01_CreateTables.sql
2. schema/02_CreateViews.sql (nếu có)
3. schema/03_CreateStoredProcedures.sql (nếu có)
4. sample-data/01_InsertSampleData.sql (optional)
```

### 3. Kiểm tra
```sql
USE QLTHPT_DB;
SELECT * FROM NamHoc;
SELECT * FROM HocKy;
SELECT * FROM GiaoVien;
```

## Lưu ý

- Luôn backup database trước khi chạy scripts
- Chạy scripts theo đúng thứ tự
- Kiểm tra kỹ connection string trước khi chạy
- Scripts được thiết kế để chạy idempotent (có thể chạy nhiều lần)
