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
using System.Text.RegularExpressions;
using System.IO;
using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.DataVisualization.Charting;

public partial class FixtureReport : System.Web.UI.Page
{
    public String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    public DBServer objserver = new DBServer();
    public DataSet ds;
    public PagedDataSource paging = new PagedDataSource();
    public SqlDataAdapter da;
    public static Object thisLock = new Object();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public int findex, lindex, count = 0;
    public string[] PartNo;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            populateyear();


        }
    }

    public void populateyear()
    {
        int _currentyear;
        const int _year = 1990;
        _currentyear = DateTime.Now.Year;
        ddl_fyear.Items.Add("--- Select Year ---");
        for (int s = 0; s <= 50; s++)
        {

            ddl_fyear.Items.Add((_currentyear - s).ToString());
        }
        ddl_fyear.DataBind();
    }

    private DataTable GetData()
    {
        string Part = "", Fix = "", Oper = "", Mach = "", Year = "", Month = "", Month1 = "";
        string Part11 = "";
        string partno = hdn_fpart.Value.ToString();
        string fixno = hdn_ffixno.Value.ToString();
        string oper = hdn_foperation.Value.ToString();
        string mach = hdn_fmachi.Value.ToString();
        string year = hdn_fyear.Value.ToString();
        string month = hdn_month.Value.ToString();
        DataTable dt = new DataTable();
        dt.Columns.Add("Partno", Type.GetType("System.String"));
        dt.Columns.Add("Feedback", Type.GetType("System.Int32"));
        dt.Columns.Add("Response", Type.GetType("System.Int32"));
        lock (thisLock)
        {
            try
            {
                if (partno == "ALL")
                {
                    string part1 = "";
                    SqlDataAdapter da = new SqlDataAdapter("select distinct PartNo from tbl_PartNo", strConnString);
                    DataSet ds = new DataSet();
                    ds.Tables.Clear();
                    ds.Clear();
                    ds.Reset();

                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            part1 += "," + "'" + ds.Tables[0].Rows[i]["PartNo"].ToString() + "'";
                            Part11 += "," + ds.Tables[0].Rows[i]["PartNo"].ToString();
                        }
                        Part = "Partno in(" + part1.Remove(0, 1).ToString() + ")";
                    }

                }
                else
                {
                    Part = "Partno in('" + partno.ToString() + "')";
                }
                Fix = "and Fixno in('" + fixno + "')";
                Oper = "and Operation in('" + oper.ToString() + "')";
                Mach = "and Machine in('" + mach.ToString() + "')";
                Year = year.ToString();
                Month = month.ToString();
                string mon = "";
                string mfrom = "", mto = "";
                mfrom = hfn_fmonth1.Value.ToString();
                mto = hdn_fmonth2.Value.ToString();
                for (int i = Convert.ToInt32(mfrom); i <= Convert.ToInt32(mto); i++)
                {
                    mon += "," + "'" + i.ToString() + "'";
                }
                Month = "and Month in(" + mon.Remove(0, 1).ToString() + ")";

                if (partno == "ALL")
                {
                    PartNo = Regex.Split(Part11, ",");

                    for (int i = 0; i < PartNo.Length; i++)
                    {
                        if (PartNo[i].ToString() == "")
                        {
                        }
                        else
                        {
                            string query = "select * from Feedback where Partno='" + PartNo[i].ToString() + "' and Operation='" + oper + "' and Fixno like '%" + fixno + "%'" + Month + " and Year='" + Year.ToString() + "' and Machine='" + mach + "';select count(FB_Date)as Feedback from Feedback where Partno='" + PartNo[i].ToString() + "' and Operation='" + oper + "' and Fixno like '%" + fixno + "%'" + Month + " and Year='" + Year.ToString() + "' and Machine='" + mach + "' and FB_Date<>'';select count(FB_Rdate)as Response from Feedback where Partno='" + PartNo[i].ToString() + "' and Operation='" + oper + "' and Fixno like '%" + fixno + "%' " + Month1 + " and Year='" + Year.ToString() + "' and Machine='" + mach + "' and FB_Rdate<>''";
                            SqlDataAdapter da1 = new SqlDataAdapter(query, strConnString);
                            DataSet ds1 = new DataSet();
                            da1.Fill(ds1);

                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = dt.NewRow();
                                dr["Partno"] = PartNo[i].ToString();
                                if (ds1.Tables[1].Rows[0]["Feedback"] != null && ds1.Tables[1].Rows[0]["Feedback"].ToString() != "0")
                                {
                                    dr["Feedback"] = Convert.ToInt32(ds1.Tables[1].Rows[0]["Feedback"].ToString());
                                }
                                else
                                {
                                    dr["Feedback"] = Convert.ToInt32("0");
                                }
                                if (ds1.Tables[2].Rows[0]["Response"] != null && ds1.Tables[2].Rows[0]["Response"].ToString() != "0")
                                {
                                    dr["Response"] = Convert.ToInt32(ds1.Tables[2].Rows[0]["Response"].ToString());
                                }
                                else
                                {
                                    dr["Response"] = Convert.ToInt32("0");
                                }
                                dt.Rows.Add(dr);

                            }

                        }
                    }

                }
                else
                {
                    string query = "select * from Feedback where Partno='" + partno.ToString() + "' and Operation='" + oper + "' and Fixno like '%" + fixno + "%'" + Month + " and Year='" + Year.ToString() + "' and Machine='" + mach + "';select count(FB_Date)as Feedback from Feedback where Partno='" + partno.ToString() + "' and Operation='" + oper + "' and Fixno like '%" + fixno + "%'" + Month + " and Year='" + Year.ToString() + "' and Machine='" + mach + "' and FB_Date<>'';select count(FB_Rdate)as Response from Feedback where Partno='" + partno.ToString() + "' and Operation='" + oper + "' and Fixno like '%" + fixno + "%' " + Month1 + " and Year='" + Year.ToString() + "' and Machine='" + mach + "' and FB_Rdate<>''";
                    SqlDataAdapter da2 = new SqlDataAdapter(query, strConnString);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);

                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["Partno"] = partno.ToString();
                        if (ds2.Tables[1].Rows[0]["Feedback"] != null && ds2.Tables[1].Rows[0]["Feedback"].ToString() != "")
                        {
                            dr["Feedback"] = Convert.ToInt32(ds2.Tables[1].Rows[0]["Feedback"].ToString());
                        }
                        else
                        {
                            dr["Feedback"] = Convert.ToInt32("0");
                        }
                        if (ds2.Tables[2].Rows[0]["Response"] != null && ds2.Tables[2].Rows[0]["Response"].ToString() != "")
                        {
                            dr["Response"] = Convert.ToInt32(ds2.Tables[2].Rows[0]["Response"].ToString());
                        }
                        else
                        {
                            dr["Response"] = Convert.ToInt32("0");
                        }
                        dt.Rows.Add(dr);

                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
            return dt;
        }
    }
    private void LoadChartData(DataTable initialDataSource)
    {
        lock (thisLock)
        {
            try
            {
                for (int i = 1; i < initialDataSource.Columns.Count; i++)
                {
                    Series series = new Series();
                    foreach (DataRow dr in initialDataSource.Rows)
                    {
                        int y = (int)dr[i];
                        series.Points.AddXY(dr["Partno"].ToString(), y);
                    }

                    chart_feedback.Series.Add(series);
                    //chart_feedback.Series[0].IsValueShownAsLabel = true;
                    chart_feedback.Series[0].BackGradientStyle = GradientStyle.TopBottom;
                }

                chart_feedback.ChartAreas["ChartArea1"].AxisY.Maximum = 100;
                chart_feedback.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
                chart_feedback.ChartAreas["ChartArea1"].AxisY.Interval = 2;
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }
    protected void btn_feedback_Click(object sender, ImageClickEventArgs e)
    {
        lock (thisLock)
        {
            try
            {
                DataTable dt = GetData();
                if (dt.Rows.Count > 0)
                {
                    LoadChartData(dt);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not Found');", true);
                }


            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }
}
