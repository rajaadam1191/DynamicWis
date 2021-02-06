<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="PartNoMaster.aspx.cs" Inherits="PartNoMaster" Title="PH :: Part No" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    <asp:Panel ID="Panel1" runat="server">
        &nbsp;&nbsp;&nbsp;</asp:Panel>
    <p>
        <body>
            <div id="divPNO" class="divPNo">
                <table>
                    <tr>
                        <td>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                            <asp:Label ID="Label2" runat="server" Text="MASTER  /" valign="left" Font-Bold="false"
                                Font-Size="25px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="OFARTICLES" valign="left" Font-Bold="false"
                                Font-Size="15px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <center>
                <%--<div id ="divcenter" class ="divCenter">--%>
                <div id="divPart" class="divPart">
                    <br />
                    <table>
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server" Text="OFARTICLES" CssClass="lablestyle" ></asp:Label>
                    &nbsp;<span style="font-weight: bold;">:</span>
                    <asp:FileUpload ID="FileUpload1" runat="server" Width='280px' Height='25px' Font-Size="Medium"
                        ForeColor="Black" /><br />
                        </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                    <tr>
                    <td align="center" >
                    <asp:ImageButton ID="ImageButton2" runat="server" Width="112px" Height="41px" ImageUrl="~/Menu_image/Upload.jpg"
                        OnClick="ImageButton2_Click" />
                        </td>
                        </tr>
                        </table>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblMessage" runat="server" Font-Names="Arial" ForeColor="White"></asp:Label>
                </div>
            </center>
            <div id="div6" class="divCenter1">
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:GridView ID="grdMac" runat="server" AutoGenerateColumns="False"
                    Width="427px" fontsize="24px" ForeColor="White" Cell-border="7px" PagerStyle-BorderStyle="Solid">
                    <Columns>
                        <asp:TemplateField HeaderText="PART NO" HeaderStyle-Font-Names="arial">
                            <ItemTemplate>
                                <asp:Label ID="lblCodes" runat="server" Text='<%#Eval("Machine Code") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <HeaderStyle ForeColor="Yellow" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BorderStyle="Solid"></PagerStyle>
                </asp:GridView>
                </center>
                <br />
            </div>
            </div>
            <div>
            </div>
        </body>
    </p>
</asp:Content>
