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

public partial class Master_DYNValues : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
                    if (Session["User_ID"] != null && Session["User_ID"].ToString() != "" && Session["PID_ID"] != null && Session["PID_ID"].ToString() != "")
                    { }
                    else
                    {
                        Response.Redirect("~/Home.aspx");
                    }
    }
}
