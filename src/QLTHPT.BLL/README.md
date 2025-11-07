# Business Logic Layer (BLL)

Thư mục này chứa tất cả business logic của ứng dụng.

## Cấu trúc

Mỗi thư mục con tương ứng với một domain logic:

### HocSinh/
- `HocSinhBLL.cs` - Business logic cho học sinh
- Validation, business rules liên quan đến học sinh

### GiaoVien/
- `GiaoVienBLL.cs` - Business logic cho giáo viên

### LopHoc/
- `LopHocBLL.cs` - Business logic cho lớp học

### MonHoc/
- `MonHocBLL.cs` - Business logic cho môn học

### Diem/
- `DiemBLL.cs` - Business logic cho điểm
- Tính toán điểm trung bình, xếp loại

### HocKy/
- `HocKyBLL.cs` - Business logic cho học kỳ/năm học

## Nhiệm vụ của BLL

### 1. Validation
```csharp
public class HocSinhBLL
{
    public bool ValidateHocSinh(HocSinh hs)
    {
        if (string.IsNullOrWhiteSpace(hs.HoTen))
            throw new ValidationException("Họ tên không được để trống");
            
        if (hs.NgaySinh > DateTime.Now)
            throw new ValidationException("Ngày sinh không hợp lệ");
            
        // More validation...
        return true;
    }
}
```

### 2. Business Rules
```csharp
public class DiemBLL
{
    public decimal TinhDiemTrungBinh(List<Diem> danhSachDiem)
    {
        // Business logic to calculate average score
        // Following school rules
    }
    
    public string XepLoaiHocLuc(decimal diemTB, List<Diem> danhSachDiem)
    {
        // Giỏi: >= 8.0 và không có môn nào < 6.5
        // Khá: >= 6.5 và không có môn nào < 5.0
        // Trung bình: >= 5.0 và không có môn nào < 3.5
        // Yếu: < 5.0 hoặc có môn < 3.5
    }
}
```

### 3. Data Transformation
```csharp
public HocSinhDTO ConvertToDTO(HocSinh entity)
{
    return new HocSinhDTO
    {
        MaHS = entity.MaHS,
        HoTen = entity.HoTen,
        TenLop = entity.LopHoc?.TenLop ?? "Chưa xếp lớp"
    };
}
```

### 4. Orchestration
```csharp
public bool ChuyenLop(int maHS, int maLopMoi)
{
    try
    {
        // 1. Validate business rules
        ValidateChuyenLop(maHS, maLopMoi);
        
        // 2. Update old class size
        var lopCu = _lopRepository.GetById(oldLopId);
        lopCu.SiSo--;
        _lopRepository.Update(lopCu);
        
        // 3. Update new class size
        var lopMoi = _lopRepository.GetById(maLopMoi);
        lopMoi.SiSo++;
        _lopRepository.Update(lopMoi);
        
        // 4. Update student record
        var hs = _hsRepository.GetById(maHS);
        hs.MaLop = maLopMoi;
        _hsRepository.Update(hs);
        
        return true;
    }
    catch (Exception ex)
    {
        // Handle and log error
        return false;
    }
}
```

## Architecture Pattern

```
UI Layer
   ↓ (calls)
BLL Layer (validation, business logic)
   ↓ (calls)
DAL Layer (data access)
   ↓ (queries)
Database
```

## Best Practices

### 1. Single Responsibility
Mỗi BLL class chỉ xử lý logic cho 1 domain

### 2. No Direct Database Access
BLL không trực tiếp truy cập database, phải thông qua DAL

### 3. Return DTOs
BLL nên return DTOs thay vì Entities để UI layer

### 4. Proper Exception Handling
```csharp
try
{
    // Business logic
}
catch (ValidationException ex)
{
    // Handle validation errors
    throw;
}
catch (DataAccessException ex)
{
    // Handle data access errors
    throw new BusinessException("Error processing request", ex);
}
```

## Dependencies

- **QLTHPT.Models**: Entity classes và DTOs
- **QLTHPT.DAL**: Data access repositories

## Example Usage

```csharp
// In UI Layer
var bll = new HocSinhBLL();

// Add new student
var hs = new HocSinh { ... };
if (bll.ValidateHocSinh(hs))
{
    bll.ThemHocSinh(hs);
}

// Calculate average score
var diem = bll.TinhDiemTrungBinh(maHS, maHK);
```
