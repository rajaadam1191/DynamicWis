<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="SpcChart.aspx.cs" Inherits="DYNSheets_SpcChart" Title="SPC CHART" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />
    <%--<script src="JS/jquery.easing.1.3.js" type="text/javascript"></script>--%>
    <%--<script src="JS/jquery.min.js" type="text/javascript"></script>--%>
    <link href="../Styles/Chart.css" rel="stylesheet" type="text/css" />
    <script src="../JS/Chart.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>
    <script src="../JS/QualitySheetscript.js" type="text/javascript"></script>
    <script src="../JS/Common.js" type="text/javascript"></script>
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

    $(document).ready(function()
{
$('#error').hide();
//getmachine1();
    $("input[id$='txt_fromdate']").datepick({maxDate: 0,dateFormat: 'mm/dd/yyyy'});
    $("input[id$='txt_todate']").datepick({maxDate: 0,dateFormat: 'mm/dd/yyyy'});
    AttachSearch('searchit');
    loadSPChdnvalues();
});




    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
  <div style="margin-top: -30px;" id="div_header" runat="server">
        <table align="left">
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label32" runat="server" Text="REPORT /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label33" runat="server" Text="SPC CHART" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-top: 5px;" id="div_quality" runat="server" visible="false">
        <table align="left">
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label7" runat="server" Text="Quality Sheet /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Chart" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <div style="background-color: #eefaff;" id="div_chart1" align="center" runat="server">
        <table>
            <tr>
                <td valign="top">
                    <div>
                        <table>
                            <%-- <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label9" runat="server" Text="UNIT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_unit_QC_chart" runat="server" class="dropdownstyle" onchange="javascript:getmachine1();validateunit();">
                        <option value="0" selected="selected">-- Select Cell ---</option>
                        <option value="ALL">ALL</option>
                        <option value="MBU">MBU</option>
                        <option value="ABU">ABU</option>
                    </select>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>--%>
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
                                    <select id="ddl_cell" onchange="javascript:getmachine();validatecell();" class="dropdownstyle" runat="server">
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
                                    <select id="Slct_machine_QC_chart" runat="server" class="dropdownstyle" onchange="javascript:validatemacnine();" runat="server">
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
                                        <asp:Label ID="Label1" runat="server" Text="PART NO" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td style="width: 446px">
                                    <div id="searchit">
                                        <select id="ddl_partno" runat="server" class="dropdownstyle" style="width:398px;">
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
                                        <asp:Label ID="Label2" runat="server" Text="PROCESS" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td style="width: 446px">
                                    <select id="ddl_operation" runat="server" class="dropdownstyle">
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
                                        <asp:Label ID="Label4" runat="server" Text="SHIFT" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td style="width: 446px">
                                    <select id="ddl_shift" runat="server" class="dropdownstyle">
                                        <option value="0" selected="selected">-- Select Shift --</option>
                                        <option value="All">All</option>
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
                                <tr>
                                    <td colspan="3">
                                        <div>
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        <b>
                                                            <asp:Label ID="Label5" runat="server" Text="FROM" Style="font-family: Times New Roman;"
                                                                CssClass="lablestyle">
                                                            </asp:Label></b>
                                                    </td>
                                                    <td style="padding-left: 75px;">
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
                                    </td>
                                </tr>
                                <tr style="height: 5px;">
                                    <td colspan="3">
                                    </td>
                                </tr>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label3" runat="server" Text="SAMPLE SIZE(N)" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td style="width: 446px">
                                    <select id="ddl_ssize" runat="server" class="dropdownstyle">
                                        <option value="0" selected="selected">-- Select Sample Size --</option>
                                    </select>
                                </td>
                            </tr>
                            <tr style="height: 15px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div align="center" style="padding-left: 80px;">
                                        <img src="../Menu_image/view.jpg" id="btn_chart" style="cursor: pointer;" alt="" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td valign="top">
                    <div style="padding-left:50px;" runat="server">
                        <table>
                            <tr style="height: 15px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>USL</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <hr noshade="noshade" size="5" align="center" style="background-color: Red; border: 0px;" />
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td>
                                    <span id="spn_spcUSL" runat="server"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>UCL</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <hr noshade="noshade" size="5" align="center" style="background-color: Yellow; border: 0px;" />
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td>
                                    <span id="spn_spcUCL" runat="server"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>PROCESS MEAN</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <hr noshade="noshade" size="5" align="center" style="background-color: #006400; border: 0px;" />
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td>
                                    <span id="spn_spcPMean" runat="server"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>MEAN</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <hr noshade="noshade" size="5" align="center" style="background-color: Blue; border: 0px;" />
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td>
                                    <span id="spn_spcMean" runat="server"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>TREND</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <hr noshade="noshade" size="5" align="center" style="background-color: #87ceeb; border: 0px;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>LCL</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <hr noshade="noshade" size="5" align="center" style="background-color: Yellow; border: 0px;" />
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td>
                                    <span id="spn_spcLCL" runat="server"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>LSL</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td style="width: 100px;">
                                    <hr noshade="noshade" size="5" align="center" style="background-color: Red; border: 0px;" />
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td>
                                    <span id="spn_spcLSL" runat="server"></span>
                                </td>
                            </tr>
                           
                        </table>
                        <div><table> <tr><td colspan="6"><span> Place the cursor over the points to view the comments</span></td></tr></table></div>
                    </div>
                </td>
            </tr>

        </table>
    </div>
    <br />
    <div style="" id="div_dimenssion">
        <ul class="tabs" data-persist="true" id="ul_dimension">
        </ul>
    </div>
    <div class="tabcontents" align="center" style="display:none;" id="div_dimenssion1">
        <div id="div_dimensionchart">
        </div>
    </div>
    <div>
        <input type="hidden" id="hdn_user" name="hdn_user" runat="server" />
        <input type="hidden" id="hdn_part" name="hdn_part" runat="server" />
        <input type="hidden" id="hdn_operation" name="hdn_operation" runat="server" />
        <input type="hidden" id="hdn_shift" name="hdn_shift" runat="server" />
        <input type="hidden" id="hdn_cell" name="hdn_cell" runat="server" />
        <input type="hidden" id="hdn_mach" name="hdn_mach" runat="server" />
        <input type="hidden" id="hdn_unit1" name="hdn_unit1" runat="server" />
        <input type="hidden" id="hdn_dimesion" name="hdn_dimesion" runat="server" />
        <input type="hidden" id="hdn_mean" name="hdn_mean" runat="server" />
        <input type="hidden" id="hdn_ssize" name="hdn_ssize" runat="server" />
        <input type="hidden" id="hdn_dynrefid" name="hdn_dynrefid" runat="server" />
         <input type="hidden" id="hdn_dynvalid" name="hdn_dynvalid" runat="server" />
         <input type="hidden" id="hdn_coldim" name="hdn_coldim" runat="server" />
    </div>
    <div align="center" id="error"><span style="font-family:Arial Black; font-size:35px; font-weight:bold; color:Red;" id="spn_error1">SPC Chart are not available</span></div>
    <div align="center" id="div_error" class="hidden">
    <%--<span style="font-family:Arial Black; font-size:35px; font-weight:bold; color:Red;" id="spn_error">SPC Chart are not available</span>--%>
    </div>
</asp:Content>