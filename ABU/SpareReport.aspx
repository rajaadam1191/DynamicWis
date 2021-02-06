<%@ Page Language="C#" MasterPageFile="~/AbuMaster.master" AutoEventWireup="true" enableEventValidation ="false"
    CodeFile="SpareReport.aspx.cs" Inherits="ABU_FeedBackReport" Title="PH :: FeedBack Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../JS/Abu.js" type="text/javascript"></script>
 <script src="../JS/quicksearch.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    $(document).ready(function()
{
    // $("input[id$='txt_fromdate']").datepick({maxDate: 31,dateFormat: 'dd/mm/yyyy'});
    // $("input[id$='txt_todate']").datepick({maxDate: 31,dateFormat: 'dd/mm/yyyy'});
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
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <div style="margin-top: 50px; margin-left:600px;"  align="center" >
            <table align="left">
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text="ABU /" valign="left" Font-Bold="true"
                            Font-Size="30px" ForeColor="White" Font-Names="Arial"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="SPARE REPORT" valign="left" Font-Bold="true"
                            Font-Size="20px" ForeColor="White" Font-Names="Arial"></asp:Label>
                    </td>
                    <td>
                        <div style="padding-left:300px;">
                        <asp:ImageButton ID="btn_excel" runat="server" Text="Excel" color="black" 
                                ImageUrl="~/Menu_image/Export.png" OnClick = "ExportToPDF"
                           />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <%--<div style="margin-left: -10px; margin-top: -10px;">
            <table align="center">
                <tr>
                    <td align="left">
                        <span class="lablestyle">From</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="text" id="txt_fromdate" runat="server" class="textboxstyle" style="width: 218px;" />
                    </td>
                    <td style="width: 30px;">
                    </td>
                    <td align="left">
                        <span class="lablestyle">To</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="text" id="txt_todate" runat="server" class="textboxstyle" style="width: 218px;" />
                    </td>
                </tr>
            </table>
        </div>--%>
        <br />
        <br />
        <%--<div style="margin-left: 50px;" align="center">
            <asp:ImageButton ID="btn_search" runat="server" ImageUrl="~/Menu_image/view.jpg"
                OnClientClick="return valdate();" OnClick="btn_search_Click1" />
        </div>--%>
    </div>
   
    <div align="center">
        <table>
            <tr>
                <td>
                    <div>
                        <asp:GridView ID="grid_abumaster" runat="server" BorderColor="AliceBlue" 
                            AutoGenerateColumns="false" ondatabound="OnDataBound">
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
                                        <asp:Label ID="lbl_id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SID") %>'
                                            Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tool Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_tool" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Tool") %>'
                                            Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Spare Maximum">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_station" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Maximum") %>'
                                            Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Spare Minimum">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_desc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Minimum") %>'
                                            Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Current Stock">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_issued" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TotalCount") %>'
                                            Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
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
</asp:Content>
