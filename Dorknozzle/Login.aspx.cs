using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Dorknozzle
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*protected void LoginUser(object sender, EventArgs e)
        {
            if (username.Text == "username" && password.Text == "password")
            {
                FormsAuthentication.RedirectFromLoginPage(username.Text, false);
            }
            if (FormsAuthentication.Authenticate(username.Text, password.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(username.Text, true);
            }
        }This requires username TextBox and password TextBox and we have to code in */
    }
}