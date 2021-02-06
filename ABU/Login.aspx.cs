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
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mime;
using System.Globalization;

public partial class Login : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public DataSet ds;
    public SqlDataAdapter da;
    public SqlCommand cmd;
    public StringBuilder sb = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mailsend();
            mailsend1();
        }
    }
    protected void btn_log_Click(object sender, ImageClickEventArgs e)
    {

        string res = "";
        string uname = txt_ausername.Value.ToString();
        string pwd = txt_apassword.Value.ToString();
        da = new SqlDataAdapter("select * from tbl_Registration where Reg_Username='" + uname + "' and Reg_Userpassword='" + pwd + "'", strConnString);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            res = ds.Tables[0].Rows[0]["Reg_Role"].ToString();
            Session["User_Role"] = res.ToString();

            Session["User_ID"] = ds.Tables[0].Rows[0]["Reg_ID"].ToString();
            Session["User_Name"] = ds.Tables[0].Rows[0]["Reg_Username"].ToString();
            Session["Logtime"] = DateTime.Now.ToShortTimeString();
            Session["LogDate"] = DateTime.Now.ToShortDateString();
            HttpContext.Current.Session.Timeout = 300;
        }
        else
        {
            res = "F";

        }

        if (res == "User")
        {
            Response.Redirect("~/ABU/AbuUser.aspx");
        }
        if (res == "Super Admin" || res == "Admin")
        {
            Response.Redirect("~/ABU/AbuMaster.aspx");
        }
        if (res == "F")
        {
            txt_ausername.Value = "";
            txt_apassword.Value = "";
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('LOGIN FAILED !');", true);
        }
    }
    //public void mail()
    //{
    //    try
    //    {
    //        string pathvv = Server.MapPath("~/ABU/Excel/");
    //        strConnString.Open();
    //        cmd = new SqlCommand("GerDueMail", strConnString);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add("@from", SqlDbType.DateTime).Value = DateTime.Now;
    //        strConnString.Close();
    //        da = new SqlDataAdapter(cmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            sb.Append("<table style='width:100%;'><tr style='background-color:#105fe0;height:35px;'><td style='text-align:center; color:#fff;width:150px;'><span>Tool No</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Availability</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Station</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Spare</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Retension Time</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Issued On</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Next Due</span></td></tr>");

    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {
    //                sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;background-color:red;'><span>" + ds.Tables[0].Rows[i]["Tool"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Availability"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Station"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Maintained"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Rentime"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Issuedon"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Nextdueon"].ToString() + "</span></td></tr>");


    //                //cmd = new SqlCommand("update Abu_Master set MailFlag='' where ID='" + Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString()) + "'", strConnString);
    //                //cmd.Parameters.Add("ID", SqlDbType.Int).Value = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
    //                //strConnString.Open();
    //                //cmd.ExecuteNonQuery();
    //                //strConnString.Close();
    //            }
    //            sb.Append("</table>");
    //            string path = Server.MapPath("~/ABU/Excel/");
    //            if (!Directory.Exists(path))
    //            {
    //                Directory.CreateDirectory(path);
    //            }
    //            using (StringWriter sw = new StringWriter(sb))
    //            {
    //                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //                {
    //                    StreamWriter writer = File.AppendText(path + "Tools.xls");
    //                    hw.BeginRender();
    //                    string html = sb.ToString();
    //                    writer.WriteLine(html);
    //                    writer.Close();
    //                }
    //            }

    //            SqlDataAdapter da2 = new SqlDataAdapter("select * from MailAutorized", strConnString);
    //            DataSet ds2 = new DataSet();
    //            da2.Fill(ds2);
    //            if (ds2.Tables[0].Rows.Count > 0)
    //            {


    //                for (int n = 0; n < ds2.Tables[0].Rows.Count; n++)
    //                {

    //                    MailMessage mail = new MailMessage();
    //                    mail.From = new MailAddress("tlmautomail@gmail.com", "Pentanodes");
    //                    string to = ds2.Tables[0].Rows[n]["MailID"].ToString();
    //                    mail.To.Add(new MailAddress(to));
    //                    mail.Subject = "Tool Life Details";
    //                    mail.IsBodyHtml = true;
    //                    //SmtpClient client = new SmtpClient();
    //                    //client.Credentials = new System.Net.NetworkCredential("tlmautomail@gmail.com", "ph123456");
    //                    ////client.Port = 25;
    //                    ////client.EnableSsl = true;
    //                    //client.Port = 25;
    //                    //client.EnableSsl = true;
    //                    //mail.BodyEncoding = System.Text.Encoding.UTF8;
    //                    //client.Host = "smtp.gmail.com";

    //                    //   client.Send(mail);
    //                    //////
    //                    mail.Body = "Dear Sir";
    //                    //string Inlineimage = Server.MapPath("~/ABU/Mail/mail.jpg");
    //                    //string Inlineimg = Server.MapPath("~/ABU/Mail/mail");
    //                    //sb.Length = 0;


    //                    //LinkedResource myimage = new LinkedResource(Inlineimage);
    //                    //myimage.ContentId = Guid.NewGuid().ToString();
    //                    //sb.Append("<html><body><div style='width: 100%;'><img src='cid:" + myimage.ContentId + "'></div><div style='height:10px;'></div><table style='width: 100%;border:1px solid black;border-collapse: collapse;'><tr style='background-color: #fff; height: 35px;'><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture No</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Station</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Commenced On</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Life Completed On</span></td></tr>");
    //                    ////for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //                    ////{
    //                    ////    sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;background-color:red;'><span>" + ds.Tables[0].Rows[i]["ToolNumber"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Tool"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Station"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Issuedon"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Nextdueon"].ToString() + "</span></td></tr>");

    //                    ////    //cmd = new SqlCommand("update Abu_Master set MailFlag='1' where ID='" + Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString()) + "'", strConnString);
    //                    ////    //cmd.Parameters.Add("ID", SqlDbType.Int).Value = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
    //                    ////    //strConnString.Open();
    //                    ////    //cmd.ExecuteNonQuery();
    //                    ////  strConnString.Close();
    //                    ////}
    //                    ////sb.Append("</table></body></html>");
    //                    ////string mailbody = sb.ToString();

    //                    //// Create HTML view
    //                    //AlternateView htmlMail = AlternateView.CreateAlternateViewFromString(mailbody, null, "text/html");
    //                    //// Set ContentId property. Value of ContentId property must be the same as
    //                    //// the src attribute of image tag in email body. 
    //                    //htmlMail.LinkedResources.Add(myimage);
    //                    //mail.AlternateViews.Add(htmlMail);

    //                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
    //                    //E:\Louis\PH\PHWIS FIXTURE\Project_update\PhwisFixtures\ABU\Excel
    //                    //  mail.Attachments.Add(new Attachment(@"E:\\Louis\\PH\\PHWIS FIXTURE\\Project_update\\PhwisFixtures\\ABU\\Excel\\Tools.xls"));
    //                    ////string FileAttach = Server.MapPath("~/ABU/Excel/");
    //                    ////mail.Attachments.Add(new Attachment(FileAttach + "Tools.xls"));
    //                    mail.BodyEncoding = System.Text.Encoding.UTF8;
    //                    mail.IsBodyHtml = true;
    //                    mail.Priority = MailPriority.High;

    //                    SmtpClient client = new SmtpClient();
    //                    client.EnableSsl = false;
    //                    //client.Port = Convert.ToInt32(ds1.Tables[0].Rows[0]["Port"].ToString());
    //                    client.Port = Convert.ToInt32(23);
    //                    client.Host = "smtp.gmail.com";
    //                    // client.Host = "smtp-mail.outlook.com";
    //                    client.UseDefaultCredentials = false;
    //                    client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
    //                    //client.Credentials = new System.Net.NetworkCredential(ds1.Tables[0].Rows[0]["Username"].ToString(), ds1.Tables[0].Rows[0]["Password"].ToString());
    //                    client.Credentials = new System.Net.NetworkCredential("tlmautomail@gmail.com", "ph123456");
    //                    try
    //                    {
    //                        client.Send(mail);
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        Exception ex2 = ex;
    //                        string errorMessage = string.Empty;
    //                        while (ex2 != null)
    //                        {
    //                            errorMessage += ex2.ToString();
    //                            ex2 = ex2.InnerException;
    //                        }
    //                        HttpContext.Current.Response.Write(errorMessage);
    //                    }
    //                    mail.Dispose();
    //                }
    //            }
    //            else
    //            {
    //            }
    //        }
    //        else
    //        {

    //        }

    //    }
    //    catch (Exception ex3)
    //    {
    //        Exception ex4 = ex3;

    //    }
    //}

    public void mailsend()
    {
        try
        {
            string concatto = "";
            strConnString.Open();
            cmd = new SqlCommand("GerDueMail", strConnString);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@from", SqlDbType.DateTime).Value = DateTime.Now;
            strConnString.Close();
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                SqlDataAdapter da2 = new SqlDataAdapter("select * from MailAutorized where unit='ABU'", strConnString);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    //for (int n = 0; n < ds2.Tables[0].Rows.Count; n++)
                    //{
                    //    concatto = concatto + ";" + ds2.Tables[0].Rows[n]["MailID"].ToString();
                    //}
                    //if (concatto.StartsWith(";"))
                    //{
                    //    concatto = concatto.Substring(1);
                    //}

                    MailMessage msg = new MailMessage();
                    //msg.From = new MailAddress("tlmautomail@gmail.com");

                    msg.From = new MailAddress("sathishkumar.p@poclain.com");

                    for (int n = 0; n < ds2.Tables[0].Rows.Count; n++)
                    {
                        string to = ds2.Tables[0].Rows[n]["MailID"].ToString();
                        msg.To.Add(new MailAddress(to));
                    }
                    //string to = ds2.Tables[0].Rows[n]["MailID"].ToString();
                    //msg.To.Add(new MailAddress(to));
                    //msg.To.Add("sathishkumar.p@poclain.com");
                    msg.Subject = "Tool Life Details";
                    msg.Body = "";
                    msg.IsBodyHtml = true;
                    SmtpClient smt = new SmtpClient();

                    //smt.Host = "smtp.gmail.com";
                    //smt.EnableSsl = true;

                    smt.Host = "mailer.poclain-hydraulics.net";
                    smt.EnableSsl = false;

                    string Inlineimage = Server.MapPath("~/ABU/Mail/mail.jpg");

                    sb.Length = 0;
                    LinkedResource myimage = new LinkedResource(Inlineimage);
                    myimage.ContentId = Guid.NewGuid().ToString();
                    sb.Append("<html><body><div style='width: 100%;'><img src='cid:" + myimage.ContentId + "'></div><div style='height:10px;'></div><table style='width: 100%;border:1px solid black;border-collapse: collapse;'><tr style='background-color: #fff; height: 35px;'><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture No</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Station</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Commenced On</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Life Completed On</span></td></tr>");

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["ToolNumber"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Tool"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Station"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Issuedon"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Nextdueon"].ToString() + "</span></td></tr>");

                        //cmd = new SqlCommand("update Abu_Master set MailFlag='1' where ID='" + Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString()) + "'", strConnString);
                        //cmd.Parameters.Add("ID", SqlDbType.Int).Value = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                        //strConnString.Open();
                        //cmd.ExecuteNonQuery();
                        //strConnString.Close();
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
        }
        catch (Exception ex)
        {

        }
    }

    public void mailsend1()
    {
        try
        {
            string concatto = "";
            strConnString.Open();
            cmd = new SqlCommand("GerDueMail1", strConnString);
            // cmd.CommandType = CommandType.StoredProcedure;

            // cmd.Parameters.Add("@from", SqlDbType.DateTime).Value = DateTime.Now;
            strConnString.Close();
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                SqlDataAdapter da2 = new SqlDataAdapter("select * from MailAutorized where unit='MBU'", strConnString);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count > 0)
                {


                    MailMessage msg = new MailMessage();
                    //msg.From = new MailAddress("tlmautomail@gmail.com");

                    msg.From = new MailAddress("sathishkumar.p@poclain.com");

                    for (int n = 0; n < ds2.Tables[0].Rows.Count; n++)
                    {
                        string to = ds2.Tables[0].Rows[n]["MailID"].ToString();
                        msg.To.Add(new MailAddress(to));
                    }
                    msg.Subject = "Fixture Life Details - MBU ";
                    msg.Body = "";
                    msg.IsBodyHtml = true;
                    SmtpClient smt = new SmtpClient();

                    //smt.Host = "smtp.gmail.com";
                    //smt.EnableSsl = true;

                    smt.Host = "mailer.poclain-hydraulics.net";
                    smt.EnableSsl = false;

                    string Inlineimage = Server.MapPath("~/ABU/Mail/mail.jpg");

                    sb.Length = 0;
                    LinkedResource myimage = new LinkedResource(Inlineimage);
                    myimage.ContentId = Guid.NewGuid().ToString();
                    sb.Append("<html><body><div style='width: 100%;'><img src='cid:" + myimage.ContentId + "'></div><div style='height:10px;'></div><table style='width: 100%;border:1px solid black;border-collapse: collapse;'><tr style='background-color: #fff; height: 35px;'><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture No</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Part Number</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Fixture Count</span></td></tr>");

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["fixtureno"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["fixturename"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["partnumber"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["fixturelife"].ToString() + "</span></td></tr>");

                        //cmd = new SqlCommand("update Abu_Master set MailFlag='1' where ID='" + Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString()) + "'", strConnString);
                        //cmd.Parameters.Add("ID", SqlDbType.Int).Value = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                        //strConnString.Open();
                        //cmd.ExecuteNonQuery();
                        //strConnString.Close();
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
        }
        catch (Exception ex)
        {

        }
    }

    private AlternateView getEmbeddedImage(String filePath)
    {
        LinkedResource inline = new LinkedResource(filePath);
        inline.ContentId = Guid.NewGuid().ToString();
        string htmlBody = @"<img src='cid:" + inline.ContentId + @"'/>";
        AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
        alternateView.LinkedResources.Add(inline);
        return alternateView;
    }
}
