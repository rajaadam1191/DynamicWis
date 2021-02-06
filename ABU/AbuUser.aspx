<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AbuUser.aspx.cs" Inherits="ABU_AbuUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PH :: ABU USER</title>
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../favicon.ico" type="image/x-icon" />
    <link rel="../stylesheet" href="../css/style.css" type="text/css" media="screen" />
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Usermenu.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script src="../JS/Abu.js" type="text/javascript"></script>

    <script src="../JS/quicksearch.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    $(document).ready(function()
{
});
// $(function () {
//            $('.search_textbox').each(function (i) {
//                $(this).quicksearch("[id*=grid_abumaster] tr:not(:has(th))", {
//                    'testQuery': function (query, txt, row) {
//                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
//                    }
//                });
//            });
//        });

    </script>

    <style type="text/css">
        .search_textbox
        {
            text-align: center;
            border: solid 1px #000;
            width: 100px;
        }
        .zoomClass
        {
            display: none;
            position: fixed;
            top: 20px;
            left: 0px;
            background-color: #fff;
            height: 500px;
            width: 600px;
            padding: 3px;
            border: solid 1px #525252;
            z-index:99999;
        }
        .Green
        {
            background-color: Green;
            border: medium none;
            color: White;
            border: solid 1px #000;
        }
        .Yellow
        {
            background-color: Yellow;
            color: black;
            border: solid 1px #000;
        }
        .Red
        {
            background-color: Red;
            color: White;
            border: solid 1px #000;
        }
        .Orange
        {
            background-color: #FF8C00;
            color: White;
            border: solid 1px #000;
        }
    </style>
