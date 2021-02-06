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
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office;
//using Microsoft.Office.Interop.Word;
public partial class View_Reports : System.Web.UI.Page
{
    private String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    DBServer objserver = new DBServer();
    DataSet ds;
    public string strPath;
    public String pathname = "~/Document" + "/" + "A17724Q" + "/";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_view_Click(object sender, EventArgs e)
    {
        ds=objserver.GetDateset("select * from QSReportFile where PID_No='"+txt_pidno.Value.ToString()+"' and Shift='"+txt_shift.Value.ToString()+"'");
        if (ds.Tables[0].Rows.Count > 0)
        {

            strPath = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            string filepath = strPath;
            string FullFilePath = strPath;
            FileInfo file = new FileInfo(FullFilePath);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "inline; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
        }
       
    }
}
