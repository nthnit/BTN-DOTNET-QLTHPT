# Hướng dẫn Phát triển

## Bắt đầu

### 1. Yêu cầu hệ thống
- Visual Studio 2019 hoặc 2022
- .NET Framework 4.7.2 trở lên
- SQL Server 2016+ hoặc SQL Server Express
- Git

### 2. Clone repository
```bash
git clone https://github.com/nthnit/BTN-DOTNET-QLTHPT.git
cd BTN-DOTNET-QLTHPT
```

### 3. Cấu hình Database

#### Bước 1: Tạo Database
Mở SQL Server Management Studio và chạy script:
```
database/schema/01_CreateTables.sql
```

#### Bước 2: Thêm dữ liệu mẫu (optional)
```
database/sample-data/01_InsertSampleData.sql
```

#### Bước 3: Cấu hình Connection String
Mở file `src/QLTHPT.UI/App.config` và cập nhật:
```xml
<connectionStrings>
  <add name="QLTHPTConnection" 
       connectionString="Data Source=YOUR_SERVER;Initial Catalog=QLTHPT_DB;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4. Build Project
1. Mở `QLTHPT.sln` trong Visual Studio
2. Restore NuGet packages (nếu có)
3. Build solution: `Ctrl + Shift + B`

### 5. Run Application
Press `F5` để chạy ứng dụng

## Cấu trúc thư mục

```
QLTHPT/
├── src/                    # Source code
│   ├── QLTHPT.UI/         # Windows Forms UI
│   ├── QLTHPT.BLL/        # Business Logic Layer
│   ├── QLTHPT.DAL/        # Data Access Layer
│   └── QLTHPT.Models/     # Data Models
├── database/              # Database scripts
├── docs/                  # Documentation
└── tests/                 # Tests (nếu có)
```

## Quy tắc Coding

### Naming Conventions

#### Classes và Methods
```csharp
// PascalCase cho class và method names
public class HocSinhRepository { }
public void GetAllHocSinh() { }
```

#### Variables và Parameters
```csharp
// camelCase cho biến local và parameters
int maHocSinh;
string tenHocSinh;
```

#### Constants
```csharp
// UPPER_CASE cho constants
const int MAX_SO_HOC_SINH = 45;
```

### Code Organization

#### DAL Layer
```csharp
// Interface
public interface IHocSinhRepository
{
    IEnumerable<HocSinh> GetAll();
    HocSinh GetById(int id);
    bool Insert(HocSinh entity);
    bool Update(HocSinh entity);
    bool Delete(int id);
}

// Implementation
public class HocSinhRepository : IHocSinhRepository
{
    // Implementation
}
```

#### BLL Layer
```csharp
public class HocSinhBLL
{
    private IHocSinhRepository _repository;
    
    public HocSinhBLL()
    {
        _repository = new HocSinhRepository();
    }
    
    public bool ValidateHocSinh(HocSinh hs)
    {
        // Validation logic
    }
    
    // Business methods
}
```

#### UI Layer
```csharp
public partial class HocSinhForm : Form
{
    private HocSinhBLL _bll;
    
    public HocSinhForm()
    {
        InitializeComponent();
        _bll = new HocSinhBLL();
    }
    
    private void LoadData()
    {
        // Load data logic
    }
}
```

## Database Access

### Sử dụng ADO.NET
```csharp
using (var connection = DatabaseConnection.CreateConnection())
{
    connection.Open();
    using (var command = new SqlCommand(query, connection))
    {
        // Add parameters
        command.Parameters.AddWithValue("@MaHS", maHS);
        
        // Execute query
        var reader = command.ExecuteReader();
        // Process results
    }
}
```

### Sử dụng Parameterized Queries
**Luôn luôn** sử dụng parameters để tránh SQL Injection:
```csharp
// ĐÚNG
string query = "SELECT * FROM HocSinh WHERE MaHS = @MaHS";
command.Parameters.AddWithValue("@MaHS", maHS);

// SAI - Dễ bị SQL Injection
string query = $"SELECT * FROM HocSinh WHERE MaHS = {maHS}";
```

## Error Handling

```csharp
try
{
    // Your code here
}
catch (SqlException ex)
{
    // Handle database errors
    MessageBox.Show($"Lỗi database: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
}
catch (Exception ex)
{
    // Handle other errors
    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

## Testing

### Manual Testing
1. Test từng chức năng CRUD
2. Test validation
3. Test edge cases
4. Test với dữ liệu lớn

### Unit Testing (Optional)
Sử dụng NUnit hoặc MSTest framework

## Git Workflow

### Branching Strategy
```
main/master     -> Production-ready code
develop         -> Development branch
feature/xxx     -> New features
bugfix/xxx      -> Bug fixes
```

### Commit Messages
```
feat: Thêm chức năng quản lý học sinh
fix: Sửa lỗi tính điểm trung bình
docs: Cập nhật README
refactor: Tái cấu trúc code DAL
```

## Troubleshooting

### Lỗi Connection String
- Kiểm tra tên server trong connection string
- Kiểm tra SQL Server có đang chạy không
- Kiểm tra database đã được tạo chưa

### Lỗi Build
- Clean solution: `Build > Clean Solution`
- Rebuild solution: `Build > Rebuild Solution`
- Kiểm tra tất cả project references

### Lỗi Runtime
- Kiểm tra connection string trong App.config
- Kiểm tra database schema đã được tạo đúng
- Xem chi tiết lỗi trong Output window

## Resources

- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [Windows Forms Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
- [ADO.NET Documentation](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/)
- [SQL Server Documentation](https://docs.microsoft.com/en-us/sql/)

## Hỗ trợ

Nếu gặp vấn đề, hãy:
1. Tìm kiếm trong Issues trên GitHub
2. Tạo Issue mới với mô tả chi tiết
3. Liên hệ nhóm phát triển
