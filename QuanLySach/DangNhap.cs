using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySach
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
           frmDangKi dangKi = new frmDangKi();
            dangKi.ShowDialog();
        }

        Modify modify = new Modify();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;    
            string pass = txtPass.Text;

            if(username.Trim() == "")
            {
                MessageBox.Show("Vui long nhap username");
                return;
            }
            else if (pass.Trim() == "")
            {
                MessageBox.Show("Vui long nhap pass");
                return;
            }
            else
            {
                string query = "Select * from TaiKhoan where UserName = '" + username + "' and Pass = '"+pass+"' ";
                  if(modify.TaiKhoans(query).Count != 0)
                    {

                         MessageBox.Show("Dang nhap thanh cong!","Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                         frmHome home = new frmHome();
                          home.ShowDialog();
                          this.Close();
                }
                    else
                    {
                          MessageBox.Show("Dang nhap khong thanh cong pass hoac username khong chinh xac!","Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
            }
        }
    }
}
