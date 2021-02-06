<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PH :: Index</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <%--<link rel="stylesheet" type="text/css" href="pro_dropdown_2/pro_dropdown_2.css" />--%>
    <%--<script src="pro_dropdown_2/stuHover.js" type="text/javascript"> </script>--%>

    <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="JS/Common.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        $(document).ready(function()
        {
            $('#txtName').focus();
        });
    </script>

    

    <link href="Styles/CSS.css" rel="stylesheet" type="text/css" />
    
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
        .style3
        {
            height: 100px;
            width: 964px;
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
    </style>
    <%--<script type="text/javascript">
function ConfirmationBox(username) {

var result = confirm('Are you sure you want to delete '+username+' Details?' );
if (result) {
return true;
}
else {
return false;
}
}
    </script>--%>
</head>
<body style="margin: 0px; background-color: #0059b0;">
    <form id="form1" runat="server">
    <div style="">
        <table cellpadding="0px" cellspacing="0px" width="100%" border="0px" align="center">
            <tr>
                <td>
                    <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
                        <tr>
                            <td style="height: 100px; width: 489px;"
                                align="left">
                            </td>
                            <td style="background-repeat: repeat; height: 100px">
                            </td>
                            <td style="" width="466" align="right">
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
                <td align="center">
                    <table border="0px" cellpadding="0px" style="background-image: url(Menu_image/login.png);
                        background-repeat: no-repeat; width: 420px; height: 380px;" cellspacing="0px">
                        <tr>
                            <td valign="top" align="center">
                                <div style="padding-top: 138px; padding-left: 85px;">
                                    <asp:TextBox ID="txtName" runat="server" Width="239px" Height="27" Style="background-color: #0059b0;
                                        border: none; color: #FFFFFF; font-weight: bold;" 
                                        onblur="javascript:validate_username();" ontextchanged="txtName_TextChanged"></asp:TextBox></div>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="center">
                                <div style="padding-top: 11px; padding-left: 85px;">
                                    <input type="password" runat="server" id="txtPassword" style="background-color: #0059b0;
                                        width: 239px; height: 27px; border: none; color: #FFFFFF; font-weight: bold;"
                                        onblur="javascript:validate_loginshift();validate_password();" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="center">
                                <div style="padding-top: 11px; padding-left: 85px;">
                                    <select id="ddl_shift" runat="server" style="width: 241px; height: 32px; color: #ffffff;
                                        background-color: #0059b0; border-style: none; font-size: 14px; font-weight: bold;"
                                        onchange="javascript:validate_shift();" disabled="disabled">
                                        <option value="0">-Select-</option>
                                        <option value="A">A</option>
                                        <option value="B">B</option>
                                        <option value="C">C</option>
                                        <%--<option value="G">G</option>
                                        <option value="A1">A1</option>
                                        <option value="B1">B1</option>--%>
                                    </select></div>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="center" colspan="2">
                                <div style="padding-top: 11px; padding-left: 85px;">
                                    <asp:TextBox ID="txt_date" runat="server" Width="239px" Height="27" Style="background-color: #0059b0;
                                        border: none; color: #FFFFFF; font-weight: bold;" Enabled="false">
                                    </asp:TextBox></div>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="">
                                    <table>
                                        <tr>
                                            <td style="width: 200px;">
                                                <div style="padding-left: 80px; display: none;" id="div_error">
                                                    <span id="sp_error" style="font-size: 14px; color: Yellow; font-family: Arial; font-weight: bold;">
                                                    </span>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btn_login" runat="server" ImageUrl="~/Menu_image/loginb1.png"
                                                    OnClick="btn_login_Click" OnClientClick="return loginvalidation();" />
                                            </td>
                                            <td style="width: 7px;">
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Menu_image/loginb2.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <%--<td style="padding-left: 230px">
                                <asp:LinkButton ID="Label2" runat="server" Width="50px" ForeColor="Transparent" Text="LOGIN"
                                    OnClick="ImageButton1_Click"></asp:LinkButton><asp:LinkButton ID="Label3" ForeColor="Transparent"
                                        runat="server" Width="50px" Text="Cancel"></asp:LinkButton>
                            </td>--%>
                        </tr>
                        <%--  <tr>
                            <td>
                               <div style="padding-left:100px;"> <span id="spn_error" style="font-family: Times New Roman:Verdana; font-size: 12px;
                                    font-weight: bold; display: none; color: Red;"></span></div>
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="height: 65px">
                                <asp:TextBox ID="txtPassword0" TextMode="Password" runat="server" Width="54px" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <input type="hidden" id="hdn_shift" name="hdn_shift" />
    </form>
</body>
</html>
