<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="EfficiencyReports.aspx.cs" Inherits="EfficiencyReports" Title="PH :: EfficiencyReports" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />

    <script src="../JS/QualitySheetscript.js" type="text/javascript"></script>

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    $(document).ready(function()
{
    $("input[id$='txt_fromdate']").datepick({maxDate: 0,dateFormat: 'mm/dd/yy'});
    $("input[id$='txt_fromdate']").datepick({maxDate: 0,dateFormat: 'mm/dd/yy'});
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
<div style="" align="left">
<br />
<br />
        <table align="left">
             <tr>
                <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label41" runat="server" Text="REPORT /" valign="left" Font-Bold="false"
                        Font-Size="25px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label42" runat="server" Text="ALL REPORT" valign="left" Font-Bold="false"
                        Font-Size="15px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
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
                <td>
                    <span class="lablestyle">Type</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_type" runat="server" class="dropdownstyle">
                        <option selected="selected" value="0">-Select-</option>
                        <option value="1">DMT</option>
                        <option value="2">Efficiency</option>
                        <option value="3">Spc Chart</option>
                    </select>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <span class="lablestyle">Part No</span>
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
                <td>
                    <span class="lablestyle">Process</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_operation" runat="server" class="dropdownstyle">
                    </select>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <span class="lablestyle">Shift</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_shift" runat="server" class="dropdownstyle" runat="server">
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
                    <div style="padding-left: 17px;">
                        <table>
                            <tr>
                                <td>
                                    <span class="lablestyle">From</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_fromdate" class="textboxstyle" style="width: 197px;" runat="server" />
                                </td>
                                <td>
                                </td>
                                <td>
                                    <span class="lablestyle">To</span>
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
                        <asp:ImageButton ImageUrl="~/Menu_image/view.jpg" ID="img_view" runat="server" 
                            onclick="img_view_Click"  />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <div align="center">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1200px" Font-Names="Verdana"
            Font-Size="8pt" Height="400px">
            <LocalReport>
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1_EfficiencyReports" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
            TypeName="DBWISDataSetTableAdapters.EfficiencyReportsTableAdapter"></asp:ObjectDataSource>
    </div>
</asp:Content>
