using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;
using System.Windows.Forms.Layout;
using System.IO;
using System.Globalization;
using System.Data.SqlClient;
using System.Configuration;


public partial class ABU_PlayVideos : System.Web.UI.Page
{  
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public DataSet ds;
    public SqlDataAdapter da;
    public SqlCommand cmd;
    public int findex, lindex, count = 0;
    public QualitySheetdclassDataContext objcontext = new QualitySheetdclassDataContext();
    public ToolVideofile objv = new ToolVideofile();
    protected void Page_Load(object sender, EventArgs e)
    {
        string Filename = "";
        string ID = Request.QueryString["ID"].ToString();
        da = new SqlDataAdapter("select * from ToolVideofiles where ID='" + Convert.ToInt32(ID) + "'", strConnString);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Filename = "../ABU/Videos/" + ds.Tables[0].Rows[0]["FileName"].ToString();
        }
        else
        {
        }
        Media_Player_Control1.MovieURL = Filename;
        Media_Player_Control1.AutoStart = true;
        Media_Player_Control1.FullScreen = true;
    }
}
