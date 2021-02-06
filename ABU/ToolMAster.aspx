<%@ Page Language="C#" MasterPageFile="~/AbuMaster.master" AutoEventWireup="true"
    CodeFile="ToolMAster.aspx.cs" Inherits="ABU_ToolMAster" Title="PH :: Tool Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
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
                $(this).quicksearch("[id*=grid_abumtoolaster] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });

    </script>
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
                        <asp:Label ID="Label6" runat="server" Text="TOOL MASTER" valign="left" Font-Bold="true"
                            Font-Size="20px" ForeColor="White" Font-Names="Arial"></asp:Label>
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
                        <span class="lablestyle" style="color:#fff;">Unit</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddl_unit" CssClass="dropdownstyle" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span class="lablestyle" style="color:#fff;">Tool Type</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddl_tooltype" CssClass="dropdownstyle" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span class="lablestyle" style="color:#fff;">Line/ MAchine</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddl_line" CssClass="dropdownstyle" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span class="lablestyle" style="color:#fff;">Tool Number</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td colspan="2">
                        <input type="text" id="txt_toolno" class="textboxstyle" runat="server" onkeypress="return onlyNumbers(this);"/>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span class="lablestyle" style="color:#fff;">Calibration Due</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td colspan="2">
                        <input type="text" id="txt_tredension" class="textboxstyle" runat="server" onkeypress="return onlyNumbers(this);"/>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span class="lablestyle" style="color:#fff;">Green Range</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="text" id="txt_gfrom" class="textboxstyle" style="width: 215px;" runat="server" onkeypress="return onlyNumbers(this);"/>
                    </td>
                    <td>
                        <input type="text" id="txt_gto" class="textboxstyle" style="width: 215px;" runat="server" onkeypress="return onlyNumbers(this);"/>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span class="lablestyle" style="color:#fff;">Yellow Range</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="text" id="txt_yfrom" class="textboxstyle" style="width: 215px;" runat="server" onkeypress="return onlyNumbers(this);" />
                    </td>
                    <td>
                        <input type="text" id="txt_yto" class="textboxstyle" style="width: 215px;" runat="server" onkeypress="return onlyNumbers(this);" />
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span class="lablestyle" style="color:#fff;">Red Range</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="text" id="txt_rfrom" class="textboxstyle" style="width: 215px;" runat="server" onkeypress="return onlyNumbers(this);" />
                    </td>
                    <td>
                        <input type="text" id="txt_rto" class="textboxstyle" style="width: 215px;" runat="server" onkeypress="return onlyNumbers(this);" />
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
                                    OnClick="btn_submit_Click" OnClientClick="return validateabutool();" />
                            </div>
                            <div align="center" style="padding-left: 30px; display: none;" id="div_toolupdate"
                                runat="server">
                                <asp:ImageButton ID="btn_update" runat="server" ImageUrl="~/Menu_image/Submit.jpg"
                                    Style="cursor: pointer;" OnClick="btn_update_Click" OnClientClick="return validateabutool();" /></div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <div align="center" id="div_cycle" runat="server">
            <table>
                <tr>
                    <td>
                        <div>
                            <asp:GridView ID="grid_abumtoolaster" runat="server" BorderColor="AliceBlue" 
                                AutoGenerateColumns="false" ondatabound="OnDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "IndexNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
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
                                            <asp:Label ID="lbl_tool" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ToolNumber") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" Height="30" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Calibration Due">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_avail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RetensionTime") %> '
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Green From">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_avail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Gfrom") %> '
                                                Style="font-size: 20px; text-align: center;"></asp:Label><span>%</span>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="Green" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Green To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_station" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Gto") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label><span>%</span>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="Green" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Yellow From">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_desc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Yfrom") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label><span>%</span>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="Yellow" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Yellow To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_retine" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Yto") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label><span>%</span>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="Yellow" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Red From">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_issued" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Rfrom") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label><span>%</span>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="Red" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Red To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Rto") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label><span>%</span>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="Red" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ControlStyle-Width="50pt">
                                        <ItemTemplate>
                                            <a id="<%# Eval("ID") %>" onclick="javascript:edittool(this.id);">
                                                <img src="../Images/Edit.jpg" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                            </a>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                                        <ItemTemplate>
                                            <a id="<%# Eval("ID") %>" onclick="javascript:deletetool(this.id);">
                                                <img src="../Images/Delete.png" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                            </a>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
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
    </div>
    <input type="hidden" id="hdn_toolid" name="hdn_toolid" runat="server" />
</asp:Content>
