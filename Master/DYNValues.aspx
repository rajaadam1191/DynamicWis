<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="DYNValues.aspx.cs" Inherits="Master_DYNValues" Title="PH :: QUALITY VALUES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/DynMaster.js" type="text/javascript"></script>
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
$('#dy_partno1').focus();
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
    
         getpart1();
         AttachSearch('searchit');
    });

    </script>
    <style type="text/css">
    .dy_td
    {
         width:150px;
         text-align:center;
    }
    .dy_text
    {
         width:150px;
         height:30px;
         text-align:center;
         border:solid 1px green;
    }
    .dy_hspan
    {
        font-family:Arial;
        font-size:20px;
        color:Purple;
    }
    </style>
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
                    <asp:Label ID="Label8" runat="server" Text="ADD QUALITY VALUES" valign="left" Font-Bold="true"
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
                    <select id="dy_partno1" runat="server" class="dropdownstyle" onchange="javascript:va_par();" style="width:398px;">
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
                    <select id="dy_operation1" runat="server" class="dropdownstyle" onchange="javascript:va_op();">
                        <%--<option value="0">--- Select Operations ---</option>
                        <option value="1" selected="selected">Operation 1</option>
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
                    <select id="dy_unit1" runat="server" class="dropdownstyle" onchange="javascript:va_un();">
                        <option value="0">--- Select Unit ---</option>
                        <option value="MBU" selected="selected">MBU</option>
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
                    <select id="dy_cell1" runat="server" runat="server" class="dropdownstyle" onchange="javascript:va_cell();">
<%--                        <option value="0">--- Select Cell ---</option>
                        <option value="Valve" selected="selected">Valve</option>
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
            <tr style="height: 10px;">
                <td colspan="3" align="center">
                    <div align="center">
                        <span id="dy_spn_error" style="font-family: Arial; font-size: 14px; color: Red;">
                        </span>
                    </div>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr style="height: 15px;">
                <td colspan="3">
                    <div align="center" id="div_view">
                        <img src="../Menu_image/view.jpg" id="btn_view" style="cursor: pointer;" alt="" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div align="center">
        <div id="div_dynvalues">
        </div>
    </div>
    <div align="center" id="div_save" style="display:none;">
        <div align="center">
            <img src="../Menu_image/Save.jpg" id="btn_save" style="cursor: pointer;" alt="" />
        </div>
    </div>
</asp:Content>