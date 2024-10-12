using Nyobanyoba.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nyobanyoba.View.Admin
{
    public partial class ManageSupplementAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewSupplement.DataSource = SupplementController.GetAllSupplements().Payload;
                GridViewSupplement.DataBind();
            }
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertSupplementAdmin.aspx");
        }

        protected void GridViewSupplement_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridViewSupplement.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;
            Response.Redirect("UpdateSupplementAdmin.aspx?Id=" + id);
        }

        protected void GridViewSupplement_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewSupplement.Rows[e.RowIndex];
            String id = row.Cells[0].Text;
            var res = SupplementController.DeleteSupplement(Convert.ToInt32(id));
            Response.Redirect("ManageSupplementAdmin.aspx");
        }
    }
}