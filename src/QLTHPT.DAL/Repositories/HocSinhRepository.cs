using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QLTHPT.Models.Entities;

namespace QLTHPT.DAL.Repositories
{
    /// <summary>
    /// Repository implementation cho HocSinh
    /// Xử lý tất cả các thao tác database liên quan đến học sinh
    /// </summary>
    public class HocSinhRepository : IRepository<HocSinh>
    {
        /// <summary>
        /// Lấy tất cả học sinh
        /// </summary>
        public IEnumerable<HocSinh> GetAll()
        {
            var list = new List<HocSinh>();
            
            using (var connection = DbContext.DatabaseConnection.CreateConnection())
            {
                connection.Open();
                string query = @"
                    SELECT hs.*, lh.TenLop 
                    FROM HocSinh hs
                    LEFT JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    ORDER BY hs.HoTen";
                
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
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
        
        /// <summary>
        /// Lấy học sinh theo mã
        /// </summary>
        public HocSinh GetById(int id)
        {
            using (var connection = DbContext.DatabaseConnection.CreateConnection())
            {
                connection.Open();
                string query = @"
                    SELECT hs.*, lh.TenLop 
                    FROM HocSinh hs
                    LEFT JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    WHERE hs.MaHS = @MaHS";
                
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaHS", id);
                    
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapFromReader(reader);
                        }
                    }
                }
            }
            
            return null;
        }
        
