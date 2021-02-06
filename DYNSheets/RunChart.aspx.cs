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
using System.Collections.Generic;
using System.Web.Services;
using System.IO;

public partial class DYNSheets_RunChart : System.Web.UI.Page
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
                try
                {
                    BindCell();
                    BindMachine();
                    BindPartNO();
                    BindOperation();
                    //txt_fromdate.Value = DateTime.Now.ToShortDateString().ToString();
                    //txt_todate.Value = DateTime.Now.ToShortDateString().ToString();
                    //loadvalues();
                    txt_fromdate.Value = Convert.ToDateTime(HttpContext.Current.Session["LogDate"].ToString()).ToString("dd/MM/yyyy");
                    txt_todate.Value = Convert.ToDateTime(HttpContext.Current.Session["LogDate"].ToString()).ToString("dd/MM/yyyy");


                    //string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);

                    //foreach (string filePath in Directory.GetFiles(tempPath, "*.*", SearchOption.AllDirectories))
                    //{
                    //    try
                    //    {
                    //        FileInfo currentFile = new FileInfo(filePath);
                    //        currentFile.Delete();
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        //Debug.WriteLine("Error on file: {0}\r\n   {1}", filePath, ex.Message);
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                }
                finally
                {
                }
            }
            else
            {
                HttpContext.Current.Response.Write("else part");
                Response.Redirect("../Home.aspx", false);
            }

        }
    }
    public class httpvalues
    {
        public string Operation { get; set; }
        public string Machine { get; set; }
        public string Shift { get; set; }
        public string Partno { get; set; }
        public string Cell { get; set; }
    }
    [WebMethod]
    private static httpvalues[] loaddatavalues()
    {
        List<httpvalues> obju = new List<httpvalues>();
        httpvalues obju1 = new httpvalues();
        obju1 = new httpvalues();
        obju1.Cell = HttpContext.Current.Session["Depart"].ToString();
        obju1.Machine = HttpContext.Current.Session["machine"].ToString();
        obju1.Partno = HttpContext.Current.Session["PartNo"].ToString();
        obju1.Operation = HttpContext.Current.Session["Operation"].ToString();
        obju1.Shift = HttpContext.Current.Session["Shift"].ToString();
        //txt_fromdate.Value = HttpContext.Current.Session["LogDate"].ToString();
        //txt_todate.Value = HttpContext.Current.Session["LogDate"].ToString();
        obju.Add(obju1);
        return obju.ToArray();
    }
    private void BindPartNO()
    {
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        ds = objserver.GetDateset("select '-Select-' PartNo union select distinct PartNo from tbl_PartNo order by PartNo asc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_partno.DataSource = ds.Tables[0];
            ddl_partno.DataValueField = "partNo";
            ddl_partno.DataTextField = "partNo";
            ddl_partno.DataBind();
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
}
