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


public partial class PlannedStopEntry : System.Web.UI.Page
{
    public PlaneedEntryDetail objplanned;
    public QualitySheetdclassDataContext objcontext;
    DBServer objserver = new DBServer();
    public SqlDataAdapter da;
    public PagedDataSource paging = new PagedDataSource();
    public DataTable dt;
    public int cate_comp;
    public int findex, lindex;
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString); 

    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadPartno();
            LoadProcess();
            Loadplan();

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
    public void LoadPartno()
    {
        ds = objserver.GetDateset("select '-Select-' partno,'-Select-' partno union select distinct partno,partno from tbl_PartNo order by 1 desc");


        ddl_partno.DataSource = ds.Tables[0];
        ddl_partno.DataValueField = "PartNo";
        ddl_partno.DataTextField = "PartNo";
        ddl_partno.DataBind();

    }
    public void LoadProcess()
    {
        ds = objserver.GetDateset("select '0' PID,'-Select-' Process union select distinct PID,Process from tbl_Process order by PID");
        ddl_process.DataValueField = "Process";
        ddl_process.DataTextField = "Process";
        ddl_process.DataSource = ds.Tables[0];
        ddl_process.DataBind();
    }
   
   
    public void Loadplan()
    {
        objplanned = new PlaneedEntryDetail();
        dt = new DataTable();
        objcontext = new QualitySheetdclassDataContext();

        //var query = (from c in (objQualitySheetdclassDataContext.CycleTimeEntries) select c).ToList();
        da = new SqlDataAdapter("select * from PlaneedEntryDetails", strConnString);
        ds = new DataSet();
        da.Fill(dt);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {

            paging.DataSource = dt.DefaultView;
            if (ds.Tables[0].Rows.Count > 5)
            {
                paging.AllowPaging = true;
                paging.PageSize = 5;
                paging.CurrentPageIndex = CurrentPage;
                ViewState["totalpage"] = paging.PageCount;
                link_previous.Enabled = !paging.IsFirstPage;
                link_next.Enabled = !paging.IsLastPage;
            }
            else
            {
                div_paging.Visible = false;
            }
            Grid_plan.DataSource = paging;
            Grid_plan.DataBind();
            div_planentry.Visible = true;
            div_actualerror.Visible = false;
            createpaging();


        }
        else
        {
            div_planentry.Visible = false;
            div_actualerror.Visible = true;
        }
    }


    public void clearcontrols()
    {
        LoadPartno();
        LoadProcess();
        txt_pmaintenance.Value = "";
        txt_cleaning.Value = "";
        txt_break.Value = "";
        txt_demand.Value= "";
        txt_trial.Value = "";
        txt_meetings.Value = "";
        txt_traings.Value = "";
        txt_planedmaintenance.Value = "";
    }
    protected void btn_update_Click(object sender, ImageClickEventArgs e)
    {
        objcontext = new QualitySheetdclassDataContext();
        if (hdn_planid.Value.ToString() != "")
        {
            int id = Convert.ToInt32(hdn_planid.Value);
            var query = (from table in objcontext.PlaneedEntryDetails where table.PNO == id select table).FirstOrDefault();
            if (query != null)
            {
                
                query.PartNo = ddl_partno.Value.ToString();
                query.Process = ddl_process.Value.ToString();
                query.Maintenace = txt_pmaintenance.Value.ToString();
                query.Cleaning = txt_cleaning.Value.ToString();
                query.Break = txt_break.Value.ToString();
                query.Noplan = txt_demand.Value.ToString();
                query.Trials = txt_trial.Value.ToString();
                query.Meetings = txt_meetings.Value.ToString();
                query.Trainings = txt_traings.Value.ToString();
                query.Planedmaintenance = txt_planedmaintenance.Value.ToString();

            }
            objcontext.SubmitChanges();
            Loadplan();
            clearcontrols();
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Data Updated Successfully');", true);
        }
    }
    //protected void OnSelectedIndexChanged_ddl_shift(object sender, EventArgs e)
    //{
    //    string shift11 = ddl_shift.Text.ToString();
    //    if(shift11=="A")
    //    {
    //        txt_shift.Value="6:00 AM to 2:00 PM";
    //    }
    //    if (shift11 == "B")
    //    {
    //        txt_shift.Value = "2:00 PM to 10:00 PM";

    //    }
    //    if (shift11 == "C")
    //    {
    //        txt_shift.Value = "10:00 PM to 6:00 AM";

    //    }
    //      if (shift11 == "A1")
    //      {
    //          txt_shift.Value = "6:00 AM to 6:00 PM";

    //      }
    //      if (shift11 == "B1")
    //      {
    //          txt_shift.Value = "6:00 PM to 6:00 AM";
    //      }
    //}

    protected void btn_submit_Click(object sender, ImageClickEventArgs e)
    {
        objplanned = new PlaneedEntryDetail();
        objcontext = new QualitySheetdclassDataContext();
        try
        {
            ds = objserver.GetDateset("select * from PlaneedEntryDetails where PartNo='" + ddl_partno.Value.ToString() + "' and Process='" + ddl_process.Value.ToString() + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //var query = (from table in objcontext.PlaneedEntryDetails where table.PartNo == ddl_partno.Value.ToString() select table).FirstOrDefault();
                //if (query != null)
                //{
                //    query.PartNo = ddl_partno.Value.ToString();
                //    query.Process = ddl_process.Value.ToString();
                //    query.Setup = txt_fixed_data.Value.ToString();
                //    query.LunchTime = txt_lunchtime.Value.ToString();
                //    query.TeaTime = txt_teatime.Value.ToString();
                //    //query.ShiftTime = txt_shift.Value.ToString();
                //    query.PlanTime = txt_plan.Value.ToString();
                //    query.Maintenance = txt_maintenance.Value.ToString();
                //    query.Manufacturing = txt_manuf.Value.ToString();
                //    query.Meeting = txt_meeting.Value.ToString();
                //  //  query.Shift = ddl_shift.Text.ToString();
                //    objcontext.SubmitChanges();
                //    clearcontrols();
                //    Loadplan();
                //}
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Data Already Exist !');", true);
            }
            else
            {
                objplanned.PartNo = ddl_partno.Value.ToString();
                objplanned.Process = ddl_process.Value.ToString();

                objplanned.Maintenace = txt_pmaintenance.Value.ToString();
                objplanned.Cleaning = txt_cleaning.Value.ToString();
                objplanned.Break = txt_break.Value.ToString();
                objplanned.Noplan = txt_demand.Value.ToString();
                objplanned.Trials = txt_trial.Value.ToString();
                objplanned.Meetings = txt_meetings.Value.ToString();
                objplanned.Trainings = txt_traings.Value.ToString();
                objplanned.Planedmaintenance = txt_planedmaintenance.Value.ToString();
                objcontext.PlaneedEntryDetails.InsertOnSubmit(objplanned);
                objcontext.SubmitChanges();

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Data Submitted Successfuly !');", true);
                clearcontrols();
                Loadplan();
            }

        }
        catch (Exception ex)
        {
        }
        finally
        {

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
           Loadplan();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
       Loadplan();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
       Loadplan();
    }
}
