using Nyobanyoba.Controller;
using Nyobanyoba.Model;
using Nyobanyoba.Modules;
using Nyobanyoba.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Nyobanyoba.View
{
    public partial class LoginPage : System.Web.UI.Page
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

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            String name = UsernameTxt.Text;
            String password = PasswordTxt.Text;
            bool remember = RememberCB.Checked;
            ErrorLbl.Text = String.Empty;
            var response = UserController.LoginUser(name, password);

            if (!response.Success)
            {
                ErrorLbl.Text = response.Message;
                return;
            }

            Session["user"] = response.Payload.UserID.ToString();

            if (remember)
            {
                HttpCookie cookie = new HttpCookie("user_cookie");
                cookie.Value = response.Payload.UserID.ToString();
                cookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(cookie);
            }

            if (response.Payload.UserRole.Equals("Customer"))
            {
                Response.Redirect("~/View/Customer/HomePageCustomer.aspx");
            }
            if (response.Payload.UserRole.Equals("Admin"))
            {
                Response.Redirect("~/View/Admin/HomePageAdmin.aspx");
            }
        }
    }
}