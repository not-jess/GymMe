using Nyobanyoba.Controller;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nyobanyoba.View.Admin
{
    public partial class InsertSupplementAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLbl.Text = String.Empty;
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            String name = NameTxt.Text;
            String expirydate = ExpiryDateTxt.Text;
            String price = PriceTxt.Text;
            String typeid = TypeIdTxt.Text;
            
            var response = SupplementController.CreateSupplement(name, expirydate, price, typeid);  
            if (!response.Success)
            {
                ErrorLbl.Text = response.Message;
                return;
            } else
            {
                NameTxt.Text = String.Empty;
                ExpiryDateTxt.Text = String.Empty;
                PriceTxt.Text = String.Empty;
                TypeIdTxt.Text = String.Empty;
                ErrorLbl.Text = response.Message;
            }
        }
    }
}