using System;
using System.Collections.Generic;

namespace QLTHPT.Models.Entities
{
    /// <summary>
    /// Entity class đại diện cho Năm học
    /// </summary>
    public class NamHoc
    {
        public int MaNamHoc { get; set; }
        public string TenNamHoc { get; set; } // "2023-2024"
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public bool HienHanh { get; set; } // Năm học hiện tại
        
        // Navigation properties
        public virtual ICollection<HocKy> DanhSachHocKy { get; set; }
        public virtual ICollection<LopHoc> DanhSachLop { get; set; }
    }
}
