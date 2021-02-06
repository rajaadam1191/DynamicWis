<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="Process.aspx.cs" Inherits="Process" Title="PH :: FILE UPLOAD" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    $(document).ready(function()
    {

    $("input[id$='txt_date']").datepick({maxDate: 0,dateFormat: 'mm/dd/yyyy'});
    $("input[id$='Txt_date1']").datepick({maxDate: 0,dateFormat: 'mm/dd/yyyy'});
    
    });
    </script>

</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <%-- <asp:Panel ID="Panel1" runat="server">
        <span style="color: #FFFFFF; font-weight: bold;  font-style: normal; font-size: large">PROCESS MASTER</span></asp:Panel>--%>
    <%--<p>--%>
    <div style="margin-top: -30px;">
        <table>
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="MASTER   /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="FILE UPLOAD" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
     <br />
    <%--<div id ="divcenter" class ="divCenter ">--%>
    <div id="divP" class="divProcess">
        <table>
            <tr>
                <td>
                    <b>
                        <asp:Label ID="Label3" runat="server" Text="PROCESS" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" Width='470px' Height='25px' Font-Size="Medium"
                        ForeColor="Black" />
                </td>
            </tr>
<%--            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>--%>
            <tr>
                <td>
                    <b>
                        <%--<asp:Label ID="Label4" runat="server" Text="OFARTICLES" Style="font-family: Times New Roman;"
                            CssClass="lablestyle"></asp:Label></b>--%>
                            <asp:Label ID="Label4" runat="server" Text="PART NO" Style="font-family: Times New Roman;"
                            CssClass="lablestyle"></asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload2" runat="server" Width='470px' Height='25px' Font-Size="Medium"
                        ForeColor="Black" />
                </td>
            </tr>
             <tr>
                <td>
                    <b>
                        <asp:Label ID="Label6" runat="server" Text="FREQUENCY" Style="font-family: Times New Roman;"
                            CssClass="lablestyle"></asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload4" runat="server" Width='470px' Height='25px' Font-Size="Medium"
                        ForeColor="Black" />
                </td>
            </tr>
                     <tr>
                <td>
                    <b>
                        <asp:Label ID="Label5" runat="server" Text="CELL" Style="font-family: Times New Roman;"
                            CssClass="lablestyle"></asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload5" runat="server" Width='470px' Height='25px' Font-Size="Medium"
                        ForeColor="Black" />
                </td>
            </tr>
             <tr>
                <td>
                    <b>
                        <asp:Label ID="Label7" runat="server" Text="MACHINE" Style="font-family: Times New Roman;"
                            CssClass="lablestyle"></asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload6" runat="server" Width='470px' Height='25px' Font-Size="Medium"
                        ForeColor="Black" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
        </table>
        <div style="padding-left: 70px;" class="divProcess5">
            <table>
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Menu_image/Upload.jpg"
                            OnClick="ImageButton1_Click" Width="100px" Height="60px" />
                    </td>
                </tr>
                <tr>
                    <%--<td align="center">
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Menu_image/Upload.jpg"
                            OnClick="ImageButton2_Click" Width="100px" Height="30px" />
                    </td>--%>
                </tr>
            </table>
        </div>
    </div>
    <div class="divProcess1">
        <table style="border: solid 1px #c3d3da; width: 710px;">
            <tr>
                <td style="font-family: Times New Roman; font-style: inherit; font-size: larger;">
                    <b>USER NAME</b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <span id="sp_username" runat="server" visible="true"></span>
                </td>
            </tr>
            <tr>
                <td style="font-family: Times New Roman; font-style: inherit; font-size: larger;">
                    <b>USER ROLE</b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <span id="Sp_role" runat="server" visible="true"></span>
                </td>
            </tr>
            <tr>
                <span id="date" runat="server" visible="false"></span><span id="Time" runat="server"
                    visible="false"></span>
            </tr>
        </table>
    </div>
    <div class="divProcess2" id="div_process" runat="server">
       
        <asp:GridView ID="grid_process" runat="server" AutoGenerateColumns="false" Width="350px">
            <Columns>
                <asp:TemplateField HeaderText="S.No" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lbl_regid" runat="server" Text='<%#Bind("SNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="File Upload">
                    <ItemTemplate>
                        <asp:Label ID="lbl_FileUpload" runat="server" Text='<%# Bind("FileUpload") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Name" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbl_regusername" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="File Uploaded Date">
                    <ItemTemplate>
                        <asp:Label ID="lbl_regdate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="File Uploaded Time">
                    <ItemTemplate>
                        <asp:Label ID="lbl_regtim" runat="server" Text='<%# Bind("Time") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table style="padding-top: 20px;">
            <tr>
                <td>
                    <div id="div_paging" runat="server">
                        <table>
                            <tr>
                                <td class="square_selected">
                                    <asp:LinkButton ID="link_previous" runat="server" Font-Underline="false" OnClick="link_previous_Click">Previous</asp:LinkButton>
                                </td>
                                <td>
                                </td>
                                <td class="">
                                    <div style="margin-top: -2px;">
                                        <asp:DataList ID="DataListPaging" runat="server" RepeatDirection="Horizontal" OnItemDataBound="DataListPaging_ItemDataBound"
                                            OnItemCommand="DataListPaging_ItemCommand">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="link_pagebtn" runat="server" CommandName="newpage" CommandArgument='<%# Eval("PageIndex") %>'
                                                    Text='<%# Eval("PageText") %> ' Style="text-decoration: none; color: Black"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                </td>
                                <td>
                                </td>
                                <td class="square_selected">
                                    <asp:LinkButton ID="link_next" runat="server" Font-Underline="false" OnClick="link_next_Click"
                                        ForeColor="Blue">Next</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divProcess3" id="div_ofarticle" runat="server">
        <asp:GridView ID="Grid_ofarticle" runat="server" AutoGenerateColumns="false" Width="350px">
            <Columns>
                <asp:TemplateField HeaderText="S.No" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lbl_regid" runat="server" Text='<%#Bind("SNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="File Upload">
                    <ItemTemplate>
                        <asp:Label ID="lbl_FileUpload" runat="server" Text='<%# Bind("FileUpload") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Name" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbl_regusername" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="File Uploaded Date">
                    <ItemTemplate>
                        <asp:Label ID="lbl_regdate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="File Uploaded Time">
                    <ItemTemplate>
                        <asp:Label ID="lbl_regtim" runat="server" Text='<%# Bind("Time") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table style="padding-top: 20px;">
            <tr>
                <td>
                    <div id="div_paging1" runat="server">
                        <table>
                            <tr>
                                <td class="square_selected">
                                    <asp:LinkButton ID="link_previous1" runat="server" Font-Underline="false" OnClick="link_previous_Click1">Previous</asp:LinkButton>
                                </td>
                                <td>
                                </td>
                                <td class="">
                                    <div style="margin-top: -2px;">
                                        <asp:DataList ID="DataListPaging1" runat="server" RepeatDirection="Horizontal" OnItemDataBound="DataListPaging_ItemDataBound1"
                                            OnItemCommand="DataListPaging_ItemCommand1">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="link_pagebtn" runat="server" CommandName="newpage" CommandArgument='<%# Eval("PageIndex") %>'
                                                    Text='<%# Eval("PageText") %> ' Style="text-decoration: none; color: Black"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                </td>
                                <td>
                                </td>
                                <td class="square_selected">
                                    <asp:LinkButton ID="link_next1" runat="server" Font-Underline="false" OnClick="link_next_Click1"
                                        ForeColor="Blue">Next</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="divProcess4">
        <table>
            <tr>
                <td>
                    <asp:Menu ID="Menu1" Width="168px" runat="server" Orientation="Horizontal" StaticEnableDefaultPopOutImage="False"
                        OnMenuItemClick="Menu1_MenuItemClick">
                        <Items>
                            <asp:MenuItem ImageUrl="../Images/process.jpg" Text=" " Value="0"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../Images/partno.jpg" Text=" " Value="1"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../Images/frequency.jpg" Text=" " Value="2"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../Images/cell.jpg" Text=" " Value="3"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../Images/machine.jpg" Text=" " Value="4"></asp:MenuItem>
                        </Items>
                    </asp:Menu>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="Tab1" runat="server">
                            <div style="padding-left: 4.5px;">
                                <table style="width: 260px; background-color: White; height: 20px; border: solid 1px #c3d3da;">
                                    <tr>
                                        <td>
                                            <div style="width: 670px;">
                                                <div style="padding-left: -2px; margin-top: 0px;">
                                                    <asp:GridView ID="Grid_proc" runat="server" AutoGenerateColumns="False" Width="550px"
                                                        CssClass="grid">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.NO" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_PID" runat="server" Text='<%#Bind("PID") %>' Style="font-size: 12px;
                                                                        text-align: center;"></asp:Label>
                                                                </ItemTemplate>
                                                                <ControlStyle BorderColor="#C3D3DA" />
                                                                <FooterStyle BorderColor="#C3D3DA" />
                                                                <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                                                    BorderColor="#C3D3DA" />
                                                                <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="#C3D3DA" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Process">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("Process") %>' Style="font-size: 12px;
                                                                        text-align: center;"></asp:Label>
                                                                </ItemTemplate>
                                                                <ControlStyle BorderColor="#C3D3DA" />
                                                                <FooterStyle BorderColor="#C3D3DA" />
                                                                <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                                                    BorderColor="#C3D3DA" />
                                                                <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="#C3D3DA" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:View>
                        <asp:View ID="Tab2" runat="server">
                            <div style="padding-left: 4.5px;">
                                <table style="border: solid 1px #c3d3da; width: 260px; background-color: White; height: 20px;">
                                    <tr>
                                        <td>
                                            <div style="width: 670px; height: 480px;">
                                                <div style="overflow-y: scroll; overflow-x: hidden; width: 550px; height: 473px;">
                                                    <asp:GridView ID="Grid_of" runat="server" AutoGenerateColumns="False" Width="550px"
                                                        CssClass="grid">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.NO" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_PID" runat="server" Text='<%#Bind("id") %>' Style="font-size: 12px;
                                                                        text-align: center;"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="10px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                                <ItemStyle Width="10px" BackColor="White" HorizontalAlign="Center" BorderColor="#C3D3DA" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PartNo">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_PartNo" runat="server" Text='<%# Bind("PartNo") %>' Style="font-size: 12px;
                                                                        text-align: center;"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="10px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                                <ItemStyle Width="50px" BackColor="White" HorizontalAlign="Center" BorderColor="#C3D3DA" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Description">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Description" runat="server" Text='<%# Bind("Description") %>'
                                                                        Style="font-size: 12px; text-align: center;"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="10px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                                <ItemStyle Width="10px" BackColor="White" HorizontalAlign="Center" BorderColor="#C3D3DA" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                            <div style="padding-left: 4.5px;">
                                <table style="border: solid 1px #c3d3da; width: 260px; background-color: White; height: 20px;">
                                    <tr>
                                        <td>
                                            <div style="width: 670px; height: 480px;">
                                                <div style="overflow-y: auto; overflow-x: hidden; width: 550px; height: 473px;">
                                                    <asp:GridView ID="grd_frequency" runat="server" AutoGenerateColumns="False" Width="550px"
                                                        CssClass="grid">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.NO" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_PID" runat="server" Text='<%#Bind("id") %>' Style="font-size: 12px;
                                                                        text-align: center;"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="10px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                                <ItemStyle Width="10px" BackColor="White" HorizontalAlign="Center" BorderColor="#C3D3DA" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Frequency">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_frequency" runat="server" Text='<%# Bind("frequency") %>' Style="font-size: 12px;
                                                                        text-align: center;"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="10px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                                <ItemStyle Width="50px" BackColor="White" HorizontalAlign="Center" BorderColor="#C3D3DA" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:View>
                        <asp:View ID="View5" runat="server">
                            <div style="padding-left: 4.5px;">
                                <table style="border: solid 1px #c3d3da; width: 260px; background-color: White; height: 20px;">
                                    <tr>
                                        <td>
                                            <div style="width: 670px; height: 480px;">
                                                <div style="overflow-y: auto; overflow-x: hidden; width: 550px; height: 473px;">
                                                    <asp:GridView ID="grd_unit" runat="server" AutoGenerateColumns="False" Width="550px"
                                                        CssClass="grid">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.NO" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_PID" runat="server" Text='<%#Bind("id") %>' Style="font-size: 12px;
                                                                        text-align: center;"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="10px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                                <ItemStyle Width="10px" BackColor="White" HorizontalAlign="Center" BorderColor="#C3D3DA" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Cell">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Cell" runat="server" Text='<%# Bind("cell") %>' Style="font-size: 12px;
                                                                        text-align: center;"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="10px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                                <ItemStyle Width="50px" BackColor="White" HorizontalAlign="Center" BorderColor="#C3D3DA" />
                                                            </asp:TemplateField>
                                                           
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:View>
                        <asp:View ID="View1" runat="server">
                            <div style="padding-left: 4.5px;">
                                <table style="border: solid 1px #c3d3da; width: 260px; background-color: White; height: 20px;">
                                    <tr>
                                        <td>
                                            <div style="width: 670px; height: 480px;">
                                                <div style="overflow-y: auto; overflow-x: hidden; width: 550px; height: 473px;">
                                                    <asp:GridView ID="grd_mach" runat="server" AutoGenerateColumns="False" Width="550px"
                                                        CssClass="grid">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.NO" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_PID" runat="server" Text='<%#Bind("Id") %>' Style="font-size: 12px;
                                                                        text-align: center;"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="10px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                                <ItemStyle Width="10px" BackColor="White" HorizontalAlign="Center" BorderColor="#C3D3DA" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Cell">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_cell1" runat="server" Text='<%# Bind("Cell") %>' Style="font-size: 12px;
                                                                        text-align: center;"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="10px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                                <ItemStyle Width="50px" BackColor="White" HorizontalAlign="Center" BorderColor="#C3D3DA" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Machine">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_machine" runat="server" Text='<%# Bind("Machine") %>' Style="font-size: 12px;
                                                                        text-align: center;"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="10px" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                                                <ItemStyle Width="50px" BackColor="White" HorizontalAlign="Center" BorderColor="#C3D3DA" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
    </div>
    <div align="center" id="div_actualerror" runat="server" visible="false">
        <span style="color: Red; font-family: Arial; font-size: 18px; font-weight: bold;">
          </span>
    </div>
</asp:Content>
