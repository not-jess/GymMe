<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/NavbarAdmin.Master" AutoEventWireup="true" CodeBehind="UpdateSupplementAdmin.aspx.cs" Inherits="Nyobanyoba.View.Admin.UpdateSupplementAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <div>
            <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="ExpiryDateLbl" runat="server" Text="Expiry Date"></asp:Label>
            <asp:TextBox TextMode="Date" ID="ExpiryDateTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="PriceLbl" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="PriceTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="TypeIdLbl" runat="server" Text="Type ID"></asp:Label>
            <asp:TextBox ID="TypeIdTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
            <asp:Label ID="ErrorLbl" runat="server" Text="Error Message" ForeColor="#CC3300"></asp:Label>
        </div>
    </div>
</asp:Content>
