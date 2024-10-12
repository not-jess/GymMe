using Nyobanyoba.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nyobanyoba.View.Admin
{
    public partial class HistoryAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewTransactionHeader.DataSource = TransactionHeaderController.GetAllTransactionHeaders().Payload;
                GridViewTransactionHeader.DataBind();
            }
        }

        protected void GridViewTransactionHeader_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Control sourceControl = e.CommandSource as Control;
                GridViewRow row = sourceControl.NamingContainer as GridViewRow;

                string tid = row.Cells[0].Text;

                Response.Redirect("TransactionDetailAdmin.aspx?Id=" + tid);
            }
        }
    }
}