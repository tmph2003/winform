using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BTL_Nhom1.DataContext
{
    public partial class Lop
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string MaNganh { get; set; }
        public string MaSinhVien { get; set; }

        public virtual SinhVien MaSinhVienNavigation { get; set; }
    }
}
