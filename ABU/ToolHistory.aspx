<%@ Page Language="C#" MasterPageFile="~/AbuMaster.master" AutoEventWireup="true"
    CodeFile="ToolHistory.aspx.cs" Inherits="ToolHistory" Title="PH :: Tool Change Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
 <script src="../JS/quicksearch.js" type="text/javascript"></script>

    <script src="../JS/Abu.js" type="text/javascript"></script>
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
                    <td style="width:200px;">
                        <asp:Label ID="Label6" runat="server" Text="Tool History Report" valign="left" Font-Bold="true"
                            Font-Size="20px" ForeColor="White" Font-Names="Arial"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <div style="margin-left: 150px;" align="center">
            <table>
                <tr>
                    <td style="width:150px;color:White">
                        Tool Number
                    </td>
                    <td style="color:White">
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="txt_toolnumber" CssClass="dropdownstyle" runat="server" OnSelectedIndexChanged="txt_toolnumber_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
        <div ><table><tr><td style="color:White"><asp:Label id="spn_toolC" runat="server" visible="false">Tool History</asp:Label></td></tr></table></div>
         <br />
    <div align="center" id="div_toolgrid">
        <asp:GridView ID="grid_abumaster" runat="server" BorderColor="AliceBlue" AutoGenerateColumns="false"
            OnRowDataBound="grid_abumaster_RowDataBound" Width="1250" 
            ondatabound="OnDataBound">
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
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Availability">
                    <ItemTemplate>
                        <asp:Label ID="lbl_avail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Availability") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Station">
                    <ItemTemplate>
                        <asp:Label ID="lbl_station" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Station") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lbl_desc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Description") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Photo">
                    <ItemTemplate>
                        <asp:Image ID="ph_image" Style="width: 150px; height: 100px;" runat="server" />
                    </ItemTemplate>
                    <HeaderStyle Width="150" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="150" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Retension Time">
                    <ItemTemplate>
                        <asp:Label ID="lbl_retine" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Issued On">
                    <ItemTemplate>
                        <asp:Label ID="lbl_issued" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Issuedon") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Station Qty">
                    <ItemTemplate>
                        <asp:Label ID="lbl_qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "StationQty") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Maintained">
                    <ItemTemplate>
                        <asp:Label ID="lbl_maintain" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Maintained") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Next Due">
                    <ItemTemplate>
                        <asp:Label ID="lbl_nextdue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nextdueon") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="lbl_remarks" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Calibration Done On">
                    <ItemTemplate>
                        <asp:Label ID="lbl_calibrationdone" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModifyDate") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <%-- <asp:TemplateField HeaderText="Edit" ControlStyle-Width="50pt">
                    <ItemTemplate>
                        <a id="<%# Eval("ID") %>" onclick="javascript:editmaster(this.id);">
                            <img src="../Images/Edit.jpg" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                    <ItemTemplate>
                        <a id="<%# Eval("ID") %>" onclick="javascript:deletemaster(this.id);">
                            <img src="../Images/Delete.png" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </div>
    
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
        <br />
        <div ><table><tr><td style="color:White"><asp:Label id="spn_toolf" runat="server" visible="false">Tool Feedback</asp:Label></td></tr></table></div>
         <br />
    <div align="center">
        <asp:GridView ID="GridView1" runat="server" BorderColor="AliceBlue" AutoGenerateColumns="false"
            OnRowDataBound="GridView1_RowDataBound" >
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
                <asp:TemplateField HeaderText="Tool Number">
                    <ItemTemplate>
                        <asp:Label ID="lbl_tool" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Tool") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" HorizontalAlign="Center" Height="30" BackColor="White" BorderColor="Black" />
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
                <asp:TemplateField HeaderText="Request Date">
                    <ItemTemplate>
                        <asp:Label ID="lbl_reqdate" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Response Date">
                    <ItemTemplate>
                        <asp:Label ID="lbl_resdate" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
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
</asp:Content>
