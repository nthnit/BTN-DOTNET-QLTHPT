using System;
using System.Collections.Generic;

namespace QLTHPT.Models.Entities
{
    /// <summary>
    /// Entity class đại diện cho Học sinh
    /// </summary>
    public class HocSinh
    {
        public int MaHS { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string CMND { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
        
        // Thông tin gia đình
        public string HoTenPhuHuynh { get; set; }
        public string SoDienThoaiPH { get; set; }
        public string NgheNghiepPH { get; set; }
        
        // Thông tin học tập
        public int? MaLop { get; set; }
        public string TrangThai { get; set; } // "Đang học", "Đã tốt nghiệp", "Thôi học"
        public DateTime NgayNhapHoc { get; set; }
        
        // Navigation properties
        public virtual LopHoc LopHoc { get; set; }
        public virtual ICollection<Diem> DanhSachDiem { get; set; }
    }
}
