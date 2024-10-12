using Nyobanyoba.Controller;
using Nyobanyoba.Model;
using Nyobanyoba.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nyobanyoba.View.Admin
{
    public partial class HomePageAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
                {
                    if (Session["user"] != null)
                    {
                        String role = UserController.GetRole(Convert.ToInt32(Session["user"]));
                        if (role.Equals("Customer"))
                        {
                            Response.Redirect("~/View/Admin/HomePageCustomer.aspx");
                        }
                        int uid = Convert.ToInt32(Session["user"]);
                        MsUser user = UserController.GetUserById(uid);
                        HelloLbl.Text = "Hello " + user.UserName + "<br>";
                        RoleLbl.Text = "You are an " + user.UserRole + "<br><br>";
                    }
                    else if (Request.Cookies["user_cookie"] != null)
                    {
                        Session["user"] = Request.Cookies["user_cookie"].Value;
                        int cookie = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                        String role = UserController.GetRole(cookie);
                        if (role.Equals("Customer"))
                        {
                            Response.Redirect("~/View/Customer/HomePageCustomer.aspx");
                        }
                        int uid = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                        MsUser user = UserController.GetUserById(uid);
                        HelloLbl.Text = "Hello " + user.UserName + "<br>";
                        RoleLbl.Text = "You are an " + user.UserRole + "<br><br>";
                    }
                }
                else
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
                GridViewCustomer.DataSource = UserController.GetAllCustomers().Payload;
                GridViewCustomer.DataBind();
            }
        }
    }
}