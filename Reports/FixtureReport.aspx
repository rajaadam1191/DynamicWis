<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="FixtureReport.aspx.cs" Inherits="FixtureReport" Title="PH :: FIXTURE REPORTS"
    EnableEventValidation="false" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />
    <%--<script src="JS/jquery.easing.1.3.js" type="text/javascript"></script>--%>
    <%--<script src="JS/jquery.min.js" type="text/javascript"></script>--%>
    <link href="../Styles/Chart.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/quicksearch.js" type="text/javascript"></script>

    <script type="text/javascript">
    
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
$('#ddl_cpartno').focus();
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

$(function () {
    $('.search_textbox').each(function (i) {
        $(this).quicksearch("[id*=grid_fixture] tr:not(:has(th))", {
            'testQuery': function (query, txt, row) {
                return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
            }
        });
    });
});
        
    $(document).ready(function()
    {   
        loadpartno();
        getmachine_fix();
        AttachSearch('searchit');
    });
    </script>

    <style >
        .search_textbox
        {
            text-align: center;
            border: solid 1px #000;
            width:100px;
        }
        .drop
        {
            width: 500px;
            height: 50px;
        }
        .tdclass
        {
            background-color:#fff;
            font-size:14px;
            font-family:Arial;
            font-weight:bold;
            border-bottom:solid 1px #000;
            text-align:center;
        }
        .trclass1
        {
            border:solid 1px gray;
        }
        .spn
        {
            font-size:14px;
            font-family:Arial;
            font-weight:bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div runat="server" id="div_chart" style="width: 1350px; background-color: #eefaff;"
        align="center">
        <ul class="tabs" data-persist="true">
            <li id="link_one"><a href="#"><span>Fixture History</span></a></li>
            <li id="link_two"><a href="#"><span>Calibration Trend</span></a></li>
            <%--<li id="link_three"><a href="#"><span>Fixture Change</span></a></li>--%>
        </ul>
        <div class="tabcontents" align="center" style="background-color: #eefaff;">
            <div id="view1">
            
                <div style="margin: 20px 0px 20px 0px;">
                    <table>
                        <tr style="display:none;">
                            <td>
                                <span class="lablestyle">Part No</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <select id="ddl_partno" class="dropdownstyle" onchange="javascript:getfixno();v_partno();"
                                    runat="server">
                                    <option value="0" selected="selected">--- Select Part No ---</option>
                                </select>
                            </td>
                        </tr>
                        <tr style="height: 10px;">
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="lablestyle">Fixture No</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <%--<select id="ddl_fixno" class="dropdownstyle" onchange="javascript:v_fno();" runat="server">
                                    <option value="0" selected="selected">--- Select Fixture No ---</option>
                                </select>--%>
                                <asp:DropDownList ID="ddl_fixno" CssClass="dropdownstyle" runat="server">
                                    <asp:ListItem Value="0" Selected="True">--- Select Fixture Number ---</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 10px;">
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="lablestyle">Operation</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <select id="ddl_operation" class="dropdownstyle" onchange="javascript:v_op();" runat="server">
                                   <%-- <option value="0" selected="selected">--- Select Operation ---</option>
                                        <option value="1">First</option>
                                        <option value="2">Second</option>
                                        <option value="1">Operation 1</option>
                                        <option value="2">Operation 2</option>
                                        <option value="Lapping">Lapping</option>
                                        <option value="Polishing">Polishing</option>
                                        <option value="Sanding">Sanding</option>
                                        <option value="Engraving">Engraving</option>
                                        <option value="Deburring">Deburring</option>
                                        <option value="PackingValue">Packing Value</option>
                                        <option value="Grinding">Grinding</option>--%>
                                </select>
                            </td>
                        </tr>
                        <tr style="height: 10px;">
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="lablestyle">Machine</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <select id="ddl_machine" class="dropdownstyle" onchange="javascript:v_mach();" runat="server">
                                    <option value="0" selected="selected">--- Select Machine ---</option>
                                </select>
                            </td>
                        </tr>
                        <tr style="height: 30px;">
                            <td colspan="3">
                                <div align="center" id="div_error" style="display: none;">
                                    <span style="font-family: Arial; color: Red; font-size: 15px;" id="spn_error"></span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <div align="center">
                                    <asp:ImageButton ImageUrl="~/Menu_image/Submit.jpg" runat="server" ID="btn_search"
                                        OnClientClick="return checksearch();" OnClick="btn_search_Click" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="margin-left: -17px; display:none;">
                    <asp:GridView ID="GridView1" runat="server" BorderColor="AliceBlue" AutoGenerateColumns="false"
                        OnDataBound="OnDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.No" HeaderStyle-ForeColor="#FFFFFF">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_sno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" Height="30" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" Height="50" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Part No">
                                <ItemTemplate>
                                <div style="word-wrap: break-word; width: 400px;font-size: 20px; text-align: center;">
                                    <asp:Label ID="lbl_process" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Partno") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                       </div>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Height="25" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Operation">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Operation") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fixture No">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Fixtureno") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Due for Fixture Calibration">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "YellowOpenDate") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fixture Calibrated Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "YellowCloseDate") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fixture Life Completed Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RedOpenDate") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Calibration Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "YellowStatus") %>'
                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="margin-left: -17px;">
                    <asp:GridView ID="grid_fixture" runat="server" BorderColor="AliceBlue" 
                                AutoGenerateColumns="false" onrowdatabound="grid_fixture_RowDataBound" OnDataBound="OnDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                        <ItemTemplate>
                                           <%-- <%# Container.DataItemIndex+1 %>--%>
                                           <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "IndexNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Fid") %>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_fixture" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Fixturename") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" Height="30" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Model Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_model" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Model") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" Height="30" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Part Number">
                                        <ItemTemplate>
                                        <div style="word-wrap: break-word; width: 250px;font-size: 20px; text-align: center;">
                                            <asp:Label ID="lbl_part" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Partnumber") %> '
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                                </div>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Life">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_life" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FixLife") %> '
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Operation">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_oper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Operation") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
<%--                                    <asp:TemplateField HeaderText="Spare Availability">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_spare" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "currentstock") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Photo">
                                        <ItemTemplate>
                                            <asp:Image ID="ph_image" Style="width: 150px; height: 100px;" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="150" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="150" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Count">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_fixcount" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_remarks" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Calibration Done On">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_modify" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModifyDate") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                </div>
                
                        <br />
        <div ><table><tr><td style="color:Black"><asp:Label id="spn_toolf" runat="server" visible="false">Fixture Feedback</asp:Label></td></tr></table></div>
         <br />
    <div align="center">
        <asp:GridView ID="GridView2" runat="server" BorderColor="AliceBlue" AutoGenerateColumns="false"
             >
            <Columns>
                <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle BackColor="White" BorderColor="Black" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF"
                    Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbl_fid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FBID") %>'
                            Visible="false"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Name">
                    <ItemTemplate>
                        <asp:Label ID="lbl_UName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "U_Name") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" HorizontalAlign="Center" Height="30" BackColor="White" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Shift">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Shift" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Shift") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cell">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Cell" runat="server" Style="font-size: 15px; text-align: center;"
                            Text='<%#DataBinder.Eval(Container.DataItem, "Cell") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Machine">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Machine" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Machine") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FeedBack">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Machine" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FeedBack") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FeedBack Date">
                    <ItemTemplate>
                        <asp:Label ID="lbl_desc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FB_Date") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Response">
                    <ItemTemplate>
                        <asp:Label ID="lbl_retine" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Response") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Response date">
                    <ItemTemplate>
                        <asp:Label ID="lbl_issued" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FB_Rdate") %>'
                            Style="font-size: 15px; text-align: center;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
                <div>
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
                <div align="center" id="div_pdf" runat="server" visible="false">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <div>
                                        <asp:ImageButton ImageUrl="~/Menu_image/Excel.jpg" runat="server" ID="btn_pdf" OnClick="btn_pdf_Click" /></div>
                                </td>
                                <td style="width:100px;"></td>
                                <td>
                                    <div>
                                        <asp:ImageButton ImageUrl="~/Menu_image/print.jpg" runat="server" 
                                            ID="btn_print" onclick="btn_print_Click" /></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            
            <div id="view2" style="display: none;">
                <div>
                    <div style="margin: 20px 0px 20px 0px;">
                        <table>
                            <tr>
                                <td>
                                    <span class="lablestyle">Part No</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                 <div id="searchit">
                                    <select id="ddl_cpartno" class="dropdownstyle" onchange="javascript:getfixno1();va_partno();"
                                        runat="server" style="width:398px;">
                                        <option value="0" selected="selected">--- Select Part No ---</option>
                                    </select>
                                    </div>
                                </td>
                            </tr>
                            <tr style="height: 10px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="lablestyle">Fixture No</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <select id="ddl_cfixno" class="dropdownstyle" onchange="javascript:va_fixno();" runat="server">
                                        <option value="0" selected="selected">--- Select Fixture No ---</option>
                                    </select>
                                </td>
                            </tr>
                            <tr style="height: 10px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="lablestyle">Operation</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <select id="ddl_coperation" class="dropdownstyle" onchange="javascript:va_operation();"
                                        runat="server">
                                         <%--<option value="0" selected="selected">--- Select Operation ---</option>
                                         <option value="1">First</option>
                                        <option value="2">Second</option>
                                        <option value="1">Operation 1</option>
                                        <option value="2">Operation 2</option>
                                        <option value="Lapping">Lapping</option>
                                        <option value="Polishing">Polishing</option>
                                        <option value="Sanding">Sanding</option>
                                        <option value="Engraving">Engraving</option>
                                        <option value="Deburring">Deburring</option>
                                        <option value="PackingValue">Packing Value</option>
                                        <option value="Grinding">Grinding</option>--%>
                                    </select>
                                </td>
                            </tr>
                            <tr style="height: 10px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="lablestyle">Machine</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <select id="ddl_cmachine" class="dropdownstyle" onchange="javascript:va_machine();"
                                        runat="server">
                                        <option value="0" selected="selected">--- Select Machine ---</option>
                                    </select>
                                </td>
                            </tr>
                            <tr style="height: 10px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="lablestyle">Year</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_year" runat="server" AutoPostBack="false" CssClass="dropdownstyle"
                                        onchange="javascript:va_year();">
                                    </asp:DropDownList>
                                    <%--<select id="ddl_year" class="dropdownstyle" onchange="javascript:v_mach();" runat="server">
                                        
                                    </select>--%>
                                </td>
                            </tr>
                            <tr style="height: 10px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="lablestyle">Month</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <div>
                                        <table>
                                            <tr>
                                                <td>   </td>
                                                <td>From</td>
                                                    
                                             
                                                <td><select id="ddl_month" class="dropdownstyle" onchange="javascript:va_month();" runat="server"
                                                        style="width: 180px;">
                                                        <option value="0" selected="selected">--- Select Month ---</option>
                                                        <option value="1">January </option>
                                                        <option value="2">February </option>
                                                        <option value="3">March </option>
                                                        <option value="4">April </option>
                                                        <option value="5">May </option>
                                                        <option value="6">June </option>
                                                        <option value="7">July </option>
                                                        <option value="8">August </option>
                                                        <option value="9">September </option>
                                                        <option value="10">October </option>
                                                        <option value="11">November </option>
                                                        <option value="12">December </option>
                                                    </select></td>
                                                <td>TO</td>
                                                <td>
                                                
                                                    <select id="ddl_monthto" class="dropdownstyle" onchange="javascript:va_month1();"
                                                        runat="server" style="width: 180px;">
                                                        <option value="0" selected="selected">--- Select Month ---</option>
                                                        <option value="1">January </option>
                                                        <option value="2">February </option>
                                                        <option value="3">March </option>
                                                        <option value="4">April </option>
                                                        <option value="5">May </option>
                                                        <option value="6">June </option>
                                                        <option value="7">July </option>
                                                        <option value="8">August </option>
                                                        <option value="9">September </option>
                                                        <option value="10">October </option>
                                                        <option value="11">November </option>
                                                        <option value="12">December </option>
                                                    </select>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td colspan="3">
                                    <div align="center" id="div_caerror" style="display: none;">
                                        <span style="font-family: Arial; color: Red; font-size: 15px;" id="spn_caerror">
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div align="center">
                                        <asp:ImageButton ImageUrl="~/Menu_image/Submit.jpg" runat="server" ID="btn_calibrate"
                                            OnClientClick="return checkcalibrte();" OnClick="btn_calibrate_Click" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div>
                    <asp:Chart ID="chart_calibration" runat="server" Width="1300px" Palette="None" Height="720"
                        BackColor="#eefaff" PaletteCustomColors="Navy; Gold; DarkSlateBlue" ImageStorageMode="UseImageLocation">
                        <Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BackColor="white">
                                <AxisY LineColor="SkyBlue" IntervalType="NotSet">
                                    <LabelStyle Font="Arial, 8.25pt, style=Bold" IntervalType="Auto" />
                                    <ScaleBreakStyle LineWidth="2" Spacing="10" />
                                    <MajorGrid LineColor="white" />
                                </AxisY>
                                <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                                    <MajorGrid LineColor="White" Interval="Auto" />
                                    <MajorTickMark Interval="Auto" />
                                    <LabelStyle Font="Microsoft Sans Serif, 8.25pt" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
                <br />
                <div style="margin-left: 420px;">
                    <div align="left">
                        <table>
                            <tr>
                                <td>
                                    <div style="height: 20px; width: 20px; background-color: Navy;">
                                    </div>
                                </td>
                                <td>
                                    <span>No. of. Fixture Alert</span>
                                </td>
                                <td style="width:20px;"></td>
                                <td>
                                    <div style="height: 20px; width: 20px; background-color: Gold;">
                                    </div>
                                </td>
                                <td>
                                    <span>No. of. Fixture Calibrated</span>
                                </td>
                                <td style="width:20px;"></td>
                                <td>
                                    <div style="height: 20px; width: 20px; background-color: DarkSlateBlue;">
                                    </div>
                                </td>
                                <td>
                                    <span>No. of. Life Extended</span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div align="left">
                        <table>
                            <tr>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div align="left">
                        <table>
                            <tr>
                               
                            </tr>
                        </table>
                    </div>
                </div>
                <div>
                    <div id="div_tablecontent">
                    </div>
                </div>
                <br />
                <div align="center" visible="false">
                    <asp:ImageButton ImageUrl="~/Menu_image/print.jpg" runat="server" ID="ImageButton1"
                        OnClick="ImageButton1_Click1" Style="display: none;" />
                </div>
            </div>
            <div id="view3" style="display: none;">
                <div>
                    <div style="margin-left: -17px;">
                    <asp:GridView ID="GridView3" runat="server" BorderColor="AliceBlue" 
                                AutoGenerateColumns="false" onrowdatabound="GridView3_RowDataBound" OnDataBound="changeOnDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                        <ItemTemplate>
                                           <%-- <%# Container.DataItemIndex+1 %>--%>
                                           <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "IndexNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Fid") %>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_fixture" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Fixturename") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" Height="30" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Model Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_model" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Model") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" Height="30" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Part Number">
                                        <ItemTemplate>
                                        <div style="word-wrap: break-word; width: 400px;font-size: 20px; text-align: center;">
                                            <asp:Label ID="lbl_part" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Partno") %> '
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                                </div>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Life">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_life" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FixLife") %> '
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Operation">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_oper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Operation") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Spare Availability">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_spare" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "currentstock") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Photo">
                                        <ItemTemplate>
                                            <asp:Image ID="ph_image" Style="width: 150px; height: 100px;" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="150" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="150" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Count">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_fixcount" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_remarks" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Calibration Done On">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_modify" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModifyDate") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                </div></div>
            </div>
        </div>
        <input type="hidden" id="hdn_part" name="hdn_part" runat="server" />
        <input type="hidden" id="hdn_fix" name="hdn_fix" runat="server" />
        <input type="hidden" id="hdn_op" name="hdn_op" runat="server" />
        <input type="hidden" id="hdn_mach" name="hdn_part" runat="server" />
        <input type="hidden" id="hdn_part1" name="hdn_part1" runat="server" />
        <input type="hidden" id="hdn_fix1" name="hdn_fix1" runat="server" />
        <input type="hidden" id="hdn_op1" name="hdn_op1" runat="server" />
        <input type="hidden" id="hdn_mach1" name="hdn_mach1" runat="server" />
        <input type="hidden" id="hdn_year" name="hdn_year" runat="server" />
        <input type="hidden" id="hdn_month" name="hdn_month" runat="server" />
    </div>
</asp:Content>
