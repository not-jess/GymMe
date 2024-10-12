<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/NavbarAdmin.Master" AutoEventWireup="true" CodeBehind="TransactionReportAdmin.aspx.cs" Inherits="Nyobanyoba.View.Admin.TransactionReportAdmin" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"/>
    </div>
</asp:Content>
