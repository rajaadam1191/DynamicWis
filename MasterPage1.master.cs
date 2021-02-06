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
public partial class MasterPage1 : System.Web.UI.MasterPage
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
                if (Session["User_Role"].ToString().ToLower() == "admin")
                {
                    div_user.Visible = false;
                    div_admin.Visible = true;
                    super_admin.Visible = false;
                }
                if (Session["User_Role"].ToString().ToLower() == "user")
                {
                    div_user.Visible = true;
                    div_admin.Visible = false;
                    super_admin.Visible = false;

                }
                if (Session["User_Role"].ToString().ToLower() == "super admin")
                {
                    div_user.Visible = false;
                    div_admin.Visible = false;
                    super_admin.Visible = true;
                    Showadminlink();

                }
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
        if (Session["User_Role"].ToString().ToLower() == "user")
        {
         //   objqualitysheetbl.showprodataBL(link_productiondata, Session["User_Role"].ToString(), Session["PartNo"].ToString(), Session["Operation"].ToString());
        }
    }
    public void Showadminlink()
    {
      //  objqualitysheetbl.show_Access_RightsBL(link_24q, link_6j, link_1c, link_8n, link_3u, link_process, link_part, link_work, link_userpage,  link_time, link_laping24, link_opt24, link_poli24, link_chart,  link_register, link_dmttemp,  link_opt2j, link_poliJ, link_polc, link_polu, link_poln, link_planned, link_barcode,  link_addpages, Session["PID_ID"].ToString());
    }

}