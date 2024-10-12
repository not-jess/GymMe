<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Nyobanyoba.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
                <asp:TextBox TextMode="Password" ID="PasswordTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:CheckBox ID="RememberCB" Text="Remember Me." runat="server"></asp:CheckBox>
            </div>
            <div>
                <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click" />
                <asp:Label ID="ErrorLbl" runat="server" Text="Error Message" ForeColor="#CC3300"></asp:Label>
            </div>
            <div>
                <asp:HyperLink ID="RegisterLink" NavigateUrl="RegisterPage.aspx" runat="server">Sign Up</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
