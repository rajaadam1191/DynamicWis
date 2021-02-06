<%@ Page Language="C#" MasterPageFile="~/AbuMaster.master" AutoEventWireup="true"
    CodeFile="MailFormat.aspx.cs" Inherits="ABU_MailFormat" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../JS/Abu.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
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
                        <asp:Label ID="Label6" runat="server" Text="MASTER MAIL" valign="left" Font-Bold="true"
                            Font-Size="20px" ForeColor="White" Font-Names="Arial"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
    </div>
    <div>
        <table align="center">
            <tr>
                <td align="left">
                    <span class="lablestyle" style="color: #fff;">User Name</span>
                </td>
                <td>
                    :
                </td>
                <td colspan="2">
                    <input type="text" id="txt_musername" class="textboxstyle" runat="server" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <span class="lablestyle" style="color: #fff;">Password</span>
                </td>
                <td>
                    :
                </td>
                <td colspan="2">
                    <input type="password" id="txt_mpassword" class="textboxstyle" runat="server" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <span class="lablestyle" style="color: #fff;">Port</span>
                </td>
                <td>
                    :
                </td>
                <td colspan="2">
                    <input type="text" id="txt_mport" class="textboxstyle" runat="server" />
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
                                OnClick="btn_submit_Click" />
                        </div>
                        <div align="center" style="padding-left: 30px; display: none;" id="div_toolupdate"
                            runat="server">
                            <asp:ImageButton ID="btn_update" runat="server" ImageUrl="~/Menu_image/Submit.jpg"
                                Style="cursor: pointer;" OnClick="btn_update_Click" /></div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div align="center">
        <asp:GridView ID="grid_abumaster" runat="server" BorderColor="AliceBlue" AutoGenerateColumns="false">
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
                <asp:TemplateField HeaderText="User Name">
                    <ItemTemplate>
                        <asp:Label ID="lbl_tool" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Username") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Password">
                    <ItemTemplate>
                        <asp:Label ID="lbl_avail" runat="server" Text="********"
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Port">
                    <ItemTemplate>
                        <asp:Label ID="lbl_avail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Port") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit" ControlStyle-Width="50pt">
                    <ItemTemplate>
                        <a id="<%# Eval("ID") %>" onclick="javascript:editmail(this.id);">
                            <img src="../Images/Edit.jpg" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                    <ItemTemplate>
                        <a id="<%# Eval("ID") %>" onclick="javascript:deletemail(this.id);">
                            <img src="../Images/Delete.png" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <input type="hidden" id="hdn_mid" name="hdn_mid" runat="server" />
    </div>
</asp:Content>
