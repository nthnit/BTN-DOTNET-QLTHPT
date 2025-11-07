# Forms Directory

Thư mục này chứa tất cả các Windows Forms của ứng dụng.

## Cấu trúc

### HocSinh/
Forms liên quan đến quản lý học sinh:
- `HocSinhListForm.cs` - Danh sách học sinh
- `HocSinhDetailForm.cs` - Chi tiết/Thêm/Sửa học sinh
- `HocSinhSearchForm.cs` - Tìm kiếm học sinh

### GiaoVien/
Forms liên quan đến quản lý giáo viên:
- `GiaoVienListForm.cs` - Danh sách giáo viên
- `GiaoVienDetailForm.cs` - Chi tiết/Thêm/Sửa giáo viên

### LopHoc/
Forms liên quan đến quản lý lớp học:
- `LopHocListForm.cs` - Danh sách lớp học
- `LopHocDetailForm.cs` - Chi tiết/Thêm/Sửa lớp học
- `PhanBoHocSinhForm.cs` - Phân bổ học sinh vào lớp

### MonHoc/
Forms liên quan đến quản lý môn học:
- `MonHocListForm.cs` - Danh sách môn học
- `MonHocDetailForm.cs` - Chi tiết/Thêm/Sửa môn học

### Diem/
Forms liên quan đến quản lý điểm:
- `NhapDiemForm.cs` - Nhập điểm cho học sinh
- `DiemTheoLopForm.cs` - Xem điểm theo lớp
- `DiemTheoMonForm.cs` - Xem điểm theo môn

### HocKy/
Forms liên quan đến quản lý học kỳ:
- `HocKyListForm.cs` - Danh sách học kỳ
- `NamHocListForm.cs` - Danh sách năm học

### KetQua/
Forms xem kết quả học tập:
- `KetQuaHocSinhForm.cs` - Kết quả của từng học sinh
- `KetQuaLopHocForm.cs` - Kết quả của lớp học

### BaoCao/
Forms báo cáo và thống kê:
- `BaoCaoTongKetForm.cs` - Báo cáo tổng kết
- `BaoCaoHocLucForm.cs` - Báo cáo học lực
- `ThongKeForm.cs` - Thống kê chung

## Quy tắc đặt tên

- Tên form nên rõ ràng, mô tả chức năng
- Kết thúc bằng `Form` (VD: `HocSinhListForm`)
- Designer file tự động: `FormName.Designer.cs`
- Resource file: `FormName.resx`
