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


public partial class ABU_MailAddress : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public DataSet ds;
    public SqlDataAdapter da;
    public SqlCommand cmd;
    public int findex, lindex, count = 0;
    public PagedDataSource paging = new PagedDataSource();
    public QualitySheetdclassDataContext objcontext = new QualitySheetdclassDataContext();
    public MailAutorized objm = new MailAutorized();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadgrid();
        }
    }
    public void loadgrid()
    {
        da = new SqlDataAdapter("select * from MailAutorized", strConnString);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grid_abumaster.DataSource = ds.Tables[0];
            grid_abumaster.DataBind();
        }
        else
        {
        }
    }
    protected void btn_submit_Click(object sender, ImageClickEventArgs e)
    {
        objcontext = new QualitySheetdclassDataContext();
        objm = new MailAutorized()
        {
            MailID = txt_mailaddress.Value.ToString(),
            unit = ddl_availability.Text

        };
        objcontext.MailAutorizeds.InsertOnSubmit(objm);
        objcontext.SubmitChanges();
        loadgrid();
        txt_mailaddress.Value = "";
        ddl_availability.Text = "--- Select Unit ---";

    }
    protected void btn_update_Click(object sender, ImageClickEventArgs e)
    {
        var query = (from table in objcontext.MailAutorizeds where table.ID == Convert.ToInt32(hdn_midauth.Value.ToString()) select table).First();
        if (query != null)
        {
            query.MailID = txt_mailaddress.Value.ToString();
            query.unit = ddl_availability.Text;
            objcontext.SubmitChanges();
            loadgrid();
            txt_mailaddress.Value = "";
            ddl_availability.Text = "--- Select Unit ---";
        }
        else
        {
        }
    }
}
