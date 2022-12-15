

using App.Controllers;
using App.DTOs;

namespace App
{
    public partial class LoginForm : Form
    {
        public bool UserSuccessfullyAuthenticated { get; private set; }
        private AuthenticationController auth_controller;

        public LoginForm(AuthenticationController auth_controller)
        {
            InitializeComponent();
            this.auth_controller = auth_controller;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            LoginModelDto loginModel = new() { Email = textBox2.Text, Password = textBox1.Text };
            var success = await auth_controller.LoginAsync(loginModel);
            if (success)
            {
                UserSuccessfullyAuthenticated = true;
                Close();
            }
            else
            {
                //implement
            }
            
            
        }
    }
}
