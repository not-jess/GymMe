using Nyobanyoba.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nyobanyoba.View.Admin
{
    public partial class OrderQueueAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridView();
            }
        }

        protected void GVOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Control sourceControl = e.CommandSource as Control;
            GridViewRow row = sourceControl.NamingContainer as GridViewRow;
            int rowIndex = row.RowIndex;

            int transactionId = Convert.ToInt32(GridViewQueue.Rows[rowIndex].Cells[0].Text);
            var response = TransactionHeaderController.UpdateTransactionHeader(transactionId, "Handled");

            RefreshGridView();
        }

        private void RefreshGridView()
        {
            var response = TransactionHeaderController.GetAllTransactionHeaders();

            if (response.Success)
            {
                GridViewQueue.DataSource = response.Payload;
                GridViewQueue.DataBind();
            }
        }
    }
}