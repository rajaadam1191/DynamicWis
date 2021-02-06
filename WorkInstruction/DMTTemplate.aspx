<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="DMTTemplate.aspx.cs" Inherits="DMTTemplate" Title="PH :: DMT TEMPLATE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script src="../JS/Common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--<form  >--%>
    <center>
        <br />
        <br />
        <br />
        <br />
       
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <link rel="stylesheet" href="css/jquery-ui.css">
        <link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css"></link>

        <script type="text/javascript">
function ConfirmationBox() {

var result = confirm('Are you sure you want to delete this Details?' );
if (result) {

return true;
}
else {
return false;
}
}
        </script>

        <link rel="stylesheet" type="text/css" href="pro_dropdown_2/pro_dropdown_2.css" />

        <script src="pro_dropdown_2/stuHover.js" type="text/javascript"> </script>

        <link href="Styles/CSS.css" rel="stylesheet" type="text/css" />

        <script src="Jquery/jquery-1.3.2.min.js" type="text/javascript"></script>

        <script src="Jquery/jquery.blockUI.js" type="text/javascript"></script>

        <script type="text/javascript">
    function Save()
{
    if(document.getElementById("ID").value=="")
    {
        alert("Please enter Visitor Name");
        document.getElementById("txtVisitor").focus();
        return false;
    }
     if(document.getElementById("ID").value=="")
    {
        alert("Please enter Relation Name");
         document.getElementById("txtRelation").focus();
        return false;
    }
}
        </script>

        <script type="text/javascript">
    function BlockUI(elementID) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(function() {
            $("#" + elementID).block({ message: '<table align = "center"><tr><td>' +
     '<img src="images/loadingAnim.gif"/></td></tr></table>',
                css: {},
                overlayCSS: { backgroundColor: '#507CD1', opacity: 1.0
                }
            });
        });
        prm.add_endRequest(function() {
            $("#" + elementID).unblock();
        });
    }
    $(document).ready(function() {

        BlockUI("<%=pnlAddEdit.ClientID %>");
        $.blockUI.defaults.css = {};
    });
    function Hidepopup() {
        $find("popup").hide();
        return false;
    }
        </script>

        <link rel="stylesheet" href="css/jquery-ui.css">

        <script src="js/jquery-1.10.2.js"></script>

        <script src="js/jquery-ui.js"></script>

        <link rel="stylesheet" href="/resources/demos/style.css">

        <script>
$(function() {
$('CreateDate').datepicker({
    dateFormat: 'mm/dd/yy',
    onSelect: function(datetext){
        var d = new Date(); // for now
        var time_t = "";
        var cur_hour = d.getHours();
        
        (cur_hour < 12) ? time_t = "am" : time_t = "pm";
            (cur_hour == 0) ? cur_hour = 12 : cur_hour = cur_hour;
            (cur_hour > 12) ? cur_hour = cur_hour - 12 : cur_hour = cur_hour;
        datetext=datetext+" "+cur_hour+": "+d.getMinutes()+": "+d.getSeconds()+ " " + time_t;
        $('CreateDate').val(datetext);
    },
});
});

