<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="Userpage.aspx.cs" Inherits="Userpage" Title="PH :: PD VIEW" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/tabcontent.css" rel="stylesheet" type="text/css" />
    <script src="../JS/ErrorPOPup.js" type="text/javascript"></script>
    <script type="text/javascript">
function validate_userpage()
{
if(!validate_partno())return false
if(!validate_process())return false
if(!validate_type())return false
}
function validate_partno()
{
    var partno=$("select[id$='DropPart']").val();
    if(partno=="-Select-" || partno==null)
    {
        $("div[id$='div_errorr']").show();
        $("span[id$='spnerror']").text('Please Select Part No');
        $("select[id$='DropPart']").focus();
        //$("select[id$='ddl_partno']").focus();
        return false;
    }
    else
    {   
        $("div[id$='div_errorr']").hide();
        return true;
    }
    
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
$('#DropPart').focus();
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

function validate_process()
{
    var process=$("input[id$='hdn_process']").val();
  
     if(process==null || process=="")
    {
     $("div[id$='div_errorr']").show();
        $("span[id$='spnerror']").text('Please Select Process');
        $("select[id$='DropProcess']").focus();
        //$("select[id$='ddl_partno']").focus();
        return false;
    }
    else
    {   
        $("div[id$='div_errorr']").hide();
        return true;
    }

}
function validate_type()
{   
     var type=$("select[id$='DropType']").val();
    if(type=="0" || type==null)
    {
     $("div[id$='div_errorr']").show();
        $("span[id$='spnerror']").text('Please Select Type');
        $("select[id$='DropType']").focus();
        //$("select[id$='ddl_partno']").focus();
        return false;
    }
    else
    {   
        $("div[id$='div_errorr']").hide();
        return true;
    }
    
}
  onload=function(){AttachSearch('searchit');}
</script>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
   
    <div id="div_usermenu" runat="server" style="margin-top: -30px;">
        <table align="left">
            <tr>
             <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label7" runat="server" Text="PRODUCTION DOCUMENT /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="PD VIEW" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
               
            </tr>
        </table>
    </div>
    <div id="divP" class="divUPage ">
        <table align="center" cellpadding="0px" cellspacing="0px" border="0" style="font-family: Arial;"
            style="border: none; font-size: 13px;" width="100%">
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td valign="top" style="height: 10px">
                    <table border="0px" cellpadding="0px" cellspacing="0px" style="border-color: #7e7e7e"
                        style="border: none;">
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label3" runat="server" Text="PART NO" style="font-family:Times New Roman;" CssClass="lablestyle" Font-Bold="true"></asp:Label>&nbsp;
                            </td>
                            <td>
                                :&nbsp;
                            </td>
                            <td>
                            <div id="div_DropPart" runat="server">
                             <div id="searchit">
                                <asp:DropDownList ID="DropPart" CssClass="dropdownstyle" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="DropPart_SelectedIndexChanged" Width="395">
                                </asp:DropDownList>
                                </div>
                                </div>
                            </td>
                        </tr>
                        <tr style="height: 5px;">
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label6" runat="server" Text="DESCRIPTION" style="font-family:Times New Roman;" CssClass="lablestyle" Font-Bold="true"></asp:Label>&nbsp;
                            </td>
                            <td>
                                :&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="TxtDescription" runat="server" CssClass="textboxstyle"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 5px;">
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label2" runat="server" Text="PROCESS" style="font-family:Times New Roman;" CssClass="lablestyle" Font-Bold="true"></asp:Label>&nbsp;
                            </td>
                            <td >
                                :&nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="DropProcess" CssClass="dropdownstyle" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="DropProcess_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 5px;">
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label1" runat="server" Text="TYPE" style="font-family:Times New Roman;" CssClass="lablestyle" Font-Bold="true"></asp:Label>&nbsp;
                            </td>
                            <td >
                                :&nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="DropType" CssClass="dropdownstyle" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="DropType_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">-Select-</asp:ListItem>
                                    <asp:ListItem Value="1">Work Instruction</asp:ListItem>
                                    <asp:ListItem Value="2">Control Plan</asp:ListItem>
                                    <asp:ListItem Value="3">Drawing</asp:ListItem>
                                    <asp:ListItem Value="4">Offset</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                                <div style="margin-left: -100px;" id="div_user" runat="server">
                                    <asp:GridView ID="grid_viewresult" runat="server" AutoGenerateColumns="false" Width="950"
                                        BorderColor="#4c6c9f" BorderStyle="Solid" BorderWidth="2">
                                        <RowStyle CssClass="GridItem" />
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderText="Select" HeaderStyle-BackColor="#4c6c9f"
                                                HeaderStyle-ForeColor="#FFFFFF">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ch_view" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="file path" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_path" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FilePath") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PartNo" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF"
                                                Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_partno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PartNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="File Name" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_filename" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SourceName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="File Type" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF"
                                                Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_filetype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "type") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Process" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF"
                                                Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_process" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "process") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <br />
                                <div align="center" id="div_error" runat="server" visible="false">
                                    <span style="color: Red; font-size: 20px; font-family: Arial;" id="spn_error" runat="server">
                                    </span>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="height: 2px;">
                <td colspan="3" align="center">
                    <div id="div_errorr" style="display: none; padding-left: 50px;">
                        <span id="spnerror" style="font-family: Arial; font-size: 14px; color: Red;"></span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                   
                    <div style="padding-left: 250px;">
                        <asp:ImageButton ID="btnView" ImageUrl="~/Menu_image/view.jpg" runat="server" OnClick="Save"
                            OnClientClick="return validate_userpage();" />
                    </div>
                </td>
            </tr>
        </table>
        <input type="hidden" id="hdn_process" runat="server" name="hdn_process" />
    </div>
</asp:Content>