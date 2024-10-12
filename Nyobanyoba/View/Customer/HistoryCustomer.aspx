<%@ Page Title="" Language="C#" MasterPageFile="~/View/Customer/NavbarCustomer.Master" AutoEventWireup="true" CodeBehind="HistoryCustomer.aspx.cs" Inherits="Nyobanyoba.View.Customer.HistoryCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <asp:GridView ID="GridViewTransactionHeader" AutoGenerateColumns="False" runat="server" OnRowCommand="GridViewTransactionHeader_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:TemplateField HeaderText="View">
                    <ItemTemplate>
                        <div>
                            <asp:Button ID="ViewBtn" CommandName="View" runat="server" Text="View" UseSubmitBehavior="false" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
