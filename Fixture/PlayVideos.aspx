<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlayVideos.aspx.cs" Inherits="ABU_PlayVideos" %>
<%@ Register Assembly="Media-Player-ASP.NET-Control" Namespace="Media_Player_ASP.NET_Control"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
         <cc1:Media_Player_Control ID="Media_Player_Control1" runat="server" Width="950" Height="480" />
        </div>
    </div>
    </form>
</body>
</html>
