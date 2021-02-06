<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="Time_Master.aspx.cs" Inherits="Time_Master" Title="PH :: Time Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css"></link>
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../JS/Common.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
   function checkbrowser(browser)
   {
        if(browser=="IE")
        {
            
            document.getElementById("div_upload").style.marginLeft='-203px';
        }
        else
        {
        }
        
   }
   
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
        .errormessage
        {
            border: solid 1px red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div style="margin-top: -30px;">
        <table>
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="MASTER /" valign="left" Font-Bold="true"
                        Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="TIME MASTER" valign="left" Font-Bold="true"
                        Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div align="center" style="margin-top:-50px;margin-left:-20px;">
        <table>
            <tr style="height: 50px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <b>
                        <asp:Label ID="Label1" runat="server" Text="PART NO" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="DropPartNo" runat="server" CssClass="dropdownstyle" onchange="javascript:validate_Tpartno();">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <b>
                        <asp:Label ID="Label2" runat="server" Text="OPERATION" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="DropOperation" runat="server" CssClass="dropdownstyle" onchange="javascript:validate_Tprocess();">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <b>
                        <asp:Label ID="Label4" runat="server" Text="BOTTLE NECK TIME" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="TxtBottleNeckTime" runat="server" CssClass="textboxstyle" onkeypress="return onlyNumbers(this);"
                        onblur="javascript:validate_Tbotele();" ></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <b>
                        <asp:Label ID="Label5" runat="server" Text="TT" Style="font-family: Times New Roman;"
                            CssClass="lablestyle">
                        </asp:Label></b>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="TxtTt" runat="server" CssClass="textboxstyle" onblur="javascript:validate_TT();"
                        onkeypress="return onlyNumbers(this);"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <div id="div_upload" visible="false">
                <tr style="height: 5px;">
                    <td style="text-align: left;">
                        <b>
                            <asp:Label ID="Label7" runat="server" Text="FILE" Style="font-family: Times New Roman;"
                                CssClass="lablestyle">
                            </asp:Label></b>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:FileUpload ID="fup_file" runat="server" Width='440px' Height='25px' Font-Size="Medium"
                            ForeColor="Black" />
                    </td>
                </tr>
            </div>
            <tr style="height: 5px;">
                <td colspan="3">
                </td>
            </tr>
            <tr style="height: 5px;">
                <td colspan="3">
                    <div align="center" style="padding-left: 30px;" id="div_save" runat="server">
                        <asp:ImageButton ID="btn_save" OnClick="btn_save_Click" runat="server" ImageUrl="~/Menu_image/Save.jpg"
                            OnClientClick="return validateTimemaster();" /></div>
                    <div align="center" style="padding-left: 30px; display: none;" id="div_update" runat="server">
                        <asp:ImageButton ID="btn_update" runat="server" ImageUrl="~/Menu_image/Submit.jpg"
                            OnClientClick="return validateTimemaster();" OnClick="btn_update_Click" Style="cursor: pointer;" /></div>
                </td>
            </tr>
            <tr style="height: 20px;">
                <td colspan="3">
                </td>
            </tr>
        </table>
    </div>
   
     <div align="center" runat="server" id="div_time">
       
                    <div>
                         <asp:GridView ID="gridTimemaster" runat="server" Width="610px" BorderColor="AliceBlue"
                            AutoGenerateColumns="false" >
                            <Columns>
                             <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_sno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                </asp:TemplateField>
                              <%--  <asp:TemplateField HeaderText="Employee ID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_regid" runat="server" Text='<%#Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Part No">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_regusername" runat="server" Text='<%# Bind("PartNo") %>' Style="font-size: 12px;text-align: center;" ></asp:Label>
                                    </ItemTemplate>
                                    
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Operation">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_regpassword" runat="server" Text='<%# Bind("Operation") %>' Style="font-size: 12px;text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bottle Neck Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_repassword" runat="server" Text='<%# Bind("BottleNecktime") %>' Style="font-size: 12px;text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TT">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_regdate" runat="server" Text='<%# Bind("tt") %>' Style="font-size: 12px;text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ControlStyle-Width="50pt">
                                    <ItemTemplate>
                                        <a id="<%# Eval("ID") %>" onclick="javascript:gettimemaster(this.id);">
                                            <img src="../Images/Edit.jpg" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                                    <ItemTemplate>
                                        <a id="<%# Eval("ID") %>" onclick="javascript:deletetimemaster(this.id);">
                                            <img src="../Images/Delete.png" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                                    <ItemStyle BackColor="White" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblresult" runat="server"></asp:Label>
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
    <div align="center" id="div_actualerror" runat="server" visible="false">
        <span style="color: Red; font-family: Arial; font-size: 18px; font-weight: bold;">No
            Record Found</span>
    </div>
    <input type="hidden" id="hdn_browser" name="hdn_browser" runat="server" />
    <input type="hidden" id="hdn_timeid" name="hdn_timeid" runat="server" />
</asp:Content>
