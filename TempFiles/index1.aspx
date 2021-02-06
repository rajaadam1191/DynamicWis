<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index1.aspx.cs" Inherits="index1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Styles/tabcontent.css" rel="stylesheet" type="text/css" />
    <link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="JS/Common.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function calculate()
    {
    var start = '7:00 AM';
    var end = '10:09 PM';
    start=start.replace("AM","");
    end=end.replace("AM","");
    end=end.replace("PM","");
    s = start.split(':');
    e = end.split(':');

    min = e[1]-s[1];
    alert(min);
    hour_carry = 0;
    if(min<=9)
    {
        min="0"+min;
    }
    if(min < 0){
        min +=60;
        hour_carry +=1;
    }
    alert(hour_carry);  
    hour = e[0]-s[0]-hour_carry;
    if(hour<=9)
    {
        hour="0"+hour;
    }
    diff = hour + ":" + min+":"+"00";
    alert(diff);


    }
    </script>

    <style type="text/css">
        .style3
        {
            height: 23px;
        }
    </style>
</head>
<body onload="javascript:calculate();">
    <form id="form1" runat="server">
    <div>
    </div>
    </form>
</body>
</html>
