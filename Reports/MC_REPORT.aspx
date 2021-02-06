<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MC_REPORT.aspx.cs" Inherits="MC_REPORT" %>
--%>

<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="MC_REPORT.aspx.cs" Inherits="MC_REPORT" Title="PH :: PLANT OEE/LET" EnableEventValidation="false" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
function machinevalidate()
{
  if(!validate_rptunit()) return false 
 if(!validate_rptmachine())return false 
 if(!validate_rptProcess()) return false 
 if(!validate_rptmcshift()) return false 
 if(!checkfromdate())return false
 if(!checktodate())return false
}
function validate_rptunit()
{
  var mach=$("select[id$='ddl_unit']").val();
 if(mach==null || mach=="0"|| mach=="-Select-")
 {
  $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select unit');
        $("select[id$='ddl_unit']").focus()
  
     return false;
 }
 else
 {
   $("div[id$='diverror']").hide();
      return true;
  }
}
function validate_rptmachine()
 {

 var machn=$("select[id$='Slct_machine_rpt']").val();
 if(machn==null||machn=="0"||machn=="-Select-")
 {
      $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Machine');
        $("select[id$='Slct_machine_rpt']").focus()
     return false;
 }
 else
 {
 $("div[id$='diverror']").hide();
      return true;
  }
 }
 function validate_rptProcess()
 {
 var process=$("select[id$='ddl_process']").val();

 if(process==null||process=="0"||process=="-Select-")
 {
      $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Process');
        $("select[id$='ddl_process']").focus()
     return false;
 }
 else
 {
 $("div[id$='diverror']").hide();
      return true;
  }
 }

function validate_rptmcshift()
{
 var shift=$("select[id$='ddl_shift']").val();
 
 if(shift==null || shift=="0"|| shift=="-Select-")
 {
 $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Shift');
        $("select[id$='ddl_shift']").focus()
    
     return false;
 }
 else
 {
  $("div[id$='diverror']").hide();

      return true;
  }
}

function checkfromdate()
{

  var dt=$("input[id$='txtt_fromdate']").val();
 
    if(dt=="" || dt==null)
    {
    $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select From Date');
        $("input[id$='txtt_fromdate']").focus()
      
       return false;
 }
 else
 {
    $("div[id$='diverror']").hide();
      return true;
  }
}
function checktodate()
{

  var dt=$("input[id$='txtt_todate']").val();
 
    if(dt=="" || dt==null)
    {
    $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select To Date');
        $("input[id$='txtt_todate']").focus()
       
       return false;
 }
 else
 {
        $("div[id$='diverror']").hide();

      return true;
  }
}
$(document).ready(function () {
 
    $("input[id$='txtt_fromdate']").datepick({maxDate: 0,dateFormat: 'mm/dd/yyyy'});
    $("input[id$='txtt_todate']").datepick({maxDate: 0,dateFormat: 'mm/dd/yyyy'});
});
    </script>

