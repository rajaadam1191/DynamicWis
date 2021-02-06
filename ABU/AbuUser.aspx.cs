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
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mime;

public partial class ABU_AbuUser : System.Web.UI.Page
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
    public StringBuilder sb = new StringBuilder();
    public int toolid;
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
                HttpContext.Current.Response.Redirect("../Home.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            sp_logdate.InnerText = Session["LogDate"].ToString();
            sp_logtimr.InnerText = Session["Logtime"].ToString();
            sp_username.InnerText = Session["User_Name"].ToString();
           // BindToolNumber();
            loadgrid();
            loadgridHMC();
            loadgridTMC();
        }
    }
    //private void BindToolNumber()
    //{

    //    ds = objserver.GetDateset("select '--- Select Unit ---' Unit,'--- Select Unit ---' Unit union select distinct Unit,Unit from AbuToolMaster");
    //    ddl_toolnumber.DataSource = ds.Tables[0];

    //    ddl_toolnumber.DataValueField = "Unit";
    //    ddl_toolnumber.DataTextField = "Unit";
    //    ddl_toolnumber.DataBind();
    //}
    public void loadgrid()
    {
        da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active' and b.Unit='ABU'", strConnString);
        ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds);
        da.Fill(dt);
        if (ds.Tables[0].Rows.Count > 0)
        {
          //  grid_abumaster.DataSource = ds.Tables[0];
           // grid_abumaster.DataBind();
            ddl_gridlist.DataSource = dt;
            ddl_gridlist.DataBind();
        }
        else
        {
        }
        //BindToolNumber();
    }
    public void loadgridHMC()
    {
        da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active' and b.Unit='HMC'", strConnString);
        ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds);
        da.Fill(dt);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_hmc.DataSource = dt;
            ddl_hmc.DataBind();
        }
        else
        {
        }
    }
    public void loadgridTMC()
    {
        da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active' and b.Unit='TMC'", strConnString);
        ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds);
        da.Fill(dt);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_tmc.DataSource = dt;
            ddl_tmc.DataBind();
        }
        else
        {
        }
    }
    //protected void grid_abumaster_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Label ID = e.Row.FindControl("lbl_id") as Label;
    //        Image image = e.Row.FindControl("ph_image") as Image;
    //        Image ph_drawing = e.Row.FindControl("ph_drawing") as Image;
    //        Label lbl_status = e.Row.FindControl("lbl_status") as Label;
    //        HtmlImage img_feedback = e.Row.FindControl("img_feedback") as HtmlImage;
    //        Label lbl_feedback = e.Row.FindControl("lbl_feedback") as Label;
    //        TableCell cell = e.Row.Cells[13];
    //        if (ID.Text != "" && ID.Text != null)
    //        {
    //            da = new SqlDataAdapter("select * from Abu_Master where ID='" + Convert.ToInt32(ID.Text.ToString()) + "'", strConnString);
    //            ds = new DataSet();
    //            da.Fill(ds);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {


    //                if (ds.Tables[0].Rows[0]["Photo"] != null && ds.Tables[0].Rows[0]["Photo"].ToString() != "")
    //                {
    //                    //string name = ds.Tables[0].Rows[0]["Photo"].ToString();
    //                    //name = name.Substring(name.Length - 4);
    //                    //if (name != ".png" && name != ".jpg" && name != ".jpeg")
    //                    //{
    //                    //    image.ImageUrl = "~/ABU/Tools/video.png";
    //                    //}
    //                    //else
    //                    //{
    //                    image.ImageUrl = "~/ABU/Tools/" + ds.Tables[0].Rows[0]["Photo"].ToString();
    //                    //}
    //                }
    //                else
    //                {
    //                    image.ImageUrl = "~/Menu_image/noimage.png";
    //                }

    //                if (ds.Tables[0].Rows[0]["Drawings"] != null && ds.Tables[0].Rows[0]["Drawings"].ToString() != "")
    //                {
    //                    ph_drawing.ImageUrl = "~/ABU/Drawing/" + ds.Tables[0].Rows[0]["Drawings"].ToString();
    //                }
    //                else
    //                {
    //                    ph_drawing.ImageUrl = "~/Menu_image/noimage.png";
    //                }

    //                string setColorClass = string.Empty;
    //                if (DateTime.Now >= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenFrom"].ToString()) && DateTime.Now <= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenTo"].ToString()))
    //                {
    //                    setColorClass = "Green";
    //                    lbl_status.Text = "Fixture life at<br> usable condition";
    //                }
    //                if (DateTime.Now >= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowFrom"].ToString()) && DateTime.Now <= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowTo"].ToString()))
    //                {
    //                    setColorClass = "Yellow";
    //                    lbl_status.Text = "Alert for fixture Calibration<br>& Re order Zone";
    //                }
    //                if (DateTime.Now >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedFrom"].ToString()) && DateTime.Now <= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
    //                {
    //                    setColorClass = "Red";
    //                    lbl_status.Text = "Fixture life Completed";
    //                }
    //                //e.Row.CssClass = setColorClass;
    //                cell.CssClass = setColorClass;
    //            }
    //            else
    //            {
    //            }
    //            SqlDataAdapter da1 = new SqlDataAdapter("select * from AbuToolFeedback where ToolNumber='" + ds.Tables[0].Rows[0]["ToolNumber"].ToString() + "'", strConnString);
    //            DataSet ds1 = new DataSet();
    //            da1.Fill(ds1);
    //            if (ds1.Tables[0].Rows.Count > 0)
    //            {
    //                if (ds1.Tables[0].Rows[0]["FeedBack"] != null && ds1.Tables[0].Rows[0]["FeedBack"].ToString() != "")
    //                {
    //                    lbl_feedback.Text = ds1.Tables[0].Rows[0]["FeedBack"].ToString();
    //                    img_feedback.Visible = false;
    //                    lbl_feedback.Visible = true;
    //                }
    //                else
    //                {
    //                    img_feedback.Src = "~/Images/edit.png";
    //                    img_feedback.Attributes.Add("onclick", "response('" + ID.Text + "',event)");
    //                    img_feedback.Visible = true;
    //                    lbl_feedback.Visible = false;

    //                }

    //            }
    //            else
    //            {
    //                img_feedback.Src = "~/Images/edit.png";
    //                img_feedback.Visible = true;
    //                lbl_feedback.Visible = false;
    //                img_feedback.Attributes.Add("onclick", "response('" + ID.Text + "',event)");
    //            }


    //        }
    //        else
    //        {
    //        }

    //    }
    //}
    //protected void ddl_toolnumber_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    loadgrid(ddl_toolnumber.SelectedValue.ToString());
    //}
    protected void btn_savefeed_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            var query = (from table in objcontext.Abu_Masters where table.ID == Convert.ToInt32(hdn_fid.Value.ToString()) select table).FirstOrDefault();
            if (query != null)
            {
                cmd = new SqlCommand("savetoolfeedback", strConnString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TNo", SqlDbType.VarChar, 100).Value = query.ToolNumber.ToString();
                cmd.Parameters.Add("@station", SqlDbType.VarChar, 50).Value = query.Station.ToString();
                cmd.Parameters.Add("@fb", SqlDbType.VarChar, 500).Value = txt_response.Value.ToString();
                cmd.Parameters.Add("@rtime", SqlDbType.VarChar, 10).Value = query.Rentime.ToString();
                cmd.Parameters.Add("@issued", SqlDbType.VarChar, 10).Value = query.Issuedon.ToString();
                cmd.Parameters.Add("@nextdue", SqlDbType.VarChar, 10).Value = query.Nextdueon.ToString();
                cmd.Parameters.Add("@req", SqlDbType.DateTime).Value = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                if (txt_response.Value != "")
                {
                    feedbackmail(query.ToolNumber.ToString(), query.Station.ToString());
                }
                txt_response.Value = "";
               
               // loadgrid(ddl_toolnumber.SelectedValue.ToString());
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
  //public void feedbackmail(string toolno,string station)
  //  {



  //      DataSet ds1 = new DataSet();
  //      ds1.Tables.Clear();
  //      SqlDataAdapter da2 = new SqlDataAdapter("select * from MailAutorized", strConnString);
  //      DataSet ds2 = new DataSet();
  //      da2.Fill(ds2);
  //      if (ds2.Tables[0].Rows.Count > 0)
  //      {
  //          for (int n = 0; n < ds2.Tables[0].Rows.Count; n++)
  //          {
  //              //string from = "tlmautomail@gmail.com";
  //              //string to = ds2.Tables[0].Rows[n]["MailID"].ToString();
  //              //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
  //              //mail.To.Add(to);
  //              ////mail.From = new MailAddress(from, Session["User_Name"].ToString(), System.Text.Encoding.UTF8);
  //              ////mail.Subject = "Tool Feedback Details";
  //              ////mail.Body = "Dear Sir/Madam,  <br/> <br/> Tool Number -" + toolno.ToString() + "<br/>Station:" + station.ToString() + "<br/>Feedback:" + txt_response.Value.ToString();
  //              //mail.From = new MailAddress(from, "Tool Feedback", System.Text.Encoding.UTF8);
  //              //mail.Subject = "Tool Feedback Details";
  //              ////mail.Body = "Dear Sir, KFA for the Tools life details,";
  //              //string Inlineimage = Server.MapPath("~/ABU/Mail/mail_Feed.jpg");
  //              //string Inlineimg = Server.MapPath("~/ABU/Mail/mail_Feed");
  //              //sb.Length = 0;

  //              //LinkedResource myimage = new LinkedResource(Inlineimage);
  //              //myimage.ContentId = Guid.NewGuid().ToString();
  //              //sb.Append("<html><body><div style='width: 100%;'><img src='cid:" + myimage.ContentId + "'></div><div style='height:10px;'></div><table style='width: 100%;border:1px solid black;border-collapse: collapse;'><tr style='background-color: #fff; height: 35px;'><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture No</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Station</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Feedback</span></td></tr>");

  //              //da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active' and a.ID='" + Convert.ToInt32(hdn_fid.Value.ToString()) + "'", strConnString);
  //              //ds1 = new DataSet();
  //              //da.Fill(ds1);
  //              //if (ds1.Tables[0].Rows.Count > 0)
  //              //{
  //              //    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
  //              //    {
  //              //        sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + Session["User_Name"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + toolno.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds1.Tables[0].Rows[i]["Tool"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + station.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + txt_response.Value.ToString() + "</span></td></tr>");
  //              //    }
  //              //}
  //              //sb.Append("</table></body></html>");
  //              //string mailbody = sb.ToString();

  //              //// Create HTML view
  //              //AlternateView htmlMail = AlternateView.CreateAlternateViewFromString(mailbody, null, "text/html");
  //              //// Set ContentId property. Value of ContentId property must be the same as
  //              //// the src attribute of image tag in email body. 
  //              //htmlMail.LinkedResources.Add(myimage);
  //              //mail.AlternateViews.Add(htmlMail);

  //              //mail.SubjectEncoding = System.Text.Encoding.UTF8;
  //              //mail.BodyEncoding = System.Text.Encoding.UTF8;
  //              //mail.IsBodyHtml = true;
  //              //mail.Priority = MailPriority.High;

  //              //SmtpClient client = new SmtpClient();
  //              //client.EnableSsl = true;
  //              //client.Port = Convert.ToInt32(587);
  //              //client.Host = "smtp.gmail.com";
  //              //client.Credentials = new System.Net.NetworkCredential("tlmautomail@gmail.com", "ph123456");

                
               
  //              MailMessage mail = new MailMessage();
  //              mail.From = new MailAddress("tlmautomail@gmail.com", "Pentanodes");
  //              //msgmail.Bcc.Add(new MailAddress(tobcc));
  //              //mail.To.Add(new MailAddress("tlmautomail@gmail.com"));
  //              //mail.To.Add(new MailAddress("sathishkumar.p@poclain.com"));
  //              // msgmail.Body = "test success";
  //              string to = ds2.Tables[0].Rows[n]["MailID"].ToString();
  //              mail.To.Add(new MailAddress(to));
  //              mail.Subject = "Tool Feedback Details";
  //              mail.IsBodyHtml = true;
  //              SmtpClient client = new SmtpClient();
  //              client.Credentials = new System.Net.NetworkCredential("tlmautomail@gmail.com", "ph123456");
  //              //client.Port = 25;
  //              //client.EnableSsl = true;
  //              client.Port = 587;
  //              client.EnableSsl = true;
  //              mail.BodyEncoding = System.Text.Encoding.UTF8;
  //              mail.SubjectEncoding = System.Text.Encoding.UTF8;
  //              client.Host = "smtp.gmail.com";
  //              string Inlineimage = Server.MapPath("~/ABU/Mail/mail_Feed.jpg");
  //              sb.Length = 0;
  //              LinkedResource myimage = new LinkedResource(Inlineimage);
  //              myimage.ContentId = Guid.NewGuid().ToString();
  //              //sb.Append("<html><body><div style='width: 100%;'><img src='cid:" + myimage.ContentId + "'></div><div style='height:10px;'></div><table style='width: 100%;border:1px solid black;border-collapse: collapse;'><tr style='background-color: #fff; height: 35px;'><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture No</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Station</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Feedback</span></td></tr>");
  //              sb.Append("<html><body><div style='height:10px;'></div><table style='width: 100%;border:1px solid black;border-collapse: collapse;'><tr style='background-color: #fff; height: 35px;'><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture No</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Station</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Feedback</span></td></tr>");

  //              da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active' and a.ID='" + Convert.ToInt32(hdn_fid.Value.ToString()) + "'", strConnString);
  //              ds1 = new DataSet();
  //              da.Fill(ds1);
  //              if (ds1.Tables[0].Rows.Count > 0)
  //              {
  //                  for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
  //                  {
  //                      sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + Session["User_Name"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + toolno.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds1.Tables[0].Rows[i]["Tool"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + station.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + txt_response.Value.ToString() + "</span></td></tr>");
  //                  }
  //              }
  //              sb.Append("</table></body></html>");
  //              string mailbody = sb.ToString();

  //              ////// Create HTML view
  //              ////AlternateView htmlMail = AlternateView.CreateAlternateViewFromString(mailbody, null, "text/html");
  //              ////// Set ContentId property. Value of ContentId property must be the same as
  //              ////// the src attribute of image tag in email body. 
  //              ////htmlMail.LinkedResources.Add(myimage);
  //              ////mail.AlternateViews.Add(htmlMail);

  //              string path = Server.MapPath("~/ABU/Feedback/");
  //              if (!Directory.Exists(path))
  //              {
  //                  Directory.CreateDirectory(path);
  //              }
  //              using (StringWriter sw = new StringWriter(sb))
  //              {
  //                  using (HtmlTextWriter hw = new HtmlTextWriter(sw))
  //                  {
  //                      StreamWriter writer = File.AppendText(path + "Feedback.xls");
  //                      hw.BeginRender();
  //                      string html = sb.ToString();
  //                      writer.WriteLine(html);
  //                      writer.Close();
  //                  }
  //              }

  //              mail.SubjectEncoding = System.Text.Encoding.UTF8;
  //              //E:\Louis\PH\PHWIS FIXTURE\Project_update\PhwisFixtures\ABU\Excel
  //              //  mail.Attachments.Add(new Attachment(@"E:\\Louis\\PH\\PHWIS FIXTURE\\Project_update\\PhwisFixtures\\ABU\\Excel\\Tools.xls"));
  //              string FileAttach = Server.MapPath("~/ABU/Feedback/");
  //              mail.Attachments.Add(new Attachment(FileAttach + "Feedback.xls"));

  //              mail.BodyEncoding = System.Text.Encoding.UTF8;
  //              mail.IsBodyHtml = true;
  //              mail.Priority = MailPriority.High;

  //              // SmtpClient client = new SmtpClient();
  //              client.EnableSsl = true;
  //              //client.Port = Convert.ToInt32(ds1.Tables[0].Rows[0]["Port"].ToString());
  //              client.Port = Convert.ToInt32(587);
  //              client.Host = "smtp.gmail.com";
  //              // client.Host = "smtp-mail.outlook.com";
  //              client.UseDefaultCredentials = false;
  //              //client.Credentials = new System.Net.NetworkCredential(ds1.Tables[0].Rows[0]["Username"].ToString(), ds1.Tables[0].Rows[0]["Password"].ToString());
  //              client.Credentials = new System.Net.NetworkCredential("tlmautomail@gmail.com", "ph123456");

  //              try
  //              {
  //                  client.Send(mail);
  //              }
  //              catch (Exception ex)
  //              {
  //                  Exception ex2 = ex;
  //                  string errorMessage = string.Empty;
  //                  while (ex2 != null)
  //                  {
  //                      errorMessage += ex2.ToString();
  //                      ex2 = ex2.InnerException;
  //                  }
  //                  HttpContext.Current.Response.Write(errorMessage);
  //              }
  //              mail.Dispose();
  //          }
  //      }
  //  }

  //public void feedbackmail(string toolno,string station)
  //  {
  //      DataSet ds1 = new DataSet();
  //      ds1.Tables.Clear();
  //      SqlDataAdapter da2 = new SqlDataAdapter("select * from MailAutorized", strConnString);
  //      DataSet ds2 = new DataSet();
  //      da2.Fill(ds2);
  //      sb.Length = 0;
  //      if (ds2.Tables[0].Rows.Count > 0)
  //      {
  //          string path = Server.MapPath("~/ABU/Feedback/");
  //          if (!Directory.Exists(path))
  //          {
  //              Directory.CreateDirectory(path);
  //          }
  //          if (System.IO.File.Exists(path + "Feedback.xls"))
  //          {
  //              // Use a try block to catch IOExceptions, to
  //              // handle the case of the file already being
  //              // opened by another process.
  //              try
  //              {
  //                  System.IO.File.Delete(path + "Feedback.xls");
  //              }
  //              catch (System.IO.IOException e)
  //              {
  //                  Console.WriteLine(e.Message);
  //                  return;
  //              }
  //          }

  //          sb.Append("<table style='width: 100%;border:1px solid black;border-collapse: collapse;'><tr style='background-color: #fff; height: 35px;'><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture No</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Station</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Feedback</span></td></tr>");

  //          da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active' and a.ID='" + Convert.ToInt32(hdn_fid.Value.ToString()) + "'", strConnString);
  //          ds1 = new DataSet();
  //          da.Fill(ds1);
  //          if (ds1.Tables[0].Rows.Count > 0)
  //          {
  //              for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
  //              {
  //                  sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + Session["User_Name"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + toolno.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds1.Tables[0].Rows[i]["Tool"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + station.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + txt_response.Value.ToString() + "</span></td></tr>");
  //              }
  //          }
  //          sb.Append("</table>");

            
  //          using (StringWriter sw = new StringWriter(sb))
  //          {
  //              using (HtmlTextWriter hw = new HtmlTextWriter(sw))
  //              {
  //                  StreamWriter writer = File.AppendText(path + "Feedback.xls");
  //                  hw.BeginRender();
  //                  string html = sb.ToString();
  //                  writer.WriteLine(html);
  //                  writer.Close();
  //              }
  //          }
  //          for (int n = 0; n < ds2.Tables[0].Rows.Count; n++)
  //          {
  //              //string from = "tlmautomail@gmail.com";
  //              //string to = ds2.Tables[0].Rows[n]["MailID"].ToString();
  //              //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
  //              //mail.To.Add(to);
  //              ////mail.From = new MailAddress(from, Session["User_Name"].ToString(), System.Text.Encoding.UTF8);
  //              ////mail.Subject = "Tool Feedback Details";
  //              ////mail.Body = "Dear Sir/Madam,  <br/> <br/> Tool Number -" + toolno.ToString() + "<br/>Station:" + station.ToString() + "<br/>Feedback:" + txt_response.Value.ToString();
  //              //mail.From = new MailAddress(from, "Tool Feedback", System.Text.Encoding.UTF8);
  //              //mail.Subject = "Tool Feedback Details";
  //              ////mail.Body = "Dear Sir, KFA for the Tools life details,";
  //              //string Inlineimage = Server.MapPath("~/ABU/Mail/mail_Feed.jpg");
  //              //string Inlineimg = Server.MapPath("~/ABU/Mail/mail_Feed");
  //              //sb.Length = 0;

  //              //LinkedResource myimage = new LinkedResource(Inlineimage);
  //              //myimage.ContentId = Guid.NewGuid().ToString();
  //              //sb.Append("<html><body><div style='width: 100%;'><img src='cid:" + myimage.ContentId + "'></div><div style='height:10px;'></div><table style='width: 100%;border:1px solid black;border-collapse: collapse;'><tr style='background-color: #fff; height: 35px;'><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture No</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Station</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Feedback</span></td></tr>");

  //              //da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active' and a.ID='" + Convert.ToInt32(hdn_fid.Value.ToString()) + "'", strConnString);
  //              //ds1 = new DataSet();
  //              //da.Fill(ds1);
  //              //if (ds1.Tables[0].Rows.Count > 0)
  //              //{
  //              //    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
  //              //    {
  //              //        sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + Session["User_Name"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + toolno.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds1.Tables[0].Rows[i]["Tool"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + station.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + txt_response.Value.ToString() + "</span></td></tr>");
  //              //    }
  //              //}
  //              //sb.Append("</table></body></html>");
  //              //string mailbody = sb.ToString();

  //              //// Create HTML view
  //              //AlternateView htmlMail = AlternateView.CreateAlternateViewFromString(mailbody, null, "text/html");
  //              //// Set ContentId property. Value of ContentId property must be the same as
  //              //// the src attribute of image tag in email body. 
  //              //htmlMail.LinkedResources.Add(myimage);
  //              //mail.AlternateViews.Add(htmlMail);

  //              //mail.SubjectEncoding = System.Text.Encoding.UTF8;
  //              //mail.BodyEncoding = System.Text.Encoding.UTF8;
  //              //mail.IsBodyHtml = true;
  //              //mail.Priority = MailPriority.High;

  //              //SmtpClient client = new SmtpClient();
  //              //client.EnableSsl = true;
  //              //client.Port = Convert.ToInt32(587);
  //              //client.Host = "smtp.gmail.com";
  //              //client.Credentials = new System.Net.NetworkCredential("tlmautomail@gmail.com", "ph123456");

                
               
  //              MailMessage mail = new MailMessage();
  //              mail.From = new MailAddress("sathishkumar.p@poclain.com", "Pentanodes");
  //              //msgmail.Bcc.Add(new MailAddress(tobcc));
  //              //mail.To.Add(new MailAddress("tlmautomail@gmail.com"));
  //              //mail.To.Add(new MailAddress("sathishkumar.p@poclain.com"));
  //              // msgmail.Body = "test success";
  //              string to = ds2.Tables[0].Rows[n]["MailID"].ToString();
  //              mail.To.Add(new MailAddress(to));
  //              mail.Subject = "Tool Feedback Details";
  //              mail.IsBodyHtml = true;
  //              SmtpClient client = new SmtpClient();
  //              client.UseDefaultCredentials = false;
  //              client.Credentials = new System.Net.NetworkCredential("sathishkumar.p@poclain.com", "Fordfigo2016");
  //              client.Port = 23;
  //              //client.EnableSsl = true;
  //              //client.Port = 587;
  //              client.EnableSsl = false;
  //              mail.BodyEncoding = System.Text.Encoding.UTF8;
  //          //   client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
  //              mail.SubjectEncoding = System.Text.Encoding.UTF8;
  //              //client.Host = "smtp.gmail.com";
  //              string Inlineimage = Server.MapPath("~/ABU/Mail/mail_Feed.jpg");
  //              //sb.Length = 0;
  //              //LinkedResource myimage = new LinkedResource(Inlineimage);
  //              //myimage.ContentId = Guid.NewGuid().ToString();
  //              ////sb.Append("<html><body><div style='width: 100%;'><img src='cid:" + myimage.ContentId + "'></div><div style='height:10px;'></div><table style='width: 100%;border:1px solid black;border-collapse: collapse;'><tr style='background-color: #fff; height: 35px;'><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture No</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Station</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Feedback</span></td></tr>");
  //              //sb.Append("<html><body><div style='height:10px;'></div><table style='width: 100%;border:1px solid black;border-collapse: collapse;'><tr style='background-color: #fff; height: 35px;'><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture No</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Station</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Feedback</span></td></tr>");

  //              //da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active' and a.ID='" + Convert.ToInt32(hdn_fid.Value.ToString()) + "'", strConnString);
  //              //ds1 = new DataSet();
  //              //da.Fill(ds1);
  //              //if (ds1.Tables[0].Rows.Count > 0)
  //              //{
  //              //    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
  //              //    {
  //              //        sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + Session["User_Name"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + toolno.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds1.Tables[0].Rows[i]["Tool"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + station.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + txt_response.Value.ToString() + "</span></td></tr>");
  //              //    }
  //              //}
  //              //sb.Append("</table></body></html>");
  //              //string mailbody = sb.ToString();

  //              ////// Create HTML view
  //              ////AlternateView htmlMail = AlternateView.CreateAlternateViewFromString(mailbody, null, "text/html");
  //              ////// Set ContentId property. Value of ContentId property must be the same as
  //              ////// the src attribute of image tag in email body. 
  //              ////htmlMail.LinkedResources.Add(myimage);
  //              ////mail.AlternateViews.Add(htmlMail);

  //              //string path = Server.MapPath("~/ABU/Feedback/");
  //              //if (!Directory.Exists(path))
  //              //{
  //              //    Directory.CreateDirectory(path);
  //              //}
  //              //using (StringWriter sw = new StringWriter(sb))
  //              //{
  //              //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
  //              //    {
  //              //        StreamWriter writer = File.AppendText(path + "Feedback.xls");
  //              //        hw.BeginRender();
  //              //        string html = sb.ToString();
  //              //        writer.WriteLine(html);
  //              //        writer.Close();
  //              //    }
  //              //}

  //              mail.SubjectEncoding = System.Text.Encoding.UTF8;
  //              //E:\Louis\PH\PHWIS FIXTURE\Project_update\PhwisFixtures\ABU\Excel
  //              //  mail.Attachments.Add(new Attachment(@"E:\\Louis\\PH\\PHWIS FIXTURE\\Project_update\\PhwisFixtures\\ABU\\Excel\\Tools.xls"));
  //              string FileAttach = Server.MapPath("~/ABU/Feedback/");
  //              mail.Attachments.Add(new Attachment(FileAttach + "Feedback.xls"));
  //              mail.Body = "Dear Sir, KFA for the Tools Feedback details,";
  //              mail.BodyEncoding = System.Text.Encoding.UTF8;
  //              mail.IsBodyHtml = true;
  //              mail.Priority = MailPriority.High;

  //              // SmtpClient client = new SmtpClient();
  //              client.EnableSsl = false;
  //              //client.Port = Convert.ToInt32(ds1.Tables[0].Rows[0]["Port"].ToString());
  //              client.Port = Convert.ToInt32(23);
  //              client.Host = "mailer.poclain-hydraulics.net";
  //             // client.DeliveryMethod = SmtpDeliveryMethod.Network;
  //             // client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
  //              //client.Host = "smtp.gmail.com";
  //              // client.Host = "smtp-mail.outlook.com";
  //              client.UseDefaultCredentials = false;
  //              //client.Credentials = new System.Net.NetworkCredential(ds1.Tables[0].Rows[0]["Username"].ToString(), ds1.Tables[0].Rows[0]["Password"].ToString());
  //              client.Credentials = new System.Net.NetworkCredential("sathishkumar.p@poclain.com", "Fordfigo2016");

  //              try
  //              {
  //                  client.Send(mail);
  //              }
  //              catch (Exception ex)
  //              {
  //                  Exception ex2 = ex;
  //                  string errorMessage = string.Empty;
  //                  while (ex2 != null)
  //                  {
  //                      errorMessage += ex2.ToString();
  //                      ex2 = ex2.InnerException;
  //                  }
  //                  HttpContext.Current.Response.Write(errorMessage);
  //              }
  //              mail.Dispose();
  //          }
  //      }
  //  }

    public void feedbackmail(string toolno, string station)
    {
        DataSet ds1 = new DataSet();
        ds1.Tables.Clear();
        SqlDataAdapter da2 = new SqlDataAdapter("select * from MailAutorized where Unit='ABU' ", strConnString);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        sb.Length = 0;
        if (ds2.Tables[0].Rows.Count > 0)
        {
            MailMessage msg = new MailMessage();
            //msg.From = new MailAddress("tlmautomail@gmail.com");

            msg.From = new MailAddress("sathishkumar.p@poclain.com");
            //string to = ds2.Tables[0].Rows[n]["MailID"].ToString();
            //msg.To.Add(to);

            for (int n = 0; n < ds2.Tables[0].Rows.Count; n++)
            {
                string to = ds2.Tables[0].Rows[n]["MailID"].ToString();
                msg.To.Add(new MailAddress(to));
            }

            //msg.To.Add(new MailAddress(to));
            //msg.To.Add("sathishkumar.p@poclain.com");
            msg.Subject = "Tool Feedback Details";
            msg.Body = "";
            msg.IsBodyHtml = true;
            SmtpClient smt = new SmtpClient();

            //smt.Host = "smtp.gmail.com";
            //smt.EnableSsl = true;

            smt.Host = "mailer.poclain-hydraulics.net";
            smt.EnableSsl = false;

            string Inlineimage = Server.MapPath("~/ABU/Mail/mail_Feed.jpg");
            sb.Length = 0;
            LinkedResource myimage = new LinkedResource(Inlineimage);
            myimage.ContentId = Guid.NewGuid().ToString();
            sb.Append("<html><body><div style='width: 100%;'><img src='cid:" + myimage.ContentId + "'></div><div style='height:10px;'></div><table style='width: 100%;border:1px solid black;border-collapse: collapse;'><tr style='background-color: #fff; height: 35px;'><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture No</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Station</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Feedback</span></td></tr>");
            da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active' and a.ID='" + Convert.ToInt32(hdn_fid.Value.ToString()) + "'", strConnString);
            ds1 = new DataSet();
            da.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + Session["User_Name"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + toolno.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds1.Tables[0].Rows[i]["Tool"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + station.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + txt_response.Value.ToString() + "</span></td></tr>");
                }
            }
            sb.Append("</table></body></html>");
            string mailbody = sb.ToString();

            // Create HTML view
            AlternateView htmlMail = AlternateView.CreateAlternateViewFromString(mailbody, null, "text/html");
            // Set ContentId property. Value of ContentId property must be the same as
            // the src attribute of image tag in email body. 
            htmlMail.LinkedResources.Add(myimage);
            msg.AlternateViews.Add(htmlMail);

            //NetworkCredential ntcd = new NetworkCredential("tlmautomail@gmail.com", "ph123456");
            NetworkCredential ntcd = new NetworkCredential("sathishkumar.p@poclain.com", "Fordfigo2016");
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntcd;
            smt.Port = 25;

            smt.Send(msg);
            msg.Dispose();
        }
    }

    //protected void OnDataBound(object sender, EventArgs e)
    //{
    //    if (grid_abumaster.Rows.Count > 0)
    //    {
    //        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
    //        for (int i = 1; i < grid_abumaster.Columns.Count; i++)
    //        {
    //            TableHeaderCell cell = new TableHeaderCell();
    //            TextBox txtSearch = new TextBox();
    //            txtSearch.Attributes["placeholder"] = "Search";
    //            txtSearch.CssClass = "search_textbox";
    //            cell.Controls.Add(txtSearch);
    //            row.Controls.Add(cell);
    //        }
    //        grid_abumaster.HeaderRow.Parent.Controls.AddAt(1, row);
    //    }
    //}

    protected void ddl_gridlist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label ID = (Label)e.Item.FindControl("lblid");
            HtmlContainerControl div_tool = (HtmlContainerControl)e.Item.FindControl("div_tool");
           
            if (ID.Text != "" && ID.Text != null)
            {
                da = new SqlDataAdapter("select * from Abu_Master where ID='" + Convert.ToInt32(ID.Text.ToString()) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string setColorClass = string.Empty;

                    SqlDataAdapter da1 = new SqlDataAdapter("select * from AbuToolFeedback where ToolNumber='" + ds.Tables[0].Rows[0]["ToolNumber"].ToString() + "' and ResDate is null ", strConnString);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        setColorClass = "Orange";
                        div_tool.Attributes.Add("class", setColorClass);
                    }
                    else
                    {
                        if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenTo"].ToString()))
                        {
                            setColorClass = "Green";
                            div_tool.Attributes.Add("class", setColorClass);
                        }
                        if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowTo"].ToString()))
                        {
                            setColorClass = "Yellow";
                            div_tool.Attributes.Add("class", setColorClass);
                        }
                        if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                        {
                            setColorClass = "Red";
                            div_tool.Attributes.Add("class", setColorClass);
                        }
                        else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                        {
                            setColorClass = "Red";
                            div_tool.Attributes.Add("class", setColorClass);
                        }
                    }
                    div_tool.Attributes.Add("onclick", "response('" + ID.Text + "',event)");
                }
            }
            else
            {
            }
        }

    }
    protected void ddl_hmc_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label ID = (Label)e.Item.FindControl("lblid");
            HtmlContainerControl div_tool = (HtmlContainerControl)e.Item.FindControl("div_tool");

            if (ID.Text != "" && ID.Text != null)
            {
                da = new SqlDataAdapter("select * from Abu_Master where ID='" + Convert.ToInt32(ID.Text.ToString()) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    string setColorClass = string.Empty;

                    SqlDataAdapter da1 = new SqlDataAdapter("select * from AbuToolFeedback where ToolNumber='" + ds.Tables[0].Rows[0]["ToolNumber"].ToString() + "' and ResDate is null ", strConnString);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        setColorClass = "Orange";
                        div_tool.Attributes.Add("class", setColorClass);
                    }
                    else
                    {
                        if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenTo"].ToString()))
                        {
                            setColorClass = "Green";
                            div_tool.Attributes.Add("class", setColorClass);
                        }
                        if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowTo"].ToString()))
                        {
                            setColorClass = "Yellow";
                            div_tool.Attributes.Add("class", setColorClass);
                        }
                        if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                        {
                            setColorClass = "Red";
                            div_tool.Attributes.Add("class", setColorClass);
                        }
                        else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                        {
                            setColorClass = "Red";
                            div_tool.Attributes.Add("class", setColorClass);
                        }
                    }
                    div_tool.Attributes.Add("onclick", "response('" + ID.Text + "',event)");
                }
            }
            else
            {
            }
        }
    }

    protected void ddl_tmc_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label ID = (Label)e.Item.FindControl("lblid");
            HtmlContainerControl div_tool = (HtmlContainerControl)e.Item.FindControl("div_tool");

            if (ID.Text != "" && ID.Text != null)
            {
                da = new SqlDataAdapter("select * from Abu_Master where ID='" + Convert.ToInt32(ID.Text.ToString()) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string setColorClass = string.Empty;

                    SqlDataAdapter da1 = new SqlDataAdapter("select * from AbuToolFeedback where ToolNumber='" + ds.Tables[0].Rows[0]["ToolNumber"].ToString() + "' and ResDate is null ", strConnString);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        setColorClass = "Orange";
                        div_tool.Attributes.Add("class", setColorClass);
                    }
                    else
                    {
                        if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenTo"].ToString()))
                        {
                            setColorClass = "Green";
                            div_tool.Attributes.Add("class", setColorClass);
                        }
                        if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowTo"].ToString()))
                        {
                            setColorClass = "Yellow";
                            div_tool.Attributes.Add("class", setColorClass);
                        }
                        if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                        {
                            setColorClass = "Red";
                            div_tool.Attributes.Add("class", setColorClass);
                        }
                        else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                        {
                            setColorClass = "Red";
                            div_tool.Attributes.Add("class", setColorClass);
                        }
                    }
                    div_tool.Attributes.Add("onclick", "response('" + ID.Text + "',event)");
                }
            }
            else
            {
            }
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

