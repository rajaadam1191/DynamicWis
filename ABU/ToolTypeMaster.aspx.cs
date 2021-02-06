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
    public ToolTypeMaster objt = new ToolTypeMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadgrid();
        }
    }
    public void loadgrid()
    {
        da = new SqlDataAdapter("select * from ToolTypeMaster", strConnString);
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
        try
        {
            objcontext = new QualitySheetdclassDataContext();
            objt = new ToolTypeMaster()
            {
                //TText = txt_ttype.Value.ToString(),
                //TValue = txt_tvalue.Value.ToString()
                TText = txt_tvalue.Value.ToString(),
                TValue = txt_ttype.Value.ToString()
            };
            txt_ttype.Value = "";
            txt_tvalue.Value = "";
            objcontext.ToolTypeMasters.InsertOnSubmit(objt);
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
    protected void btn_update_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            objcontext = new QualitySheetdclassDataContext();
            var query = (from table in objcontext.ToolTypeMasters where table.TID == Convert.ToInt32(hdn_typeid.Value.ToString()) select table).First();
            if (query != null)
            {
                //query.TText = txt_ttype.Value.ToString();
                //query.TValue = txt_tvalue.Value.ToString();
                query.TText = txt_tvalue.Value.ToString();
                query.TValue = txt_ttype.Value.ToString();
                objcontext.SubmitChanges();
                txt_ttype.Value = "";
                txt_tvalue.Value = "";
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
    protected void OnDataBound(object sender, EventArgs e)
    {
        if (grid_abumaster.Rows.Count > 0)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            for (int i = 1; i < grid_abumaster.Columns.Count; i++)
            {
                TableHeaderCell cell = new TableHeaderCell();
                TextBox txtSearch = new TextBox();
                txtSearch.Attributes["placeholder"] = "Filter";
                txtSearch.CssClass = "search_textbox";
                cell.Controls.Add(txtSearch);
                row.Controls.Add(cell);
            }
            grid_abumaster.HeaderRow.Parent.Controls.AddAt(1, row);
        }
    }
}