</head>
<body style="background-color: #1f497d;">
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0px" cellspacing="0px" border="0px" align="center" width="99%"
            style="height: 80%">
            <tr>
                <td width="283">
                    <div style="background-color: #315881; margin-left: -5px;">
                        <table>
                            <tr>
                                <td colspan="2">
                                    <div id="oScroll">
                                        <div align="center" id="scroll">
                                            <span id="sp_username" runat="server" style="font-family: Verdana:Times New Roman;
                                                font-size: 20px; color: #ffffff; font-style: italic;"></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="border-bottom: solid 1px #ffffff; width: 355px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="center">
                                        <span id="sp_logtimr" runat="server" style="font-family: Verdana:Times New Roman;
                                            font-size: 15px; color: #ffffff; font-style: italic;"></span>
                                    </div>
                                </td>
                                <td>
                                    <div align="center">
                                        <span id="sp_logdate" runat="server" style="font-family: Verdana:Times New Roman;
                                            font-size: 15px; color: #ffffff; font-style: italic;"></span>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td>
                    <div id="div_user" runat="server">
                        <div id="wrap">
                            <ul class="navbar">
                                <li style="width:275px;"><a href="AbuUser.aspx">ABU TOOLS VIEW</a> </li>
                                <li style="width:275px;"><a id="A1" href="Ranges.aspx">TOOLS FEEDBACK</a></li>
                                <li style="width:275px;">
                                <a href="#">TOOLS TEMPLATE VIEW</a>
                                <ul>
                                    <li><a id="B1" href="#" runat='Server' onserverclick="B1_Click">Tool master list</a></li>
                                    <li><a id="B2" href="#" runat='Server' onserverclick="B2_Click">Tool inspection check list</a></li>
                                    <li><a id="B3" href="#" runat='Server' onserverclick="B3_Click">ToolTry out & inspection Report</a></li>
                                    <li><a id="B4" href="#" runat='Server' onserverclick="B4_Click">Tool Trial Report</a></li>
                                    <li><a id="B5" href="#" runat='Server' onserverclick="B5_Click">Tool Failure Report</a></li>
                                    <li><a id="B6" href="#" runat='Server' onserverclick="B6_Click">Tool Disposal Note</a></li>
                                    <li><a id="B7" href="#" runat='Server' onserverclick="B7_Click">Consumable Transfer Note</a></li>
                                    </ul>
                                </li>
                                <li style="width:275px;"><a href="#" onclick="javascript:exituser1();">LOG OUT</a> </li>
                            </ul>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-top: 0px; margin-left: 10px; float: left;">
        <img src="../Menu_image/poclainlogo.png" />
    </div>
    <div style="margin-top: 0px; margin-right: 10px; float: right;">
        <img src="../Menu_image/TLM-Logo.png" />
    </div>
    <div>
        <div style="margin-top: 50px; margin-left: 600px;" align="center">
            <table align="left">
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text="ABU /" valign="left" Font-Bold="true"
                            Font-Size="30px" ForeColor="White" Font-Names="Arial"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="MASTER VIEW" valign="left" Font-Bold="true"
                            Font-Size="20px" ForeColor="White" Font-Names="Arial"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <br />
    <br />
    <%--<br />
    <br />--%>
    <%--<div align="center">
        <table>
            <tr>
                <td align="left">
                    <span class="lablestyle" style="color: #fff;">Tool Number</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddl_toolnumber" CssClass="dropdownstyle" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddl_toolnumber_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>--%>
    <div>
        <table>
            <tr>
                <td align="center">
                    <div class="Green" style="width: 15px; height: 15px;">
                    </div>
                </td>
                <td style="color: White; width: 10px;">
                    -
                </td>
                <td style="color: White">
                    Usable Condition
                </td>
                 <td style="width:10px;"></td>
                <td align="center">
                    <div class="Yellow" style="width: 15px; height: 15px;">
                    </div>
                </td>
                <td style="color: White; width: 10px;">
                    -
                </td>
                <td style="color: White">
                    Re order Zone
                </td>
                 <td style="width:10px;"></td>
                <td align="center">
                    <div class="Red" style="width: 15px; height: 15px;">
                    </div>
                </td>
                <td style="color: White; width: 10px;">
                    -
                </td>
                <td style="color: White">
                    Life Completed
                </td>
                 <td style="width:10px;"></td>
                <td align="center">
                    <div class="Orange" style="width: 15px; height: 15px;">
                    </div>
                </td>
                <td style="color: White; width: 10px;">
                    -
                </td>
                <td style="color: White">
                    FeedBack Pending
                </td>
            </tr>
            <%--<tr>
                <td style="color: White">
                    Usable condition
                </td>
                <td style="width:10px;"></td>
                <td style="color: White">
                   Re order Zone
                </td>
                <td style="width:10px;"></td>
                <td style="color: White">
                    Life Completed
                </td>
                <td style="width:10px;"></td>
                <td style="color: White">
                    FeedBack Pending
                </td>
            </tr>--%>
        </table>
    </div>
    <div align="center">
        <table>
            <tr>
                <td valign="top">
                    <div align="center" style="background-color:#31aae3;height:50px;">
                        <span style="font-size: 25px; font-family: Arial Black;text-align: center; color: #fff;">
                            ABU</span>
                    </div>
                    <div style="background-color:#287ab0;">
                        <asp:DataList ID="ddl_gridlist" runat="server" RepeatColumns="4" BorderColor="Beige"
                            OnItemDataBound="ddl_gridlist_ItemDataBound">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                    Visible="false"></asp:Label>
                                <div style="height: 50px; width: 100px; cursor: pointer; border: solid 2px #fff;text-align: center;"
                                    id="div_tool" runat="server">
                                    <div style="padding-top: 0px;">
                                        <span style="font-size: 15px; font-family: Arial Black; text-align: center;">
                                            <%# DataBinder.Eval(Container.DataItem, "Tool")%></span></div>
                                </div>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:DataList></div>
                </td>
                <td valign="top">
                    <div align="center" style="background-color:#3cbffc;height:50px;">
                        <span style="font-size: 25px; font-family: Arial Black; text-align: center; color: #fff;">
                            HMC</span>
                    </div>
                    <div style="background-color:#2e84bd;">
                        <asp:DataList ID="ddl_hmc" runat="server" RepeatColumns="4" BorderColor="Beige" OnItemDataBound="ddl_hmc_ItemDataBound">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                    Visible="false"></asp:Label>
                                <div style="height: 50px; width: 100px; cursor: pointer; border: solid 2px #fff;text-align: center;"
                                    id="div_tool" runat="server">
                                    <div style="padding-top: 0px;">
                                        <span style="font-size: 15px; font-family: Arial Black; text-align: center;">
                                            <%# DataBinder.Eval(Container.DataItem, "Tool")%></span></div>
                                </div>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:DataList></div>
                </td>
                <td valign="top">
                  <div align="center" style="background-color:#85c8e7;height:50px;">
                        <span style="font-size: 25px; font-family: Arial Black; text-align: center; color: #fff;">
                            TMC</span>
                    </div>
                 <div style="background-color:#5289b2;">
                        <asp:DataList ID="ddl_tmc" runat="server" RepeatColumns="4" BorderColor="Beige" 
                            onitemdatabound="ddl_tmc_ItemDataBound">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                    Visible="false"></asp:Label>
                                <div style="height: 50px; width: 100px; cursor: pointer; border: solid 2px #fff;text-align: center;"
                                    id="div_tool" runat="server">
                                    <div style="padding-top: 0px;">
                                        <span style="font-size: 15px; font-family: Arial Black; text-align: center;">
                                            <%# DataBinder.Eval(Container.DataItem, "Tool")%></span></div>
                                </div>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:DataList></div>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <div>
                            <%--<asp:GridView ID="grid_abumaster" runat="server" BorderColor="AliceBlue" AutoGenerateColumns="false"
                                OnRowDataBound="grid_abumaster_RowDataBound" OnDataBound="OnDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Width="50" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="50" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID") %>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tool No">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_tool" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Tool") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Availability">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_avail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Availability") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Station">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_station" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Station") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_desc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Description") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Photo">
                                        <ItemTemplate>
                                            <asp:Image ID="ph_image" runat="server" Style="width: 150px; height: 100px;" onmouseover="fnZoomImage(this.src);"
                                                onmouseout="HideImage();" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="150" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="150" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Drawing">
                                        <ItemTemplate>
                                            <asp:Image ID="ph_drawing" Style="width: 145px; height: 100px;" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="150" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="150" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Retension Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_retine" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Rentime") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Issued On">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_issued" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Issuedon") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Station Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "StationQty") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Spare Availability">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_maintain" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Maintained") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Next Due">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_nextdue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nextdueon") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_status" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FeedBack">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_feedback" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                            <img id="img_feedback" runat="server" style="width: 50px; height: 50px;" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" BorderColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>--%>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divImage" class="zoomClass" style="">
        <div style="float:right;">
        <div ><span style="color:Blue; cursor:pointer;" onclick="javascript:HideImage();">Close</span></div>
        </div>
            <table style="">
                <tr>
                    <td valign="middle" align="center">
                        <img id="imgZoom" runat="server" style="display: none; height: 500px; width: 600px;"
                            alt="" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <div id="shadow" class="opaqueLayer">
        </div>
        <div id="question" class="questionLayer" style="width: 1000px;">
            <div style="float: right;">
                <span style="font-family: Arial; color: Blue; font-size: 15px; cursor: pointer;"
                    onclick="javascript:closepop();">Close</span>
            </div>
            <br />
            <div align="center">
                <table>
                    <tr>
                        <td colspan="2">
                            <div id="div_toolvalues">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center" style="width: 100px;">
                                <span style="color: #000; font-family: Arial Black; font-weight: bold; font-size: 15px;">
                                    Feed Back</span>
                            </div>
                        </td>
                        <td>
                            <div align="center">
                                <textarea id="txt_response" style="width: 800px; height: 50px;" runat="server"></textarea>
                            </div>
                        </td>
                    </tr>
                    <tr style="height: 20px;">
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div align="center">
                                <asp:ImageButton ID="btn_savefeed" runat="server" ImageUrl="../Menu_image/Submit.jpg"
                                    OnClick="btn_savefeed_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <input type="hidden" id="hdn_fid" name="hdn_fid" runat="server" />
    </form>
</body>
</html>
