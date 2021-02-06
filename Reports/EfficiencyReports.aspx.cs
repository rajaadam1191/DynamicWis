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

public partial class EfficiencyReports : System.Web.UI.Page
{
    private String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    DBServer objserver = new DBServer();
    DataSet ds;
    public static Object thisLock = new Object();
    public string partno, operation, fromdate, todate, Type, shift;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPartNO();
            BindOperation();
            if (Request.QueryString["Type"] != null && Request.QueryString["Type"].ToString() != "-Select-")
            {
                Type = Request.QueryString["Type"].ToString();
                ddl_type.Value = Type;
            }
            else
            {
                ddl_type.Value = "0";

            }
            if (Request.QueryString["Partno"] != null && Request.QueryString["Partno"].ToString() != "-Select-")
            {
                partno = Request.QueryString["Partno"].ToString();
                ddl_partno.Value = partno;
            }
            else
            {
                partno = Request.QueryString["Partno"].ToString();
                ddl_partno.Value = "0";

            }
            if (Request.QueryString["Operation"] != null && Request.QueryString["Operation"].ToString() != "-Select-")
            {
                operation = Request.QueryString["Operation"].ToString();
                ddl_operation.Value = operation;
            }
            else
            {
                operation = Request.QueryString["Operation"].ToString();
                ddl_operation.Value = "0";

            }
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"].ToString() != "")
            {
                fromdate = Request.QueryString["fromdate"].ToString();
                txt_fromdate.Value = fromdate;
            }
            else
            {
                fromdate = Request.QueryString["fromdate"].ToString();
                txt_fromdate.Value = DateTime.Now.ToShortDateString().ToString();

            }
            if (Request.QueryString["todate"] != null && Request.QueryString["todate"].ToString() != "")
            {
                todate = Request.QueryString["todate"].ToString();
                txt_todate.Value = todate;
            }
            else
            {
                todate = Request.QueryString["todate"].ToString();
                txt_todate.Value = DateTime.Now.ToShortDateString().ToString();

            }
            if (Request.QueryString["Shift"] != null && Request.QueryString["Shift"].ToString() != "-Select-")
            {
               shift = Request.QueryString["Shift"].ToString();
                ddl_shift.Value = shift;
            }
            else
            {
                ddl_shift.Value = "0";

            }
            showpageloadresult(partno, operation, fromdate, todate, shift);

        }
    }
    private void BindPartNO()
    {
        lock (thisLock)
        {
            try
            {
                ds = objserver.GetDateset("select '-Select-' partno,'-Select-' partno union select distinct partno,partno from tbl_PartNo order by 1 desc");


                ddl_partno.DataSource = ds.Tables[0];
                ddl_partno.DataValueField = "PartNo";
                ddl_partno.DataTextField = "PartNo";
                ddl_partno.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }


    }
    private void BindOperation()
    {
        lock (thisLock)
        {
            try
            {
                ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");

                ddl_operation.DataSource = ds.Tables[0];
                ddl_operation.DataValueField = "Process";
                ddl_operation.DataTextField = "Process";
                ddl_operation.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }

    }
    public void showpageloadresult(string partno, string operation, string fromdate, string todate, string shift)
    {
        lock (thisLock)
        {
            try
            {
                DBServer db = new DBServer();
                DataSet ds = new DataSet();
                ds = db.viewpageloadresulteffiency(partno, operation, fromdate, todate, shift);
                ReportDataSource rds = new ReportDataSource("DataSet1_EfficiencyReports", ds.Tables[0]);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LocalReport lr = null;
                    DataSet ds1 = new DataSet();
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    lr = ReportViewer1.LocalReport;
                    lr.ReportPath = "Reports/Efficiency.rdlc";

                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    ReportViewer1.LocalReport.Refresh();

                }
                else
                {
                    LocalReport lr = null;
                    lr = ReportViewer1.LocalReport;
                    lr.ReportPath = "Reports/Efficiency.rdlc";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    ReportViewer1.LocalReport.Refresh();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }
    //public void get_Reports()
    //{
    //    ds = objserver.GetDateset("select * from EfficiencyReports");
    //    ReportDataSource rds = new ReportDataSource("DataSet1_EfficiencyReports", ds.Tables[0]);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        LocalReport lr = null;
    //        DataSet ds1 = new DataSet();
    //        ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //        lr = ReportViewer1.LocalReport;
    //        lr.ReportPath = "Reports/Efficiency.rdlc";

    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(rds);
    //        ReportViewer1.LocalReport.Refresh();

    //    }
    //    else
    //    {
    //        LocalReport lr = null;
    //        lr = ReportViewer1.LocalReport;
    //        lr.ReportPath = "Reports/Efficiency.rdlc";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);
    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(rds);
    //        ReportViewer1.LocalReport.Refresh();
    //    }
    //}
    //public void Showdatewise()
    //{
    //    DBServer db = new DBServer();
    //    DataSet ds = new DataSet();
    //    DateTime dt = Convert.ToDateTime(txt_from_date.Value);
    //    db.fromdate = txt_from_date.Value;
    //    db.todate = txt_to_date.Value;
    //    ds = db.ViewAllEfficiencyReportsdatetime(db);
    //    ReportDataSource rds = new ReportDataSource("DataSet1_EfficiencyReports", ds.Tables[0]);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        LocalReport lr = null;
    //        DataSet ds1 = new DataSet();
    //        ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //        lr = ReportViewer1.LocalReport;
    //        lr.ReportPath = "Reports/Efficiency.rdlc";
            
    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(rds);
    //        ReportViewer1.LocalReport.Refresh();
    //    }
    //    else
    //    {
    //        LocalReport lr = null;
    //        lr = ReportViewer1.LocalReport;
    //        lr.ReportPath = "Reports/Efficiency.rdlc";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);
    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(rds);
    //        ReportViewer1.LocalReport.Refresh();
    //    }
    //}
    ////protected void btn_datewise_Click(object sender, EventArgs e)
    ////{
    ////    Showdatewise();
    ////}
    ////protected void btn_viewall_Click(object sender, EventArgs e)
    ////{
    ////    get_Reports();
    ////}
    //protected void img_results_Click(object sender, ImageClickEventArgs e)
    //{
    //    DBServer db = new DBServer();
    //    DataSet ds = new DataSet();
    //    ds = db.ViewAllEfficiency(ddl_partno.Value.ToString(), ddl_operation.Value.ToString(), txt_from_date.Value.ToString(), txt_to_date.Value.ToString());
    //    ReportDataSource rds = new ReportDataSource("DataSet1_EfficiencyReports", ds.Tables[0]);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        LocalReport lr = null;
    //        DataSet ds1 = new DataSet();
    //        ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //        lr = ReportViewer1.LocalReport;
    //        lr.ReportPath = "Reports/Efficiency.rdlc";

    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(rds);
    //        ReportViewer1.LocalReport.Refresh();
    //    }
    //    else
    //    {
    //        LocalReport lr = null;
    //        lr = ReportViewer1.LocalReport;
    //        lr.ReportPath = "Reports/Efficiency.rdlc";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);
    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(rds);
    //        ReportViewer1.LocalReport.Refresh();
    //    }
    //}

    protected void img_view_Click(object sender, ImageClickEventArgs e)
    {
        string partno, operation, type, fromdate, todate, shift;
        partno = ddl_partno.Value.ToString();
        operation = ddl_operation.Value.ToString();
        type = ddl_type.Value.ToString();
        fromdate = txt_fromdate.Value.ToString();
        todate = txt_todate.Value.ToString();
        shift = ddl_shift.Value.ToString();
        lock (thisLock)
        {
            try
            {
                if (type == "1")
                {
                    Response.Redirect("DMTRptFrm.aspx?Type=" + type + "&Partno=" + partno + "&Operation=" + operation + "&fromdate=" + fromdate + "&todate=" + todate + "&Shift=" + shift);
                }
                if (type == "2")
                {
                    DBServer db = new DBServer();
                    DataSet ds = new DataSet();
                    ds = db.viewpageloadresulteffiency(partno, operation, fromdate, todate, shift);
                    ReportDataSource rds = new ReportDataSource("DataSet1_EfficiencyReports", ds.Tables[0]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        LocalReport lr = null;
                        DataSet ds1 = new DataSet();
                        ReportViewer1.ProcessingMode = ProcessingMode.Local;
                        lr = ReportViewer1.LocalReport;
                        lr.ReportPath = "Reports/Efficiency.rdlc";

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(rds);
                        ReportViewer1.LocalReport.Refresh();

                    }
                    else
                    {
                        LocalReport lr = null;
                        lr = ReportViewer1.LocalReport;
                        lr.ReportPath = "Reports/Efficiency.rdlc";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(rds);
                        ReportViewer1.LocalReport.Refresh();
                    }
                }



            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            if (type == "3")
            {
                Response.Redirect("~/QualityGrid/ViewQChart.aspx?Type=" + type + "&Partno=" + partno + "&Operation=" + operation + "&fromdate=" + fromdate + "&todate=" + todate + "&Shift=" + shift);
            }
        }
    }




}