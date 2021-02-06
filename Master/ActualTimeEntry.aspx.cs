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

public partial class Master_ActualTimeEntry : System.Web.UI.Page
{
    public Actual_PrdQty objact;
    public QualitySheetdclassDataContext objQualitySheetdclassDataContext;
    public DBServer objserver = new DBServer();
    public DataSet ds;
    public SqlDataAdapter da;
    public PagedDataSource paging = new PagedDataSource();
    public DataTable dt;
    public int cate_comp;
    public int findex, lindex, count = 0;
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "" && Session["PID_ID"] != null && Session["PID_ID"].ToString() != "")
            {
                BindPart();
                BindProcess();
                GetEntryTime();
                
            }
            else
            {
                Response.Redirect("~/Home.aspx");
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
    private void BindPart()
    {
        ds = objserver.GetDateset("select '-Select-' Partno,'-Select-' Partno union select distinct partno,Partno from tbl_PartNo order by 1 desc");
        ddl_partno.DataValueField = "Partno";
        ddl_partno.DataTextField = "Partno";
        ddl_partno.DataSource = ds.Tables[0];
        ddl_partno.DataBind();
    }
    private void BindProcess()
    {
        ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");

        ddl_process.DataSource = ds.Tables[0];

        ddl_process.DataValueField = "process";
        ddl_process.DataTextField = "process";
        ddl_process.DataBind();
    }
   
    public void GetEntryTime()
    {
            objact = new Actual_PrdQty();
            dt = new DataTable();
            objQualitySheetdclassDataContext = new QualitySheetdclassDataContext();

            //var query = (from c in (objQualitySheetdclassDataContext.CycleTimeEntries) select c).ToList();
            da = new SqlDataAdapter("select * from Actual_PrdQty", strConnString);
            ds = new DataSet();
            da.Fill(dt);
            da.Fill(ds);
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
                gridprdqty.DataSource = paging;
                gridprdqty.DataBind();
                div_actual.Visible = true;
                div_actualerror.Visible = false;
                createpaging();


            }
            else
            {
                div_actual.Visible = false;
                div_actualerror.Visible = true;
            }
        }
                      
                      
    

    protected void btn_submit_Click(object sender, ImageClickEventArgs e)
    {
        objact = new Actual_PrdQty();
        objQualitySheetdclassDataContext = new QualitySheetdclassDataContext();
        try
        {
            var query = (from table in objQualitySheetdclassDataContext.Actual_PrdQties where table.PartNo == ddl_partno.Value.ToString() && table.Process == ddl_process.Value.ToString() && table.Shift == ddl_shift.Value.ToString()  select table).ToList();
            if (query.Count > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Data Already Exist !');", true);
            }
            else
            {
                objact.PartNo = ddl_partno.Value.ToString();
                objact.Process = ddl_process.Value.ToString();
                objact.Shift = ddl_shift.Value.ToString();
                objact.FixedTime = Convert.ToDecimal(txt_fixedtime.Value.ToString());
               // objact.ProducedQty = Convert.ToDecimal(txt_prdquty.Value.ToString());
                objact.EntryTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                objQualitySheetdclassDataContext.Actual_PrdQties.InsertOnSubmit(objact);
                objQualitySheetdclassDataContext.SubmitChanges();
               // ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Datas Submitted Successfuly !');", true);
            }

        }
        catch (Exception ex)
        {
        }
        finally
        {
            BindPart();
            BindProcess();
            GetEntryTime();
            txt_fixedtime.Value = "";
            ddl_shift.Value = "0";
           // txt_prdquty.Value = "";
        }

    }
   
    protected void btn_update_Click1(object sender, ImageClickEventArgs e)
    {
        objQualitySheetdclassDataContext = new QualitySheetdclassDataContext();
        if (hdn_actualid.Value.ToString() != "")
        {
            int id = Convert.ToInt32(hdn_actualid.Value);
            var query = (from table in objQualitySheetdclassDataContext.Actual_PrdQties where table.AID == id select table).FirstOrDefault();
            if (query != null)
            {
                query.PartNo = ddl_partno.Value.ToString();
                query.Process = ddl_process.Value.ToString();
                query.Shift = ddl_shift.Value.ToString();
                query.FixedTime = Convert.ToDecimal(txt_fixedtime.Value.ToString());
                //query.ProducedQty= Convert.ToDecimal(txt_prdquty.Value.ToString());

            }
            objQualitySheetdclassDataContext.SubmitChanges();
           // div_save.Visible = true;
           // div_update.Visible = false;
            BindPart();
            BindProcess();
            GetEntryTime();
            txt_fixedtime.Value = "";
            ddl_shift.Value = "0";
           // txt_prdquty.Value = "";
           // ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Data Updated Successfully');", true);
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
           GetEntryTime();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
       GetEntryTime();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
       GetEntryTime();
    }
    //protected void gridprdqty_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (gridprdqty.Rows.Count > 0)
    //    {
    //        count += 1;
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {

             
    //            Label lbl_sno = e.Row.FindControl("lbl_sno") as Label;
    //            lbl_sno.Text = Convert.ToString(count.ToString());

    //        }
    //    }
    //    else
    //    {
    //        count = 0;
    //    }
    //}
}