$(function() {
$('RevisionDate').datepicker({
    dateFormat: 'mm/dd/yy',
    onSelect: function(datetext){
        var d = new Date(); // for now
        var time_t = "";
        var cur_hour = d.getHours();
        
        (cur_hour < 12) ? time_t = "am" : time_t = "pm";
            (cur_hour == 0) ? cur_hour = 12 : cur_hour = cur_hour;
            (cur_hour > 12) ? cur_hour = cur_hour - 12 : cur_hour = cur_hour;
        datetext=datetext+" "+cur_hour+": "+d.getMinutes()+": "+d.getSeconds()+ " " + time_t;
        $('RevisionDate').val(datetext);
    },
});
});
        </script>

        <div style="margin-top: -100px;">
          <div style="float: left;">
                <table>
                    <tr>
                    <td>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label32" runat="server" Text="PRODUCTION DOCUMENT /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label33" runat="server" Text="DMT TEMPLATE" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                       
                    </tr>
                </table>
            </div>
            <br />
            <br />
            <br />
            <div>
                <table width="109%">
                    <tr>
                        <td colspan="6">
                            <div id="div_localminus" style="height: 20px; background-color: #4c6c9f">
                                <span style="color: #ffffff; font-size: 120%; cursor: pointer; font-weight: bold;
                                    float: right; padding-right: 10px;"></span><span style="color: #ffffff; font-size: 100%;
                                        font-weight: bold; padding-left: 10px; float: left;">LOCAL</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center" style="margin-left:-200px;">
                                <table>
                                    <tr style="height: 10px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label1" runat="server" Text="DOC.REF" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdocref" runat="server" Text="" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label28" runat="server" Text="Rev" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtrev" runat="server" Text="" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label2" runat="server" Text="Business Unit" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBusiness" runat="server" Text="" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 5px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label3" runat="server" Text="Parts Type" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Parttype" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label4" runat="server" Text="Operation" CssClass="Dmtlable"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <%-- <asp:TextBox ID="Operation" runat="server" CssClass="dmt_textbox"></asp:TextBox>--%>
                                            <asp:DropDownList ID="Operation" runat="server" CssClass="tabdropdown1">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label5" runat="server" Text="SpecificPart" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <%-- <asp:TextBox ID="txtSpecificpartcommon" runat="server" CssClass="dmt_textbox"></asp:TextBox>--%>
                                            <asp:DropDownList ID="txtSpecificpartcommon" runat="server" CssClass="tabdropdown1">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr style="height: 5px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label6" runat="server" Text="Type Of Document" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Typeofdocument" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label7" runat="server" Text="Creation Date" Style="font-family: Times New Roman;" CssClass="Dmtlable" ></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="CreateDate" runat="server" CssClass="dmt_textbox" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label8" runat="server" Text="Revision Date" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="RevisionDate" runat="server" CssClass="dmt_textbox" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 5px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label9" runat="server" Text="Status" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Status" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label10" runat="server" Text="Comments" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Comments" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 10px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="div_fillingplus" style="height: 20px; background-color: #4c6c9f" onclick="javascript:showlfilingminus();">
                                <span style="color: #ffffff; font-size: 120%; cursor: pointer; font-weight: bold;
                                    float: right; padding-right: 10px;">+</span><span style="color: #ffffff; font-size: 100%;
                                        font-weight: bold; padding-left: 10px; float: left;">FILLING</span>
                            </div>
                            <div id="div_fillingminus" style="height: 20px; background-color: #4c6c9f; display: none;"
                                onclick="javascript:showfillingplus();">
                                <span style="color: #ffffff; font-size: 120%; cursor: pointer; font-weight: bold;
                                    float: right; padding-right: 10px;">-</span><span style="color: #ffffff; font-size: 100%;
                                        font-weight: bold; padding-left: 10px; float: left;">FILLING</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <div id="div_showfiling" align="center" style="margin-left:-250px;">
                                <table>
                                    <tr style="height: 10px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label11" runat="server" Text="Function In Charge Of" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtfunctioninchargeof" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label12" runat="server" Text="Paper" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="paper" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label13" runat="server" Text="Electronic" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtelectronic" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 5px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label14" runat="server" Text="Duration of filling(in years)" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdurationoffilling" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label15" runat="server" Text="Storage Place" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtstorageplace" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label16" runat="server" Text="Method of filling" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="methodoffilling" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 5px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label17" runat="server" Text="M.T.Protect</br> Against Water "
                                                CssClass="Dmtlable" Style="font-family: Times New Roman;"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtmethodwater" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 10px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="div_archplus" style="height: 20px; background-color: #4c6c9f" onclick="javascript:showlarchgminus();">
                                <span style="color: #ffffff; font-size: 120%; cursor: pointer; font-weight: bold;
                                    float: right; padding-right: 10px;">+</span><span style="color: #ffffff; font-size: 100%;
                                        font-weight: bold; padding-left: 10px; float: left;">ARCHIVING</span>
                            </div>
                            <div id="div_archminus" style="height: 20px; background-color: #4c6c9f; display: none;"
                                onclick="javascript:showarchplus();">
                                <span style="color: #ffffff; font-size: 120%; cursor: pointer; font-weight: bold;
                                    float: right; padding-right: 10px;">-</span><span style="color: #ffffff; font-size: 100%;
                                        font-weight: bold; padding-left: 10px; float: left;">ARCHIVING</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <div id="div_showarch"  align="center" style="margin-left:-280px;">
                                <table>
                                    <tr style="height: 10px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label18" runat="server" Text="Function in Charge Of" Style="font-family: Times New Roman;"  CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtfunctionincharge" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label19" runat="server" Text="Paper" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpaper" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label20" runat="server" Text="Electronic" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtelectronics" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 5px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label21" runat="server" Text="Duration OF Archiving + Starting" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdurationofarchiving" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label22" runat="server" Text="Archiving Place" Style="font-family: Times New Roman;" CssClass="Dmtlable"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtarchivingplace" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label23" runat="server" Text="M.T.Protect</br> Against Water"
                                                CssClass="Dmtlable" Style="font-family: Times New Roman;"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtmethodofwater" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 10px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="div_desplus" style="height: 20px; background-color: #4c6c9f" onclick="javascript:showdesminus();">
                                <span style="color: #ffffff; font-size: 120%; cursor: pointer; font-weight: bold;
                                    float: right; padding-right: 10px;">+</span><span style="color: #ffffff; font-size: 100%;
                                        font-weight: bold; padding-left: 10px; float: left;">DESTRUCTION (AFTER ARCHIVING)</span>
                            </div>
                            <div id="div_desminus" style="height: 20px; background-color: #4c6c9f; display: none;"
                                onclick="javascript:showesplus();">
                                <span style="color: #ffffff; font-size: 120%; cursor: pointer; font-weight: bold;
                                    float: right; padding-right: 10px;">-</span><span style="color: #ffffff; font-size: 100%;
                                        font-weight: bold; padding-left: 10px; float: left;">DESTRUCTION (AFTER ARCHIVING)</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9">
                            <div  id="div_description" align="center" style="margin-left:-210px;">
                                <table>
                                    <tr style="height: 10px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label24" runat="server" Text="Authorized" CssClass="Dmtlable" Style="font-family: Times New Roman;"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtauthorized" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label25" runat="server" Text="Not Authorized" CssClass="Dmtlable" Style="font-family: Times New Roman;"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtnotauthorized" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label26" runat="server" Text="Fn.In.ChargeOf" CssClass="Dmtlable" Style="font-family: Times New Roman;"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtfunctioninchrge" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 5px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label27" runat="server" Text="Method of Destruction" CssClass="Dmtlable" Style="font-family: Times New Roman;"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtmethodofdestruction" runat="server" CssClass="dmt_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 10px;">
                                        <td colspan="9">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr style="height: 5px;">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9">
                            <div align="center">
                                <asp:ImageButton ID="ImageButton1" runat="server" Width="112px" Height="41px" ImageUrl="~/Menu_image/Save.jpg"
                                    OnClick="ImageButton1_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div  class="" style="padding-left: 200px;">
            <asp:Label ID="lblresult" runat="server" Text="l" Font-Size="Medium" ForeColor="White"></asp:Label>
            <center>
            </center>
            <div>
                <center>
                    <%--    <asp:Button ID="Button1" runat="server" Text="Save"  Width ="150px" Height="30px"/>--%>
                    <%-- <asp:ImageButton ID="ImageButton1" runat="server"  Width ="112px" Height="41px" 
                    ImageUrl="~/Images/save.jpg" onclick="ImageButton1_Click" />--%>
                </center>
            </div>
            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none">
                <table>
                    <tr>
                        <td class="h1" align="left">
                            DMT TEMPLATE
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div style="overflow: scroll; height: 430px">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="Button3" CssClass="button" runat="server" Text="Cancel" OnClientClick="return Hidepopup()" />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" name="basic_example_1" class="inputDate" Width="200px"
                                MaxLength="150" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:LinkButton ID="pnlAddEdit" runat="server"></asp:LinkButton>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="false"
                PopupControlID="pnlAddEdit" TargetControlID="lnkFake" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <div id="DivGrid" class="divGrid">
                <asp:GridView ID="GridView1" runat="server" Width="600px" AutoGenerateColumns="False"
                    HeaderStyle-ForeColor="White" ForeColor="#5E5E5E" HeaderStyle-BackColor="#7e7e7e"
                    HeaderStyle-Height="40px" EmptyDataText="ve;j gjpTk; ,y;iy" EmptyDataRowStyle-ForeColor="Blue"
                    PageSize="13">
                    <RowStyle Font-Names="Arial" Font-Size="12px" />
                    <HeaderStyle BorderColor="#7e7e7e" BorderWidth="2px" Font-Names="Arial" />
                    <EmptyDataRowStyle ForeColor="Blue"></EmptyDataRowStyle>
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" HtmlEncode="true" ItemStyle-Width="150px">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="doc_ref" HeaderText="DocReference" HtmlEncode="true" ItemStyle-Width="150px">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Rev" HeaderText="Rev" HtmlEncode="true" ItemStyle-Width="100px">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Businessunit" HeaderText="Businessunit" HtmlEncode="true"
                            ItemStyle-Width="100px">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="parttype" HeaderText="PartType" HtmlEncode="true" ItemStyle-Width="200px">
                            <ItemStyle Width="200px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="operation" HeaderText="Operation" HtmlEncode="true" ItemStyle-Width="100px">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="specificpartorcommon" HeaderText="specificpartorcommon"
                            HtmlEncode="true" ItemStyle-Width="100px">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="TypeofDocument" HeaderText="typeofdocument" HtmlEncode="true"
                            ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreationDate" HeaderText="creationdate" HtmlEncode="true"
                            ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="RevisionDate" HeaderText="revisiondate" HtmlEncode="true"
                            ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="status" HtmlEncode="true" ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Comments" HeaderText="comments" HtmlEncode="true" ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="FunctioninChargeofFilling" HeaderText="functioninchargeoffilling"
                            HtmlEncode="true" ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PaperFilling" HeaderText="paperfilling" HtmlEncode="true"
                            ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="DurationofFilling" HeaderText="paperfilling" HtmlEncode="true"
                            ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="StoragePlaceFilling" HeaderText="storageplacefilling"
                            HtmlEncode="true" ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Electronicsfilling" HeaderText="electronicsfilling" HtmlEncode="true"
                            ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MethodofFilling" HeaderText="methodoffilling" HtmlEncode="true"
                            ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ProtectagainstWaterfilling" HeaderText="protectagainstwaterfilling"
                            HtmlEncode="true" ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Funinchargeof" HeaderText="funinchargeof" HtmlEncode="true"
                            ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="paper" HeaderText="paper" HtmlEncode="true" ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Electronics" HeaderText="electronics" HtmlEncode="true"
                            ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="DurationofArchiving" HeaderText="durationofarchiving"
                            HtmlEncode="true" ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ArchivingPlace" HeaderText="archivingplace" HtmlEncode="true"
                            ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Authorized" HeaderText="authorized" HtmlEncode="true"
                            ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="NotAuthorized" HeaderText="notauthorized" HtmlEncode="true"
                            ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="FunctioninchargeofDestruction" HeaderText="functioninchargeofdestruction"
                            HtmlEncode="true" ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MethodofDestruction" HeaderText="methodofdestruction"
                            HtmlEncode="true" ItemStyle-Width="80px">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="dmttemplate">
                            <ItemTemplate>
                                <%--  <img src="<%#Eval("Image") %>" width=50 height=50 />--%>
                            </ItemTemplate>
                            <ItemStyle Width="30px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Edit">
                            <ItemTemplate>
                                <%--  <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" OnClick="Edit"><img src="Images/edit.png" width="20" height="20"/></asp:LinkButton>--%>
                            </ItemTemplate>
                            <ItemStyle Width="30px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Del">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClientClick="javascript:return ConfirmationBox();"
                                    OnClick="Delete"><img src="Images/delete.png" width="20" height="20"/></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="30px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="#e1e1e1" />
                </asp:GridView>
            </div>
            <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
            <cc1:ModalPopupExtender ID="popup" runat="server" DropShadow="false" PopupControlID="pnlAddEdit"
                TargetControlID="lnkFake" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <%--<asp:Label ID="Label24" CssClass="myTamilFont1" runat="server" Text="tpguk; ntw;wpfukhf Nrh;f;fg;gl;lJ"></asp:Label>--%>
            <asp:Label ID="Label29" ForeColor="Red" runat="server"></asp:Label>
            <br />
            <br />
            <%--</form>--%>
        </div>
</asp:Content>
