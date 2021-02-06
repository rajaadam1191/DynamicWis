<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="logreport.aspx.cs" Inherits="Reports_logreport" Title="Log Report"   EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Button ID="Button1" runat="server" Text="Exception Log"  OnClick="ExportToPDF" />
    <asp:Button ID="Button2" runat="server" Text="Event Log" OnClick="ExportToPDF_sqllog" />
    
    <%--<div style="padding-left: 300px; display: none">
        <asp:ImageButton ID="btn_excel" runat="server" Text="Excel" color="black" ImageUrl="~/Menu_image/Export.png"
            OnClick="ExportToPDF" />
    </div>--%>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    
</asp:Content>

