<%@ Page Language="C#" MasterPageFile="~/AbuMaster.master" AutoEventWireup="true" enableEventValidation ="false"
    CodeFile="FeedBackReport.aspx.cs" Inherits="ABU_FeedBackReport" Title="PH :: FeedBack Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../Chartdate/jquery.datepick.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../JS/Abu.js" type="text/javascript"></script>
<script src="../Chartdate/jquery.datepick.js" type="text/javascript"></script>
 <script src="../JS/quicksearch.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    $(document).ready(function()
{
     $("input[id$='txt_fromdate']").datepick({maxDate: 31,dateFormat: 'dd/mm/yyyy'});
     $("input[id$='txt_todate']").datepick({maxDate: 31,dateFormat: 'dd/mm/yyyy'});
   
});
 $(function () {
            $('.search_textbox').each(function (i) {
                $(this).quicksearch("[id*=grid_abumaster] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });
    </script>
<style type="text/css">
         .search_textbox
        {
            text-align: center;
            border: solid 1px #000;
            width:100px;
        }
        
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
         <div style="margin-top: 50px; margin-left:600px;"  align="center" >
            <table align="left">
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text="ABU /" valign="left" Font-Bold="true"
                            Font-Size="30px" ForeColor="White" Font-Names="Arial"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="FEEDBACK REPORT" valign="left" Font-Bold="true"
                            Font-Size="20px" ForeColor="White" Font-Names="Arial"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <div style="margin-left: -10px; margin-top: -10px;">
            <table align="center">
                <tr>
                    <td align="left">
                        <span class="lablestyle" style="color:#fff;">From</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="text" id="txt_fromdate" runat="server" class="textboxstyle" style="width: 218px;" />
                    </td>
                    <td style="width: 30px;">
                    </td>
                    <td align="left">
                        <span class="lablestyle" style="color:#fff;">To</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <input type="text" id="txt_todate" runat="server" class="textboxstyle" style="width: 218px;" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <div style="margin-left: 50px;" align="center">
            <asp:ImageButton ID="btn_search" runat="server" ImageUrl="~/Menu_image/view.jpg"
                OnClientClick="return valdate();" OnClick="btn_search_Click1" />
        </div>
    </div>
    <br />
    <br />
  
    <div>
      <div><table><tr><td><div style="padding-left: 1200px;">
                        <asp:ImageButton ID="btn_excel" Visible="false" runat="server" Text="Excel" color="black" ImageUrl="~/Menu_image/Export.png"
                            OnClick="ExportToPDF"/>
                    </div></td></tr></table></div>
        <table>
            <tr>
                <td>
                    <div>
                        <asp:GridView ID="grid_abumaster" runat="server" BorderColor="AliceBlue" AutoGenerateColumns="false"
                            OnRowDataBound="grid_abumaster_RowDataBound" ondatabound="OnDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle BackColor="White" BorderColor="Black" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="#4c6c9f" HeaderStyle-ForeColor="#FFFFFF"
                                    Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID") %>'
                                            Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle BackColor="#b9d2ef" BorderColor="" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tool Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_tool" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Tool") %>'
                                            Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" HorizontalAlign="Center" Height="30" BackColor="White" BorderColor="Black"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Station">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_avail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Station") %>'
                                            Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FeedBack">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_feedback" runat="server" Style="font-size: 15px; text-align: center;"
                                            Text='<%#DataBinder.Eval(Container.DataItem, "FeedBack") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Request Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_reqdate" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Response Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_resdate" runat="server" Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Retension Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_desc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReTime") %>'
                                            Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Issued On">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_retine" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Issued") %>'
                                            Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Next Due">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_issued" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NextDue") %>'
                                            Style="font-size: 15px; text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Response">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_reponser" runat="server" Style=""></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200" BackColor="#4C6C9F" Font-Size="15px" ForeColor="White" />
                                    <ItemStyle Width="200" BackColor="White" HorizontalAlign="Center" BorderColor="Black" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
