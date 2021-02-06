<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="ViewQChart.aspx.cs" Inherits="ViewQChart" Title="PH :: SPC CHART" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />
    <%--<script src="JS/jquery.easing.1.3.js" type="text/javascript"></script>--%>
    <%--<script src="JS/jquery.min.js" type="text/javascript"></script>--%>
    <link href="../Styles/Chart.css" rel="stylesheet" type="text/css" />

    <script src="../JS/Chart.js" type="text/javascript"></script>

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script src="../JS/QualitySheetscript.js" type="text/javascript"></script>

    <script src="../JS/Common.js" type="text/javascript"></script>

    <%--<script src="JS/ErrorPOPup.js" type="text/javascript"></script>--%>

    <script type="text/javascript" language="javascript">
    $(document).ready(function()
{
    $("input[id$='txt_fromdate']").datepick({maxDate: 0,dateFormat: 'dd/mm/yyyy'});
    $("input[id$='txt_todate']").datepick({maxDate: 0,dateFormat: 'dd/mm/yyyy'});
});


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div style="margin-top: -30px;" id="div_header" runat="server">
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
    <div style="margin-top: 5px;" id="div_quality" runat="server" visible="false">
        <table align="left">
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label7" runat="server" Text="Quality Sheet /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Chart" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <div style="background-color: #eefaff;" id="div_chart1" align="center" runat="server">
        <table>
            <%--<tr>
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
                    <select id="ddl_type" runat="server" class="dropdownstyle" onchange="javascript:validatetype();">
                        <option selected="selected" value="0">--- Select Type ---</option>
                        <option value="SPC Chart">SPC Chart</option>
                    </select>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>--%>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label9" runat="server" Text="UNIT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_unit_QC_chart" runat="server" class="dropdownstyle" onchange="javascript:getmachine1();validateunit();">
                        <option value="0" selected="selected">-- Select Cell ---</option>
                        <option value="ALL">ALL</option>
                        <option value="MBU">MBU</option>
                        <option value="ABU">ABU</option>
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
                        <asp:Label ID="Label11" runat="server" Text="CELL" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_cell" runat="server" class="dropdownstyle" onchange="javascript:getmachine();validatecell();">
                        <option value="0" selected="selected">-- Select Cell ---</option>
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
                        <asp:Label ID="Label10" runat="server" Text="MACHINE" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="Slct_machine_QC_chart" runat="server" class="dropdownstyle" onchange="javascript:validatemacnine();">
                        <option value="0" selected="selected">--- Select Machine ---</option>
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
                        <option value="0" selected="selected">-- Select Part No --</option>
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
                    <select id="ddl_operation" runat="server" class="dropdownstyle" onchange="javascript:getdimension();">
                        <option value="0" selected="selected">-- Select Operation --</option>
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
                        <asp:Label ID="Label3" runat="server" Text="DIMENSION" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_dimesion" runat="server" class="dropdownstyle" onchange="javascript:validatedimension();">
                        <option value="0" selected="selected">-- Select Dimension --</option>
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
                        <option value="0" selected="selected">-- Select Shift --</option>
                        <option value="All">All</option>
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
                    <div>
                        <table>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label5" runat="server" Text="FROM" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td style="padding-left: 26px;">
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_fromdate" class="textboxstyle" style="width: 197px;" runat="server" />
                                </td>
                                <td>
                                </td>
                                <td>
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
                        <asp:ImageButton ImageUrl="~/Menu_image/view.jpg" ID="img_view" runat="server" OnClick="img_view_Click"
                            OnClientClick="return validatechart();" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div runat="server" id="div_chart" style="width: 1300px; background-color: #eefaff;"
        align="center" visible="false">
        <%-- <ul class="tabs" data-persist="true">
            <li runat="server"><a href="#view1"><span id="spn_dimensionone" runat="server"></span>
            </a></li>
            <li><a href="#" onclick="javascript:showdimesiontwo();"><span id="spn_dimensiontwo"
                runat="server"></span></a></li>
            <li><a href="#" onclick="javascript:showdimesionthree();"><span id="spn_dimensionthree"
                runat="server"></span></a></li>
            <li><a href="#" onclick="javascript:showdimesionfour();" runat="server" id="linkview4">
                <span id="spn_dimensionfour" runat="server"></span></a></li>
        </ul>--%>
        <div class="tabcontents" align="center" style="background-color: #eefaff;">
            <div id="view1">
                <table>
                    <tr>
                        <td>
                            <asp:Chart ID="QC_Chart" runat="server" Height="700px" Width="1200px" BackColor="#eefaff">
                                <Series>
                                    <asp:Series BorderWidth="2" Color="SkyBlue" Name="Series1" ChartType="Line" ChartArea="ChartArea1"
                                        YValueType="Double" XValueType="Auto" MarkerStyle="Square" MarkerColor="Black">
                                    </asp:Series>
                                    <asp:Series BorderWidth="2" Color="green" Name="Series2" ChartType="Line" ChartArea="ChartArea1"
                                        YValueType="Double">
                                    </asp:Series>
                                    <asp:Series BorderWidth="2" Color="red" Name="Series3" ChartType="Line" BorderDashStyle="Solid"
                                        ChartArea="ChartArea1">
                                    </asp:Series>
                                    <asp:Series BorderWidth="2" Color="red" Name="Series4" ChartType="Line" BorderDashStyle="Solid"
                                        ChartArea="ChartArea1">
                                    </asp:Series>
                                    <asp:Series BorderWidth="2" Color="Blue" Name="Series5" ChartType="Line" BorderDashStyle="Solid"
                                        ChartArea="ChartArea1">
                                    </asp:Series>
                                    <asp:Series BorderWidth="2" Color="Yellow" Name="Series6" ChartType="Line" BorderDashStyle="Solid"
                                        ChartArea="ChartArea1">
                                    </asp:Series>
                                    <asp:Series BorderWidth="2" Color="Yellow" Name="Series7" ChartType="Line" BorderDashStyle="Solid"
                                        ChartArea="ChartArea1">
                                    </asp:Series>
                                    <asp:Series BorderWidth="2" Color="Green" Name="Series8" ChartType="Line" BorderDashStyle="Solid"
                                        ChartArea="ChartArea1">
                                    </asp:Series>
                                    <asp:Series BorderWidth="2" Color="Green" Name="Series9" ChartType="Line" BorderDashStyle="Solid"
                                        ChartArea="ChartArea1">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" BackColor="#eefaff">
                                        <AxisY LineColor="SkyBlue" IntervalType="NotSet">
                                            <LabelStyle Font="Arial, 8.25pt, style=Bold" IntervalType="Auto" />
                                            <ScaleBreakStyle LineWidth="2" Spacing="10" />
                                            <MajorGrid LineColor="black" />
                                        </AxisY>
                                        <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                                            <MajorGrid LineColor="White" Interval="Auto" />
                                            <MajorTickMark Interval="Auto" />
                                            <LabelStyle Font="Microsoft Sans Serif, 8.25pt" />
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div align="center">
                                <table>
                                    <tr>
                                        <td>
                                            <div style="float: left;">
                                                <table>
                                                    <tr>
                                                        <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                            font-weight: bold">
                                                            <span id="sp_vusl" runat="server">USL</span>
                                                        </td>
                                                        <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                            font-weight: bold">
                                                            <span id="sp_us" runat="server" >:</span>
                                                        </td>
                                                        <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                            font-weight: bold;">
                                                            <span id="sp_usl" runat="server" ></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                            font-weight: bold">
                                                            <span id="sp_vlsl" runat="server" >LSL</span>
                                                        </td>
                                                        <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                            font-weight: bold">
                                                            <span id="sp_ls" runat="server" >:</span>
                                                        </td>
                                                        <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                            font-weight: bold">
                                                            <span id="sp_lsl" runat="server"></span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 100px;">
                                        </td>
                                        <td>
                                            <div>
                                                <table>
                                                    <tr>
                                                        <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                            font-weight: bold">
                                                            <span id="spcp" runat="server" >CP</span>
                                                        </td>
                                                        <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                            font-weight: bold">
                                                            <span id="sp_co" runat="server" >:</span>
                                                        </td>
                                                        <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                            font-weight: bold;">
                                                            <span id="sp_CP" runat="server" ></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                            font-weight: bold">
                                                            <span id="spcpk" runat="server" >CPK</span>
                                                        </td>
                                                        <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                            font-weight: bold">
                                                            <span id="sp_col" runat="server">:</span>
                                                        </td>
                                                        <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                            font-weight: bold">
                                                            <span id="sp_CPK" runat="server"></span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 100px;">
                                        </td>
                                        <%--<td valign="top">
                                            <div id="div_roughness" runat="server">
                                                <div>
                                                    <span id="spn_header" runat="server" style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                        font-weight: bold"></span>
                                                </div>
                                                <div>
                                                    <table>
                                                        <tr>
                                                            <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                                font-weight: bold">
                                                                CP (1.6 µm)
                                                            </td>
                                                            <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                                font-weight: bold">
                                                                <span id="Span12" runat="server">:</span>
                                                            </td>
                                                            <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                                font-weight: bold">
                                                                <span id="spn67" runat="server"></span>
                                                            </td>
                                                            <td style="width: 50px;">
                                                            </td>
                                                            <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                                font-weight: bold">
                                                                CPK (7.2 µm)
                                                            </td>
                                                            <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                                font-weight: bold">
                                                                <span id="Span21" runat="server">:</span>
                                                            </td>
                                                            <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                                font-weight: bold">
                                                                <span id="spn_67" runat="server"></span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>--%>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            
        </div>
    </div>
    <br />
    <br />
    <div align="center" id="div_errormessage" visible="false" runat="server">
        <span style="color: Red; font-family: Arial; font-size: 18px; font-weight: bold;
            padding-left: 80px;">No Record Found</span>
    </div>
    <div>
        <input type="hidden" id="hdn_user" name="hdn_user" runat="server" />
        <input type="hidden" id="hdn_part" name="hdn_part" runat="server" />
        <input type="hidden" id="hdn_operation" name="hdn_operation" runat="server" />
        <input type="hidden" id="hdn_shift" name="hdn_shift" runat="server" />
        <input type="hidden" id="hdn_cell" name="hdn_cell" runat="server" />
        <input type="hidden" id="hdn_mach" name="hdn_mach" runat="server" />
        <input type="hidden" id="hdn_unit1" name="hdn_unit1" runat="server" />
        <input type="hidden" id="hdn_dimesion" name="hdn_dimesion" runat="server" />
    </div>
</asp:Content>
