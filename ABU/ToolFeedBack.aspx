<%@ Page Language="C#" MasterPageFile="~/AbuMaster.master" AutoEventWireup="true" enableEventValidation ="false"
    CodeFile="ToolFeedBack.aspx.cs" Inherits="ABU_ToolFeedBack" Title="PH :: Tool FeedBack Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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

    </script>
    <style type="text/css">
         .search_textbox
        {
            text-align: center;
            border: solid 1px #000;
            width:100px;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
     <div style="margin-top: 50px; margin-left:600px;"  align="center" >
        <table align="left">
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="ABU /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="White" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="FEEDBACK" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="White" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <div style="padding-left: 300px;">
                        <asp:ImageButton ID="btn_excel" runat="server" Text="Excel" color="black" ImageUrl="~/Menu_image/Export.png"
                            OnClick="ExportToPDF" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <div align="center" id="div_cycle" runat="server">
        <table>
            <tr>
                <td>
                    <div>
                        <div>
                            <asp:GridView ID="grid_abumaster" runat="server" BorderColor="AliceBlue" AutoGenerateColumns="false"
                                OnRowDataBound="grid_abumaster_RowDataBound" ondatabound="OnDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "IndexNo") %>'></asp:Label>
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
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" Height="30"  BackColor="White" BorderColor="Black"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Station">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_avail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Station") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FeedBack">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_feedback" runat="server" Style="font-size: 15px; text-align: center;"
                                                Text='<%#DataBinder.Eval(Container.DataItem, "FeedBack") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Request Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_reqdate" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Response Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_resdate" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Retension Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_desc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReTime") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Issued On">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_retine" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Issued") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Next Due">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_issued" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NextDue") %>'
                                                Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Response">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_reponser" runat="server" Style=""></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
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
    <div>
        <div id="shadow" class="opaqueLayer">
        </div>
        <div id="question" class="questionLayer">
            <div align="center">
                <table>
                    <tr>
                        <td>
                            <textarea id="txt_response" style="width: 300px; height: 50px;" runat="server"></textarea>
                        </td>
                    </tr>
                    <tr style="height: 20px;">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
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
    <div>
        <input type="hidden" id="hdn_fid" name="hdn_fid" runat="server" />
    </div>
</asp:Content>
