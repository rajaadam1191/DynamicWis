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
using System.Web.UI.DataVisualization.Charting;

public partial class DYNSheets_SpcChart : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public SqlCommand cmd;
    public DataSet ds;
    public SqlDataAdapter da;
    public DataSet ds1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "")
            {
                BindCell();
                BindMachine();
                BindPartNO();
                BindOperation();
                BindSize();
                //txt_fromdate.Value = DateTime.Now.ToShortDateString().ToString();
                //txt_todate.Value = DateTime.Now.ToShortDateString().ToString();
                txt_fromdate.Value = Convert.ToDateTime(HttpContext.Current.Session["LogDate"].ToString()).ToString("MM/dd/yyyy");
                txt_todate.Value = Convert.ToDateTime(HttpContext.Current.Session["LogDate"].ToString()).ToString("MM/dd/yyyy");
            }
            else
            {
                Response.Redirect("../Home.aspx");
            }

        }
    }
    private void BindCell()
    {
        //ds = objserver.GetDateset("select '-Select-' partno,'-Select-' partno union select distinct partno,partno from tbl_PartNo order by 1 asc");
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        ds = objserver.GetDateset("select 0 Id ,'-Select-' Cell union select distinct Id,Cell from Cell order by Id asc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_cell.DataSource = ds.Tables[0];
            ddl_cell.DataValueField = "Cell";
            ddl_cell.DataTextField = "Cell";
            ddl_cell.DataBind();
        }
    }
    private void BindMachine()
    {
        //ds = objserver.GetDateset("select '-Select-' partno,'-Select-' partno union select distinct partno,partno from tbl_PartNo order by 1 asc");
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        ds = objserver.GetDateset("select 0 Id ,'-Select-' Machine union select distinct Id,Machine from Machine order by Id asc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            Slct_machine_QC_chart.DataSource = ds.Tables[0];
            Slct_machine_QC_chart.DataValueField = "Machine";
            Slct_machine_QC_chart.DataTextField = "Machine";
            Slct_machine_QC_chart.DataBind();
        }
    }
    private void BindPartNO()
    {
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        ds = objserver.GetDateset("select '-Select-' PartNo union select distinct PartNo from tbl_PartNo order by PartNo asc");
        ddl_partno.DataSource = ds.Tables[0];
        ddl_partno.DataValueField = "PartNo";
        ddl_partno.DataTextField = "PartNo";
        ddl_partno.DataBind();

    }
    private void BindOperation()
    {
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();

        ds = objserver.GetDateset("select 0 PID ,'-Select-' Process union select distinct PID,Process from tbl_Process order by PID asc");

        ddl_operation.DataSource = ds.Tables[0];
        ddl_operation.DataValueField = "Process";
        ddl_operation.DataTextField = "Process";
        ddl_operation.DataBind();

    }
    private void BindSize()
    {
        ds = objserver.GetDateset("select 0 SID ,'-Select-' SampleSize union select distinct SID,convert(varchar(max),SampleSize) from SPCValues order by SID asc");

        ddl_ssize.DataSource = ds.Tables[0];
        ddl_ssize.DataValueField = "SampleSize";
        ddl_ssize.DataTextField = "SampleSize";
        ddl_ssize.DataBind();

    }
}
