# Data Access Layer (DAL)

Thư mục này chứa tất cả logic truy cập dữ liệu.

## Cấu trúc

### DbContext/
Quản lý kết nối database:
- `DatabaseConnection.cs` - Connection factory

### Repositories/
Implement Repository Pattern:
- `IRepository.cs` - Generic repository interface
- `HocSinhRepository.cs` - Repository cho học sinh
- `GiaoVienRepository.cs` - Repository cho giáo viên
- `DiemRepository.cs` - Repository cho điểm
- Các repositories khác

## Repository Pattern

### Interface
```csharp
public interface IHocSinhRepository : IRepository<HocSinh>
{
    // Custom methods
    IEnumerable<HocSinh> GetByLop(int maLop);
    IEnumerable<HocSinh> Search(string keyword);
}
```

### Implementation
```csharp
public class HocSinhRepository : IHocSinhRepository
{
    public IEnumerable<HocSinh> GetAll()
    {
        var list = new List<HocSinh>();
        using (var conn = DatabaseConnection.CreateConnection())
        {
            conn.Open();
            string query = "SELECT * FROM HocSinh";
            using (var cmd = new SqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(MapFromReader(reader));
                    }
                }
            }
        }
        return list;
    }
    
    private HocSinh MapFromReader(SqlDataReader reader)
    {
        return new HocSinh
        {
            MaHS = (int)reader["MaHS"],
            HoTen = reader["HoTen"].ToString(),
            // ... map other fields
        };
    }
}
```

## Best Practices

### 1. Sử dụng Using Statements
```csharp
using (var connection = DatabaseConnection.CreateConnection())
{
    // Your code here
}
```

### 2. Parameterized Queries
```csharp
string query = "SELECT * FROM HocSinh WHERE MaHS = @MaHS";
cmd.Parameters.AddWithValue("@MaHS", maHS);
```

### 3. Transaction Handling
```csharp
using (var connection = DatabaseConnection.CreateConnection())
{
    connection.Open();
    using (var transaction = connection.BeginTransaction())
    {
        try
        {
            // Multiple operations
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}
```

### 4. Error Handling
```csharp
try
{
    // Database operations
}
catch (SqlException ex)
{
    // Log and handle SQL errors
    throw new DataAccessException("Error accessing database", ex);
}
```

## Dependencies

- **QLTHPT.Models**: Để sử dụng entity classes
- **System.Data.SqlClient**: Để kết nối SQL Server
- **System.Configuration**: Để đọc connection string

## Testing

Có thể test repositories bằng cách:
1. Mock database connection
2. Sử dụng in-memory database
3. Test với database test riêng
