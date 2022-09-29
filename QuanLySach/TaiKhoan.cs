using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySach
{
    public class TaiKhoan
    {
        private string username;
        private string email;
        private string password;
        private string v1;
        private string v2;

        public TaiKhoan()
        {

        }

        public TaiKhoan(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public TaiKhoan(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }
    }
}
