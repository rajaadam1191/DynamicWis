<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="DYNMaster.aspx.cs" Inherits="Master_DYNMaster" Title="PH :: QUALITY HEADER" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Styles/QualityStyle.css" rel="stylesheet" type="text/css" />

    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="/JS/DynMaster.js" type="text/javascript"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" language="javascript">
    
        
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
$('#dy_partno').focus();
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

function AttachSearch1(id) {
// Returns a reference to the [select] element tag.
el = document.getElementById(id);

// Creates an instance of the element for the specified tag and returns a reference to the new element.
searchbox1 = document.createElement('input');
searchbox1.id = 'searchbox1';
searchbox1.style['width'] = '40px';
$('#searchbox1').focus();
searchbox1.onkeypress = function() { setTimeout('HandleKey1();', 10); };
// Returns a collection of objects with the specified element name.
selects1 = el.getElementsByTagName('select').item(0);

// Returns a reference to the element that is inserted into the document.
el.insertBefore(searchbox1, selects1);
}

function HandleKey1() {
k = document.getElementById('searchbox1');
keys = k.value;
if (keys.length > 3) {
FindKey1(keys);
}
}

function FindKey1(keys) {
// Returns a collection of objects with the specified element name.
opts = selects1.getElementsByTagName('option');

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
selects1.selectedIndex = i;
return true;
}
}
}

    $(document).ready(function()
    {   
        getpart();
//        dyngridload();
        AttachSearch('searchit');
        AttachSearch1('searchit1');
    });
    
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
                    <asp:Label ID="Label8" runat="server" Text="ADD QUALITY HEADER" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div align="center">
        <table>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label1" runat="server" Text="Part No" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                 <div id="searchit">
                    <select id="dy_partno" runat="server" class="dropdownstyle" onchange="javascript:partno();" style="width:398px;">
                    </select>
                    </div>
                </td>
            </tr>
            <tr style="height: 15px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label2" runat="server" Text="Operation" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="dy_operation" runat="server" class="dropdownstyle">
                        <%--<option value="0">--- Select Operatios ---</option>
                        <option value="1">Operation 1</option>
                        <option value="2">Operation 2</option>
                        <option value="Lapping">Lapping</option>
                        <option value="Polishing">Polishing</option>
                        <option value="Sanding">Sanding</option>
                        <option value="Engraving">Engraving</option>
                        <option value="Deburring">Deburring</option>
                        <option value="PackingValue">Packing Value</option>--%>
                    </select>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label6" runat="server" Text="Unit" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="dy_unit" runat="server" class="dropdownstyle">
                        <option value="0">--- Select Unit ---</option>
                        <option value="MBU">MBU</option>
                        <option value="ABU">ABU</option>
                    </select>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label3" runat="server" Text="Cell" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="dy_cell" runat="server" class="dropdownstyle">
                        <%--<option value="0">--- Select Cell ---</option>
                        <option value="Valve">Valve</option>
                        <option value="Block">Block</option>
                        <option value="Shaft">Shaft</option>
                        <option value="Cover">Cover</option>--%>
                    </select>
                </td>
            </tr>
             <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label12" runat="server" Text="Header Name" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="Txt_headername" runat="server" class="textboxstyle" onkeyup="javascript:changecase2();"/>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label4" runat="server" Text="Instruments" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="dy_intrument" runat="server" class="textboxstyle" onkeyup="javascript:changecase();" />
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label10" runat="server" Text="Instruments (Short Name)" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_shortname" runat="server" class="textboxstyle" onkeyup="javascript:changecase1();"
                        maxlength="5" />
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label5" runat="server" Text="Instruments Value" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="dy_instruvalues" runat="server" class="textboxstyle" onkeypress="return isNumber_instvalue(event)" />
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
             <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label11" runat="server" Text="No.Of Cells" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <%--<input type="text" id="txt_noofcells" runat="server" class="textboxstyle" onkeypress="return isNumber_noofcell(event)" />--%>
                     <select id="txt_noofcells" runat="server" class="dropdownstyle">
                        <option value="">--- Select No Of Cells----</option>
                        <option value="0">0</option>
                        <option value="2">2</option>
                    </select>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label9" runat="server" Text="Ranges" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="dy_ranges" runat="server" class="dropdownstyle">
                        <%--<option value="0">--- Select Instruments Range-</option>
                        <option value="100%">100%</option>
                        <option value="1/5 Parts">1/5 Parts</option>
                        <option value="1/10 Parts">1/10 Parts</option>
                        <option value="1/15 Parts">1/15 Parts</option>
                        <option value="1st part/shift">1st part/shift</option>
                        <option value="4 parts/shift">4 parts/shift</option>--%>
                    </select>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label13" runat="server" Text="Run Chart" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                <select id="slt_runchart" runat="server" class="dropdownstyle">
                        <option value="0">--- Select Values-</option>
                        <option value="Yes">Yes</option>
                        <option value="No">No</option>
                    </select>
                  <%-- <asp:RadioButton ID="rbRunyes" Text="Yes" runat="server" GroupName="RunChart"  AutoPostBack="true"/>
                    <asp:RadioButton ID="rbRunno" Text="No" Checked="true" runat="server" GroupName="RunChart" AutoPostBack="true"/>--%>
                    <%--<asp:RadioButtonList runat="server" ID="RunChart" AutoPostBack="true">
                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                        <asp:ListItem Value="No">No</asp:ListItem>
                    </asp:RadioButtonList>--%>
                </td>
            </tr>
            <%--<tr style="height: 10px;">
                <td colspan="3" align="center">
                </td>
            </tr>
            <tr id="runval" runat="server" visible="false">
                <td colspan="3">
                    <div>
                        <table style="padding-left:180px;">
                            <tr>
                                <td >
                                    <b>
                                        <asp:Label ID="Label14" runat="server" Text="UCL" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_ucl" runat="server" class="textboxstyle" style="width: 170px;" />
                                </td>
                                <td>
                                    <b>
                                        <asp:Label ID="Label15" runat="server" Text="LCL" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_lcl" runat="server" class="textboxstyle" style="width: 170px;" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>--%>
            <tr style="height: 10px;">
                <td colspan="3" align="center">
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr style="height: 15px;">
                <td colspan="3">
                    <div align="center" id="div_save">
                        <asp:ImageButton ID="btnsave" runat="server" ImageUrl="~/Menu_image/Save.jpg" OnClientClick="return validatedyn();"
                            OnClick="btnsave_Click" />
                        <%--<img src="/Menu_image/save.jpg" id="btn_save" style="cursor: pointer;" alt="" onclick="return btn_save_onclick()" />--%>
                    </div>
                    <div align="center" id="div_updatge" style="display: none;">
                        <%--<img src="/Menu_image/Submit.jpg" id="btn_dyupdate"  style="cursor: pointer;" alt="" />--%>
                        <asp:ImageButton ID="btndynupd" runat="server" ImageUrl="~/Menu_image/Submit.jpg" OnClientClick="return validatedyn();"
                            OnClick="btnUpdate_Click" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
   
    
    <div align="center">
        <table>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label14" runat="server" Text="Part No" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                 <div id="searchit1">
                    <asp:DropDownList ID="ddl_partnosrch" CssClass="dropdownstyle" runat="server" OnSelectedIndexChanged="ddl_partnosrch_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList> 
                    </div>
                    
