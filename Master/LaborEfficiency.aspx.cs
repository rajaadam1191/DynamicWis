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

public partial class LaborEfficiency : System.Web.UI.Page
{
    public QualitySheetdclassDataContext objQualitySheetdclassDataContext = new QualitySheetdclassDataContext();
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString); 

    public laborefficiency objlaboreff = new laborefficiency();
    public DBServer objserver = new DBServer();
    public PagedDataSource paging = new PagedDataSource();
    public DataTable dt;
    public DataSet ds;
    public int cate_comp;
    public SqlDataAdapter da;
    public int findex, lindex;

    string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ToString();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_date.Value = DateTime.Now.ToShortDateString().ToString();
            //var selMon = txt_date.getMonth();
            //var selYear = startDate.getYear();
            Loadplan();
           
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

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string strDate = txt_date.Value.ToString(); //Format – dd/MM/yyyy
        //split string date by separator, here I'm using '/'
        string[] arrDate = strDate.Split('/');

        //now use array to get specific date object
        string  month = arrDate[0].ToString();
        string month1 = arrDate[0].ToString();

        if (month == "01")
        {
            month = "Jan";
         
        }
        else if (month == "02")
        {
            month = "Feb";
        }
        else if (month == "03")
        {
            month = "Mar";
        }
        else if (month == "04")
        {
            month = "Apr";
        }
        else if (month == "05")
        {
            month = "May";
        }
        else if (month == "06")
        {
            month = "Jun";
        }
        else if (month == "07")
        {
            month = "Jul";
        }
        else if (month == "08")
        {
            month = "Aug";
        }
        else if (month == "09")
        {
            month = "Sep";
        }
        else if (month == "10")
        {
            month = "Oct";
           
        }
        else if (month == "11")
        {
            month = "Nov";
        }
        else if (month == "12")
        {

            month = "Dec";
        }
        else
        {
        }
        int num = 07;
        int num1 = 14;
        int num2 = 21;
        int num3 = 28;
       int day = Convert.ToInt32(arrDate[1].ToString());
        string day1 = arrDate[1].ToString();

        if (Convert.ToInt32(day)<= Convert.ToInt32(num))
        {
            day1 = "week1";
        }
        else if ((Convert.ToInt32(day) >= Convert.ToInt32(num)) && (Convert.ToInt32(day) <= Convert.ToInt32(num1)))
        {
            day1 = "week2";
        }
        else if ((Convert.ToInt32(day) >= Convert.ToInt32(num)) && (Convert.ToInt32(day) >= Convert.ToInt32(num1)) && (Convert.ToInt32(day) <= Convert.ToInt32(num2)))
        {
            day1 = "week3";
        }
        else if ((Convert.ToInt32(day) >= Convert.ToInt32(num)) && (Convert.ToInt32(day) >= Convert.ToInt32(num1)) && (Convert.ToInt32(day) >= Convert.ToInt32(num2)) && (Convert.ToInt32(day) <= Convert.ToInt32(num3)))
        {
            day1 = "week4";
        }
        string year = arrDate[2].ToString();

        objlaboreff = new laborefficiency();
        objlaboreff.LDate = txt_date.Value.ToString();
        objlaboreff.Lmonth_num = month1.ToString();

        objlaboreff.Lmonth = month.ToString();
        objlaboreff.Lday = day.ToString();
        objlaboreff.Lweek = day1.ToString();

        objlaboreff.Lyear = year.ToString();

        objlaboreff.Lshift = ddl_shift.SelectedItem.Text.ToString();
        objlaboreff.earn_time = Text_earn.Value.ToString();
        objlaboreff.actual_time = Text_actual.Value.ToString();
        objlaboreff.unit  = ddl_unit_LBeff.Text.ToString();
        objlaboreff.MachineName = Slct_machine_eff_LE.Value.ToString();
        if (ttl_tim.Value != "")
        {
            objlaboreff.total_time = Convert.ToInt32(ttl_tim.Value.ToString());
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "actualtym();", true);
            return;
            //ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert(' !');", true);
           
        }

        objQualitySheetdclassDataContext.laborefficiencies.InsertOnSubmit(objlaboreff);
        objQualitySheetdclassDataContext.SubmitChanges();
        objQualitySheetdclassDataContext = null;
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Data Submitted Successfuly !');", true);
        clear();
        Loadplan();
    }
    private void clear()
    {
        ddl_shift.SelectedValue = "-Select-";
        Text_earn.Value = "";
        Text_actual.Value = "";
        ttl_tim.Value = "";
        txt_date.Value = "";
    }
    public void Loadplan()
    {
        dt = new DataTable();
        DataSet ds = new DataSet();
        objlaboreff = new laborefficiency();
        da = new SqlDataAdapter("select * from laborefficiency", strConnString);

        //ds = objserver.GetDateset("select * from laborefficiency");
        da.Fill(dt);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //Grid_plan.DataSource = ds.Tables[0];
            //Grid_plan.DataBind();
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
                Grid_lbr.DataSource = paging;
                Grid_lbr.DataBind();
                div_labr.Visible = true;
                div_actualerror.Visible = false;
                createpaging();


            }
        }
        else
        {
            div_labr.Visible = false;
            div_actualerror.Visible = true;
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
            Loadplan();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        Loadplan();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        Loadplan();
    }
    protected void onselectedindexchanged_laboreff(object sender, EventArgs e)
    {
        string unit = ddl_unit_LBeff.Text.ToString();
        if (unit == "MBU")
        {
            ds = objserver.GetDateset("select '-Select-' MBU,'-Select-' MBU union select distinct MBU,MBU from Machine_rpt_tble order by 1 asc");

          Slct_machine_eff_LE.DataSource = ds.Tables[0];

          Slct_machine_eff_LE.DataValueField = "MBU";
          Slct_machine_eff_LE.DataTextField = "MBU";
          Slct_machine_eff_LE.DataBind();
        }
        else if (unit == "ABU")
        {
            ds = objserver.GetDateset("select '-Select-' ABU,'-Select-' ABU union select distinct ABU,ABU from Machine_rpt_tble order by 1 asc");

          Slct_machine_eff_LE.DataSource = ds.Tables[0];

          Slct_machine_eff_LE.DataValueField = "ABU";
          Slct_machine_eff_LE.DataTextField = "ABU";
          Slct_machine_eff_LE.DataBind();
        }
        //else if (unit == "ALL")
        //{
        //    ds = objserver.GetDateset("SELECT '-Select-' ALLRPT,'-Select-' ALLRPT union select distinct MBU,MBU  as ALLRPT FROM Machine_rpt_tble where MBU<>'' UNION ALL SELECT '-Select-' ALLRPT,'-Select-' ALLRPT  union select distinct ABU,ABU  as ALLRPT   FROM Machine_rpt_tble where ABU<>'' ");
        //  Slct_machine_eff_LE.DataSource = ds.Tables[0];

        //  Slct_machine_eff_LE.DataValueField = "ALLRPT";
        //  Slct_machine_eff_LE.DataTextField = "ALLRPT";
        //  Slct_machine_eff_LE.DataBind();
        //}
    }

}
