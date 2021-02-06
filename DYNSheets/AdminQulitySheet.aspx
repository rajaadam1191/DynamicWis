<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminQulitySheet.aspx.cs"
    Inherits="DYNSheets_AdminQulitySheet" EnableEventValidation="false" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PH :: Quality Sheet</title>
    <link href="../Styles/QualitySheetDesign.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Dynamicmenu.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StylemenuWI.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />
    
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../JS/MasterAdmin.js" type="text/javascript"></script>
    <script src="../JS/ErrorPOPup.js" type="text/javascript"></script>
    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>
    
    <script type="text/javascript">
   $(document).ready(function()
   {
     var idx = document.URL.indexOf('?');
         var queryString = new Array();
         var partno;
         var operation;
         var unit;
         var cell;
         var mach;var shift;var date;var operator;
         if (idx != "" && idx != null && idx != "-1") 
         {
            if (window.location.search.split('?').length > 1)
             {
                   var params = window.location.search.split('?')[1].split('&');
                   for (var i = 0; i < params.length; i++)
                    {
                        partno = params[0].split('=')[1].trim();
                        operation = params[1].split('=')[1].trim();
                        unit = params[2].split('=')[1].trim();
                        cell = params[3].split('=')[1].trim();
                        mach = params[4].split('=')[1].trim();
                        shift = params[5].split('=')[1].trim();
                        date = params[6].split('=')[1].trim();
                        operator = params[7].split('=')[1].trim();
                    }
              }
         }
        
        $('#spn_partno').text(partno);
        $('#spn_prdpin1').text(partno);
        $('#hdn_partno1').val(partno);
        $('#hdn_mach1').val(mach);
        $('#hdn_shift1').val(shift);
        $('#hdn_date1').val(date);
        $('#hdn_operation').val(operation);
        $('#hdn_operator').val(operator);
        $('#hdn_operation1').val(operation);
        $('#hdn_unit').val(unit);
        $('#hdn_cell').val(cell);
        $('#spn_machine').text(mach);
        $('#spn_mach1').text(mach);
        getadminmachine(cell);
        
        getdescription(partno);
        showuserheader();
        headertextshow(partno,operation,unit,cell);
        getotqty();
        getinstcount();
        get_designvalue(partno,operation,unit,cell);
        //ShowDialog(false);
        getversion1();
        $("#txt_date").datepick({maxDate: 0,dateFormat: 'dd/mm/yyyy'});
        var currentTime = new Date()
        var month = currentTime.getMonth() + 1
        var day = currentTime.getDate()
        var year = currentTime.getFullYear()
        var mon;
        if(parseInt(month)>9)
        {
            mon=month;
        }
        else
        {
            mon='0'+month;
        }
        if(day<10){day='0'+day}
        $("#txt_date").val(day + "/" + mon + "/" + year);
    
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
            height: 35%;
            z-index: 3000;
            top: 200px;
            margin-right: -270px;
            cursor: pointer;
        }
        .vertical-text
        {
            transform: rotate(90deg);
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
    <form id="form" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
        <div style="display:none;">
            <asp:Button ID="btn_adminexcel" runat="server" OnClick="btn_adminexcel_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <input type="hidden" name="hdn_excel" id="hdn_excel" runat="server" />
    <input type="hidden" name="hdn_shift1" id="hdn_shift1" runat="server" />
    <input type="hidden" name="hdn_operator" id="hdn_operator" runat="server" />
    <input id="hdn_partno1" type="hidden" name="hdn_partno1" runat="server" />
    <input id="hdn_mach1" type="hidden" name="hdn_mach1" runat="server" />
    <input type="hidden" id="hdn_date1" name="hdn_date1" runat="server" />
    <input id="hdn_operation1" type="hidden" name="hdn_operation1" runat="server" />
    </form>
    <div>
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
                            <div id="wrap" style="width: 3000px;">
                                <ul class="navbar">
                                    <%--<li id="link_master"><a href="#">MASTER</a>
                                        <ul>
                                            <li id="linke_upload"><a href="../Master/Process.aspx">FILE UPLOAD</a> </li>
                                            <li id="linke_stopentry"><a href="../Master/PlannedStopEntry.aspx">PLANNED STOP ENTRY</a></li>
                                            <li id="linke_template"><a href="../Master/BarcodeTemplate.aspx">BARCODE TEMPLATE</a></li>
                                            <li id="linke_downtimetemp"><a href="../Master/DowntimeTemplate.aspx">DOWNTIMELOSS TEMPLATE</a></li>
                                            <li id="linke_timetry"><a href="../Master/MasterFile.aspx">CYCLE TIME ENTRY</a></li>
                                            <li id="link_effen"><a href="../Master/LaborEfficiency.aspx">LABOR EFFICIENCY</a></li>
                                            <li id="link_fixed"><a href="../Master/ActualTimeEntry.aspx">ADD FIXED TIME</a></li>
                                            <li id="link_fixture"><a href="../Master/FixtureValues.aspx">ADD FIXTURE VALUES</a></li>
                                            <li id="link_dymaster"><a href="../Master/DYNMaster.aspx">ADD DYNAMIC MASTER</a></li>
                                            <li id="link_dynvalues" style="border-bottom: 1px solid #54879d;"><a href="../Master/DYNValues.aspx">
                                                ADD DYNAMIC VALUES</a></li>
                                        </ul>
                                    </li>--%>
                                    <li id="link_production1"><a href="#">PRODUCTION DOCUMENT</a>
                                        <ul>
                                            <li id="link_fileupload"><a href="../Master/Process.aspx" id="A1">FILE UPLOAD</a> </li>
                                            <li id="link_pdupload"><a href="../WorkInstruction/Workinstruction.aspx">PD UPLOAD</a></li>
                                            <li id="link_view"><a href="../WorkInstruction/Userpage.aspx">PD VIEW</a></li>
                                            <li id="link_form"><a href="../WorkInstruction/RegisrationFrm.aspx">REGISTRATION FORM</a></li>
                                            <li id="link_dmt" style="border-bottom: 1px solid #54879d;"><a href="../WorkInstruction/DMTTemplate.aspx">
                                                DMT TEMPLATE</a></li>
                                        </ul>
                                    </li>
                                    <li id="link_planteff"><a href="#">PLANT EFFICIENCY</a>
                                        <ul>
                                            <li id="link_plannedstop"><a href="../Master/PlannedStopEntry.aspx" id="link_planned">PLANNED STOP ENTRY</a></li>
                                            <li id="link_barcodetemplate"><a href="../Master/BarcodeTemplate.aspx" id="link_barcode">BARCODE TEMPLATE</a></li>
                                            <li id="link_downtimeloss"><a href="../Master/DowntimeTemplate.aspx">DOWNTIMELOSS TEMPLATE</a></li>
                                            <li id="link_cycletime"><a href="../Master/MasterFile.aspx">CYCLE TIME ENTRY</a></li>
                                            <li id="link_laboreff"><a href="../Master/LaborEfficiency.aspx">LABOR EFFICIENCY</a></li>
                                            <li id="link_fixedtime" style="border-bottom: 1px solid #54879d;"><a href="../Master/ActualTimeEntry.aspx">
                                                ADD FIXED TIME</a></li>
                                        </ul>
                                    </li>
                                    <li id="link_dynQScreation"><a href="#">DYNAMIC QS CREATION</a>
                                        <ul>
                                            <li id="link_dynmaster"><a href="../Master/DYNMaster.aspx">ADD DYNAMIC MASTER</a></li>
                                            <li style="width:210px;"><a href="../Master/DYNValues.aspx">ADD DYNAMIC VALUES</a></li>
                                            <li style="border-bottom: 1px solid #54879d;width:210px;"><a href="../Master/DynMasterDel.aspx">DELETE QUALITY SHEET</a></li>
                                        </ul>
                                    </li>
                                    <li id="link_fixture"><a href="#">FIXTURE</a>
                                        <ul>
                                            <li id="link_unit"><a href="../Fixture/UnitMaster.aspx">UNIT MASTER</a></li>
                                            <li id="link_type"><a href="../Fixture/TypeMaster.aspx">TYPE MASTER</a></li>
                                            <li id="link_line"><a href="../Fixture/LineMaster.aspx">LINE MASTER</a></li>
                                            <li id="link_spare"><a href="../Fixture/SpareMaster.aspx">SPARE MASTER</a></li>
                                            <li id="link_model"><a href="../Fixture/ModelMaster.aspx">MODEL MASTER</a></li>
                                            <li id="link_fixcreation"><a href="../Fixture/FixtureName.aspx">FIXTURE CREATION</a></li>
                                            <li id="link_fixvalues" style="border-bottom: 1px solid #54879d;"><a href="../Fixture/FixtureValues.aspx">
                                                FIXTURE ASSIGNING</a></li>
                                        </ul>
                                    </li>
                                    <li id="link_prdata"><a href="../DYNSheets/ProductionData.aspx" id="linkproddata">PRODUCTION DATA</a>
                                        <%--<ul id="ul_productiondata">
                                        </ul>--%>
                                    </li>
                                    <li id="link_reports"><a href="#">REPORT</a>
                                        <ul>
                                            <li id="link_chart"><a href="../DYNSheets/SpcChart.aspx">SPC CHART</a></li>
                                            <li id="link_qcrpt"><a href="../QualityGrid/ViewQCSheetReports.aspx">VIEW QC REPORT</a></li>
                                            <li id="link_effrpt"><a href="../Reports/Defaultchart.aspx">PLANT EFFICIENCY</a></li>
                                            <li id="link_oeelet"><a href="../Reports/MC_REPORT.aspx">PLANT OEE/LET</a></li>
                                            <li id="link_fixrpt"><a href="../Reports/FixtureReport.aspx">FIXTURE REPORT</a></li>
                                            <li id="link_fixchange"><a href="../Reports/FixtureChange.aspx">FIXTURE CHANGE</a></li>
                                        <li id="link_fbrpt"><a href="../Reports/FeedBack_reports1.aspx">FEEDBACK REPORT</a></li>
                                            <li id="link_feedback" style="border-bottom: 1px solid #54879d;"><a href="../Reports/FeedBack_reports.aspx">
                                                FEEDBACK TREND</a></li>
                                        </ul>
                                    </li>
                                    <li id="link_log"><a href="#" onclick="javascript:exituser();">LOG OUT</a> </li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="div1">
            <div id="tbl_sheet">
                <table border="1px;" cellpadding="0" align="center" style="border-collapse: collapse;"
                    bgcolor="#eefaff">
                    <tr>
                        <td valign="top" class="style57">
                            <div style="width: 485px;">
                                <table border="1px;" cellpadding="0" style="border-collapse: collapse;" bgcolor="#eefaff">
                                    <tr style="height: 17.0pt">
                                        <td class="style3" align="left" colspan="1" rowspan="1" style="height: 60.0pt;" valign="top">
                                            <img src="../Menu_image/PH-logo-1.jpg" width="232px" height="137px" alt='' />
                                        </td>
                                        <td class="style56" colspan="1" height="138px" rowspan="1">
                                            <div style="margin-top: 30px;">
                                                <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: right;">
                                                    PRODUCT PN : <span id="spn_partno"></span></span>
                                                <br />
                                                <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: left;">
                                                    DESCRIPTION : <span id="spn_desc"></span></span>
                                                <br />
                                                <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: left;">
                                                    MACHINE: <span id="spn_machine"></span></span>
                                                <%--<br />
                                                <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: left;">
                                                    MACHINE NUMBER: M24 001/ 002N1</span><br />--%>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style58" colspan="10" style="text-align: width:500px; color: #0b7dc6;
                                            border-bottom: solid 1.4px #fff; font-size: 15px; font-family: Arial Black; cursor: pointer;"
                                            id="td_search">
                                            <span>Search</span>
                                        </td>
                                    </tr>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style58" colspan="10" style="text-align: width:500px; center; background-color: #4C6C9F;
                                            color: #fff; border-bottom: solid 1.4px #fff;">
                                            <span>Instruments</span>
                                        </td>
                                    </tr>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style3" colspan="10" style="height: 15pt; width: 500px; text-align: center;
                                            background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;">
                                            <span>Frequency</span>
                                        </td>
                                    </tr>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style3" colspan="10" style="height: 15pt; width: 500px; text-align: center;
                                            background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;">
                                            <span>Dimensions</span>
                                        </td>
                                    </tr>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style3" colspan="10" style="height: 15pt; width: 500px; text-align: center;
                                            background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;">
                                            <span>Upper Specification</span>
                                        </td>
                                    </tr>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style3" colspan="10" style="height: 15pt; width: 500px; text-align: center;
                                            background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;">
                                            <span>Mean</span>
                                        </td>
                                    </tr>
                                    <tr style="border: solid 1.4px #fff;">
                                        <td class="style3" colspan="10" style="height: 15pt; width: 500px; text-align: center;
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
                                                        <div id="div_lbl" style="float: left; background-color: #eefaff; margin-top: -1px;">
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
                                <%--<span>Document Name:<span><br />
                                    <span id="spn_filename"></span>
                                    <br />
                                    <a style="font-size: large; color: red;">Version:<span id="spn_version"></span></a><br />
                                </span></span>Creation Date :<span id="spn_createdate"></span><br />
                                By : <a style="font-size: large; color: red;"><span id="spn_createby"></span></a>
                                <br />
                                Validated Date: 01/10/2013<br />
                                By: <a style="font-size: large; color: red;">Balasubramanian</a><br />
                                <div style="margin-top: -12px;">
                                    <span>_________________________________________</span>
                                </div>--%>
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
                    <input type="hidden" id="hdn_date" name="hdn_date" />
                    <input type="hidden" id="hdn_marph" name="hdn_marph" />
                    <input type="hidden" id="hdnrowid" name="hdnrowid" />
                    <input type="hidden" id="hdn_arrylength" name="hdn_arrylength" />
                    <input type="hidden" id="hdn_instcount" name="hdn_instcount" />
                    <input type="hidden" id="hdn_max" name="hdn_max" />
                    <input type="hidden" id="hdn_min" name="hdn_min" />
                    <input type="hidden" name="hdn_partno" id="hdn_partno" />
                    <input id="hdn_pidno" type="hidden" name="hdn_pidno" />
                    <input id="hdn_shift" type="hidden" name="hdn_shift" />
                    <input id="HdnValexceldata" type="hidden" name="HdnValexceldata" />
                    <input id="hdn_fixno" type="hidden" name="hdn_fixno" />
                    <input id="hdn_color" type="hidden" name="hdn_color" />
                    <input id="hdn_vid" type="hidden" name="hdn_vid" />
                    <input id="hdn_ymax" type="hidden" name="hdn_ymax" />
                    <input id="hdn_ymin" type="hidden" name="hdn_ymin" />
                    <input id="hdn_operation" type="hidden" name="hdn_operation" />
                    <input id="hdn_unit" type="hidden" name="hdn_unit" />
                    <input id="hdn_cell" type="hidden" name="hdn_cell" />
                    <input id="hdn_liwidth" type="hidden" name="hdn_liwidth" />
                    <input id="hdn_mach" type="hidden" name="hdn_mach" />
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <div id="div_livedata" style="display: none;">
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
                                                DESCRIPTION : <span id="spn_desc1"></span></span>
                                            <br />
                                            <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: left;">
                                                MACHINE: <span id="spn_mach1"></span></span>
                                            <%--<br />
                                            <span style="font-style: italic; font-weight: bold; font-size: 16px; text-align: left;">
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
    <div>
        <div id="overlay" class="web_dialog_overlay">
        </div>
        <div id="dialog" class="web_dialog">
            <table style="width: 100%; border: 0px;" cellpadding="3" cellspacing="0">
                <tr>
                    <td class="web_dialog_title">
                        Quality Sheet
                    </td>
                    <td class="web_dialog_title align_right">
                        <a href="#" id="btnClose">Close</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 0px;">
                        <div id="brands" align="center">
                            <table>
                                <tr>
                                    <td>
                                        <span style="font-family: Arial; font-weight: bold; font-size: 15px;">Select Date</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <input type="text" id="txt_date" runat="server" style="width: 215px; height: 20px;" />
                                    </td>
                                </tr>
                                <tr style="height: 10px;">
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="font-family: Arial; font-weight: bold; font-size: 15px;">Select Shift</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <select id="ddl_adminshift" style="width: 217px" onchange="javascript:getadminmachine($('#hdn_cell').val());">
                                            <option value="A">A</option>
                                            <option value="B">B</option>
                                            <option value="C">C</option>
                                        </select>
                                    </td>
                                </tr>
                                 <tr style="height: 10px;">
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="font-family: Arial; font-weight: bold; font-size: 15px;">Select Machine</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <select id="ddl_adminmach" runat="server" style="width: 217px" onchange="getprodadminoper();">
                                        </select>
                                    </td>
                                </tr>
                                 <tr style="height: 10px;">
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="font-family: Arial; font-weight: bold; font-size: 15px;">Select Operator</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <select id="ddl_adminoperator" runat="server" style="width: 217px">
                                        </select>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr style="height: 10px;">
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <div align="center" style="margin-left: 100px; cursor: pointer;">
                            <img src="../Menu_image/view.jpg" alt="" id="btn_searchsheet" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</body>
</html>
