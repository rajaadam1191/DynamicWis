<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BarcodeTemplate.aspx.cs"
    Inherits="BarcodeTemplate" %>--%>
<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="BarcodeTemplate.aspx.cs" Inherits="BarcodeTemplate" Title="PH :: BARCODE TEMPLATE" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <style type="text/css">
        .divstyle
        {
            background-color: #4d7eac;
            height: 20px;
            text-align: center;
            font-family: Arial;
            font-size: 15px;
            color: #ffffff;
            font-weight: bold;
            padding-top: 3px;
            border:solid 1px #000;
        }
        .labelstyle
        {
            font-family: Arial;
            font-size: 13px;
            text-align: left;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <%--<link href="../Styles/Stylemenu.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/QualitySheetscript.js" type="text/javascript"></script>

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
        .divstyle
        {
            background-color: #4d7eac;
            height: 20px;
            text-align: center;
            font-family: Arial;
            font-size: 15px;
            color: #ffffff;
            font-weight: bold;
            padding-top: 3px;
            border:solid 1px #000;
        }
        .labelstyle
        {
            font-family: Arial;
            font-size: 13px;
            text-align: left;
            font-weight: bold;
        }
         #scroll
        {
            position: absolute;
            white-space: nowrap;
            top: 0px;
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
    </style>--%>
   
                <div style="margin-top: -30px;">
                <table>
                    <tr>
                        <td>
                           &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="MASTER  /" valign="left" Font-Bold="true"
                                Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="BARCODE TEMPLATE" valign="left" Font-Bold="true"
                                Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
                    <div id="div_barcode" align="center" style="padding-top:20px;" >
                        <asp:DataList ID="DL_barcodeTemplate" runat="server" OnItemDataBound="DL_barcodeTemplate_ItemDataBound">
                            <ItemTemplate>
                                <div style="width: 800px;">
                                    <table width="100%" style="background-color: #ffffff; border: solid 1px #c3d3da;">
                                        <tr>
                                            <td>
                                                <span style="display: none;">
                                                    <%#Eval("SNo")%>
                                                </span><span style="display: none;">
                                                    <%#Eval("BarcodeText")%>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="divstyle" >
                                                        <span style="">Barcode</span></div>
                                                    <div align="center">
                                                        <table>
                                                            <tr style="height: 10px;">
                                                                <td colspan="7">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="labelstyle">
                                                                    <span>Start Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Image ID="img_Opstart" runat="server"  Height="50" Width="250" />
                                                                </td>
                                                                <td style="width: 50px;">
                                                                </td>
                                                                <td class="labelstyle">
                                                                    <span>End Time</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Image ID="img_Opend" runat="server" Height="50" Width="250" />
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 10px;">
                                                                <td colspan="7">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                      
                                       
                                    </table>
                                </div>
                            </ItemTemplate>
                        </asp:DataList></div>
                     <br />
                     <br />
          <div align="center">
            <input type="button" id="btn_print" value="Print" style="width: 100px; height: 35px;
                cursor: pointer;" onclick="javascript:printpage('div_barcode');" />
                </div>
    
</asp:Content>