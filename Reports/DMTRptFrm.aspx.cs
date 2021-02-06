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



public partial class DMTRptFrm : System.Web.UI.Page
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
            BindProcess();
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
                ddl_partno.Value ="0";

            }
            if (Request.QueryString["Operation"] != null && Request.QueryString["Operation"].ToString() != "-Select-")
            {
                operation = Request.QueryString["Operation"].ToString();
                ddl_process.Value = operation;
            }
            else
            {
                operation = Request.QueryString["Operation"].ToString();
                ddl_process.Value = "0";

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
            showPageloadResult(partno, operation, fromdate, todate);
            
          // BindAllDmt();
           
            //ViewAllDMTDetails();
         //=DateTime.Now.ToShortDateString();
         //   DateTime.Now.ToShortDateString();
           
        }

    }


    //private void BindAllDmt()
    //{
    //    ds = objserver.GetDateset("select doc_ref,Rev,Businessunit,parttype,operation,specificpartorcommon,typeofdocument,creationdate,revisiondate,status,comments,functioninchargeoffilling ,paperfilling ,durationoffilling ,storageplacefilling ,electronicsfilling ,methodoffilling ,protectagainstwaterfilling  ,funinchargeof ,paper ,electronics ,durationofarchiving ,archivingplace ,authorized ,notauthorized ,functioninchargeofdestruction ,methodOfDestruction  from dbo.DMT_Template");
    //    ReportDataSource rds = new ReportDataSource("DataSet1_DMT_Template", ds.Tables[0]);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        LocalReport lr = null;
    //        DataSet ds1 = new DataSet();
    //        // ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //        lr = ReportViewer1.LocalReport;
    //        lr.ReportPath = "Reports/DmtReports.rdlc";
    //        //lr.DataSources.Add(new ReportDataSource("ViewDMTTemplate", ds.Tables[0]));

    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(rds);
    //        ReportViewer1.LocalReport.Refresh();



    //    }
    //    else
    //    {
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);
    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(rds);
    //        ReportViewer1.LocalReport.Refresh();
    //    }



    //}
    //private void ViewDMTDetailsbyDateWise()
    //{
    //    ds = objserver.GetDateset("select doc_ref,Rev,Businessunit,parttype,operation,specificpartorcommon,typeofdocument,creationdate,revisiondate,status,comments,functioninchargeoffilling ,paperfilling ,durationoffilling ,storageplacefilling ,electronicsfilling ,methodoffilling ,protectagainstwaterfilling  ,funinchargeof ,paper ,electronics ,durationofarchiving ,archivingplace ,authorized ,notauthorized ,functioninchargeofdestruction ,methodOfDestruction  from dbo.DMT_Template where creationdate between fromdate=@fromdate and todate=@todate and revisiondate between fromdate=@fromdate and todate=@todate");
    //    ReportDataSource rds = new ReportDataSource("DataSet1_DMT_Template", ds.Tables[0]);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        LocalReport lr = null;
    //        DataSet ds1 = new DataSet();
    //        // ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //        lr = ReportViewer1.LocalReport;
    //        lr.ReportPath = "Reports/DmtReports.rdlc";
    //        //lr.DataSources.Add(new ReportDataSource("ViewDMTTemplate", ds.Tables[0]));
            
    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(rds);
    //        ReportViewer1.LocalReport.Refresh();




    //    }
    //    else
    //    {
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);
    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(rds);
    //        ReportViewer1.LocalReport.Refresh();
    //    }
    //}
    //private void ViewDMTDetailsbyPartNO()
    //{
    //    try
    //    {
    //        DBServer db = new DBServer();
    //        db.PartNo = DropPartNo.Text;
    //        ds = db.ViewAllDMTTemplateByPartNO(db);

    //        //  ds = objserver.GetDateset("select doc_ref,Rev,businessunit,parttype,operation,specificpartorcommon,typeofdocument,creationdate,revisiondate,status,comments,functioninchargeoffilling ,paperfilling ,durationoffilling ,storageplacefilling ,electronicsfilling ,methodoffilling ,protectagainstwaterfilling  ,funinchargeof ,paper ,electronics ,durationofarchiving ,archivingplace ,authorized ,notauthorized ,functioninchargeofdestruction ,methodOfDestruction  from dbo.DMT_Template where specificpartorcommon=" + Convert.ToString(this.DropPartNo.Text) + "");
    //        ReportDataSource rds = new ReportDataSource("DataSet1_DMT_Template", ds.Tables[0]);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            LocalReport lr = null;
    //            DataSet ds1 = new DataSet();
    //            ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //            lr = ReportViewer1.LocalReport;
    //            lr.ReportPath = "Reports/DmtReports.rdlc";
    //            //lr.DataSources.Add(new ReportDataSource("ViewAllDMTDetailbyPartNo", ds.Tables[0]));
                
    //            ReportViewer1.LocalReport.DataSources.Clear();
    //            ReportViewer1.LocalReport.DataSources.Add(rds);
    //            ReportViewer1.LocalReport.Refresh();

    //        }
    //        else
    //        {

    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);
    //            ReportViewer1.LocalReport.DataSources.Clear();
    //            ReportViewer1.LocalReport.DataSources.Add(rds);
    //            ReportViewer1.LocalReport.Refresh();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Label3.Text = ex.Message;
    //        if (Label3.Text != "An invalid parameter or option was specified for procedure 'No already Exists'.")
    //        {

    //            Label3.Text = "Record Not Found";
    //        }
    //    }
        

    //}
    //private void ViewAllDMTDetails()
    //{
    //    try
    //    {
    //        DBServer db = new DBServer();
    //        ds = db.ViewDMTTemplate1(db);

    //        //  ds = objserver.GetDateset("select doc_ref,Rev,businessunit,parttype,operation,specificpartorcommon,typeofdocument,creationdate,revisiondate,status,comments,functioninchargeoffilling ,paperfilling ,durationoffilling ,storageplacefilling ,electronicsfilling ,methodoffilling ,protectagainstwaterfilling  ,funinchargeof ,paper ,electronics ,durationofarchiving ,archivingplace ,authorized ,notauthorized ,functioninchargeofdestruction ,methodOfDestruction  from dbo.DMT_Template where specificpartorcommon=" + Convert.ToString(this.DropPartNo.Text) + "");
    //        ReportDataSource rds = new ReportDataSource("DataSet1_DMT_Template", ds.Tables[0]);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            LocalReport lr = null;
    //            DataSet ds1 = new DataSet();
    //            ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //            lr = ReportViewer1.LocalReport;
    //            lr.ReportPath = "Reports/DmtReports.rdlc";
    //            //lr.DataSources.Add(new ReportDataSource("ViewDMTTemplate", ds.Tables[0]));
                
    //            ReportViewer1.LocalReport.DataSources.Clear();
    //            ReportViewer1.LocalReport.DataSources.Add(rds);
    //            ReportViewer1.LocalReport.Refresh();

    //        }
    //        else
    //        {

    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);
    //            ReportViewer1.LocalReport.DataSources.Clear();
    //            ReportViewer1.LocalReport.DataSources.Add(rds);
    //            ReportViewer1.LocalReport.Refresh();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Label3.Text = ex.Message;
    //        if (Label3.Text != "An invalid parameter or option was specified for procedure 'No already Exists'.")
    //        {

    //            Label3.Text = "Record Not Found";
    //        }
    //    }


    //}
    private void BindPartNO()
    {
        lock (thisLock)
        {
            try
            {
                ds = objserver.GetDateset("select '-Select-' partno,'-Select-' partno union select distinct partno,partno from tbl_PartNo order by 1 desc");

                ddl_partno.DataSource = ds.Tables[0];

                ddl_partno.DataValueField = "partno";
                ddl_partno.DataTextField = "partno";
                ddl_partno.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

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
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }
    //protected void DropPartNo_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ViewDMTDetailsbyPartNO();
    //}
    //protected void DropPartNo_TextChanged(object sender, EventArgs e)
    //{
    //    ViewDMTDetailsbyPartNO();

    //}
    //private void ViewDMTDetailsbyProcess()
    //{

    //    DBServer db = new DBServer();
    //    db.Process = DropProcess.Text;
    //    db.PartNo = DropPartNo.Text;
    //    ds = db.ViewAllDMTTemplateByProcess(db);
    //    //ds = objserver.GetDateset("select doc_ref,Rev,businessunit,parttype,operation,specificpartorcommon,typeofdocument,creationdate,revisiondate,status,comments,functioninchargeoffilling ,paperfilling ,durationoffilling ,storageplacefilling ,electronicsfilling ,methodoffilling ,protectagainstwaterfilling  ,funinchargeof ,paper ,electronics ,durationofarchiving ,archivingplace ,authorized ,notauthorized ,functioninchargeofdestruction ,methodOfDestruction  from dbo.DMT_Template where specificpartorcommon=" + Convert.ToString(this.DropProcess.Text) + "");
    //    ReportDataSource rds = new ReportDataSource("DataSet1_DMT_Template", ds.Tables[0]);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        LocalReport lr = null;
    //        DataSet ds1 = new DataSet();
    //        ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //        lr = ReportViewer1.LocalReport;
    //        lr.ReportPath = "Reports/DmtReports.rdlc";
    //        //lr.DataSources.Add(new ReportDataSource("ViewDMTTemplate", ds.Tables[0]));
            
    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(rds);
    //        ReportViewer1.LocalReport.Refresh();

    //    }
    //    else
    //    {
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);
    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(rds);
    //        ReportViewer1.LocalReport.Refresh();

    //    }
    //}
    //protected void DropProcess_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ViewDMTDetailsbyProcess();
    //}
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    ViewDMTDetailsbyProcess();
      
    //}
    //protected void DropPartNo_Unload(object sender, EventArgs e)
    //{

    //}
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    ViewDMTDetailsbyPartNO();
    //}
    //protected void Button3_Click(object sender, EventArgs e)
    //{
    //    ViewAllDMTDetails();
    //}
    public void showPageloadResult(string partno, string process, string from, string to)
    {
        lock (thisLock)
        {
            try
            {
                DBServer db = new DBServer();
                DataSet ds = new DataSet();
                ds = db.viewpageloadresultdmt(partno, process, from, to);
                ReportDataSource rds = new ReportDataSource("DataSet1_DMT_Template", ds.Tables[0]);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LocalReport lr = null;
                    DataSet ds1 = new DataSet();
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    lr = ReportViewer1.LocalReport;
                    lr.ReportPath = "Reports/DmtReports.rdlc";
                    //lr.DataSources.Add(new ReportDataSource("ViewDMTTemplate", ds.Tables[0]));

                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    ReportViewer1.LocalReport.Refresh();

                }
                else
                {

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
    protected void img_view_Click(object sender, ImageClickEventArgs e)
    {
       
        string partno, operation, type, fromdate, todate, shift;
        partno = ddl_partno.Value.ToString();
        operation = ddl_process.Value.ToString();
        type = ddl_type.Value.ToString();
        fromdate = txt_fromdate.Value.ToString();
        todate = txt_todate.Value.ToString();
        shift = ddl_shift.Value.ToString();
       
        if (type == "1")
        {
            DBServer db = new DBServer();
            DataSet ds = new DataSet();
            ds = db.viewpageloadresultdmt(partno, operation, fromdate, todate);
            ReportDataSource rds = new ReportDataSource("DataSet1_DMT_Template", ds.Tables[0]);
            if (ds.Tables[0].Rows.Count > 0)
            {
                LocalReport lr = null;
                DataSet ds1 = new DataSet();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                lr = ReportViewer1.LocalReport;
                lr.ReportPath = "Reports/DmtReports.rdlc";
                //lr.DataSources.Add(new ReportDataSource("ViewDMTTemplate", ds.Tables[0]));

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();

            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();

            }
        }
        if (type == "2")
        {
            Response.Redirect("EfficiencyReports.aspx?Type=" + type + "&Partno=" + partno + "&Operation=" + operation + "&fromdate=" + fromdate + "&todate=" + todate + "&Shift=" + shift);
        }
        if (type == "3")
        {
            Response.Redirect("~/QualityGrid/ViewQChart.aspx?Type=" + type + "&Partno=" + partno + "&Operation=" + operation + "&fromdate=" + fromdate + "&todate=" + todate + "&Shift=" + shift);
        }
        
    }
}

