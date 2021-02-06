<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="RoutingsFrm.aspx.cs" Inherits="RoutingsFrm" Title="PH :: Efficiency Calculus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/tabcontent.css" rel="stylesheet" type="text/css" />

    <script src="../JS/tabcontent.js" type="text/javascript"></script>

    <script src="../JS/Common.js" type="text/javascript"></script>

    <script type="text/javascript">
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="" align="left">
        <table align="left">
            <tr>
                <td>
                    <asp:Label ID="Label41" runat="server" Text="MAINTENANCE /" valign="left" Font-Bold="false"
                        Font-Size="25px" ForeColor="#4c6c9f" Font-Names="Arial"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label42" runat="server" Text="EFFICIENCY CALCULUS" valign="left" Font-Bold="false"
                        Font-Size="15px" ForeColor="#4c6c9f" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="divcolor" class="divtotCntr">
        <br />
        <br />
        <br />
        <br />
        <br />
        <div style="width: 1300px; margin: 0 auto;">
            <ul class="tabs" data-persist="true">
                <li><a href="#view1">Time Template</a></li>
                <li><a href="#view2">Template</a></li>
            </ul>
            <div class="tabcontents">
                <div id="view1">
                    <div align="center">
                        <table>
                            <tr>
                                <td>
                                    <div align="center" style="font-family: Arial; font-size: 15px; font-weight: bold;
                                        background-color: #315881; color: #ffffff; width: 1074px;">
                                        WORKING TIME</div>
                                    <div>
                                        <table style="border: solid 1px #c3d3da; width: 1070px;">
                                            <tr>
                                                <td>
                                                    <div style="padding-left: 100px;">
                                                        <table>
                                                            <tr style="height: 10px;">
                                                                <td colspan="11">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablabel" style="width: 55px;">
                                                                    <span>Part No</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DropPartNo" runat="server" CssClass="tabdropdown" onchange="javascript:getRejection();">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 60px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    <span>Operation</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DropOperation" runat="server" CssClass="tabdropdown" OnSelectedIndexChanged="DropOperation_SelectedIndexChanged"
                                                                        AutoPostBack="True" Style="width: 275px;" onchange="javascript:getRejection();">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 60px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    <span>Date Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtDateTime" runat="server" CssClass="tabtextbox" onblur="javascript:getRejection();"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 5px;">
                                                                <td colspan="11">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablabel">
                                                                    <span>Shift</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DropShift" runat="server" CssClass="tabdropdown" onchange="javascript:getRejection();">
                                                                        <asp:ListItem Value="0" Selected="True">-Select-</asp:ListItem>
                                                                        <asp:ListItem Value="A">A</asp:ListItem>
                                                                        <asp:ListItem Value="B">B</asp:ListItem>
                                                                        <asp:ListItem Value="C">C</asp:ListItem>
                                                                        <asp:ListItem Value="C">G</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 60px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    <span>From</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <div style="margin-left: -2px;">
                                                                        <select style="width: 60px;" id="ddl_fromtime" runat="server">
                                                                            <option value="12">12</option>
                                                                            <option value="1">1</option>
                                                                            <option value="2">2</option>
                                                                            <option value="3">3</option>
                                                                            <option value="4">4</option>
                                                                            <option value="5">5</option>
                                                                            <option value="6">6</option>
                                                                            <option value="7">7</option>
                                                                            <option value="8">8</option>
                                                                            <option value="9">9</option>
                                                                            <option value="10">10</option>
                                                                            <option value="11">11</option>
                                                                            <option value="12">12</option>
                                                                        </select>
                                                                        <select style="width: 60px;" id="ddl_fromampm" runat="server">
                                                                            <option value="am">am</option>
                                                                            <option value="pm">pm</option>
                                                                        </select>
                                                                        <span>To</span>
                                                                        <select style="width: 60px;" id="ddl_totime" runat="server">
                                                                            <option value="12">12</option>
                                                                            <option value="1">1</option>
                                                                            <option value="2">2</option>
                                                                            <option value="3">3</option>
                                                                            <option value="4">4</option>
                                                                            <option value="5">5</option>
                                                                            <option value="6">6</option>
                                                                            <option value="7">7</option>
                                                                            <option value="8">8</option>
                                                                            <option value="9">9</option>
                                                                            <option value="10">10</option>
                                                                            <option value="11">11</option>
                                                                            <option value="12">12</option>
                                                                        </select>
                                                                        <select style="width: 60px;" id="ddl_toampm" runat="server">
                                                                            <option value="pm">pm</option>
                                                                            <option value="am">am</option>
                                                                        </select>
                                                                        <%--<asp:TextBox ID="TxtFromTo" runat="server" CssClass="tabtextbox"></asp:TextBox>--%>
                                                                    </div>
                                                                </td>
                                                                <td style="width: 60px;">
                                                                </td>
                                                                <td class="tablabel" style="width: 155px;">
                                                                    <span>Operator Name</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtOperatorName" runat="server" CssClass="tabtextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 5px;">
                                                                <td colspan="11">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablabel" style="text-align:left;">
                                                                    <span>Machine Name</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_machinename" runat="server" class="tabtextbox" />
                                                                </td>
                                                                <td style="width: 60px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td style="width: 60px;">
                                                                </td>
                                                                <td class="tablabel" style="width: 155px;">
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td style="border-bottom: solid 1px #315881;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div>
                                                        <table>
                                                            <tr>
                                                                <td colspan="11">
                                                                    <div style="font-family: Arial; font-weight: bold; font-size: 14px;" align="center">
                                                                        <span>SPEED LOSS</span>
                                                                    </div>
                                                                    <div align="center">
                                                                        <table width="1060">
                                                                            <tr>
                                                                                <td>
                                                                                    <div>
                                                                                        <div class="divlabel">
                                                                                            Minor Breakdown</div>
                                                                                        <div align="center">
                                                                                            <table>
                                                                                                <tr style="height: 5px;">
                                                                                                    <td colspan="11">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="tablabel">
                                                                                                        <span>Start Time</span>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <input type="text" id="txt_speedstart" runat="server" class="tabtextbox" onchange="javascript:getfromtime(this.id);" />
                                                                                                    </td>
                                                                                                    <td style="width: 40px;">
                                                                                                    </td>
                                                                                                    <td class="tablabel">
                                                                                                        <span>End Time</span>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <input type="text" id="txt_speedend" runat="server" class="tabtextbox" onchange="javascript:gettotime('txt_speedstart','txt_speedend','TxtMinorBreakdown');"
                                                                                                            onblur="javascript:gettotime('txt_speedstart','txt_speedend','TxtMinorBreakdown');"
                                                                                                            onclick="javascript:startime('txt_speedstart','txt_speedend','TxtMinorBreakdown');" />
                                                                                                    </td>
                                                                                                    <td style="width: 40px;">
                                                                                                    </td>
                                                                                                    <td class="tablabel">
                                                                                                        Total
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="TxtMinorBreakdown" runat="server" AutoPostBack="True" CssClass="tabtextbox"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 5px;">
                                                                                <td style="border-bottom: solid 1px #315881;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <div>
                                                                                        <div class="divlabel">
                                                                                            Due To Bottle Neck Down</div>
                                                                                        <div align="center">
                                                                                            <table>
                                                                                                <tr style="height: 5px;">
                                                                                                    <td colspan="11">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="tablabel">
                                                                                                        <span>Start Time</span>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <input type="text" id="txt_botstart" runat="server" class="tabtextbox" onchange="javascript:getfromtime(this.id);" />
                                                                                                    </td>
                                                                                                    <td style="width: 40px;">
                                                                                                    </td>
                                                                                                    <td class="tablabel">
                                                                                                        <span>End Time</span>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <input type="text" id="txt_botend" runat="server" class="tabtextbox" onclick="javascript:startime('txt_botstart','txt_botend','TxtbottleNeckTime');"
                                                                                                            onchange="javascript:gettotime('txt_botstart','txt_botend','TxtbottleNeckTime');" />
                                                                                                    </td>
                                                                                                    <td style="width: 40px;">
                                                                                                    </td>
                                                                                                    <td class="tablabel">
                                                                                                        Total
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="TxtbottleNeckTime" runat="server" AutoPostBack="True" CssClass="tabtextbox"
                                                                                                            OnTextChanged="TxtbottleNeckTime_TextChanged"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="center" style="font-family: Arial; font-size: 15px; font-weight: bold;
                                        background-color: #315881; color: #ffffff; width: 1074px;">
                                        PLANNED STOP(Minutes)
                                    </div>
                                    <div>
                                        <table style="border: solid 1px #c3d3da; width: 1070px;">
                                            <tr style="height: 10px;">
                                                <td colspan="11">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel" style="width: 230px;">
                                                    <span>Private Maintenance and Cleaning</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TXTPreventive" runat="server" CssClass="tabtextbox"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td class="tablabel">
                                                    <div>
                                                        <span>Lunch/Tea</span></div>
                                                </td>
                                                <td>
                                                    <div>
                                                        :</div>
                                                </td>
                                                <td>
                                                    <div>
                                                        <asp:TextBox ID="Txtbreak" runat="server" CssClass="tabtextbox"></asp:TextBox></div>
                                                </td>
                                                <td>
                                                </td>
                                                <td class="tablabel">
                                                    <span>No Plan</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtPlan" runat="server" CssClass="tabtextbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="11">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Planned Manufacturing Engg Trials</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtPlannedEngg" runat="server" CssClass="tabtextbox"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td class="tablabel">
                                                    <span>Meetings</span>
                                                </td>
                                                <td>
                                                    <div>
                                                        :</div>
                                                </td>
                                                <td>
                                                    <div>
                                                        <asp:TextBox ID="TxtMeetings" runat="server" CssClass="tabtextbox"></asp:TextBox></div>
                                                </td>
                                                <td>
                                                </td>
                                                <td class="tablabel">
                                                    <span>Shift Time</span>
                                                </td>
                                                <td>
                                                    <div>
                                                        :</div>
                                                </td>
                                                <td>
                                                    <div>
                                                        <asp:TextBox ID="txt_shift" runat="server" CssClass="tabtextbox"></asp:TextBox></div>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="11">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Setup Fixed Data</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_setup" runat="server" CssClass="tabtextbox"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td class="tablabel">
                                                    <span>Prod Qty</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtProductionQty" runat="server" AutoPostBack="True" OnTextChanged="TxtProductionQty_TextChanged"
                                                        CssClass="tabtextbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 10px;">
                                                <td colspan="11" style="border-bottom: solid 1px #315881;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="11">
                                                    <div style="font-family: Arial; font-weight: bold; font-size: 14px;" align="center">
                                                        <span>QUALITY LOSS</span>
                                                    </div>
                                                    <div align="center">
                                                        <table width="1060">
                                                            <tr>
                                                                <td>
                                                                    <div align="" style="padding-left: 161px;">
                                                                        <table>
                                                                            <tr style="height: 10px;">
                                                                                <td colspan="11">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="tablabel">
                                                                                    <span>Rejection</span>
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="TxtRejection" runat="server" CssClass="tabtextbox"></asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 10px;">
                                                                                </td>
                                                                                <td class="tablabel">
                                                                                    <span>CMM Inspection</span>
                                                                                </td>
                                                                                <td>
                                                                                    :
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="TxtCMMInspection" runat="server" CssClass="tabtextbox" OnTextChanged="TxtCMMInspection_TextChanged"
                                                                                        AutoPostBack="True" OnUnload="TxtCMMInspection_Unload"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style="height: 10px;">
                                                <td colspan="11">
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="center" style="font-family: Arial; font-size: 15px; font-weight: bold;
                                        background-color: #315881; color: #ffffff; width: 1074px;">
                                        DOWN TIME LOSS</div>
                                    <div>
                                        <table style="border: solid 1px #c3d3da; width: 1073px;">
                                            <tr style="height: 10px;">
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="divlabel">
                                                        <span>Equipment Breakdown/Failure</span>
                                                    </div>
                                                    <br />
                                                    <div align="center">
                                                        <table>
                                                            <tr>
                                                                <td class="tablabel">
                                                                    <span>Start Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_eqstarttime" runat="server" class="tabtextbox" onchange="javascript:getfromtime(this.id);" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    <span>End Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_eqendtime" runat="server" class="tabtextbox" onchange="javascript:gettotime('txt_eqstarttime','txt_eqendtime','TxtEquipment');"
                                                                        onclick="javascript:startime('txt_eqstarttime','txt_eqendtime','TxtEquipment');" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    Total
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtEquipment" runat="server" CssClass="tabtextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td style="border-bottom: solid 1px #315881;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="divlabel">
                                                        <span>Unplanned Maintenance</span>
                                                    </div>
                                                    <br />
                                                    <div align="center">
                                                        <table>
                                                            <tr>
                                                                <td class="tablabel">
                                                                    <span>Start Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_unstart" runat="server" class="tabtextbox" onchange="javascript:getfromtime(this.id);" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    <span>End Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_unend" runat="server" class="tabtextbox" onchange="javascript:gettotime('txt_unstart','txt_unend','TxtUnplanned');"
                                                                        onclick="javascript:startime('txt_unstart','txt_unend','TxtUnplanned');" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    Total
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtUnplanned" runat="server" CssClass="tabtextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td style="border-bottom: solid 1px #315881;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="divlabel">
                                                        <span>Set Up Change Over</span>
                                                    </div>
                                                    <br />
                                                    <div align="center">
                                                        <table>
                                                            <tr>
                                                                <td class="tablabel">
                                                                    <span>Start Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_setstart" runat="server" class="tabtextbox" onchange="javascript:getfromtime(this.id);" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    <span>End Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_setend" runat="server" class="tabtextbox" onchange="javascript:gettotime('txt_setstart','txt_setend','TxtChangeOver');"
                                                                        onclick="javascript:startime('txt_setstart','txt_setend','TxtChangeOver');" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    Total
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtChangeOver" runat="server" CssClass="tabtextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td style="border-bottom: solid 1px #315881;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="divlabel">
                                                        <span>Material Shortage/Delay</span>
                                                    </div>
                                                    <br />
                                                    <div align="center">
                                                        <table>
                                                            <tr>
                                                                <td class="tablabel">
                                                                    <span>Start Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_matstart" runat="server" class="tabtextbox" onchange="javascript:getfromtime(this.id);" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    <span>End Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_matend" runat="server" class="tabtextbox" onchange="javascript:gettotime('txt_matstart','txt_matend','TxtDelay');"
                                                                        onclick="javascript:startime('txt_matstart','txt_matend','TxtDelay');" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    Total
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtDelay" runat="server" CssClass="tabtextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td style="border-bottom: solid 1px #315881;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="divlabel">
                                                        <span>Operator Shortage</span>
                                                    </div>
                                                    <br />
                                                    <div align="center">
                                                        <table>
                                                            <tr>
                                                                <td class="tablabel">
                                                                    <span>Start Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_opstart" runat="server" class="tabtextbox" onchange="javascript:getfromtime(this.id);" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    <span>End Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_opend" runat="server" class="tabtextbox" onchange="javascript:gettotime('txt_opstart','txt_opend','TxtOpStortages');"
                                                                        onclick="javascript:startime('txt_opstart','txt_opend','TxtOpStortages');" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    Total
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtOpStortages" runat="server" CssClass="tabtextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td style="border-bottom: solid 1px #315881;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="divlabel">
                                                        <span>Not Planned Manuf Engg Trails</span>
                                                    </div>
                                                    <br />
                                                    <div align="center">
                                                        <table>
                                                            <tr>
                                                                <td class="tablabel">
                                                                    <span>Start Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_ntstart" runat="server" class="tabtextbox" onchange="javascript:getfromtime(this.id);" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    <span>End Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_ntend" runat="server" class="tabtextbox" onchange="javascript:gettotime('txt_ntstart','txt_ntend','TxtNotPlanned');"
                                                                        onclick="javascript:startime('txt_ntstart','txt_ntend','TxtNotPlanned');" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    Total
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtNotPlanned" runat="server" CssClass="tabtextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td style="border-bottom: solid 1px #315881;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="divlabel">
                                                        <span>Quality Issues</span>
                                                    </div>
                                                    <br />
                                                    <div align="center">
                                                        <table>
                                                            <tr>
                                                                <td class="tablabel">
                                                                    <span>Start Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_qstart" runat="server" class="tabtextbox" onchange="javascript:getfromtime(this.id);" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    <span>End Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txt_qend" runat="server" class="tabtextbox" onchange="javascript:gettotime('txt_qstart','txt_qend','TxtQtyIssues');"
                                                                        onclick="javascript:startime('txt_qstart','txt_qend','TxtQtyIssues');" />
                                                                </td>
                                                                <td style="width: 40px;">
                                                                </td>
                                                                <td class="tablabel">
                                                                    Total
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtQtyIssues" runat="server" Width="150px" CssClass="tabtextbox"
                                                                        OnTextChanged="TxtQtyIssues_TextChanged1" AutoPostBack="True"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td style="border-bottom: solid 1px #315881;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div align="center" style="font-family: Arial; font-size: 15px; font-weight: bold;">
                                                        <span>UTILE TIME</span></div>
                                                    <div style="padding-left: 130px;">
                                                        <table>
                                                            <tr>
                                                                <td class="tablabel">
                                                                    <span>Util Time(HRS)</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtUtilTime" runat="server" CssClass="tabtextbox" OnTextChanged="TxtUtilTime_TextChanged"
                                                                        AutoPostBack="True"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td style="border-bottom: solid 1px #315881;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div align="center">
                                                        <div>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <div style="">
                                                                        </div>
                                                                    </td>
                                                                    <td style="width: 50px;">
                                                                    </td>
                                                                    <td>
                                                                        <div style="">
                                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Menu_image/Save.jpg"
                                                                                Visible="true" OnClick="ImageButton1_Click" />
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblresult" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="view2" style="padding-left: 95px;">
                    <div>
                        <table runat="server" id="tbl_view2">
                            <tr>
                                <td valign="top">
                                    <div>
                                        <table style="border: solid 1px #c3d3da; height: 300px;">
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Tt Total Time(HRS)</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextTt" runat="server" CssClass="tabtextbox1" OnTextChanged="TextTt_TextChanged"
                                                        AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Planned Closing Time(HRS)</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtPlandClosing" runat="server" CssClass="tabtextbox1"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>To Opend Time(HRS)</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtOpenedTime" runat="server" CssClass="tabtextbox1" OnTextChanged="TxtOpenedTime_TextChanged"
                                                        AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Planned Stop(HRS)</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtPlannedStops" runat="server" CssClass="tabtextbox1" OnTextChanged="TxtPlannedStops_TextChanged"
                                                        AutoPostBack="True">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Tr Required Time(HRS)</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtReqtime" runat="server" CssClass="tabtextbox1" 
                                                        AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Down Time Loss(HRS)</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtDownTimeLoss" runat="server" CssClass="tabtextbox1" 
                                                        AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Tf Function Time(HRS)</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtFunctionTime" runat="server" CssClass="tabtextbox1"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td style="width: 100px;">
                                </td>
                                <td valign="top">
                                    <div>
                                        <table style="border: solid 1px #c3d3da; height: 300px;">
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Time(HRS)</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtSpeedLoss" runat="server" CssClass="tabtextbox1" 
                                                        AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Tn Ent Operating Time(HRS)</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtNetOpTime" runat="server" CssClass="tabtextbox1"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <div>
                                                        <span>Quality Loss(HRS)</span></div>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtQualityloss" runat="server" CssClass="tabtextbox1" 
                                                        AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Tu Utile Time(HRS)</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtUtileTime" runat="server" CssClass="tabtextbox1" 
                                                        AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>TRS</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtTRS" runat="server" CssClass="tabtextbox1" 
                                                        AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>TRG</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtTRG" runat="server" CssClass="tabtextbox1" 
                                                        AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Total Stop(HRS)</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtTotalStop" runat="server" CssClass="tabtextbox1" 
                                                        AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablabel">
                                                    <span>Util Time Tu + Total Stop(HRS)</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtTotalStophours" runat="server" CssClass="tabtextbox1"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td colspan="3">
                                </td>
                            </tr>
                           
                        </table>
                    </div>
                </div>
                <br />
                <br />
            </div>
        </div>
        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2" Visible="false"
            BackColor="Transparent">
            <HeaderTemplate>
                CALCULATION</HeaderTemplate>
            <ContentTemplate>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label23" runat="server" Text="Tt TOTAL TIME(HOURS)"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtTt" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label24" runat="server" Text="PLANNED CLOSING TIME(HOURS)"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtPlannedClosing" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
</asp:Content>
