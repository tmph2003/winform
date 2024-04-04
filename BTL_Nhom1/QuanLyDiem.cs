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
    public partial class QuanLyDiem : Form
    {
        QuanLySinhVienContext db = new QuanLySinhVienContext();
        public QuanLyDiem()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongKeTheoSinhVien thongKe = new ThongKeTheoSinhVien();
            thongKe.Show();
        }

        private void QuanLyDiem_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            QLDiemTenSinhVien.Text = db.SinhVien.FirstOrDefault(s => s.MaSinhVien == "SV001").TenSinhVien;
            var danhSachMon = db.SinhVienMonHoc
                                .Where(s => s.MaSinhVien == "SV001")
                                .Select(s => new { s.MaMon, s.Diem });

            var DiemTungMon = from smh in danhSachMon
                              join monHoc in db.MonHoc on smh.MaMon equals monHoc.MaMon
                              select new
                              {
                                  MaMon = smh.MaMon,
                                  TenMon = monHoc.TenMon,
                                  Ky = monHoc.Ky,
                                  Nam = monHoc.Nam,
                                  Diem = smh.Diem,
                                  TrangThai = smh.Diem < 4 ? "Học lại" : "Qua môn"
                              };
            dataGridView1.DataSource = DiemTungMon.ToList();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["TrangThai"].Value.ToString() == "Học lại")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
    }
}
