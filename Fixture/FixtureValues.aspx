<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="FixtureValues.aspx.cs" Inherits="FixtureValues" Title="PH :: ADD FIXTURE VALUES" EnableEventValidation="false" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/Fixture.js" type="text/javascript"></script>

    <%--<style>
        /* NOTE: The styles were added inline because Prefixfree needs access to your styles and they must be inlined if they are on local disk! */section
        {
            display: none;
            padding: 20px 0 0;
            border-top: 1px solid #ddd;
        }
        input
        {
            display: none;
        }
        label
        {
            display: inline-block;
            margin: 0 0 -1px;
            padding: 15px 25px;
            font-weight: 600;
            text-align: center;
            color: #bbb;
            border: 1px solid transparent;
        }
        label:before
        {
            font-family: fontawesome;
            font-weight: normal;
            margin-right: 10px;
        }
        label[for*='1']:before
        {
            content: '\f1cb';
        }
        label[for*='2']:before
        {
            content: '\f17d';
        }
        label[for*='3']:before
        {
            content: '\f16b';
        }
        label[for*='4']:before
        {
            content: '\f1a9';
        }
        label:hover
        {
            color: #888;
            cursor: pointer;
        }
        input:checked + label
        {
            color: #555;
            border: 1px solid #ddd;
            border-top: 2px solid orange;
            border-bottom: 1px solid #fff;
        }
        #tab1:checked ~
        #content1, #tab2:checked ~
        #content2, #tab3:checked ~
        #content3, #tab4:checked ~
        #content4
        {
            display: block;
        }
        .classTD
        {
            background-color: #4C6C9F;
            color: #fff;
            border-right: solid 1px #fff;
            text-align: center;
        }
        .classTR
        {
            background-color: #fff;
            color: #000;
            border-right: solid 1px #000;
            border-bottom: solid 1px #000;
            text-align: center;
        }
    </style>--%>

    <script src="../JS/ActualEntry.js" type="text/javascript"></script>

    <script type="text/javascript">
$(document).ready(function()
{

$("input[id$='txt_fix']").show();
$("input[id$='txtfixlife']").show();
$("input[id$='txt_grom']").show();
$("input[id$='txt_gto']").show();
$("input[id$='txt_yfrom']").show();
$("input[id$='txt_yto']").show();
$("input[id$='txt_rfrom']").show();
$("input[id$='txt_rto']").show();
//pageload();
GetProcess();
});

function onlyNumbers(evt) {
    var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)&& charCode != 46){
    alert("Accept only number !!");
        return false;
        }
        else{
    return true;
    }
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
    <div style="margin-top: -30px;">
        <table>
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label7" runat="server" Text="MASTER /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="ADD FIXTURE VALUES" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <%--<div style="margin-top: 50px; margin-left: 30px;">
        <input id="tab1" type="radio" name="tabs" checked="checked" />
        <label for="tab1">
            Fixture Number</label>
        <input id="tab2" type="radio" name="tabs" />
        <label for="tab2">
            Fixture Values</label>
        <section id="content1">
   <div align="center" style="margin-top:50px; margin-left:150px;">
   <table width="1000">
            <tr>
                <td>
                    <div style="padding: 10px 10px 10px 80px;">
                        <table>
                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label  runat="server" Text="Part No" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <select id="ddl_partno" runat="server" class="dropdownstyle" onchange="javascript:v_partno();">
                                    </select>
                                </td>
                            </tr>
                            <tr style="height: 15px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label2" runat="server" Text="Fixture Number" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                <input type="text" id="txt_fix" class="textboxstyle" onblur="javascript:v_fixname();" />
                                </td>
                            </tr>
                             <tr style="height: 10px;">
                                <td colspan="3">
                                </td>
                            </tr>
                             <tr style="height: 10px;">
                                <td colspan="3" align="center">
                                    <div id="div_error1" style="display: none; padding-left: 100px;">
                                        <span id="spnerror1" style="font-family: Arial; font-size: 14px; color: Red;"></span>
                                    </div>
                                </td>
                            </tr>
                             <tr style="height: 10px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr style="height: 15px;">
                                <td colspan="3">
                                
                                    <div align="center" id="div_save">
                                    <img src="../Menu_image/save.jpg" id="btn_save"  style="cursor:pointer;" alt=""/>
                                    </div>
                                     <div align="center" id="div_updatge" style="display:none;">
                                    <img src="../Menu_image/Submit.jpg"  id="btn_update"  style="cursor:pointer;" alt=""/>
                                    </div>
                                 
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                   
                </td>
            </tr>
        </table>
   </div>
    <div style="width:800px; margin-left:250px;" align="center">
                    <div id="div_fixname"></div>
                    </div>
  </section>
        <section id="content2">
   
    <div style="width:1300px; margin-left:1px;" align="center">
                    <div id="div_fixvalues"></div>
                    </div>
  </section>
    </div>--%>
    <div align="center" style="margin-top: 50px; margin-left: 150px;">
        <table width="1000">
            <tr>
                <td>
                    <div style="padding: 10px 10px 10px 80px;">
                        <table>
