using BTL_Nhom1.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom1
{
    public partial class ThongKeTheoSinhVien : Form
    {
        QuanLySinhVienContext db = new QuanLySinhVienContext();
        public ThongKeTheoSinhVien()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series[1].IsVisibleInLegend = false;
            ThongKeTenSinhVien.Text = db.SinhVien.FirstOrDefault(s => s.MaSinhVien == "SV001").TenSinhVien;
            ThongKeMaSinhVien.Text = "SV001";
            var danhSachMon = db.SinhVienMonHoc
                                .Where(s => s.MaSinhVien == "SV001")
                                .Select(s => s.MaMon)
                                .Distinct()
                                .ToList();
            var cacKy = db.MonHoc
                .Where(s => danhSachMon.Contains(s.MaMon))
                .Select(s => new { s.Ky, s.Nam })
                .Distinct()
                .ToList();
            var kyList = cacKy.Select(s => s.Ky).ToList();
            kyList.Add(-1);
            comboBox1.DataSource = kyList;
            comboBox1.SelectedIndex = kyList.Count - 1;
        }
        static string DiemToDiemChu(double? diem)
        {
            if (diem >= 8.5)
                return "A";
            else if (diem >= 7.7)
                return "B+";
            else if (diem >= 7.0)
                return "B";
            else if (diem >= 6.2)
                return "C+";
            else if (diem >= 5.5)
                return "C";
            else if (diem >= 4.7)
                return "D+";
            else if (diem >= 4.0)
                return "D";
            else
                return "F";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyDiem quanLyDiem = new QuanLyDiem();
            quanLyDiem.Show();
        }
        private void UpdateChart(int selectedKy)
        {
            var sinhVienMonHocList = db.SinhVienMonHoc.ToList();
            var monHocList = db.MonHoc.ToList();
            IEnumerable<dynamic> countDiemChu = null;
            if (selectedKy == -1)
            {
                countDiemChu = sinhVienMonHocList.GroupBy(
                    smh => DiemToDiemChu(smh.Diem),
                    (diemChu, smhGroup) => new
                    {
                        DiemChu = diemChu,
                        SoLuong = smhGroup.Count()
                    }).OrderBy(s => s.DiemChu);
            }
            else
            {
                var monTheoKy = monHocList.Where(s => s.Ky == selectedKy).ToList();
                countDiemChu = monTheoKy
                                .Join(sinhVienMonHocList,
                                        mon => mon.MaMon,
                                        smh => smh.MaMon,
                                        (mon, smh) => new { MonHoc = mon, SinhVienMonHoc = smh }) // Selector
                                .GroupBy(
                                    combined => DiemToDiemChu(combined.SinhVienMonHoc.Diem), // Group by
                                    (diemChu, smhGroup) => new
                                    {
                                        DiemChu = diemChu,
                                        SoLuong = smhGroup.Count()
                                    }).OrderBy(s=>s.DiemChu);
            }

            chart1.DataSource = countDiemChu.ToList();
            chart2.DataSource = countDiemChu.ToList();

            chart1.Series["Series1"].XValueMember = "DiemChu";
            chart1.Series["Series1"].YValueMembers = "SoLuong";
            chart1.Series["Series2"].Points.DataBind(countDiemChu, "DiemChu", "SoLuong", "");
            chart2.Series["Series1"].XValueMember = "DiemChu";
            chart2.Series["Series1"].YValueMembers = "SoLuong";
            chart1.DataBind();
            chart2.DataBind();
        }
        private void ThongKeTheoSinhVien_Load(object sender, EventArgs e)
        {
            UpdateChart(-1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedKy = (int)comboBox1.SelectedItem;

            // Cập nhật biểu đồ dựa trên giá trị mới
            UpdateChart(selectedKy);
        }
    }
}
