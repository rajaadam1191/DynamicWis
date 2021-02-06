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

public partial class BarcodeTemplate : System.Web.UI.Page
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
        //Image img_setupstart = (Image)(e.Item.FindControl("img_setupstart"));
       // Image img_setupend = (Image)(e.Item.FindControl("img_setupend"));
       // Image img_unstart = (Image)(e.Item.FindControl("img_unstart"));
        //Image img_unend = (Image)(e.Item.FindControl("img_unend"));
        //Image img_coverstart = (Image)(e.Item.FindControl("img_coverstart"));
       // Image img_coverend = (Image)(e.Item.FindControl("img_coverend"));
        //Image img_matstart = (Image)(e.Item.FindControl("img_matstart"));
        //Image img_matend = (Image)(e.Item.FindControl("img_matend"));
        Image img_Opstart = (Image)(e.Item.FindControl("img_Opstart"));
        Image img_Opend = (Image)(e.Item.FindControl("img_Opend"));
        //Image img_ntstart = (Image)(e.Item.FindControl("img_ntstart"));
        //Image img_ntend = (Image)(e.Item.FindControl("img_ntend"));
        //Image img_qstart = (Image)(e.Item.FindControl("img_qstart"));
        //Image img_qend = (Image)(e.Item.FindControl("img_qend"));
        //Image img_mstart = (Image)(e.Item.FindControl("img_mstart"));
       // Image img_mend = (Image)(e.Item.FindControl("img_mend"));
       // Image img_dstart = (Image)(e.Item.FindControl("img_dstart"));
       // Image img_dend = (Image)(e.Item.FindControl("img_dend"));

        string date = System.DateTime.Now.ToShortTimeString();
       // img_setupstart.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_setupend.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_unstart.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_unend.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
        //img_coverstart.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
        //img_coverend.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_matstart.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_matend.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
        img_Opstart.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
        img_Opend.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_ntstart.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_ntend.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_qstart.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_qend.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_mstart.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_mend.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_dstart.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));
       // img_dend.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText=0&Height=30", date.PadLeft(8, '0'));

    }
}

