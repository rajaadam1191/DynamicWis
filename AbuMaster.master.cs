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
public partial class AbuMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "")
            {
                if (Session["User_Role"].ToString().ToLower() == "admin")
                {
                    div_user.Visible = false;
                    div_admin.Visible = true;
                    super_admin.Visible = false;
                }
                //if (Session["User_Role"].ToString().ToLower() == "user")
                //{
                //    div_user.Visible = true;
                //    div_admin.Visible = false;
                //    super_admin.Visible = false;

                //}
                if (Session["User_Role"].ToString().ToLower() == "super admin")
                {
                    //div_user.Visible = false;
                    //div_admin.Visible = false;
                    //super_admin.Visible = true;

                    div_user.Visible = false;
                    div_admin.Visible = true;
                    super_admin.Visible = false;

                }
            }

            else
            {
                Response.Redirect("../Home.aspx");
            }
            sp_logdate.InnerText = Session["LogDate"].ToString();
            sp_logtimr.InnerText = Session["Logtime"].ToString();
            sp_username.InnerText = Session["User_Name"].ToString();
        }
    }
}
