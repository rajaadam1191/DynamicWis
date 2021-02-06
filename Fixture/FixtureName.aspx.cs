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

public partial class Fixture_FixtureName : System.Web.UI.Page
{
    public static SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public DataSet ds;
    public SqlDataAdapter da;
    public SqlCommand cmd;
    public int findex, lindex, count = 0;
    public PagedDataSource paging = new PagedDataSource();
    public QualitySheetdclassDataContext objcontext = new QualitySheetdclassDataContext();
    public FixtureName objn = new FixtureName();
    public static string spltpart;
    public static string splitpartno;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "" && Session["PID_ID"] != null && Session["PID_ID"].ToString() != "")
            {
                BindPartNumber();
                BindUnit();
                BindModel();
                BindToolType();
                BindToolLine();
                Bindcell();
                loadgrid();
                BindData();
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
        }
    }
    public class Fixname
    {
        public string fixname { get; set; }
        public string partno { get; set; }
        public string fid { get; set; }
        public string unit { get; set; }
        public string line { get; set; }
        public string model { get; set; }
        public string type { get; set; }
        public string fixtureno { get; set; }
        public string cell { get; set; }
    }
    private void BindData()
    {
        ds = objserver.GetDateset("select distinct Partno from tbl_PartNo order by Partno");

        GridView2.DataSource = ds.Tables[0];
        GridView2.DataBind();
    }
    public void BindModel()
    {
        ds = objserver.GetDateset("select '0' Mvalue,'--- Select Model ---' Mtext union select distinct Mvalue,Mtext from FixtureModel");

        ddl_model.DataSource = ds.Tables[0];
        ddl_model.DataValueField = "MValue";
        ddl_model.DataTextField = "MText";
        ddl_model.DataBind();
    }
    public void loadgrid()
    {
        //da = new SqlDataAdapter("select ROW_NUMBER() over (order by FID desc) as IndexNo,* from FixtureName", strConnString);
        da = new SqlDataAdapter("select ROW_NUMBER() over (order by a.FID desc) as IndexNo,a.* from FixtureName a Left Join FixtureValues b on b.FixName =a.Fixturename where b.Status ='Active' or b.Status is null ", strConnString);

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
            grid_Fixturename.DataSource = paging;
            grid_Fixturename.DataBind();
            createpaging();
        }
        else
        {
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
    private void BindUnit()
    {
        ds = objserver.GetDateset("select '0' MValue,'--- Select Unit ---' MText union select distinct MValue,MText from UnitMastermbu");

        ddl_funit.DataSource = ds.Tables[0];

        ddl_funit.DataValueField = "MValue";
        ddl_funit.DataTextField = "MText";
        ddl_funit.DataBind();
    }
    private void BindToolType()
    {
        ds = objserver.GetDateset("select '0' TValue,'--- Select Fixture Type ---' TText union select distinct TValue,TText from ToolTypeMastermbu");

        ddl_ftooltype.DataSource = ds.Tables[0];

        ddl_ftooltype.DataValueField = "TValue";
        ddl_ftooltype.DataTextField = "TText";
        ddl_ftooltype.DataBind();
    }
    public void ddl_fixcell_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindToolLine();
    }
    private void BindToolLine()
    {
        //ds = objserver.GetDateset("select '0' LValue,'--- Select Fixture Line ---' LText union select distinct LValue,LText from LineMastermbu");

        //ddl_fline.DataSource = ds.Tables[0];

        //ddl_fline.DataValueField = "LValue";
        //ddl_fline.DataTextField = "LText";
        //ddl_fline.DataBind();

        if (ddl_fixcell.SelectedValue.ToString() != "--- Select Part Number ---" && ddl_fixcell.SelectedValue.ToString() != "" && ddl_fixcell.SelectedValue.ToString() != null)
        {
            ds = objserver.GetDateset("select 0 Id ,'--- Select Fixture Line ---' Machine union select distinct Id,Machine from Machine where Cell='" + ddl_fixcell.SelectedValue.ToString() + "' order by Id asc ");

            ddl_fline.DataSource = ds.Tables[0];

            ddl_fline.DataValueField = "Machine";
            ddl_fline.DataTextField = "Machine";
            ddl_fline.DataBind();
        }
    }
    private void Bindcell()
    {
        ds = objserver.GetDateset("select '--- Select Fixture Cell ---' Cell union select Cell from Cell");
        ddl_fixcell.DataSource = ds.Tables[0];
        ddl_fixcell.DataValueField = "Cell";
        ddl_fixcell.DataTextField = "Cell";
        ddl_fixcell.DataBind();
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

    protected void btn_Clear_Click(object sender, ImageClickEventArgs e)
    {
        BindPartNumber();
        BindUnit();
        BindModel();
        BindToolType();
        BindToolLine();
        Bindcell();
        loadgrid();
        uncheck_partno();
        txt_fixtureno.Value = "";
        ddl_fixcell.Enabled = true;
        ddl_funit.Enabled = true;
        ddl_fline.Enabled = true;
        ddl_ftooltype.Enabled = true;
        txt_fixtureno.Attributes.Remove("disabled");
        div_fistruesave.Visible = true;
        div_fistrueupdate.Visible = false;
    }
    public void uncheck_partno()
    {
        if (GridView2.Rows.Count > 0)
        {
            for (int j = 0; j < GridView2.Rows.Count; j++)
            {
                var chk = (System.Web.UI.WebControls.CheckBox)(GridView2.Rows[j].Cells[0].FindControl("CheckBox2"));
                chk.Checked = false;
            }
        }
    }
    protected void btn_submit_Click(object sender, ImageClickEventArgs e)
    {
        string oper = "";
        string partno = "";
        int extableflg = 0;
        int flgfix = 0;
        string mulpartno = string.Empty;
        string alrpartno = string.Empty;
        objcontext = new QualitySheetdclassDataContext();
        objcontext = new QualitySheetdclassDataContext();
        if (GridView2.Rows.Count > 0)
        {
            //foreach (GridViewRow row in GridView2.Rows)
            //{
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                //CheckBox cb = (CheckBox)row.("CheckBox2");
                CheckBox cb = (CheckBox)GridView2.Rows[i].FindControl("CheckBox2");
                //CheckBox ch = (CheckBox)Grdchild.Rows[Grdchild.SelectedIndex].FindControl("CheckBox1");
                if (cb != null && cb.Checked)
                {
                    var query = (from table in objcontext.FixtureNames where table.Fixturename1 == ddl_funit.SelectedValue.ToString() + "-" + ddl_ftooltype.SelectedValue.ToString() + "" + txt_fixtureno.Value.ToString() + "-" + ddl_fline.SelectedValue.ToString() && table.Partnumber.Contains(GridView2.Rows[i].Cells[1].Text) select table).FirstOrDefault();
                    if (query != null)
                    {
                        flgfix = 1;
                        alrpartno += "," + GridView2.Rows[i].Cells[1].Text;
                    }
                    else
                    {
                        mulpartno += "," + GridView2.Rows[i].Cells[1].Text;
                    }

                    var query2 = (from table in objcontext.FixtureValues where table.FixName == ddl_funit.SelectedValue.ToString() + "-" + ddl_ftooltype.SelectedValue.ToString() + "" + txt_fixtureno.Value.ToString() + "-" + ddl_fline.SelectedValue.ToString() select table).FirstOrDefault();
                    if (query2 != null)
                    {
                        oper = query2.Operation.Trim();

                        string CheckTabName = "QualitySheet_" + ddl_fixcell.SelectedValue.ToString() + "_" + GridView2.Rows[i].Cells[1].Text + "_" + oper.ToString() + "";

                        string str11 = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + CheckTabName + "'";
                        SqlCommand myCommand = new SqlCommand(str11, strConnString);
                        SqlDataReader myReader = null;
                        int count = 0;
                        // strConnString.Close();

                        try
                        {
                            if (strConnString.State == ConnectionState.Open)
                            {
                                strConnString.Close();
                            }
                            strConnString.Open();
                            myReader = myCommand.ExecuteReader();
                            while (myReader.Read())
                                count++;

                            myReader.Close();
                            strConnString.Close();
                        }
                        catch (Exception ex) { }
                        if (count == 0)
                        {
                            partno = GridView2.Rows[i].Cells[1].Text;
                            extableflg = 1;
                            break;
                        }
                    }
                    else { }
                }
            }
        }
        mulpartno = mulpartno.TrimStart(',');
        alrpartno = alrpartno.TrimStart(',');
        if (flgfix == 1)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Fixture Number Already Exist for " + alrpartno + " ');", true);
        }
        else if (extableflg == 1)
        {
            string operationname = "";
            if (oper == "1")
            {
                operationname = "Operation 1";
            }
            else if (oper == "2")
            {
                operationname = "Operation 2";
            }
            else
            {
                operationname = oper.ToString().Trim();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Quality Sheet not Created for " + partno.ToString() + "_" + operationname.ToString() + " Please Create the Sheet and then update Fixture');", true);
        }
        else if (mulpartno == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Atleast One Part No');", true);
        }
        else
        {
            objn = new FixtureName()
            {
                Fixturename1 = ddl_funit.SelectedValue.ToString() + "-" + ddl_ftooltype.SelectedValue.ToString() + "" + txt_fixtureno.Value.ToString() + "-" + ddl_fline.SelectedValue.ToString(),
                Line = ddl_fline.SelectedValue.ToString(),
                Model = ddl_model.SelectedValue.ToString(),
                CreationDate = DateTime.Now.ToShortDateString().ToString(),
                Partnumber = mulpartno.ToString(),
                Type = ddl_ftooltype.SelectedValue.ToString(),
                Unit = ddl_funit.SelectedValue.ToString(),
                Fixtrue = txt_fixtureno.Value.ToString(),
                Cell = ddl_fixcell.SelectedValue.ToString()
            };
            objcontext.FixtureNames.InsertOnSubmit(objn);
            objcontext.SubmitChanges();
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Saved Successfully');", true);
            BindPartNumber();
            BindUnit();
            BindModel();
            BindToolType();
            BindToolLine();
            Bindcell();
            loadgrid();
            BindData();
            txt_fixtureno.Value = "";
        }
    }
    protected void btn_update_Click(object sender, ImageClickEventArgs e)
    {
        string oper = "";
        string partno = "";
        int flgfix = 0;
        int extableflg = 0;
        string mulpartno = string.Empty;
        string alrpartno = string.Empty;

        var query = (from table in objcontext.FixtureNames where table.FID == Convert.ToInt32(hdn_fid.Value.ToString()) select table).First();
        if (query != null)
        {
            //mulpartno = query.Partnumber.ToString();
            if (GridView2.Rows.Count > 0)
            {
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    CheckBox cb = (CheckBox)GridView2.Rows[i].FindControl("CheckBox2");
                    if (cb != null && cb.Checked)
                    {
                        //var query1 = (from table in objcontext.FixtureNames where table.Fixturename1 == ddl_funit.SelectedValue.ToString() + "-" + ddl_ftooltype.SelectedValue.ToString() + "" + txt_fixtureno.Value.ToString() + "-" + ddl_fline.SelectedValue.ToString() && table.Partnumber.Contains(GridView2.Rows[i].Cells[1].Text) select table).FirstOrDefault();
                        //if (query1 != null)
                        //{
                        //    //flgfix = 1;
                        //    //alrpartno += "," + GridView2.Rows[i].Cells[1].Text;
                        //}
                        //else
                        //{
                            mulpartno += "," + GridView2.Rows[i].Cells[1].Text;
                        //}
                        var query2 = (from table in objcontext.FixtureValues where table.FixName == ddl_funit.SelectedValue.ToString() + "-" + ddl_ftooltype.SelectedValue.ToString() + "" + txt_fixtureno.Value.ToString() + "-" + ddl_fline.SelectedValue.ToString() select table).FirstOrDefault();
                        if (query2 != null)
                        {
                            oper = query2.Operation.Trim();

                            string CheckTabName = "QualitySheet_" + ddl_fixcell.SelectedValue.ToString() + "_" + GridView2.Rows[i].Cells[1].Text + "_" + oper.ToString() + "";

                            string str11 = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + CheckTabName + "'";
                            SqlCommand myCommand = new SqlCommand(str11, strConnString);
                            SqlDataReader myReader = null;
                            int count = 0;
                            // strConnString.Close();

                            try
                            {
                                if (strConnString.State == ConnectionState.Open)
                                {
                                    strConnString.Close();
                                }
                                strConnString.Open();
                                myReader = myCommand.ExecuteReader();
                                while (myReader.Read())
                                    count++;

                                myReader.Close();
                                strConnString.Close();
                            }
                            catch (Exception ex) { }
                            if (count == 0)
                            {
                                partno = GridView2.Rows[i].Cells[1].Text;
                                extableflg = 1;
                                break;
                            }
                        }
                        else { }
                    }
                }
            }
            mulpartno = mulpartno.TrimStart(',');
            alrpartno = alrpartno.TrimStart(',');
            if (flgfix == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Fixture Number Already Exist for " + alrpartno + " ');", true);
            }
            else if (extableflg == 1)
            {
                string operationname = "";
                if (oper == "1")
                {
                    operationname = "Operation 1";
                }
                else if (oper == "2")
                {
                    operationname = "Operation 2";
                }
                else
                {
                    operationname = oper.ToString().Trim();
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Quality Sheet not Created for " + partno.ToString() + "_" + operationname.ToString() + " Please Create the Sheet and then update Fixture');", true);
            }
            else
            {
                query.Fixturename1 = ddl_funit.SelectedValue.ToString() + "-" + ddl_ftooltype.SelectedValue.ToString() + "" + txt_fixtureno.Value.ToString() + "-" + ddl_fline.SelectedValue.ToString();
                query.Line = ddl_fline.SelectedValue.ToString();
                query.Model = ddl_model.SelectedValue.ToString();
                query.Partnumber = mulpartno.ToString();
                query.Type = ddl_ftooltype.SelectedValue.ToString();
                query.Unit = ddl_funit.SelectedValue.ToString();
                query.Fixtrue = txt_fixtureno.Value.ToString();
                query.Cell = ddl_fixcell.SelectedValue.ToString();
                objcontext.SubmitChanges();
                BindPartNumber();
                BindUnit();
                BindModel();
                BindToolType();
                BindToolLine();
                Bindcell();
                loadgrid();
                BindData();
                uncheck_partno();
                txt_fixtureno.Value = "";
                ddl_fixcell.Enabled = true;
                ddl_funit.Enabled = true;
                ddl_fline.Enabled = true;
                ddl_ftooltype.Enabled = true;
                txt_fixtureno.Attributes.Remove("disabled");
                div_fistruesave.Visible = true;
                div_fistrueupdate.Visible = false;
            }
        }
        else
        {
        }
    }

    [WebMethod]
    public static Fixname[] editfixname(string ID)
    {
       
        string s = "";
        List<Fixname> objf = new List<Fixname>();
        Fixname objfix = new Fixname();
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from FixtureName where FID='" + Convert.ToInt32(ID) + "'", strConnString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objfix = new Fixname();
                    objfix.fixname = ds.Tables[0].Rows[i]["Fixturename"].ToString();
                    objfix.partno = ds.Tables[0].Rows[i]["Partnumber"].ToString();
                    objfix.fid = ds.Tables[0].Rows[i]["FID"].ToString();
                    objfix.unit = ds.Tables[0].Rows[i]["Unit"].ToString();
                    objfix.line = ds.Tables[0].Rows[i]["Line"].ToString();
                    objfix.model = ds.Tables[0].Rows[i]["Model"].ToString();
                    objfix.type = ds.Tables[0].Rows[i]["Type"].ToString();
                    objfix.fixtureno = ds.Tables[0].Rows[i]["Fixtrue"].ToString();
                    objfix.cell = ds.Tables[0].Rows[i]["Cell"].ToString();
                    objf.Add(objfix);
                    splitpartno = ds.Tables[0].Rows[i]["Partnumber"].ToString();
                }

                //check(splitpartno);
                // string[] spltpartno = spltpart.Split(',');
                //for (int i = 0; i < splitpartno.Length; i++)
                //{
                //    GridViewRow row = GridView2.Rows[e.RowIndex];
                //    String courseNo = splitpartno[i].Trim();
                //    //System.Diagnostics.Debug.Print("Course No :"+courseNo+"\n");

                //    for (int j = 0; j < row.Count; j++)
                //    {
                //        //System.Diagnostics.Debug.Print("Row Value = " + gridview_modules.Rows[j].Cells[1].ToString() + "List value = " + courseNo + "\n");
                //        //if (row.Rows[j].Cells[1].Text == courseNo)
                //        //{
                //        //    var chk = (System.Web.UI.WebControls.CheckBox)(row.Rows[j].Cells[0].FindControl("CheckBox2"));
                //        //    chk.Checked = true;
                //        //}
                //    }
                //}
            }
            else
            {
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return objf.ToArray();
    }

    public void check(string strPartno)
    {

        string[] spltpartno = strPartno.Split(',');
        try
        {
            for (int i = 0; i < spltpartno.Length; i++)
            {
                //Page page = (Page)HttpContext.Current.Handler;
                //GridView grdview = (GridView)page.FindControl("GridView2");
                //String courseNo = spltpartno[i].Trim();
                ////System.Diagnostics.Debug.Print("Course No :"+courseNo+"\n");

                //for (int j = 0; j < grdview.Rows.Count; j++)
                //{
                //    //System.Diagnostics.Debug.Print("Row Value = " + gridview_modules.Rows[j].Cells[1].ToString() + "List value = " + courseNo + "\n");
                //    if (grdview.Rows[j].Cells[1].Text == courseNo)
                //    {
                //        var chk = (System.Web.UI.WebControls.CheckBox)(grdview.Rows[j].Cells[0].FindControl("CheckBox2"));
                //        chk.Checked = true;
                //    }
                //}

                string partNo = spltpartno[i].Trim();
                if (GridView2.Rows.Count > 0)
                {
                    for (int j = 0; j < GridView2.Rows.Count; j++)
                    {
                        //System.Diagnostics.Debug.Print("Row Value = " + gridview_modules.Rows[j].Cells[1].ToString() + "List value = " + courseNo + "\n");
                        if (GridView2.Rows[j].Cells[1].Text == partNo)
                        {
                            var chk = (System.Web.UI.WebControls.CheckBox)(GridView2.Rows[j].Cells[0].FindControl("CheckBox2"));
                            chk.Checked = true;
                        }
                    }
                }
            }
        }
        catch(Exception ex)
        {

        }
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        //GridView1.EditIndex = e.NewEditIndex;
        //this.BindGrid();
        try
        {
            Label lbl_id = grid_Fixturename.Rows[e.NewEditIndex].FindControl("lbl_id") as Label;
            int ID = Convert.ToInt32(lbl_id.Text);
            if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from FixtureName where FID='" + Convert.ToInt32(ID) + "'", strConnString);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //objfix.fixname = ds.Tables[0].Rows[i]["Fixturename"].ToString();
                        splitpartno = ds.Tables[0].Rows[i]["Partnumber"].ToString();
                        hdn_fid.Value = ds.Tables[0].Rows[i]["FID"].ToString();
                        ddl_funit.SelectedValue = ds.Tables[0].Rows[i]["Unit"].ToString();
                        
                        ddl_model.SelectedValue = ds.Tables[0].Rows[i]["Model"].ToString();
                        ddl_ftooltype.SelectedValue = ds.Tables[0].Rows[i]["Type"].ToString();
                        txt_fixtureno.Value = ds.Tables[0].Rows[i]["Fixtrue"].ToString();
                        ddl_fixcell.SelectedValue = ds.Tables[0].Rows[i]["Cell"].ToString();
                        BindToolLine();
                        ddl_fline.SelectedValue = ds.Tables[0].Rows[i]["Line"].ToString();
                    }
                    ddl_fixcell.Enabled = false;
                    ddl_funit.Enabled = false;
                    ddl_fline.Enabled = false;
                    ddl_ftooltype.Enabled = false;
                    txt_fixtureno.Attributes.Add("disabled", "disabled");
                    div_fistruesave.Visible = false;
                    div_fistrueupdate.Visible = true;
                    uncheck_partno();
                    check(splitpartno);
                }
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }

    protected void OnRowCancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //GridView1.EditIndex = -1;
        //this.BindGrid();
    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string s = "";
        List<Fixname> objf = new List<Fixname>();
        Fixname objfix = new Fixname();
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from FixtureName where FID='" + Convert.ToInt32(ID) + "'", strConnString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objfix = new Fixname();
                    objfix.fixname = ds.Tables[0].Rows[i]["Fixturename"].ToString();
                    objfix.partno = ds.Tables[0].Rows[i]["Partnumber"].ToString();
                    objfix.fid = ds.Tables[0].Rows[i]["FID"].ToString();
                    objfix.unit = ds.Tables[0].Rows[i]["Unit"].ToString();
                    objfix.line = ds.Tables[0].Rows[i]["Line"].ToString();
                    objfix.model = ds.Tables[0].Rows[i]["Model"].ToString();
                    objfix.type = ds.Tables[0].Rows[i]["Type"].ToString();
                    objfix.fixtureno = ds.Tables[0].Rows[i]["Fixtrue"].ToString();
                    objfix.cell = ds.Tables[0].Rows[i]["Cell"].ToString();
                    objf.Add(objfix);
                    splitpartno = ds.Tables[0].Rows[i]["Partnumber"].ToString();
                }
             //   string[] splitpartno1 = splitpartno;
                //for (int i = 0; i < splitpartno1.Length; i++)
                //{
                    GridViewRow row = GridView2.Rows[e.RowIndex];
                    String courseNo = splitpartno;//splitpartno1[i].Trim();
                    //System.Diagnostics.Debug.Print("Course No :"+courseNo+"\n");

                    for (int j = 0; j < GridView2.Rows.Count; j++)
                    {
                        //System.Diagnostics.Debug.Print("Row Value = " + gridview_modules.Rows[j].Cells[1].ToString() + "List value = " + courseNo + "\n");
                        //if (row.Rows[j].Cells[1].Text == courseNo)
                        //{
                        //    var chk = (System.Web.UI.WebControls.CheckBox)(row.Rows[j].Cells[0].FindControl("CheckBox2"));
                        //    chk.Checked = true;
                        //}
                    }
                //}
            }
        }
        else
        {
            Response.Redirect("~/Home.aspx");
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    CheckBox chk = (CheckBox)e.Row.FindControl("CheckBox2");
        //    if (e.Row.Cells[1].Text == "Chennai")
        //    {
        //        chk.Enabled = false;
        //    }
        //    else
        //    {
        //        chk.Enabled = true;
        //    }
        //}
    }
}

       
    

