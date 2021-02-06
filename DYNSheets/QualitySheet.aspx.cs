using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
//using Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel.Workbook;
using System.IO;
using System.Data;
using System.Threading;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
public partial class DYNSheets_QualitySheet : System.Web.UI.Page
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
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public String path = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
            {
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Home.aspx");
            }
        }
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
        if (Session["User_ID"] != null && Session["User_ID"].ToString() != "")
        {
            try
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                string[] surl =url.Split('/');
                string excel = hdn_excel.Value.ToString();
                excel = excel.Replace("localhost:14851", surl[2]);
                string Partno = Session["PartNo"].ToString();
                string pidno = Session["PID_ID"].ToString();
                string Shift = Session["Shift"].ToString();
                string Operation = Session["Operation"].ToString();
                string username = Session["User_Name"].ToString();
                path = Request.PhysicalApplicationPath + "Document\\" + Partno.ToString() + "\\";
                //string datetime = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString();
                DateTime ldate = Convert.ToDateTime(HttpContext.Current.Session["LogDate"].ToString());
                string mach = HttpContext.Current.Session["machine"].ToString();
                string datetime = ldate.Day.ToString() + "." + ldate.Month.ToString() + "." + ldate.Year.ToString();
                createfolder(datetime);
                string html = excel.ToString();
                html = html.Replace("&gt;", ">");
                html = html.Replace("&lt;", "<");
                string filenamerp = "";
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "QCSheet.xls"));
                Response.ContentType = "application/ms-excel";
                //string date = DateTime.Now.ToString("MM-dd-yyyy");
                string date = ldate.ToString("MM-dd-yyyy");
                string f_name1 = "QS_Report_" + date.ToString() + "_" + Partno.ToString() + Shift.ToString() + "_" + mach.ToString() + "_" + username.ToString() + "_" + Operation.ToString() + ".xls";
                string f_name = "QS_Report_" + date.ToString() + "_" + Partno.ToString() + Shift.ToString() + "_" + mach.ToString() + "_" + username.ToString() + "_" + Operation.ToString() + ".pdf";
                filenamerp = f_name1;
                Session["WorkingFile"] = filenamerp.ToString();
                string path1 = Server.MapPath("~/Document/" + Partno.ToString() + "\\" + datetime.ToString() + "\\" + HttpContext.Current.Session["WorkingFile"].ToString());
                //string path1 = Server.MapPath("~/Document/A17724Q" + "\\" + Pidno.ToString());
                //FileInfo fi = new FileInfo(Server.MapPath("../Styles/QualitySheetDesign.css"));
                //StringBuilder sb = new StringBuilder();
                //StreamReader sr = fi.OpenText();
                //while (sr.Peek() >= 0)
                //{
                //    sb.Append(sr.ReadLine());
                //}
                //sr.Close();

                //FileInfo fi1 = new FileInfo(Server.MapPath("../Styles/Dynamicmenu.css"));
                //StringBuilder sb1 = new StringBuilder();
                //StreamReader sr1 = fi1.OpenText();
                //while (sr1.Peek() >= 0)
                //{
                //    sb1.Append(sr1.ReadLine());
                //}
                //sr1.Close();
                //FileInfo fi2 = new FileInfo(Server.MapPath("../Styles/QualityStyle.css"));
                //StringBuilder sb2 = new StringBuilder();
                //StreamReader sr2 = fi2.OpenText();
                //while (sr2.Peek() >= 0)
                //{
                //    sb2.Append(sr2.ReadLine());
                //}
                //sr2.Close();
               // string style = "<html><head><style type='text/css'>" + sb.ToString() + "" + sb1.ToString() + "" + sb2.ToString() + "</style></head><body>" + html.ToString() + "</body></html>";
                string style1 = "<html><head><title></title></head><body><img style='width:150px;height:150px;' src='' alt=''/>" + html.ToString() + "</body></html>";
                FileInfo file = new FileInfo(path1);
                if (file.Exists)
                {
                    file.Delete();
                    path = Server.MapPath("~/Document/" + Partno.ToString() + "\\" + datetime.ToString() + "\\");
                    File.AppendAllText(path + Session["WorkingFile"].ToString(), html.ToString());
                }
                else
                {
                    path = Server.MapPath("~/Document/" + Partno.ToString() + "\\" + datetime.ToString() + "\\");
                    File.AppendAllText(path + Session["WorkingFile"].ToString(), html.ToString());
                }
                //SautinSoft.PdfVision objv = new SautinSoft.PdfVision();
                //objv.ConvertHtmlFileToPDFFile(@"http://localhost:52753/Dynamic/DYNSheets/QualitySheet.aspx", path + Session["WorkingFile"].ToString());
                //objv.ConvertHtmlStringToPDFFile(style1.ToString(), path + f_name.ToString());
                string p = path + "/" + Session["WorkingFile"].ToString();
//                objqualitysheetbl.insertupdatereportsBL(Session["WorkingFile"].ToString(), p.ToString(), 1, Convert.ToDateTime(DateTime.Today), hdn_shift1.Value.ToString(), hdn_operator.Value.ToString());
                objqualitysheetbl.insertupdatereportsBL(Session["WorkingFile"].ToString(), p.ToString(), 1, Convert.ToDateTime(ldate), hdn_shift1.Value.ToString(), hdn_operator.Value.ToString());
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
            }
        }
        else
        {
            Response.Redirect("../Home.aspx");
        }
    }
   
    public void createfolder(string pidno)
    {
        DirectoryInfo dirifo = new DirectoryInfo(path);
        dirifo.CreateSubdirectory(pidno.ToString());
    }
}
