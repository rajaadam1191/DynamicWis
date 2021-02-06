<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChartView.aspx.cs" Inherits="DYNSheets_ChartView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div_chart" runat="server">
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
                                                    <span id="sp_us" runat="server">:</span>
                                                </td>
                                                <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                    font-weight: bold;">
                                                    <span id="sp_usl" runat="server"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                    font-weight: bold">
                                                    <span id="sp_vlsl" runat="server">LSL</span>
                                                </td>
                                                <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                    font-weight: bold">
                                                    <span id="sp_ls" runat="server">:</span>
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
                                                    <span id="spcp" runat="server">CP</span>
                                                </td>
                                                <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                    font-weight: bold">
                                                    <span id="sp_co" runat="server">:</span>
                                                </td>
                                                <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                    font-weight: bold;">
                                                    <span id="sp_CP" runat="server"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="color: Black; font-size: 20px; font-family: Verdana, Times New Roman;
                                                    font-weight: bold">
                                                    <span id="spcpk" runat="server">CPK</span>
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
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
      <div align="center" id="div_error" runat="server" visible="false">
    <span style="font-family:Arial Black; font-size:35px; font-weight:bold; color:Red;" id="spn_error" runat="server"></span>
    </div>
    </form>
</body>
</html>
