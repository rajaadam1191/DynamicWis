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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.DataVisualization.Charting;

public partial class FixtureChange : System.Web.UI.Page
{
    public String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    public DBServer objserver = new DBServer();
    public DataSet ds;
    public PagedDataSource paging = new PagedDataSource();
    public SqlDataAdapter da;
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public int findex, lindex, count = 0;
    public string[] PartNo;
    public static Object thisLock = new Object();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //  loadgridview();
            div_paging.Visible = false;
            loadfixchange();
        }
    }
    protected void changeOnDataBound(object sender, EventArgs e)
    {
        lock (thisLock)
        {
            try
            {

                if (GridView3.Rows.Count > 0)
                {
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                    for (int i = 0; i < GridView3.Columns.Count - 1; i++)
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        TextBox txtSearch = new TextBox();
                        txtSearch.Attributes["placeholder"] = "Search";
                        txtSearch.CssClass = "search_textbox";
                        cell.Controls.Add(txtSearch);
                        row.Controls.Add(cell);
                    }
                    GridView3.HeaderRow.Parent.Controls.AddAt(1, row);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }

    }
    protected void DataListPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        LinkButton lnkPage = (LinkButton)e.Item.FindControl("link_pagebtn");
        lock (thisLock)
        {
            try
            {
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
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }

    }
    private void createpaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");
        findex = CurrentPage - 5;
        if (CurrentPage >= 4)
        {
            lindex = CurrentPage + 10;
        }
        else
        {
            lindex = 5;
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
    protected void DataListPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("newpage"))
        {
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            loadfixchange();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        loadfixchange();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        loadfixchange();
    }

    public void loadfixchange()
    {
        lock (thisLock)
        {
            try
            {
                string query = "select ROW_NUMBER() over (order by b.FID desc) as IndexNo,min(a.Fid) as Fid,min(a.FixName) as FixName,min(b.Partnumber) as Partno,min(a.FixLife) as FixLife,min(a.Operation) as Operation,min(a.Gfrom) as Gfrom,min(a.Gto) as Gto,min(a.Yfrom) as Yfrom,min(a.Yto) as Yto,min(a.Rfrom) as Rfrom,min(a.Rto) as Rto,min(a.Creationdata) as Creationdata,min(a.Status) as Status,min(a.Flag) as Flag,min(a.GreenRange) as GreenRange,min(a.YellowRange) as YellowRange,min(a.RedRange) as RedRange,min(a.GreenRange1) as GreenRange1,min(a.YellowRange1) as YellowRange1,min(a.RedRange1) as RedRange1,min(a.Availability) as Availability,min(a.Imagefile) as Imagefile,min(a.Drawing) as Drawing,min(ModifyDate) as ModifyDate,min(b.Fixturename) as Fixturename,min(b.Model) as Model,isnull(sum(cast(c.TotalCount as int)),0) as currentstock,min(d.GreenOpenDate) as issueon from FixtureValues a inner join FixtureName b on a.FixName =b.Fixturename Left join SpareMastermbu c ON b.FID =c.ToolNumber  Left join FixtureStatus d on b.Fixturename=d.Fixtureno where a.Status='Inactive' group by b.FID";
                SqlDataAdapter da1 = new SqlDataAdapter(query, strConnString);
                DataSet ds1 = new DataSet();
                DataTable dt = new DataTable();
                da1.Fill(ds1);
                da1.Fill(dt);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    div_pdf.Visible = false;
                    paging.AllowPaging = true;
                    paging.DataSource = dt.DefaultView;
                    if (ds1.Tables[0].Rows.Count > 8)
                    {
                        paging.PageSize = 8;
                        paging.CurrentPageIndex = CurrentPage;
                        ViewState["totalpage"] = paging.PageCount;
                        link_previous.Enabled = !paging.IsFirstPage;
                        link_next.Enabled = !paging.IsLastPage;
                        // div_pdf.Visible = true;
                    }
                    else
                    {
                        div_paging.Visible = false;
                    }
                    GridView3.DataSource = paging;
                    GridView3.DataBind();
                    //  div_actual.Visible = true;
                    //  div_actualerror.Visible = false;
                    createpaging();
                }
                else
                {
                    GridView3.DataSource = null;
                    div_paging.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }

    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        lock (thisLock)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //e.Row.Cells[3].Attributes.Add("style", "word-break:break-all;word-wrap:break-word;");

                    Label ID = e.Row.FindControl("lbl_id") as Label;
                    System.Web.UI.WebControls.Image image = e.Row.FindControl("ph_image") as System.Web.UI.WebControls.Image;
                    //Image ph_drawing = e.Row.FindControl("ph_drawing") as Image;
                    Label lbl_status = e.Row.FindControl("lbl_status") as Label;
                    Label lbl_remarks = e.Row.FindControl("lbl_remarks") as Label;
                    Label lbl_life = e.Row.FindControl("lbl_life") as Label;
                    Label lbl_fixcount = e.Row.FindControl("lbl_fixcount") as Label;
                    //TableCell cell = e.Row.Cells[19];
                    if (ID.Text != "" && ID.Text != null)
                    {
                        da = new SqlDataAdapter("select * from FixtureValues a inner join FixtureName b on a.FixName=b.Fixturename where a.Fid='" + Convert.ToInt32(ID.Text.ToString()) + "'", strConnString);
                        ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Imagefile"] != null && ds.Tables[0].Rows[0]["Imagefile"].ToString() != "")
                            {
                                image.ImageUrl = "~/Fixture/FixtureImage/" + ds.Tables[0].Rows[0]["Imagefile"].ToString();
                            }
                            else
                            {
                                image.ImageUrl = "~/Menu_image/noimage.png";
                            }

                            //if (ds.Tables[0].Rows[0]["Drawing"] != null && ds.Tables[0].Rows[0]["Drawing"].ToString() != "")
                            //{
                            //    ph_drawing.ImageUrl = "~/Fixture/Drawing/" + ds.Tables[0].Rows[0]["Drawing"].ToString();
                            //}
                            //else
                            //{
                            //    ph_drawing.ImageUrl = "~/Menu_image/noimage.png";
                            //}
                            if (ds.Tables[0].Rows[0]["Fixtureclose"] == "Yes")
                            {
                                lbl_remarks.Text = "Fixture Life Completed";
                            }
                            else
                            {
                                lbl_remarks.Text = "Life Extended";
                            }
                            string setColorClass = string.Empty;
                            SqlDataAdapter da1 = new SqlDataAdapter("select a.*,b.Fixturename,b.Cell,b.Partnumber from FixtureValues a inner join FixtureName b on a.FixName=b.Fixturename where a.Operation='" + ds.Tables[0].Rows[0]["Operation"].ToString() + "' and b.Line='" + ds.Tables[0].Rows[0]["Line"].ToString() + "' and FixName='" + ds.Tables[0].Rows[0]["FixName"].ToString() + "' and a.Status='Active'", strConnString);
                            DataSet ds1 = new DataSet();
                            ds1.Tables.Clear();
                            ds1.Clear();
                            ds1.Reset();

                            da1.Fill(ds1);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                int fixcount = 0;
                                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                                {
                                    string[] spltpartno = ds1.Tables[0].Rows[j]["Partnumber"].ToString().Split(',');
                                    for (int k = 0; k < spltpartno.Length; k++)
                                    {
                                        string fixtablename = "QualitySheet_" + ds1.Tables[0].Rows[j]["Cell"].ToString() + "_" + spltpartno[k].ToString() + "_" + ds1.Tables[0].Rows[j]["Operation"].ToString() + "";
                                        SqlDataAdapter da2 = new SqlDataAdapter("select count(*)totoal from " + fixtablename + " where FixNo like '%" + ds.Tables[0].Rows[0]["FixName"].ToString() + "%'", strConnString);
                                        DataSet ds2 = new DataSet();
                                        ds2.Tables.Clear();
                                        ds2.Clear();
                                        ds2.Reset();
                                        da2.Fill(ds2);
                                        if (ds2.Tables[0].Rows.Count > 0)
                                        {
                                            if (ds2.Tables[0].Rows[0]["totoal"].ToString() != "0")
                                            {
                                                fixcount = fixcount + Convert.ToInt32(ds2.Tables[0].Rows[0]["totoal"].ToString());
                                            }
                                        }
                                    }
                                }
                                //if (Convert.ToInt32(fixcount) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Gfrom"].ToString()) && Convert.ToInt32(fixcount) <= Convert.ToInt32(ds.Tables[0].Rows[0]["Gto"].ToString()))
                                //{
                                //    setColorClass = "Green";
                                //    lbl_status.Text = "Fixture life at<br> usable condition";
                                //}
                                //if (Convert.ToInt32(fixcount) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Yfrom"].ToString()) && Convert.ToInt32(fixcount) <= Convert.ToInt32(ds.Tables[0].Rows[0]["Yto"].ToString()))
                                //{
                                //    setColorClass = "Yellow";
                                //    lbl_status.Text = "Alert for fixture Calibration<br>& Re order Zone";
                                //}
                                //if (Convert.ToInt32(fixcount) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Rfrom"].ToString()) && Convert.ToInt32(fixcount) <= Convert.ToInt32(ds.Tables[0].Rows[0]["Rto"].ToString()))
                                //{
                                //    setColorClass = "Red";
                                //    lbl_status.Text = "Fixture life Completed";
                                //}
                                //else
                                //{
                                //    if (Convert.ToInt32(fixcount) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Rto"].ToString()))
                                //    {
                                //        setColorClass = "Red";
                                //        lbl_status.Text = "Fixture life Completed";
                                //    }
                                //}
                                lbl_fixcount.Text = fixcount.ToString();
                            }
                            else
                            {
                                lbl_fixcount.Text = "0";
                            }
                            //cell.CssClass = setColorClass;
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
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please create Quality Sheet then allocate Fixture');", true);
            }
        }
    }
    private void PrepareGridViewForExport(Control gv)
    {
        Literal l = new Literal();
        string name = String.Empty;
        for (int i = 0; i < gv.Controls.Count; i++)
        {
            if (gv.Controls[i].GetType() == typeof(TextBox))
            {
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            if (gv.Controls[i].HasControls())
            {
                PrepareGridViewForExport(gv.Controls[i]);
            }
        }
    }
    protected void btn_pdf_Click(object sender, ImageClickEventArgs e)
    {
        lock (thisLock)
        {
            try
            {

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    GridView3.AllowPaging = false;
                    loadfixchange();
                    PrepareGridViewForExport(GridView3);
                    GridView3.HeaderRow.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in GridView3.HeaderRow.Cells)
                    {
                        cell.BackColor = GridView3.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in GridView3.Rows)
                    {
                        row.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = GridView3.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = GridView3.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    // GridView3.RenderControl(hw);
                    HtmlForm frm = new HtmlForm();
                    GridView3.Parent.Controls.Add(frm);
                    frm.Attributes["runat"] = "server";
                    frm.Controls.Add(GridView3);
                    frm.RenderControl(hw);
                    //style to format numbers to string
                    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }

    }





    protected void btn_print_Click(object sender, ImageClickEventArgs e)
    {
        lock (thisLock)
        {
            try
            {
                GridView3.AllowPaging = false;
                loadfixchange();
                string fileName = "ExportToPdf_" + DateTime.Now.ToShortDateString();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}",
                fileName + ".pdf"));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter objSW = new StringWriter();
                HtmlTextWriter objTW = new HtmlTextWriter(objSW);
                GridView3.HeaderRow.Style.Add("background-color", "#FFFFFF");
                //Applying stlye to gridview header cells
                for (int i = 0; i < GridView3.HeaderRow.Cells.Count; i++)
                {
                    GridView3.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
                    GridView3.HeaderRow.Cells[i].Style.Add("width", "500px;");
                }
                HtmlForm frm = new HtmlForm();
                GridView3.Parent.Controls.Add(frm);
                frm.Attributes["runat"] = "server";
                frm.Controls.Add(GridView3);
                frm.RenderControl(objTW);
                StringReader objSR = new StringReader(objSW.ToString());
                Document objPDF = new Document(PageSize.A4, 100f, 100f, 100f, 100f);
                HTMLWorker objHW = new HTMLWorker(objPDF);
                PdfWriter.GetInstance(objPDF, Response.OutputStream);
                objPDF.Open();
                objHW.Parse(objSR);
                objPDF.Close();
                Response.Write(objPDF);
                Response.End();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }

        }
    }
}


