using System;
using System.Collections.Generic;

namespace QLTHPT.Models.Entities
{
    /// <summary>
    /// Entity class đại diện cho Học kỳ
    /// </summary>
    public class HocKy
    {
        public int MaHK { get; set; }
        public string TenHK { get; set; } // "Học kỳ 1", "Học kỳ 2"
        public int Hky { get; set; } // 1 hoặc 2
        public int MaNamHoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        
        // Navigation properties
        public virtual NamHoc NamHoc { get; set; }
        public virtual ICollection<Diem> DanhSachDiem { get; set; }
    }
}
