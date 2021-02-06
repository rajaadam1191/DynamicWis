<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="ViewQCSheetReports.aspx.cs" Inherits="ViewQCSheetReports" Title="PH :: QC REPORTS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />
    <%--<script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>--%>

    <script src="../JS/report.js" type="text/javascript"></script>

    <script src="../JS/QualitySheetscript.js" type="text/javascript"></script>

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

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
$('#ddl_operation').focus();
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
searchbox.style['height'] = '15px';
$('#searchbox').focus();
searchbox.onkeypress = function() { setTimeout('HandleKey();', 10); };
// Returns a collection of objects with the specified element name.
selects = el.getElementsByTagName('select').item(0);

// Returns a reference to the element that is inserted into the document.
el.insertBefore(searchbox, selects);
}

    $(document).ready(function()
{
    $("input[id$='txt_fromdate']").datepick({maxDate: 0,dateFormat: 'dd/mm/yyyy'});
    $("input[id$='txt_todate']").datepick({maxDate: 0,dateFormat: 'dd/mm/yyyy'});
    AttachSearch('searchit');
});
    </script>

    <style type="text/css">
        .errorControls
        {
            border: solid 1px red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <div style="margin-top: -30px;">
            <table align="left">
                <tr>
                    <td>
                     &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label41" runat="server" Text="REPORT /" valign="left" Font-Bold="true"
                            Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="Label42" runat="server" Text="QC REPORT" valign="left" Font-Bold="true"
                            Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div align="center" style="margin-top: 30px;">
            <table>
             <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label4" runat="server" Text="UNIT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddl_unit_QC" runat="server" class="dropdownstyle" 
                        AutoPostBack="true">
                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                        <%--<asp:ListItem Value="ALL">ALL</asp:ListItem>--%>
                        <asp:ListItem Value="MBU">MBU</asp:ListItem>
                        <asp:ListItem Value="ABU">ABU</asp:ListItem>
                    </asp:DropDownList>
                    <%-- <select id="ddl_unit" class="dropdownstyle1" runat="server" OnSelectedIndexChanged="onselectedindexchanged_mchn" onblur="javascript:validate_rptunit();">
                        <option value="ALL">ALL</option>
                        <option value="MBU">MBU</option>
                        <option value="ABU">ABU</option>
                    </select>--%>
                </td>
            </tr>
                        <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label6" runat="server" Text="CELL" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <%--<select id="Slct_Cell_QC" runat="server" class="dropdownstyle" onchange="javascript:getmachine();">
                        <option value="0" selected="selected">-Select-</option>
                    </select>--%>
                   <asp:DropDownList ID="Slct_Cell_QC" runat="server"  CssClass="dropdownstyle" OnSelectedIndexChanged="onselectedindexchanged_Cell"  AutoPostBack="true"> 
                        </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label7" runat="server" Text="MACHINE" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="Slct_machine_QC" runat="server" class="dropdownstyle" >
                        <option value="0" selected="selected">-Select-</option>
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
                        <asp:Label ID="Label2" runat="server" Text="PART NO" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                      
                    </td>
                    <td style="width: 15px; color: Black;">
                        :
                    </td>
                    <td>
                     <div id="searchit">
                        <asp:DropDownList ID="ddl_prodn_no" runat="server"  Width="398px" CssClass="dropdownstyle" onchange="javascript:validate_prodtno();" >
                        </asp:DropDownList>
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
                    <td style="width: 15px; color: Black;">
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_operation" runat="server" CssClass="dropdownstyle" onchange="javascript:validate_operation();">
                        </asp:DropDownList>
                    </td>
                </tr>
                <%-- <tr style="height: 5px;">
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td class="lablestyle">
                        PID NO
                    </td>
                    <td style="width: 15px; color: Black;">
                        :
                    </td>
                    <td>
                        <select id="sld_pidno" runat="server" class="dropdownstyle">
                            <option value="0">-Select-</option>
                        </select>
                    </td>
                </tr>--%>
                <tr style="height: 5px;">
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                         <b>
                        <asp:Label ID="Label3" runat="server" Text="SHIFT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                    </td>
                    <td style="width: 15px; color: Black;">
                        :
                    </td>
                    <td>
                        <select id="ddl_shift" runat="server" class="dropdownstyle" >
                            <option value="O">-Select-</option>
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
<%--                    <div>
                        <td align="left">
                            <b>
                                <asp:Label ID="Label5" runat="server" Text="FROM" Style="font-family: Times New Roman;"
                                    CssClass="lablestyle">
                                </asp:Label></b>
                        </td>
                        <td style="width: 15px; color: Black;">
                            :
                        </td>
                        <td>
                            <input type="text" id="txt_fromdate" class="textboxstyle" style="width: 441px;" runat="server" />
                        </td>
                    </div>--%>
                    <td colspan="3">
                        <div >
                        <table>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label5" runat="server" Text="FROM" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td style="padding-left:32px;">
                                    :
                                </td>
                                <td style="padding-left:10px;">
                                    <input type="text" id="txt_fromdate" class="textboxstyle" style="width: 197px;" runat="server" />
                                </td>
                                <td>
                                </td>
                                <td >
                                    <b>
                                        <asp:Label ID="Label8" runat="server" Text="TO" Style="font-family: Times New Roman;"
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
                <tr style="height: 20px;">
                    <td colspan="3">
                        <div align="center" id="divqcerror" style="display: none; padding-left: 50px;">
                            <span id="spn_qcerror" style="color: Red; font-family: Arial; font-weight: bold;
                                font-size: 14px;"></span>
                        </div>
                    </td>
                </tr>
                <tr style="height: 5px;">
                    <td colspan="3">
                        <div align="center" style="padding-left: 80px;">
                            <asp:ImageButton ID="btn_viewreports" ImageUrl="~/Menu_image/view.jpg" runat="server"
                                OnClick="btn_viewreports_Click" OnClientClick="return validateQCReports();" />
                        </div>
                    </td>
                </tr>
                
            </table>
        </div>
        <br />
        
        <div style="" id="div_result" runat="server" align="center">
            <asp:GridView ID="grid_viewresult" runat="server" AutoGenerateColumns="false" Width="950"
                BorderColor="#4c6c9f" BorderStyle="Solid" BorderWidth="2" OnRowCommand="grid_viewresult_RowCommand">
                
                <RowStyle CssClass="GridItem" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                        <ItemTemplate>
                            <asp:Label ID="lbl_sno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" HorizontalAlign="Center" />
                    </asp:TemplateField>
<%--                    <asp:TemplateField HeaderText="Rno" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF"
                        Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_rowid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Fileid") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="file path" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_path" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FilePath") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" />
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="file path" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_prtno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Product_PN") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="PartNo" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                        <ItemTemplate>
                            <asp:Label ID="lbl_partno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ProductPN") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                        <ItemTemplate>
                            <asp:Label ID="lbl_pidno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PID_No") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" HorizontalAlign="Center" />
                    </asp:TemplateField>
<%--                    <asp:TemplateField HeaderText="Operation" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                        <ItemTemplate>
                            <asp:Label ID="lbl_opertaion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Operantion") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Shift" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                        <ItemTemplate>
                            <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Shift") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Name" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                        <ItemTemplate>
                            <asp:Label ID="lbl_filename" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FileName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Created Date" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                        <ItemTemplate>
                            <asp:Label ID="lbl_createdate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CreatedOn","{0:dd MMM yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="View" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                        <ItemTemplate>
                            <asp:ImageButton ID="img_view" ImageAlign="Middle" runat="server" ImageUrl="~/Menu_image/view.jpg"
                                Height="30" Width="100" CommandName="Show" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
                        </ItemTemplate>
                        <ItemStyle BackColor="#b9d2ef" BorderColor="#4c6c9f" HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div align="center" id="div_error" runat="server" visible="false">
            <span style="color: Red; font-family: Arial; font-size: 16px;">No Record found</span>
        </div>
        <br />
    </div>
</asp:Content>
