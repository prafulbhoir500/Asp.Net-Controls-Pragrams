using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspControl.ValidationControl
{
    public partial class RequiredFieldValidationProgramaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Perform login with email and password
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Add your login logic here
        }

        protected void btnOtpLogin_Click(object sender, EventArgs e)
        {
            // Perform OTP login with email
            string email = txtEmail.Text;

            // Add your OTP login logic here
        }
    }
}