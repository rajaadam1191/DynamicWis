<%@ Page Language="C#" MasterPageFile="~/AbuMaster.master" AutoEventWireup="true"
    CodeFile="AbuMaster.aspx.cs"  EnableEventValidation="false" Inherits="ABU_AbuMaster" Title="PH :: Tool Assign Master" %>
    
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="/Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="/Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script src="/JS/Abu.js" type="text/javascript"></script>
  <script src="/JS/quicksearch.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    $(document).ready(function()
{
     $("input[id$='txt_issuedon']").datepick({maxDate: 31,dateFormat: 'dd/mm/yyyy'});
    
});
 $(function () {
            $('.search_textbox').each(function (i) {
                $(this).quicksearch("[id*=GridView1] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });

function txt_retension_onclick() {

}

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
        .style56
        {
            width: 170px;
            height: 27px;
        }
        .style57
        {
            height: 27px;
        }
        .style58
        {
            height: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                        <asp:Label ID="Label6" runat="server" Text="MASTER UPLOAD" valign="left" Font-Bold="true"
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
        <div style="">
            <div>
                <table align="center">
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Tool Number</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txt_toolnumber" CssClass="dropdownstyle" runat="server" OnSelectedIndexChanged="txt_toolnumber_SelectedIndexChanged"
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
                            <span class="lablestyle" style="color:#fff;">Drawing Availability</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_availability" CssClass="dropdownstyle" runat="server">
                                <asp:ListItem Value="0" Selected="True">--- Select Availablity ---</asp:ListItem>
                                <asp:ListItem Value="Yes">YES</asp:ListItem>
                                <asp:ListItem Value="No">NO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Drawing</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:FileUpload ID="fld_drawings" runat="server" Style="width: 435px;" />
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Station</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <input type="text" id="txt_mstation" class="textboxstyle" runat="server" />
                            <%--<asp:DropDownList ID="ddl_statios" CssClass="dropdownstyle" runat="server">
                                <asp:ListItem Value="0" Selected="True">--- Select Station ---</asp:ListItem>
                                <asp:ListItem Value="Station1">Station 1</asp:ListItem>
                                <asp:ListItem Value="Station2">Station 2</asp:ListItem>
                                <asp:ListItem Value="Station3">Station 3</asp:ListItem>
                                <asp:ListItem Value="Station4">Station 4</asp:ListItem>
                                <asp:ListItem Value="Station5">Station 5</asp:ListItem>
                                <asp:ListItem Value="Station6">Station 6</asp:ListItem>
                                <asp:ListItem Value="Station7">Station 7</asp:ListItem>
                            </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Tool Description</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <input type="text" id="txt_description" class="textboxstyle" runat="server" />
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Photo</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:FileUpload ID="up_photo" runat="server" Style="width: 435px;" />
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Calibration Due</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <input type="text" id="txt_retension" class="textboxstyle" runat="server" disabled="disabled" onclick="return txt_retension_onclick()" />
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Commenced on</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <input type="text" id="txt_issuedon" class="textboxstyle" runat="server"  />
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Station Quantity</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <input type="text" id="txt_quantity" class="textboxstyle" runat="server" onclick="javascript:datachk()" onblur="javascript:datachk()"/>
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Spare Availability</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <input type="text" id="txt_maintained" class="textboxstyle" runat="server"  disabled="disabled"/>
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Next Due On</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <input type="text" id="txt_dueon" class="textboxstyle" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="margin-top: 10px; display: none; margin-left: 0px;" id="div_life_extended">
                <table align="center">
                    <tr>
                        <td align="left" class="style56" style="width: 145px;">
                            <span class="lablestyle" style="color:#fff;">Spare Replaced</span>
                        </td>
                        <td class="style57">
                            :
                        </td>
                        <td class="style57">
                            <asp:DropDownList ID="ddl_replaced" CssClass="dropdownstyle" runat="server" >
                                <asp:ListItem Value="0" Selected="True">--- Select Replaced ---</asp:ListItem>
                                <asp:ListItem Value="Yes">YES</asp:ListItem>
                                <asp:ListItem Value="No">NO</asp:ListItem>
                            </asp:DropDownList>
                            <%--<input type="text" id="txt_replaced" class="textboxstyle" runat="server" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="style58">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Life Extended</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <input type="text" id="txt_extended" class="textboxstyle" runat="server" />
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Tool Rectified</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <input type="text" id="txt_rectified" class="textboxstyle" runat="server" />
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Others</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <input type="text" id="txt_others" class="textboxstyle" runat="server" />
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="lablestyle" style="color:#fff;">Premature Life</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <input type="text" id="txt_premature" class="textboxstyle" runat="server" />
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
                    OnClick="btn_submit_Click" OnClientClick="return validateabu();" />
            </div>
            <div align="center" style="padding-left: 30px; display: none;" id="div_update" runat="server">
                <asp:ImageButton ID="btn_update" runat="server" ImageUrl="~/Menu_image/Submit.jpg"
                    Style="cursor: pointer;" OnClientClick="return validateabu1();" OnClick="btn_update_Click" /></div>
        </div>
      
        <div align="center" id="div_cycle" runat="server">
      <div><table><tr><td><div style="padding-left: 1200px;">
                        <asp:ImageButton ID="btn_excel" Visible="false" runat="server" Text="Excel" color="black" ImageUrl="~/Menu_image/Export.png"
                            OnClick="ExportToPDF"/>
                    </div></td></tr></table></div>
            <table>
                <tr>
                    <td>
                        <div>
                            <asp:GridView ID="GridView1" runat="server" BorderColor="AliceBlue" AutoGenerateColumns="False"
                                OnRowDataBound="GridView1_RowDataBound" OnDataBound="OnDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSerial" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "IndexNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#4C6C9F" ForeColor="White"></HeaderStyle>
                                        <ItemStyle BackColor="White" BorderColor="Black" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF"
                                        Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID") %>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#4C6C9F" ForeColor="White"></HeaderStyle>
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
                                    <asp:TemplateField HeaderText="Drawing Availability">
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
                                    <asp:TemplateField HeaderText="Drawing">
                                        <ItemTemplate>
                                           <%-- <asp:Image ID="ph_drawing" Style="width: 145px; height: 100px;" runat="server" />--%>
                                           <%--<asp:LinkButton ID="ph_drawing" runat="server" Text="Click" OnClick="ph_drawing_Click">
    </asp:LinkButton>--%>
                                           <%--<a id="ph_drawing" runat="server"></a>--%>
                                           <asp:HyperLink ID="ph_drawing" Target="_blank" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="150" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="150" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Calibration Due">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_retine" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Commenced on">
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
                                    <asp:TemplateField HeaderText="Spare Availability">
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
                                    <asp:TemplateField HeaderText="Edit" ControlStyle-Width="50pt">
                                        <ItemTemplate>
                                            <a id="<%# Eval("ID") %>" onclick="javascript:editmaster(this.id);">
                                                <img src="/Images/Edit.jpg" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                            </a>
                                        </ItemTemplate>
                                        <ControlStyle Width="50pt"></ControlStyle>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                                        <ItemTemplate>
                                            <a id="<%# Eval("ID") %>" onclick="javascript:deletemaster(this.id);">
                                                <img src="/Images/Delete.png" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                            </a>
                                        </ItemTemplate>
                                        <ControlStyle Width="50pt"></ControlStyle>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_status" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" HorizontalAlign="Center" BorderColor="Black" />
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
    </div>
    <div>
        <input type="hidden" id="hdn_id" name="hdn_id" runat="server" />
        <input type="hidden" id="hdn_issued" name="hdn_issued" runat="server" />
        <input type="hidden" id="hdn_sparecount" name="hdn_sparecount" runat="server" />
        <input type="hidden" id="hdn_sparecount1" name="hdn_sparecount1" runat="server" />
    </div>
    <div>        
        <cr:crystalreportviewer ID="CRV" runat="server" 
            AutoDataBind="true" /></div>
</asp:Content>
