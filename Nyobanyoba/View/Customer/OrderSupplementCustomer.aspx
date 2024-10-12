<%@ Page Title="" Language="C#" MasterPageFile="~/View/Customer/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="OrderSupplementCustomer.aspx.cs" Inherits="Nyobanyoba.View.Customer.OrderSupplementCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridViewSupplement" AutoGenerateColumns="False" runat="server" OnRowCommand="GridViewSupplement_RowCommand">
        <Columns>
            <asp:BoundField DataField="SupplementID" HeaderText="Supplement ID" SortExpression="SupplementID" />
            <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
            <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
            <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
            <asp:BoundField DataField="MsSupplementType.SupplementTypeName" HeaderText="Type Name" SortExpression="MsSupplementType.SupplementTypeName" />
            <asp:TemplateField HeaderText="Order">
                <ItemTemplate>
                    <div>
                        <asp:TextBox ID="QuantityTxt" placeholder="input quantity" runat="server" TextMode="Number"></asp:TextBox>
                        <asp:Button ID="OrderBtn" CommandName="Order" runat="server" Text="Order" UseSubmitBehavior="false" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <asp:Label ID="Feedback1Lbl" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="CartLbl" runat="server" Text="Cart:"></asp:Label>
        <asp:GridView ID="GridViewCart" AutoGenerateColumns="False" runat="server">
            <Columns>
                <asp:BoundField DataField="CartID" HeaderText="Cart ID" SortExpression="CartID" />
                <asp:BoundField DataField="MsSupplement.SupplementName" HeaderText="Supplement" SortExpression="MsSupplement.SupplementName" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" OnClick="ClearCartBtn_Click" />
        <asp:Label ID="Feedback2Lbl" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" OnClick="CheckoutBtn_Click" />
        <asp:Label ID="Feedback3Lbl" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
