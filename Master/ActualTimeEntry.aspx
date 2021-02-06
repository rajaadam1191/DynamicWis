<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="ActualTimeEntry.aspx.cs" Inherits="Master_ActualTimeEntry" Title="PH :: ADD FIXED TIME" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../JS/ActualEntry.js" type="text/javascript"></script>
<script type="text/javascript">
    function HandleKey() {
k = document.getElementById('searchbox');
keys = k.value;
if (keys.length > 3) {
FindKey(keys);
}
}

function FindKey(keys) {
// Returns a collection of objects with the specified element name.
opts = selects.getElementsByTagName('option');

for (i = opts.length-1; i >=0; i--) {
    //alert(i + ". option= " + opts.item(i).text + " searching= " + keys);
//    alert(opts.item(i).text.substr(opts.item(i).text.length - 1, keys.length));
    //    alert(parseFloat(opts.item(i).text.length)-1);
    val = "";
    var val = opts.item(i).text.substr(opts.item(i).text.length - 4, keys.length);
    val = val + opts.item(i).text.substr(opts.item(i).text.length - 3, keys.length);
    val = val + opts.item(i).text.substr(opts.item(i).text.length - 2, keys.length);
    val = val + opts.item(i).text.substr(opts.item(i).text.length - 1, keys.length);
    // alert(val);

val=val.toUpperCase();
     if (val.substr(0, 4) == keys.toUpperCase()) {
// Select the option opts.item(i)
selects.selectedIndex = i;
$('#ddl_partno').focus();
return true;
}
}
}

    function AttachSearch(id) {
// Returns a reference to the [select] element tag.
el = document.getElementById(id);

// Creates an instance of the element for the specified tag and returns a reference to the new element.
searchbox = document.createElement('input');
searchbox.id = 'searchbox';
searchbox.style['width'] = '40px';
$('#searchbox').focus();
searchbox.onkeypress = function() { setTimeout('HandleKey();', 10); };
// Returns a collection of objects with the specified element name.
selects = el.getElementsByTagName('select').item(0);

// Returns a reference to the element that is inserted into the document.
el.insertBefore(searchbox, selects);
}

  onload=function(){AttachSearch('searchit');}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div style="margin-top: -30px;">
        <table>
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label7" runat="server" Text="MASTER /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="ADD FIXED TIME" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div align="center" style="margin-top: -20px">
        <table width="800">
            <tr>
                <td>
                    <div style="padding: 10px 10px 10px 80px;">
                        <table>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label1" runat="server" Text="PART NO" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td> <div id="searchit">
                                    <select id="ddl_partno" runat="server" class="dropdownstyle" style="width:398px;">
                                    </select></div>
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label2" runat="server" Text="PROCESS" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <select id="ddl_process" runat="server" class="dropdownstyle">
                                    </select>
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label runat="server" Text="SHIFT" Style="font-family: Times New Roman;" CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <select id="ddl_shift" runat="server" class="dropdownstyle" onchange="javascript:validate_Ashift();">
                                        <option value="0" selected="selected">-Select-</option>
                                        <option value="A">A</option>
                                        <option value="B">B</option>
                                        <option value="C">C</option>
                                        <%--<option value="G">G</option>
                                        <option value="A1">A1</option>
                                        <option value="B1">B1</option>--%>
                                    </select>
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label3" runat="server" Text="FIXED TIME" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_fixedtime" runat="server" class="textboxstyle"  readonly="readonly" />
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <%--<tr>
                                <td>
                                    <b>
                                        <asp:Label ID="Label6" runat="server" Text="PRODUCED QUANTITY" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_prdquty" runat="server" class="textboxstyle" />
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>--%>
                            <tr style="height: 10px;">
                                <td colspan="3" align="center">
                                    <div id="div_error" style="display: none; padding-left: 100px;">
                                        <span id="spnerror" style="font-family: Arial; font-size: 14px; color: Red;"></span>
                                    </div>
                                </td>
                            </tr>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                    <div align="center" style="padding-left: 100px;" id="div_save" runat="server">
                                        <asp:ImageButton ID="btn_submit" runat="server" ImageUrl="~/Menu_image/Save.jpg"
                                            OnClick="btn_submit_Click" OnClientClick="return validate_Actualentry();" />
                                    </div>
                                    <div align="center" style="padding-left: 30px; display: none;" id="div_update" runat="server">
                                        <asp:ImageButton ID="btn_update" runat="server" ImageUrl="~/Menu_image/Submit.jpg"
                                            OnClientClick="return validate_Actualentry();" Style="cursor: pointer;" OnClick="btn_update_Click1" /></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div align="center" id="div_actual" runat="server">
        <table style="">
            <tr>
                <td>
                    <div>
                        <asp:GridView ID="gridprdqty" runat="server" Width="630px" BorderColor="AliceBlue"
                            AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_sno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <%--  <asp:TemplateField HeaderText="S.No" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_aid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AID") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle BackColor="White" BorderColor="" HorizontalAlign="Center" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Part No">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_partno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PartNo") %>'
                                            Style="font-size: 12px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Operation">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_process" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Process") %>'
                                            Style="font-size: 12px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Shift">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Shift") %>'
                                            Style="font-size: 12px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fixed Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_fixedtime" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FixedTime") %>'
                                            Style="font-size: 12px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Produced Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_prdqty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ProducedQty") %>'
                                            Style="font-size: 12px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Edit" ControlStyle-Width="50pt">
                                    <ItemTemplate>
                                        <a id="<%# Eval("AID") %>" onclick="javascript:getactualdata(this.id);">
                                            <img src="../Images/Edit.jpg" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                                    <ItemTemplate>
                                        <a id="<%# Eval("AID") %>" onclick="javascript:deleteactualdata(this.id);">
                                            <img src="../Images/Delete.png" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <input type="hidden" id="hdn_actualid" runat="server" name="hdn_actualid" />
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
    <input type="hidden" id="hdn_id" name="hdn_id" />
    <div align="center" id="div_actualerror" runat="server" visible="false">
        <span style="color: Red; font-family: Arial; font-size: 18px; font-weight: bold;">No
            Record Found</span>
    </div>
</asp:Content>
