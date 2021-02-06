<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="OEERptFrm.aspx.cs" Inherits="OEERptFrm" Title="PH :: OEE Reports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />

    <script src="../JS/QualitySheetscript.js" type="text/javascript"></script>
     <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    $(document).ready(function()
{
    $("input[id$='txt_from_date']").datepick({maxDate: 0,dateFormat: 'mm/dd/yy'});
    $("input[id$='txt_to_date']").datepick({maxDate: 0,dateFormat: 'mm/dd/yy'});
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
        <table align="left">
            <tr>
                <td>
                    <asp:Label ID="Label41" runat="server" Text="REPORTS /" valign="left" Font-Bold="false"
                        Font-Size="25px" ForeColor="#4c6c9f" Font-Names="Arial"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label42" runat="server" Text="OEE REPORTS" valign="left" Font-Bold="false"
                        Font-Size="15px" ForeColor="#4c6c9f" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<center>
            <div>
                <h1>
                    OEE FOLLOW UP TURNMILL
                </h1>
                <table style="width: 513px" border="1">
                    
                        <tr>
                            
                            <td><span>From Date</span> <input type="text" id="txt_from_date" runat="server" style="width: 100px;" onblur="return validatefromdate();" />
                            </td>
                            
                            <td><span>To Date</span>
                                <input type="text" id="txt_to_date" runat="server" style="width: 100px;" onblur="return validatetodate();" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="View DateWise" Width="149px" Height="26px"
                                    OnClick="Button1_Click" /></td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" Text="VIEW ALL" Width="149px" Height="26px"
                                        OnClick="Button3_Click" />
                                </td>
                        </tr>
                </table>
            </div>
            <br />
            <center>
                <asp:Label ID="Label3" runat="server" Text="Label3" Visible="false "> </asp:Label>
            </center>
            <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="565px" Width="1366px"
                Font-Names="Arial" Font-Size="Medium" BorderColor="Black" ForeColor="Brown">
                <LocalReport ReportPath="Report5.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1_ViewAllEfficiencyCal" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBWISConnectionString3 %>"
                SelectCommand="SELECT [partno], [process], [date], [shift], [shiftfromto], [operatorname], [preventivemaintenance], [lunch], [noplan], [plannedEngtrials], [operatorshortage], [materialshortage], [setupchangeover], [unplannedmaintenance], [Equipfailure], [meetings], [trs], [notplannedengtrails], [qualityissues], [minorbreakdown], [duetobottlenecktime], [rejection], [cmminspection], [tu], [qualityloss], [tn], [speedloss], [tf], [downtimeloss], [trg], [totalstop], [utiletimestop], [productionqty], [tr], [plannedstops], [too], [plantclosingtime], [tt], [utiletime] FROM [efficiencycal]">
            </asp:SqlDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
                TypeName="DataSet1TableAdapters."></asp:ObjectDataSource>--%>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1265px" Font-Names="Verdana"
                Font-Size="8pt" Height="400px">
                <LocalReport ReportPath="Reports/Report5.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1_ViewAllEfficiencyCal" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
                TypeName="DBWISDataSetTableAdapters.efficiencycalTableAdapter"></asp:ObjectDataSource>
    </div>
</asp:Content>
