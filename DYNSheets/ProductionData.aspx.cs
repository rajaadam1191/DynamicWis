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

public partial class DYNSheets_ProductionData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "")
            {
                txt_prod_fromdate.Value = Convert.ToDateTime(HttpContext.Current.Session["LogDate"].ToString()).ToString("dd/MM/yyyy");
            }
            else
            {
                Response.Redirect("../Home.aspx");
            }

        }
    }
}
