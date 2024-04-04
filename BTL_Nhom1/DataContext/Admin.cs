using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BTL_Nhom1.DataContext
{
    public partial class Admin
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string MaGiaoVien { get; set; }

        public virtual GiaoVien MaGiaoVienNavigation { get; set; }
    }
}
