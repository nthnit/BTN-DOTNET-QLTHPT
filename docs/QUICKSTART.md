# Hướng dẫn Bắt đầu Nhanh

## 📋 Yêu cầu

Trước khi bắt đầu, đảm bảo bạn đã cài đặt:

- ✅ Visual Studio 2019 hoặc 2022
- ✅ .NET Framework 4.7.2 trở lên
- ✅ SQL Server 2016+ hoặc SQL Server Express
- ✅ SQL Server Management Studio (SSMS)
- ✅ Git

## 🚀 Cài đặt trong 5 phút

### Bước 1: Clone Repository (30 giây)
```bash
git clone https://github.com/nthnit/BTN-DOTNET-QLTHPT.git
cd BTN-DOTNET-QLTHPT
```

### Bước 2: Tạo Database (2 phút)

1. Mở **SQL Server Management Studio**
2. Kết nối đến SQL Server của bạn
3. Mở và chạy file: `database/schema/01_CreateTables.sql`
4. (Tùy chọn) Chạy file: `database/sample-data/01_InsertSampleData.sql` để có dữ liệu mẫu

Hoặc chạy script nhanh:
```sql
-- Tạo database
CREATE DATABASE QLTHPT_DB;
GO

-- Chuyển sang database mới
USE QLTHPT_DB;
GO

-- Sau đó chạy nội dung file 01_CreateTables.sql
```

### Bước 3: Cấu hình Connection String (1 phút)

1. Mở file `src/QLTHPT.UI/App.config`
2. Tìm section `<connectionStrings>`
3. Thay đổi `YOUR_SERVER` thành tên SQL Server của bạn:

```xml
<connectionStrings>
  <add name="QLTHPTConnection" 
       connectionString="Data Source=YOUR_SERVER;Initial Catalog=QLTHPT_DB;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

**Ví dụ:**
- Local SQL Server: `Data Source=localhost;...`
- SQL Express: `Data Source=.\SQLEXPRESS;...`
- Named Instance: `Data Source=DESKTOP-ABC\SQLEXPRESS;...`

### Bước 4: Build và Run (1.5 phút)

1. Mở file `QLTHPT.sln` trong Visual Studio
2. Chờ Visual Studio restore packages (nếu có)
3. Build solution: Menu `Build` > `Build Solution` hoặc `Ctrl+Shift+B`
4. Run: Menu `Debug` > `Start Debugging` hoặc `F5`

## ✅ Kiểm tra

Nếu cài đặt thành công, bạn sẽ thấy:
- ✅ Solution build không có lỗi
- ✅ Ứng dụng chạy và hiển thị message box thông báo
- ✅ Có thể kết nối đến database

## 🔧 Xử lý sự cố

### Lỗi: "Cannot open database"
**Nguyên nhân:** Connection string không đúng hoặc database chưa được tạo

**Giải pháp:**
1. Kiểm tra tên server trong connection string
2. Kiểm tra database đã được tạo: `SELECT * FROM sys.databases WHERE name = 'QLTHPT_DB'`
3. Kiểm tra SQL Server đang chạy

### Lỗi: "Login failed for user"
**Nguyên nhân:** Vấn đề authentication

**Giải pháp:**
- Nếu dùng Windows Authentication: `Integrated Security=True`
- Nếu dùng SQL Authentication: `User Id=sa;Password=yourpassword`

### Lỗi: Build failed
**Nguyên nhân:** Thiếu dependencies hoặc project references

**Giải pháp:**
1. Clean solution: `Build` > `Clean Solution`
2. Rebuild solution: `Build` > `Rebuild Solution`
3. Kiểm tra .NET Framework 4.7.2 đã được cài đặt

### Lỗi: "Could not load file or assembly"
**Nguyên nhân:** Project references không đúng

**Giải pháp:**
1. Click phải vào Solution > `Restore NuGet Packages`
2. Rebuild solution

## 📚 Bước tiếp theo

Sau khi cài đặt thành công:

1. **Tìm hiểu cấu trúc**: Đọc [PROJECT_STRUCTURE.md](PROJECT_STRUCTURE.md)
2. **Xem kiến trúc**: Đọc [ARCHITECTURE.md](design/ARCHITECTURE.md)
3. **Bắt đầu phát triển**: Đọc [CONTRIBUTING.md](CONTRIBUTING.md)
4. **Thêm chức năng**: Tạo forms mới theo hướng dẫn

## 🎯 Roadmap Phát triển

### Phase 1: Core Features (Tuần 1-2)
- [ ] Form đăng nhập
- [ ] Form Dashboard chính
- [ ] CRUD Học sinh
- [ ] CRUD Giáo viên
- [ ] CRUD Lớp học

### Phase 2: Academic Features (Tuần 3-4)
- [ ] Quản lý môn học
- [ ] Phân công giảng dạy
- [ ] Nhập điểm
- [ ] Tính điểm trung bình

### Phase 3: Reports (Tuần 5)
- [ ] Báo cáo học lực
- [ ] Báo cáo tổng kết
- [ ] Xuất Excel/PDF

### Phase 4: Polish (Tuần 6)
- [ ] UI/UX improvements
- [ ] Testing
- [ ] Documentation
- [ ] Deployment guide

## 💡 Tips

1. **Sử dụng Sample Data**: Chạy script sample data để có dữ liệu test ngay
2. **Backup Database**: Backup trước khi thay đổi schema
3. **Git Branches**: Tạo branch mới cho mỗi feature
4. **Code Review**: Review code trước khi merge
5. **Documentation**: Update docs khi thêm features mới

## 🆘 Cần giúp đỡ?

- 📖 Xem [Documentation](design/ARCHITECTURE.md)
- 💬 Tạo [GitHub Issue](https://github.com/nthnit/BTN-DOTNET-QLTHPT/issues)
- 👥 Liên hệ nhóm phát triển

## 📝 Checklist Cài đặt

- [ ] Clone repository
- [ ] Cài đặt Visual Studio
- [ ] Cài đặt SQL Server
- [ ] Tạo database
- [ ] Chạy schema scripts
- [ ] Chạy sample data scripts (optional)
- [ ] Cấu hình connection string
- [ ] Build solution thành công
- [ ] Run application thành công
- [ ] Test kết nối database

**Chúc mừng! Bạn đã sẵn sàng để bắt đầu phát triển! 🎉**
