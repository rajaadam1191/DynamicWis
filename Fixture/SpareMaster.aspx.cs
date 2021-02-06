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
    public SpareMastermbu objspare = new SpareMastermbu();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPartNumber();
            BindToolNumber();
            loadgrid();
        }
    }
    private void BindPartNumber()
    {

        ds = objserver.GetDateset("select '--- Select Part Number ---' PartNo union select distinct PartNo from tbl_PartNo");
        ddl_partnumber.DataSource = ds.Tables[0];

        ddl_partnumber.DataValueField = "PartNo";
        ddl_partnumber.DataTextField = "PartNo";
        ddl_partnumber.DataBind();
    }
    protected void ddl_toolnumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(ddl_toolnumber.SelectedValue.ToString());
            da = new SqlDataAdapter("select a.* ,b.Fixturename as Tool from SpareMastermbu  a inner join FixtureName b on cast(a.ToolNumber as int)=b.FID where b.FID='" + id.ToString() + "'", strConnString);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_maximum.Value = ds.Tables[0].Rows[0]["Maximum"].ToString();
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
        da = new SqlDataAdapter("select a.* ,b.Fixturename as Tool from SpareMastermbu  a inner join FixtureName b on cast(a.ToolNumber as int)=b.FID", strConnString);
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

        //ds = objserver.GetDateset("select '0' ID,'--- Select Tool Number ---' ToolNumber union select distinct ID,ToolNumber from AbuToolMaster");

        ds = objserver.GetDateset("select '0' FID,'--- Select Fixturename ---' Fixturename union select distinct FID,Fixturename from FixtureName");
        ddl_toolnumber.DataSource = ds.Tables[0];

        //dl_toolnumber.DataValueField = "FID";
        ddl_toolnumber.DataValueField = "FID";
        ddl_toolnumber.DataTextField = "Fixturename";
        ddl_toolnumber.DataBind();
    }
    protected void ddl_partnumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_toolnumber.SelectedValue == "0")
        {
            string partno = ddl_partnumber.SelectedValue.ToString();
            ds = objserver.GetDateset("select '0' Fid,'--- Select Fixture Number ---' FixtureName union select distinct Fid,Fixturename from FixtureName where Partnumber='" + partno + "'");
            ddl_toolnumber.DataSource = ds.Tables[0];

            ddl_toolnumber.DataValueField = "Fid";
            //ddl_toolnumber.DataValueField = "Fixturename";
            ddl_toolnumber.DataTextField = "Fixturename";
            ddl_toolnumber.DataBind();
        }
    }
    protected void btn_submit_Click(object sender, ImageClickEventArgs e)
    {
        objcontext = new QualitySheetdclassDataContext();
        objspare = new SpareMastermbu()
        {
            Partno = "",
            ToolNumber = ddl_toolnumber.SelectedValue.ToString(),
            Maximum = txt_maximum.Value.ToString(),
            Minimum = txt_minimum.Value.ToString(),
            TotalCount = txt_sparecount.Value.ToString()
        };
        objcontext.SpareMastermbus.InsertOnSubmit(objspare);
        objcontext.SubmitChanges();
        loadgrid();
        BindPartNumber();
        BindToolNumber();
        txt_maximum.Value = "";
        txt_minimum.Value = "";
        txt_sparecount.Value = "";
    }
   
    protected void btn_update_Click1(object sender, ImageClickEventArgs e)
    {
        objcontext = new QualitySheetdclassDataContext();
        var query = (from table in objcontext.SpareMastermbus where table.SID == Convert.ToInt32(hdn_spareid.Value.ToString()) select table).First();
        if (query != null)
        {
            query.Partno = "";
            query.ToolNumber = ddl_toolnumber.SelectedValue.ToString();
            query.Maximum = txt_maximum.Value.ToString();
            query.Minimum = txt_minimum.Value.ToString();
            query.TotalCount = txt_sparecount.Value.ToString();
            objcontext.SubmitChanges();
            loadgrid();
            BindPartNumber();
            BindToolNumber();
            txt_maximum.Value = "";
            txt_minimum.Value = "";
            txt_sparecount.Value = "";
        }
        else
        {
        }
    }
}
