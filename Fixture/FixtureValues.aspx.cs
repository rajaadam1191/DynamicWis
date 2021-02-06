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
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
using System.Web.Services;
using System.Collections.Generic;

public partial class FixtureValues : System.Web.UI.Page
{
    public DBServer objserver = new DBServer();
    public DataSet ds;
    public SqlDataAdapter da;
    public DataTable dt;
    public int cate_comp;
    public int findex, lindex, count = 0;
    public PagedDataSource paging = new PagedDataSource();
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public QualitySheetdclassDataContext objcontext = new QualitySheetdclassDataContext();
    public FixtureValue objf = new FixtureValue();
   // ReportDocument rpt = new ReportDocument();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "" && Session["PID_ID"] != null && Session["PID_ID"].ToString() != "")
            {

            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
            //BindPartNumber();
            loadgrid();
            BindFixtureNumber();
        }
        //else
        //{
        //    //To solve the error:
        //    //Failed to export using the options you specified. Please check your options and try again.
        //    if (Request.Form["__EVENTTARGET"] == CRV.UniqueID)
        //    {
        //        loadexcelgrid(rpt);
        //    }
        //}
    }
    public class BindToolNumberDetails
    {
        public int ID { get; set; }
        public string FixNumber { get; set; }
    }
    public void loadgrid()
    {
        paging = new PagedDataSource();
        //da = new SqlDataAdapter("select ROW_NUMBER() over (order by b.FID) as IndexNo, a.* ,b.Fixturename,b.Model from FixtureValues a inner join FixtureName b on cast(a.FixName as int)=b.FID", strConnString);
        da = new SqlDataAdapter("select ROW_NUMBER() over (order by b.FID desc) as IndexNo,min(a.Fid) as Fid,min(a.FixName) as FixName,min(b.Partnumber) as Partno,min(a.FixLife) as FixLife,min(a.Operation) as Operation,min(a.Gfrom) as Gfrom,min(a.Gto) as Gto,min(a.Yfrom) as Yfrom,min(a.Yto) as Yto,min(a.Rfrom) as Rfrom,min(a.Rto) as Rto,min(a.Creationdata) as Creationdata,min(a.Status) as Status,min(a.Flag) as Flag,min(a.GreenRange) as GreenRange,min(a.YellowRange) as YellowRange,min(a.RedRange) as RedRange,min(a.GreenRange1) as GreenRange1,min(a.YellowRange1) as YellowRange1,min(a.RedRange1) as RedRange1,min(a.Availability) as Availability,min(a.Imagefile) as Imagefile,min(a.Drawing) as Drawing,min(b.Fixturename) as Fixturename,min(b.Model) as Model,isnull(sum(cast(c.TotalCount as int)),0) as currentstock from FixtureValues a inner join FixtureName b on a.FixName =b.Fixturename Left join SpareMastermbu c ON b.FID =c.ToolNumber where a.Status='Active' group by b.FID", strConnString);
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
            grid_fixture.DataSource = paging;
            grid_fixture.DataBind();
            createpaging();
            btn_excel.Visible = true;
        }
        else
        {
            btn_excel.Visible = false;
        }
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
    private void BindPartNumber()
    {
        ds = objserver.GetDateset("select '--- Select Part Number ---' PartNo union select distinct PartNo from tbl_PartNo");
        ddl_partnumber.DataSource = ds.Tables[0];

        ddl_partnumber.DataValueField = "PartNo";
        ddl_partnumber.DataTextField = "PartNo";
        ddl_partnumber.DataBind();
    }
    private void BindFixtureNumber()
    {

        //ds = objserver.GetDateset("select '0' Fid,'--- Select Fixture Number ---' FixtureName union select distinct Fid,Fixturename from FixtureName except select distinct FixID as Fid,FixName as Fixturename from FixtureValues");
        ds = objserver.GetDateset("select '--- Select Fixture Number ---' FixtureName union select Fixturename from FixtureName except select FixName as Fixturename from FixtureValues");
        ddl_fixturename.DataSource = ds.Tables[0];

        ddl_fixturename.DataValueField = "Fixturename";
        //ddl_fixturename.DataValueField = "Fixturename";
        ddl_fixturename.DataTextField = "Fixturename";
        ddl_fixturename.DataBind();
    }
    protected void ddl_partnumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_fixturename.SelectedValue == "0")
        {
            string partno = ddl_partnumber.SelectedValue.ToString();
            ds = objserver.GetDateset("select '0' Fid,'--- Select Fixture Number ---' FixtureName union select distinct Fid,Fixturename from FixtureName where Partnumber='" + partno + "'");
            ddl_fixturename.DataSource = ds.Tables[0];

            ddl_fixturename.DataValueField = "Fid";
            //ddl_fixturename.DataValueField = "Fixturename";
            ddl_fixturename.DataTextField = "Fixturename";
            ddl_fixturename.DataBind();
        }
    }
    public void createfolder(string filepath, string date)
    {
        DirectoryInfo dirifo = new DirectoryInfo(filepath);
        dirifo.CreateSubdirectory(date);
    }

    protected void btn_Clear_Click(object sender, ImageClickEventArgs e)
    {
        cleaer();
        ddl_fixturename.SelectedValue = "--- Select Fixture Number ---";
    }
    protected void btn_submit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int extableflg = 0;
            string fixid = "";
            string[] fixpartno;
            string partno = "";
            string cell;
            string oper;
            objcontext = new QualitySheetdclassDataContext();

            SqlDataAdapter tabda = new SqlDataAdapter("select * from FixtureName where Fixturename='" + ddl_fixturename.SelectedValue.ToString() + "'", strConnString);
            DataSet tabds = new DataSet();
            tabda.Fill(tabds);

            if (tabds.Tables[0].Rows.Count > 0)
            {
                fixpartno = tabds.Tables[0].Rows[0]["Partnumber"].ToString().Split(',');
                cell = tabds.Tables[0].Rows[0]["Cell"].ToString();
                oper = hdn_operation.Value.ToString().Trim();//ddloperation.Value.ToString();
                fixid = tabds.Tables[0].Rows[0]["FID"].ToString();
                for (int i = 0; i < fixpartno.Length; i++)
                {
                    string CheckTabName = "QualitySheet_" + cell + "_" + fixpartno[i].ToString() + "_" + oper.ToString() + "";

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
                        partno = fixpartno[i].ToString();
                        extableflg = 1;
                        break;
                    }
                }
            }
            if (extableflg == 0)
            {
                var query = (from table in objcontext.FixtureValues where table.FixName == ddl_fixturename.SelectedItem.ToString() select table).FirstOrDefault();
                if (query != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Fixture Number Already Exist');", true);
                }
                else
                {
                    string path = "";
                    string filename = "";
                    string filename1 = "";
                    if (fld_drawings.HasFile)
                    {
                        string path1 = Server.MapPath("~/Fixture/");
                        createfolder(path1, "Drawing");
                        filename1 = fld_drawings.PostedFile.FileName.ToString();
                        // string f_name = path1 + "Drawing" + '\\' + Path.GetFileName(fld_drawings.PostedFile.FileName);
                        fld_drawings.PostedFile.SaveAs(path1 + "Drawing" + '\\' + filename1);
                    }
                    if (up_photo.HasFile)
                    {

                        path = Server.MapPath("~/Fixture/");
                        createfolder(path, "FixtureImage");
                        filename = up_photo.PostedFile.FileName.ToString();
                        // string f_name = path + "Tools" + '\\' + Path.GetFileName(up_photo.PostedFile.FileName);
                        up_photo.PostedFile.SaveAs(path + "FixtureImage" + '\\' + filename);
                    }
                    int life = Convert.ToInt32(txtfixlife.Value.ToString());
                    int green = Convert.ToInt32(txt_gto.Value.ToString());
                    int yellow = Convert.ToInt32(txt_yto.Value.ToString());
                    int red = Convert.ToInt32(txt_rto.Value.ToString());

                    double gt = (Convert.ToInt32(life)) * ((Convert.ToDouble(green) / 100));
                    double yt = (Convert.ToInt32(life)) * ((Convert.ToDouble(yellow) / 100));
                    double rt = (Convert.ToInt32(life)) * ((Convert.ToDouble(red) / 100));

                    int g = (int)Math.Round(gt, 0, MidpointRounding.AwayFromZero);
                    int y = (int)Math.Round(yt, 0, MidpointRounding.AwayFromZero);
                    int r = (int)Math.Round(rt, 0, MidpointRounding.AwayFromZero);
                    int r1 = (int)Math.Round(rt, 0, MidpointRounding.AwayFromZero);
                    double yf = gt + 1;
                    int yff = (int)Math.Round(yf, 0, MidpointRounding.AwayFromZero);
                    double rf = yt + 1;
                    int rff = (int)Math.Round(rf, 0, MidpointRounding.AwayFromZero);

                    int ye = Convert.ToInt32(txt_gto.Value.ToString()) + (1);
                    objcontext = new QualitySheetdclassDataContext();
                    objf = new FixtureValue()
                    {
                        Partno = "",
                        FixName = ddl_fixturename.SelectedItem.ToString(),
                        Operation = hdn_operation.Value.ToString().Trim(), //ddloperation.Value.ToString(),
                        FixLife = txtfixlife.Value.ToString(),
                        Gfrom = "0",
                        Gto = g.ToString(),
                        Yfrom = yff.ToString(),
                        Yto = y.ToString(),
                        Rfrom = rff.ToString(),
                        Rto = r.ToString(),
                        GreenRange = txt_grom.Value.ToString(),
                        GreenRange1 = txt_gto.Value.ToString(),
                        YellowRange = txt_yfrom.Value.ToString(),
                        YellowRange1 = txt_yto.Value.ToString(),
                        RedRange = txt_rfrom.Value.ToString(),
                        RedRange1 = txt_rto.Value.ToString(),
                        Status = "Active",
                        Creationdata = DateTime.Now.ToShortDateString().ToString(),
                        Flag = "0",
                        Availability = ddl_availability.SelectedValue.ToString(),
                        Drawing = filename1.ToString(),
                        Imagefile = filename.ToString(),
                        FixID = Convert.ToInt32(fixid.ToString())
                    };
                    objcontext.FixtureValues.InsertOnSubmit(objf);
                    objcontext.SubmitChanges();
                    cleaer();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Saved Successfully');", true);
                    ddl_fixturename.SelectedValue = "--- Select Fixture Number ---";
                }
            }
            else
            {
                string operationname = "";
                if (hdn_operation.Value == "1")
                {
                    operationname = "Operation 1";
                }
                else if (hdn_operation.Value == "2")
                {
                    operationname = "Operation 2";
                }
                else
                {
                    operationname = hdn_operation.Value.ToString().Trim();
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Quality Sheet not Created for " + partno.ToString() + "_" + operationname.ToString() + " Please Create the Sheet and then Create Fixture');", true);
                SqlCommand scmd = new SqlCommand("delete from FixtureName where Fixturename='" + ddl_fixturename.SelectedValue.ToString() + "' ", strConnString);
                strConnString.Close();
                strConnString.Open();
                scmd.ExecuteNonQuery();
                strConnString.Close();
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            cleaer();
        }

    }
    public void cleaer()
    {
        //BindPartNumber();
        loadgrid();
        BindFixtureNumber();
        txt_grom.Value = "";
        txt_gto.Value = "";
        txt_rfrom.Value = "";
        txt_rto.Value = "";
        txt_yfrom.Value = "";
        txt_yto.Value = "";
        txtfixlife.Value="";
        ddloperation.Value = "0";
        ddl_availability.SelectedValue = "0";
        hdn_operation.Value = "0";
    }
    public string fixturecount(string operation, string fixtureno,string Line)
    {
        int fixcount = 0;
        SqlDataAdapter da1 = new SqlDataAdapter("select a.*,b.Fixturename,b.Cell,b.Partnumber from FixtureValues a inner join FixtureName b on a.FixName=b.Fixturename where a.Operation='" + ds.Tables[0].Rows[0]["Operation"].ToString() + "' and b.Line='" + ds.Tables[0].Rows[0]["Line"].ToString() + "' and FixName='" + ds.Tables[0].Rows[0]["FixName"].ToString() + "' and a.Status='Active'", strConnString);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            fixcount = 0;
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                string[] spltpartno = ds1.Tables[0].Rows[j]["Partnumber"].ToString().Split(',');
                for (int k = 0; k < spltpartno.Length; k++)
                {
                    string fixtablename = "QualitySheet_" + ds1.Tables[0].Rows[j]["Cell"].ToString() + "_" + spltpartno[k].ToString() + "_" + ds1.Tables[0].Rows[j]["Operation"].ToString() + "";
                    SqlDataAdapter da2 = new SqlDataAdapter("select count(*)totoal from " + fixtablename + " where FixNo like '%" + ds.Tables[0].Rows[0]["FixName"].ToString() + "%'", strConnString);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        if (ds2.Tables[0].Rows[0]["totoal"].ToString() != "0")
                        {
                            fixcount = fixcount + Convert.ToInt32(ds2.Tables[0].Rows[0]["totoal"].ToString());
                        }
                    }
                }
            }
        }
        return fixcount.ToString();
    }
    protected void btn_update_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int extableflg = 0;
            string[] fixpartno;
            string partno = "";
            string cell;
            string oper;

            string fixname = "";
            int fixid = 0;
            string path = "";
            string filename = "";
            string filename1 = "";
            string Id = hdn_id.Value.ToString();
            if (fld_drawings.HasFile)
            {
                string path1 = Server.MapPath("~/ABU/");
                createfolder(path1, "Drawing");
                filename1 = fld_drawings.PostedFile.FileName.ToString();
                string f_name = path1 + "Tools" + '\\' + Path.GetFileName(fld_drawings.PostedFile.FileName);
                fld_drawings.PostedFile.SaveAs(path1 + "Drawing" + '\\' + filename);

            }
            else
            {
                da = new SqlDataAdapter("select * from FixtureValues where Fid='" + Convert.ToInt32(Id) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    filename1 = ds.Tables[0].Rows[0]["Drawing"].ToString();
                }
            }
            if (up_photo.HasFile)
            {
                path = Server.MapPath("~/ABU/");
                createfolder(path, "FixtureImage");
                filename = up_photo.PostedFile.FileName.ToString();
                string f_name = path + "FixtureImage" + '\\' + Path.GetFileName(up_photo.PostedFile.FileName);
                up_photo.PostedFile.SaveAs(path + "FixtureImage" + '\\' + filename);

            }
            else
            {
                da = new SqlDataAdapter("select * from FixtureValues where Fid='" + Convert.ToInt32(Id) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    filename = ds.Tables[0].Rows[0]["Imagefile"].ToString();
                }
            }
            da = new SqlDataAdapter("select * from FixtureValues a inner join FixtureName b on a.FixName=b.Fixturename where a.Fid='" + Convert.ToInt32(Id) + "'", strConnString);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdn_mach.Value = ds.Tables[0].Rows[0]["Line"].ToString();
                if (ddl_fixturename.SelectedValue.ToString() == "--- Select Fixture Number ---")
                {
                    fixname = ds.Tables[0].Rows[0]["FixName"].ToString();
                    fixid = Convert.ToInt32(ds.Tables[0].Rows[0]["FixID"].ToString());
                }
                else
                {
                    fixname = ddl_fixturename.SelectedItem.ToString();
                    //fixid = Convert.ToInt32(ddl_fixturename.SelectedValue.ToString());
                    fixid = Convert.ToInt32(ds.Tables[0].Rows[0]["FixID"].ToString());
                }
            }
            SqlDataAdapter tabda = new SqlDataAdapter("select * from FixtureName where FID='" + fixid.ToString() + "'", strConnString);
            DataSet tabds = new DataSet();
            tabda.Fill(tabds);

            if (tabds.Tables[0].Rows.Count > 0)
            {
                fixpartno = tabds.Tables[0].Rows[0]["Partnumber"].ToString().Split(',');
                cell = tabds.Tables[0].Rows[0]["Cell"].ToString();
                oper = hdn_operation.Value.ToString().Trim();//ddloperation.Value.ToString();

                for (int i = 0; i < fixpartno.Length; i++)
                {
                    string CheckTabName = "QualitySheet_" + cell + "_" + fixpartno[i].ToString() + "_" + oper.ToString() + "";

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
                        partno = fixpartno[i].ToString();
                        extableflg = 1;
                        break;
                    }
                }
            }
            if (extableflg == 0)
            {
                if (ddl_fixclose.SelectedValue.ToString() == "0")
                {
                    var query = (from table in objcontext.FixtureValues where table.Fid == Convert.ToInt32(hdn_id.Value.ToString()) select table).First();
                    if (query != null)
                    {
                        int life = Convert.ToInt32(txtfixlife.Value.ToString());
                        int green = Convert.ToInt32(txt_gto.Value.ToString());
                        int yellow = Convert.ToInt32(txt_yto.Value.ToString());
                        int red = Convert.ToInt32(txt_rto.Value.ToString());

                        double gt = (Convert.ToInt32(life)) * ((Convert.ToDouble(green) / 100));
                        double yt = (Convert.ToInt32(life)) * ((Convert.ToDouble(yellow) / 100));
                        double rt = (Convert.ToInt32(life)) * ((Convert.ToDouble(red) / 100));

                        int g = (int)Math.Round(gt, 0, MidpointRounding.AwayFromZero);
                        int y = (int)Math.Round(yt, 0, MidpointRounding.AwayFromZero);
                        int r = (int)Math.Round(rt, 0, MidpointRounding.AwayFromZero);
                        int r1 = (int)Math.Round(rt, 0, MidpointRounding.AwayFromZero);
                        double yf = gt + 1;
                        int yff = (int)Math.Round(yf, 0, MidpointRounding.AwayFromZero);
                        double rf = yt + 1;
                        int rff = (int)Math.Round(rf, 0, MidpointRounding.AwayFromZero);
                        query.Partno = "";
                        query.FixName = fixname.ToString();
                        query.Operation = hdn_operation.Value.ToString().Trim(); //ddloperation.Value.ToString();
                        query.FixLife = txtfixlife.Value.ToString();
                        query.Gfrom = "0";
                        query.Gto = g.ToString();
                        query.Yfrom = yff.ToString();
                        query.Yto = y.ToString();
                        query.Rfrom = rff.ToString();
                        query.Rto = r.ToString();
                        query.GreenRange = txt_grom.Value.ToString();
                        query.GreenRange1 = txt_gto.Value.ToString();
                        query.YellowRange = txt_yfrom.Value.ToString();
                        query.YellowRange1 = txt_yto.Value.ToString();
                        query.RedRange = txt_rfrom.Value.ToString();
                        query.RedRange1 = txt_rto.Value.ToString();
                        query.Availability = ddl_availability.SelectedValue.ToString();
                        query.Drawing = filename1.ToString();
                        query.Imagefile = filename.ToString();
                        query.FixID = Convert.ToInt32(fixid.ToString());
                        objcontext.SubmitChanges();

                        //                    string fixcount = fixturecount(ddloperation.Value.ToString(), fixname.ToString(), hdn_mach.Value);
                        string fixcount = fixturecount(hdn_operation.Value.ToString().Trim(), fixname.ToString(), hdn_mach.Value);
                        if (Convert.ToInt32(fixcount) < Convert.ToInt32(rff.ToString()))
                        {
                            string Query = "update Fixturestatus set RedOpenDate='' where Fixtureno='" + fixname.ToString() + "'";
                            SqlCommand cmd = new SqlCommand(Query, strConnString);
                            if (strConnString.State == ConnectionState.Open)
                            {
                                strConnString.Close();
                            }
                            strConnString.Open();
                            cmd.ExecuteNonQuery();
                            strConnString.Close();
                        }

                        cleaer();
                    }
                    else
                    {
                    }
                }
                else
                {
                    if (ddl_fixclose.SelectedValue.ToString() == "Yes")
                    {
                        var query1 = (from table in objcontext.FixtureValues where table.Fid == Convert.ToInt32(hdn_id.Value.ToString()) && table.Status == "Active" select table).First();
                        if (query1 != null)
                        {
                            query1.Status = "Inactive";
                            query1.ModifyDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                            query1.Fixtureclose = ddl_fixclose.SelectedValue.ToString();
                            //cleaer();
                            objcontext.SubmitChanges();
                            loadgrid();
                        }
                    }
                    else
                    {
                        var query = (from table in objcontext.FixtureValues where table.Fid == Convert.ToInt32(hdn_id.Value.ToString()) select table).First();
                        if (query != null)
                        {
                            query.Status = "Inactive";
                            //query.LifeExtend = txt_extended.Value.ToString();
                            query.ModifyDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                            query.Fixtureclose = ddl_fixclose.SelectedValue.ToString();
                            objcontext.SubmitChanges();
                            //cleaer();
                            loadgrid();
                        }
                        int lifetot = Convert.ToInt32(txtfixlife.Value.ToString()) + Convert.ToInt32(txt_extended.Value.ToString());
                        int life = lifetot;// Convert.ToInt32(txtfixlife.Value.ToString());
                        int green = Convert.ToInt32(txt_gto.Value.ToString());
                        int yellow = Convert.ToInt32(txt_yto.Value.ToString());
                        int red = Convert.ToInt32(txt_rto.Value.ToString());

                        double gt = (Convert.ToInt32(life)) * ((Convert.ToDouble(green) / 100));
                        double yt = (Convert.ToInt32(life)) * ((Convert.ToDouble(yellow) / 100));
                        double rt = (Convert.ToInt32(life)) * ((Convert.ToDouble(red) / 100));

                        int g = (int)Math.Round(gt, 0, MidpointRounding.AwayFromZero);
                        int y = (int)Math.Round(yt, 0, MidpointRounding.AwayFromZero);
                        int r = (int)Math.Round(rt, 0, MidpointRounding.AwayFromZero);
                        int r1 = (int)Math.Round(rt, 0, MidpointRounding.AwayFromZero);
                        double yf = gt + 1;
                        int yff = (int)Math.Round(yf, 0, MidpointRounding.AwayFromZero);
                        double rf = yt + 1;
                        int rff = (int)Math.Round(rf, 0, MidpointRounding.AwayFromZero);

                        int ye = Convert.ToInt32(txt_gto.Value.ToString()) + (1);
                        objcontext = new QualitySheetdclassDataContext();
                        objf = new FixtureValue()
                        {
                            Partno = "",
                            FixName = fixname.ToString(),
                            Operation = hdn_operation.Value.ToString().Trim(), //ddloperation.Value.ToString(),
                            FixLife = lifetot.ToString(),
                            Gfrom = "0",
                            Gto = g.ToString(),
                            Yfrom = yff.ToString(),
                            Yto = y.ToString(),
                            Rfrom = rff.ToString(),
                            Rto = r.ToString(),
                            GreenRange = txt_grom.Value.ToString(),
                            GreenRange1 = txt_gto.Value.ToString(),
                            YellowRange = txt_yfrom.Value.ToString(),
                            YellowRange1 = txt_yto.Value.ToString(),
                            RedRange = txt_rfrom.Value.ToString(),
                            RedRange1 = txt_rto.Value.ToString(),
                            Status = "Active",
                            Creationdata = DateTime.Now.ToShortDateString().ToString(),
                            Flag = "0",
                            Availability = ddl_availability.SelectedValue.ToString(),
                            Drawing = filename1.ToString(),
                            Imagefile = filename.ToString(),
                            FixID = Convert.ToInt32(fixid.ToString()),
                            LifeExtend = txt_extended.Value.ToString(),
                            //Fixtureclose = ddl_fixclose.SelectedValue.ToString(),
                            ModifyDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
                        };
                        objcontext.FixtureValues.InsertOnSubmit(objf);
                        objcontext.SubmitChanges();

                        //                    string fixcount = fixturecount(ddloperation.Value.ToString(), fixname.ToString(), hdn_mach.Value);
                        string fixcount = fixturecount(hdn_operation.Value.ToString().Trim(), fixname.ToString(), hdn_mach.Value);
                        if (Convert.ToInt32(fixcount) < Convert.ToInt32(rff.ToString()))
                        {
                            string Query = "update Fixturestatus set RedOpenDate='' where Fixtureno='" + fixname.ToString() + "'";
                            SqlCommand cmd = new SqlCommand(Query, strConnString);
                            if (strConnString.State == ConnectionState.Open)
                            {
                                strConnString.Close();
                            }
                            strConnString.Open();
                            cmd.ExecuteNonQuery();
                            strConnString.Close();
                        }
                    }
                }
            }
            else
            {
                string operationname = "";
                if (hdn_operation.Value == "1")
                {
                    operationname = "Operation 1";
                }
                else if (hdn_operation.Value == "2")
                {
                    operationname = "Operation 2";
                }
                else
                {
                    operationname = hdn_operation.Value.ToString().Trim();
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Quality Sheet not Created for " + partno.ToString() + "_" + operationname.ToString() + " Please Create the Sheet and then update Fixture');", true);
            }
            cleaer();
            loadgrid();
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
    protected void OnDataBound(object sender, EventArgs e)
    {
        if (grid_fixture.Rows.Count > 0)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

            for (int i = 1; i < grid_fixture.Columns.Count; i++)
            {
                TableHeaderCell cell = new TableHeaderCell();
                TextBox txtSearch = new TextBox();
                txtSearch.Attributes["placeholder"] = "Filter";
                txtSearch.CssClass = "search_textbox";
                cell.Controls.Add(txtSearch);
                row.Controls.Add(cell);
            }
            grid_fixture.HeaderRow.Parent.Controls.AddAt(1, row);
        }
    }
    protected void grid_fixture_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label ID = e.Row.FindControl("lbl_id") as Label;
                Image image = e.Row.FindControl("ph_image") as Image;
                //Image ph_drawing = e.Row.FindControl("ph_drawing") as Image;
                HyperLink ph_drawing = e.Row.FindControl("ph_drawing") as HyperLink;
                Label lbl_status = e.Row.FindControl("lbl_status") as Label;
                Label lbl_life = e.Row.FindControl("lbl_life") as Label;
                Label lbl_fixcount = e.Row.FindControl("lbl_fixcount") as Label;
                TableCell cell = e.Row.Cells[19];
                if (ID.Text != "" && ID.Text != null)
                {
                    da = new SqlDataAdapter("select * from FixtureValues a inner join FixtureName b on a.FixName=b.Fixturename where a.Fid='" + Convert.ToInt32(ID.Text.ToString()) + "'", strConnString);
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Imagefile"] != null && ds.Tables[0].Rows[0]["Imagefile"].ToString() != "")
                        {
                            image.ImageUrl = "~/Fixture/FixtureImage/" + ds.Tables[0].Rows[0]["Imagefile"].ToString();
                        }
                        else
                        {
                            image.ImageUrl = "~/Menu_image/noimage.png";
                        }

                        if (ds.Tables[0].Rows[0]["Drawing"] != null && ds.Tables[0].Rows[0]["Drawing"].ToString() != "")
                        {
                            //ph_drawing.ImageUrl = "~/Fixture/Drawing/" + ds.Tables[0].Rows[0]["Drawing"].ToString();
                            ph_drawing.Text = ds.Tables[0].Rows[0]["Drawing"].ToString();
                            ph_drawing.NavigateUrl = "~/Fixture/Drawing/" + ds.Tables[0].Rows[0]["Drawing"].ToString();
                        }
                        else
                        {
                            //ph_drawing.ImageUrl = "~/Menu_image/noimage.png";
                            ph_drawing.Text = "noimage.png";
                            ph_drawing.NavigateUrl = "~/Menu_image/noimage.png";
                        }
                        //if (ds.Tables[0].Rows[0]["LifeExtend"] != null && ds.Tables[0].Rows[0]["LifeExtend"].ToString() != "")
                        //{
                        //    int from = Convert.ToInt32(ds.Tables[0].Rows[0]["FixLife"].ToString());
                        //    int to = Convert.ToInt32(ds.Tables[0].Rows[0]["LifeExtend"].ToString());
                        //    int tot = from + to;
                        //    lbl_life.Text = tot.ToString();
                        //}
                        //else
                        //{
                        //    lbl_life.Text = ds.Tables[0].Rows[0]["FixLife"].ToString();
                        //}
                        string setColorClass = string.Empty;
                        SqlDataAdapter da1 = new SqlDataAdapter("select a.*,b.Fixturename,b.Cell,b.Partnumber from FixtureValues a inner join FixtureName b on a.FixName=b.Fixturename where a.Operation='" + ds.Tables[0].Rows[0]["Operation"].ToString() + "' and b.Line='" + ds.Tables[0].Rows[0]["Line"].ToString() + "' and FixName='" + ds.Tables[0].Rows[0]["FixName"].ToString() + "' and a.Status='Active'", strConnString);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            int fixcount = 0;
                            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                            {
                                string[] spltpartno = ds1.Tables[0].Rows[j]["Partnumber"].ToString().Split(',');
                                for (int k = 0; k < spltpartno.Length; k++)
                                {
                                    string fixtablename = "QualitySheet_" + ds1.Tables[0].Rows[j]["Cell"].ToString() + "_" + spltpartno[k].ToString() + "_" + ds1.Tables[0].Rows[j]["Operation"].ToString() + "";
                                    SqlDataAdapter da2 = new SqlDataAdapter("select count(*)totoal from " + fixtablename + " where FixNo like '%" + ds.Tables[0].Rows[0]["FixName"].ToString() + "%'", strConnString);
                                    DataSet ds2 = new DataSet();
                                    da2.Fill(ds2);
                                    if (ds2.Tables[0].Rows.Count > 0)
                                    {
                                        if (ds2.Tables[0].Rows[0]["totoal"].ToString() != "0")
                                        {
                                            fixcount = fixcount + Convert.ToInt32(ds2.Tables[0].Rows[0]["totoal"].ToString());
                                        }
                                    }
                                }
                            }
                            if (Convert.ToInt32(fixcount) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Gfrom"].ToString()) && Convert.ToInt32(fixcount) <= Convert.ToInt32(ds.Tables[0].Rows[0]["Gto"].ToString()))
                            {
                                setColorClass = "Green";
                                lbl_status.Text = "Fixture life at<br> usable condition";
                            }
                            if (Convert.ToInt32(fixcount) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Yfrom"].ToString()) && Convert.ToInt32(fixcount) <= Convert.ToInt32(ds.Tables[0].Rows[0]["Yto"].ToString()))
                            {
                                setColorClass = "Yellow";
                                lbl_status.Text = "Alert for fixture Calibration<br>& Re order Zone";
                            }
                            if (Convert.ToInt32(fixcount) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Rfrom"].ToString()) && Convert.ToInt32(fixcount) <= Convert.ToInt32(ds.Tables[0].Rows[0]["Rto"].ToString()))
                            {
                                setColorClass = "Red";
                                lbl_status.Text = "Fixture life Completed";
                            }
                            else
                            {
                                if (Convert.ToInt32(fixcount) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Rto"].ToString()))
                                {
                                    setColorClass = "Red";
                                    lbl_status.Text = "Fixture life Completed";
                                }
                            }
                            lbl_fixcount.Text = fixcount.ToString();
                        }
                        else
                        {
                            lbl_fixcount.Text = "0";
                        }
                        cell.CssClass = setColorClass;
                    }
                    else
                    {
                    }
                }
                else
                {
                }

            }
        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please create Quality Sheet then allocate Fixture');", true);
        }
    }
    [WebMethod]
    public static BindToolNumberDetails[] BindToolNumberEdit(string fixid)
    {
        DataTable dt = new DataTable();
        List<BindToolNumberDetails> details = new List<BindToolNumberDetails>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select distinct Fid,Fixturename from FixtureName where Fid='" + fixid.ToString() + "'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dtrow in dt.Rows)
                {
                    BindToolNumberDetails bt = new BindToolNumberDetails();
                    bt.ID = Convert.ToInt32(dtrow["Fid"].ToString());
                    bt.FixNumber = dtrow["Fixturename"].ToString();
                    details.Add(bt);
                }
            }
        }
        return details.ToArray();
    }
    protected void ExportToPDF(object sender, EventArgs e)
    {
        //ReportDocument rpt = new ReportDocument();
        //loadexcelgrid(rpt);
        //ExportFormatType formatType = ExportFormatType.NoFormat;
        //switch ("PDF")
        //{
        //    case "Word":
        //        formatType = ExportFormatType.WordForWindows;
        //        break;
        //    case "PDF":
        //        formatType = ExportFormatType.PortableDocFormat;
        //        break;
        //    case "Excel":
        //        formatType = ExportFormatType.Excel;
        //        break;
        //}
        //rpt.ExportToHttpResponse(formatType, Response, true, "FixtureAssign");
        //Response.End();
        loadexcelgrid();
    }

    public void loadexcelgrid() //ReportDocument rpt
    {
        //da = new SqlDataAdapter("select  ROW_NUMBER() over (order by b.FID) as IndexNo,a.*,b.Fixturename,b.Model as ModelNo from FixtureValues a inner join FixtureName b on cast(a.FixName as int)=b.FID", strConnString);
        da = new SqlDataAdapter("select ROW_NUMBER() over (order by b.FID) as IndexNo,min(a.Fid) as Fid,min(a.FixName) as FixName,min(b.Partnumber) as Partno,min(a.FixLife) as FixLife,min(a.Operation) as Operation,min(a.Gfrom) as Gfrom,min(a.Gto) as Gto,min(a.Yfrom) as Yfrom,min(a.Yto) as Yto,min(a.Rfrom) as Rfrom,min(a.Rto) as Rto,min(a.Creationdata) as Creationdata,min(a.Status) as Status,min(a.Flag) as Flag,min(a.GreenRange) as GreenRange,min(a.YellowRange) as YellowRange,min(a.RedRange) as RedRange,min(a.GreenRange1) as GreenRange1,min(a.YellowRange1) as YellowRange1,min(a.RedRange1) as RedRange1,min(a.Availability) as Availability,min(a.Imagefile) as Imagefile,min(a.Drawing) as Drawing,min(b.Fixturename) as Fixturename,min(b.Model) as ModelNo,isnull(sum(cast(c.TotalCount as int)),0) as spare,min(b.Line) as Line,min(LifeExtend) as LifeExtend from FixtureValues a inner join FixtureName b on a.FixName =b.Fixturename Left join SpareMastermbu c ON b.FID =c.ToolNumber group by b.FID", strConnString);
        ds = new DataSet();
        DataTable dt = new DataTable("FixtureValues");
        dt.Clear();
        da.Fill(ds);
        da.Fill(dt);
        dt.Columns.Add("PhotoImg", System.Type.GetType("System.Byte[]"));
        dt.Columns.Add("DrawingImg", System.Type.GetType("System.Byte[]"));
        dt.Columns.Add("FixtureCount");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                FileStream fs;
                BinaryReader br;

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Fixture\\FixtureImage\\" + dt.Rows[i]["Imagefile"].ToString()))
                {
                    // open image in file stream
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Fixture\\FixtureImage\\" + dt.Rows[i]["Imagefile"].ToString(), FileMode.Open);
                }
                else
                {
                    // if photo does not exist show the nophoto.jpg file
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Menu_image\\noimage.png", FileMode.Open);
                }
                br = new BinaryReader(fs);
                // define the byte array of file length
                byte[] imgbyte = new byte[fs.Length + 1];
                // read the bytes from the binary reader
                imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));
                dt.Rows[i]["PhotoImg"] = imgbyte;
                //drow[0] = br.Read(imgbyte, 0, imgbyte.Length);
                dt.AcceptChanges();
                // add row into the data table
                br.Close();
                // close the binary reader
                fs.Close();

                ///////////
                FileStream fs1;
                BinaryReader br1;

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Fixture\\Drawing\\" + dt.Rows[i]["Imagefile"].ToString()))
                {
                    // open image in file stream
                    fs1 = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Fixture\\Drawing\\" + dt.Rows[i]["Imagefile"].ToString(), FileMode.Open);
                }
                else
                {
                    // if photo does not exist show the nophoto.jpg file
                    fs1 = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Menu_image\\noimage.png", FileMode.Open);
                }
                br1 = new BinaryReader(fs1);
                // define the byte array of file length
                byte[] imgbyte1 = new byte[fs1.Length + 1];
                // read the bytes from the binary reader
                imgbyte1 = br1.ReadBytes(Convert.ToInt32((fs1.Length)));
                dt.Rows[i]["DrawingImg"] = imgbyte1;
                //drow[0] = br1.Read(imgbyte1, 0, imgbyte1.Length);
                dt.AcceptChanges();
                // add row into the data table
                br1.Close();
                // close the binary reader
                fs1.Close();

                //if (dt.Rows[i]["LifeExtend"] != null && ds.Tables[0].Rows[i]["LifeExtend"].ToString() != "")
                //{
                //    int from = Convert.ToInt32(ds.Tables[0].Rows[0]["FixLife"].ToString());
                //    int to = Convert.ToInt32(ds.Tables[0].Rows[0]["LifeExtend"].ToString());
                //    int tot = from + to;
                //    dt.Rows[i]["FixLife"] = tot.ToString();
                //}
                //else
                //{
                //    dt.Rows[i]["FixLife"] = ds.Tables[0].Rows[0]["FixLife"].ToString();
                //}

                SqlDataAdapter da1 = new SqlDataAdapter("select a.*,b.Fixturename,b.Cell,b.Partnumber from FixtureValues a inner join FixtureName b on a.FixName=b.Fixturename where a.Operation='" + ds.Tables[0].Rows[0]["Operation"].ToString() + "' and b.Line='" + ds.Tables[0].Rows[0]["Line"].ToString() + "' and FixName='" + ds.Tables[0].Rows[0]["FixName"].ToString() + "' and a.Status='Active'", strConnString);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    int fixcount = 0;
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        string[] spltpartno = ds1.Tables[0].Rows[j]["Partnumber"].ToString().Split(',');
                        for (int k = 0; k < spltpartno.Length; k++)
                        {
                            string fixtablename = "QualitySheet_" + ds1.Tables[0].Rows[j]["Cell"].ToString() + "_" + spltpartno[k].ToString() + "_" + ds1.Tables[0].Rows[j]["Operation"].ToString() + "";
                            SqlDataAdapter da2 = new SqlDataAdapter("select count(*)totoal from " + fixtablename + " where FixNo like '%" + ds.Tables[0].Rows[i]["FixName"].ToString() + "%'", strConnString);
                            DataSet ds2 = new DataSet();
                            da2.Fill(ds2);
                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                if (ds2.Tables[0].Rows[0]["totoal"].ToString() != "0")
                                {
                                    fixcount = fixcount + Convert.ToInt32(ds2.Tables[0].Rows[0]["totoal"].ToString());
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(fixcount) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Gfrom"].ToString()) && Convert.ToInt32(fixcount) <= Convert.ToInt32(ds.Tables[0].Rows[0]["Gto"].ToString()))
                    {
                        // setColorClass = "Green";
                        dt.Rows[i]["Status"] = "Fixture life at usable condition";
                    }
                    if (Convert.ToInt32(fixcount) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Yfrom"].ToString()) && Convert.ToInt32(fixcount) <= Convert.ToInt32(ds.Tables[0].Rows[0]["Yto"].ToString()))
                    {
                        //  setColorClass = "Yellow";
                        dt.Rows[i]["Status"] = "Alert for fixture Calibration<br>& Re order Zone";
                    }
                    if (Convert.ToInt32(fixcount) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Rfrom"].ToString()) && Convert.ToInt32(fixcount) <= Convert.ToInt32(ds.Tables[0].Rows[0]["Rto"].ToString()))
                    {
                        // setColorClass = "Red";
                        dt.Rows[i]["Status"] = "Fixture life Completed";
                    }
                    else
                    {
                        if (Convert.ToInt32(fixcount) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Rto"].ToString()))
                        {
                            //  setColorClass = "Red";
                            dt.Rows[i]["Status"] = "Fixture life Completed";
                        }
                    }
                    dt.Rows[i]["FixtureCount"] = fixcount.ToString();
                }
                else
                {
                    dt.Rows[i]["FixtureCount"] = "0";
                }
                //cell.CssClass = setColorClass;
            }

        }

        //ReportDocument rpt = new ReportDocument();
        //rpt.Load(Server.MapPath("~/Fixture/FixtureValues.rpt"));
        //rpt.SetDataSource(dt);
        //CRV.ReportSource = rpt;
    }
      
 

    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        MemoryStream ms = new MemoryStream();
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        return ms.ToArray();
    }
}
