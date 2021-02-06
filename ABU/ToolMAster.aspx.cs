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
using System.Web.Services;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data.OleDb;

public partial class ABU_ToolMAster : System.Web.UI.Page
{
    public static SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public DataSet ds;
    public SqlDataAdapter da;
    public static SqlCommand cmd;
    public QualitySheetdclassDataContext objcontext = new QualitySheetdclassDataContext();
    public AbuToolMaster objabu = new AbuToolMaster();
    public int findex, lindex, count = 0;
    public PagedDataSource paging = new PagedDataSource();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUnit();
            BindToolType();
            BindToolLine();
            loadtoolgrid();
        }
    }
    private void BindUnit()
    {
        ds = objserver.GetDateset("select '0' MValue,'--- Select Unit ---' MText union select distinct MValue,MText from UnitMaster");

        ddl_unit.DataSource = ds.Tables[0];

        ddl_unit.DataValueField = "MValue";
        ddl_unit.DataTextField = "MText";
        ddl_unit.DataBind();
    }
    private void BindToolType()
    {
        ds = objserver.GetDateset("select '0' TValue,'--- Select Tool Type ---' TText union select distinct TValue,TText from ToolTypeMaster");

        ddl_tooltype.DataSource = ds.Tables[0];

        ddl_tooltype.DataValueField = "TValue";
        ddl_tooltype.DataTextField = "TText";
        ddl_tooltype.DataBind();
    }
    private void BindToolLine()
    {
        ds = objserver.GetDateset("select '0' LValue,'--- Select Tool Line ---' LText union select distinct LValue,LText from LineMaster");

        ddl_line.DataSource = ds.Tables[0];

        ddl_line.DataValueField = "LValue";
        ddl_line.DataTextField = "LText";
        ddl_line.DataBind();
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
            lindex = 10;
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
            loadtoolgrid();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        loadtoolgrid();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        loadtoolgrid();
    }
    public void loadtoolgrid()
    {
        da = new SqlDataAdapter("select ROW_NUMBER() over (order by ToolNumber) as IndexNo,* from AbuToolMaster", strConnString);
        ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds);
        da.Fill(dt);
        if (ds.Tables[0].Rows.Count > 0)
        {
            paging.DataSource = dt.DefaultView;
            if (ds.Tables[0].Rows.Count > 8)
            {
                paging.AllowPaging = true;
                paging.PageSize = 8;
                paging.CurrentPageIndex = CurrentPage;
                ViewState["totalpage"] = paging.PageCount;
                link_previous.Enabled = !paging.IsFirstPage;
                link_next.Enabled = !paging.IsLastPage;
            }
            else
            {
                div_paging.Visible = false;
            }
            grid_abumtoolaster.DataSource = paging;
            grid_abumtoolaster.DataBind();
            createpaging();
        }
        else
        {
        }
    }
    public void clearbox()
    {
        txt_gfrom.Value = "";
        txt_gto.Value = "";
        txt_yfrom.Value = "";
        txt_yto.Value = "";
        txt_rfrom.Value = "";
        txt_rto.Value = "";
        txt_toolno.Value = "";
        ddl_unit.SelectedValue = "0";
        ddl_tooltype.SelectedValue = "0";
        ddl_line.SelectedValue = "0";
        txt_tredension.Value = "";
    }
    protected void btn_submit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            objcontext = new QualitySheetdclassDataContext();
            var query = (from table in objcontext.AbuToolMasters where table.ToolNumber == ddl_unit.SelectedValue.ToString() + "-" + ddl_tooltype.SelectedValue.ToString() + "" + txt_toolno.Value.ToString() + "-" + ddl_line.SelectedValue.ToString() select table).FirstOrDefault();
            if (query != null)
            {
                clearbox();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Tool Number Already Exist');", true);
            }
            else
            {
                objabu = new AbuToolMaster()
                {
                    ToolNumber = ddl_unit.SelectedValue.ToString() + "-" + ddl_tooltype.SelectedValue.ToString() + "" + txt_toolno.Value.ToString() + "-" + ddl_line.SelectedValue.ToString(),
                    Gfrom = txt_gfrom.Value.ToString(),
                    Gto = txt_gto.Value.ToString(),
                    Yfrom = txt_yfrom.Value.ToString(),
                    Yto = txt_yto.Value.ToString(),
                    Rfrom = txt_rfrom.Value.ToString(),
                    Rto = txt_rto.Value.ToString(),
                    Unit = ddl_unit.SelectedValue.ToString(),
                    Name = ddl_tooltype.SelectedValue.ToString(),
                    Line = ddl_line.SelectedValue.ToString(),
                    RetensionTime = txt_tredension.Value.ToString()
                };
                objcontext.AbuToolMasters.InsertOnSubmit(objabu);
                objcontext.SubmitChanges();
                clearbox();
                loadtoolgrid();
            }
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
        string id = hdn_toolid.Value.ToString();
        var query = (from table in objcontext.AbuToolMasters where table.ID == Convert.ToInt32(id) select table).First();
        if (query != null)
        {
            query.ToolNumber = txt_toolno.Value.ToString();
            query.Gfrom = txt_gfrom.Value.ToString();
            query.Gto = txt_gto.Value.ToString();
            query.Yfrom = txt_yfrom.Value.ToString();
            query.Yto = txt_yto.Value.ToString();
            query.Rfrom = txt_rfrom.Value.ToString();
            query.Rto = txt_rto.Value.ToString();
            query.Unit = ddl_unit.SelectedValue.ToString();
            query.Name = ddl_tooltype.SelectedValue.ToString();
            query.Line = ddl_line.SelectedValue.ToString();
            query.RetensionTime = txt_tredension.Value.ToString();
            objcontext.SubmitChanges();

            da = new SqlDataAdapter("select * from Abu_Master where ToolNumber='" + Convert.ToInt32(id) + "' and ToolStatus='Active' ", strConnString);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string  ret ,lifeextend;
                string grom = "";
                string gto = "";
                string yfrom = "";
                string yto = "";
                string rfrom = "";
                string rto = "";

                ret = txt_tredension.Value.ToString();
                lifeextend = ds.Tables[0].Rows[0]["LifeExtend"].ToString();
                if (lifeextend.ToString() == "")
                {
                    lifeextend = "0";
                }
                int total = Convert.ToInt32(ret.ToString()) + Convert.ToInt32(lifeextend.ToString());
                string issue = ds.Tables[0].Rows[0]["Issuedon"].ToString();

                string grfrom = txt_gfrom.Value.ToString();
                string grto = txt_gto.Value.ToString();
                string ylfrom = txt_yfrom.Value.ToString();
                string ylto = txt_yto.Value.ToString();
                string rdfrom = txt_rfrom.Value.ToString();
                string rdto = txt_rto.Value.ToString();

                double gf = (Convert.ToInt32(total)) * ((Convert.ToDouble(grto) / 100));
                double yf = (Convert.ToInt32(total)) * ((Convert.ToDouble(ylfrom) / 100));
                double yt = (Convert.ToInt32(total)) * ((Convert.ToDouble(ylto) / 100));
                double rf = (Convert.ToInt32(total)) * ((Convert.ToDouble(rdfrom) / 100));
                double rt = (Convert.ToInt32(total)) * ((Convert.ToDouble(rdto) / 100));

                int g = (int)Math.Round(gf);
                int y = (int)Math.Round(yf);
                int y1 = (int)Math.Round(yt);
                int r = (int)Math.Round(rf);
                int r1 = (int)Math.Round(rt);

                DateTime days = Convert.ToDateTime(issue);
                grom = days.AddDays(Convert.ToInt32(0)).ToShortDateString().ToString();
                DateTime days1 = Convert.ToDateTime(issue);
                gto = days1.AddDays(Convert.ToInt32(g)).ToShortDateString().ToString();

                DateTime days2 = Convert.ToDateTime(gto);
                yfrom = days2.AddDays(Convert.ToInt32(1)).ToShortDateString().ToString();
                DateTime days3 = Convert.ToDateTime(issue);
                yto = days3.AddDays(Convert.ToInt32(y1)).ToShortDateString().ToString();

                DateTime days4 = Convert.ToDateTime(yto);
                rfrom = days4.AddDays(Convert.ToInt32(1)).ToShortDateString().ToString();
                DateTime days5 = Convert.ToDateTime(issue);
                rto = days5.AddDays(Convert.ToInt32(r1)).ToShortDateString().ToString();
                var query1 = (from table in objcontext.Abu_Masters where table.ToolNumber == id.ToString() && table.ToolStatus=="Active" select table).First();
                if (query1 != null)
                {
                    query1.Rentime = txt_tredension.Value.ToString();
                    query1.GreenFrom = Convert.ToDateTime(grom.ToString());
                    query1.GreenTo = Convert.ToDateTime(gto.ToString());
                    query1.YellowFrom = Convert.ToDateTime(yfrom.ToString());
                    query1.YellowTo = Convert.ToDateTime(yto.ToString());
                    query1.RedFrom = Convert.ToDateTime(rfrom.ToString());
                    query1.RedTo = Convert.ToDateTime(rto.ToString());
                    query1.Nextdueon = Convert.ToDateTime(rto.ToString()).ToShortDateString().ToString();
                    objcontext.SubmitChanges();
                }
            }
            else
            {
            }
            clearbox();
            loadtoolgrid();
        }
        else
        {
        }
    }
    protected void OnDataBound(object sender, EventArgs e)
    {
        if (grid_abumtoolaster.Rows.Count > 0)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            for (int i = 1; i < grid_abumtoolaster.Columns.Count; i++)
            {
                TableHeaderCell cell = new TableHeaderCell();
                TextBox txtSearch = new TextBox();
                txtSearch.Attributes["placeholder"] = "Filter";
                txtSearch.CssClass = "search_textbox";
                cell.Controls.Add(txtSearch);
                row.Controls.Add(cell);
            }
            grid_abumtoolaster.HeaderRow.Parent.Controls.AddAt(1, row);
        }
    }
    [WebMethod]
    public static string deleteToolmaster(string ID)
    {
        string res = "";
        try
        {
            if (strConnString.State == ConnectionState.Open)
            {
                strConnString.Close();
            }
            cmd = new SqlCommand("delete  from AbuToolMaster where ID='" + Convert.ToInt32(ID) + "'", strConnString);
            strConnString.Open();
            cmd.ExecuteNonQuery();
            strConnString.Close();
            res = "S";
        }
        catch (Exception ex)
        {
            res = "F";
        }
        finally
        {
        }
        return res.ToString();
    }
}
