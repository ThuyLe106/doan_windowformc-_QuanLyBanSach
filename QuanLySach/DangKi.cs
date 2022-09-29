using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySach
{
    public partial class frmDangKi : Form
    {
        public frmDangKi()
        {
            InitializeComponent();
        }

      
        public bool checkAccount(string ac)
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }
        public bool CheckEmail (string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");

        }
        Modify modify = new Modify();
        private void btnDangKi_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;   
            string pass  = txtPass.Text;
            string confirmpass = txtCofirmPass.Text;
            if (!checkAccount(username))
            {
                MessageBox.Show("Vui long nhap username dai 6 - 24 ky tu, voi cac ky chu va so, chu hoa va chu thuong!");
                return;
            }
            //if (!checkAccount(email))
            //{
            //    MessageBox.Show("Vui long nhap email dung dinh dang!");
            //    return;
            //}

            if (!checkAccount(pass))
            {
                MessageBox.Show("Vui long nhap pass dai 6 - 24 ky tu, voi cac ky chu va so, chu hoa va chu thuong!");
                return;
            }
            if (confirmpass != pass)
            {
                MessageBox.Show("Vui long xac nhan pass chinh xac");
                return;
            }
            //if(modify.TaiKhoans("Select * from TaiKhoan where Email = '" + email+ "'").Count != 0)
            //{
            //    MessageBox.Show("Email nay da duoc dang ki vui long dang ki email khac!");
            //  return ;
            //}
            try
            {
                string query = "Insert into TaiKhoan values('" + username + "', '" + email + "', '" + pass + "')";
                modify.Command(query);
                if (MessageBox.Show("Dang ki thanh cong! Ban muon dang nhap hay khong ?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ten tai khoan nay da duoc dang ky!. Vui long dang ky ten tai khoan khac!");
            }

        }

      
    }
}
