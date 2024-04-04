using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_Nhom1.DataContext;

namespace BTL_Nhom1
{
    public partial class DangNhap : Form
    {
        QuanLySinhVienContext db = new QuanLySinhVienContext();
        public DangNhap()
        {
            InitializeComponent();
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            DangNhapmatKhau.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var check = from a in db.Admin
                        where a.TenDangNhap == DangNhaptenDangNhap.Text && a.MatKhau == DangNhapmatKhau.Text
                        select a;
            if (check.FirstOrDefault() != null)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy dangKy = new DangKy();
            dangKy.Show();
        }
    }
}
