<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LaborEfficiency.aspx.cs"
    Inherits="LaborEfficiency" %>--%>

<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="LaborEfficiency.aspx.cs" Inherits="LaborEfficiency" Title="PH :: LABOR EFFICIENCY" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />

    <script src="../JS/masterfile.js" type="text/javascript"></script>

    <script src="../JS/Common.js" type="text/javascript"></script>
    <script src="../JS/ErrorPOPup.js" type="text/javascript"></script>
    <script src="../JS/plannedstop.js" type="text/javascript"></script>

    <script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    $(document).ready(function()
{


    $("input[id$='txt_date']").datepick({maxDate: 0,dateFormat: 'mm/dd/yyyy'});
    

});
    </script>
    <script type="text/javascript">
function onlyNumbers(evt) {
    var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)&& charCode != 46)
        return false;
    return true;
}
</script>
<style type="text/css">
 .opaqueLayer
        {
            display: none;
            position: fixed;
            top: 0px;
            left: 0px;
            opacity: 0.6;
            filter: alpha(opacity=60);
            background-color: #000000;
            z-index: 800;
        }
        .questionLayer
        {
            position: fixed;
            top: 0px;
            left: 0px;
            width: 400px;
            height:auto;
            display: none;
            z-index: 1001;
            border: 2px solid black;
            background-color: #FFFFFF;
            text-align: center;
            vertical-align: middle;
            padding: 10px;
        }
</style>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div style="margin-top: -30px;">
        <table>
            <tr>
                <td>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="MASTER  /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="LABOR EFFICIENCY" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />

    <div style="margin-top:-20px;">
        <table align="center">
          <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label9" runat="server" Text="UNIT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddl_unit_LBeff" runat="server" class="dropdownstyle" OnSelectedIndexChanged="onselectedindexchanged_laboreff"
                        AutoPostBack="true">
                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                        <asp:ListItem Value="MBU">MBU</asp:ListItem>
                        <asp:ListItem Value="ABU">ABU</asp:ListItem>
                    </asp:DropDownList>
                    <%-- <select id="ddl_unit" class="dropdownstyle1" runat="server" OnSelectedIndexChanged="onselectedindexchanged_mchn" onblur="javascript:validate_rptunit();">
                        <option value="ALL">ALL</option>
                        <option value="MBU">MBU</option>
                        <option value="ABU">ABU</option>
                    </select>--%>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label10" runat="server" Text="MACHINE" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <select id="Slct_machine_eff_LE" runat="server" class="dropdownstyle">
                        <option value="0" selected="selected">-Select-</option>
                    </select>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label1" runat="server" Text="DATE" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_date" class="textboxstyle" runat="server" />
                    <%--   <input type="text" id="day" class="textboxstyle" runat="server" />
                      
                      <input type="text" id="month" class="textboxstyle" runat="server" />
                      <input type="text" id="year" class="textboxstyle" runat="server" />--%>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label4" runat="server" Text="SHIFT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddl_shift" runat="server" class="dropdownstyle" onchange="javascript:laborefficiency();"
                        AutoPostBack="false">
                        <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                        <asp:ListItem Value="A">A</asp:ListItem>
                        <asp:ListItem Value="B">B</asp:ListItem>
                        <asp:ListItem Value="C">C</asp:ListItem>
                        <asp:ListItem Value="G">G</asp:ListItem>
                        <asp:ListItem Value="A1">A1</asp:ListItem>
                        <asp:ListItem Value="B1">B1</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label5" runat="server" Text="EARNED TIME (Mints)" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="Text_earn" class="textboxstyle" runat="server" onkeypress="return onlyNumbers(this);"  />
                </td>
            </tr>
            
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label6" runat="server" Text="ACTUAL TIME (Mints)" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="Text_actual" class="textboxstyle" runat="server" onchange="javascript:changefocus();" onblur="javascript:changefocus();" onkeypress="return onlyNumbers(this);"  />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label8" runat="server" Text="ACTUAL TIME (Seconds)" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="txt_seconds" class="textboxstyle" runat="server"  onchange="javascript:actualtym();" onblur="javascript:actualtym();" onkeypress="return onlyNumbers(this);" />
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <b>
                        <asp:Label ID="Label7" runat="server" Text="TOTAL EFFICIENCY (%)" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <input type="text" id="ttl_tim" class="textboxstyle" runat="server" onkeypress="return onlyNumbers(this);"  />
                </td>
            </tr>
            <tr style="height: 20px;">
                <td colspan="3">
                    <div align="center" style="display: none; padding-left: 20px;" id="diverror">
                        <span id="spn_error" style="font-size: 14px; color: Red; font-family: Arial;"></span>
                    </div>
                </td>
            </tr>
          <%--  <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>--%>
            <tr  style="height: 5px;">
                <td colspan="3">
                    <div align="center" style="padding-left: 20px;">
                        <asp:ImageButton ID="ImageButton1" runat="server" Text="Save" color="black" ImageUrl="~/Menu_image/Save.jpg"
                            OnClick="ImageButton1_Click" OnClientClick="return Labor_validate()" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_labr" runat="server" align="center" >
                    <div style="padding-left:0px;">
                        <asp:GridView ID="Grid_lbr" runat="server" AutoGenerateColumns="False" Width="635px"
                             BorderColor="AliceBlue">
                            <Columns>
                             <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_sno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                </asp:TemplateField>
                             <%--  <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_sno" runat="server" Text='<%#Bind("LID") %>' Style="font-size: 12px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle BackColor="White"  HorizontalAlign="Center" BorderColor="Black"/>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="DATE" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_PID" runat="server" Text='<%#Bind("LDate") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SHIFT">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("Lshift") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EARNED TIME">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("earn_time") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ACTUAL TIME">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("actual_time") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TOTAL EFFICICENCY">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Process" runat="server" Text='<%# Bind("total_time") %>' Style="font-size: 12px;
                                            text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="#C3D3DA" />
                                    <FooterStyle BorderColor="#C3D3DA" />
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White"
                                        BorderColor="#C3D3DA" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                
                                
                                <%--<asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                                    <ItemTemplate>
                                        <a id="<%# Eval("LID") %>" onclick="javascript:deletecLABOREFFICICENCY(this.id);">
                                            <img src="../Images/Delete.png" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
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
              
    <div>
        <div id="shadow" class="opaqueLayer">
        </div>
        <div id="question" class="questionLayer">
            <div id="div_close">
                <span style="font-size: 13px; font-family: Verdana:Times New Roman; font-weight: bold;
                    color: Blue; float: right; cursor: pointer;">Close</span></div>
            <div id="div_errro">
            </div>
        </div>
    </div>
       <div align="center" id="div_actualerror" runat="server" visible="false">
        <span style="color: Red; font-family: Arial; font-size: 18px; font-weight: bold;">No
            Record Found</span>
    </div>
</asp:Content>
