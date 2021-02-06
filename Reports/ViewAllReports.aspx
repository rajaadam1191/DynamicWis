<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="ViewAllReports.aspx.cs" Inherits="Reports_ViewAllReports" Title="PH :: ALL REPORTS" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script src="../JS/report.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <script type="text/javascript" language="javascript">
    $(document).ready(function()
{

    $("input[id$='txt_fromdate']").datepick({maxDate: 0,dateFormat: 'mm/dd/yyyy'});
    $("input[id$='txt_todate']").datepick({maxDate: 0,dateFormat: 'mm/dd/yyyy'});
    
});
    </script>

    <div style="margin-top: -30px;">
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
                <td align="left">
                    <b>
                        <asp:Label ID="Label7" runat="server" Text="UNIT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddl_unit_QC_chart" runat="server" class="dropdownstyle" OnSelectedIndexChanged="onselectedindexchanged_allrpt"
                        AutoPostBack="true">
                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                        <asp:ListItem Value="ALL">ALL</asp:ListItem>
                        <asp:ListItem Value="MBU">MBU</asp:ListItem>
                        <asp:ListItem Value="ABU">ABU</asp:ListItem>
                    </asp:DropDownList>
                    <%-- <select id="ddl_unit" class="dropdownstyle1" runat="server" OnSelectedIndexChanged="onselectedindexchanged_mchn" onblur="javascript:validate_rptunit();">
                        <option value="ALL">ALL</option>
                        <option value="MBU">MBU</option>
                        <option value="ABU">ABU</option>
                    </select>--%>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label8" runat="server" Text="MACHINE" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="Slct_machine_QC_chart" runat="server" class="dropdownstyle" >
                        <option value="0" selected="selected">-Select-</option>
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
                       <%-- <option value="G">G</option>
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
                                <td style="padding-left:26px;">
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
                 <div id="div_errorr" style="display: none; padding-left: 0px;">
                        <span id="spnerror" style="font-family: Arial; font-size: 14px; color: Red;"></span>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div align="center" style="padding-left: 80px;">
                        <img src="../Menu_image/view.jpg" id="img_view" style="cursor: pointer;" onclick="javascript:movepages();" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
