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

public partial class ABU_SendMail : System.Web.UI.Page
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
    public StringBuilder sb = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
    }
    public void mail()
    {
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
            sb.Append("<table style='width:100%;'><tr style='background-color:#105fe0;height:35px;'><td style='text-align:center; color:#fff;width:150px;'><span>Tool No</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Availability</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Station</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Spare</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Retension Time</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Issued On</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Next Due</span></td></tr>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;background-color:red;'><span>" + ds.Tables[0].Rows[i]["Tool"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Availability"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Station"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Maintained"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Rentime"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Issuedon"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Nextdueon"].ToString() + "</span></td></tr>");
                //sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Tool"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Availability"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Station"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Maintained"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><img src='../ABU/Tools/" + ds.Tables[0].Rows[i]["Photo"].ToString() + "' style='width:100px; height:100px;' /></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><img src='../ABU/Drawing/" + ds.Tables[0].Rows[i]["Drawings"].ToString() + "' style='width:100px; height:100px;' /></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Rentime"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Issuedon"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Nextdueon"].ToString() + "</span></td></tr>");
            }
            sb.Append("</table>");
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Mail", strConnString);
            DataSet ds1 = new DataSet();
            DataTable dt = new DataTable();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {


                string from = "krajendiran90@gmail.com";
                string to = "staffpenta@gmail.com";
                // string pwd = password.ToString();
                // string url = link.ToString();
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(from, "Tool Due Date", System.Text.Encoding.UTF8);
                mail.Subject = "Dear Sir, KFA for the Tools life details, List the details of toolnumbers with all other datas";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                string msg = sb.ToString();// " Dear Sir,</br> KFA for the Tools life details,</br> List the details of toolnumbers with all other datas";
                AlternateView view = AlternateView.CreateAlternateViewFromString(msg.ToString(), null, "text/html");
                mail.AlternateViews.Add(view);
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                SmtpClient client = new SmtpClient();
                client.EnableSsl = true;
                client.Port = Convert.ToInt32(ds1.Tables[0].Rows[0]["Port"].ToString());
                client.Host = "smtp.gmail.com";
                //client.Host = "smtp-mail.outlook.com";
                client.Credentials = new System.Net.NetworkCredential(ds1.Tables[0].Rows[0]["Username"].ToString(), ds1.Tables[0].Rows[0]["Password"].ToString());
                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    string errorMessage = string.Empty;
                    while (ex2 != null)
                    {
                        errorMessage += ex2.ToString();
                        ex2 = ex2.InnerException;
                    }
                    HttpContext.Current.Response.Write(errorMessage);
                }
            }
            else
            {
            }




        }
    }

    //public void sendEMailThroughHotMail()
    //{
    //    try
    //    {
    //        //Mail Message
    //        MailMessage mM = new MailMessage();
    //        //Mail Address
    //        mM.From = new MailAddress("sender@hotmail.com");
    //        //receiver email id
    //        mM.To.Add("rcver@gmail.com");
    //        //subject of the email
    //        mM.Subject = "your subject line will go here";
    //        //deciding for the attachment
    //        mM.Attachments.Add(new Attachment(@"C:\\attachedfile.jpg"));
    //        //add the body of the email
    //        mM.Body = "Body of the email";
    //        mM.IsBodyHtml = true;
    //        //SMTP client
    //        SmtpClient sC = new SmtpClient("smtp.live.com");
    //        //port number for Hot mail
    //        sC.Port = 25;
    //        //credentials to login in to hotmail account
    //        sC.Credentials = new NetworkCredential("sender@hotmail.com", "HotMailPassword");
    //        //enabled SSL
    //        sC.EnableSsl = true;
    //        //Send an email
    //        sC.Send(mM);
    //    }//end of try block
    //    catch (Exception ex)
    //    {

    //    }//end of catch
    //}//end of Email Meth
    //public void sendEMailThroughYahoo()
    //{
    //    try
    //    {
    //        //mail message
    //        MailMessage mM = new MailMessage();
    //        //Mail Address
    //        mM.From = new MailAddress("sender@yahoo.com");
    //        //emailid to send
    //        mM.To.Add("recvEmailid@gmail.com");
    //        //your subject line of the message
    //        mM.Subject = "your subject line will go here.";
    //        //now attached the file
    //        mM.Attachments.Add(new Attachment(@"C:\\attachedfile.jpg"));
    //        //add the body of the email
    //        mM.Body = "Your Body of the email.";
    //        mM.IsBodyHtml = false;
    //        //SMTP 
    //        SmtpClient SmtpServer = new SmtpClient();
    //        //your credential will go here
    //        SmtpServer.Credentials = new System.Net.NetworkCredential("sender@yahoo.com", "password");
    //        //port number to login yahoo server
    //        SmtpServer.Port = 587;
    //        //yahoo host name
    //        SmtpServer.Host = "smtp.mail.yahoo.com";
    //        //Send the email
    //        SmtpServer.Send(mM);
    //    }//end of try block
    //    catch (Exception ex)
    //    {
    //    }//end of catch
    //}//end o
    //public void sendEMailThroughAOL()
    //{
    //    try
    //    {
    //        //mail message
    //        MailMessage mM = new MailMessage();
    //        //Mail Address
    //        mM.From = new MailAddress("sender@aol.com");
    //        //emailid to send
    //        mM.To.Add("recvEmailid@gmail.com");
    //        //your subject line of the message
    //        mM.Subject = "your subject line will go here.";
    //        //now attached the file
    //        mM.Attachments.Add(new Attachment(@"C:\\attachedfile.jpg"));
    //        //add the body of the email
    //        mM.Body = "Your Body of the email.";
    //        mM.IsBodyHtml = false;
    //        //SMTP 
    //        SmtpClient SmtpServer = new SmtpClient();
    //        //your credential will go here
    //        SmtpServer.Credentials = new System.Net.NetworkCredential("sender@aol.com", "AOLpassword");
    //        //port number to login yahoo server
    //        SmtpServer.Port = 587;
    //        //yahoo host name
    //        SmtpServer.Host = "smtp.aol.com";
    //        //Send the email
    //        SmtpServer.Send(mM);
    //    }//end of try block
    //    catch (Exception ex)
    //    {

    //    }//end of catch
    //}//en
    //public void sendEMailThroughGmail()
    //{
    //    try
    //    {
    //        //Mail Message
    //        MailMessage mM = new MailMessage();
    //        //Mail Address
    //        mM.From = new MailAddress("sender@gmail.com");
    //        //receiver email id
    //        mM.To.Add("rcver@gmail.com");
    //        //subject of the email
    //        mM.Subject = "your subject line will go here";
    //        //deciding for the attachment
    //        mM.Attachments.Add(new Attachment(@"C:\\attachedfile.jpg"));
    //        //add the body of the email
    //        mM.Body = "Body of the email";
    //        mM.IsBodyHtml = true;
    //        //SMTP client
    //        SmtpClient sC = new SmtpClient("smtp.gmail.com");
    //        //port number for Gmail mail
    //        sC.Port = 587;
    //        //credentials to login in to Gmail account
    //        sC.Credentials = new NetworkCredential("sender@gmail.com", "GmailPassword");
    //        //enabled SSL
    //        sC.EnableSsl = true;
    //        //Send an email
    //        sC.Send(mM);
    //    }//end of try block
    //    catch (Exception ex)
    //    {

    //    }//end of catch
    //}//end of E
}
