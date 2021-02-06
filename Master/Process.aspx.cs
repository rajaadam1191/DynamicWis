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
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

public partial class Process : System.Web.UI.Page
{
    public string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ToString();
    public QualitySheetdclassDataContext objQualitySheetdclassDataContext = new QualitySheetdclassDataContext();
    public Processtble_grid objtbl_Process = new Processtble_grid();
    public ofarticle_grid objofarticle = new ofarticle_grid();

    public SqlDataAdapter da;
    public PagedDataSource paging = new PagedDataSource();
    public DataTable dt;
    public int cate_comp;
    public int findex, lindex;

    public DBServer objserver = new DBServer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
            {
                sp_username.InnerText = HttpContext.Current.Session["User_Name"].ToString();
                Sp_role.InnerText = HttpContext.Current.Session["User_Role"].ToString();
                Loadprocess();
                Loadofarticle();
                Loadproc();
            }
            else
            {
                HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
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
        //DataListPaging1.DataSource = dt;
        //DataListPaging1.DataBind();
    }
    private void createpaging1()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");
        findex = CurrentPage1 - 5;
        if (CurrentPage1 >= 10)
        {
            lindex = CurrentPage1 + 10;
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

        DataListPaging1.DataSource = dt;
        DataListPaging1.DataBind();
    }
    public int CurrentPage1
    {
        get
        {
            if (ViewState["CurrentPage1"] != null)

                return Convert.ToInt32(ViewState["CurrentPage1"]);
            else
                return 0;
        }
        set
        {
            ViewState["CurrentPage1"] = value;
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

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            fileupload1();
        }

        if (FileUpload2.HasFile)
        {
            fileupload2();
        }
        if (FileUpload4.HasFile)
        {
            fileuploadfrequency();
        }
        if (FileUpload5.HasFile)
        {
            fileuploadcell();
        }
        if (FileUpload6.HasFile)
        {
            fileuploadMachine();
        }
        if (!(FileUpload1.HasFile) && !(FileUpload2.HasFile) && !(FileUpload4.HasFile) && !(FileUpload5.HasFile) && !(FileUpload6.HasFile))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Process (OR) ofarticle file (OR) Frequency (OR) Cell (OR) Machine !!');", true);

        }
    }

    public void Loadprocess()
    {
        objtbl_Process = new Processtble_grid();
        dt = new DataTable();
        objQualitySheetdclassDataContext = new QualitySheetdclassDataContext();

        //var query = (from c in (objQualitySheetdclassDataContext.CycleTimeEntries) select c).ToList();
        da = new SqlDataAdapter("select * from Processtble_grid", constr);
        DataSet ds = new DataSet();
        da.Fill(dt);
        da.Fill(ds);
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
            grid_process.DataSource = paging;
            grid_process.DataBind();
            div_process.Visible = true;
            div_actualerror.Visible = false;
            createpaging();


        }
        else
        {
            div_process.Visible = false;
            div_actualerror.Visible = true;
        }

    }
    public void Loadofarticle()
    {

        objofarticle = new ofarticle_grid();
        dt = new DataTable();
        objQualitySheetdclassDataContext = new QualitySheetdclassDataContext();

        //var query = (from c in (objQualitySheetdclassDataContext.CycleTimeEntries) select c).ToList();
        da = new SqlDataAdapter("select * from ofarticle_grid", constr);
        DataSet ds = new DataSet();
        da.Fill(dt);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {

            paging.DataSource = dt.DefaultView;
            if (ds.Tables[0].Rows.Count > 8)
            {

                paging.AllowPaging = true;
                paging.PageSize = 8;
                paging.CurrentPageIndex = CurrentPage1;
                ViewState["totalpage"] = paging.PageCount;
                link_previous1.Enabled = !paging.IsFirstPage;
                link_next1.Enabled = !paging.IsLastPage;
            }
            else
            {
                div_paging1.Visible = false;
            }
            Grid_ofarticle.DataSource = paging;
            Grid_ofarticle.DataBind();
            div_ofarticle.Visible = true;
            div_actualerror.Visible = false;
            createpaging1();


        }
        else
        {
            div_ofarticle.Visible = false;
            div_actualerror.Visible = true;
        }

    }
    public void fileuploadfrequency()
    {
        SqlConnection conn = new SqlConnection(constr);

        try
        {


            if (FileUpload4.HasFile)
            {
                FileUpload4.Dispose();

                string fileName = FileUpload4.ResolveClientUrl(FileUpload4.PostedFile.FileName);

                DataTable datatble = new DataTable();
                DataSet ds = new DataSet();

                string file = FileUpload4.PostedFile.FileName;
                string serverpath = Server.MapPath("~/uploads/" + file);
                if (File.Exists(serverpath))
                    File.Delete(serverpath);
                FileUpload4.SaveAs(Server.MapPath("~/uploads/" + file));
                string filePath = Server.MapPath("~/uploads/" + file);

                bool hasHeaders = false;
                string HDR = hasHeaders ? "Yes" : "No";
                // string HDR = "Yes";
                string strConn;
                if (filePath.Substring(filePath.LastIndexOf('.')).ToLower() == ".xlsx")
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
                else
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
                OleDbConnection con = new OleDbConnection(strConn);
                con.Open();
                DataTable schemaTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                DataRow schemaRow = schemaTable.Rows[0];
                string sheet = schemaRow["TABLE_NAME"].ToString();
                if (!sheet.EndsWith("_"))
                {
                    string query = "SELECT frequency FROM [" + sheet + "]";
                    OleDbDataAdapter data = new OleDbDataAdapter(query, con);
                    data.Fill(datatble);
                    DataTable filteredRows = datatble.Rows.Cast<DataRow>()
    .Where(row => !row.ItemArray.All(field => field is System.DBNull))
    .CopyToDataTable();
                    ds.Tables.Add(filteredRows);
                }
                SqlDataAdapter daa1 = new SqlDataAdapter("Select * from frequency ", conn);
                DataSet dss = new DataSet();
                daa1.Fill(dss);

                if (dss.Tables[0].Rows.Count > 0)
                {

                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmd1 = new SqlCommand("Truncate table frequency", conn);
                    SqlDataAdapter daa3 = new SqlDataAdapter(cmd1);
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string frequency = Convert.ToString(ds.Tables[0].Rows[i]["frequency"].ToString());
                    ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmd = new SqlCommand("insert into Frequency(frequency)values ('" + frequency + "')", conn);
                    SqlDataAdapter daa = new SqlDataAdapter(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Frequency File Uploaded Successfully !');", true);
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid file !');", true);

        }
        finally
        {
            
            //conn.Close();
            FileUpload4.Dispose();
        }
    }
    public void fileuploadcell()
    {
        SqlConnection conn = new SqlConnection(constr);

        try
        {


            if (FileUpload5.HasFile)
            {

                FileUpload5.Dispose();
                string fileName = FileUpload5.ResolveClientUrl(FileUpload5.PostedFile.FileName);

                DataTable datatble = new DataTable();
                DataSet ds = new DataSet();

                string file = FileUpload5.PostedFile.FileName;
                string serverpath = Server.MapPath("~/uploads/" + file);
                if (File.Exists(serverpath))
                    File.Delete(serverpath);
                FileUpload5.SaveAs(Server.MapPath("~/uploads/" + file));
                string filePath = Server.MapPath("~/uploads/" + file);

                bool hasHeaders = false;
                string HDR = hasHeaders ? "Yes" : "No";
                // string HDR = "Yes";
                string strConn;
                if (filePath.Substring(filePath.LastIndexOf('.')).ToLower() == ".xlsx")
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
                else
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
                OleDbConnection con = new OleDbConnection(strConn);
                con.Open();
                DataTable schemaTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                DataRow schemaRow = schemaTable.Rows[0];
                string sheet = schemaRow["TABLE_NAME"].ToString();
                if (!sheet.EndsWith("_"))
                {
                    string query = "SELECT cell FROM [" + sheet + "]";
                    OleDbDataAdapter data = new OleDbDataAdapter(query, con);
                    data.Fill(datatble);
                    DataTable filteredRows = datatble.Rows.Cast<DataRow>()
    .Where(row => !row.ItemArray.All(field => field is System.DBNull))
    .CopyToDataTable();
                    ds.Tables.Add(filteredRows);
                }
                SqlDataAdapter daa1 = new SqlDataAdapter("Select * from cell ", conn);
                DataSet dss = new DataSet();
                daa1.Fill(dss);

                if (dss.Tables[0].Rows.Count > 0)
                {

                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmd1 = new SqlCommand("Truncate table cell", conn);
                    SqlDataAdapter daa3 = new SqlDataAdapter(cmd1);
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string cell = Convert.ToString(ds.Tables[0].Rows[i]["cell"].ToString());
                    ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmd = new SqlCommand("insert into cell(cell)values ('" + cell + "')", conn);
                    SqlDataAdapter daa = new SqlDataAdapter(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cell File Uploaded Successfully !');", true);
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid file !');", true);

        }
        finally
        {
            //conn.Close();
            FileUpload5.Dispose();
        }
    }
    public void fileuploadMachine()
    {
        SqlConnection conn = new SqlConnection(constr);

        try
        {


            if (FileUpload6.HasFile)
            {

                FileUpload6.Dispose();
                string fileName = FileUpload5.ResolveClientUrl(FileUpload6.PostedFile.FileName);

                DataTable datatble = new DataTable();
                DataSet ds = new DataSet();

                string file = FileUpload6.PostedFile.FileName;
                string serverpath = Server.MapPath("~/uploads/" + file);
                if (File.Exists(serverpath))
                    File.Delete(serverpath);
                FileUpload6.SaveAs(Server.MapPath("~/uploads/" + file));
                string filePath = Server.MapPath("~/uploads/" + file);

                bool hasHeaders = false;
                string HDR = hasHeaders ? "Yes" : "No";
                // string HDR = "Yes";
                string strConn;
                if (filePath.Substring(filePath.LastIndexOf('.')).ToLower() == ".xlsx")
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
                else
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
                OleDbConnection con = new OleDbConnection(strConn);
                con.Open();
                DataTable schemaTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                DataRow schemaRow = schemaTable.Rows[0];
                string sheet = schemaRow["TABLE_NAME"].ToString();
                if (!sheet.EndsWith("_"))
                {
                    string query = "SELECT * FROM [" + sheet + "]";
                    OleDbDataAdapter data = new OleDbDataAdapter(query, con);
                    data.Fill(datatble);
                    DataTable filteredRows = datatble.Rows.Cast<DataRow>()
    .Where(row => !row.ItemArray.All(field => field is System.DBNull))
    .CopyToDataTable();
                    ds.Tables.Add(filteredRows);
                }
                SqlDataAdapter daa1 = new SqlDataAdapter("Select * from Machine ", conn);
                DataSet dss = new DataSet();
                daa1.Fill(dss);

                if (dss.Tables[0].Rows.Count > 0)
                {

                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmd1 = new SqlCommand("Truncate table Machine", conn);
                    SqlDataAdapter daa3 = new SqlDataAdapter(cmd1);
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string cell = Convert.ToString(ds.Tables[0].Rows[i]["Cell"].ToString());
                    string machine = Convert.ToString(ds.Tables[0].Rows[i]["Machine"].ToString());
                    ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmd = new SqlCommand("insert into Machine(Cell,Machine)values ('" + cell + "','" + machine + "')", conn);
                    SqlDataAdapter daa = new SqlDataAdapter(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Machine File Uploaded Successfully !');", true);
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid file !');", true);

        }
        finally
        {
            //conn.Close();
            FileUpload6.Dispose();
        }
    }
    public void fileupload1()
    {
        SqlConnection conn = new SqlConnection(constr);

        try
        {


            if (FileUpload1.HasFile)
            {
                FileUpload1.Dispose();

                string fileName = FileUpload1.ResolveClientUrl(FileUpload1.PostedFile.FileName);

                DataTable datatble = new DataTable();
                DataSet ds = new DataSet();

                //string SourceConstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName + "';Extended Properties= 'Excel 8.0;HDR=Yes;IMEX=1'";
                //OleDbConnection con = new OleDbConnection(SourceConstr);
                ////con.Open();
                //string query = "Select Process from [Process$]";

                string file = FileUpload1.PostedFile.FileName;
                string serverpath = Server.MapPath("~/uploads/" + file);
                if (File.Exists(serverpath))
                    File.Delete(serverpath);
                FileUpload1.SaveAs(Server.MapPath("~/uploads/" + file));
                string filePath = Server.MapPath("~/uploads/" + file);

                bool hasHeaders = false;
                string HDR = hasHeaders ? "Yes" : "No";
                // string HDR = "Yes";
                string strConn;
                if (filePath.Substring(filePath.LastIndexOf('.')).ToLower() == ".xlsx")
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
                else
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
                OleDbConnection con = new OleDbConnection(strConn);
                con.Open();
                DataTable schemaTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                DataRow schemaRow = schemaTable.Rows[0];
                string sheet = schemaRow["TABLE_NAME"].ToString();
                if (!sheet.EndsWith("_"))
                {
                    string query = "SELECT Process FROM [" + sheet + "]";
                    OleDbDataAdapter data = new OleDbDataAdapter(query, con);
                    data.Fill(datatble);
                    DataTable filteredRows = datatble.Rows.Cast<DataRow>()
    .Where(row => !row.ItemArray.All(field => field is System.DBNull))
    .CopyToDataTable();
                    ds.Tables.Add(filteredRows);
                }
                SqlDataAdapter daa1 = new SqlDataAdapter("Select * from tbl_Process ", conn);
                DataSet dss = new DataSet();
                daa1.Fill(dss);

                if (dss.Tables[0].Rows.Count > 0)
                {

                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmd1 = new SqlCommand("Truncate table tbl_Process", conn);
                    SqlDataAdapter daa3 = new SqlDataAdapter(cmd1);
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string Process = Convert.ToString(ds.Tables[0].Rows[i]["Process"].ToString());


                    ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmd = new SqlCommand("insert into tbl_Process(Process)values ('" + Process + "')", conn);
                    SqlDataAdapter daa = new SqlDataAdapter(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                //objBL_Mac.Mode = "ExcelUpload1";

                //grdMac.DataSource = ds.Tables[0];
                //grdMac.DataBind();

                //DataSet SQlResult = objDL_Mac.BulkInsert1(objBL_Mac);

                //data.Dispose();
                //con.Close();
                //con.Dispose();

                objtbl_Process = new Processtble_grid();
                objtbl_Process.FileUpload = "Process";
                objtbl_Process.UserName = HttpContext.Current.Session["User_Name"].ToString();
                objtbl_Process.Time = HttpContext.Current.Session["Logtime"].ToString();
                objtbl_Process.Date = HttpContext.Current.Session["LogDate"].ToString();

                objQualitySheetdclassDataContext.Processtble_grids.InsertOnSubmit(objtbl_Process);
                objQualitySheetdclassDataContext.SubmitChanges();
                objQualitySheetdclassDataContext = null;
                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Process File Uploaded Successfully !');", true);
                Loadprocess();
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid file !');", true);
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);

        }
        finally
        {
            //conn.Close();
            FileUpload1.Dispose();
        }
    }
    public void fileupload2()
    {
        SqlConnection conn = new SqlConnection(constr);

        try
        {

            if (FileUpload2.HasFile)
            {
                FileUpload2.Dispose();
                string fileName = FileUpload2.ResolveClientUrl(FileUpload2.PostedFile.FileName);

                DataTable datatble = new DataTable();
                DataSet ds = new DataSet();
                //string SourceConstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName + "';Extended Properties= 'Excel 8.0;HDR=Yes;IMEX=1'";
                //OleDbConnection con = new OleDbConnection(SourceConstr);
                ////con.Open();
                ////string query = "Select Partno,Description from [Sheet1$]";
                //string query = "Select * from [ofarticles$]";
                //OleDbDataAdapter data = new OleDbDataAdapter(query, SourceConstr);
                //data.Fill(datatble);
                //ds.Tables.Add(datatble);

                //string filename = Path.GetFileName(FileUpload2.PostedFile.FileName);
                //FileUpload2.SaveAs(Server.MapPath("uploads/" + filename));
                //string filepath = "uploads/" + filename;

                //string file = FileUpload2.PostedFile.FileName;
                //string serverpath = Server.MapPath("~/uploads/" + file);
                //if (File.Exists(serverpath))
                //    File.Delete(serverpath);
               
                //FileUpload2.SaveAs(Server.MapPath("~/uploads/" + file));
                //string filepath = Server.MapPath("~/uploads/" + file);
                //DataTable res = ConvertCSVtoDataTable(filepath);
                //ds.Tables.Add(res);



                string file = FileUpload2.PostedFile.FileName;
                string serverpath = Server.MapPath("~/uploads/" + file);
                if (File.Exists(serverpath))
                    File.Delete(serverpath);
                FileUpload2.SaveAs(Server.MapPath("~/uploads/" + file));
                string filePath = Server.MapPath("~/uploads/" + file);
                

                bool hasHeaders = false;
                string HDR = hasHeaders ? "Yes" : "No";
                // string HDR = "Yes";
                string strConn;
                if (filePath.Substring(filePath.LastIndexOf('.')).ToLower() == ".xlsx")
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
                else
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
                OleDbConnection con = new OleDbConnection(strConn);
                con.Open();
                DataTable schemaTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                DataRow schemaRow = schemaTable.Rows[0];
                //DataRow schemaRow = schemaTable.Rows[1];
                string sheet = schemaRow["TABLE_NAME"].ToString();
                if (!sheet.EndsWith("_"))
                {
                    string query = "SELECT * FROM [" + sheet + "]";
                    OleDbDataAdapter data = new OleDbDataAdapter(query, con);
                    data.Fill(datatble);
                    DataTable filteredRows = datatble.Rows.Cast<DataRow>()
    .Where(row => !row.ItemArray.All(field => field is System.DBNull))
    .CopyToDataTable();
                    ds.Tables.Add(filteredRows);
                }

                SqlDataAdapter daa1 = new SqlDataAdapter("Select * from tbl_PartNo ", conn);
                DataSet dss = new DataSet();
                daa1.Fill(dss);

                if (dss.Tables[0].Rows.Count > 0)
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmd1 = new SqlCommand("Truncate table tbl_PartNo", conn);
                    SqlDataAdapter daa3 = new SqlDataAdapter(cmd1);
                    conn.Close();
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string Partno = Convert.ToString(ds.Tables[0].Rows[i][2].ToString());
                    string Description = Convert.ToString(ds.Tables[0].Rows[i][3].ToString());

                    ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmd = new SqlCommand("insert into tbl_PartNo(Partno,Description)values ('" + Partno + "','" + Description + "')", conn);
                    SqlDataAdapter daa = new SqlDataAdapter(cmd);
                    conn.Close();
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                if (HttpContext.Current.Session["User_Name"].ToString() != "" && HttpContext.Current.Session["User_Name"].ToString() != null)
                {
                    objofarticle = new ofarticle_grid();
                    objofarticle.FileUpload = "Part No";
                    objofarticle.UserName = HttpContext.Current.Session["User_Name"].ToString();
                    objofarticle.Time = HttpContext.Current.Session["Logtime"].ToString();
                    objofarticle.Date = HttpContext.Current.Session["LogDate"].ToString();

                    objQualitySheetdclassDataContext.ofarticle_grids.InsertOnSubmit(objofarticle);
                    objQualitySheetdclassDataContext.SubmitChanges();
                    objQualitySheetdclassDataContext = null;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Part No File Uploaded Successfully !');", true);

                    Loadofarticle();
                }
            }
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid file !');", true);
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        }
        finally
        {
            //conn.Close();
            FileUpload2.Dispose();
        }
    }

    public static DataTable ConvertCSVtoDataTable(string strFilePath)
    {
        StreamReader sr = new StreamReader(strFilePath);
        string[] headers = sr.ReadLine().Split(';');
        DataTable dt = new DataTable();
        foreach (string header in headers)
        {
            dt.Columns.Add(header);
        }
        while (!sr.EndOfStream)
        {
            string[] rows = Regex.Split(sr.ReadLine(), ";(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            DataRow dr = dt.NewRow();
            for (int i = 0; i < headers.Length; i++)
            {
                dr[i] = rows[i];
            }
            dt.Rows.Add(dr);
        }
        sr.Close();
        return dt;
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {

        int index = Int32.Parse(e.Item.Value);

        MultiView1.ActiveViewIndex = index;

        if (index == 0)
        {
            DataSet ds = new DataSet();
            ds = objserver.GetDateset("select * from tbl_Process");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Grid_proc.DataSource = ds.Tables[0];
                Grid_proc.DataBind();
            }
        }
        else if (index == 1)
        {
            DataSet ds = new DataSet();
            ds = objserver.GetDateset("select * from tbl_PartNo");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Grid_of.DataSource = ds.Tables[0];
                Grid_of.DataBind();
            }
        }
        else if (index == 2)
        {
            DataSet ds = new DataSet();
            ds = objserver.GetDateset("select * from Frequency");
            if (ds.Tables[0].Rows.Count > 0)
            {
                grd_frequency.DataSource = ds.Tables[0];
                grd_frequency.DataBind();
            }
        }
        else if (index == 3)
        {
            DataSet ds = new DataSet();
            ds = objserver.GetDateset("select * from cell");
            if (ds.Tables[0].Rows.Count > 0)
            {
                grd_unit.DataSource = ds.Tables[0];
                grd_unit.DataBind();
            }
        }
        else if (index == 4)
        {
            DataSet ds = new DataSet();
            ds = objserver.GetDateset("select * from Machine");
            if (ds.Tables[0].Rows.Count > 0)
            {
                grd_mach.DataSource = ds.Tables[0];
                grd_mach.DataBind();
            }
        }
    }

    public void Loadproc()
    {
        DataSet ds = new DataSet();
        ds = objserver.GetDateset("select * from tbl_Process");
        if (ds.Tables[0].Rows.Count > 0)
        {
            Grid_proc.DataSource = ds.Tables[0];
            Grid_proc.DataBind();
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
            Loadprocess();
            //Loadofarticle();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        Loadprocess();
        //Loadofarticle();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        Loadprocess();
        //Loadofarticle();
    }
    protected void DataListPaging_ItemDataBound1(object sender, DataListItemEventArgs e)
    {
        LinkButton lnkPage = (LinkButton)e.Item.FindControl("link_pagebtn");
        if (lnkPage.CommandArgument.ToString() == CurrentPage1.ToString())
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
    protected void DataListPaging_ItemCommand1(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("newpage"))
        {
            CurrentPage1 = Convert.ToInt32(e.CommandArgument.ToString());
            Loadofarticle();
        }

    }
    protected void link_previous_Click1(object sender, EventArgs e)
    {
        CurrentPage1 -= 1;
        Loadofarticle();
    }
    protected void link_next_Click1(object sender, EventArgs e)
    {
        CurrentPage1 += 1;
        Loadofarticle();
    }
}

