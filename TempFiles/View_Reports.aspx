<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="View_Reports.aspx.cs" Inherits="View_Reports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table>
            <tr>
                <td>
                    Enter the PID No
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_pidno" runat="server" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    Enter the Shift
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_shift" runat="server" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    Enter the operator
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="operator" runat="server" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                    <div>
                        <asp:Button ID="btn_view" Text="View Report" runat="server" 
                            onclick="btn_view_Click" /></div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
