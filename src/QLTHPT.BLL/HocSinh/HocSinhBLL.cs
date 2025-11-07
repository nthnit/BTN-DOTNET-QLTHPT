using System;
using System.Collections.Generic;
using System.Linq;
using QLTHPT.DAL.Repositories;
using QLTHPT.Models.Entities;

namespace QLTHPT.BLL.HocSinh
{
    /// <summary>
    /// Business Logic Layer cho Học sinh
    /// Xử lý validation và business rules
    /// </summary>
    public class HocSinhBLL
    {
        private readonly HocSinhRepository _repository;
        
        public HocSinhBLL()
        {
            _repository = new HocSinhRepository();
        }
        
        /// <summary>
        /// Lấy tất cả học sinh
        /// </summary>
        public IEnumerable<Models.Entities.HocSinh> GetAll()
        {
            return _repository.GetAll();
        }
        
        /// <summary>
        /// Lấy học sinh theo mã
        /// </summary>
        public Models.Entities.HocSinh GetById(int maHS)
        {
            if (maHS <= 0)
                throw new ArgumentException("Mã học sinh không hợp lệ");
                
            return _repository.GetById(maHS);
        }
        
        /// <summary>
        /// Lấy danh sách học sinh theo lớp
        /// </summary>
        public IEnumerable<Models.Entities.HocSinh> GetByLop(int maLop)
        {
            if (maLop <= 0)
                throw new ArgumentException("Mã lớp không hợp lệ");
                
            return _repository.GetByLop(maLop);
        }
        
        /// <summary>
        /// Tìm kiếm học sinh
        /// </summary>
        public IEnumerable<Models.Entities.HocSinh> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();
                
            return _repository.Search(keyword);
        }
        
        /// <summary>
        /// Thêm học sinh mới
        /// </summary>
        public bool ThemHocSinh(Models.Entities.HocSinh hs)
        {
            // Validation
            ValidateHocSinh(hs);
            
            // Business rules
            if (!IsValidAge(hs.NgaySinh))
                throw new Exception("Học sinh phải từ 15 đến 20 tuổi");
            
            // Insert
            return _repository.Insert(hs);
        }
        
        /// <summary>
        /// Cập nhật thông tin học sinh
        /// </summary>
        public bool CapNhatHocSinh(Models.Entities.HocSinh hs)
        {
            // Validation
            ValidateHocSinh(hs);
            
            // Check exists
            var existing = _repository.GetById(hs.MaHS);
            if (existing == null)
                throw new Exception("Không tìm thấy học sinh");
            
            // Update
            return _repository.Update(hs);
        }
        
        /// <summary>
        /// Xóa học sinh
        /// </summary>
        public bool XoaHocSinh(int maHS)
        {
            if (maHS <= 0)
                throw new ArgumentException("Mã học sinh không hợp lệ");
            
            // Check if student has scores - prevent deletion
            // TODO: Check điểm trước khi xóa
            
            return _repository.Delete(maHS);
        }
        
        /// <summary>
        /// Validate dữ liệu học sinh
        /// </summary>
        private void ValidateHocSinh(Models.Entities.HocSinh hs)
        {
            if (hs == null)
                throw new ArgumentNullException("Thông tin học sinh không được để trống");
            
            // Validate Họ tên
            if (string.IsNullOrWhiteSpace(hs.HoTen))
                throw new Exception("Họ tên không được để trống");
                
            if (hs.HoTen.Length < 3 || hs.HoTen.Length > 100)
                throw new Exception("Họ tên phải từ 3 đến 100 ký tự");
            
            // Validate Ngày sinh
            if (hs.NgaySinh == DateTime.MinValue)
                throw new Exception("Ngày sinh không hợp lệ");
                
            if (hs.NgaySinh > DateTime.Now)
                throw new Exception("Ngày sinh không được lớn hơn ngày hiện tại");
            
            // Validate Giới tính
            var validGenders = new[] { "Nam", "Nữ", "Khác" };
            if (!validGenders.Contains(hs.GioiTinh))
                throw new Exception("Giới tính phải là Nam, Nữ hoặc Khác");
            
            // Validate Số điện thoại (nếu có)
            if (!string.IsNullOrWhiteSpace(hs.SoDienThoai))
            {
                if (hs.SoDienThoai.Length < 10 || hs.SoDienThoai.Length > 15)
                    throw new Exception("Số điện thoại không hợp lệ");
            }
            
            // Validate Email (nếu có)
            if (!string.IsNullOrWhiteSpace(hs.Email))
            {
                if (!IsValidEmail(hs.Email))
                    throw new Exception("Email không hợp lệ");
            }
            
            // Validate CMND (nếu có)
            if (!string.IsNullOrWhiteSpace(hs.CMND))
            {
                if (hs.CMND.Length < 9 || hs.CMND.Length > 12)
                    throw new Exception("CMND/CCCD không hợp lệ");
            }
            
            // Validate Trạng thái
            var validStatuses = new[] { "Đang học", "Đã tốt nghiệp", "Thôi học", "Bảo lưu" };
            if (!validStatuses.Contains(hs.TrangThai))
                throw new Exception("Trạng thái không hợp lệ");
        }
        
        /// <summary>
        /// Kiểm tra tuổi hợp lệ (15-20 tuổi cho THPT)
        /// </summary>
        private bool IsValidAge(DateTime ngaySinh)
        {
            var age = DateTime.Now.Year - ngaySinh.Year;
            if (ngaySinh.Date > DateTime.Now.AddYears(-age)) age--;
            
            return age >= 15 && age <= 20;
        }
        
        /// <summary>
        /// Validate email format
        /// </summary>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// Chuyển lớp cho học sinh
        /// </summary>
        public bool ChuyenLop(int maHS, int maLopMoi)
        {
            if (maHS <= 0 || maLopMoi <= 0)
                throw new ArgumentException("Mã học sinh hoặc mã lớp không hợp lệ");
            
            var hs = _repository.GetById(maHS);
            if (hs == null)
                throw new Exception("Không tìm thấy học sinh");
            
            // TODO: Check sĩ số lớp mới trước khi chuyển
            // TODO: Update sĩ số lớp cũ và lớp mới
            
            hs.MaLop = maLopMoi;
            return _repository.Update(hs);
        }
        
        /// <summary>
        /// Thống kê số lượng học sinh theo trạng thái
        /// </summary>
        public Dictionary<string, int> ThongKeSoLuongTheoTrangThai()
        {
            var allStudents = _repository.GetAll();
            
            return allStudents
                .GroupBy(hs => hs.TrangThai)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        
        /// <summary>
        /// Lấy danh sách học sinh có nguy cơ bỏ học
        /// (Học sinh có trạng thái "Bảo lưu" hoặc đã lâu không cập nhật)
        /// </summary>
        public IEnumerable<Models.Entities.HocSinh> GetHocSinhNguyCo()
        {
            var allStudents = _repository.GetAll();
            
            return allStudents.Where(hs => 
                hs.TrangThai == "Bảo lưu" || 
                hs.TrangThai == "Thôi học");
        }
    }
}
