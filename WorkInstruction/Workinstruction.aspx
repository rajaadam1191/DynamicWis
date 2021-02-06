<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Workinstruction.aspx.cs"
    EnableEventValidation="false" Inherits="Workinstruction" Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PH :: PD UPLOAD</title>
     <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../../favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" href="../css/style.css" type="text/css" media="screen" />
    <link href="../Styles/StylemenuWI.css" rel="stylesheet" type="text/css" />
  <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/QualitySheetscript.js" type="text/javascript"></script>

    <script src="../JS/Common.js" type="text/javascript"></script>

    <script src="../JS/jquery.easing.1.3.js" type="text/javascript"></script>
        <script src="../JS/masterfile.js" type="text/javascript"></script>
     <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

 <script src="../JS/Mc_report.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
   function checkbrowser(browser)
   {
        if(browser=="IE")
        {
            
            document.getElementById("div_upload").style.marginLeft='-230px';
        }
        else
        {
        }
        
   }
    </script>

    <script type="text/javascript">
            $(function() {
                $('#sdt_menu > li').bind('mouseenter',function(){
					var $elem = $(this);
					$elem.find('img')
						 .stop(true)
						 .animate({
							'width':'168px',
							'height':'60px',
							'left':'0px'
						 },400,'easeOutBack')
						 .andSelf()
						 .find('.sdt_wrap')
					     .stop(true)
						 .animate({'top':'60px'},500,'easeOutBack')
						 .andSelf()
						 .find('.sdt_active')
					     .stop(true)
						 .animate({'height':'45px'},300,function(){
						var $sub_menu = $elem.find('.sdt_box');
						if($sub_menu.length){
							var left = '170px';
							if($elem.parent().children().length == $elem.index()+1)
								left = '-170px';
							$sub_menu.show().animate({'left':left},200);
						}	
					});
				}).bind('mouseleave',function(){
					var $elem = $(this);
					var $sub_menu = $elem.find('.sdt_box');
					if($sub_menu.length)
						$sub_menu.hide().css('left','0px');
					
					$elem.find('.sdt_active')
						 .stop(true)
						 .animate({'height':'0px'},300)
						 .andSelf().find('img')
						 .stop(true)
						 .animate({
							'width':'0px',
							'height':'0px',
							'left':'85px'},400)
						 .andSelf()
						 .find('.sdt_wrap')
						 .stop(true)
						 .animate({'top':'15px'},500);
				});
            });
             //getmasterlinkpages();
    </script>
