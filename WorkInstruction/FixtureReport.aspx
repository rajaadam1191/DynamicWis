<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FixtureReport.aspx.cs" EnableEventValidation="false"
    Inherits="FixtureReport" Debug="true" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PH :: PD UPLOAD</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../../favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" href="../css/style.css" type="text/css" media="screen" />
    <link href="../Styles/StylemenuWI.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Chart.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/QualitySheetscript.js" type="text/javascript"></script>

    <script src="../JS/Common.js" type="text/javascript"></script>

    <script src="../JS/jquery.easing.1.3.js" type="text/javascript"></script>

    <script src="../JS/masterfile.js" type="text/javascript"></script>

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('.search_textbox').each(function (i) {
                $(this).quicksearch("[id*=GridView1] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });
          
    </script>

    <style>
        .search_textbox
        {
            text-align: center;
            border: solid 1px #000;
        }
        .drop
        {
            width: 500px;
            height: 20px;
        }
    </style>
</head>
<body>
    <form runat="server">
    <div style="margin-top: -8px;">
        <table cellpadding="0px" cellspacing="0px" border="0px" align="center" width="100%"
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
                    <div id="super_admin" runat="server">
                        <div id="wrap2">
                            <ul class="navbar2">
                                <li><a href="#">MASTER</a>
                                    <ul>
                                        <li><a href="../Master/Process.aspx" id="link_process">FILE UPLOAD</a> </li>
                                        <li>
                                            <%--<a href="../Master/PartNoMaster.aspx" id="link_part"  >OFARTICLES</a>--%></li>
                                        <li><a href="../Master/PlannedStopEntry.aspx" id="link_planned">PLANNED STOP ENTRY</a></li>
                                        <li><a href="../Master/BarcodeTemplate.aspx" id="link_barcode">BARCODE TEMPLATE</a></li>
                                        <li><a href="../Master/DowntimeTemplate.aspx">DOWNTIMELOSS TEMPLATE</a></li>
                                        <%--<li><a href="../Master/SpeedLossTemplate.aspx">SPEEDLOSS TEMPLATE</a></li>--%>
                                        <li><a href="../Master/MasterFile.aspx">CYCLE TIME ENTRY</a></li>
                                        <li><a href="../Master/LaborEfficiency.aspx">LABOR EFFICIENCY</a></li>
                                        <li>
                                            <%--<a href="../Master/AddPages.aspx">ADD PAGES</a>--%></li>
                                        <li>
                                            <%--<a href="../Master/Time_Master.aspx">TIME MASTER</a>--%></li>
                                        <li><a href="../Master/ActualTimeEntry.aspx">ADD FIXED TIME</a></li>
                                        <li style="border-bottom: 1px solid #54879d;"><a href="../Master/FixtureValues.aspx">
                                            ADD FIXTURE VALUES</a></li>
                                    </ul>
                                </li>
                                <li><a href="#">PRODUCTION DOCUMENT</a>
                                    <ul>
                                        <li><a href="../Master/Process.aspx" id="A1">FILE UPLOAD</a> </li>
                                        <li><a href="Workinstruction.aspx">PD UPLOAD</a></li>
                                        <li><a href="Userpage.aspx">PD VIEW</a></li>
                                        <li><a href="RegisrationFrm.aspx">REGISTRATION FORM</a></li>
                                        <li style="border-bottom: 1px solid #54879d;"><a href="DMTTemplate.aspx">DMT TEMPLATE</a></li>
                                    </ul>
                                </li>
                                <li><a href="#">PRODUCTION DATA</a>
                                    <ul>
                                        <li><a href="../QualityGrid/QualityGrid.aspx">A17724Q-Operation1</a></li>
                                        <li><a href="../QualityGrid/opt2QSheetA17724Q.aspx">A17724Q-Operation2</a></li>
                                        <li><a href="../QualityGrid/lapping24Q.aspx">A17724Q-lapping</a></li>
                                        <li><a href="../QualityGrid/polishing24Q.aspx">A17724Q-polishing</a></li>
                                        <li><a href="../QualityGrid/QSA22916J.aspx">A22916J-Operation1</a> </li>
                                        <li><a href="../QualityGrid/opt2QSheetA22916J.aspx">A22916J-Operation2</a></li>
                                        <li><a href="../QualityGrid/polishingA22916J.aspx">A22916J-polishing</a></li>
                                        <li><a href="../QualityGrid/QualitySheetA32271C.aspx">A32271C-Operation1</a></li>
                                        <li><a href="../QualityGrid/polishingA32271C.aspx">A32271C-Polishing</a></li>
                                        <li><a href="../QualityGrid/QualitySheetA44908N.aspx">A44908N-Operation1</a> </li>
                                        <li><a href="../QualityGrid/polishingA44908N.aspx">A44908N-Polishing</a></li>
                                        <li><a href="../QualityGrid/qualitysheetA44983u.aspx">A44983U-Operation1</a></li>
                                        <li style="border-bottom: 1px solid #54879d;"><a href="../QualityGrid/polishingA44983U.aspx">
                                            A44983U-Polishing</a></li>
                                    </ul>
                                </li>
                                <li>
                                    <%--<a href="../Productions/DownTimeLoss.htm">DOWN TIME LOSS</a>--%></li>
                                <li><a href="#">REPORTS</a>
                                    <ul>
                                        <li><a href="../Reports/ViewAllReports.aspx">All REPORT</a></li>
                                        <li><a href="../Reports/Defaultchart.aspx">PLANT EFFICIENCY</a></li>
                                        <li><a href="../QualityGrid/ViewQCSheetReports.aspx">VIEW QC REPORT</a></li>
                                        <li><a href="../Reports/MC_REPORT.aspx">PLANT OEE/LET</a></li>
                                        <li style="border-bottom: 1px solid #54879d;"><a href="../Reports/FixtureReport.aspx">
                                            FIXTURE REPORT</a></li>
                                    </ul>
                                </li>
                                <li><a href="#" onclick="javascript:exituser();">LOG OUT</a> </li>
                            </ul>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-top: 5px;">
        <table align="left">
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="PRODUCTION DOCUMENT /" valign="left"
                        Font-Bold="true" Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="PD UPLOAD" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <div align="center">
        <ul class="tabs" data-persist="true">
            <li id="link_one"><a href="#view1"><span>Fixture History</span></a></li>
            <li id="link_two"><a href="#"><span>Calibration Trend</span></a></li>
        </ul>
        <div class="tabcontents" align="center" style="background-color: #eefaff;">
            <div id="view1">
                <div style="margin:20px 10px 50px 10px;">
                <table>
                    <tr>
                        <td>
                            <span class="lablestyle">Part No</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <div>
                                <asp:DropDownCheckBoxes ID="ddchkCountry" runat="server" AddJQueryReference="True"
                                    UseSelectAllNode="True" CssClass="drop" 
                                    onselectedindexchanged="ddchkCountry_SelectedIndexChanged" 
                                    ontextchanged="ddchkCountry_TextChanged">
                                    <Style2 SelectBoxCssClass="drop"></Style2>
                                    <Texts SelectBoxCaption="--- Select Part No ---" />
                                </asp:DropDownCheckBoxes>
                                <asp:Label ID="partnoid" runat="server"></asp:Label><br />
                                <asp:Label ID="partname" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr style="height: 10px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="lablestyle">Operation</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <div>
                                <asp:DropDownList ID="ddl_operation" runat="server" CssClass="drop">
                                    <asp:ListItem Value="0" Selected="True">--- Select Operation ---</asp:ListItem>
                                    <asp:ListItem Value="1">FIRST</asp:ListItem>
                                    <asp:ListItem Value="2">SECOND</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr style="height: 10px;">
                        <td colspan="3">
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <span class="lablestyle">Fixture No</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <div>
                                <asp:DropDownList ID="ddl_fixno" runat="server" CssClass="drop">
                                    <asp:ListItem Value="0" Selected="True">--- Select Fixture No ---</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr style="height: 10px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="lablestyle">Machine</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <div>
                                <asp:DropDownList ID="ddl_machine" runat="server" CssClass="drop">
                                    <asp:ListItem Value="0" Selected="True">--- Select Machine ---</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                     <tr style="height: 30px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr style="height: 10px;">
                        <td colspan="3">
                            <div align="center">
                                <asp:ImageButton ID="ImageButton1" ImageUrl="~/Menu_image/Submit.jpg" runat="server" OnClick="Unnamed1_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
                </div>
                <div style="margin-left: -17px;">
                    <asp:GridView ID="GridView1" runat="server" Width="630px" BorderColor="AliceBlue"
                        AutoGenerateColumns="false" OnDataBound="OnDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.No" HeaderStyle-ForeColor="#FFFFFF">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_sno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" Height="30" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Part No">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_process" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Partno") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Height="25" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Operation">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Operation") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fixture No">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Fixtureno") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Alter Date for Fixture Calibration">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "YellowOpenDate") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fixture Calibrated Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "YellowCloseDate") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fixture Life Completed Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RedOpenDate") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Calibration Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "YellowStatus") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div id="view2" style="display: none;">
                <div>
                    Two</div>
            </div>
            <div id="view3" style="display: none;">
                <div>
                    Three</div>
            </div>
        </div>
        <input type="hidden" id="hdn_user" name="hdn_user" runat="server" />
    </div>
    </form>
</body>
