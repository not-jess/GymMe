using Nyobanyoba.Controller;
using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nyobanyoba.View.Admin
{
    public partial class UpdateSupplementAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLbl.Text = String.Empty;
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
                if (Request["Id"] == null)
                {
                    Response.Redirect("ManageSupplementAdmin.aspx");
                }
                int id = Convert.ToInt32(Request["Id"]);
                MsSupplement s = SupplementController.GetSupplementById(id).Payload;

                NameTxt.Text = s.SupplementName;
                ExpiryDateTxt.Text = s.SupplementExpiryDate.ToString("yyyy-MM-dd");
                PriceTxt.Text = s.SupplementPrice.ToString();
                TypeIdTxt.Text = s.SupplementTypeID.ToString();
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["Id"]);
            String name = NameTxt.Text;
            String expirydate = ExpiryDateTxt.Text;
            String price = PriceTxt.Text;
            String typeid = TypeIdTxt.Text;

            var response = SupplementController.UpdateSupplement(id, name, expirydate, price, typeid);
            if (!response.Success)
            {
                ErrorLbl.Text = response.Message;
                return;
            }

            Response.Redirect("ManageSupplementAdmin.aspx");
        }
    }
}