<%--                            <tr style="height: 5px;">
                                <td colspan="3">
                                </td>
                            </tr>--%>
                            <tr style="display:none;">
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
                                    <asp:DropDownList ID="ddl_partnumber" CssClass="dropdownstyle" runat="server" OnSelectedIndexChanged="ddl_partnumber_SelectedIndexChanged"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="height: 15px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label3" runat="server" Text="Fixture Number" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_fixturename" CssClass="dropdownstyle" runat="server">
                                        <asp:ListItem Value="0" Selected="True">--- Select Fixture Number ---</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="height: 10px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label4" runat="server" Text="Fixture Operation" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <select id="ddloperation" runat="server" class="dropdownstyle">
                                      <%--  <option value="0" selected="selected">--- Select Operation --</option>
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
                                        <option value="Grinding">Grinding</option> --%>
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
                                        <asp:Label ID="Label5" runat="server" Text="Fixture Life" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txtfixlife" class="textboxstyle" runat="server" onkeypress="return onlyNumbers(this);"/>
                                </td>
                            </tr>
                            <tr style="height: 10px;">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>
                                        <asp:Label ID="Label2" runat="server" Text="Drawing Availability" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
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
                                    <b>
                                        <asp:Label ID="Label11" runat="server" Text="Drawing" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
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
                                 <b>
                                        <asp:Label ID="Label12" runat="server" Text="Photo" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
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
                                    <b>
                                        <asp:Label ID="Label6" runat="server" Text="Fixture life at<br> usable condition in %"
                                            Style="font-family: Times New Roman; color: Green;" CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <div>
                                        <table>
                                            <tr>
                                                <td>
                                                    <span class="lablestyle">From</span>
                                                </td>
                                                <td>
                                                    <input type="text" id="txt_grom" class="textboxstyle" runat="server" style="width: 183px;" onkeypress="return onlyNumbers(this);"/>
                                                </td>
                                                <td>
                                                    <span class="lablestyle">To</span>
                                                </td>
                                                <td>
                                                    <input type="text" id="txt_gto" class="textboxstyle" runat="server" style="width: 183px;" onkeypress="return onlyNumbers(this);"/>
                                                </td>
                                            </tr>
                                        </table>
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
                                        <asp:Label ID="Label9" runat="server" Text="Alert for fixture Calibration<br>& Re order Zone in %"
                                           ForeColor="Orange" Style="font-family: Times New Roman;" CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <div>
                                        <table>
                                            <tr>
                                                <td>
                                                    <span class="lablestyle">From</span>
                                                </td>
                                                <td>
                                                    <input type="text" id="txt_yfrom" class="textboxstyle" runat="server" style="width: 183px;" onkeypress="return onlyNumbers(this);" />
                                                </td>
                                                <td>
                                                    <span class="lablestyle">To</span>
                                                </td>
                                                <td>
                                                    <input type="text" id="txt_yto" class="textboxstyle" runat="server" style="width: 183px;" onkeypress="return onlyNumbers(this);" />
                                                </td>
                                            </tr>
                                        </table>
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
                                        <asp:Label ID="Label10" runat="server" Text="Fixture life Completed in %" Style="font-family: Times New Roman;
                                            color: Red;" CssClass="lablestyle">
                                        </asp:Label></b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <div>
                                        <table>
                                            <tr>
                                                <td>
                                                    <span class="lablestyle">From</span>
                                                </td>
                                                <td>
                                                    <input type="text" id="txt_rfrom" class="textboxstyle" runat="server" style="width: 183px;" onkeypress="return onlyNumbers(this);" />
                                                </td>
                                                <td>
                                                    <span class="lablestyle">To</span>
                                                </td>
                                                <td>
                                                    <input type="text" id="txt_rto" class="textboxstyle" runat="server" style="width: 183px;" onkeypress="return onlyNumbers(this);" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"> 
                                    <div style="margin-top: 10px; display: none; margin-left: 0px;" id="div_fix_life_extended">
                                        <table >
                                            <tr>
                                                <td align="left" style="width:180px;">
                                                    <span class="lablestyle" style="font-family: Times New Roman;">Life Completed</span>
                                                </td>
                                                <td >
                                                    :
                                                </td>
                                                <td >
                                                    <asp:DropDownList ID="ddl_fixclose" CssClass="dropdownstyle" runat="server">
                                                        <asp:ListItem Value="0" Selected="True">--- Select ---</asp:ListItem>
                                                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                        <asp:ListItem Value="No">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%--<input type="text" id="txt_replaced" class="textboxstyle" runat="server" />--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" >
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <span class="lablestyle" style="font-family: Times New Roman;">Life Extended</span>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <input type="text" id="txt_extended" class="textboxstyle" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
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
                                        <div align="center" style="padding-left: 30px;" id="div_fistruesave" runat="server">
                                            <asp:ImageButton ID="btn_submit" runat="server" Text="Save" color="black" ImageUrl="~/Menu_image/Save.jpg"
                                                OnClientClick="return valMbufixValues();" OnClick="btn_submit_Click" />
                                                
                                                 <asp:ImageButton ID="ImageButton2" runat="server" Text="Clear" color="black" ImageUrl="~/Menu_image/Clear.jpg"
                                                 OnClick="btn_Clear_Click" />
                                        </div>
                                        <div align="center" style="padding-left: 30px; display: none;" id="div_fistrueupdate"
                                            runat="server">
                                            <asp:ImageButton ID="btn_update" runat="server" ImageUrl="~/Menu_image/Submit.jpg"
                                                Style="cursor: pointer;" OnClientClick="return valMbufixValues1();" OnClick="btn_update_Click" /></div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </div>

                    
    <div>
        
        <div align="center" id="div_cycle" runat="server">
            <div><table><tr><td><div style="padding-left: 1200px;">
                        <asp:ImageButton ID="btn_excel" Visible="false" runat="server" Text="Excel" color="black" ImageUrl="~/Menu_image/Export.png"
                            OnClick="ExportToPDF"/>
                    </div></td></tr></table></div>
        
            <table>
                <tr>
                    <td>
                        <div>
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
                                        <div style="word-wrap: break-word; width: 400px;font-size: 20px; text-align: center;">
                                            <asp:Label ID="lbl_part" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Partno") %> '
                                                Style="font-size: 20px; text-align: center;"></asp:Label>
                                                </div>
                                        </ItemTemplate>
                                        <HeaderStyle Width="400" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="400" BackColor="White" HorizontalAlign="Center" BorderColor="Black"
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
                                    <asp:TemplateField HeaderText="Drawing">
                                        <ItemTemplate>
                                            <%--<asp:Image ID="ph_drawing" Style="width: 145px; height: 100px;" runat="server" />--%>
                                            <asp:HyperLink ID="ph_drawing" Target="_blank" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="150" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="150" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Green From">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_grfrom" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GreenRange") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label><span>%</span>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="Green" HorizontalAlign="Center" BorderColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Green To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_grto" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GreenRange1") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label><span>%</span>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="Green" HorizontalAlign="Center" BorderColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Yellow From">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ylwfrom" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "YellowRange") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label><span>%</span>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="Yellow" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Yellow To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ylwto" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "YellowRange1") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label><span>%</span>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="Yellow" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Red From">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_redfrom" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RedRange") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label><span>%</span>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="Red" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Red To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_redto" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RedRange1") %>'
                                                Style="font-size: 20px; text-align: center;"></asp:Label><span>%</span>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" BackColor="Red" HorizontalAlign="Center" BorderColor="Black"
                                            ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ControlStyle-Width="50pt">
                                        <ItemTemplate>
                                            <a id="<%# Eval("Fid") %>" onclick="javascript:editfixvalue(this.id);">
                                                <img src="../Images/Edit.jpg" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                            </a>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                                        <ItemTemplate>
                                            <a id="<%# Eval("Fid") %>" onclick="javascript:deletefixvalue(this.id);">
                                                <img src="../Images/Delete.png" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                            </a>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixture Count">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_fixcount" runat="server" Style="font-size: 20px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" HorizontalAlign="Center" BorderColor="Black" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_status" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100" HorizontalAlign="Center" BorderColor="Black" />
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
    </div>
    <div>
        <input type="hidden" id="hdn_operation" name="hdn_operation" runat="server" />
        <input type="hidden" id="hdn_cell" name="hdn_cell" runat="server" />
        <input type="hidden" id="hdn_mach" name="hdn_mach" runat="server" />
        <input type="hidden" id="hdn_id" name="hdn_id" runat="server" />
        <input type="hidden" id="hdn_green" name="hdn_green" />
        <input type="hidden" id="hdn_yellow" name="hdn_yellow" />
        <input type="hidden" id="hdn_red" name="hdn_red" />
    </div>
        <div>  
          <%--  <CR:CrystalReportViewer ID="CRV" runat="server" AutoDataBind="true" />    --%>  
        </div>
</asp:Content>

