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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;
using System.Data.OleDb;
using System.Diagnostics;
using System.Threading;

public partial class _Default : System.Web.UI.Page
{
    public static SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ToString();

    public static QualitySheetdclassDataContext objcontext;
    public static QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public static EfficiencyCalculaus objcal;
    public static QualitySheet objsheet;
    public static Dynmaster objm = new Dynmaster();
    public static DBServer objserver = new DBServer();
    public static DataSet ds;
    public static DataSet ds1, ds2;
    public static SqlDataAdapter da;
    public static SqlDataAdapter da1, da2;
    public static SqlCommand cmd;
    public static String PartNo;
    public static Object thisLock = new Object();

    public static Regex comma;
    public static string CreateQuery, InsertQuery, UpdateQuery;
    public static decimal CP, CP1, CP2, CP3, CPK, CPK1, CPK2, CPK3, tolerance, points = 67, Standardeviation, Standardeviation2, Standardeviation3, Standardeviation4, Range;
    public static decimal CPP, CPP1, CPP2, CPP3;
    public static double standart, standart1, standart2, standart3;
    public static double cp, cp1, cp2, cp3;
    public static string error_msg;
    public static double xminxbar, xminxbar2, xminxbar3, xminxbar4;
    public static double xxminxbar, xxminxbar2, xxminxbar3, xxminxbar4;
    public static int count = 0;

    //public static String errormessage="";
    public static String plannedstop, Topentime, Plannedclosing, TRequired, Downtimeloss, Tfunction, Operatingtime, Utiletime, Qualityloss, TUtiletime, TRS, TRG, Totalstop, Stophours, Speedloss;
    public static String[] table = { "QualitySheet", "QualitySheetA22916J", "qualityshtA44983U", "QSheetA32271C", "QSheetA44908N", "QSheetPolishing24Q", "QSheetpolishingA22916J", "QSheetpolishingA32271C", "QSheetPolishingA44908N", "QSheetpolishingA44983U", "opt2QSA17724Q", "opt2QualitySheetA22916J" };
    public static String[] table1 = { "A17724Q", "A22916J", "A32271C", "A44983U", "A44908N" };
    public static String[] DownType, downtimeloss;
    public static String path = "";

    public static DataSet pds = new DataSet();
    public static DataSet rds = new DataSet();
    public static SqlDataAdapter pda = new SqlDataAdapter();
    public static SqlDataAdapter rda = new SqlDataAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
        }
        else
        {

        }
    }
    public class httpvalues
    {
        public string Operation { get; set; }
        public string Machine { get; set; }
        public string Shift { get; set; }
        public string Partno { get; set; }
        public string Cell { get; set; }
    }
    public class editmail
    {
        public string username { get; set; }
        public string password { get; set; }
        public string port { get; set; }
    }
    public class editmail2
    {
        public string mailid { get; set; }
        public string unit { get; set; }

    }
    public class gettooldeatils
    {
        public string toolno { get; set; }
        public string avail { get; set; }
        public string station { get; set; }
        public string photo { get; set; }
        public string drawing { get; set; }
        public string retenstion { get; set; }
        public string spare { get; set; }
        public string nextdue { get; set; }
        public string issued { get; set; }

    }
    public class sparemaster
    {
        public string partno { get; set; }
        public string tool { get; set; }
        public string max { get; set; }
        public string min { get; set; }
        public string count { get; set; }
    }
    public class ToolType
    {
        public string ttext { get; set; }
        public string tvalue { get; set; }
    }
    public class Linemaster
    {
        public string ttext { get; set; }
        public string tvalue { get; set; }
    }
    public class abutoolmaster
    {
        public string tno { get; set; }
        public string grom { get; set; }
        public string gto { get; set; }
        public string rfrom { get; set; }
        public string rto { get; set; }
        public string yfrom { get; set; }
        public string yto { get; set; }
        public string unit { get; set; }
        public string type { get; set; }
        public string line { get; set; }
        public string Retension { get; set; }
    }
    public class editabumaster
    {
        public string id { get; set; }
        public string tno { get; set; }
        public string davail { get; set; }
        public string station { get; set; }
        public string desc { get; set; }
        public string rtime { get; set; }
        public string issued { get; set; }
        public string qty { get; set; }
        public string maint { get; set; }
        public string next { get; set; }
        public string replaced { get; set; }
        public string extended { get; set; }
        public string rectified { get; set; }
        public string other { get; set; }
        public string premature { get; set; }
    }
    public class getsheetversion
    {
        public string version { get; set; }
        public string date { get; set; }
        public string filename { get; set; }
        public string creatby { get; set; }
    }
    public class Mastelink
    {
        public string Partno { get; set; }
        public string Operation { get; set; }
        public string Cell { get; set; }
    }
    public class userheader
    {
        public string Machinename { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string name { get; set; }
    }
    public class GetMaxMin
    {
        public string Max { get; set; }
        public string Min { get; set; }
        public string Cellvalue { get; set; }
    }
    public class Getdata
    {
        public string[] arr_val = new string[] { "" };

    }
    public class Rowcount
    {
        public string Accept { get; set; }
        public string Reject { get; set; }
        public string _Accept { get; set; }
    }
    public class getInstvalues
    {
        public string Instrument { get; set; }
        public string Dimesion { get; set; }
        public string Upper { get; set; }
        public string Mean { get; set; }
        public string Lower { get; set; }
        public string id { get; set; }
    }
    public class Qltyheadervalue
    {
        public string Instruments { get; set; }
        public string Instrcount { get; set; }
        public string Frequency { get; set; }
        public string MahrRoundnessTester { get; set; }
        public string PlugGauge { get; set; }
        public string CMM { get; set; }
        public string PinGauge { get; set; }
        public string Profiletester { get; set; }
        public string BoreGauge { get; set; }
        public string totalVal { get; set; }
        public string ShortName { get; set; }
        public string Cells { get; set; }
        public string Headername { get; set; }
        public string Id { get; set; }

    }
    public class QualitySheetDegin
    {
        public string Instruments { get; set; }
        public string Frequency { get; set; }
        public string Dimensions { get; set; }
        public string UpperSpecification { get; set; }
        public string UpperControlLimit { get; set; }
        public string Mean { get; set; }
        public string ProcessMean { get; set; }
        public string LowerSpecification { get; set; }
        public string LowerControlLimit { get; set; }
        public string ShortName { get; set; }
        public string Cellvalue { get; set; }
        public string RunChart { get; set; }
    }
    public class Instruments
    {
        public string Instrument { get; set; }
        public string Count { get; set; }
        public string Range { get; set; }
        public string Upper { get; set; }
        public string Mean { get; set; }
        public string Lower { get; set; }
        public string Dimession { get; set; }
        public string id { get; set; }
        public string id1 { get; set; }
        public string Count1 { get; set; }
        public string RUCL { get; set; }
        public string RLCL { get; set; }
        public string RPmean { get; set; }
        public int Reorder { get; set; }
    }
    public class Dynmaster
    {

        public string partno { get; set; }
        public string operation { get; set; }
        public string cell { get; set; }
        public string unit { get; set; }
        public string instrument { get; set; }
        public string inst_values { get; set; }
        public string inst_ranges { get; set; }
        public string shortname { get; set; }
        public string cellvalues { get; set; }
        public string headername { get; set; }
        public string runchart { get; set; }
        public string ucl { get; set; }
        public string lcl { get; set; }
        public string runchartpercent { get; set; }
    }
    public class Getfeedback
    {
        public string id { get; set; }
        public string partno { get; set; }
        public string operation { get; set; }
        public string cell { get; set; }
        public string shift { get; set; }
        public string name { get; set; }
        public string feedback { get; set; }
        public string fdate { get; set; }
        public string response { get; set; }
        public string r_date { get; set; }
        public string resby { get; set; }
        public string machine { get; set; }
    }
    public class T_content
    {
        public string A_count { get; set; }
        public string C_count { get; set; }
        public string Partno { get; set; }
    }
    public class Fixvalues
    {
        public string partno { get; set; }
        public string partno1 { get; set; }
        public string fixno { get; set; }
        public string fixname { get; set; }
        public string operation { get; set; }
        public string drawing { get; set; }
        public string life { get; set; }
        public string gf { get; set; }
        public string gt { get; set; }
        public string yf { get; set; }
        public string yt { get; set; }
        public string rf { get; set; }
        public string rt { get; set; }
        public string id { get; set; }
        public string multifixname { get; set; }
    }
    public class operationrs
    {
        public string operation { get; set; }
        public string res { get; set; }
    }
    public class Fixname
    {
        public string fixname { get; set; }
        public string partno { get; set; }
        public string fid { get; set; }
        public string unit { get; set; }
        public string line { get; set; }
        public string model { get; set; }
        public string type { get; set; }
        public string fixtureno { get; set; }
        public string cell { get; set; }
    }
    public class CycleTime
    {
        public String Cprocess { get; set; }
        public String Cpartno { get; set; }
        public String Ctime { get; set; }
        public string Cseconds { get; set; }
    }
    public class getplannedEntry
    {
        public String partno { get; set; }
        public String Process { get; set; }
        public String pmaintenance { get; set; }
        public String cleaning { get; set; }
        public String break1 { get; set; }
        public String noplan { get; set; }
        public String trials { get; set; }
        public String meeitngs { get; set; }
        public String trainings { get; set; }
        public String plnmaintenance { get; set; }
    }
    public class getdowntime
    {
        public string types { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string total { get; set; }
        public string Remarks { get; set; }
    }
    public class Getrejload
    {
        public String partno { get; set; }
        public String pidn { get; set; }
        public String operation { get; set; }
        public String shift { get; set; }
    }
    public class GetPageLod
    {
        public String partno { get; set; }
        public String pidn { get; set; }
        public String operation { get; set; }
        public String shift { get; set; }
        public String dept { get; set; }
        public String ut { get; set; }
        public String machine { get; set; }
        public String Username { get; set; }
        public String Maintenance { get; set; }
        public String Tea { get; set; }
        public String Plan { get; set; }
        public String Manuf { get; set; }
        public String Meeting { get; set; }
        public String Fixed { get; set; }
        public String lunch { get; set; }
        public String shifttime { get; set; }
        public String Rejection { get; set; }
        public string Datetime { get; set; }
        public String logtime { get; set; }
        public String logdate { get; set; }
        public String TT { get; set; }
        public string accept { get; set; }
        public string ctime { get; set; }
        public string Utiletime { get; set; }
        public string mchn { get; set; }
        public string errormessage { get; set; }
        public string page { get; set; }
        public String pmaintenance { get; set; }
        public String cleaning { get; set; }
        public String break1 { get; set; }
        public String noplan { get; set; }
        public String trials { get; set; }
        public String meeitngs { get; set; }
        public String trainings { get; set; }
        public String plnmaintenance { get; set; }
        public String shiftime { get; set; }

    }
    public class Register
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Date { get; set; }
        public String Role { get; set; }
    }
    public class TimeMaster
    {
        public String Tpartno { get; set; }
        public String Toperation { get; set; }
        public String Tbottle { get; set; }
        public String TTT { get; set; }
    }
    public class cycletime
    {
        public String cylcpartno { get; set; }
        public String cycloperation { get; set; }
        public String cyclettime { get; set; }
    }
    public class laborEfficiency
    {
        public String Accept { get; set; }
        public String cycl { get; set; }
        public String total { get; set; }
        public String ttl { get; set; }
    }
    public class laborEff
    {
        public string errormessage { get; set; }
        public int val { get; set; }
    }
    public class getactualtimevalues
    {
        public string partno { get; set; }
        public string process { get; set; }
        public string shift { get; set; }
        public string fixedtime { get; set; }
        public string prdqty { get; set; }
    }
    public class runchartdimension
    {
        public string runchart { get; set; }
        public string ucl { get; set; }
        public string lcl { get; set; }
        public string usl { get; set; }
        public string lsl { get; set; }
        public string mean { get; set; }
        public string dimension { get; set; }
        public string DynRefid { get; set; }
        public string DynValid { get; set; }
        public string ColDimen { get; set; }
        
    }
    [WebMethod]
    public static string SelectmbuStatus(string Unit, string Cell, string Name)
    {
        lock (thisLock)
        {
            string res = "";
            try
            {
                ConnectionState state = strConnString.State;
                if (state == ConnectionState.Open)
                {
                    strConnString.Close();
                    //  strConnString.Open();
                }
                //else
                //{
                strConnString.Open();
                //}
                cmd = new SqlCommand("select * from Stationstatus where Unit='" + Unit + "' and Line='" + Cell.ToString() + "' and StationName='" + Name.ToString() + "'", strConnString);
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        res = dr["MStatus"].ToString();
                    }
                }
                else
                {
                    res = "";
                }
                strConnString.Close();
                dr.Close();

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {
            }

            return res.ToString();
        }
    }
    [WebMethod]
    public static string Updatembustatus(string Machine, string Status, string Cell, string Unit)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {

                ConnectionState state = strConnString.State;
                if (state == ConnectionState.Open)
                {
                    strConnString.Close();
                    strConnString.Open();
                }
                else
                {
                    strConnString.Open();
                }
                cmd = new SqlCommand("savestationstatus", strConnString);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@stationname", SqlDbType.VarChar, 100).Value = Machine.ToString();
                cmd.Parameters.Add("@unit", SqlDbType.VarChar, 30).Value = Unit.ToString();
                cmd.Parameters.Add("@status", SqlDbType.VarChar, 15).Value = Status.ToString();
                cmd.Parameters.Add("@line", SqlDbType.VarChar, 15).Value = Cell.ToString();


            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {

                cmd.ExecuteNonQuery();
                strConnString.Close();
                res = "S";
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static userheader[] userdata()
    {
        List<userheader> obju = new List<userheader>();
        userheader objuu = new userheader();
        lock (thisLock)
        {
            try
            {
                objuu.name = HttpContext.Current.Session["User_Name"].ToString();
                objuu.date = HttpContext.Current.Session["LogDate"].ToString();
                objuu.time = HttpContext.Current.Session["Logtime"].ToString();
                if (HttpContext.Current.Session["machine"] != null && HttpContext.Current.Session["machine"].ToString() != "")
                {
                    objuu.Machinename = HttpContext.Current.Session["machine"].ToString();
                }
                else
                {
                    objuu.Machinename = "";
                }
                obju.Add(objuu);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }

            finally
            {
            }
            return obju.ToArray();
        }
    }
    [WebMethod]
    public static Getfeedback[] GetFB_view(string Fromdate, string Todate)
    {
        List<Getfeedback> objf = new List<Getfeedback>();
        Getfeedback objfb = new Getfeedback();
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from Feedback where Convert(Varchar,FB_Date,103) >= Convert(Varchar,'" + Fromdate + "',103) and Convert(Varchar,FB_Date,101) <=Convert(Varchar,'" + Todate + "',103) ", strConnString);
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        objfb = new Getfeedback();
                        objfb.cell = ds.Tables[0].Rows[i]["Cell"].ToString();
                        objfb.fdate = ds.Tables[0].Rows[i]["FB_Date"].ToString();
                        objfb.feedback = ds.Tables[0].Rows[i]["FeedBack"].ToString();
                        objfb.id = ds.Tables[0].Rows[i]["FBID"].ToString();
                        objfb.name = ds.Tables[0].Rows[i]["U_Name"].ToString();
                        objfb.operation = ds.Tables[0].Rows[i]["Operation"].ToString();
                        objfb.partno = ds.Tables[0].Rows[i]["Partno"].ToString();
                        objfb.r_date = ds.Tables[0].Rows[i]["FB_Rdate"].ToString();
                        objfb.resby = ds.Tables[0].Rows[i]["ResponseBy"].ToString();
                        objfb.response = ds.Tables[0].Rows[i]["Response"].ToString();
                        objfb.shift = ds.Tables[0].Rows[i]["Shift"].ToString();
                        objfb.machine = ds.Tables[0].Rows[i]["Machine"].ToString();
                        objf.Add(objfb);
                    }

                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
            }
            finally
            {
            }
            return objf.ToArray();
        }
    }
    [WebMethod]
    public static Getfeedback[] GetFB()
    {
        List<Getfeedback> objf = new List<Getfeedback>();
        Getfeedback objfb = new Getfeedback();
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from Feedback", strConnString);
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        objfb = new Getfeedback();
                        objfb.cell = ds.Tables[0].Rows[i]["Cell"].ToString();
                        objfb.fdate = ds.Tables[0].Rows[i]["FB_Date"].ToString();
                        objfb.feedback = ds.Tables[0].Rows[i]["FeedBack"].ToString();
                        objfb.id = ds.Tables[0].Rows[i]["FBID"].ToString();
                        objfb.name = ds.Tables[0].Rows[i]["U_Name"].ToString();
                        objfb.operation = ds.Tables[0].Rows[i]["Operation"].ToString();
                        objfb.partno = ds.Tables[0].Rows[i]["Partno"].ToString();
                        objfb.r_date = ds.Tables[0].Rows[i]["FB_Rdate"].ToString();
                        objfb.resby = ds.Tables[0].Rows[i]["ResponseBy"].ToString();
                        objfb.response = ds.Tables[0].Rows[i]["Response"].ToString();
                        objfb.shift = ds.Tables[0].Rows[i]["Shift"].ToString();
                        objfb.machine = ds.Tables[0].Rows[i]["Machine"].ToString();
                        objf.Add(objfb);
                    }

                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return objf.ToArray();
        }
    }
    [WebMethod]
    public static T_content[] get_tablecontent(string Partno, string OPE, string Fix, string Month, string Year, string Mach)
    {
        List<T_content> objT = new List<T_content>();
        T_content obj_T = new T_content();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {

                    string query = "select * from FixtureStatus where Partno='" + Partno.ToString() + "' and Operation='" + OPE + "' and Fixtureno='" + Fix + "' and Month='" + Month.ToString() + "' and Year='" + Year.ToString() + "' and Machine='" + Mach + "';select count(YellowOpenDate)as Alert from FixtureStatus where Partno='" + Partno.ToString() + "' and Operation='" + OPE + "' and Fixtureno='" + Fix + "' and Month='" + Month.ToString() + "' and Year='" + Year.ToString() + "'  and Machine='" + Mach + "';select count(YellowCloseDate)as Calibrate from FixtureStatus where Partno='" + Partno.ToString() + "' and Operation='" + OPE + "' and Fixtureno='" + Fix + "' and Y_Month='" + Month.ToString() + "' and Y_Year='" + Year.ToString() + "' and Machine='" + Mach + "'";
                    da = new SqlDataAdapter(query, strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        obj_T.Partno = Partno;
                        if (ds.Tables[1].Rows[0]["Alert"] != null && ds.Tables[1].Rows[0]["Alert"].ToString() != "")
                        {
                            obj_T.A_count = ds.Tables[1].Rows[0]["Alert"].ToString();
                        }
                        else
                        {
                            obj_T.A_count = "0";
                        }
                        if (ds.Tables[2].Rows[0]["Calibrate"] != null && ds.Tables[2].Rows[0]["Calibrate"] != "")
                        {

                            obj_T.C_count = ds.Tables[2].Rows[0]["Calibrate"].ToString();
                        }
                        else
                        {
                            obj_T.C_count = "0";
                        }
                        objT.Add(obj_T);

                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return objT.ToArray();
        }
    }
    [WebMethod]
    public static string savefixvalues(string Partno, string Fixname, string Operation, string Life, string Gf, string Gt, string Yf, string Yt, string Rf, string Rt, string ID, string GrFrom, string Grto, string YEfrom, string Yeto, string Refrom, string Reto)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    cmd = new SqlCommand("AddFixtureValues", strConnString);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fixname", SqlDbType.VarChar, 30).Value = Fixname.ToString();
                    cmd.Parameters.Add("@partno", SqlDbType.VarChar, 30).Value = Partno.ToString();
                    cmd.Parameters.Add("@life", SqlDbType.VarChar, 30).Value = Life.ToString();
                    cmd.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = Operation.ToString();
                    cmd.Parameters.Add("@gf", SqlDbType.VarChar, 10).Value = GrFrom.ToString();
                    cmd.Parameters.Add("@gt", SqlDbType.VarChar, 10).Value = Grto.ToString();
                    cmd.Parameters.Add("@yf", SqlDbType.VarChar, 10).Value = YEfrom.ToString();
                    cmd.Parameters.Add("@yt", SqlDbType.VarChar, 10).Value = Yeto.ToString();
                    cmd.Parameters.Add("@Rf", SqlDbType.VarChar, 10).Value = Refrom.ToString();
                    cmd.Parameters.Add("@rto", SqlDbType.VarChar, 10).Value = Reto.ToString();
                    cmd.Parameters.Add("@data", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(ID);
                    cmd.Parameters.Add("@flag", SqlDbType.VarChar, 5).Value = "0";
                    cmd.Parameters.Add("@greenrnage", SqlDbType.VarChar, 30).Value = Gf.ToString();
                    cmd.Parameters.Add("@yellowrnage", SqlDbType.VarChar, 30).Value = Yf.ToString();
                    cmd.Parameters.Add("@redrnage", SqlDbType.VarChar, 30).Value = Rf.ToString();
                    cmd.Parameters.Add("@greenrnage1", SqlDbType.VarChar, 30).Value = Gt.ToString();
                    cmd.Parameters.Add("@yellowrnage1", SqlDbType.VarChar, 30).Value = Yt.ToString();
                    cmd.Parameters.Add("@redrnage1", SqlDbType.VarChar, 30).Value = Rt.ToString();

                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";

                }
                finally
                {
                    if (strConnString.State == ConnectionState.Open)
                    {
                        strConnString.Close();
                    }
                    strConnString.Open();
                    cmd.ExecuteNonQuery();
                    strConnString.Close();
                    res = "S";
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }

    [WebMethod]
    public static string savefixvalues1(string ID, string Life, string Gf, string Gt, string Yf, string Yt, string Rf, string Rt, string Life1, string GrFrom, string Grto, string YEfrom, string Yeto, string Refrom, string Reto, string Fixturename)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            string Fixname = HttpContext.Current.Session["FixNo"].ToString();
            string Partno = HttpContext.Current.Session["PartNo"].ToString();
            string Operation = HttpContext.Current.Session["Operation"].ToString();
            lock (thisLock)
            {
                try
                {
                    int count = Convert.ToInt32(Life) + Convert.ToInt32(Life1);
                    cmd = new SqlCommand("AddFixtureValues", strConnString);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fixname", SqlDbType.VarChar, 30).Value = Fixturename.ToString();// Fixname.ToString();
                    cmd.Parameters.Add("@partno", SqlDbType.VarChar, 30).Value = Partno.ToString();
                    cmd.Parameters.Add("@life", SqlDbType.VarChar, 30).Value = count.ToString();
                    cmd.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = Operation.ToString();
                    cmd.Parameters.Add("@gf", SqlDbType.VarChar, 10).Value = GrFrom.ToString();
                    cmd.Parameters.Add("@gt", SqlDbType.VarChar, 10).Value = Grto.ToString();
                    cmd.Parameters.Add("@yf", SqlDbType.VarChar, 10).Value = YEfrom.ToString();
                    cmd.Parameters.Add("@yt", SqlDbType.VarChar, 10).Value = Yeto.ToString();
                    cmd.Parameters.Add("@Rf", SqlDbType.VarChar, 10).Value = Refrom.ToString();
                    cmd.Parameters.Add("@rto", SqlDbType.VarChar, 10).Value = Reto.ToString();
                    cmd.Parameters.Add("@data", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(ID);
                    cmd.Parameters.Add("@flag", SqlDbType.VarChar, 5).Value = "0";
                    cmd.Parameters.Add("@greenrnage", SqlDbType.VarChar, 30).Value = Gf.ToString();
                    cmd.Parameters.Add("@yellowrnage", SqlDbType.VarChar, 30).Value = Yf.ToString();
                    cmd.Parameters.Add("@redrnage", SqlDbType.VarChar, 30).Value = Rf.ToString();
                    cmd.Parameters.Add("@greenrnage1", SqlDbType.VarChar, 30).Value = Gt.ToString();
                    cmd.Parameters.Add("@yellowrnage1", SqlDbType.VarChar, 30).Value = Yt.ToString();
                    cmd.Parameters.Add("@redrnage1", SqlDbType.VarChar, 30).Value = Rt.ToString();


                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";
                }
                finally
                {
                    if (strConnString.State == ConnectionState.Open)
                    {
                        strConnString.Close();
                    }
                    strConnString.Open();
                    cmd.ExecuteNonQuery();
                    strConnString.Close();
                    res = "S";
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }
    [WebMethod]
    public static Fixvalues[] editfixvalues(string ID)
    {
        List<Fixvalues> objfv = new List<Fixvalues>();
        Fixvalues obv = new Fixvalues();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select a.*,b.Fixturename from FixtureValues a inner join FixtureName b on a.FixName =b.Fixturename where a.Fid='" + Convert.ToInt32(ID) + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        obv.fixno = ds.Tables[0].Rows[0]["FixID"].ToString();
                        obv.gf = ds.Tables[0].Rows[0]["GreenRange"].ToString();
                        obv.gt = ds.Tables[0].Rows[0]["GreenRange1"].ToString();
                        obv.id = ds.Tables[0].Rows[0]["Fid"].ToString();
                        obv.life = ds.Tables[0].Rows[0]["FixLife"].ToString();
                        obv.operation = ds.Tables[0].Rows[0]["Operation"].ToString();
                        obv.drawing = ds.Tables[0].Rows[0]["Availability"].ToString();
                        obv.partno = ds.Tables[0].Rows[0]["Partno"].ToString();
                        obv.rf = ds.Tables[0].Rows[0]["RedRange"].ToString();
                        obv.rt = ds.Tables[0].Rows[0]["RedRange1"].ToString();
                        obv.yf = ds.Tables[0].Rows[0]["YellowRange"].ToString();
                        obv.yt = ds.Tables[0].Rows[0]["YellowRange1"].ToString();
                        obv.fixname = ds.Tables[0].Rows[0]["FixName"].ToString();
                        objfv.Add(obv);

                    }
                    else
                    {
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return objfv.ToArray();
        }
    }
    [WebMethod]
    public static Fixvalues[] getfixvalues()
    {
        List<Fixvalues> objfv = new List<Fixvalues>();
        Fixvalues obv = new Fixvalues();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {

                    da = new SqlDataAdapter("select * from FixtureValues", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            obv = new Fixvalues();
                            obv.fixname = ds.Tables[0].Rows[i]["FixName"].ToString();
                            obv.gf = ds.Tables[0].Rows[i]["GreenRange"].ToString();
                            obv.gt = ds.Tables[0].Rows[i]["GreenRange1"].ToString();
                            obv.id = ds.Tables[0].Rows[i]["Fid"].ToString();
                            obv.life = ds.Tables[0].Rows[i]["FixLife"].ToString();
                            obv.operation = ds.Tables[0].Rows[i]["Operation"].ToString();
                            obv.partno = ds.Tables[0].Rows[i]["Partno"].ToString();
                            obv.rf = ds.Tables[0].Rows[i]["RedRange"].ToString();
                            obv.rt = ds.Tables[0].Rows[i]["RedRange1"].ToString();
                            obv.yf = ds.Tables[0].Rows[i]["YellowRange"].ToString();
                            obv.yt = ds.Tables[0].Rows[i]["YellowRange1"].ToString();
                            objfv.Add(obv);
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return objfv.ToArray();
        }
    }
    [WebMethod]
    public static string GetFixtureStatus(string Color, string FixtureNo)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    string Fixno = HttpContext.Current.Session["FixNo"].ToString();
                    string Machine = HttpContext.Current.Session["machine"].ToString();
                    string prdname = HttpContext.Current.Session["PartNo"].ToString();
                    string process = HttpContext.Current.Session["Operation"].ToString();
                    //string[] splitFixno = Fixno.Split(',');
                    //for (int i = 0; i < splitFixno.Length; i++)
                    //{
                    da = new SqlDataAdapter("select * from FixtureStatus where Partno='" + prdname + "' and Fixtureno='" + FixtureNo.ToString() + "' and Operation='" + process + "' and E_Flag='0' and Machine='" + Machine + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Color == "Yellow")
                        {
                            if (ds.Tables[0].Rows[0]["YellowOpenDate"].ToString() == "")
                            {
                                if (strConnString.State == ConnectionState.Open)
                                {
                                    strConnString.Close();
                                }
                                strConnString.Open();
                                cmd = new SqlCommand("update FixtureStatus set YellowOpenDate='" + DateTime.Now.ToShortDateString().ToString() + "'", strConnString);
                                cmd.ExecuteNonQuery();
                                strConnString.Close();

                            }
                            if (ds.Tables[0].Rows[0]["YellowCloseDate"].ToString() == "")
                            {
                                res = "Y";
                            }
                        }
                        if (Color == "Red")
                        {
                            if (ds.Tables[0].Rows[0]["RedOpenDate"].ToString() == "")
                            {
                                if (strConnString.State == ConnectionState.Open)
                                {
                                    strConnString.Close();
                                }
                                strConnString.Open();
                                cmd = new SqlCommand("update FixtureStatus set RedOpenDate='" + DateTime.Now.ToShortDateString().ToString() + "'", strConnString);
                                cmd.ExecuteNonQuery();
                                strConnString.Close();

                            }
                            if (ds.Tables[0].Rows[0]["RedCloseDate"].ToString() == "")
                            {
                                res = "R";
                            }
                        }
                        if (Color == "Green")
                        {

                            if (ds.Tables[0].Rows[0]["GreenCloseDate"].ToString() == "")
                            {
                                res = "G";
                            }
                        }

                    }
                    else
                    {
                        try
                        {
                            cmd = new SqlCommand("savefixturesatatus", strConnString);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@partno", SqlDbType.VarChar, 30).Value = prdname;
                            cmd.Parameters.Add("@fixno", SqlDbType.VarChar, 30).Value = FixtureNo.ToString(); //Fixno;
                            cmd.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = process;
                            cmd.Parameters.Add("@greedate", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                            cmd.Parameters.Add("@machine", SqlDbType.VarChar, 10).Value = Machine.ToString();
                            cmd.Parameters.Add("@month", SqlDbType.VarChar, 10).Value = DateTime.Now.Month.ToString();
                            cmd.Parameters.Add("@year", SqlDbType.VarChar, 10).Value = DateTime.Now.Year.ToString();

                        }
                        catch (Exception ex)
                        {
                            ExceptionLogging.SendExcepToDB(ex);
                            res = "F";
                        }
                        finally
                        {
                            if (strConnString.State == ConnectionState.Open)
                            {
                                strConnString.Close();
                            }
                            strConnString.Open();
                            cmd.ExecuteNonQuery();
                            strConnString.Close();
                            res = "G";
                        }
                    }
                    //}
                    //try
                    //{
                    //    cmd = new SqlCommand("savefixtureopen", strConnString);
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.Add("@partno", SqlDbType.VarChar, 30).Value = Partno;
                    //    cmd.Parameters.Add("@fixno", SqlDbType.VarChar, 30).Value = FixNo;
                    //    cmd.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = Operation;
                    //    cmd.Parameters.Add("@opendate", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                    //    cmd.Parameters.Add("@machine", SqlDbType.VarChar, 10).Value = MAchine.ToString();
                    //    cmd.Parameters.Add("@month", SqlDbType.VarChar, 10).Value = DateTime.Now.Month.ToString();
                    //    cmd.Parameters.Add("@year", SqlDbType.VarChar, 10).Value = DateTime.Now.Year.ToString();
                    //    cmd.Parameters.Add("@color", SqlDbType.VarChar, 10).Value = Color.ToString();
                    //    if (Color == "Green")
                    //    {
                    //        res = "G";
                    //    }
                    //    if (Color == "Yellow")
                    //    {
                    //        res = "Y";
                    //    }
                    //    if (Color == "Red")
                    //    {
                    //        res = "R";
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    res = "F";
                    //}
                    //finally
                    //{
                    //    strConnString.Open();
                    //    cmd.ExecuteNonQuery();
                    //    strConnString.Close();

                    //}
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }

            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string savefixturestatus(string Color, string Status, string Fix, string FixtureNo)
    {
        //List<operationrs> objfv = new List<operationrs>();
        //operationrs obv = new operationrs();
        string res = "";

        string finxname = "";
        lock (thisLock)
        {
            try
            {

                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    string FixNo = HttpContext.Current.Session["FixNo"].ToString();

                    string MAchine = HttpContext.Current.Session["machine"].ToString();

                    string Partno = HttpContext.Current.Session["PartNo"].ToString();
                    string Operation = HttpContext.Current.Session["Operation"].ToString();
                    // obv.operation = Operation;
                    da = new SqlDataAdapter("select * from FixtureStatus where Partno='" + Partno + "' and Fixtureno='" + FixtureNo + "' and Operation='" + Operation + "' and Machine='" + MAchine + "' and E_Flag='0'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            cmd = new SqlCommand("updatefxstatus", strConnString);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@partno", SqlDbType.VarChar, 30).Value = Partno;
                            cmd.Parameters.Add("@fxno", SqlDbType.VarChar, 30).Value = FixtureNo; //FixNo;
                            cmd.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = Operation;
                            cmd.Parameters.Add("@closedate", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                            cmd.Parameters.Add("@status", SqlDbType.VarChar, 500).Value = Status.ToString();
                            cmd.Parameters.Add("@mode", SqlDbType.VarChar, 10).Value = Color.ToString();
                            cmd.Parameters.Add("@month", SqlDbType.VarChar, 10).Value = DateTime.Now.Month.ToString();
                            cmd.Parameters.Add("@year", SqlDbType.VarChar, 10).Value = DateTime.Now.Year.ToString();
                            cmd.Parameters.Add("@machine", SqlDbType.VarChar, 10).Value = MAchine.ToString();

                            //cmd = new SqlCommand("savefixtureclose", strConnString);
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.Add("@partno", SqlDbType.VarChar, 30).Value = Partno;
                            //cmd.Parameters.Add("@fixno", SqlDbType.VarChar, 30).Value = FixNo;
                            //cmd.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = Operation;
                            //cmd.Parameters.Add("@closedate", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                            //cmd.Parameters.Add("@machine", SqlDbType.VarChar, 10).Value = MAchine.ToString();
                            //cmd.Parameters.Add("@month", SqlDbType.VarChar, 10).Value = DateTime.Now.Month.ToString();
                            //cmd.Parameters.Add("@year", SqlDbType.VarChar, 10).Value = DateTime.Now.Year.ToString();
                            //if (Color == "G")
                            //{
                            //    cmd.Parameters.Add("@color", SqlDbType.VarChar, 10).Value = "Green";
                            //}
                            //if (Color == "Y")
                            //{
                            //    cmd.Parameters.Add("@color", SqlDbType.VarChar, 10).Value = "Yellow";
                            //}
                            //if (Color == "R")
                            //{
                            //    cmd.Parameters.Add("@color", SqlDbType.VarChar, 10).Value = "Red";
                            //}
                            //cmd.Parameters.Add("@remark", SqlDbType.VarChar, 500).Value = Status.ToString();

                        }
                        catch (Exception ex)
                        {
                            res = "F";
                            ExceptionLogging.SendExcepToDB(ex);
                        }
                        finally
                        {
                            if (strConnString.State == ConnectionState.Open)
                            {
                                strConnString.Close();
                            }
                            strConnString.Open();
                            cmd.ExecuteNonQuery();
                            strConnString.Close();
                            res = "S";

                            int c = 0;
                            if (Fix == "N")
                            {
                                //SqlDataAdapter da1 = new SqlDataAdapter("select max(Fid) as id, min(Fid) as lid from FixtureValues  where Partno='" + Partno + "'  and Operation='" + Operation + "' and Status='Active'", strConnString);
                                SqlDataAdapter da1 = new SqlDataAdapter("select max(a.Fid) as id, min(a.Fid) as lid from FixtureValues a inner join FixtureName b on cast(a.FixName as int)=b.FID where a.Partno='" + Partno + "'  and a.Operation='" + Operation + "' and a.Status='Active' and b.Fixturename='" + FixtureNo + "'", strConnString);
                                DataSet ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    int id = Convert.ToInt32(ds1.Tables[0].Rows[0]["id"].ToString());
                                    int id1 = Convert.ToInt32(ds1.Tables[0].Rows[0]["lid"].ToString());
                                    //SqlDataAdapter da2 = new SqlDataAdapter("select * from FixtureValues where Fid=" + id + " and  Status='Active';select * from FixtureValues where Fid=" + id1 + " and  Status='Active'", strConnString);
                                    SqlDataAdapter da2 = new SqlDataAdapter("select a.*,b.Fixturename from FixtureValues a inner join FixtureName b on cast(a.FixName as int)=b.FID where a.Fid=" + id + " and  a.Status='Active' and b.Fixturename='" + FixNo + "';select a.*,b.Fixturename from FixtureValues a inner join FixtureName b on cast(a.FixName as int)=b.FID where a.Fid=" + id1 + " and a.Status='Active' and b.Fixturename='" + FixtureNo + "'", strConnString);
                                    DataSet ds2 = new DataSet();
                                    ds2.Tables.Clear();
                                    ds2.Clear();
                                    ds2.Reset();
                                    da2.Fill(ds2);
                                    if (ds2.Tables[0].Rows.Count > 0)
                                    {
                                        try
                                        {
                                            SqlCommand cmd1 = new SqlCommand("AddFixtureValues", strConnString);
                                            cmd1.CommandType = CommandType.StoredProcedure;
                                            if (ds2.Tables[1].Rows[0]["Flag"].ToString() != "" && ds2.Tables[1].Rows[0]["Flag"].ToString() != null)
                                            {
                                                int f = Convert.ToInt32(ds2.Tables[0].Rows[0]["Flag"].ToString());
                                                string name = ds2.Tables[1].Rows[0]["Fixturename"].ToString();
                                                c = f + 1;
                                                finxname = name + "-" + c.ToString();
                                                cmd1.Parameters.Add("@fixname", SqlDbType.VarChar, 30).Value = name + "-" + c.ToString();
                                                cmd1.Parameters.Add("@flag", SqlDbType.VarChar, 5).Value = c.ToString();
                                                if (strConnString.State == ConnectionState.Open)
                                                {
                                                    strConnString.Close();
                                                }
                                                strConnString.Open();
                                                SqlCommand cmd2 = new SqlCommand("update FixtureValues set Status='Close' where Partno='" + Partno + "'  and Operation='" + Operation + "' and Status='Active' and FixName='" + ds2.Tables[1].Rows[0]["FixName"].ToString() + "'", strConnString);
                                                cmd2.ExecuteNonQuery();
                                                strConnString.Close();
                                            }
                                            if (strConnString.State == ConnectionState.Open)
                                            {
                                                strConnString.Close();
                                            }
                                            strConnString.Open();
                                            cmd1.Parameters.Add("@partno", SqlDbType.VarChar, 30).Value = ds2.Tables[0].Rows[0]["Partno"].ToString();
                                            cmd1.Parameters.Add("@life", SqlDbType.VarChar, 30).Value = ds2.Tables[0].Rows[0]["FixLife"].ToString();
                                            cmd1.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = ds2.Tables[0].Rows[0]["Operation"].ToString();
                                            cmd1.Parameters.Add("@gf", SqlDbType.VarChar, 10).Value = ds2.Tables[0].Rows[0]["Gfrom"].ToString();
                                            cmd1.Parameters.Add("@gt", SqlDbType.VarChar, 10).Value = ds2.Tables[0].Rows[0]["Gto"].ToString();
                                            cmd1.Parameters.Add("@yf", SqlDbType.VarChar, 10).Value = ds2.Tables[0].Rows[0]["Yfrom"].ToString();
                                            cmd1.Parameters.Add("@yt", SqlDbType.VarChar, 10).Value = ds2.Tables[0].Rows[0]["Yto"].ToString();
                                            cmd1.Parameters.Add("@Rf", SqlDbType.VarChar, 10).Value = ds2.Tables[0].Rows[0]["Rfrom"].ToString();
                                            cmd1.Parameters.Add("@rto", SqlDbType.VarChar, 10).Value = ds2.Tables[0].Rows[0]["Rto"].ToString();
                                            cmd1.Parameters.Add("@data", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                                            cmd1.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(0);
                                            cmd1.ExecuteNonQuery();
                                            strConnString.Close();

                                        }
                                        catch (Exception ex)
                                        {
                                            ExceptionLogging.SendExcepToDB(ex);
                                            res = "F";
                                        }
                                        finally
                                        {

                                            try
                                            {
                                                if (strConnString.State == ConnectionState.Open)
                                                {
                                                    strConnString.Close();
                                                }
                                                strConnString.Open();
                                                SqlCommand cmd3 = new SqlCommand("Addfixname", strConnString);
                                                cmd3.CommandType = CommandType.StoredProcedure;
                                                cmd3.Parameters.Add("@partnumber", SqlDbType.VarChar, 30).Value = Partno.ToString();
                                                cmd3.Parameters.Add("@fixname", SqlDbType.VarChar, 30).Value = finxname.ToString();
                                                cmd3.Parameters.Add("@createdata", SqlDbType.VarChar, 30).Value = DateTime.Now.ToShortDateString().ToString();
                                                cmd3.Parameters.Add("@id", SqlDbType.VarChar, 30).Value = 0;
                                                cmd3.ExecuteNonQuery();
                                                strConnString.Close();
                                            }
                                            catch (Exception ex)
                                            {
                                                ExceptionLogging.SendExcepToDB(ex);
                                                res = "F";
                                            }
                                            finally
                                            {

                                                strConnString.Close();
                                                res = "S";
                                            }
                                            res = "S";
                                        }
                                    }
                                }
                                else
                                {
                                }
                            }
                            if (Fix == "E")
                            {
                                //SqlDataAdapter da5 = new SqlDataAdapter("select * from FixtureValues  where Partno='" + Partno + "'  and Operation='" + Operation + "' and Status='Active' and FixName='" + FixNo + "'", strConnString);
                                SqlDataAdapter da5 = new SqlDataAdapter("select a.*,b.Fixturename from FixtureValues a inner join FixtureName b on a.FixName=b.Fixturename and a.Partno=b.Partnumber where a.Partno='" + Partno + "'  and a.Operation='" + Operation + "' and a.Status='Active' and b.Fixturename='" + FixtureNo + "'", strConnString);
                                DataSet ds5 = new DataSet();
                                ds5.Tables.Clear();
                                ds.Clear();
                                ds5.Reset();
                                da5.Fill(ds5);
                                if (ds5.Tables[0].Rows.Count > 0)
                                {
                                    res = ds5.Tables[0].Rows[0]["Fid"].ToString();
                                    if (Color == "Y" || Color == "R")
                                    {
                                        if (strConnString.State == ConnectionState.Open)
                                        {
                                            strConnString.Close();
                                        }
                                        strConnString.Open();
                                        cmd = new SqlCommand("update FixtureStatus set E_Flag='1' where Partno='" + Partno + "' and Fixtureno='" + FixtureNo + "' and Operation='" + Operation + "'  and Machine='" + MAchine + "'", strConnString);
                                        cmd.ExecuteNonQuery();
                                        strConnString.Close();

                                    }
                                    else
                                    {
                                        res = "S";
                                    }
                                }
                                else
                                {
                                    res = "F";
                                }

                            }


                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }

            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();
            //objfv.Add(obv);

            //return objfv.ToArray();

        }
    }
    [WebMethod]
    public static Fixvalues[] GetfixtureValue()
    {
        string mulfixname = "";
        List<Fixvalues> objfv = new List<Fixvalues>();
        Fixvalues obv = new Fixvalues();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    string prdname = HttpContext.Current.Session["PartNo"].ToString();
                    string process = HttpContext.Current.Session["Operation"].ToString();
                    string Cell = HttpContext.Current.Session["Depart"].ToString();
                    if (process == "OP1")
                    {
                        process = "1";
                    }
                    if (process == "OP2")
                    {
                        process = "2";
                    }

                    string tableName = "QualitySheet_" + Cell + "_" + prdname + "_" + process + "";
                    //if (process == "Grinding")
                    //{
                    //    process = "1";
                    //}
                    //da = new SqlDataAdapter("select a.*,b.Fixturename from FixtureValues a inner join FixtureName b on cast(a.FixName as int)=b.FID where a.Partno='" + prdname + "' and a.Operation='" + process + "' and a.Status='Active' and b.Fixturename='" + HttpContext.Current.Session["Fixture"].ToString() + "'", strConnString);
                    da = new SqlDataAdapter("select a.*,b.Fixturename from FixtureValues a inner join FixtureName b on a.FixName=b.Fixturename  where b.Partnumber like '%" + prdname + "%' and a.Operation='" + process + "' and b.Line='" + HttpContext.Current.Session["machine"].ToString() + "' and a.Status='Active'", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    obv.partno1 = HttpContext.Current.Session["PartNo"].ToString();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            obv = new Fixvalues();
                            obv.fixname = ds.Tables[0].Rows[i]["FixName"].ToString();
                            obv.gf = ds.Tables[0].Rows[i]["Gfrom"].ToString();
                            obv.gt = ds.Tables[0].Rows[i]["Gto"].ToString();
                            obv.rf = ds.Tables[0].Rows[i]["Rfrom"].ToString();
                            obv.rt = ds.Tables[0].Rows[i]["Rto"].ToString();
                            obv.yf = ds.Tables[0].Rows[i]["Yfrom"].ToString();
                            obv.yt = ds.Tables[0].Rows[i]["Yto"].ToString();
                            obv.partno1 = prdname;//ds.Tables[0].Rows[i]["Partno"].ToString();

                            //HttpContext.Current.Session["FixNo"] = obv.fixname.ToString();

                            mulfixname += "," + ds.Tables[0].Rows[i]["FixName"].ToString();
                            if (mulfixname.StartsWith(","))
                            {
                                mulfixname = mulfixname.Substring(1);
                            }
                            HttpContext.Current.Session["FixNo"] = mulfixname.ToString();

                            obv.multifixname = mulfixname;

                            //SqlDataAdapter da1 = new SqlDataAdapter("select count(*)totoal from " + tableName + " where FixNo like '%" + ds.Tables[0].Rows[i]["FixName"].ToString() + "%'", strConnString);
                            //DataSet ds1 = new DataSet();
                            //da1.Fill(ds1);
                            //if (ds1.Tables[0].Rows.Count > 0)
                            //{
                            //    if (ds1.Tables[0].Rows[0]["totoal"].ToString() != "0")
                            //    {
                            //        obv.partno = ds1.Tables[0].Rows[0]["totoal"].ToString();
                            //    }
                            //}

                            SqlDataAdapter da1 = new SqlDataAdapter("select a.*,b.Fixturename,b.Partnumber from FixtureValues a inner join FixtureName b on a.FixName=b.Fixturename where a.Operation='" + process + "' and b.Line='" + HttpContext.Current.Session["machine"].ToString() + "' and FixName='" + ds.Tables[0].Rows[i]["FixName"].ToString() + "' and a.Status='Active'", strConnString);
                            DataSet ds1 = new DataSet();
                            ds1.Tables.Clear();
                            ds1.Clear();
                            ds1.Reset();
                            da1.Fill(ds1);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                int fixcount = 0;
                                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                                {
                                    string[] spltpartno = ds1.Tables[0].Rows[j]["Partnumber"].ToString().Split(',');
                                    for (int k = 0; k < spltpartno.Length; k++)
                                    {
                                        string fixtablename = "QualitySheet_" + Cell + "_" + spltpartno[k].ToString() + "_" + ds1.Tables[0].Rows[j]["Operation"].ToString() + "";
                                        SqlDataAdapter da2 = new SqlDataAdapter("select count(*)totoal from " + fixtablename + " where FixNo like '%" + ds.Tables[0].Rows[i]["FixName"].ToString() + "%'", strConnString);
                                        DataSet ds2 = new DataSet();
                                        ds2.Tables.Clear();
                                        ds2.Clear();
                                        ds2.Reset();
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
                                obv.partno = fixcount.ToString();
                            }
                            objfv.Add(obv);
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return objfv.ToArray();
        }
    }
    [WebMethod]
    public static Fixname[] getfixname()
    {
        List<Fixname> objf = new List<Fixname>();
        Fixname objfix = new Fixname();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from FixtureName", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            objfix = new Fixname();
                            objfix.fixname = ds.Tables[0].Rows[i]["Fixturename"].ToString();
                            objfix.partno = ds.Tables[0].Rows[i]["Partnumber"].ToString();
                            objfix.fid = ds.Tables[0].Rows[i]["FID"].ToString();
                            objf.Add(objfix);
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return objf.ToArray();
        }
    }
    [WebMethod]
    public static string deletefixname(string ID)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    cmd = new SqlCommand("delete from FixtureName where FID='" + Convert.ToInt32(ID) + "'", strConnString);

                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";
                }
                finally
                {
                    if (strConnString.State == ConnectionState.Open)
                    {
                        strConnString.Close();
                    }
                    strConnString.Open();
                    cmd.ExecuteNonQuery();
                    strConnString.Close();
                    res = "S";
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }

    [WebMethod]
    public static string Reorderlevel()
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    string Partno = HttpContext.Current.Session["PartNo"].ToString();
                    string Operation = HttpContext.Current.Session["Operation"].ToString();
                    //  string Machine = HttpContext.Current.Session["machine"].ToString();
                    //  string Process = HttpContext.Current.Session["Process"].ToString();
                    string Cell = HttpContext.Current.Session["Depart"].ToString();
                    string Unit = HttpContext.Current.Session["Unit"].ToString();
                    //da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by cast(dynrefid as int) asc", strConnString);
                    da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and (Reorder ='0' or Reorder is null) order by cast(Reorder as int) asc", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        res = "Not Allocated";
                    }
                    else
                    { res = "Allocated"; }
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";
                }
                finally
                {
                    
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }

    [WebMethod]
    public static string deletefixvalue1(string ID)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                string fixid = "";
                da = new SqlDataAdapter("select * from FixtureValues where FID='" + Convert.ToInt32(ID) + "'", strConnString);
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    fixid = ds.Tables[0].Rows[0]["FixID"].ToString();
                }
                cmd = new SqlCommand("delete from FixtureName where Fid='" + Convert.ToInt32(fixid) + "'", strConnString);
                cmd = new SqlCommand("delete from FixtureValues where Fid='" + Convert.ToInt32(ID) + "'", strConnString);

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                res = "S";
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string deletefixvalue(string ID)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    cmd = new SqlCommand("delete from FixtureValues where Fid='" + Convert.ToInt32(ID) + "'", strConnString);

                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";
                }
                finally
                {
                    if (strConnString.State == ConnectionState.Open)
                    {
                        strConnString.Close();
                    }
                    strConnString.Open();
                    cmd.ExecuteNonQuery();
                    strConnString.Close();
                    res = "S";
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }
    [WebMethod]
    public static Fixname[] editfixname(string ID)
    {
        List<Fixname> objf = new List<Fixname>();
        Fixname objfix = new Fixname();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from FixtureName where FID='" + Convert.ToInt32(ID) + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            objfix = new Fixname();
                            objfix.fixname = ds.Tables[0].Rows[i]["Fixturename"].ToString();
                            objfix.partno = ds.Tables[0].Rows[i]["Partnumber"].ToString();
                            objfix.fid = ds.Tables[0].Rows[i]["FID"].ToString();
                            objfix.unit = ds.Tables[0].Rows[i]["Unit"].ToString();
                            objfix.line = ds.Tables[0].Rows[i]["Line"].ToString();
                            objfix.model = ds.Tables[0].Rows[i]["Model"].ToString();
                            objfix.type = ds.Tables[0].Rows[i]["Type"].ToString();
                            objfix.fixtureno = ds.Tables[0].Rows[i]["Fixtrue"].ToString();
                            objfix.cell = ds.Tables[0].Rows[i]["Cell"].ToString();
                            objf.Add(objfix);
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return objf.ToArray();
        }
    }
    [WebMethod]
    public static getdowntime[] get_downtime(string part, string pid, string shift, string operation, string Machine, string Unit)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        List<getdowntime> objdown = new List<getdowntime>();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from EfficiencyCalculaus where Partno='" + part + "' and EffDate='" + date + "' and Shift='" + shift + "' and PIDNO='" + pid + "' and MachineName='" + Machine + "' and unit='" + Unit + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            getdowntime obj_down = new getdowntime();
                            obj_down.start_time = ds.Tables[0].Rows[i]["DowntimeStart"].ToString();
                            obj_down.end_time = ds.Tables[0].Rows[i]["DowntimedEnd"].ToString();
                            obj_down.types = ds.Tables[0].Rows[i]["DowntimeType"].ToString();
                            obj_down.Remarks = ds.Tables[0].Rows[i]["Remarks"].ToString();
                            obj_down.total = ds.Tables[0].Rows[i]["DowntimeTotal"].ToString();
                            objdown.Add(obj_down);
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objdown.ToArray();
        }
    }
    [WebMethod]
    public static laborEff[] laborEff1(string date, string shift, string mchn, string unit)
    {
        List<laborEff> objeff = new List<laborEff>();
        laborEff objeff1 = new laborEff();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    string errormessage1 = "";
                    int Accept = 0;
                    int cycl = 0;
                    int Accept1 = 0;
                    int cycl1 = 0;
                    int ttl = 0;
                    int ttlaccept = 0;
                    int ttlcyc = 0;

                    for (int i = 0; i < table.Length; i++)
                    {
                        da = new SqlDataAdapter(" Select * from " + table[i] + " where rejectedQty <> 1  and Shift= '" + shift + "' and MachineName= '" + mchn + "' and unit= '" + unit + "' and CreatedOn ='" + Convert.ToDateTime(date) + "'", strConnString);
                        ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Accept = Accept + Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());
                            if (table[i] == "QualitySheet")
                            {
                                da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='A17724Q' and CProcess='OP1'", strConnString);
                                ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                string values = ds1.Tables[0].Rows[0]["CTime"].ToString();
                                if (values == "" || values == null)
                                {
                                    errormessage1 += "," + "Please Enter the Quality Sheet(A17724Q) Operation One Cycle time Values";
                                }
                                else
                                {
                                    double val = Convert.ToDouble(values);
                                    cycl = cycl + Convert.ToInt32(val);
                                }
                            }
                            if (table[i] == "QualitySheetA22916J")
                            {

                                da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='A22916J' and CProcess='OP1'", strConnString);
                                ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                string values = ds1.Tables[0].Rows[0]["CTime"].ToString();
                                if (values == "" || values == null)
                                {
                                    errormessage1 += "," + "Please Enter the Quality Sheet(A22916J) Operation One Cycle time Values";
                                }
                                else
                                {
                                    double val = Convert.ToDouble(values);
                                    cycl = cycl + Convert.ToInt32(val);
                                }
                            }

                            if (table[i] == "qualityshtA44983U")
                            {

                                da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='A44983U' and CProcess='OP1'", strConnString);
                                ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                string values = ds1.Tables[0].Rows[0]["CTime"].ToString();
                                if (values == "" || values == null)
                                {
                                    errormessage1 += "," + "Please Enter the Quality Sheet(A44983U) Operation One Cycle time Values";
                                }
                                else
                                {
                                    double val = Convert.ToDouble(values);
                                    cycl = cycl + Convert.ToInt32(val);
                                }
                            }
                            if (table[i] == "QSheetA32271C")
                            {

                                da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='A32271C' and CProcess='OP1'", strConnString);
                                ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                string values = ds1.Tables[0].Rows[0]["CTime"].ToString();
                                if (values == "" || values == null)
                                {
                                    errormessage1 += "," + "Please Enter the Quality Sheet(A32271C) Operation One Cycle time Values";
                                }
                                else
                                {
                                    double val = Convert.ToDouble(values);
                                    cycl = cycl + Convert.ToInt32(val);
                                }
                            }
                            if (table[i] == "QSheetA44908N")
                            {


                                da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='A44908N' and CProcess='OP1'", strConnString);
                                ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                string values = ds1.Tables[0].Rows[0]["CTime"].ToString();
                                if (values == "" || values == null)
                                {
                                    errormessage1 += "," + "Please Enter the Quality Sheet(A44908N) Operation One Cycle time Values";
                                }
                                else
                                {
                                    double val = Convert.ToDouble(values);
                                    cycl = cycl + Convert.ToInt32(val);
                                }
                            }
                            if (table[i] == "QSheetPolishing24Q")
                            {
                                da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='A17724Q' and CProcess='Polishing'", strConnString);
                                ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                string values = ds1.Tables[0].Rows[0]["CTime"].ToString();
                                if (values == "" || values == null)
                                {
                                    errormessage1 += "," + "Please Enter the Quality Sheet(A17724Q) Polishing Cycle time Values";
                                }
                                else
                                {
                                    double val = Convert.ToDouble(values);
                                    cycl = cycl + Convert.ToInt32(val);
                                }
                            }
                            if (table[i] == "QSheetpolishingA22916J")
                            {
                                da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='A22916J' and CProcess='Polishing'", strConnString);
                                ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                string values = ds1.Tables[0].Rows[0]["CTime"].ToString();
                                if (values == "" || values == null)
                                {
                                    errormessage1 += "," + "Please Enter the Quality Sheet(A22916J) Polishing Cycle time Values";
                                }
                                else
                                {
                                    double val = Convert.ToDouble(values);
                                    cycl = cycl + Convert.ToInt32(val);
                                }
                            }
                            if (table[i] == "QSheetpolishingA32271C")
                            {
                                da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='A32271C' and CProcess='Polishing'", strConnString);
                                ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                string values = ds1.Tables[0].Rows[0]["CTime"].ToString();
                                if (values == "" || values == null)
                                {
                                    errormessage1 += "," + "Please Enter the Quality Sheet(A32271C) Polishing Cycle time Values";
                                }
                                else
                                {
                                    double val = Convert.ToDouble(values);
                                    cycl = cycl + Convert.ToInt32(val);
                                }
                            }
                            if (table[i] == "QSheetPolishingA44908N")
                            {
                                da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='A44908N' and CProcess='Polishing'", strConnString);
                                ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                string values = ds1.Tables[0].Rows[0]["CTime"].ToString();
                                if (values == "" || values == null)
                                {
                                    errormessage1 += "," + "Please Enter the Quality Sheet(A44908N) Polishing Cycle time Values";
                                }
                                else
                                {
                                    double val = Convert.ToDouble(values);
                                    cycl = cycl + Convert.ToInt32(val);
                                }
                            }
                            if (table[i] == "QSheetpolishingA44983U")
                            {
                                da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='A44983U' and CProcess='Polishing'", strConnString);
                                ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                string values = ds1.Tables[0].Rows[0]["CTime"].ToString();
                                if (values == "" || values == null)
                                {
                                    errormessage1 += "," + "Please Enter the Quality Sheet(A44983U) Polishing Cycle time Values";
                                }
                                else
                                {
                                    double val = Convert.ToDouble(values);
                                    cycl = cycl + Convert.ToInt32(val);
                                }
                            }
                            if (table[i] == "opt2QSA17724Q")
                            {
                                da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='A17724Q' and CProcess='OP2'", strConnString);
                                ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                string values = ds1.Tables[0].Rows[0]["CTime"].ToString();
                                if (values == "" || values == null)
                                {
                                    errormessage1 += "," + "Please Enter the Quality Sheet(A17724Q) Operation Two Cycle time Values";
                                }
                                else
                                {
                                    double val = Convert.ToDouble(values);
                                    cycl = cycl + Convert.ToInt32(val);
                                }
                            }
                            if (table[i] == "opt2QualitySheetA22916J")
                            {
                                da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='A22916J' and CProcess='OP2'", strConnString);
                                ds1 = new DataSet();
                                ds1.Tables.Clear();
                                ds1.Clear();
                                ds1.Reset();
                                da1.Fill(ds1);
                                string values = ds1.Tables[0].Rows[0]["CTime"].ToString();
                                if (values == "" || values == null)
                                {
                                    errormessage1 += "," + "Please Enter the Quality Sheet(A22916J) Operation Two Cycle time Values";
                                }
                                else
                                {
                                    double val = Convert.ToDouble(values);
                                    cycl = cycl + Convert.ToInt32(val);
                                }
                            }



                        }
                    }

                    for (int j = 0; j < table1.Length; j++)
                    {

                        da = new SqlDataAdapter(" Select * from lappingQsheet24Q where rejectedQty <> 1  and Shift= '" + shift + "' and MachineName= '" + mchn + "' and unit= '" + unit + "' and CreatedOn ='" + Convert.ToDateTime(date) + "' and  Product_PN='" + table1[j] + "'", strConnString);
                        ds = new DataSet();
                        ds1.Tables.Clear();
                        ds1.Clear();
                        ds1.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Accept1 = Accept1 + Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());
                            da1 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='" + table1[j] + "' and CProcess='Lapping'", strConnString);
                            ds1 = new DataSet();
                            ds1.Tables.Clear();
                            ds1.Clear();
                            ds1.Reset();
                            da1.Fill(ds1);
                            string values1 = ds1.Tables[0].Rows[0]["CTime"].ToString();
                            if (values1 == "" || values1 == null)
                            {
                                errormessage1 += "," + "Please Enter the " + table[j] + " Cycle time Values";
                            }
                            else
                            {
                                double val = Convert.ToDouble(values1);
                                cycl1 = cycl1 + Convert.ToInt32(val);
                            }
                        }

                    }

                    ttlaccept = Accept + Accept1;
                    ttlcyc = cycl + cycl1;
                    ttl = ttlaccept * ttlcyc;
                    objeff1.val = ttl;
                    objeff1.errormessage = errormessage1;
                    objeff.Add(objeff1);
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return objeff.ToArray();


        }
    }
    [WebMethod]
    public static string ttlEff(string Earndtm, string actualtm, string Seconds)
    {
        int ttl = 0;
        int a, b, total;
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {

                    a = Convert.ToInt32(Earndtm);
                    b = Convert.ToInt32(actualtm);
                    if (Seconds != "")
                    {
                        double secondsc = Convert.ToInt32(Seconds.ToString());
                        secondsc = secondsc / 60;
                        int minutes = Convert.ToInt32(actualtm.ToString());
                        double total1 = Convert.ToDouble(minutes) + secondsc;
                        int values = Convert.ToInt32(total1);
                        double first = (a - values);
                        double second = ((a + values) / 2);
                        double third = first / second;
                        total = Convert.ToInt32(third * 100);
                        ttl = total;
                    }
                    else
                    {
                        // double secondsc = Convert.ToInt32(Seconds.ToString());
                        //secondsc = secondsc / 60;
                        int minutes = Convert.ToInt32(actualtm.ToString());
                        double total1 = Convert.ToDouble(minutes);
                        int values = Convert.ToInt32(total1);
                        double first = (a - values);
                        double second = ((a + values) / 2);
                        double third = first / second;
                        total = Convert.ToInt32(third * 100);
                        ttl = total;
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return ttl.ToString();
        }
    }
    [WebMethod]
    public static string GetRejValueNew(string Table, string PID, string Q_ID)
    {
        string maxid, Rowid = "";
        string reject = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {

                    DataSet dsrej = new DataSet();
                    SqlDataAdapter darej;
                    da = new SqlDataAdapter("select max(Qid_ref) as rowid from " + Table + " where PID_No='" + PID + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        darej = new SqlDataAdapter("select * from " + Table + " where Qid_ref='" + Q_ID + "' and  PID_No='" + PID + "'", strConnString);
                        dsrej = new DataSet();
                        darej.Fill(dsrej);
                        maxid = dsrej.Tables[0].Rows[0]["Qid_ref"].ToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            reject = dsrej.Tables[0].Rows[0]["rejectedQty"].ToString();
                        }
                        else
                        {
                            reject = "0";
                        }
                        if (reject == "1")
                        {
                            Rowid = maxid;
                        }
                        else
                        {
                            Rowid = "F";
                        }

                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return Rowid.ToString();
        }
    }
    [WebMethod]
    public static string GetRejValue(string Table, string PID, string Q_ID)
    {
        string maxid, Rowid = "";
        string reject = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select max(QID) as rowid from " + Table + " where PID_No='" + PID + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (Q_ID.ToString() == "0")
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            maxid = ds.Tables[0].Rows[0]["rowid"].ToString();
                            da = new SqlDataAdapter("select * from " + Table + " where QID='" + maxid + "'", strConnString);
                            ds = new DataSet();
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                reject = ds.Tables[0].Rows[0]["rejectedQty"].ToString();
                            }
                            else
                            {
                                reject = "0";
                            }
                            if (reject == "1")
                            {
                                Rowid = maxid;
                            }
                            else
                            {
                                Rowid = "F";
                            }

                        }
                    }
                    else
                    {
                        da = new SqlDataAdapter("select QID as rowQid from " + Table + " where PID_No='" + PID + "' and QID='" + Q_ID + "'", strConnString);
                        ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            maxid = ds.Tables[0].Rows[0]["rowQid"].ToString();
                            da = new SqlDataAdapter("select * from " + Table + " where QID='" + Q_ID + "'", strConnString);
                            ds = new DataSet();
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                reject = ds.Tables[0].Rows[0]["rejectedQty"].ToString();
                            }
                            else
                            {
                                reject = "0";
                            }
                            if (reject == "1")
                            {
                                Rowid = maxid;
                            }
                            else
                            {
                                Rowid = "F";
                            }
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return Rowid.ToString();
        }
    }
    [WebMethod]
    public static string updateRejValue(string Table, string PID, string Comment, string RowId)
    {
        string result = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {

                    try
                    {
                        if ((Table == "QualitySheet" && HttpContext.Current.Session["Process"].ToString() == "Baker") || (Table == "QSheetPolishing24Q" && HttpContext.Current.Session["Process"].ToString() == "Baker"))
                        {
                            if (strConnString.State == ConnectionState.Open)
                            {
                                strConnString.Close();
                            }
                            strConnString.Open();
                            cmd = new SqlCommand("update " + Table + " set Comments='" + Comment + "' where Qid_ref='" + RowId + "' and PID_No='" + PID + "'", strConnString);
                            cmd.Parameters.Add("@PID_No", SqlDbType.VarChar, 50).Value = PID.ToString();
                            cmd.Parameters.Add("@QID", SqlDbType.Int).Value = RowId.ToString();
                            cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 500).Value = Comment.ToString();
                            cmd.ExecuteNonQuery();
                            strConnString.Close();
                        }
                        else
                        {
                            if (strConnString.State == ConnectionState.Open)
                            {
                                strConnString.Close();
                            }
                            strConnString.Open();
                            cmd = new SqlCommand("update " + Table + " set Comments='" + Comment + "' where QID='" + RowId + "' and PID_No='" + PID + "'", strConnString);
                            cmd.Parameters.Add("@PID_No", SqlDbType.VarChar, 50).Value = PID.ToString();
                            cmd.Parameters.Add("@QID", SqlDbType.Int).Value = RowId.ToString();
                            cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 500).Value = Comment.ToString();
                            cmd.ExecuteNonQuery();
                            strConnString.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogging.SendExcepToDB(ex);
                        result = "F";
                    }
                    finally
                    {
                        strConnString.Close();

                        result = "S";
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return result.ToString();
        }
    }
    [WebMethod]
    public static TimeMaster[] GetTimeValues(string ID)
    {
        int id = Convert.ToInt32(ID);
        List<TimeMaster> objtime = new List<TimeMaster>();
        TimeMaster obj_time = new TimeMaster();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from TimeMaster where ID='" + id + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        obj_time.Tpartno = ds.Tables[0].Rows[0]["PartNo"].ToString();
                        obj_time.Toperation = ds.Tables[0].Rows[0]["Operation"].ToString();
                        obj_time.Tbottle = ds.Tables[0].Rows[0]["BottleNecktime"].ToString();
                        obj_time.TTT = ds.Tables[0].Rows[0]["tt"].ToString();

                    }
                    else
                    {
                    }
                    objtime.Add(obj_time);
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objtime.ToArray();
        }
    }
    [WebMethod]
    public static getactualtimevalues[] getactual_timevalues(string ID)
    {
        int id = Convert.ToInt32(ID);
        List<getactualtimevalues> objactual = new List<getactualtimevalues>();
        getactualtimevalues obj_actual = new getactualtimevalues();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from Actual_PrdQty where AID='" + id + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        obj_actual.partno = ds.Tables[0].Rows[0]["PartNo"].ToString();
                        obj_actual.process = ds.Tables[0].Rows[0]["Process"].ToString();
                        obj_actual.shift = ds.Tables[0].Rows[0]["Shift"].ToString();
                        obj_actual.fixedtime = ds.Tables[0].Rows[0]["FixedTime"].ToString();
                        obj_actual.prdqty = ds.Tables[0].Rows[0]["ProducedQty"].ToString();

                    }
                    else
                    {
                    }
                    objactual.Add(obj_actual);
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objactual.ToArray();
        }
    }
    [WebMethod]
    public static CycleTime[] Cycle_Time(string ID)
    {
        int id = Convert.ToInt32(ID);
        List<CycleTime> objcycle = new List<CycleTime>();
        CycleTime obj_cycle = new CycleTime();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from CycleTimeEntry where CID='" + id + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        obj_cycle.Cpartno = ds.Tables[0].Rows[0]["CPartno"].ToString();
                        obj_cycle.Cprocess = ds.Tables[0].Rows[0]["CProcess"].ToString();
                        if (ds.Tables[0].Rows[0]["Cseconds"].ToString() != "" && ds.Tables[0].Rows[0]["Cseconds"].ToString() != null && ds.Tables[0].Rows[0]["Cseconds"].ToString() != "0")
                        {

                            double secondsc = Convert.ToInt32(ds.Tables[0].Rows[0]["Cseconds"].ToString());
                            secondsc = secondsc / 60;
                            double minutes = Convert.ToDouble(ds.Tables[0].Rows[0]["CTime"].ToString());
                            double total = Convert.ToDouble(minutes) - secondsc;
                            int totalvalues = Convert.ToInt32(total);
                            obj_cycle.Ctime = totalvalues.ToString();
                            obj_cycle.Cseconds = ds.Tables[0].Rows[0]["Cseconds"].ToString();
                        }
                        else
                        {
                            obj_cycle.Ctime = ds.Tables[0].Rows[0]["CTime"].ToString();
                            obj_cycle.Cseconds = "0";
                        }




                    }
                    else
                    {
                    }
                    objcycle.Add(obj_cycle);
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return objcycle.ToArray();
        }
    }
    [WebMethod]
    public static getplannedEntry[] Getplannedstop(string ID)
    {
        int id = Convert.ToInt32(ID);
        List<getplannedEntry> objplan = new List<getplannedEntry>();
        getplannedEntry obj_plan = new getplannedEntry();
        lock (thisLock)
        {
            try
            {

                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from PlaneedEntryDetails where PNO='" + id + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        obj_plan.partno = ds.Tables[0].Rows[0]["PartNo"].ToString();
                        obj_plan.Process = ds.Tables[0].Rows[0]["Process"].ToString();
                        obj_plan.pmaintenance = ds.Tables[0].Rows[0]["Maintenace"].ToString();
                        obj_plan.cleaning = ds.Tables[0].Rows[0]["Cleaning"].ToString();
                        obj_plan.break1 = ds.Tables[0].Rows[0]["Break"].ToString();
                        obj_plan.noplan = ds.Tables[0].Rows[0]["Noplan"].ToString();
                        obj_plan.trials = ds.Tables[0].Rows[0]["Trials"].ToString();
                        obj_plan.meeitngs = ds.Tables[0].Rows[0]["Meetings"].ToString();
                        obj_plan.trainings = ds.Tables[0].Rows[0]["Trainings"].ToString();
                        obj_plan.plnmaintenance = ds.Tables[0].Rows[0]["Planedmaintenance"].ToString();

                    }
                    else
                    {
                    }
                    objplan.Add(obj_plan);
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return objplan.ToArray();
        }
    }
    [WebMethod]
    public static Register[] GetRegValues(string ID)
    {
        int id = Convert.ToInt32(ID);
        List<Register> objreg = new List<Register>();
        Register obj_reg = new Register();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from tbl_Registration where Reg_ID='" + id + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        obj_reg.UserName = ds.Tables[0].Rows[0]["Reg_Username"].ToString();
                        obj_reg.Password = ds.Tables[0].Rows[0]["Reg_Userpassword"].ToString();
                        obj_reg.Role = ds.Tables[0].Rows[0]["Reg_Role"].ToString();

                    }
                    else
                    {
                    }
                    objreg.Add(obj_reg);
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return objreg.ToArray();
        }
    }
    [WebMethod]
    public static GetPageLod[] Effpageload()
    {
        List<GetPageLod> objload = new List<GetPageLod>();
        GetPageLod obj_load = new GetPageLod();
        string errormessage1 = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    obj_load.Username = HttpContext.Current.Session["User_Name"].ToString();
                    obj_load.shift = HttpContext.Current.Session["Shift"].ToString();
                    if (obj_load.shift == "A")
                    {
                        obj_load.shiftime = "6 AM to 2 PM";
                    }
                    if (obj_load.shift == "B")
                    {
                        obj_load.shiftime = "2 PM TO 10 PM";
                    }
                    if (obj_load.shift == "C")
                    {
                        obj_load.shiftime = "10 PM TO 6 AM";
                    }
                    if (obj_load.shift == "A1")
                    {
                        obj_load.shiftime = "6 AM TO 6 PM";
                    }
                    if (obj_load.shift == "B1")
                    {
                        obj_load.shiftime = "6 PM TO 2 AM";
                    }

                    obj_load.partno = HttpContext.Current.Session["PartNo"].ToString();
                    obj_load.pidn = HttpContext.Current.Session["PID_ID"].ToString();
                    obj_load.dept = HttpContext.Current.Session["Department"].ToString();
                    obj_load.mchn = HttpContext.Current.Session["machine"].ToString();
                    obj_load.ut = HttpContext.Current.Session["Unit"].ToString();
                    obj_load.logtime = HttpContext.Current.Session["Logtime"].ToString();
                    obj_load.logdate = HttpContext.Current.Session["LogDate"].ToString();
                    //obj_load.page = HttpContext.Current.Session["Page"].ToString();
                    if (HttpContext.Current.Session["Operation"].ToString() == "1" || HttpContext.Current.Session["Operation"].ToString() == "2")
                    {
                        if (HttpContext.Current.Session["Operation"].ToString() == "1")
                        {
                            obj_load.operation = "OP1";
                        }
                        if (HttpContext.Current.Session["Operation"].ToString() == "2")
                        {
                            obj_load.operation = "OP2";
                        }
                    }
                    else
                    {
                        obj_load.operation = HttpContext.Current.Session["Operation"].ToString();
                    }

                    obj_load.Datetime = DateTime.Now.ToShortDateString().ToString();
                    if (HttpContext.Current.Session["MachineName"] != null && HttpContext.Current.Session["MachineName"].ToString() != "")
                    {
                        obj_load.machine = HttpContext.Current.Session["MachineName"].ToString();
                    }
                    else
                    {
                        obj_load.machine = "";
                    }

                    string op = "";
                    op = obj_load.operation;
                    SqlDataAdapter da = new SqlDataAdapter("select * from PlaneedEntryDetails where PartNo='" + obj_load.partno + "' and Process='" + op + "'", strConnString);
                    DataSet ds1 = new DataSet();
                    ds1.Tables.Clear();
                    ds1.Clear();
                    ds1.Reset();
                    da.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0 && ds1.Tables.Count > 0 && ds1.Tables[0].Rows[0][1] != DBNull.Value)
                    {
                        obj_load.pmaintenance = ds1.Tables[0].Rows[0]["Maintenace"].ToString();
                        obj_load.cleaning = ds1.Tables[0].Rows[0]["Cleaning"].ToString();
                        obj_load.break1 = ds1.Tables[0].Rows[0]["Break"].ToString();
                        obj_load.noplan = ds1.Tables[0].Rows[0]["Noplan"].ToString();
                        obj_load.trials = ds1.Tables[0].Rows[0]["Trials"].ToString();
                        obj_load.meeitngs = ds1.Tables[0].Rows[0]["Meetings"].ToString();
                        obj_load.trainings = ds1.Tables[0].Rows[0]["Trainings"].ToString();
                        obj_load.plnmaintenance = ds1.Tables[0].Rows[0]["Planedmaintenance"].ToString();

                    }
                    else
                    {
                        errormessage1 += "," + "Please Enter the Planned Stop Entry Value of " + obj_load.partno + " ( " + op + " - " + obj_load.shift + " ) ";
                    }


                    //string mode2 = "";
                    //string mode3 = "";

                    //if (obj_load.partno == "A17724Q" && op == "OP1")
                    //{
                    //    mode2 = "Q";
                    //    mode3 = "1";
                    //}
                    //if (obj_load.partno == "A17724Q" && op == "OP2")
                    //{
                    //    mode2 = "Q";
                    //    mode3 = "2";
                    //}
                    //if (obj_load.partno == "A17724Q" && op == "Polishing")
                    //{
                    //    mode2 = "Q";
                    //    mode3 = "P";
                    //}
                    //if (obj_load.partno == "A17724Q" && op == "Lapping")
                    //{
                    //    mode2 = "Q";
                    //    mode3 = "L";
                    //}
                    //if (obj_load.partno == "A22916J" && op == "OP1")
                    //{
                    //    mode2 = "J";
                    //    mode3 = "1";
                    //}
                    //if (obj_load.partno == "A22916J" && op == "OP2")
                    //{
                    //    mode2 = "J";
                    //    mode3 = "2";
                    //}
                    //if (obj_load.partno == "A22916J" && op == "Polishing")
                    //{
                    //    mode2 = "J";
                    //    mode3 = "P";
                    //}
                    //if (obj_load.partno == "A22916J" && op == "Lapping")
                    //{
                    //    mode2 = "J";
                    //    mode3 = "L";
                    //}

                    //if (obj_load.partno == "A44983U" && op == "OP1")
                    //{
                    //    mode2 = "U";
                    //    mode3 = "1";
                    //}
                    //if (obj_load.partno == "A44983U" && op == "Polishing")
                    //{
                    //    mode2 = "U";
                    //    mode3 = "P";
                    //}
                    //if (obj_load.partno == "A44983U" && op == "Lapping")
                    //{
                    //    mode2 = "U";
                    //    mode3 = "L";
                    //}

                    //if (obj_load.partno == "A32271C" && op == "OP1")
                    //{
                    //    mode2 = "C";
                    //    mode3 = "1";
                    //}
                    //if (obj_load.partno == "A32271C" && op == "Polishing")
                    //{
                    //    mode2 = "C";
                    //    mode3 = "P";
                    //}
                    //if (obj_load.partno == "A32271C" && op == "Lapping")
                    //{
                    //    mode2 = "C";
                    //    mode3 = "L";
                    //}

                    //if (obj_load.partno == "A44908N" && op == "OP1")
                    //{
                    //    mode2 = "N";
                    //    mode3 = "1";
                    //}
                    //if (obj_load.partno == "A44908N" && op == "Polishing")
                    //{
                    //    mode2 = "N";
                    //    mode3 = "P";
                    //}
                    //if (obj_load.partno == "A44908N" && op == "Lapping")
                    //{
                    //    mode2 = "N";
                    //    mode3 = "L";
                    //}
                    da2 = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='" + obj_load.partno + "' and CProcess='" + obj_load.operation + "'", strConnString);
                    ds2 = new DataSet();
                    ds2.Tables.Clear();
                    ds2.Clear();
                    ds2.Reset();
                    da2.Fill(ds2);
                    string dime1 = DateTime.Now.ToShortDateString().ToString();
                    //cmd = new SqlCommand("Get_AcceptCount", strConnString);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@PartName", SqlDbType.VarChar, 30).Value = obj_load.partno.ToString();
                    //cmd.Parameters.Add("@pidno", SqlDbType.VarChar, 50).Value = obj_load.pidn.ToString();
                    //cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dime1.ToString());
                    //cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 30).Value = obj_load.shift.ToString();
                    //cmd.Parameters.Add("@mode2", SqlDbType.VarChar, 30).Value = mode2.ToString();
                    //cmd.Parameters.Add("@mode3", SqlDbType.VarChar, 30).Value = mode3.ToString();

                    string Partno1 = HttpContext.Current.Session["PartNo"].ToString();
                    string Opertaion1 = HttpContext.Current.Session["Operation"].ToString();
                    string Machine1 = HttpContext.Current.Session["machine"].ToString();
                    string Process1 = HttpContext.Current.Session["Process"].ToString();
                    string Cell1 = HttpContext.Current.Session["Depart"].ToString();
                    string Unit1 = HttpContext.Current.Session["Unit"].ToString();
                    string Shift1 = HttpContext.Current.Session["Shift"].ToString();
                    string tableName = "QualitySheet_" + Cell1.ToString() + "_" + Partno1.ToString() + "_" + Opertaion1.ToString() + "";
                    string yesterday = "";
                    string Current = DateTime.Now.ToShortTimeString().ToString();
                    DateTime Tfrom = Convert.ToDateTime("22:00:00");
                    DateTime Tto = Convert.ToDateTime("06:00:00");
                    if (Shift1 == "C")
                    {
                        if (Convert.ToDateTime(Current) > Convert.ToDateTime(Tfrom) || Convert.ToDateTime(Current) < Convert.ToDateTime(Tto))
                        {
                            if (Convert.ToDateTime(Current) >= Convert.ToDateTime("22:00:00") && Convert.ToDateTime(Current) <= Convert.ToDateTime("23:59:59"))
                            {
                                yesterday = DateTime.Now.ToShortDateString().ToString();
                            }
                            else
                            {
                                yesterday = DateTime.Now.AddDays(-1).ToShortDateString().ToString();
                            }
                        }
                    }
                    SqlDataAdapter daa;
                    if (obj_load.shift == "C")
                    {
                        daa = new SqlDataAdapter("select count(*) as Produced from " + "QualitySheet_" + Cell1.ToString() + "_" + Partno1.ToString() + "_" + Opertaion1.ToString() + " where Prdn_Name='" + Partno1.ToString() + "' and QShift='" + Shift1.ToString() + "' and (CONVERT(VARCHAR, QDate, 103))='" + Convert.ToDateTime(yesterday).ToShortDateString().ToString() + "' and MachineName='" + Machine1.ToString() + "' and rejectedQty=0", strConnString);
                    }
                    else
                    {
                        daa = new SqlDataAdapter("select count(*) as Produced from " + "QualitySheet_" + Cell1.ToString() + "_" + Partno1.ToString() + "_" + Opertaion1.ToString() + " where Prdn_Name='" + Partno1.ToString() + "' and QShift='" + Shift1.ToString() + "' and (CONVERT(VARCHAR, QDate, 103))='" + DateTime.Now.ToShortDateString().ToString() + "' and MachineName='" + Machine1.ToString() + "' and rejectedQty=0", strConnString);
                    }
                    
                    DataSet dss = new DataSet();
                    dss.Tables.Clear();
                    dss.Clear();
                    dss.Reset();
                    daa.Fill(dss);
                    if (dss.Tables[0].Rows.Count > 0 && dss.Tables.Count > 0 && dss.Tables[0].Rows[0][0] != DBNull.Value)
                    {
                        obj_load.accept = dss.Tables[0].Rows[0]["Produced"].ToString();
                        int accpt = Convert.ToInt32(obj_load.accept);
                        obj_load.ctime = ds2.Tables[0].Rows[0]["CTime"].ToString();
                        double t = Convert.ToDouble(obj_load.ctime);
                        int ctime = Convert.ToInt32(t);
                        int count = 0;
                        count = (accpt) * (ctime);
                        obj_load.Utiletime = count.ToString();

                    }
                    else
                    {
                        obj_load.accept = "0";
                        obj_load.Utiletime = "0";
                    }


                    //if ((obj_load.TT != "" || obj_load.TT != null) && (obj_load.accept != "" || obj_load.accept != ""))
                    //{
                    //    double h1, f1, g1;
                    //    h1 = Convert.ToDouble(obj_load.accept);
                    //    f1 = Convert.ToDouble(obj_load.TT);
                    //    g1 = h1 * f1 / 60;
                    //    obj_load.Utiletime = Convert.ToString(g1);
                    //    obj_load.Utiletime = Math.Round(double.Parse(obj_load.Utiletime), 0).ToString();


                    //}
                    //else
                    //{
                    //    obj_load.Utiletime = "0";
                    //}



                    //string mode = "";
                    //string mode1 = "";
                    try
                    {
                        //if (obj_load.partno == "A17724Q" && op == "OP1")
                        //{
                        //    mode = "Q";
                        //    mode1 = "1";
                        //}
                        //if (obj_load.partno == "A17724Q" && op == "OP2")
                        //{
                        //    mode = "Q";
                        //    mode1 = "2";
                        //}
                        //if (obj_load.partno == "A17724Q" && op == "Polishing")
                        //{
                        //    mode = "Q";
                        //    mode1 = "P";
                        //}
                        //if (obj_load.partno == "A17724Q" && op == "Lapping")
                        //{
                        //    mode = "Q";
                        //    mode1 = "L";
                        //}
                        //if (obj_load.partno == "A22916J" && op == "OP1")
                        //{
                        //    mode = "J";
                        //    mode1 = "1";
                        //}
                        //if (obj_load.partno == "A22916J" && op == "OP2")
                        //{
                        //    mode = "J";
                        //    mode1 = "2";
                        //}
                        //if (obj_load.partno == "A22916J" && op == "Polishing")
                        //{
                        //    mode = "J";
                        //    mode1 = "P";
                        //}
                        //if (obj_load.partno == "A22916J" && op == "Lapping")
                        //{
                        //    mode = "J";
                        //    mode1 = "L";
                        //}

                        //if (obj_load.partno == "A44983U" && op == "OP1")
                        //{
                        //    mode = "U";
                        //    mode1 = "1";
                        //}
                        //if (obj_load.partno == "A44983U" && op == "Polishing")
                        //{
                        //    mode = "U";
                        //    mode1 = "P";
                        //}
                        //if (obj_load.partno == "A44983U" && op == "Lapping")
                        //{
                        //    mode = "U";
                        //    mode1 = "L";
                        //}

                        //if (obj_load.partno == "A32271C" && op == "OP1")
                        //{
                        //    mode = "C";
                        //    mode1 = "1";
                        //}
                        //if (obj_load.partno == "A32271C" && op == "Polishing")
                        //{
                        //    mode = "C";
                        //    mode1 = "P";
                        //}
                        //if (obj_load.partno == "A32271C" && op == "Lapping")
                        //{
                        //    mode = "C";
                        //    mode1 = "L";
                        //}

                        //if (obj_load.partno == "A44908N" && op == "OP1")
                        //{
                        //    mode = "N";
                        //    mode1 = "1";
                        //}
                        //if (obj_load.partno == "A44908N" && op == "Polishing")
                        //{
                        //    mode = "N";
                        //    mode1 = "P";
                        //}
                        //if (obj_load.partno == "A44908N" && op == "Lapping")
                        //{
                        //    mode = "N";
                        //    mode1 = "L";
                        //}
                        string dime = DateTime.Now.ToShortDateString().ToString();
                        if (strConnString.State == ConnectionState.Open)
                        {
                            strConnString.Close();
                        }
                        strConnString.Open();
                        //cmd = new SqlCommand("Get_RejectionCount", strConnString);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@PartName", SqlDbType.VarChar, 30).Value = obj_load.partno.ToString();
                        //cmd.Parameters.Add("@pidno", SqlDbType.VarChar, 50).Value = obj_load.pidn.ToString();
                        //cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dime.ToString());
                        //cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 30).Value = obj_load.shift.ToString();
                        //cmd.Parameters.Add("@mode", SqlDbType.VarChar, 30).Value = mode.ToString();
                        //cmd.Parameters.Add("@mode1", SqlDbType.VarChar, 30).Value = mode1.ToString();
                        strConnString.Close();
                        if (Shift1.ToString() == "C")
                        {
                            da = new SqlDataAdapter("select count(*) as Reject from " + "QualitySheet_" + Cell1.ToString() + "_" + Partno1.ToString() + "_" + Opertaion1.ToString() + " where Prdn_Name='" + Partno1.ToString() + "' and QShift='" + Shift1.ToString() + "' and (CONVERT(VARCHAR, QDate, 103))='" + Convert.ToDateTime(yesterday).ToString() + "' and MachineName='" + Machine1.ToString() + "' and rejectedQty=1", strConnString);
                        }
                        else
                        {
                            da = new SqlDataAdapter("select count(*) as Reject from " + "QualitySheet_" + Cell1.ToString() + "_" + Partno1.ToString() + "_" + Opertaion1.ToString() + " where Prdn_Name='" + Partno1.ToString() + "' and QShift='" + Shift1.ToString() + "' and (CONVERT(VARCHAR, QDate, 103))='" + DateTime.Now.ToShortDateString().ToString() + "' and MachineName='" + Machine1.ToString() + "' and rejectedQty=1", strConnString);
                        }
                        ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0 && ds.Tables[0].Rows[0][0] != DBNull.Value)
                        {
                            obj_load.Rejection = ds.Tables[0].Rows[0]["Reject"].ToString();

                        }
                        else
                        {
                            obj_load.Rejection = "0";
                        }



                    }
                    catch (Exception Ex)
                    {
                        obj_load.Rejection = "0";

                    }
                    finally
                    {

                        strConnString.Close();
                    }
                    obj_load.errormessage = errormessage1;
                    objload.Add(obj_load);
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return objload.ToArray();
        }
    }
    [WebMethod]
    public static string GetQtyRej(string TableName, string Pidno, string Admpidno)
    {
        string sessionvalue = "";
        string rej = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    if (HttpContext.Current.Session["User_Role"] != null && HttpContext.Current.Session["User_Role"].ToString() != "")
                    {
                        if (TableName != "" && TableName != "undefined" && Pidno != "" && Pidno != "undefined" && Admpidno != "" && Admpidno != "undefined")
                        {
                            sessionvalue = HttpContext.Current.Session["User_Role"].ToString();

                            try
                            {

                                if (sessionvalue == "User")
                                {
                                    string partno = HttpContext.Current.Session["PartNo"].ToString();
                                    string operation = HttpContext.Current.Session["Operation"].ToString();
                                    string shift = HttpContext.Current.Session["Shift"].ToString();
                                    if (operation == "Lapping")
                                    {
                                        SqlDataAdapter da = new SqlDataAdapter("select SUM (CONVERT(int,rejectedQty)) as rejectedQty  from " + TableName + " where PID_No='" + Pidno + "'and rejectedQty='1' and Product_PN='" + partno + "' and Shift='" + shift + "' ", strConnString);
                                        DataSet ds = new DataSet();
                                        ds.Tables.Clear();
                                        ds.Clear();
                                        ds.Reset();
                                        da.Fill(ds);
                                        rej = ds.Tables[0].Rows[0]["rejectedQty"].ToString();
                                    }
                                    else
                                    {
                                        SqlDataAdapter da = new SqlDataAdapter("select SUM (CONVERT(int,rejectedQty)) as rejectedQty  from " + TableName + " where PID_No='" + Pidno + "'and rejectedQty='1' and Shift='" + shift + "' ", strConnString);
                                        DataSet ds = new DataSet();
                                        ds.Tables.Clear();
                                        ds.Clear();
                                        ds.Reset();
                                        da.Fill(ds);
                                        rej = ds.Tables[0].Rows[0]["rejectedQty"].ToString();
                                    }
                                }
                                else
                                {
                                    SqlDataAdapter da = new SqlDataAdapter("select SUM (CONVERT(int,rejectedQty)) as rejectedQty  from " + TableName + " where PID_No='" + Admpidno + "'and rejectedQty='1' ", strConnString);
                                    DataSet ds = new DataSet();
                                    ds.Tables.Clear();
                                    ds.Clear();
                                    ds.Reset();
                                    da.Fill(ds);
                                    rej = ds.Tables[0].Rows[0]["rejectedQty"].ToString();
                                }
                                if (rej == "")
                                {
                                    rej = "0";
                                }

                            }
                            catch (Exception ex)
                            {
                                ExceptionLogging.SendExcepToDB(ex);
                            }
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return rej.ToString();
        }
    }
    [WebMethod]
    public static string Get_Autoprtno(string PID)
    {
        PartNo = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select distinct PartNo from tbl_PartNoNew where PIDNO='" + PID + "' ", strConnString);
                    DataSet ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            PartNo = ds.Tables[0].Rows[i]["PartNo"].ToString();
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return PartNo.ToString();
        }
    }
    [WebMethod]
    public static string Get_prtno()
    {
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        PartNo = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select distinct PartNo as PartNo from tbl_PartNo ", strConnString);

                    //DataSet ds = new DataSet();
                    da.Fill(ds, "tbl_PartNo");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            PartNo += "," + ds.Tables[0].Rows[i]["PartNo"].ToString();
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return PartNo.ToString();
        }
    }
    [WebMethod]
    public static string Get_fixname(string ID)
    {
        string fixname = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    if (ID == "ALL")
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select distinct Fixturename from FixtureName", strConnString);
                        DataSet ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                fixname += "," + ds.Tables[0].Rows[i]["Fixturename"].ToString();
                            }
                        }

                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select distinct Fixturename from FixtureName where Partnumber like '%" + ID + "%'", strConnString);
                        DataSet ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                fixname += "," + ds.Tables[0].Rows[i]["Fixturename"].ToString();
                            }
                        }

                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return fixname.ToString();
        }
    }
    [WebMethod]
    public static string Get_machine()
    {
        string macname = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select distinct Valve from Unit_table", strConnString);
                    DataSet ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds, "Unit_table");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            macname += "," + ds.Tables[0].Rows[i]["Valve"].ToString();
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return macname.ToString();
        }
    }
    [WebMethod]
    public static string Get_machine_fix()
    {
        string macname = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select distinct LText from LineMastermbu", strConnString);
                    DataSet ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            macname += "," + ds.Tables[0].Rows[i]["LText"].ToString();
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return macname.ToString();
        }
    }
    [WebMethod]
    public static string Deleteregister(string ID)
    {
        string result = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    objcontext = new QualitySheetdclassDataContext();
                    try
                    {
                        int id = Convert.ToInt32(ID);
                        var query = (from table in objcontext.tbl_Registrations where table.Reg_ID == id select table).FirstOrDefault();
                        if (query != null)
                        {
                            query.Status = "DeActive";
                        }
                    }
                    catch (Exception ex)
                    {
                        result = "F";
                    }
                    finally
                    {
                        objcontext.SubmitChanges();
                        result = "S";
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            finally
            {
            }
            return result.ToString();
        }
    }
    [WebMethod]
    public static string Deletetimeregister(string ID)
    {
        string result = "";

        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            objcontext = new QualitySheetdclassDataContext();
            lock (thisLock)
            {
                try
                {
                    int id = Convert.ToInt32(ID);
                    var query = (from table in objcontext.TimeMasters where table.ID == id select table).FirstOrDefault();
                    objcontext.TimeMasters.DeleteOnSubmit(query);
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    result = "F";
                }
                finally
                {
                    objcontext.SubmitChanges();
                    result = "S";
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return result.ToString();
    }
    [WebMethod]
    public static string Deleteactualregister(string ID)
    {
        string result = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            objcontext = new QualitySheetdclassDataContext();
            lock (thisLock)
            {
                try
                {
                    int id = Convert.ToInt32(ID);
                    var query = (from table in objcontext.Actual_PrdQties where table.AID == id select table).FirstOrDefault();
                    objcontext.Actual_PrdQties.DeleteOnSubmit(query);
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    result = "F";
                }
                finally
                {
                    objcontext.SubmitChanges();
                    result = "S";
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return result.ToString();
    }
    [WebMethod]
    public static string Deletecycleregister(string ID)
    {
        string result = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            objcontext = new QualitySheetdclassDataContext();
            lock (thisLock)
            {
                try
                {
                    int id = Convert.ToInt32(ID);
                    var query = (from table in objcontext.CycleTimeEntries where table.CID == id select table).FirstOrDefault();
                    objcontext.CycleTimeEntries.DeleteOnSubmit(query);
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    result = "F";
                }
                finally
                {
                    objcontext.SubmitChanges();
                    result = "S";
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return result.ToString();
    }
    [WebMethod]
    public static string Deleteplaned(string ID)
    {
        string result = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            objcontext = new QualitySheetdclassDataContext();
            lock (thisLock)
            {
                try
                {
                    int id = Convert.ToInt32(ID);
                    var query = (from table in objcontext.PlaneedEntryDetails where table.PNO == id select table).FirstOrDefault();
                    objcontext.PlaneedEntryDetails.DeleteOnSubmit(query);
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    result = "F";
                }
                finally
                {
                    objcontext.SubmitChanges();
                    result = "S";
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return result.ToString();

    }
    [WebMethod]
    public static string Deletelaboreff(string ID)
    {
        string result = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            objcontext = new QualitySheetdclassDataContext();
            lock (thisLock)
            {
                try
                {
                    int id = Convert.ToInt32(ID);
                    var query = (from table in objcontext.laborefficiencies where table.LID == id select table).FirstOrDefault();
                    objcontext.laborefficiencies.DeleteOnSubmit(query);
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    result = "F";
                }
                finally
                {
                    objcontext.SubmitChanges();
                    result = "S";
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return result.ToString();
    }
    [WebMethod]
    public static string Get_prtprocess()
    {
        string process = "";
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select Process  from tbl_Process", strConnString);

                    da.Fill(ds, "tbl_Process");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            process += "," + ds.Tables[0].Rows[i]["Process"].ToString();
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return process.ToString();
        }
    }
    [WebMethod]
    public static string logout()
    {
        string result = "";
        lock (thisLock)
        {
            try
            {

                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    HttpContext.Current.Session.Abandon();
                    HttpContext.Current.Session.Clear();
                    System.Web.Security.FormsAuthentication.SignOut();
                    HttpContext.Current.Session["User_ID"] = "";
                    HttpContext.Current.Session["User_Name"] = "";
                    HttpContext.Current.Session["Logtime"] = "";
                    HttpContext.Current.Session["LogDate"] = "";
                    HttpContext.Current.Session["PIDNO"] = "";
                    HttpContext.Current.Session["Shift"] = "";

                    string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);

                    foreach (string filePath in Directory.GetFiles(tempPath, "*.*", SearchOption.AllDirectories))
                    {
                        try
                        {
                            FileInfo currentFile = new FileInfo(filePath);
                            currentFile.Delete();
                        }
                        catch (Exception ex)
                        {
                            //Debug.WriteLine("Error on file: {0}\r\n   {1}", filePath, ex.Message);
                            //ExceptionLogging.SendExcepToDB(ex);
                        }
                    }

                    result = "S";
                }
                else
                {
                    //HttpContext.Current.Response.Redirect(FormsAuthentication.DefaultUrl, false);
                    //HttpContext.Current.Response.Redirect("../Home.aspx", false);
                    HttpContext.Current.Response.Redirect("../Home.aspx?mode=logout", false);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                strConnString.Close();
            }
        }


        return result.ToString();
    }
    [WebMethod]
    public static string Getcycletime(string Partno, string Process)
    {
        lock (thisLock)
        {
            string result = "";
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='" + Partno + "' and CProcess='" + Process + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "S";
                    }
                    else
                    {
                        result = "F";
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return result.ToString();
        }
    }
    [WebMethod]
    public static string checkusername(string username)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from tbl_Registration where Reg_Username='" + username + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        res = "S";
                    }
                    else
                    {
                        res = "F";
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string checkpassword(string username, string password)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from tbl_Registration where Reg_Username='" + username + "' and Reg_Userpassword='" + password + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        res = "S";
                    }
                    else
                    {
                        res = "F";
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string checkuser_shift(string Username, string Password)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                //if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                //{
                da = new SqlDataAdapter("select * from tbl_Registration where Reg_Username='" + Username + "' and Reg_Userpassword='" + Password + "'", strConnString);
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    res = ds.Tables[0].Rows[0]["Reg_Role"].ToString();
                }
                else
                {
                    res = "F";
                }
                //}
                //else
                //{
                //    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                //}
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string Ignorefixture(string Username, string Password, string Color)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            string FixNo = HttpContext.Current.Session["FixNo"].ToString();
            string MAchine = HttpContext.Current.Session["machine"].ToString();
            string Partno = HttpContext.Current.Session["PartNo"].ToString();
            string Operation = HttpContext.Current.Session["Operation"].ToString();

            da = new SqlDataAdapter("select * from tbl_Registration where Reg_Username='" + Username + "' and Reg_Userpassword='" + Password + "'", strConnString);
            ds.Tables.Clear();
            ds.Clear();
            ds.Reset();
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                res = ds.Tables[0].Rows[0]["Reg_Role"].ToString();
                lock (thisLock)
                {
                    try
                    {
                        cmd = new SqlCommand("updatefxstatus", strConnString);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@partno", SqlDbType.VarChar, 30).Value = Partno;
                        cmd.Parameters.Add("@fxno", SqlDbType.VarChar, 30).Value = FixNo;
                        cmd.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = Operation;
                        cmd.Parameters.Add("@closedate", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                        cmd.Parameters.Add("@status", SqlDbType.VarChar, 500).Value = "Ignore";
                        cmd.Parameters.Add("@mode", SqlDbType.VarChar, 10).Value = Color.ToString();
                        cmd.Parameters.Add("@month", SqlDbType.VarChar, 10).Value = DateTime.Now.Month.ToString();
                        cmd.Parameters.Add("@year", SqlDbType.VarChar, 10).Value = DateTime.Now.Year.ToString();
                        cmd.Parameters.Add("@machine", SqlDbType.VarChar, 10).Value = MAchine.ToString();
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogging.SendExcepToDB(ex);
                        res = "F";
                    }
                    finally
                    {
                        if (strConnString.State == ConnectionState.Open)
                        {
                            strConnString.Close();
                        }
                        strConnString.Open();
                        cmd.ExecuteNonQuery();
                        strConnString.Close();
                        res = "S";
                    }

                }
            }
            else
            {
                res = "F";
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }
    [WebMethod]
    public static string gettime()
    {
        string time = "";
        lock (thisLock)
        {
            try
            {
                time = System.DateTime.Now.ToShortTimeString();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return time.ToString();
        }
    }
    [WebMethod]
    public static string get_time(string fromtime, string totime)
    {
        string total = "";
        lock (thisLock)
        {
            try
            {
                System.DateTime date1 = Convert.ToDateTime(fromtime);
                System.DateTime date2 = Convert.ToDateTime(totime);
                System.TimeSpan diff1 = date2.Subtract(date1);
                string total1 = diff1.TotalHours.ToString();
                string total2 = diff1.TotalMinutes.ToString();
                string tot3 = diff1.TotalSeconds.ToString();
                total = diff1.ToString();// +":" + total2.ToString() + ":" + tot3.ToString();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return total.ToString();
        }
    }
    [WebMethod]
    public static string getRejection(string prt, string date, string shift, string Process)
    {
        string rejection = "";
        string mode1 = "";
        string mode = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    if (prt == "A17724Q" && Process == "OP1")
                    {
                        mode = "Q";
                        mode1 = "1";
                    }
                    if (prt == "A17724Q" && Process == "OP2")
                    {
                        mode = "Q";
                        mode1 = "2";
                    }
                    if (prt == "A17724Q" && Process == "Polishing")
                    {
                        mode = "Q";
                        mode1 = "P";
                    }
                    if (prt == "A17724Q" && Process == "Lapping")
                    {
                        mode = "Q";
                        mode1 = "L";
                    }
                    if (prt == "A22916J" && Process == "OP1")
                    {
                        mode = "J";
                        mode1 = "1";
                    }
                    if (prt == "A22916J" && Process == "OP2")
                    {
                        mode = "J";
                        mode1 = "2";
                    }
                    if (prt == "A22916J" && Process == "Polishing")
                    {
                        mode = "J";
                        mode1 = "P";
                    }
                    if (prt == "A22916J" && Process == "Lapping")
                    {
                        mode = "J";
                        mode1 = "L";
                    }

                    if (prt == "A44983U" && Process == "OP1")
                    {
                        mode = "U";
                        mode1 = "1";
                    }
                    if (prt == "A44983U" && Process == "Polishing")
                    {
                        mode = "U";
                        mode1 = "P";
                    }
                    if (prt == "A44983U" && Process == "Lapping")
                    {
                        mode = "U";
                        mode1 = "L";
                    }

                    if (prt == "A32271C" && Process == "OP1")
                    {
                        mode = "C";
                        mode1 = "1";
                    }
                    if (prt == "A32271C" && Process == "Polishing")
                    {
                        mode = "C";
                        mode1 = "P";
                    }
                    if (prt == "A32271C" && Process == "Lapping")
                    {
                        mode = "C";
                        mode1 = "L";
                    }

                    if (prt == "A44908N" && Process == "OP1")
                    {
                        mode = "N";
                        mode1 = "1";
                    }
                    if (prt == "A44908N" && Process == "Polishing")
                    {
                        mode = "N";
                        mode1 = "P";
                    }
                    if (prt == "A44908N" && Process == "Lapping")
                    {
                        mode = "N";
                        mode1 = "L";
                    }
                    if (strConnString.State == ConnectionState.Open)
                    {
                        strConnString.Close();
                    }
                    strConnString.Open();
                    cmd = new SqlCommand("Get_RejectionCount", strConnString);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PartName", SqlDbType.VarChar, 30).Value = prt.ToString();
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = Convert.ToDateTime(date.ToString());
                    cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 30).Value = shift.ToString();
                    cmd.Parameters.Add("@mode", SqlDbType.VarChar, 30).Value = mode.ToString();
                    cmd.Parameters.Add("@mode1", SqlDbType.VarChar, 30).Value = mode1.ToString();
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rejection = ds.Tables[0].Rows.Count.ToString();
                    }
                    else
                    {
                        rejection = "0";
                    }

                }
                catch (Exception Ex)
                {
                    ExceptionLogging.SendExcepToDB(Ex);

                    rejection = "0";
                }
                finally
                {

                    strConnString.Close();
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return rejection.ToString();
    }
    //[WebMethod]
    //public static string UserAuthentication(string PID, string Partno, string Operation, string machine)
    //{

    //    string resulst = "S";
    //    HttpContext.Current.Session["PID_ID"] = PID.ToString();
    //    HttpContext.Current.Session["PartNo"] = Partno.ToString();
    //    HttpContext.Current.Session["Operation"] = Operation.ToString();
    //    HttpContext.Current.Session["machine"] = machine.ToString();
    //    //HttpContext.Current.Session["Unit"] = unit.ToString();
    //    return resulst.ToString();
    //}
    [WebMethod]
    public static string UserAuthentication(string PID, string Partno, string Operation, string machine, string Process, string Dept, string Unit)
    {
        //string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);

        //foreach (string filePath in Directory.GetFiles(tempPath, "*.*", SearchOption.AllDirectories))
        //{
        //    try
        //    {
        //        FileInfo currentFile = new FileInfo(filePath);
        //        currentFile.Delete();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Debug.WriteLine("Error on file: {0}\r\n   {1}", filePath, ex.Message);
        //    }
        //}
        string resulst = "S";
        lock (thisLock)
        {
            try
            {

                if (Operation == "OP1")
                {
                    Operation = "1";
                }
                else if (Operation == "OP2")
                {
                    Operation = "2";
                }
                HttpContext.Current.Session["PID_ID"] = PID.ToString();
                HttpContext.Current.Session["PartNo"] = Partno.ToString();
                HttpContext.Current.Session["Operation"] = Operation.ToString();
                HttpContext.Current.Session["machine"] = machine.ToString();
                HttpContext.Current.Session["Process"] = Process.ToString();
                HttpContext.Current.Session["Depart"] = Dept.ToString();
                HttpContext.Current.Session["Unit"] = Unit.ToString();

                //HttpContext.Current.Session["Fixture"] = Fixture.ToString();
                //HttpContext.Current.Session["Unit"] = unit.ToString();

                //if (HttpContext.Current.Session["PID_ID"].ToString() != "" || HttpContext.Current.Session["PartNo"].ToString() != "")
                //{

                //    try
                //    {
                //        String[] excelFiles = System.IO.Directory.GetFiles("F:\\sangeetha\\Project\\PHWIS\\Files\\" + Partno.ToString() + "\\" + PID.ToString() + "\\", "*.xls");
                //        string path = excelFiles[0];
                //        DataTable datatble = new DataTable();
                //        DataSet dsExcel = new DataSet();
                //        string SourceConstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties= 'Excel 8.0;HDR=Yes;IMEX=1'";
                //        OleDbConnection con = new OleDbConnection(SourceConstr);
                //        //con.Open();
                //        string query = "Select F13,F14,F15,F16,F17,F18 from [Sheet1$]";
                //        OleDbDataAdapter data = new OleDbDataAdapter(query, con);
                //        data.Fill(datatble);

                //        datatble = datatble.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();
                //        dsExcel.Tables.Add(datatble);
                //        decimal max1 = 0;
                //        decimal min1 = 0;
                //        decimal max2 = 0;
                //        decimal min2 = 0;
                //        decimal max3 = 0;
                //        decimal min3 = 0;
                //        DataTable dt = new DataTable();
                //        dt.Clear();
                //        dt.Columns.Add("QMG1Max");
                //        dt.Columns.Add("QMG1Min");
                //        dt.Columns.Add("QMG2Max");
                //        dt.Columns.Add("QMG2Min");
                //        dt.Columns.Add("QMG3Max");
                //        dt.Columns.Add("QMG3Min");


                //        for (int i = 1; i < dsExcel.Tables[0].Rows.Count; i++)
                //        {
                //            max1 = Convert.ToDecimal(dsExcel.Tables[0].Rows[i][0].ToString());
                //            min1 = Convert.ToDecimal(dsExcel.Tables[0].Rows[i][1].ToString());
                //            max2 = Convert.ToDecimal(dsExcel.Tables[0].Rows[i][2].ToString());
                //            min2 = Convert.ToDecimal(dsExcel.Tables[0].Rows[i][3].ToString());
                //            max3 = Convert.ToDecimal(dsExcel.Tables[0].Rows[i][4].ToString());
                //            min3 = Convert.ToDecimal(dsExcel.Tables[0].Rows[i][5].ToString());



                //            DataRow dtrow = dt.NewRow();
                //                dtrow["QMG1Max"] = max1.ToString(); 
                //                dtrow["QMG1Min"] = min1.ToString();
                //                dtrow["QMG2Max"] = max2.ToString();
                //                dtrow["QMG2Min"] = min2.ToString();
                //                dtrow["QMG3Max"] = max3.ToString();
                //                dtrow["QMG3Min"] = min3.ToString();
                //                dt.Rows.Add(dtrow);




                //                //dsExcel.Locale = System.Globalization.CultureInfo.InvariantCulture;
                //                //SqlCommand cmd = new SqlCommand("insert into QualitySheet(QMG1Max,QMG1Min,QMG2Max,QMG2Min,QMG3Max,QMG3Min )values ('" + max1 + "','" + min1 + "','" + max2 + "','" + min2 + "','" + max3 + "','" + min3 + "')", strConnString);
                //                //SqlDataAdapter daa = new SqlDataAdapter(cmd);
                //                //strConnString.Open();
                //                //cmd.ExecuteNonQuery();
                //                //strConnString.Close();


                //        }

                //    }
                //    catch(Exception e)
                //    {
                //    }

                //}
                //else
                //{
                //}
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return resulst.ToString();
        }
    }
    [WebMethod]
    public static string CheckDyn(string Partno, string Operation, string Unit, string Cell)
    {
        string res = "";
        da = null;
        ds.Tables.Clear();
        da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno.ToString() + "' and Operation='" + Operation.ToString() + "' and Unit='" + Unit.ToString() + "' and Cell='" + Cell.ToString() + "'", strConnString);
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        da.Fill(ds);
        lock (thisLock)
        {
            try
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    res = "S";
                }
                else
                {
                    res = "F";
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string getpartnumber()
    {
        string depart = "";
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    ds = objserver.GetDateset(" select distinct PartNo from tbl_PartNo");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        depart += "," + ds.Tables[0].Rows[i]["PartNo"].ToString();
                    }

                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return depart.ToString();
        }
    }
    [WebMethod]
    public static string getdepartment(string unit)
    {
        string depart = "";
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();

        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    HttpContext.Current.Session["Unit"] = unit.ToString();

                    if (HttpContext.Current.Session["Unit"].ToString() == "MBU")
                    {
                        ds = objserver.GetDateset("select Cell from Cell");
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            depart += "," + ds.Tables[0].Rows[i]["Cell"].ToString();
                        }

                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);

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
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return depart.ToString();
    }
    [WebMethod]
    public static string getfrequency()
    {
        string frequency = "";
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    ds = objserver.GetDateset(" select * from Frequency");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        frequency += "," + ds.Tables[0].Rows[i]["frequency"].ToString();
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }

            return frequency.ToString();
        }
    }
    [WebMethod]
    public static string getmachinename(string dept)
    {
        string machine = "";
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    HttpContext.Current.Session["Department"] = dept.ToString();

                    ds = objserver.GetDateset(" select * from Machine where Cell='" + dept.ToString() + "'");

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        machine += "," + ds.Tables[0].Rows[i]["Machine"].ToString();
                    }

                    //if (HttpContext.Current.Session["Department"].ToString() == "Valve")
                    //{
                    //    ds = objserver.GetDateset(" select * from Unit_table");
                    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //    {
                    //        machine += "," + ds.Tables[0].Rows[i]["Valve"].ToString();
                    //    }

                    //}
                    //else if (HttpContext.Current.Session["Department"].ToString() == "Block")
                    //{
                    //    ds = objserver.GetDateset(" select * from Unit_table");
                    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //    {
                    //        machine += "," + ds.Tables[0].Rows[i]["Block"].ToString();
                    //    }

                    //}
                    //else if (HttpContext.Current.Session["Department"].ToString() == "Shaft")
                    //{
                    //    ds = objserver.GetDateset(" select * from Unit_table");
                    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //    {
                    //        machine += "," + ds.Tables[0].Rows[i]["Shaft"].ToString();
                    //    }

                    //}
                    //else if (HttpContext.Current.Session["Department"].ToString() == "Cover")
                    //{
                    //    ds = objserver.GetDateset(" select * from Unit_table");
                    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //    {
                    //        machine += "," + ds.Tables[0].Rows[i]["Cover"].ToString();
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
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
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return machine.ToString();
    }
    [WebMethod]
    public static string getSPCValues()
    {
        string SPCValues = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    ds = objserver.GetDateset("select distinct SampleSize from SPCValues");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        SPCValues += "," + ds.Tables[0].Rows[i]["SampleSize"].ToString();
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return SPCValues.ToString();
        }
    }
    [WebMethod]
    public static string getProdOper(string Partno, string Operation, string Cell, string Machine, string Shift, string Date)
    {
        string Prodoperator = "";
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();

        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    if (Partno.ToString() != null && Partno.ToString() != "" && Operation.ToString() != null && Operation.ToString() != "" && Cell.ToString() != null && Cell.ToString() != "" && Machine.ToString() != null && Machine.ToString() != "" && Shift.ToString() != null && Shift.ToString() != "" && Date.ToString() != null && Date.ToString() != "")
                    {
                        string fromdate = Convert.ToDateTime(Date).Year.ToString() + "/" + Convert.ToDateTime(Date).Month.ToString("00") + "/" + Convert.ToDateTime(Date).Day.ToString("00");
                        string tableName = "QualitySheet_" + Cell + "_" + Partno + "_" + Operation + "";
                        ds = objserver.GetDateset("select distinct Operator from " + tableName + " where Qdate='" + fromdate.ToString() + "' and Qshift ='" + Shift.ToString() + "' and MachineName='" + Machine.ToString() + "' ");
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Prodoperator += "," + ds.Tables[0].Rows[i]["Operator"].ToString();
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
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return Prodoperator.ToString();
    }
    [WebMethod]
    public static string getfixtureno(string Partno)
    {
        string fixture = "";
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        lock (thisLock)
        {
            try
            {

                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    ds = objserver.GetDateset("select distinct Fid,Fixturename from FixtureName where Partnumber='" + Partno.ToString() + "'");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        fixture += "," + ds.Tables[0].Rows[i]["Fixturename"].ToString();
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {

            }

            return fixture.ToString();
        }
    }


    [WebMethod]
    public static string getdimensions(string Part, string Operation, string Cell)
    {
        string operation = "";
        string dimesion = "";
        lock (thisLock)
        {
            try
            {
                if (Operation == "OP1")
                {
                    operation = "1";
                }
                if (Operation == "OP2")
                {
                    operation = "2";
                }
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from Dynmaster where Partno='" + Part + "' and Operation='" + operation + "' and CellValues<>'0' and CellValues<>'' and Cell='" + Cell + "'", strConnString);
                    DataSet ds1 = new DataSet();
                    ds1.Tables.Clear();
                    ds1.Clear();
                    ds1.Reset();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        //da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Part + "' and Operation='" + operation + "' and DynRefid='" + ds1.Tables[0].Rows[0]["DID"].ToString() + "' and Cell='" + Cell + "' order by DynRefid", strConnString);
                        da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Part + "' and Operation='" + operation + "' and DynRefid='" + ds1.Tables[0].Rows[0]["DID"].ToString() + "' and Cell='" + Cell + "' order by Reorder", strConnString);
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        ds = new DataSet();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                dimesion = dimesion + "," + ds.Tables[0].Rows[i]["MeanValue"].ToString();

                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        SqlDataAdapter da2 = new SqlDataAdapter("select * from Dynmaster where Partno='" + Part + "' and Operation='" + operation + "' and RunChart='Yes' and Cell='" + Cell + "'", strConnString);
                        DataSet ds2 = new DataSet();
                        ds2.Tables.Clear();
                        ds2.Clear();
                        ds2.Reset();
                        da2.Fill(ds2);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            //da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Part + "' and Operation='" + operation + "' and DynRefid='" + ds2.Tables[0].Rows[0]["DID"].ToString() + "' and Cell='" + Cell + "' order by DynRefid", strConnString);
                            da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Part + "' and Operation='" + operation + "' and DynRefid='" + ds2.Tables[0].Rows[0]["DID"].ToString() + "' and Cell='" + Cell + "' order by Reorder", strConnString);
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();
                            ds = new DataSet();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    dimesion = dimesion + "," + ds.Tables[0].Rows[i]["MeanValue"].ToString();

                                }
                            }
                            else
                            {
                            }
                        }
                    }


                }

                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return dimesion.ToString();
        }
    }
    [WebMethod]
    public static httpvalues[] getSPChdnvalues()
    {
        List<httpvalues> obju = new List<httpvalues>();
        httpvalues obju1 = new httpvalues();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "" && HttpContext.Current.Session["User_Role"] != null && HttpContext.Current.Session["User_Role"].ToString() != "")
                {
                    if (HttpContext.Current.Session["User_Role"].ToString().ToUpper() == "USER")
                    {
                        obju1 = new httpvalues();
                        obju1.Cell = HttpContext.Current.Session["Depart"].ToString();
                        obju1.Machine = HttpContext.Current.Session["machine"].ToString();
                        obju1.Partno = HttpContext.Current.Session["PartNo"].ToString();
                        if (HttpContext.Current.Session["Operation"].ToString() == "1")
                        {
                            obju1.Operation = "OP1";
                        }
                        else if (HttpContext.Current.Session["Operation"].ToString() == "2")
                        {
                            obju1.Operation = "OP2";
                        }
                        else
                        {
                            obju1.Operation = HttpContext.Current.Session["Operation"].ToString();
                        }
                        obju1.Shift = HttpContext.Current.Session["Shift"].ToString();
                        obju.Add(obju1);
                    }
                    else
                    {

                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
            }
            return obju.ToArray();
        }
    }
    [WebMethod]
    public static httpvalues[] gethdnvalues()
    {
        List<httpvalues> obju = new List<httpvalues>();
        httpvalues obju1 = new httpvalues();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    obju1 = new httpvalues();
                    obju1.Cell = HttpContext.Current.Session["Depart"].ToString();
                    obju1.Machine = HttpContext.Current.Session["machine"].ToString();
                    obju1.Partno = HttpContext.Current.Session["PartNo"].ToString();
                    if (HttpContext.Current.Session["Operation"].ToString() == "1")
                    {
                        obju1.Operation = "OP1";
                    }
                    else if (HttpContext.Current.Session["Operation"].ToString() == "2")
                    {
                        obju1.Operation = "OP2";
                    }
                    else
                    {
                        obju1.Operation = HttpContext.Current.Session["Operation"].ToString();
                    }
                    obju1.Shift = HttpContext.Current.Session["Shift"].ToString();
                    obju.Add(obju1);
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
            }
            return obju.ToArray();
        }
    }
    void ClearFolder(DirectoryInfo folder)
    {
        foreach (FileInfo file in folder.GetFiles())
        {
            try
            {
                file.Delete();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
            }
        }
        foreach (DirectoryInfo subfolder in folder.GetDirectories())
        {
            ClearFolder(subfolder);
        }
    }
    [WebMethod]
    public static runchartdimension[] getdimensionsrun(string Part, string Operation, string Cell)
    {
        lock (thisLock)
        {
            try
            {
                //string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);

                //foreach (string filePath in Directory.GetFiles(tempPath, "*.*", SearchOption.AllDirectories))
                //{
                //    try
                //    {
                //        FileInfo currentFile = new FileInfo(filePath);
                //        currentFile.Delete();
                //    }
                //    catch (Exception ex)
                //    {
                //        //Debug.WriteLine("Error on file: {0}\r\n   {1}", filePath, ex.Message);
                //    }
                //}
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
            }
            decimal roundusl = 0; decimal roundlsl = 0; decimal roundmean = 0;
            List<runchartdimension> objr = new List<runchartdimension>();
            runchartdimension objr1 = new runchartdimension();
            string operation = "";
            string dimesion = "";
            if (Operation == "OP1")
            {
                operation = "1";
            }
            else if (Operation == "OP2")
            {
                operation = "2";
            }
            else
            {
                operation = Operation;
            }
            if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
            {
                SqlDataAdapter da1 = new SqlDataAdapter("select * from Dynmaster where Partno='" + Part + "' and Operation='" + operation + "' and RunChart='Yes' and Cell='" + Cell + "'  order by ReorderMaster ", strConnString);
                DataSet ds1 = new DataSet();
                ds1.Tables.Clear();
                ds1.Clear();
                ds1.Reset();
                da1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds1.Tables[0].Rows.Count; k++)
                    {
                        if (ds1.Tables[0].Rows[k]["CellValues"].ToString() != "" && ds1.Tables[0].Rows[k]["CellValues"].ToString() != "0" && ds1.Tables[0].Rows[k]["CellValues"].ToString() != null)
                        {
                            //da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Part + "' and Operation='" + operation + "' and DynRefid='" + ds1.Tables[0].Rows[k]["DID"].ToString() + "' and Cell='" + Cell + "' order by DynRefid", strConnString);
                            da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Part + "' and Operation='" + operation + "' and DynRefid='" + ds1.Tables[0].Rows[k]["DID"].ToString() + "' and Cell='" + Cell + "' order by Reorder", strConnString);
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();
                            ds = new DataSet();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    //dimesion = dimesion + "," + ds.Tables[0].Rows[i]["MeanValue"].ToString();

                                    if (ds.Tables[0].Rows[i]["UpperValue"].ToString() != "-" && ds.Tables[0].Rows[i]["UpperValue"].ToString() != "")
                                    {
                                        roundusl = Decimal.Parse(Regex.Match(ds.Tables[0].Rows[i]["UpperValue"].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                                    }
                                    else
                                    {
                                        if (ds.Tables[0].Rows[i]["LowerValue"].ToString() != "" && ds.Tables[0].Rows[i]["LowerValue"].ToString() != "-" && (ds.Tables[0].Rows[i]["MeanValue"].ToString() == "-" || ds.Tables[0].Rows[i]["MeanValue"].ToString() == ""))
                                        {
                                            roundusl = Convert.ToDecimal(ds.Tables[0].Rows[i]["LowerValue"].ToString()) * 3;
                                        }
                                        else
                                        {
                                            roundusl = 0;
                                        }
                                    }
                                    if (ds.Tables[0].Rows[i]["LowerValue"].ToString() != "-" && ds.Tables[0].Rows[i]["LowerValue"].ToString() != "")
                                    {
                                        roundlsl = Decimal.Parse(Regex.Match(ds.Tables[0].Rows[i]["LowerValue"].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                                    }
                                    else
                                    {
                                        roundlsl = 0;
                                    }
                                    if (ds.Tables[0].Rows[i]["MeanValue"].ToString() != "-" && ds.Tables[0].Rows[i]["MeanValue"].ToString() != "")
                                    {
                                        roundmean = Decimal.Parse(Regex.Match(ds.Tables[0].Rows[i]["MeanValue"].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                                    }
                                    else
                                    {
                                        if (roundusl != 0)
                                        {
                                            roundmean = Convert.ToDecimal(roundusl) / 2;
                                        }
                                        else
                                        {
                                            roundmean = 0;
                                        }
                                    }

                                    objr1 = new runchartdimension();
                                    objr1.DynRefid = ds1.Tables[0].Rows[k]["DID"].ToString();
                                    //objr1.DynRefid = "";
                                    int s = i + 1;
                                    objr1.ColDimen = s.ToString();
                                    //objr1.mean = ds.Tables[0].Rows[i]["MeanValue"].ToString();
                                    objr1.mean = roundmean.ToString();
                                    objr1.dimension = ds.Tables[0].Rows[i]["Dimension"].ToString();
                                    objr1.DynValid = ds.Tables[0].Rows[i]["DVID"].ToString();
                                    //objr1.usl = ds.Tables[0].Rows[i]["UpperValue"].ToString();
                                    //objr1.lsl = ds.Tables[0].Rows[i]["LowerValue"].ToString();
                                    //objr1.mean = ds.Tables[0].Rows[i]["MeanValue"].ToString();
                                    objr.Add(objr1);
                                }
                            }



                        }
                        else
                        {

                            //objr1.runchart = ds2.Tables[0].Rows[i]["Runchart"].ToString();
                            //objr1.ucl = ds2.Tables[0].Rows[i]["UCL"].ToString();
                            //objr1.lcl = ds2.Tables[0].Rows[i]["LCL"].ToString();

                            //da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Part + "' and Operation='" + operation + "' and DynRefid='" + ds1.Tables[0].Rows[k]["DID"].ToString() + "' and Cell='" + Cell + "' order by DynRefid", strConnString);
                            da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Part + "' and Operation='" + operation + "' and DynRefid='" + ds1.Tables[0].Rows[k]["DID"].ToString() + "' and Cell='" + Cell + "' order by Reorder", strConnString);
                            ds = new DataSet();
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();

                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    //dimesion = dimesion + "," + ds.Tables[0].Rows[i]["MeanValue"].ToString();
                                    if (ds.Tables[0].Rows[i]["UpperValue"].ToString() != "-" && ds.Tables[0].Rows[i]["UpperValue"].ToString() != "")
                                    {
                                        roundusl = Decimal.Parse(Regex.Match(ds.Tables[0].Rows[i]["UpperValue"].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                                    }
                                    else
                                    {
                                        if (ds.Tables[0].Rows[i]["LowerValue"].ToString() != "" && ds.Tables[0].Rows[i]["LowerValue"].ToString() != "-" && (ds.Tables[0].Rows[i]["MeanValue"].ToString() == "-" || ds.Tables[0].Rows[i]["MeanValue"].ToString() == ""))
                                        {
                                            //roundusl = Convert.ToDecimal(ds.Tables[0].Rows[i]["LowerValue"].ToString()) * 3;
                                            roundusl = Convert.ToDecimal(Decimal.Parse(Regex.Match(ds.Tables[0].Rows[i]["LowerValue"].ToString(), "-?[0-9]*\\.*[0-9]*").Value)) * 3;
                                        }
                                        else
                                        {
                                            roundusl = 0;
                                        }
                                    }
                                    if (ds.Tables[0].Rows[i]["LowerValue"].ToString() != "-" && ds.Tables[0].Rows[i]["LowerValue"].ToString() != "")
                                    {
                                        roundlsl = Decimal.Parse(Regex.Match(ds.Tables[0].Rows[i]["LowerValue"].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                                    }
                                    else
                                    {
                                        roundlsl = 0;
                                    }
                                    if (ds.Tables[0].Rows[i]["MeanValue"].ToString() != "-" && ds.Tables[0].Rows[i]["MeanValue"].ToString() != "")
                                    {
                                        roundmean = Decimal.Parse(Regex.Match(ds.Tables[0].Rows[i]["MeanValue"].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                                    }
                                    else
                                    {
                                        if (roundusl != 0)
                                        {
                                            roundmean = Convert.ToDecimal(roundusl) / 2;
                                        }
                                        else
                                        {
                                            roundmean = 0;
                                        }
                                    }

                                    objr1 = new runchartdimension();
                                    objr1.DynRefid = ds1.Tables[0].Rows[k]["DID"].ToString();
                                    objr1.DynValid = ds.Tables[0].Rows[i]["DVID"].ToString();
                                    //objr1.mean = ds.Tables[0].Rows[i]["MeanValue"].ToString();
                                    objr1.mean = roundmean.ToString();
                                    objr1.dimension = ds.Tables[0].Rows[i]["Dimension"].ToString();
                                    int s = i + 1;
                                    objr1.ColDimen = s.ToString();
                                    //objr1.usl = ds.Tables[0].Rows[i]["UpperValue"].ToString();
                                    //objr1.lsl = ds.Tables[0].Rows[i]["LowerValue"].ToString();
                                    //objr1.mean = ds.Tables[0].Rows[i]["MeanValue"].ToString();
                                    objr.Add(objr1);
                                }
                            }
                            else
                            {
                            }
                        }
                    }
                }
                else
                {
                    
                }
            }

            else
            {
                HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            //return dimesion.ToString();
            return objr.ToArray();
        }
    }
    [WebMethod]
    public static string report(string Type, string Partno, string Operation)
    {
        string resulst = "S";
        lock (thisLock)
        {
            try
            {
                HttpContext.Current.Session["Type"] = Type.ToString();
                HttpContext.Current.Session["PartNo"] = Partno.ToString();
                HttpContext.Current.Session["Operation"] = Operation.ToString();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return resulst.ToString();
        }



    }
    [WebMethod]
    public static string checkpageload()
    {
        string sessionvalue = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_Role"] != null && HttpContext.Current.Session["User_Role"].ToString() != "")
                {

                    sessionvalue = HttpContext.Current.Session["User_Role"].ToString();
                }
                else
                {
                    sessionvalue = "F";
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return sessionvalue.ToString();
        }
    }
    [WebMethod]
    public static string Getfixedtime(string Partno, string Process, string Shift, string Table, string Machine, string PIDNO)
    {
        string date = DateTime.Now.ToString();
        string createddate = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
        int fixedtime = 0;
        int prdqty = 0;
        int totalfixedtime = 0;
        int total = 0;
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    da = new SqlDataAdapter("select * from Actual_PrdQty where PartNo='" + Partno + "' and  Process='" + Process + "' and Shift='" + Shift + "'", strConnString);
                    ds = new DataSet();
                    da.Fill(ds);

                    //da1 = new SqlDataAdapter(" Select * from " + Table + " where rejectedQty <> 1  and Shift= '" + Shift + "' and PID_No='"+PIDNO+"'  and MachineName='" + Machine + "' and CreatedOn ='" + Convert.ToDateTime(date) + "'", strConnString);
                    //da1 = new SqlDataAdapter(" Select * from " + Table + " where Shift= '" + Shift + "' and PID_No='" + PIDNO + "'  and MachineName='" + Machine + "' and CreatedOn ='" + createddate + "'", strConnString);
                    da1 = new SqlDataAdapter("select * from " + Table + " where Prdn_Name='" + Partno.ToString() + "' and QShift='" + Shift.ToString() + "' and (CONVERT(VARCHAR, QDate, 103))='" + Convert.ToDateTime(createddate).ToShortDateString().ToString() + "' and MachineName='" + Machine.ToString() + "' and rejectedQty='0'", strConnString);
                    ds1 = new DataSet();
                    da1.Fill(ds1);
                    //string tbl = objcontext.QualitySheets;
                    //objcontext = new QualitySheetdclassDataContext();
                    //var GetData1 = (from c in (tbl)
                    //                where c.QPIDNo == 1 && c.PID_No == PIDNO.ToString() && c.Shift == Shift.ToString() && c.CreatedOn == Convert.ToDateTime(date) && c.MachineName == Machine
                    //                select c).ToList();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        fixedtime = Convert.ToInt32(ds.Tables[0].Rows[0]["FixedTime"].ToString());
                        total = fixedtime;
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        da = new SqlDataAdapter("select * from CycleTimeEntry where CPartno='" + Partno + "' and  CProcess='" + Process + "'", strConnString);
                        ds = new DataSet();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            double values = Convert.ToDouble(ds.Tables[0].Rows[0]["CTime"]);
                            int produced = Convert.ToInt32(ds1.Tables[0].Rows.Count.ToString());
                            int producedvalues = produced * (Convert.ToInt32(values));
                            prdqty = Convert.ToInt32(producedvalues);
                            total = total - prdqty;
                        }
                        else
                        {
                            prdqty = 0;
                        }


                    }
                    totalfixedtime = total;

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
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return totalfixedtime.ToString();
    }
    [WebMethod]
    public static string Getfixe_dtime(string Partno, string Process, string Shift, string Machine, string PIDNO, string Speedloss)
    {
        Regex objdot = new Regex(".");
        int total = 0, hours = 0, hr = 0, min = 0;
        string date = DateTime.Now.ToString();
        string createddate = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    da = new SqlDataAdapter("select * from EfficiencyCalculaus where Partno='" + Partno + "' and  Operation='" + Process + "' and Shift='" + Shift + "' and EffDate='" + createddate + "' and MachineName='" + Machine + "' and PIDNO='" + PIDNO + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string speed = ds.Tables[0].Rows[i]["DowntimeTotal"].ToString();
                            char[] delimiters = new char[] { '.' };
                            downtimeloss = speed.Split(delimiters);
                            for (int j = 0; j < downtimeloss.Length; j++)
                            {
                                if (downtimeloss[j] == null || downtimeloss[j] == "0" || downtimeloss[j] == "00" || downtimeloss[j] == "")
                                {
                                }
                                else if (j == 0)
                                {
                                    hr = Convert.ToInt32(downtimeloss[j].ToString());
                                    if (hr == 1)
                                    {
                                        hours = 60;
                                    }
                                    if (hr == 2)
                                    {
                                        hours = 120;
                                    }
                                    if (hr == 3)
                                    {
                                        hours = 180;
                                    }
                                    if (hr == 4)
                                    {
                                        hours = 240;
                                    }
                                    if (hr == 5)
                                    {
                                        hours = 300;
                                    }
                                    if (hr == 6)
                                    {
                                        hours = 360;
                                    }
                                    if (hr == 7)
                                    {
                                        hours = 420;
                                    }
                                    if (hr == 8)
                                    {
                                        hours = 480;
                                    }
                                    if (hr == 9)
                                    {
                                        hours = 540;
                                    }
                                    if (hr == 10)
                                    {
                                        hours = 600;
                                    }
                                    if (hr == 11)
                                    {
                                        hours = 660;
                                    }
                                    if (hr == 12)
                                    {
                                        hours = 720;
                                    }


                                    total = Convert.ToInt32(Speedloss) - hours;
                                    Speedloss = total.ToString();
                                }
                                else if (j == 1)
                                {
                                    min = Convert.ToInt32(downtimeloss[j].ToString());
                                    total = Convert.ToInt32(Speedloss) - min;
                                    Speedloss = total.ToString();
                                }

                            }

                            double cmm = Convert.ToDouble(ds.Tables[0].Rows[i]["CMM"].ToString());
                            int CMM = Convert.ToInt32(cmm);
                            total = Convert.ToInt32(Speedloss) - CMM;
                            Speedloss = total.ToString();
                            if (ds.Tables[0].Rows[i]["QualityIssues"].ToString() != "" && ds.Tables[0].Rows[i]["QualityIssues"].ToString() != null)
                            {
                                double qul = Convert.ToDouble(ds.Tables[0].Rows[i]["QualityIssues"].ToString());
                                int quality = Convert.ToInt32(qul);
                                total = Convert.ToInt32(Speedloss) - quality;
                                Speedloss = total.ToString();
                            }
                            if (ds.Tables[0].Rows[i]["Reworks"].ToString() != "" && ds.Tables[0].Rows[i]["Reworks"].ToString() != null)
                            {
                                double rew = Convert.ToDouble(ds.Tables[0].Rows[i]["Reworks"].ToString());
                                int rework = Convert.ToInt32(rew);
                                total = Convert.ToInt32(Speedloss) - rework;
                                Speedloss = total.ToString();
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
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return Speedloss.ToString();
    }
    [WebMethod]
    public static string Getfixe_dtime1(string Partno, string Process, string Shift, string Machine, string PIDNO)
    {
        Regex objdot = new Regex(".");
        int total = 0, hours = 0, hr = 0, min = 0;
        string date = DateTime.Now.ToString();
        string createddate = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    da = new SqlDataAdapter("select * from EfficiencyCalculaus where Partno='" + Partno + "' and  Operation='" + Process + "' and Shift='" + Shift + "' and EffDate='" + createddate + "' and MachineName='" + Machine + "' and PIDNO='" + PIDNO + "'", strConnString);
                    ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string speed = ds.Tables[0].Rows[i]["DowntimeTotal"].ToString();
                            char[] delimiters = new char[] { '.' };
                            downtimeloss = speed.Split(delimiters);
                            for (int j = 0; j < downtimeloss.Length; j++)
                            {
                                if (downtimeloss[j] == null || downtimeloss[j] == "0" || downtimeloss[j] == "00" || downtimeloss[j] == "")
                                {
                                }
                                else if (j == 0)
                                {
                                    hr = Convert.ToInt32(downtimeloss[j].ToString());
                                    if (hr == 1)
                                    {
                                        hours = 60;
                                    }
                                    if (hr == 2)
                                    {
                                        hours = 120;
                                    }
                                    if (hr == 3)
                                    {
                                        hours = 180;
                                    }
                                    if (hr == 4)
                                    {
                                        hours = 240;
                                    }
                                    if (hr == 5)
                                    {
                                        hours = 300;
                                    }
                                    if (hr == 6)
                                    {
                                        hours = 360;
                                    }
                                    if (hr == 7)
                                    {
                                        hours = 420;
                                    }
                                    if (hr == 8)
                                    {
                                        hours = 480;
                                    }
                                    if (hr == 9)
                                    {
                                        hours = 540;
                                    }
                                    if (hr == 10)
                                    {
                                        hours = 600;
                                    }
                                    if (hr == 11)
                                    {
                                        hours = 660;
                                    }
                                    if (hr == 12)
                                    {
                                        hours = 720;
                                    }


                                    total = total + hours;
                                    Speedloss = total.ToString();
                                }
                                else if (j == 1)
                                {
                                    min = Convert.ToInt32(downtimeloss[j].ToString());
                                    total += min;
                                }

                            }

                            double cmm = Convert.ToDouble(ds.Tables[0].Rows[i]["CMM"].ToString());
                            int CMM = Convert.ToInt32(cmm);
                            total += CMM;
                            if (ds.Tables[0].Rows[i]["QualityIssues"].ToString() != "" && ds.Tables[0].Rows[i]["QualityIssues"].ToString() != null)
                            {
                                double qul = Convert.ToDouble(ds.Tables[0].Rows[i]["QualityIssues"].ToString());
                                int quality = Convert.ToInt32(qul);
                                total += quality;
                            }
                            if (ds.Tables[0].Rows[i]["Reworks"].ToString() != "" && ds.Tables[0].Rows[i]["Reworks"].ToString() != null)
                            {
                                double rew = Convert.ToDouble(ds.Tables[0].Rows[i]["Reworks"].ToString());
                                int rework = Convert.ToInt32(rew);
                                total += rework;
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
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return total.ToString();
    }
    [WebMethod]
    public static string CalcuateUtiletime(string prdqty, string TT)
    {
        double h1, f1, g1;
        string results = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            h1 = Convert.ToDouble(prdqty);
            f1 = Convert.ToDouble(TT);
            g1 = h1 * f1 / 60;
            results = Convert.ToString(g1);
            results = Math.Round(double.Parse(results), 0).ToString();
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return results.ToString();
    }
    [WebMethod]
    public static string Movepage()
    {
        string results = "";
        results = HttpContext.Current.Session["Page"].ToString();
        return results.ToString();
    }
    [WebMethod]
    public static string Savedetails(String pmaintenance, String Clean, String Brak, String Demand, String Trials, String Meetings, String Trainings, String Plnmaintenance, String Shifthrs, String Acceptqty, String Rejection, String CMM, String Qualityissues, String Rework, String Downtypeone, String Downsone, String DownEone, String Downtotone, String Remarksone, String Date, String utiletime, string Speedloss)
    {

        string results = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            //downtypes += "," + Downtypeone + "," + Downtypetwo + "," + Downtypethree + "," + Downtypefour + "," + Downtypefive + "," + Downtypesix + "," + Downtypeseven;
            //comma = new Regex(",");
            //DownType = comma.Split(downtypes);
            //for (int j1 = 0; j1 < DownType.Length; j1++)
            //{

            //    if (DownType[j1] == "" || DownType[j1] == ",")
            //    {

            //    }

            //    else
            //    {
            lock (thisLock)
            {
                try
                {

                    if (pmaintenance != "" && pmaintenance != null && Clean != "" && Clean != null && Brak != "" && Brak != null && Demand != "" && Demand != null && Trials != "" && Trials != null && Meetings != "" && Meetings != null && Trainings != "" && Trainings != null && Plnmaintenance != "" && Plnmaintenance != null)
                    {
                        double a, b, c, d, f, g, h, i, j, k;
                        a = Convert.ToDouble(pmaintenance);
                        b = Convert.ToDouble(Clean);
                        c = Convert.ToDouble(Brak);
                        d = Convert.ToDouble(Demand);
                        f = Convert.ToDouble(Trials);
                        g = Convert.ToDouble(Meetings);
                        h = Convert.ToDouble(Trainings);
                        i = Convert.ToDouble(Plnmaintenance);
                        j = a + b + c + d + f + g + h + i;
                        k = j / 60;
                        plannedstop = Convert.ToString(k);
                        plannedstop = Math.Round(double.Parse(plannedstop), 0).ToString();
                    }
                    else
                    {
                        plannedstop = "0.00";
                    }
                    Utiletime = utiletime;

                    double a1, b1, c1, d1, e1, f1;
                    if (Rejection != "0" && Rejection != null && CMM != "" && CMM != null)
                    {
                        a1 = Convert.ToDouble(Rejection);
                        b1 = Convert.ToDouble(CMM);
                        e1 = Convert.ToDouble(Qualityissues);
                        f1 = Convert.ToDouble(Rework);
                        c1 = a1 + b1 + e1 + f1;
                        d1 = c1 / 60;
                        Qualityloss = Convert.ToString(d1);
                        Qualityloss = Math.Round(double.Parse(Qualityloss), 0).ToString();
                    }
                    else
                    {
                        Qualityloss = "0.00";
                    }
                    double a2, d2;
                    string minor = Speedloss;
                    if (minor != "" && minor != null)
                    {
                        minor = minor.Replace(":", ".");
                        a2 = Convert.ToDouble(minor);
                        d2 = a2 / 60;
                        Speedloss = Convert.ToString(d2);
                        Speedloss = Math.Round(double.Parse(Speedloss), 0).ToString();
                    }
                    else
                    {
                        Speedloss = "0";
                    }

                    double a10, d10;
                    string minor1 = Downtotone;
                    if (minor1 != "" && minor1 != null)
                    {
                        minor1 = minor.Replace(":", ".");
                        a10 = Convert.ToDouble(minor);
                        d10 = a10 / 60;

                        Downtimeloss = Convert.ToString(d10);
                        Downtimeloss = Math.Round(double.Parse(Downtimeloss), 0).ToString();
                    }
                    else
                    {
                        Downtimeloss = "0";
                    }
                    Topentime = Shifthrs.ToString();

                    if (Topentime != "" && Topentime != null && plannedstop != "" && plannedstop != null)
                    {
                        double a21, b21, c21;
                        a21 = Convert.ToDouble(Topentime);
                        b21 = Convert.ToDouble(plannedstop);
                        c21 = a21 - b21;
                        Plannedclosing = Convert.ToString(c21);
                        Plannedclosing = Math.Round(double.Parse(Plannedclosing), 0).ToString();
                        TUtiletime = Utiletime;
                        TUtiletime = Math.Round(double.Parse(TUtiletime), 0).ToString();
                    }
                    else
                    {
                        TUtiletime = "0.00";
                    }

                    if (Topentime != "" && Topentime != null && plannedstop != "" && plannedstop != null)
                    {
                        double a3, b3, c3;
                        a3 = Convert.ToDouble(Topentime);
                        b3 = Convert.ToDouble(plannedstop);
                        c3 = a3 - b3;
                        TRequired = Convert.ToString(c3);
                        TRequired = Math.Round(double.Parse(TRequired), 0).ToString();
                    }
                    else
                    {
                        TRequired = "0.00";
                    }
                    if (TRequired != "" && TRequired != null && Downtimeloss != "" && Downtimeloss != null)
                    {
                        double a4, b4, c4;
                        a4 = Convert.ToDouble(TRequired);
                        b4 = Convert.ToDouble(Downtimeloss);
                        c4 = a4 - b4;
                        Tfunction = Convert.ToString(c4);
                        Tfunction = Math.Round(double.Parse(Tfunction), 0).ToString();
                    }
                    else
                    {
                        Tfunction = "0.00";
                    }
                    if (Utiletime != "" && Utiletime != null && Qualityloss != "" && Qualityloss != null)
                    {
                        double a5, b5, c5;
                        a5 = Convert.ToDouble(Utiletime);
                        b5 = Convert.ToDouble(Qualityloss);
                        c5 = a5 + b5;
                        Operatingtime = Convert.ToString(c5);
                        Operatingtime = Math.Round(double.Parse(Operatingtime), 0).ToString();
                    }
                    else { Operatingtime = "0.00"; }

                    if (Utiletime != "" && Utiletime != null && TRequired != "" && TRequired != null)
                    {
                        double a6, b6, c6;
                        a6 = Convert.ToDouble(Utiletime);
                        b6 = Convert.ToDouble(TRequired);
                        c6 = (a6 / b6) * 100;
                        TRS = Convert.ToString(c6);
                        TRS = Math.Round(double.Parse(TRS), 0).ToString();
                    }
                    else
                    {
                        TRS = "0.00";
                    }

                    if (Utiletime != "" && Utiletime != null && Topentime != "" && Topentime != null)
                    {
                        double a7, b7, c7;
                        a7 = Convert.ToDouble(Utiletime);
                        b7 = Convert.ToDouble(Topentime);
                        c7 = (a7 / b7) * 100;
                        TRG = Convert.ToString(c7);
                        TRG = Math.Round(double.Parse(TRG), 0).ToString();
                    }
                    else
                    {
                        TRG = "0.00";
                    }
                    if (Utiletime != "" && Utiletime != null)
                    {
                        double a8, b8, c8;
                        a8 = Convert.ToDouble(0);
                        b8 = Convert.ToDouble(0);
                        c8 = (a8 - b8);
                        Totalstop = Convert.ToString(c8);
                        Totalstop = Math.Round(double.Parse(Totalstop), 0).ToString();
                    }
                    else
                    {
                        Totalstop = "0.00";
                    }
                    if (Utiletime != "" && Utiletime != null && Totalstop != "" && Totalstop != null)
                    {
                        double d9, f9, g9;
                        d9 = Convert.ToDouble(Totalstop);
                        f9 = Convert.ToDouble(Utiletime);
                        g9 = (d9 + f9);
                        Stophours = Convert.ToString(g9);
                        Stophours = Math.Round(double.Parse(Stophours), 0).ToString();
                    }
                    else
                    {
                        Stophours = "0.00";
                    }
                    objcal = new EfficiencyCalculaus();
                    objcal.Partno = HttpContext.Current.Session["PartNo"].ToString();
                    string OPER = "";
                    if (HttpContext.Current.Session["Operation"].ToString() == "1" || HttpContext.Current.Session["Operation"].ToString() == "2")
                    {
                        if (HttpContext.Current.Session["Operation"].ToString() == "1")
                        {
                            OPER = "OP1";
                        }
                        if (HttpContext.Current.Session["Operation"].ToString() == "2")
                        {
                            OPER = "OP2";
                        }
                    }
                    else
                    {
                        OPER = HttpContext.Current.Session["Operation"].ToString();
                    }
                    objcal.Operation = OPER.ToString();
                    objcal.EffDate = Convert.ToDateTime(HttpContext.Current.Session["LogDate"].ToString());
                    objcal.Shift = HttpContext.Current.Session["Shift"].ToString();
                    if (HttpContext.Current.Session["Shift"].ToString() == "A")
                    {
                        objcal.FromTo = "06:00 am TO 02:00 pm";
                    }
                    if (HttpContext.Current.Session["Shift"].ToString() == "B")
                    {
                        objcal.FromTo = "02:00 pm TO 10:00 pm";
                    }
                    if (HttpContext.Current.Session["Shift"].ToString() == "C")
                    {
                        objcal.FromTo = "10:00 pm TO 06:00 am";
                    }
                    if (HttpContext.Current.Session["Shift"].ToString() == "A1")
                    {
                        objcal.FromTo = "06:00 am TO 06:00 pm";
                    }
                    if (HttpContext.Current.Session["Shift"].ToString() == "B1")
                    {
                        objcal.FromTo = "06:00 pm TO 06:00 am";
                    }
                    objcal.OperatorName = HttpContext.Current.Session["User_Name"].ToString();

                    if (pmaintenance != "" && pmaintenance != null)
                    {
                        objcal.Mainteance = Convert.ToDecimal(pmaintenance);
                    }
                    else
                    {
                        objcal.Mainteance = Convert.ToDecimal(0.00);
                    }
                    if (Clean != "" && Clean != null)
                    {
                        objcal.Cleaning = Convert.ToDecimal(Clean);
                    }
                    else
                    {
                        objcal.Cleaning = Convert.ToDecimal(0.00);
                    }
                    if (Brak != "" && Brak != null)
                    {
                        objcal.Break = Convert.ToDecimal(Brak);
                    }
                    else
                    {
                        objcal.Break = Convert.ToDecimal(0.00);
                    }
                    if (Demand != "" && Demand != null)
                    {
                        objcal.Noplan = Convert.ToDecimal(Demand);
                    }
                    else
                    {
                        objcal.Noplan = Convert.ToDecimal(0.00);
                    }
                    if (Trials != "" && Trials != null)
                    {
                        objcal.Trials = Convert.ToDecimal(Trials);
                    }
                    else
                    {
                        objcal.Trials = Convert.ToDecimal(0.00);
                    }
                    if (Shifthrs != "" && Shifthrs != null)
                    {
                        objcal.ShiftTime = Convert.ToDecimal(Shifthrs);
                    }
                    else
                    {
                        objcal.ShiftTime = Convert.ToDecimal(0.00);
                    }
                    if (Meetings != "" && Meetings != null)
                    {
                        objcal.Meetings = Convert.ToDecimal(Meetings);
                    }
                    else
                    {
                        objcal.Meetings = Convert.ToDecimal(0.00);
                    }
                    if (Trainings != "" && Trainings != null)
                    {
                        objcal.Trainings = Convert.ToDecimal(Trainings);
                    }
                    else
                    {
                        objcal.Trainings = Convert.ToDecimal(0.00);
                    }
                    if (Plnmaintenance != "" && Plnmaintenance != null)
                    {
                        objcal.PlannedMaintenance = Convert.ToDecimal(Plnmaintenance);
                    }
                    else
                    {
                        objcal.PlannedMaintenance = Convert.ToDecimal(0.00);
                    }

                    objcal.SpeedTotal = Convert.ToDecimal(Speedloss);
                    //if (Downtypeone != "" && Downtypeone != null && DownType[j1].ToString() == Downtypeone.ToString())
                    //{
                    objcal.DowntimeType = Downtypeone.ToString();
                    objcal.DowntimeStart = Downsone.ToString();
                    objcal.DowntimedEnd = DownEone.ToString();
                    string downtime = Downtotone.ToString();
                    if (downtime == "" || downtime == null)
                    {
                        objcal.DowntimeTotal = Convert.ToDecimal(0.00);
                    }
                    else
                    {
                        downtime = downtime.Replace(":", ".");
                        objcal.DowntimeTotal = Convert.ToDecimal(downtime);
                    }
                    //objcal.Remarks = Remarksone.ToString();
                    // Downtypeone = "";
                    //}
                    //if (Downtypetwo != "" && Downtypetwo != null && DownType[j1].ToString() == Downtypetwo.ToString())
                    //{
                    //    objcal.DowntimeType = Downtypetwo.ToString();
                    //    objcal.DowntimeStart = Downstwo.ToString();
                    //    objcal.DowntimedEnd = DownEtwo.ToString();
                    //    string downtime = Downtottwo.ToString();
                    //    if (downtime == "" || downtime == null)
                    //    {
                    //        objcal.DowntimeTotal = Convert.ToDecimal(0.00);
                    //    }
                    //    else
                    //    {
                    //        downtime = downtime.Replace(":", ".");
                    //        objcal.DowntimeTotal = Convert.ToDecimal(downtime);
                    //    }
                    //    objcal.Remarks = Remarkstwo.ToString();
                    //   // Downtypetwo = "";
                    //}
                    //if (Downtypethree != "" && Downtypethree != null && DownType[j1].ToString() == Downtypethree.ToString())
                    //{
                    //    objcal.DowntimeType = Downtypethree.ToString();
                    //    objcal.DowntimeStart = Downsthree.ToString();
                    //    objcal.DowntimedEnd = DownEthree.ToString();
                    //    string downtime = Downtotthree.ToString();
                    //    if (downtime == "" || downtime == null)
                    //    {
                    //        objcal.DowntimeTotal = Convert.ToDecimal(0.00);
                    //    }
                    //    else
                    //    {
                    //        downtime = downtime.Replace(":", ".");
                    //        objcal.DowntimeTotal = Convert.ToDecimal(downtime);
                    //    }
                    //    objcal.Remarks = Remarksthree.ToString();
                    //   // Downtypethree = "";
                    //}
                    //if (Downtypefour != "" && Downtypefour != null && DownType[j1].ToString() == Downtypefour.ToString())
                    //{
                    //    objcal.DowntimeType = Downtypefour.ToString();
                    //    objcal.DowntimeStart = Downsfour.ToString();
                    //    objcal.DowntimedEnd = DownEfour.ToString();
                    //    string downtime = Downtotfour.ToString();
                    //    if (downtime == "" || downtime == null)
                    //    {
                    //        objcal.DowntimeTotal = Convert.ToDecimal(0.00);
                    //    }
                    //    else
                    //    {
                    //        downtime = downtime.Replace(":", ".");
                    //        objcal.DowntimeTotal = Convert.ToDecimal(downtime);
                    //    }
                    //    objcal.Remarks = Remarksfour.ToString();
                    //    //Downtypefour = "";
                    //}
                    //if (Downtypefive != "" && Downtypefive != null && DownType[j1].ToString() == Downtypefive.ToString())
                    //{
                    //    objcal.DowntimeType = Downtypefive.ToString();
                    //    objcal.DowntimeStart = Downsfive.ToString();
                    //    objcal.DowntimedEnd = DownEfive.ToString();
                    //    string downtime = Downtotfive.ToString();
                    //    if (downtime == "" || downtime == null)
                    //    {
                    //        objcal.DowntimeTotal = Convert.ToDecimal(0.00);
                    //    }
                    //    else
                    //    {
                    //        downtime = downtime.Replace(":", ".");
                    //        objcal.DowntimeTotal = Convert.ToDecimal(downtime);
                    //    }
                    //    objcal.Remarks = Remarksfive.ToString();
                    //    //Downtypefive = "";
                    //}
                    //if (Downtypesix != "" && Downtypesix != null && DownType[j1].ToString() == Downtypesix.ToString())
                    //{
                    //    objcal.DowntimeType = Downtypesix.ToString();
                    //    objcal.DowntimeStart = Downssix.ToString();
                    //    objcal.DowntimedEnd = DownEsix.ToString();
                    //    string downtime = Downtotsix.ToString();
                    //    if (downtime == "" || downtime == null)
                    //    {
                    //        objcal.DowntimeTotal = Convert.ToDecimal(0.00);
                    //    }
                    //    else
                    //    {
                    //        downtime = downtime.Replace(":", ".");
                    //        objcal.DowntimeTotal = Convert.ToDecimal(downtime);
                    //    }
                    //    objcal.Remarks = Remarksix.ToString();
                    //    //Downtypesix = "";
                    //}
                    //if (Downtypeseven != "" && Downtypeseven != null && DownType[j1].ToString() == Downtypeseven.ToString())
                    //{
                    //    objcal.DowntimeType = Downtypeseven.ToString();
                    //    objcal.DowntimeStart = Downsseven.ToString();
                    //    objcal.DowntimedEnd = DownEseven.ToString();
                    //    string downtime = Downtotseven.ToString();
                    //    if (downtime == "" || downtime == null)
                    //    {
                    //        objcal.DowntimeTotal = Convert.ToDecimal(0.00);
                    //    }
                    //    else
                    //    {
                    //        downtime = downtime.Replace(":", ".");
                    //        objcal.DowntimeTotal = Convert.ToDecimal(downtime);
                    //    }
                    //    objcal.Remarks = Remarkseven.ToString();
                    //    //Downtypeseven = "";
                    //}
                    //objcal.TT = Convert.ToDecimal(TT.ToString());
                    
                    objcal.Plantclosing = Convert.ToDecimal(Plannedclosing);
                    objcal.ToOpend = Convert.ToDecimal(Topentime);
                    objcal.PlannedStop = Convert.ToDecimal(plannedstop);
                    objcal.TrRequired = Convert.ToDecimal(TRequired);
                    objcal.DownTimeLoss = Convert.ToDecimal(Downtimeloss);
                    objcal.TfFunction = Convert.ToDecimal(Tfunction);
                    objcal.TTtime = Convert.ToDecimal(Speedloss);
                    objcal.EntOperating = Convert.ToDecimal(Operatingtime);
                    objcal.Qloss = Convert.ToDecimal(Qualityloss);
                    objcal.TuUtile = Convert.ToDecimal(TUtiletime);
                    objcal.TRS = Convert.ToDecimal(TRS);
                    objcal.TRG = Convert.ToDecimal(TRG);
                    objcal.TotalStop = Convert.ToDecimal(Totalstop);
                    objcal.UtilTimeStop = Convert.ToDecimal(Stophours);
                    objcal.PIDNO = HttpContext.Current.Session["PID_ID"].ToString();
                    objcal.Rejection = Convert.ToDecimal(Rejection.ToString());
                    objcal.CMM = Convert.ToDecimal(CMM.ToString());
                    objcal.department = HttpContext.Current.Session["Department"].ToString();
                    objcal.unit = HttpContext.Current.Session["Unit"].ToString();
                    objcal.ProdQty = Convert.ToDecimal(Acceptqty.ToString());
                    objcal.UtileTime = Convert.ToDecimal(Utiletime.ToString());
                    objcal.MachineName = HttpContext.Current.Session["machine"].ToString();
                    objcal.QualityIssues = Convert.ToDecimal(Qualityissues.ToString());
                    objcal.Reworks = Convert.ToDecimal(Rework.ToString());
                    objcal.Remarks = Remarksone.ToString();

                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    results = "F";
                }
                finally
                {
                    objcontext = new QualitySheetdclassDataContext();
                    objcontext.EfficiencyCalculaus.InsertOnSubmit(objcal);
                    objcontext.SubmitChanges();
                    objcontext = null;
                    results = HttpContext.Current.Session["Page"].ToString();
                }
                //}
                // }

            }
        }

        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return results.ToString();
    }
    //[WebMethod]
    //public static string getmachinename_MC_RPT(string unit_Mchn_rpt)
    //{
    //    string mchn_rpt = "";
    //    HttpContext.Current.Session["unit_Mchn_rpt"] = unit_Mchn_rpt.ToString();

    //    if (HttpContext.Current.Session["Unit"].ToString() == "MBU")
    //    {
    //        ds = objserver.GetDateset(" select MBU from Unit_table");
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            depart += "," + ds.Tables[0].Rows[i]["MBU"].ToString();
    //        }
    //        if (unit == "MBU")
    //        {
    //            ds = objserver.GetDateset("select '-Select-' MBU,'-Select-' MBU union select distinct MBU,MBU from Machine_rpt_tble order by 1 asc");
    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {
    //                mchn_rpt += "," + ds.Tables[0].Rows[i]["MBU"].ToString();

    //            }
    //        }
    //        else if (unit == "ABU")
    //        {
    //            ds = objserver.GetDateset("select '-Select-' ABU,'-Select-' ABU union select distinct ABU,ABU from Machine_rpt_tble order by 1 asc");
    //            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
    //            {
    //                mchn_rpt += "," + ds.Tables[0].Rows[j]["ABU"].ToString();

    //            }
    //        }
    //        else if (unit == "ALL")
    //        {
    //            ds = objserver.GetDateset("SELECT '-Select-' ALLRPT,'-Select-' ALLRPT union select distinct MBU,MBU  as ALLRPT FROM Machine_rpt_tble where MBU<>'' UNION ALL SELECT '-Select-' ALLRPT,'-Select-' ALLRPT  union select distinct ABU,ABU  as ALLRPT   FROM Machine_rpt_tble where ABU<>'' ");

    //            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    //            {
    //                mchn_rpt += "," + ds.Tables[0].Rows[k]["ALLRPT"].ToString();

    //            }
    //        }

    //    }
    //    return mchn_rpt.ToString();
    //}
    [WebMethod]
    public static string savefixname(string Partno, string Fixname, string ID)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {

                    cmd = new SqlCommand("Addfixname", strConnString);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@partnumber", SqlDbType.VarChar, 30).Value = Partno.ToString();
                    cmd.Parameters.Add("@fixname", SqlDbType.VarChar, 30).Value = Fixname.ToString();
                    cmd.Parameters.Add("@createdata", SqlDbType.VarChar, 30).Value = DateTime.Now.ToShortDateString().ToString();
                    cmd.Parameters.Add("@id", SqlDbType.VarChar, 30).Value = Convert.ToInt32(ID);

                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";
                }
                finally
                {
                    if (strConnString.State == ConnectionState.Open)
                    {
                        strConnString.Close();
                    }
                    strConnString.Open();
                    cmd.ExecuteNonQuery();
                    strConnString.Close();
                    res = "S";
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }
    [WebMethod]
    public static string SaveFB(string FeedBack)
    {
        string res = "";

        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            string prdname = HttpContext.Current.Session["PartNo"].ToString();
            string shift = HttpContext.Current.Session["Shift"].ToString();
            string process = HttpContext.Current.Session["Operation"].ToString();
            string Machine = HttpContext.Current.Session["machine"].ToString();
            string FixNo = HttpContext.Current.Session["FixNo"].ToString();
            if (process == "OP1")
            {
                process = "1";
            }
            if (process == "OP2")
            {
                process = "2";
            }
            string id = HttpContext.Current.Session["User_ID"].ToString();
            da = new SqlDataAdapter("select * from tbl_Registration where Reg_ID=" + Convert.ToInt32(id) + "", strConnString);

            ds = new DataSet();
            ds.Tables.Clear();
            ds.Clear();
            ds.Reset();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lock (thisLock)
                {
                    try
                    {
                        cmd = new SqlCommand("SaveFeedBack", strConnString);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Opname", SqlDbType.VarChar, 150).Value = ds.Tables[0].Rows[0]["Reg_Username"].ToString();
                        cmd.Parameters.Add("@Opshift", SqlDbType.VarChar, 3).Value = shift.ToString();
                        cmd.Parameters.Add("@Machine", SqlDbType.VarChar, 50).Value = Machine.ToString();
                        cmd.Parameters.Add("@FeedBack", SqlDbType.VarChar, 500).Value = FeedBack.ToString();
                        cmd.Parameters.Add("@FbDate", SqlDbType.VarChar, 10).Value = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy");
                        cmd.Parameters.Add("@cell", SqlDbType.VarChar, 10).Value = HttpContext.Current.Session["Depart"].ToString();
                        cmd.Parameters.Add("@partno", SqlDbType.VarChar, 50).Value = prdname.ToString();
                        cmd.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = process.ToString();
                        cmd.Parameters.Add("@fixno", SqlDbType.VarChar, 30).Value = FixNo.ToString();
                        cmd.Parameters.Add("@month", SqlDbType.VarChar, 10).Value = DateTime.Now.Month.ToString();
                        cmd.Parameters.Add("@year", SqlDbType.VarChar, 10).Value = DateTime.Now.Year.ToString();

                        if (FeedBack.ToString() != "")
                        {
                            StringBuilder sb = new StringBuilder();
                            DataSet ds1 = new DataSet();
                            ds1.Tables.Clear();
                            SqlDataAdapter da2 = new SqlDataAdapter("select * from MailAutorized where unit='MBU' ", strConnString);
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
                                msg.Subject = "Fixture Feedback Details";
                                msg.Body = "";
                                msg.IsBodyHtml = true;
                                SmtpClient smt = new SmtpClient();

                                //smt.Host = "smtp.gmail.com";
                                //smt.EnableSsl = true;

                                smt.Host = "mailer.poclain-hydraulics.net";
                                smt.EnableSsl = false;

                                string Inlineimage = HttpContext.Current.Server.MapPath("~/ABU/Mail/mail_Feed.jpg");
                                sb.Length = 0;
                                LinkedResource myimage = new LinkedResource(Inlineimage);
                                myimage.ContentId = Guid.NewGuid().ToString();
                                sb.Append("<html><body><div style='width: 100%;'><img src='cid:" + myimage.ContentId + "'></div><div style='height:10px;'></div><table style='width: 100%;border:1px solid black;border-collapse: collapse;'><tr style='background-color: #fff; height: 35px;'><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture No</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Tool/Fixture Name</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Part Number</span></td><td style='text-align: center; color: #000; width: 150px;border:solid 1px #000;font-weight:bold;'><span>Feedback</span></td></tr>");
                                da = new SqlDataAdapter("select *,b.FID as Fixtureno from FixtureValues a Left join FixtureName b on a.FixName =b.Fixturename where a.Status='Active' and b.Fixturename='" + FixNo.ToString() + "' and b.Partnumber like '%" + HttpContext.Current.Session["PartNo"].ToString() + "%' ", strConnString);
                                ds1 = new DataSet();
                                da.Fill(ds1);
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                                    {
                                        sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[0]["Reg_Username"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds1.Tables[0].Rows[i]["Fixtureno"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + FixNo.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + prdname.ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + FeedBack.ToString() + "</span></td></tr>");
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
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogging.SendExcepToDB(ex);
                        res = "F";
                    }
                    finally
                    {
                        if (strConnString.State == ConnectionState.Open)
                        {
                            strConnString.Close();
                        }
                        strConnString.Open();
                        cmd.ExecuteNonQuery();
                        strConnString.Close();
                        res = "S";
                    }

                }
            }
            else
            {
            }
        }
        else
        {
            res = "N";
        }


        return res.ToString();
    }

    [WebMethod]
    public static string saveResponse(string ID, string Message)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            string id = HttpContext.Current.Session["User_ID"].ToString();
            da = new SqlDataAdapter("select * from tbl_Registration where Reg_ID=" + Convert.ToInt32(id) + "", strConnString);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lock (thisLock)
                {
                    try
                    {
                        cmd = new SqlCommand("UpdateFeedback", strConnString);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@by", SqlDbType.VarChar, 150).Value = ds.Tables[0].Rows[0]["Reg_Username"].ToString();
                        cmd.Parameters.Add("@response", SqlDbType.VarChar, 500).Value = Message.ToString();
                        cmd.Parameters.Add("@resdate", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(ID);
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogging.SendExcepToDB(ex);
                        res = "F";
                    }
                    finally
                    {
                        if (strConnString.State == ConnectionState.Open)
                        {
                            strConnString.Close();
                        }
                        strConnString.Open();
                        cmd.ExecuteNonQuery();
                        strConnString.Close();
                        res = "S";
                    }

                }
            }
            else
            {
            }
        }
        else
        {
            res = "N";
        }
        return res.ToString();
    }
    [WebMethod]
    public static string checkFreqvalue(string Freq)
    {
        string result = "";
        HttpContext.Current.Session["Freq"] = Freq.ToString();
        string pidno = HttpContext.Current.Session["PID_ID"].ToString();
        string QCdate = HttpContext.Current.Session["LogDate"].ToString();
        string prdname = HttpContext.Current.Session["PartNo"].ToString();
        string shift = HttpContext.Current.Session["Shift"].ToString();
        string process = HttpContext.Current.Session["Operation"].ToString();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    if (HttpContext.Current.Session["Freq"].ToString() != "" || HttpContext.Current.Session["Freq"].ToString() != null)
                    {
                        if ((prdname == "A17724Q") && (process == "1"))
                        {
                            ds = objserver.GetDateset(" select * from QualitySheet  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }
                        else if (prdname == "A22916J" && process == "1")
                        {
                            ds = objserver.GetDateset(" select * from  QualitySheetA22916J  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }
                        else if (prdname == "A32271C" && process == "1")
                        {
                            ds = objserver.GetDateset(" select * from QSheetA32271C  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }
                        else if (prdname == "A44908N" && process == "1")
                        {
                            ds = objserver.GetDateset(" select * from QSheetA44908N  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }
                        else if (prdname == "A44983U" && process == "1")
                        {
                            ds = objserver.GetDateset(" select * from qualityshtA44983U  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }
                        else if (prdname == "A17724Q" && process == "Polishing")
                        {
                            ds = objserver.GetDateset(" select * from QSheetPolishing24Q  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }
                        else if (prdname == "A22916J" && process == "Polishing")
                        {
                            ds = objserver.GetDateset(" select * from QSheetpolishingA22916J  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }
                        else if (prdname == "A32271C" && process == "Polishing")
                        {
                            ds = objserver.GetDateset(" select * from QSheetpolishingA32271C  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }
                        else if (prdname == "A44908N" && process == "Polishing")
                        {
                            ds = objserver.GetDateset(" select * from QSheetPolishingA44908N  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }
                        else if (prdname == "A44983U" && process == "Polishing")
                        {
                            ds = objserver.GetDateset(" select * from QSheetpolishingA44983U  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }
                        else if (prdname == "A17724Q" && process == "2")
                        {
                            ds = objserver.GetDateset(" select * from opt2QSA17724Q  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }
                        else if (prdname == "A22916J" && process == "2")
                        {
                            ds = objserver.GetDateset(" select * from opt2QualitySheetA22916J  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }
                        else if (process == "Lapping")
                        {
                            ds = objserver.GetDateset(" select * from lappingQsheet24Q  where Qsheetno='" + Freq + "' and PID_No='" + pidno + "' and CreatedOn='" + QCdate + "' and Prdn_Name='" + prdname + "' and Shift='" + shift + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                result = "S";
                            }
                            else
                            {

                            }
                        }

                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return result.ToString();
        }
    }
    [WebMethod]
    public static Dynmaster[] editdynmaster(string id)
    {
        List<Dynmaster> objm = new List<Dynmaster>();
        Dynmaster objm1 = new Dynmaster();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from Dynmaster where DID=" + Convert.ToInt32(id) + "", strConnString);
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objm1.cell = ds.Tables[0].Rows[0]["Cell"].ToString();
                        objm1.inst_ranges = ds.Tables[0].Rows[0]["Int_range"].ToString();
                        objm1.inst_values = ds.Tables[0].Rows[0]["Int_count"].ToString();
                        objm1.instrument = ds.Tables[0].Rows[0]["Instrument"].ToString();
                        objm1.operation = ds.Tables[0].Rows[0]["Operation"].ToString();
                        objm1.partno = ds.Tables[0].Rows[0]["Partno"].ToString();
                        objm1.unit = ds.Tables[0].Rows[0]["Unit"].ToString();
                        objm1.shortname = ds.Tables[0].Rows[0]["ShortName"].ToString();
                        objm1.cellvalues = ds.Tables[0].Rows[0]["CellValues"].ToString();
                        objm1.headername = ds.Tables[0].Rows[0]["HeaderName"].ToString();
                        if (ds.Tables[0].Rows[0]["Runchart"].ToString() != "")
                        {
                            objm1.runchart = ds.Tables[0].Rows[0]["Runchart"].ToString();
                            objm1.ucl = ds.Tables[0].Rows[0]["UCL"].ToString();
                            objm1.lcl = ds.Tables[0].Rows[0]["LCL"].ToString();
                            objm1.runchartpercent = ds.Tables[0].Rows[0]["Runpercent"].ToString();
                        }
                        else
                        {
                            objm1.runchart = "No";
                            objm1.ucl = "0";
                            objm1.lcl = "0";
                            objm1.runchartpercent = "0";
                        }
                        objm.Add(objm1);
                    }
                    else
                    {
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objm.ToArray();
        }
    }
    [WebMethod]
    public static string updatedynmaster(string ID, string Part, string Opertaion, string Unit, string Cell, string Instru, string InstV, string InstR, string Short, string Cells, string Header, string Runchart, string Ucl, string Lcl)
    {

        string res = "";

        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    objcontext = new QualitySheetdclassDataContext();
                    int id = Convert.ToInt32(ID);
                    var query = (from table in objcontext.Dynmasters where table.DID == id select table).FirstOrDefault();
                    if (query != null)
                    {
                        query.Cell = Cell.ToString();
                        query.Instrument = Instru.ToString();
                        query.Int_count = InstV.ToString();
                        query.Int_range = InstR.ToString();
                        query.Operation = Opertaion.ToString();
                        query.Partno = Part.ToString();
                        query.Unit = Unit.ToString();
                        query.ShortName = Short.ToString();
                        query.CellValues = Cells.ToString();
                        query.HeaderName = Header.ToString();
                        if (Runchart.ToString() == "Yes")
                        {
                            query.Runchart = Runchart.ToString();
                            query.UCL = Convert.ToDecimal(Ucl.ToString());
                            query.LCL = Convert.ToDecimal(Lcl.ToString());
                        }
                        else
                        {
                            query.Runchart = Runchart.ToString();
                            query.UCL = 0;
                            query.LCL = 0;
                        }
                        objcontext.SubmitChanges();
                        res = "S";
                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";
                }
                finally
                {
                    ConnectionState state = strConnString.State;
                    if (state == ConnectionState.Open)
                    {
                        strConnString.Close();
                        strConnString.Open();
                    }
                    else
                    {
                        strConnString.Open();
                    }
                    cmd = null;
                    cmd = new SqlCommand("update DynmasterValues set Int_Frequency='" + InstR.ToString() + "',Instrument='" + Instru.ToString() + "',ShortName='" + Short.ToString() + "',Operation='" + Opertaion.ToString() + "' where DynRefid='" + ID.ToString() + "'", strConnString);
                    cmd.ExecuteNonQuery();
                    strConnString.Close();
                    res = "S";
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }
    [WebMethod]
    public static string deletedynmaster(string ID)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    objcontext = new QualitySheetdclassDataContext();
                    int id = Convert.ToInt32(ID);
                    var query = (from table in objcontext.Dynmasters where table.DID == id select table).FirstOrDefault();
                    objcontext.Dynmasters.DeleteOnSubmit(query);
                    objcontext.SubmitChanges();

                    //var query1 = (from table in objcontext.DynmasterValues where table.DynRefid == id.ToString() select table).FirstOrDefault();
                    //if (query1 != null)
                    //{
                    //    objcontext.DynmasterValues.DeleteOnSubmit(query1);
                    //    objcontext.SubmitChanges();
                    //}

                    foreach (var query1 in objcontext.DynmasterValues.Where(table => table.DynRefid == id.ToString()).ToList())
                    {
                        objcontext.DynmasterValues.DeleteOnSubmit(query1);
                    }
                    objcontext.SubmitChanges();

                    res = "S";
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";
                }
                finally
                {

                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }
    [WebMethod]
    public static string getinstruments(string Partno, string Opertaion, string Unit, string Cell)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by ReorderMaster", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            res += "," + ds.Tables[0].Rows[i]["DID"].ToString();
                        }
                    }
                    else
                    {
                        res = "F";
                    }

                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";
                }
                finally
                {

                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }

    [WebMethod]
    public static string getdynmasterinst(string id)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    da = new SqlDataAdapter("select * from DynmasterValues where dynrefid='" + id.ToString() + "' ", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        res = "S";
                    }
                    else
                    {
                        res = "F";
                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";
                }
                finally
                {

                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }

    [WebMethod]
    public static Instruments[] getinstrumentsvaluesorder(string Partno, string Opertaion, string Unit, string Cell)
    {
        List<Instruments> obji = new List<Instruments>();
        Instruments objii = new Instruments();
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by DID", strConnString);
                    DataSet ds1 = new DataSet();
                    ds1.Tables.Clear();
                    ds1.Clear();
                    ds1.Reset();
                    da1.Fill(ds1);
                    for (int d = 0; d < ds1.Tables[0].Rows.Count; d++)
                    {
                        da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and DynRefid='" + ds1.Tables[0].Rows[d]["DID"].ToString() + "';select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and DID='" + Convert.ToInt32(ds1.Tables[0].Rows[d]["DID"].ToString()) + "'", strConnString);
                        ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows[0]["Int_count"].ToString());
                            string C_count = ds.Tables[1].Rows[0]["Int_count"].ToString();
                            string range = ds.Tables[1].Rows[0]["Int_range"].ToString();
                            string run_chart = ds.Tables[1].Rows[0]["Runchart"].ToString();
                            for (int k = 0; k < count; k++)
                            {
                                if (ds.Tables[0].Rows.Count > k)
                                {
                                    objii = new Instruments();
                                    if (ds.Tables[0].Rows[k]["reorder"] != null && ds.Tables[0].Rows[k]["reorder"].ToString() != "")
                                    {
                                        objii.Reorder =Convert.ToInt32(ds.Tables[0].Rows[k]["reorder"].ToString());
                                    }
                                    else
                                    {
                                        //objii.Reorder = 0;
                                        objii.Reorder = d+1;
                                    }
                                    if (ds.Tables[0].Rows[k]["Dimension"] != null && ds.Tables[0].Rows[k]["Dimension"].ToString() != "")
                                    {
                                        objii.Dimession = ds.Tables[0].Rows[k]["Dimension"].ToString();
                                    }
                                    else
                                    {
                                        objii.Dimession = "";
                                    }
                                    if (ds.Tables[0].Rows[k]["Instrument"] != null && ds.Tables[0].Rows[k]["Instrument"].ToString() != "")
                                    {
                                        objii.Instrument = ds.Tables[0].Rows[k]["Instrument"].ToString();
                                    }
                                    else
                                    {
                                        objii.Instrument = "";
                                    }
                                    if (ds.Tables[0].Rows[k]["UpperValue"] != null && ds.Tables[0].Rows[k]["UpperValue"].ToString() != "")
                                    {
                                        objii.Upper = ds.Tables[0].Rows[k]["UpperValue"].ToString();
                                    }
                                    else
                                    {
                                        objii.Upper = "";
                                    }
                                    if (ds.Tables[0].Rows[k]["MeanValue"] != null && ds.Tables[0].Rows[k]["MeanValue"].ToString() != "")
                                    {
                                        objii.Mean = ds.Tables[0].Rows[k]["MeanValue"].ToString();
                                    }
                                    else
                                    {
                                        objii.Mean = "";
                                    }
                                    if (ds.Tables[0].Rows[k]["LowerValue"] != null && ds.Tables[0].Rows[k]["LowerValue"].ToString() != "")
                                    {
                                        objii.Lower = ds.Tables[0].Rows[k]["LowerValue"].ToString();
                                    }
                                    else
                                    {
                                        objii.Lower = "";
                                    }
                                    if (ds.Tables[0].Rows[k]["Int_Frequency"] != null && ds.Tables[0].Rows[k]["Int_Frequency"].ToString() != "")
                                    {
                                        objii.Range = ds.Tables[0].Rows[k]["Int_Frequency"].ToString();
                                    }
                                    else
                                    {
                                        objii.Range = range.ToString();
                                    }
                                    if (ds.Tables[0].Rows[k]["Int_count"] != null && ds.Tables[0].Rows[k]["Int_count"].ToString() != "")
                                    {
                                        objii.Count = ds.Tables[0].Rows[k]["Int_count"].ToString();
                                    }
                                    else
                                    {
                                        objii.Count = "0";
                                    }
                                    if (ds.Tables[0].Rows[k]["DynRefid"] != null && ds.Tables[0].Rows[k]["DynRefid"].ToString() != "")
                                    {
                                        objii.id = ds.Tables[0].Rows[k]["DynRefid"].ToString();
                                    }
                                    else
                                    {
                                        objii.id = "0";
                                    }
                                    if (ds.Tables[0].Rows[k]["DVID"] != null && ds.Tables[0].Rows[k]["DVID"].ToString() != "")
                                    {
                                        objii.id1 = ds.Tables[0].Rows[k]["DVID"].ToString();
                                    }
                                    else
                                    {
                                        objii.id1 = "0";
                                    }
                                    if (run_chart == "Yes")
                                    {
                                        DataSet dsrun = new DataSet();
                                        dsrun.Tables.Clear();
                                        dsrun.Clear();
                                        dsrun.Reset();
                                        dsrun = objserver.GetDateset("select * from Runchart where DVRefid='" + ds.Tables[0].Rows[k]["DVID"].ToString() + "' and RCStatus='Active' ");
                                        if (dsrun.Tables[0].Rows.Count > 0)
                                        {
                                            if (dsrun.Tables[0].Rows[0]["RUCL"] != null && dsrun.Tables[0].Rows[0]["RUCL"].ToString() != "")
                                            {
                                                objii.RUCL = dsrun.Tables[0].Rows[0]["RUCL"].ToString();
                                            }
                                            else
                                            {
                                                objii.RUCL = "0";
                                            }
                                            if (dsrun.Tables[0].Rows[0]["RLCL"] != null && dsrun.Tables[0].Rows[0]["RLCL"].ToString() != "")
                                            {
                                                objii.RLCL = dsrun.Tables[0].Rows[0]["RLCL"].ToString();
                                            }
                                            else
                                            {
                                                objii.RLCL = "0";
                                            }
                                            if (dsrun.Tables[0].Rows[0]["RPMean"] != null && dsrun.Tables[0].Rows[0]["RPMean"].ToString() != "")
                                            {
                                                objii.RPmean = dsrun.Tables[0].Rows[0]["RPMean"].ToString();
                                            }
                                            else
                                            {
                                                objii.RPmean = "0";
                                            }
                                        }
                                        else
                                        {
                                            objii.RUCL = "0";
                                            objii.RLCL = "0";
                                            objii.RPmean = "0";
                                        }
                                    }
                                    else
                                    {
                                        objii.RUCL = "";
                                        objii.RLCL = "";
                                        objii.RPmean = "";
                                    }
                                    objii.Count1 = C_count.ToString();
                                    obji.Add(objii);
                                }
                                else
                                {
                                    objii = new Instruments();
                                    objii.Instrument = ds.Tables[1].Rows[0]["Instrument"].ToString();
                                    objii.Count = ds.Tables[1].Rows[0]["Int_count"].ToString();
                                    objii.Range = ds.Tables[1].Rows[0]["Int_range"].ToString();
                                    objii.Upper = "";
                                    objii.id = ds.Tables[1].Rows[0]["DID"].ToString();
                                    objii.Dimession = "";
                                    objii.Count1 = "0";
                                    objii.Lower = "";
                                    objii.Upper = "";
                                    objii.Mean = "";
                                    objii.id1 = "0";
                                    if (ds.Tables[1].Rows[0]["Runchart"].ToString() == "Yes")
                                    {
                                        objii.RUCL = "0";
                                        objii.RLCL = "0";
                                        objii.RPmean = "0";
                                    }
                                    else
                                    {
                                        objii.RUCL = "";
                                        objii.RLCL = "";
                                        objii.RPmean = "";
                                    }
                                    objii.Count1 = C_count.ToString();
                                    obji.Add(objii);
                                }
                            }

                        }
                        else
                        {
                            da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and DID='" + ds1.Tables[0].Rows[d]["DID"].ToString() + "'", strConnString);
                            ds = new DataSet();
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                objii = new Instruments();
                                objii.Instrument = ds.Tables[0].Rows[0]["Instrument"].ToString();
                                objii.Count = ds.Tables[0].Rows[0]["Int_count"].ToString();
                                objii.Range = ds.Tables[0].Rows[0]["Int_range"].ToString();
                                objii.Upper = "";
                                objii.id = ds.Tables[0].Rows[0]["DID"].ToString();
                                //objii.Reorder = 0;
                                objii.Reorder = d + 1;
                                objii.Dimession = "";
                                objii.Count1 = "0";
                                objii.Lower = "";
                                objii.Upper = "";
                                objii.Mean = "";
                                if (ds.Tables[0].Rows[0]["Runchart"].ToString() == "Yes")
                                {
                                    objii.RUCL = "0";
                                    objii.RLCL = "0";
                                    objii.RPmean = "0";
                                }
                                else
                                {
                                    objii.RUCL = "";
                                    objii.RLCL = "";
                                    objii.RPmean = "";
                                }
                                obji.Add(objii);
                            }
                            else
                            {
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        var newList = obji.OrderBy(x => x.Reorder).ToList();
        return newList.ToArray();
        //return obji.ToArray();
    }
    [WebMethod]
    public static Instruments[] getinstrumentsvalues(string Instruments, string Partno, string Opertaion, string Unit, string Cell)
    {
        List<Instruments> obji = new List<Instruments>();
        Instruments objii = new Instruments();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and DynRefid='" + Instruments + "';select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and DID='" + Convert.ToInt32(Instruments) + "'", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows[0]["Int_count"].ToString());
                        string C_count = ds.Tables[1].Rows[0]["Int_count"].ToString();
                        string range = ds.Tables[1].Rows[0]["Int_range"].ToString();
                        for (int k = 0; k < count; k++)
                        {
                            objii = new Instruments();
                            if (ds.Tables[0].Rows[k]["Dimension"] != null && ds.Tables[0].Rows[k]["Dimension"].ToString() != "")
                            {
                                objii.Dimession = ds.Tables[0].Rows[k]["Dimension"].ToString();
                            }
                            else
                            {
                                objii.Dimession = "";
                            }
                            if (ds.Tables[0].Rows[k]["Instrument"] != null && ds.Tables[0].Rows[k]["Instrument"].ToString() != "")
                            {
                                objii.Instrument = ds.Tables[0].Rows[k]["Instrument"].ToString();
                            }
                            else
                            {
                                objii.Instrument = "";
                            }
                            if (ds.Tables[0].Rows[k]["UpperValue"] != null && ds.Tables[0].Rows[k]["UpperValue"].ToString() != "")
                            {
                                objii.Upper = ds.Tables[0].Rows[k]["UpperValue"].ToString();
                            }
                            else
                            {
                                objii.Upper = "";
                            }
                            if (ds.Tables[0].Rows[k]["MeanValue"] != null && ds.Tables[0].Rows[k]["MeanValue"].ToString() != "")
                            {
                                objii.Mean = ds.Tables[0].Rows[k]["MeanValue"].ToString();
                            }
                            else
                            {
                                objii.Mean = "";
                            }
                            if (ds.Tables[0].Rows[k]["LowerValue"] != null && ds.Tables[0].Rows[k]["LowerValue"].ToString() != "")
                            {
                                objii.Lower = ds.Tables[0].Rows[k]["LowerValue"].ToString();
                            }
                            else
                            {
                                objii.Lower = "";
                            }
                            if (ds.Tables[0].Rows[k]["Int_Frequency"] != null && ds.Tables[0].Rows[k]["Int_Frequency"].ToString() != "")
                            {
                                objii.Range = ds.Tables[0].Rows[k]["Int_Frequency"].ToString();
                            }
                            else
                            {
                                objii.Range = range.ToString();
                            }
                            if (ds.Tables[0].Rows[k]["Int_count"] != null && ds.Tables[0].Rows[k]["Int_count"].ToString() != "")
                            {
                                objii.Count = ds.Tables[0].Rows[k]["Int_count"].ToString();
                            }
                            else
                            {
                                objii.Count = "0";
                            }
                            if (ds.Tables[0].Rows[k]["DynRefid"] != null && ds.Tables[0].Rows[k]["DynRefid"].ToString() != "")
                            {
                                objii.id = ds.Tables[0].Rows[k]["DynRefid"].ToString();
                            }
                            else
                            {
                                objii.id = "0";
                            }
                            if (ds.Tables[0].Rows[k]["DVID"] != null && ds.Tables[0].Rows[k]["DVID"].ToString() != "")
                            {
                                objii.id1 = ds.Tables[0].Rows[k]["DVID"].ToString();
                            }
                            else
                            {
                                objii.id1 = "0";
                            }
                            objii.Count1 = C_count.ToString();
                            obji.Add(objii);
                        }
                    }
                    else
                    {
                        da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and DID='" + Instruments + "'", strConnString);
                        ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            objii = new Instruments();
                            objii.Instrument = ds.Tables[0].Rows[0]["Instrument"].ToString();
                            objii.Count = ds.Tables[0].Rows[0]["Int_count"].ToString();
                            objii.Range = ds.Tables[0].Rows[0]["Int_range"].ToString();
                            objii.Upper = "";
                            objii.id = ds.Tables[0].Rows[0]["DID"].ToString();
                            objii.Dimession = "";
                            objii.Count1 = "0";
                            objii.Lower = "";
                            objii.Upper = "";
                            objii.Mean = "";
                            obji.Add(objii);
                        }
                        else
                        {
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return obji.ToArray();
        }
    }
    [WebMethod]
    public static Instruments[] getinstrumentsvalues1()
    {
        string Partno = HttpContext.Current.Session["PartNo"].ToString();
        string Operation = HttpContext.Current.Session["Operation"].ToString();
        //  string Machine = HttpContext.Current.Session["machine"].ToString();
        //  string Process = HttpContext.Current.Session["Process"].ToString();
        string Cell = HttpContext.Current.Session["Depart"].ToString();
        string Unit = HttpContext.Current.Session["Unit"].ToString();

        List<Instruments> obji = new List<Instruments>();
        Instruments objii = new Instruments();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by ReorderMaster", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objii = new Instruments();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            objii.Instrument = objii.Instrument + "," + ds.Tables[0].Rows[i]["Instrument"].ToString();
                            objii.Count = objii.Count + "," + ds.Tables[0].Rows[i]["Int_count"].ToString();
                        }

                    }
                    else
                    {
                    }
                    obji.Add(objii);
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return obji.ToArray();
        }
    }
    public static string checkcolun(string Table, string Column, string Col)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    da1 = new SqlDataAdapter(" SELECT * FROM sys.columns WHERE [name] = N'" + Column + "' AND [object_id] = OBJECT_ID(N'" + Table + "') ", strConnString);
                    ds1 = new DataSet();
                    ds1.Tables.Clear();
                    ds1.Clear();
                    ds1.Reset();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        res = "S";
                    }
                    else
                    {

                        cmd = new SqlCommand("alter table " + Table + " add " + Col + "", strConnString);
                        if (strConnString.State == ConnectionState.Open)
                        {
                            strConnString.Close();
                        }
                        strConnString.Open();
                        cmd.ExecuteNonQuery();
                        strConnString.Close();
                    }

                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();
        }
    }
    public static void saveversiondata(string Partno, string Opertaion, string Unit, string Cell, string Dim, string Max, string Mean, string Min, string Range, int Instrument, string ID, string Instrument1, string count)
    {
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    cmd = new SqlCommand("Dynmastervalueversion", strConnString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@partno", SqlDbType.VarChar, 30).Value = Partno.ToString();
                    cmd.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = Opertaion;
                    cmd.Parameters.Add("@unit", SqlDbType.VarChar, 20).Value = Unit.ToString();
                    cmd.Parameters.Add("@cell", SqlDbType.VarChar, 30).Value = Cell.ToString();
                    cmd.Parameters.Add("@dim", SqlDbType.VarChar, 150).Value = Dim.ToString();
                    cmd.Parameters.Add("@max", SqlDbType.VarChar, 100).Value = Max.ToString();
                    cmd.Parameters.Add("@mean", SqlDbType.VarChar, 100).Value = Mean.ToString();
                    cmd.Parameters.Add("@min", SqlDbType.VarChar, 100).Value = Min.ToString();
                    cmd.Parameters.Add("@frequency", SqlDbType.VarChar, 10).Value = Range.ToString();
                    cmd.Parameters.Add("@uid", SqlDbType.Int).Value = Convert.ToInt32(Instrument.ToString());
                    cmd.Parameters.Add("@id", SqlDbType.VarChar, 30).Value = ID.ToString();
                    cmd.Parameters.Add("@instrument", SqlDbType.VarChar, 500).Value = Instrument1.ToString();
                    cmd.Parameters.Add("@version", SqlDbType.VarChar, 500).Value = count.ToString();
                    cmd.Parameters.Add("@date", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                    cmd.Parameters.Add("@userid", SqlDbType.Int).Value = Convert.ToInt32(HttpContext.Current.Session["User_ID"].ToString());
                    if (strConnString.State == ConnectionState.Open)
                    {
                        strConnString.Close();
                    }
                    strConnString.Open();
                    cmd.ExecuteNonQuery();
                    strConnString.Close();
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                }
                finally
                {
                    strConnString.Close();
                }
            }
        }
    }
    [WebMethod]
    public static string SaveDYNValues(string Partno, string Opertaion, string Unit, string Cell, string Dim, string Max, string Mean, string Min, string Range, string Instrument, string ID, string Flag, string RUCL, string RLCL, string RPMean, string Reorder)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    string Instrument1 = "";
                    da = new SqlDataAdapter("select Instrument from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and DID='" + Convert.ToInt32(Instrument) + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            Instrument1 = ds.Tables[0].Rows[i]["Instrument"].ToString();
                        }

                    }
                    else
                    {
                    }
                    if (Flag == "1")
                    {
                        da = null;
                        ds.Tables.Clear();
                        da = new SqlDataAdapter("select max(cast(Version as int)) as Version from DynmasterValuesVersion where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "'", strConnString);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Version"] == null || ds.Tables[0].Rows[0]["Version"].ToString() == "")
                            {
                                count = 1;
                            }
                            else
                            {
                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["Version"].ToString()) + 1;
                            }
                        }
                        else
                        {
                            count = 1;
                        }
                    }
                    SqlDataAdapter daa = new SqlDataAdapter("select * from DynmasterValues where DVID='" + Convert.ToInt32(ID) + "'", strConnString);
                    DataSet dss = new DataSet();
                    dss.Tables.Clear();
                    dss.Clear();
                    dss.Reset();
                    daa.Fill(dss);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        string d = "";
                        string u = "";
                        string m = "";
                        string l = "";
                        string f = "";
                        if (dss.Tables[0].Rows[0]["Dimension"].ToString() == Dim.ToString())
                        {
                        }
                        else
                        {
                            d = "1";
                        }
                        if (dss.Tables[0].Rows[0]["UpperValue"].ToString() == Max.ToString())
                        {
                        }
                        else
                        {
                            u = "1";
                        }
                        if (dss.Tables[0].Rows[0]["MeanValue"].ToString() == Mean.ToString())
                        {

                        }
                        else
                        {
                            m = "1";

                        }
                        if (dss.Tables[0].Rows[0]["LowerValue"].ToString() == Min.ToString())
                        {

                        }
                        else
                        {
                            l = "1";

                        }
                        if (Range.ToString() == "100%")
                        {
                            if (dss.Tables[0].Rows[0]["Int_Frequency"].ToString() == Range.ToString())
                            {

                            }
                            else
                            {
                                f = "1";

                            }
                        }
                        else
                        {
                            if (dss.Tables[0].Rows[0]["Int_Frequency"].ToString() == Range.ToString() + " Parts")
                            {

                            }
                            else
                            {
                                f = "1";

                            }
                        }

                        if (d == "1" || u == "1" || m == "1" || l == "1" || f == "1")
                        {
                            saveversiondata(Partno.ToString(), Opertaion, Unit, Cell, Dim, Max, Mean, Min, Range, Convert.ToInt32(Instrument), ID, Instrument1, count.ToString());
                            count = 0;
                        }
                        else
                        {
                        }
                        d = "";
                        u = "";
                        m = "";
                        l = "";
                        f = "";

                    }
                    else
                    {

                    }
                    decimal runucl = 0; decimal runlcl = 0; decimal runpmean = 0;
                    if (decimal.TryParse(RUCL, out runucl))
                    {
                        runucl = runucl;
                    }
                    else
                    { runucl = 0; }
                    if (decimal.TryParse(RLCL, out runlcl))
                    {
                        runlcl = runlcl;
                    }
                    else
                    { runlcl = 0; }
                    if (decimal.TryParse(RPMean, out runpmean))
                    {
                        runpmean = runpmean;
                    }
                    else
                    { runpmean = 0; }
                    cmd = new SqlCommand("Dynmastervalue", strConnString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@partno", SqlDbType.VarChar, 30).Value = Partno.ToString();
                    cmd.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = Opertaion;
                    cmd.Parameters.Add("@unit", SqlDbType.VarChar, 20).Value = Unit.ToString();
                    cmd.Parameters.Add("@cell", SqlDbType.VarChar, 30).Value = Cell.ToString();
                    cmd.Parameters.Add("@dim", SqlDbType.VarChar, 150).Value = Dim.ToString();
                    cmd.Parameters.Add("@max", SqlDbType.VarChar, 100).Value = Max.ToString();
                    cmd.Parameters.Add("@mean", SqlDbType.VarChar, 100).Value = Mean.ToString();
                    cmd.Parameters.Add("@min", SqlDbType.VarChar, 100).Value = Min.ToString();
                    cmd.Parameters.Add("@frequency", SqlDbType.VarChar, 10).Value = Range.ToString();
                    cmd.Parameters.Add("@uid", SqlDbType.Int).Value = Convert.ToInt32(Instrument.ToString());
                    cmd.Parameters.Add("@id", SqlDbType.VarChar, 30).Value = ID.ToString();
                    cmd.Parameters.Add("@instrument", SqlDbType.VarChar, 500).Value = Instrument1.ToString();
                    cmd.Parameters.Add("@date", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                    cmd.Parameters.Add("@userid", SqlDbType.Int).Value = Convert.ToInt32(HttpContext.Current.Session["User_ID"].ToString());
                    cmd.Parameters.Add("@rucl", SqlDbType.VarChar, 500).Value = runucl.ToString();
                    cmd.Parameters.Add("@rlcl", SqlDbType.VarChar, 500).Value = runlcl.ToString();
                    cmd.Parameters.Add("@rpmean", SqlDbType.VarChar, 500).Value = runpmean.ToString();
                    cmd.Parameters.Add("@Reorder", SqlDbType.VarChar, 150).Value = Reorder.ToString();

                    if (strConnString.State == ConnectionState.Open)
                    {
                        strConnString.Close();
                    }
                    strConnString.Open();
                    cmd.ExecuteNonQuery();
                    strConnString.Close();
                    res = "S";

                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";
                }
                finally
                {
                    strConnString.Close();
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }
    [WebMethod]
    public static GetMaxMin[] Get_maxmin()
    {
        List<GetMaxMin> objmm = new List<GetMaxMin>();
        GetMaxMin objm = new GetMaxMin();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    string Partno = HttpContext.Current.Session["PartNo"].ToString();
                    string Operation = HttpContext.Current.Session["Operation"].ToString();
                    //  string Machine = HttpContext.Current.Session["machine"].ToString();
                    //  string Process = HttpContext.Current.Session["Process"].ToString();
                    string Cell = HttpContext.Current.Session["Depart"].ToString();
                    string Unit = HttpContext.Current.Session["Unit"].ToString();
                    //da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by cast(dynrefid as int) asc", strConnString);
                    da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by cast(Reorder as int) asc", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            objm = new GetMaxMin();
                            objm.Max = ds.Tables[0].Rows[i]["UpperValue"].ToString();
                            objm.Min = ds.Tables[0].Rows[i]["LowerValue"].ToString();
                            da1 = null;
                            da1 = new SqlDataAdapter("select * from Dynmaster where DID='" + ds.Tables[0].Rows[i]["dynrefid"].ToString() + "'", strConnString);
                            ds1 = new DataSet();
                            ds1.Tables.Clear();
                            ds1.Clear();
                            ds1.Reset();
                            da1.Fill(ds1);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                objm.Cellvalue = ds1.Tables[0].Rows[0]["CellValues"].ToString();
                            }
                            else
                            {
                                objm.Cellvalue = "";
                            }
                            objmm.Add(objm);
                        }
                    }
                    else
                    {
                    }
                    da = null;
                    ds = null;
                    da1 = null;
                    ds1= null;
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage);
            }
            return objmm.ToArray();
        }
    }
    [WebMethod]
    public static GetMaxMin[] Get_adminmaxmin(string Partno, string Operation, string Unit, string Cell)
    {
        List<GetMaxMin> objmm = new List<GetMaxMin>();
        GetMaxMin objm = new GetMaxMin();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    string Partno1 = Partno.ToString();
                    string Operation1 = Operation.ToString();
                    string Cell1 = Cell.ToString();
                    string Unit1 = Unit.ToString();
                    //da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by cast(dynrefid as int) asc", strConnString);
                    da = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by cast(Reorder as int) asc", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            objm = new GetMaxMin();
                            objm.Max = ds.Tables[0].Rows[i]["UpperValue"].ToString();
                            objm.Min = ds.Tables[0].Rows[i]["LowerValue"].ToString();
                            da1 = null;
                            da1 = new SqlDataAdapter("select * from Dynmaster where DID='" + ds.Tables[0].Rows[i]["dynrefid"].ToString() + "'", strConnString);
                            ds1 = new DataSet();
                            ds1.Tables.Clear();
                            ds1.Clear();
                            ds1.Reset();
                            da1.Fill(ds1);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                objm.Cellvalue = ds1.Tables[0].Rows[0]["CellValues"].ToString();
                            }
                            else
                            {
                                objm.Cellvalue = "";
                            }
                            objmm.Add(objm);
                        }
                    }
                    else
                    {
                    }
                    da = null;
                    ds = null;
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objmm.ToArray();
        }
    }
    [WebMethod]
    public static QualitySheetDegin[] GetQualitydesign()
    {
        decimal roundusl = 0; decimal roundlsl = 0; decimal roundmean = 0; decimal tolerval = 0;
        //HttpContext.Current.Session["Unit"] = unit.ToString();
        DataTable dt = new DataTable();
        List<QualitySheetDegin> details = new List<QualitySheetDegin>();
        QualitySheetDegin QualityShtdgn = new QualitySheetDegin();
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            string Partno = HttpContext.Current.Session["PartNo"].ToString();
            string Operation = HttpContext.Current.Session["Operation"].ToString();
            //  string Machine = HttpContext.Current.Session["machine"].ToString();
            //  string Process = HttpContext.Current.Session["Process"].ToString();
            string Cell = HttpContext.Current.Session["Depart"].ToString();
            string Unit = HttpContext.Current.Session["Unit"].ToString();
            //using (SqlCommand cmd = new SqlCommand("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by cast(dynrefid as int) asc", strConnString))
            using (SqlCommand cmd = new SqlCommand("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by cast(Reorder as int) asc", strConnString))
            {
                lock (thisLock)
                {
                    try
                    {
                        if (strConnString.State == ConnectionState.Open)
                        {
                            strConnString.Close();
                        }
                        strConnString.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        foreach (DataRow dtrow in dt.Rows)
                        {
                            QualityShtdgn = new QualitySheetDegin();
                            QualityShtdgn.Instruments = dtrow["Instrument"].ToString();
                            QualityShtdgn.Frequency = dtrow["Int_Frequency"].ToString();
                            QualityShtdgn.Dimensions = dtrow["Dimension"].ToString();
                            QualityShtdgn.UpperSpecification = dtrow["UpperValue"].ToString();
                            QualityShtdgn.Mean = dtrow["MeanValue"].ToString();
                            QualityShtdgn.LowerSpecification = dtrow["LowerValue"].ToString();
                            QualityShtdgn.ShortName = dtrow["ShortName"].ToString();
                            
                            da = null;
                            da = new SqlDataAdapter("select * from Dynmaster where DID='" + dtrow["dynrefid"].ToString() + "'", strConnString);
                            ds = new DataSet();
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                QualityShtdgn.Cellvalue = ds.Tables[0].Rows[0]["CellValues"].ToString();
                                if (ds.Tables[0].Rows[0]["Runchart"].ToString() != "")
                                {
                                    QualityShtdgn.RunChart = ds.Tables[0].Rows[0]["Runchart"].ToString();
                                }
                                else
                                {
                                    QualityShtdgn.RunChart = "No";
                                }
                            }
                            else
                            {
                                QualityShtdgn.Cellvalue = "";
                                QualityShtdgn.RunChart = "No";
                            }

                            //if (dtrow["UpperValue"].ToString() != "-" && dtrow["UpperValue"].ToString() != "")
                            //{
                            //    roundusl = Decimal.Parse(Regex.Match(dtrow["UpperValue"].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                            //}
                            //else
                            //{
                            //    if (dtrow["LowerValue"].ToString() != "" && dtrow["LowerValue"].ToString() != "-" && (dtrow["MeanValue"].ToString() == "-" || dtrow["MeanValue"].ToString() == ""))
                            //    {
                            //        roundusl = Convert.ToDecimal(dtrow["LowerValue"].ToString()) * 3;
                            //    }
                            //    else
                            //    {
                            //        roundusl = 0;
                            //    }
                            //}
                            //if (dtrow["LowerValue"].ToString() != "-" && dtrow["LowerValue"].ToString() != "")
                            //{
                            //    roundlsl = Decimal.Parse(Regex.Match(dtrow["LowerValue"].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                            //}
                            //else
                            //{
                            //    roundlsl = 0;
                            //}
                            //if (dtrow["MeanValue"].ToString() != "-" && dtrow["MeanValue"].ToString() != "")
                            //{
                            //    roundmean = Decimal.Parse(Regex.Match(dtrow["MeanValue"].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                            //}
                            //else
                            //{
                            //    if (roundusl != 0)
                            //    {
                            //        roundmean = Convert.ToDecimal(roundusl) / 2;
                            //    }
                            //    else
                            //    {
                            //        roundmean = 0;
                            //    }
                            //}

                            //decimal tolerance = Convert.ToDecimal(roundusl) - Convert.ToDecimal(roundlsl);
                            //tolerval = Math.Round(((tolerance * 60) / 100) / 2, 3);
                            ////if (ds.Tables[0].Rows[0]["Runpercent"].ToString() == "")
                            ////{
                            ////    tolerval = Math.Round(((tolerance * Convert.ToInt32(0)) / 100) / 2, 3);
                            ////}
                            ////else
                            ////{
                            ////    tolerval = Math.Round(((tolerance * Convert.ToInt32(ds.Tables[0].Rows[0]["Runpercent"].ToString())) / 100) / 2, 3);
                            ////}
                            //decimal ucl = Math.Round(Convert.ToDecimal(roundmean) + tolerval, 3);
                            //decimal lcl = Math.Round(Convert.ToDecimal(roundmean) - tolerval, 3);

                            DataSet dsrun = new DataSet();
                            dsrun.Tables.Clear();
                            dsrun.Clear();
                            dsrun.Reset();
                            dsrun = objserver.GetDateset("select * from Runchart where DVRefid='" + dtrow["DVID"].ToString() + "' and RCStatus='Active'");
                            if (dsrun.Tables[0].Rows.Count > 0)
                            {
                                if (dsrun.Tables[0].Rows[0]["RUCL"].ToString() != "-" && dsrun.Tables[0].Rows[0]["RUCL"].ToString() != "")
                                {
                                    QualityShtdgn.UpperControlLimit = dsrun.Tables[0].Rows[0]["RUCL"].ToString();
                                }
                                else
                                {
                                    QualityShtdgn.UpperControlLimit = "0.00";
                                }

                                if (dsrun.Tables[0].Rows[0]["RPMean"].ToString() != "-" && dsrun.Tables[0].Rows[0]["RPMean"].ToString() != "")
                                {
                                    QualityShtdgn.ProcessMean = dsrun.Tables[0].Rows[0]["RPMean"].ToString();
                                }
                                else
                                {
                                    QualityShtdgn.ProcessMean = "0.00";
                                }
                                if (dsrun.Tables[0].Rows[0]["RLCL"].ToString() != "-" && dsrun.Tables[0].Rows[0]["RLCL"].ToString() != "")
                                {
                                    QualityShtdgn.LowerControlLimit = dsrun.Tables[0].Rows[0]["RLCL"].ToString();
                                }
                                else
                                {
                                    QualityShtdgn.LowerControlLimit = "0.00";
                                }
                            }
                            else
                            {
                                QualityShtdgn.UpperControlLimit = "0.00";
                                QualityShtdgn.ProcessMean = "0.00";
                                QualityShtdgn.LowerControlLimit = "0.00";
                            }

                            details.Add(QualityShtdgn);
                        }
                        strConnString.Close();
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogging.SendExcepToDB(ex);
                    }
                    finally
                    {
                        strConnString.Close();
                    }
                }
            }
        }

        else
        {
            HttpContext.Current.Response.Redirect("~/Home.aspx");
        }
        return details.ToArray();
    }
    [WebMethod]
    public static QualitySheetDegin[] GetadminQualitydesign(string Partno, string Operation, string Unit, string Cell)
    {

        //HttpContext.Current.Session["Unit"] = unit.ToString();
        DataTable dt = new DataTable();
        List<QualitySheetDegin> details = new List<QualitySheetDegin>();
        QualitySheetDegin QualityShtdgn = new QualitySheetDegin();
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            string Partno1 = Partno.ToString();
            string Operation1 = Operation.ToString();
            string Cell1 = Cell.ToString();
            string Unit1 = Unit.ToString();
            //using (SqlCommand cmd = new SqlCommand("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by cast(dynrefid as int) asc", strConnString))
            using (SqlCommand cmd = new SqlCommand("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by cast(Reorder as int) asc", strConnString))
            {
                lock (thisLock)
                {
                    try
                    {
                        if (strConnString.State == ConnectionState.Open)
                        {
                            strConnString.Close();
                        }
                        strConnString.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        foreach (DataRow dtrow in dt.Rows)
                        {
                            QualityShtdgn = new QualitySheetDegin();
                            QualityShtdgn.Instruments = dtrow["Instrument"].ToString();
                            QualityShtdgn.Frequency = dtrow["Int_Frequency"].ToString();
                            QualityShtdgn.Dimensions = dtrow["Dimension"].ToString();
                            QualityShtdgn.UpperSpecification = dtrow["UpperValue"].ToString();
                            QualityShtdgn.Mean = dtrow["MeanValue"].ToString();
                            QualityShtdgn.LowerSpecification = dtrow["LowerValue"].ToString();
                            QualityShtdgn.ShortName = dtrow["ShortName"].ToString();
                            da = null;
                            da = new SqlDataAdapter("select * from Dynmaster where DID='" + dtrow["dynrefid"].ToString() + "'", strConnString);
                            ds = new DataSet();
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                QualityShtdgn.Cellvalue = ds.Tables[0].Rows[0]["CellValues"].ToString();
                            }
                            else
                            {
                                QualityShtdgn.Cellvalue = "";
                            }
                            details.Add(QualityShtdgn);

                        }
                        strConnString.Close();
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogging.SendExcepToDB(ex);
                    }
                    finally
                    {
                        strConnString.Close();
                    }
                }
            }
        }

        else
        {
            HttpContext.Current.Response.Redirect("~/Home.aspx");
        }
        return details.ToArray();
    }
    [WebMethod]
    public static Qltyheadervalue[] GetheaderQsTxtbx_header()
    {
        string Partno = HttpContext.Current.Session["PartNo"].ToString();
        string Operation = HttpContext.Current.Session["Operation"].ToString();
        string Cell = HttpContext.Current.Session["Depart"].ToString();
        string Unit = HttpContext.Current.Session["Unit"].ToString();
        DataTable dt = new DataTable();
        List<Qltyheadervalue> QtyShthdrval1 = new List<Qltyheadervalue>();
        Qltyheadervalue QtyShthdrval = new Qltyheadervalue();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
//                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by ReorderMaster", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            QtyShthdrval = new Qltyheadervalue();
                            QtyShthdrval.Instruments = ds.Tables[0].Rows[i]["Instrument"].ToString();
                            QtyShthdrval.Instrcount = ds.Tables[0].Rows[i]["Int_count"].ToString();
                            QtyShthdrval.ShortName = ds.Tables[0].Rows[i]["ShortName"].ToString();
                            QtyShthdrval.Cells = ds.Tables[0].Rows[i]["CellValues"].ToString();
                            QtyShthdrval.Headername = ds.Tables[0].Rows[i]["HeaderName"].ToString();
                            QtyShthdrval1.Add(QtyShthdrval);
                        }
                    }
                    else
                    {
                    }
                }
                else
                {

                    HttpContext.Current.Response.Redirect("../../Home.aspx");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return QtyShthdrval1.ToArray();
        }
    }
    [WebMethod]
    public static Qltyheadervalue[] GetadminheaderQsTxtbx_header(string Partno, string Operation, string Unit, string Cell)
    {
        string Partno1 = Partno.ToString();
        string Operation1 = Operation.ToString();
        string Cell1 = Cell.ToString();
        string Unit1 = Unit.ToString();
        DataTable dt = new DataTable();
        List<Qltyheadervalue> QtyShthdrval1 = new List<Qltyheadervalue>();
        Qltyheadervalue QtyShthdrval = new Qltyheadervalue();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno1 + "' and Operation='" + Operation1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno1 + "' and Operation='" + Operation1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' order by ReorderMaster", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            QtyShthdrval = new Qltyheadervalue();
                            QtyShthdrval.Instruments = ds.Tables[0].Rows[i]["Instrument"].ToString();
                            QtyShthdrval.Instrcount = ds.Tables[0].Rows[i]["Int_count"].ToString();
                            QtyShthdrval.ShortName = ds.Tables[0].Rows[i]["ShortName"].ToString();
                            QtyShthdrval.Cells = ds.Tables[0].Rows[i]["CellValues"].ToString();
                            QtyShthdrval.Headername = ds.Tables[0].Rows[i]["HeaderName"].ToString();
                            QtyShthdrval1.Add(QtyShthdrval);
                        }
                    }
                    else
                    {
                    }
                }
                else
                {

                    HttpContext.Current.Response.Redirect("../../Home.aspx");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return QtyShthdrval1.ToArray();
        }
    }
    [WebMethod]
    public static Qltyheadervalue[] GetadminheaderQsTxtbx_header1(string Partno, string Operation, string Unit, string Cell)
    {
        string Partno1 = Partno.ToString();
        string Operation1 = Operation.ToString();
        string Cell1 = Cell.ToString();
        string Unit1 = Unit.ToString();
        //HttpContext.Current.Session["Unit"] = unit.ToString();
        DataTable dt = new DataTable();
        List<Qltyheadervalue> QtyShthdrval1 = new List<Qltyheadervalue>();
        Qltyheadervalue QtyShthdrval = new Qltyheadervalue();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno1 + "' and Operation='" + Operation1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno1 + "' and Operation='" + Operation1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' order by ReorderMaster", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            QtyShthdrval = new Qltyheadervalue();
                            QtyShthdrval.Instruments = ds.Tables[0].Rows[i]["Instrument"].ToString();
                            QtyShthdrval.Instrcount = ds.Tables[0].Rows[i]["Int_count"].ToString();
                            QtyShthdrval.Frequency = ds.Tables[0].Rows[i]["Int_range"].ToString();
                            QtyShthdrval.Headername = ds.Tables[0].Rows[i]["HeaderName"].ToString();
                            QtyShthdrval.Cells = ds.Tables[0].Rows[i]["CellValues"].ToString();
                            QtyShthdrval.Id = ds.Tables[0].Rows[i]["DID"].ToString();
                            QtyShthdrval.ShortName = ds.Tables[0].Rows[i]["ShortName"].ToString();
                            QtyShthdrval1.Add(QtyShthdrval);
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return QtyShthdrval1.ToArray();
        }
    }
    [WebMethod]
    public static Qltyheadervalue[] GetheaderQsTxtbx_header1()
    {
        DataTable dt = new DataTable();
        List<Qltyheadervalue> QtyShthdrval1 = new List<Qltyheadervalue>();
        Qltyheadervalue QtyShthdrval = new Qltyheadervalue();
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    string Partno = HttpContext.Current.Session["PartNo"].ToString();
                    string Operation = HttpContext.Current.Session["Operation"].ToString();
                    string Cell = HttpContext.Current.Session["Depart"].ToString();
                    string Unit = HttpContext.Current.Session["Unit"].ToString();


                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by ReorderMaster", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            QtyShthdrval = new Qltyheadervalue();
                            QtyShthdrval.Instruments = ds.Tables[0].Rows[i]["Instrument"].ToString();
                            QtyShthdrval.Instrcount = ds.Tables[0].Rows[i]["Int_count"].ToString();
                            QtyShthdrval.Frequency = ds.Tables[0].Rows[i]["Int_range"].ToString();
                            QtyShthdrval.Headername = ds.Tables[0].Rows[i]["HeaderName"].ToString();
                            QtyShthdrval.Cells = ds.Tables[0].Rows[i]["CellValues"].ToString();
                            QtyShthdrval.Id = ds.Tables[0].Rows[i]["DID"].ToString();
                            QtyShthdrval1.Add(QtyShthdrval);
                        }
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
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
        }
        else
        {
            //HttpContext.Current.Response.Redirect("../Home.aspx", false);
            ////context.ApplicationInstance.CompleteRequest();
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
            ////HttpContext.Current.Response.End();

            try
            {
                HttpContext.Current.Response.Redirect("~/Home.aspx");
                //Server.Transfer("~/Home.aspx");
            }
            catch (ThreadAbortException te)
            {
                //do nothing or handle as required
            }

        }
        return QtyShthdrval1.ToArray();
    }
    [WebMethod]
    public static string getuserdetailval()
    {
        string result = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    string Qdate = HttpContext.Current.Session["LogDate"].ToString();
                    //Qdate = Convert.ToDateTime(Qdate).ToString("MM/dd/yyyy");
                    string Qdate1 = HttpContext.Current.Session["LogDate"].ToString();
                    string Pidno = HttpContext.Current.Session["PID_ID"].ToString();
                    string shift = HttpContext.Current.Session["Shift"].ToString();
                    string UserName = HttpContext.Current.Session["User_Name"].ToString();
                    string partno = HttpContext.Current.Session["PartNo"].ToString();
                    string operation = HttpContext.Current.Session["Operation"].ToString();
                    string machine = HttpContext.Current.Session["machine"].ToString();
                    result = Qdate + ',' + Pidno + ',' + shift + ',' + UserName + ',' + partno + "," + operation + "," + machine;

                    //string tablename = "QualitySheet_" + HttpContext.Current.Session["Depart"].ToString() + "_" + partno + "_" + operation + "";

                    //SqlDataAdapter cda = new SqlDataAdapter("select isnull(max(convert(int,SLNo)),0)+1 as Slno from " + tablename + " where CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(Qdate1).ToString("dd/MM/yyyy") + "' and QShift='" + shift + "' and OPERATOR='" + UserName + "' and MachineName='" + machine + "'", strConnString);
                    //DataSet cds = new DataSet();
                    //cda.Fill(cds);
                    //if (cds.Tables[0].Rows.Count > 0)
                    //{
                    //    result += "," + cds.Tables[0].Rows[0]["Slno"].ToString();
                    //}
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    Exception ex2 = ex;
                    string errorMessage = string.Empty;
                    while (ex2 != null)
                    {
                        errorMessage += ex2.ToString();
                        ex2 = ex2.InnerException;
                    }
                    //HttpContext.Current.Response.Write(errorMessage);
                    ////ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid file !');", true);
                    ////Response.Write("<script>alert('" + errorMessage + "');</script>");

                    //Page page = HttpContext.Current.CurrentHandler as Page;

                    //if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
                    //{
                    //    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", "<script>alert('Invalid file !');</script>", true);
                    //}
                    //Alert.Show(errorMessage);

                    string script = "<script type=\"text/javascript\">" + string.Format("alert('{0}');", errorMessage) + ";</script>";


                    Page page = HttpContext.Current.CurrentHandler as Page;

                    if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
                    {
                        page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true);
                    }
                    result = string.Empty;
                    result = errorMessage;
                    result.ToString();
                }
            }

        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return result.ToString();

    }
    [WebMethod]
    public static string CreateTable(string Partno, string Opertaion, string Unit, string Cell)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    string marph = "";
                    string sheet = "";
                    string colums = "";
                    string totcol = "";
                    string tableName = "QualitySheet_" + Cell + "_" + Partno + "_" + Opertaion + "";
                    totcol = "QSid int primary key IDENTITY(1,1) NOT NULL,QDate datetime,QPidno nvarchar(MAX),QShift nvarchar(50),OPERATOR nvarchar(MAX),SLNo nvarchar(MAX),QHeatCode nvarchar(MAX)";
                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by ReorderMaster", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i]["CellValues"] != null && ds.Tables[0].Rows[i]["CellValues"].ToString() != "" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "0" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "-")
                            {
                                int count = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                string id = ds.Tables[0].Rows[i]["DID"].ToString();
                                for (int j = 1; j <= count; j++)
                                {
                                    marph = marph + "," + "QMax_" + "" + id + "" + j + "" + " nvarchar(MAX)" + " " + String.Empty;
                                    marph = marph + "," + "QMin_" + "" + id + "" + j + "" + " nvarchar(MAX)" + " " + String.Empty;
                                    sheet = sheet + "," + "Chart_MaxD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    sheet = sheet + "," + "Chart_MinD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    sheet = sheet + "," + "AverageD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    sheet = sheet + "," + "Chart_CPD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    sheet = sheet + "," + "Chart_CPKD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    sheet = sheet + "," + "Chart_DeviationD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    sheet = sheet + "," + "Chart_Y_MaxD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    sheet = sheet + "," + "Chart_Y_MinD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    sheet = sheet + "," + "Chart_G_MaxD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    sheet = sheet + "," + "Chart_G_MinD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    sheet = sheet + "," + "Chart_MeanD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                }
                            }
                            else
                            {
                                string three = ds.Tables[0].Rows[i]["Instrument"].ToString().Substring(0, 3);
                                int count1 = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                string id1 = ds.Tables[0].Rows[i]["DID"].ToString();
                                for (int k = 1; k <= count1; k++)
                                {
                                    colums = colums + "," + three + "" + id1 + "" + k + "" + " nvarchar(MAX)" + " " + String.Empty;
                                }
                            }
                        }

                        string PName = "," + "Prdn_Name" + "  nvarchar(max)" + " " + String.Empty;
                        string rejectedQty = "," + "rejectedQty" + "   nvarchar(20)" + " " + String.Empty;
                        string MachineName = "," + "MachineName" + "   nvarchar(max)" + " " + String.Empty;
                        string cycletime = "," + "cycletime" + "  nvarchar(50)" + " " + String.Empty;
                        string unit = "," + "Unit" + "  nvarchar(20)" + " " + String.Empty;
                        string cmt = "," + "Comments" + "  nvarchar(max)" + " " + String.Empty;
                        string date = "," + "CreateDate" + "  nvarchar(10)" + " " + String.Empty;
                        string fixno = "," + "FixNo" + "  nvarchar(max)" + " " + String.Empty;
                        string Cell1 = "," + "Cell" + "  nvarchar(50)" + " " + String.Empty;
                        string Time = "," + "Qtime" + "  datetime" + " " + String.Empty;
                        string Month = "," + "Month" + "  varchar(3)" + " " + String.Empty;
                        string Year = "," + "Year" + "  varchar(5)" + " " + String.Empty;
                        totcol = totcol + marph + colums + cmt + sheet + PName + rejectedQty + MachineName + cycletime + unit + date + fixno + Cell1 + Time + Month + Year;
                        totcol = totcol.Trim().TrimStart(',');
                        ChecktableExistnew(tableName, totcol, Partno, Opertaion, Unit, Cell);
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                }
                finally
                {
                    res = "S";
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }
    static void ChecktableExistnew(string CheckTabName, string DbColname, string Partno, string Opertaion, string Unit, string Cell)
    {
        string str11 = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + CheckTabName + "'";
        SqlCommand myCommand = new SqlCommand(str11, strConnString);
        SqlDataReader myReader = null;
        int count = 0;
        // strConnString.Close();
        lock (thisLock)
        {
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
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
            }
            if (count == 0)
            {
                // "Table doesn't exists";
                CreateQuery = "create table " + CheckTabName.ToString() + " ( " + DbColname + ")";
                SqlCommand cmd = new SqlCommand(CreateQuery, strConnString);
                if (strConnString.State == ConnectionState.Open)
                {
                    strConnString.Close();
                }
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
            }
            else
            {
                try
                {
                    string tableName = CheckTabName;
                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by ReorderMaster", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    string res = "";
                    string marph = "";
                    string Col = "";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i]["CellValues"] != null && ds.Tables[0].Rows[i]["CellValues"].ToString() != "" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "0" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "-")
                            {
                                int count1 = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                string id = ds.Tables[0].Rows[i]["DID"].ToString();
                                for (int j = 1; j <= count1; j++)
                                {


                                    marph = "QMax_" + "" + id + "" + j;
                                    Col = "QMax_" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                    marph = "QMin_" + "" + id + "" + j;
                                    Col = "QMin_" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                    marph = "Chart_MaxD" + "" + id + "" + j;
                                    Col = "Chart_MaxD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                    marph = "Chart_MinD" + "" + id + "" + j;
                                    Col = "Chart_MinD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                    marph = "AverageD" + "" + id + "" + j;
                                    Col = "AverageD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                    marph = "Chart_CPD" + "" + id + "" + j;
                                    Col = "Chart_CPD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                    marph = "Chart_CPKD" + "" + id + "" + j;
                                    Col = "Chart_CPKD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                    marph = "Chart_DeviationD" + "" + id + "" + j;
                                    Col = "Chart_DeviationD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                    marph = "Chart_Y_MaxD" + "" + id + "" + j;
                                    Col = "Chart_Y_MaxD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                    marph = "Chart_Y_MinD" + "" + id + "" + j;
                                    Col = "Chart_Y_MinD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                    marph = "Chart_G_MaxD" + "" + id + "" + j;
                                    Col = "Chart_G_MaxD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                    marph = "Chart_G_MinD" + "" + id + "" + j;
                                    Col = "Chart_G_MinD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                    marph = "Chart_MeanD" + "" + id + "" + j;
                                    Col = "Chart_MeanD" + "" + id + "" + j + "" + " decimal(18, 3)" + " " + String.Empty;
                                    res = checkcolun(tableName, marph, Col);

                                }
                            }
                            else
                            {
                                string three = ds.Tables[0].Rows[i]["Instrument"].ToString().Substring(0, 3);
                                int count1 = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                string id1 = ds.Tables[0].Rows[i]["DID"].ToString();
                                for (int k = 1; k <= count1; k++)
                                {
                                    string m = three + id1 + "" + k.ToString();
                                    Col = three + "" + id1 + "" + k + "" + " nvarchar(MAX)" + " " + String.Empty;
                                    res = checkcolun(tableName, m, Col);
                                }
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
                    strConnString.Close();
                }
            }
        }
    }
    [WebMethod]
    public static string getadmindesc(string Partno)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                SqlDataAdapter dapd = new SqlDataAdapter("Select distinct Partno,Description from tbl_PartNo where partno='" + Partno.ToString() + "'", strConnString);
                DataSet dspd = new DataSet();
                dapd.Fill(dspd);
                if (dspd.Tables[0].Rows.Count > 0)
                {
                    res = dspd.Tables[0].Rows[0]["Description"].ToString();
                }
                else
                {
                    res = "F";
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string getpartdesc()
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                string Partno = HttpContext.Current.Session["PartNo"].ToString();
                SqlDataAdapter dapd = new SqlDataAdapter("Select distinct Partno,Description from tbl_PartNo where partno='" + Partno.ToString() + "'", strConnString);
                DataSet dspd = new DataSet();
                dapd.Fill(dspd);
                if (dspd.Tables[0].Rows.Count > 0)
                {
                    res = dspd.Tables[0].Rows[0]["Description"].ToString();
                }
                else
                {
                    res = "F";
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string UpdateRejectValues(string ID, string Reject)
    {
        string tableName = "";
        string res = "";
        if (Reject == "1")
        {
            Reject = "1";
        }
        else
        {
            Reject = "0";
        }
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    string Partno = HttpContext.Current.Session["PartNo"].ToString();
                    string Opertaion = HttpContext.Current.Session["Operation"].ToString();
                    string Machine = HttpContext.Current.Session["machine"].ToString();
                    string Process = HttpContext.Current.Session["Process"].ToString();
                    string Cell = HttpContext.Current.Session["Depart"].ToString();
                    string Unit = HttpContext.Current.Session["Unit"].ToString();
                    tableName = "QualitySheet_" + Cell + "_" + Partno + "_" + Opertaion + "";
                    cmd = new SqlCommand("update " + tableName + "  set rejectedQty='" + Reject + "' where QSid='" + Convert.ToInt32(ID) + "'", strConnString);

                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";
                }
                finally
                {
                    if (strConnString.State == ConnectionState.Open)
                    {
                        strConnString.Close();
                    }
                    strConnString.Open();
                    cmd.ExecuteNonQuery();
                    strConnString.Close();
                    res = "S";
                    string Shift = HttpContext.Current.Session["Shift"].ToString();
                    da = new SqlDataAdapter("select count(*) as Accepet from " + tableName + " where rejectedQty='0' and CreateDate='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "' and QShift='" + Shift + "';select count(*) as Reject  from " + tableName + " where rejectedQty='1' and CreateDate='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "' and QShift='" + Shift + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            string accepet = ds.Tables[0].Rows[0]["Accepet"].ToString();
                            string reject = ds.Tables[1].Rows[0]["Reject"].ToString();
                            string Partno1 = HttpContext.Current.Session["PartNo"].ToString();
                            string Opertaion1 = HttpContext.Current.Session["Operation"].ToString();
                            string Machine1 = HttpContext.Current.Session["machine"].ToString();
                            string Process1 = HttpContext.Current.Session["Process"].ToString();
                            string Cell1 = HttpContext.Current.Session["Depart"].ToString();
                            string Unit1 = HttpContext.Current.Session["Unit"].ToString();
                            string Shift1 = HttpContext.Current.Session["Shift"].ToString();

                            //SqlCommand valcmd = new SqlCommand("saveproductionentry", strConnString);
                            //valcmd.CommandType = CommandType.StoredProcedure;

                            //valcmd.Parameters.Add("@partno", SqlDbType.VarChar, 10).Value = Partno1.ToString();
                            //valcmd.Parameters.Add("@operation", SqlDbType.VarChar, 10).Value = Opertaion1.ToString();
                            //valcmd.Parameters.Add("@unit", SqlDbType.VarChar, 10).Value = Unit1.ToString();
                            //valcmd.Parameters.Add("@date", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                            //valcmd.Parameters.Add("@shift", SqlDbType.VarChar, 10).Value = Shift1.ToString();
                            //valcmd.Parameters.Add("@produced", SqlDbType.VarChar, 10).Value = accepet.ToString();
                            //valcmd.Parameters.Add("@reject", SqlDbType.VarChar, 10).Value = reject.ToString();
                            //valcmd.Parameters.Add("@celltype", SqlDbType.VarChar, 10).Value = Cell1.ToString();
                            //valcmd.Parameters.Add("@month", SqlDbType.VarChar, 3).Value = DateTime.Now.Month.ToString();
                            //valcmd.Parameters.Add("@year", SqlDbType.VarChar, 15).Value = DateTime.Now.Year.ToString();
                            //valcmd.Parameters.Add("@time", SqlDbType.VarChar, 15).Value = DateTime.Now.ToShortTimeString().ToString();
                            //valcmd.Parameters.Add("@line", SqlDbType.VarChar, 15).Value = "";
                            //strConnString.Open();
                            //valcmd.ExecuteNonQuery();
                            //strConnString.Close();

                            string yesterday = "";
                            string Current = DateTime.Now.ToShortTimeString().ToString();
                            DateTime Tfrom = Convert.ToDateTime("22:00:00");
                            DateTime Tto = Convert.ToDateTime("06:00:00");
                            if (Shift1 == "C")
                            {
                                if (Convert.ToDateTime(Current) > Convert.ToDateTime(Tfrom) || Convert.ToDateTime(Current) < Convert.ToDateTime(Tto))
                                {
                                    if (Convert.ToDateTime(Current) >= Convert.ToDateTime("22:00:00") && Convert.ToDateTime(Current) <= Convert.ToDateTime("23:59:59"))
                                    {
                                        yesterday = DateTime.Now.ToShortDateString().ToString();
                                    }
                                    else
                                    {
                                        yesterday = DateTime.Now.AddDays(-1).ToShortDateString().ToString();
                                    }
                                }
                            }
                            SqlCommand valcmd = new SqlCommand("saveproduction", strConnString);
                            valcmd.CommandType = CommandType.StoredProcedure;

                            valcmd.Parameters.Add("@partno", SqlDbType.VarChar, 10).Value = Partno1.ToString();
                            valcmd.Parameters.Add("@process", SqlDbType.VarChar, 10).Value = Opertaion1.ToString();
                            valcmd.Parameters.Add("@unit", SqlDbType.VarChar, 10).Value = Unit1.ToString();
                            if (Shift1 == "C")
                            {
                                valcmd.Parameters.Add("@date", SqlDbType.VarChar, 10).Value = Convert.ToDateTime(yesterday).ToShortDateString().ToString();
                                valcmd.Parameters.Add("@month", SqlDbType.VarChar, 3).Value = Convert.ToDateTime(yesterday).Month.ToString();
                                valcmd.Parameters.Add("@year", SqlDbType.VarChar, 15).Value = Convert.ToDateTime(yesterday).Year.ToString();
                            }
                            else
                            {
                                valcmd.Parameters.Add("@date", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                                valcmd.Parameters.Add("@month", SqlDbType.VarChar, 3).Value = DateTime.Now.Month.ToString();
                                valcmd.Parameters.Add("@year", SqlDbType.VarChar, 15).Value = DateTime.Now.Year.ToString();
                            }

                            valcmd.Parameters.Add("@shift", SqlDbType.VarChar, 10).Value = Shift1.ToString();
                            valcmd.Parameters.Add("@celltype", SqlDbType.VarChar, 10).Value = Cell1.ToString();
                            valcmd.Parameters.Add("@time", SqlDbType.VarChar, 15).Value = DateTime.Now.ToShortTimeString().ToString();
                            valcmd.Parameters.Add("@line", SqlDbType.VarChar, 15).Value = "";
                            valcmd.Parameters.Add("@machine", SqlDbType.VarChar, 30).Value = Machine1.ToString();
                            pds.Tables.Clear();
                            pds.Clear();
                            pds.Reset();

                            if (Shift1 == "C")
                            {
                                pda = new SqlDataAdapter("select count(*) as Produced from " + "QualitySheet_" + Cell1.ToString() + "_" + Partno1.ToString() + "_" + Opertaion1.ToString() + " where Prdn_Name='" + Partno1.ToString() + "' and QShift='" + Shift1.ToString() + "' and (CONVERT(VARCHAR, QDate, 103))='" + Convert.ToDateTime(yesterday).ToShortDateString().ToString() + "' and MachineName='" + Machine1.ToString() + "' and rejectedQty=0", strConnString);
                            }
                            else
                            {
                                pda = new SqlDataAdapter("select count(*) as Produced from " + "QualitySheet_" + Cell1.ToString() + "_" + Partno1.ToString() + "_" + Opertaion1.ToString() + " where Prdn_Name='" + Partno1.ToString() + "' and QShift='" + Shift1.ToString() + "' and (CONVERT(VARCHAR, QDate, 103))='" + DateTime.Now.ToShortDateString().ToString() + "' and MachineName='" + Machine1.ToString() + "' and rejectedQty=0", strConnString);
                            }
                            pda.Fill(pds);
                            if (pds.Tables[0].Rows.Count > 0)
                            {
                                valcmd.Parameters.Add("@produced", SqlDbType.VarChar, 10).Value = pds.Tables[0].Rows[0]["Produced"].ToString();
                            }
                            else
                            {
                                valcmd.Parameters.Add("@produced", SqlDbType.VarChar, 10).Value = "0";
                            }
                            rds.Tables.Clear();
                            rds.Reset();
                            rds.Clear();
                            if (Shift1 == "C")
                            {
                                rda = new SqlDataAdapter("select count(*) as Reject from " + "QualitySheet_" + Cell1.ToString() + "_" + Partno1.ToString() + "_" + Opertaion1.ToString() + " where Prdn_Name='" + Partno1.ToString() + "' and QShift='" + Shift1.ToString() + "' and (CONVERT(VARCHAR, QDate, 103))='" + Convert.ToDateTime(yesterday).ToString() + "' and MachineName='" + Machine1.ToString() + "' and rejectedQty=1", strConnString);
                            }
                            else
                            {
                                rda = new SqlDataAdapter("select count(*) as Reject from " + "QualitySheet_" + Cell1.ToString() + "_" + Partno1.ToString() + "_" + Opertaion1.ToString() + " where Prdn_Name='" + Partno1.ToString() + "' and QShift='" + Shift1.ToString() + "' and (CONVERT(VARCHAR, QDate, 103))='" + DateTime.Now.ToShortDateString().ToString() + "' and MachineName='" + Machine1.ToString() + "' and rejectedQty=1", strConnString);
                            }
                            rda.Fill(rds);
                            if (rds.Tables[0].Rows.Count > 0)
                            {
                                valcmd.Parameters.Add("@reject", SqlDbType.VarChar, 5).Value = rds.Tables[0].Rows[0]["Reject"].ToString();
                            }
                            else
                            {
                                valcmd.Parameters.Add("@reject", SqlDbType.VarChar, 5).Value = "0";
                            }
                            strConnString.Close();
                            strConnString.Open();
                            valcmd.ExecuteNonQuery();
                            strConnString.Close();
                        }
                        catch (Exception ex)
                        {
                            ExceptionLogging.SendExcepToDB(ex);
                        }
                        finally
                        {
                            strConnString.Close();

                        }



                    }

                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }
    [WebMethod]
    public static string UpdateadminRejectValues(string ID, string Reject, string Partno, string Operation, string Unit, string Cell)
    {
        string tableName = "";
        string res = "";
        if (Reject == "1")
        {
            Reject = "1";
        }
        else
        {
            Reject = "0";
        }
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    string Partno1 = Partno.ToString();
                    string Opertaion1 = Operation.ToString();
                    string Cell1 = Cell.ToString();
                    string Unit1 = Unit.ToString();
                    tableName = "QualitySheet_" + Cell1 + "_" + Partno1 + "_" + Opertaion1 + "";
                    cmd = new SqlCommand("update " + tableName + "  set rejectedQty='" + Reject + "' where QSid='" + Convert.ToInt32(ID) + "'", strConnString);

                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    res = "F";
                }
                finally
                {
                    if (strConnString.State == ConnectionState.Open)
                    {
                        strConnString.Close();
                    }
                    strConnString.Open();
                    cmd.ExecuteNonQuery();
                    strConnString.Close();
                    res = "S";
                    //string Shift = HttpContext.Current.Session["Shift"].ToString();
                    //da = new SqlDataAdapter("select count(*) as Accepet from " + tableName + " where rejectedQty='0' and CreateDate='" + DateTime.Now.ToShortDateString().ToString() + "' and QShift='" + Shift + "';select count(*) as Reject  from " + tableName + " where rejectedQty='1' and CreateDate='" + DateTime.Now.ToShortDateString().ToString() + "' and QShift='" + Shift + "'", strConnString);
                    //ds = new DataSet();
                    //da.Fill(ds);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //try
                    //{
                    //    string accepet = ds.Tables[0].Rows[0]["Accepet"].ToString();
                    //    string reject = ds.Tables[1].Rows[0]["Reject"].ToString();
                    //    string Partno11 = Partno.ToString();
                    //    string Opertaion11 = Operation.ToString();
                    //    string Cell11 = Cell.ToString();
                    //    string Unit11 = Unit.ToString();
                    //    string Shift1 = HttpContext.Current.Session["Shift"].ToString();

                    //    SqlCommand valcmd = new SqlCommand("saveproductionentry", strConnString);
                    //    valcmd.CommandType = CommandType.StoredProcedure;

                    //    valcmd.Parameters.Add("@partno", SqlDbType.VarChar, 10).Value = Partno11.ToString();
                    //    valcmd.Parameters.Add("@operation", SqlDbType.VarChar, 10).Value = Opertaion11.ToString();
                    //    valcmd.Parameters.Add("@unit", SqlDbType.VarChar, 10).Value = Unit11.ToString();
                    //    valcmd.Parameters.Add("@date", SqlDbType.VarChar, 10).Value = DateTime.Now.ToShortDateString().ToString();
                    //    valcmd.Parameters.Add("@shift", SqlDbType.VarChar, 10).Value = Shift1.ToString();
                    //    valcmd.Parameters.Add("@produced", SqlDbType.VarChar, 10).Value = accepet.ToString();
                    //    valcmd.Parameters.Add("@reject", SqlDbType.VarChar, 10).Value = reject.ToString();
                    //    valcmd.Parameters.Add("@celltype", SqlDbType.VarChar, 10).Value = Cell11.ToString();
                    //    valcmd.Parameters.Add("@month", SqlDbType.VarChar, 3).Value = DateTime.Now.Month.ToString();
                    //    valcmd.Parameters.Add("@year", SqlDbType.VarChar, 15).Value = DateTime.Now.Year.ToString();
                    //    valcmd.Parameters.Add("@time", SqlDbType.VarChar, 15).Value = DateTime.Now.ToShortTimeString().ToString();
                    //    valcmd.Parameters.Add("@line", SqlDbType.VarChar, 15).Value = "";
                    //    strConnString.Open();
                    //    valcmd.ExecuteNonQuery();
                    //    strConnString.Close();
                    //}
                    //catch (Exception ex)
                    //{
                    //}
                    //finally
                    //{

                    //}



                    //}

                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }
    [WebMethod]
    public static Mastelink[] getmasterlink()
    {
        List<Mastelink> objm = new List<Mastelink>();
        Mastelink objmm = new Mastelink();
        lock (thisLock)
        {
            try
            {
                da = null;
                ds.Tables.Clear();
                da = new SqlDataAdapter("select distinct Partno,Operation,Cell from Dynmaster", strConnString);

                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        objmm = new Mastelink();
                        objmm.Partno = ds.Tables[0].Rows[i]["Partno"].ToString();
                        objmm.Operation = ds.Tables[0].Rows[i]["Operation"].ToString();
                        objmm.Cell = ds.Tables[0].Rows[i]["Cell"].ToString();
                        objm.Add(objmm);
                    }

                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objm.ToArray();
        }
    }
    [WebMethod]
    public static Getdata[] ReadExistinValues()
    {
        ////string res = "";
        List<Getdata> dbvalues = new List<Getdata>();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    try
                    {
                        string Partno = HttpContext.Current.Session["PartNo"].ToString();
                        string Opertaion = HttpContext.Current.Session["Operation"].ToString();
                        string Machine = HttpContext.Current.Session["machine"].ToString();
                        string Process = HttpContext.Current.Session["Process"].ToString();
                        string Cell = HttpContext.Current.Session["Depart"].ToString();
                        string Unit = HttpContext.Current.Session["Unit"].ToString();
                        string Shift = HttpContext.Current.Session["Shift"].ToString();

                        //string Shift = string.Empty;
                        //DateTime Ffrom = Convert.ToDateTime("06:00:00");
                        //DateTime Fto = Convert.ToDateTime("14:00:00");
                        //DateTime Sfrom = Convert.ToDateTime("14:00:00");
                        //DateTime Sto = Convert.ToDateTime("22:00:00");
                        //DateTime Tfrom = Convert.ToDateTime("22:00:00");
                        //DateTime Tto = Convert.ToDateTime("06:00:00").AddDays(1);
                        //string Current = DateTime.Now.ToShortTimeString().ToString();

                        //TimeSpan start = new TimeSpan(0, 0, 0); //0 o'clock
                        //TimeSpan end = new TimeSpan(6, 0, 0); //6 o'clock
                        //TimeSpan now = DateTime.Now.TimeOfDay;

                        //if ((now > start) && (now < end))
                        //{
                        //    Shift = "C";
                        //}
                        //else
                        //{
                        //    if (Convert.ToDateTime(Current) >= Ffrom && Convert.ToDateTime(Current) < Fto)
                        //    {
                        //        Shift = "A";
                        //    }
                        //    if (Convert.ToDateTime(Current) >= Sfrom && Convert.ToDateTime(Current) < Sto)
                        //    {
                        //        Shift = "B";
                        //    }
                        //    if (Convert.ToDateTime(Current) >= Tfrom && Convert.ToDateTime(Current) < Tto)
                        //    {
                        //        Shift = "C";
                        //    }
                        //}

                        string column1 = "";
                        string column = "";
                        string[] ColName_dbValue = new string[] { "" };
                        string tableName = "QualitySheet_" + Cell + "_" + Partno + "_" + Opertaion + "";
                        //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by DID", strConnString);
                        da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by ReorderMaster", strConnString);

                        ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            column = "CreateDate,QPidno,QShift,OPERATOR,SLNo,QHeatCode";
                            column1 = "CreateDate,QPidno,QShift,OPERATOR,SLNo,QHeatCode";
                            //column = "CONVERT(VARCHAR,Qdate,101) as CreateDate,QPidno,QShift,OPERATOR,SLNo,QHeatCode";
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                int count = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                string id = ds.Tables[0].Rows[i]["DID"].ToString();
                                if (ds.Tables[0].Rows[i]["CellValues"] != null && ds.Tables[0].Rows[i]["CellValues"].ToString() != "" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "0" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "-")
                                {
                                    for (int j = 1; j <= count; j++)
                                    {
                                        column = column + "," + "QMax_" + "" + id + "" + j;
                                        column = column + "," + "QMin_" + "" + id + "" + j;
                                        column1 = column1 + "," + "QMax_" + "" + id + "" + j;
                                        column1 = column1 + "," + "QMin_" + "" + id + "" + j;
                                    }
                                }
                                else
                                {
                                    string three = ds.Tables[0].Rows[i]["Instrument"].ToString().Substring(0, 3);
                                    int count1 = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                    string id1 = ds.Tables[0].Rows[i]["DID"].ToString();
                                    for (int k = 1; k <= count1; k++)
                                    {
                                        column = column + "," + three + "" + id1 + "" + k;
                                        column1 = column1 + "," + three + "" + id1 + "" + k;
                                    }
                                }

                            }
                            column += ",Comments,CONVERT(VARCHAR(8),Qtime,108) as Qtime,QSid";
                            column1 += ",Comments,Qtime,QSid";
                            ColName_dbValue = column1.Split(new char[] { ',' });
                        }
                        if (Shift != "C")
                        {
                            da = new SqlDataAdapter("select " + column + " from " + tableName + " where QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "'", strConnString);
                            ds = new DataSet();
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                int count = ColName_dbValue.Length;
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    Getdata objdata = new Getdata();
                                    objdata.arr_val = new string[count];
                                    for (int m = 0; m < ColName_dbValue.Length; m++)
                                    {
                                        objdata.arr_val[m] = ds.Tables[0].Rows[i][ColName_dbValue[m].ToString()].ToString();
                                    }
                                    dbvalues.Add(objdata);
                                }
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                            if (DateTime.Now.ToString("dd/MM/yyyy") == Convert.ToDateTime(HttpContext.Current.Session["LogDate"].ToString()).ToString("dd/MM/yyyy"))
                            {
                                da = new SqlDataAdapter("select " + column + " from " + tableName + " where QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "'", strConnString);
                                ds = new DataSet();
                                ds.Tables.Clear();
                                ds.Clear();
                                ds.Reset();
                                da.Fill(ds);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    int count = ColName_dbValue.Length;
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        Getdata objdata = new Getdata();
                                        objdata.arr_val = new string[count];
                                        for (int m = 0; m < ColName_dbValue.Length; m++)
                                        {
                                            objdata.arr_val[m] = ds.Tables[0].Rows[i][ColName_dbValue[m].ToString()].ToString();
                                        }
                                        dbvalues.Add(objdata);
                                    }
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                da = new SqlDataAdapter("select " + column + " from " + tableName + " where QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()).ToString("dd/MM/yyyy") + "'", strConnString);
                                ds = new DataSet();
                                ds.Tables.Clear();
                                ds.Clear();
                                ds.Reset();
                                da.Fill(ds);

                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    int count = ColName_dbValue.Length;
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        Getdata objdata = new Getdata();
                                        objdata.arr_val = new string[count];
                                        for (int m = 0; m < ColName_dbValue.Length; m++)
                                        {
                                            objdata.arr_val[m] = ds.Tables[0].Rows[i][ColName_dbValue[m].ToString()].ToString();
                                        }
                                        dbvalues.Add(objdata);
                                    }
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogging.SendExcepToDB(ex);
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
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage);
            }
            return dbvalues.ToArray();
        }
    }
    [WebMethod]
    public static Getdata[] ReadadminExistinValues(string Partno, string Operation, string Unit, string Cell, string Shift, string Date, string Machine, string Operator)
    {
        //string res = "";
        List<Getdata> dbvalues = new List<Getdata>();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    string Partno1 = Partno.ToString();
                    string Opertaion1 = Operation.ToString();
                    string Cell1 = Cell.ToString();
                    string Unit1 = Unit.ToString();
                    string column = "";
                    string column1 = "";
                    string[] ColName_dbValue = new string[] { "" };
                    string tableName = "QualitySheet_" + Cell1 + "_" + Partno1 + "_" + Opertaion1 + "";
                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno1 + "' and Operation='" + Opertaion1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno1 + "' and Operation='" + Opertaion1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' order by ReorderMaster", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        column = "CreateDate,QPidno,QShift,OPERATOR,SLNo,QHeatCode";
                        column1 = "CreateDate,QPidno,QShift,OPERATOR,SLNo,QHeatCode";
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                            string id = ds.Tables[0].Rows[i]["DID"].ToString();
                            if (ds.Tables[0].Rows[i]["CellValues"] != null && ds.Tables[0].Rows[i]["CellValues"].ToString() != "" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "0" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "-")
                            {
                                for (int j = 1; j <= count; j++)
                                {
                                    column = column + "," + "QMax_" + "" + id + "" + j;
                                    column = column + "," + "QMin_" + "" + id + "" + j;

                                    column1 = column1 + "," + "QMax_" + "" + id + "" + j;
                                    column1 = column1 + "," + "QMin_" + "" + id + "" + j;
                                }
                            }
                            else
                            {
                                string three = ds.Tables[0].Rows[i]["Instrument"].ToString().Substring(0, 3);
                                int count1 = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                string id1 = ds.Tables[0].Rows[i]["DID"].ToString();
                                for (int k = 1; k <= count1; k++)
                                {
                                    column = column + "," + three + "" + id1 + "" + k;
                                    column1 = column1 + "," + three + "" + id1 + "" + k;
                                }
                            }

                        }

                        column += ",Comments,CONVERT(VARCHAR(8),Qtime,108) as Qtime,QSid";
                        column1 += ",Comments,Qtime,QSid";
                        ColName_dbValue = column1.Split(new char[] { ',' });
                    }
                    //da = new SqlDataAdapter("select " + column + " from " + tableName + " where CreateDate='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "' and QShift='A'", strConnString);
                    da = new SqlDataAdapter("select " + column + " from " + tableName + " where CONVERT(VARCHAR,Qdate,103)='" + Date.ToString() + "' and QShift='" + Shift.ToString() + "' and MachineName ='" + Machine.ToString() + "'  and Operator ='" + Operator.ToString() + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = ColName_dbValue.Length;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Getdata objdata = new Getdata();
                            objdata.arr_val = new string[count];
                            for (int m = 0; m < ColName_dbValue.Length; m++)
                            {
                                objdata.arr_val[m] = ds.Tables[0].Rows[i][ColName_dbValue[m].ToString()].ToString();
                            }
                            dbvalues.Add(objdata);
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
            }
            return dbvalues.ToArray();
        }
    }
    [WebMethod]
    public static Getdata[] ReadadminExistinsearchValues(string Partno, string Operation, string Unit, string Cell, string Date, string Shift, string Machine, string Operator)
    {
        //string res = "";
        List<Getdata> dbvalues = new List<Getdata>();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    string Partno1 = Partno.ToString();
                    string Opertaion1 = Operation.ToString();
                    string Cell1 = Cell.ToString();
                    string Unit1 = Unit.ToString();
                    string column = "";
                    string column1 = "";
                    string[] ColName_dbValue = new string[] { "" };
                    string tableName = "QualitySheet_" + Cell1 + "_" + Partno1 + "_" + Opertaion1 + "";
                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno1 + "' and Operation='" + Opertaion1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno1 + "' and Operation='" + Opertaion1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' order by ReorderMaster", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        column = "CreateDate,QPidno,QShift,OPERATOR,SLNo,QHeatCode";
                        column1 = "CreateDate,QPidno,QShift,OPERATOR,SLNo,QHeatCode";
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                            string id = ds.Tables[0].Rows[i]["DID"].ToString();
                            if (ds.Tables[0].Rows[i]["CellValues"] != null && ds.Tables[0].Rows[i]["CellValues"].ToString() != "" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "0" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "-")
                            {
                                for (int j = 1; j <= count; j++)
                                {
                                    column = column + "," + "QMax_" + "" + id + "" + j;
                                    column = column + "," + "QMin_" + "" + id + "" + j;

                                    column1 = column1 + "," + "QMax_" + "" + id + "" + j;
                                    column1 = column1 + "," + "QMin_" + "" + id + "" + j;
                                }
                            }
                            else
                            {
                                string three = ds.Tables[0].Rows[i]["Instrument"].ToString().Substring(0, 3);
                                int count1 = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                string id1 = ds.Tables[0].Rows[i]["DID"].ToString();
                                for (int k = 1; k <= count1; k++)
                                {
                                    column = column + "," + three + "" + id1 + "" + k;
                                    column1 = column1 + "," + three + "" + id1 + "" + k;
                                }
                            }

                        }
                        //column += ",Comments,QSid";
                        //ColName_dbValue = column.Split(new char[] { ',' });

                        column += ",Comments,CONVERT(VARCHAR(8),Qtime,108) as Qtime,QSid";
                        column1 += ",Comments,Qtime,QSid";
                        ColName_dbValue = column1.Split(new char[] { ',' });
                    }

                    //            da = new SqlDataAdapter("select " + column + " from " + tableName + " where CreateDate= Convert(varchar,'" + Date + "',103) and QShift='" + Shift.ToString() + "'", strConnString);
                    da = new SqlDataAdapter("select " + column + " from " + tableName + " where CONVERT(VARCHAR,Qdate,103)= Convert(varchar,'" + Date + "',103) and QShift='" + Shift.ToString() + "' and MachineName='" + Machine.ToString() + "' and OPERATOR='" + Operator.ToString() + "'", strConnString);
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = ColName_dbValue.Length;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Getdata objdata = new Getdata();
                            objdata.arr_val = new string[count];
                            for (int m = 0; m < ColName_dbValue.Length; m++)
                            {
                                objdata.arr_val[m] = ds.Tables[0].Rows[i][ColName_dbValue[m].ToString()].ToString();
                            }
                            dbvalues.Add(objdata);
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }

            return dbvalues.ToArray();
        }
    }
    [WebMethod]
    public static string TxtbxSavevalues(string Texboxvalues, string Average1, string Max, string Min, string YMax, string YMin)
    {
        // string Partno = "A13152V";
        string results = "";
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    string Partno = HttpContext.Current.Session["PartNo"].ToString();
                    string Opertaion = HttpContext.Current.Session["Operation"].ToString();
                    string Machine = HttpContext.Current.Session["machine"].ToString();
                    string Process = HttpContext.Current.Session["Process"].ToString();
                    string Cell = HttpContext.Current.Session["Depart"].ToString();
                    string Unit = HttpContext.Current.Session["Unit"].ToString();
                    string tableName = "QualitySheet_" + Cell + "_" + Partno + "_" + Opertaion + "";

                    string column = "";
                    string Average = "";
                    Texboxvalues = Texboxvalues.Trim().TrimStart(',');
                    string[] TextboxVal = new string[] { "" };
                    TextboxVal = Texboxvalues.Split(new char[] { ',' });
                    string[] Avg1 = new string[] { "" };
                    Avg1 = Average1.Split(new char[] { ',' });
                    string strTxtBxVal = String.Empty;
                    string strAvgVal = String.Empty;
                    string strCmax = String.Empty;
                    string strCmin = String.Empty;
                    string strYmax = String.Empty;
                    string strYmin = String.Empty;
                    string strFieldname = String.Empty;
                    string C_max = "";
                    string C_min = "";
                    string Y_max = "";
                    string Y_min = "";
                    string[] Cmax = new string[] { "" };
                    Cmax = Max.Split(new char[] { ',' });
                    string[] Yemax = new string[] { "" };
                    Yemax = YMax.Split(new char[] { ',' });
                    string[] Cmin = new string[] { "" };
                    Cmin = Min.Split(new char[] { ',' });
                    string[] Yemin = new string[] { "" };
                    Yemin = YMin.Split(new char[] { ',' });
                    string Green = "";
                    string _Green = "";
                    string[] ColName_dbValue = new string[] { "" };
                    string[] Value_dbValue = new string[] { "" };


                    string QSshift = TextboxVal[2].ToString();
                    string QSshiftalert = string.Empty;
                    string Shift = string.Empty;
                    string Qdate = string.Empty;
                    string Logdate = string.Empty;
                    DateTime Ffrom = Convert.ToDateTime("06:00:00");
                    DateTime Fto = Convert.ToDateTime("14:00:00");
                    DateTime Sfrom = Convert.ToDateTime("14:00:00");
                    DateTime Sto = Convert.ToDateTime("22:00:00");
                    DateTime Tfrom = Convert.ToDateTime("22:00:00");
                    DateTime Tto = Convert.ToDateTime("06:00:00").AddDays(1);
                    string Current = DateTime.Now.ToShortTimeString().ToString();

                    TimeSpan start = new TimeSpan(0, 0, 0); //0 o'clock
                    TimeSpan end = new TimeSpan(6, 0, 0); //6 o'clock
                    TimeSpan now = DateTime.Now.TimeOfDay;

                    if ((now > start) && (now < end))
                    {
                        Shift = "C";
                        //Qdate = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddDays(-1);
                        Qdate = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()).ToString("MM/dd/yyyy");
                        //Logdate = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()).ToString("dd/MM/yyyy");
                        HttpContext.Current.Session["LogDate"] = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddDays(-1).ToShortDateString();
                    }
                    else
                    {
                        if (Convert.ToDateTime(Current) >= Ffrom && Convert.ToDateTime(Current) < Fto)
                        {
                            Shift = "A";

                        }
                        if (Convert.ToDateTime(Current) >= Sfrom && Convert.ToDateTime(Current) < Sto)
                        {
                            Shift = "B";
                        }
                        if (Convert.ToDateTime(Current) >= Tfrom && Convert.ToDateTime(Current) < Tto)
                        {
                            Shift = "C";
                        }

                        //Qdate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        // Qdate = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "MM/dd/yyyy", null);
                        Qdate = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy");
                        //Logdate = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy");
                        HttpContext.Current.Session["LogDate"] = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToShortDateString();
                    }
                    HttpContext.Current.Session["Shift"] = Shift.ToString();
                    //HttpContext.Current.Session["LogDate"] = Logdate.ToString();
                    TextboxVal[0] = Qdate.ToString();
                    TextboxVal[2] = Shift.ToString();
                    if (QSshift.ToString() != Shift.ToString())
                    {
                        QSshiftalert = Shift.ToString();
                    }

                    try
                    {
                        //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by DID", strConnString);
                        da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by ReorderMaster", strConnString);

                        ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            column = "QDate,QPidno,QShift,OPERATOR,SLNo,QHeatCode";
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                int count = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                string id = ds.Tables[0].Rows[i]["DID"].ToString();
                                if (ds.Tables[0].Rows[i]["CellValues"] != null && ds.Tables[0].Rows[i]["CellValues"].ToString() != "" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "0" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "-")
                                {
                                    for (int j = 1; j <= count; j++)
                                    {
                                        column = column + "," + "QMax_" + "" + id + "" + j;
                                        column = column + "," + "QMin_" + "" + id + "" + j;
                                        Average = Average + "," + "AverageD" + "" + id + "" + j;
                                        C_max = C_max + "," + "Chart_MaxD" + "" + id + "" + j;
                                        C_min = C_min + "," + "Chart_MinD" + "" + id + "" + j;
                                        Green = Green + "," + "Chart_G_MaxD" + "" + id + "" + j;
                                        Green = Green + "," + "Chart_G_MinD" + "" + id + "" + j;
                                        Y_max = Y_max + "," + "Chart_Y_MaxD" + "" + id + "" + j;
                                        Y_min = Y_min + "," + "Chart_Y_MinD" + "" + id + "" + j;
                                        _Green = _Green + "," + "0.00" + "," + "0.00";

                                    }
                                }
                                else
                                {
                                    string three = ds.Tables[0].Rows[i]["Instrument"].ToString().Substring(0, 3);
                                    int count1 = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                    string id1 = ds.Tables[0].Rows[i]["DID"].ToString();
                                    for (int k = 1; k <= count1; k++)
                                    {
                                        column = column + "," + three + "" + id1 + "" + k;
                                    }
                                }

                            }
                            column += ",Comments,MachineName,Prdn_Name,Unit,CreateDate,FixNo,Cell,Qtime,Month,Year";
                            column = column + Average + C_max + C_min + Y_max + Y_min + Green;
                            for (int i = 0; i < TextboxVal.Length; i++)
                            {
                                strTxtBxVal = strTxtBxVal + "," + "'" + TextboxVal[i] + "'" + String.Empty;
                                strTxtBxVal = strTxtBxVal.Trim().TrimStart(',');
                            }
                            for (int j = 1; j < Avg1.Length; j++)
                            {
                                strAvgVal = strAvgVal + "," + "'" + Avg1[j] + "'" + String.Empty;
                            }
                            for (int k = 1; k < Cmax.Length; k++)
                            {
                                strCmax = strCmax + "," + "'" + Cmax[k] + "'" + String.Empty;
                            }
                            for (int l = 1; l < Cmin.Length; l++)
                            {
                                strCmin = strCmin + "," + "'" + Cmin[l] + "'" + String.Empty;
                            }
                            for (int k = 1; k < Yemax.Length; k++)
                            {
                                strYmax = strYmax + "," + "'" + Yemax[k] + "'" + String.Empty;
                            }
                            for (int l = 1; l < Yemin.Length; l++)
                            {
                                strYmin = strYmin + "," + "'" + Yemin[l] + "'" + String.Empty;
                            }
                            strTxtBxVal = strTxtBxVal + "," + "'" + Machine.ToString() + "'" + "," + "'" + Partno.ToString() + "'" + "," + "'" + Unit.ToString() + "'" + "," + "'" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "'" + "," + "'" + HttpContext.Current.Session["FixNo"].ToString() + "'" + "," + "'" + HttpContext.Current.Session["Depart"].ToString() + "'" + "," + "'" + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + "'" + "," + "'" + DateTime.Now.Month.ToString() + "'" + "," + "'" + DateTime.Now.Year.ToString() + "'" + strAvgVal.ToString() + strCmax + strCmin + strYmax + strYmin + _Green;

                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogging.SendExcepToDB(ex);
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
                    }
                    try
                    {
                        InsertQuery = "INSERT INTO " + tableName.ToString() + " (" + column + ")VALUES (" + strTxtBxVal + ")";

                        SqlCommand cmd_insert = new SqlCommand(InsertQuery, strConnString);
                        if (strConnString.State == ConnectionState.Open)
                        {
                            strConnString.Close();
                        }
                        strConnString.Open();
                        cmd_insert.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogging.SendExcepToDB(ex);
                        results = "F";

                        Exception ex2 = ex;
                        string errorMessage = string.Empty;
                        while (ex2 != null)
                        {
                            errorMessage += ex2.ToString();
                            ex2 = ex2.InnerException;
                        }
                        HttpContext.Current.Response.Write(errorMessage);

                    }
                    finally { results = "S" + "," + QSshiftalert; }
                    strConnString.Close();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string shift = HttpContext.Current.Session["Shift"].ToString();
                        string date = DateTime.Now.ToShortDateString().ToString();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                            string id = ds.Tables[0].Rows[i]["DID"].ToString();
                            if (ds.Tables[0].Rows[i]["CellValues"] != null && ds.Tables[0].Rows[i]["CellValues"].ToString() != "" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "0" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "-")
                            {
                                for (int j = 1; j <= count; j++)
                                {
                                    string Sheet = "";
                                    string Values = "";
                                    string max = "QMax_" + "" + id + "" + j;
                                    string min = "QMin_" + "" + id + "" + j;
                                    Average = "AverageD" + "" + id + "" + j;
                                    Sheet = Sheet + "," + "Chart_CPD" + "" + id + "" + j;
                                    Sheet = Sheet + "," + "Chart_CPKD" + "" + id + "" + j;
                                    Sheet = Sheet + "," + "Chart_DeviationD" + "" + id + "" + j;

                                    da1 = new SqlDataAdapter("select sum(" + Average + ") as Average from " + tableName + " where  CreateDate='" + Convert.ToDateTime(date).ToString("dd/MM/yyyy") + "' and QShift='" + shift + "';select max(" + Average + ") as MaxAverage from " + tableName + " where  CreateDate='" + Convert.ToDateTime(date).ToString("dd/MM/yyyy") + "' and QShift='" + shift + "';select min(" + Average + ") as MinAverage from " + tableName + " where  CreateDate='" + Convert.ToDateTime(date).ToString("dd/MM/yyyy") + "' and QShift='" + shift + "';select max(" + max + ")as Max from " + tableName + " where  CreateDate='" + Convert.ToDateTime(date).ToString("dd/MM/yyyy") + "' and QShift='" + shift + "';select min(" + min + ")as Min from " + tableName + " where  CreateDate='" + Convert.ToDateTime(date).ToString("dd/MM/yyyy") + "' and QShift='" + shift + "';select count(*) as rowcoun from " + tableName + " where CreateDate='" + Convert.ToDateTime(date).ToString("dd/MM/yyyy") + "' and QShift='" + shift + "'", strConnString);
                                    ds1 = new DataSet();
                                    da1.Fill(ds1);
                                    if (ds1.Tables[0].Rows.Count > 0)
                                    {
                                        double TotAvg = Convert.ToDouble(ds1.Tables[0].Rows[0]["Average"]);
                                        double MAvg = Convert.ToDouble(ds1.Tables[1].Rows[0]["MaxAverage"]);
                                        double MiAvg = Convert.ToDouble(ds1.Tables[2].Rows[0]["MinAverage"]);
                                        int TotRow = Convert.ToInt32(ds1.Tables[5].Rows[0]["rowcoun"]);
                                        if (Convert.ToString(ds1.Tables[3].Rows[0]["Max"]).ToString() == "-")
                                        {
                                            ds1.Tables[3].Rows[0]["Max"] = 0;
                                        }
                                        if (Convert.ToString(ds1.Tables[4].Rows[0]["Min"]).ToString() == "-")
                                        {
                                            ds1.Tables[4].Rows[0]["Min"] = 0;
                                        }
                                        double Maxval = Convert.ToDouble(ds1.Tables[3].Rows[0]["Max"]);
                                        double Minval = Convert.ToDouble(ds1.Tables[4].Rows[0]["Min"]);
                                        double xbar = TotAvg / TotRow;
                                        xminxbar = (MAvg - xbar) * (MAvg - xbar) / (TotRow - 1);
                                        if (xminxbar > 0)
                                        {
                                            standart = Math.Sqrt(xminxbar);

                                            cp = ((Convert.ToDouble(Maxval)) - (Convert.ToDouble(Minval))) / (6 * standart);
                                            CP = Convert.ToDecimal(cp);
                                            double cpk1 = ((Convert.ToDouble(Maxval)) - (xbar)) / (3 * standart);
                                            double cpk2 = ((xbar) - Convert.ToDouble(Minval)) / (3 * standart);
                                            if (cpk1 > cpk2)
                                            {
                                                CPK = (Convert.ToDecimal(cpk2));

                                            }
                                            else
                                            {
                                                CPK = (Convert.ToDecimal(cpk1));
                                            }

                                            double rang = MAvg - MiAvg;
                                            Range = Convert.ToDecimal(rang);

                                            Standardeviation = Convert.ToDecimal(standart);
                                            Values = Values + "," + CP + "," + CPK + "," + Standardeviation;
                                            ColName_dbValue = Sheet.Split(new char[] { ',' });
                                            Value_dbValue = Values.Split(new char[] { ',' });
                                            int m = 1;
                                            string update = "";
                                            for (int z = 1; z < ColName_dbValue.Length; z++)
                                            {
                                                string colunm = ColName_dbValue[z].ToString();
                                                string value = Value_dbValue[m].ToString();
                                                update = update + "" + colunm + "=" + value.ToString() + ",";
                                                m++;
                                            }
                                            try
                                            {
                                                update = update.TrimEnd(',');
                                                SqlCommand cmd_insert = new SqlCommand("update " + tableName.ToString() + " set " + update + "where CreateDate='" + Convert.ToDateTime(date).ToString("dd/MM/yyyy") + "' and QShift='" + shift + "'", strConnString);
                                                if (strConnString.State == ConnectionState.Open)
                                                {
                                                    strConnString.Close();
                                                }
                                                strConnString.Open();
                                                cmd_insert.ExecuteNonQuery();
                                                strConnString.Close();
                                                results = "S";
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
                                            finally
                                            {
                                                strConnString.Close();
                                            }
                                        }
                                        else
                                        {
                                            int m = 1;
                                            string update = "";
                                            ColName_dbValue = Sheet.Split(new char[] { ',' });
                                            for (int z = 1; z < ColName_dbValue.Length; z++)
                                            {
                                                string colunm = ColName_dbValue[z].ToString();
                                                string value = "0.00";
                                                update = update + "" + colunm + "=" + value.ToString() + ",";
                                                m++;
                                            }
                                            try
                                            {
                                                update = update.TrimEnd(',');
                                                SqlCommand cmd_insert = new SqlCommand("update " + tableName.ToString() + " set " + update + "where CreateDate='" + Convert.ToDateTime(date).ToString("dd/MM/yyyy") + "' and QShift='" + shift + "'", strConnString);
                                                if (strConnString.State == ConnectionState.Open)
                                                {
                                                    strConnString.Close();
                                                }
                                                strConnString.Open();
                                                cmd_insert.ExecuteNonQuery();
                                                strConnString.Close();
                                                results = "S";
                                            }
                                            catch (Exception ex)
                                            {
                                                ExceptionLogging.SendExcepToDB(ex);
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
                                                strConnString.Close();
                                            }
                                        }
                                    }
                                    else
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage);

            }
            finally { strConnString.Close(); }
        }
        return results.ToString();
    }
    [WebMethod]
    public static string TxtbxUpdatevalues(string Texboxvalues, string Average1, string ID)
    {
        string Partno = HttpContext.Current.Session["PartNo"].ToString();
        string Opertaion = HttpContext.Current.Session["Operation"].ToString();
        string Machine = HttpContext.Current.Session["machine"].ToString();
        string Process = HttpContext.Current.Session["Process"].ToString();
        string Cell = HttpContext.Current.Session["Depart"].ToString();
        string Unit = HttpContext.Current.Session["Unit"].ToString();
        string tableName = "QualitySheet_" + Cell + "_" + Partno + "_" + Opertaion + "";
        string results = "";
        string column = "";
        string Average = "";
        Texboxvalues = Texboxvalues.Trim().TrimStart(',');
        string[] ColName_dbValue = new string[] { "" };
        string[] Value_dbValue = new string[] { "" };
        string[] TextboxVal = new string[] { "" };
        TextboxVal = Texboxvalues.Split(new char[] { ',' });
        string[] Avg1 = new string[] { "" };
        Avg1 = Average1.Split(new char[] { ',' });
        string strTxtBxVal = String.Empty;
        string strAvgVal = "";
        string strFieldname = String.Empty;
        lock (thisLock)
        {
            try
            {
                // string Partno = "A13152V";

                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by ReorderMaster", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //column = "QDate,QShift,OPERATOR";
                        column = "QShift,OPERATOR";
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                            string id = ds.Tables[0].Rows[i]["DID"].ToString();
                            if (ds.Tables[0].Rows[i]["CellValues"] != null && ds.Tables[0].Rows[i]["CellValues"].ToString() != "" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "0" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "-")
                            {
                                for (int j = 1; j <= count; j++)
                                {
                                    column = column + "," + "QMax_" + "" + id + "" + j;
                                    column = column + "," + "QMin_" + "" + id + "" + j;
                                    Average = Average + "," + "AverageD" + "" + id + "" + j;
                                }
                            }
                            else
                            {
                                string three = ds.Tables[0].Rows[i]["Instrument"].ToString().Substring(0, 3);
                                int count1 = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                string id1 = ds.Tables[0].Rows[i]["DID"].ToString();
                                for (int k = 1; k <= count1; k++)
                                {
                                    column = column + "," + three + "" + id1 + "" + k;
                                }
                            }

                        }
                        column += ",Comments,MachineName,Prdn_Name,Unit";
                        column = column + Average;
                        for (int i = 0; i < TextboxVal.Length; i++)
                        {
                            strTxtBxVal = strTxtBxVal + "," + "'" + TextboxVal[i] + "'" + String.Empty;
                            strTxtBxVal = strTxtBxVal.Trim().TrimStart(',');
                        }
                        for (int j = 1; j < Avg1.Length; j++)
                        {
                            strAvgVal = strAvgVal + "," + "'" + Avg1[j] + "'" + String.Empty;

                        }
                        strTxtBxVal = strTxtBxVal + "," + "'" + Machine.ToString() + "'" + "," + "'" + Partno.ToString() + "'" + "," + "'" + Unit.ToString() + "'" + strAvgVal.ToString();
                        ColName_dbValue = column.Split(new char[] { ',' });
                        Value_dbValue = strTxtBxVal.Split(new char[] { ',' });
                    }
                    try
                    {
                        int m = 0;
                        string update = "";
                        for (int i = 0; i < ColName_dbValue.Length; i++)
                        {
                            string colunm = ColName_dbValue[i].ToString();
                            string value = Value_dbValue[m].ToString();
                            update = update + "" + colunm + "=" + value.ToString() + ",";
                            m++;
                        }
                        try
                        {
                            update = update.TrimEnd(',');
                            int id = Convert.ToInt32(ID.ToString());
                            SqlCommand cmd_insert = new SqlCommand("update " + tableName.ToString() + " set " + update + "where QSid='" + id + "'", strConnString);
                            if (strConnString.State == ConnectionState.Open)
                            {
                                strConnString.Close();
                            }
                            strConnString.Open();
                            cmd_insert.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            ExceptionLogging.SendExcepToDB(ex);
                        }
                        finally
                        {
                            strConnString.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogging.SendExcepToDB(ex);
                        results = "F";
                    }
                    finally { results = "S"; }
                    strConnString.Close();
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                strConnString.Close();
            }
        }
        return results.ToString();
    }
    [WebMethod]
    public static string TxtbxadminUpdatevalues(string Pidno, string Sno, string Code, string Texboxvalues, string Average1, string ID, string Partno, string Operation, string Unit, string Cell)
    {
        string Partno1 = Partno.ToString();
        string Opertaion1 = Operation.ToString();
        string Cell1 = Cell.ToString();
        string Unit1 = Unit.ToString();
        string tableName = "QualitySheet_" + Cell1 + "_" + Partno1 + "_" + Opertaion1 + "";
        string results = "";
        string column = "";
        string Average = "";
        Texboxvalues = Texboxvalues.Trim().TrimStart(',');
        string[] ColName_dbValue = new string[] { "" };
        string[] Value_dbValue = new string[] { "" };
        string[] TextboxVal = new string[] { "" };
        TextboxVal = Texboxvalues.Split(new char[] { ',' });
        string[] Avg1 = new string[] { "" };
        Avg1 = Average1.Split(new char[] { ',' });
        string strTxtBxVal = String.Empty;
        string strAvgVal = "";
        string strFieldname = String.Empty;
        lock (thisLock)
        {
            try
            {
                // string Partno = "A13152V";

                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno1 + "' and Operation='" + Opertaion1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno1 + "' and Operation='" + Opertaion1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' order by ReorderMaster", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //column = "QPidno,SLNo,QHeatCode";
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                            string id = ds.Tables[0].Rows[i]["DID"].ToString();
                            if (ds.Tables[0].Rows[i]["CellValues"] != null && ds.Tables[0].Rows[i]["CellValues"].ToString() != "" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "0" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "-")
                            {
                                for (int j = 1; j <= count; j++)
                                {
                                    column = column + "," + "QMax_" + "" + id + "" + j;
                                    column = column + "," + "QMin_" + "" + id + "" + j;
                                    Average = Average + "," + "AverageD" + "" + id + "" + j;
                                }
                            }
                            else
                            {
                                string three = ds.Tables[0].Rows[i]["Instrument"].ToString().Substring(0, 3);
                                int count1 = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                string id1 = ds.Tables[0].Rows[i]["DID"].ToString();
                                for (int k = 1; k <= count1; k++)
                                {
                                    column = column + "," + three + "" + id1 + "" + k;
                                }
                            }

                        }
                        column += ",Comments,Prdn_Name,Unit";
                        column = column + Average;
                        for (int i = 0; i < TextboxVal.Length; i++)
                        {
                            strTxtBxVal = strTxtBxVal + "," + "'" + TextboxVal[i] + "'" + String.Empty;
                            strTxtBxVal = strTxtBxVal.Trim().TrimStart(',');
                        }
                        for (int j = 1; j < Avg1.Length; j++)
                        {
                            strAvgVal = strAvgVal + "," + "'" + Avg1[j] + "'" + String.Empty;

                        }
                        strTxtBxVal = strTxtBxVal + "," + "'" + Partno1.ToString() + "'" + "," + "'" + Unit1.ToString() + "'" + strAvgVal.ToString();
                        ColName_dbValue = column.Split(new char[] { ',' });
                        Value_dbValue = strTxtBxVal.Split(new char[] { ',' });
                    }
                    try
                    {
                        int m = 0;
                        string update = "";
                        update = "QPidno='" + Pidno.ToString() + "',SLNo='" + Sno.ToString() + "',QHeatCode='" + Code.ToString() + "',";
                        for (int i = 1; i < ColName_dbValue.Length; i++)
                        {
                            string colunm = ColName_dbValue[i].ToString();
                            string value = Value_dbValue[m].ToString();
                            update = update + "" + colunm + "=" + value.ToString() + ",";
                            m++;
                        }
                        try
                        {
                            update = update.TrimEnd(',');
                            int id = Convert.ToInt32(ID.ToString());
                            SqlCommand cmd_insert = new SqlCommand("update " + tableName.ToString() + " set " + update + "where QSid='" + id + "'", strConnString);


                            strConnString.Close();
                            strConnString.Open();
                            cmd_insert.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            ExceptionLogging.SendExcepToDB(ex);
                        }
                        finally
                        {
                            strConnString.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogging.SendExcepToDB(ex);
                        results = "F";
                    }
                    finally { results = "S"; }
                    strConnString.Close();
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                strConnString.Close();
            }
        }
        return results.ToString();
    }
    [WebMethod]
    public static Rowcount[] getrowcount()
    {
        List<Rowcount> objr = new List<Rowcount>();
        Rowcount objrr = new Rowcount();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {

                    string Partno = HttpContext.Current.Session["PartNo"].ToString();
                    string Opertaion = HttpContext.Current.Session["Operation"].ToString();
                    string Machine = HttpContext.Current.Session["machine"].ToString();
                    string Process = HttpContext.Current.Session["Process"].ToString();
                    string Cell = HttpContext.Current.Session["Depart"].ToString();
                    string Unit = HttpContext.Current.Session["Unit"].ToString();
                    string Shift = HttpContext.Current.Session["Shift"].ToString();
                    string tableName = "QualitySheet_" + Cell + "_" + Partno + "_" + Opertaion + "";

                    if (Shift != "C")
                    {
                        da = new SqlDataAdapter("select count(*) as row_count from " + tableName + " where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "';select count(*) as rej_count from " + tableName + "  where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "' and rejectedQty='1';select count(*) as acc_count from " + tableName + "  where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "' and rejectedQty='0' ", strConnString);
                        ds = new DataSet();
                        ds.Tables.Clear();
                        ds.Clear();
                        ds.Reset();
                        da.Fill(ds);
                    }
                    else
                    {
                        if (DateTime.Now.ToString("dd/MM/yyyy") == Convert.ToDateTime(HttpContext.Current.Session["LogDate"].ToString()).ToString("dd/MM/yyyy"))
                        {
                            //da = new SqlDataAdapter("select count(*) as row_count from " + tableName + " where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "';select count(*) as rej_count from " + tableName + "  where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "' and rejectedQty='1';select count(*) as acc_count from " + tableName + "  where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "' and rejectedQty='0' ", strConnString);

                            string today = Convert.ToDateTime(DateTime.Now.ToShortDateString()).Year.ToString() + "/" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).Month.ToString("00") + "/" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).Day.ToString("00");

                            da = new SqlDataAdapter("select count(*) as row_count from " + tableName + " where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,111)=CONVERT(VARCHAR, '" + today + "', 111);select count(*) as rej_count from " + tableName + "  where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,111)=CONVERT(VARCHAR, '" + today + "', 111) and rejectedQty='1';select count(*) as acc_count from " + tableName + "  where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,111)=CONVERT(VARCHAR, '" + today + "', 111) and rejectedQty='0' ", strConnString);

                            ds = new DataSet();
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();
                            da.Fill(ds);
                        }
                        else
                        {
                            //da = new SqlDataAdapter("select count(*) as row_count from " + tableName + " where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()).ToString("dd/MM/yyyy") + "';select count(*) as rej_count from " + tableName + "  where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()).ToString("dd/MM/yyyy") + "' and rejectedQty='1';select count(*) as acc_count from " + tableName + "  where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()).ToString("dd/MM/yyyy") + "' and rejectedQty='0' ", strConnString);

                            //string yesterday = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()).Year.ToString() + "/" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).Month.ToString("00") + "/" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).Day.ToString("00");

                            string yesterday = Convert.ToDateTime(HttpContext.Current.Session["LogDate"].ToString()).ToString("yyyy/MM/dd");

                            da = new SqlDataAdapter("select count(*) as row_count from " + tableName + " where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,111)=CONVERT(VARCHAR, '" + yesterday + "', 111);select count(*) as rej_count from " + tableName + "  where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,111)=CONVERT(VARCHAR, '" + yesterday + "', 111) and rejectedQty='1';select count(*) as acc_count from " + tableName + "  where Prdn_Name='" + Partno + "' and QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,111)=CONVERT(VARCHAR, '" + yesterday + "', 111) and rejectedQty='0' ", strConnString);

                            ds = new DataSet();
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();
                            da.Fill(ds);
                        }
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objrr.Accept = ds.Tables[0].Rows[0]["row_count"].ToString();
                    }
                    else
                    {
                        objrr.Accept = "0";
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objrr.Reject = ds.Tables[1].Rows[0]["rej_count"].ToString();
                    }
                    else
                    {
                        objrr.Reject = "0";
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        objrr._Accept = ds.Tables[2].Rows[0]["acc_count"].ToString();
                    }
                    else
                    {
                        objrr._Accept = "0";
                    }
                    objr.Add(objrr);
                }
                else
                {
                    objrr.Accept = "F";
                    objr.Add(objrr);
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage);
            }
            return objr.ToArray();
        }
    }
    [WebMethod]
    public static Rowcount[] getadminrowcount(string Partno, string Operation, string Unit, string Cell, string Shift, string Date, string Machine, string Operator)
    {
        List<Rowcount> objr = new List<Rowcount>();
        Rowcount objrr = new Rowcount();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {

                    string Partno1 = Partno.ToString();
                    string Opertaion1 = Operation.ToString();
                    string Cell1 = Cell.ToString();
                    string Unit1 = Unit.ToString();
                    string tableName = "QualitySheet_" + Cell1 + "_" + Partno1 + "_" + Opertaion1 + "";
                    //da = new SqlDataAdapter("select count(*) as row_count from " + tableName + " where Prdn_Name='" + Partno1 + "'  and CreateDate='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "';select count(*) as rej_count from " + tableName + "  where Prdn_Name='" + Partno1 + "' and CreateDate='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "' and rejectedQty='1';select count(*) as acc_count from " + tableName + "  where Prdn_Name='" + Partno1 + "' and CreateDate='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "' and rejectedQty='0' ", strConnString);
                    da = new SqlDataAdapter("select count(*) as row_count from " + tableName + " where Prdn_Name='" + Partno1 + "'  and CONVERT(VARCHAR,Qdate,103)='" + Date.ToString() + "' and QShift='" + Shift.ToString() + "' and MachineName='" + Machine.ToString() + "' and OPERATOR='" + Operator.ToString() + "';select count(*) as rej_count from " + tableName + "  where Prdn_Name='" + Partno1 + "' and CONVERT(VARCHAR,Qdate,103)='" + Date.ToString() + "' and QShift='" + Shift.ToString() + "' and rejectedQty='1' and MachineName='" + Machine.ToString() + "' and OPERATOR='" + Operator.ToString() + "';select count(*) as acc_count from " + tableName + "  where Prdn_Name='" + Partno1 + "' and CONVERT(VARCHAR,Qdate,103)='" + Date.ToString() + "' and QShift='" + Shift.ToString() + "' and rejectedQty='0' and MachineName='" + Machine.ToString() + "' and OPERATOR='" + Operator.ToString() + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objrr.Accept = ds.Tables[0].Rows[0]["row_count"].ToString();
                    }
                    else
                    {
                        objrr.Accept = "0";
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objrr.Reject = ds.Tables[1].Rows[0]["rej_count"].ToString();
                    }
                    else
                    {
                        objrr.Reject = "0";
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        objrr._Accept = ds.Tables[2].Rows[0]["acc_count"].ToString();
                    }
                    else
                    {
                        objrr._Accept = "0";
                    }
                    objr.Add(objrr);
                }
                else
                {
                    objrr.Accept = "F";
                    objr.Add(objrr);
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objr.ToArray();
        }
    }
    [WebMethod]
    public static Rowcount[] getadminsrchrowcount(string Partno, string Operation, string Unit, string Cell, string Date, string Shift, string Machine, string Operator)
    {
        List<Rowcount> objr = new List<Rowcount>();
        Rowcount objrr = new Rowcount();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {

                    string Partno1 = Partno.ToString();
                    string Opertaion1 = Operation.ToString();
                    string Cell1 = Cell.ToString();
                    string Unit1 = Unit.ToString();
                    string tableName = "QualitySheet_" + Cell1 + "_" + Partno1 + "_" + Opertaion1 + "";
                    //da = new SqlDataAdapter("select count(*) as row_count from " + tableName + " where Prdn_Name='" + Partno1 + "'  and CreateDate='" + Convert.ToDateTime(Date).ToString("dd/MM/yyyy") + "';select count(*) as rej_count from " + tableName + "  where Prdn_Name='" + Partno1 + "' and CreateDate='" + Convert.ToDateTime(Date).ToString("dd/MM/yyyy") + "' and rejectedQty='1';select count(*) as acc_count from " + tableName + "  where Prdn_Name='" + Partno1 + "' and CreateDate='" + Convert.ToDateTime(Date).ToString("dd/MM/yyyy") + "' and rejectedQty='0' ", strConnString);
                    da = new SqlDataAdapter("select count(*) as row_count from " + tableName + " where Prdn_Name='" + Partno1 + "'  and CONVERT(VARCHAR,Qdate,103)='" + Date.ToString() + "' and QShift='" + Shift.ToString() + "' and MachineName='" + Machine.ToString() + "' and OPERATOR='" + Operator.ToString() + "';select count(*) as rej_count from " + tableName + "  where Prdn_Name='" + Partno1 + "' and CONVERT(VARCHAR,Qdate,103)='" + Date.ToString() + "' and QShift='" + Shift.ToString() + "' and rejectedQty='1' and MachineName='" + Machine.ToString() + "' and OPERATOR='" + Operator.ToString() + "';select count(*) as acc_count from " + tableName + "  where Prdn_Name='" + Partno1 + "' and CONVERT(VARCHAR,Qdate,103)='" + Date.ToString() + "' and QShift='" + Shift.ToString() + "' and rejectedQty='0' and MachineName='" + Machine.ToString() + "' and OPERATOR='" + Operator.ToString() + "'", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objrr.Accept = ds.Tables[0].Rows[0]["row_count"].ToString();
                    }
                    else
                    {
                        objrr.Accept = "0";
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objrr.Reject = ds.Tables[1].Rows[0]["rej_count"].ToString();
                    }
                    else
                    {
                        objrr.Reject = "0";
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        objrr._Accept = ds.Tables[2].Rows[0]["acc_count"].ToString();
                    }
                    else
                    {
                        objrr._Accept = "0";
                    }
                    objr.Add(objrr);
                }
                else
                {
                    objrr.Accept = "F";
                    objr.Add(objrr);
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objr.ToArray();
        }
    }
    [WebMethod]
    public static string getcount()
    {
        int res = 0;
        string Partno = HttpContext.Current.Session["PartNo"].ToString();
        string Opertaion = HttpContext.Current.Session["Operation"].ToString();
        string Machine = HttpContext.Current.Session["machine"].ToString();
        string Process = HttpContext.Current.Session["Process"].ToString();
        string Cell = HttpContext.Current.Session["Depart"].ToString();
        string Unit = HttpContext.Current.Session["Unit"].ToString();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by ReorderMaster", strConnString);

                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Getdata objdata = new Getdata();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i]["CellValues"] == null || ds.Tables[0].Rows[i]["CellValues"].ToString() == "" || ds.Tables[0].Rows[i]["CellValues"].ToString() == "0")
                            {
                                res = res + Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                            }
                        }

                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string getadmincount(string Partno, string Operation, string Unit, string Cell)
    {
        int res = 0;
        string Partno1 = Partno.ToString();
        string Opertaion1 = Operation.ToString();
        string Cell1 = Cell.ToString();
        string Unit1 = Unit.ToString();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    //da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno1 + "' and Operation='" + Opertaion1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' order by DID", strConnString);
                    da = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno1 + "' and Operation='" + Opertaion1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' order by ReorderMaster", strConnString);
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Getdata objdata = new Getdata();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i]["CellValues"] == null || ds.Tables[0].Rows[i]["CellValues"].ToString() == "" || ds.Tables[0].Rows[i]["CellValues"].ToString() == "0" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "-")
                            {
                                res = res + Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                            }
                        }

                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();
        }
    }
    public static void createfolder(string pidno)
    {
        DirectoryInfo dirifo = new DirectoryInfo(path);
        dirifo.CreateSubdirectory(pidno.ToString());
    }
    [WebMethod]
    public static string export(string Texboxvalues)
    {
        string res = "";
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    string Partno = HttpContext.Current.Session["PartNo"].ToString();
                    string pidno = HttpContext.Current.Session["PID_ID"].ToString();
                    string Shift = HttpContext.Current.Session["Shift"].ToString();
                    path = HttpContext.Current.Request.PhysicalApplicationPath + "Document\\" + Partno.ToString() + "\\";
                    createfolder(pidno);
                    string html = Texboxvalues.ToString();
                    html = html.Replace("&gt;", ">");
                    html = html.Replace("&lt;", "<");
                    string filenamerp = "";
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "QCSheet.xls"));
                    HttpContext.Current.Response.ContentType = "application/ms-excel";
                    string date = DateTime.Now.ToString("MM-dd-yyyy");
                    string kail = "QS_Report_" + date.ToString() + "_" + Partno.ToString() + Shift.ToString() + ".xls";
                    filenamerp = kail;
                    HttpContext.Current.Session["WorkingFile"] = filenamerp.ToString();
                    string path1 = HttpContext.Current.Server.MapPath("~/Document/" + Partno.ToString() + "\\" + pidno.ToString() + "\\" + HttpContext.Current.Session["WorkingFile"].ToString());
                    //string path1 = Server.MapPath("~/Document/A17724Q" + "\\" + Pidno.ToString());

                    FileInfo file = new FileInfo(path1);
                    if (file.Exists)//check file exsit or not
                    {
                        file.Delete();
                        path = HttpContext.Current.Server.MapPath("~/Document/" + Partno.ToString() + "\\" + pidno.ToString() + "\\");
                        File.AppendAllText(path + HttpContext.Current.Session["WorkingFile"].ToString(), html.ToString());
                    }
                    else
                    {
                        path = HttpContext.Current.Server.MapPath("~/Document/" + Partno.ToString() + "\\" + pidno.ToString() + "\\");
                        File.AppendAllText(path + HttpContext.Current.Session["WorkingFile"].ToString(), html.ToString());
                    }


                    // HttpContext.Current.Response.Write(html);
                    // HttpContext.Current.Response.End();
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                    // throw ex;
                    res = "F";
                }
                finally
                {
                    res = "S";
                    strConnString.Close();
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }
    [WebMethod]
    public static string Updaecellsatuas(string Status)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                string Partno = HttpContext.Current.Session["PartNo"].ToString();
                string Shift = HttpContext.Current.Session["Shift"].ToString();
                string Process = HttpContext.Current.Session["Operation"].ToString();
                string Cell = HttpContext.Current.Session["Depart"].ToString();
                string Unit = HttpContext.Current.Session["Unit"].ToString();
                if (Process == "OP1")
                {
                    Process = "1";
                }
                else if (Process == "OP2")
                {
                    Process = "2";
                }


                cmd = new SqlCommand("updatecellstaus", strConnString);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@status", SqlDbType.VarChar, 30).Value = Status.ToString();
                cmd.Parameters.Add("@cell", SqlDbType.VarChar, 30).Value = Cell.ToString();
                cmd.Parameters.Add("@unit", SqlDbType.VarChar, 30).Value = Unit.ToString();
                cmd.Parameters.Add("@shift", SqlDbType.VarChar, 30).Value = Shift.ToString();
                cmd.Parameters.Add("@partno", SqlDbType.VarChar, 50).Value = Partno.ToString();
                cmd.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = Process.ToString();
                cmd.Parameters.Add("@date", SqlDbType.VarChar, 30).Value = DateTime.Now.ToShortDateString().ToString();


            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                res = "S";
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string SelectStatus()
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                string Partno = HttpContext.Current.Session["PartNo"].ToString();
                string Shift = HttpContext.Current.Session["Shift"].ToString();
                string Process = HttpContext.Current.Session["Operation"].ToString();
                string Cell = HttpContext.Current.Session["Depart"].ToString();
                string Unit = HttpContext.Current.Session["Unit"].ToString();
                if (Process == "OP1")
                {
                    Process = "1";
                }
                else if (Process == "OP2")
                {
                    Process = "2";
                }

                strConnString.Open();
                cmd = new SqlCommand("selectCellstaus", strConnString);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cell", SqlDbType.VarChar, 30).Value = Cell.ToString();
                cmd.Parameters.Add("@unit", SqlDbType.VarChar, 30).Value = Unit.ToString();
                cmd.Parameters.Add("@shift", SqlDbType.VarChar, 30).Value = Shift.ToString();
                cmd.Parameters.Add("@partno", SqlDbType.VarChar, 50).Value = Partno.ToString();
                cmd.Parameters.Add("@operation", SqlDbType.VarChar, 30).Value = Process.ToString();
                cmd.Parameters.Add("@date", SqlDbType.VarChar, 30).Value = DateTime.Now.ToShortDateString().ToString();
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    res = ds.Tables[0].Rows[0]["CellStatus"].ToString();
                }
                else
                {
                    res = "";
                }

                strConnString.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {
                strConnString.Close();
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static getsheetversion[] get_sheetversion()
    {
        List<getsheetversion> objg = new List<getsheetversion>();
        getsheetversion objgg = new getsheetversion();
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            string Partno = HttpContext.Current.Session["PartNo"].ToString();
            string Operation = HttpContext.Current.Session["Operation"].ToString();
            string Cell = HttpContext.Current.Session["Depart"].ToString();
            string Unit = HttpContext.Current.Session["Unit"].ToString();
            string op = "";
            if (Operation == "1" || Operation == "2")
            {
                if (Operation == "1")
                {
                    op = "OP1";
                }
                if (Operation == "2")
                {
                    op = "OP2";
                }
            }
            else
            {
                op = Operation.ToString();
            }
            da = null;
            ds.Tables.Clear();
            ds.Clear();
            ds.Reset();
            da = new SqlDataAdapter("select max(cast(Version as int))as Version from DynmasterValuesVersion where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "'", strConnString);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Version"] == null || ds.Tables[0].Rows[0]["Version"].ToString() == "")
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "';select * from tbl_WIPart where PartNo='" + Partno + "' and process='" + op + "'", strConnString);
                    DataSet ds1 = new DataSet();
                    ds1.Tables.Clear();
                    ds1.Clear();
                    ds.Reset();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        objgg.version = "1";
                        objgg.date = ds1.Tables[0].Rows[0]["Createdate"].ToString();
                        objgg.creatby = ds1.Tables[0].Rows[0]["Createdby"].ToString();
                        if (ds1.Tables[1].Rows.Count > 0)
                        {
                            if (ds1.Tables[1].Rows[0]["SourceName"] != null && ds1.Tables[1].Rows[0]["SourceName"].ToString() != "")
                            {
                                objgg.filename = ds1.Tables[1].Rows[0]["SourceName"].ToString();
                            }
                            else
                            {
                                objgg.filename = "File Name Not Found";
                            }
                        }
                        else
                        {
                            objgg.filename = "File Name Not Found";
                        }
                        objg.Add(objgg);
                    }
                    else
                    {
                    }

                }
                else
                {
                    objgg.version = ds.Tables[0].Rows[0]["Version"].ToString();
                    da = null;
                    ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();
                    da = new SqlDataAdapter("select * from DynmasterValuesVersion where Partno='" + Partno + "' and Operation='" + Operation + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and Version='" + objgg.version.ToString() + "';select * from tbl_WIPart where PartNo='" + Partno + "' and process='" + op + "'", strConnString);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objgg.date = ds.Tables[0].Rows[0]["Createdate"].ToString();
                        objgg.creatby = ds.Tables[0].Rows[0]["Createdby"].ToString();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        if (ds.Tables[1].Rows[0]["SourceName"] != null && ds.Tables[1].Rows[0]["SourceName"].ToString() != "")
                        {
                            objgg.filename = ds.Tables[1].Rows[0]["SourceName"].ToString();
                        }
                        else
                        {
                            objgg.filename = "File Name Not Found";
                        }
                    }
                    else
                    {
                        objgg.filename = "File Name Not Found";
                    }

                    objg.Add(objgg);
                }
            }

        }
        return objg.ToArray();
    }
    [WebMethod]
    public static string Sevenoneside(string Crnttxtvalue, string dynrefid, string inst_count, string UCL, string Mean, string LCL)
    {
        string res = "";
        int lflag = 0;
        int uflag = 0;
        int mdflag = 0;
        int muflag = 0;
        if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
        {
            lock (thisLock)
            {
                try
                {
                    decimal value, value1, value2, value3;
                    if (Decimal.TryParse(Crnttxtvalue, out value))
                    // It's a decimal
                    {
                        if (Crnttxtvalue != "NaN" && Crnttxtvalue != "" && Crnttxtvalue != "-" && Crnttxtvalue != null)
                        {
                            if (UCL == "")
                            { UCL = "0.00"; }
                            if (LCL == "")
                            { LCL = "0.00"; }
                            if (Mean == "" || Mean=="-")
                            { Mean = "0.00"; }
                            if (!Decimal.TryParse(UCL, out value1))
                            // It's a not decimal
                            {
                                UCL = "0.00";
                            }
                            if (!Decimal.TryParse(LCL, out value2))
                            // It's a not decimal
                            {
                                LCL = "0.00";
                            } if (!Decimal.TryParse(Mean, out value3))
                            // It's a not decimal
                            {
                                Mean = "0.00";
                            }
                            string Partno = HttpContext.Current.Session["PartNo"].ToString();
                            string Opertaion = HttpContext.Current.Session["Operation"].ToString();
                            string Machine = HttpContext.Current.Session["machine"].ToString();
                            string Process = HttpContext.Current.Session["Process"].ToString();
                            string Cell = HttpContext.Current.Session["Depart"].ToString();
                            string Unit = HttpContext.Current.Session["Unit"].ToString();
                            string Shift = HttpContext.Current.Session["Shift"].ToString();
                            string column = "";
                            string[] ColName_dbValue = new string[] { "" };
                            string tableName = "QualitySheet_" + Cell + "_" + Partno + "_" + Opertaion + "";
                            //da = new SqlDataAdapter("select * from Dynmaster where DID='" + dynrefid + "' order by DID", strConnString);
                            da = new SqlDataAdapter("select * from Dynmaster where DID='" + dynrefid + "' order by ReorderMaster", strConnString);
                            ds = new DataSet();
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                //column = "CreateDate,QPidno,QShift,OPERATOR,SLNo,QHeatCode";
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    int count = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                    string id = ds.Tables[0].Rows[i]["DID"].ToString();
                                    if (ds.Tables[0].Rows[i]["CellValues"] != null && ds.Tables[0].Rows[i]["CellValues"].ToString() != "" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "0" && ds.Tables[0].Rows[i]["CellValues"].ToString() != "-")
                                    {
                                        for (int j = 1; j <= count; j++)
                                        {
                                            column = column + "," + "QMax_" + "" + id + "" + j;
                                            column = column + "," + "QMin_" + "" + id + "" + j;
                                        }
                                    }
                                    else
                                    {
                                        string three = ds.Tables[0].Rows[i]["Instrument"].ToString().Substring(0, 3);
                                        int count1 = Convert.ToInt32(ds.Tables[0].Rows[i]["Int_count"].ToString());
                                        string id1 = ds.Tables[0].Rows[i]["DID"].ToString();
                                        //for (int k = 1; k <= count1; k++)
                                        //{
                                        column = column + "," + three + "" + id1 + "" + inst_count;
                                        //}
                                    }

                                }
                                //column += ",Comments,QSid";
                                ColName_dbValue = column.Split(new char[] { ',' });
                                column = column.Trim().TrimStart(',');
                            }
                            if (Shift != "C")
                            {
                                da = new SqlDataAdapter("select top 6 " + column + " from " + tableName + " where QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "' order by QSid desc", strConnString);
                                ds = new DataSet();
                                ds.Tables.Clear();
                                ds.Clear();
                                ds.Reset();
                                da.Fill(ds);
                                //DataSet mpds = new DataSet();
                                //mpds.Tables.Add(ds.Copy());

                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                                    {
                                        if (Decimal.TryParse(ds.Tables[0].Rows[k][column].ToString(), out value1))
                                        // It's a decimal
                                        {
                                            if (Convert.ToDecimal(ds.Tables[0].Rows[k][column].ToString()) >= Convert.ToDecimal(LCL) && Convert.ToDecimal(ds.Tables[0].Rows[k][column].ToString()) <= Convert.ToDecimal(Mean))
                                            {
                                                uflag = 0;
                                                lflag = lflag + 1;
                                            }
                                            if (Convert.ToDecimal(ds.Tables[0].Rows[k][column].ToString()) >= Convert.ToDecimal(Mean) && Convert.ToDecimal(ds.Tables[0].Rows[k][column].ToString()) <= Convert.ToDecimal(UCL))
                                            {
                                                lflag = 0;
                                                uflag = uflag + 1;
                                            }
                                            if (k != ds.Tables[0].Rows.Count - 1)
                                            {
                                                if (Decimal.TryParse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 1)][column].ToString(), out value2))
                                                // It's a decimal
                                                {
                                                    if (Decimal.TryParse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 2)][column].ToString(), out value3))
                                                    // It's a decimal
                                                    {
                                                        if (Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 1)][column].ToString()) > Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 2)][column].ToString()))
                                                        {
                                                            muflag = 0;
                                                            mdflag = mdflag + 1;
                                                        }
                                                        if (Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 1)][column].ToString()) < Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 2)][column].ToString()))
                                                        {
                                                            mdflag = 0;
                                                            muflag = muflag + 1;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Decimal.TryParse(ds.Tables[0].Rows[0][column].ToString(), out value1))
                                                // It's a decimal
                                                {
                                                    if (Convert.ToDecimal(ds.Tables[0].Rows[0][column].ToString()) > Convert.ToDecimal(Crnttxtvalue))
                                                    {
                                                        muflag = 0;
                                                        mdflag = mdflag + 1;
                                                    }
                                                    if (Convert.ToDecimal(ds.Tables[0].Rows[0][column].ToString()) < Convert.ToDecimal(Crnttxtvalue))
                                                    {
                                                        mdflag = 0;
                                                        muflag = muflag + 1;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (Convert.ToDecimal(Crnttxtvalue) >= Convert.ToDecimal(LCL) && Convert.ToDecimal(Crnttxtvalue) <= Convert.ToDecimal(Mean))
                                    {
                                        uflag = 0;
                                        lflag = lflag + 1;
                                    }
                                    if (Convert.ToDecimal(Crnttxtvalue) >= Convert.ToDecimal(Mean) && Convert.ToDecimal(Crnttxtvalue) <= Convert.ToDecimal(UCL))
                                    {
                                        lflag = 0;
                                        uflag = uflag + 1;
                                    }
                                    if (lflag == 7)
                                    {
                                        res = "L";
                                    }
                                    if (uflag == 7)
                                    {
                                        res = "U";
                                    }
                                    if (mdflag == 6)
                                    {
                                        res = "MDown";
                                    }
                                    if (muflag == 6)
                                    {
                                        res = "MUp";
                                    }
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                if (DateTime.Now.ToString("dd/MM/yyyy") == Convert.ToDateTime(HttpContext.Current.Session["LogDate"].ToString()).ToString("dd/MM/yyyy"))
                                {
                                    da = new SqlDataAdapter("select top 6 " + column + " from " + tableName + " where QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + "' order by QSid desc", strConnString);
                                    ds = new DataSet();
                                    ds.Tables.Clear();
                                    ds.Clear();
                                    ds.Reset();
                                    da.Fill(ds);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                                        {
                                            if (Decimal.TryParse(ds.Tables[0].Rows[k][column].ToString(), out value1))
                                            // It's a decimal
                                            {
                                                if (Convert.ToDecimal(ds.Tables[0].Rows[k][column].ToString()) >= Convert.ToDecimal(LCL) && Convert.ToDecimal(ds.Tables[0].Rows[k][column].ToString()) <= Convert.ToDecimal(Mean))
                                                {
                                                    uflag = 0;
                                                    lflag = lflag + 1;
                                                }
                                                if (Convert.ToDecimal(ds.Tables[0].Rows[k][column].ToString()) >= Convert.ToDecimal(Mean) && Convert.ToDecimal(ds.Tables[0].Rows[k][column].ToString()) <= Convert.ToDecimal(UCL))
                                                {
                                                    lflag = 0;
                                                    uflag = uflag + 1;
                                                }
                                                if (k != ds.Tables[0].Rows.Count - 1)
                                                {
                                                    if (Decimal.TryParse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 1)][column].ToString(), out value2))
                                                    // It's a decimal
                                                    {
                                                        if (Decimal.TryParse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 2)][column].ToString(), out value3))
                                                        // It's a decimal
                                                        {
                                                            if (Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 1)][column].ToString()) > Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 2)][column].ToString()))
                                                            {
                                                                muflag = 0;
                                                                mdflag = mdflag + 1;
                                                            }
                                                            if (Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 1)][column].ToString()) < Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 2)][column].ToString()))
                                                            {
                                                                mdflag = 0;
                                                                muflag = muflag + 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Decimal.TryParse(ds.Tables[0].Rows[0][column].ToString(), out value1))
                                                    // It's a decimal
                                                    {
                                                        if (Convert.ToDecimal(ds.Tables[0].Rows[0][column].ToString()) > Convert.ToDecimal(Crnttxtvalue))
                                                        {
                                                            muflag = 0;
                                                            mdflag = mdflag + 1;
                                                        }
                                                        if (Convert.ToDecimal(ds.Tables[0].Rows[0][column].ToString()) < Convert.ToDecimal(Crnttxtvalue))
                                                        {
                                                            mdflag = 0;
                                                            muflag = muflag + 1;
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                        if (Convert.ToDecimal(Crnttxtvalue) >= Convert.ToDecimal(LCL) && Convert.ToDecimal(Crnttxtvalue) <= Convert.ToDecimal(Mean))
                                        {
                                            uflag = 0;
                                            lflag = lflag + 1;
                                        }
                                        if (Convert.ToDecimal(Crnttxtvalue) >= Convert.ToDecimal(Mean) && Convert.ToDecimal(Crnttxtvalue) <= Convert.ToDecimal(UCL))
                                        {
                                            lflag = 0;
                                            uflag = uflag + 1;
                                        }
                                        if (lflag == 7)
                                        {
                                            res = "L";
                                        }
                                        if (uflag == 7)
                                        {
                                            res = "U";
                                        }
                                        if (mdflag == 6)
                                        {
                                            res = "MDown";
                                        }
                                        if (muflag == 6)
                                        {
                                            res = "MUp";
                                        }
                                    }
                                    else
                                    {
                                    }
                                }
                                else
                                {
                                    da = new SqlDataAdapter("select top 6 " + column + " from " + tableName + " where QShift='" + Shift + "' and MachineName='" + Machine + "' and OPERATOR='" + HttpContext.Current.Session["User_Name"].ToString() + "' and CONVERT(VARCHAR,Qdate,103)='" + Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()).ToString("dd/MM/yyyy") + "' order by QSid desc", strConnString);
                                    ds = new DataSet();
                                    ds.Tables.Clear();
                                    ds.Clear();
                                    ds.Reset();
                                    da.Fill(ds);

                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                                        {
                                            if (Decimal.TryParse(ds.Tables[0].Rows[k][column].ToString(), out value1))
                                            // It's a decimal
                                            {
                                                if (Convert.ToDecimal(ds.Tables[0].Rows[k][column].ToString()) >= Convert.ToDecimal(LCL) && Convert.ToDecimal(ds.Tables[0].Rows[k][column].ToString()) <= Convert.ToDecimal(Mean))
                                                {
                                                    uflag = 0;
                                                    lflag = lflag + 1;
                                                }
                                                if (Convert.ToDecimal(ds.Tables[0].Rows[k][column].ToString()) >= Convert.ToDecimal(Mean) && Convert.ToDecimal(ds.Tables[0].Rows[k][column].ToString()) <= Convert.ToDecimal(UCL))
                                                {
                                                    lflag = 0;
                                                    uflag = uflag + 1;
                                                }
                                                if (k != ds.Tables[0].Rows.Count - 1)
                                                {
                                                    if (Decimal.TryParse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 1)][column].ToString(), out value2))
                                                    // It's a decimal
                                                    {
                                                        if (Decimal.TryParse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 2)][column].ToString(), out value3))
                                                        // It's a decimal
                                                        {
                                                            if (Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 1)][column].ToString()) > Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 2)][column].ToString()))
                                                            {
                                                                muflag = 0;
                                                                mdflag = mdflag + 1;
                                                            }
                                                            if (Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 1)][column].ToString()) < Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - (k + 2)][column].ToString()))
                                                            {
                                                                mdflag = 0;
                                                                muflag = muflag + 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Decimal.TryParse(ds.Tables[0].Rows[0][column].ToString(), out value1))
                                                    // It's a decimal
                                                    {
                                                        if (Convert.ToDecimal(ds.Tables[0].Rows[0][column].ToString()) > Convert.ToDecimal(Crnttxtvalue))
                                                        {
                                                            muflag = 0;
                                                            mdflag = mdflag + 1;
                                                        }
                                                        if (Convert.ToDecimal(ds.Tables[0].Rows[0][column].ToString()) < Convert.ToDecimal(Crnttxtvalue))
                                                        {
                                                            mdflag = 0;
                                                            muflag = muflag + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (Convert.ToDecimal(Crnttxtvalue) >= Convert.ToDecimal(LCL) && Convert.ToDecimal(Crnttxtvalue) <= Convert.ToDecimal(Mean))
                                        {
                                            uflag = 0;
                                            lflag = lflag + 1;
                                        }
                                        if (Convert.ToDecimal(Crnttxtvalue) >= Convert.ToDecimal(Mean) && Convert.ToDecimal(Crnttxtvalue) <= Convert.ToDecimal(UCL))
                                        {
                                            lflag = 0;
                                            uflag = uflag + 1;
                                        }
                                        if (lflag == 7)
                                        {
                                            res = "L";
                                        }
                                        if (uflag == 7)
                                        {
                                            res = "U";
                                        }
                                        if (mdflag == 6)
                                        {
                                            res = "MDown";
                                        }
                                        if (muflag == 6)
                                        {
                                            res = "MUp";
                                        }
                                    }
                                    else
                                    {
                                    }
                                    
                                }
                            }
                        }
                    }
                    else
                    { }
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex);
                }
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("../Home.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        return res.ToString();
    }
    [WebMethod]
    public static getsheetversion[] get_adminsheetversion(string Partno, string Operation, string Unit, string Cell)
    {
        List<getsheetversion> objg = new List<getsheetversion>();
        getsheetversion objgg = new getsheetversion();
        lock (thisLock)
        {
            try
            {
                if (HttpContext.Current.Session["User_ID"] != null && HttpContext.Current.Session["User_ID"].ToString() != "")
                {
                    string Partno1 = Partno.ToString();
                    string Operation1 = Operation.ToString();
                    string Cell1 = Cell.ToString();
                    string Unit1 = Unit.ToString();
                    string op = "";
                    if (Operation1 == "1" || Operation1 == "2")
                    {
                        if (Operation1 == "1")
                        {
                            op = "OP1";
                        }
                        if (Operation1 == "2")
                        {
                            op = "OP2";
                        }
                    }
                    else
                    {
                        op = Operation1.ToString();
                    }
                    da = null;
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("select max(cast(Version as int))as Version from DynmasterValuesVersion where Partno='" + Partno1 + "' and Operation='" + Operation1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "'", strConnString);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Version"] == null || ds.Tables[0].Rows[0]["Version"].ToString() == "")
                        {
                            SqlDataAdapter da1 = new SqlDataAdapter("select * from DynmasterValues where Partno='" + Partno1 + "' and Operation='" + Operation1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "';select * from tbl_WIPart where PartNo='" + Partno1 + "' and process='" + op + "'", strConnString);
                            DataSet ds1 = new DataSet();
                            da1.Fill(ds1);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                objgg.version = "1";
                                objgg.date = ds1.Tables[0].Rows[0]["Createdate"].ToString();
                                objgg.creatby = ds1.Tables[0].Rows[0]["Createdby"].ToString();
                                if (ds1.Tables[1].Rows.Count > 0)
                                {
                                    if (ds1.Tables[1].Rows[0]["SourceName"] != null && ds1.Tables[1].Rows[0]["SourceName"].ToString() != "")
                                    {
                                        objgg.filename = ds1.Tables[1].Rows[0]["SourceName"].ToString();
                                    }
                                    else
                                    {
                                        objgg.filename = "File Name Not Found";
                                    }
                                }
                                else
                                {
                                    objgg.filename = "File Name Not Found";
                                }
                                objg.Add(objgg);
                            }
                            else
                            {
                            }

                        }
                        else
                        {
                            objgg.version = ds.Tables[0].Rows[0]["Version"].ToString();
                            da = null;
                            ds = new DataSet();
                            ds.Tables.Clear();
                            ds.Clear();
                            ds.Reset();
                            da = new SqlDataAdapter("select * from DynmasterValuesVersion where Partno='" + Partno1 + "' and Operation='" + Operation1 + "' and Unit='" + Unit1 + "' and Cell='" + Cell1 + "' and Version='" + objgg.version.ToString() + "';select * from tbl_WIPart where PartNo='" + Partno1 + "' and process='" + op + "'", strConnString);
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                objgg.date = ds.Tables[0].Rows[0]["Createdate"].ToString();
                                objgg.creatby = ds.Tables[0].Rows[0]["Createdby"].ToString();
                            }
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                if (ds.Tables[1].Rows[0]["SourceName"] != null && ds.Tables[1].Rows[0]["SourceName"].ToString() != "")
                                {
                                    objgg.filename = ds.Tables[1].Rows[0]["SourceName"].ToString();
                                }
                                else
                                {
                                    objgg.filename = "File Name Not Found";
                                }
                            }
                            else
                            {
                                objgg.filename = "File Name Not Found";
                            }

                            objg.Add(objgg);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objg.ToArray();
        }
    }
    [WebMethod]
    public static string add_days(string Date, string Count)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                DateTime days = Convert.ToDateTime(Date);
                string day = days.AddDays(Convert.ToInt32(Count)).ToShortDateString().ToString();
                res = day.ToString();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();

        }
    }
    [WebMethod]
    public static string Changedate(string Replaced)
    {
        string res = "";
        string day = DateTime.Now.ToShortDateString().ToString();
        res = day.ToString();
        return res.ToString();
    }
    [WebMethod]
    public static abutoolmaster[] EditAbutoolMaster(string ID)
    {
        List<abutoolmaster> objf = new List<abutoolmaster>();
        abutoolmaster objfb = new abutoolmaster();
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from AbuToolMaster where ID='" + Convert.ToInt32(ID) + "'", strConnString);
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objfb.grom = ds.Tables[0].Rows[0]["Gfrom"].ToString();
                    objfb.gto = ds.Tables[0].Rows[0]["Gto"].ToString();
                    objfb.yfrom = ds.Tables[0].Rows[0]["Yfrom"].ToString();
                    objfb.yto = ds.Tables[0].Rows[0]["Yto"].ToString();
                    objfb.rfrom = ds.Tables[0].Rows[0]["Rfrom"].ToString();
                    objfb.rto = ds.Tables[0].Rows[0]["Rto"].ToString();
                    objfb.tno = ds.Tables[0].Rows[0]["ToolNumber"].ToString();
                    objfb.unit = ds.Tables[0].Rows[0]["Unit"].ToString();
                    objfb.type = ds.Tables[0].Rows[0]["Name"].ToString();
                    objfb.line = ds.Tables[0].Rows[0]["Line"].ToString();
                    objfb.Retension = ds.Tables[0].Rows[0]["RetensionTime"].ToString();
                    objf.Add(objfb);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objf.ToArray();
        }
    }
    [WebMethod]
    public static string DeleteAbuMaster(string ID)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                cmd = new SqlCommand("delete from Abu_Master where ID='" + Convert.ToInt32(ID) + "'", strConnString);
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
            }
            catch (Exception ex)
            {
                res = "F";
            }
            finally
            {
                res = "S";
                strConnString.Close();
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static editabumaster[] EditAbuMaster(string ID)
    {
        List<editabumaster> obje = new List<editabumaster>();
        editabumaster objee = new editabumaster();
        string res = "";
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from Abu_Master where ID='" + Convert.ToInt32(ID) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select sum(convert(int,TotalCount)) As SparesIn from SpareMaster where ToolNumber='" + ds.Tables[0].Rows[0]["ToolNumber"].ToString() + "'", strConnString);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    SqlDataAdapter da2 = new SqlDataAdapter("select count(*) As SparesOut from dbo.Abu_Master where ToolNumber='" + ds.Tables[0].Rows[0]["ToolNumber"].ToString() + "' and ToolStatus='InActive' and Spare='Yes'", strConnString);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    decimal spare = Convert.ToDecimal(ds1.Tables[0].Rows[0]["SparesIn"].ToString()) - Convert.ToDecimal(ds2.Tables[0].Rows[0]["SparesOut"].ToString());
                    objee.id = ds.Tables[0].Rows[0]["ID"].ToString();
                    objee.tno = ds.Tables[0].Rows[0]["ToolNumber"].ToString();
                    objee.davail = ds.Tables[0].Rows[0]["Availability"].ToString();
                    objee.desc = ds.Tables[0].Rows[0]["Description"].ToString();
                    objee.issued = ds.Tables[0].Rows[0]["Issuedon"].ToString();
                    objee.maint = spare.ToString();
                    objee.next = ds.Tables[0].Rows[0]["Nextdueon"].ToString();
                    objee.qty = ds.Tables[0].Rows[0]["StationQty"].ToString();
                    objee.rtime = ds.Tables[0].Rows[0]["Rentime"].ToString();
                    objee.station = ds.Tables[0].Rows[0]["Station"].ToString();
                    objee.replaced = "0"; //ds.Tables[0].Rows[0]["Spare"].ToString();
                    objee.extended = "0"; //ds.Tables[0].Rows[0]["LifeExtend"].ToString();
                    objee.rectified = ds.Tables[0].Rows[0]["Rectified"].ToString();
                    objee.other = ds.Tables[0].Rows[0]["Others"].ToString();
                    objee.premature = ds.Tables[0].Rows[0]["Premature"].ToString();
                    obje.Add(objee);
                }
                else { }

            }
            catch (Exception ex)
            {
                res = "F";
            }
            finally
            {
                res = "S";
            }
            return obje.ToArray();
        }
    }
    [WebMethod]
    public static editabumaster[] getfeedbacktool(string ID)
    {
        List<editabumaster> objf = new List<editabumaster>();
        editabumaster objff = new editabumaster();
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from Abu_Master where ToolNumber='" + ID + "' and ToolStatus='Active'", strConnString);
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objff.station = ds.Tables[0].Rows[0]["Station"].ToString();
                    objff.rtime = ds.Tables[0].Rows[0]["Rentime"].ToString();
                    objff.issued = ds.Tables[0].Rows[0]["Issuedon"].ToString();
                    objff.next = ds.Tables[0].Rows[0]["Nextdueon"].ToString();
                    objf.Add(objff);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objf.ToArray();
        }
    }
    [WebMethod]
    public static string editunitmaster(string ID)
    {
        string res = "";
        da = new SqlDataAdapter("select * from UnitMaster where MID='" + Convert.ToInt32(ID) + "'", strConnString);
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        da.Fill(ds);
        lock (thisLock)
        {
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    res = ds.Tables[0].Rows[0]["MValue"].ToString();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string editunitmastermbu(string ID)
    {
        string res = "";
        da = new SqlDataAdapter("select * from UnitMastermbu where MID='" + Convert.ToInt32(ID) + "'", strConnString);

        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        da.Fill(ds);
        lock (thisLock)
        {
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    res = ds.Tables[0].Rows[0]["MValue"].ToString();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string deleteunitmaster(string ID)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (strConnString.State == ConnectionState.Open)
                {
                    strConnString.Close();
                }
                cmd = new SqlCommand("delete  from UnitMaster where MID='" + Convert.ToInt32(ID) + "'", strConnString);
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                res = "S";
            }
            catch (Exception ex)
            {
                res = "F";
            }
            finally
            {
                strConnString.Close();
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string deleteunitmastermbu(string ID)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (strConnString.State == ConnectionState.Open)
                {
                    strConnString.Close();
                }
                cmd = new SqlCommand("delete  from UnitMastermbu where MID='" + Convert.ToInt32(ID) + "'", strConnString);
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();

                res = "S";
            }
            catch (Exception ex)
            {
                res = "F";
            }
            finally
            {
                strConnString.Close();
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string deletetypemaster(string ID)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (strConnString.State == ConnectionState.Open)
                {
                    strConnString.Close();
                }
                cmd = new SqlCommand("delete  from ToolTypeMaster where TID='" + Convert.ToInt32(ID) + "'", strConnString);
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                res = "S";
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {
                strConnString.Close();
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string deletetypemastermbu(string ID)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (strConnString.State == ConnectionState.Open)
                {
                    strConnString.Close();
                }
                cmd = new SqlCommand("delete  from ToolTypeMastermbu where TID='" + Convert.ToInt32(ID) + "'", strConnString);
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                res = "S";
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {
                strConnString.Close();
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static ToolType[] edittypemaster(string ID)
    {
        List<ToolType> objt = new List<ToolType>();
        ToolType objtt = new ToolType();
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from ToolTypeMaster where TID='" + ID + "'", strConnString);
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objtt.ttext = ds.Tables[0].Rows[0]["TText"].ToString();
                    objtt.tvalue = ds.Tables[0].Rows[0]["TValue"].ToString();
                    objt.Add(objtt);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objt.ToArray();
        }
    }
    [WebMethod]
    public static ToolType[] edittypemastermbu(string ID)
    {
        List<ToolType> objt = new List<ToolType>();
        ToolType objtt = new ToolType();
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from ToolTypeMastermbu where TID='" + ID + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objtt.ttext = ds.Tables[0].Rows[0]["TText"].ToString();
                    objtt.tvalue = ds.Tables[0].Rows[0]["TValue"].ToString();
                    objt.Add(objtt);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objt.ToArray();
        }
    }
    [WebMethod]
    public static Linemaster[] editlinemaster(string ID)
    {
        List<Linemaster> objl = new List<Linemaster>();
        Linemaster objll = new Linemaster();
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from LineMaster where LID='" + ID + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objll.ttext = ds.Tables[0].Rows[0]["LText"].ToString();
                    objll.tvalue = ds.Tables[0].Rows[0]["LValue"].ToString();
                    objl.Add(objll);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objl.ToArray();
        }
    }

    [WebMethod]
    public static Linemaster[] editlinemastermbu(string ID)
    {
        List<Linemaster> objl = new List<Linemaster>();
        Linemaster objll = new Linemaster();
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from LineMastermbu where LID='" + ID + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objll.ttext = ds.Tables[0].Rows[0]["LText"].ToString();
                    objll.tvalue = ds.Tables[0].Rows[0]["LValue"].ToString();
                    objl.Add(objll);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objl.ToArray();
        }
    }
    [WebMethod]
    public static string deletelinemaster(string ID)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (strConnString.State == ConnectionState.Open)
                {
                    strConnString.Close();
                }
                cmd = new SqlCommand("delete  from LineMaster where LID='" + Convert.ToInt32(ID) + "'", strConnString);
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                res = "S";
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {
                strConnString.Close();
            }
            return res.ToString();
        }
    }

    [WebMethod]
    public static string deletelinemastermbu(string ID)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (strConnString.State == ConnectionState.Open)
                {
                    strConnString.Close();
                }
                cmd = new SqlCommand("delete  from LineMastermbu where LID='" + Convert.ToInt32(ID) + "'", strConnString);
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                res = "S";
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {
                strConnString.Close();
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static sparemaster[] editsparemaster(string ID)
    {
        List<sparemaster> pbjs = new List<sparemaster>();
        sparemaster objsp = new sparemaster();
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from SpareMaster where SID='" + Convert.ToInt32(ID) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objsp.tool = ds.Tables[0].Rows[0]["ToolNumber"].ToString();
                    objsp.max = ds.Tables[0].Rows[0]["Maximum"].ToString();
                    objsp.min = ds.Tables[0].Rows[0]["Minimum"].ToString();
                    objsp.count = ds.Tables[0].Rows[0]["TotalCount"].ToString();
                    pbjs.Add(objsp);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return pbjs.ToArray();
        }
    }

    [WebMethod]
    public static sparemaster[] editsparemastermbu(string ID)
    {
        List<sparemaster> pbjs = new List<sparemaster>();
        sparemaster objsp = new sparemaster();
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from SpareMastermbu where SID='" + Convert.ToInt32(ID) + "'", strConnString);
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objsp.partno = ds.Tables[0].Rows[0]["Partno"].ToString();
                    objsp.tool = ds.Tables[0].Rows[0]["ToolNumber"].ToString();
                    objsp.max = ds.Tables[0].Rows[0]["Maximum"].ToString();
                    objsp.min = ds.Tables[0].Rows[0]["Minimum"].ToString();
                    objsp.count = ds.Tables[0].Rows[0]["TotalCount"].ToString();
                    pbjs.Add(objsp);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return pbjs.ToArray();
        }
    }
    [WebMethod]
    public static string deletesparemaster(string ID)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (strConnString.State == ConnectionState.Open)
                {
                    strConnString.Close();
                }
                cmd = new SqlCommand("delete  from SpareMaster where SID='" + Convert.ToInt32(ID) + "'", strConnString);
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                res = "S";
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {
                strConnString.Close();
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string deletesparemastermbu(string ID)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (strConnString.State == ConnectionState.Open)
                {
                    strConnString.Close();
                }
                cmd = new SqlCommand("delete  from SpareMastermbu where SID='" + Convert.ToInt32(ID) + "'", strConnString);
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                res = "S";
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {
                strConnString.Close();
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string editmodel(String ID)
    {
        string res = "";
        da = new SqlDataAdapter("select * from FixtureModel where ID='" + Convert.ToInt32(ID) + "'", strConnString);
        ds = new DataSet();
        da.Fill(ds);
        lock (thisLock)
        {
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    res = ds.Tables[0].Rows[0]["Mvalue"].ToString();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string deletemodelmaster(string ID)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (strConnString.State == ConnectionState.Open)
                {
                    strConnString.Close();
                }
                cmd = new SqlCommand("delete  from FixtureModel where ID='" + Convert.ToInt32(ID) + "'", strConnString);
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                res = "S";
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {
                strConnString.Close();
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static gettooldeatils[] gettoolsvalues(string ID)
    {
        List<gettooldeatils> objt = new List<gettooldeatils>();
        gettooldeatils objtt = new gettooldeatils();
        lock (thisLock)
        {
            try
            {

                da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Active' and a.ID='" + Convert.ToInt32(ID) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objtt.toolno = ds.Tables[0].Rows[0]["Tool"].ToString();
                    objtt.nextdue = ds.Tables[0].Rows[0]["Nextdueon"].ToString();
                    objtt.photo = ds.Tables[0].Rows[0]["Photo"].ToString();
                    objtt.retenstion = ds.Tables[0].Rows[0]["Rentime"].ToString();
                    objtt.spare = ds.Tables[0].Rows[0]["Maintained"].ToString();
                    objtt.station = ds.Tables[0].Rows[0]["Station"].ToString();
                    objtt.avail = ds.Tables[0].Rows[0]["Availability"].ToString();
                    objtt.drawing = ds.Tables[0].Rows[0]["Drawings"].ToString();
                    objtt.issued = ds.Tables[0].Rows[0]["Issuedon"].ToString();
                    objt.Add(objtt);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
            }
            finally
            {
            }
            return objt.ToArray();
        }
    }
    [WebMethod]
    public static editmail[] editmail1(string ID)
    {
        List<editmail> objm = new List<editmail>();
        editmail objmm = new editmail();
        lock (thisLock)
        {
            try
            {
                da = new SqlDataAdapter("select * from Mail where ID='" + Convert.ToInt32(ID) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objmm.username = ds.Tables[0].Rows[0]["Username"].ToString();
                    objmm.password = ds.Tables[0].Rows[0]["Password"].ToString();
                    objmm.port = ds.Tables[0].Rows[0]["Port"].ToString();
                    objm.Add(objmm);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return objm.ToArray();
        }
    }
    [WebMethod]
    public static editmail2[] editmailauth(string ID)
    {
        List<editmail2> objm = new List<editmail2>();
        // string res = "";
        editmail2 objma = new editmail2();
        lock (thisLock)
        {
            try
            {

                da = new SqlDataAdapter("select * from MailAutorized where ID='" + Convert.ToInt32(ID) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objma.mailid = ds.Tables[0].Rows[0]["MailID"].ToString();
                    objma.unit = ds.Tables[0].Rows[0]["unit"].ToString();
                    objm.Add(objma);
                    // res1 = ds.Tables[0].Rows[0]["unit"].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }

            return objm.ToArray();
        }
    }
    [WebMethod]
    public static string deleteauth(string ID)
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                if (strConnString.State == ConnectionState.Open)
                {
                    strConnString.Close();
                }
                cmd = new SqlCommand("delete from MailAutorized where ID='" + Convert.ToInt32(ID) + "'", strConnString);
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                res = "S";
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                res = "F";
            }
            finally
            {
                strConnString.Close();
            }
            return res.ToString();
        }
    }
    [WebMethod]
    public static string Cdatetime()
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                res = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        return res.ToString();
    }
    [WebMethod]
    public static string datetime_current()
    {
        string res = "";
        lock (thisLock)
        {
            try
            {
                res = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return res.ToString();
        }
    }
}
