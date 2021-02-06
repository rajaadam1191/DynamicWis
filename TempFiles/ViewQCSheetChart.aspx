<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewQCSheetchart.aspx.cs"
    Inherits="ViewQCSheetchart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%--<%@ Register Assembly="DevExpress.XtraCharts.v9.1.Web, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>--%>
<%--<%@ Register Assembly="DevExpress.XtraCharts.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073"
    Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Chart ID="QC_Chart" runat="server" Height="800px">
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
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY LineColor="SkyBlue" IntervalType="NotSet" Minimum="67.575" Maximum="67.625" Interval="00.002">
                        <LabelStyle Font="Arial, 8.25pt, style=Bold" IntervalType="Auto" />
                        <ScaleBreakStyle LineWidth="2" Spacing="10" />
                        <MajorGrid LineColor="black"/>
                    </AxisY>
                    <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                        <MajorGrid LineColor="White" Interval="Auto" />
                        <MajorTickMark Interval="Auto" />
                        <LabelStyle Font="Microsoft Sans Serif, 8.25pt" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    </form>
</body>
</html>
