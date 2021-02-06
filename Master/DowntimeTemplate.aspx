<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="DowntimeTemplate.aspx.cs" Inherits="DowntimeTemplate" Title="PH :: DOWNTIMELOSS TEMPLATE" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .divstyle
        {
            background-color: #4d7eac;
            height: 20px;
            text-align: center;
            font-family: Arial;
            font-size: 15px;
            color: #ffffff;
            font-weight: bold;
            padding-top: 3px;
            border: solid 1px #000;
        }
        .labelstyle
        {
            font-family: Arial;
            font-size: 13px;
            text-align: left;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
   
                    <div style="margin-top: -30px;">
                        <table>
                            <tr>
                                <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label2" runat="server" Text="MASTER  /" valign="left" Font-Bold="true"
                                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="DOWNTIME TEMPLATE" valign="left" Font-Bold="true"
                                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="div_barcode" align="center" style="padding-top: 20px;">
                        <asp:DataList ID="DL_barcodeTemplate" runat="server" OnItemDataBound="DL_barcodeTemplate_ItemDataBound">
                            <ItemTemplate>
                                <div style="width: 800px;">
                                    <table width="100%" style="background-color: #ffffff; border: solid 1px #c3d3da;">
                                        <tr>
                                            <td>
                                                <span style="display: none;">
                                                    <%#Eval("SNo")%>
                                                </span><span style="display: none;">
                                                    <%#Eval("BarcodeText")%>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="divstyle">
                                                        <span style="">Equipment Breakdown/Failure</span></div>
                                                    <br />
                                                    <br />
                                                    <div align="center">
                                                        <asp:Image ID="img_breakdown" runat="server" Width="250" />
                                                    </div>
                                                    <br />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr style="height: 10px;">
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="divstyle">
                                                        <span style="">Unplanned Maintenance</span></div>
                                                    <br />
                                                    <br />
                                                    <div align="center">
                                                        <asp:Image ID="img_maintenance" runat="server" Width="250" />
                                                    </div>
                                                    <br />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr style="height: 10px;">
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="divstyle">
                                                        <span style="">Set Up Change Over</span></div>
                                                    <br />
                                                    <br />
                                                    <div align="center">
                                                        <asp:Image ID="img_setup" runat="server" Width="250" />
                                                    </div>
                                                </div>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr style="height: 10px;">
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="divstyle">
                                                        <span style="">Material Shortage/Delay</span></div>
                                                    <br />
                                                    <br />
                                                    <div align="center">
                                                        <asp:Image ID="img_material" runat="server" Width="250" />
                                                    </div>
                                                    <br />
                                            </td>
                                        </tr>
                                        <tr style="height: 10px;">
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="divstyle">
                                                        <span style="">Operator Shortage </span>
                                                    </div>
                                                    <br />
                                                    <br />
                                                    <div align="center">
                                                        <asp:Image ID="img_operator" runat="server" Width="250" />
                                                    </div>
                                                    <br />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr style="height: 10px;">
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="divstyle">
                                                        <span style="">Not Planned Manuf Engg Trails </span>
                                                    </div>
                                                    <br />
                                                    <br />
                                                    <div align="center">
                                                        <asp:Image ID="img_manuf" runat="server" Width="250" />
                                                    </div>
                                                    <br />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ItemTemplate>
                        </asp:DataList></div>
              
        <br />
        <br />
        <div align="center">
            <input type="button" id="btn_print" value="Print" style="width: 100px; height: 35px;
                cursor: pointer;" onclick="javascript:printpage('div_barcode');" />
        </div>
    </div>
</asp:Content>