        /// <summary>
        /// Thêm học sinh mới
        /// </summary>
        public bool Insert(HocSinh entity)
        {
            using (var connection = DbContext.DatabaseConnection.CreateConnection())
            {
                connection.Open();
                string query = @"
                    INSERT INTO HocSinh (HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, 
                                        CMND, DanToc, TonGiao, HoTenPhuHuynh, SoDienThoaiPH, 
                                        NgheNghiepPH, MaLop, TrangThai, NgayNhapHoc)
                    VALUES (@HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai, @Email, 
                           @CMND, @DanToc, @TonGiao, @HoTenPhuHuynh, @SoDienThoaiPH, 
                           @NgheNghiepPH, @MaLop, @TrangThai, @NgayNhapHoc)";
                
                using (var command = new SqlCommand(query, connection))
                {
                    AddParameters(command, entity);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
        
        /// <summary>
        /// Cập nhật thông tin học sinh
        /// </summary>
        public bool Update(HocSinh entity)
        {
            using (var connection = DbContext.DatabaseConnection.CreateConnection())
            {
                connection.Open();
                string query = @"
                    UPDATE HocSinh 
                    SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, 
                        DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email,
                        CMND = @CMND, DanToc = @DanToc, TonGiao = @TonGiao,
                        HoTenPhuHuynh = @HoTenPhuHuynh, SoDienThoaiPH = @SoDienThoaiPH,
                        NgheNghiepPH = @NgheNghiepPH, MaLop = @MaLop, TrangThai = @TrangThai
                    WHERE MaHS = @MaHS";
                
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaHS", entity.MaHS);
                    AddParameters(command, entity);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
        
        /// <summary>
        /// Xóa học sinh
        /// </summary>
        public bool Delete(int id)
        {
            using (var connection = DbContext.DatabaseConnection.CreateConnection())
            {
                connection.Open();
                string query = "DELETE FROM HocSinh WHERE MaHS = @MaHS";
                
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaHS", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
        
        /// <summary>
        /// Lấy danh sách học sinh theo lớp
        /// </summary>
        public IEnumerable<HocSinh> GetByLop(int maLop)
        {
            var list = new List<HocSinh>();
            
            using (var connection = DbContext.DatabaseConnection.CreateConnection())
            {
                connection.Open();
                string query = @"
                    SELECT hs.*, lh.TenLop 
                    FROM HocSinh hs
                    LEFT JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    WHERE hs.MaLop = @MaLop
                    ORDER BY hs.HoTen";
                
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaLop", maLop);
                    
                    using (var reader = command.ExecuteReader())
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
        
        /// <summary>
        /// Tìm kiếm học sinh theo từ khóa
        /// </summary>
        public IEnumerable<HocSinh> Search(string keyword)
        {
            var list = new List<HocSinh>();
            
            using (var connection = DbContext.DatabaseConnection.CreateConnection())
            {
                connection.Open();
                string query = @"
                    SELECT hs.*, lh.TenLop 
                    FROM HocSinh hs
                    LEFT JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    WHERE hs.HoTen LIKE @Keyword 
                       OR hs.SoDienThoai LIKE @Keyword
                       OR hs.Email LIKE @Keyword
                    ORDER BY hs.HoTen";
                
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    
                    using (var reader = command.ExecuteReader())
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
        
        /// <summary>
        /// Map data từ SqlDataReader sang HocSinh object
        /// </summary>
        private HocSinh MapFromReader(SqlDataReader reader)
        {
            return new HocSinh
            {
                MaHS = Convert.ToInt32(reader["MaHS"]),
                HoTen = reader["HoTen"].ToString(),
                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                GioiTinh = reader["GioiTinh"].ToString(),
                DiaChi = reader["DiaChi"]?.ToString(),
                SoDienThoai = reader["SoDienThoai"]?.ToString(),
                Email = reader["Email"]?.ToString(),
                CMND = reader["CMND"]?.ToString(),
                DanToc = reader["DanToc"]?.ToString(),
                TonGiao = reader["TonGiao"]?.ToString(),
                HoTenPhuHuynh = reader["HoTenPhuHuynh"]?.ToString(),
                SoDienThoaiPH = reader["SoDienThoaiPH"]?.ToString(),
                NgheNghiepPH = reader["NgheNghiepPH"]?.ToString(),
                MaLop = reader["MaLop"] != DBNull.Value ? Convert.ToInt32(reader["MaLop"]) : (int?)null,
                TrangThai = reader["TrangThai"].ToString(),
                NgayNhapHoc = Convert.ToDateTime(reader["NgayNhapHoc"])
            };
        }
        
        /// <summary>
        /// Thêm parameters vào SqlCommand
        /// </summary>
        private void AddParameters(SqlCommand command, HocSinh entity)
        {
            command.Parameters.AddWithValue("@HoTen", entity.HoTen);
            command.Parameters.AddWithValue("@NgaySinh", entity.NgaySinh);
            command.Parameters.AddWithValue("@GioiTinh", entity.GioiTinh);
            command.Parameters.AddWithValue("@DiaChi", (object)entity.DiaChi ?? DBNull.Value);
            command.Parameters.AddWithValue("@SoDienThoai", (object)entity.SoDienThoai ?? DBNull.Value);
            command.Parameters.AddWithValue("@Email", (object)entity.Email ?? DBNull.Value);
            command.Parameters.AddWithValue("@CMND", (object)entity.CMND ?? DBNull.Value);
            command.Parameters.AddWithValue("@DanToc", (object)entity.DanToc ?? DBNull.Value);
            command.Parameters.AddWithValue("@TonGiao", (object)entity.TonGiao ?? DBNull.Value);
            command.Parameters.AddWithValue("@HoTenPhuHuynh", (object)entity.HoTenPhuHuynh ?? DBNull.Value);
            command.Parameters.AddWithValue("@SoDienThoaiPH", (object)entity.SoDienThoaiPH ?? DBNull.Value);
            command.Parameters.AddWithValue("@NgheNghiepPH", (object)entity.NgheNghiepPH ?? DBNull.Value);
            command.Parameters.AddWithValue("@MaLop", (object)entity.MaLop ?? DBNull.Value);
            command.Parameters.AddWithValue("@TrangThai", entity.TrangThai);
            command.Parameters.AddWithValue("@NgayNhapHoc", entity.NgayNhapHoc);
        }
    }
}
