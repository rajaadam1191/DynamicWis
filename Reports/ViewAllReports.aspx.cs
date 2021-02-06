using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.DataVisualization.Charting;


public partial class Reports_ViewAllReports : System.Web.UI.Page
{
    private String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    public SqlConnection strConnString1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);

    public DBServer objserver = new DBServer();

    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public SqlCommand cmd;
    public DataSet ds;
    public SqlDataAdapter da;
    public static Object thisLock = new Object();
    public string strPath;
    public string partno, operation, fromdate, todate;
    public decimal CP;
    public decimal CPK;
    public decimal tolerance;
    public decimal points = 67;
    public decimal Standardeviation;
    public DataSet ds1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPart();
            BindProcess();
            txt_fromdate.Value = DateTime.Now.ToShortDateString().ToString();
            txt_todate.Value = DateTime.Now.ToShortDateString().ToString();
            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "")
            {
               // load_operator();
            }
            else
            {
                Response.Redirect("../Home.aspx");
            }
        }
    }
    private void BindPart()
    {
        lock (thisLock)
        {


try
        {
        ds = objserver.GetDateset("select '-Select-' Partno,'-Select-' Partno union select distinct partno,Partno from tbl_PartNo order by 1 desc");
        ddl_partno.DataValueField = "Partno";
        ddl_partno.DataTextField = "Partno";
        ddl_partno.DataSource = ds.Tables[0];
        ddl_partno.DataBind();
        }
catch (Exception ex)
{
    ExceptionLogging.SendExcepToDB(ex);

}
finally
{
    

}
        }
    }
    private void BindProcess()
    {
        lock (thisLock)
        {


            try
            {
        ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");

        ddl_process.DataSource = ds.Tables[0];

        ddl_process.DataValueField = "process";
        ddl_process.DataTextField = "process";
        ddl_process.DataBind();
        } catch (Exception ex)
        {
             ExceptionLogging.SendExcepToDB(ex); 
           
        }
finally
{


}
}
    }
    protected void onselectedindexchanged_allrpt(object sender, EventArgs e)
    {
         lock (thisLock)
        {


try
        {
        string unit = ddl_unit_QC_chart.Text.ToString();
        if (unit == "MBU")
        {
            ds = objserver.GetDateset("select '-Select-' MBU,'-Select-' MBU union select distinct MBU,MBU from Machine_rpt_tble order by 1 asc");

            Slct_machine_QC_chart.DataSource = ds.Tables[0];

            Slct_machine_QC_chart.DataValueField = "MBU";
            Slct_machine_QC_chart.DataTextField = "MBU";
            Slct_machine_QC_chart.DataBind();
        }
        else if (unit == "ABU")
        {
            ds = objserver.GetDateset("select '-Select-' ABU,'-Select-' ABU union select distinct ABU,ABU from Machine_rpt_tble order by 1 asc");

            Slct_machine_QC_chart.DataSource = ds.Tables[0];

            Slct_machine_QC_chart.DataValueField = "ABU";
            Slct_machine_QC_chart.DataTextField = "ABU";
            Slct_machine_QC_chart.DataBind();
        }
        else if (unit == "ALL")
        {
            ds = objserver.GetDateset("SELECT '-Select-' ALLRPT,'-Select-' ALLRPT union select distinct MBU,MBU  as ALLRPT FROM Machine_rpt_tble where MBU<>'' UNION ALL SELECT '-Select-' ALLRPT,'-Select-' ALLRPT  union select distinct ABU,ABU  as ALLRPT   FROM Machine_rpt_tble where ABU<>'' ");

            Slct_machine_QC_chart.DataSource = ds.Tables[0];

            Slct_machine_QC_chart.DataValueField = "ALLRPT";
            Slct_machine_QC_chart.DataTextField = "ALLRPT";
            Slct_machine_QC_chart.DataBind();
        }
        }
catch (Exception ex)
{
    ExceptionLogging.SendExcepToDB(ex);

}
finally
{
    

}
        }
         
    }
   

}

