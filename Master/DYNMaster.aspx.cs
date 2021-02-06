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

using System.Data.OleDb;

public partial class Master_DYNMaster : System.Web.UI.Page
{
    public static SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ToString();

    public QualitySheetdclassDataContext objcontext = new QualitySheetdclassDataContext();
    public Dynmaster objm = new Dynmaster();
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand cmd = new SqlCommand();
    public DBServer objserver = new DBServer();
    public int findex, lindex, count = 0;
    public PagedDataSource paging = new PagedDataSource();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "" && Session["PID_ID"] != null && Session["PID_ID"].ToString() != "")
            {
                loadpartno();
                //BindDummyRow();
                getgrid();
                ////if (hdn_srchpart.Value.ToString().Trim() != "--- Select Part Number ---" && hdn_srchpart.Value.ToString().Trim() != "")
                //if (Session["srchpartno"] != null && Session["srchpartno"].ToString() != "")
                //{
                //    ddl_partnosrch.SelectedValue = hdn_srchpart.Value.ToString().Trim();
                //    //ddl_partnosrch.Value = hdn_srchpart.Value.ToString().Trim();
                //    loadpartgrid();
                //}
                //else
                //{
                //    getgrid();
                //}
                
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "getpart()", true);
             //   div_paging.Visible = false;
                
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
        }
    }
    public void loadpartno()
    {
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            SqlDataAdapter da = new SqlDataAdapter("select '--- Select Part Number ---' PartNo union select distinct PartNo from tbl_PartNo", strConnString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_partnosrch.DataSource = ds.Tables[0];
                ddl_partnosrch.DataValueField = "PartNo";
                ddl_partnosrch.DataTextField = "PartNo";
                ddl_partnosrch.DataBind();
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
    protected void ddl_partnosrch_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadpartgrid();
    }
    public void loadpartgrid()
    {
        if (ddl_partnosrch.SelectedValue.ToString() != "--- Select Part Number ---")
        //if (ddl_partnosrch.Value.ToString() != "--- Select Part Number ---")
        {
            grd_dynmaster.DataSource = null;
            grd_dynmaster.DataBind();
            da = new SqlDataAdapter("select ROW_NUMBER() over (order by DID) as IndexNo,* from Dynmaster where Partno='" + ddl_partnosrch.SelectedValue.ToString() + "'", strConnString);
            //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + ddl_partnosrch.Value.ToString() + "'", strConnString);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds);
            da.Fill(dt);

            if (ds.Tables[0].Rows.Count > 0)
            {
                div_paging.Visible = false;
                paging.AllowPaging = true;
                paging.DataSource = dt.DefaultView;
                if (ds.Tables[0].Rows.Count > 10)
                {

                    paging.PageSize = 10;
                    paging.CurrentPageIndex = CurrentPage;
                    ViewState["totalpage"] = paging.PageCount;
                    link_previous.Enabled = !paging.IsFirstPage;
                    link_next.Enabled = !paging.IsLastPage;
                    div_paging.Visible = true;
                    // div_pdf.Visible = true;
                }
                else
                {
                    div_paging.Visible = false;
                }
                grd_dynmaster.DataSource = paging;
                grd_dynmaster.DataBind();
                //  div_actual.Visible = true;
                //  div_actualerror.Visible = false;
                createpaging();
            }
            else
            {
                //DataSet ds2 = objserver.GetDateset("select DID ='',Partno='',Operation='',Unit='',Cell='',Instrument='',Int_count='',Int_range=''");
                //if (ds2.Tables[0].Rows.Count > 0)
                //{
                //    grd_dynmaster.DataSource = ds2;
                //    grd_dynmaster.DataBind();
                //    grd_dynmaster.Rows[0].Visible = false;
                //    div_paging.Visible = false;


                //}
                grd_dynmaster.DataSource = null;
                grd_dynmaster.DataBind();
                div_paging.Visible = false;
            }
        }
    }
    public void getgrid()
    {
        da = new SqlDataAdapter("select ROW_NUMBER() over (order by DID) as IndexNo,* from Dynmaster", strConnString);
        ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds);
        da.Fill(dt);
        if (ds.Tables[0].Rows.Count > 0)
        {
            div_paging.Visible = false;
            paging.AllowPaging = true;
            paging.DataSource = dt.DefaultView;
            if (ds.Tables[0].Rows.Count > 10)
            {

                paging.PageSize = 10;
                paging.CurrentPageIndex = CurrentPage;
                ViewState["totalpage"] = paging.PageCount;
                link_previous.Enabled = !paging.IsFirstPage;
                link_next.Enabled = !paging.IsLastPage;
                div_paging.Visible = true;
                // div_pdf.Visible = true;
            }
            else
            {
                div_paging.Visible = false;
            }
            grd_dynmaster.DataSource = paging;
            grd_dynmaster.DataBind();
            //  div_actual.Visible = true;
            //  div_actualerror.Visible = false;
            createpaging();
        }
        else
        {
            //DataSet ds2 = objserver.GetDateset("select DID ='',Partno='',Operation='',Unit='',Cell='',Instrument='',Int_count='',Int_range=''");
            //if (ds2.Tables[0].Rows.Count > 0)
            //{
            //    grd_dynmaster.DataSource = ds2;
            //    grd_dynmaster.DataBind();
            //    grd_dynmaster.Rows[0].Visible = false;
            //    div_paging.Visible = false;


            //}

            grd_dynmaster.DataSource = null;
            grd_dynmaster.DataBind();
            div_paging.Visible = false;

        }
    }
    protected void btn_save_Click(object sender, ImageClickEventArgs e)
    {
       
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
    private void createpaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");
        findex = CurrentPage - 5;
        if (CurrentPage >= 10)
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
    protected void DataListPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("newpage"))
        {
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            if (ddl_partnosrch.SelectedValue.ToString() != "--- Select Part Number ---")
            //if (ddl_partnosrch.Value.ToString() != "--- Select Part Number ---")
            {
                loadpartgrid();
            }
            else
            {
                getgrid();
            }
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        if (ddl_partnosrch.SelectedValue.ToString() != "--- Select Part Number ---")
        //if (ddl_partnosrch.Value.ToString() != "--- Select Part Number ---")
        {
            loadpartgrid();
        }
        else
        {
            getgrid();
        }
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        if (ddl_partnosrch.SelectedValue.ToString() != "--- Select Part Number ---")
        //if (ddl_partnosrch.Value.ToString() != "--- Select Part Number ---")
        {
            loadpartgrid();
        }
        else
        {
            getgrid();
        }
    }
    protected void btnview_Click(object sender, ImageClickEventArgs e)
    {
        getgrid();
        loadpartno();
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        loadpartgrid();
    }
    protected void btnsave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //string runchart = string.Empty;
            //if (RunChart. == "Yes")
            //{
            //    //if (txt_ucl.Value != "0" && txt_lcl.Value != "0" && txt_ucl.Value != "" && txt_lcl.Value != "")
            //    //{
            //        runchart = "Yes";
            //    //}
            //    //else
            //    //{
            //    //    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Enter the UCL and LCL !');", true);
            //    //}
            //}
            //else if (RunChart.SelectedValue == "No")
            //{
            //    runchart = "No";
            //    //txt_ucl.Value = "0";
            //    //txt_lcl.Value = "0";
            //}

            objm = new Dynmaster();
            objcontext = new QualitySheetdclassDataContext();
            objm.Partno = hdn_part.Value.ToString().Trim();
            objm.Unit = dy_unit.Value.ToString().Trim();
            objm.Cell = hdncell.Value.ToString().Trim();
            objm.Instrument = dy_intrument.Value.ToString().Trim();
            objm.Int_count = dy_instruvalues.Value.ToString().Trim();
            objm.Int_range = hdn_ranges.Value.ToString().Trim(); //dy_ranges.Value.ToString().Trim();
            objm.Operation = hdn_oper.Value.ToString().Trim(); //dy_operation.Value.ToString().Trim();
            objm.ShortName = txt_shortname.Value.ToString().Trim();
            objm.CellValues = hdn_noofcell.Value.ToString().Trim(); //txt_noofcells.Value.ToString().Trim();
            objm.HeaderName = Txt_headername.Value.ToString().Trim();
            objm.Runchart = slt_runchart.Value.ToString().Trim();
            objm.UCL = Convert.ToDecimal(0);
            objm.LCL = Convert.ToDecimal(0);
            dy_intrument.Value = "";
            dy_instruvalues.Value = "";
            dy_ranges.Value = "0";
            objcontext.Dynmasters.InsertOnSubmit(objm);  //mid object name is same as table name
            objcontext.SubmitChanges();
            getgrid();
            hdn_ranges.Value = "0";
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
    protected void grd_dynmaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl_header = e.Row.FindControl("lbl_header") as Label;
            string header = DataBinder.Eval(e.Row.DataItem, "HeaderName").ToString();
            if (header.Length > 15)
            {
                lbl_header.Text = header.Substring(0, 10) + "...";
            }
            else
            {
                lbl_header.Text = header.ToString();
            }
        }
    }
    //protected void RunChart_CheckedChanged(Object sender, EventArgs e)
    //{
    //    if (RunChart.SelectedValue == "Yes")
    //    {
    //        runval.Visible = true;
    //    }

    //    if (RunChart.SelectedValue == "No")
    //    {
    //        runval.Visible = false;
    //    }
    //}

    //[WebMethod]
    //public static string getfullgrid()
    //{
    //    string query = "SELECT ROW_NUMBER() OVER(ORDER BY [DID] desc)AS RowNumber,* from Dynmaster";
    //    SqlCommand cmd = new SqlCommand(query);
    //    DataSet ds = new DataSet();
    //    string strConnString1 = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    //    SqlConnection con = new SqlConnection(strConnString1);
    //    SqlDataAdapter sda = new SqlDataAdapter(query, strConnString1);
    //    cmd.Connection = con;
    //    sda.SelectCommand = cmd;
    //    sda.Fill(ds);
    //    return ds.GetXml();
    //}
    //private static DataSet GetData(SqlCommand cmd)
    //{
    //    string strConnString1 = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    //    using (SqlConnection con = new SqlConnection(strConnString1))
    //    {
    //        using (SqlDataAdapter sda = new SqlDataAdapter())
    //        {
    //            cmd.Connection = con;
    //            sda.SelectCommand = cmd;
    //            using (DataSet ds = new DataSet())
    //            {
    //                sda.Fill(ds);
    //                return ds;

    //            }
    //        }
    //    }
    //}
    //private void BindDummyRow()
    //{
    //    DataTable dummy = new DataTable();
    //    dummy.Columns.Add("Partno");
    //    dummy.Columns.Add("Operation");
    //    dummy.Columns.Add("Unit");
    //    dummy.Columns.Add("HeaderName");
    //    dummy.Columns.Add("Cell");
    //    dummy.Columns.Add("Instrument");
    //    dummy.Columns.Add("ShortName");
    //    dummy.Columns.Add("Int_count");
    //    dummy.Columns.Add("CellValues");
    //    dummy.Columns.Add("Int_range");
    //    dummy.Columns.Add("Runchart");
    //    dummy.Columns.Add("DID");
    //    dummy.Rows.Add();
    //    grd_dynmaster.DataSource = dummy;
    //    grd_dynmaster.DataBind();
    //}

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //string runchart = string.Empty;
            //if (RunChart. == "Yes")
            //{
            //    //if (txt_ucl.Value != "0" && txt_lcl.Value != "0" && txt_ucl.Value != "" && txt_lcl.Value != "")
            //    //{
            //        runchart = "Yes";
            //    //}
            //    //else
            //    //{
            //    //    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Enter the UCL and LCL !');", true);
            //    //}
            //}
            //else if (RunChart.SelectedValue == "No")
            //{
            //    runchart = "No";
            //    //txt_ucl.Value = "0";
            //    //txt_lcl.Value = "0";
            //}
            var query = (from table in objcontext.Dynmasters where table.DID == Convert.ToInt32(hdn_dyid.Value.ToString()) select table).First();
            if (query != null)
            {
                query.Partno = hdn_part.Value.ToString().Trim();
                query.Unit = dy_unit.Value.ToString().Trim();
                query.Cell = hdncell.Value.ToString().Trim();
                if (dy_intrument.Value.ToString().Trim() != "")
                {
                    query.Instrument = dy_intrument.Value.ToString().Trim();
                }
                else
                {
                    query.Instrument = hdn_instname.Value.ToString().Trim();
                }
                if (dy_instruvalues.Value.ToString().Trim() != "")
                {
                    query.Int_count = dy_instruvalues.Value.ToString().Trim();
                }
                else
                {
                    query.Int_count = hdn_instvalues.Value.ToString().Trim();
                }
                
                query.Int_range = hdn_ranges.Value.ToString().Trim(); //dy_ranges.Value.ToString().Trim();
                query.Operation = hdn_oper.Value.ToString().Trim(); //dy_operation.Value.ToString().Trim();
                query.ShortName = txt_shortname.Value.ToString().Trim();
                query.CellValues = hdn_noofcell.Value.ToString().Trim(); //txt_noofcells.Value.ToString().Trim();
                query.HeaderName = Txt_headername.Value.ToString().Trim();
                query.Runchart = slt_runchart.Value.ToString().Trim();
                query.UCL = Convert.ToDecimal(0);
                query.LCL = Convert.ToDecimal(0);
                objcontext.SubmitChanges();
                
                objcontext = new QualitySheetdclassDataContext();
                //var query1 = (from table in objcontext.DynmasterValues where table.DynRefid == hdn_dyid.Value.ToString() select table).FirstOrDefault();
                //if (query1 != null)
                //{
                //    query1.Partno = hdn_part.Value.ToString().Trim();
                //    query1.Unit = dy_unit.Value.ToString().Trim();
                //    query1.Cell = hdncell.Value.ToString().Trim();
                //    query1.Instrument = dy_intrument.Value.ToString().Trim();
                //    query1.Int_count = dy_instruvalues.Value.ToString().Trim();
                //    query1.Int_Frequency = hdn_ranges.Value.ToString().Trim(); //dy_ranges.Value.ToString().Trim();
                //    query1.Operation = hdn_oper.Value.ToString().Trim();
                //    objcontext.SubmitChanges();
                //}

                foreach (var query1 in objcontext.DynmasterValues.Where(table => table.DynRefid == hdn_dyid.Value.ToString()).ToList())
                {
                    query1.Partno = hdn_part.Value.ToString().Trim();
                    query1.Unit = dy_unit.Value.ToString().Trim();
                    query1.Cell = hdncell.Value.ToString().Trim();
                    //query1.Instrument = dy_intrument.Value.ToString().Trim();
                    //query1.Int_count = dy_instruvalues.Value.ToString().Trim();
                    if (dy_intrument.Value.ToString().Trim() != "")
                    {
                        query1.Instrument = dy_intrument.Value.ToString().Trim();
                    }
                    else
                    {
                        query1.Instrument = hdn_instname.Value.ToString().Trim();
                    }
                    if (dy_instruvalues.Value.ToString().Trim() != "")
                    {
                        query1.Int_count = dy_instruvalues.Value.ToString().Trim();
                    }
                    else
                    {
                        query1.Int_count = hdn_instvalues.Value.ToString().Trim();
                    }
                    query1.Int_Frequency = hdn_ranges.Value.ToString().Trim(); //dy_ranges.Value.ToString().Trim();
                    query1.Operation = hdn_oper.Value.ToString().Trim();
                }
                objcontext.SubmitChanges();

                cleardyn();
            }
            if (ddl_partnosrch.SelectedValue.ToString() != "--- Select Part Number ---")
            //if (ddl_partnosrch.Value.ToString() != "--- Select Part Number ---")
            {
                loadpartgrid();
            }
            else
            {
                getgrid();
            }
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        }
        finally
        {

        }
    }
    private void cleardyn()
    {
        hdn_noofcell.Value = "0";
        hdn_part.Value = "0";
        dy_unit.Value = "0";
        hdncell.Value = "0";
        dy_intrument.Value = "";
        hdn_instname.Value = "";
        dy_instruvalues.Value = "0";
        hdn_instvalues.Value = "0";
        hdncell.Value = "0";
        hdn_ranges.Value = "0";
        hdn_oper.Value = "0";
        txt_shortname.Value = "";
        txt_noofcells.Value = "";
        Txt_headername.Value = "";
        slt_runchart.Value = "0";
        dy_intrument.Attributes.Remove("readonly");
        dy_instruvalues.Attributes.Remove("readonly");
    }
    //protected void btnDel_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        int id = Convert.ToInt32(grd_dynmaster.Rows[e.RowIndex].Cells[14].Text);
    //        var query = (from table in objcontext.Dynmasters where table.DID == id select table).FirstOrDefault();
    //        objcontext.Dynmasters.DeleteOnSubmit(query);
    //        objcontext.SubmitChanges();

    //        var query1 = (from table in objcontext.DynmasterValues where table.DynRefid == id.ToString() select table).FirstOrDefault();
    //        if (query1 != null)
    //        {
    //            objcontext.DynmasterValues.DeleteOnSubmit(query1);
    //            objcontext.SubmitChanges();
    //        }
    //        if (ddl_partnosrch.SelectedValue.ToString() != "--- Select Part Number ---")
    //        //if (ddl_partnosrch.Value.ToString() != "--- Select Part Number ---")
    //        {
    //            loadpartgrid();
    //        }
    //        else
    //        {
    //            getgrid();
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    finally
    //    {

    //    }
    //}

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //Label usernamelable = (Label)row.FindControl("lbl_did");
            //string username = usernamelable.Text;
            Label lbl_id = grd_dynmaster.Rows[e.RowIndex].FindControl("lbl_did") as Label;

            //string ee = grd_dynmaster.DataKeys[e.RowIndex].Values["Runchart"].ToString();
            int id = Convert.ToInt32(lbl_id.Text);
            var query = (from table in objcontext.Dynmasters where table.DID == id select table).FirstOrDefault();
            objcontext.Dynmasters.DeleteOnSubmit(query);
            objcontext.SubmitChanges();

            //var query1 = (from table in objcontext.DynmasterValues where table.DynRefid == id.ToString() select table).FirstOrDefault();
            //if (query1 != null)
            //{
            //    objcontext.DynmasterValues.DeleteOnSubmit(query1);
            //    objcontext.SubmitChanges();
            //}

            foreach (var query1 in objcontext.DynmasterValues.Where(table => table.DynRefid == id.ToString()).ToList())
            {
                objcontext.DynmasterValues.DeleteOnSubmit(query1);
            }
            objcontext.SubmitChanges();

            if (ddl_partnosrch.SelectedValue.ToString() != "--- Select Part Number ---")
            //if (ddl_partnosrch.Value.ToString() != "--- Select Part Number ---")
            {
                loadpartgrid();
            }
            else
            {
                getgrid();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Deleted Successfully');", true);
            cleardyn();
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
 }
