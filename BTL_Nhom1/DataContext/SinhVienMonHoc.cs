using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BTL_Nhom1.DataContext
{
    public partial class SinhVienMonHoc
    {
        public string MaMon { get; set; }
        public string MaSinhVien { get; set; }
        public double? Diem { get; set; }

        public virtual MonHoc MaMonNavigation { get; set; }
        public virtual SinhVien MaSinhVienNavigation { get; set; }
    }
}
