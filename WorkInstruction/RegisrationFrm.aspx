<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="RegisrationFrm.aspx.cs" Inherits="RegisrationFrm" Title="PH :: REGISTRATION FORM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Styles/QualityStyle.css" rel="stylesheet" type="text/css" />
    <%--<script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>--%>
    <%--<script src="JS/QualitySheetscript.js" type="text/javascript"></script>--%>

    <script src="../JS/reg_val.js" type="text/javascript"></script>
    <script src="../JS/ErrorPOPup.js" type="text/javascript"></script>

    <style type="text/css">
        .errormsg
        {
            border: solid 1px red;
        }
        .errormsg1
        {
            border: solid 1px #0b5aa3;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div align="center" style="padding-top: 60px;">
        <div style="margin-top: -90px; float: left;">
            <table align="left">
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label7" runat="server" Text="PRODUCTION DOCUMENT /" valign="left"
                            Font-Bold="true" Font-Size="30px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="REGISTRATION FORM" valign="left" Font-Bold="true"
                            Font-Size="20px" ForeColor="#0b7dc6" Font-Names="Arial"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div  align="center" style="margin-top:0px;">
            <table>
                <tr>
                    <td align="left">
                        <b>
                            <asp:Label ID="Label4" runat="server" Text=" USER NAME" Style="font-family: Times New Roman;"
                                CssClass="lablestyle">
                            </asp:Label></b>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="text" id="txt_username" runat="server" class="textboxstyle" onblur="javascript:validate_username();" />
                    </td>
                </tr>
                <tr style="height: 7px;">
                    <td colspan="3" style="height: 5px">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span id="spnpassword"><b>
                            <asp:Label ID="Label1" runat="server" Text="PASSWORD" Style="font-family: Times New Roman;"
                                CssClass="lablestyle">
                            </asp:Label></b></span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="password" id="txt_password" runat="server" class="textboxstyle" onblur="javascript:validate_password();" />
                    </td>
                </tr>
                <tr style="height: 7px;">
                    <td colspan="3">
                        <div style="padding-left: 200px;">
                            <span id="sp_error" style="color: Red; font-family: Verdana:Times New Roman; font-size: 12px;
                                display: none;"></span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td  align="left">
                        <span id="spn_repassword"><b>
                            <asp:Label ID="Label2" runat="server" Text="RE-TYPE PASSWORD" Style="font-family: Times New Roman;"
                                CssClass="lablestyle">
                            </asp:Label></b></span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="password" id="txt_retype" runat="server" class="textboxstyle" onblur="javascript:validate_retype();" />
                        <input type="password" id="txtretype" runat="server" style="display: none;" class="textboxstyle"
                            onblur="javascript:validate_Uretype();" />
                    </td>
                </tr>
                <tr style="height: 7px;">
                    <td colspan="3">
                        <div style="padding-left: 200px;">
                            <span id="spnretype" style="color: Red; font-family: Verdana:Times New Roman; font-size: 12px;
                                display: none;"></span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td  align="left">
                        <b>
                            <asp:Label ID="Label3" runat="server" Text="USER ROLE" Style="font-family: Times New Roman;"
                                CssClass="lablestyle">
                            </asp:Label></b>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <select id="ddl_role" runat="server" class="dropdownstyle">
                            <option value="0" selected="selected">-Select-</option>
                            <option value="1">Super Admin</option>
                            <option value="2">Admin</option>
                            <option value="3">User</option>
                        </select>
                    </td>
                </tr>
                <%--<tr style="height: 5px;">
                    <td class="lablestyle" valign="top">
                        Allow Pages
                    </td>
                    <td valign="top" style="font-weight: bolder;">
                        :
                    </td>
                    <td>
                        <div style="overflow-y: scroll; overflow-x: hidden; width: 460px; height: 345px; border:solid 1px #064b68;">
                            <asp:GridView ID="grid_pages" runat="server" AutoGenerateColumns="False" Style="margin-right: 0px;
                                text-align: left;" CellSpacing="10" Width="441">
                                <RowStyle CssClass="GridItem" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="100px">
                                        <HeaderTemplate>
                                            <span>Select All</span>
                                            <asp:CheckBox ID="chkboxSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkboxSelectAll_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ch_pages" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee ID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_pageid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Page_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Allow Pages">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Page_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>--%>
                <tr style="height: 20px;">
                    <td colspan="3">
                    <div id="div_errorr" style="display: none; padding-left: 0px;">
                        <span id="spnerror" style="font-family: Arial; font-size: 14px; color: Red;"></span>
                    </div>
                    </td>
                </tr>
                
                <tr style="height: 5px;">
                    <td colspan="3">
                        <div style="padding-left: 280px;" id="div_save" runat="server">
                            <asp:ImageButton ID="btn_save" runat="server" ImageUrl="~/Menu_image/Save.jpg" OnClick="btn_save_Click"
                                OnClientClick="return validate_registration();" Style="cursor: pointer;" /></div>
                        <div style="padding-left: 280px; display: none;" id="div_update" runat="server">
                            <asp:ImageButton ID="btn_update" runat="server" ImageUrl="~/Menu_image/Submit.jpg"
                                OnClientClick="return validate_updateregistration();" OnClick="btn_update_Click"
                                Style="cursor: pointer;" /></div>
                    </td>
                </tr>
                <tr style="height: 20px;">
                    <td colspan="3">
                    </td>
                </tr>
            </table>
        </div>
        <div id="div_reg" runat="server" >
            <asp:GridView ID="grid_registration" runat="server" AutoGenerateColumns="false" Width="610">
                <Columns>
                    <asp:TemplateField HeaderText="Employee ID" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbl_regid" runat="server" Text='<%#Bind("Reg_ID") %>' Style="font-size: 12px;text-align: center;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Name">
                        <ItemTemplate>
                            <asp:Label ID="lbl_regusername" runat="server" Text='<%# Bind("Reg_Username") %>' Style="font-size: 12px;text-align: center;"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Password">
                        <ItemTemplate>
                            <asp:Label ID="lbl_regpassword" runat="server" Text="*********"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Re-Password" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_repassword" runat="server" Text="*********"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created Date">
                        <ItemTemplate>
                            <asp:Label ID="lbl_regdate" runat="server" Text='<%# Bind("Reg_Createdate") %>' Style="font-size: 12px;text-align: center;"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Role">
                        <ItemTemplate>
                            <asp:Label ID="lbl_regrole" runat="server" Text='<%# Bind("Reg_Role") %>' Style="font-size: 12px;text-align: center;"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                        <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit" ControlStyle-Width="50pt">
                        <ItemTemplate>
                            <a id="<%# Eval("Reg_ID") %>" onclick="javascript:getregvalues(this.id);">
                                <img src="../Images/Edit.jpg" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                            </a>
                        </ItemTemplate>
                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                        <ItemStyle BackColor="White" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" ControlStyle-Width="50pt">
                        <ItemTemplate>
                            <a id="<%# Eval("Reg_ID") %>" onclick="javascript:deletevalues(this.id);">
                                <img src="../Images/Delete.png" alt="" style="height: 20px; width: 20px; cursor: pointer;" />
                            </a>
                        </ItemTemplate>
                        <HeaderStyle Width="100" BackColor="#4C6C9F" Font-Size="Small" ForeColor="White" />
                        <ItemStyle BackColor="White" HorizontalAlign="Center" />
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
        <input type="hidden" id="hdn_regid" name="hdn_regid" runat="server" />
    </div>
       <div align="center" id="div_actualerror" runat="server" visible="false">
        <span style="color: Red; font-family: Arial; font-size: 18px; font-weight: bold;">No
            Record Found</span>
    </div>
</asp:Content>
