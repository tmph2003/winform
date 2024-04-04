using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BTL_Nhom1.DataContext
{
    public partial class GiaoVien
    {
        public GiaoVien()
        {
            Admin = new HashSet<Admin>();
        }

        public string MaGiaoVien { get; set; }
        public string TenGiaoVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public bool? GioiTinh { get; set; }
        public string SoDienThoai { get; set; }

        public virtual ICollection<Admin> Admin { get; set; }
    }
}
