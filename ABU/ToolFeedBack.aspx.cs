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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class ABU_ToolFeedBack : System.Web.UI.Page
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
    public AbuToolFeedback objf = new AbuToolFeedback();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
            loadgrid();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
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
    public void loadgrid()
    {
        da = new SqlDataAdapter("select ROW_NUMBER() over (order by b.ToolNumber) as IndexNo,a.* ,b.ToolNumber as Tool from AbuToolFeedback  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID", strConnString);
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
        }
        else
        {
        }
    }
    protected void grid_abumaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label ID = e.Row.FindControl("lbl_id") as Label;
            Label lbl_feedback = e.Row.FindControl("lbl_feedback") as Label;
            Label lbl_reponser = e.Row.FindControl("lbl_reponser") as Label;
            Label lbl_reqdate = e.Row.FindControl("lbl_reqdate") as Label;
            Label lbl_resdate = e.Row.FindControl("lbl_resdate") as Label;
          //  Image image = e.Row.FindControl("ph_image") as Image;
            TableCell cell = e.Row.Cells[2];
            if (ID.Text != "" && ID.Text != null)
            {
                da = new SqlDataAdapter("select * from AbuToolFeedback where ID='" + Convert.ToInt32(ID.Text.ToString()) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // image.ImageUrl = "~/ABU/Tools/" + ds.Tables[0].Rows[0]["Photo"].ToString();
                    //string setColorClass = string.Empty;
                    //if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenTo"].ToString()))
                    //{
                    //    setColorClass = "Green";
                    //}
                    //if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowTo"].ToString()))
                    //{
                    //    setColorClass = "Yellow";
                    //}
                    //if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                    //{
                    //setColorClass = "Red";
                    // }
                   // cell.CssClass = setColorClass;
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
    protected void btn_savefeed_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            cmd = new SqlCommand("updatetoolfeedback", strConnString);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(hdn_fid.Value.ToString());
            cmd.Parameters.Add("@res", SqlDbType.DateTime).Value =  Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
            cmd.Parameters.Add("@response", SqlDbType.VarChar, 500).Value = txt_response.Value.ToString();
            strConnString.Open();
            cmd.ExecuteNonQuery();
            strConnString.Close();
            loadgrid();
        }
        catch (Exception ex)
        {
        }
        finally
        {
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
    protected void ExportToPDF(object sender, EventArgs e)
    {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                //To Export all pages
                grid_abumaster.AllowPaging = false;
                loadgridpdf();

                grid_abumaster.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.LEGAL.Rotate());
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=ToolFeedback.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
                loadgrid();
            }
        }
    }
    public void loadgridpdf()
    {
        da = new SqlDataAdapter("select ROW_NUMBER() over (order by b.ToolNumber) as IndexNo,a.* ,b.ToolNumber as Tool from AbuToolFeedback  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID", strConnString);
        ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds);
        da.Fill(dt);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grid_abumaster.DataSource = dt.DefaultView;
            grid_abumaster.DataBind();
            createpaging();
        }
        else
        {
        }
    }

}
