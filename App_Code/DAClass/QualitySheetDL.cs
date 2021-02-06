using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using System.Threading;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

/// <summary>
/// Summary description for QualitySheetDL
/// </summary>
public class QualitySheetDL
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public DBServer objserver = new DBServer();
    public SqlCommand cmd;
    public DataSet ds,ds1;
    public SqlDataAdapter da;
    public static String[] table = { "QualitySheet", "QualitySheetA22916J", "qualityshtA44983U", "QSheetA32271C", "QSheetA44908N", "QSheetPolishing24Q", "QSheetpolishingA22916J", "QSheetpolishingA32271C", "QSheetPolishingA44908N", "QSheetpolishingA44983U", "opt2QSA17724Q", "opt2QualitySheetA22916J" };
    public static String[] table1 = { "A17724Q", "A22916J", "A32271C", "A44983U", "A44908N" };
    public string PRDPN = "17724";
    public string PRDPName = "A17724Q";
    public string max = "67.623";
    public string min = "67.577";
    public string strPath;
    public decimal CP,CP1,CP2,CP3, CPK,CPK1,CPK2,CPK3, tolerance, points = 67, Standardeviation,Standardeviation2,Standardeviation3,Standardeviation4, Range;
    public decimal CPP, CPP1, CPP2, CPP3;
    public string error_msg;
    public double xminxbar, xminxbar2, xminxbar3, xminxbar4;
    public double xxminxbar, xxminxbar2, xxminxbar3, xxminxbar4;
    public string reff;
    public string result = "";
    public double standart, standart1, standart2, standart3;
    public double cp, cp1, cp2, cp3;
    private string _username;
    private string _passwrod;
    private string _role;
    private string _date;
    private string _reff;
    private string _regid;
    public string _pagename;
    public string userrole;
    public string mode;
    public string query;
    public Object thisLock = new Object();
    public void updatechangesDA(decimal maxval, decimal minval,decimal maxvald2,decimal minvald2,decimal maxvald3,decimal minvald3,decimal maxvald4,decimal minvald4,string mode,string pid,string date,string shift)
    {
        try
        {
            cmd = new SqlCommand("SP_GetstanderdDeviation", strConnString);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@mode", SqlDbType.VarChar, 5).Value = mode;
            cmd.Parameters.Add("@pidno", SqlDbType.VarChar, 50).Value = pid;
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            cmd.Parameters.Add("@shift", SqlDbType.VarChar, 3).Value = shift.ToString();
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (mode.ToString() == "C" || mode.ToString() == "CP" || mode.ToString() == "UP" || mode.ToString() == "U")
            {
                //Dimesgion one
                double TotAvg = Convert.ToDouble(ds.Tables[0].Rows[0]["Average"]);
                double MAvg = Convert.ToDouble(ds.Tables[1].Rows[0]["Average"]);
                double MiAvg = Convert.ToDouble(ds.Tables[2].Rows[0]["Average"]);
                int TotRow = Convert.ToInt32(ds.Tables[12].Rows[0]["rowcoun"]);
               // double Max = Convert.ToDouble(ds.Tables[10].Rows[0]["QMG1Max"]);

                double xbar = TotAvg / TotRow;
                xminxbar = (MAvg - xbar) * (MAvg - xbar) / (TotRow - 1);
                if (xminxbar > 0)
                {
                    standart = Math.Sqrt(xminxbar);

                    cp = ((Convert.ToDouble(maxval)) - (Convert.ToDouble(minval))) / (6 * standart);
                    CP = Convert.ToDecimal(cp);
                    double cpk1 = ((Convert.ToDouble(maxval)) - (xbar)) / (3 * standart);
                    double cpk2 = ((xbar) - Convert.ToDouble(minval)) / (3 * standart);
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
                }
                //dimesgion two
                double TotAvg1 = Convert.ToDouble(ds.Tables[3].Rows[0]["Average2"]);
                double MAvg1 = Convert.ToDouble(ds.Tables[4].Rows[0]["Average2"]);
                double MiAvg1 = Convert.ToDouble(ds.Tables[5].Rows[0]["Average2"]);
                int TotRow1 = Convert.ToInt32(ds.Tables[12].Rows[0]["rowcoun"]);
               // double Max1 = Convert.ToDouble(ds.Tables[11].Rows[0]["QMG2Max"]);

                double xbar1 = TotAvg1 / TotRow1;
                xminxbar2 = (MAvg1 - xbar1) * (MAvg1 - xbar1) / (TotRow1 - 1);
                if (xminxbar2 > 0)
                {
                    standart1 = Math.Sqrt(xminxbar2);

                    cp1 = ((Convert.ToDouble(maxvald2)) - (Convert.ToDouble(minvald2))) / (6 * standart1);
                    CP1 = Convert.ToDecimal(cp1);
                    double cpk11 = ((Convert.ToDouble(maxvald2)) - (xbar1)) / (3 * standart1);
                    double cpk21 = ((xbar1) - Convert.ToDouble(minvald2)) / (3 * standart1);
                    if (cpk11 > cpk21)
                    {
                        CPK1 = (Convert.ToDecimal(cpk21));

                    }
                    else
                    {
                        CPK1 = (Convert.ToDecimal(cpk11));
                    }

                    double rang = MAvg1 - MiAvg1;
                    Range = Convert.ToDecimal(rang);

                    Standardeviation2 = Convert.ToDecimal(standart1);
                }

                //dimesion three
                double TotAvg2 = Convert.ToDouble(ds.Tables[6].Rows[0]["Average3"]);
                double MAvg2 = Convert.ToDouble(ds.Tables[7].Rows[0]["Average3"]);
                double MiAvg2 = Convert.ToDouble(ds.Tables[8].Rows[0]["Average3"]);
                int TotRow2 = Convert.ToInt32(ds.Tables[12].Rows[0]["rowcoun"]);
               // double Max2 = Convert.ToDouble(ds.Tables[12].Rows[0]["QMG3Max"]);
                double xbar2 = TotAvg2 / TotRow2;
                xminxbar3 = (MAvg2 - xbar2) * (MAvg2 - xbar2) / (TotRow2 - 1);
                if (xminxbar3 > 0)
                {
                    standart2 = Math.Sqrt(xminxbar3);

                    cp2 = ((Convert.ToDouble(maxvald3)) - (Convert.ToDouble(minvald3))) / (6 * standart2);
                    CP2 = Convert.ToDecimal(cp2);
                    double cpk111 = ((Convert.ToDouble(maxvald3)) - (xbar2)) / (3 * standart2);
                    double cpk211 = ((xbar2) - Convert.ToDouble(minvald3)) / (3 * standart2);
                    if (cpk111 > cpk211)
                    {
                        CPK2 = (Convert.ToDecimal(cpk211));

                    }
                    else
                    {
                        CPK2 = (Convert.ToDecimal(cpk111));
                    }

                    double rang = MAvg2 - MiAvg2;
                    Range = Convert.ToDecimal(rang);

                    Standardeviation3 = Convert.ToDecimal(standart2);
                }

                //dimesgion four
                double TotAvg3 = Convert.ToDouble(ds.Tables[9].Rows[0]["Average4"]);
                double MAvg3 = Convert.ToDouble(ds.Tables[10].Rows[0]["Average4"]);
                double MiAvg3 = Convert.ToDouble(ds.Tables[11].Rows[0]["Average4"]);
                int TotRow3 = Convert.ToInt32(ds.Tables[12].Rows[0]["rowcoun"]);
                double Max3 = Convert.ToDouble(ds.Tables[16].Rows[0]["QMG4Max"]);
                double xbar3 = TotAvg3 / TotRow3;
                xminxbar4 = (MAvg3 - xbar3) * (MAvg3 - xbar3) / (TotRow3 - 1);
                if (xminxbar4 > 0)
                {
                    standart3 = Math.Sqrt(xminxbar4);

                    cp3 = ((Convert.ToDouble(maxvald4)) - (Convert.ToDouble(minvald4))) / (6 * standart3);
                    CP3 = Convert.ToDecimal(cp3);
                    double cpk1111 = ((Convert.ToDouble(maxvald4)) - (xbar3)) / (3 * standart3);
                    double cpk2111 = ((xbar3) - Convert.ToDouble(minvald4)) / (3 * standart3);
                    if (cpk1111 > cpk2111)
                    {
                        CPK3 = (Convert.ToDecimal(cpk2111));

                    }
                    else
                    {
                        CPK3 = (Convert.ToDecimal(cpk1111));
                    }

                    double rang = MAvg3 - MiAvg3;
                    Range = Convert.ToDecimal(rang);

                    Standardeviation4 = Convert.ToDecimal(standart3);
                }
            }
            else
            {
                //Dimesgion one
                double TotAvg = Convert.ToDouble(ds.Tables[0].Rows[0]["Average"]);
                double MAvg = Convert.ToDouble(ds.Tables[1].Rows[0]["Average"]);
                double MiAvg = Convert.ToDouble(ds.Tables[2].Rows[0]["Average"]);
                int TotRow = Convert.ToInt32(ds.Tables[9].Rows[0]["rowcoun"]);
                double Max = Convert.ToDouble(ds.Tables[10].Rows[0]["QMG1Max"]);

                double xbar = TotAvg / TotRow;
                xminxbar = (MAvg - xbar) * (MAvg - xbar) / (TotRow - 1);
                if (xminxbar > 0)
                {
                    standart = Math.Sqrt(xminxbar);

                    cp = ((Convert.ToDouble(maxval)) - (Convert.ToDouble(minval))) / (6 * standart);
                    CP = Convert.ToDecimal(cp);
                    double cpk1 = ((Convert.ToDouble(maxval)) - (xbar)) / (3 * standart);
                    double cpk2 = ((xbar) - Convert.ToDouble(minval)) / (3 * standart);
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
                }
                //dimesgion two
                double TotAvg1 = Convert.ToDouble(ds.Tables[3].Rows[0]["Average2"]);
                double MAvg1 = Convert.ToDouble(ds.Tables[4].Rows[0]["Average2"]);
                double MiAvg1 = Convert.ToDouble(ds.Tables[5].Rows[0]["Average2"]);
                int TotRow1 = Convert.ToInt32(ds.Tables[9].Rows[0]["rowcoun"]);
                double Max1 = Convert.ToDouble(ds.Tables[11].Rows[0]["QMG2Max"]);

                double xbar1 = TotAvg1 / TotRow1;
                xminxbar2 = (MAvg1 - xbar1) * (MAvg1 - xbar1) / (TotRow1 - 1);
                if (xminxbar2 > 0)
                {
                    standart1 = Math.Sqrt(xminxbar2);

                    cp1 = ((Convert.ToDouble(maxvald2)) - (Convert.ToDouble(minvald2))) / (6 * standart1);
                    CP1 = Convert.ToDecimal(cp1);
                    double cpk11 = ((Convert.ToDouble(maxvald2)) - (xbar1)) / (3 * standart1);
                    double cpk21 = ((xbar1) - Convert.ToDouble(minvald2)) / (3 * standart1);
                    if (cpk11 > cpk21)
                    {
                        CPK1 = (Convert.ToDecimal(cpk21));

                    }
                    else
                    {
                        CPK1 = (Convert.ToDecimal(cpk11));
                    }

                    double rang = MAvg1 - MiAvg1;
                    Range = Convert.ToDecimal(rang);

                    Standardeviation2 = Convert.ToDecimal(standart1);
                }

                //dimesion three
                double TotAvg2 = Convert.ToDouble(ds.Tables[6].Rows[0]["Average3"]);
                double MAvg2 = Convert.ToDouble(ds.Tables[7].Rows[0]["Average3"]);
                double MiAvg2 = Convert.ToDouble(ds.Tables[8].Rows[0]["Average3"]);
                int TotRow2 = Convert.ToInt32(ds.Tables[9].Rows[0]["rowcoun"]);
                double Max2 = Convert.ToDouble(ds.Tables[12].Rows[0]["QMG3Max"]);
                double xbar2 = TotAvg2 / TotRow2;
                xminxbar3 = (MAvg2 - xbar2) * (MAvg2 - xbar2) / (TotRow2 - 1);
                if (xminxbar3 > 0)
                {
                    standart2 = Math.Sqrt(xminxbar3);

                    cp2 = ((Convert.ToDouble(maxvald3)) - (Convert.ToDouble(minvald3))) / (6 * standart2);
                    CP2 = Convert.ToDecimal(cp2);
                    double cpk111 = ((Convert.ToDouble(maxvald3)) - (xbar2)) / (3 * standart2);
                    double cpk211 = ((xbar2) - Convert.ToDouble(minvald3)) / (3 * standart2);
                    if (cpk111 > cpk211)
                    {
                        CPK2 = (Convert.ToDecimal(cpk211));

                    }
                    else
                    {
                        CPK2 = (Convert.ToDecimal(cpk111));
                    }

                    double rang = MAvg2 - MiAvg2;
                    Range = Convert.ToDecimal(rang);

                    Standardeviation3 = Convert.ToDecimal(standart2);
                }
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Chart_CP", SqlDbType.Decimal).Value = CP;
            cmd.Parameters.Add("@Chart_CPK", SqlDbType.Decimal).Value = CPK;
            cmd.Parameters.Add("@Chart_CPD2", SqlDbType.Decimal).Value = CP1;
            cmd.Parameters.Add("@Chart_CPKD2", SqlDbType.Decimal).Value = CPK1;
            cmd.Parameters.Add("@Chart_CPD3", SqlDbType.Decimal).Value = CP2;
            cmd.Parameters.Add("@Chart_CPKD3", SqlDbType.Decimal).Value = CPK2;
            cmd.Parameters.Add("@Chart_Deviation", SqlDbType.Decimal).Value = Standardeviation;
            cmd.Parameters.Add("@Chart_DeviationD2", SqlDbType.Decimal).Value = Standardeviation2;
            cmd.Parameters.Add("@Chart_DeviationD3", SqlDbType.Decimal).Value = Standardeviation3;
            cmd.Parameters.Add("@pidno", SqlDbType.VarChar, 50).Value = pid;
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            cmd.Parameters.Add("@shift", SqlDbType.VarChar, 3).Value = shift.ToString();
            if (mode.ToString() == "C" || mode.ToString() == "CP" || mode.ToString() == "UP" || mode.ToString() == "U")
            {
                cmd.Parameters.Add("@Chart_DeviationD4", SqlDbType.Decimal).Value = Standardeviation4;
                cmd.Parameters.Add("@Chart_CPD4", SqlDbType.Decimal).Value = CP3;
                cmd.Parameters.Add("@Chart_CPKD4", SqlDbType.Decimal).Value = CPK3;
            }
            else
            {
                cmd.Parameters.Add("@Chart_DeviationD4", SqlDbType.Decimal).Value = Convert.ToDecimal(00.000);
                cmd.Parameters.Add("@Chart_CPD4", SqlDbType.Decimal).Value = Convert.ToDecimal(00.000);
                cmd.Parameters.Add("@Chart_CPKD4", SqlDbType.Decimal).Value = Convert.ToDecimal(00.000);
            }
            cmd.Parameters.Add("@mode", SqlDbType.VarChar, 5).Value = mode;
        }
        catch (Exception ex)
        {
        }
        finally
        {
            strConnString.Open();
            cmd.ExecuteNonQuery();
            strConnString.Close();
        }
    }
    public void updatechanges_DA(decimal maxval, decimal minval, decimal maxvald2, decimal minvald2, decimal maxvald3, decimal minvald3, decimal maxvald4, decimal minvald4, string mode, string pid, string date, string shift)
    {
        try
        {

            // strConnString.Open();
            cmd = new SqlCommand("sp_getroughstanderdDeviation", strConnString);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@mode", SqlDbType.VarChar, 5).Value = mode;
            cmd.Parameters.Add("@pidno", SqlDbType.VarChar, 50).Value = pid;
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            cmd.Parameters.Add("@shift", SqlDbType.VarChar, 3).Value = shift.ToString();
            da = new SqlDataAdapter(cmd);


            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (mode.ToString() == "CP" || mode.ToString() == "UP")
                {
                    int TotRow = Convert.ToInt32(ds.Tables[16].Rows[0]["rowcoun"]);
                    //1
                    double TotAvg16 = Convert.ToDouble(ds.Tables[0].Rows[0]["QRAVG16"]);
                    double MAvg16 = Convert.ToDouble(ds.Tables[1].Rows[0]["QRMax16"]);
                    double TotAvg72 = Convert.ToDouble(ds.Tables[2].Rows[0]["QRAVG72"]);
                    double MAvg72 = Convert.ToDouble(ds.Tables[3].Rows[0]["QRMax72"]);

                    double xbar = TotAvg16 / TotRow;
                    double xbar1 = TotAvg72 / TotRow;
                    xminxbar = (MAvg16 - xbar) * (MAvg16 - xbar) / (TotRow - 1);
                    xxminxbar = (MAvg72 - xbar1) * (MAvg72 - xbar1) / (TotRow - 1);
                    if (xminxbar > 0)
                    {
                        standart = Math.Sqrt(xminxbar);

                        double cp = ((Convert.ToDouble(maxval)) - (Convert.ToDouble(xbar))) / (3 * standart);
                        CP = Convert.ToDecimal(cp);
                    }
                    if (xxminxbar > 0)
                    {
                        standart = Math.Sqrt(xxminxbar);

                        double cp = ((Convert.ToDouble(minval)) - (Convert.ToDouble(xbar1))) / (3 * standart);
                        CPP = Convert.ToDecimal(cp);
                    }
                    //2
                    double TotAvg161 = Convert.ToDouble(ds.Tables[4].Rows[0]["QRAVG16"]);
                    double MAvg161 = Convert.ToDouble(ds.Tables[5].Rows[0]["QRMax16"]);
                    double TotAvg721 = Convert.ToDouble(ds.Tables[6].Rows[0]["QRAVG72"]);
                    double MAvg721 = Convert.ToDouble(ds.Tables[7].Rows[0]["QRMax72"]);

                    double xbar12 = TotAvg161 / TotRow;
                    double xbar11 = TotAvg721 / TotRow;
                    xminxbar2 = (MAvg161 - xbar12) * (MAvg161 - xbar12) / (TotRow - 1);
                    xxminxbar2 = (MAvg721 - xbar11) * (MAvg721 - xbar11) / (TotRow - 1);
                    if (xminxbar2 > 0)
                    {
                        double cp1 = 0;
                        standart1 = Math.Sqrt(xminxbar2);

                        cp1 = ((Convert.ToDouble(maxvald2)) - (Convert.ToDouble(xbar12))) / (3 * standart1);
                        CP1 = Convert.ToDecimal(cp1);

                    }
                    if (xxminxbar2 > 0)
                    {
                        double cp1 = 0;
                        standart1 = Math.Sqrt(xxminxbar2);

                        cp1 = ((Convert.ToDouble(minvald2)) - (Convert.ToDouble(xbar11))) / (3 * standart1);
                        CPP1 = Convert.ToDecimal(cp1);

                    }
                    //3
                    double TotAvg162 = Convert.ToDouble(ds.Tables[8].Rows[0]["QRAVG16"]);
                    double MAvg162 = Convert.ToDouble(ds.Tables[9].Rows[0]["QRMax16"]);
                    double TotAvg722 = Convert.ToDouble(ds.Tables[10].Rows[0]["QRAVG72"]);
                    double MAvg722 = Convert.ToDouble(ds.Tables[11].Rows[0]["QRMax72"]);

                    double xbar2 = TotAvg162 / TotRow;
                    double xbar22 = TotAvg722 / TotRow;
                    xminxbar3 = (MAvg162 - xbar2) * (MAvg162 - xbar2) / (TotRow - 1);
                    xxminxbar3 = (MAvg722 - xbar22) * (MAvg722 - xbar22) / (TotRow - 1);
                    if (xminxbar3 > 0)
                    {
                        double cp2 = 0;
                        standart2 = Math.Sqrt(xminxbar3);

                        cp2 = ((Convert.ToDouble(maxvald3)) - (Convert.ToDouble(xbar2))) / (3 * standart2);
                        CP2 = Convert.ToDecimal(cp2);

                    }
                    if (xxminxbar3 > 0)
                    {
                        double cp2 = 0;
                        standart2 = Math.Sqrt(xxminxbar3);

                        cp2 = ((Convert.ToDouble(minvald3)) - (Convert.ToDouble(xbar2))) / (3 * standart2);
                        CPP2 = Convert.ToDecimal(cp2);

                    }
                    //4
                    double TotAvg163 = Convert.ToDouble(ds.Tables[12].Rows[0]["QRAVG16"]);
                    double MAvg163 = Convert.ToDouble(ds.Tables[13].Rows[0]["QRMax16"]);
                    double TotAvg723 = Convert.ToDouble(ds.Tables[14].Rows[0]["QRAVG72"]);
                    double MAvg723 = Convert.ToDouble(ds.Tables[15].Rows[0]["QRMax72"]);

                    double xbar3 = TotAvg163 / TotRow;
                    double xbar33 = TotAvg723 / TotRow;
                    xminxbar4 = (MAvg163 - xbar3) * (MAvg163 - xbar3) / (TotRow - 1);
                    xxminxbar4 = (MAvg723 - xbar33) * (MAvg723 - xbar33) / (TotRow - 1);
                    if (xminxbar4 > 0)
                    {
                        double cp3 = 0;
                        standart3 = 0;
                        standart3 = Math.Sqrt(xminxbar4);

                        cp3 = ((Convert.ToDouble(maxvald4)) - (Convert.ToDouble(xbar3))) / (3 * standart3);
                        CP3 = Convert.ToDecimal(cp3);

                    }
                    if (xxminxbar4 > 0)
                    {
                        double cp3 = 0;
                        standart3 = 0;
                        standart3 = Math.Sqrt(xminxbar4);

                        cp3 = ((Convert.ToDouble(maxvald4)) - (Convert.ToDouble(xbar33))) / (3 * standart3);
                        CPP3 = Convert.ToDecimal(cp3);

                    }

                }
                else
                {
                    int TotRow = Convert.ToInt32(ds.Tables[12].Rows[0]["rowcoun"]);
                    //1
                    double TotAvg16 = Convert.ToDouble(ds.Tables[0].Rows[0]["QRAVG16"]);
                    double MAvg16 = Convert.ToDouble(ds.Tables[1].Rows[0]["QRMax16"]);
                    double TotAvg72 = Convert.ToDouble(ds.Tables[2].Rows[0]["QRAVG72"]);
                    double MAvg72 = Convert.ToDouble(ds.Tables[3].Rows[0]["QRMax72"]);

                    double xbar = TotAvg16 / TotRow;
                    double xbar1 = TotAvg72 / TotRow;
                    xminxbar = (MAvg16 - xbar) * (MAvg16 - xbar) / (TotRow - 1);
                    xxminxbar = (MAvg72 - xbar1) * (MAvg72 - xbar1) / (TotRow - 1);
                    if (xminxbar > 0)
                    {
                        standart = Math.Sqrt(xminxbar);

                        double cp = ((Convert.ToDouble(maxval)) - (Convert.ToDouble(xbar))) / (3 * standart);
                        CP = Convert.ToDecimal(cp);
                    }
                    if (xxminxbar > 0)
                    {
                        standart = Math.Sqrt(xxminxbar);

                        double cp = ((Convert.ToDouble(minval)) - (Convert.ToDouble(xbar1))) / (3 * standart);
                        CPP = Convert.ToDecimal(cp);
                    }
                    //2
                    double TotAvg161 = Convert.ToDouble(ds.Tables[4].Rows[0]["QRAVG16"]);
                    double MAvg161 = Convert.ToDouble(ds.Tables[5].Rows[0]["QRMax16"]);
                    double TotAvg721 = Convert.ToDouble(ds.Tables[6].Rows[0]["QRAVG72"]);
                    double MAvg721 = Convert.ToDouble(ds.Tables[7].Rows[0]["QRMax72"]);

                    double xbar13 = TotAvg161 / TotRow;
                    double xbar11 = TotAvg721 / TotRow;
                    xminxbar2 = (MAvg161 - xbar13) * (MAvg161 - xbar13) / (TotRow - 1);
                    xxminxbar2 = (MAvg721 - xbar11) * (MAvg721 - xbar11) / (TotRow - 1);
                    if (xminxbar2 > 0)
                    {
                        double cp1 = 0;
                        standart1 = Math.Sqrt(xminxbar2);

                        cp1 = ((Convert.ToDouble(maxvald2)) - (Convert.ToDouble(xbar13))) / (3 * standart1);
                        CP1 = Convert.ToDecimal(cp1);

                    }
                    if (xxminxbar2 > 0)
                    {
                        double cp1 = 0;
                        standart1 = Math.Sqrt(xxminxbar2);

                        cp1 = ((Convert.ToDouble(minvald2)) - (Convert.ToDouble(xbar11))) / (3 * standart1);
                        CPP1 = Convert.ToDecimal(cp1);

                    }
                    //3
                    double TotAvg162 = Convert.ToDouble(ds.Tables[8].Rows[0]["QRAVG16"]);
                    double MAvg162 = Convert.ToDouble(ds.Tables[9].Rows[0]["QRMax16"]);
                    double TotAvg722 = Convert.ToDouble(ds.Tables[10].Rows[0]["QRAVG72"]);
                    double MAvg722 = Convert.ToDouble(ds.Tables[11].Rows[0]["QRMax72"]);

                    double xbar2 = TotAvg162 / TotRow;
                    double xbar22 = TotAvg722 / TotRow;
                    xminxbar3 = (MAvg162 - xbar2) * (MAvg162 - xbar2) / (TotRow - 1);
                    xxminxbar3 = (MAvg722 - xbar22) * (MAvg722 - xbar22) / (TotRow - 1);
                    if (xminxbar3 > 0)
                    {
                        double cp2 = 0;
                        standart2 = Math.Sqrt(xminxbar3);

                        cp2 = ((Convert.ToDouble(maxvald3)) - (Convert.ToDouble(xbar2))) / (3 * standart2);
                        CP2 = Convert.ToDecimal(cp2);

                    }
                    if (xxminxbar3 > 0)
                    {
                        double cp2 = 0;
                        standart2 = Math.Sqrt(xxminxbar3);

                        cp2 = ((Convert.ToDouble(minvald3)) - (Convert.ToDouble(xbar2))) / (3 * standart2);
                        CPP2 = Convert.ToDecimal(cp2);

                    }

                }
            }

            cmd = new SqlCommand("SP_UpdateRouhness", strConnString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QRMaxCP1", SqlDbType.Decimal).Value = CP;
            cmd.Parameters.Add("@QRMaxCP2", SqlDbType.Decimal).Value = CPP;
            cmd.Parameters.Add("@QRMaxCP3", SqlDbType.Decimal).Value = CP1;
            cmd.Parameters.Add("@QRMaxCP4", SqlDbType.Decimal).Value = CPP1;
            cmd.Parameters.Add("@QRMaxCP5", SqlDbType.Decimal).Value = CP2;
            cmd.Parameters.Add("@QRMaxCP6", SqlDbType.Decimal).Value = CPP2;
            cmd.Parameters.Add("@pidno", SqlDbType.VarChar, 50).Value = pid;
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            cmd.Parameters.Add("@shift", SqlDbType.VarChar, 3).Value = shift.ToString();
            if (mode.ToString() == "CP" || mode.ToString() == "UP")
            {
                cmd.Parameters.Add("@QRMaxCP7", SqlDbType.Decimal).Value = CP3;
                cmd.Parameters.Add("@QRMaxCP8", SqlDbType.Decimal).Value = CPP3;
            }
            else
            {
                cmd.Parameters.Add("@QRMaxCP7", SqlDbType.Decimal).Value = Convert.ToDecimal(00.000); 
                cmd.Parameters.Add("@QRMaxCP8", SqlDbType.Decimal).Value = Convert.ToDecimal(00.000); 
            }


            cmd.Parameters.Add("@mode", SqlDbType.VarChar, 5).Value = mode;




        }
        catch (Exception ex)
        {
        }
        finally
        {
            strConnString.Open();
            cmd.ExecuteNonQuery();
            strConnString.Close();
        }
    }

    public string Username
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
        }
    }
    public string Password
    {
        get
        {
            return _passwrod;
        }
        set
        {
            _passwrod = value;
        }
    }
    public string Role
    {
        get
        {
            return _role;
        }
        set
        {
            _role = value;
        }
    }
    public string Date
    {
        get
        {
            return _date;
        }
        set
        {
            _date = value;
        }
    }
    public string RegID
    {
        get
        {
            return _regid;
        }
        set
        {
            _regid = value;

        }
    }
    public string Pagename
    {
        get
        {
            return _pagename;
        }
        set
        {
            _pagename = value;
        }
    }
    public string Reff
    {
        get
        {
            return _reff;
        }
        set
        {
            _reff = value;
        }
    }
    public string save_registrationDA(string username, string password, string role, string date, string repassword)
    {
        string result = "";
        if (role == "1") { userrole = "Super Admin"; }
        if (role == "2") { userrole = "Admin"; }
        if (role == "3") { userrole = "User"; }
        ds = objserver.GetDateset("select * from tbl_Registration where Reg_Username='" + username + "' and Reg_Role='" + userrole + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            result = "F";
        }
        else
        {
            try
            {

                if (role == "1") { userrole = "Super Admin"; }
                if (role == "2") { userrole = "Admin"; }
                if (role == "3") { userrole = "User"; }
                cmd = new SqlCommand("SP_Insertregistration", strConnString);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Reg_Username", SqlDbType.VarChar, 50).Value = username.ToString().Trim(); ;
                cmd.Parameters.Add("@Reg_Userpassword", SqlDbType.VarChar, 50).Value = password.ToString().Trim(); ;
                cmd.Parameters.Add("@Reg_Createdate", SqlDbType.VarChar, 15).Value = date.ToString().Trim(); ;
                cmd.Parameters.Add("@Reg_Role", SqlDbType.VarChar, 25).Value = userrole.ToString().Trim();
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 25).Value ="Active";
                cmd.Parameters.Add("@RePassowrd", SqlDbType.VarChar, 25).Value = repassword.ToString().Trim();
            }

            catch (Exception ex)
            {
            }
            finally
            {
                strConnString.Open();
                cmd.ExecuteNonQuery();
                strConnString.Close();
                result = "S";
            }

        }
        return result.ToString();
    }
    public void save_regpagesDA(string regid, string page,string role,string pagereff)
    {
        try
        {
            if (role == "1") { userrole = "Admin"; }
            if (role == "2") { userrole = "User"; }
            cmd = new SqlCommand("SP_InsertuserRights", strConnString);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UID", SqlDbType.VarChar, 50).Value = Convert.ToInt32(regid);
            cmd.Parameters.Add("@PageURL", SqlDbType.VarChar, 250).Value = page.ToString().Trim();
            cmd.Parameters.Add("@URole", SqlDbType.VarChar, 25).Value = userrole.ToString().Trim();
            cmd.Parameters.Add("@UPages", SqlDbType.VarChar, 250).Value = pagereff.ToString().Trim();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            strConnString.Open();
            cmd.ExecuteNonQuery();
            strConnString.Close();
        }

    }
    public void show_Access_RightsDA(HtmlAnchor link_24q, HtmlAnchor link_6j, HtmlAnchor link_1c, HtmlAnchor link_8n, HtmlAnchor link_3u, HtmlAnchor link_process, HtmlAnchor link_part, HtmlAnchor link_work, HtmlAnchor link_userpage, HtmlAnchor link_time, HtmlAnchor link_laping24, HtmlAnchor link_opt24, HtmlAnchor link_poli24, HtmlAnchor link_register, HtmlAnchor link_dmttemp, HtmlAnchor link_opt2j, HtmlAnchor link_poliJ, HtmlAnchor link_polc, HtmlAnchor link_polu, HtmlAnchor link_poln, HtmlAnchor link_planned, HtmlAnchor link_barcode, HtmlAnchor link_addpages, string userid)
    {
        try
        {
            //cmd = new SqlCommand("SP_SHOW_USER_RIGTHS", strConnString);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@USERID", SqlDbType.VarChar, 50).Value = userid;

            //da = new SqlDataAdapter(cmd);
            //ds = new DataSet();
            //da.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    if (ds.Tables[0].Rows[0]["URole"].ToString().ToLower() == "user")
            //    {
            //        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        //{
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A17724Q Form")
            //        //    {
            //        //        link_24q.Visible = true;
            //        //        link_24q.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A32271C Form")
            //        //    {
            //        //        link_1c.Visible = true;
            //        //        link_1c.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();
            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A44908N Form")
            //        //    {
            //        //        link_8n.Visible = true;
            //        //        link_8n.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();
            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A44983u Form")
            //        //    {
            //        //        link_3u.Visible = true;
            //        //        link_3u.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();
            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A22916J Form")
            //        //    {
            //        //        link_6j.Visible = true;
            //        //        link_6j.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();
            //        //    }

            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "Process Form")
            //        //    {
            //        //        link_process.Visible = true;
            //        //        link_process.HRef = "~/Master" + ds.Tables[0].Rows[i]["PageURL"].ToString();
            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "PartNo Form")
            //        //    {
            //        //        link_part.Visible = true;
            //        //        link_part.HRef = "~/" + ds.Tables[0].Rows[i]["UPages"].ToString();
            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "Time Master Form")
            //        //    {
            //        //        link_time.Visible = true;
            //        //        link_time.HRef = "~/Master" + ds.Tables[0].Rows[i]["PageURL"].ToString();
            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "Work Instruction Form")
            //        //    {
            //        //        link_work.Visible = true;
            //        //        link_work.HRef = "~/WorkInstruction" + ds.Tables[0].Rows[i]["PageURL"].ToString();
            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "User Page Form")
            //        //    {
            //        //        link_userpage.Visible = true;
            //        //        link_userpage.HRef = "~/WorkInstruction" + ds.Tables[0].Rows[i]["UPages"].ToString();
            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "Hourly Production Form")
            //        //    {
            //        //        //link_hourly.Visible = true;
            //        //       // link_hourly.HRef = "~/Productions" + ds.Tables[0].Rows[i]["PageURL"].ToString();
            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "DMT Report Form")
            //        //    {
            //        //        link_dmt.Visible = true;
            //        //        link_dmt.HRef = "~/Reports" + ds.Tables[0].Rows[i]["UPages"].ToString();
            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "OEE Report Form")
            //        //    {
            //        //       // link_oee.Visible = true;
            //        //       // link_oee.HRef = "~/Reports" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "Hourly Production Rerport Form")
            //        //    {
            //        //        //link_hrept.Visible = true;
            //        //        //link_hrept.HRef = "~/Reports" + ds.Tables[0].Rows[i]["PageURL"].ToString();
            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A17724Q-Lapping Form")
            //        //    {
            //        //        link_laping24.Visible = true;
            //        //        link_laping24.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["UPages"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A17724Q-polishing Form")
            //        //    {
            //        //        link_poli24.Visible = true;
            //        //        link_poli24.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A17724Q-opt2QSheet Form")
            //        //    {
            //        //        link_opt24.Visible = true;
            //        //        link_opt24.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "View Chart Form")
            //        //    {
            //        //        link_chart.Visible = true;
            //        //        link_chart.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "View QCSheet Report Form")
            //        //    {
            //        //        link_reports.Visible = true;
            //        //        link_reports.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "DMT Template Form")
            //        //    {
            //        //        link_dmttemp.Visible = true;
            //        //        link_dmttemp.HRef = "~/WorkInstruction" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "Efficiency Form")
            //        //    {
            //        //        link_eff.Visible = true;
            //        //        link_eff.HRef = "~/Productions" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A22916J Oper2")
            //        //    {
            //        //        link_opt2j.Visible = true;
            //        //        link_opt2j.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }

            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A22916J-polishing Form")
            //        //    {
            //        //        link_poliJ.Visible = true;
            //        //        link_poliJ.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A32271C-polishing Form")
            //        //    {
            //        //        link_polc.Visible = true;
            //        //        link_polc.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A44983U-polishing Form")
            //        //    {
            //        //        link_polu.Visible = true;
            //        //        link_polu.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "A44908N-polishing Form")
            //        //    {
            //        //        link_poln.Visible = true;
            //        //        link_poln.HRef = "~/QualityGrid" + "/" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "Efficiency Reports")
            //        //    {
            //        //        link_effreports.Visible = true;
            //        //        link_effreports.HRef = "~/Reports" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "Barcode Template Form")
            //        //    {
            //        //        link_barcode.Visible = true;
            //        //        link_barcode.HRef = "~/Master" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }
            //        //    if (ds.Tables[0].Rows[i]["UPages"].ToString() == "PlannedStopEntry Form")
            //        //    {
            //        //        link_planned.Visible = true;
            //        //        link_planned.HRef = "~/Master" + ds.Tables[0].Rows[i]["PageURL"].ToString();

            //        //    }

            //        //}
            //      //  link_barcode.Visible = true;
            //        //link_planned.Visible = true;
            //        link_polu.Visible = true;
            //        link_polc.Visible = true;
            //        link_24q.Visible = true;
            //        link_1c.Visible = true;
            //        link_8n.Visible = true;
            //        link_3u.Visible = true;
            //        link_6j.Visible = true;
            //        //link_process.Visible = true;
            //       // link_part.Visible = true;
            //       // link_time.Visible = true;
            //       // link_work.Visible = true;
            //        link_reports.Visible = true;
            //        link_chart.Visible = true;
            //        link_opt24.Visible = true;
            //        link_poli24.Visible = true;
            //        link_laping24.Visible = true;
            //        //link_hrept.Visible = true;
            //        //link_oee.Visible = true;
            //       link_dmt.Visible = true;
            //        link_userpage.Visible = true;
            //        //link_hourly.Visible = true;
            //        //link_register.Visible = true;
            //       // link_dmttemp.Visible = true;
            //        link_eff.Visible = true;
            //        link_opt2j.Visible = true;
            //        link_poliJ.Visible = true;
            //        link_poln.Visible = true;
            //        link_effreports.Visible = true;
            //       // link_addpages.Visible = true;

            //        link_barcode.HRef = "~/Master/BarcodeTemplate.aspx";
            //        link_planned.HRef = "~/Master/PlannedStopEntry.aspx";
            //        link_24q.HRef = "~/QualityGrid/QualityGrid.aspx";
            //        link_1c.HRef = "~/QualityGrid/QualitySheetA32271C.aspx";
            //        link_8n.HRef = "~/QualityGrid/QualitySheetA44908N.aspx";
            //        link_3u.HRef = "~/QualityGrid/qualitysheetA44983u.aspx";
            //        link_6j.HRef = "~/QualityGrid/QSA22916J.aspx";
            //        link_effreports.HRef = "~/Reports/EfficiencyReports.aspx";
            //        link_addpages.HRef = "~/Master/AddPages.aspx";
            //        link_process.HRef = "~/Master/Process.aspx";
            //        link_part.HRef = "~/Master/PartNoMaster.aspx";
            //        link_time.HRef = "~/Master/Time_Master.aspx";
            //        link_work.HRef = "~/WorkInstruction/Workinstruction.aspx";
            //        link_reports.HRef = "~/QualityGrid/ViewQCSheetReports.aspx";
            //        link_chart.HRef = "~/QualityGrid/ViewQChart.aspx";
            //        link_opt24.HRef = "~/QualityGrid/opt2QSheetA17724Q.aspx";
            //        link_poli24.HRef = "~/QualityGrid/polishing24Q.aspx";
            //        link_laping24.HRef = "~/QualityGrid/lapping24Q.aspx";
            //        //  link_hrept.HRef = "~/Reports/HourlyProductionRpt.aspx";
            //        // link_oee.HRef = "~/Reports/OEERptFrm.aspx";
            //        link_dmt.HRef = "~/Reports/DMTRptFrm.aspx";
            //        link_userpage.HRef = "~/WorkInstruction/Userpage.aspx";
            //        link_register.HRef = "~/WorkInstruction/RegisrationFrm.aspx";
            //        link_dmttemp.HRef = "~/WorkInstruction/DMTTemplate.aspx";
            //        // link_hourly.HRef = "~/Productions/HourlyProduction.aspx";
            //        link_eff.HRef = "~/Productions/RoutingsFrm.aspx";
            //        link_opt2j.HRef = "~/QualityGrid/opt2QSheetA22916J.aspx";

            //        link_poliJ.HRef = "~/QualityGrid/polishingA22916J.aspx";
            //        link_polu.HRef = "~/QualityGrid/polishingA44983U.aspx";
            //        link_polc.HRef = "~/QualityGrid/polishingA32271C.aspx";
            //        link_poln.HRef = "~/QualityGrid/polishingA44908N.aspx";
            //    }
            //    if (ds.Tables[0].Rows[0]["URole"].ToString().ToLower() == "admin")
            //    {
            //        link_work.Visible = true;
            //        link_dmttemp.Visible = true;
            //        link_work.HRef = "~/WorkInstruction/Workinstruction.aspx";
            //        link_dmttemp.HRef = "~/WorkInstruction/DMTTemplate.aspx";
            //    }
            //    if (ds.Tables[0].Rows[0]["URole"].ToString().ToLower() == "super admin")
            //    {
            link_barcode.Visible = true;
            link_planned.Visible = true;
            link_polu.Visible = true;
            link_polc.Visible = true;
            link_24q.Visible = true;
            link_1c.Visible = true;
            link_8n.Visible = true;
            link_3u.Visible = true;
            link_6j.Visible = true;
            link_process.Visible = true;
            link_part.Visible = true;
            link_time.Visible = true;
            link_work.Visible = true;
            // link_reports.Visible = true;
            //link_chart.Visible = true;
            link_opt24.Visible = true;
            link_poli24.Visible = true;
            link_laping24.Visible = true;
            //link_hrept.Visible = true;
            //link_oee.Visible = true;
            //link_dmt.Visible = true;
            link_userpage.Visible = true;
            //link_hourly.Visible = true;
            link_register.Visible = true;
            link_dmttemp.Visible = true;
            // link_eff.Visible = true;
            link_opt2j.Visible = true;
            link_poliJ.Visible = true;
            link_poln.Visible = true;
            //link_effreports.Visible = true;
            // link_addpages.Visible = true;

            link_barcode.HRef = "~/Master/BarcodeTemplate.aspx";
            link_planned.HRef = "~/Master/PlannedStopEntry.aspx";
            link_24q.HRef = "~/QualityGrid/QualityGrid.aspx";
            link_1c.HRef = "~/QualityGrid/QualitySheetA32271C.aspx";
            link_8n.HRef = "~/QualityGrid/QualitySheetA44908N.aspx";
            link_3u.HRef = "~/QualityGrid/qualitysheetA44983u.aspx";
            link_6j.HRef = "~/QualityGrid/QSA22916J.aspx";
            // link_effreports.HRef = "~/Reports/EfficiencyReports.aspx";
            //link_addpages.HRef = "~/Master/AddPages.aspx";
            link_process.HRef = "~/Master/Process.aspx";
            link_part.HRef = "~/Master/PartNoMaster.aspx";
            link_time.HRef = "~/Master/Time_Master.aspx";
            link_work.HRef = "~/WorkInstruction/Workinstruction.aspx";
            // link_reports.HRef = "~/QualityGrid/ViewQCSheetReports.aspx";
            //link_chart.HRef = "~/QualityGrid/ViewQChart.aspx";
            link_opt24.HRef = "~/QualityGrid/opt2QSheetA17724Q.aspx";
            link_poli24.HRef = "~/QualityGrid/polishing24Q.aspx";
            link_laping24.HRef = "~/QualityGrid/lapping24Q.aspx";
            //  link_hrept.HRef = "~/Reports/HourlyProductionRpt.aspx";
            // link_oee.HRef = "~/Reports/OEERptFrm.aspx";
            // link_dmt.HRef = "~/Reports/DMTRptFrm.aspx";
            link_userpage.HRef = "~/WorkInstruction/Userpage.aspx";
            link_register.HRef = "~/WorkInstruction/RegisrationFrm.aspx";
            link_dmttemp.HRef = "~/WorkInstruction/DMTTemplate.aspx";
            // link_hourly.HRef = "~/Productions/HourlyProduction.aspx";
            //  link_eff.HRef = "~/Productions/RoutingsFrm.aspx";
            link_opt2j.HRef = "~/QualityGrid/opt2QSheetA22916J.aspx";

            link_poliJ.HRef = "~/QualityGrid/polishingA22916J.aspx";
            link_polu.HRef = "~/QualityGrid/polishingA44983U.aspx";
            link_polc.HRef = "~/QualityGrid/polishingA32271C.aspx";
            link_poln.HRef = "~/QualityGrid/polishingA44908N.aspx";
            //    }

            //}
            //else
            //{
            //    link_polu.Visible = true;
            //    link_polc.Visible = true;
            //    link_24q.Visible = true;
            //    link_1c.Visible = true;
            //    link_8n.Visible = true;
            //    link_3u.Visible = true;
            //    link_6j.Visible = true;
            //    //link_process.Visible = true;
            //    // link_part.Visible = true;
            //    // link_time.Visible = true;
            //    // link_work.Visible = true;
            //    link_reports.Visible = true;
            //    link_chart.Visible = true;
            //    link_opt24.Visible = true;
            //    link_poli24.Visible = true;
            //    link_laping24.Visible = true;
            //    //link_hrept.Visible = true;
            //    //link_oee.Visible = true;
            //    link_dmt.Visible = true;
            //    link_userpage.Visible = true;
            //    //link_hourly.Visible = true;
            //    //link_register.Visible = true;
            //    // link_dmttemp.Visible = true;
            //    link_eff.Visible = true;
            //    link_opt2j.Visible = true;
            //    link_poliJ.Visible = true;
            //    link_poln.Visible = true;
            //    link_effreports.Visible = true;
            //    // link_addpages.Visible = true;

            //    link_barcode.HRef = "~/Master/BarcodeTemplate.aspx";
            //    link_planned.HRef = "~/Master/PlannedStopEntry.aspx";
            //    link_24q.HRef = "~/QualityGrid/QualityGrid.aspx";
            //    link_1c.HRef = "~/QualityGrid/QualitySheetA32271C.aspx";
            //    link_8n.HRef = "~/QualityGrid/QualitySheetA44908N.aspx";
            //    link_3u.HRef = "~/QualityGrid/qualitysheetA44983u.aspx";
            //    link_6j.HRef = "~/QualityGrid/QSA22916J.aspx";
            //    link_effreports.HRef = "~/Reports/EfficiencyReports.aspx";
            //    link_addpages.HRef = "~/Master/AddPages.aspx";
            //    link_process.HRef = "~/Master/Process.aspx";
            //    link_part.HRef = "~/Master/PartNoMaster.aspx";
            //    link_time.HRef = "~/Master/Time_Master.aspx";
            //    link_work.HRef = "~/WorkInstruction/Workinstruction.aspx";
            //    link_reports.HRef = "~/QualityGrid/ViewQCSheetReports.aspx";
            //    link_chart.HRef = "~/QualityGrid/ViewQChart.aspx";
            //    link_opt24.HRef = "~/QualityGrid/opt2QSheetA17724Q.aspx";
            //    link_poli24.HRef = "~/QualityGrid/polishing24Q.aspx";
            //    link_laping24.HRef = "~/QualityGrid/lapping24Q.aspx";
            //    //  link_hrept.HRef = "~/Reports/HourlyProductionRpt.aspx";
            //    // link_oee.HRef = "~/Reports/OEERptFrm.aspx";
            //    link_dmt.HRef = "~/Reports/DMTRptFrm.aspx";
            //    link_userpage.HRef = "~/WorkInstruction/Userpage.aspx";
            //    link_register.HRef = "~/WorkInstruction/RegisrationFrm.aspx";
            //    link_dmttemp.HRef = "~/WorkInstruction/DMTTemplate.aspx";
            //    // link_hourly.HRef = "~/Productions/HourlyProduction.aspx";
            //    link_eff.HRef = "~/Productions/RoutingsFrm.aspx";
            //    link_opt2j.HRef = "~/QualityGrid/opt2QSheetA22916J.aspx";

            //    link_poliJ.HRef = "~/QualityGrid/polishingA22916J.aspx";
            //    link_polu.HRef = "~/QualityGrid/polishingA44983U.aspx";
            //    link_polc.HRef = "~/QualityGrid/polishingA32271C.aspx";
            //    link_poln.HRef = "~/QualityGrid/polishingA44908N.aspx";
            //}
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
    public void Login_userDA(string username, string password, string shift)
    {
        lock (thisLock)
        {
            try
            {
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

                cmd = new SqlCommand("SP_LOIGN", strConnString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar, 25).Value = username.ToString().Trim();
                cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar, 15).Value = password.ToString().Trim();
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 15).Value = "Active";

                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                ds.Tables.Clear();
                ds.Clear();
                ds.Reset();
                da.Fill(ds, "tbl_Registration");
                //if (ds.Tables[0].Rows.Count > 0)
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][1] != DBNull.Value)
                {
                    HttpContext.Current.Session["User_ID"] = ds.Tables[0].Rows[0]["Reg_ID"].ToString();
                    HttpContext.Current.Session["User_Name"] = ds.Tables[0].Rows[0]["Reg_Username"].ToString();
                    HttpContext.Current.Session["Logtime"] = DateTime.Now.ToShortTimeString();
                    //HttpContext.Current.Session["LogDate"] = DateTime.Now.ToShortDateString();
                    if (ds.Tables[0].Rows[0]["Reg_Role"].ToString().ToLower() == "user")
                    {
                        if ((now > start) && (now < end))
                        {
                            shift = "C";
                        }
                        else
                        {
                            if (Convert.ToDateTime(Current) >= Ffrom && Convert.ToDateTime(Current) < Fto)
                            {
                                shift = "A";
                            }
                            if (Convert.ToDateTime(Current) >= Sfrom && Convert.ToDateTime(Current) < Sto)
                            { shift = "B"; }
                            if (Convert.ToDateTime(Current) >= Tfrom && Convert.ToDateTime(Current) < Tto)
                            {
                                shift = "C";
                            }
                        }
                    }
                    HttpContext.Current.Session["Shift"] = shift.ToString();
                    if (shift == "C")
                    {
                        if ((now > start) && (now < end))
                        {
                            HttpContext.Current.Session["LogDate"] = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddDays(-1).ToShortDateString();
                        }
                        else
                        {
                            HttpContext.Current.Session["LogDate"] = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToShortDateString();
                        }
                    }
                    else
                    {
                        HttpContext.Current.Session["LogDate"] = DateTime.Now.ToShortDateString();
                    }

                    HttpContext.Current.Session["User_Role"] = ds.Tables[0].Rows[0]["Reg_Role"].ToString();
                    HttpContext.Current.Session.Timeout = 300;
                    string usertype = ds.Tables[0].Rows[0]["Reg_Role"].ToString();

                    if (ds.Tables[0].Rows[0]["Reg_Role"].ToString().ToLower() == "admin")
                    {
                        HttpContext.Current.Session["PID_ID"] = "1001";
                        HttpContext.Current.Response.Redirect("~/WorkInstruction/Userpage.aspx", false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                    if (ds.Tables[0].Rows[0]["Reg_Role"].ToString().ToLower() == "super admin")
                    {
                        HttpContext.Current.Session["PID_ID"] = "1000";
                        HttpContext.Current.Response.Redirect("~/WorkInstruction/Workinstruction.aspx", false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                    if (ds.Tables[0].Rows[0]["Reg_Role"].ToString().ToLower() == "user")
                    {
                        HttpContext.Current.Response.Redirect("Home.htm", false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }

                    //HttpContext.Current.Response.Write(System.Diagnostics.EventLog.WriteEntry("CustomEventLog", "Message"));
                    //System.Diagnostics.EventLog.WriteEntry("CustomEventLog", "Message");
                }
                else
                {
                }


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
                ExceptionLogging.SendExcepToDB(ex);
            }
            finally
            {
            }
        }
    }
    public DataSet get_qualitysheetdataDA(string mode)
    {
        if (mode == "Q")
        {
            query="select * from QualitySheet";
        }
        if (mode == "J")
        {
            query = "select * from QualitySheetA22916J";
        }
       
        try
        {
            cmd = new SqlCommand(query, strConnString);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
        return ds;
    }
    public void insertupdatereportsDA(string filename, string filepath, int createdby, DateTime createdon, string shift, string operat)
    {
        try
        {
            //string pid = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString(); //HttpContext.Current.Session["PID_ID"].ToString();
            string pid = createdon.Day.ToString() + "." + createdon.Month.ToString() + "." + createdon.Year.ToString() + "_" + shift + "_" + HttpContext.Current.Session["machine"].ToString(); //HttpContext.Current.Session["PID_ID"].ToString();
            string partno =  HttpContext.Current.Session["PartNo"].ToString();
            string operation = HttpContext.Current.Session["Operation"].ToString();
            string machine = HttpContext.Current.Session["machine"].ToString();
            string unit = HttpContext.Current.Session["Unit"].ToString();
            string op = "";
            if (operation == "1" || operation == "2")
            {
                if (operation == "1")
                {
                    op = "OP1";
                }
                if (operation == "2")
                {
                    op = "OP2";
                }
            }
            else
            {
                op = operation.ToString();
            }
            cmd = new SqlCommand("SP_GETREPORTS", strConnString);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PRDPN", SqlDbType.VarChar, 20).Value = partno;
            cmd.Parameters.Add("@PIDNO", SqlDbType.VarChar, 20).Value = pid;
            cmd.Parameters.Add("@SHIFT", SqlDbType.VarChar, 20).Value = shift;
            cmd.Parameters.Add("@Opertaion", SqlDbType.VarChar, 20).Value = op.ToString();
            //cmd.Parameters.Add("@unit", SqlDbType.VarChar, 20).Value = unit;
            //cmd.Parameters.Add("@Machinename", SqlDbType.VarChar, 20).Value = machine;
            da = new SqlDataAdapter("SELECT * FROM QSReportFile WHERE PID_No='" + pid + "' AND Product_PN='" + partno + "' and Operantion='" + op + "' ", strConnString);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                mode = "U";
            }
            else
            {
                mode = "I";
            }

            cmd = new SqlCommand("sp_insupdreportfile", strConnString);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@FUid", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@FClient_ID", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@FileName", SqlDbType.VarChar, 500).Value = filename;
            cmd.Parameters.Add("@FilePath", SqlDbType.VarChar, 500).Value = filepath;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = createdby;
            cmd.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = createdon;
            cmd.Parameters.Add("@PID_No", SqlDbType.VarChar, 50).Value = pid;
            cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 3).Value = shift;
            cmd.Parameters.Add("@Operator", SqlDbType.VarChar, 30).Value = operat;
            cmd.Parameters.Add("@Product_PN", SqlDbType.VarChar, 20).Value = partno;
            cmd.Parameters.Add("@PID_Text", SqlDbType.VarChar, 50).Value = pid;
            cmd.Parameters.Add("@Operantion", SqlDbType.VarChar, 50).Value = op.ToString();
            cmd.Parameters.Add("@mode", SqlDbType.VarChar, 5).Value = mode;
            cmd.Parameters.Add("@Machinename", SqlDbType.VarChar, 50).Value = machine;
            cmd.Parameters.Add("@machine_text", SqlDbType.VarChar, 50).Value = machine;
            cmd.Parameters.Add("@Suppliername", SqlDbType.VarChar, 50).Value = "";
            cmd.Parameters.Add("@prtno", SqlDbType.VarChar, 30).Value = partno;
            cmd.Parameters.Add("@unit", SqlDbType.VarChar, 30).Value = unit;
        }
        catch (Exception ex)
        {
        }
        finally
        {
            strConnString.Open();
            cmd.ExecuteNonQuery();
            strConnString.Close();
        }
    }

    public string generate_excelDA(string shift, string prodn_no1, string operation, string pidno)
    {
        try
        {
           
            strConnString.Open();
            cmd = new SqlCommand("sp_getqualityreports", strConnString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pidno", SqlDbType.VarChar,50).Value = pidno;
            cmd.Parameters.Add("@shift", SqlDbType.VarChar,3).Value = shift;
            cmd.Parameters.Add("@prodn", SqlDbType.VarChar,50).Value = prodn_no1;
            cmd.Parameters.Add("@operation", SqlDbType.VarChar,20).Value = operation;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                strPath = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                string filepath = strPath;
                string FullFilePath = strPath;
                FileInfo file = new FileInfo(FullFilePath);
                if (file.Exists)
                {
                    result = "S";
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" + file.Name);
                    HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    HttpContext.Current.Response.WriteFile(file.FullName);
                    HttpContext.Current.Response.End();
                }
                else
                {
                    result = "F";
                }
            }
            else
            {
                result = "F";
            }
            
        }
        catch (Exception ex)
        {
        }
        finally
        {
            strConnString.Close();
        }
        return result.ToString();
    }
    //public void load_pidDA( string prodn_no, string operation)
    //{
    //    ds = objserver.GetDateset(" select '0' PID_No,'-Select-' PID_Text union select distinct PID_No,PID_Text from QSReportFile where Product_PN='" + prodn_no + "' and Operantion='" + operation + "' order by PID_No asc");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            sld_pidno.DataTextField = "PID_Text";
    //            sld_pidno.DataValueField = "PID_No";
    //            sld_pidno.DataSource = ds.Tables[0];
    //            sld_pidno.DataBind();
    //        }
    //        else
    //        {
    //        }
    //    }
    //}
    public void load_shtDA(HtmlSelect txt_mchn, string shift)
    {
        ds = objserver.GetDateset(" select '0' Machinename,'-Select-' machine_text union select distinct Machinename,machine_text from QSReportFile where Shift='" + shift + "' order by Machinename asc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_mchn.DataTextField = "machine_text";
                txt_mchn.DataValueField = "Machinename";
                txt_mchn.DataSource = ds.Tables[0];
                txt_mchn.DataBind();
            }
            else
            {
            }
        }
    }
    public void load_userDA(HtmlSelect ddl_operator)
    {
        ds = objserver.GetDateset("select '-Select-' Operator,'-Select-' Operator union select distinct Operator,operator from QSReportFile order by 1 asc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_operator.DataValueField = "Operator";
            ddl_operator.DataTextField = "Operator";
            ddl_operator.DataSource = ds.Tables[0];
            ddl_operator.DataBind();

        }
        else
        {
        }
    }
    public void show_pagesDA(HtmlAnchor link_user, HtmlAnchor link_admin, string user)
    {
        ds=objserver.GetDateset("select * from tbl_Registration where Reg_ID='"+Convert.ToInt32(user)+"'");
        string Role = ds.Tables[0].Rows[0]["Reg_Role"].ToString();
      // HttpContext.Current.Session["User"] = Role.ToString();
       
        
    }
    public void getuserdetailsDA(string pidno)
    {
        HttpContext.Current.Session["PID_ID"] = pidno.ToString();
        HttpContext.Current.Response.Redirect("~/WorkInstruction/Userpage.aspx");


    }
    public void showprodataDA(HtmlAnchor link_data, string username, string partno, string operation)
    {
        if (username.ToLower().ToString() == "user")
        {
            if (partno == "A17724Q" && operation == "1" && HttpContext.Current.Session["Process"].ToString() == "Baker")
            {
                link_data.HRef = "../QualityGrid/QualityGrid.aspx";
            }
            if (partno == "A17724Q" && operation == "1" && HttpContext.Current.Session["Process"].ToString() == "Manual")
            {
                link_data.HRef = "../QualityGrid/QualityGridManual.aspx";
            }
            if (partno == "A17724Q" && operation == "2")
            {
                link_data.HRef = "QualityGrid/opt2QSheetA17724Q.aspx";
            }
            if (partno == "A17724Q" && operation == "Polishing" && HttpContext.Current.Session["Process"].ToString() == "Baker")
            {
                link_data.HRef = "../QualityGrid/polishing24Q.aspx";
            }
            if (partno == "A17724Q" && operation == "Polishing" && HttpContext.Current.Session["Process"].ToString() == "Manual")
            {
                link_data.HRef = "../QualityGrid/polishingManual24Q.aspx";
            }
            if (partno == "A17724Q" && operation == "Lapping")
            {
                link_data.HRef = "QualityGrid/lapping24Q.aspx";
            }
            if (partno == "A22916J" && operation == "1")
            {
                link_data.HRef = "QualityGrid/QSA22916J.aspx";
            }
            if (partno == "A22916J" && operation == "2")
            {
                link_data.HRef = "QualityGrid/opt2QSheetA22916J.aspx";
            }
            if (partno == "A22916J" && operation == "Lapping")
            {
                link_data.HRef = "QualityGrid/lapping24Q.aspx";
            }
            if (partno == "A22916J" && operation == "Polishing")
            {
                link_data.HRef = "QualityGrid/polishingA22916J.aspx";
            }

            if (partno == "A44983U" && operation == "1")
            {
                link_data.HRef = "QualityGrid/qualitysheetA44983u.aspx";
            }
            if (partno == "A44983U" && operation == "Polishing")
            {
                link_data.HRef = "QualityGrid/polishingA44983U.aspx";
            }
            if (partno == "A44983U" && operation == "Lapping")
            {
                link_data.HRef = "QualityGrid/lapping24Q.aspx";
            }
            if (partno == "A32271C" && operation == "1")
            {
                link_data.HRef = "QualityGrid/QualitySheetA32271C.aspx";
            }
            if (partno == "A32271C" && operation == "Polishing")
            {
                link_data.HRef = "QualityGrid/polishingA32271C.aspx";
            }
            if (partno == "A32271C" && operation == "Lapping")
            {
                link_data.HRef = "QualityGrid/lapping24Q.aspx";
            }

            if (partno == "A44908N" && operation == "1")
            {
                link_data.HRef = "QualityGrid/QualitySheetA44908N.aspx";
            }
            if (partno == "A44908N" && operation == "Polishing")
            {
                link_data.HRef = "QualityGrid/polishingA44908N.aspx";
            }
            if (partno == "A44908N" && operation == "Lapping")
            {
                link_data.HRef = "QualityGrid/lapping24Q.aspx";
            }
        }
        else
        {
        }
    }

    public void showprodataDA1(HtmlAnchor link_data, string username, string partno, string operation)
    {
        if (username.ToLower().ToString() == "user")
        {
            if (partno == "A17724Q" && operation == "1" && HttpContext.Current.Session["Process"].ToString() == "Baker")
            {
                link_data.HRef = "../QualityGrid/QualityGrid.aspx";
            }
            if (partno == "A17724Q" && operation == "1" && HttpContext.Current.Session["Process"].ToString() == "Manual")
            {
                link_data.HRef = "../QualityGrid/QualityGridManual.aspx";
            }
            if (partno == "A17724Q" && operation == "2")
            {
                link_data.HRef = "../QualityGrid/opt2QSheetA17724Q.aspx";
            }
            if (partno == "A17724Q" && operation == "Polishing" && HttpContext.Current.Session["Process"].ToString() == "Baker")
            {
                link_data.HRef = "../QualityGrid/polishing24Q.aspx";
            }
            if (partno == "A17724Q" && operation == "Polishing" && HttpContext.Current.Session["Process"].ToString() == "Manual")
            {
                link_data.HRef = "../QualityGrid/polishingManual24Q.aspx";
            }
            if (partno == "A17724Q" && operation == "Lapping")
            {
                link_data.HRef = "../QualityGrid/lapping24Q.aspx";
            }
            if (partno == "A22916J" && operation == "1")
            {
                link_data.HRef = "../QualityGrid/QSA22916J.aspx";
            }
            if (partno == "A22916J" && operation == "2")
            {
                link_data.HRef = "../QualityGrid/opt2QSheetA22916J.aspx";
            }
            if (partno == "A22916J" && operation == "Lapping")
            {
                link_data.HRef = "../QualityGrid/lapping24Q.aspx";
            }
            if (partno == "A22916J" && operation == "Polishing")
            {
                link_data.HRef = "../QualityGrid/polishingA22916J.aspx";
            }

            if (partno == "A44983U" && operation == "1")
            {
                link_data.HRef = "../QualityGrid/qualitysheetA44983u.aspx";
            }
            if (partno == "A44983U" && operation == "Polishing")
            {
                link_data.HRef = "../QualityGrid/polishingA44983U.aspx";
            }
            if (partno == "A44983U" && operation == "Lapping")
            {
                link_data.HRef = "../QualityGrid/lapping24Q.aspx";
            }
            if (partno == "A32271C" && operation == "1")
            {
                link_data.HRef = "../QualityGrid/QualitySheetA32271C.aspx";
            }
            if (partno == "A32271C" && operation == "Polishing")
            {
                link_data.HRef = "../QualityGrid/polishingA32271C.aspx";
            }
            if (partno == "A32271C" && operation == "Lapping")
            {
                link_data.HRef = "../QualityGrid/lapping24Q.aspx";
            }
            if (partno == "A44908N" && operation == "1")
            {
                link_data.HRef = "../QualityGrid/QualitySheetA44908N.aspx";
            }
            if (partno == "A44908N" && operation == "Polishing")
            {
                link_data.HRef = "../QualityGrid/polishingA44908N.aspx";
            }
            if (partno == "A44908N" && operation == "Lapping")
            {
                link_data.HRef = "../QualityGrid/lapping24Q.aspx";
            }
        }
        else
        {
        }
    }

   
}
