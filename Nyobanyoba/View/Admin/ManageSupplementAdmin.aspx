<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/NavbarAdmin.Master" AutoEventWireup="true" CodeBehind="ManageSupplementAdmin.aspx.cs" Inherits="Nyobanyoba.View.Admin.ManageSupplementAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <asp:GridView ID="GridViewSupplement" AutoGenerateColumns="False" runat="server" OnRowEditing="GridViewSupplement_RowEditing" OnRowDeleting="GridViewSupplement_RowDeleting">
            <Columns>
                <asp:BoundField DataField="SupplementID" HeaderText="ID" SortExpression="SupplementID" />
                <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="SupplementTypeID" HeaderText="Type ID" SortExpression="SupplementTypeID" />
                <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Button ID="insertBtn" runat="server" Text="Insert Supplement" OnClick="insertBtn_Click" />
    </div>
</asp:Content>
