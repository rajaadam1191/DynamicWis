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
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;

public partial class ABU_AbuMaster : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public DataSet ds;
    public SqlDataAdapter da;
    public SqlCommand cmd;
    public int findex, lindex, count = 0;
    public PagedDataSource paging = new PagedDataSource();
    public QualitySheetdclassDataContext objcontext = new QualitySheetdclassDataContext();
    public Abu_Master objabu = new Abu_Master();
    public SpareMaster objspare = new SpareMaster();
    //ReportDocument rpt = new ReportDocument();

    public class BindToolNumberDetails
    {
        public int ID { get; set; }
        public string ToolNumber { get; set; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindToolNumber();
            loadgrid();
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    private void BindToolNumber()
    {

        //ds = objserver.GetDateset("select '0' ID,'--- Select Tool Number ---' ToolNumber union select distinct ID,ToolNumber from AbuToolMaster");
        ds = objserver.GetDateset("select '0' ID,'--- Select Tool Number ---' ToolNumber union select distinct ID,ToolNumber from AbuToolMaster except select distinct b.ID,b.ToolNumber as ToolNumber from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID");
        txt_toolnumber.DataSource = ds.Tables[0];

        txt_toolnumber.DataValueField = "ID";
        txt_toolnumber.DataTextField = "ToolNumber";
        txt_toolnumber.DataBind();
    }

    //[WebMethod]
    //public static List<ListItem> BindToolNumberEdit(string toolid)
    //{
    //    string query = "select distinct b.ID,b.ToolNumber as ToolNumber from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where b.Id='" + toolid.ToString() + "'";
    //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    //    using (SqlConnection con = new SqlConnection(constr))
    //    {
    //        using (SqlCommand cmd = new SqlCommand(query))
    //        {
    //            List<ListItem> BindToolNum = new List<ListItem>();
    //            cmd.CommandType = CommandType.Text;
    //            cmd.Connection = con;
    //            con.Open();
    //            using (SqlDataReader sdr = cmd.ExecuteReader())
    //            {
    //                while (sdr.Read())
    //                {
    //                    BindToolNum.Add(new ListItem
    //                    {
    //                        Value = sdr["ID"].ToString(),
    //                        Text = sdr["ToolNumber"].ToString()
    //                    });
    //                }
    //            }
    //            con.Close();
    //            return BindToolNum;
    //        }
    //    }
    //}
    [WebMethod]
    public static BindToolNumberDetails[] BindToolNumberEdit(string toolid)
    {
        DataTable dt = new DataTable();
        List<BindToolNumberDetails> details = new List<BindToolNumberDetails>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select distinct b.ID,b.ToolNumber as ToolNumber from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where b.Id='" + toolid.ToString() + "'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dtrow in dt.Rows)
                {
                    BindToolNumberDetails bt = new BindToolNumberDetails();
                    bt.ID = Convert.ToInt32(dtrow["ID"].ToString());
                    bt.ToolNumber = dtrow["ToolNumber"].ToString();
                    details.Add(bt);
                }
            }
        }
        return details.ToArray();
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
    protected void btn_submit_Click(object sender, ImageClickEventArgs e)
    {
        string path = "";
        string path3 = "";

        string filename = "";
        string filename1 = "";
        if (fld_drawings.HasFile)
        {
            string path1 = Server.MapPath("~/ABU/");
            //string path1 = Server.MapPath(@"\ABU\");
            createfolder(path1, "Drawing");
            //filename1 = fld_drawings.PostedFile.FileName.ToString();
            filename1 = System.IO.Path.GetFileName(fld_drawings.PostedFile.FileName.ToString());
         //   path3=Path.Combine(path1,"Drawing\\"+ filename1);
            // string f_name = path1 + "Drawing" + '\\' + Path.GetFileName(fld_drawings.PostedFile.FileName);
            //fld_drawings.PostedFile.SaveAs(path1 + "Drawing" + '\\' + filename1);
           fld_drawings.PostedFile.SaveAs(path1 + "Drawing" + '\\' + filename1);
           // fld_drawings.PostedFile.SaveAs(path3);
        }
        if (up_photo.HasFile)
        {
            path = Server.MapPath("~/ABU/");
            //path = Server.MapPath(@"\ABU\");
            createfolder(path, "Tools");
            //filename = up_photo.PostedFile.FileName.ToString();
            filename = System.IO.Path.GetFileName(up_photo.PostedFile.FileName.ToString());
            // string f_name = path + "Tools" + '\\' + Path.GetFileName(up_photo.PostedFile.FileName);
            up_photo.PostedFile.SaveAs(path + "Tools" + '\\' + filename);
        }


        try
        {
            string toolno = txt_toolnumber.SelectedValue.ToString();
            string avail = ddl_availability.Text.ToString();
            string station = txt_mstation.Value.ToString();
            string desc = txt_description.Value.ToString();
            string ret = txt_retension.Value.ToString();
            string issue = txt_issuedon.Value.ToString();
           // DateTime issue = Convert.ToDateTime(txt_issuedon.ToString());
            string qty = txt_quantity.Value.ToString();
            string maintain = txt_maintained.Value.ToString();
          // DateTime next = Convert.ToDateTime(txt_dueon.ToString());
          string next = txt_dueon.Value.ToString();

            string grom = "";
            string gto = "";
            string yfrom = "";
            string yto = "";
            string rfrom = "";
            string rto = "";
            string res = "";
            da = new SqlDataAdapter("select * from AbuToolMaster where ID='" + Convert.ToInt32(toolno) + "'", strConnString);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string grfrom = ds.Tables[0].Rows[0]["Gfrom"].ToString();
                string grto = ds.Tables[0].Rows[0]["Gto"].ToString();
                string ylfrom = ds.Tables[0].Rows[0]["Yfrom"].ToString();
                string ylto = ds.Tables[0].Rows[0]["Yto"].ToString();
                string rdfrom = ds.Tables[0].Rows[0]["Rfrom"].ToString();
                string rdto = ds.Tables[0].Rows[0]["Rto"].ToString();

                double gf = (Convert.ToInt32(ret)) * ((Convert.ToDouble(grto) / 100));
                double yf = (Convert.ToInt32(ret)) * ((Convert.ToDouble(ylfrom) / 100));
                double yt = (Convert.ToInt32(ret)) * ((Convert.ToDouble(ylto) / 100));
                double rf = (Convert.ToInt32(ret)) * ((Convert.ToDouble(rdfrom) / 100));
                double rt = (Convert.ToInt32(ret)) * ((Convert.ToDouble(rdto) / 100));

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

            }
            cmd = new SqlCommand("SaveAbuMaster", strConnString);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@toolno", SqlDbType.VarChar, 50).Value = toolno.ToString();
            cmd.Parameters.Add("@availbility", SqlDbType.VarChar, 15).Value = avail.ToString();
            cmd.Parameters.Add("@station", SqlDbType.VarChar, 50).Value = station.ToString();
            cmd.Parameters.Add("@description", SqlDbType.VarChar, 500).Value = desc.ToString();
            cmd.Parameters.Add("@photo", SqlDbType.VarChar, 500).Value = filename.ToString();
            cmd.Parameters.Add("@rentime", SqlDbType.VarChar, 10).Value = ret.ToString();
            cmd.Parameters.Add("@issued", SqlDbType.VarChar, 10).Value = issue.ToString();
            cmd.Parameters.Add("@qty", SqlDbType.VarChar, 50).Value = qty.ToString();
            cmd.Parameters.Add("@maintain", SqlDbType.VarChar, 50).Value = maintain.ToString();
            cmd.Parameters.Add("@nextdue", SqlDbType.VarChar, 10).Value = rto.ToString();
            cmd.Parameters.Add("@gf", SqlDbType.DateTime).Value = Convert.ToDateTime(grom.ToString());
            cmd.Parameters.Add("@gt", SqlDbType.DateTime).Value = Convert.ToDateTime(gto.ToString());
            cmd.Parameters.Add("@yf", SqlDbType.DateTime).Value = Convert.ToDateTime(yfrom.ToString());
            cmd.Parameters.Add("@yt", SqlDbType.DateTime).Value = Convert.ToDateTime(yto.ToString());
            cmd.Parameters.Add("@rf", SqlDbType.DateTime).Value = Convert.ToDateTime(rfrom.ToString());
            cmd.Parameters.Add("@rt", SqlDbType.DateTime).Value = Convert.ToDateTime(rto.ToString());
            cmd.Parameters.Add("@drawing", SqlDbType.VarChar, 500).Value = filename1.ToString();

            strConnString.Open();
            cmd.ExecuteNonQuery();
            strConnString.Close();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            cleardata();
            loadgrid();
        }

    }

    
    public void loadgrid()
    {
        da = new SqlDataAdapter("select ROW_NUMBER() over (order by b.ToolNumber) as IndexNo, a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active'", strConnString);
        ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds);
        da.Fill(dt);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //GridView1.DataSource = dt.DefaultView;
            //GridView1.DataBind();

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
            GridView1.DataSource = paging;
            GridView1.DataBind();
            createpaging();
            btn_excel.Visible = true;
        }
        else
        {
            btn_excel.Visible = false;
        }
    }
    public void createfolder(string filepath, string date)
    {
        DirectoryInfo dirifo = new DirectoryInfo(filepath);
        dirifo.CreateSubdirectory(date);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            Label ID = e.Row.FindControl("lbl_id") as Label;
            Image image = e.Row.FindControl("ph_image") as Image;
            //Image ph_drawing = e.Row.FindControl("ph_drawing") as Image;
            //LinkButton ph_drawing = e.Row.FindControl("ph_drawing") as LinkButton;
            HyperLink ph_drawing = e.Row.FindControl("ph_drawing") as HyperLink;
            TableCell cell = e.Row.Cells[15];
            Label lbl_retine = e.Row.FindControl("lbl_retine") as Label;
            Label lbl_status = e.Row.FindControl("lbl_status") as Label;
            Label lbl_maintain = e.Row.FindControl("lbl_maintain") as Label;
            if (ID.Text != "" && ID.Text != null)
            {
                da = new SqlDataAdapter("select * from Abu_Master where ID='" + Convert.ToInt32(ID.Text.ToString()) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select ROW_NUMBER() over (order by min(ToolNumber)) as IndexNo,min(SID) as SID,min(ToolNumber)as ToolNumber,min(Maximum)as Maximum,min(Minimum) as Minimum,min(CurrentStock) as TotalCount,min(Tool) as Tool  from SpareView  where Toolnumber='" + Convert.ToInt32(ds.Tables[0].Rows[0]["ToolNumber"].ToString()) + "' group by Toolnumber", strConnString);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        lbl_maintain.Text = ds1.Tables[0].Rows[0]["TotalCount"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Photo"] != null && ds.Tables[0].Rows[0]["Photo"].ToString() != "")
                    {
                        //string name = ds.Tables[0].Rows[0]["Photo"].ToString();
                        //name = name.Substring(name.Length - 4);
                        //if (name != ".png" && name != ".jpg" && name != ".jpeg")
                        //{
                        //    image.ImageUrl = "~/ABU/Tools/video.png";
                        //}
                        //else
                        //{
                        image.ImageUrl = "~/ABU/Tools/" + ds.Tables[0].Rows[0]["Photo"].ToString();
                        // }
                    }
                    else
                    {
                        image.ImageUrl = "~/Menu_image/noimage.png";
                    }

                    if (ds.Tables[0].Rows[0]["Drawings"] != null && ds.Tables[0].Rows[0]["Drawings"].ToString() != "")
                    {
                        ph_drawing.Text = ds.Tables[0].Rows[0]["Drawings"].ToString();
                        ph_drawing.NavigateUrl = "~/ABU/Drawing/" + ds.Tables[0].Rows[0]["Drawings"].ToString();
                    }
                    else
                    {
                        ph_drawing.Text = "noimage.png";
                        ph_drawing.NavigateUrl = "~/Menu_image/noimage.png";
                    }
                    if (ds.Tables[0].Rows[0]["LifeExtend"] != null && ds.Tables[0].Rows[0]["LifeExtend"].ToString() != "")
                    {
                        int from = Convert.ToInt32(ds.Tables[0].Rows[0]["Rentime"].ToString());
                        int to = Convert.ToInt32(ds.Tables[0].Rows[0]["LifeExtend"].ToString());
                        int tot = from + to;
                        lbl_retine.Text = tot.ToString();
                    }
                    else
                    {
                        lbl_retine.Text = ds.Tables[0].Rows[0]["Rentime"].ToString();
                    }
                    string setColorClass = string.Empty;
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenTo"].ToString()))
                    {
                        setColorClass = "Green";
                        lbl_status.Text = "Fixture life at<br> usable condition";
                    }
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowTo"].ToString()))
                    {
                        setColorClass = "Yellow";
                        lbl_status.Text = "Alert for fixture Calibration<br>& Re order Zone";
                    }
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                    {
                        setColorClass = "Red";
                        lbl_status.Text = "Fixture life Completed";
                    }
                    else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                    {
                        setColorClass = "Red";
                        lbl_status.Text = "Fixture life Completed";
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

    protected void ph_drawing_Click(object sender, EventArgs e)
    {
        LinkButton lnk = sender as LinkButton;
        Label Label1 = lnk.NamingContainer.FindControl("ph_drawing") as Label;

        string dpath = lnk.PostBackUrl;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + dpath + "','_blank');", true);
        
    }
    public void cleardata()
    {
        BindToolNumber();
        ddl_replaced.Text = "0";
        ddl_availability.Text = "0";
        txt_mstation.Value = "";
        txt_description.Value = "";
        txt_retension.Value = "";
        txt_issuedon.Value = "";
        txt_quantity.Value = "";
        txt_maintained.Value = "";
        txt_dueon.Value = "";
    }
    protected void btn_update_Click(object sender, ImageClickEventArgs e)
    {
        string path = "";
        string filename = "";
        string filename1 = "";
        string Id = hdn_id.Value.ToString();
        if (fld_drawings.HasFile)
        {
            string path1 = Server.MapPath("~/ABU/");
            createfolder(path1, "Drawing");
            filename1 = System.IO.Path.GetFileName(fld_drawings.PostedFile.FileName.ToString());
            string f_name = path1 + "Drawing" + '\\' + Path.GetFileName(fld_drawings.PostedFile.FileName);
            fld_drawings.PostedFile.SaveAs(path1 + "Drawing" + '\\' + filename1);

        }
        else
        {
            da = new SqlDataAdapter("select * from Abu_Master where ID='" + Convert.ToInt32(Id) + "'", strConnString);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                filename1 = ds.Tables[0].Rows[0]["Drawings"].ToString();
            }
        }
        if (up_photo.HasFile)
        {
            path = Server.MapPath("~/ABU/");
            createfolder(path, "Tools");
            filename = System.IO.Path.GetFileName(up_photo.PostedFile.FileName.ToString());
            string f_name = path + "Tools" + '\\' + Path.GetFileName(up_photo.PostedFile.FileName);
            up_photo.PostedFile.SaveAs(path + "Tools" + '\\' + filename);

        }
        else
        {
            da = new SqlDataAdapter("select * from Abu_Master where ID='" + Convert.ToInt32(Id) + "'", strConnString);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                filename = ds.Tables[0].Rows[0]["Photo"].ToString();
            }
        }
        try
        {
            int toolno = 0, ret = 0;
            da = new SqlDataAdapter("select * from Abu_Master where ID='" + Convert.ToInt32(Id) + "'", strConnString);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (txt_toolnumber.SelectedValue.ToString() == "0")
                {
                    toolno = Convert.ToInt32(ds.Tables[0].Rows[0]["ToolNumber"].ToString());
                }
                else
                {
                    toolno = Convert.ToInt32(txt_toolnumber.SelectedValue.ToString());
                }
            }

            string avail = ddl_availability.Text.ToString();
            string station = txt_mstation.Value.ToString();
            string desc = txt_description.Value.ToString();
            if (txt_retension.Value.ToString() == "")
            {
                ret = Convert.ToInt32(ds.Tables[0].Rows[0]["Rentime"].ToString());
            }
            else
            {
                ret = Convert.ToInt32(txt_retension.Value.ToString());
            }

            string issue = txt_issuedon.Value.ToString();
            string qty = txt_quantity.Value.ToString();
            string maintain = hdn_sparecount1.Value.ToString();
            string next = txt_dueon.Value.ToString();
            if (txt_extended.Value.ToString() == "")
            {
                txt_extended.Value = "0";
            }
            int total = Convert.ToInt32(ret) + Convert.ToInt32(txt_extended.Value.ToString());

            string grom = "";
            string gto = "";
            string yfrom = "";
            string yto = "";
            string rfrom = "";
            string rto = "";

            string res = "";

            da = new SqlDataAdapter("select * from AbuToolMaster where ID='" + Convert.ToInt32(toolno) + "'", strConnString);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string grfrom = ds.Tables[0].Rows[0]["Gfrom"].ToString();
                string grto = ds.Tables[0].Rows[0]["Gto"].ToString();
                string ylfrom = ds.Tables[0].Rows[0]["Yfrom"].ToString();
                string ylto = ds.Tables[0].Rows[0]["Yto"].ToString();
                string rdfrom = ds.Tables[0].Rows[0]["Rfrom"].ToString();
                string rdto = ds.Tables[0].Rows[0]["Rto"].ToString();

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

            }
            else
            {
            }
            if (ddl_replaced.SelectedValue.ToString() != "0")
            {
                var query = (from table in objcontext.Abu_Masters where table.ID == Convert.ToInt32(Id) select table).First();
                if (query != null)
                {
                    query.Spare = ddl_replaced.SelectedValue.ToString();
                    query.LifeExtend = txt_extended.Value.ToString();
                    query.ToolStatus = "Inactive";
                    query.ModifyDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    objcontext.SubmitChanges();
                    cleardata();
                    loadgrid();
                }
                else
                {
                }
                string date = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                objabu = new Abu_Master()
                {
                    ToolNumber = toolno.ToString(),
                    Availability = avail.ToString(),
                    Station = station.ToString(),
                    Description = desc.ToString(),
                    Photo = filename.ToString(),
                    Rentime = ret.ToString(),
                    Issuedon = issue.ToString(),
                    StationQty = qty.ToString(),
                    Nextdueon = rto.ToString(),
                    GreenFrom = Convert.ToDateTime(grom.ToString()),
                    GreenTo = Convert.ToDateTime(gto.ToString()),
                    YellowFrom = Convert.ToDateTime(yfrom.ToString()),
                    YellowTo = Convert.ToDateTime(yto.ToString()),
                    RedFrom = Convert.ToDateTime(rfrom.ToString()),
                    RedTo = Convert.ToDateTime(rto.ToString()),
                    Spare = ddl_replaced.SelectedValue.ToString(),
                    LifeExtend = txt_extended.Value.ToString(),
                    Rectified = txt_rectified.Value.ToString(),
                    Others = txt_others.Value.ToString(),
                    Premature = txt_premature.Value.ToString(),
                    Maintained = maintain.ToString(),
                    ToolStatus = "Active",
                    Drawings = filename1,
                    MailFlag = "",
                    ModifyDate=Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
                };
                objcontext.Abu_Masters.InsertOnSubmit(objabu);
                objcontext.SubmitChanges();
                cleardata();
                loadgrid();
                //objcontext = new QualitySheetdclassDataContext();
                //var query1 = (from table in objcontext.SpareMasters where table.ToolNumber == toolno.ToString() select table).First();
                //if (query1 != null)
                //{
                //    query1.TotalCount = hdn_sparecount1.Value.ToString();
                //    objcontext.SubmitChanges();
                //}
                //else
                //{
                //}
            }
            else
            {
                var query2 = (from table in objcontext.Abu_Masters where table.ToolNumber == toolno.ToString() && table.ToolStatus =="Active" select table).First();

                //if (query2 != null)
                //{
                //    query2.Spare = ddl_replaced.SelectedValue.ToString();
                //    query2.LifeExtend = txt_extended.Value.ToString();
                //    query2.ToolStatus = "Inactive";
                //    query2.ModifyDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                //    objcontext.SubmitChanges();
                //    cleardata();
                //    loadgrid();
                //}
                //else
                //{
                //}
                string date = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                if (query2 != null)
                {
                    query2.ToolNumber = toolno.ToString();
                    query2.Availability = avail.ToString();
                    query2.Station = station.ToString();
                    query2.Description = desc.ToString();
                    query2.Photo = filename.ToString();
                    query2.Rentime = ret.ToString();
                    query2.Issuedon = issue.ToString();
                    query2.StationQty = qty.ToString();
                    query2.Nextdueon = rto.ToString();
                    query2.GreenFrom = Convert.ToDateTime(grom.ToString());
                    query2.GreenTo = Convert.ToDateTime(gto.ToString());
                    query2.YellowFrom = Convert.ToDateTime(yfrom.ToString());
                    query2.YellowTo = Convert.ToDateTime(yto.ToString());
                    query2.RedFrom = Convert.ToDateTime(rfrom.ToString());
                    query2.RedTo = Convert.ToDateTime(rto.ToString());

                    query2.Drawings = filename1;
                    objcontext.SubmitChanges();
                    cleardata();
                    loadgrid();
                }
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            cleardata();
            loadgrid();
        }
    }
    protected void txt_toolnumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(txt_toolnumber.SelectedValue.ToString());

            var query = (from table in objcontext.AbuToolMasters where table.ID == id select table).First();
            if (query != null)
            {
                txt_retension.Value = query.RetensionTime.ToString();
            }
            var query1 = (from table1 in objcontext.SpareMasters where table1.ToolNumber == id.ToString() select table1).FirstOrDefault();
            if (query1 != null)
            {
                txt_maintained.Value = query1.TotalCount.ToString();
            }

        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }
    protected void OnDataBound(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count > 0)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
         
            for (int i = 1; i < GridView1.Columns.Count; i++)
            {
                TableHeaderCell cell = new TableHeaderCell();
                TextBox txtSearch = new TextBox();
                txtSearch.Attributes["placeholder"] = "Filter";
                txtSearch.CssClass = "search_textbox";
                cell.Controls.Add(txtSearch);
                row.Controls.Add(cell);
            }
            GridView1.HeaderRow.Parent.Controls.AddAt(1, row);
        }
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
        //rpt.ExportToHttpResponse(formatType, Response, true, "ToolAssign");
        //Response.End();
        loadexcelgrid();
    }
    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        MemoryStream ms = new MemoryStream();
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        return ms.ToArray();
    }
    public void loadexcelgrid() //ReportDocument rpt
    {
        da = new SqlDataAdapter("select ROW_NUMBER() over (order by b.ToolNumber) as IndexNo, a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active'", strConnString);
        ds = new DataSet();
        DataTable dt = new DataTable("Abu_Master");
        dt.Clear();
        da.Fill(ds);
        da.Fill(dt);
        dt.Columns.Add("PhotoImg", System.Type.GetType("System.Byte[]"));
        dt.Columns.Add("Remarks");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                FileStream fs;
                BinaryReader br;

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "ABU\\Tools\\" + dt.Rows[i]["Photo"].ToString()))
                {
                    // open image in file stream
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "ABU\\Tools\\" + dt.Rows[i]["Photo"].ToString(), FileMode.Open);
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
                if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenTo"].ToString()))
                {
                    dt.Rows[i]["Remarks"] = "Fixture life at usable condition";
                }
                if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowTo"].ToString()))
                {
                    dt.Rows[i]["Remarks"] = "Alert for fixture Calibration & Re order Zone";
                }
                if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                {
                    dt.Rows[i]["Remarks"] = "Fixture life Completed";
                }
                else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                {
                    dt.Rows[i]["Remarks"] = "Fixture life Completed";
                }
            }

            //ReportDocument rpt = new ReportDocument();
            //rpt.Load(Server.MapPath("~/ABU/ToolAssignRpt.rpt"));
            //rpt.SetDataSource(dt);
            //CRV.ReportSource = rpt;
        }
        else
        {
        }
    }
}