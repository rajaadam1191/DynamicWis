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
using System.Data.SqlClient;
using System.Xml.Linq;
using System.IO;
using System.Drawing;

public partial class Time_Master : System.Web.UI.Page
{
   
    public QualitySheetdclassDataContext objcontext;
    public TimeMaster objtime;
        DBServer objserver = new DBServer();

        public PagedDataSource paging = new PagedDataSource();
        public DataTable dt;
        public int cate_comp;
        public SqlDataAdapter da;
        public int findex, lindex;

    private String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    DataSet ds, ds1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindProcess();
            BindPartNO();
            BindTimeMaster();
            checkbrowser();
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

    public void BindPartNO()
    {
        ds = objserver.GetDateset("select '-Select-' partno,'-Select-' partno union select distinct partno,partno from tbl_PartNo order by 1 desc");
        DropPartNo.DataSource = ds.Tables[0];
        DropPartNo.DataValueField = "partno";
        DropPartNo.DataTextField = "partno";
        DropPartNo.DataBind();
    }

    public void BindProcess()
    {

        ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");
        DropOperation.DataSource = ds.Tables[0];
        DropOperation.DataValueField = "Process";
        DropOperation.DataTextField = "Process";
        DropOperation.DataBind();
    }
    public void BindTimeMaster()
    {
            dt = new DataTable();
            DataSet ds = new DataSet();
            objtime = new TimeMaster();
            da = new SqlDataAdapter("select * from TimeMaster", strConnString);

            //ds = objserver.GetDateset("select * from laborefficiency");
            da.Fill(dt);
            da.Fill(ds);
            //Grid_plan.DataSource = ds.Tables[0];
                //Grid_plan.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                  
                        paging.DataSource = dt.DefaultView;
                        if (ds.Tables[0].Rows.Count >8)
                        {
                            paging.AllowPaging = true;
                            paging.PageSize = 8;
                            paging.CurrentPageIndex = CurrentPage;
                            ViewState["totalpage"] = paging.PageCount;
                            link_previous.Enabled = !paging.IsFirstPage;
                            link_next.Enabled = !paging.IsLastPage;
                        }
                        else{
                            div_paging.Visible = false;
                        }
                        gridTimemaster.DataSource = paging;
                        gridTimemaster.DataBind();
                        div_time.Visible = true;
                        div_actualerror.Visible = false;
                        createpaging();
                    

                }
            
