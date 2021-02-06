<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="PlannedStopEntry.aspx.cs" Inherits="PlannedStopEntry" Title="PH :: PLANNED STOP ENTRY" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />

    <script src="../JS/plannedstop.js" type="text/javascript"></script>

    <script src="../JS/ErrorPOPup.js" type="text/javascript"></script>

    <script src="../JS/Common.js" type="text/javascript"></script>

    <script type="text/javascript">
function onlyNumbers(evt) {
    var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)&& charCode != 46)
        return false;
    return true;
}
    
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
//$('#ddl_partno').focus();
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
searchbox.style['height'] = '17px';
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
        <table align="left">
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="MASTER /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="PLANNED STOP ENTRY" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <div style="" align="center">
        <table>
            <tr>
                <td style="width: 258px;" align="left">
                    <b>
                        <asp:Label ID="Label3" runat="server" Text="PART NO" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td align="left">
                 <div id="searchit">
                    <select id="ddl_partno" runat="server" class="dropdownstyleplan" style="height: 25px;
                        width: 460px;" onchange="javascript:validate_Pprtno();">
                    </select>
                    </div>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label1" runat="server" Text="PROCESS" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td align="left">
                    <select id="ddl_process" runat="server" class="dropdownstyleplan" style="height: 25px;
                        width: 500px;" onchange="javascript:validate_Pprocess();">
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
                        <asp:Label ID="Label6" runat="server" Text="PREVENTIVE MAINTENANCE(mins)" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_pmaintenance" runat="server" class="textboxstyleplan"
                        onblur="javascript:validate_Pmiantenance();" onkeypress="return onlyNumbers(this);"
                        style="width: 500px;" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label7" runat="server" Text="CLEANING(mins)" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_cleaning" runat="server" class="textboxstyleplan" style="width: 500px;"
                        onblur="javascript:validate_Pcleaning();" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label8" runat="server" Text="BREAK(mins)" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_break" runat="server" class="textboxstyleplan" style="width: 500px;"
                        onblur="javascript:validate_Pbreak();" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label10" runat="server" Text="NO PLAN/DEMAND(mins)" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_demand" runat="server" class="textboxstyleplan" onblur="javascript:validate_Pnoplan();"
                        onkeypress="return onlyNumbers(this);" style="width: 500px;" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label11" runat="server" Text="PLANNED MANUFACTURING TRIALS(mins)"
                            Style="font-family: Times New Roman;" CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_trial" runat="server" class="textboxstyleplan" style="width: 500px;"
                        onblur="javascript:validate_Ptrials();" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label12" runat="server" Text="MEETINGS(mins)" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_meetings" runat="server" class="textboxstyleplan" onblur="javascript:validate_Pmeetings();"
                        onkeypress="return onlyNumbers(this);" style="width: 500px;" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label13" runat="server" Text="TRAININGS(mins)" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_traings" runat="server" class="textboxstyleplan" onblur="javascript:validate_Ptrainigs();"
                        onkeypress="return onlyNumbers(this);" style="width: 500px;" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label2" runat="server" Text="PLANNED MAINTENANCE(mins)" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_planedmaintenance" runat="server" class="textboxstyleplan"
                        onblur="javascript:validate_Planmaintenace();" onkeypress="return onlyNumbers(this);"
                        style="width: 500px;" />
                </td>
            </tr>
            <tr style="height: 30px;">
                <td colspan="3">
                    <div id="div_error" style="font-size: 12px; color: Red; font-family: Arial; display: none;
                        padding-left: 200px;" align="center">
                        <span id="spn_error"></span>
                    </div>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                    <%--  <div align="center">
                                        <asp:ImageButton ID="btn_submit" runat="server" ImageUrl="~/Menu_image/Save.jpg"
                                            OnClientClick="return validate_plannedentry();" OnClick="btn_submit_Click" />
                                    </div>--%>
                    <div align="center" style="padding-left: 200px;" id="div_save" runat="server">
                        <asp:ImageButton ID="btn_submit" OnClick="btn_submit_Click" runat="server" ImageUrl="~/Menu_image/Save.jpg"
                            OnClientClick="return validate_plannedentry();" /></div>
                    <div align="center" style="padding-left: 200px; display: none;" id="div_update" runat="server">
                        <asp:ImageButton ID="btn_update" runat="server" ImageUrl="~/Menu_image/Submit.jpg"
                            OnClientClick="return validate_plannedentry();" OnClick="btn_update_Click" Style="cursor: pointer;" /></div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div style="padding-left: 150px;" id="div_planentry" runat="server" align="center">
        <table>
            <tr>
                <td>
                    <div>
                        <asp:GridView ID="Grid_plan" runat="server" AutoGenerateColumns="False" Width="1000px"
                            BorderColor="AliceBlue">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                    <ItemTemplate>
                                    
                                     <asp:Label ID="lbl_sno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                         <%--<asp:Label ID="lbl_sno" runat="server" Text="<%#((GridViewRow)Container).RowIndex + 1%>"></asp:Label>--%>
                                    </ItemTemplate>
                                    <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <%--  <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_sno" runat="server" Text='<%#Bind("PNO") %>' Style="font-size: 12px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                      <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle BackColor="White"  HorizontalAlign="Center" BorderColor="Black"/>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Part_No" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_PID" runat="server" Text='<%#Bind("PartNo") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="250" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Process">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("Process") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="250" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Maintenance">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("Maintenace") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="250" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cleaning">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("Cleaning") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="250" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Break">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("Break") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="250" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Shift_Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("ShiftTime") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="No Plan">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("Noplan") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="250" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Trials">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("Trials") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="250" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Meetings">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("Meetings") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="250" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Trainings">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("Trainings") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
   <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="250" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Shift">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("Shift") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Edit" ControlStyle-Width="50pt">
                                    <ItemTemplate>
                                        <a id="<%# Eval("PNO") %>" onclick="javascript:getplannedstop(this.id);">
                                            <img src="../Images/Edit.jpg" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                                    <ItemTemplate>
                                        <a id="<%# Eval("PNO") %>" onclick="javascript:deleteplannedstop(this.id);">
                                            <img src="../Images/Delete.png" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle BackColor="White" HorizontalAlign="Center" />
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
    <div align="center" id="div_actualerror" runat="server" visible="false">
        <span style="color: Red; font-family: Arial; font-size: 18px; font-weight: bold;">No
            Record Found</span>
    </div>
    <input type="hidden" id="hdn_planid" name="hdn_planid" runat="server" />
    <input type="hidden" id="Hdn_shift" name="Hdn_shift" runat="server" />
    <input type="hidden" id="hdn_shifttime" name="hdn_shifttime" runat="server" />
</asp:Content>
