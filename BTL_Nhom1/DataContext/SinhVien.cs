using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BTL_Nhom1.DataContext
{
    public partial class SinhVien
    {
        public SinhVien()
        {
            Lop = new HashSet<Lop>();
            SinhVienMonHoc = new HashSet<SinhVienMonHoc>();
        }

        public string MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public double? Gpa { get; set; }
        public string Email { get; set; }
        public bool? GioiTinh { get; set; }
        public string SoDienThoai { get; set; }

        public virtual ICollection<Lop> Lop { get; set; }
        public virtual ICollection<SinhVienMonHoc> SinhVienMonHoc { get; set; }
    }
}
