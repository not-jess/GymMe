<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/NavbarAdmin.Master" AutoEventWireup="true" CodeBehind="HomePageAdmin.aspx.cs" Inherits="Nyobanyoba.View.Admin.HomePageAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <asp:Label ID="HelloLbl" runat="server" Text=""></asp:Label>
        <asp:Label ID="RoleLbl" runat="server" Text=""></asp:Label>
        <asp:Label ID="PageDescriptionLbl" runat="server" Text="Below are all the customer data:"></asp:Label>
        <asp:GridView ID="GridViewCustomer" AutoGenerateColumns="False" runat="server">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="ID" SortExpression="UserID" />
                <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="UserName" />
                <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                <asp:BoundField DataField="UserPassword" HeaderText="Password" SortExpression="UserPassword" />
                <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
                <asp:BoundField DataField="UserDOB" HeaderText="Date of Birth" SortExpression="UserDOB" />
                <asp:BoundField DataField="UserRole" HeaderText="Role" SortExpression="UserRole" />
            </Columns>
        </asp:GridView>
    </div>    
</asp:Content>
