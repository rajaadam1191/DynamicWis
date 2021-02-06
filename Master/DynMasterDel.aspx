<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="DynMasterDel.aspx.cs" Inherits="Master_DynMasterDel" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/DynMaster.js" type="text/javascript"></script>
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
$('#dy_del_partno').focus();
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
        AttachSearch('searchit');
    });
    
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div style="margin-top: -30px;">
    <table>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Text="MASTER /" valign="left" Font-Bold="true"
                    Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" Text="DELETE QUALITY SHEET" valign="left" Font-Bold="true"
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
                        <select id="dy_del_partno" runat="server" class="dropdownstyle" onchange="javascript:partno();"
                            style="width: 398px;">
                        </select>
                    </div>
                </td>
            </tr>
            <tr style="height: 10px;">
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
                    <select id="dy_del_operation" runat="server" class="dropdownstyle">
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
                    <select id="dy_del_cell" runat="server" class="dropdownstyle">
                    </select>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3" align="center">
                    <div id="diverror1" style="display: none; padding-left: 100px;">
                        <span id="spn_error1" style="font-family: Arial; font-size: 14px; color: Red;"></span>
                    </div>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr style="height: 15px;">
                <td colspan="3">
                    <div align="center">
                        <asp:Button ID="btn_Del" Text="Delete" runat="server" OnClientClick="return valdynDelValues();"
                            OnClick="btn_Del_Click" />
                        
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

