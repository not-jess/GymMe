<%@ Page Title="" Language="C#" MasterPageFile="~/View/Customer/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="ProfileCustomer.aspx.cs" Inherits="Nyobanyoba.View.Customer.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <div class="profileInfo">
            <h3>Update Profile Info</h3>
            <div>
                <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="GenderLbl" runat="server" Text="Gender"></asp:Label>
                <asp:RadioButtonList ID="GenderRB" runat="server">
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div>
                <asp:Label ID="DOBLbl" runat="server" Text="Date of Birth (dd/mm/yy)"></asp:Label>
                <asp:TextBox ID="dobTxt" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="UpdateProfileBtn" runat="server" Text="Update Profile" OnClick="UpdateProfileBtn_Click" />
                <asp:Label ID="UpdateProfileFeedbackLbl" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <br />
        <div class="changePass">
            <h3>Update Password</h3>
            <div>
                <asp:Label ID="OldPasswordLbl" runat="server" Text="Old Password"></asp:Label>
                <asp:TextBox TextMode="Password" ID="OldPasswordTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="NewPasswordLbl" runat="server" Text="New Password"></asp:Label>
                <asp:TextBox TextMode="Password" ID="NewPasswordTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="UpdatePasswordBtn" runat="server" Text="Update Password" OnClick="UpdatePasswordBtn_Click" />
                <asp:Label ID="UpdatePasswordFeedbackLbl" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
