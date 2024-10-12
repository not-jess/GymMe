using Nyobanyoba.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nyobanyoba.View.Admin
{
    public partial class NavbarAdmin : System.Web.UI.MasterPage
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
                            Response.Redirect("~/View/Customer/HomePageCustomer.aspx");
                        }
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
                    }
                }
                else
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
            }
        }

        protected void profileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileAdmin.aspx");
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageAdmin.aspx");
        }

        protected void orderQueueBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderQueueAdmin.aspx");
        }

        protected void manageSupplementBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSupplementAdmin.aspx");
        }

        protected void transactionReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionReportAdmin.aspx");
        }
        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void historyBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistoryAdmin.aspx");
        }
    }
}