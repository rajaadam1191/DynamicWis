﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="FixtureName.aspx.cs" Inherits="Fixture_FixtureName" Title="PH :: FIXTURE NAME MASTER" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/Fixture.js" type="text/javascript"></script>
 <script type="text/javascript" language="javascript">
//     function HandleKey() {
//k = document.getElementById('searchbox');
//keys = k.value;
//if (keys.length > 3) {
//FindKey(keys);
//}
//}

//function FindKey(keys) {
//// Returns a collection of objects with the specified element name.
//opts = selects.getElementsByTagName('option');

//for (i = opts.length-1; i >=0; i--) {
//    //alert(i + ". option= " + opts.item(i).text + " searching= " + keys);
////    alert(opts.item(i).text.substr(opts.item(i).text.length - 1, keys.length));
//    //    alert(parseFloat(opts.item(i).text.length)-1);
//    val = "";
//    var val = opts.item(i).text.substr(opts.item(i).text.length - 4, keys.length);
//    val = val + opts.item(i).text.substr(opts.item(i).text.length - 3, keys.length);
//    val = val + opts.item(i).text.substr(opts.item(i).text.length - 2, keys.length);
//    val = val + opts.item(i).text.substr(opts.item(i).text.length - 1, keys.length);
//    // alert(val);

//val=val.toUpperCase();
//     if (val.substr(0, 4) == keys.toUpperCase()) {
//// Select the option opts.item(i)
//selects.selectedIndex = i;
////$('#ddl_partno').focus();
//return true;
//}
//}
//}

//    function AttachSearch(id) {
//// Returns a reference to the [select] element tag.
//el = document.getElementById(id);

//// Creates an instance of the element for the specified tag and returns a reference to the new element.
//searchbox = document.createElement('input');
//searchbox.id = 'searchbox';
//searchbox.style['width'] = '40px';
//$('#searchbox').focus();
//searchbox.onkeypress = function() { setTimeout('HandleKey();', 10); };
//// Returns a collection of objects with the specified element name.
//selects = el.getElementsByTagName('select').item(0);

//// Returns a reference to the element that is inserted into the document.
//el.insertBefore(searchbox, selects);
//}

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