</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div style="margin-top: -30px;">
        <table align="left">
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label41" runat="server" Text="REPORT /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label42" runat="server" Text="PLANT OEE/LET" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <div id="div1">
        <table align="center">
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label3" runat="server" Text="UNIT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddl_unit" runat="server" class="dropdownstyle" OnSelectedIndexChanged="onselectedindexchanged_mchn"
                        AutoPostBack="true" onchange="javascript:validate_rptunit();">
                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                        <asp:ListItem Value="ALL">ALL</asp:ListItem>
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
                        <asp:Label ID="Label4" runat="server" Text="MACHINE" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="Slct_machine_rpt" runat="server" class="dropdownstyle" onchange="javascript:validate_rptmachine();">
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
                        <asp:Label ID="Label1" runat="server" Text="PROCESS" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="ddl_process" runat="server" class="dropdownstyle" onchange="javascript:validate_rptProcess();">
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
                        <asp:Label ID="Label2" runat="server" Text="SHIFT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddl_shift" runat="server" class="dropdownstyle" onchange="javascript:validate_rptmcshift();">
                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                        <asp:ListItem Value="A">A</asp:ListItem>
                        <asp:ListItem Value="B">B</asp:ListItem>
                        <asp:ListItem Value="C">C</asp:ListItem>
                        <asp:ListItem Value="G">G</asp:ListItem>
                        <asp:ListItem Value="A1">A1</asp:ListItem>
                        <asp:ListItem Value="B1">B1</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                    <div id="Div1" visible="true" runat="server">
                        <table>
                            <tr align="left">
                                <td>
                                    <b>
                                        <asp:Label ID="Label5" runat="server" Text="FROM" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txtt_fromdate" class="textboxstyle" style="width: 197px;"
                                        runat="server" onchange="javascript:checkfromdate();" />
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
                                    <input type="text" id="txtt_todate" class="textboxstyle" style="width: 197px;" runat="server"
                                        onchange="javascript:checkfromdate();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center">
                        <table>
                            <tr style="height: 10px;">
                                <td colspan="3">
                                    <div align="center" style="display: none; padding-left: 20px;" id="diverror">
                                        <span id="spn_error" style="font-size: 14px; color: Red; font-family: Arial;"></span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <br />
                                <td colspan="3" style="padding-left: 100px;">
                                    <div align="center">
                                        <asp:ImageButton ImageUrl="~/Menu_image/view.jpg" ID="img_view" runat="server" OnClick="Button1_Click"
                                            OnClientClick="return machinevalidate();" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-left: 150px;">
        <table>
            <tr>
                <td>
                    <div runat="server" id="div_lbl" visible="false">
                        <span style="font-family: Arial; font-weight: bold; font-size: 20px; color: Black;">
                            DEPARTMENT REPORT</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="DIV_DEPART" runat="server">
                        <div>
                            <asp:GridView ID="grid_process" runat="server" AutoGenerateColumns="false" Width="1000px">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="id" runat="server" Text='<%#Bind("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Label ID="Test" runat="server" Text='<%# Bind("Eff_cal") %>' Style="font-size: 12px;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Test Bench">
                                        <ItemTemplate>
                                            <asp:Label ID="Painting" runat="server" Text='<%# Bind("TestBench") %>' Style="font-size: 12px;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shaft">
                                        <ItemTemplate>
                                            <asp:Label ID="Valve" runat="server" Text='<%# Bind("Shaft") %>' Style="font-size: 12px;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Block">
                                        <ItemTemplate>
                                            <asp:Label ID="Block" runat="server" Text='<%# Bind("Block") %>' Style="font-size: 12px;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Valve">
                                        <ItemTemplate>
                                            <asp:Label ID="Shaft" runat="server" Text='<%# Bind("Valve") %>' Style="font-size: 12px;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="250" BackColor="White" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Painting">
                                        <ItemTemplate>
                                            <asp:Label ID="Shaft" runat="server" Text='<%# Bind("Painting") %>' Style="font-size: 12px;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div align="center" id="div_exceldept" runat="server" visible="false" style="padding-left: 150px;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="btn_excel" runat="server" ImageUrl="~/Menu_image/Excel.jpg"
                                            OnClick="btn_excel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="div_dept_error" runat="server" visible="false" align="center">
                        <asp:Label ID="lbl_dept" runat="server" Style="color: Red; font-family: Arial; font-size: 14px;
                            font-weight: bold;"></asp:Label>
                    </div>
                    <div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-left: 150px;">
        <table>
            <tr>
                <td>
                    <div runat="server" id="div_lbl_mchn" visible="false">
                        <span style="font-family: Arial; font-weight: bold; font-size: 20px; color: Black;">
                            MACHINE REPORT</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="div_machine" runat="server">
                        <div>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="1000px">
                                <Columns>
                                    <asp:TemplateField HeaderText="MachineName">
                                        <ItemTemplate>
                                            <asp:Label ID="Test" runat="server" Text='<%# Bind("machinename") %>' Style="font-size: 12px;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="100px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OEE">
                                        <ItemTemplate>
                                            <asp:Label ID="Painting" runat="server" Text='<%# Bind("OEE") %>' Style="font-size: 12px;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200px" BackColor="White" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Planned Stop">
                                        <ItemTemplate>
                                            <asp:Label ID="Valve" runat="server" Text='<%# Bind("plannedstop") %>' Style="font-size: 12px;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200px" BackColor="White" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Produced Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="Block" runat="server" Text='<%# Bind("producedqty") %>' Style="font-size: 12px;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200px" BackColor="White" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Downtime Loss">
                                        <ItemTemplate>
                                            <asp:Label ID="Shaft" runat="server" Text='<%# Bind("downtimeloss") %>' Style="font-size: 12px;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="200px" BackColor="White" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Downtime Type">
                                        <ItemTemplate>
                                            <asp:Label ID="Shaft" runat="server" Text='<%# Bind("downtimetype") %>' Style="font-size: 12px;"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle Width="250" BackColor="White" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div align="center" id="div_excelmac" runat="server" visible="false" style="padding-left: 150px;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="img_btnmacexcel" runat="server" ImageUrl="~/Menu_image/Excel.jpg"
                                            OnClick="img_btnmacexcel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="div_mchn_error" runat="server" visible="false" align="center">
                        <asp:Label ID="lbl_mchn" runat="server" Style="color: Red; font-family: Arial; font-size: 14px;
                            font-weight: bold;"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
