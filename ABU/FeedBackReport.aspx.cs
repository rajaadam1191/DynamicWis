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

public partial class ABU_FeedBackReport : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btn_excel.Visible = false;
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
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
    protected void btn_search_Click1(object sender, ImageClickEventArgs e)
    {
        loadgrid();
    }

    public void loadgrid()
    {
        DateTime fromdate = Convert.ToDateTime(txt_fromdate.Value.ToString());
        DateTime todate = Convert.ToDateTime(txt_todate.Value.ToString());

        strConnString.Open();
        cmd = new SqlCommand("selecttoolfeedback", strConnString);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@from", SqlDbType.DateTime).Value = fromdate;
        cmd.Parameters.Add("@to", SqlDbType.DateTime).Value = todate;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        strConnString.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            grid_abumaster.DataSource = ds.Tables[0];
            grid_abumaster.DataBind();
            btn_excel.Visible = true;
        }
        else
        {
            btn_excel.Visible = false;
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
                Response.AddHeader("content-disposition", "attachment;filename=ToolFeedbackReport.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
                loadgrid();
            }
        }
    }
    public void loadgridpdf()
    {
        DateTime fromdate = Convert.ToDateTime(txt_fromdate.Value.ToString());
        DateTime todate = Convert.ToDateTime(txt_todate.Value.ToString());

        strConnString.Open();
        cmd = new SqlCommand("selecttoolfeedback", strConnString);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@from", SqlDbType.DateTime).Value = fromdate;
        cmd.Parameters.Add("@to", SqlDbType.DateTime).Value = todate;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        strConnString.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            grid_abumaster.DataSource = ds.Tables[0];
            grid_abumaster.DataBind();
        }
        else
        {
        }
    }
}

