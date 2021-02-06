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
    public Abu_Master objabu = new Abu_Master();
    public UnitMastermbu objunit = new UnitMastermbu();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

           loadgrid();
        }
       
       // loadgrid();
    }
    public void loadgrid()
    {
        ds = new DataSet();
    //ds.Tables.Clear();
    //da = null;
        da = new SqlDataAdapter("select ROW_NUMBER() over (order by MID) as IndexNo,* from UnitMastermbu", strConnString);
       
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
    private void createpaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");
        findex = CurrentPage - 10;
        if (CurrentPage >= 9)
        {
            lindex = CurrentPage + 10;
        }
        else
        {
            lindex = 5;
        }
        if (lindex > Convert.ToInt32(ViewState["totalpage"]))
        {
            lindex = Convert.ToInt32(ViewState["totalpage"]);
            findex = lindex - 10;
        }
        if (findex < 0)
        {
            findex = 0;
        }
        for (int i = findex; i < lindex; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }
        DataListPaging.DataSource = dt;
        DataListPaging.DataBind();
    }
    public int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] != null)

                return Convert.ToInt32(ViewState["CurrentPage"]);
            else
                return 0;
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }
    protected void DataListPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        LinkButton lnkPage = (LinkButton)e.Item.FindControl("link_pagebtn");
        if (lnkPage.CommandArgument.ToString() == CurrentPage.ToString())
        {
            lnkPage.Enabled = false;
            lnkPage.Font.Bold = true;
            lnkPage.Attributes.Add("class", "square_selected");
        }
        else
        {
            lnkPage.Attributes.Add("class", "square");
        }
    }
    protected void DataListPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("newpage"))
        {
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            loadgrid();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        loadgrid();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        loadgrid();
    }
    protected void btn_submit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            objcontext = new QualitySheetdclassDataContext();
            objunit = new UnitMastermbu()
            {
                MText = txt_unitname.Value.ToString(),
                MValue = txt_unitname.Value.ToString()
            };
            txt_unitname.Value = "";
            objcontext.UnitMastermbus.InsertOnSubmit(objunit);
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
            var query = (from table in objcontext.UnitMastermbus where table.MID == Convert.ToInt32(hdn_masterid.Value.ToString()) select table).First();
            if (query != null)
            {
                query.MText = txt_unitname.Value.ToString();
                query.MValue = txt_unitname.Value.ToString();
                objcontext.SubmitChanges();
                loadgrid();
                txt_unitname.Value = "";
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
