using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

//using Excel = Microsoft.Office.Interop.Excel;
//using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;

public partial class ToolHistory : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public DataSet ds;
    public SqlDataAdapter da;
    public SqlCommand cmd;
    public int findex, lindex, count = 0;
    public PagedDataSource paging = new PagedDataSource();
    public QualitySheetdclassDataContext objcontext = new QualitySheetdclassDataContext();
    public Abu_Master objabu = new Abu_Master();
    public StringBuilder sb = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindToolNumber();
            div_paging.Visible = false;
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void loadgrid()
    {
       
    }
    private void createpaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");
        findex = CurrentPage - 10;
        if (CurrentPage >= 9)
        {
            lindex = CurrentPage + 10;
        }
        else
        {
            lindex = 10;
        }
        if (lindex > Convert.ToInt32(ViewState["totalpage"]))
        {
            lindex = Convert.ToInt32(ViewState["totalpage"]);
            findex = lindex - 10;
        }
        if (findex < 0)
        {
            findex = 0;
        }
        for (int i = findex; i < lindex; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }
        DataListPaging.DataSource = dt;
        DataListPaging.DataBind();
    }
    public int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] != null)

                return Convert.ToInt32(ViewState["CurrentPage"]);
            else
                return 0;
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }
    protected void DataListPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        LinkButton lnkPage = (LinkButton)e.Item.FindControl("link_pagebtn");
        if (lnkPage.CommandArgument.ToString() == CurrentPage.ToString())
        {
            lnkPage.Enabled = false;
            lnkPage.Font.Bold = true;
            lnkPage.Attributes.Add("class", "square_selected");
        }
        else
        {
            lnkPage.Attributes.Add("class", "square");
        }
    }
    protected void DataListPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("newpage"))
        {
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            loadgrid();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        loadgrid();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        loadgrid();
    }
    protected void grid_abumaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label ID = e.Row.FindControl("lbl_id") as Label;
            System.Web.UI.WebControls.Image image = e.Row.FindControl("ph_image") as System.Web.UI.WebControls.Image;
            TableCell cell = e.Row.Cells[2];
            Label lbl_retine = e.Row.FindControl("lbl_retine") as Label;
            Label lbl_remarks = e.Row.FindControl("lbl_remarks") as Label;
            Label lbl_maintain = e.Row.FindControl("lbl_maintain") as Label;
            if (ID.Text != "" && ID.Text != null)
            {
                da = new SqlDataAdapter("select * from Abu_Master where ID='" + Convert.ToInt32(ID.Text.ToString()) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select ROW_NUMBER() over (order by min(ToolNumber)) as IndexNo,min(SID) as SID,min(ToolNumber)as ToolNumber,min(Maximum)as Maximum,min(Minimum) as Minimum,min(CurrentStock) as TotalCount,min(Tool) as Tool  from SpareView  where Toolnumber='" + Convert.ToInt32(ds.Tables[0].Rows[0]["ToolNumber"].ToString()) + "' group by Toolnumber", strConnString);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        lbl_maintain.Text = ds1.Tables[0].Rows[0]["TotalCount"].ToString();
                    }

                    //image.ImageUrl = "~/ABU/Tools/" + ds.Tables[0].Rows[0]["Photo"].ToString();
                    if (ds.Tables[0].Rows[0]["Photo"] != null && ds.Tables[0].Rows[0]["Photo"].ToString() != "")
                    {
                        image.ImageUrl = "~/ABU/Tools/" + ds.Tables[0].Rows[0]["Photo"].ToString();
                    }
                    else
                    {
                        image.ImageUrl = "~/Menu_image/noimage.png";
                    }

                    if (ds.Tables[0].Rows[0]["LifeExtend"] != null && ds.Tables[0].Rows[0]["LifeExtend"].ToString() != "" && ds.Tables[0].Rows[0]["LifeExtend"].ToString() != "0")
                    {
                        int from = Convert.ToInt32(ds.Tables[0].Rows[0]["Rentime"].ToString());
                        int to = Convert.ToInt32(ds.Tables[0].Rows[0]["LifeExtend"].ToString());
                        int tot = from + to;
                        lbl_retine.Text = tot.ToString();
                        lbl_remarks.Text = "Life Extended";
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[0]["Spare"].ToString() == "Yes")
                        {
                            lbl_remarks.Text = "Spare Replaced";
                        }
                        else if (ds.Tables[0].Rows[0]["Spare"].ToString() == "No")
                        {
                            lbl_remarks.Text = "Life Extended";
                        }
                        else
                        {
                            lbl_remarks.Text = "";
                        }
                        if (ds.Tables[0].Rows[0]["ToolStatus"].ToString() == "Active")
                        {
                            lbl_retine.Text = ds.Tables[0].Rows[0]["Rentime"].ToString();
                            lbl_remarks.Text = "";
                        }
                        else
                        {
                            lbl_retine.Text = ds.Tables[0].Rows[0]["Rentime"].ToString();
                            lbl_remarks.Text = "Spare Replaced";
                        }
                    }
                    string setColorClass = string.Empty;
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenTo"].ToString()))
                    {
                        setColorClass = "Green";
                    }
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowTo"].ToString()))
                    {
                        setColorClass = "Yellow";
                    }
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                    {
                        setColorClass = "Red";
                    }
                    else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                    {
                        setColorClass = "Red";
                    }
                    cell.CssClass = setColorClass;
                }
                else
                {
                }
            }
            else
            {
            }

        }


    }
    protected void OnDataBound(object sender, EventArgs e)
    {
        if (grid_abumaster.Rows.Count > 0)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            for (int i = 1; i < grid_abumaster.Columns.Count; i++)
            {
                TableHeaderCell cell = new TableHeaderCell();
                TextBox txtSearch = new TextBox();
                txtSearch.Attributes["placeholder"] = "Filter";
                txtSearch.CssClass = "search_textbox";
                cell.Controls.Add(txtSearch);
                row.Controls.Add(cell);
            }
            grid_abumaster.HeaderRow.Parent.Controls.AddAt(1, row);
        }
    }
    private void BindToolNumber()
    {

        ds = objserver.GetDateset("select '0' ID,'--- Select Tool Number ---' ToolNumber union select distinct b.ID,b.ToolNumber as ToolNumber from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID");
        txt_toolnumber.DataSource = ds.Tables[0];
        txt_toolnumber.DataValueField = "ID";
        txt_toolnumber.DataTextField = "ToolNumber";
        txt_toolnumber.DataBind();
    }

    protected void txt_toolnumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(txt_toolnumber.SelectedValue.ToString());
            da = new SqlDataAdapter("select ROW_NUMBER() over (order by b.ToolNumber) as IndexNo, a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Inactive' and b.Id='" + id.ToString() + "'", strConnString);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds);
            da.Fill(dt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                paging.DataSource = dt.DefaultView;
                if (ds.Tables[0].Rows.Count > 8)
                {
                    paging.AllowPaging = true;
                    paging.PageSize = 8;
                    paging.CurrentPageIndex = CurrentPage;
                    ViewState["totalpage"] = paging.PageCount;
                    link_previous.Enabled = !paging.IsFirstPage;
                    link_next.Enabled = !paging.IsLastPage;
                }
                else
                {
                    div_paging.Visible = false;
                }
                grid_abumaster.DataSource = paging;
                grid_abumaster.DataBind();
                createpaging();
                spn_toolC.Visible = true;
                
            }
            else
            {
                //spn_toolC.Visible = false;
                //div_paging.Visible = false;
                //grid_abumaster.DataSource = null;
                //grid_abumaster.DataBind();
                //createpaging();

                da = new SqlDataAdapter("select ROW_NUMBER() over (order by b.ToolNumber) as IndexNo,a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active' and b.Id='" + id.ToString() + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                da.Fill(dt);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    paging.DataSource = dt.DefaultView;
                    if (ds.Tables[0].Rows.Count > 8)
                    {
                        paging.AllowPaging = true;
                        paging.PageSize = 8;
                        paging.CurrentPageIndex = CurrentPage;
                        ViewState["totalpage"] = paging.PageCount;
                        link_previous.Enabled = !paging.IsFirstPage;
                        link_next.Enabled = !paging.IsLastPage;
                    }
                    else
                    {
                        div_paging.Visible = false;
                    }
                    grid_abumaster.DataSource = paging;
                    grid_abumaster.DataBind();
                    createpaging();
                    spn_toolC.Visible = true;

                }
            }
            da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from AbuToolFeedback  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where b.Id='" + id.ToString() + "'", strConnString);
            ds = new DataSet();
            DataTable dt1 = new DataTable();
            da.Fill(ds);
            da.Fill(dt1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                paging.DataSource = dt1.DefaultView;
                if (ds.Tables[0].Rows.Count > 8)
                {
                    paging.AllowPaging = true;
                    paging.PageSize = 8;
                    paging.CurrentPageIndex = CurrentPage;
                    ViewState["totalpage"] = paging.PageCount;
                    link_previous.Enabled = !paging.IsFirstPage;
                    link_next.Enabled = !paging.IsLastPage;
                }
                else
                {
                    div_paging.Visible = false;
                }
                GridView1.DataSource = paging;
                GridView1.DataBind();
                spn_toolf.Visible = true;
            }
            else
            {
                spn_toolf.Visible = false;
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label ID = e.Row.FindControl("lbl_id") as Label;
            Label lbl_feedback = e.Row.FindControl("lbl_feedback") as Label;
            Label lbl_reponser = e.Row.FindControl("lbl_reponser") as Label;
            Label lbl_reqdate = e.Row.FindControl("lbl_reqdate") as Label;
            Label lbl_resdate = e.Row.FindControl("lbl_resdate") as Label;
            TableCell cell = e.Row.Cells[2];
            if (ID.Text != "" && ID.Text != null)
            {
                da = new SqlDataAdapter("select * from AbuToolFeedback where ID='" + Convert.ToInt32(ID.Text.ToString()) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ReqDate"] != null && ds.Tables[0].Rows[0]["ReqDate"].ToString() != "")
                    {
                        lbl_reqdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReqDate"].ToString()).ToShortDateString().ToString();
                    }
                    else
                    {
                        lbl_reqdate.Text = "";
                    }
                    if (ds.Tables[0].Rows[0]["ResDate"] != null && ds.Tables[0].Rows[0]["ResDate"].ToString() != "")
                    {
                        lbl_resdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ResDate"].ToString()).ToShortDateString().ToString();
                    }
                    else
                    {
                        lbl_resdate.Text = "";
                    }
                    if (ds.Tables[0].Rows[0]["Response"] != null && ds.Tables[0].Rows[0]["Response"].ToString() != "")
                    {
                        lbl_reponser.Text = ds.Tables[0].Rows[0]["Response"].ToString();
                        lbl_reponser.CssClass = "textcolor";
                    }
                    else
                    {
                        lbl_reponser.Text = "Pending";
                        lbl_reponser.CssClass = "textcolor1";
                        lbl_reponser.Attributes.Add("onclick", "response(" + ID.Text.ToString() + ")");
                    }
                }
                else
                {

                }
            }
            else
            {
            }
        }
    }
}
