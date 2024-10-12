using Nyobanyoba.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Nyobanyoba.View.Customer
{
    public partial class OrderSupplementCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewSupplement.DataSource = SupplementController.GetAllSupplements().Payload;
                GridViewSupplement.DataBind();

                GridViewCart.DataSource = CartController.GetCartsByUserId(Convert.ToInt32(Session["user"])).Payload;
                if(GridViewCart.DataSource == null)
                {
                    CartLbl.Text = String.Empty;
                }
                GridViewCart.DataBind();
            }
        }

        protected void GridViewSupplement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                Control sourceControl = e.CommandSource as Control;
                GridViewRow row = sourceControl.NamingContainer as GridViewRow;
                int rowIndex = row.RowIndex;

                int sid = Convert.ToInt32(GridViewSupplement.Rows[rowIndex].Cells[0].Text);

                TextBox Quantitytxt = GridViewSupplement.Rows[rowIndex].Cells[5].FindControl("QuantityTxt") as TextBox;
                String quantity = Quantitytxt.Text;
                Quantitytxt.Text = String.Empty;
                int uid = Convert.ToInt32(Session["User"]);

                Feedback1Lbl.Text = String.Empty;
                var response = CartController.CreateCart(uid, sid, quantity);

                if (!response.Success)
                {
                    Feedback1Lbl.Text = response.Message;
                    return;
                }
                else
                {
                    Feedback1Lbl.Text = response.Message;
                    Response.Redirect("OrderSupplementCustomer.aspx");
                }
            }
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Session["User"]);

            Feedback2Lbl.Text = String.Empty;
            var response = CartController.DeleteCart(uid);

            if (!response.Success)
            {
                Feedback2Lbl.Text = response.Message;
                return;
            }
            else
            {
                Feedback2Lbl.Text = response.Message;
                Response.Redirect("OrderSupplementCustomer.aspx");
            }
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Session["User"]);

            Feedback3Lbl.Text = String.Empty;
            
            var response = CartController.CheckoutCart(uid);

            if (!response.Success)
            {
                Feedback3Lbl.Text = response.Message;
                return;
            }
            else
            {
                Feedback3Lbl.Text = response.Message;
                Response.Redirect("OrderSupplementCustomer.aspx");
            }
        }
    }
}