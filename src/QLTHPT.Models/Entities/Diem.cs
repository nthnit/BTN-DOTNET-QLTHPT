using System;

namespace QLTHPT.Models.Entities
{
    /// <summary>
    /// Entity class đại diện cho Điểm số
    /// </summary>
    public class Diem
    {
        public int MaDiem { get; set; }
        public int MaHS { get; set; }
        public int MaMH { get; set; }
        public int MaHK { get; set; }
        
        // Các loại điểm
        public decimal? DiemMieng { get; set; }
        public decimal? Diem15Phut { get; set; }
        public decimal? Diem1Tiet { get; set; }
        public decimal? DiemGiuaKy { get; set; }
        public decimal? DiemCuoiKy { get; set; }
        public decimal? DiemTrungBinh { get; set; }
        
        // Navigation properties
        public virtual HocSinh HocSinh { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual HocKy HocKy { get; set; }
    }
}
