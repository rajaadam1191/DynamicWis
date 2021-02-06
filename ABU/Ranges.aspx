<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ranges.aspx.cs" Inherits="ABU_Ranges" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PH :: TOOLS FEEDBACK</title>
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
$(function () {
            $('.search_textbox').each(function (i) {
                $(this).quicksearch("[id*=grid_abumaster] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });
function scroll(oid,iid){
            this.oCont=document.getElementById(oid)
            this.ele=document.getElementById(iid)
            this.width=this.ele.clientWidth;
            this.n=this.oCont.clientWidth;
            this.move=function(){
                this.ele.style.left=this.n+"px"
                this.n--
                if(this.n<(-this.width)){this.n=this.oCont.clientWidth}
            }
        }
        var vScroll
        function setup(){
            vScroll=new scroll("oScroll","scroll");
            setInterval("vScroll.move()",50)
        }
        onload=function(){setup()}
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
        }
        .Green
        {
            background-color: Green;
            border: medium none;
            color: White;
        }
        .Yellow
        {
            background-color: Yellow;
            color: black;
        }
        .Red
        {
            background-color: Red;
            color: White;
        }
        .textcolor
        {
            color: Black;
            font-style: normal;
            font-size: 15px;
            text-align: center;
        }
        .textcolor1
        {
            color: Blue;
            font-style: italic;
            font-size: 15px;
            text-align: center;
            cursor: pointer;
        }
    </style>
</head>
<body style="background-color: #1f497d;">
    <form id="form1" runat="server">
    <div>
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
            <img src="../Menu_image/poclainlogo.png" alt="" />
        </div>
        <div style="margin-top: 0px; margin-right: 10px; float: right;">
            <img src="../Menu_image/TLM-Logo.png" alt="" />
        </div>
        <div>
            <div>
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
                    <br />
                    <br />
                    <br />
                    <div>
                        <%--<table align="center">
                            <tr>
                                <td align="left">
                                    <span class="lablestyle">Tool Number</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList ID="txt_rtoolnumber" CssClass="dropdownstyle" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <span class="lablestyle">Station</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_rstation" class="textboxstyle" runat="server" />
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <span class="lablestyle">Retension Time</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_rretension" class="textboxstyle" runat="server" />
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <span class="lablestyle">Issued on</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_rissuedon" class="textboxstyle" runat="server" />
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <span class="lablestyle">Next Due On</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_rdueon" class="textboxstyle" runat="server" />
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <span class="lablestyle">Feed Back</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <textarea id="txt_rfeedback" runat="server" class="textboxstyle" style="height: 50px;"></textarea>
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                    <div align="center" style="display: none; padding-left: 20px;" id="diverror">
                                        <span id="spn_error" style="font-size: 14px; color: Red; font-family: Arial;"></span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div align="center">
                                        <asp:ImageButton ID="btn_save" runat="server" ImageUrl="../Menu_image/Submit.jpg"
                                            OnClick="btn_save_Click" OnClientClick="return valranges();" />
                                    </div>
                                </td>
                            </tr>
                        </table>--%>
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
                                            <asp:GridView ID="grid_abumaster" runat="server" BorderColor="AliceBlue" AutoGenerateColumns="false"
                                                OnRowDataBound="grid_abumaster_RowDataBound" OnDataBound="OnDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle BackColor="White" BorderColor="Black" HorizontalAlign="Center" />
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
                                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" Height="30" BorderColor="Black" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Station">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_avail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Station") %>'
                                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="FeedBack">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_feedback" runat="server" Style="font-size: 15px; text-align: center;"
                                                                Text='<%#DataBinder.Eval(Container.DataItem, "FeedBack") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Retension Time">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_desc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReTime") %>'
                                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Issued On">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_retine" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Issued") %>'
                                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Next Due">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_issued" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NextDue") %>'
                                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Response">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_reponser" runat="server" Style=""></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="divImage" class="zoomClass">
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
                </div>
            </div>
        </div>
        <input type="hidden" id="hdn_toid" name="hdn_toid" runat="server" />
    </div>
    </form>
</body>
</html>
