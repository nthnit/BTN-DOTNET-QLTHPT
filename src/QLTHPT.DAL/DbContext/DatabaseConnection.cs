using System;
using System.Configuration;
using System.Data.SqlClient;

namespace QLTHPT.DAL.DbContext
{
    /// <summary>
    /// Class quản lý kết nối database
    /// </summary>
    public class DatabaseConnection
    {
        private static string connectionString;
        
        static DatabaseConnection()
        {
            // Đọc connection string từ App.config
            connectionString = ConfigurationManager.ConnectionStrings["QLTHPTConnection"]?.ConnectionString;
            
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'QLTHPTConnection' không được tìm thấy trong App.config");
            }
        }
        
        /// <summary>
        /// Lấy connection string
        /// </summary>
        public static string GetConnectionString()
        {
            return connectionString;
        }
        
        /// <summary>
        /// Tạo một connection mới
        /// </summary>
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
        
        /// <summary>
        /// Kiểm tra kết nối database
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
