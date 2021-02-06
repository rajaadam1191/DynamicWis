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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class FixtureReport : System.Web.UI.Page
{
    public String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    public DBServer objserver = new DBServer();
    public DataSet ds;
    public SqlDataAdapter da;
    public static Object thisLock = new Object();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User_Role"] != null && Session["User_Role"].ToString() != "")
            {
                loadgridview();
                BindData();
                show_link();
               
            }
            else
            {
                Response.Redirect("../Home.aspx");
            }
        }

    }
    protected void BindData()
    {
        lock (thisLock)
        {
            try
            {

                DataSet ds = new DataSet();
                string cmdstr = "select id,PartNo from tbl_PartNo";
                SqlDataAdapter adp = new SqlDataAdapter(cmdstr, strConnString);
                adp.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddchkCountry.DataSource = ds.Tables[0];
                    ddchkCountry.DataTextField = "PartNo";
                    ddchkCountry.DataValueField = "id";
                    ddchkCountry.DataBind();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }

    }
    protected void OnDataBound(object sender, EventArgs e)
    {
        lock (thisLock)
        {
            try
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                for (int i = 0; i < GridView1.Columns.Count; i++)
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    TextBox txtSearch = new TextBox();
                    txtSearch.Attributes["placeholder"] = "Search";
                    txtSearch.CssClass = "search_textbox";
                    cell.Controls.Add(txtSearch);
                    row.Controls.Add(cell);
                }
                GridView1.HeaderRow.Parent.Controls.AddAt(1, row);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }
    public void loadgridview()
    {
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from FixtureStatus", strConnString);
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }

                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }
   
    public void show_link()
    {
        sp_logdate.InnerText = Session["LogDate"].ToString();
        sp_logtimr.InnerText = Session["Logtime"].ToString();
        sp_username.InnerText = Session["User_Name"].ToString();
    }

    protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
    {
        List<String> CountryID_list = new List<string>();
        List<String> CountryName_list = new List<string>();
        lock (thisLock)
        {
            try
            {

                foreach (System.Web.UI.WebControls.ListItem item in ddchkCountry.Items)
                {
                    if (item.Selected)
                    {
                        CountryID_list.Add(item.Value);
                        CountryName_list.Add(item.Text);
                    }

                    // partnoid.Text = "Country ID: " + String.Join(",", CountryID_list.ToArray());
                    // partname.Text = "Country Name: " + String.Join(",", CountryName_list.ToArray());
                }
                loadgridview();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }
    protected void ddchkCountry_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddchkCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
 
