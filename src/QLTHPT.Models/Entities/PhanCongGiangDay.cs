using System;

namespace QLTHPT.Models.Entities
{
    /// <summary>
    /// Entity class đại diện cho Phân công giảng dạy
    /// </summary>
    public class PhanCongGiangDay
    {
        public int MaPC { get; set; }
        public int MaGV { get; set; }
        public int MaMH { get; set; }
        public int MaLop { get; set; }
        public int MaHK { get; set; }
        
        // Navigation properties
        public virtual GiaoVien GiaoVien { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual LopHoc LopHoc { get; set; }
        public virtual HocKy HocKy { get; set; }
    }
}
