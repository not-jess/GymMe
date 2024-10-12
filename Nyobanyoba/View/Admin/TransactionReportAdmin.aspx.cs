using CrystalDecisions.Web;
using Nyobanyoba.Controller;
using Nyobanyoba.DataSet;
using Nyobanyoba.Model;
using Nyobanyoba.Modules;
using Nyobanyoba.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nyobanyoba.View.Admin
{
    public partial class TransactionReportAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var getth = TransactionHeaderController.GetAllTransactionHeaders();

            if (!getth.Success)
            {
                return;
            }

            var getsupplement = SupplementController.GetAllSupplements();

            if (!getsupplement.Success)
            {
                return;
            }

            var getsupplementtype = SupplementTypeController.GetAllSupplementTypes();

            if (!getsupplementtype.Success)
            {
                return;
            }

            TransactionReport report = new TransactionReport();
            CrystalReportViewer1.ReportSource = report;
            report.SetDataSource(GetDataSet(getth.Payload, getsupplement.Payload, getsupplementtype.Payload));
        }


        public DataSet1 GetDataSet(List<TransactionHeader> th, List<MsSupplement> supplements, List<MsSupplementType> supplementTypes)
        {
            DataSet1 data = new DataSet1();
            var thTable = data.TransactionHeader;
            var tdTable = data.TransactionDetail;
            var supplementTable = data.MsSupplement;
            var supplementTypeTable = data.MsSupplementType;

            foreach (MsSupplement x in supplements)
            {
                var supplementRow = supplementTable.NewRow();
                supplementRow["SupplementID"] = x.SupplementID;
                supplementRow["SupplementName"] = x.SupplementName;
                supplementRow["SupplementExpiryDate"] = x.SupplementExpiryDate;
                supplementRow["SupplementPrice"] = x.SupplementPrice;
                supplementRow["SupplementTypeID"] = x.SupplementTypeID;
                supplementTable.Rows.Add(supplementRow);
            }

            foreach (MsSupplementType x in supplementTypes)
            {
                var supplementTypeRow = supplementTypeTable.NewRow();
                supplementTypeRow["SupplementTypeID"] = x.SupplementTypeID;
                supplementTypeRow["SupplementTypeName"] = x.SupplementTypeName;
                supplementTypeTable.Rows.Add(supplementTypeRow);
            }

            foreach (TransactionHeader x in th)
            {
                var thRow = thTable.NewRow();
                thRow["TransactionID"] = x.TransactionID;
                thRow["UserID"] = x.UserID;
                thRow["TransactionDate"] = x.TransactionDate;
                thRow["Status"] = x.Status;
                thTable.Rows.Add(thRow);

                foreach (TransactionDetail y in x.TransactionDetails)
                {
                    var tdRow = tdTable.NewRow();
                    tdRow["TransactionID"] = x.TransactionID;
                    tdRow["SupplementID"] = y.SupplementID;
                    tdRow["Quantity"] = y.Quantity;
                    tdTable.Rows.Add(tdRow);
                }
            }

            return data;
        }
    }
}