﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QualitySheet.aspx.cs" Inherits="DYNSheets_QualitySheet"
    EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PH :: Quality Sheet</title>
    <link href="../Styles/QualitySheetDesign.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Dynamicmenu.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../css/home.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/DynMaster.js" type="text/javascript"></script>

    <script src="../JS/ErrorPOPup.js" type="text/javascript"></script>

    <script type="text/javascript">
   $(document).ready(function()
    {
      loadevent();
    });
    
    function scroll(oid,iid){
        this.oCont=document.getElementById(oid)
        this.ele=document.getElementById(iid)
        this.width=this.ele.clientWidth;
        this.n=this.oCont.clientWidth;
        this.move=function(){
            this.ele.style.left=this.n+"px"
            this.n--
            if(this.n<(-this.width)){this.n=this.oCont.clientWidth}
        }
    }
    var vScroll
    function setup(){
        vScroll=new scroll("oScroll","scroll");
        setInterval("vScroll.move()",50)
    }
        onload=function(){setup()}
    </script>

    <style type="text/css">
        .error
        {
            background-color: Lime;
        }
        #scroll
        {
            position: relative;
            white-space: nowrap;
            top: 2px;
            left: 200px;
        }
        #oScroll
        {
            margin: 0px;
            padding: 0px;
            width: 200px;
            height: 20px;
            overflow: hidden;
        }
        .yscroll
        {
        	overflow-y:auto;
        	overflow-x:hidden;
        	height:220px;
        }
    </style>

    <script type="text/javascript" language="javascript">
   
    </script>

    <style type="text/css">
        .opaqueLayer10
        {
            display: none;
            position: fixed;
            top: 0px;
            left: 0px;
            opacity: 0.6;
            filter: alpha(opacity=60);
            background-color: #000000;
            z-index: 800;
        }
        .questionLayer10
        {
            position: fixed;
            top: 0px;
            left: 0px;
            width: auto;
            height: auto;
            display: none;
            z-index: 1001;
            text-align: center;
            vertical-align: middle;
            padding: 10px;
        }
        .style56
        {
            width: 317px;
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: italic;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: top;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
            height: 60.0pt;
            white-space:normal;
        }
        .style57
        {
            width: 1004px;
        }
        .style58
        {
            width: 1000px;
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: italic;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: top;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
            height: 15pt;
        }
        .chat
        {
            border-radius: 5px 5px 5px 5px;
            background-color: orange;
            padding: 5px;
            position: fixed;
            height: 30px;
            right: 0;
            width: 300px;
            color: #888;
            height: 55%;
            z-index: 3000;
            top: 200px;
            margin-right: -270px;
            cursor: pointer;
        }
        .vertical-text
        {
        	-ms-transform: rotate(90deg);
        	-webkit-transform: rotate(90deg);
            
            transform-origin: left top 0;
            color: #fff;
        }
        .feedback
        {
            border-radius: 5px 5px 5px 5px;
            background-color: orange;
            padding: 5px;
            position: fixed;
            height: 30px;
            left: 0;
            width: 600px;
            color: #888;
            height: 35%;
            z-index: 3000;
            top: 50px;
            cursor: pointer;
            margin-left: -570px;
        }
        .CellStatus
        {
            border-radius: 5px 5px 5px 5px;
            background-color: orange;
            padding: 5px;
            position: fixed;
            left: 0;
            width: 400px;
            color: #888;
            height: 40%;
            z-index: 3000;
            top: 350px;
            cursor: pointer;
            margin-left: -370px;
        }
        .circle
        {
            width: 35px;
            height: 35px;
            background: blue;
            border-radius: 70px;
        }
        </style>