<%--                    <select id="ddl_partnosrch" runat="server" class="dropdownstyle" onchange="javascript:srchpartno();" OnSelectedIndexChanged="ddl_partnosrch_SelectedIndexChanged" >
                    </select>--%>
                </td>
                <td>
                    <div align="right">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Menu_image/search.jpg"
                            OnClick="btnSearch_Click" /></div>
                </td>
                <td>
                    <div align="right">
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Menu_image/viewall.jpg"
                            OnClick="btnview_Click" /></div>
                </td>
            </tr>
        </table>
    </div>
     <br />
     
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
            <div align="center">
                <asp:GridView ID="grd_dynmaster" runat="server" BorderColor="AliceBlue" OnRowDeleting="OnRowDeleting" AutoGenerateColumns="false"
                    OnRowDataBound="grd_dynmaster_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Sl.No" HeaderStyle-ForeColor="#FFFFFF">
                            <ItemTemplate>
                                <%--<asp:Label ID="lbl_sno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>--%>
                                <asp:Label ID="lbl_sno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "IndexNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" Height="30" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" Height="30" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part No">
                            <ItemTemplate>
                                <asp:Label ID="lbl_partno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Partno") %>'
                                    Style="font-size: 12px; text-align: center;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Height="25" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operation">
                            <ItemTemplate>
                                <asp:Label ID="lbl_operation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Operation") %>'
                                    Style="font-size: 12px; text-align: center;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit">
                            <ItemTemplate>
                                <asp:Label ID="lbl_unit" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Unit") %>'
                                    Style="font-size: 12px; text-align: center;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Header Name">
                            <ItemTemplate>
                                <asp:Label ID="lbl_header" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "HeaderName") %>'
                                    Style="font-size: 12px; text-align: center;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cell">
                            <ItemTemplate>
                                <asp:Label ID="lbl_cell" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Cell") %>'
                                    Style="font-size: 12px; text-align: center;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Instruments">
                            <ItemTemplate>
                                <asp:Label ID="lbl_instrument" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Instrument") %>'
                                    Style="font-size: 12px; text-align: center;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Short Name">
                            <ItemTemplate>
                                <asp:Label ID="lbl_shortname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ShortName") %>'
                                    Style="font-size: 12px; text-align: center;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Inst Value">
                            <ItemTemplate>
                                <asp:Label ID="lbl_count" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Int_count") %>'
                                    Style="font-size: 12px; text-align: center;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="No.Of Cells">
                            <ItemTemplate>
                                <asp:Label ID="lbl_cellvalues" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CellValues") %>'
                                    Style="font-size: 12px; text-align: center;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Inst Range">
                            <ItemTemplate>
                                <asp:Label ID="lbl_range" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Int_range") %>'
                                    Style="font-size: 12px; text-align: center;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Run/SPC Chart">
                            <ItemTemplate>
                                <asp:Label ID="lbl_chart" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Runchart") %>'
                                    Style="font-size: 12px; text-align: center;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <img src="/Images/Edit.jpg" alt="" id='<%#DataBinder.Eval(Container.DataItem, "DID") %>'
                                    onclick="javascript:edit(this.id);" style="cursor: pointer;" />
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <%-- <img src="/Images/Delete.png" alt="" id='<%#DataBinder.Eval(Container.DataItem, "DID") %>'
                                    onclick="javascript:_delete(this.id);" style="cursor: pointer;" />--%>
                                <asp:ImageButton ID="btndel" runat="server" ImageUrl="/Images/Delete.png"
                                CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this event?');" />
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbl_did" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DID") %>'
                                    Style="font-size: 12px; text-align: center;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                            <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
<%--        </asp:UpdatePanel>
    </asp:ScriptManager>--%>
       
    <div align="center">
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
        <input type="hidden" id="hdn_part" runat="server" name="hdn_part" />
        <input type="hidden" id="hdn_srchpart" runat="server" name="hdn_srchpart" />
        <input type="hidden" id="hdn_oper" runat="server" name="hdn_oper" />
        <input type="hidden" id="hdncell" runat="server" name="hdncell" />
        <input type="hidden" id="hdn_dyid" runat="server" name="hdn_dyid" />
        <input type="hidden" id="hdn_ranges" runat="server" name="hdn_ranges" />
        <input type="hidden" id="hdn_instname" runat="server" name="hdn_instname" />
        <input type="hidden" id="hdn_instvalues" runat="server" name="hdn_instvalues" />
        <input type="hidden" id="hdn_noofcell" runat="server" name="hdn_noofcell" />
         <input type="hidden" id="hdn_runchart" runat="server" name="hdn_runchart" />
    </div>
</asp:Content>
