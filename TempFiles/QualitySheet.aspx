<%@ Page Language="C#"  MasterPageFile="~/TempFiles/MasterPage.master" AutoEventWireup="true" CodeFile="QualitySheet.aspx.cs" Inherits="QualitySheet" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
--%>
<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quality Sheet Form</title>
    <link href="Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
</head>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
    <p>
     <link href="Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
<br />
<body>
 <%--   <form id="form1" runat="server">--%>
    <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>
    <div><%--#0f7fc7--%>
    <table border="1px;" cellpadding="0" align="center" cellspacing="0" style="border-collapse:
 collapse;width:95%; align="center" bgcolor="#0f7fc8" margin-right: 162px;" width="100%">
        <colgroup>
            <col style="mso-width-source:userset;mso-width-alt:2340;width:48pt" 
                width="64" />
            <col span="2" style="mso-width-source:userset;mso-width-alt:2340;
 width:48pt" width="64" />
            <col style="mso-width-source:userset;mso-width-alt:2560;width:53pt" 
                width="70" />
            <col span="6" style="mso-width-source:userset;mso-width-alt:2340;
 width:48pt" width="64" />
            <col span="1" style="mso-width-source:userset;mso-width-alt:2340;
 " />
            <col span="3" style="mso-width-source:userset;mso-width-alt:2340;
 width:48pt" width="64" />
            <col style="mso-width-source:userset;mso-width-alt:3547;width:73pt" 
                width="97" />
        </colgroup>
        <tr height="20" style="height:15.0pt">
            <td align="left" colspan="4"  height="80" rowspan="2" 
                style="height:60.0pt;" valign="top">
                
             
               <img src="Images/Poclain-Hydraulics-Logo.jpg" 
                    v:shapes="Picture_x0020_2" width="283px" height="118px" />
                    
            </td>
            <td class="style2" colspan="8">
                The sheets of this document should remain together at the Workstation</td>
            <td class="style3" colspan="3" width="225">
                Page : 1<span style="mso-spacerun:yes">&nbsp;&nbsp; </span>/<span 
                    style="mso-spacerun:yes">&nbsp;&nbsp; </span>2</td>
        </tr>
        <tr height="60" style="mso-height-source:userset;height:45.0pt">
            <td class="style4" colspan="8" height="60">
                QUALITY SHEET</td>
            <td class="style5" colspan="3" width="225">
                Creation Date :01/10/2013<span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;<br />
                By : <a style="font-size:large;color:#f5fe5b;">Thirumavalavan.P</a><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
            </td>
        </tr>
        <tr height="20" style="height:15.0pt">
            <td class="style6" colspan="2" height="41" rowspan="2" width="128">
                PH-PVT</td>
            <td class="style7" colspan="2" rowspan="2">
                OPERATOR:<span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
            <td class="style8" colspan=
            "3">
                PRODUCT PN: A17724Q<span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
           
            <td class="style10" colspan="5" style="mso-ignore: colspan">
                DESIGNATION: ME-GLACE-MSO2-1C-CAST-NG<span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
            <td class="style11" colspan="3" rowspan="3" width="225">
                Creation Date :01/10/2013<br />
                By : <a style="font-size:large;color:#f5fe5b;">Thirumavalavan.P</a><br />
                Validated Date: 01/10/2013<br />
                By: <a style="font-size:large;color:#f5fe5b;">Balasubramanian</a><br />
            </td>
        </tr>
        <tr height="21" style="mso-height-source:userset;height:15.75pt">
            <td class="style12" colspan="3" height="21">
                Nagarajan</td>
            <td class="style13">
                Date</td>
            <td class="style14" colspan="2">
                6-May-14</td>
            <td class="style15" colspan="2">
                PID:</td>
        </tr>
        <tr height="53" style="mso-height-source:userset;height:39.75pt">
            <td class="style16" colspan="3" height="53" width="192">
                MACHINE: TMC 1 / 2 NO</br> : M21001N2 / M21002N2</td>
            <td class="style17">
                SUPPLIER:<span style="mso-spacerun:yes">&nbsp;</span></td>
            <td class="style14" colspan="3">
                <asp:TextBox ID="TextBox2" runat="server" Height="50px" Width="192px" BackColor="#0f7fc7" BorderColor ="#0f7fc7"></asp:TextBox>
                                        </td>
            <td class="style10" colspan="2" style="mso-ignore: colspan">
                <span style="mso-spacerun:yes">&nbsp;</span>TOTAL QUANTITY:<span 
                    style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
            <td class="style14">
                28</td>
            <td class="style18" colspan="2">
                16018</td>
        </tr>
        <tr height="23" style="mso-height-source:userset;height:17.25pt">
            <td class="style19" height="23" width="64">
                N0</td>
            <td class="style20" colspan="14" width="935">
                Description of control, Freq, tool and dimensions.</td>
        </tr>
        <tr height="27" style="mso-height-source:userset;height:20.25pt">
            <td class="style21" height="27" width="64">
                Control<span style="mso-spacerun:yes">&nbsp;</span></td>
            <td class="font5" width="64">
                G<font class="font6"><sup>al</sup></font><font class="font5"> aspect<span 
                    style="mso-spacerun:yes">&nbsp;</span></font></td>
            <td class="style23" width="64">
                CMM</td>
            <td class="style24" colspan="7" width="454">
                Ø ODs</td>
            <td class="style55" colspan="2">
                OD Roughness</td>
            <td class="style26" colspan="3" width="225">
                Ø ODs</td>
        </tr>
        <tr height="21" style="mso-height-source:userset;height:15.75pt">
            <td class="style27" height="49" rowspan="2" width="64">
                Freq.</td>
            <td class="style28" colspan="14" width="935">
                Every dimension to be inspected in shift first part</td>
        </tr>
        <tr height="28" style="mso-height-source:userset;height:21.0pt">
            <td class="style29" height="28" width="64">
                -100%</td>
            <td class="style23" width="64">
                (1/15 parts)</td>
            <td class="style55" colspan="7" width="454">
                -100%</td>
            <td class="style55" colspan="2">
                (1/10 parts)</td>
            <td class="style31" colspan="3" width="225">
                (1/10 parts)</td>
        </tr>
        <tr height="18" style="mso-height-source:userset;height:13.5pt">
            <td class="style32" height="45" rowspan="2" width="64">
                Tool</td>
            <td class="style32" rowspan="2" width="64">
                Visual</td>
            <td class="style32" rowspan="2" width="64">
                (1/15 parts)</td>
            <td class="style30" colspan="7" width="454">
                Marphoss Gauge</td>
            <td class="style30" colspan="2">
                Roughness tester</td>
            <td class="style31" colspan="3" rowspan="2" width="225">
                Vernier<span style="mso-spacerun:yes">&nbsp;</span></td>
        </tr>
        <tr height="27" style="mso-height-source:userset;height:20.25pt">
            <td class="style33" height="89" rowspan="4">
                Heat Code No</td>
            <td class="style25" colspan="2" width="128">
                67.623&nbsp;mm</td>
            <td class="style25" colspan="2" width="128">
                75.023&nbsp;mm</td>
            <td class="style25" colspan="2" width="128">
                81.727&nbsp;mm</td>
            <td class="style50" width="64">
                Ra</td>
            <td class="style50">
                Rp</td>
        </tr>
        <tr height="21" style="mso-height-source:userset;height:15.75pt">
            <td class="style35" height="21" width="64">
                Tol. Max</td>
            <td class="style22" width="64">
                -</td>
            <td class="style22" width="64">
                &nbsp;</td>
            <td class="style25" colspan="2" width="128">
                67.600&nbsp;mm</td>
            <td class="style25" colspan="2" width="128">
                75.000&nbsp;mm</td>
            <td class="style25" colspan="2" width="128">
                81.700&nbsp;mm</td>
            <td class="style25" width="64">
                1.6 µm</td>
            <td class="style25">
                3.2 µm</td>
            <td class="style25" width="64">
                68.50 mm</td>
            <td class="style25" width="64">
                75.90 mm</td>
            <td class="style36" width="97">
                82.60 mm</td>
        </tr>
        <tr height="21" style="height:15.75pt">
            <td class="style35" height="21" width="64">
                Nom</td>
            <td class="style22" width="64">
                -</td>
            <td class="style22" width="64">
                &nbsp;</td>
            <td class="style25" colspan="2" width="128">
                67.577&nbsp;mm</td>
            <td class="style25" colspan="2" width="128">
                74.977&nbsp;mm</td>
            <td class="style25" colspan="2" width="128">
                81.673&nbsp;mm</td>
            <td class="style22" width="64">
                -</td>
            <td class="style50">
                -</td>
            <td class="style22" width="64">
                68.40 mm</td>
            <td class="style22" width="64">
                75.80 mm</td>
            <td class="style36" width="97">
                82.50 mm</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style37" height="20" width="64">
                Tol. Min</td>
            <td class="style38" width="64">
                -</td>
            <td class="style38" width="64">
                &nbsp;</td>
            <td class="style39" width="64">
                MAX</td>
            <td class="style39" width="64">
                MIN</td>
            <td class="style39" width="64">
                MAX</td>
            <td class="style40" width="64">
                MIN</td>
            <td class="style40" width="64">
                MAX</td>
            <td class="style40" width="64">
                MIN</td>
            <td class="style25" width="64">
                0.0 µm</td>
            <td class="style25">
                0.0 µm</td>
            <td class="style38" width="64">
                68.30 mm</td>
            <td class="style38" width="64">
                75.70 mm</td>
            <td class="style41" width="97">
                82.40 mm</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                </td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                
            <asp:TextBox ID="txtmax1" runat="server" BackColor="#0f7fc7" Width="95%" 
                    AutoPostBack="True" ontextchanged="txtmax1_TextChanged" style="border:none;"
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtmax1_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtmax1" ValidChars=".">
                </asp:FilteredTextBoxExtender>
                </td>
            <td class="style45" width="64">
                <asp:TextBox ID="txtmin1" runat="server" BackColor="#0f7fc7" Width="95%" style="border:none;"
                    AutoPostBack="True" ontextchanged="txtmin1_TextChanged" 
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtmin1" ValidChars="."></asp:FilteredTextBoxExtender></td>
            <td class="style45" width="64">
                <asp:TextBox ID="TextBox1" runat="server" BackColor="#0f7fc7" Width="95%" style="border:none;"
                    AutoPostBack="True" 
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtmax1" ValidChars=".">
                </asp:FilteredTextBoxExtender></td>
            <td class="style45" width="64">
                </td>
            <td class="style45" width="64">
               </td>
            <td class="style45" width="64">
                </td>
            <td class="style46" width="64">
                </td>
            <td class="style52">
                </td>
            <td class="style46" width="64">
                </td>
            <td class="style46" width="64">
                </td>
            <td class="style47" width="97">
                </td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                </td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                <asp:TextBox ID="txtma2" runat="server" BackColor="#0f7fc7" Width="95%" AutoPostBack="True" style="border:none;"
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtma2" ValidChars=".">
                </asp:FilteredTextBoxExtender></td>
            <td class="style48" width="64">
                 <asp:TextBox ID="txtmin2" runat="server" BackColor="#0f7fc7" Width="95%" AutoPostBack="True" style="border:none;"
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtmin2" ValidChars="."/>
                    </td>
            <td class="style45" width="64">
                <asp:TextBox ID="txtmmax2" runat="server" BackColor="#0f7fc7" Width="95%" style="border:none;"
                    ontextchanged="txtmmax2_TextChanged" AutoPostBack="True" 
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtmmax2" ValidChars="."></asp:FilteredTextBoxExtender></td>
            <td class="style48" width="64">
               </td>
            <td class="style45" width="64">
               </td>
            <td class="style45" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                </td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                <asp:TextBox ID="txtma3" runat="server" BackColor="#0f7fc7" Width="95%" AutoPostBack="True" style="border:none;"
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtma3" ValidChars=".">
                </asp:FilteredTextBoxExtender></td>
            <td class="style45" width="64">
                  <asp:TextBox ID="txtmin3" runat="server" BackColor="#0f7fc7" Width="95%" AutoPostBack="True" style="border:none;"
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtmin3" ValidChars="."/></td>
            <td class="style45" width="64">
                &nbsp;</td>
            <td class="style45" width="64">
                </td>
            <td class="style45" width="64">
                </td>
            <td class="style45" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                </td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                 <asp:TextBox ID="txtma4" runat="server" BackColor="#0f7fc7" Width="95%" AutoPostBack="True" style="border:none;"
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtma4" ValidChars="."></asp:FilteredTextBoxExtender></td>
            <td class="style45" width="64">
                <asp:TextBox ID="txtmin4" runat="server" BackColor="#0f7fc7" Width="95%" AutoPostBack="True" style="border:none;"
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtmin4" ValidChars="."/></td>
            <td class="style45" width="64">
                &nbsp;</td>
            <td class="style45" width="64">
                </td>
            <td class="style45" width="64">
               </td>
            <td class="style45" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr style="mso-height-source:userset;">
            <td class="style42" width="64" style="height: 20px">
                </td>
            <td class="style43" width="64" style="height: 20px">
                </td>
            <td class="style43" width="64" style="height: 20px">
                </td>
            <td class="style54" style="height: 20px">
                </td>
            <td class="style45" width="64" style="height: 20px">
                 <asp:TextBox ID="txtma5" runat="server" BackColor="#0f7fc7" Width="95%" AutoPostBack="True" style="border:none;"
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtma5" ValidChars=".">
                </asp:FilteredTextBoxExtender></td>
            <td class="style45" width="64" style="height: 20px">
                <asp:TextBox ID="txtmin5" runat="server" BackColor="#0f7fc7" Width="95%" AutoPostBack="True" style="border:none;"
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtmin5" ValidChars="."/></td>
            <td class="style45" width="64" style="height: 20px">
                </td>
            <td class="style45" width="64" style="height: 20px">
               </td>
            <td class="style45" width="64" style="height: 20px">
                </td>
            <td class="style45" width="64" style="height: 20px">
               </td>
            <td class="style43" width="64" style="height: 20px">
                </td>
            <td class="style53" style="height: 20px">
                </td>
            <td class="style43" width="64" style="height: 20px">
                </td>
            <td class="style43" width="64" style="height: 20px">
                </td>
            <td class="style49" width="97" style="height: 20px">
                </td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                </td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                </td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                <asp:TextBox ID="txtma6" runat="server" BackColor="#0f7fc7" Width="95%" AutoPostBack="True" style="border:none;"
                    ></asp:TextBox>
                
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtma6" ValidChars=".">
                </asp:FilteredTextBoxExtender></td>
            <td class="style45" width="64">
                <asp:TextBox ID="txtmin6" runat="server" BackColor="#0f7fc7" Width="95%" AutoPostBack="True" style="border:none;"
                    ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" 
                    runat="server" Enabled="True" FilterType="Custom, Numbers" 
                    TargetControlID="txtmin6" ValidChars="."/></td>
            <td class="style45" width="64">
                </td>
            <td class="style45" width="64">
                </td>
            <td class="style45" width="64">
               </td>
            <td class="style45" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <%--<tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                60</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                7DO</td>
            <td class="style45" width="64">
                67.605</td>
            <td class="style48" width="64">
                67.613</td>
            <td class="style45" width="64">
                75.01</td>
            <td class="style48" width="64">
                75.013</td>
            <td class="style48" width="64">
                81.712</td>
            <td class="style45" width="64">
                81.707</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                61</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                8DO</td>
            <td class="style45" width="64">
                67.597</td>
            <td class="style45" width="64">
                67.606</td>
            <td class="style45" width="64">
                74.998</td>
            <td class="style45" width="64">
                75.001</td>
            <td class="style45" width="64">
                81.702</td>
            <td class="style45" width="64">
                81.701</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                62</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.599</td>
            <td class="style45" width="64">
                67.604</td>
            <td class="style45" width="64">
                75.002</td>
            <td class="style45" width="64">
                75.006</td>
            <td class="style45" width="64">
                81.703</td>
            <td class="style45" width="64">
                81.705</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                63</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                8DO</td>
            <td class="style45" width="64">
                67.609</td>
            <td class="style48" width="64">
                67.615</td>
            <td class="style48" width="64">
                75.014</td>
            <td class="style48" width="64">
                75.018</td>
            <td class="style48" width="64">
                81.712</td>
            <td class="style48" width="64">
                81.713</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                64</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.607</td>
            <td class="style48" width="64">
                67.614</td>
            <td class="style45" width="64">
                75.01</td>
            <td class="style48" width="64">
                75.013</td>
            <td class="style45" width="64">
                81.708</td>
            <td class="style48" width="64">
                81.712</td>
            <td class="style46" width="64">
                0.5</td>
            <td class="style52">
                2.56</td>
            <td class="style46" width="64">
                68.45</td>
            <td class="style46" width="64">
                75.85</td>
            <td class="style47" width="97">
                82.54</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                65</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.6</td>
            <td class="style45" width="64">
                67.608</td>
            <td class="style45" width="64">
                75.002</td>
            <td class="style45" width="64">
                75.008</td>
            <td class="style45" width="64">
                81.705</td>
            <td class="style45" width="64">
                81.709</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                66</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.597</td>
            <td class="style45" width="64">
                67.604</td>
            <td class="style45" width="64">
                75.001</td>
            <td class="style45" width="64">
                75.006</td>
            <td class="style45" width="64">
                81.702</td>
            <td class="style45" width="64">
                81.704</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                67</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.599</td>
            <td class="style45" width="64">
                67.604</td>
            <td class="style45" width="64">
                75.003</td>
            <td class="style45" width="64">
                75.007</td>
            <td class="style45" width="64">
                81.705</td>
            <td class="style45" width="64">
                81.704</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                68</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.601</td>
            <td class="style45" width="64">
                67.609</td>
            <td class="style45" width="64">
                75.004</td>
            <td class="style45" width="64">
                75.008</td>
            <td class="style45" width="64">
                81.706</td>
            <td class="style45" width="64">
                81.704</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                69</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.603</td>
            <td class="style45" width="64">
                67.608</td>
            <td class="style45" width="64">
                75.006</td>
            <td class="style45" width="64">
                75.009</td>
            <td class="style45" width="64">
                81.705</td>
            <td class="style45" width="64">
                81.708</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                70</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.602</td>
            <td class="style45" width="64">
                67.608</td>
            <td class="style45" width="64">
                75.004</td>
            <td class="style45" width="64">
                75.009</td>
            <td class="style48" width="64">
                81.711</td>
            <td class="style45" width="64">
                81.709</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>--%>
       <%-- <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                71</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.605</td>
            <td class="style48" width="64">
                67.615</td>
            <td class="style48" width="64">
                75.012</td>
            <td class="style48" width="64">
                75.015</td>
            <td class="style48" width="64">
                81.713</td>
            <td class="style48" width="64">
                81.717</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                72</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                8DO</td>
            <td class="style45" width="64">
                67.603</td>
            <td class="style48" width="64">
                67.613</td>
            <td class="style45" width="64">
                75.007</td>
            <td class="style48" width="64">
                75.011</td>
            <td class="style45" width="64">
                81.71</td>
            <td class="style45" width="64">
                81.709</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                73</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.608</td>
            <td class="style48" width="64">
                67.615</td>
            <td class="style48" width="64">
                75.011</td>
            <td class="style48" width="64">
                75.016</td>
            <td class="style48" width="64">
                81.714</td>
            <td class="style48" width="64">
                81.718</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                74</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                Q=</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.607</td>
            <td class="style48" width="64">
                67.612</td>
            <td class="style48" width="64">
                75.013</td>
            <td class="style45" width="64">
                75.009</td>
            <td class="style45" width="64">
                81.707</td>
            <td class="style45" width="64">
                81.709</td>
            <td class="style46" width="64">
                0.4</td>
            <td class="style52">
                2.14</td>
            <td class="style46" width="64">
                68.38</td>
            <td class="style46" width="64">
                75.78</td>
            <td class="style47" width="97">
                82.5</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                75</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                7DO</td>
            <td class="style45" width="64">
                67.609</td>
            <td class="style48" width="64">
                67.616</td>
            <td class="style48" width="64">
                75.012</td>
            <td class="style48" width="64">
                75.016</td>
            <td class="style48" width="64">
                81.711</td>
            <td class="style48" width="64">
                81.716</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                76</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.605</td>
            <td class="style48" width="64">
                67.615</td>
            <td class="style45" width="64">
                75.008</td>
            <td class="style48" width="64">
                75.012</td>
            <td class="style45" width="64">
                81.709</td>
            <td class="style48" width="64">
                81.711</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                77</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.6</td>
            <td class="style45" width="64">
                67.603</td>
            <td class="style45" width="64">
                75.001</td>
            <td class="style45" width="64">
                75.003</td>
            <td class="style45" width="64">
                81.702</td>
            <td class="style45" width="64">
                81.699</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                78</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.6</td>
            <td class="style45" width="64">
                67.605</td>
            <td class="style45" width="64">
                75.002</td>
            <td class="style45" width="64">
                75.004</td>
            <td class="style45" width="64">
                81.702</td>
            <td class="style45" width="64">
                81.704</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                79</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                </td>
            <td class="style45" width="64">
                67.602</td>
            <td class="style45" width="64">
                67.608</td>
            <td class="style45" width="64">
                75.004</td>
            <td class="style45" width="64">
                75.003</td>
            <td class="style45" width="64">
                81.705</td>
            <td class="style45" width="64">
                81.708</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                80</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                8DO</td>
            <td class="style45" width="64">
                67.601</td>
            <td class="style45" width="64">
                67.606</td>
            <td class="style45" width="64">
                75.007</td>
            <td class="style45" width="64">
                75.003</td>
            <td class="style45" width="64">
                81.709</td>
            <td class="style45" width="64">
                81.705</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>
        <tr height="20" style="mso-height-source:userset;height:15.0pt">
            <td class="style42" height="20" width="64">
                81</td>
            <td class="style43" width="64">
                </td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style54">
                7DO</td>
            <td class="style45" width="64">
                67.608</td>
            <td class="style48" width="64">
                67.612</td>
            <td class="style48" width="64">
                75.012</td>
            <td class="style45" width="64">
                75.008</td>
            <td class="style45" width="64">
                81.708</td>
            <td class="style45" width="64">
                81.71</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style43" width="64">
                &nbsp;</td>
            <td class="style49" width="97">
                &nbsp;</td>
        </tr>--%>
    </table>
    </div>
   <%-- </form>--%>
</body>
<%--</html>--%>
 </p>

</asp:Content>