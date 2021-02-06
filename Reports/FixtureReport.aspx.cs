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

public partial class FixtureReport : System.Web.UI.Page
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
            populateyear();
            BindFixtureNumber();
            //loadfixchange();
        }
    }
    private void BindFixtureNumber()
    {
        lock (thisLock)
        {

            try
            {
                ds = objserver.GetDateset("select '0' Fid,'--- Select Fixture Number ---' FixtureName union select distinct a.Fid,a.Fixturename from FixtureName a inner join dbo.FixtureValues b on a.Fid=b.Fixid ");
                ddl_fixno.DataSource = ds.Tables[0];

                ddl_fixno.DataValueField = "Fixturename";
                //ddl_fixno.DataValueField = "Fixturename";
                ddl_fixno.DataTextField = "Fixturename";
                ddl_fixno.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }
    protected void OnDataBound(object sender, EventArgs e)
    {
        lock (thisLock)
        {

            try
            {
                if (grid_fixture.Rows.Count > 0)
                {
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                    for (int i = 0; i < grid_fixture.Columns.Count - 1; i++)
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        TextBox txtSearch = new TextBox();
                        txtSearch.Attributes["placeholder"] = "Search";
                        txtSearch.CssClass = "search_textbox";
                        cell.Controls.Add(txtSearch);
                        row.Controls.Add(cell);
                    }
                    grid_fixture.HeaderRow.Parent.Controls.AddAt(1, row);
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }

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
    public void loadgridview()
    {
        da = new SqlDataAdapter("select * from FixtureStatus", strConnString);
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grid_fixture.DataSource = ds;
            grid_fixture.DataBind();
        }
        else
        {
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
            getgriddata();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        getgriddata();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        getgriddata();
    }
    protected void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        getfixhistgrid();
        //getgriddata();
        BindFixtureNumber();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">one();</script>");
       
    }
    public void getgriddata()
    {
        string Part = "", Fix = "", Oper = "", Mach = "";
        string partno = hdn_part.Value.ToString();
        string fixno = hdn_fix.Value.ToString();
        string oper = hdn_op.Value.ToString();
        string mach = hdn_mach.Value.ToString();
        lock (thisLock)
        {

            try
            {
                if (partno == "ALL")
                {
                    string part1 = "";
                    SqlDataAdapter da = new SqlDataAdapter("select distinct PartNo from tbl_PartNo", strConnString);
                    DataSet ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();

                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            part1 += "," + "'" + ds.Tables[0].Rows[i]["PartNo"].ToString() + "'";
                        }
                        Part = "Partno in(" + part1.Remove(0, 1).ToString() + ")";
                    }

                }
                else
                {
                    Part = "Partno in('" + partno.ToString() + "')";
                }
                if (fixno == "ALL")
                {
                    if (partno == "ALL")
                    {
                        string fix = "";
                        SqlDataAdapter da = new SqlDataAdapter("select distinct Fixturename from FixtureName", strConnString);
                        DataSet ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                fix += "," + "'" + ds.Tables[0].Rows[i]["Fixturename"].ToString() + "'";
                            }
                            Fix = "Fixtureno in(" + fix.Remove(0, 1).ToString() + ")";
                        }

                    }
                    else
                    {
                        string fix1 = "";
                        SqlDataAdapter da = new SqlDataAdapter("select distinct Fixturename from FixtureName where Partnumber='" + partno + "'", strConnString);
                        DataSet ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                fix1 += "," + "'" + ds.Tables[0].Rows[i]["Fixturename"].ToString() + "'";
                            }
                            Fix = "Fixtureno in(" + fix1.Remove(0, 1).ToString() + ")";
                        }

                    }
                }
                else
                {
                    Fix = "Fixtureno in('" + fixno + "')";
                }
                if (oper == "ALL")
                {
                    Oper = "and Operation in ('1','2')";
                }
                else
                {
                    Oper = "and Operation in('" + oper.ToString() + "')";
                }
                if (mach == "ALL")
                {
                    string mach1 = "";
                    SqlDataAdapter da = new SqlDataAdapter("select distinct Valve from Unit_table", strConnString);
                    DataSet ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            mach1 += "," + "'" + ds.Tables[0].Rows[i]["Valve"].ToString() + "'";
                        }
                        Mach = "and Machine in(" + mach1.Remove(0, 1).ToString() + ")";
                    }

                }
                else
                {
                    Mach = "and Machine in('" + mach.ToString() + "')";
                }

                //string query = "select * from FixtureStatus where " + Part + Fix + Oper + Mach;
                string query = "select * from FixtureStatus where " + Fix + Oper + Mach;
                SqlDataAdapter da1 = new SqlDataAdapter(query, strConnString);
                DataSet ds1 = new DataSet();
                DataTable dt = new DataTable();
                da1.Fill(ds1);
                da1.Fill(dt);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    div_pdf.Visible = true;
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
                    GridView1.DataSource = paging;
                    GridView1.DataBind();
                    //  div_actual.Visible = true;
                    //  div_actualerror.Visible = false;
                    createpaging();
                }
                else
                {
                    DataSet ds2 = objserver.GetDateset("select Partno ='',Operation='',Fixtureno='',YellowOpenDate='',YellowCloseDate='',RedOpenDate='',YellowStatus=''");
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = ds2;
                        GridView1.DataBind();
                        GridView1.Rows[0].Visible = false;
                        div_paging.Visible = false;


                    }

                }
                ddl_operation.Value = "0";
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }

    }

    public void getfixhistgrid()
    {
                string partno = hdn_part.Value.ToString();
        string fixno = hdn_fix.Value.ToString();
        string oper = hdn_op.Value.ToString();
        string mach = hdn_mach.Value.ToString();
        string query = "select ROW_NUMBER() over (order by b.FID desc) as IndexNo,* from FixtureValues a Left join FixtureName b on a.FixName =b.Fixturename Left join SpareMastermbu c ON b.FID =c.ToolNumber where a.FixName='" + fixno.ToString() + "' and a.Operation='" + oper.ToString() + "' and b.Line='" + mach.ToString() + "' ";
        SqlDataAdapter da1 = new SqlDataAdapter(query, strConnString);
        DataSet ds1 = new DataSet();
        DataTable dt = new DataTable();
        da1.Fill(ds1);
        da1.Fill(dt);
        lock (thisLock)
        {

            try
            {
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
                    grid_fixture.DataSource = paging;
                    grid_fixture.DataBind();
                    //  div_actual.Visible = true;
                    //  div_actualerror.Visible = false;
                    createpaging();
                }
                else
                {
                    grid_fixture.DataSource = null;
                    grid_fixture.DataBind();
                    div_paging.Visible = false;
                }
                ddl_operation.Value = "0";
                div_pdf.Visible = false;

                da = new SqlDataAdapter("select * from Feedback where Fixno like '%" + fixno.ToString() + "%' and Machine='" + mach.ToString() + "' ", strConnString);
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
                    GridView2.DataSource = paging;
                    GridView2.DataBind();
                    spn_toolf.Visible = true;
                }
                else
                {
                    spn_toolf.Visible = false;
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
                if (grid_fixture.DataSource == null && GridView2.DataSource == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not Found');", true);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }

    }
    protected void grid_fixture_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        lock (thisLock)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label ID = e.Row.FindControl("lbl_id") as Label;
                    System.Web.UI.WebControls.Image image = e.Row.FindControl("ph_image") as System.Web.UI.WebControls.Image;
                    //Image ph_drawing = e.Row.FindControl("ph_drawing") as Image;
                    Label lbl_status = e.Row.FindControl("lbl_status") as Label;
                    Label lbl_remarks = e.Row.FindControl("lbl_remarks") as Label;
                    Label lbl_life = e.Row.FindControl("lbl_life") as Label;
                    Label lbl_fixcount = e.Row.FindControl("lbl_fixcount") as Label;
                    Label lbl_modify = e.Row.FindControl("lbl_modify") as Label;
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
                            if (ds.Tables[0].Rows[0]["Fixtureclose"].ToString() == "Yes")
                            {
                                lbl_remarks.Text = "Fixture Life Completed";
                            }
                            else if (ds.Tables[0].Rows[0]["Fixtureclose"].ToString() == "No")
                            {
                                lbl_remarks.Text = "Life Extended";
                            }
                            else
                            {
                                lbl_remarks.Text = "";
                                lbl_modify.Text = "";
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
    [WebMethod]
    public void loadfixchange()
    {
        string query = "select ROW_NUMBER() over (order by b.FID desc) as IndexNo,min(a.Fid) as Fid,min(a.FixName) as FixName,min(b.Partnumber) as Partno,min(a.FixLife) as FixLife,min(a.Operation) as Operation,min(a.Gfrom) as Gfrom,min(a.Gto) as Gto,min(a.Yfrom) as Yfrom,min(a.Yto) as Yto,min(a.Rfrom) as Rfrom,min(a.Rto) as Rto,min(a.Creationdata) as Creationdata,min(a.Status) as Status,min(a.Flag) as Flag,min(a.GreenRange) as GreenRange,min(a.YellowRange) as YellowRange,min(a.RedRange) as RedRange,min(a.GreenRange1) as GreenRange1,min(a.YellowRange1) as YellowRange1,min(a.RedRange1) as RedRange1,min(a.Availability) as Availability,min(a.Imagefile) as Imagefile,min(a.Drawing) as Drawing,min(ModifyDate) as ModifyDate,min(b.Fixturename) as Fixturename,min(b.Model) as Model,isnull(sum(cast(c.TotalCount as int)),0) as currentstock,min(d.GreenOpenDate) as issueon from FixtureValues a inner join FixtureName b on a.FixName =b.Fixturename Left join SpareMastermbu c ON b.FID =c.ToolNumber  Left join FixtureStatus d on b.Fixturename=d.Fixtureno where a.Status='Inactive' group by b.FID";
        SqlDataAdapter da1 = new SqlDataAdapter(query, strConnString);
        DataSet ds1 = new DataSet();
        DataTable dt = new DataTable();
        da1.Fill(ds1);
        da1.Fill(dt);
        lock (thisLock)
        {

            try
            {
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
                    grid_fixture.AllowPaging = false;
                    getgriddata();
                    PrepareGridViewForExport(grid_fixture);
                    grid_fixture.HeaderRow.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in grid_fixture.HeaderRow.Cells)
                    {
                        cell.BackColor = grid_fixture.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in grid_fixture.Rows)
                    {
                        row.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = grid_fixture.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = grid_fixture.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    // grid_fixture.RenderControl(hw);
                    HtmlForm frm = new HtmlForm();
                    grid_fixture.Parent.Controls.Add(frm);
                    frm.Attributes["runat"] = "server";
                    frm.Controls.Add(grid_fixture);
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
    public void populateyear()
    {
        int _currentyear;
        const int _year = 1990;
        _currentyear = DateTime.Now.Year;
        ddl_year.Items.Add("--- Select Year ---");
        for (int s = 0; s <= 50; s++)
        {

            ddl_year.Items.Add((_currentyear - s).ToString());
        }
        ddl_year.DataBind();
    }
    private void LoadChartData(DataTable initialDataSource)
    {
        for (int i = 1; i < initialDataSource.Columns.Count; i++)
        {
            Series series = new Series();
            foreach (DataRow dr in initialDataSource.Rows)
            {
                int y = (int)dr[i];
                series.Points.AddXY(dr["Partno"].ToString(), y);
            }
            chart_calibration.Series.Add(series);
        }
        chart_calibration.ChartAreas["ChartArea1"].AxisY.Maximum = 100;
        chart_calibration.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
        chart_calibration.ChartAreas["ChartArea1"].AxisY.Interval = 5;
    }
    private DataTable GetData()
    {
        string Part = "", Fix = "", Oper = "", Mach = "", Year = "", Month = "", Month1 = "";
        string Part11 = "", Fix1 = "", Oper1 = "", Mach1 = "";
        string partno = hdn_part1.Value.ToString();
        string fixno = hdn_fix1.Value.ToString();
        string oper = hdn_op1.Value.ToString();
        string mach = hdn_mach1.Value.ToString();
        string year = hdn_year.Value.ToString();
        string month = hdn_month.Value.ToString();
        DataTable dt = new DataTable();
        lock (thisLock)
        {

            try
            {
                if (partno == "ALL")
                {
                    string part1 = "";
                    SqlDataAdapter da = new SqlDataAdapter("select distinct PartNo from tbl_PartNo", strConnString);
                    DataSet ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            part1 += "," + "'" + ds.Tables[0].Rows[i]["PartNo"].ToString() + "'";
                            Part11 += "," + ds.Tables[0].Rows[i]["PartNo"].ToString();
                        }
                        Part = "Partno in(" + part1.Remove(0, 1).ToString() + ")";
                    }

                }
                else
                {
                    Part = "Partno in('" + partno.ToString() + "')";
                }
                if (fixno == "ALL")
                {
                    if (partno == "ALL")
                    {
                        string fix = "";
                        SqlDataAdapter da = new SqlDataAdapter("select distinct Fixturename from FixtureName", strConnString);
                        DataSet ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                fix += "," + "'" + ds.Tables[0].Rows[i]["Fixturename"].ToString() + "'";
                            }
                            Fix = "and Fixtureno in(" + fix.Remove(0, 1).ToString() + ")";
                        }

                    }
                    else
                    {
                        string fix1 = "";
                        SqlDataAdapter da = new SqlDataAdapter("select distinct Fixturename from FixtureName where Partnumber='" + partno + "'", strConnString);
                        DataSet ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                fix1 += "," + "'" + ds.Tables[0].Rows[i]["Fixturename"].ToString() + "'";
                            }
                            Fix = "and Fixtureno in(" + fix1.Remove(0, 1).ToString() + ")";
                        }

                    }
                }
                else
                {
                    Fix = "and Fixtureno in('" + fixno + "')";
                }
                if (oper == "ALL")
                {
                    Oper = "and Operation in ('1','2')";
                }
                else
                {
                    Oper = "and Operation in('" + oper.ToString() + "')";
                }
                if (mach == "ALL")
                {
                    string mach1 = "";
                    SqlDataAdapter da = new SqlDataAdapter("select distinct Valve from Unit_table", strConnString);
                    DataSet ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            mach1 += "," + "'" + ds.Tables[0].Rows[i]["Valve"].ToString() + "'";
                        }
                        Mach = "and Machine in(" + mach1.Remove(0, 1).ToString() + ")";
                    }

                }
                else
                {
                    Mach = "and Machine in('" + mach.ToString() + "')";
                }

                //  Year = "and Year ='"+  year.ToString()+"'";
                //  Month = "and Month ='" + month.ToString() + "'";
                string tblcontent = "";
                Year = year.ToString();
                Month = month.ToString();
                string mon = "";
                string mfrom = "", mto = "";
                if (ddl_month.Value.ToString() != "0")
                {
                    mfrom = ddl_month.Value.ToString();
                }
                if (ddl_monthto.Value.ToString() != "0")
                {
                    mto = ddl_monthto.Value.ToString();
                }
                for (int i = Convert.ToInt32(mfrom); i <= Convert.ToInt32(mto); i++)
                {
                    mon += "," + "'" + i.ToString() + "'";
                }
                Month = "and Month in(" + mon.Remove(0, 1).ToString() + ")";
                Month1 = "and Y_Month in(" + mon.Remove(0, 1).ToString() + ")";
                //DataTable dt = new DataTable();
                dt.Columns.Add("Partno", Type.GetType("System.String"));
                dt.Columns.Add("Alert", Type.GetType("System.Int32"));
                dt.Columns.Add("Calibrate", Type.GetType("System.Int32"));
                dt.Columns.Add("Replaced", Type.GetType("System.Int32"));
                if (partno == "ALL")
                {
                    PartNo = Regex.Split(Part11, ",");

                    for (int i = 0; i < PartNo.Length; i++)
                    {
                        if (PartNo[i].ToString() == "")
                        {
                        }
                        else
                        {
                            //string query = "select * from FixtureStatus where " + Part + Fix + Oper + Mach + Year + Month;
                            string query = "select * from FixtureStatus where Partno='" + PartNo[i].ToString() + "' and Operation='" + oper + "' and Fixtureno='" + fixno + "'" + Month + " and Year='" + Year.ToString() + "' and Machine='" + mach + "';select count(YellowOpenDate)as Alert from FixtureStatus where Partno='" + PartNo[i].ToString() + "' and Operation='" + oper + "' and Fixtureno='" + fixno + "'" + Month1 + " and Year='" + Year.ToString() + "' and Machine='" + mach + "';select count(YellowCloseDate)as Calibrate from FixtureStatus where Partno='" + PartNo[i].ToString() + "' and Operation='" + oper + "' and Fixtureno='" + fixno + "' " + Month1 + " and Y_Year='" + Year.ToString() + "' and Machine='" + mach + "';select count(*) as LifeExtented from dbo.FixtureValues where status='Inactive' and Fixtureclose='No' and FixName='" + fixno.ToString() + "' ";
                            // string query = "select count(OpenDate)as Alert from FixtureOpen where Partno='" + PartNo[i].ToString() + "' and Operation='" + oper + "' and Fixtureno='" + fixno + "' and Month='" + Month.ToString() + "' and Year='" + Year.ToString() + "' and Status='Yellow';select count(CloseDate)as Calibrate from FixtureClose where Partno='" + PartNo[i].ToString() + "' and Operation='" + oper + "' and Fixtureno='" + fixno + "' and Month='" + Month.ToString() + "' and Year='" + Year.ToString() + "' and Status='Yellow'";
                            SqlDataAdapter da1 = new SqlDataAdapter(query, strConnString);
                            DataSet ds1 = new DataSet();
                            ds1.Tables.Clear();
                            ds1.Clear();
                            ds1.Reset();
                            da1.Fill(ds1);

                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = dt.NewRow();
                                dr["Partno"] = PartNo[i].ToString();
                                if (ds1.Tables[1].Rows[0]["Alert"] != null && ds1.Tables[1].Rows[0]["Alert"].ToString() != "0")
                                {
                                    dr["Alert"] = Convert.ToInt32(ds1.Tables[1].Rows[0]["Alert"].ToString());
                                }
                                else
                                {
                                    dr["Alert"] = Convert.ToInt32("0");
                                }
                                if (ds1.Tables[2].Rows[0]["Calibrate"] != null && ds1.Tables[2].Rows[0]["Calibrate"].ToString() != "0")
                                {
                                    dr["Calibrate"] = Convert.ToInt32(ds1.Tables[2].Rows[0]["Calibrate"].ToString());
                                }
                                else
                                {
                                    dr["Calibrate"] = Convert.ToInt32("0");
                                }
                                if (ds1.Tables[3].Rows[0]["LifeExtented"] != null && ds1.Tables[3].Rows[0]["LifeExtented"].ToString() != "")
                                {
                                    dr["Replaced"] = Convert.ToInt32(ds1.Tables[3].Rows[0]["LifeExtented"].ToString());
                                }
                                else
                                {
                                    dr["Replaced"] = Convert.ToInt32("0");
                                }
                                // dr["Replaced"] = 0;
                                dt.Rows.Add(dr);
                                tblcontent += "," + PartNo[i].ToString();

                                //DataRow dr2 = dt.NewRow();
                                //dr2["Partno"] = "A17724J";
                                //dr2["Alert"] = 62;
                                //dr2["Calibrate"] = 10;
                                //dr2["Replaced"] = 89;
                                //dt.Rows.Add(dr2);
                                //DataRow dr3 = dt.NewRow();
                                //dr3["Partno"] = "A17724U";
                                //dr3["Alert"] = 19;
                                //dr3["Calibrate"] = 23;
                                //dr3["Replaced"] = 78;
                                //dt.Rows.Add(dr3);

                            }

                        }
                    }

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">showtablecontent('" + tblcontent + "','" + oper + "','" + fixno + "','" + Month + "','" + Year + "','" + mach + "');two();</script>");
                }
                else
                {
                    string query = "select * from FixtureStatus where Partno='" + partno.ToString() + "' and Operation='" + oper + "' and Fixtureno='" + fixno + "' " + Month.ToString() + " and Year='" + Year.ToString() + "' and Machine='" + mach + "';select count(YellowOpenDate)as Alert from FixtureStatus where Partno='" + partno.ToString() + "' and Operation='" + oper + "' and Fixtureno='" + fixno + "'" + Month1.ToString() + " and Year='" + Year.ToString() + "'  and Machine='" + mach + "';select count(YellowCloseDate)as Calibrate from FixtureStatus where Partno='" + partno.ToString() + "' and Operation='" + oper + "' and Fixtureno='" + fixno + "'" + Month1.ToString() + " and Y_Year='" + Year.ToString() + "' and Machine='" + mach + "';select count(*) as LifeExtented from dbo.FixtureValues where status='Inactive' and Fixtureclose='No' and FixName='" + fixno.ToString() + "'";
                    SqlDataAdapter da2 = new SqlDataAdapter(query, strConnString);
                    DataSet ds2 = new DataSet();
                    ds2.Tables.Clear();
                    ds2.Clear();
                    ds2.Reset();
                    da2.Fill(ds2);

                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["Partno"] = partno.ToString();
                        if (ds2.Tables[1].Rows[0]["Alert"] != null && ds2.Tables[1].Rows[0]["Alert"].ToString() != "")
                        {
                            dr["Alert"] = Convert.ToInt32(ds2.Tables[1].Rows[0]["Alert"].ToString());
                        }
                        else
                        {
                            dr["Alert"] = Convert.ToInt32("0");
                        }
                        if (ds2.Tables[2].Rows[0]["Calibrate"] != null && ds2.Tables[2].Rows[0]["Calibrate"].ToString() != "")
                        {
                            dr["Calibrate"] = Convert.ToInt32(ds2.Tables[2].Rows[0]["Calibrate"].ToString());
                        }
                        else
                        {
                            dr["Calibrate"] = Convert.ToInt32("0");
                        }
                        if (ds2.Tables[3].Rows[0]["LifeExtented"] != null && ds2.Tables[3].Rows[0]["LifeExtented"].ToString() != "")
                        {
                            dr["Replaced"] = Convert.ToInt32(ds2.Tables[3].Rows[0]["LifeExtented"].ToString());
                        }
                        else
                        {
                            dr["Replaced"] = Convert.ToInt32("0");
                        }
                        //dr["Replaced"] = 0;
                        dt.Rows.Add(dr);
                        tblcontent += "," + partno.ToString();

                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">showtablecontent('" + tblcontent + "','" + oper + "','" + fixno + "','" + Month + "','" + Year + "','" + mach + "');two();</script>");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }

            return dt;
        }

    }
    protected void btn_calibrate_Click(object sender, ImageClickEventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptsKey", "<script type=\"text/JavaScript\" language=\"javascript\">two();</script>");
        DataTable dt = GetData();
        if (dt.Rows.Count > 0)
        {
            LoadChartData(dt);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not Found');", true);
        }

    }
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)    
    {
        lock (thisLock)
        {

            try
            {

                // Response.Clear();
                // Response.Buffer = true;
                // Response.AddHeader("content-disposition", "attachment;filename=ChartExport.xls");
                // Response.ContentType = "application/vnd.ms-excel";
                // Response.Charset = "";
                // StringWriter sw = new StringWriter();
                // HtmlTextWriter hw = new HtmlTextWriter(sw);
                // DataTable dt = GetData();
                // chart_calibration.RenderControl(hw);

                // string tmpChartName = "ChartImage.jpg";

                // string imgPath = HttpContext.Current.Request.PhysicalApplicationPath + tmpChartName;

                // chart_calibration.SaveImage(imgPath);

                //// string img = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/" + tmpChartName);
                //  string src = Regex.Match(sw.ToString(), "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase).Groups[1].Value;
                //  string img = string.Format("<img src = '{0}{1}' />", Request.Url.GetLeftPart(UriPartial.Authority), src);

                // System.Web.UI.WebControls.Table table = new System.Web.UI.WebControls.Table();
                // TableRow row = new TableRow();
                // row.Cells.Add(new TableCell());
                // row.Cells[0].Width = 200;
                // row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                // row.Cells[0].Controls.Add(new Label { Text = "Fruits Distribution (India)", ForeColor = System.Drawing.Color.Red });
                // table.Rows.Add(row);
                // row = new TableRow();
                // row.Cells.Add(new TableCell());
                // row.Cells[0].Controls.Add(new Literal { Text = img });
                // table.Rows.Add(row);

                // sw = new StringWriter();
                // hw = new HtmlTextWriter(sw);
                // table.RenderControl(hw);
                // Response.Write(sw.ToString());
                // Response.Flush();
                // Response.End();

                string tmpChartName = "test2.jpg";
                string imgPath = HttpContext.Current.Request.PhysicalApplicationPath + "TempChartImages\\" + tmpChartName;

                chart_calibration.SaveImage(imgPath, ChartImageFormat.Jpeg);
                string imgPath2 = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/TempChartImages/" + tmpChartName);

                Response.Clear();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment; filename=test.xls;");
                StringWriter stringWrite = new StringWriter();
                HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                string headerTable = @"<Table><tr><td><img src='" + imgPath2 + @"' \></td></tr></Table>";
                Response.Write(headerTable);
                Response.Write(stringWrite.ToString());
                Response.End();
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

                grid_fixture.AllowPaging = false;
                getgriddata();
                string fileName = "ExportToPdf_" + DateTime.Now.ToShortDateString();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}",
                fileName + ".pdf"));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter objSW = new StringWriter();
                HtmlTextWriter objTW = new HtmlTextWriter(objSW);
                grid_fixture.HeaderRow.Style.Add("background-color", "#FFFFFF");
                //Applying stlye to gridview header cells
                for (int i = 0; i < grid_fixture.HeaderRow.Cells.Count; i++)
                {
                    grid_fixture.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
                    grid_fixture.HeaderRow.Cells[i].Style.Add("width", "500px;");
                }
                HtmlForm frm = new HtmlForm();
                grid_fixture.Parent.Controls.Add(frm);
                frm.Attributes["runat"] = "server";
                frm.Controls.Add(grid_fixture);
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
