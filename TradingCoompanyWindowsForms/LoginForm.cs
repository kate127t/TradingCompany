using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingCompanyBLL.Interfaces;
using TradingCompanyDTO;

namespace TradingCoompanyWindowsForms
{
    public partial class LoginForm : Form
    {
        private readonly IAuthManager authManager;
        public UserDTO curUser { get; set; }
        public LoginForm(IAuthManager authManager)
        {
            InitializeComponent();
            this.authManager = authManager;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            doLogin();
        }

        private void doLogin()
        {
            if (authManager.Login(textBoxLogin.Text, textBoxPassword.Text))
            {
                DialogResult = DialogResult.OK;
                this.curUser = authManager.GetUserByLogin(textBoxLogin.Text);
                this.Close();
            }
            else {
                MessageBox.Show("Invalid login or password");
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                doLogin();
            }
        }
    }
}
