<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PH :: Index</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="../Styles/CSS.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/Common.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
      
     $(function(){
        var scroller = $('#scroller div.innerScrollArea');
        var scrollerContent = scroller.children('ul');
        scrollerContent.children().clone().appendTo(scrollerContent);
        var curX = 0;
        scrollerContent.children().each(function(){
            var $this = $(this);
            $this.css('left', curX);
            curX += $this.outerWidth(true);
        });
        var fullW = curX / 2;
        var viewportW = scroller.width();
 
        var controller = {curSpeed:0, fullSpeed:2};
        var $controller = $(controller);
        var tweenToNewSpeed = function(newSpeed, duration)
        {
            if (duration === undefined)
                duration = 600;
            $controller.stop(true).animate({curSpeed:newSpeed}, duration);
        };
 
        // Pause on hover
        scroller.hover(function(){
            tweenToNewSpeed(0);
        }, function(){
            tweenToNewSpeed(controller.fullSpeed);
        });
 
        // Scrolling management; start the automatical scrolling
        var doScroll = function()
        {
            var curX = scroller.scrollLeft();
            var newX = curX + controller.curSpeed;
            if (newX > fullW*2 - viewportW)
                newX -= fullW;
            scroller.scrollLeft(newX);
        };
     setInterval(doScroll, 50);
            tweenToNewSpeed(controller.fullSpeed);
    });
 
     
 
    </script>

    <link href="../Styles/CSS.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
        }
        a:link
        {
            color: #666666;
        }
        a:visited
        {
            color: #666666;
        }
        a:hover
        {
            color: #666666;
        }
        a:active
        {
            color: #666666;
        }
        .wrapper
        {
            width: 900px;
            margin: 0px auto;
            padding: 15px;
            background-color: #eee;
        }
        .input
        {
            width: 250px;
            border: 2px solid #CCC;
            line-height: 20px;
            height: 20px;
            padding: 5px;
        }
        .style4
        {
            width: 200px;
            height: 40px;
        }
        .style5
        {
            height: 40px;
        }
        #scroller
        {
            position: relative;
        }
        #scroller .innerScrollArea
        {
            overflow: hidden;
            position: absolute;
            left: 0;
            right: 0;
            top: 0;
            bottom: 0;
        }
        #scroller ul
        {
            padding: 0;
            margin: 0;
            position: relative;
        }
        #scroller li
        {
            padding: 0;
            margin: 0;
            list-style-type: none;
            position: absolute;
        }
    </style>
</head>
<body style="background-color: #1f497d;">
    <form id="form1" runat="server">
    <div style="margin-top: 20px; margin-left: 10px; float: left;">
        <img src="../Menu_image/poclainlogo.png" />
    </div>
    <div style="margin-top: 20px; margin-right: 10px; float: right;">
        <img src="../Menu_image/TLM-Logo.png" />
    </div>
    <div>
        <div style="">
            <table cellpadding="0px" cellspacing="0px" width="100%" border="0px" align="center">
                <tr>
                    <td>
                        <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
                            <tr>
                                <td style="background-image: url(Images/left.png); height: 100px; width: 489px;"
                                    align="left">
                                </td>
                                <td style="background-image: url(Images/middle.png); background-repeat: repeat; height: 100px">
                                </td>
                                <td style="background-image: url(Images/right.png);" width="466" align="right">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 100px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <div align="center" style="margin-left: 300px; margin-top: -100px; background-image: url(../Menu_image/tlm-login.jpg);
                            background-repeat: no-repeat; width: 1200px; height: 450px;">
                            <div style="padding-top: 90px; padding-left: 220px;">
                                <input type="text" id="txt_ausername" runat="server" style="width: 200px; height: 20px;" /></div>
                            <div style="padding-top: 8px; padding-left: 220px;">
                                <input type="password" id="txt_apassword" runat="server" style="width: 200px; height: 20px;" /></div>
                            <div style="padding-left: 80px; display: none;" id="div_error">
                                <span id="sp_error" style="font-size: 14px; color: Yellow; font-family: Arial; font-weight: bold;">
                                </span>
                            </div>
                            <div align="center" style="margin-left: 290px;">
                                <table>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:ImageButton ID="btn_login" runat="server" ImageUrl="~/Menu_image/loginb1.png"
                                                    OnClick="btn_log_Click" OnClientClick="return login_validation();" /></div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Menu_image/loginb2.png" /></div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="div_abu" style="margin-top: -200px; margin-left: 80px;" align="center">
            <div id="scroller" style="width: 800px; height: 450px; margin: 0 auto;">
                <div class="innerScrollArea">
                    <ul>
                        <li>
                            <img src="Images/IMG_1322.JPG" width="150" height="150" alt="" /></li>
                        <li>
                            <img src="Images/IMG_1324.JPG" width="150" height="150" alt="" /></li>
                        <li>
                            <img src="Images/IMG_1328.JPG" width="150" height="150" alt="" /></li>
                        <li>
                            <img src="Images/IMG_1329.JPG" width="150" height="150" alt="" /></li>
                        <li>
                            <img src="Images/IMG_1330.JPG" width="150" height="150" alt="" /></li>
                        <li>
                            <img src="Images/IMG_1333.JPG" width="150" height="150" alt="" /></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
