<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="FixtureChange.aspx.cs" Inherits="FixtureChange" Title="PH :: FIXTURE REPORTS"
    EnableEventValidation="false" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />
    <%--<script src="JS/jquery.easing.1.3.js" type="text/javascript"></script>--%>
    <%--<script src="JS/jquery.min.js" type="text/javascript"></script>--%>
    <link href="../Styles/Chart.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/quicksearch.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('.search_textbox').each(function (i) {
                $(this).quicksearch("[id*=grid_fixture] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });
    </script>

    <style >
        .search_textbox
        {
            text-align: center;
            border: solid 1px #000;
            width:100px;
        }
        .drop
        {
            width: 500px;
            height: 50px;
        }
        .tdclass
        {
            background-color:#fff;
            font-size:14px;
            font-family:Arial;
            font-weight:bold;
            border-bottom:solid 1px #000;
            text-align:center;
        }
        .trclass1
        {
            border:solid 1px gray;
        }
        .spn
        {
            font-size:14px;
            font-family:Arial;
            font-weight:bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div runat="server" id="div_chart" style="width: 1350px; background-color: #eefaff;"
        align="center">
        <ul class="tabs" data-persist="true">
            <li id="link_one"><a href="#"><span>Fixture Change</span></a></li>
        </ul>
        <div class="tabcontents" align="center" style="background-color: #eefaff;">
            
            <div id="view3">
                <div>
                    <div style="margin-left: -17px;">
                    <asp:GridView ID="GridView3" runat="server" BorderColor="AliceBlue" 
                                AutoGenerateColumns="false" onrowdatabound="GridView3_RowDataBound" OnDataBound="changeOnDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                        <ItemTemplate>
                                           <%-- <%# Container.DataItemIndex+1 %>--%>
                                           <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "IndexNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Fid") %>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_fixture" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Fixturename") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" Height="30" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Model Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_model" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Model") %>'
                                                Style="font-size: 20px; text-align: center;" ></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" Height="30" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Part Number">
                                        <ItemTemplate>
                                        <div style="word-wrap: break-word; width: 120px;font-size: 20px; text-align: center;">
                                            <asp:Label ID="lbl_part" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Partno") %> '
                                                Style="font-size: 20px; text-align: center;" ></asp:Label>
                                                </div>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Life">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_life" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FixLife") %> '
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Operation">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_oper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Operation") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Spare Availability">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_spare" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "currentstock") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Photo">
                                        <ItemTemplate>
                                            <asp:Image ID="ph_image" Style="width: 150px; height: 100px;" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="150" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="150" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Count">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_fixcount" runat="server" Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_remarks" runat="server" Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Calibration Done On">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_modify" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModifyDate") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                </div></div>
                
                                <div>
                    <table style="padding-top: 20px;">
                        <tr>
                            <td>
                                <div id="div_paging" runat="server">
                                    <table>
                                        <tr>
                                            <td class="square_selected">
                                                <asp:LinkButton ID="link_previous" runat="server" Font-Underline="false" OnClick="link_previous_Click">Previous</asp:LinkButton>
                                            </td>
                                            <td>
                                            </td>
                                            <td class="">
                                                <div style="margin-top: -2px;">
                                                    <asp:DataList ID="DataListPaging" runat="server" RepeatDirection="Horizontal" OnItemDataBound="DataListPaging_ItemDataBound"
                                                        OnItemCommand="DataListPaging_ItemCommand">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="link_pagebtn" runat="server" CommandName="newpage" CommandArgument='<%# Eval("PageIndex") %>'
                                                                Text='<%# Eval("PageText") %> ' Style="text-decoration: none; color: Black"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                            </td>
                                            <td>
                                            </td>
                                            <td class="square_selected">
                                                <asp:LinkButton ID="link_next" runat="server" Font-Underline="false" OnClick="link_next_Click"
                                                    ForeColor="Blue">Next</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div align="center" id="div_pdf" runat="server" visible="false">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <div>
                                        <asp:ImageButton ImageUrl="~/Menu_image/Excel.jpg" runat="server" ID="btn_pdf" OnClick="btn_pdf_Click" /></div>
                                </td>
                                <td style="width:100px;"></td>
                                <td>
                                    <div>
                                        <asp:ImageButton ImageUrl="~/Menu_image/print.jpg" runat="server" 
                                            ID="btn_print" onclick="btn_print_Click" /></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                
            </div>
        </div>
        <input type="hidden" id="hdn_part" name="hdn_part" runat="server" />
        <input type="hidden" id="hdn_fix" name="hdn_fix" runat="server" />
        <input type="hidden" id="hdn_op" name="hdn_op" runat="server" />
        <input type="hidden" id="hdn_mach" name="hdn_part" runat="server" />
        <input type="hidden" id="hdn_part1" name="hdn_part1" runat="server" />
        <input type="hidden" id="hdn_fix1" name="hdn_fix1" runat="server" />
        <input type="hidden" id="hdn_op1" name="hdn_op1" runat="server" />
        <input type="hidden" id="hdn_mach1" name="hdn_mach1" runat="server" />
        <input type="hidden" id="hdn_year" name="hdn_year" runat="server" />
        <input type="hidden" id="hdn_month" name="hdn_month" runat="server" />
    </div>
</asp:Content>
