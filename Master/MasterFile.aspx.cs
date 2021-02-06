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


public partial class MasterFile : System.Web.UI.Page
{
    public QualitySheetdclassDataContext objQualitySheetdclassDataContext = new QualitySheetdclassDataContext();
    public CycleTimeEntry objcycle;
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString); 
    public SqlCommand cmd;
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public  masterfile objmaster;
    DBServer objserver = new DBServer();
    DataSet ds;
    public SqlDataAdapter da;
    public PagedDataSource paging = new PagedDataSource();
    public DataTable dt;
    public int cate_comp;
    public int findex, lindex;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPart();
            BindProcess();
            getcycledata();
         
        }
    }
    private void createpaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");
        findex = CurrentPage - 5;
        if (CurrentPage >= 4)
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

    public void getcycledata()
    {
        objcycle=new CycleTimeEntry ();
        dt = new DataTable();
        objQualitySheetdclassDataContext = new QualitySheetdclassDataContext();

        //var query = (from c in (objQualitySheetdclassDataContext.CycleTimeEntries) select c).ToList();
        da=new SqlDataAdapter ("select * from CycleTimeEntry",strConnString);
        ds=new DataSet ();
        da.Fill(dt);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count>0)
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
            gridcycletime.DataSource = paging;
            gridcycletime.DataBind();
            div_cycle.Visible = true;
            div_actualerror.Visible = false;
            createpaging();
           

        }
        else
        {
            div_cycle.Visible = false;
            div_actualerror.Visible = true;
        }
    }
    private void BindPart()
    {
        ds = objserver.GetDateset("select '-Select-' Partno,'-Select-' Partno union select distinct partno,Partno from tbl_PartNo order by 1 desc");
        DropPart_cyc.DataValueField = "Partno";
        DropPart_cyc.DataTextField = "Partno";
        DropPart_cyc.DataSource = ds.Tables[0];
        DropPart_cyc.DataBind();
    }
    private void BindProcess()
    {
        ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");

        Dropprocess_cyc.DataSource = ds.Tables[0];

        Dropprocess_cyc.DataValueField = "process";
        Dropprocess_cyc.DataTextField = "process";
        Dropprocess_cyc.DataBind();
    }
   
    public void clearcontrols()
    {
        BindPart();
        BindProcess();
        Text_cycle.Value = "";
        txt_seconds.Value = "";
        
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string partno = DropPart_cyc.SelectedItem.Text.ToString();
        string process = Dropprocess_cyc.SelectedItem.Text.ToString();
        objQualitySheetdclassDataContext = new QualitySheetdclassDataContext();
        objcycle = new CycleTimeEntry();

        try
        {
            var query = (from table in objQualitySheetdclassDataContext.CycleTimeEntries where table.CPartno == DropPart_cyc.SelectedItem.Text.ToString() && table.CProcess == Dropprocess_cyc.SelectedItem.Text.ToString() select table).ToList();
            if (query.Count > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Data Already Exist !');", true);
            }
            else
            {
                objcycle.CPartno = DropPart_cyc.SelectedItem.Text.ToString();
                objcycle.CProcess = Dropprocess_cyc.SelectedItem.Text.ToString();
                if (txt_seconds.Value != "")
                {
                    double secondsc = Convert.ToInt32(txt_seconds.Value.ToString());
                    secondsc = secondsc / 60;
                    int minutes = Convert.ToInt32(Text_cycle.Value.ToString());
                    double total = Convert.ToDouble(minutes) + secondsc;
                    objcycle.CTime = Convert.ToDecimal( total.ToString());
                    objcycle.Cseconds = txt_seconds.Value.ToString();
                }
                else
                {
                    objcycle.Cseconds = "0";
                    objcycle.CTime = Convert.ToDecimal(Text_cycle.Value.ToString());
                }
                objQualitySheetdclassDataContext.CycleTimeEntries.InsertOnSubmit(objcycle);
                objQualitySheetdclassDataContext.SubmitChanges();
                
            }
        }

        catch (Exception ex)
        {
        }
        finally
        {
            clearcontrols();
            getcycledata();
            
        }
    }
    protected void btn_update_Click1(object sender, ImageClickEventArgs e)
    {
        objQualitySheetdclassDataContext = new QualitySheetdclassDataContext();
        if (hdn_cycleid.Value.ToString() != "")
        {
            int id = Convert.ToInt32(hdn_cycleid.Value);
            var query = (from table in objQualitySheetdclassDataContext.CycleTimeEntries where table.CID == id select table).FirstOrDefault();
            if (query != null)
            {
                query.CPartno = DropPart_cyc.SelectedItem.Text.ToString();
                query.CProcess = Dropprocess_cyc.SelectedItem.Text.ToString();
               // query.CTime = Convert.ToDecimal(Text_cycle.Value.ToString());
                if (txt_seconds.Value != "")
                {
                    double secondsc = Convert.ToInt32(txt_seconds.Value.ToString());
                    secondsc = secondsc / 60;
                    int minutes = Convert.ToInt32(Text_cycle.Value.ToString());
                    double total = Convert.ToDouble(minutes) + secondsc;
                    query.CTime = Convert.ToDecimal(total.ToString());
                    query.Cseconds = txt_seconds.Value.ToString();
                }

                else
                {
                    query.Cseconds = "0";
                    query.CTime = Convert.ToDecimal(Text_cycle.Value.ToString());
                }

            }
            objQualitySheetdclassDataContext.SubmitChanges();
           // div_save.Visible = true;
            //div_update.Visible = false;
            BindPart();
            BindProcess();
            getcycledata();
            clearcontrols();
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
            getcycledata();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        getcycledata();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        getcycledata();
    }
    protected void gridcycletime_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            lblSerial.Text = ((gridcycletime.PageIndex * gridcycletime.PageSize) + e.Row.RowIndex + 1).ToString();
        }
    }
}


