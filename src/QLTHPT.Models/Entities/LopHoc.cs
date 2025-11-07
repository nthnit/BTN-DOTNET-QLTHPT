using System;
using System.Collections.Generic;

namespace QLTHPT.Models.Entities
{
    /// <summary>
    /// Entity class đại diện cho Lớp học
    /// </summary>
    public class LopHoc
    {
        public int MaLop { get; set; }
        public string TenLop { get; set; }
        public int Khoi { get; set; } // 10, 11, 12
        public int SiSo { get; set; }
        public int? MaGVCN { get; set; } // Mã giáo viên chủ nhiệm
        public int MaNamHoc { get; set; }
        public string PhongHoc { get; set; }
        
        // Navigation properties
        public virtual GiaoVien GiaoVienChuNhiem { get; set; }
        public virtual NamHoc NamHoc { get; set; }
        public virtual ICollection<HocSinh> DanhSachHocSinh { get; set; }
    }
}
