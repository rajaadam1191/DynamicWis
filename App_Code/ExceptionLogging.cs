using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using context = System.Web.HttpContext;
using System.Configuration;  
/// <summary>
/// Summary description for ExceptionLogging
/// </summary>
public class ExceptionLogging
{
    
    public DBServer objserver = new DBServer();
    public static SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public static Object thisLock = new Object();

    public ExceptionLogging()
    {
    }
    private static String exepurl;
    static SqlConnection con;
    private static void connecttion()
    {


        string constr = ConfigurationManager.ConnectionStrings["Constr"].ToString();
        con = new SqlConnection(constr);
        con.Open();
    }
    public static void SendExcepToDB(Exception exdb)
    {
        lock (thisLock)
        {
            try
            {
                //connecttion();
                //ConnectionState state = strConnString.State;
                //if (state == ConnectionState.Open)
                //{
                //strConnString.Close();
                //strConnString.Open();
                //}
                //else
                //{
                //    strConnString.Open();
                //}
                strConnString.Close();
                if (strConnString.State != ConnectionState.Open)
                    strConnString.Open();

                exepurl = context.Current.Request.Url.ToString();
                //SqlCommand com = new SqlCommand("ExceptionLoggingToDataBase", con);
                SqlCommand com = new SqlCommand("ExceptionLoggingToDataBase", strConnString);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ExceptionMsg", exdb.Message.ToString());
                com.Parameters.AddWithValue("@ExceptionType", exdb.GetType().Name.ToString());
                //com.Parameters.AddWithValue("@ExceptionURL", exepurl);
                com.Parameters.AddWithValue("@ExceptionURL", context.Current.Request.Url.ToString());
                com.Parameters.AddWithValue("@ExceptionSource", exdb.StackTrace.ToString());
                //strConnString.Close();
                //strConnString.Open();
                com.ExecuteNonQuery();
                strConnString.Close();

            }
            catch (Exception ex)
            {
                //throw ex; //TODO: Please log it or remove the catch
                if (ex.Message != "The connection was not closed. The connection's current state is connecting." && ex.Message != "The connection was not closed. The connection's current state is open.")
                {
                    ExceptionLogging.SendExcepToDB(ex);
                }
            }
            finally
            {
                strConnString.Close();
            }

        }
    }
    public static void sqlqueryRequest(string stime, string etime, string duration,Exception excp)
    {
        //connecttion();
        //SqlConnection strConnString1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
        lock (thisLock)
        {
            try
            {
                DateTime dd = Convert.ToDateTime(stime.ToString());
                exepurl = context.Current.Request.Url.ToString();
                if (exepurl.Contains(".jpg") || exepurl.Contains(".js") || exepurl.Contains(".css") || exepurl.Contains(".png") || exepurl.Contains(".gif"))
                {

                }
                else
                {
                    SqlCommand com1 = new SqlCommand("sp_Sqlloghist", strConnString);
                    com1.CommandType = CommandType.StoredProcedure;
                    com1.Parameters.AddWithValue("@url", exepurl.ToString());
                    com1.Parameters.AddWithValue("@LogSTime", stime);
                    com1.Parameters.AddWithValue("@LogETime", etime);
                    com1.Parameters.AddWithValue("@Duration", duration);
                    if (excp != null && excp.Message != "File does not exist.")
                    {
                        com1.Parameters.AddWithValue("@Exception", excp.Message.ToString());
                    }
                    else
                    {
                        com1.Parameters.AddWithValue("@Exception", "");
                    }
                    //  com1.Parameters.AddWithValue("@Exception", excp.Message.ToString());
                    strConnString.Close();
                    strConnString.Open();
                    com1.ExecuteNonQuery();
                    strConnString.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex; //TODO: Please log it or remove the catch
                if (ex.Message != "The connection was not closed. The connection's current state is connecting." && ex.Message != "The connection was not closed. The connection's current state is open.")
                {
                    //sqlqueryRequest(url, stime, etime, duration);

                }
            }
            finally
            {
                strConnString.Close();
            }
        }
    }
}
	