function scroll(oid,iid){
            this.oCont=document.getElementById(oid)
            this.ele=document.getElementById(iid)
            this.width=this.ele.clientWidth;
            this.n=this.oCont.clientWidth;
            this.move=function(){
                this.ele.style.left=this.n+"px"
                this.n--
                if(this.n<(-this.width)){this.n=this.oCont.clientWidth}
            }
        }
        var vScroll
        function setup(){
            vScroll=new scroll("oScroll","scroll");
            setInterval("vScroll.move()",50)
        }
        onload=function(){setup();
//        AttachSearch('searchit');
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
                        <asp:Label ID="Label6" runat="server" Text="FIXTURE MASTER" valign="left" Font-Bold="true"
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
                    <td valign="top">
                        <div>
                            <table>
                                <tr>
                                    <td> <div id="searchit">
                                     <%--<asp:TextBox ID="txtSearch" runat="server" />--%>
                                        <div style="overflow-y: scroll; overflow-x: hidden; width: 335px; height: 180px;
                                            border: solid 1px #064b68;" align="center">
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" align="right"
                                                Width="335px" OnRowDataBound="GridView2_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <%--                                                    <HeaderTemplate>
                                                        <span>ALL</span>
                                                        <asp:CheckBox ID="chkboxSelectAll" onclick="javascript:checkall();" runat="server" />
                                                    </HeaderTemplate>--%>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox2" runat="server" Style="padding-left: 25px;" />
                                                        </ItemTemplate>
                                                        <ControlStyle Font-Size="Medium" ForeColor="Black" />
                                                        <FooterStyle ForeColor="Black" />
                                                        <HeaderStyle Width="100px" Font-Size="Medium" ForeColor="Black" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PartNo" HeaderText="PART NO" FooterStyle-Font-Bold="true">
                                                        <ControlStyle ForeColor="Black" Font-Bold="True" />
                                                        <FooterStyle ForeColor="Black" />
                                                        <HeaderStyle ForeColor="Black" Font-Bold="True" Font-Size="Medium" />
                                                        <ItemStyle Font-Size="Small" ForeColor="Black" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td valign="top">
                        <div style="float: right; margin-left: 50px;">
                            <table>
                                <tr>
                                    <td align="left">
                                        <span class="lablestyle">Unit</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddl_funit" CssClass="dropdownstyle" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="height: 5px;">
                                    <td colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <span class="lablestyle">Tool Type</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddl_ftooltype" CssClass="dropdownstyle" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="height: 5px;">
                                    <td colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <span class="lablestyle">Cell</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddl_fixcell" CssClass="dropdownstyle" runat="server" OnSelectedIndexChanged="ddl_fixcell_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="height: 5px;">
                                    <td colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <span class="lablestyle">Line/ MAchine</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddl_fline" CssClass="dropdownstyle" runat="server">
                                        <asp:ListItem Value="0">--- Select Fixture Line ---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="height: 5px;">
                                    <td colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <span class="lablestyle">Model</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddl_model" CssClass="dropdownstyle" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="height: 5px;">
                                    <td colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <span class="lablestyle">Fixture Number</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td colspan="2">
                                        <input type="text" id="txt_fixtureno" class="textboxstyle" runat="server"  />
                                    </td>
                                </tr>
                                <tr style="height: 5px;">
                                    <td colspan="4">
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td align="left">
                                        <span class="lablestyle">Cell</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddl_fixcell" CssClass="dropdownstyle" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="height: 5px;">
                                    <td colspan="4">
                                    </td>
                                </tr>--%>
                                <tr visible="false" style="display:none">
                                    <td align="left">
                                        <span class="lablestyle">Part Number</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddl_partnumber" CssClass="dropdownstyle" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
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
                        <table align="center">
                            <tr>
                                <td>
                                    <div align="center">
                                        <div align="center" style="padding-left: 30px;" id="div_fistruesave" runat="server">
                                            <asp:ImageButton ID="btn_submit" runat="server" Text="Save" color="black" ImageUrl="~/Menu_image/Save.jpg"
                                                OnClick="btn_submit_Click" OnClientClick="return valMbufixture();" />
                                        </div>
                                        <div align="center" style="padding-left: 30px;" id="div_fistrueupdate" visible="false"
                                            runat="server">
                                            <asp:ImageButton ID="btn_update" runat="server" ImageUrl="~/Menu_image/Submit.jpg"
                                                Style="cursor: pointer;" OnClientClick="return valMbufixture();" OnClick="btn_update_Click" /></div>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <asp:ImageButton ID="ImageButton2" runat="server" Text="New" color="black" ImageUrl="~/Menu_image/Clear.jpg"
                                            OnClick="btn_Clear_Click" /></div>
                                </td>
                            </tr>
                        </table>
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
                            <asp:GridView ID="grid_Fixturename" runat="server" BorderColor="AliceBlue" AutoGenerateColumns="false" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelEdit" OnRowUpdating="OnRowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                        <ItemTemplate>
                                          <%--  <%# Container.DataItemIndex+1 %>--%>
                                           <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "IndexNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FID") %>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_tool" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Fixturename") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" Height="30" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cell">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Cell" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Cell") %> '
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Part Number">
                                        <ItemTemplate>
                                        <div style="word-wrap: break-word; width: 400px;font-size: 20px; text-align: center;">
                                            <asp:Label ID="lbl_partno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Partnumber") %> '
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                                </div>
                                        </ItemTemplate>
                                        <HeaderStyle Width="400" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="400" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Unit">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_unit" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Unit") %> '
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_type" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Type") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Line">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_line" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Line") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Model">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_model" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Model") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Creation Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_creation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CreationDate") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ControlStyle-Width="50pt">
                                        <ItemTemplate>
                                           <%-- <a id="<%# Eval("FID") %>" onclick="javascript:editfname(this.id);">
                                                <img src="../Images/Edit.jpg" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                            </a>--%>
                                             <asp:ImageButton ID="btnedit" runat="server" ImageUrl="../Images/Edit.jpg" style="height: 20px; width: 20px; cursor: pointer;"
                                CommandName="Edit" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                                        <ItemTemplate>
                                            <a id="<%# Eval("FID") %>" onclick="javascript:deletefname(this.id);">
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
    <div>
        <input type="hidden" id="hdn_fid" name="hdn_fid" runat="server" />
    </div>
</asp:Content>