            else
            {
                div_time.Visible = false;
                div_actualerror.Visible = true;
            }

        }
    



    //protected void btn_save_Click(object sender, EventArgs e)
    //{
    //    conn.Open();
    //    try
    //    {
    //        string filepath = "";
    //        string directoryPath = "";
    //        string productID = DropPartNo.SelectedValue.ToString();
    //        if (fup_file.PostedFile.FileName == "")
    //        {
    //            filepath = "";
    //        }
    //        else
    //        {
    //            directoryPath = Server.MapPath("~/TimeMaster/" + productID + "/" + DropOperation.SelectedItem + "/");
    //            if (!Directory.Exists(directoryPath))
    //            {
    //                Directory.CreateDirectory(directoryPath);
    //            }
    //            string strFile = DateTime.Now.ToString("dd_MMM_yyhhmm") + "_" + System.IO.Path.GetFileName(fup_file.PostedFile.FileName);
    //            fup_file.PostedFile.SaveAs((directoryPath + strFile));
    //            filepath = directoryPath + strFile;
    //        }
    //        using (SqlCommand cmd = new SqlCommand())
    //        {

    //            cmd.Connection = conn;
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.CommandText = "InsertTimeMaster";
    //            cmd.Parameters.AddWithValue("@partno", DropPartNo.Text.Trim());
    //            cmd.Parameters.AddWithValue("@operation", DropOperation.Text.Trim());
    //            cmd.Parameters.AddWithValue("@bottlenecktime", TxtBottleNeckTime.Text.Trim());
    //            cmd.Parameters.AddWithValue("@tt", TxtTt.Text.Trim());
    //            cmd.ExecuteNonQuery();
    //            BindTimeMaster();
    //            Clear();
    //            //gridTimemaster.DataBind();

    //            // gridTimemaster.DataSource = ds.Tables[0];
    //            //  gridTimemaster.DataBind();
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Saved Successfully');", true);
    //            clearcontrols();
    //            // popup.Hide();
    //        }

    //    }

    //    catch (Exception ex)
    //    {
    //        // lblresult.Text = ex.Message;
    //        //  if (lblresult.Text == "An invalid parameter or option was specified for procedure 'MobileNo already Exists'.")
    //        //  {

    //        // lblresult.Text = "MobileNo already Exists";
    //        // }
    //    }

    //}
    protected void gridTimemaster_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        BindPartNO();
        DropPartNo.Text = gridTimemaster.SelectedRow.Cells[3].Text;
        BindProcess();
        DropOperation.Text = gridTimemaster.SelectedRow.Cells[4].Text;
        TxtBottleNeckTime.Text = gridTimemaster.SelectedRow.Cells[5].Text;
        TxtTt.Text = gridTimemaster.SelectedRow.Cells[6].Text;

    }



    protected void gridTimemaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DeleteMethod();
        clearcontrols();
    }
    private void DeleteMethod()
    {

        objserver.GetDateset("delete from TimeMaster where partno='" + DropPartNo.Text + "' ");
        lblresult.ForeColor = Color.Red;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Detail Deleted Successfully ');", true);
        BindTimeMaster();
        Clear();

    }

    protected void gridTimemaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        UploadMethod();
        clearcontrols();
    }
        private void UploadMethod()
        {
            objserver.GetDateset("update TimeMaster set PartNo='" + DropPartNo.Text + "',Operation='" + DropOperation.Text + "',BottleNecktime ='" + TxtBottleNeckTime.Text + "', tt='" + TxtTt.Text + "' where PartNo='" + DropPartNo.Text + "' ");
        lblresult.ForeColor = Color.Red;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Detail Upload Successfully ');", true);
        BindTimeMaster();
        Clear();
    }
    private void Clear()
    {
        TxtBottleNeckTime.Text = "0.00";
        TxtTt.Text = "0.00";
     //   lblresult.Text = "";
    }
    public void checkbrowser()
    {
        string browser = Request.Browser.Browser.ToString();

        hdn_browser.Value = browser.ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "checkbrowser('" + browser + "');", true);
    }
    public void clearcontrols()
    {
        BindProcess();
        BindPartNO();
        TxtBottleNeckTime.Text = "";
        TxtTt.Text = "";
    }
    protected void btn_update_Click(object sender, ImageClickEventArgs e)
    {
        objcontext = new QualitySheetdclassDataContext();
        if (hdn_timeid.Value.ToString() != "")
        {
            int id = Convert.ToInt32(hdn_timeid.Value);
            var query = (from table in objcontext.TimeMasters where table.ID == id select table).FirstOrDefault();
            if (query != null)
            {
                query.PartNo = DropPartNo.SelectedItem.Text.ToString();
                query.Operation = DropOperation.SelectedItem.Text.ToString();
                query.BottleNecktime = Convert.ToDecimal(TxtBottleNeckTime.Text.ToString());
                query.tt = Convert.ToDecimal(TxtTt.Text.ToString());

            }
            objcontext.SubmitChanges();
            //div_save.Visible = true;
            //div_update.Visible = false;
            BindProcess();
            BindPartNO();
            BindTimeMaster();
            checkbrowser();
            TxtTt.Text = "";
            TxtBottleNeckTime.Text = "";
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Data Updated Successfully');", true);
        }
    }
    protected void btn_save_Click(object sender, ImageClickEventArgs e)
    {
            conn.Open();
            try
            {
                string filepath = "";
                string directoryPath = "";
                string productID = DropPartNo.SelectedValue.ToString();
                if (fup_file.PostedFile.FileName == "")
                {
                    filepath = "";
                }
                else
                {
                    directoryPath = Server.MapPath("~/TimeMaster/" + productID + "/" + DropOperation.SelectedItem + "/");
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    string strFile = DateTime.Now.ToString("dd_MMM_yyhhmm") + "_" + System.IO.Path.GetFileName(fup_file.PostedFile.FileName);
                    fup_file.PostedFile.SaveAs((directoryPath + strFile));
                    filepath = directoryPath + strFile;
                }
                //using (SqlCommand cmd = new SqlCommand())
                //{

                //    cmd.Connection = conn;
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.CommandText = "InsertTimeMaster";
                //    cmd.Parameters.AddWithValue("@partno", DropPartNo.Text.Trim());
                //    cmd.Parameters.AddWithValue("@operation", DropOperation.Text.Trim());
                //    cmd.Parameters.AddWithValue("@bottlenecktime", TxtBottleNeckTime.Text.Trim());
                //    cmd.Parameters.AddWithValue("@tt", TxtTt.Text.Trim());
                //    cmd.ExecuteNonQuery();
                //    BindTimeMaster();
                //    Clear();
                //    //gridTimemaster.DataBind();

                //    // gridTimemaster.DataSource = ds.Tables[0];
                //    //  gridTimemaster.DataBind();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Saved Successfully');", true);
                //    clearcontrols();
                //    // popup.Hide();


                    
                        objtime = new TimeMaster();
                        objcontext = new QualitySheetdclassDataContext();

                        ds = objserver.GetDateset("select * from TimeMaster where PartNo='" + DropPartNo.Text.ToString() + "' and Operation='" + DropOperation.Text.ToString() + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                var query = (from table in objcontext.TimeMasters where table.PartNo == DropPartNo.Text.ToString() select table).FirstOrDefault();
                                if (query != null)
                                {
                                    query.PartNo = DropPartNo.Text.ToString();
                                    query.Operation = DropOperation.Text.ToString();
                                    query.BottleNecktime = Convert.ToDecimal(TxtBottleNeckTime.Text.ToString());
                                    query.tt = Convert.ToDecimal(TxtTt.Text.ToString());
                                  
                                    objcontext.SubmitChanges();
                                    clearcontrols();
                                    BindTimeMaster();
                                }
                            }
                            else
                            {
                                objtime.PartNo = DropPartNo.Text.ToString();
                                objtime.Operation = DropOperation.Text.ToString();
                                objtime.BottleNecktime = Convert.ToDecimal(TxtBottleNeckTime.Text.ToString());
                                objtime.tt = Convert.ToDecimal(TxtTt.Text.ToString());
                               
                                objcontext.TimeMasters.InsertOnSubmit(objtime);
                                objcontext.SubmitChanges();

                                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Data Submitted Successfuly !');", true);
                                clearcontrols();
                                BindTimeMaster();
                            }

                        }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {

                        }

                    }



                

            

            //catch (Exception ex)
            //{
            //    // lblresult.Text = ex.Message;
            //    //  if (lblresult.Text == "An invalid parameter or option was specified for procedure 'MobileNo already Exists'.")
            //    //  {

            //    // lblresult.Text = "MobileNo already Exists";
            //    // }
            //}

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
           BindTimeMaster();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
       BindTimeMaster();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
       BindTimeMaster();
    }

    
}
