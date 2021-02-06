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
public partial class ABU_Master : System.Web.UI.Page
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
    public LineMastermbu objl = new LineMastermbu();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadgrid();
        }
    }
    protected void btn_submit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            objcontext = new QualitySheetdclassDataContext();
            objl = new LineMastermbu()
            {
                LText = txt_lname.Value.ToString(),
                LValue = txt_lvalue.Value.ToString()
            };
            txt_lname.Value = "";
            txt_lvalue.Value = "";

            objcontext.LineMastermbus.InsertOnSubmit(objl);
            objcontext.SubmitChanges();
            loadgrid();
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
    public void loadgrid()
    {
        da = new SqlDataAdapter("select * from LineMastermbu", strConnString);
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
    protected void btn_update_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            objcontext = new QualitySheetdclassDataContext();
            var query = (from tbale in objcontext.LineMastermbus where tbale.LID == Convert.ToInt32(hdn_lineid.Value.ToString()) select tbale).First();
            if (query != null)
            {
                query.LText = txt_lname.Value.ToString();
                query.LValue = txt_lvalue.Value.ToString();
                objcontext.SubmitChanges();
                txt_lname.Value = "";
                txt_lvalue.Value = "";
                loadgrid();
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
}
