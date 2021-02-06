<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
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
            position: relative;
            width: 200px;
            height: 20px;
            overflow: hidden;
        }
    </style>

    <script language="javascript" type="text/javascript">
        var size = 2;
        var id = 0;
 
//        function ProgressBar() {
//            if (document.getElementById('<%=ImageFile.ClientID %>').value != "") {
//                document.getElementById("divProgress").style.display = "block";
//                document.getElementById("divUpload").style.display = "block";
//                id = setInterval("progress()", 20);
//                return true;
//            }
//            else {
//                alert("Select a file to upload");
//                return false;
//            }
// 
//        }
 
        function progress() {
            size = size + 1;
            
            if (size > 299) {
                clearTimeout(id);
            }
            document.getElementById("divProgress").style.width = size + "pt";
            document.getElementById("<%=lblPercentage.ClientID %>").firstChild.data = parseInt(size / 3) + "%";
        }
 
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <table cellpadding="0" cellspacing="0" width="80%" align="center" style="background: White;
                padding: 10px;" border="4">
                <tr>
                    <td align="left" style="border: none;">
                        <div>
                            <h1>
                                Select File To Upload</h1>
                            <asp:Label ID="lblImageFile" Text="Your File" AssociatedControlID="ImageFile" runat="server"
                                CssClass="lbl" />
                            <asp:DropDownList ID="DListFileType" runat="server">
                                <asp:ListItem Text="Image" Value="Image"></asp:ListItem>
                                <asp:ListItem Text="Video" Value="Video"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:FileUpload ID="htmlFile1" runat="server" />
                            <input id="ImageFile" contenteditable="false" runat="server" name="ImageFile" type="file"
                                style="width: 300px" />&nbsp;&nbsp;
                            <asp:Button ID="btnAddImage" runat="server" Text="Upload File" OnClientClick="return ProgressBar()"
                                OnClick="btnAddImage_Click" />
                            <br />
                            <br />
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="btnShowImage" Text="Show Image" runat="server" OnClick="btnShowImage_Click" />
                            <asp:Button ID="btnShowVideo" Text="Show Video" runat="server" OnClick="btnShowVideo_Click" />
                            <div id="divUpload" style="display: none">
                                <div style="width: 300pt; text-align: center;">
                                    Uploading...</div>
                                <div style="width: 300pt; height: 20px; border: solid 1pt gray">
                                    <div id="divProgress" runat="server" style="width: 1pt; height: 20px; background-color: Blue;
                                        display: none">
                                    </div>
                                </div>
                                <div style="width: 300pt; text-align: center;">
                                    <asp:Label ID="lblPercentage" runat="server" Text="Label"></asp:Label></div>
                                <br />
                                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <br class="clear" />
                        <div class="bottomColumn">
                            <asp:DataList ID="dlImageList" RepeatColumns="3" runat="server">
                                <ItemTemplate>
                                    <asp:Image ID="imgShow" ImageUrl='<%# Eval("Name","~/Images/{0}")%>' Style="width: 200px"
                                        runat="server" AlternateText='<%# Eval("Name") %>' />
                                    <br />
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="bottomColumn">
                            <asp:DataList ID="DataListVideo" RepeatColumns="3" runat="server" Width="100%">
                                <ItemTemplate>
                                    <object id="mediaPlayer" classid='clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95' standby='Loading....'
                                        type='application/x-oleobject' width="160px">
                                        <param name="movie" value="<%# Eval("Name","http://localhost/UploadFileWithProgressBar/Video/{0}")%>">
                                        <param name='animationatStart' value='false'>
                                        <%-- Here your URL --%>
                                        <param name='transparentatStart' value='false'>
                                        <param name='autoStart' value='false'>
                                        <param name='showControls' value='true'>
                                        <param name='clickToPlay' value='true'>
                                        <param name="ShowStatusBar" value='true'>
                                        <param name="windowlessVideo" value='false'>
                                        <embed type="application/x-mplayer2" pluginspage="http://microsoft.com/windows/mediaplayer/en/download/"
                                            id="" name="mediaPlayer" class="MediaPlayerWidth" src="<%# Eval("Name","http://localhost/UploadFileWithProgressBar/Video/{0}")%>"> </embed>
                                        <%-- Here your URL --%>
                                    </object>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    
    </form>
</body>
</html>
