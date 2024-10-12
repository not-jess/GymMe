<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Nyobanyoba.View.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
            <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox TextMode="Password" ID="PasswordTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="ConfirmPassLbl" runat="server" Text="Confirmation Password"></asp:Label>
            <asp:TextBox TextMode="Password" ID="ConfirmTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="DOBLbl" runat="server" Text="Date of Birth (dd/mm/yy)"></asp:Label>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </div>
        <div>
            <asp:Button ID="RegisBtn" runat="server" Text="Register" OnClick="registerBtn" />
            <asp:Label ID="ErrorLbl" runat="server" Text="Error Message" ForeColor="#CC3300"></asp:Label>
        </div>
        <div>
            <asp:HyperLink ID="LoginLink" NavigateUrl="LoginPage.aspx" runat="server">Log In</asp:HyperLink>
        </div>
    </form>
</body>
</html>
