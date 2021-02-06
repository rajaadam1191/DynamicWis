<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master"  AutoEventWireup="true" CodeFile="ProductionData.aspx.cs" Inherits="DYNSheets_ProductionData" Title="Production Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />
    <%--<script src="JS/jquery.easing.1.3.js" type="text/javascript"></script>--%>
    <%--<script src="JS/jquery.min.js" type="text/javascript"></script>--%>
    <link href="../Styles/Chart.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script src="../JS/QualitySheetscript.js" type="text/javascript"></script>

    <script src="../JS/MasterAdmin.js" type="text/javascript"></script>
    
    <script src="../JS/Common.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
$(document).ready(function()
{
    AttachSearch('searchit');
    getProdpart();
    $("input[id$='txt_prod_fromdate']").datepick({maxDate: 0,dateFormat: 'dd/mm/yyyy'});
//    $("input[id$='txt_todate']").datepick({maxDate: 0,dateFormat: 'dd/mm/yyyy'});

});
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
GetProdProcess();
//ddl_prod_operation.focus();
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
searchbox.style['height'] = '20px';
$('#searchbox').focus();
searchbox.onkeypress = function() { setTimeout('HandleKey();', 10); };
// Returns a collection of objects with the specified element name.
selects = el.getElementsByTagName('select').item(0);

// Returns a reference to the element that is inserted into the document.
el.insertBefore(searchbox, selects);
}
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
  <div style="margin-top: -30px;" id="div_header" runat="server">
        <table align="left">
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label32" runat="server" Text="Production Data /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label33" runat="server" Text="Quality Sheet" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <div style="background-color: #eefaff;" id="div_prod" align="center" runat="server">
        <table>
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
                <td style="width: 446px">
                <div id="searchit">
                    <select id="ddl_prod_partno" runat="server" style="width:398px;" class="dropdownstyle" onchange="javascript:valprodpart();">
                        <option value="0" selected="selected">-- Select Part No --</option>
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
                        <asp:Label ID="Label2" runat="server" Text="OPERATION" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td style="width: 446px">
                    <select id="ddl_prod_operation" runat="server" class="dropdownstyle" onchange="javascript:valprodoper();">
                        <option value="0" selected="selected">-- Select Operation --</option>
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
                        <asp:Label ID="Label11" runat="server" Text="CELL" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td style="width: 446px">
                    <select id="ddl_prod_cell" onchange="javascript:getprodmachine();valprodcell();" class="dropdownstyle"
                        runat="server">
                        <option value="0" selected="selected">-- Select Cell ---</option>
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
                        <asp:Label ID="Label10" runat="server" Text="MACHINE" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td style="width: 446px">
                    <select id="Slct_prod_machine" runat="server" class="dropdownstyle" onchange="javascript:valprodmach();">
                        <option value="0" selected="selected">--- Select Machine ---</option>
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
                        <asp:Label ID="Label4" runat="server" Text="SHIFT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td style="width: 446px">
                    <select id="ddl_prod_shift" runat="server" class="dropdownstyle" onchange="getprodoper();">
                        <option value="0" selected="selected">-- Select Shift --</option>
                       <%-- <option value="All">All</option>--%>
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
            <tr style="height: 5px;">
                <td align="left">
                    <b>
                        <asp:Label ID="Label5" runat="server" Text="DATE" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td style="width: 15px; color: Black;">
                    :
                </td>
                <td>
                    <input type="text" id="txt_prod_fromdate" class="textboxstyle" style="width: 441px;"
                      onblur="getprodoper();"  runat="server" />
                </td>
                <%--<td colspan="3">
                    <div>
                        <table>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label5" runat="server" Text="FROM" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td style="padding-left: 26px;">
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_fromdate" class="textboxstyle" style="width: 197px;" runat="server" />
                                </td>
                                <td>
                                </td>
                                <td>
                                    <b>
                                        <asp:Label ID="Label6" runat="server" Text="TO" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txt_todate" class="textboxstyle" style="width: 197px;" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>--%>
            </tr>
            <tr style="height: 5px;">
                <td align="left">
                    <b>
                        <asp:Label ID="Label3" runat="server" Text="OPERATOR" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td style="width: 15px; color: Black;">
                    :
                </td>
               <td style="width: 446px">
                    <select id="Slct_prod_operator" runat="server" class="dropdownstyle" onchange="javascript:valprodopertor();">
                        <option value="0" selected="selected">--- Select Operator ---</option>
                    </select>
                </td></tr>
            <tr style="height: 15px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div align="center" style="padding-left: 80px;">
                    <img src="../Menu_image/view.jpg" id="btn_QSView" style="cursor:pointer;" />
                            
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />

    <div>
    <input type="hidden" id="hdn_operator" name="hdn_operator" runat="server" />
        <input type="hidden" id="hdn_user" name="hdn_user" runat="server" />
        <input type="hidden" id="hdn_part" name="hdn_part" runat="server" />
        <input type="hidden" id="hdn_operation" name="hdn_operation" runat="server" />
        <input type="hidden" id="hdn_prod_date" name="hdn_prod_date" runat="server" />
        <input type="hidden" id="hdn_shift" name="hdn_shift" runat="server" />
        <input type="hidden" id="hdn_cell" name="hdn_cell" runat="server" />
        <input type="hidden" id="hdn_mach" name="hdn_mach" runat="server" />
        <input type="hidden" id="hdn_unit1" name="hdn_unit1" runat="server" />
        <input type="hidden" id="hdn_dimesion" name="hdn_dimesion" runat="server" />
        <input type="hidden" id="hdn_mean" name="hdn_mean" runat="server" />
        <input type="hidden" id="hdn_dynrefid" name="hdn_dynrefid" runat="server" />
    </div>
    <div align="center" id="div_error" style="display:none;">
    </div>
</asp:Content>

