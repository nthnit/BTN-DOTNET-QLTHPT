using System;
using System.Collections.Generic;

namespace QLTHPT.Models.Entities
{
    /// <summary>
    /// Entity class đại diện cho Giáo viên
    /// </summary>
    public class GiaoVien
    {
        public int MaGV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string CMND { get; set; }
        
        // Thông tin công tác
        public string ChuyenMon { get; set; }
        public string TrinhDo { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string ChucVu { get; set; }
        public string TrangThai { get; set; } // "Đang làm việc", "Đã nghỉ"
        
        // Navigation properties
        public virtual ICollection<PhanCongGiangDay> DanhSachPhanCong { get; set; }
        public virtual ICollection<LopHoc> DanhSachChuNhiem { get; set; }
    }
}
