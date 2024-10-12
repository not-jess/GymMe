using Nyobanyoba.Controller;
using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nyobanyoba.View.Customer
{
    public partial class TransactionDetailCustomer : System.Web.UI.Page
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
                if (Request["Id"] == null)
                {
                    Response.Redirect("HistoryCustomer.aspx");
                }
                int id = Convert.ToInt32(Request["Id"]);

                TransactionIDLbl.Text = "Transaction ID: " + id.ToString();

                List<TransactionDetail> tdList = TransactionDetailController.GetAllTransactionDetails(id).Payload;

                string details = "";

                foreach (TransactionDetail td in tdList)
                {
                    details += "Supplement ID: " + td.SupplementID.ToString() + ", Quantity: " + td.Quantity.ToString() + "<br />";
                }

                TransactionDetailsLbl.Text = details;

            }
        }
    }
}