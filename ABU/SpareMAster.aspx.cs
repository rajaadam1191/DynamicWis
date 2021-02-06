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

public partial class ABU_SpareMAster : System.Web.UI.Page
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
    public SpareMaster objspare = new SpareMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindToolNumber();
            loadgrid();
        }
    }
    protected void ddl_toolnumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(ddl_toolnumber.SelectedValue.ToString());
            da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from SpareMaster  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where b.Id='" + id.ToString() + "'", strConnString);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
               txt_maximum.Value=ds.Tables[0].Rows[0]["Maximum"].ToString();
               txt_minimum.Value = ds.Tables[0].Rows[0]["Minimum"].ToString();
               txt_sparecount.Focus();
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
    public void loadgrid()
    {
        da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from SpareMaster  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID", strConnString);
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
    private void BindToolNumber()
    {

        ds = objserver.GetDateset("select '0' ID,'--- Select Tool Number ---' ToolNumber union select distinct ID,ToolNumber from AbuToolMaster");
        ddl_toolnumber.DataSource = ds.Tables[0];

        ddl_toolnumber.DataValueField = "ID";
        ddl_toolnumber.DataTextField = "ToolNumber";
        ddl_toolnumber.DataBind();
    }
    protected void btn_submit_Click(object sender, ImageClickEventArgs e)
    {
        objcontext = new QualitySheetdclassDataContext();
        objspare = new SpareMaster()
        {
            ToolNumber = ddl_toolnumber.SelectedValue.ToString(),
            Maximum = txt_maximum.Value.ToString(),
            Minimum = txt_minimum.Value.ToString(),
            TotalCount = txt_sparecount.Value.ToString()
        };
        objcontext.SpareMasters.InsertOnSubmit(objspare);
        objcontext.SubmitChanges();
        loadgrid();
        BindToolNumber();
        txt_maximum.Value = "";
        txt_minimum.Value = "";
        txt_sparecount.Value = "";
    }
   
    protected void btn_update_Click1(object sender, ImageClickEventArgs e)
    {
        objcontext = new QualitySheetdclassDataContext();
        var query = (from table in objcontext.SpareMasters where table.SID == Convert.ToInt32(hdn_spareid.Value.ToString()) select table).First();
        if (query != null)
        {
            query.ToolNumber = ddl_toolnumber.SelectedValue.ToString();
            query.Maximum = txt_maximum.Value.ToString();
            query.Minimum = txt_minimum.Value.ToString();
            query.TotalCount = txt_sparecount.Value.ToString();
            objcontext.SubmitChanges();
            loadgrid();
            BindToolNumber();
            txt_maximum.Value = "";
            txt_minimum.Value = "";
            txt_sparecount.Value = "";
        }
        else
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
    protected void grid_abumaster_Disposed(object sender, EventArgs e)
    {

    }
}
