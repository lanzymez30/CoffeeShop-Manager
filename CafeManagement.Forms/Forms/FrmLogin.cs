using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeManagement.BLL.Implementations;
using CafeManagement.BLL.Interfaces;
using CafeManagement.DAL;
using CafeManagement.DAL.Repositories;
using System;
using System.Windows.Forms;

namespace CafeManagement.Forms.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly IAuthService _authService;

        public FrmLogin()
        {
            InitializeComponent();

            var context = new CafeContext();
            var uow = new UnitOfWork(context);
            _authService = new AuthService(uow);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            var user = _authService.Login(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (user == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            Hide();
            var mainForm = new FrmMain(user);
            mainForm.ShowDialog();
            Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "1";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
