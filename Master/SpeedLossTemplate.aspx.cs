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

public partial class SpeedLossTemplate : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                if (Session["User_ID"] != null && Session["User_ID"].ToString() != "" && Session["PID_ID"] != null && Session["PID_ID"].ToString() != "")
                {
                  //  show_link();
                    loadGrid();
                }
                else
                {
                    Response.Redirect("~/Home.aspx");
                }

            }

        }
    }
    public void show_link()
    {
      //  objqualitysheetbl.show_Access_RightsBL(link_24q, link_6j, link_1c, link_8n, link_3u, link_process, link_part, link_work, link_userpage, link_hourly, link_dmt, link_oee, link_hrept, link_time, link_laping24, link_opt24, link_poli24, link_chart, link_reports, link_register, link_dmttemp, link_eff, link_opt2j, link_poliJ, link_polc, link_polu, link_poln, link_planned, link_barcode,link_effreports,link_addpages, Session["PID_ID"].ToString());
        //sp_logdate.InnerText = Session["LogDate"].ToString();
       // sp_logtimr.InnerText = Session["Logtime"].ToString();
       // sp_username.InnerText = Session["User_Name"].ToString();
    }
    public void loadGrid()
    {
        ds = objserver.GetDateset("select * from tbl_barcode");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DL_barcodeTemplate.DataSource = ds;
            DL_barcodeTemplate.DataBind();
        }
        else { }
    }
    protected void DL_barcodeTemplate_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Image img_breakdown = (Image)(e.Item.FindControl("img_breakdown"));
        Image img_maintenance = (Image)(e.Item.FindControl("img_maintenance"));

        string breakdown = "1234567890";
        string maitenane = "2345678901";

        img_breakdown.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=100", breakdown.PadLeft(8, '0'));
        img_maintenance.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", maitenane.PadLeft(8, '0'));

    }
}