</head>
<body>
    <div runat="server">
        <div>
            <table cellpadding="0px" cellspacing="0px" border="0px" align="center" width="100%"
                style="height: 80%">
                <tr>
                    <td width="283">
                        <div style="background-color: #315881; margin-left: 0px;">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <div id="oScroll">
                                            <div align="center" id="scroll" style="margin-top: -3px;">
                                                <span id="sp_username" runat="server" style="font-family: Verdana:Times New Roman;
                                                    font-size: 20px; color: #ffffff; font-style: italic;"></span>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="border-bottom: solid 1px #ffffff; width: 355px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="center">
                                            <span id="sp_logtimr" runat="server" style="font-family: Verdana:Times New Roman;
                                                font-size: 15px; color: #ffffff; font-style: italic;"></span>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="center">
                                            <span id="sp_logdate" runat="server" style="font-family: Verdana:Times New Roman;
                                                font-size: 15px; color: #ffffff; font-style: italic;"></span>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td>
                        <div id="div_user" runat="server">
                            <div id="wrap" style="width: 2000px;">
                                <ul class="navbar">
                                    <li id="link_production"><a href="../WorkInstruction/Userpage.aspx">PRODUCTION DOCUMENT</a>
                                    </li>
                                    <li id="linkproductiondata"><a href="#" runat="server">PRODUCTION DATA</a> </li>
                                    <li id="link_downtime"><a href="../Productions/DownTimeLoss.htm">DOWN TIME LOSS</a>
                                    </li>
                                   <%-- <li id="link_Chart"><a href="../DYNSheets/RunChart.aspx">Chart</a>
                                    </li>--%>
                                    <li style="width: 225px;"><a href="#">CHARTS</a>
                                    <ul>
                                        <li style="width: 225px;"><a href="../DYNSheets/RunChart.aspx">RUN CHART</a> </li>
                                        <li style="width: 225px;"><a href="../DYNSheets/SpcChart.aspx">SPC CHART</a></li>
                                    </ul>
                                </li>
                                    <li id="link_logout"><a href="#" onclick="javascript:exituser();">LOG OUT</a> </li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="div_data">
            <div id="tbl_sheet">
                <table border="1px;" cellpadding="0" align="center" style="border-collapse: collapse;"
                    bgcolor="#eefaff">
                    <tr>
                        <td valign="top" class="style57" colspan="6">
                            <div style="width: 485px;">
                                <table border="1px;" cellpadding="0" style="border-collapse: collapse;" bgcolor="#eefaff">
                                    <tr style="height: 17.0pt">
                                        <td class="style3" align="left" colspan="1" rowspan="1" style="height: 60.0pt;" valign="top">
                                            <img src="../Menu_image/PH-logo-1.jpg" width="232px" height="136px" alt='' />
                                        </td>
                                        <td class="style56" colspan="1" height="138px" rowspan="1">
                                            <div style="margin-top: 30px;">
                                                <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: right;">
                                                    PRODUCT PN : <span id="spn_partno"></span></span>
                                                <br />
                                                <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: left;">
                                                    DESCRIPTION : <span id="spn_desc"></span> </span>
                                                <br />
                                                <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: left;">
                                                    MACHINE: <span id="spn_machine"></span></span>
                                                <br />
                                               <%-- <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: left;">
                                                    MACHINE NUMBER: M24 001/ 002N1</span><br />--%>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="margin-top: 20px;">
                                <table>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style58" colspan="6" style="text-align: center; width: 500px; background-color: #4C6C9F;
                                            color: #fff; border-bottom: solid 1.4px #fff;height: 16pt;">
                                            <span>Instruments</span>
                                        </td>
                                    </tr>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style3" colspan="6" style="height: 15pt; width: 500px; text-align: center;
                                            background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;">
                                            <span>Frequency</span>
                                        </td>
                                    </tr>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style3" colspan="6" style="height: 15pt; width: 500px; text-align: center;
                                            background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;">
                                            <span>Dimensions</span>
                                        </td>
                                    </tr>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style3" colspan="6" style="height: 15pt; width: 500px; text-align: center;
                                            background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;">
                                            <span>Upper Specification</span>
                                        </td>
                                    </tr>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style3" colspan="6" style="height: 15pt; width: 500px; text-align: center;
                                            background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;">
                                            <span>Mean</span>
                                        </td>
                                    </tr>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style3" colspan="6" style="height: 15pt; width: 500px; text-align: center;
                                            background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;">
                                            <span>Lower Specification</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table id='tbleheader' style='border: 0px solid black; border-collapse: collapse;
                                    background-color: #eefaff;'>
                                    <tr style='height: 30px; background-color: #4C6C9F;'>
                                        <td style='text-align: center; height: 10pt; width: 100px; color: #fff; border-right: solid 1px #fff;'
                                            class='styleHDR'>
                                            <span>DATE</span>
                                        </td>
                                        <td style='text-align: center; height: 10pt; width: 100px; color: #fff; border-right: solid 1px #fff;'
                                            class='styleHDR'>
                                            <span style>PID</span>
                                        </td>
                                        <td style='text-align: center; height: 10pt; width: 50px; color: #fff; border-right: solid 1px #fff;'
                                            class='styleHDR'>
                                            <span>SHIFT</span>
                                        </td>
                                        <td style='text-align: center; height: 10pt; width: 100px; color: #fff; border-right: solid 1px #fff;'
                                            class='styleHDR'>
                                            <span>OPERATOR</span>
                                        </td>
                                        <td style='text-align: center; height: 10pt; width: 50px; color: #fff; border-right: solid 1px #fff;'
                                            class='styleHDR'>
                                            <span>Sl.No</span>
                                        </td>
                                        <td style='text-align: center; height: 10pt; width: 100px; color: #fff; border-right: solid 1px #fff;'
                                            class='styleHDR'>
                                            <span>HEAT CODE</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td>
                            <div>
                                <div style="">
                                    <table border="1px;" cellpadding="0" align="center" style="border-collapse: collapse;"
                                        bgcolor="#eefaff">
                                        <tr>
                                            <td class="style2" colspan="20">
                                                The sheets of this document should remain together at the Workstation
                                            </td>
                                        </tr>
                                        <tr class="style2">
                                            <td colspan="20" style="color: #0b7dc6; font-size: 100px; text-align: left;">
                                                <div style="margin-top: -5px;" align="center">
                                                    QUALITY SHEET</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="">
                                                <div id='div_width_dyn' style="margin-top: 0px; margin-left: 0px;">
                                                    <div style="float: left; left: 0%;">
                                                        <div id="divheaderlabel" style="float: left; background-color: #eefaff; padding-left: 0px;">
                                                        </div>
                                                        <div id="div_dyn" style="float: left; background-color: #eefaff; padding-left: 0px;">
                                                        </div>
                                                        <div id="div_headerlabel">
                                                        </div>
                                                        <div id="div_lbl" runat="server" style="float: left; background-color: #eefaff; margin-top: -1px;">
                                                        </div>
                                                        <div id="div_tab" style="float: left; background-color: #eefaff; margin-top: -2px;
                                                            width: 50px;">
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td valign="top">
                            <div align="center">
                                <span>Document Name:<span><br />
                                    <span id="spn_filename"></span>
                                    <br />
                                    <a style="font-size: large; color: red;">Version:<span id="spn_version"></span></a><br />
                                </span></span>Creation Date :<span id="spn_createdate"></span><br />
                                By : <a style="font-size: large; color: red;"><span id="spn_createby"></span></a>
                                <br />
