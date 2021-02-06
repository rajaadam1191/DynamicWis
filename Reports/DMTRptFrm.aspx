<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DMTRptFrm.aspx.cs" Inherits="DMTRptFrm" %>--%>

<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="DMTRptFrm.aspx.cs" Inherits="DMTRptFrm" Title="PH :: DMT REPORTS" %>

<%--<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
--%>
<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    $(document).ready(function()
{
    $("input[id$='txt_fromdate']").datepick({maxDate: 0,dateFormat: 'mm/dd/yy'});
    $("input[id$='txt_todate']").datepick({maxDate: 0,dateFormat: 'mm/dd/yy'});
    
});
    </script>

    <style type="text/css">
        #Select1
        {
            width: 173px;
        }
        #Select2
        {
            width: 175px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div  style="margin-top: -30px;" align="left">

        <table align="left">
            <tr>
             <td>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label32" runat="server" Text="REPORT /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label33" runat="server" Text="ALL REPORT" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <div style="background-color: #eefaff;" id="div_rpt" align="center">
        <table>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label3" runat="server" Text="TYPE" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_type" runat="server" class="dropdownstyle">
                        <option selected="selected" value="0">-Select-</option>
                        <option value="1">DMT</option>
                        <option value="3">SPC Chart</option>
                    </select>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td aalign="left">
                    <b>
                        <asp:Label ID="Label1" runat="server" Text="PART NO" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_partno" runat="server" class="dropdownstyle">
                    </select>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label2" runat="server" Text="PROCESS" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_process" runat="server" class="dropdownstyle">
                    </select>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label4" runat="server" Text="SHIFT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_shift" runat="server" class="dropdownstyle">
                        <option value="0" selected="selected">All</option>
                        <option value="A">A</option>
                        <option value="B">B</option>
                        <option value="C">C</option>
                        <%--<option value="G">G</option>
                        <option value="A1">A1</option>
                        <option value="B1">B1</option>--%>
                    </select>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                    <div >
                        <table>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label5" runat="server" Text="FROM" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td style="padding-left:23px;">
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_fromdate" class="textboxstyle" style="width: 197px;" runat="server" />
                                </td>
                                <td>
                                </td>
                                <td >
                                    <b>
                                        <asp:Label ID="Label6" runat="server" Text="TO" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_todate" class="textboxstyle" style="width: 197px;" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr style="height: 15px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                     <div align="center" style="padding-left: 80px;">
                        <asp:ImageButton ImageUrl="~/Menu_image/view.jpg" ID="img_view" runat="server" OnClick="img_view_Click" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <div>
        <div align="center">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1150px" Font-Names="Verdana"
                Font-Size="8pt"  style="height:auto;">
                <LocalReport>
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1_DMT_Template" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
                TypeName="DBWISDataSetTableAdapters.DMT_TemplateTableAdapter"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
