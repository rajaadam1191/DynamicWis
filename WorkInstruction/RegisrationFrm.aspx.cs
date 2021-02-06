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

public partial class RegisrationFrm : System.Web.UI.Page
{
    public QualitySheetdclassDataContext objContext = new QualitySheetdclassDataContext();
    public tbl_Registration objreg = new tbl_Registration();
    public DBServer objserver = new DBServer();
    public DataSet ds;
    public DataSet ds1;
    public SqlDataAdapter da;
    public PagedDataSource paging = new PagedDataSource();
    public DataTable dt;
    public int cate_comp;
    public int findex, lindex;
    public static Object thisLock = new Object();
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public QualitySheetBL objqualitysheetBL = new QualitySheetBL();
    public int pageid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_password.Value = "";
            txt_username.Value = "";
            LoadRegUser();
            
        }
    }
    private void createpaging()
    {
          lock (thisLock)
        {
        try{
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
            } catch (Exception ex)
        {
             ExceptionLogging.SendExcepToDB(ex); 
           
        }
    }
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
    public void LoadRegUser()
    {
          lock (thisLock)
        {
        try{
            objreg = new tbl_Registration();
            dt = new DataTable();
            objContext = new QualitySheetdclassDataContext();

            //var query = (from c in (objQualitySheetdclassDataContext.CycleTimeEntries) select c).ToList();
            da = new SqlDataAdapter("select * from tbl_Registration where Status='Active'", strConnString);
            ds = new DataSet();
            da.Fill(dt);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                paging.DataSource = dt.DefaultView;
                if (ds.Tables[0].Rows.Count > 10)
                {
                    paging.AllowPaging = true;
                    paging.PageSize = 10;
                    paging.CurrentPageIndex = CurrentPage;
                    ViewState["totalpage"] = paging.PageCount;
                    link_previous.Enabled = !paging.IsFirstPage;
                    link_next.Enabled = !paging.IsLastPage;
                }
                else
                {
                    div_paging.Visible = false;
                }
                grid_registration.DataSource = paging;
                grid_registration.DataBind();
                div_reg.Visible = true;
                div_actualerror.Visible = false;
                createpaging();


            }
            else
            {
                div_reg.Visible = false;
                div_actualerror.Visible = true;
            }
            } catch (Exception ex)
        {
             ExceptionLogging.SendExcepToDB(ex); 
           
        }
        }
    }
    
   

    protected void btn_update_Click(object sender, ImageClickEventArgs e)
    {
        string userrole = "";
        objContext=new QualitySheetdclassDataContext ();
        string usernam=txt_username.Value.ToString();
        try{
        if (hdn_regid.Value.ToString() != "")
        {
            int id = Convert.ToInt32(hdn_regid.Value);
            if (ddl_role.Value.ToString() == "1") { userrole = "Super Admin"; }
            if (ddl_role.Value.ToString() == "2") { userrole = "Admin"; }
            if (ddl_role.Value.ToString() == "3") { userrole = "User"; }
            var query1 = (from table in objContext.tbl_Registrations where table.Reg_Role == userrole && table.Reg_Username == usernam select table).ToList();
            
            if (query1.Count>0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Already Exist');", true);
                txt_password.Value = "";
                txt_username.Value = "";
                txtretype.Value = "";
                txt_retype.Value = "";
                ddl_role.Value = "0";
            }
            else
            {
                var query = (from table in objContext.tbl_Registrations where table.Reg_ID == id select table).FirstOrDefault();
                if (query != null)
                {
                    query.Reg_Username = txt_username.Value.ToString();
                    query.Reg_Userpassword = txtretype.Value.ToString();
                    query.Reg_Repassword = txtretype.Value.ToString();
                    query.Reg_Role = userrole.ToString();
                }
                objContext.SubmitChanges();
                LoadRegUser();
                // div_save.Visible = true;
                // div_update.Visible = false;
                txt_password.Value = "";
                txt_username.Value = "";
                txtretype.Value = "";
                txt_retype.Value = "";
                ddl_role.Value = "0";
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Data Updated Successfully');", true);
            }
        }
            } catch (Exception ex)
        {
             ExceptionLogging.SendExcepToDB(ex); 
           
        }
    }
    protected void DataListPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        LinkButton lnkPage = (LinkButton)e.Item.FindControl("link_pagebtn");
          lock (thisLock)
        {
        try{
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
            } catch (Exception ex)
        {
             ExceptionLogging.SendExcepToDB(ex); 
           
        }
    }
    }
    protected void DataListPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("newpage"))
        {
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
           LoadRegUser();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
       LoadRegUser();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
       LoadRegUser();
    }
    protected void btn_save_Click(object sender, ImageClickEventArgs e)
    {
        string result = "";
        string username = txt_username.Value.ToString();
        string password = txt_password.Value.ToString();
        string role = ddl_role.Value.ToString();
        string date = DateTime.Now.ToShortDateString().ToString();
        string repassword = txt_retype.Value.ToString();
          lock (thisLock)
        {
        try{
        result = objqualitysheetBL.save_registrationBL(username, password, role, date, repassword);
        if (result == "S")
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Saved Successfully');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Already Exist');", true);
        }
        txt_password.Value = "";
        txt_username.Value = "";
        txtretype.Value = "";
        txt_retype.Value = "";
        ddl_role.Value = "0";
        LoadRegUser();
    
        } catch (Exception ex)
        {
             ExceptionLogging.SendExcepToDB(ex); 
           
        }
    }
    }

}
