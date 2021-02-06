<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="UnitMaster.aspx.cs" Inherits="ABU_Master" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script src="../JS/Abu.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
.<div>
        <div style="margin-top: 5px;">
            ....<table align="left">
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text="MBU /" valign="left" Font-Bold="true"
                            Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="TOOL MASTER" valign="left" Font-Bold="true"
                            Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <div>
            <table align="center">
                <tr>
                    <td align="left">
                        <span class="lablestyle">Unit Name</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td colspan="2">
                        <input type="text" id="txt_unitname" class="textboxstyle" runat="server" />
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="4">
                    </td>
                </tr>
                <tr style="height: 20px;">
                    <td colspan="4">
                        <div align="center" style="display: none; padding-left: 20px;" id="diverror1">
                            <span id="spn_error1" style="font-size: 14px; color: Red; font-family: Arial;"></span>
                        </div>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="4">
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="4">
                        <div align="center">
                            <div align="center" style="padding-left: 30px;" id="div_toolsave" runat="server">
                                <asp:ImageButton ID="btn_submit" runat="server" Text="Save" color="black" ImageUrl="~/Menu_image/Save.jpg"
                                    OnClick="btn_submit_Click" OnClientClick="return valunitmaster();"/>
                            </div>
                            <div align="center" style="padding-left: 30px; display: none;" id="div_toolupdate"
                                runat="server">
                                <asp:ImageButton ID="btn_update" runat="server" ImageUrl="~/Menu_image/Submit.jpg"
                                    Style="cursor: pointer;" OnClientClick="return valunitmaster();" OnClick="btn_update_Click" /></div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div align="center" id="div_cycle" runat="server">
        <table>
            <tr>
                <td>
                    <div>
                        <asp:GridView ID="grid_abumaster" runat="server" BorderColor="AliceBlue" AutoGenerateColumns="false">
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
                                        <asp:Label ID="lbl_id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MID") %>'
                                            Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit Value">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_tool" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MValue") %>'
                                            Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit Text">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_avail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MText") %>'
                                            Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ControlStyle-Width="50pt">
                                    <ItemTemplate>
                                        <a id="<%# Eval("MID") %>" onclick="javascript:edit_mastermbu(this.id);">
                                            <img src="../Images/Edit.jpg" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                                    <ItemTemplate>
                                        <a id="<%# Eval("MID") %>" onclick="javascript:delete_mastermbu(this.id);">
                                            <img src="../Images/Delete.png" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                    </div>
                    <input type="hidden" id="hdn_cycleid" runat="server" name="hdn_cycleid" />
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
        <input type="hidden" id="hdn_masterid" name="hdn_masterid" runat="server" />
    </div>
</asp:Content>
