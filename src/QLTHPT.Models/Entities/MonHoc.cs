using System;
using System.Collections.Generic;

namespace QLTHPT.Models.Entities
{
    /// <summary>
    /// Entity class đại diện cho Môn học
    /// </summary>
    public class MonHoc
    {
        public int MaMH { get; set; }
        public string TenMH { get; set; }
        public int SoTiet { get; set; }
        public int HeSo { get; set; } // Hệ số để tính điểm trung bình
        public string LoaiMon { get; set; } // "Bắt buộc", "Tự chọn"
        public int Khoi { get; set; } // 10, 11, 12 (hoặc 0 nếu áp dụng cho tất cả)
        
        // Navigation properties
        public virtual ICollection<PhanCongGiangDay> DanhSachPhanCong { get; set; }
        public virtual ICollection<Diem> DanhSachDiem { get; set; }
    }
}
