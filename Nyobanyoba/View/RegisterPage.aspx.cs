using Nyobanyoba.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nyobanyoba.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLbl.Text = String.Empty;

            if (Session["user"] != null)
            {
                String role = UserController.GetRole(Convert.ToInt32(Session["user"]));
                if (role.Equals("Admin"))
                {
                    Response.Redirect("~/View/Admin/HomePageAdmin.aspx");
                }
                if (role.Equals("Customer"))
                {
                    Response.Redirect("~/View/Customer/HomePageCustomer.aspx");
                }
            }
            else if (Request.Cookies["user_cookie"] != null)
            {
                Session["user"] = Request.Cookies["user_cookie"].Value;
                int cookie = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                String role = UserController.GetRole(cookie);
                if (role.Equals("Admin"))
                {
                    Response.Redirect("~/View/Admin/HomePageAdmin.aspx");
                }
                if (role.Equals("Customer"))
                {
                    Response.Redirect("~/View/Customer/HomePageCustomer.aspx");
                }
            }
            
        }

        protected void registerBtn(object sender, EventArgs e)
        {
            String name = UsernameTxt.Text;
            String email = EmailTxt.Text;
            String gender = GenderRB.SelectedValue;
            String password = PasswordTxt.Text;
            String confirm = ConfirmTxt.Text;
            String dob = Calendar1.SelectedDate.ToString();

            var response = UserController.RegisterUser(name, email, password, confirm, dob, gender);
            if (!response.Success)
            {
                ErrorLbl.Text = response.Message;
                return;
            }

            Response.Redirect("~/View/Customer/HomePageCustomer.aspx");
        }
    }
}