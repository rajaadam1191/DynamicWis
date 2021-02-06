
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

public partial class Workinstruction : System.Web.UI.Page
{
    private String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    public SqlConnection strConnString1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    DBServer objserver = new DBServer();
    DataSet ds;
    public SqlCommand cmd;
    public string strFile = "", mode = "";
    public static Object thisLock = new Object();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User_Role"] != null && Session["User_Role"].ToString() != "")
            {
                show_link();
                BindData();
                if (Session["User_Role"].ToString().ToLower() == "admin")
                {
                    div_user.Visible = false;
                    div_admin.Visible = true;
                    super_admin.Visible = false;
                }
                if (Session["User_Role"].ToString().ToLower() == "user")
                {
                    div_user.Visible = true;
                    div_admin.Visible = false;
                    super_admin.Visible = false;

                }
                if (Session["User_Role"].ToString().ToLower() == "super admin")
                {
                    div_user.Visible = false;
                    div_admin.Visible = false;
                    super_admin.Visible = true;
                    Showadminlink();

                }
            }

            else
            {
                Response.Redirect("../Home.aspx");
            }
        }

    }
    public void show_link()
    {
        lock (thisLock)
        {
            try
            {
                if (Session["User_Role"].ToString().ToLower() == "user")
                {
                    objqualitysheetbl.showprodataBL(link_productiondata, Session["User_Role"].ToString(), Session["PartNo"].ToString(), Session["Operation"].ToString());
                }
                sp_logdate.InnerText = Session["LogDate"].ToString();
                sp_logtimr.InnerText = Session["Logtime"].ToString();
                sp_username.InnerText = Session["User_Name"].ToString();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
        }
    }
    public void Showadminlink()
    {
       // objqualitysheetbl.show_Access_RightsBL(link_24q, link_6j, link_1c, link_8n, link_3u, link_process, link_part, link_work, link_userpage, link_time, link_laping24, link_opt24, link_poli24, link_chart, link_register, link_dmttemp, link_opt2j, link_poliJ, link_polc, link_polu, link_poln, link_planned, link_barcode, link_addpages, Session["PID_ID"].ToString());
    }
   
    private void BindData()
    {
        lock (thisLock)
        {
            try
            {
                ds = objserver.GetDateset("select distinct Partno,Description from tbl_PartNo");

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
        }
    }
    private void BindProcess()
    {
        lock (thisLock)
        {
            try
            {
                ds = objserver.GetDateset("select '0' PID,'-Select-' Process union select distinct PID,Process from tbl_Process order by PID");
                DropProcess.DataValueField = "PID";
                DropProcess.DataTextField = "Process";
                DropProcess.DataSource = ds.Tables[0];
                DropProcess.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
        }

    }
    private void GetData(SqlCommand cmd)
    {
        lock (thisLock)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        con.Open();
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);

                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
        }
    }
    protected void Save(object sender, EventArgs e)
    {
        lock (thisLock)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertWI";

                    cmd.Parameters.AddWithValue("@Type", this.DropType.Text.Trim());

                    cmd.Parameters.AddWithValue("@PID", DropProcess.SelectedValue);

                    //string serverMap = Server.MapPath("~/upload/" + strFile);

                    cmd.Parameters.AddWithValue("@LoginID", 0);

                    this.GetData(cmd);
                }
                if (GridView1.Rows.Count > 0)
                {
                    //foreach (GridViewRow row in GridView1.Rows)
                    //{
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        //CheckBox cb = (CheckBox)row.("CheckBox2");
                        CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("CheckBox2");
                        //CheckBox ch = (CheckBox)Grdchild.Rows[Grdchild.SelectedIndex].FindControl("CheckBox1");
                        if (cb != null && cb.Checked)
                        {
                            string filepath = "";
                            string directoryPath;
                            //string productID =(GridView1.DataKeys[row.RowIndex].Value);


                            string productID = GridView1.Rows[i].Cells[1].Text;

                            if (FileUpload1.PostedFile.FileName == "")
                            {
                                // FileUpload1.SaveAs(Server.MapPath("~/upload/" + strFile));
                                filepath = "";
                            }
                            else
                            {
                                if (DropType.Text == "1")
                                {
                                    directoryPath = Server.MapPath("~/uploads/" + productID + "/" + DropType.SelectedItem + "/" + DropProcess.SelectedItem + "/");
                                    DropProcess.Enabled = true;
                                }
                                else
                                {
                                    DropProcess.Enabled = false;
                                    directoryPath = Server.MapPath("~/uploads/" + productID + "/" + DropType.SelectedItem + "/");
                                }
                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }
                                strFile = DateTime.Now.ToString("dd_MMM_yyhhmm") + "_" + (FileUpload1.PostedFile.FileName);
                                FileUpload1.SaveAs((directoryPath + strFile));
                                filepath = directoryPath + strFile;
                            }

                            // objserver.GetDateset(" '" + productID + "','" + filepath + "' , '" + DropType.SelectedItem + "','" + DropProcess.SelectedItem + "','" + strFile + "'");

                            BindData();
                            BindProcess();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Uploaded Successfully');", true);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
        }
            
        }
    protected void DropType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lock (thisLock)
        {
            try
            {
                if (DropType.SelectedItem.Text == "Work Instruction")
                {
                    DropProcess.Enabled = true;
                    BindProcess();
                }

                else
                {
                    BindProcess();
                    DropProcess.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
        }
    }
                        
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        lock (thisLock)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertWI";

                    cmd.Parameters.AddWithValue("@Type", this.DropType.Text.Trim());

                    cmd.Parameters.AddWithValue("@PID", DropProcess.SelectedValue);

                    //string serverMap = Server.MapPath("~/upload/" + strFile);

                    cmd.Parameters.AddWithValue("@LoginID", 0);

                    this.GetData(cmd);
                }
                if (GridView1.Rows.Count > 0)
                {
                    //foreach (GridViewRow row in GridView1.Rows)
                    //{
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        //CheckBox cb = (CheckBox)row.("CheckBox2");
                        CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("ch_workinstruction");
                        //CheckBox ch = (CheckBox)Grdchild.Rows[Grdchild.SelectedIndex].FindControl("CheckBox1");
                        if (cb != null && cb.Checked)
                        {
                            hdn_file.Value = "1";
                            string filepath = "";
                            string directoryPath;
                            //string productID =(GridView1.DataKeys[row.RowIndex].Value);


                            string productID = GridView1.Rows[i].Cells[1].Text;
                            if (FileUpload1.PostedFile.FileName == "")
                            {
                                // FileUpload1.SaveAs(Server.MapPath("~/upload/" + strFile));
                                filepath = "";
                            }
                            else
                            {
                                if (DropType.Text == "1")
                                {
                                    directoryPath = Server.MapPath("~/uploads/" + productID + "/" + DropType.SelectedItem + "/" + DropProcess.SelectedItem + "/");
                                    DropProcess.Enabled = true;
                                }
                                else
                                {
                                    DropProcess.Enabled = false;
                                    directoryPath = Server.MapPath("~/uploads/" + productID + "/" + DropType.SelectedItem + "/");
                                }
                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }
                                strFile = DateTime.Now.ToString("dd_MMM_yy") + "_" + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                                FileUpload1.PostedFile.SaveAs(directoryPath + strFile);
                                filepath = directoryPath + strFile;
                                try
                                {
                                    ds = objserver.GetDateset(" select * from tbl_WIPart where PartNo='" + productID + "' and process='" + DropProcess.SelectedItem + "' and SourceName='" + strFile + "'");
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        mode = "U";
                                    }
                                    else
                                    {
                                        mode = "I";
                                    }
                                    cmd = new SqlCommand("InsertWIPart", strConnString1);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@PartNo", SqlDbType.VarChar, 50).Value = productID.ToString();
                                    cmd.Parameters.Add("@FilePath", SqlDbType.VarChar, 500).Value = filepath.ToString();
                                    cmd.Parameters.Add("@type", SqlDbType.VarChar, 50).Value = DropType.SelectedItem.Text.ToString();
                                    cmd.Parameters.Add("@process", SqlDbType.VarChar, 50).Value = DropProcess.SelectedItem.Text.ToString();
                                    cmd.Parameters.Add("@SourceName", SqlDbType.VarChar, 500).Value = strFile.ToString();
                                    cmd.Parameters.Add("@mode", SqlDbType.VarChar, 3).Value = mode.ToString();
                                }
                                catch (Exception ex)
                                {
                                    ExceptionLogging.SendExcepToDB(ex);

                                }
                                finally
                                {
                                    strConnString1.Open();
                                    cmd.ExecuteNonQuery();
                                    strConnString1.Close();
                                }
                            }

                            //objserver.GetDateset("InsertWIPart '" + productID + "','" + filepath + "' , '" + DropType.SelectedItem + "','" + DropProcess.SelectedItem + "'");



                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter The Details');", true);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Uploaded Successfully');", true);
                BindData();
                BindProcess();
                DropType.SelectedValue = "0";
            }
        }

    }
    
    //protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
    //{
    //    CheckBox chkboxSelectAll = (CheckBox)GridView1.HeaderRow.FindControl("chkboxSelectAll");
    //    foreach (GridViewRow row in GridView1.Rows)
    //    {
    //        CheckBox ch_workinstruction = (CheckBox)row.FindControl("ch_workinstruction");
    //        if (chkboxSelectAll.Checked == true)
    //        {
    //            ch_workinstruction.Checked = true;
    //        }
    //        else
    //        {
    //            ch_workinstruction.Checked = false;
    //        }
    //    }
    //}
    public void checkbrowser()
    {
        lock (thisLock)
        {
            try
            {
                string browser = Request.Browser.Browser.ToString();

                hdn_browser.Value = browser.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "checkbrowser('" + browser + "');", true);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
        }
    }

}
 
