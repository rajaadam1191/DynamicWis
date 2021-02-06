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

public partial class ABU_Ranges : System.Web.UI.Page
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
    public AbuToolFeedback objf = new AbuToolFeedback();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "")
            {
                if (Session["User_Role"].ToString().ToLower() == "user")
                {
                    div_user.Visible = true;

                }
            }
            else
            {
                Response.Redirect("../Home.aspx");
            }
            sp_logdate.InnerText = Session["LogDate"].ToString();
            sp_logtimr.InnerText = Session["Logtime"].ToString();
            sp_username.InnerText = Session["User_Name"].ToString();
           // BindToolNumber();
            loadgrid();
        }
    }
    //private void BindToolNumber()
    //{
    //    ds = objserver.GetDateset("select '0' ID,'--- Select Tool Number ---' ToolNumber union select distinct ID,ToolNumber from AbuToolMaster");
    //    txt_rtoolnumber.DataSource = ds.Tables[0];
    //    txt_rtoolnumber.DataValueField = "ID";
    //    txt_rtoolnumber.DataTextField = "ToolNumber";
    //    txt_rtoolnumber.DataBind();
    //}
    public void loadgrid()
    {
        try
        {
            //cmd = new SqlCommand("gettooranges", strConnString);
            //cmd.CommandType = CommandType.StoredProcedure;
            //strConnString.Open();
            //cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
            da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from AbuToolFeedback  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID", strConnString);
            ds = new DataSet();
            da.Fill(ds);
           // strConnString.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid_abumaster.DataSource = ds.Tables[0];
                grid_abumaster.DataBind();
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
    protected void grid_abumaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label ID = e.Row.FindControl("lbl_id") as Label;
            Label lbl_feedback = e.Row.FindControl("lbl_feedback") as Label;
            Label lbl_reponser = e.Row.FindControl("lbl_reponser") as Label;
            //  Image image = e.Row.FindControl("ph_image") as Image;
            TableCell cell = e.Row.Cells[2];
            if (ID.Text != "" && ID.Text != null)
            {
                da = new SqlDataAdapter("select * from AbuToolFeedback where ID='" + Convert.ToInt32(ID.Text.ToString()) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                  ////  image.ImageUrl = "~/ABU/Tools/" + ds.Tables[0].Rows[0]["Photo"].ToString();
                   //string setColorClass = string.Empty;
                  //  if (DateTime.Now >= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenFrom"].ToString()) && DateTime.Now <= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenTo"].ToString()))
                  //  {
                  //      setColorClass = "Green";
                  //  }
                  //  if (DateTime.Now >= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowFrom"].ToString()) && DateTime.Now <= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowTo"].ToString()))
                  //  {
                  //      setColorClass = "Yellow";
                  //  }
                  //  if (DateTime.Now >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedFrom"].ToString()) && DateTime.Now <= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                  //  {
                     //   setColorClass = "Red";
                   // }
                 //  setColorClass = "Blue";
                   // cell.CssClass = setColorClass;
                    if (ds.Tables[0].Rows[0]["Response"] != null && ds.Tables[0].Rows[0]["Response"].ToString() != "")
                    {
                        lbl_reponser.Text = ds.Tables[0].Rows[0]["Response"].ToString();
                        lbl_reponser.CssClass = "textcolor";
                    }
                    else
                    {
                        lbl_reponser.Text = "Pending";
                        lbl_reponser.CssClass = "textcolor1";
                    }
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
    //protected void btn_savefeed_Click(object sender, ImageClickEventArgs e)
    //{
    //    objcontext = new QualitySheetdclassDataContext();
    //    var query = (from table in objcontext.Abu_Masters where table.ID == Convert.ToInt32(hdn_toid.Value.ToString()) select table).First();
    //    if (query != null)
    //    {
    //        objf = new AbuToolFeedback()
    //        {
    //            ToolNumber = query.ToolNumber.ToString(),
    //            Station = query.Station.ToString(),
    //            FeedBack = txt_response.Value.ToString(),
    //            ReTime = query.Rentime.ToString(),
    //            Issued = query.Issuedon.ToString(),
    //            NextDue = query.Nextdueon.ToString(),
    //            Response = ""
    //        };
    //        objcontext.AbuToolFeedbacks.InsertOnSubmit(objf);
    //        objcontext.SubmitChanges();
    //    }
    //    else
    //    {
    //    }
        
        
       
    //}
    //protected void btn_save_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        cmd = new SqlCommand("savetoolfeedback", strConnString);
    //        cmd.CommandType = CommandType.StoredProcedure;

    //        cmd.Parameters.Add("@TNo", SqlDbType.VarChar, 100).Value = txt_rtoolnumber.SelectedValue.ToString();
    //        cmd.Parameters.Add("@station", SqlDbType.VarChar, 50).Value = txt_rstation.Value.ToString();
    //        cmd.Parameters.Add("@fb", SqlDbType.VarChar, 500).Value = txt_rfeedback.Value.ToString();
    //        cmd.Parameters.Add("@rtime", SqlDbType.VarChar, 10).Value = txt_rretension.Value.ToString();
    //        cmd.Parameters.Add("@issued", SqlDbType.VarChar, 10).Value = txt_rissuedon.Value.ToString();
    //        cmd.Parameters.Add("@nextdue", SqlDbType.VarChar, 10).Value = txt_rdueon.Value.ToString();
    //        cmd.Parameters.Add("@req", SqlDbType.DateTime).Value = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
    //        strConnString.Open();
    //        cmd.ExecuteNonQuery();
    //        strConnString.Close();
    //        //objcontext = new QualitySheetdclassDataContext();
    //        //objf = new AbuToolFeedback()
    //        //{
    //        //    ToolNumber = txt_rtoolnumber.SelectedValue.ToString(),
    //        //    Station = txt_rstation.Value.ToString(),
    //        //    FeedBack = txt_rfeedback.Value.ToString(),
    //        //    ReTime = txt_rretension.Value.ToString(),
    //        //    Issued = txt_rissuedon.Value.ToString(),
    //        //    NextDue = txt_rdueon.Value.ToString(),
    //        //    ReqDate = DateTime.Now,
    //        //    Response = ""
    //        //};
    //        BindToolNumber();
    //        txt_rstation.Value = "";
    //        txt_rfeedback.Value = "";
    //        txt_rretension.Value = "";
    //        txt_rissuedon.Value = "";
    //        txt_rdueon.Value = "";
    //        //objcontext.AbuToolFeedbacks.InsertOnSubmit(objf);
    //        // objcontext.SubmitChanges();
    //        loadgrid();
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //    finally
    //    {
    //    }

    //}
    protected void OnDataBound(object sender, EventArgs e)
    {
        if (grid_abumaster.Rows.Count > 0)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            for (int i = 1; i < grid_abumaster.Columns.Count; i++)
            {
                TableHeaderCell cell = new TableHeaderCell();
                TextBox txtSearch = new TextBox();
                txtSearch.Attributes["placeholder"] = "Filter";
                txtSearch.CssClass = "search_textbox";
                cell.Controls.Add(txtSearch);
                row.Controls.Add(cell);
            }
            grid_abumaster.HeaderRow.Parent.Controls.AddAt(1, row);
        }
    }

    public void B1_Click(Object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = @"application\octet-stream";
        System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath("~/ABU/FileUpload/Tool master list.xlsx"));
        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(file.FullName);
        Response.Flush();
    }
    public void B2_Click(Object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = @"application\octet-stream";
        System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath("~/ABU/FileUpload/TOOLS INSPECTION CHECK LIST.xlsx"));
        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(file.FullName);
        Response.Flush();
    }
    public void B3_Click(Object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = @"application\octet-stream";
        System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath("~/ABU/FileUpload/TOOL TRY OUT & INSPECTION REPORT.xls"));
        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(file.FullName);
        Response.Flush();
    }
    public void B4_Click(Object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = @"application\octet-stream";
        System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath("~/ABU/FileUpload/TOOL TRIAL REPORT.xlsx"));
        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(file.FullName);
        Response.Flush();
    }
    public void B5_Click(Object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = @"application\octet-stream";
        System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath("~/ABU/FileUpload/TOOL FAILURE REPROT.xlsx"));
        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(file.FullName);
        Response.Flush();
    }
    public void B6_Click(Object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = @"application\octet-stream";
        System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath("~/ABU/FileUpload/TOOL DISPOSAL NOTE.doc"));
        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(file.FullName);
        Response.Flush();
    }
    public void B7_Click(Object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = @"application\octet-stream";
        System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath("~/ABU/FileUpload/CONSUMABLE TRANSFER NOTE.xls"));
        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(file.FullName);
        Response.Flush();
    }
}
