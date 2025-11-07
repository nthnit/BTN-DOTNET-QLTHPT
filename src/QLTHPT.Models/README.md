# Models Layer

Thư mục này chứa tất cả các data models của ứng dụng.

## Cấu trúc

### Entities/
Các entity classes ánh xạ trực tiếp với bảng database:
- `HocSinh.cs` - Entity học sinh
- `GiaoVien.cs` - Entity giáo viên
- `LopHoc.cs` - Entity lớp học
- `MonHoc.cs` - Entity môn học
- `Diem.cs` - Entity điểm
- `HocKy.cs` - Entity học kỳ
- `NamHoc.cs` - Entity năm học
- `PhanCongGiangDay.cs` - Entity phân công giảng dạy

### DTOs/ (Data Transfer Objects)
Objects dùng để transfer data giữa các layers:
- `HocSinhDTO.cs` - DTO cho học sinh
- `DiemDTO.cs` - DTO cho điểm
- Các DTO khác theo nhu cầu

### ViewModels/
Models được tối ưu cho UI layer:
- `HocSinhViewModel.cs` - ViewModel hiển thị thông tin học sinh
- `BangDiemViewModel.cs` - ViewModel hiển thị bảng điểm
- Các ViewModel khác

## Quy tắc

### Entity Classes
- Ánh xạ 1:1 với bảng database
- Property names trùng với column names
- Sử dụng navigation properties cho relationships
- Không chứa business logic

```csharp
public class HocSinh
{
    public int MaHS { get; set; }
    public string HoTen { get; set; }
    // ... other properties
    
    // Navigation property
    public virtual LopHoc LopHoc { get; set; }
}
```

### DTOs
- Chỉ chứa data cần thiết
- Không có navigation properties
- Có thể combine data từ nhiều entities

```csharp
public class HocSinhDTO
{
    public int MaHS { get; set; }
    public string HoTen { get; set; }
    public string TenLop { get; set; }
}
```

### ViewModels
- Tối ưu cho UI display
- Có thể chứa computed properties
- Có thể chứa display logic

```csharp
public class HocSinhViewModel
{
    public int MaHS { get; set; }
    public string HoTen { get; set; }
    public string TenLop { get; set; }
    
    // Computed property
    public string HoTenDayDu => $"{HoTen} ({MaHS})";
}
```

## Dependencies

Project này không có dependencies với projects khác.
Các project khác reference đến Models project.