<%--                                Validated Date: 01/10/2013<br />
                                By: <a style="font-size: large; color: red;">Balasubramanian</a><br />--%>
                                <div style="margin-top: -14px;">
                                    <span>_________________________________________</span>
                                </div>
                            </div>
                            <div style="text-align: center">
                                <div style="margin-top: 10px;">
                                    <div align="center">
                                        <table>
                                            <tr>
                                                <td>
                                                    <div>
                                                        <span style="font-family: Arial; font-size: 20px;">TOTAL QUANTITY</span>
                                                    </div>
                                                    <div align="center" style="margin-top: 10px;">
                                                        <span style="font-family: Arial; font-size: 20px; color: Green;" id="spn_tot_qty">
                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div align="center">
                                        <table>
                                            <tr>
                                                <td>
                                                    <div>
                                                        <span style="font-family: Arial; font-size: 20px;">ACCEPTED QUANTITY</span>
                                                    </div>
                                                    <div align="center" style="margin-top: 10px;">
                                                        <span style="font-family: Arial; font-size: 20px; color: Blue;" id="spn_acc_qty">
                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div align="center">
                                        <table>
                                            <tr>
                                                <td>
                                                    <div>
                                                        <span style="font-family: Arial; font-size: 20px;">REJECTED QUANTITY</span>
                                                    </div>
                                                    <div align="center" style="margin-top: 10px;">
                                                        <span style="font-family: Arial; font-size: 20px; color: Red;" id="spn_rej_qty">
                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div style="margin-top: 10px;">
                                 <div align="center">
                                        <table>
                                            <tr>
                                                <td>
                                                    <div>
                                                        <span style="font-family: Arial; font-size: 20px;" id="spn_currenttime"></span>
                                                    </div>
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <table>
        <tr>
            <td>
                <div>
                    <input type="hidden" id="hdn_date" runat="server" name="hdn_date" />
                    <input type="hidden" id="hdn_marph" runat="server" name="hdn_marph" />
                    <input type="hidden" id="hdnrowid" runat="server" name="hdnrowid" />
                    <input type="hidden" id="hdn_arrylength" runat="server" name="hdn_arrylength" />
                    <input type="hidden" id="hdn_instcount" runat="server" name="hdn_instcount" />
                    <input type="hidden" id="hdn_max" runat="server" name="hdn_max" />
                    <input type="hidden" id="hdn_min" runat="server" name="hdn_min" />
                    <input type="hidden" runat="server" name="hdn_partno" id="hdn_partno" />
                    <input id="hdn_pidno" type="hidden" runat="server" name="hdn_pidno" />
                    <input id="hdn_shift" type="hidden" runat="server" name="hdn_shift" />
                    <input id="HdnValexceldata" type="hidden" runat="server" name="HdnValexceldata" />
                    <input id="hdn_fixno" type="hidden" runat="server" name="hdn_fixno" />
                    <input id="hdn_color" type="hidden" runat="server" name="hdn_color" />
                    <input id="hdn_vid" type="hidden" runat="server" name="hdn_vid" />
                    <input id="hdn_ymax" type="hidden" runat="server" name="hdn_ymax" />
                    <input id="hdn_ymin" type="hidden" runat="server" name="hdn_ymin" />
                    <input id="hdn_getrowcount" type="hidden" runat="server" name="hdn_getrowcount" />
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <div style="display: none;" id="div_livedata">
        <div>
            <table bgcolor="#eefaff">
                <tr>
                    <td>
                        <div style="width: auto;">
                            <table border="1px;" cellpadding="0" style="border-collapse: collapse;" bgcolor="#eefaff">
                                <tr style="height: 17.0pt">
                                    <td class="style3" align="left" colspan="1" rowspan="1" style="height: 60.0pt;" valign="top">
                                        <img src="http://localhost:14851/DynamicWIS/Menu_image/PH-logo_qs.jpg" width="150px"
                                            height="100px" alt='' />
                                    </td>
                                    <td class="style56" colspan="1" height="138px" rowspan="1">
                                        <div style="margin-top: 30px;">
                                            <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: right;">
                                                PRODUCT PN : <span id="spn_prdpin1"></span></span>
                                            <br />
                                            <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: left;">
                                                DESCRIPTION : <span id="spn_desc1"></span> </span>
                                            <br />
                                            <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: left;">
                                                MACHINE: <span id="spn_mach1"></span></span>
                                            <br />
                                            <%--<span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: left;">
                                                MACHINE NUMBER: M24 001/ 002N1</span><br />--%>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td>
                        <div>
                            <table>
                                <tr>
                                    <td class="style2" colspan="20">
                                        The sheets of this document should remain together at the Workstation
                                    </td>
                                </tr>
                                <tr class="style2">
                                    <td colspan="20" style="color: #0b7dc6; font-size: 100px; text-align: left;">
                                        <div style="margin-top: -5px;" align="center">
                                            QUALITY SHEET</div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <%--<td>
                    <div align="center">
                        <span>Document Name:<span><br />
                            <span id="Span2"></span>
                            <br />
                            <a style="font-size: large; color: red;">Version:<span id="spn_vversion"></span></a><br />
                        </span></span>Creation Date :<span id="spn_vdate"></span><br />
                        By : <a style="font-size: large; color: red;"><span id="spn_vcreate"></span></a>
                        <br />
                        Validated Date: 01/10/2013<br />
                        By: <a style="font-size: large; color: red;">Balasubramanian</a><br />
                        <div style="margin-top: -14px;">
                            <span>_________________________________________</span>
                        </div>
                    </div>
                </td>--%>
                </tr>
            </table>
        </div>
        <div id="div_sheetheader">
        </div>
        <div id="div_qualitysheet">
        </div>
        <div id="div_headerlabel1">
        </div>
        <div id="div_lbl1" style="float: left; background-color: #eefaff; margin-top: -1px;">
        </div>
    </div>
    <div>   
            <%--<button ID="btnexcel" Text="Excel" runat="server" OnClick="btn_excel_Click" />--%>
            </div>
    <div>
        <div id="shadow" class="opaqueLayer10">
        </div>
        <div id="question" class="questionLayer10">
            <div>
                <div>
                    <img src="../Menu_image/PleaseWait.gif" alt="" style="height: 200px; width: 450px;" />
                </div>
            </div>
        </div>
    </div>
    <div class='chat' id="div_fixture" style="display: none; background-color: #fff;">
        <div style="margin-top: 0px;" id="div_open">
            <img src="../Images/leftarrow.png" style="height: 30px; width: 30px;" alt="" /></div>
        <div style="margin-top: 0px; display: none;" id="div_clos">
            <img src="../Images/rightarrow.png" style="height: 30px; width: 30px;" alt="" /></div>
        <div style="margin-left: -5px; width:1000px;">
            <table>
                <tr>
                    <td valign="top">
                        <div style="margin: 50px -15px 0px 35px; ">
                            <span class="vertical-text" id="spn_fixturecount" style=" color: #000;">FIXTURE LIFE</span></div>
                    </td>
                    <td valign="top">
                    <div id="div_fixSheetValues"></div>
                        <%--<div style="margin-left: -80px; margin-top: 0px; text-align: right;" align="center">
                            <div style="padding-right: 60px;">
                                <span style="font-family: Arial; font-size: 30px; font-weight: bold; color: #fff;"
                                    id="spn_fixno"></span>
                            </div>
                            <br />
                            <div style="padding-right: 90px;">
                                <span style="font-family: Arial; font-size: 35px; font-weight: bold; color: #fff;"
                                    id="spn_fixduration"></span>
                            </div>
                            <br />
                            <div  align="center">
                                <span style="font-family: Arial; font-size: 65px; font-weight: bold; color: #fff;"
                                    id="spn_fixtot">100000</span></div>
                        </div>--%>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <div class="modal">
            <div id="div_model">
                <div class="modal-header">
                    <h3>
                        <span id="spn_head"></span>
                    </h3>
                </div>
                <div class="modal-body">
                    <div id="div_fixtureerror" style="height: 300px; width: 500px;" align="center">
                        <div style="padding: 20px 10px 20px 10px;" id="div_fixtureerror1">
                            <span id="spn_message" style="color: #fff; font-family: Arial; font-size: 45px;">
                            </span>
                        </div>
                        <div style="display: none;" id="div_remarks">
                            <div style="padding: 20px 10px 20px 10px;">
                                <input type="text" id="Txt_remarks" style="height: 50px; width: 350px;" onblur="javascript:validate_status();" />
                            </div>
                            <div id="div_staterror" style="display: none;">
                                <span id="spn_sterror" style="color: Red; font-family: Arial; font-size: 15px;">
                                </span>
                            </div>
                            <br />
                            <div align="center" style="padding-top: 30px; cursor: pointer;">
                                <img src="../Menu_image/Save.jpg" alt="" id="btn_savestatus" />
                            </div>
                        </div>
                        <div align="center" id="div_log" style="display: none; padding: 30px 10px 20px 10px;">
                            <table>
                                <tr>
                                    <td colspan="3">
                                        <div align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" id="rdo_exist" name="rdo" style="cursor: pointer;" />
                                                        <span style="font-family: Arial; font-size: 18px;" id="spn_exist">Use Existing Fixture
                                                            No</span>
                                                    </td>
                                                    <td style="width: 50px;">
                                                    </td>
                                                    <td>
                                                        <input type="radio" id="rdo_new" name="rdo" style="cursor: pointer;" /><span style="font-family: Arial;
                                                            font-size: 18px;" id="spn_new">Add New Fixture No</span>
                                                    </td>
                                                </tr>
                                                <tr style="height: 30px;">
                                                    <td colspan="3">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="font-family: Arial; font-size: 30px;" id="spn_username">User Name</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <input type="text" id="txtusername" style="height: 30px; width: 250px;" onblur="javascript:validateusername1();" />
                                    </td>
                                </tr>
                                <tr style="height: 10px;">
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="font-family: Arial; font-size: 30px;" id="spn_password">Password</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <input type="password" id="txtpassword" style="height: 30px; width: 250px;" onblur="javascript:validatepassword1();" />
                                    </td>
                                </tr>
                                <tr style="height: 20px;">
                                    <td colspan="3">
                                        <div id="div_logerror" style="display: none; margin-left: 150px;">
                                            <span id="spn_logerror" style="color: Red; font-family: Arial; font-size: 15px;">
                                            </span>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="height: 10px;">
                                    <td colspan="3">
                                        <div align="center" style="margin-left: 150px;">
                                            <img src="../Menu_image/Submit.jpg" id="btn_login" alt="" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div align="center" id="div_ignore" style="display: none; padding: 30px 10px 20px 10px;">
                            <table>
                                <tr>
                                    <td>
                                        <span style="font-family: Arial; font-size: 30px;" id="spnuser">User Name</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <input type="text" id="txtusername1" style="height: 30px; width: 250px;" onblur="javascript:validateusername11();" />
                                    </td>
                                </tr>
                                <tr style="height: 10px;">
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="font-family: Arial; font-size: 30px;" id="spnpass">Password</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <input type="password" id="txtPassword1" style="height: 30px; width: 250px;" onblur="javascript:validatepassword11();" />
                                    </td>
                                </tr>
                                <tr style="height: 20px;">
                                    <td colspan="3">
                                        <div id="div_logerror1" style="display: none; margin-left: 150px;">
                                            <span id="spn_logerror1" style="color: Red; font-family: Arial; font-size: 15px;">
                                            </span>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="height: 10px;">
                                    <td colspan="3">
                                        <div align="center" style="margin-left: 150px;">
                                            <img src="../Menu_image/Submit.jpg" id="btn_ignore" alt="" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div align="center" style="padding-top: 30px; cursor: pointer;" id="div_btnstatus">
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <div id="div_fixsubmit">
                                                <img src="../Menu_image/Submit.jpg" alt="" id="btn_status" />
                                            </div>
                                        </td>
                                        <td>
                                            <div id="div_or">
                                                <span style="font-family: Arial; font-size: 35px; font-weight: bold; color: #fff;"
                                                    id="spn_or">OR</span>
                                            </div>
                                        </td>
                                        <td>
                                            <div id="div_cancel">
                                                <img src="../Menu_image/Cancel.jpg" id="btn_cancel" alt="" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <!--<div class="modal-footer">
        <input type="button" value="OK" class="modalOK close-modal" id="btn_closepop" />
        </div>-->
            </div>
        </div>
        <div class="modal-backdrop" id="divmodel">
        </div>
    </div>
    <div>
        <div id="shadow1" class="opaqueLayer1">
        </div>
        <div id="question1" class="questionLayer1">
            <div align="center" style="margin-top: 50px;">
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
                                            <span class="lablestyle" style="font-family: Times New Roman;">Part No</span>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <input type="text" id="txt_partno" class="textboxstyle" disabled="disabled" />
                                        </td>
                                    </tr>
                                    <tr style="height: 15px;">
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <span class="lablestyle" style="font-family: Times New Roman;">Fixture Number</span>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <input type="text" id="fix_no" class="textboxstyle" disabled="disabled" />
                                        </td>
                                    </tr>
                                    <tr style="height: 10px;">
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <span class="lablestyle" style="font-family: Times New Roman;">Fixture Operation</span>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <input type="text" id="txt_operation" class="textboxstyle" disabled="disabled" />
                                        </td>
                                    </tr>
                                    <tr style="height: 10px;">
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <span class="lablestyle" style="font-family: Times New Roman;">Fixture Life</span>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <input type="text" id="txtfixlife" class="textboxstyle" style="width: 217px;" disabled="disabled" /><input
                                                type="text" id="txt_morelife" class="textboxstyle" style="width: 217px;" />
                                        </td>
                                    </tr>
                                    <tr style="height: 10px;">
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <span class="lablestyle" style="font-family: Times New Roman; color: Green; ">Fixture
                                                life at<br>
                                                usable condition</span>
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
                                                            <input type="text" id="txt_grom" class="textboxstyle" style="width: 183px;" />
                                                        </td>
                                                        <td>
                                                            <span class="lablestyle">To</span>
                                                        </td>
                                                        <td>
                                                            <input type="text" id="txt_gto" class="textboxstyle" style="width: 183px;" />
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
                                                <asp:Label ID="Label9" runat="server" Text="Alert for fixture Calibration<br>& Re order Zone"
                                                    Style="font-family: Times New Roman; color: orange;" CssClass="lablestyle">
                                                </asp:Label>
                                            </b>
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
                                                            <input type="text" id="txt_yfrom" class="textboxstyle" style="width: 183px;" />
                                                        </td>
                                                        <td>
                                                            <span class="lablestyle">To</span>
                                                        </td>
                                                        <td>
                                                            <input type="text" id="txt_yto" class="textboxstyle" style="width: 183px;" />
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
                                                <asp:Label ID="Label10" runat="server" Text="Fixture life Completed" Style="font-family: Times New Roman;
                                                    color: Red;" CssClass="lablestyle">
                                                </asp:Label>
                                            </b>
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
                                                            <input type="text" id="txt_rfrom" class="textboxstyle" style="width: 183px;" />
                                                        </td>
                                                        <td>
                                                            <span class="lablestyle">To</span>
                                                        </td>
                                                        <td>
                                                            <input type="text" id="txt_rto" class="textboxstyle" style="width: 183px;" />
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
                                            <div id="diverror" style="display: none; padding-left: 100px;">
                                                <span id="spn_error" style="font-family: Arial; font-size: 14px; color: Red;"></span>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="height: 10px;">
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                    <tr style="height: 15px;">
                                        <td colspan="3">
                                            <div align="center" id="div_fsave" style="margin-left: 50px;">
                                                <img src="../Menu_image/save.jpg" id="brn_fixvalues" style="cursor: pointer;" alt="" />
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
        </div>
    </div>
    <div id="div_feedback">
        <div class='feedback' id="divfeedback" style="background-color: #4C6C9F;">
            <div style="margin: 0px 0px 0px 568px; display: none;" id="div_fopen">
                <img src="../Images/leftarrow.png" style="height: 30px; width: 30px;" alt="" /></div>
            <div style="margin: 0px 0px 0px 568px;" id="div_fclos">
                <img src="../Images/rightarrow.png" style="height: 30px; width: 30px;" alt="" /></div>
            <div>
                <table>
                    <tr>
                        <td valign="top">
                            <div style="margin: 110px 0px 0px 490px; -ms-transform: rotate(180deg);">
                                <span class="vertical-text" id="Span3">FEEDBACK</span></div>
                        </td>
                        <td>
                            <div style="margin-top: -30px;">
                                <div style="margin: 30px 0px 0px -550px;">
                                    <textarea id="txt_feedback" style="width: 500px; height: 100px;" maxlength="200"></textarea>
                                    <div>
                                        <span id="Span6" style="font-family: Arial; font-size: 25px; font-weight: bold; color: #fff;">
                                            Count</span>&nbsp;&nbsp; <span id="Span9" style="font-family: Arial; font-size: 25px;
                                                font-weight: bold; color: #fff;">:</span>&nbsp;<span id="spn_count" style="font-family: Arial;
                                                    font-size: 25px; font-weight: bold; color: #fff;">0</span></div>
                                </div>
                                <div style="margin: 0px 0px 0px -500px;">
                                    <input type="button" id="btn_feedback" style="width: 200px; height: 50px; cursor: pointer;"
                                        value="Send Feedback" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="divcellstatus">
        <div class='CellStatus' id="div_cellstatus" style="background-color: #4C6C9F;">
            <div style="margin: 0px 0px 0px 370px; display: none;" id="div_cellright">
                <img src="../Images/leftarrow.png" style="height: 30px; width: 30px;" alt="" /></div>
            <div style="margin: 0px 0px 0px 370px;" id="div_cellleft">
                <img src="../Images/rightarrow.png" style="height: 30px; width: 30px;" alt="" /></div>
            <div>
                <table>
                    <tr>
                        <td valign="top">
                            <div style="margin: 120px 0px 0px 270px;-ms-transform: rotate(180deg);">
                                <span class="vertical-text" id="Span1">CELLSTATUS</span></div>
                        </td>
                        <td>
                            <div style="margin-top: -35px; margin-left: -375px;">
                                <table id="table" style="width: 350px; border: solid 2px #000; background-color: #fff;">
                                    <tr>
                                        <td style="border-bottom: solid 1px #000;">
                                            <div>
                                            </div>
                                        </td>
                                        <td style="border-bottom: solid 1px #fff; background-color: #FFD700; height: 50px;
                                            width: 200px;">
                                            <div align="center">
                                                <span id="spn_machinename" runat="server" style="color: #000;"></span>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-bottom: solid 1px #000;">
                                            <div>
                                                <span id="Span7" runat="server" style="color: #000; font-family: Arial; font-size: 15px;">
                                                    BreakDown</span></div>
                                        </td>
                                        <td style="border-bottom: solid 1px #000; background-color: #000; height: 50px; width: 200px;">
                                            <div align="center">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div align="center">
                                                                <div class="circle" style="background-color: Red;">
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td style="width: 50px;">
                                                        </td>
                                                        <td>
                                                            <div>
                                                                <input type="checkbox" id="ch_breakdown" style="width: 50px; height: 50px;" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-bottom: solid 1px #000;">
                                            <div>
                                                <span id="Span8" runat="server" style="color: #000; font-family: Arial; font-size: 15px;">
                                                    Stopped</span></div>
                                        </td>
                                        <td style="border-bottom: solid 1px #000; background-color: #000; height: 50px; width: 200px;">
                                            <div align="center">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div class="circle" style="background-color: Yellow;">
                                                            </div>
                                                        </td>
                                                        <td style="width: 50px;">
                                                        </td>
                                                        <td>
                                                            <div>
                                                                <input type="checkbox" id="ch_stop" style="width: 50px; height: 50px;" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="">
                                            <div>
                                                <span id="Span10" runat="server" style="color: #000; font-family: Arial; font-size: 15px;">
                                                    Running</span></div>
                                        </td>
                                        <td style="background-color: #000; height: 50px; width: 200px;">
                                            <div align="center">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div class="circle" style="background-color: Green;">
                                                            </div>
                                                        </td>
                                                        <td style="width: 50px;">
                                                        </td>
                                                        <td>
                                                            <div>
                                                                <input type="checkbox" id="ch_running" style="width: 50px; height: 50px;" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div>
        <div id="myModal" class="modal1">
            <div class="modal-content1">
                <div class="modal-header1">
                    <span class="close" id="spn_closehpop">×</span>
                    <h2>
                        <span id="spn_msg"></span>
                        <br />
                        <span style="font-size: 50px;" id="spn_parthome"></span>
                    </h2>
                </div>
            </div>
        </div>
        <div id="myModal1" class="modal1">
            <div class="modal-content1">
                <div class="modal-header1">
                    <h2>
                        <span id="spn_msg1"></span>
                        <br />
                        <span style="font-size: 50px;" id="spn_parthome1"></span>
                    </h2>
                </div>
            </div>
        </div>
    </div>
    <div>
        <input type="hidden" name="hdn_operation" id="hdn_operation" />
        <input type="hidden" name="hdn_flag" id="hdn_flag" />
    </div>
    <form id="form" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div style="display: none;">
                <asp:Button ID="btn_excel" runat="server" OnClick="btn_excel_Click" /></div>
            <div style="padding-left:40px;">
<%--                <asp:Button ID="btn_excelexport" runat="server" OnClick="btn_excel_Click"
                    OnClientClick="exportoexcel1();" /> --%>
                    <asp:ImageButton ID="btn_excelexport" runat="server" ImageUrl="~/Menu_image/Save.jpg" OnClientClick="return exportoexcel1();"
                            OnClick="btn_excel_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <input type="hidden" name="hdn_excel" id="hdn_excel" runat="server" />
    <input type="hidden" name="hdn_shift1" id="hdn_shift1" runat="server" />
    <input type="hidden" name="hdn_operator" id="hdn_operator" runat="server" />
    </form>
</body>
</html>
