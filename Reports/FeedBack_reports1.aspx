<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="FeedBack_reports1.aspx.cs" Inherits="FeedBack_reports1" Title="PH :: FIXTURE REPORTS"
    EnableEventValidation="false" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Chart.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/ErrorPOPup.js" type="text/javascript"></script>
<script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    $(document).ready(function()
    {
    
//        showfeedback();
        //loadpartno();
        $("input[id$='txt_fromdate']").datepick({maxDate: 31,dateFormat: 'dd/mm/yyyy'});
        $("input[id$='txt_todate']").datepick({maxDate: 31,dateFormat: 'dd/mm/yyyy'});
    });
    </script>

    <style>
        .tdclass
        {
            background-color: #4C6C9F;
            font-size: 14px;
            font-family: Arial;
            font-weight: bold;
            border-right: solid 1px #fff;
            text-align: center;
            color: #fff;
        }
        .tdclass1
        {
            background-color: #FFF;
            font-size: 14px;
            font-family: Arial;
            font-weight: bold;
            border-right: solid 1px #000;
            border-bottom: solid 1px #000;
            text-align: center;
            color: #000;
            height: 30px;
        }
        .trclass1
        {
            border: solid 1px gray;
        }
        .spn
        {
            font-size: 14px;
            font-family: Arial;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div runat="server" id="div_chart" style="width: 1350px; background-color: #eefaff;"
        align="center">
        <ul class="tabs" data-persist="true">
           <%-- <li id="link_one"><a href="#"><span>Feedback Trend</span></a></li>--%>
            <li id="link_two"><a href="#"><span>Feedback History</span></a></li>
        </ul>
        <div class="tabcontents" align="center" style="background-color: #eefaff;">
            <%--<div id="view1" runat="server">
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
                                    <select id="ddl_fpartno" class="dropdownstyle" onchange="javascript:getfixno();v_partno();"
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
                                    <select id="ddl_ffixno" class="dropdownstyle" onchange="javascript:v_fixno();" runat="server">
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
                                    <select id="ddl_foperation" class="dropdownstyle" onchange="javascript:v_operation();"
                                        runat="server">
                                        <option value="0" selected="selected">--- Select Operation ---</option>
                                        <option value="1">FIRST</option>
                                        <option value="2">SECOND</option>
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
                                    <select id="ddl_fmachine" class="dropdownstyle" onchange="javascript:v_machine();"
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
                                    <asp:DropDownList ID="ddl_fyear" runat="server" AutoPostBack="false" CssClass="dropdownstyle"
                                        onchange="javascript:v_year();">
                                    </asp:DropDownList>
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
                                                <td>
                                                </td>
                                                <td>
                                                    From
                                                </td>
                                                <td>
                                                    <select id="ddl_fmonth" class="dropdownstyle" onchange="javascript:v_month1();" runat="server"
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
                                                    </select>
                                                </td>
                                                <td>
                                                    TO
                                                </td>
                                                <td>
                                                    <select id="ddl_fmonthto" class="dropdownstyle" onchange="javascript:v_month2();"
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
                                    <div align="center" id="div_fcaerror" style="display: none;">
                                        <span style="font-family: Arial; color: Red; font-size: 15px;" id="spn_ferror">
                                        </span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div align="center">
                                        <asp:ImageButton ImageUrl="~/Menu_image/Submit.jpg" runat="server" 
                                            ID="btn_feedback"   OnClientClick="return check_feedback();" 
                                            onclick="btn_feedback_Click"/>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div>
                    <asp:Chart ID="chart_feedback" runat="server" Width="1300px" Palette="None" Height="1000"
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
                                    <span> No. of. Feedback</span>
                                </td>
                            
                                
                                <td style="width: 20px;">
                                </td>
                               <td>
                                    <div style="height: 20px; width: 20px; background-color: Gold;">
                                    </div>
                                </td>
                                <td>
                                    <span>No. of. Response</span>
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
            </div>--%>
            <div id="view2" runat="server">
            
                <div style="margin-left: -10px; margin-top: -10px;">
                    <table align="center">
                        <tr>
                            <td align="left">
                                <span class="lablestyle" style="color: #000;">From</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txt_fromdate" runat="server" class="textboxstyle" style="width: 218px;" />
                            </td>
                            <td style="width: 30px;">
                            </td>
                            <td align="left">
                                <span class="lablestyle" style="color: #000;">To</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txt_todate" runat="server" class="textboxstyle" style="width: 218px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <div style="margin-left: 50px;" align="center">
                    <asp:ImageButton ID="btn_fixfeedbacksearch" runat="server" ImageUrl="~/Menu_image/view.jpg"
                        OnClick="btn_fixfeedbacksearch_Click" />
                </div>
                <br />
                <br />
                <div id="divfeedback">
                </div>
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
    <div>
        <div id="shadow" class="opaqueLayer">
        </div>
        <div id="question" class="questionLayer">
            <div align="center">
                <table>
                <tr><td style="padding-left:390px;"><a onclick="javascript:hideLayer()"> <span style="color:Red;padding-top:-500px;cursor:pointer">X</span> </a></td></tr>
                <tr><td><span>Response</span></td></tr>
                    <tr>
                        <td>
                            <textarea id="txt_response" style="width: 300px; height: 50px;"></textarea>
                        </td>
                    </tr>
                    <tr style="height: 20px;">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center">
                                <img src="../Menu_image/Submit.jpg" alt="" id="btn_submit" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
  <div>
    <input type="hidden" id="hdn_fbid" name="hdn_fbid" runat="server" />
    <input type="hidden" id="hdn_fpart" name="hdn_fpart" runat="server"  />
    <input type="hidden" id="hdn_foperation" name="hdn_foperation"  runat="server" />
    <input type="hidden" id="hdn_ffixno" name="hdn_ffixno"  runat="server" />
    <input type="hidden" id="hdn_fmachi" name="hdn_fmachi" runat="server"  />
    <input type="hidden" id="hdn_fyear" name="hdn_fyear"  runat="server" />
    <input type="hidden" id="hfn_fmonth1" name="hfn_fmonth1"  runat="server" />
    <input type="hidden" id="hdn_fmonth2" name="hdn_fmonth2"  runat="server" />
  </div>
</asp:Content>
