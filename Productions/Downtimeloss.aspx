<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="Downtimeloss.aspx.cs" Inherits="Productions_Downtimeloss" Title="PH :: DownTimeLoss" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/tabcontent.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/tabcontent.js" type="text/javascript"></script>

    <script src="../JS/EffienciencyCalculus.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div align="center">
        <div align="center">
            <table>
                <tr>
                    <td>
                        <div align="center" style="font-family: Arial; font-size: 15px; font-weight: bold;
                            background-color: #315881; color: #ffffff; width: 1074px;">
                            WORKING TIME</div>
                        <div>
                            <table style="border: solid 1px #c3d3da; width: 1073px;">
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
                                                        <select id="ddl_partno" class="tabdropdown" runat="server">
                                                        </select>
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
                                                        <select id="ddl_operation" class="tabdropdown" style="width: 212px;" runat="server">
                                                        </select>
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
                                                        <input type="text" id="txt_date" class="tabtextbox" runat="server" />
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
                                                        <select id="ddl_shift" class="tabdropdown" runat="server">
                                                            <option value="0" selected="selected">-Select-</option>
                                                            <option value="A">A</option>
                                                            <option value="B">B</option>
                                                            <option value="C">C</option>
                                                            <%--<option value="G">G</option>--%>
                                                        </select>
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
                                                            <select style="width: 45px;" id="ddl_fromtime" runat="server">
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
                                                            <select style="width: 45px;" id="ddl_fromampm" runat="server">
                                                                <option value="am">am</option>
                                                                <option value="pm">pm</option>
                                                            </select>
                                                            <span>To</span>
                                                            <select style="width: 45px;" id="ddl_totime" runat="server">
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
                                                            <select style="width: 45px;" id="ddl_toampm" runat="server">
                                                                <option value="pm">pm</option>
                                                                <option value="am">am</option>
                                                            </select>
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
                                                        <input type="text" id="txt_operatorname" class="tabtextbox" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr style="height: 5px;">
                                                    <td colspan="11">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tablabel" style="text-align: left;">
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
                            <table style="border: solid 1px #c3d3da; width: 1073px;">
                                <tr style="height: 20px;">
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
                                        <input type="text" id="txt_maintenance" class="tabtextbox" runat="server" />
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
                                            <input type="text" id="txt_lunch" class="tabtextbox" runat="server" />
                                        </div>
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
                                        <input type="text" id="txt_noplan" class="tabtextbox" runat="server" />
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
                                        <input type="text" id="txt_manuf" class="tabtextbox" runat="server" />
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
                                            <input type="text" id="txt_meeting" class="tabtextbox" runat="server" />
                                        </div>
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
                                            <input type="text" id="txt_shifttime" class="tabtextbox" runat="server" />
                                        </div>
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
                                        <input type="text" id="txt_fixed" class="tabtextbox" runat="server" />
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
                                    <asp:TextBox id="txt_prodqty" class="tabtextbox" runat="server" AutoPostBack="true" onchange="txt_prodqty_TextChanged" ></asp:TextBox>
<%--                                        <input type="text" id="txt_prodqty" class="tabtextbox" runat="server" onchange="txt_prodqty_TextChanged"   />
--%>                                    </td>
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
                            background-color: #315881; color: #ffffff;">
                            <span>QUALITY LOSS</span>
                        </div>
                        <div align="center">
                            <table width="1073" style="border: solid 1px #c3d3da;">
                                <tr style="height: 10px;">
                                    <td>
                                    </td>
                                </tr>
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
                                                        <input type="text" id="txt_rejection" class="tabtextbox" runat="server" />
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
                                                    <asp:TextBox id="txt_cmm" runat="server"  class="tabtextbox" onchange="TxtCMMInspection_TextChanged" AutoPostBack="true"></asp:TextBox>
<%--                                                        <input type="text" id="txt_cmm" runat="server"  class="tabtextbox" onchange="TxtCMMInspection_TextChanged" />
--%>                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="height: 10px;">
                                    <td>
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
                            UTILE TIME</div>
                        <div>
                            <table style="border: solid 1px #c3d3da; width: 1073px;">
                                <tr style="height: 10px;">
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
                                                        <input type="text" id="Text_Util" runat="server" class="tabtextbox" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="height: 10px;">
                                    <td>
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
                            SPEED LOSS
                        </div>
                        <div>
                            <table style="border: solid 1px #c3d3da; width: 1073px;">
                                <tr style="height: 20px;">
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="" style="padding-left: 191px;">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <span class="tablabel">Type</span>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <input type="text" id="txt_speedtype" class="tabtextbox" style="width: 652px; height: 30px;" runat="server"  />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
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
                                                        <input type="text" id="txt_speedend" runat="server" class="tabtextbox" onchange="javascript:gettotime('txt_speedstart','txt_speedend','txt_totspeed');"
                                                            onblur="javascript:gettotime('txt_speedstart','txt_speedend','txt_totspeed');"
                                                            onclick="javascript:startime('txt_speedstart','txt_speedend','txt_totspeed');" />
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
                                                    <asp:TextBox id="txt_totspeed" runat="server" class="tabtextbox" onchange=" txt_speedtype_TextChanged" AutoPostBack="true"> </asp:TextBox>
<%--                                                        <input type="text" id="txt_totspeed" runat="server" class="tabtextbox" onchange=" txt_speedtype_TextChanged"/>
--%>                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="height: 20px;">
                                    <td>
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
                                <tr style="height: 20px;">
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="" style="padding-left: 191px;">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <span class="tablabel">Type</span>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
<%--                                                    <asp:TextBox id="txt_downtype" class="tabtextbox" style="width: 652px; height: 30px;" runat="server"></asp:TextBox>
--%>                                                        <input type="text" id="txt_downtype" class="tabtextbox" style="width: 652px; height: 30px;" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
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
                                                        <input type="text" id="txt_startdown" runat="server" class="tabtextbox" onchange="javascript:getfromtime(this.id);" />
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
                                                        <input type="text" id="txt_downend" runat="server" class="tabtextbox" onchange="javascript:startime('txt_srartdown','txt_downend','txt_totdowntime');"
                                                            onblur="javascript:gettotime('txt_srartdown','txt_downend','txt_totdowntime');"
                                                            onclick="javascript:startime('txt_srartdown','txt_downend','txt_totdowntime');" />
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
                                                        <input type="text" id="txt_totdowntime" runat="server" class="tabtextbox" onchange="txt_totdowntime_TextChanged" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="height: 20px;">
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="" align="center">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Menu_image/Save.jpg" OnClick="ImageButton1_Click"/>
                        </div>
                    </td>
                </tr>
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
                                                    <asp:TextBox ID="TextTt" runat="server" CssClass="tabtextbox1" 
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
                                                    <asp:TextBox ID="TxtOpenedTime" runat="server" CssClass="tabtextbox1"></asp:TextBox>

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
                                                    <asp:TextBox ID="TxtPlannedStops" runat="server" CssClass="tabtextbox1" 
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
                                                        AutoPostBack="True" ></asp:TextBox>
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
            </table>
        </div>
    </div>
</asp:Content>
