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
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Summary description for DBServer
/// </summary>
public class DBServer
{
    
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ToString();
    public SqlCommand cmd;
    public static String[] table = { "Test Bench", "Painting", "Valve", "Block", "Shaft" };

    public string query;
    public string PartNo { set; get; }
    public string Process { set; get; }
    public string Department { set; get; }
    public string Machinename { set; get; }
    public string fromdate { set; get; }
    public string todate { set; get; }
    public string shift { set; get; }
    public string date { set; get; }
    public string month1 { set; get; }
    public string ttl { set; get; }
    public string tttl { set; get; }
    public string month11 { set; get; }
    public string ttl1 { set; get; }
    public string DowntimeType { set; get; }
    public string DowntimeType1 { set; get; }
    public string TRS { set; get; }
    public string TRS1 { set; get; }
    public string TRG { set; get; }
    public string TRG1 { set; get; }

    public DataSet objds;
    public SqlDataAdapter objda;
    public string Query = "";

    public DataRow tr;

    public DataSet GetDateset(string query)
    {
        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            
            ExceptionLogging.SendExcepToDB(ex);
            throw ex;
        }
    }
    public DataSet ViewAllDMTTemplateByPartNO(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewAllDMTDetailbyPartNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@specificpart", db.PartNo);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet machinereport(string shift, string unit, string mchn, string process, DateTime frmtm, DateTime totm)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {

            SqlCommand cmdddd1 = new SqlCommand("Delete from machinereport", con);
            SqlDataAdapter adp1 = new SqlDataAdapter(cmdddd1);
            con.Open();
            cmdddd1.ExecuteNonQuery();
            con.Close();

            DataSet ds = new DataSet();


            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewMachinereport", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@mchn", mchn);
            cmd.Parameters.AddWithValue("@process", process);
            cmd.Parameters.AddWithValue("@frmtm", frmtm);
            cmd.Parameters.AddWithValue("@totm", totm);
            cmd.Parameters.AddWithValue("@shift", shift);
            cmd.Parameters.AddWithValue("@unit", unit);
            ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string mcname = ds.Tables[0].Rows[i]["MachineName"].ToString();
                    string prdqty = ds.Tables[0].Rows[i]["ProdQty"].ToString();
                    string trs = ds.Tables[0].Rows[i]["TRS"].ToString();
                    string plannedstp = ds.Tables[0].Rows[i]["PlannedStop"].ToString();
                    string downtymloss = ds.Tables[0].Rows[i]["DowntimeTotal"].ToString();

                    SqlCommand cmdd = new SqlCommand("insert into machinereport (machinename,OEE,plannedstop,producedqty,downtimeloss) values('" + mcname + "','" + trs + "','" + plannedstp + "','" + prdqty + "','" + downtymloss + "')", con);
                    SqlDataAdapter daa = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                    SqlCommand cmmd = new SqlCommand("select MachineName,DowntimeType from EfficiencyCalculaus where EffDate>='" + Convert.ToDateTime(frmtm) + "' and EffDate<='" + Convert.ToDateTime(totm) + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmmd);
                    DataSet dss = new DataSet();
                    daa1.Fill(dss);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < dss.Tables[0].Rows.Count; j++)
                        {
                            string mchnname = dss.Tables[0].Rows[j]["MachineName"].ToString();

                            if (mcname == mchnname)
                            {
                                string downtype = "";

                                if (unit == "ALL")
                                {
                                    SqlDataAdapter sqladp = new SqlDataAdapter(" Select DowntimeType,COUNT(DowntimeType)as DowntimeType_Count from EfficiencyCalculaus where MachineName='" + mcname + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + frmtm + "' and EffDate<='" + totm + "'and unit in ('MBU','ABU')   GROUP BY DowntimeType ", con);
                                    DataSet dssqladp = new DataSet();
                                    sqladp.Fill(dssqladp);
                                    for (int k = 0; k < dssqladp.Tables[0].Rows.Count; k++)
                                    {
                                        string downtypecount = "";
                                        string downtyp = "";
                                        downtyp = dssqladp.Tables[0].Rows[k]["DowntimeType"].ToString();

                                        downtypecount = dssqladp.Tables[0].Rows[k]["DowntimeType_Count"].ToString();
                                        downtype += downtyp + '[' + downtypecount.ToString() + ']' + "<br />" + ',';
                                    }
                                }
                                else
                                {
                                    SqlDataAdapter sqladp = new SqlDataAdapter(" Select DowntimeType,COUNT(DowntimeType)as DowntimeType_Count from EfficiencyCalculaus where MachineName='" + mcname + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + frmtm + "' and EffDate<='" + totm + "'and unit ='" + unit + "'   GROUP BY DowntimeType ", con);
                                    DataSet dssqladp = new DataSet();
                                    sqladp.Fill(dssqladp);
                                    for (int k = 0; k < dssqladp.Tables[0].Rows.Count; k++)
                                    {
                                        string downtypecount = "";
                                        string downtyp = "";
                                        downtyp = dssqladp.Tables[0].Rows[k]["DowntimeType"].ToString();

                                        downtypecount = dssqladp.Tables[0].Rows[k]["DowntimeType_Count"].ToString();
                                        downtype += downtyp + '[' + downtypecount.ToString() + ']' + "<br />" + ',';
                                    }
                                }
                                
                                downtype = downtype.Remove(downtype.Length - 1);
                                SqlCommand cmd1 = new SqlCommand("update machinereport set downtimetype='" + downtype + "' where machinename='" + mcname + "'", con);
                                SqlDataAdapter daa2 = new SqlDataAdapter(cmd1);
                                con.Open();
                                cmd1.ExecuteNonQuery();
                                con.Close();

                            }

                        }
                    }
                }
            }

            SqlCommand cmd2 = new SqlCommand("select * from machinereport", con);
            SqlDataAdapter daa4 = new SqlDataAdapter(cmd2);
            DataSet dss2 = new DataSet();
            daa4.Fill(dss2);

            return dss2;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet departmentreport(string shift, string unit, string mchn, string process, DateTime frmtm, DateTime totm)
    {
        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds1 = new DataSet();
            ds1.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmdddd = new SqlCommand("[ClearDepart]", con);
            cmdddd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmdddd);
            con.Open();
            cmdddd.ExecuteNonQuery();
            con.Close();


            DataSet ds = new DataSet();
            decimal trs = 0;
            decimal planstp = 0;
            decimal downtym = 0;
            decimal prodQty = 0;
            string downtype = "";
            string Shift = "";
            string fromdate=Convert.ToDateTime(frmtm).ToString("yyyy-MM-dd");
            string todate = Convert.ToDateTime(totm).ToString("yyyy-MM-dd");

            for (int i = 0; i < table.Length; i++)
            {

                ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                if (unit == "ALL")
                {
                    SqlDataAdapter da = new SqlDataAdapter(" Select Shift,TRS,DowntimeTotal,PlannedStop,DowntimeType,ProdQty from EfficiencyCalculaus where department='" + table[i] + "' and MachineName='" + mchn + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + fromdate + "' and EffDate<='" + todate + "'and unit in ('MBU','ABU')  ", con);
                    ds = new DataSet();
                    da.Fill(ds);
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter(" Select Shift,TRS,DowntimeTotal,PlannedStop,DowntimeType,ProdQty from EfficiencyCalculaus where department='" + table[i] + "' and MachineName='" + mchn + "'and Operation='" + process + "' and Shift='" + shift + "' and unit='" + unit + "' and EffDate>='" + fromdate + "' and EffDate<='" + todate + "'", con);
                    ds = new DataSet();
                    da.Fill(ds);
                }
               
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (table[i] == "Test Bench")
                    {
                        int id1 = 1;
                        int id2 = 2;
                        int id3 = 3;
                        int id4 = 4;
                        int id5 = 5;
                        int id6 = 6;

                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                           
                            trs = trs + Convert.ToDecimal(ds.Tables[0].Rows[j]["TRS"].ToString());
                            planstp = planstp + Convert.ToDecimal(ds.Tables[0].Rows[j]["PlannedStop"].ToString());
                            downtym = downtym + Convert.ToDecimal(ds.Tables[0].Rows[j]["DowntimeTotal"].ToString());
                            prodQty = prodQty + Convert.ToDecimal(ds.Tables[0].Rows[j]["ProdQty"].ToString());
                            //downtype = downtype + ',' + ds.Tables[0].Rows[j]["DowntimeType"].ToString();
                            Shift = ds.Tables[0].Rows[0]["Shift"].ToString();
                        }
                        string downtypecount = "";
                        string downtyp = "";

                        if (unit == "ALL")
                        {
                            SqlDataAdapter sqladp = new SqlDataAdapter(" Select DowntimeType,COUNT(DowntimeType)as DowntimeType_Count from EfficiencyCalculaus where department='" + table[i] + "' and MachineName='" + mchn + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + frmtm + "' and EffDate<='" + totm + "'and unit in ('MBU','ABU') GROUP BY DowntimeType ", con);
                            DataSet dssqladp = new DataSet();
                            sqladp.Fill(dssqladp);
                            for (int k = 0; k < dssqladp.Tables[0].Rows.Count; k++)
                            {

                                downtyp = dssqladp.Tables[0].Rows[k]["DowntimeType"].ToString();

                                downtypecount = dssqladp.Tables[0].Rows[k]["DowntimeType_Count"].ToString();
                                downtype += downtyp + '[' + downtypecount.ToString() + ']' + "<br />" + ',';

                               
                            }
                        }
                        else
                        {
                            SqlDataAdapter sqladp = new SqlDataAdapter(" Select DowntimeType,COUNT(DowntimeType)as DowntimeType_Count from EfficiencyCalculaus where department='" + table[i] + "' and MachineName='" + mchn + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + frmtm + "' and EffDate<='" + totm + "'and unit ='" + unit + "' GROUP BY DowntimeType ", con);
                            DataSet dssqladp = new DataSet();
                            sqladp.Fill(dssqladp);
                            for (int k = 0; k < dssqladp.Tables[0].Rows.Count; k++)
                            {

                                downtyp = dssqladp.Tables[0].Rows[k]["DowntimeType"].ToString();

                                downtypecount = dssqladp.Tables[0].Rows[k]["DowntimeType_Count"].ToString();
                                downtype += downtyp + '[' + downtypecount.ToString() + ']' + "<br />" + ',';

                            }
                        }
                        
                        downtype = downtype.Remove(downtype.Length - 1);
                        SqlCommand cmdd = new SqlCommand("update Departmentnew set TestBench='" + trs + "' where id='" + id1 + "'", con);
                        SqlDataAdapter daa = new SqlDataAdapter(cmdd);
                        con.Open();
                        cmdd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd = new SqlCommand("update Departmentnew set TestBench='" + prodQty + "' where id='" + id2 + "'", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmmmd = new SqlCommand("update Departmentnew set TestBench='" + Shift + "' where id='" + id3 + "'", con);
                        SqlDataAdapter da111 = new SqlDataAdapter(cmmmd);
                        con.Open();
                        cmmmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd1 = new SqlCommand("update Departmentnew set TestBench='" + planstp + "' where id='" + id4 + "'", con);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd2 = new SqlCommand("update Departmentnew set TestBench='" + downtym + "' where id='" + id5 + "'", con);
                        SqlDataAdapter da3 = new SqlDataAdapter(cmd2);
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd3 = new SqlCommand("update Departmentnew set TestBench='" + downtype + "' where id='" + id6 + "'", con);
                        SqlDataAdapter da4 = new SqlDataAdapter(cmd3);
                        con.Open();
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }
                    if (table[i] == "Painting")
                    {
                        int id1 = 1;
                        int id2 = 2;
                        int id3 = 3;
                        int id4 = 4;
                        int id5 = 5;
                        int id6 = 6;

                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            trs = trs + Convert.ToDecimal(ds.Tables[0].Rows[j]["TRS"].ToString());
                            planstp = planstp + Convert.ToDecimal(ds.Tables[0].Rows[j]["PlannedStop"].ToString());
                            downtym = downtym + Convert.ToDecimal(ds.Tables[0].Rows[j]["DowntimeTotal"].ToString());
                            prodQty = prodQty + Convert.ToDecimal(ds.Tables[0].Rows[j]["ProdQty"].ToString());
                            //downtype = downtype + ',' + ds.Tables[0].Rows[j]["DowntimeType"].ToString();
                            Shift =  ds.Tables[0].Rows[0]["Shift"].ToString();

                        }
                       
                        string downtypecount = "";
                        string downtyp = "";

                        if (unit == "ALL")
                        {
                            SqlDataAdapter sqladp = new SqlDataAdapter(" Select DowntimeType,COUNT(DowntimeType)as DowntimeType_Count from EfficiencyCalculaus where department='" + table[i] + "' and MachineName='" + mchn + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + frmtm + "' and EffDate<='" + totm + "'and unit in ('MBU','ABU') GROUP BY DowntimeType ", con);
                            DataSet dssqladp = new DataSet();
                            sqladp.Fill(dssqladp);
                            for (int k = 0; k < dssqladp.Tables[0].Rows.Count; k++)
                            {

                                downtyp = dssqladp.Tables[0].Rows[k]["DowntimeType"].ToString();

                                downtypecount = dssqladp.Tables[0].Rows[k]["DowntimeType_Count"].ToString();
                                downtype += downtyp + '[' + downtypecount.ToString() + ']' + "<br />" + ',';

                            }
                        }
                        else
                        {
                            SqlDataAdapter sqladp = new SqlDataAdapter(" Select DowntimeType,COUNT(DowntimeType)as DowntimeType_Count from EfficiencyCalculaus where department='" + table[i] + "' and MachineName='" + mchn + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + frmtm + "' and EffDate<='" + totm + "'and unit ='" + unit + "' GROUP BY DowntimeType ", con);
                            DataSet dssqladp = new DataSet();
                            sqladp.Fill(dssqladp);
                            for (int k = 0; k < dssqladp.Tables[0].Rows.Count; k++)
                            {

                                downtyp = dssqladp.Tables[0].Rows[k]["DowntimeType"].ToString();

                                downtypecount = dssqladp.Tables[0].Rows[k]["DowntimeType_Count"].ToString();
                                downtype += downtyp + '[' + downtypecount.ToString() + ']' + "<br />" + ',';

                            }
                        }
                        downtype = downtype.Remove(downtype.Length - 1);
                        SqlCommand cmdd = new SqlCommand("update Departmentnew set Painting='" + trs + "' where id='" + id1 + "'", con);
                        SqlDataAdapter daa = new SqlDataAdapter(cmdd);
                        con.Open();
                        cmdd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd = new SqlCommand("update Departmentnew set Painting='" + prodQty + "' where id='" + id2 + "'", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmmmd = new SqlCommand("update Departmentnew set Painting='" + Shift + "' where id='" + id3 + "'", con);
                        SqlDataAdapter da111 = new SqlDataAdapter(cmmmd);
                        con.Open();
                        cmmmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd1 = new SqlCommand("update Departmentnew set Painting='" + planstp + "' where id='" + id4 + "'", con);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd2 = new SqlCommand("update Departmentnew set Painting='" + downtym + "' where id='" + id5 + "'", con);
                        SqlDataAdapter da3 = new SqlDataAdapter(cmd2);
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd3 = new SqlCommand("update Departmentnew set Painting='" + downtype + "' where id='" + id6 + "'", con);
                        SqlDataAdapter da4 = new SqlDataAdapter(cmd3);
                        con.Open();
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }
                    if (table[i] == "Valve")
                    {
                        int id1 = 1;
                        int id2 = 2;
                        int id3 = 3;
                        int id4 = 4;
                        int id5 = 5;
                        int id6 = 6;

                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            trs = trs + Convert.ToDecimal(ds.Tables[0].Rows[j]["TRS"].ToString());
                            planstp = planstp + Convert.ToDecimal(ds.Tables[0].Rows[j]["PlannedStop"].ToString());
                            downtym = downtym + Convert.ToDecimal(ds.Tables[0].Rows[j]["DowntimeTotal"].ToString());
                            prodQty = prodQty + Convert.ToDecimal(ds.Tables[0].Rows[j]["ProdQty"].ToString());
                            //downtype = downtype +','+ ds.Tables[0].Rows[j]["DowntimeType"].ToString();
                            Shift =  ds.Tables[0].Rows[0]["Shift"].ToString();
                        }
                        string downtypecount = "";
                        string downtyp = "";
                      
                        if (unit == "ALL")
                        {
                            SqlDataAdapter sqladp = new SqlDataAdapter(" Select DowntimeType,COUNT(DowntimeType)as DowntimeType_Count from EfficiencyCalculaus where department='" + table[i] + "' and MachineName='" + mchn + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + frmtm + "' and EffDate<='" + totm + "'and unit in ('MBU','ABU') GROUP BY DowntimeType ", con);
                            DataSet dssqladp = new DataSet();
                            sqladp.Fill(dssqladp);
                            for (int k = 0; k < dssqladp.Tables[0].Rows.Count; k++)
                            {

                                downtyp = dssqladp.Tables[0].Rows[k]["DowntimeType"].ToString();

                                downtypecount = dssqladp.Tables[0].Rows[k]["DowntimeType_Count"].ToString();
                                //downtype += downtyp + '[' + downtypecount.ToString() + ']' + ',';
                                downtype += downtyp + '[' + downtypecount.ToString() + ']' + "<br />" + ',';
                            }
                        }
                        else
                        {
                            SqlDataAdapter sqladp = new SqlDataAdapter(" Select DowntimeType,COUNT(DowntimeType)as DowntimeType_Count from EfficiencyCalculaus where department='" + table[i] + "' and MachineName='" + mchn + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + frmtm + "' and EffDate<='" + totm + "'and unit ='" + unit + "' GROUP BY DowntimeType ", con);
                            DataSet dssqladp = new DataSet();
                            sqladp.Fill(dssqladp);
                            for (int k = 0; k < dssqladp.Tables[0].Rows.Count; k++)
                            {

                                downtyp = dssqladp.Tables[0].Rows[k]["DowntimeType"].ToString();

                                downtypecount = dssqladp.Tables[0].Rows[k]["DowntimeType_Count"].ToString();
                                downtype += downtyp + '[' + downtypecount.ToString() + ']' + "<br />" + ',';

                            }
                        }
                        downtype = downtype.Remove(downtype.Length - 1);
                        SqlCommand cmdd = new SqlCommand("update Departmentnew set Valve='" + trs + "' where id='" + id1 + "'", con);
                        SqlDataAdapter daa = new SqlDataAdapter(cmdd);
                        con.Open();
                        cmdd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd = new SqlCommand("update Departmentnew set Valve='" + prodQty + "' where id='" + id2 + "'", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmmmd = new SqlCommand("update Departmentnew set Valve='" + Shift + "' where id='" + id3 + "'", con);
                        SqlDataAdapter da111 = new SqlDataAdapter(cmmmd);
                        con.Open();
                        cmmmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd1 = new SqlCommand("update Departmentnew set Valve='" + planstp + "' where id='" + id4 + "'", con);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd2 = new SqlCommand("update Departmentnew set Valve='" + downtym + "' where id='" + id5 + "'", con);
                        SqlDataAdapter da3 = new SqlDataAdapter(cmd2);
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd3 = new SqlCommand("update Departmentnew set Valve='" + downtype + "' where id='" + id6 + "'", con);
                        SqlDataAdapter da4 = new SqlDataAdapter(cmd3);
                        con.Open();
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }
                    if (table[i] == "Block")
                    {
                        int id1 = 1;
                        int id2 = 2;
                        int id3 = 3;
                        int id4 = 4;
                        int id5 = 5;
                        int id6 = 6;

                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            trs = trs + Convert.ToDecimal(ds.Tables[0].Rows[j]["TRS"].ToString());
                            planstp = planstp + Convert.ToDecimal(ds.Tables[0].Rows[j]["PlannedStop"].ToString());
                            downtym = downtym + Convert.ToDecimal(ds.Tables[0].Rows[j]["DowntimeTotal"].ToString());
                            prodQty = prodQty + Convert.ToDecimal(ds.Tables[0].Rows[j]["ProdQty"].ToString());
                           // downtype = downtype + ',' + ds.Tables[0].Rows[j]["DowntimeType"].ToString();
                            Shift =  ds.Tables[0].Rows[0]["Shift"].ToString();

                        }
                        string downtypecount = "";
                        string downtyp = "";

                        if (unit == "ALL")
                        {
                            SqlDataAdapter sqladp = new SqlDataAdapter(" Select DowntimeType,COUNT(DowntimeType)as DowntimeType_Count from EfficiencyCalculaus where department='" + table[i] + "' and MachineName='" + mchn + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + frmtm + "' and EffDate<='" + totm + "'and unit in ('MBU','ABU') GROUP BY DowntimeType ", con);
                            DataSet dssqladp = new DataSet();
                            sqladp.Fill(dssqladp);
                            for (int k = 0; k < dssqladp.Tables[0].Rows.Count; k++)
                            {

                                downtyp = dssqladp.Tables[0].Rows[k]["DowntimeType"].ToString();

                                downtypecount = dssqladp.Tables[0].Rows[k]["DowntimeType_Count"].ToString();
                                downtype += downtyp + '[' + downtypecount.ToString() + ']' + "<br />" + ',';

                            }
                        }
                        else
                        {
                            SqlDataAdapter sqladp = new SqlDataAdapter(" Select DowntimeType,COUNT(DowntimeType)as DowntimeType_Count from EfficiencyCalculaus where department='" + table[i] + "' and MachineName='" + mchn + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + frmtm + "' and EffDate<='" + totm + "'and unit ='" + unit + "' GROUP BY DowntimeType ", con);
                            DataSet dssqladp = new DataSet();
                            sqladp.Fill(dssqladp);
                            for (int k = 0; k < dssqladp.Tables[0].Rows.Count; k++)
                            {

                                downtyp = dssqladp.Tables[0].Rows[k]["DowntimeType"].ToString();

                                downtypecount = dssqladp.Tables[0].Rows[k]["DowntimeType_Count"].ToString();
                                downtype += downtyp + '[' + downtypecount.ToString() + ']' + "<br />" + ',';

                            }
                        }
                        downtype = downtype.Remove(downtype.Length - 1);
                        SqlCommand cmdd = new SqlCommand("update Departmentnew set Block='" + trs + "' where id='" + id1 + "'", con);
                        SqlDataAdapter daa = new SqlDataAdapter(cmdd);
                        con.Open();
                        cmdd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd = new SqlCommand("update Departmentnew set Block='" + prodQty + "' where id='" + id2 + "'", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmmmd = new SqlCommand("update Departmentnew set Block='" + Shift + "' where id='" + id3 + "'", con);
                        SqlDataAdapter da111 = new SqlDataAdapter(cmmmd);
                        con.Open();
                        cmmmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd1 = new SqlCommand("update Departmentnew set Block='" + planstp + "' where id='" + id4 + "'", con);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd2 = new SqlCommand("update Departmentnew set Block='" + downtym + "' where id='" + id5 + "'", con);
                        SqlDataAdapter da3 = new SqlDataAdapter(cmd2);
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd3 = new SqlCommand("update Departmentnew set Block='" + downtype + "' where id='" + id6 + "'", con);
                        SqlDataAdapter da4 = new SqlDataAdapter(cmd3);
                        con.Open();
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }
                    if (table[i] == "Shaft")
                    {
                        int id1 = 1;
                        int id2 = 2;
                        int id3 = 3;
                        int id4 = 4;
                        int id5 = 5;
                        int id6 = 6;

                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            trs = trs + Convert.ToDecimal(ds.Tables[0].Rows[j]["TRS"].ToString());
                            planstp = planstp + Convert.ToDecimal(ds.Tables[0].Rows[j]["PlannedStop"].ToString());
                            downtym = downtym + Convert.ToDecimal(ds.Tables[0].Rows[j]["DowntimeTotal"].ToString());
                            prodQty = prodQty + Convert.ToDecimal(ds.Tables[0].Rows[j]["ProdQty"].ToString());
                            //downtype = downtype + ',' + ds.Tables[0].Rows[j]["DowntimeType"].ToString();
                            Shift =  ds.Tables[0].Rows[0]["Shift"].ToString();
                        }
                        string downtypecount = "";
                        string downtyp = "";

                        if (unit == "ALL")
                        {
                            SqlDataAdapter sqladp = new SqlDataAdapter(" Select DowntimeType,COUNT(DowntimeType)as DowntimeType_Count from EfficiencyCalculaus where department='" + table[i] + "' and MachineName='" + mchn + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + frmtm + "' and EffDate<='" + totm + "'and unit in ('MBU','ABU') GROUP BY DowntimeType ", con);
                            DataSet dssqladp = new DataSet();
                            sqladp.Fill(dssqladp);
                            for (int k = 0; k < dssqladp.Tables[0].Rows.Count; k++)
                            {

                                downtyp = dssqladp.Tables[0].Rows[k]["DowntimeType"].ToString();

                                downtypecount = dssqladp.Tables[0].Rows[k]["DowntimeType_Count"].ToString();
                                downtype += downtyp + '[' + downtypecount.ToString() + ']' + "<br />" + ',';

                            }
                        }
                        else
                        {
                            SqlDataAdapter sqladp = new SqlDataAdapter(" Select DowntimeType,COUNT(DowntimeType)as DowntimeType_Count from EfficiencyCalculaus where department='" + table[i] + "' and MachineName='" + mchn + "'and Operation='" + process + "' and Shift='" + shift + "' and EffDate>='" + frmtm + "' and EffDate<='" + totm + "'and unit ='" + unit + "' GROUP BY DowntimeType ", con);
                            DataSet dssqladp = new DataSet();
                            sqladp.Fill(dssqladp);
                            for (int k = 0; k < dssqladp.Tables[0].Rows.Count; k++)
                            {

                                downtyp = dssqladp.Tables[0].Rows[k]["DowntimeType"].ToString();

                                downtypecount = dssqladp.Tables[0].Rows[k]["DowntimeType_Count"].ToString();
                                downtype += downtyp + '[' + downtypecount.ToString() + ']' + "<br />" + ',';

                            }
                        }
                        downtype = downtype.Remove(downtype.Length - 1);
                        SqlCommand cmdd = new SqlCommand("update Departmentnew set Shaft='" + trs + "' where id='" + id1 + "'", con);
                        SqlDataAdapter daa = new SqlDataAdapter(cmdd);
                        con.Open();
                        cmdd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd = new SqlCommand("update Departmentnew set Shaft='" + prodQty + "' where id='" + id2 + "'", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmmmd = new SqlCommand("update Departmentnew set Shaft='" + Shift + "' where id='" + id3 + "'", con);
                        SqlDataAdapter da111 = new SqlDataAdapter(cmmmd);
                        con.Open();
                        cmmmd.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd1 = new SqlCommand("update Departmentnew set Shaft='" + planstp + "' where id='" + id4 + "'", con);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd2 = new SqlCommand("update Departmentnew set Shaft='" + downtym + "' where id='" + id5 + "'", con);
                        SqlDataAdapter da3 = new SqlDataAdapter(cmd2);
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        SqlCommand cmd3 = new SqlCommand("update Departmentnew set Shaft='" + downtype + "' where id='" + id6 + "'", con);
                        SqlDataAdapter da4 = new SqlDataAdapter(cmd3);
                        con.Open();
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }

                }
               
            }
            SqlCommand cmmd = new SqlCommand("select * from Departmentnew", con);
            SqlDataAdapter daa4 = new SqlDataAdapter(cmmd);
            DataSet dss = new DataSet();
            daa4.Fill(dss);

            return dss;
        }


        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet ViewUserdimension(string part, string opertion, string shift, string pid, DateTime fromdate, string table)
    {
        string _part, _operation, Shift;
        if (shift=="" || shift==null)
        {
            Shift = "or Shift='" + shift + "'";
        }
        else if (shift == "0")
        {
            Shift = " and Shift in('A','B','C','G','A1','B1')";
        }
        else
        {
            Shift = "and Shift='" + shift + "'";
        }
        SqlConnection con = new SqlConnection(constr);
        DataSet ds;
        SqlDataAdapter da;
      
            if (opertion == "OP1" || opertion == "Polishing")
            {
                query = "select * from " + table + " where Prdn_Name='" + part + "' and CreatedOn='" + fromdate + "' and PID_No='" + pid + "'" + Shift + "";

            }
      
        else
        {
            query = "select * from efficiencycal";
        }
        if (query != "" && query != null)
        {
            objds = new DataSet();
            objda = new SqlDataAdapter(query, con);
            objda.Fill(objds);

        }
        return objds;
    }
    public DataSet ViewAllDMTTemplateBydatawise(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewAllDMTDetailbyDatewise", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fromdate", db.fromdate);
            cmd.Parameters.AddWithValue("@todate", db.todate);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet getcpcpk(string part, string opertion, string fromdate1, string todate1, string shift, string mode, string pid)
    {
        string _part, _operation, Shift;
        if (shift == "0")
        {
            Shift = " and Shift in('A','B','C','G','A1','B1')";
        }
        else
        {
            Shift = "and Shift='" + shift + "'";
        }
        string fromdate = Convert.ToDateTime(fromdate1).ToString("yyyy-MM-dd");
        string todate = Convert.ToDateTime(todate1).ToString("yyyy-MM-dd");
        SqlConnection con = new SqlConnection(constr);
        DataSet ds;
        SqlDataAdapter da;
        if (opertion == "OP1" || opertion == "Polishing")
        {
            if (part == "A17724Q" && opertion == "OP1")
            {
                query = "select distinct Chart_CP,Chart_CPK,Chart_CPD2,Chart_CPKD2,Chart_CPD3,Chart_CPKD3 from QualitySheet where Prdn_Name='" + part + "' and CreatedOn>='" + fromdate + "' and CreatedOn<='" + todate + "'" + Shift + "";

            }
            if (part == "A17724Q" && opertion == "Polishing")
            {
                query = "select distinct Chart_CP,Chart_CPK,Chart_CPD2,Chart_CPKD2,Chart_CPD3,Chart_CPKD3,QRMaxCP1,QRMaxCP2,QRMaxCP3,QRMaxCP4,QRMaxCP5,QRMaxCP6 from QSheetPolishing24Q where Prdn_Name='" + part + "' and CreatedOn>='" + fromdate + "' and CreatedOn<='" + todate + "'" + Shift + "";

            }
            if (part == "A22916J" && opertion == "OP1")
            {
                query = "select distinct Chart_CP,Chart_CPK,Chart_CPD2,Chart_CPKD2,Chart_CPD3,Chart_CPKD3 from QualitySheetA22916J where Prdn_Name='" + part + "' and CreatedOn>='" + fromdate + "' and CreatedOn<='" + todate + "'" + Shift + "";

            }
            if (part == "A22916J" && opertion == "Polishing")
            {
                query = "select distinct Chart_CP,Chart_CPK,Chart_CPD2,Chart_CPKD2,Chart_CPD3,Chart_CPKD3,QRMaxCP1,QRMaxCP2,QRMaxCP3,QRMaxCP4,QRMaxCP5,QRMaxCP6 from QSheetpolishingA22916J where Prdn_Name='" + part + "' and CreatedOn>='" + fromdate + "' and CreatedOn<='" + todate + "'" + Shift + "";

            }
            if (part == "A32271C" && opertion == "OP1")
            {
                query = "select distinct Chart_CP,Chart_CPK,Chart_CPD2,Chart_CPKD2,Chart_CPD3,Chart_CPKD3,Chart_CPD4,Chart_CPKD4,QRMaxCP1,QRMaxCP2,QRMaxCP3,QRMaxCP4,QRMaxCP5,QRMaxCP6,QRMaxC7,QRMaxCP8 from QSheetA32271C where Prdn_Name='" + part + "' and CreatedOn>='" + fromdate + "' and CreatedOn<='" + todate + "'" + Shift + "";

            }
            if (part == "A32271C" && opertion == "Polishing")
            {
                query = "select distinct Chart_CP,Chart_CPK,Chart_CPD2,Chart_CPKD2,Chart_CPD3,Chart_CPKD3,Chart_CPD4,Chart_CPKD4,QRMaxCP1,QRMaxCP2,QRMaxCP3,QRMaxCP4,QRMaxCP5,QRMaxCP6,QRMaxC7,QRMaxCP8 from QSheetpolishingA32271C where Prdn_Name='" + part + "' and CreatedOn>='" + fromdate + "' and CreatedOn<='" + todate + "'" + Shift + "";

            }
            if (part == "A44908N" && opertion == "OP1")
            {
                query = "select distinct Chart_CP,Chart_CPK,Chart_CPD2,Chart_CPKD2,Chart_CPD3,Chart_CPKD3, from QSheetA44908N where Prdn_Name='" + part + "' and CreatedOn>='" + fromdate + "' and CreatedOn<='" + todate + "'" + Shift + "";

            }
            if (part == "A44908N" && opertion == "Polishing")
            {
                query = "select distinct Chart_CP,Chart_CPK,Chart_CPD2,Chart_CPKD2,Chart_CPD3,Chart_CPKD3,QRMaxCP1,QRMaxCP2,QRMaxCP3,QRMaxCP4,QRMaxCP5,QRMaxCP6 from QSheetPolishingA44908N where Prdn_Name='" + part + "' and CreatedOn>='" + fromdate + "' and CreatedOn<='" + todate + "'" + Shift + "";

            }
            if (part == "A44983U" && opertion == "OP1")
            {
                query = "select distinct Chart_CP,Chart_CPK,Chart_CPD2,Chart_CPKD2,Chart_CPD3,Chart_CPKD3,Chart_CPD4,Chart_CPKD4 from qualityshtA44983U where Prdn_Name='" + part + "' and CreatedOn>='" + fromdate + "' and CreatedOn<='" + todate + "'" + Shift + "";

            }
            if (part == "A44983U" && opertion == "Polishing")
            {
                query = "select distinct Chart_CP,Chart_CPK,Chart_CPD2,Chart_CPKD2,Chart_CPD3,Chart_CPKD3,Chart_CPD4,Chart_CPKD4,QRMaxCP1,QRMaxCP2,QRMaxCP3,QRMaxCP4,QRMaxCP5,QRMaxCP6,QRMaxCP7,QRMaxCP8 from QSheetpolishingA44983U where Prdn_Name='" + part + "' and CreatedOn>='" + fromdate + "' and CreatedOn<='" + todate + "'" + Shift + "";


            }
        }
        else
        {
            query = "select * from efficiencycal";
        }
        if (query != "" && query != null)
        {
            objds = new DataSet();
            objda = new SqlDataAdapter(query, con);
            objda.Fill(objds);

        }
        return objds;
    }
    public DataSet ViewAllDMTTemplateByProcess1(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewAllDMTDetailbyProces", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@process", db.Process);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet ViewAllDMTTemplateByProcess(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewAllDMTDetailbyProcess", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@process", db.Process);
            cmd.Parameters.AddWithValue("@partno", db.PartNo);
            cmd.Parameters.AddWithValue("@fromdate", db.fromdate);
            cmd.Parameters.AddWithValue("@todate", db.todate);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet ViewAllEffemplateByProcess(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewAllEffDetailbyProcess", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@process", db.Process);
            cmd.Parameters.AddWithValue("@partno", db.PartNo);
            //cmd.Parameters.AddWithValue("@fromdate", db.fromdate);
            //cmd.Parameters.AddWithValue("@todate", db.todate);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet laboreff(string shift, string fromdate, string todate)
    {
        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("laborEffchart", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;   
        }
        catch (Exception ex)
        {
            throw ex;
        }
      
    }
    public DataSet labor_chart(string shift, string fromdate, string todate, string unit, string mchn, DBServer db)
    {
        SqlConnection con = new SqlConnection(constr);

        try
        {
            SqlCommand cmd3 = new SqlCommand("delete from labor_date", con);
            SqlDataAdapter da3 = new SqlDataAdapter();
            con.Open();
            cmd3.ExecuteNonQuery();
            con.Close();

            DateTime objfm = Convert.ToDateTime(fromdate);
            DateTime objto = Convert.ToDateTime(todate);
            SqlCommand cmd2 = new SqlCommand("insert into labor_date (date) values ('" + fromdate + "')", con);
            SqlDataAdapter da2 = new SqlDataAdapter();
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();

            DataSet dss1 = new DataSet();
            dss1.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd4 = new SqlCommand("Labor_chart_date", con);
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.AddWithValue("@shift", shift);
            cmd4.Parameters.AddWithValue("@fromdate", fromdate);
            cmd4.Parameters.AddWithValue("@mchn", mchn);
            cmd4.Parameters.AddWithValue("@unit", unit);
            SqlDataAdapter daa4 = new SqlDataAdapter(cmd4);
            daa4.Fill(dss1);
            if (dss1.Tables[0].Rows.Count > 0)
            {
                string ttl = Convert.ToString(dss1.Tables[0].Rows[0]["total_time"].ToString());

                SqlCommand cmdd5 = new SqlCommand("update labor_date set total_time='" + ttl + "' where date='" + fromdate + "'", con);
                SqlDataAdapter daa5 = new SqlDataAdapter(cmdd5);
                con.Open();
                cmdd5.ExecuteNonQuery();
                con.Close();
            }
              
           int dat = Convert.ToDateTime(todate).Subtract(Convert.ToDateTime(fromdate)).Days;
             string datetm="";
           for (int i = 0; i < dat; i++)
           {
               objfm = objfm.AddDays(1);
               datetm = objfm.ToShortDateString().ToString();

               SqlCommand cmd1 = new SqlCommand("insert into labor_date (date) values ('" + datetm + "')", con);
               SqlDataAdapter da1 = new SqlDataAdapter();
               con.Open();
               cmd1.ExecuteNonQuery();
               con.Close();

               DataSet ds = new DataSet();
               ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
               SqlCommand cmd = new SqlCommand("Labor_chart_downtime", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@shift", shift);
               cmd.Parameters.AddWithValue("@datetm", datetm);
               cmd.Parameters.AddWithValue("@mchn", mchn);
               cmd.Parameters.AddWithValue("@unit", unit);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               da.Fill(ds);
              
                   if (ds.Tables[0].Rows.Count > 0)
                   {
                       string ttl = Convert.ToString(ds.Tables[0].Rows[0]["total_time"].ToString());

                       SqlCommand cmdd = new SqlCommand("update labor_date set total_time='" + ttl + "' where date='" + datetm + "'", con);
                       SqlDataAdapter daa = new SqlDataAdapter(cmdd);
                       con.Open();
                       cmdd.ExecuteNonQuery();
                       con.Close();
                   }
               

           }

           SqlCommand cmmd = new SqlCommand("select * from labor_date", con);
           SqlDataAdapter daa6 = new SqlDataAdapter(cmmd);
           DataSet dss = new DataSet();
           daa6.Fill(dss);

           return dss;

        }

        catch (Exception ex)
        {
            throw ex;
        }

    }
    public DataSet labor_chart_year(string year, string shift, string fromdate, string todate, string unit, string mchn, DBServer db)
    {
        SqlConnection con = new SqlConnection(constr);

        try
        {
            DataSet ds = new DataSet();
            DataSet dss = new DataSet();
            DataSet dss1 = new DataSet();
            DataSet dss2 = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("labor_chart_year", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@shift", shift);
            cmd.Parameters.AddWithValue("@mchn", mchn);
            cmd.Parameters.AddWithValue("@unit", unit);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            SqlDataAdapter daa2 = new SqlDataAdapter("Select * from temp_LE_mnth", con);
            daa2.Fill(dss);

            for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
            {
                month11 = Convert.ToString(dss.Tables[0].Rows[i]["Month1"].ToString());

                dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                SqlCommand cmd1 = new SqlCommand("updateTemp_Labor_Eff_month_clear", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@month1", month11);
                SqlDataAdapter daa3 = new SqlDataAdapter(cmd1);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            SqlDataAdapter daa4 = new SqlDataAdapter("Select * from temp_LE_mnth", con);
            daa4.Fill(dss1);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                month1 = Convert.ToString(ds.Tables[0].Rows[i]["Lmonth"].ToString());
                ttl = Convert.ToString(ds.Tables[0].Rows[i]["total_time"].ToString());
                month11 = Convert.ToString(dss1.Tables[0].Rows[i]["Month1"].ToString());
                ttl1 = Convert.ToString(dss1.Tables[0].Rows[i]["ttl"].ToString());

                if (month1 == "Jan")
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmdd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttl + "' where Month1='" + month1 + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                }
                else if (month1 == "Feb")
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmdd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttl + "' where Month1='" + month1 + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                }
                else if (month1 == "Mar")
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmdd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttl + "' where Month1='" + month1 + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                }
                else if (month1 == "Apr")
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmdd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttl + "' where Month1='" + month1 + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                }
                else if (month1 == "May")
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmdd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttl + "' where Month1='" + month1 + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                }
                else if (month1 == "Jun")
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmdd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttl + "' where Month1='" + month1 + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                }
                else if (month1 == "Jul")
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmdd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttl + "' where Month1='" + month1 + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                }
                else if (month1 == "Aug")
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmdd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttl + "' where Month1='" + month1 + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                }
                else if (month1 == "Sep")
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmdd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttl + "' where Month1='" + month1 + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                }
                else if (month1 == "Oct")
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmdd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttl + "' where Month1='" + month1 + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                }
                else if (month1 == "Nov")
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmdd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttl + "' where Month1='" + month1 + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                }
                else if (month1 == "Dec")
                {
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmdd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttl + "' where Month1='" + month1 + "'", con);
                    SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();

                }
                else
                {
                    string ttlll = "0";
                    dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    SqlCommand cmddd = new SqlCommand("update temp_LE_mnth set ttl ='" + ttlll + "' where Month1='" + month11 + "'", con);
                    SqlDataAdapter daa5 = new SqlDataAdapter(cmddd);
                    con.Open();
                    cmddd.ExecuteNonQuery();
                    con.Close();
                }
            }




            SqlDataAdapter daa = new SqlDataAdapter("Select * from temp_LE_mnth", con);
            daa.Fill(dss2);
            return dss2;
        }




        catch (Exception ex)
        {
            throw ex;
        }

    }
    public DataSet TRs_chart(string shift, string unit, string mchn, DateTime fromdate, DateTime todate)
    {
        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            DataSet dss = new DataSet();
            DataSet dss1 = new DataSet();
            DataSet dss2 = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("TRS_chart_downtime", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@shift", shift);
            cmd.Parameters.AddWithValue("@unit", unit);
            cmd.Parameters.AddWithValue("@mchn", mchn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);


            SqlDataAdapter daa2 = new SqlDataAdapter("Select * from Temp_DownTime", con);
            daa2.Fill(dss);


            SqlCommand cmd1 = new SqlCommand("delete from Temp_DownTime", con);
            SqlDataAdapter daa3 = new SqlDataAdapter(cmd1);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter daa4 = new SqlDataAdapter("Select * from Temp_DownTime", con);
            daa4.Fill(dss1);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                DowntimeType = Convert.ToString(ds.Tables[0].Rows[i]["DowntimeType"].ToString());
                TRS = Convert.ToString(ds.Tables[0].Rows[i]["TRS"].ToString());


                dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                SqlCommand cmdd = new SqlCommand("insert into Temp_DownTime (TRS,DowntimeType) values ('" + TRS + "','" + DowntimeType + "')", con);
                SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                con.Open();
                cmdd.ExecuteNonQuery();
                con.Close();

            }

            SqlDataAdapter daa = new SqlDataAdapter("Select * from Temp_DownTime", con);
            daa.Fill(dss2);
            return dss2;

        }

        catch (Exception ex)
        {
            throw ex;
        }

    }
    public DataSet TRG_chart(string shift, string unit, string mchn, DateTime fromdate, DateTime todate)
    {
        SqlConnection con = new SqlConnection(constr);

        try
        {
            DataSet ds = new DataSet();
            DataSet dss = new DataSet();
            DataSet dss1 = new DataSet();
            DataSet dss2 = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("TRG_chart_downtime", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@todate", todate);
            cmd.Parameters.AddWithValue("@shift", shift);
            cmd.Parameters.AddWithValue("@unit", unit);
            cmd.Parameters.AddWithValue("@mchn", mchn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            SqlDataAdapter daa2 = new SqlDataAdapter("Select * from temp_TRG ", con);
            daa2.Fill(dss);




            SqlCommand cmd1 = new SqlCommand("Delete from temp_TRG", con);
            SqlDataAdapter daa3 = new SqlDataAdapter(cmd1);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();


            SqlDataAdapter daa4 = new SqlDataAdapter("Select * from temp_TRG", con);
            daa4.Fill(dss1);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                DowntimeType = Convert.ToString(ds.Tables[0].Rows[i]["DowntimeType"].ToString());
                TRG = Convert.ToString(ds.Tables[0].Rows[i]["TRG"].ToString());

                dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
                SqlCommand cmdd = new SqlCommand("insert into temp_TRG (TRG,DowntimeType) values ('" + TRG + "','" + DowntimeType + "')", con);
                SqlDataAdapter daa1 = new SqlDataAdapter(cmdd);
                con.Open();
                cmdd.ExecuteNonQuery();
                con.Close();
            }
            SqlDataAdapter daa = new SqlDataAdapter("Select * from temp_TRG", con);
            daa.Fill(dss2);
            return dss2;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet ViewTimeMasterByQry(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewTimeMasterByQry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@partno", db.PartNo);
            cmd.Parameters.AddWithValue("@operation", db.Process);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public DataSet ViewTimePlanned(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlDataAdapter da = new SqlDataAdapter("select * from PlaneedEntryDetails where PartNo='" + db.PartNo + "' and Process='" + db.Process + "'", con);
            ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet ViewDescriptionbyPartNO(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewDescriptionbyPartNO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@partno", db.PartNo);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet efficiencycal(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("efficiencycal", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet ViewAllEfficiencyCalbydatetime(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewEfficiencyCalByDateTime", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fromdate", Convert.ToDateTime(db.fromdate));
            cmd.Parameters.AddWithValue("@todate", Convert.ToDateTime(db.todate));
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet ViewAllEfficiencyReportsdatetime(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {

            SqlDataAdapter da = new SqlDataAdapter("select *  from EfficiencyCalculaus where EffDate>='" + Convert.ToDateTime(db.fromdate) + "' and EffDate<='" + Convert.ToDateTime(db.todate) + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet ViewAllDMTdatetime(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {

            SqlDataAdapter da = new SqlDataAdapter("select *  from DMT_Template where creationdate>='" + Convert.ToDateTime(db.fromdate) + "' and creationdate<='" + Convert.ToDateTime(db.todate) + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet viewpageloadresulteffiency(string partno, string operation, string fromdate, string todate, string shift)
    {
        string _part, _operation,Shift;
        if (shift == "0")
        {
            Shift = " and Shift in('A','B','C','G','A1','B1')";
        }
        else
        {
            Shift = "and Shift='" + shift + "'";
        }
        SqlConnection con = new SqlConnection(constr);
        DataSet ds;
        SqlDataAdapter da;
        if (partno != "-Select-" && operation != "-Select-" && fromdate != "" && todate != "")
        {
            query = "select * from EfficiencyCalculaus where Partno='" + partno + "' and Operation='" + operation + "' and EffDate>='" + Convert.ToDateTime(fromdate) + "' and EffDate<='" + Convert.ToDateTime(todate) + "'" + Shift + "";
        }
        if (partno == "-Select-" && operation == "-Select-" && fromdate == "" && todate == "")
        {
            query = "select * from EfficiencyCalculaus";
        }
        if (partno == "-Select-" && operation == "-Select-" && fromdate != "" && todate != "")
        {
            query = "select * from EfficiencyCalculaus where EffDate>='" + Convert.ToDateTime(fromdate) + "' and EffDate<='" + Convert.ToDateTime(todate) + "'" + Shift + "";
        }
        if (partno != "-Select-" && operation == "-Select-" && fromdate != "" && todate != "")
        {
            query = "select * from EfficiencyCalculaus where Partno='" + partno + "' and EffDate>='" + Convert.ToDateTime(fromdate) + "' and EffDate<='" + Convert.ToDateTime(todate) + "'" + Shift + "";
        }
        if (partno == "-Select-" && operation != "-Select-" && fromdate != "" && todate != "")
        {
            query = "select * from EfficiencyCalculaus where Operation='" + operation + "' and EffDate>='" + Convert.ToDateTime(fromdate) + "' and EffDate<='" + Convert.ToDateTime(todate) + "'" + Shift + "";
        }
        if (partno.ToString() != "-Select-" && operation.ToString() != "-Select-" && fromdate.ToString() == "" && todate.ToString() == "")
        {
            query = "select *  from EfficiencyCalculaus where  Operation>='" + operation + "' and Partno='" + partno + "'" + Shift + "";
        }
        da = new SqlDataAdapter(query, con);
        ds = new DataSet();
        da.Fill(ds);
        return ds;

    }
    public DataSet viewpageloadresultdmt(string partno, string operation, string fromdate, string todate)
    {
        string _part, _operation, Shift;
       
        SqlConnection con = new SqlConnection(constr);
        DataSet ds;
        SqlDataAdapter da;
        if (partno != "-Select-" && operation != "-Select-" && fromdate != "" && todate != "")
        {
            query = "select * from DMT_Template where specificpartorcommon='" + partno + "' and operation='" + operation + "' and creationdate>='" + Convert.ToDateTime(fromdate) + "' and creationdate<='" + Convert.ToDateTime(todate) + "'";
        }
        if (partno == "-Select-" && operation == "-Select-" && fromdate == "" && todate == "")
        {
            query = "select * from DMT_Template";
        }
        if (partno == "-Select-" && operation == "-Select-" && fromdate != "" && todate != "")
        {
            query = "select * from DMT_Template where creationdate>='" + Convert.ToDateTime(fromdate) + "' and creationdate<='" + Convert.ToDateTime(todate) + "'";
        }
        if (partno != "-Select-" && operation == "-Select-" && fromdate != "" && todate != "")
        {
            query = "select * from DMT_Template where specificpartorcommon='" + partno + "' and creationdate>='" + Convert.ToDateTime(fromdate) + "' and creationdate<='" + Convert.ToDateTime(todate) + "'";
        }
        if (partno == "-Select-" && operation != "-Select-" && fromdate != "" && todate != "")
        {
            query = "select * from DMT_Template where operation='" + operation + "' and creationdate>='" + Convert.ToDateTime(fromdate) + "' and creationdate<='" + Convert.ToDateTime(todate) + "'";
        }

        da = new SqlDataAdapter(query, con);
        ds = new DataSet();
        da.Fill(ds);
        return ds;

    }
    public DataSet ViewAllEfficiency(string partno,string operation,string fromdate,string todate)
    {

        SqlConnection con = new SqlConnection(constr);
        DataSet ds;
        try
        {
            if (partno.ToString() == "-Select-" && operation.ToString() == "-Select-" && fromdate.ToString() == "" && todate.ToString() == "")
            {
                SqlDataAdapter da = new SqlDataAdapter("select *  from EfficiencyReports", con);
                ds = new DataSet();
                da.Fill(ds);
            }
            else
            {
                if (partno.ToString() == "-Select-" && operation.ToString() == "-Select-" && fromdate.ToString() != "" && todate.ToString()!="")
                {

                    Query = "select *  from EfficiencyReports where  EffDate>='" + Convert.ToDateTime(fromdate) + "' and EffDate<='" + Convert.ToDateTime(todate) +"'";
                    //if (partno.ToString() == "-Select-")
                    //{
                    //    partno = "";
                    //}
                    //if (operation.ToString() == "-Select-")
                    //{
                    //    operation = "";
                    //}
                }
                if (partno.ToString() == "-Select-" && operation.ToString() == "-Select-" && fromdate.ToString() == "" && todate.ToString() != "")
                {
                    Query = "select *  from EfficiencyReports where  EffDate<='" + Convert.ToDateTime(todate) + "'";
                }
                if (partno.ToString() == "-Select-" && operation.ToString() == "-Select-" && fromdate.ToString() != "" && todate.ToString() == "")
                {
                    Query = "select *  from EfficiencyReports where  EffDate>='" + Convert.ToDateTime(todate) + "'";
                }
                if (partno.ToString() != "-Select-" && operation.ToString() == "-Select-" && fromdate.ToString() == "" && todate.ToString() == "")
                {
                    Query = "select *  from EfficiencyReports where  Partno>='" + partno + "'";
                }
                if (partno.ToString() == "-Select-" && operation.ToString() != "-Select-" && fromdate.ToString() == "" && todate.ToString() == "")
                {
                    Query = "select *  from EfficiencyReports where  Operation>='" + operation + "'";
                }
                if (partno.ToString() != "-Select-" && operation.ToString() != "-Select-" && fromdate.ToString() == "" && todate.ToString() == "")
                {
                    Query = "select *  from EfficiencyReports where  Operation>='" + operation + "' and Partno='" + partno + "'";
                }
                if (partno.ToString() != "-Select-" && operation.ToString() != "-Select-" && fromdate.ToString() != "" && todate.ToString() != "")
                {
                    Query = "select *  from EfficiencyReports where Partno='" + partno + "' and Operation='" + operation + "' and EffDate>='" + Convert.ToDateTime(fromdate) + "' and EffDate<='" + Convert.ToDateTime(todate) + "'";
                }

                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                ds = new DataSet();
                da.Fill(ds);
            }
            
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet ViewAllPartNo(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewAllPartNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet ViewTotQtybyPartnos(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewTotQtybyPartno", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@partno", db.PartNo);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet ViewHourlyProdbyPartNos(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewHourlyProdbyPartNos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@partno", db.PartNo);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet ViewHourlyProdbyDatewise(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewHourlyProdbyDatewise", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@shift", db.shift);
            cmd.Parameters.AddWithValue("@date", db.PartNo);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Viewdimension(string Partno, string Tablename, string fromdate, string todate, string shift, string mchn, string Unit, string Cell, string Opertaion, string Dimension)
    {
        string column = "";
        string Average = "";
        string C_max = "";
        string C_min = "";
        string Y_max = "";
        string Y_min = "";
        string Green = "";
       // string _Green = "";
        string Yellow = "";
       // string _Yellow = "";
        SqlDataAdapter da1 = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' order by DID", strConnString);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        if (ds1.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                //int count = Convert.ToInt32(ds1.Tables[0].Rows[i]["Int_count"].ToString());
                string id = ds1.Tables[0].Rows[i]["DID"].ToString();
                if ((ds1.Tables[0].Rows[i]["CellValues"].ToString() != "0") && (ds1.Tables[0].Rows[i]["CellValues"].ToString() != ""))
                {
                    //for (int j = 1; j <= 1; j++)
                    //{
                        column = column + "," + "QMax_" + "" + id + "" + Dimension;
                        column = column + "," + "QMin_" + "" + id + "" + Dimension;
                        column = column + "," + "Chart_CPD" + "" + id + "" + Dimension;
                        column = column + "," + "Chart_CPKD" + "" + id + "" + Dimension;
                        Average = Average + "," + "AverageD" + "" + id + "" + Dimension;
                        C_max = C_max + "," + "Chart_MaxD" + "" + id + "" + Dimension;
                        C_min = C_min + "," + "Chart_MinD" + "" + id + "" + Dimension;
                        Y_max = Y_max + "," + "Chart_Y_MaxD" + "" + id + "" + Dimension;
                        Y_min = Y_min + "," + "Chart_Y_MinD" + "" + id + "" + Dimension;
                        Green = Green + "," + "Chart_G_MaxD" + "" + id + "" + Dimension;
                        Green = Green + "," + "Chart_G_MinD" + "" + id + "" + Dimension;


                   // }
                }
            }
        }
        string _part, _operation, Shift, UNIT;
        if (Unit == "ALL")
        {
            UNIT = " and Unit in('MBU','ABU')";
        }
        else
        {
            UNIT = "and Unit='" + Unit + "'";
        }
        if (shift == "0")
        {
            Shift = " and QShift in('A','B','C','G','A1','B1')";
        }
        else
        {
            Shift = "and QShift='" + shift + "'";
        }
        //string fromdate1 = Convert.ToDateTime(fromdate).ToString("dd/MM/yyyy");
        //string todate1 = Convert.ToDateTime(todate).ToString("dd/MM/yyyy");
        SqlConnection con = new SqlConnection(constr);
        DataSet ds;
        SqlDataAdapter da;
        string data = column + Average + C_max + C_min + Y_max + Y_min;
        if (data != null && data.ToString() != "")
        {
            data = data.Substring(1);
            query = "select " + data + " from " + Tablename + " where  Qdate>='" + fromdate + "' and Qdate<='" + todate + "'" + Shift + " " + UNIT + " and MachineName='" + mchn + "'";
            if (query != "" && query != null)
            {
                objds = new DataSet();
                objda = new SqlDataAdapter(query, con);
                objda.Fill(objds);

            }
        }
        return objds;
    }
    public DataSet RunViewdimension(string Partno, string Tablename, string fromdate, string todate, string shift, string mchn, string Unit, string Cell, string Opertaion, string Dimension, string Mean, string Dynrefid, string DynValueid)
    {
        int n = 0;
        decimal tolerval = 0;
        string ucl = "", usl = "";
        string lcl = "", lsl = "", processmean = "";
        string Chartpercent = "";
        string column = "";
        string Average = "";
        string C_max = "";
        string C_min = "";
        string Y_max = "";
        string Y_min = "";
        string Green = "";
        // string _Green = "";
        string Yellow = "";
        // string _Yellow = "";

        decimal roundusl=0;
        decimal roundlsl=0;
        decimal roundmean=0;
        string CellValue = "";
        try
        {
            //SqlDataAdapter da1 = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and RunChart='Yes' and DID='" + Dynrefid + "' order by DID", strConnString);
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and RunChart='Yes' and DID='" + Dynrefid + "' order by ReorderMaster", strConnString);

            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    //int count = Convert.ToInt32(ds1.Tables[0].Rows[i]["Int_count"].ToString());

                    //SqlDataAdapter dadyn = new SqlDataAdapter("select * from DynmasterValues where DynRefid='" + Dynrefid + "' ", strConnString);
                    SqlDataAdapter dadyn = new SqlDataAdapter("select * from DynmasterValues where DVID='" + DynValueid + "' ", strConnString);
                    DataSet dsdyn = new DataSet();
                    dadyn.Fill(dsdyn);
                    if (dsdyn.Tables[0].Rows.Count > 0)
                    {
                        for (int k = 0; k < dsdyn.Tables[0].Rows.Count; k++)
                        {
                            usl = usl + "," + dsdyn.Tables[0].Rows[k]["UpperValue"].ToString();
                            lsl = lsl + "," + dsdyn.Tables[0].Rows[k]["LowerValue"].ToString();
                            //ucl = ucl + "," + dsdyn.Tables[0].Rows[k]["RUCL"].ToString();
                            //lcl = lcl + "," + dsdyn.Tables[0].Rows[k]["RLCL"].ToString();
                            //processmean = processmean + "," + dsdyn.Tables[0].Rows[k]["RPMean"].ToString();
                        }
                    }

                    string id = ds1.Tables[0].Rows[i]["DID"].ToString();
                    if ((ds1.Tables[0].Rows[i]["CellValues"].ToString() == "0") || (ds1.Tables[0].Rows[i]["CellValues"].ToString() == ""))
                    {
                        //for (int j = 1; j <= 1; j++)
                        //{

                        string three = ds1.Tables[0].Rows[i]["Instrument"].ToString().Substring(0, 3);

                        column = column + "," + three + "" + id + "" + Dimension;
                        CellValue = "0";

                        //DataSet dscol = GetDateset("select * from DynmasterValues where DynRefid='" + Dynrefid + "' ");
                        //if (dscol.Tables[0].Rows.Count > 0)
                        //{
                        //    for (int c = 0; c < dscol.Tables[0].Rows.Count; c++)
                        //    {
                        //        n = n+1;
                        //        if (dscol.Tables[0].Rows[c]["DVID"].ToString() == DynValueid.ToString())
                        //        {
                        //            column = column + "," + three + "" + id + "" + "" + n + "";
                        //        }
                        //    }
                        //}

                        //ucl = ucl + "," + ds1.Tables[0].Rows[i]["UCL"].ToString();
                        //lcl = lcl + "," + ds1.Tables[0].Rows[i]["LCL"].ToString();
                        //Chartpercent = Chartpercent + "," + ds1.Tables[0].Rows[i]["Runpercent"].ToString();


                        //column = column + "," + "QMax_" + "" + id + "" + Dimension;
                        //column = column + "," + "QMin_" + "" + id + "" + Dimension;
                        //column = column + "," + "Chart_CPD" + "" + id + "" + Dimension;
                        //column = column + "," + "Chart_CPKD" + "" + id + "" + Dimension;
                        //Average = Average + "," + "AverageD" + "" + id + "" + Dimension;
                        //C_max = C_max + "," + "Chart_MaxD" + "" + id + "" + Dimension;
                        //C_min = C_min + "," + "Chart_MinD" + "" + id + "" + Dimension;
                        //Y_max = Y_max + "," + "Chart_Y_MaxD" + "" + id + "" + Dimension;
                        //Y_min = Y_min + "," + "Chart_Y_MinD" + "" + id + "" + Dimension;
                        //Green = Green + "," + "Chart_G_MaxD" + "" + id + "" + Dimension;
                        //Green = Green + "," + "Chart_G_MinD" + "" + id + "" + Dimension;


                        // }
                    }
                    else
                    {
                        CellValue = "2";
                        //column = column + "," + "QMax_" + "" + id + "" + Dimension;
                        //column = column + "," + "QMin_" + "" + id + "" + Dimension;
                        Average = Average + "," + "AverageD" + "" + id + "" + Dimension;
                    }
                }
            }
            string _part, _operation, Shift, UNIT;
            if (Unit == "ALL")
            {
                UNIT = " and Unit in('MBU','ABU')";
            }
            else
            {
                UNIT = "and Unit='" + Unit + "'";
            }
            if (shift == "All")
            {
                Shift = " and QShift in('A','B','C','G','A1','B1')";
            }
            else
            {
                Shift = "and QShift='" + shift + "'";
            }

            //if (Unit == "ALL")
            //{
            //    UNIT = " and Unit in('MBU','ABU')";
            //}
            //else
            //{
            //    UNIT = "and Unit='" + Unit + "'";
            //}
            //if (shift == "All")
            //{
            //    Shift = " and QShift in('A','B','C','G','A1','B1')";
            //}
            //else
            //{
            //    Shift = "and QShift='" + shift + "'";
            //}

            //string fromdate1 = Convert.ToDateTime(fromdate).ToString("dd/MM/yyyy");
            //string todate1 = Convert.ToDateTime(todate).ToString("dd/MM/yyyy");
            SqlConnection con = new SqlConnection(constr);
            DataSet ds;
            SqlDataAdapter da;

            //string[] ucl1 = ucl.Split(',');
            //string[] lcl1 = lcl.Split(',');
            //string[] pmean = processmean.Split(',');
            string[] usl1 = usl.Split(',');
            string[] lsl1 = lsl.Split(',');
            
            //string[] chartpercent1 = Chartpercent.Split(',');
            string data = column + Average + C_max + C_min + Y_max + Y_min;
            if (data != null && data.ToString() != "")
            {
                data = data.Substring(1);
                //            query = "select " + data + " from " + Tablename + " where  CreateDate>='" + Convert.ToDateTime(fromdate).ToString("dd/MM/yyyy") + "' and CreateDate<='" + Convert.ToDateTime(todate).ToString("dd/MM/yyyy") + "'" + Shift + " " + UNIT + " and MachineName='" + mchn + "'";
                //query = "select " + data + " from " + Tablename + " where CONVERT(VARCHAR,Qdate,103)>='" + Convert.ToDateTime(fromdate).ToString("dd/MM/yyyy") + "' and CONVERT(VARCHAR,Qdate,103)<='" + Convert.ToDateTime(todate).ToString("dd/MM/yyyy") + "'" + Shift + " " + UNIT + " and MachineName='" + mchn + "'";
                //query = "select " + data + " from " + Tablename + " where CONVERT(VARCHAR,Qdate,103) >= CONVERT(VARCHAR, '" + fromdate + "', 103) and CONVERT(VARCHAR,Qdate,103)<= CONVERT(VARCHAR, '" + todate + "', 103) " + Shift + " " + UNIT + " and MachineName='" + mchn + "' and " + data + " !='-' and " + data + " !='ok' and " + data + " !='notok' and " + data + " !='not ok' ";

                //string from_date[] = fromdate.Split('/');
                //string from_date = Convert.ToDateTime(fromdate).Day.ToString("00");
                //string from_mon = Convert.ToDateTime(fromdate).Month.ToString("00");
                //string from_year = Convert.ToDateTime(fromdate).Year.ToString("00");

                string fromdate1 = Convert.ToDateTime(fromdate).Year.ToString() + "/" + Convert.ToDateTime(fromdate).Month.ToString("00") + "/" + Convert.ToDateTime(fromdate).Day.ToString("00");
                string todate1 = Convert.ToDateTime(todate).Year.ToString() + "/" + Convert.ToDateTime(todate).Month.ToString("00") + "/" + Convert.ToDateTime(todate).Day.ToString("00");

                //string fromdate1 = Convert.ToDateTime(fromdate).ToString("yyyy/MM/dd");
                //string todate1 = Convert.ToDateTime(todate).ToString("yyyy/MM/dd");
                string setUCL = "", setLCL = "", setPMean = "";
                DataSet dsUCL= GetDateset("select RUCL from Runchart where DVRefid='" + DynValueid.ToString() + "' and RCStatus='Active'");
                if (dsUCL.Tables[0].Rows.Count > 0)
                {
                    setUCL = dsUCL.Tables[0].Rows[0]["RUCL"].ToString();
                }
                else
                { setUCL = "0"; }
                DataSet dsLCL = GetDateset("select RLCL from Runchart where DVRefid='" + DynValueid.ToString() + "' and RCStatus='Active'");
                if (dsLCL.Tables[0].Rows.Count > 0)
                {
                    setLCL = dsLCL.Tables[0].Rows[0]["RLCL"].ToString();
                }
                else
                { setLCL = "0"; }
                DataSet dsPMean = GetDateset("select RPMean from Runchart where DVRefid='" + DynValueid.ToString() + "' and RCStatus='Active'");
                if (dsPMean.Tables[0].Rows.Count > 0)
                {
                    setPMean = dsPMean.Tables[0].Rows[0]["RPMean"].ToString();
                }
                else
                { setPMean = "0"; }

                //query = "select " + data + ",isnull(s.RUCL," + setUCL + ") as UCL,isnull(s.RLCL," + setLCL + ") as LCL,isnull(s.RPMean," + setPMean + ") as PMean from " + Tablename + " a OUTER APPLY (SELECT * FROM Runchart b WHERE (CONVERT(VARCHAR,a.Qdate,111)  between CONVERT(VARCHAR, b.Creationdate, 111) and CONVERT(VARCHAR, b.Enddate, 111)) and ((CONVERT(VARCHAR,Creationdate,111) >=CONVERT(VARCHAR, '" + fromdate1 + "', 111) and CONVERT(VARCHAR,Enddate,111) <= CONVERT(VARCHAR, '" + todate1 + "', 111)) OR (CONVERT(VARCHAR,Enddate,111) >= CONVERT(VARCHAR, '" + fromdate1 + "', 111) AND CONVERT(VARCHAR,Creationdate,111) <= CONVERT(VARCHAR, '" + todate1 + "', 111))  and (DVRefid='" + DynValueid.ToString() + "')) or ((RCStatus='Active') and (DVRefid='" + DynValueid.ToString() + "')) ) as s where CONVERT(VARCHAR,Qdate,111) >= CONVERT(VARCHAR, '" + fromdate1 + "', 111) and CONVERT(VARCHAR,Qdate,111)<= CONVERT(VARCHAR, '" + todate1 + "', 111) " + Shift + " " + UNIT + " and MachineName='" + mchn + "' and " + data + " !='-' and " + data + " !='ok' and " + data + " !='notok' and " + data + " !='not ok' ";
                if (CellValue == "0")
                {
                    query = "select " + data + ",Comments,isnull(s.RUCL," + setUCL + ") as UCL,isnull(s.RLCL," + setLCL + ") as LCL,isnull(s.RPMean," + setPMean + ") as PMean from " + Tablename + " a OUTER APPLY (SELECT * FROM Runchart b WHERE (CONVERT(VARCHAR,a.Qdate,111)  between CONVERT(VARCHAR, b.Creationdate, 111) and CONVERT(VARCHAR, b.Enddate, 111)) and (DVRefid='" + DynValueid.ToString() + "') or (CONVERT(VARCHAR,Creationdate,111) >=CONVERT(VARCHAR, '" + fromdate1 + "', 111) and CONVERT(VARCHAR,Enddate,111) <= CONVERT(VARCHAR, '" + todate1 + "', 111) and (DVRefid='" + DynValueid.ToString() + "')) OR (CONVERT(VARCHAR,Enddate,111) >= CONVERT(VARCHAR, '" + fromdate1 + "', 111) AND CONVERT(VARCHAR,Creationdate,111) <= CONVERT(VARCHAR, '" + todate1 + "', 111) and (DVRefid='" + DynValueid.ToString() + "')) and (RCStatus='Active' and (DVRefid='" + DynValueid.ToString() + "') ) ) as s where CONVERT(VARCHAR,Qdate,111) >= CONVERT(VARCHAR, '" + fromdate1 + "', 111) and CONVERT(VARCHAR,Qdate,111)<= CONVERT(VARCHAR, '" + todate1 + "', 111) " + Shift + " " + UNIT + "  and MachineName='" + mchn + "' and " + data + " !='-' and " + data + " !='ok' and " + data + " !='notok' and " + data + " !='not ok' ";
                }
                else
                {
                    query = "select " + data + ",Comments,isnull(s.RUCL," + setUCL + ") as UCL,isnull(s.RLCL," + setLCL + ") as LCL,isnull(s.RPMean," + setPMean + ") as PMean from " + Tablename + " a OUTER APPLY (SELECT * FROM Runchart b WHERE (CONVERT(VARCHAR,a.Qdate,111)  between CONVERT(VARCHAR, b.Creationdate, 111) and CONVERT(VARCHAR, b.Enddate, 111)) and (DVRefid='" + DynValueid.ToString() + "') or (CONVERT(VARCHAR,Creationdate,111) >=CONVERT(VARCHAR, '" + fromdate1 + "', 111) and CONVERT(VARCHAR,Enddate,111) <= CONVERT(VARCHAR, '" + todate1 + "', 111) and (DVRefid='" + DynValueid.ToString() + "')) OR (CONVERT(VARCHAR,Enddate,111) >= CONVERT(VARCHAR, '" + fromdate1 + "', 111) AND CONVERT(VARCHAR,Creationdate,111) <= CONVERT(VARCHAR, '" + todate1 + "', 111) and (DVRefid='" + DynValueid.ToString() + "')) and (RCStatus='Active' and (DVRefid='" + DynValueid.ToString() + "') ) ) as s where CONVERT(VARCHAR,Qdate,111) >= CONVERT(VARCHAR, '" + fromdate1 + "', 111) and CONVERT(VARCHAR,Qdate,111)<= CONVERT(VARCHAR, '" + todate1 + "', 111) " + Shift + " " + UNIT + "  and MachineName='" + mchn + "' ";
                }
                if (query != "" && query != null)
                {
                    //objds = new DataSet();
                    //Lab.Keyfile key = new Lab.Keyfile();
                    //key._fromDate = fromdate1.ToString();
                    //key._toDate = todate1.ToString();
                    //key._Data = data.ToString();
                    //key._Shift = shift.ToString();
                    //key._Unit = Unit.ToString();
                    //key._Machine = mchn.ToString();
                    //key._Dynvalueid = DynValueid.ToString();
                    //objds = key.ViewRunChart(key);

                    objds = new DataSet();
                    objda = new SqlDataAdapter(query, con);
                    objda.Fill(objds);


                    DataTable runTable = objds.Tables[0];

                   // runTable.Columns.Add("UCL", typeof(string));
                   // runTable.Columns.Add("LCL", typeof(string));
                   // runTable.Columns.Add("PMean", typeof(string));

                   // string fromdate1 = Convert.ToDateTime(fromdate).ToString("yyyy/MM/dd");
                   // string todate1 = Convert.ToDateTime(todate).ToString("yyyy/MM/dd");
                   ////DataRow tr = new DataRow();
                   // DataSet dsrun = new DataSet();
                   // dsrun.Tables.Clear();
                   // dsrun.Clear();
                   // dsrun.Reset();
                   // dsrun = GetDateset("select RUCL,RLCL,RPMean FROM Runchart WHERE (CONVERT(VARCHAR,Creationdate,111) >=CONVERT(VARCHAR, '" + fromdate1 + "', 111) and CONVERT(VARCHAR,Enddate,111) <= CONVERT(VARCHAR, '" + todate1 + "', 111)) OR (CONVERT(VARCHAR,Enddate,111) >= CONVERT(VARCHAR, '" + fromdate1 + "', 111) AND CONVERT(VARCHAR,Creationdate,111) <= CONVERT(VARCHAR, '" + todate1 + "', 111)) or (RCStatus='Active') and (DVRefid='" + DynValueid.ToString() + "') ");
                   // if (dsrun.Tables[0].Rows.Count > 0)
                   // {
                   //     for (int i = 0; i < dsrun.Tables[0].Rows.Count; i++)
                   //     {
                   //         tr = runTable.Rows[i];
                   //         tr["UCL"] = dsrun.Tables[0].Rows[i]["RUCL"].ToString();
                   //         tr["LCL"] = dsrun.Tables[0].Rows[i]["RLCL"].ToString();
                   //         tr["PMean"] = dsrun.Tables[0].Rows[i]["RPMean"].ToString();
                   //     }
                   // }
                    //DataTable dt1 = runTable.Clone();
                    //var rows = from row in runTable.AsEnumerable()
                    //           where row.Field<string>("UCL") == null
                    //           select row;
                    //foreach (DataRow dr1 in rows)
                    //{
                    //    dt1.Rows.Add(dr1);
                    //}

     //               runTable.Select(string.Format("[UCL] = '{0}'", null))
     //.ToList<DataRow>()
     //.ForEach(r =>
     //{
     //    r["UCL"] = 0;
     //    r["LCL"] = 0;
     //    r["PMean"] = 0;
     //});

    //                var rowsToUpdate =
    //runTable.AsEnumerable().Where(r => r.Field<string>("UCL") == null);

    //                foreach (var row in rowsToUpdate)
    //                {
    //                    row.SetField("UCL", 0);
    //                    row.SetField("LCL", 0);
    //                    row.SetField("PMean", 0);
    //                }

                    //DataSet rundata = new DataSet();
                    //rundata.Tables.Add(runTable);

                    //objds = null;
                    //objds = rundata;
                    //objds.Merge(dsrun);

                    decimal max = Convert.ToDecimal(runTable.AsEnumerable()
                            .Max(row1 => row1[runTable.Columns[0].ColumnName]));
                    decimal min = Convert.ToDecimal(runTable.AsEnumerable()
                           .Min(row1 => row1[runTable.Columns[0].ColumnName]));

                    decimal range = max - min;
                    //decimal x_interval = Math.Round(range / 5, 3);
                    decimal x_interval = range / 5;
                    if (x_interval <= 0)
                    {
                        x_interval = 1;
                    }

                    //decimal roundusl = Decimal.Parse(Regex.Match(usl1[1].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                    //decimal roundlsl = Decimal.Parse(Regex.Match(lsl1[1].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                    //decimal roundmean = Decimal.Parse(Regex.Match(Mean, "-?[0-9]*\\.*[0-9]*").Value);

                    //decimal roundusl;
                    //decimal roundlsl;
                    //decimal roundmean;
                    if (usl1[1].ToString() != "-" && usl1[1].ToString() != "")
                    {
                        roundusl = Decimal.Parse(Regex.Match(usl1[1].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                    }
                    else
                    {
                        if (lsl1[1].ToString() != "" && lsl1[1].ToString() != "-" && (Mean.ToString() == "-" || Mean.ToString() == ""))
                        {
                        }
                        else
                        {
                            roundusl = 0;
                        }
                    }
                    if (lsl1[1].ToString() != "-" && lsl1[1].ToString() != "")
                    {
                        roundlsl = Decimal.Parse(Regex.Match(lsl1[1].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                    }
                    else
                    {
                        roundlsl = 0;
                    }
                    if (Mean.ToString() != "-" && Mean.ToString() != "")
                    {
                        roundmean = Decimal.Parse(Regex.Match(Mean, "-?[0-9]*\\.*[0-9]*").Value);
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

                    decimal tolerance = Convert.ToDecimal(roundusl) - Convert.ToDecimal(roundlsl);

                    tolerval = Math.Round(((tolerance * 60) / 100) / 2, 3);

                    //if (chartpercent1[1].ToString() == "")
                    //{
                    //    tolerval = Math.Round(((tolerance * 0) / 100) / 2, 3);
                    //}
                    //else
                    //{
                    //    tolerval = Math.Round(((tolerance * Convert.ToInt32(chartpercent1[1].ToString())) / 100) / 2, 3);
                    //}

                    //decimal percentucl = Math.Round(Convert.ToDecimal(roundmean) + tolerval, 3);
                    //decimal pecentlcl = Math.Round(Convert.ToDecimal(roundmean) - tolerval, 3);

                    //decimal Rmax = Math.Round((Convert.ToDecimal(roundusl) + Convert.ToDecimal(0.004)), 3);
                    //decimal Rmin = Math.Round((Convert.ToDecimal(roundlsl) - Convert.ToDecimal(0.004)), 3);

                    //decimal Rmax = Math.Round((Convert.ToDecimal(max) + Convert.ToDecimal(x_interval)), 3);

                    //decimal Rmin;
                    //if (roundlsl > 0)
                    //{
                    //    Rmin = Math.Round((Convert.ToDecimal(min) - Convert.ToDecimal(x_interval)), 3);
                    //}
                    //else
                    //{ Rmin = Math.Round(Convert.ToDecimal(roundlsl), 3); }

                    decimal Rmax;
                    decimal Rmin;
                    if (max > roundusl)
                    { Rmax = Math.Round((Convert.ToDecimal(max) + Convert.ToDecimal(0.00)), 3); }
                    else
                    { Rmax = Math.Round((Convert.ToDecimal(roundusl) + Convert.ToDecimal(0.00)), 3); }

                  
                    if (roundlsl > 0)
                    {
                        if (min < roundlsl)
                        {
                            Rmin = Math.Round((Convert.ToDecimal(min) - Convert.ToDecimal(0.00)), 3);
                        }
                        else
                        { Rmin = Math.Round((Convert.ToDecimal(roundlsl) - Convert.ToDecimal(0.00)), 3); }

                        if (Rmin < 0)
                        {
                            Rmin = Math.Round((Convert.ToDecimal(0)), 3);
                        }
                    }
                    else
                    { Rmin = Math.Round((Convert.ToDecimal(roundlsl)), 3); }

                    //decimal Ymax = Math.Round((Convert.ToDecimal(roundusl) - Convert.ToDecimal(x_interval)), 3);
                    //decimal Ymin = Math.Round((Convert.ToDecimal(roundlsl) - Convert.ToDecimal(x_interval)), 3);

                    objds.Tables[0].Columns.Add("RMax", typeof(string), Rmax.ToString());
                    objds.Tables[0].Columns.Add("RMin", typeof(string), Rmin.ToString());
                    objds.Tables[0].Columns.Add("Mean", typeof(string), Mean.ToString());
                    objds.Tables[0].Columns.Add("Max", typeof(string), roundusl.ToString());
                    objds.Tables[0].Columns.Add("Min", typeof(string), roundlsl.ToString());
                    //objds.Tables[0].Columns.Add("YMax", typeof(string), Ymax.ToString());
                    //objds.Tables[0].Columns.Add("YMin", typeof(string), Ymin.ToString());

                    //objds.Tables[0].Columns.Add("UCL", typeof(string), ucl1[1].ToString());
                    //objds.Tables[0].Columns.Add("LCL", typeof(string), lcl1[1].ToString());
                    //objds.Tables[0].Columns.Add("PMean", typeof(string), pmean[1].ToString());

                    //objds.Tables[0].Columns.Add("UCL", typeof(string));
                    //objds.Tables[0].Columns.Add("LCL", typeof(string));
                    //objds.Tables[0].Columns.Add("PMean", typeof(string));



                    //DataTable dd = objds.Tables[0];
                    //DataColumn dc = dd.Columns.Add("UCL").Expression = ucl1.ToString();
                    //DataColumn dc1 = dd.Columns.Add("LCL").Expression = "31.015";
                    //DataColumn dc2 = dd.Columns.Add("Max").Expression = max.ToString();
                    //DataColumn dc3 = dd.Columns.Add("Min").Expression = min.ToString();
                    //dt.Columns.Add(New DataColumn() With {.ColumnName = "Max",.DataType = GetType(String),
                    //    .DefaultValue = "Jam and chips"})

                    //********* INTERVAL **********
                    objds.Tables[0].Columns.Add("XInterval", typeof(string), x_interval.ToString());

                }
            }
        }
        catch (Exception ex)
        {
            objds = null;

            //string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);

            //foreach (string filePath in Directory.GetFiles(tempPath, "*.*", SearchOption.AllDirectories))
            //{
            //    try
            //    {
            //        FileInfo currentFile = new FileInfo(filePath);
            //        currentFile.Delete();
            //    }
            //    catch (Exception ex1)
            //    {
            //        //Debug.WriteLine("Error on file: {0}\r\n   {1}", filePath, ex.Message);
            //    }
            //}
        }
        return objds;
    }

    public DataSet SPCViewdimension(string Partno, string Tablename, string fromdate, string todate, string shift, string mchn, string Unit, string Cell, string Opertaion, string Dimension, string Mean, string Dynrefid)
    {
        decimal pp, ppk;
        decimal dec_Sqrt = 0;
        string[] Allshift = { "A", "B", "C", "G", "A1", "B1" };
        DataTable spcdt = new DataTable();
        DataRow dr;
        DataTable tempdt = new DataTable();
        DataTable sddt = new DataTable();
        DataRow dr1;
        sddt.Columns.Add("sd", typeof(Decimal));
        string ucl = "", usl = "";
        string lcl = "", lsl = "";
        string column = "";
        string Average = "";
        string C_max = "";
        string C_min = "";
        string Y_max = "";
        string Y_min = "";
        string Green = "";
        // string _Green = "";
        string Yellow = "";
        // string _Yellow = "";
        try
        {
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and RunChart='Yes' and DID='" + Dynrefid + "' order by DID", strConnString);
            DataSet ds1 = new DataSet();
            ds1.Tables.Clear();
            ds1.Clear();
            ds1.Reset();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    //int count = Convert.ToInt32(ds1.Tables[0].Rows[i]["Int_count"].ToString());
                    string id = ds1.Tables[0].Rows[i]["DID"].ToString();
                    if ((ds1.Tables[0].Rows[i]["CellValues"].ToString() == "0") || (ds1.Tables[0].Rows[i]["CellValues"].ToString() == ""))
                    {
                        //for (int j = 1; j <= 1; j++)
                        //{
                        string three = ds1.Tables[0].Rows[i]["Instrument"].ToString().Substring(0, 3);

                        column = column + "," + three + "" + id + "" + "1";
                        ucl = ucl + "," + ds1.Tables[0].Rows[i]["UCL"].ToString();
                        lcl = lcl + "," + ds1.Tables[0].Rows[i]["LCL"].ToString();

                        SqlDataAdapter dadyn = new SqlDataAdapter("select * from DynmasterValues where DynRefid='" + Dynrefid + "' ", strConnString);
                        DataSet dsdyn = new DataSet();
                        dadyn.Fill(dsdyn);
                        if (dsdyn.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < dsdyn.Tables[0].Rows.Count; k++)
                            {
                                usl = usl + "," + dsdyn.Tables[0].Rows[k]["UpperValue"].ToString();
                                lsl = lsl + "," + dsdyn.Tables[0].Rows[k]["LowerValue"].ToString();

                            }
                        }
                        //column = column + "," + "QMax_" + "" + id + "" + Dimension;
                        //column = column + "," + "QMin_" + "" + id + "" + Dimension;
                        //column = column + "," + "Chart_CPD" + "" + id + "" + Dimension;
                        //column = column + "," + "Chart_CPKD" + "" + id + "" + Dimension;
                        //Average = Average + "," + "AverageD" + "" + id + "" + Dimension;
                        //C_max = C_max + "," + "Chart_MaxD" + "" + id + "" + Dimension;
                        //C_min = C_min + "," + "Chart_MinD" + "" + id + "" + Dimension;
                        //Y_max = Y_max + "," + "Chart_Y_MaxD" + "" + id + "" + Dimension;
                        //Y_min = Y_min + "," + "Chart_Y_MinD" + "" + id + "" + Dimension;
                        //Green = Green + "," + "Chart_G_MaxD" + "" + id + "" + Dimension;
                        //Green = Green + "," + "Chart_G_MinD" + "" + id + "" + Dimension;


                        // }
                    }
                }
            }
            string _part, _operation, Shift, UNIT;
            if (Unit == "ALL")
            {
                UNIT = " and Unit in('MBU','ABU')";
            }
            else
            {
                UNIT = "and Unit='" + Unit + "'";
            }
            if (shift == "All")
            {
                Shift = " and QShift in('A','B','C','G','A1','B1')";
            }
            else
            {
                Shift = "and QShift='" + shift + "'";
            }

            //string fromdate1 = Convert.ToDateTime(fromdate).ToString("dd/MM/yyyy");
            //string todate1 = Convert.ToDateTime(todate).ToString("dd/MM/yyyy");

            SqlConnection con = new SqlConnection(constr);
            DataSet ds;
            SqlDataAdapter da;
            string[] ucl1 = ucl.Split(',');
            string[] lcl1 = lcl.Split(',');
            string[] usl1 = usl.Split(',');
            string[] lsl1 = lsl.Split(',');
            string data = column + Average + C_max + C_min + Y_max + Y_min;
            if (data != null && data.ToString() != "")
            {
                data = data.Substring(1);
                spcdt.Columns.Add(data, typeof(Decimal));
                spcdt.Columns.Add("R", typeof(Decimal));
                //spcdt.Columns.Add("sd", typeof(Decimal));
                DateTime StartDate = Convert.ToDateTime(fromdate);
                DateTime EndDate = Convert.ToDateTime(todate);

                double differ = (EndDate - StartDate).TotalDays;
                for (int b = 0; b <= differ; b++)
                {
                    DateTime eachdate = Convert.ToDateTime(fromdate).AddDays(b);
                    string streachdate = eachdate.ToString("dd/MM/yyyy");

                    if (shift == "All")
                    {
                        for (int a = 0; a < Allshift.Length; a++)
                        {
                            //                        query = "select top 5 " + data + " from " + Tablename + " where CreateDate='" + streachdate + "' and QShift='" + Allshift[a].ToString() + "' " + UNIT + " and MachineName='" + mchn + "'";
                            //                        query = "select top 5 " + data + " from " + Tablename + " where CONVERT(VARCHAR,Qdate,103)='" + streachdate + "' and QShift='" + Allshift[a].ToString() + "' " + UNIT + " and MachineName='" + mchn + "'";

                            query = "select top 5 " + data + " from " + Tablename + " where CONVERT(VARCHAR,Qdate,103) = CONVERT(VARCHAR, '" + streachdate + "', 103) and QShift='" + Allshift[a].ToString() + "' " + UNIT + " and MachineName='" + mchn + "'";

                            tempdt = new DataTable();
                            objda = new SqlDataAdapter(query, con);
                            objda.Fill(tempdt);
                            if (tempdt.Rows.Count == 5)
                            {

                                var result = tempdt.AsEnumerable()
                       .Average(x => Convert.ToDecimal(x[data]));
                                //decimal avg = Math.Round(Convert.ToDecimal(result), 3);
                                decimal avg = Convert.ToDecimal(result);
                                decimal RCmax = Convert.ToDecimal(tempdt.AsEnumerable()
                                                    .Max(row1 => row1[tempdt.Columns[0].ColumnName]));
                                decimal RCmin = Convert.ToDecimal(tempdt.AsEnumerable()
                                       .Min(row1 => row1[tempdt.Columns[0].ColumnName]));
                                //decimal Rval = Math.Round((RCmax - RCmin), 3);
                                decimal Rval = (RCmax - RCmin);

                                dr = spcdt.NewRow();
                                dr[data] = avg;
                                dr["R"] = Rval;
                                spcdt.Rows.Add(dr);

                            }
                        }
                    }
                    else
                    {
                        //query = "select top 5 " + data + " from " + Tablename + " where  CreateDate ='" + streachdate + "' " + Shift + " " + UNIT + " and MachineName='" + mchn + "'";
                        //query = "select top 5 " + data + " from " + Tablename + " where  CONVERT(VARCHAR,Qdate,103) ='" + streachdate + "' " + Shift + " " + UNIT + " and MachineName='" + mchn + "'";
                        query = "select top 5 " + data + " from " + Tablename + " where  CONVERT(VARCHAR,Qdate,103) = CONVERT(VARCHAR, '" + streachdate + "', 103) " + Shift + " " + UNIT + " and MachineName='" + mchn + "'";
                        tempdt = new DataTable();
                        objda = new SqlDataAdapter(query, con);
                        objda.Fill(tempdt);
                        if (tempdt.Rows.Count == 5)
                        {
                            var result = tempdt.AsEnumerable()
                   .Average(x => Convert.ToDecimal(x[data]));
                            //decimal avg = Math.Round(Convert.ToDecimal(result), 3);
                            decimal avg = Convert.ToDecimal(result);
                            decimal RCmax = Convert.ToDecimal(tempdt.AsEnumerable()
                                                .Max(row1 => row1[tempdt.Columns[0].ColumnName]));
                            decimal RCmin = Convert.ToDecimal(tempdt.AsEnumerable()
                                   .Min(row1 => row1[tempdt.Columns[0].ColumnName]));
                            //decimal Rval = Math.Round((RCmax - RCmin), 3);
                            decimal Rval = (RCmax - RCmin);

                            dr = spcdt.NewRow();
                            dr[data] = avg;
                            dr["R"] = Rval;
                            spcdt.Rows.Add(dr);

                        }
                    }
                }

                //if (query != "" && query != null)
                //{
                //objds = new DataSet();
                //objda = new SqlDataAdapter(query, con);
                //objda.Fill(objds);

                if (spcdt.Rows.Count > 0)
                {
                    var xdoublebar = spcdt.AsEnumerable()
                               .Average(x => Convert.ToDecimal(x[spcdt.Columns[0].ColumnName]));
                    //decimal dec_xdoublebar = Math.Round(Convert.ToDecimal(xdoublebar), 3);

                    decimal dec_xdoublebar = Convert.ToDecimal(xdoublebar);

                    for (int b = 0; b <= differ; b++)
                    {
                        DateTime eachdate = Convert.ToDateTime(fromdate).AddDays(b);
                        string streachdate = eachdate.ToString("dd/MM/yyyy");

                        if (shift == "All")
                        {
                            for (int a = 0; a < Allshift.Length; a++)
                            {
                                //                            query = "select top 5 " + data + " from " + Tablename + " where CreateDate='" + streachdate + "' and QShift='" + Allshift[a].ToString() + "' " + UNIT + " and MachineName='" + mchn + "'";
                                query = "select top 5 " + data + " from " + Tablename + " where CONVERT(VARCHAR,Qdate,101) = CONVERT(VARCHAR, '" + streachdate + "', 101) and QShift='" + Allshift[a].ToString() + "' " + UNIT + " and MachineName='" + mchn + "'";
                                tempdt = new DataTable();
                                objda = new SqlDataAdapter(query, con);
                                objda.Fill(tempdt);
                                if (tempdt.Rows.Count == 5)
                                {
                                    for (int c = 0; c < tempdt.Rows.Count; c++)
                                    {
                                        decimal values = Convert.ToDecimal(tempdt.Rows[c][data].ToString());
                                        decimal output = (decimal)Math.Pow((double)values - (double)dec_xdoublebar, 2);
                                        decimal sd = Convert.ToDecimal(output);

                                        dr1 = sddt.NewRow();
                                        dr1["sd"] = sd.ToString();
                                        sddt.Rows.Add(dr1);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //query = "select top 5 " + data + " from " + Tablename + " where  CreateDate ='" + streachdate + "' " + Shift + " " + UNIT + " and MachineName='" + mchn + "'";
                            query = "select top 5 " + data + " from " + Tablename + " where  CONVERT(VARCHAR,Qdate,103) = CONVERT(VARCHAR, '" + streachdate + "', 103) " + Shift + " " + UNIT + " and MachineName='" + mchn + "'";
                            tempdt = new DataTable();
                            objda = new SqlDataAdapter(query, con);
                            objda.Fill(tempdt);
                            if (tempdt.Rows.Count == 5)
                            {
                                for (int c = 0; c < tempdt.Rows.Count; c++)
                                {
                                    decimal values = Convert.ToDecimal(tempdt.Rows[c][data].ToString());
                                    decimal output = (decimal)Math.Pow((double)values - (double)dec_xdoublebar, 2);
                                    decimal sd = Convert.ToDecimal(output);

                                    dr1 = sddt.NewRow();
                                    dr1["sd"] = sd.ToString();
                                    sddt.Rows.Add(dr1);
                                }
                            }
                        }
                    }

                    var sumsd = sddt.AsEnumerable()
                   .Sum(x => Convert.ToDecimal(x[sddt.Columns[0].ColumnName]));

                    decimal sdval = (decimal)((double)(sumsd) / ((sddt.Rows.Count) - 1));
                    decimal Sqrt = (decimal)Math.Sqrt((double)sdval);

                    //dec_Sqrt = Math.Round(Convert.ToDecimal(Sqrt), 3);
                    dec_Sqrt = Convert.ToDecimal(Sqrt);
                }

                objds = new DataSet();
                objds.Tables.Add(spcdt);
                if (objds.Tables[0].Rows.Count > 0)
                {
                    DataTable runTable = objds.Tables[0];

                    decimal Rvalmax = Convert.ToDecimal(runTable.AsEnumerable()
                            .Max(row1 => row1[runTable.Columns[1].ColumnName]));
                    decimal Rvalmin = Convert.ToDecimal(runTable.AsEnumerable()
                           .Min(row1 => row1[runTable.Columns[1].ColumnName]));

                    var xbar = runTable.AsEnumerable()
                           .Average(x => Convert.ToDecimal(x[runTable.Columns[0].ColumnName]));
                    decimal dec_xbar = Convert.ToDecimal(xbar);

                    var r = runTable.AsEnumerable()
               .Average(x => Convert.ToDecimal(x[runTable.Columns[1].ColumnName]));
                    //decimal Rbar = Math.Round(Convert.ToDecimal(r), 3);
                    decimal Rbar = Convert.ToDecimal(r);

                    decimal XbarUCL = Math.Round((dec_xbar + (Convert.ToDecimal(0.577) * Rbar)), 3);
                    decimal XbarLCL = Math.Round((dec_xbar - (Convert.ToDecimal(0.577) * Rbar)), 3);

                    decimal RbarUCL = Math.Round((Convert.ToDecimal(2.114) * Rbar), 3);
                    decimal RbarLCL = Math.Round((Convert.ToDecimal(0) * Rbar), 3);

                    decimal roundusl = Decimal.Parse(Regex.Match(usl1[1].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                    decimal roundlsl = Decimal.Parse(Regex.Match(lsl1[1].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                    decimal roundmean = Decimal.Parse(Regex.Match(Mean, "-?[0-9]*\\.*[0-9]*").Value);
                    decimal tolerance = Convert.ToDecimal(roundusl) - Convert.ToDecimal(roundlsl);

                    if (dec_Sqrt != 0)
                    {
                        pp = Math.Round(tolerance / (6 * dec_Sqrt), 3);
                        decimal ppmax = (roundusl - dec_xbar) / (3 * dec_Sqrt);
                        decimal ppmin = (dec_xbar - roundlsl) / (3 * dec_Sqrt);
                        ppk = Math.Round(Math.Min(ppmax, ppmin), 3);
                        if (pp == 0) { pp = 0.00m; }
                        if (ppk == 0) { ppk = 0.00m; }
                    }
                    else
                    {
                        pp = 0.00m;
                        ppk = 0.00m;
                    }

                    decimal Redmax = Math.Round((Convert.ToDecimal(roundusl) + Convert.ToDecimal(0.004)), 3);
                    decimal Redmin = Math.Round((Convert.ToDecimal(roundlsl) - Convert.ToDecimal(0.004)), 3);
                    //decimal Ymax = Math.Round((Convert.ToDecimal(roundusl) - Convert.ToDecimal(0.001)), 3);
                    //decimal Ymin = Math.Round((Convert.ToDecimal(roundlsl) - Convert.ToDecimal(0.001)), 3);

                    decimal RCmax = Math.Round((Convert.ToDecimal(Rvalmax) + Convert.ToDecimal(0.004)), 3);
                    decimal RCmin = Math.Round((Convert.ToDecimal(Rvalmin) - Convert.ToDecimal(0.004)), 3);

                    objds.Tables[0].Columns.Add("RedMax", typeof(string), Redmax.ToString());
                    objds.Tables[0].Columns.Add("RedMin", typeof(string), Redmin.ToString());
                    objds.Tables[0].Columns.Add("Mean", typeof(string), Mean.ToString());
                    objds.Tables[0].Columns.Add("USL", typeof(string), roundusl.ToString());
                    objds.Tables[0].Columns.Add("LSL", typeof(string), roundlsl.ToString());
                    //objds.Tables[0].Columns.Add("YMax", typeof(string), Ymax.ToString());
                    //objds.Tables[0].Columns.Add("YMin", typeof(string), Ymin.ToString());
                    objds.Tables[0].Columns.Add("UCL", typeof(string), XbarUCL.ToString());
                    objds.Tables[0].Columns.Add("LCL", typeof(string), XbarLCL.ToString());

                    // ********** R Chart ************
                    objds.Tables[0].Columns.Add("RCMax", typeof(string), RCmax.ToString());
                    objds.Tables[0].Columns.Add("RCMin", typeof(string), RCmin.ToString());
                    objds.Tables[0].Columns.Add("RCMean", typeof(string), Rbar.ToString());
                    objds.Tables[0].Columns.Add("RCucl", typeof(string), RbarUCL.ToString());
                    objds.Tables[0].Columns.Add("RClcl", typeof(string), RbarLCL.ToString());

                    //********* pp and ppk **********
                    objds.Tables[0].Columns.Add("pp", typeof(string), pp.ToString());
                    objds.Tables[0].Columns.Add("ppk", typeof(string), ppk.ToString());

                }
            }
        }
        catch (Exception ex)
        {
            objds = null;
        }
        return objds;
    }

    public DataSet SPCViewdimensionAllvalues(string Partno, string Tablename, string fromdate, string todate, string shift, string mchn, string Unit, string Cell, string Opertaion, string Dimension, string Mean, string Dynrefid, string Size, string DynValueid)
    {
        int n = 0;
        string dimensionvalues = string.Empty;
        decimal XbarUCL = 0, XbarLCL = 0;
        decimal RbarUCL = 0, RbarLCL = 0;
        decimal ppk;
        string pp;
        //decimal pp, ppk;
        decimal dec_Sqrt = 0;
        string[] Allshift = { "A", "B", "C", "G", "A1", "B1" };
        DataTable spcdt = new DataTable();
        DataRow dr;
        DataTable tempdt = new DataTable();
        DataTable sddt = new DataTable();
        DataRow dr1;
        sddt.Columns.Add("sd", typeof(Decimal));
        string ucl = "", usl = "";
        string lcl = "", lsl = "";
        string column = "";
        string Average = "";
        string C_max = "";
        string C_min = "";
        string Y_max = "";
        string Y_min = "";
        string Green = "";
        // string _Green = "";
        string Yellow = "";
        // string _Yellow = "";

        decimal roundusl=0;
        decimal roundlsl=0;
        decimal roundmean = 0;
        string CellValue = "";
        try
        {
            //SqlDataAdapter da1 = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and RunChart='Yes' and DID='" + Dynrefid + "' order by DID", strConnString);
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Dynmaster where Partno='" + Partno + "' and Operation='" + Opertaion + "' and Unit='" + Unit + "' and Cell='" + Cell + "' and RunChart='Yes' and DID='" + Dynrefid + "' order by ReorderMaster", strConnString);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    //SqlDataAdapter dadyn = new SqlDataAdapter("select * from DynmasterValues where DynRefid='" + Dynrefid + "' ", strConnString);
                    SqlDataAdapter dadyn = new SqlDataAdapter("select * from DynmasterValues where DVID='" + DynValueid + "' ", strConnString);
                    DataSet dsdyn = new DataSet();
                    dadyn.Fill(dsdyn);
                    if (dsdyn.Tables[0].Rows.Count > 0)
                    {
                        for (int k = 0; k < dsdyn.Tables[0].Rows.Count; k++)
                        {
                            dimensionvalues = dsdyn.Tables[0].Rows[k]["Dimension"].ToString();
                            usl = usl + "," + dsdyn.Tables[0].Rows[k]["UpperValue"].ToString();
                            lsl = lsl + "," + dsdyn.Tables[0].Rows[k]["LowerValue"].ToString();
                        }
                    }

                    //int count = Convert.ToInt32(ds1.Tables[0].Rows[i]["Int_count"].ToString());
                    string id = ds1.Tables[0].Rows[i]["DID"].ToString();
                    if ((ds1.Tables[0].Rows[i]["CellValues"].ToString() == "0") || (ds1.Tables[0].Rows[i]["CellValues"].ToString() == ""))
                    {
                        //for (int j = 1; j <= 1; j++)
                        //{
                        string three = ds1.Tables[0].Rows[i]["Instrument"].ToString().Substring(0, 3);

                        column = column + "," + three + "" + id + "" + Dimension;
                        CellValue = "0";
                        //DataSet dscol = GetDateset("select * from DynmasterValues where DynRefid='" + Dynrefid + "' ");
                        //if (dscol.Tables[0].Rows.Count > 0)
                        //{
                        //    for (int c = 0; c < dscol.Tables[0].Rows.Count; c++)
                        //    {
                        //        n = n + 1;
                        //        if (dscol.Tables[0].Rows[c]["DVID"].ToString() == DynValueid.ToString())
                        //        {
                        //            column = column + "," + three + "" + id + "" + "" + n + "";
                        //        }
                        //    }
                        //}

                        //column = column + "," + three + "" + id + "" + "1";
                        //ucl = ucl + "," + ds1.Tables[0].Rows[i]["UCL"].ToString();
                        //lcl = lcl + "," + ds1.Tables[0].Rows[i]["LCL"].ToString();

                        //column = column + "," + "QMax_" + "" + id + "" + Dimension;
                        //column = column + "," + "QMin_" + "" + id + "" + Dimension;
                        //column = column + "," + "Chart_CPD" + "" + id + "" + Dimension;
                        //column = column + "," + "Chart_CPKD" + "" + id + "" + Dimension;
                        //Average = Average + "," + "AverageD" + "" + id + "" + Dimension;
                        //C_max = C_max + "," + "Chart_MaxD" + "" + id + "" + Dimension;
                        //C_min = C_min + "," + "Chart_MinD" + "" + id + "" + Dimension;
                        //Y_max = Y_max + "," + "Chart_Y_MaxD" + "" + id + "" + Dimension;
                        //Y_min = Y_min + "," + "Chart_Y_MinD" + "" + id + "" + Dimension;
                        //Green = Green + "," + "Chart_G_MaxD" + "" + id + "" + Dimension;
                        //Green = Green + "," + "Chart_G_MinD" + "" + id + "" + Dimension;


                        // }
                    }
                    else
                    {
                        CellValue = "2";
                        //column = column + "," + "QMax_" + "" + id + "" + Dimension;
                        //column = column + "," + "QMin_" + "" + id + "" + Dimension;
                        Average = Average + "," + "AverageD" + "" + id + "" + Dimension;
                    }
                }
            }
            string _part, _operation, Shift, UNIT;
            if (Unit == "ALL")
            {
                UNIT = " and Unit in('MBU','ABU')";
            }
            else
            {
                UNIT = "and Unit='" + Unit + "'";
            }
            if (shift == "All")
            {
                Shift = " and QShift in('A','B','C','G','A1','B1')";
            }
            else
            {
                Shift = "and QShift='" + shift + "'";
            }

            //string fromdate1 = Convert.ToDateTime(fromdate).ToString("dd/MM/yyyy");
            //string todate1 = Convert.ToDateTime(todate).ToString("dd/MM/yyyy");

            SqlConnection con = new SqlConnection(constr);
            DataSet ds;
            SqlDataAdapter da;
            string[] ucl1 = ucl.Split(',');
            string[] lcl1 = lcl.Split(',');
            string[] usl1 = usl.Split(',');
            string[] lsl1 = lsl.Split(',');
            string data = column + Average + C_max + C_min + Y_max + Y_min;
            if (data != null && data.ToString() != "")
            {
                data = data.Substring(1);
                spcdt.Columns.Add(data, typeof(Decimal));
                spcdt.Columns.Add("R", typeof(Decimal));
                //spcdt.Columns.Add("sd", typeof(Decimal));
                //DateTime StartDate = Convert.ToDateTime(fromdate);
                //DateTime EndDate = Convert.ToDateTime(todate);

                //double differ = (EndDate - StartDate).TotalDays;
                //for (int b = 0; b <= differ; b++)
                //{
                //    DateTime eachdate = Convert.ToDateTime(fromdate).AddDays(b);
                //    string streachdate = eachdate.ToString("dd/MM/yyyy");

//                query = "select " + data + " from " + Tablename + " where CONVERT(VARCHAR,Qdate,103) >= CONVERT(VARCHAR, '" + fromdate + "', 103) and CONVERT(VARCHAR,Qdate,103)<= CONVERT(VARCHAR, '" + todate + "', 103) " + Shift + "" + UNIT + " and MachineName='" + mchn + "'";

                //query = "WITH CTE AS (SELECT ROW_NUMBER() OVER (ORDER BY " + data + ") as ROW, " + data + " from " + Tablename + " where CONVERT(VARCHAR,Qdate,103) >= CONVERT(VARCHAR, '" + fromdate + "', 103) and CONVERT(VARCHAR,Qdate,103)<= CONVERT(VARCHAR, '" + todate + "', 103) " + Shift + "" + UNIT + " and MachineName='" + mchn + "' )SELECT a." + data + ",isnull( ABS(CAST(a." + data + " AS decimal(18,10))  - CAST(b." + data + " AS decimal(18,10))),0) as R FROM CTE a LEFT JOIN CTE b ON a.ROW = b.ROW - 1;";
                if (CellValue == "0")
                {
                    query = "WITH CTE AS (SELECT ROW_NUMBER() OVER (ORDER BY QSid) as ROW, " + data + ",Comments from " + Tablename + " where Qdate >= '" + fromdate + "' and Qdate <=  '" + todate + "' " + Shift + "" + UNIT + " and MachineName='" + mchn + "' and " + data + " !='-' and " + data + " !='ok' and " + data + " !='notok' and " + data + " !='not ok' )SELECT a." + data + ",isnull( ABS(CAST(a." + data + " AS decimal(18,10))  - CAST(b." + data + " AS decimal(18,10))),0) as R,a.Comments FROM CTE a LEFT JOIN CTE b ON a.ROW = b.ROW - 1;";
                }
                else
                {
                    query = "WITH CTE AS (SELECT ROW_NUMBER() OVER (ORDER BY QSid) as ROW, " + data + ",Comments from " + Tablename + " where Qdate >= '" + fromdate + "' and Qdate <=  '" + todate + "' " + Shift + "" + UNIT + " and MachineName='" + mchn + "' )SELECT a." + data + ",isnull( ABS(CAST(a." + data + " AS decimal(18,10))  - CAST(b." + data + " AS decimal(18,10))),0) as R,a.Comments FROM CTE a LEFT JOIN CTE b ON a.ROW = b.ROW - 1;";
                }

                    tempdt = new DataTable();
                    objda = new SqlDataAdapter(query, con);
                    objda.Fill(tempdt);
                    if (tempdt.Rows.Count > 0)
                    {
                        spcdt = tempdt;
               //         var result = tempdt.AsEnumerable()
               //.Average(x => Convert.ToDecimal(x[data]));
               //         //decimal avg = Math.Round(Convert.ToDecimal(result), 3);
               //         decimal avg = Convert.ToDecimal(result);
               //         decimal RCmax = Convert.ToDecimal(tempdt.AsEnumerable()
               //                             .Max(row1 => row1[tempdt.Columns[0].ColumnName]));
               //         decimal RCmin = Convert.ToDecimal(tempdt.AsEnumerable()
               //                .Min(row1 => row1[tempdt.Columns[0].ColumnName]));
               //         //decimal Rval = Math.Round((RCmax - RCmin), 3);
               //         decimal Rval = (RCmax - RCmin);

               //         //for (int z = 0; z < tempdt.Rows.Count; z++)
               //         //{
               //         //    decimal value = Convert.ToDecimal(tempdt.Rows[z][data].ToString());
               //         //    decimal output = (decimal)Math.Pow((double)values - (double)dec_xdoublebar, 2);
               //         //    decimal sd = Convert.ToDecimal(output);
               //         //}

               //         dr = spcdt.NewRow();
               //         dr[data] = avg;
               //         dr["R"] = Rval;
               //         spcdt.Rows.Add(dr);

                    }

                //}

                //if (query != "" && query != null)
                //{
                //objds = new DataSet();
                //objda = new SqlDataAdapter(query, con);
                //objda.Fill(objds);

                if (spcdt.Rows.Count > 0)
                {
                    var xdoublebar = spcdt.AsEnumerable()
                               .Average(x => Convert.ToDecimal(x[spcdt.Columns[0].ColumnName]));
                    //decimal dec_xdoublebar = Math.Round(Convert.ToDecimal(xdoublebar), 3);

                    decimal dec_xdoublebar = Convert.ToDecimal(xdoublebar);

                    //for (int b = 0; b <= differ; b++)
                    //{
                    //    DateTime eachdate = Convert.ToDateTime(fromdate).AddDays(b);
                    //    string streachdate = eachdate.ToString("dd/MM/yyyy");

                        //query = "select top 5 " + data + " from " + Tablename + " where  CreateDate ='" + streachdate + "' " + Shift + " " + UNIT + " and MachineName='" + mchn + "'";
                    //query = "select " + data + " from " + Tablename + " where CONVERT(VARCHAR,Qdate,103) >= CONVERT(VARCHAR, '" + fromdate + "', 103) and CONVERT(VARCHAR,Qdate,103)<= CONVERT(VARCHAR, '" + todate + "', 103) " + Shift + " " + UNIT + " and MachineName='" + mchn + "'";
                    if (CellValue == "0")
                    {
                        query = "select " + data + " from " + Tablename + " where Qdate >=  '" + fromdate + "' and Qdate <=  '" + todate + "' " + Shift + " " + UNIT + " and MachineName='" + mchn + "' and " + data + " !='-' and " + data + " !='ok' and " + data + " !='notok' and " + data + " !='not ok' ";
                    }
                    else
                    {
                        query = "select " + data + " from " + Tablename + " where Qdate >=  '" + fromdate + "' and Qdate <=  '" + todate + "' " + Shift + " " + UNIT + " and MachineName='" + mchn + "' ";
                    }

                        tempdt = new DataTable();
                        objda = new SqlDataAdapter(query, con);
                        objda.Fill(tempdt);
                        if (tempdt.Rows.Count > 0)
                        {
                            for (int c = 0; c < tempdt.Rows.Count; c++)
                            {
                                decimal values = Convert.ToDecimal(tempdt.Rows[c][data].ToString());
                                decimal output = (decimal)Math.Pow((double)values - (double)dec_xdoublebar, 2);
                                decimal sd = Convert.ToDecimal(output);

                                dr1 = sddt.NewRow();
                                dr1["sd"] = sd.ToString();
                                sddt.Rows.Add(dr1);
                            }
                        }
                    //}

                    var sumsd = sddt.AsEnumerable()
                   .Sum(x => Convert.ToDecimal(x[sddt.Columns[0].ColumnName]));

                    decimal sdval = (decimal)((double)(sumsd) / ((sddt.Rows.Count) - 1));
                    decimal Sqrt = (decimal)Math.Sqrt((double)sdval);

                    //dec_Sqrt = Math.Round(Convert.ToDecimal(Sqrt), 3);
                    dec_Sqrt = Convert.ToDecimal(Sqrt);
                }

                objds = new DataSet();
                objds.Tables.Add(spcdt);
                if (objds.Tables[0].Rows.Count > 0)
                {
                    DataTable runTable = objds.Tables[0];

                    decimal valmax = Convert.ToDecimal(runTable.AsEnumerable()
                           .Max(row2 => row2[runTable.Columns[0].ColumnName]));
                    decimal valmin = Convert.ToDecimal(runTable.AsEnumerable()
                           .Min(row2 => row2[runTable.Columns[0].ColumnName]));

                    decimal range = valmax - valmin;
//                    decimal x_interval = Math.Round(range / 5, 3);
                    decimal x_interval = range / 5;
                    if (x_interval <= 0)
                    {
                        x_interval = 1;
                    }
                    decimal Rvalmax = Convert.ToDecimal(runTable.AsEnumerable()
                            .Max(row1 => row1[runTable.Columns[1].ColumnName]));
                    decimal Rvalmin = Convert.ToDecimal(runTable.AsEnumerable()
                           .Min(row1 => row1[runTable.Columns[1].ColumnName]));

                    decimal Rrange = Rvalmax - Rvalmin;
                    decimal R_interval = Math.Round(Rrange, 3);
                    if (R_interval <= 0)
                    {
                        R_interval = 1;
                    }
                    var xbar = runTable.AsEnumerable()
                           .Average(x => Convert.ToDecimal(x[runTable.Columns[0].ColumnName]));
                    decimal dec_xbar = Convert.ToDecimal(xbar);

                    var r = runTable.AsEnumerable()
               .Average(x => Convert.ToDecimal(x[runTable.Columns[1].ColumnName]));
                    //decimal Rbar = Math.Round(Convert.ToDecimal(r), 3);
                    decimal Rbar = Convert.ToDecimal(r);

                    //decimal XbarUCL = Math.Round((dec_xbar + (Convert.ToDecimal(0.577) * Rbar)), 3);
                    //decimal XbarLCL = Math.Round((dec_xbar - (Convert.ToDecimal(0.577) * Rbar)), 3);

                    //decimal RbarUCL = Math.Round((Convert.ToDecimal(2.114) * Rbar), 3);
                    //decimal RbarLCL = Math.Round((Convert.ToDecimal(0) * Rbar), 3);

                    SqlDataAdapter daspc = new SqlDataAdapter("select * from SPCValues where SampleSize='" + Size + "' ", strConnString);
                    DataSet dsspc = new DataSet();
                    daspc.Fill(dsspc);
                    if (dsspc.Tables[0].Rows.Count > 0)
                    {
                        XbarUCL = Math.Round((dec_xbar + (Convert.ToDecimal(dsspc.Tables[0].Rows[0]["A2"].ToString()) * Rbar)), 3);
                        XbarLCL = Math.Round((dec_xbar - (Convert.ToDecimal(dsspc.Tables[0].Rows[0]["A2"].ToString()) * Rbar)), 3);

                        RbarLCL = Math.Round((Convert.ToDecimal(dsspc.Tables[0].Rows[0]["D3"].ToString()) * Rbar), 4);
                        RbarUCL = Math.Round((Convert.ToDecimal(dsspc.Tables[0].Rows[0]["D4"].ToString()) * Rbar), 4);
                    }


                    if (usl1[1].ToString() != "-" && usl1[1].ToString() != "")
                    {
                        roundusl = Decimal.Parse(Regex.Match(usl1[1].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                    }
                    else
                    {
                        if (lsl1[1].ToString() != "" && lsl1[1].ToString() != "-" && (Mean.ToString() == "-" || Mean.ToString() == ""))
                        {
                            roundusl = Convert.ToDecimal(lsl1[1].ToString()) * 3;
                        }
                        else
                        {
                            roundusl = 0;
                        }
                    }
                    if (lsl1[1].ToString() != "-" && lsl1[1].ToString() != "")
                    {
                        roundlsl = Decimal.Parse(Regex.Match(lsl1[1].ToString(), "-?[0-9]*\\.*[0-9]*").Value);
                    }
                    else
                    {
                        roundlsl = 0;
                    }
                    if (Mean.ToString() != "-" && Mean.ToString() != "")
                    {
                        roundmean = Decimal.Parse(Regex.Match(Mean, "-?[0-9]*\\.*[0-9]*").Value);
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

                    decimal tolerance = Convert.ToDecimal(roundusl) - Convert.ToDecimal(roundlsl);

                    if (dec_Sqrt != 0)
                    {
                        if (usl1[1].ToString() != "-" && usl1[1].ToString() != "" && lsl1[1].ToString() != "-" && lsl1[1].ToString() != "")
                        {
                            if (Convert.ToDecimal(Decimal.Parse(Regex.Match(usl1[1].ToString(), "-?[0-9]*\\.*[0-9]*").Value)) > 0 && Convert.ToDecimal(Decimal.Parse(Regex.Match(lsl1[1].ToString(), "-?[0-9]*\\.*[0-9]*").Value)) > 0)
                            {
                                decimal pp_dec = Math.Round(tolerance / (6 * dec_Sqrt), 3);
                                pp = pp_dec.ToString();
                                decimal ppmax = (roundusl - dec_xbar) / (3 * dec_Sqrt);
                                decimal ppmin = (dec_xbar - roundlsl) / (3 * dec_Sqrt);
                                ppk = Math.Round(Math.Min(ppmax, ppmin), 3);
                            }
                            else
                            {
                                pp = "";
                                ppk = Math.Round((roundusl - dec_xbar) / (3 * dec_Sqrt), 3);
                            }
                        }
                        else
                        {
                            pp = "";
                            ppk = Math.Round((roundusl - dec_xbar) / (3 * dec_Sqrt), 3);
                        }

                        //pp = Math.Round(tolerance / (6 * dec_Sqrt), 3);

                        //if (dimensionvalues.Contains("±"))
                        //{
                        //    decimal ppmax = (roundusl - dec_xbar) / (3 * dec_Sqrt);
                        //    decimal ppmin = (dec_xbar - roundlsl) / (3 * dec_Sqrt);
                        //    ppk = Math.Round(Math.Min(ppmax, ppmin), 3);
                        //}
                        //else
                        //{
                        //    ppk = Math.Round((roundusl - dec_xbar) / (3 * dec_Sqrt), 3);
                        //}

                        //if (pp == 0) { pp = 0.00m; }

                        if (pp == "0") { pp = "0"; }
                        if (ppk == 0) { ppk = 0.00m; }
                    }
                    else
                    {
                        pp = "0";//pp = 0.00m;
                        ppk = 0.00m;
                    }

                    decimal Redmax;
                    if (valmax > roundusl)
                    { Redmax = Math.Round((Convert.ToDecimal(valmax) + Convert.ToDecimal(0.00)), 3); }
                    else
                    { Redmax = Math.Round((Convert.ToDecimal(roundusl) + Convert.ToDecimal(0.00)), 3); }

                    decimal Redmin;
                    if (roundlsl > 0)
                    {
                        if (valmin < roundlsl)
                        {
                            Redmin = Math.Round((Convert.ToDecimal(valmin) - Convert.ToDecimal(0.00)), 3);
                        }
                        else
                        { Redmin = Math.Round((Convert.ToDecimal(roundlsl) - Convert.ToDecimal(0.00)), 3); }

                        if (Redmin < 0)
                        {
                            Redmin = Math.Round((Convert.ToDecimal(0)), 3);
                        }
                    }
                    else
                    { Redmin = Math.Round((Convert.ToDecimal(roundlsl)), 3); }

                    //decimal Redmax;
                    //Redmax = Math.Round((Convert.ToDecimal(roundusl) + Convert.ToDecimal(0.004)), 3);
                    //decimal Redmin;
                    //if (roundlsl > 0)
                    //{
                    //    Redmin = Math.Round((Convert.ToDecimal(roundlsl) - Convert.ToDecimal(0.004)), 3);
                    //}
                    //else
                    //{ Redmin = Math.Round((Convert.ToDecimal(roundlsl)), 3); }

                    //decimal Ymax = Math.Round((Convert.ToDecimal(roundusl) - Convert.ToDecimal(0.001)), 3);
                    //decimal Ymin = Math.Round((Convert.ToDecimal(roundlsl) - Convert.ToDecimal(0.001)), 3);

                    decimal RCmax = Math.Round((Convert.ToDecimal(Rvalmax) + Convert.ToDecimal(0.00)), 4);
                    decimal RCmin = Math.Round((Convert.ToDecimal(Rvalmin) - Convert.ToDecimal(0.00)), 4);
                    if (RCmin < 0)
                    {
                        RCmin = Math.Round((Convert.ToDecimal(0)), 3);
                    }
                    decimal Pmean = Math.Round(dec_xbar, 3);

                    objds.Tables[0].Columns.Add("RedMax", typeof(string), Redmax.ToString());
                    objds.Tables[0].Columns.Add("RedMin", typeof(string), Redmin.ToString());
                    objds.Tables[0].Columns.Add("Mean", typeof(string), Mean.ToString());
                    objds.Tables[0].Columns.Add("USL", typeof(string), roundusl.ToString());
                    objds.Tables[0].Columns.Add("LSL", typeof(string), roundlsl.ToString());
                    //objds.Tables[0].Columns.Add("YMax", typeof(string), Ymax.ToString());
                    //objds.Tables[0].Columns.Add("YMin", typeof(string), Ymin.ToString());
                    objds.Tables[0].Columns.Add("UCL", typeof(string), XbarUCL.ToString());
                    objds.Tables[0].Columns.Add("LCL", typeof(string), XbarLCL.ToString());
                    objds.Tables[0].Columns.Add("ProcessMean", typeof(string), Pmean.ToString());

                    // ********** R Chart ************
                    objds.Tables[0].Columns.Add("RCMax", typeof(string), RCmax.ToString());
                    objds.Tables[0].Columns.Add("RCMin", typeof(string), RCmin.ToString());
                    //objds.Tables[0].Columns.Add("RCMax", typeof(string), RbarUCL.ToString());
                    //objds.Tables[0].Columns.Add("RCMin", typeof(string), RbarLCL.ToString());
                    objds.Tables[0].Columns.Add("RCMean", typeof(string), Rbar.ToString());
                    objds.Tables[0].Columns.Add("RCucl", typeof(string), RbarUCL.ToString());
                    objds.Tables[0].Columns.Add("RClcl", typeof(string), RbarLCL.ToString());

                    //********* pp and ppk **********
                    objds.Tables[0].Columns.Add("pp", typeof(string), pp.ToString());
                    objds.Tables[0].Columns.Add("ppk", typeof(string), ppk.ToString());

                    //********* INTERVAL **********
                    objds.Tables[0].Columns.Add("SPCInterval", typeof(string), x_interval.ToString());
                    objds.Tables[0].Columns.Add("RInterval", typeof(string), R_interval.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            objds = null;

            //string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);

            //foreach (string filePath in Directory.GetFiles(tempPath, "*.*", SearchOption.AllDirectories))
            //{
            //    try
            //    {
            //        FileInfo currentFile = new FileInfo(filePath);
            //        currentFile.Delete();
            //    }
            //    catch (Exception ex1)
            //    {
            //        //Debug.WriteLine("Error on file: {0}\r\n   {1}", filePath, ex.Message);
            //    }
            //}
        }
        return objds;
    }
    public DataSet ViewOEEReport(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet dss = new DataSet();
            dss.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewdepartmentOEE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@depart", db.Department);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dss);
            return dss;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet ViewMachineReport(DBServer db)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewMachinereport", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@machinename", db.Machinename);
            //cmd.Parameters.AddWithValue("@fromdate", db.fromdate);
            //cmd.Parameters.AddWithValue("@todate", db.todate);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet ViewMachinename(string shift)
    {

        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
            SqlCommand cmd = new SqlCommand("ViewMachinename", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@shift", shift);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
 
