

using App.Controllers;
using App.DTOs;
using App.Exceptions;
using Microsoft.IdentityModel.Tokens;

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
            lblIncorrectLogin.Visible = false;

            if(textUsername.Text.IsNullOrEmpty() || textPassword.Text.IsNullOrEmpty())
            {
                lblIncorrectLogin.Visible = true;
                return;
            }

            LoginModelDto loginModel = new() { Email = textUsername.Text, Password = textPassword.Text };
            var success = false;

            try
            {
                success = await auth_controller.LoginAsync(loginModel);
            }
            catch (Exception ex)
            {
                lblIncorrectLogin.Visible = true;
            }

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
