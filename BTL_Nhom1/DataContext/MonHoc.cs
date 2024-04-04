using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BTL_Nhom1.DataContext
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            SinhVienMonHoc = new HashSet<SinhVienMonHoc>();
        }

        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public int? Ky { get; set; }
        public int? Nam { get; set; }

        public virtual ICollection<SinhVienMonHoc> SinhVienMonHoc { get; set; }
    }
}
