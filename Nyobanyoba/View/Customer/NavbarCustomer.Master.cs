using Nyobanyoba.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nyobanyoba.View.Customer
{
    public partial class NavbarCustomer : System.Web.UI.MasterPage
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
                        if (role.Equals("Admin"))
                        {
                            Response.Redirect("~/View/Admin/HomePageAdmin.aspx");
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
                    }       
                }
                else
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
            }
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageCustomer.aspx");
        }

        protected void orderSupplementBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderSupplementCustomer.aspx");
        }

        protected void historyBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistoryCustomer.aspx");
        }

        protected void profileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileCustomer.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/View/LoginPage.aspx");
        }
    }
}