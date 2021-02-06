<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Defaultchart.aspx.cs" Inherits="Defaultchart" %>
--%>

<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="Defaultchart.aspx.cs" Inherits="Defaultchart" Title="PH :: PLANT EFFICIENCY" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/masterfile.js" type="text/javascript"></script>

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    $(document).ready(function()
{
    $("input[id$='txt_fromdate_chart']").datepick({maxDate: 0,dateFormat: 'mm/dd/yyyy'});
    $("input[id$='txt_todate_chart']").datepick({maxDate: 0,dateFormat: 'mm/dd/yyyy'});
});
    </script>

</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div style="margin-top: -30px;">
        <table align="left">
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label32" runat="server" Text="REPORT /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label33" runat="server" Text="PLANT EFFICIENCY" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <div style="background-color: #eefaff; padding-left:400px;" id="div_rptchart">
        <table>
          <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label6" runat="server" Text="UNIT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddl_unit_eff" runat="server" class="dropdownstyle" OnSelectedIndexChanged="onselectedindexchanged_eff"
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
                        <asp:Label ID="Label7" runat="server" Text="MACHINE" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="Slct_machine_eff" runat="server" class="dropdownstyle">
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
                        <asp:Label ID="Label3" runat="server" Text="TYPE OF INDICATOR" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td style="padding-left:-200px;">
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddl_indicator" runat="server" class="dropdownstyle" OnSelectedIndexChanged="OnSelectedIndexChanged_dll_indicator"
                        AutoPostBack="true">
                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                        <asp:ListItem Value="OEE">OEE</asp:ListItem>
                        <asp:ListItem Value="LaborEfficiency/DateWise">Labor Efficiency-Date</asp:ListItem>
                        <asp:ListItem Value="LaborEfficiency/year">Labor Efficiency-Year</asp:ListItem>
                        <asp:ListItem Value="OPE">OPE</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label1" runat="server" Text="SHIFT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_shiftchart" runat="server" class="dropdownstyle">
                        <option value="0" selected="selected">-Select-</option>
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
                    <div runat="server" id="div_yr">
                        <tr>
                            <td align="left">
                                <b>
                                    <asp:Label ID="Label2" runat="server" Text="YEAR" Style="font-family: Times New Roman;"
                                        CssClass="lablestyle">
                                    </asp:Label></b>
                            </td>
                            <td >
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="drp_yr" runat="server" class="dropdownstyle">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </div>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                    <div id="div_date" runat="server">
                        <table>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label4" runat="server" Text="FROM" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle"> 
                                        </asp:Label></b>
                                </td>
                                <td style="padding-left:108px;">
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_fromdate_chart" class="textboxstyle" style="width: 197px;"
                                        runat="server" />
                                </td>
                                <td>
                                </td>
                                <td>
                                    <b>
                                        <asp:Label ID="Label5" runat="server" Text="TO" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_todate_chart" class="textboxstyle" style="width: 197px;"
                                        runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                    <div align="center">
                        <table>
                            <tr style="height: 20px;">
                                <td colspan="3">
                                    <div align="center" style="display: none; padding-left: 20px;" id="diverror">
                                        <span id="spn_error" style="font-size: 14px; color: Red; font-family: Arial;"></span>
                                    </div>
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="3">
                                    <asp:ImageButton ImageUrl="~/Menu_image/view.jpg" ID="img_view" runat="server" OnClick="Button1_Click"
                                        OnClientClick=" return paretoview_validate();" Width="84px" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div align="center" runat="server" id="div_TRS" style="background-color: #eefaff" visible="false">
        <asp:Chart ID="Chart2" runat="server" Width="1200px" Height="700px">
            <Series>
                <asp:Series Name="Default1" XValueMember="DowntimeType" YValueMembers="TRS">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                      <AxisY2 Interval="10" Maximum="100" Minimum="0" Title="Efficiency %" TitleForeColor="Blue">
                        <LabelStyle Font="Trebuchet MS, 10.25pt, style=Bold" />
                    </AxisY2>
                    <AxisY Interval="20" Maximum="1000" Minimum="0" LineColor="64, 64, 64, 64" Title="TRS" TitleForeColor="Blue">
                        <LabelStyle Font="Trebuchet MS, 10.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisY>
                    <AxisX Interval="1" LineColor="64, 64, 64, 64" Title="DOWNTIME TYPE" TitleForeColor="Blue">
                        <LabelStyle Font="Trebuchet MS, 10.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    <div align="center" runat="server" id="div_trg" style="padding-top: -300px; background-color: #eefaff;" visible="false">
        <asp:Chart ID="Chart1" runat="server" Width="1200px" Height="700px">
            <Series>
                <asp:Series Name="Default" XValueMember="DowntimeType" YValueMembers="TRG">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                   <AxisY2 Interval="10" Maximum="100" Minimum="0" Title="Efficiency %" TitleForeColor="Blue" >
                        <LabelStyle Font="Trebuchet MS, 10.25pt, style=Bold" />
                    </AxisY2>
                    <AxisY Interval="20"  Maximum="1000" Minimum="0" LineColor="64, 64, 64, 64" Title="TRG" TitleForeColor="Blue">
                        <LabelStyle Font="Trebuchet MS, 10.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisY>
                    <AxisX Interval="1" LineColor="64, 64, 64, 64" Title="DOWNTIME TYPE" TitleForeColor="Blue">
                        <LabelStyle Font="Trebuchet MS, 10.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    <div align="center" runat="server" id="div_labor" style="padding-top: -300px; background-color: #eefaff;" visible="false">
        <asp:Chart ID="Chart3" runat="server" Width="1200px" Height="700px">
            <Series>
                <asp:Series Name="Default3" XValueMember="date" YValueMembers="total_time">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <%-- <AxisY2 Interval="10" Maximum="100" Minimum="0">
                        <LabelStyle Font="Trebuchet MS, 10.25pt, style=Bold" />
                    </AxisY2>--%>
                    <AxisY Interval="10" Maximum="1000" Minimum="0" LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 10.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisY>
                    <AxisX Interval="1" LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 10.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    <div align="center" runat="server" id="div1_year" style="padding-top: -300px; background-color: #eefaff;" visible="false">
        <asp:Chart ID="Chart4" runat="server" Width="1200px" Height="700px">
            <Series>
                <asp:Series Name="Default4" XValueMember="Month1" YValueMembers="ttl">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <%--   <AxisY2 Interval="10" Maximum="100" Minimum="0">
                        <LabelStyle Font="Trebuchet MS, 10.25pt, style=Bold" />
                    </AxisY2>--%>
                    <AxisY Interval="10" Maximum="1000" Minimum="0" LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 10.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisY>
                    <AxisX Interval="1" LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 10.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
</asp:Content>
