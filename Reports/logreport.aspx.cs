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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class Reports_logreport : System.Web.UI.Page
{
    public String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    public DBServer objserver = new DBServer();
    public DataSet ds;
    public static Object thisLock = new Object();
    SqlDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //loadgridview();
        }
    }
    public void loadgridview()
    {
        lock (thisLock)
        {
            try
            {
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da = new SqlDataAdapter("select * from Tbl_ExceptionLoggingToDataBase", strConnString);
                ds = new DataSet();

                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
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

    public void loadgridview1()
    {

        lock (thisLock)
        {


            try
            {
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();

                da = new SqlDataAdapter("select * from Eventlog", strConnString);
                ds = new DataSet();

                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        loadgridview();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        loadgridview1();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }
    protected void ExportToPDF(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=ExceptionLog.xls");
        Response.ContentType = "application/excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //To Export all pages
        GridView1.AllowPaging = false;
        loadgridview();

        GridView1.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();

    }
    protected void ExportToPDF_sqllog(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=EventLog.xls");
        Response.ContentType = "application/excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //To Export all pages
        GridView1.AllowPaging = false;
        loadgridview1();

        GridView1.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();


        //using (StringWriter sw = new StringWriter())
        //{
        //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //    {
        //        //To Export all pages
        //        GridView1.AllowPaging = false;
        //        loadgridview1();

        //        GridView1.RenderControl(hw);
        //        StringReader sr = new StringReader(sw.ToString());
        //        Document pdfDoc = new Document(PageSize.A4);
        //        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //        pdfDoc.Open();
        //        htmlparser.Parse(sr);
        //        pdfDoc.Close();

        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=SpareReport.pdf");
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.Write(pdfDoc);
        //        Response.End();

        //    }
        //}
    }
}
