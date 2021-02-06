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

public partial class OEERptFrm : System.Web.UI.Page
{
    private String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    DBServer objserver = new DBServer();
    DataSet ds;
    public static Object thisLock = new Object();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //ASPDateEdit1.Text = System.DateTime.Now.ToString();
            //ASPDateEdit2.Text = System.DateTime.Now.ToString();
            ViewAllOEEDetails();
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        ViewAllOEEDetails();
    }

    private void ViewAllOEEDetails()
    {

        lock (thisLock)
        {
            try
            {
                DBServer db = new DBServer();
                ds = db.efficiencycal(db);

                //  ds = objserver.GetDateset("select doc_ref,Rev,businessunit,parttype,operation,specificpartorcommon,typeofdocument,creationdate,revisiondate,status,comments,functioninchargeoffilling ,paperfilling ,durationoffilling ,storageplacefilling ,electronicsfilling ,methodoffilling ,protectagainstwaterfilling  ,funinchargeof ,paper ,electronics ,durationofarchiving ,archivingplace ,authorized ,notauthorized ,functioninchargeofdestruction ,methodOfDestruction  from dbo.DMT_Template where specificpartorcommon=" + Convert.ToString(this.DropPartNo.Text) + "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LocalReport lr = null;
                    DataSet ds1 = new DataSet();
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    lr = ReportViewer1.LocalReport;
                    lr.ReportPath = "Reports/Report5.rdlc";
                    //lr.DataSources.Add(new ReportDataSource("efficiencycal", ds.Tables[0]));
                    ReportDataSource rds = new ReportDataSource("DataSet1_ViewAllEfficiencyCal", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    ReportViewer1.LocalReport.Refresh();
                }
                else
                {

                    //  ReportViewer1.LocalReport.DataSources.Clear();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                Label3.Text = ex.Message;
                if (Label3.Text != "An invalid parameter or option was specified for procedure 'No already Exists'.")
                {

                    Label3.Text = "Record Not Found";
                }
            }
            finally
            {
               

            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        lock (thisLock)
        {

            try
            {

                DBServer db = new DBServer();
                DataSet ds = new DataSet();
                DateTime dt = Convert.ToDateTime(txt_from_date.Value);
                db.fromdate = txt_from_date.Value;
                db.todate = txt_to_date.Value;
                ds = db.ViewAllEfficiencyCalbydatetime(db);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LocalReport lr = null;
                    DataSet ds1 = new DataSet();
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    lr = ReportViewer1.LocalReport;
                    lr.ReportPath = "Reports/Report5.rdlc";
                    ReportDataSource rds = new ReportDataSource("DataSet1_ViewAllEfficiencyCal", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    ReportViewer1.LocalReport.Refresh();
                }
                else
                {

                    //  ReportViewer1.LocalReport.DataSources.Clear();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Not Found');", true);

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
