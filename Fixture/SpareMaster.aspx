<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="SpareMaster.aspx.cs" Inherits="ABU_SpareMAster" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../JS/Abu.js" type="text/javascript"></script>
<script type="text/javascript">
function onlyNumbers(evt) {
    var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)&& charCode != 46){
    alert("Accept only number !!");
        return false;
        }
        else{
    return true;
    }
}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <div style="margin-top: 5px;">
            <table align="left">
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text="MBU /" valign="left" Font-Bold="true"
                            Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="SPARE MASTER" valign="left" Font-Bold="true"
                            Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
    </div>
    <div style="">
        <div>
            <table align="center">
                <tr style="display:none">
                    <td align="left">
                        <span class="lablestyle">Part No</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_partnumber" CssClass="dropdownstyle" runat="server" OnSelectedIndexChanged="ddl_partnumber_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span class="lablestyle">Tool Number</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_toolnumber" CssClass="dropdownstyle" runat="server" OnSelectedIndexChanged="ddl_toolnumber_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span class="lablestyle">Spare Maximum</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="text" id="txt_maximum" class="textboxstyle" runat="server" onkeypress="return onlyNumbers(this);"/>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span class="lablestyle">Spare Minimum</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="text" id="txt_minimum" class="textboxstyle" runat="server" onkeypress="return onlyNumbers(this);"/>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span class="lablestyle">Spare Count</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="text" id="txt_sparecount" class="textboxstyle" runat="server" onkeypress="return onlyNumbers(this);"/>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="3">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <div align="center" style="display: none; padding-left: 20px;" id="diverror">
            <span id="spn_error" style="font-size: 14px; color: Red; font-family: Arial;"></span>
        </div>
        <br />
        <br />
        <div align="center" style="padding-left: 30px;" id="div_save" runat="server">
            <asp:ImageButton ID="btn_submit" runat="server" Text="Save" color="black" ImageUrl="~/Menu_image/Save.jpg"
                OnClientClick="return valsparembu();" OnClick="btn_submit_Click" />
        </div>
        <div align="center" style="padding-left: 30px; display: none;" id="div_update" runat="server">
            <asp:ImageButton ID="btn_update" runat="server" ImageUrl="~/Menu_image/Submit.jpg"
                Style="cursor: pointer;" OnClientClick="return valsparembu();" OnClick="btn_update_Click1" /></div>
    </div>
    <br />
    <br />
    <br />
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
                    <asp:Label ID="lbl_id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SID") %>'
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
                <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
            </asp:TemplateField>
<%--             <asp:TemplateField HeaderText="Part No">
                <ItemTemplate>
                    <asp:Label ID="lbl_part" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Partno") %>'
                        Style="font-size: 15px; text-align: center;"></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Spare Maximum">
                <ItemTemplate>
                    <asp:Label ID="lbl_station" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Maximum") %>'
                        Style="font-size: 15px; text-align: center;"></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Spare Minimum">
                <ItemTemplate>
                    <asp:Label ID="lbl_desc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Minimum") %>'
                        Style="font-size: 15px; text-align: center;"></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Spare Count">
                <ItemTemplate>
                    <asp:Label ID="lbl_issued" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TotalCount") %>'
                        Style="font-size: 15px; text-align: center;"></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit" ControlStyle-Width="50pt">
                <ItemTemplate>
                    <a id="<%# Eval("SID") %>" onclick="javascript:editsparemastermbu(this.id);">
                        <img src="../Images/Edit.jpg" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                    </a>
                </ItemTemplate>
                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                <ItemTemplate>
                    <a id="<%# Eval("SID") %>" onclick="javascript:deletesparemastermbu(this.id);">
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
    <input type="hidden" id="hdn_spareid" name="hdn_spareid" runat="server" />
    </div>
</asp:Content>
