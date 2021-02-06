using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
public partial class Admin : System.Web.UI.MasterPage
{
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Workinstruction.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "" && Session["PID_ID"] != null && Session["PID_ID"].ToString() != "")
            {
                show_link();
            }

            else
            {
                Response.Redirect("../Home.aspx");
            }
        }
    }
    public void show_link()
    {
        sp_logdate.InnerText = Session["LogDate"].ToString();
        sp_logtimr.InnerText = Session["Logtime"].ToString();
        sp_username.InnerText = Session["User_Name"].ToString();
    }
}