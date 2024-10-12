<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/NavbarAdmin.Master" AutoEventWireup="true" CodeBehind="OrderQueueAdmin.aspx.cs" Inherits="Nyobanyoba.View.Admin.OrderQueueAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <asp:GridView ID="GridViewQueue" runat="server" AutoGenerateColumns="False" OnRowCommand="GVOrders_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Staus" SortExpression="Status"/>
                <asp:TemplateField HeaderText="Handle">
                    <ItemTemplate>
                        <div>
                            <asp:Button ID="HandleBtn" runat="server" Text="Handle" CommandName="Handle"/>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
