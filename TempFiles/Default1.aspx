<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head>


 <link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css" /> 
 <script src="http://code.jquery.com/jquery-1.9.1.js"></script> 
 <%--<script type="text/javascript" language="javascript">
function load_songlist(txt,size){
    $('#All_songlist').load(txt);
    document.getElementById("divArrow").style.marginLeft=size ;
}
 </script>--%>
 
 
 
 <title>FullScreen Backgrounds - fullPage.js</title>
	 

	
	<link rel="stylesheet" type="text/css" href="Styles/jquery.fullPage.css" />
	<link rel="stylesheet" type="text/css" href="Styles/examples.css" />
	 

	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
	 <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>	 

	 <script type="text/javascript" src="JS/jquery.slimscroll.min.js"></script> 

	<script type="text/javascript" src="JS/jquery.fullPage.js"></script>
 

	<script type="text/javascript">
		$(document).ready(function() {
			$.fn.fullpage({
				anchors: ['firstPage'],
				'slidesColor': ['#fff'],
				'scrollOverflow': true
			});
		});
	</script>

 </head>
 <body>
   <form id="form1" runat="server">
    <div>
        <table cellpadding="0px" cellspacing="0px" border="0px" align="center" width="100%">
            <tr>
                <td align="center">
                    <div class="topdiv">
                        <div class="divtoptxt">
                            Poclain Hydraulics<span style="color: #c5d0d7; font-family: Arial; font-size: 11px;">(WORK
                                INSTRUCTION)</span></div>
                        <div id="top_Bar" class="divtoptxtsub">
                            <a href="#" style="font-family: Arial; color: #4e4e4e; font-size: 11px; text-decoration: none"
                                onclick="load_songlist('Default.aspx','20px')">MASTER</a>
                        </div>
                        <div id="Div2" class="divtoptxtsupt">
                            |
                        </div>
                        <div id="Div1" class="divtoptxtsub">
                            <a href="#" style="font-family: Arial; color: #4e4e4e; font-size: 11px; text-decoration: none"
                                onclick="load_songlist('Default2.aspx','100px')">TRANSACTION</a>
                        </div>
                         <div id="Div3" class="divtoptxtsupt">
                            |
                        </div>
                         <div id="Div4" class="divtoptxtsub">
                            <a href="#" style="font-family: Arial; color: #4e4e4e; font-size: 11px; text-decoration: none"
                                onclick="load_songlist('Default2.aspx','175px')">REPORT</a>
                        </div>
                        <div id="divArrow" class="divtopArrow">
                            <img src="Images/arrow.png" /></div>
                        <div class="divtopmenu">
                            <div>
                                PART NO/PROCESS</div>
                        </div>
                        <div class="divline">
                        </div>
                    </div>
                    <div id="All_songlist" class="divtoptxt">
                       
              </div>
                    <div class="botdiv">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>