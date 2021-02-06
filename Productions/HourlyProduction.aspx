<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="HourlyProduction.aspx.cs" Inherits="HourlyProduction" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div style="" align="left">
        <table align="left">
            <tr>
                <td>
                    <asp:Label ID="Label30" runat="server" Text="MAINTENANCE /" valign="left" Font-Bold="false"
                        Font-Size="25px" ForeColor="#4c6c9f" Font-Names="Arial"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label31" runat="server" Text="HOURLY PRODUCTION" valign="left" Font-Bold="false"
                        Font-Size="15px" ForeColor="#4c6c9f" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="divtitle6" class="" style="font-family:Verdana:Times New Roman: Arial; font-weight:bold; font-size:13px;" align="center">
        
        <br />
        <br />
        <p>
            HOURLY PRODUCTION MONITORING REPORT
        </p>
    </div>
    <div style="padding-left:50px;" id="divFirsttab1" class="">
        <div >
            <table >
                <tr>
                    <td style="text-align: left; width: 135px;" colspan="1">
                        <span class="HPlable">Operator Name</span>
                    </td>
                    <td colspan="2">
                        <div style="margin-left: -1px;">
                            <span>:</span>
                            <asp:TextBox ID="TxtOperatorName" runat="server" CssClass="HPtextbox" Width="1025px" TabIndex="1"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td style="width: 130px; text-align: left;">
                                    <span class="HPlable">Shift</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList ID="TxtShift" runat="server" CssClass="HPdropdown" TabIndex="2">
                                    <asp:ListItem>-Select-</asp:ListItem>
                                        <asp:ListItem>A</asp:ListItem>
                                        <asp:ListItem>B</asp:ListItem>
                                        <asp:ListItem>G</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 125px; text-align: left;">
                                    <span class="HPlable">Date</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtDate" runat="server" Style="width: 142px;" CssClass="HPtextbox" TabIndex="3"></asp:TextBox>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 130px; text-align: left;">
                                    <span class="HPlable">Area</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtArea" runat="server" CssClass="HPtextbox" TabIndex="4"></asp:TextBox>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 98px; text-align: left;">
                                    <span class="HPlable">Part No</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropPartNo" runat="server" CssClass="HPdropdown" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropPartNo_SelectedIndexChanged" TabIndex="5">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height: 3px;">
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td style="width: 130px; text-align: left;">
                                    <span class="HPlable">S.No</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtSno" runat="server" CssClass="HPtextbox" TabIndex="6"></asp:TextBox>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 125px; text-align: left;">
                                    <span class="HPlable">From</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtFrom" runat="server" CssClass="HPtextbox" TabIndex="7"></asp:TextBox>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 130px; text-align: left;">
                                    <span class="HPlable">To</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtTo" runat="server" CssClass="HPtextbox" TabIndex="8"></asp:TextBox>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 98px; text-align: left;">
                                    <span class="HPlable">First Set Up</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropFirstSetUp" runat="server" CssClass="HPdropdown" TabIndex="9">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height: 3px;">
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td style="width: 130px; text-align: left;">
                                    <span class="HPlable">Second Set Up</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropSecondSetUp" runat="server" CssClass="HPdropdown" TabIndex="10">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 125px; text-align: left;">
                                    <span class="HPlable">Produced Qty(HR)</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtProducedQty" runat="server" AutoPostBack="True" CssClass="HPtextbox"
                                        OnTextChanged="TxtProducedQty_TextChanged" TabIndex="11"></asp:TextBox>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 130px; text-align: left;">
                                    <span class="HPlable">Produced Qty(TOT)</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtProducedQty1" runat="server" CssClass="HPtextbox" TabIndex="12"></asp:TextBox>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 98px; text-align: left;">
                                    <span class="HPlable">Man</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtMan" runat="server" CssClass="HPtextbox" TabIndex="13"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height: 3px;">
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td style="width: 130px; text-align: left;">
                                    <span class="HPlable">Material</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtMaterial" runat="server" CssClass="HPtextbox" TabIndex="14"></asp:TextBox>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 125px; text-align: left;">
                                    <span class="HPlable">Machine</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtMachine" runat="server" CssClass="HPtextbox" TabIndex="15"></asp:TextBox>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 130px; text-align: left;">
                                    <span class="HPlable">Environment</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtEnvironment" runat="server" CssClass="HPtextbox" TabIndex="15"></asp:TextBox>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 98px; text-align: left;">
                                    <span class="HPlable">Others</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtOthers" runat="server" CssClass="HPtextbox" TabIndex="17"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height: 3px;">
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td style="width: 130px; text-align: left;">
                                    <span class="HPlable">Down Time Details</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtDownTimeDetails" runat="server" CssClass="HPtextarea" TextMode="MultiLine" TabIndex="18"></asp:TextBox>
                                </td>
                                <td style="width: 145px; text-align: left;">
                                    <span class="HPlable">Rejection Part Details</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtRejectionPart" runat="server" CssClass="HPtextarea" TextMode="MultiLine"
                                        Width="417" TabIndex="19"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height: 3px;">
                    <td colspan="3">
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="3">
                        <div style="padding-left: 145px;">
                            <span class="HPlable">Special Communication and Suggesstion for Improvements :</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div style="padding-left: 145px;">
                            <asp:TextBox ID="TxtCommunication" runat="server" CssClass="HPtextarea" TextMode="MultiLine"
                                Width="1027" Height="70"  TabIndex="20"></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <center>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Menu_image/Save.jpg" OnClick="ImageButton1_Click" />
            </center>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblresult" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