<script type="text/javascript">
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
        .style56
        {
            width: 30pt;
            color: black;
            font-size: 9.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial" , serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style57
        {
            height: 33.75pt;
            width: 30pt;
            color: white;
            font-size: 9.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial" , serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style58
        {
            width: 30pt;
            color: Black;
            font-size: 9.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial" , serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        #scroll
        {
            position:relative;
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
</head>
<body>
    <form runat="server">
    <div style="margin-top: -8px;">
        <table cellpadding="0px" cellspacing="0px" border="0px" align="center" width="99%"
            style="height: 80%">
            <tr>
                <td width="283">
                    <div style="background-color: #315881; margin-left:-5px;" >
                        <table>
                            <tr>
                                <td colspan="2">
                                    <div id="oScroll">
                                        <div align="center" id="scroll" style="margin-top:-3px;">
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
                        <div id="wrap">
                            <ul class="navbar">
                                <li><a href="../WorkInstruction/Userpage.aspx">PRODUCTION DOCUMENT</a> </li>
                                <li><a id="link_productiondata" runat="Server">PRODUCTION DATA</a> </li>
                                <li><a href="../Productions/DownTimeLoss.htm">DOWN TIME LOSS</a> </li>
                                <li><a href="#" onclick="javascript:exituser();">LOG OUT</a> </li>
                            </ul>
                        </div>
                    </div>
                    <div id="div_admin" runat="server">
                        <div id="wrap1">
                            <ul class="navbar1">
                                <li><a href="../WorkInstruction/Userpage.aspx">PRODUCTION DOCUMENT</a> </li>
                                 <li><a href="#">REPORTS</a>
                                <ul>
                                    <li><a href="../Reports/ViewAllReports.aspx">All REPORT</a></li>
                                    <li><a href="../Reports/Defaultchart.aspx">PLANT EFFICICENCY</a></li>
                                    <li style="border-bottom: 1px solid #54879d;"><a href="../QualityGrid/ViewQCSheetReports.aspx">
                                        VIEW QC REPORT/a></li>
                                     <li  style="border-bottom: 1px solid #54879d;"><a href="../Reports/MC_REPORT.aspx">PLANT OEE/LET</a></li>

                                </ul>
                            </li>
                                <li><a href="#" onclick="javascript:exituser();">LOG OUT</a> </li>
                            </ul>
                        </div>
                    </div>
                    <div id="super_admin" runat="server">
                    
                     <div id="wrap2" style="width: 1680px;">
                        <ul class="navbar2">
                            <%--<li><a href="#">MASTER</a>
                                <ul>
                                    <li><a href="../Fixture/UnitMaster.aspx">UNIT MASTER</a></li>
                                    <li><a href="../Fixture/TypeMaster.aspx">TYPE MASTER</a></li>
                                    <li><a href="../Fixture/LineMaster.aspx">LINE MASTER</a></li>
                                    <li><a href="../Fixture/SpareMaster.aspx">SPARE MASTER</a></li>
                                    <li><a href="../Fixture/ModelMaster.aspx">MODEL MASTER</a></li>
                                    <li><a href="../Master/Process.aspx" id="link_process">FILE UPLOAD</a> </li>
                                    <li><%--<a href="../Master/PartNoMaster.aspx" id="link_part"  >OFARTICLES</a></li>
                                    <li><a href="../Master/PlannedStopEntry.aspx" id="link_planned" >PLANNED STOP ENTRY</a></li>
                                    <li><a href="../Master/BarcodeTemplate.aspx" id="link_barcode" >BARCODE TEMPLATE</a></li>
                                    <li><a href="../Master/DowntimeTemplate.aspx">DOWNTIMELOSS TEMPLATE</a></li>
                                    <%--<li><a href="../Master/SpeedLossTemplate.aspx">SPEEDLOSS TEMPLATE</a></li>
                                     <li><a href="../Master/MasterFile.aspx">CYCLE TIME ENTRY</a></li>
                                     <li><a href="../Master/LaborEfficiency.aspx">LABOR EFFICIENCY</a></li>
                                      <li><%--<a href="../Master/AddPages.aspx">ADD PAGES</a></li>
                                    <li><%--<a href="../Master/Time_Master.aspx">TIME MASTER</a></li>
                                     <li><a href="../Master/ActualTimeEntry.aspx">ADD FIXED TIME</a></li>
                                     <li><%--<a href="../Master/FixtureValues.aspx">ADD FIXTURE VALUES</a></li>
                                     <li><a href="../Fixture/FixtureName.aspx">ADD FIXTURE NAME</a></li>
                                     <li><a href="../Fixture/FixtureValues.aspx">ADD FIXTURE VALUES</a></li>
                                     <li><a href="../Master/DYNMaster.aspx">ADD DYNAMIC MASTER</a></li>
                                     <li style="border-bottom: 1px solid #54879d;"><a href="../Master/DYNValues.aspx">ADD DYNAMIC VALUES</a></li>
                                </ul>
                            </li>--%>
                            <li style="width:210px;"><a href="#">PRODUCTION DOCUMENT</a>
                                <ul>
                                    <li style="width:210px;"><a href="../Master/Process.aspx" id="link_process">FILE UPLOAD</a> </li>
                                    <li style="width:210px;"><a href="Workinstruction.aspx">PD UPLOAD</a></li>
                                    <li style="width:210px;"><a href="Userpage.aspx">PD VIEW</a></li>
                                    <li style="width:210px;"><a href="RegisrationFrm.aspx">REGISTRATION FORM</a></li>
                                    <li style="border-bottom: 1px solid #54879d;width:210px;"><a href="DMTTemplate.aspx">DMT TEMPLATE</a></li>
                                </ul>
                            </li>
                            <li style="width:160px;"><a href="#">PLANT EFFICIENCY</a>
                                <ul>
                                    <li style="width:160px;"><a href="../Master/PlannedStopEntry.aspx" id="link_planned">PLANNED STOP ENTRY</a></li>
                                    <li style="width:160px;"><a href="../Master/BarcodeTemplate.aspx" id="link_barcode">BARCODE TEMPLATE</a></li>
                                    <li style="width:160px;"><a href="../Master/DowntimeTemplate.aspx">DOWNTIMELOSS TEMPLATE</a></li>
                                    <li style="width:160px;"><a href="../Master/MasterFile.aspx">CYCLE TIME ENTRY</a></li>
                                    <li style="width:160px;"><a href="../Master/LaborEfficiency.aspx">LABOR EFFICIENCY</a></li>
                                    <li style="border-bottom: 1px solid #54879d;width:160px;"><a href="../Master/ActualTimeEntry.aspx">
                                        ADD FIXED TIME</a></li>
                                </ul>
                            </li>
                            <li style="width:210px;"><a href="#">DYNAMIC QS CREATION</a>
                                <ul>
                                    <li style="width:210px;"><a href="../Master/DYNMaster.aspx">ADD DYNAMIC MASTER</a></li>
                                    <li style="width:210px;"><a href="../Master/DYNValues.aspx">ADD DYNAMIC VALUES</a></li>
                                    <li style="border-bottom: 1px solid #54879d;width:210px;"><a href="../Master/DynMasterDel.aspx">DELETE QUALITY SHEET</a></li>
                                </ul>
                            </li>
                             <li style="width:135px;"><a href="#">FIXTURE</a>
                                <ul>
                                    <li style="width:135px;"><a href="../Fixture/UnitMaster.aspx">UNIT MASTER</a></li>
                                    <li style="width:135px;"><a href="../Fixture/TypeMaster.aspx">TYPE MASTER</a></li>
                                    <li style="width:135px;"><a href="../Fixture/LineMaster.aspx">LINE MASTER</a></li>
                                    <li style="width:135px;"><a href="../Fixture/SpareMaster.aspx">SPARE MASTER</a></li>
                                    <li style="width:135px;"><a href="../Fixture/ModelMaster.aspx">MODEL MASTER</a></li>
                                    <li style="width:135px;"><a href="../Fixture/FixtureName.aspx">FIXTURE CREATION</a></li>
                                     <li style="border-bottom: 1px solid #54879d;width:135px;"><a href="../Fixture/FixtureValues.aspx">FIXTURE ASSIGNING</a></li>
                                </ul>
                            </li>
                            <li style="width:160px;"><a href="../DYNSheets/ProductionData.aspx" >PRODUCTION DATA</a>
                                 <%--<ul id="ul_productiondata">
                                   <li><a href="../QualityGrid/QualityGrid.aspx">A17724Q-Operation1</a></li>
                                    <li><a href="../QualityGrid/opt2QSheetA17724Q.aspx">A17724Q-Operation2</a></li>
                                    <li><a href="../QualityGrid/lapping24Q.aspx">A17724Q-lapping</a></li>
                                    <li><a href="../QualityGrid/polishing24Q.aspx">A17724Q-polishing</a></li>
                                    <li><a href="../QualityGrid/QSA22916J.aspx">A22916J-Operation1</a>
                                    </li>
                                    <li><a href="../QualityGrid/opt2QSheetA22916J.aspx">A22916J-Operation2</a></li>
                                    <li><a href="../QualityGrid/polishingA22916J.aspx" >A22916J-polishing</a></li>
                                    <li><a href="../QualityGrid/QualitySheetA32271C.aspx">A32271C-Operation1</a></li>
                                    <li><a href="../QualityGrid/polishingA32271C.aspx">A32271C-Polishing</a></li>
                                    <li><a href="../QualityGrid/QualitySheetA44908N.aspx">A44908N-Operation1</a>
                                    </li>
                                    <li><a href="../QualityGrid/polishingA44908N.aspx">A44908N-Polishing</a></li>
                                    <li><a href="../QualityGrid/qualitysheetA44983u.aspx">A44983U-Operation1</a></li>
                                    <li style="border-bottom: 1px solid #54879d;"><a href="../QualityGrid/polishingA44983U.aspx">
                                        A44983U-Polishing</a></li>
                                </ul>--%>
                            </li>
                            <li>
                                <%--<a href="../Productions/DownTimeLoss.htm">DOWN TIME LOSS</a>--%></li>
                            <li style="width:135px;"><a href="#">REPORTS</a>
                                <ul>
                                    <li style="width:135px;"><a href="../DYNSheets/SpcChart.aspx">SPC CHART</a></li>
                                    <li style="width:135px;"><a href="../Reports/Defaultchart.aspx">PLANT EFFICIENCY</a></li>
                                    <li style="width:135px;"><a href="../QualityGrid/ViewQCSheetReports.aspx">VIEW QC REPORT</a></li>
                                    <li style="width:135px;"><a href="../Reports/MC_REPORT.aspx">PLANT OEE/LET</a></li>
                                    <li style="width:135px;"><a href="../Reports/FixtureReport.aspx">FIXTURE REPORT</a></li>
                                    <li style="width:135px;"><a href="../Reports/FixtureChange.aspx">FIXTURE CHANGE</a></li>
                                    <li style="width:135px;"><a href="../Reports/FeedBack_reports1.aspx">FEEDBACK REPORT</a></li>
                                    <li style="width:135px;" ><a href="../Reports/FeedBack_reports.aspx">FEEDBACK TREND</a></li>
                                    <li style="border-bottom: 1px solid #54879d;width:135px;"><a href="../Reports/logreport.aspx">LOG REPORT</a></li>
                                </ul>
                            </li>
                            <li style="width:135px;"><a href="#" onclick="javascript:exituser();">LOG OUT</a> </li>
                        </ul>
                     </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-top: 5px;">
        <table align="left">
            <tr>
             <td>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="PRODUCTION DOCUMENT /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="PD UPLOAD" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
               
            </tr>
        </table>
    </div>
    <br />
    <br />
       <br />
          
  <div align="center" >
        <table cellpadding="0px" cellspacing="0px" border="0px" style="font-family: Arial;
            font-size: 13px">
            <tr>
                <td valign="top">
                    <table border="0px" cellpadding="5px" cellspacing="0px" style="border-color: #000000">
                        <tr style="height: 30px">
                            <td style="text-align: left;">
                                 <b>
                                        <asp:Label ID="Label4" runat="server" Text="TYPE" Style="font-family: Times New Roman;"
                                            CssClass="lablestyle">
                                        </asp:Label></b>
                            </td>
                            <td style="font-size: 20px;">
                                :
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
                        <tr style="height: 30px">
                            <td style="text-align: left;">
                                <b><asp:Label ID="Label2" runat="server" Text="PROCESS" CssClass="lablestyle" Style="font-family: Times New Roman;"></asp:Label></b>
                            </td>
                            <td style="font-size: 20px;">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="DropProcess" CssClass="dropdownstyle" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: left;">
                               <b> <asp:Label ID="Label8" runat="server" Text="FILE" CssClass="lablestyle" Style="font-family: Times New Roman;"></asp:Label></b>
                            </td>
                            <td style="font-size: 20px;">
                                :
                            </td>
                            <td>
                                <div id="div_upload">
                                    <asp:FileUpload ID="FileUpload1" align="left" runat="server" Width="442px" Font-Bold="False"
                                        Font-Size="Medium" ForeColor="#000" /></div>
                            </td>
                        </tr>
                         <tr style="height: 5px;">
                                <td colspan="3" align="center">
                                    <div id="div_error" style="display: none; padding-left: 50px;">
                                        <span id="spnerror" style="font-family: Arial; font-size: 14px; color: Red;"></span>
                                    </div>
                                </td>
                            </tr>
                    </table>
                </td>
            </tr>
        </table>
  </div>
    <br />
    <div align="center" style="padding-left: 10px;">
        <%--<asp:Label ID="Label3" runat="server" Text="Select Part No" ForeColor="#000" Font-Size="X-Large"
            align="center"> </asp:Label>--%>
        <div style="overflow-y: scroll; overflow-x: hidden; width: 535px; height: 330px;
            border: solid 1px #064b68;" align="center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" align="right"
                Width="535px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <span>ALL</span>
                            <asp:CheckBox ID="chkboxSelectAll" onclick="javascript:checkall();" runat="server" />
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:CheckBox ID="ch_workinstruction" runat="server" Style="padding-left: 25px;" onclick="javascript:checkgridcheckbox();" />
                        </ItemTemplate>
                        <ControlStyle Font-Size="Medium" ForeColor="Black" />
                        <FooterStyle ForeColor="Black" />
                        <HeaderStyle Width="100px" Font-Size="Medium" ForeColor="Black" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PartNo" HeaderText="PART NO" FooterStyle-Font-Bold="true">
                        <ControlStyle ForeColor="Black" Font-Bold="True" />
                        <FooterStyle ForeColor="Black" />
                        <HeaderStyle ForeColor="Black" Font-Bold="True" Font-Size="Medium" />
                        <ItemStyle Font-Size="Small" ForeColor="Black" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="DESCRIPTION" FooterStyle-Font-Bold="true"
                        FooterStyle-Font-Size="X-Large">
                        <ControlStyle ForeColor="Black" Font-Bold="True" />
                        <FooterStyle Font-Bold="True" Font-Size="X-Large"></FooterStyle>
                        <HeaderStyle ForeColor="Black" Font-Bold="True" Font-Size="Larger" />
                        <ItemStyle Font-Bold="False" Font-Size="Small" ForeColor="Black" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <br />
   
    <div align="center" style="padding-left:70px;">
        <asp:ImageButton ID="ImageButton1" runat="server" Text="Save" color="black" ImageUrl="~/Menu_image/Save.jpg"
            OnClick="ImageButton1_Click" OnClientClick="return validatePD();" />
    </div>
    <input type="hidden" id="hdn_browser" name="hdn_browser" runat="server" />
    <input type="hidden" id="hdn_file" runat="server" name="hdn_file" />
    </form>
</body>
