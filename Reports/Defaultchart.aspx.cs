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
using System.Globalization;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Web.SessionState;

public partial class Defaultchart : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public DBServer objserver = new DBServer();
    public DataSet ds;
    public static Object thisLock = new Object();
    public SqlDataAdapter da;

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_fromdate_chart.Value = DateTime.Now.ToShortDateString().ToString();
            txt_todate_chart.Value = DateTime.Now.ToShortDateString().ToString();
            loaddropdown();
        }
    }
    public void loaddropdown()
    {
        drp_yr.Items.Add("-Select-");
        for (int a = 2013; a <= 2030; a++)
        {
            drp_yr.Items.Add(a.ToString());
        }
    }
    public void GenerateChart(string indicator, string shift, DateTime fromdate, DateTime todate,string unit,string mchn, Series series, int numOfPoints)
    {
        lock (thisLock)
        {

            try
            {

                Random rand;
                rand = new Random(20);
                DBServer db = new DBServer();
                DataSet dss = new DataSet();
                dss = db.TRG_chart(shift, unit, mchn, fromdate, todate);


                if (dss.Tables[0].Rows.Count > 0)
                {
                    Chart1.DataSource = dss.Tables[0];

                    int row = 0;
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        string[] x = new string[dss.Tables[0].Rows.Count];
                        string[] y = new string[dss.Tables[0].Rows.Count];
                        for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                        {

                            //row += 1;
                            //x[i] = Convert.ToString(row);
                            //x[i] = Convert.ToString(dss.Tables[0].Rows[i]["DowntimeType"]);
                            //decimal trg_chart=0;
                            //trg_chart = Convert.ToDecimal(dss.Tables[0].Rows[i]["TRG"]);
                            //y[i] = trg_chart / 100;
                            //Chart1.Series[0].Points.AddY(y[i]);
                            //Chart1.Series["Default"].Points.DataBindXY(x, y);
                            x[i] = Convert.ToString(dss.Tables[0].Rows[i]["DowntimeType"]);

                            y[i] = Convert.ToString(dss.Tables[0].Rows[i]["TRG"]);
                            Chart1.Series[0].Points.AddY(Convert.ToString(dss.Tables[0].Rows[i]["TRG"]));

                        }

                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('No Record found !');", true);

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
        
    }

    public void AfterLoad()
    {

        // Number of data points

        int numOfPoints = 20;
        string shift = ddl_shiftchart.Value.ToString();
        string indicator = ddl_indicator.Text.ToString();
        string unit = ddl_unit_eff.Text.ToString();
        string machn = Slct_machine_eff.Value.ToString();
        DateTime fromdate = Convert.ToDateTime(txt_fromdate_chart.Value.ToString());
        DateTime todate = Convert.ToDateTime(txt_todate_chart.Value.ToString());

        // Generate rundom data

        GenerateChart(indicator, shift, fromdate, todate,unit,machn, Chart1.Series["Default"], numOfPoints);

        // Make Pareto Chart
       
            MakeParetoChart(Chart1, "Default", "Paretochart");

            // Set chart types for output data

            Chart1.Series["Paretochart"].ChartType = SeriesChartType.Line;

            // set the markers for each point of the Pareto Line

            Chart1.Series["Paretochart"].IsValueShownAsLabel = true;

            Chart1.Series["Paretochart"].MarkerColor = System.Drawing.Color.Red;

            Chart1.Series["Paretochart"].MarkerBorderColor = System.Drawing.Color.Black;

            Chart1.Series["Paretochart"].MarkerStyle = MarkerStyle.Circle;

            Chart1.Series["Paretochart"].MarkerSize = 10;

            Chart1.Series["Paretochart"].LabelFormat = "0.#";  // format with one decimal and leading zero

            // Set Color of line Pareto chart

            Chart1.Series["Paretochart"].Color = System.Drawing.Color.FromArgb(252, 180, 65);
            System.Web.UI.DataVisualization.Charting.Series series = new System.Web.UI.DataVisualization.Charting.Series();

            //for (int i = 0; i < dowtime.Length; i++)
            //{
            //   series.Points.AddXY(dowtime[i].ToString(), 0);
            //}
            //Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 100;
            //Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 10;
            //Chart1.ChartAreas["ChartArea1"].AxisY.Interval = 10;

        
       

    }
    void MakeParetoChart(Chart chart, string srcSeriesName, string destSeriesName)
    {

        // get name of the ChartAre of the source series

        string strChartArea = chart.Series[srcSeriesName].ChartArea;

        // ensure that the source series is a column chart type

        chart.Series[srcSeriesName].ChartType = SeriesChartType.Column;

        // sort the data in all series by their values in descending order

        //chart.DataManipulator.Sort(PointSortOrder.Descending, srcSeriesName);

        // find the total of all points in the source series

        double total = 0.0;

        foreach (DataPoint pt in chart.Series[srcSeriesName].Points)
            total += pt.YValues[0];
        

        // set the max value on the primary axis to total


        chart.ChartAreas[strChartArea].AxisY.Maximum = total;
        //***
        //chart.ChartAreas["ChartArea1"].AxisY.Title = "TRG";
        //chart.ChartAreas["ChartArea1"].AxisY.TitleFont.Bold.ToString();
        //chart.ChartAreas["ChartArea1"].AxisX.Title = "DOWNTIME TYPE";
        //chart.ChartAreas["ChartArea1"].AxisY.TitleFont.Bold.ToString();
       

        // create the destination series and add it to the chart

        Series destSeries = new Series(destSeriesName);

        chart.Series.Add(destSeries);

        // ensure that the destination series is either a Line or Spline chart type

        destSeries.ChartType = SeriesChartType.Line;

        destSeries.BorderWidth = 3;

        // assign the series to the same chart area as the column chart is assigned

        destSeries.ChartArea = chart.Series[srcSeriesName].ChartArea;

        // assign this series to use the secondary axis and set it maximum to be 100%

        destSeries.YAxisType = AxisType.Secondary;

        chart.ChartAreas[strChartArea].AxisY2.Maximum = 100;

        // locale specific percentage format with no decimals

        chart.ChartAreas[strChartArea].AxisY2.LabelStyle.Format = "{0:0}%";
       
        // turn off the end point values of the primary X axis

        chart.ChartAreas[strChartArea].AxisX.LabelStyle.IsEndLabelVisible = false;

        double percentage = 0.0;

        foreach (DataPoint pt in chart.Series[srcSeriesName].Points)
        {

            percentage = (pt.YValues[0] / total *100);
            //percentage = (pt.YValues[0]);

            destSeries.Points.Add(Math.Round(percentage, 2));

        }



    }
    public void GenerateChart1(string indicator, string shift, string unit, string mchn, DateTime fromdate, DateTime todate, Series series, int numOfPoints)
    {
        Random rand;
        rand = new Random(20);
        DBServer db = new DBServer();
        DataSet dss = new DataSet();
        dss = db.TRs_chart(shift, unit, mchn, fromdate, todate);
        lock (thisLock)
        {

            try
            {

                if (dss.Tables[0].Rows.Count > 0)
                {

                    //Chart2.DataSource = dss.Tables[0];
                    Chart2.DataSource = dss.Tables[0];

                    int row = 0;
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        string[] x = new string[dss.Tables[0].Rows.Count];
                        string[] y = new string[dss.Tables[0].Rows.Count];
                        for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                        {

                            //row += 1;
                            //x[i] = Convert.ToString(row);
                            x[i] = Convert.ToString(dss.Tables[0].Rows[i]["DowntimeType"]);

                            y[i] = Convert.ToString(dss.Tables[0].Rows[i]["TRS"]);
                            Chart2.Series[0].Points.AddY(Convert.ToString(dss.Tables[0].Rows[i]["TRS"]));
                            //Chart1.Series["Default"].Points.DataBindXY(x, y);
                        }
                    }

                }

                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('No Record found !');", true);

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


    public void AfterLoad1()
    {

        // Number of data points

        int numOfPoints = 20;
        string shift = ddl_shiftchart.Value.ToString();
        string indicator = ddl_indicator.Text.ToString();
        string unit = ddl_unit_eff.Text.ToString();
        string machn = Slct_machine_eff.Value.ToString();
        DateTime fromdate = Convert.ToDateTime(txt_fromdate_chart.Value.ToString());
        DateTime todate = Convert.ToDateTime(txt_todate_chart.Value.ToString());

        // Generate rundom data

        GenerateChart1(indicator, shift, unit, machn, fromdate, todate, Chart2.Series["Default1"], numOfPoints);

        // Make Pareto Chart

        MakeParetoChart1(Chart2, "Default1", "Paretochart");

        // Set chart types for output data

        Chart2.Series["Paretochart"].ChartType = SeriesChartType.Line;



        // set the markers for each point of the Pareto Line

        Chart2.Series["Paretochart"].IsValueShownAsLabel = true;

        Chart2.Series["Paretochart"].MarkerColor = System.Drawing.Color.Red;

        Chart2.Series["Paretochart"].MarkerBorderColor = System.Drawing.Color.Black;

        Chart2.Series["Paretochart"].MarkerStyle = MarkerStyle.Circle;

        Chart2.Series["Paretochart"].MarkerSize = 10;

        Chart2.Series["Paretochart"].LabelFormat = "0.#";  // format with one decimal and leading zero

        // Set Color of line Pareto chart

        Chart2.Series["Paretochart"].Color = System.Drawing.Color.FromArgb(252, 180, 65);
        System.Web.UI.DataVisualization.Charting.Series series = new System.Web.UI.DataVisualization.Charting.Series();

        //for (int i = 0; i < dowtime.Length; i++)
        //{
        //   series.Points.AddXY(dowtime[i].ToString(), 0);
        //}
        //Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 100;
        //Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 10;
        //Chart1.ChartAreas["ChartArea1"].AxisY.Interval = 10;


    }
    void MakeParetoChart1(Chart chart, string srcSeriesName, string destSeriesName)
    {

        // get name of the ChartAre of the source series

        string strChartArea = chart.Series[srcSeriesName].ChartArea;

        // ensure that the source series is a column chart type

        chart.Series[srcSeriesName].ChartType = SeriesChartType.Column;

        // sort the data in all series by their values in descending order

        ////chart.DataManipulator.Sort(PointSortOrder.Descending, srcSeriesName);

        // find the total of all points in the source series

        double total = 0.0;

        foreach (DataPoint pt in chart.Series[srcSeriesName].Points)

            total += pt.YValues[0];

        // set the max value on the primary axis to total

        chart.ChartAreas[strChartArea].AxisY.Maximum = total;
        //***
        //chart.ChartAreas["ChartArea1"].AxisY.Title = "TRS";
        //chart.ChartAreas["ChartArea1"].AxisY.TitleFont.Bold.ToString();
        //chart.ChartAreas["ChartArea1"].AxisX.Title = "DOWNTIME TYPE";
        //chart.ChartAreas["ChartArea1"].AxisY.TitleFont.Bold.ToString();
       

        // create the destination series and add it to the chart

        Series destSeries = new Series(destSeriesName);

        chart.Series.Add(destSeries);

        // ensure that the destination series is either a Line or Spline chart type

        destSeries.ChartType = SeriesChartType.Line;

        destSeries.BorderWidth = 3;

        // assign the series to the same chart area as the column chart is assigned

        destSeries.ChartArea = chart.Series[srcSeriesName].ChartArea;

        // assign this series to use the secondary axis and set it maximum to be 100%

        destSeries.YAxisType = AxisType.Secondary;

        chart.ChartAreas[strChartArea].AxisY2.Maximum =100;

        // locale specific percentage format with no decimals

        chart.ChartAreas[strChartArea].AxisY2.LabelStyle.Format = "{0}%";


        // turn off the end point values of the primary X axis

        chart.ChartAreas[strChartArea].AxisX.LabelStyle.IsEndLabelVisible = false;

        double percentage = 0.0;

        foreach (DataPoint pt in chart.Series[srcSeriesName].Points)
        {
           // percentage = (pt.YValues[0]);
            percentage = (pt.YValues[0] / total*100);

            destSeries.Points.Add(Math.Round(percentage, 2));

        }
        

    }
    public void GenerateChart2(string indicator, string shift, string fromdate, string todate, string unit, string mchn, Series series, int numOfPoints)
    {
        lock (thisLock)
        {
            try
            {

                Random rand;
                rand = new Random(20);
                DBServer db = new DBServer();
                DataSet dss = new DataSet();
                dss = db.labor_chart(shift, fromdate, todate, unit, mchn, db);



                if (dss.Tables[0].Rows.Count > 0)
                {

                    Chart3.DataSource = dss.Tables[0];

                    int row = 0;
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        string[] x = new string[dss.Tables[0].Rows.Count];
                        string[] y = new string[dss.Tables[0].Rows.Count];
                        for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                        {

                            row += 1;
                            x[i] = Convert.ToString(row);
                            y[i] = Convert.ToString(dss.Tables[0].Rows[i]["total_time"]);
                            Chart3.Series[0].Points.AddY(Convert.ToString(dss.Tables[0].Rows[i]["total_time"]));
                            //Chart1.Series["Default"].Points.DataBindXY(x, y);
                        }

                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('No Record found !');", true);

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }


    public void AfterLoad2()
    {

        // Number of data points

        int numOfPoints = 20;
        string shift = ddl_shiftchart.Value.ToString();
        string indicator = ddl_indicator.Text.ToString();
        string fromdate = txt_fromdate_chart.Value.ToString();
        string todate = txt_todate_chart.Value.ToString();
        string unit = ddl_unit_eff.Text.ToString();
        string machn = Slct_machine_eff.Value.ToString();

        // Generate rundom data

        GenerateChart2(indicator, shift, fromdate, todate, unit, machn, Chart3.Series["Default3"], numOfPoints);

        // Make Pareto Chart

        MakeParetoChart2(Chart3, "Default3", "Paretochart");

        // Set chart types for output data

        Chart3.Series["Paretochart"].ChartType = SeriesChartType.Line;

        // set the markers for each point of the Pareto Line

        Chart3.Series["Paretochart"].IsValueShownAsLabel = true;

        Chart3.Series["Paretochart"].MarkerColor = System.Drawing.Color.Red;

        Chart3.Series["Paretochart"].MarkerBorderColor = System.Drawing.Color.Black;

        Chart3.Series["Paretochart"].MarkerStyle = MarkerStyle.Circle;

        Chart3.Series["Paretochart"].MarkerSize = 10;

        Chart3.Series["Paretochart"].LabelFormat = "0.#";  // format with one decimal and leading zero

        // Set Color of line Pareto chart

        Chart3.Series["Paretochart"].Color = System.Drawing.Color.FromArgb(252, 180, 65);
        System.Web.UI.DataVisualization.Charting.Series series = new System.Web.UI.DataVisualization.Charting.Series();

        //for (int i = 0; i < dowtime.Length; i++)
        //{
        //   series.Points.AddXY(dowtime[i].ToString(), 0);
        //}
        //Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 100;
        //Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 10;
        //Chart1.ChartAreas["ChartArea1"].AxisY.Interval = 10;


    }
    void MakeParetoChart2(Chart chart, string srcSeriesName, string destSeriesName)
    {

        // get name of the ChartAre of the source series

        string strChartArea = chart.Series[srcSeriesName].ChartArea;

        // ensure that the source series is a column chart type

        chart.Series[srcSeriesName].ChartType = SeriesChartType.Column;

        // sort the data in all series by their values in descending order

        chart.DataManipulator.Sort(PointSortOrder.Descending, srcSeriesName);

        // find the total of all points in the source series

        double total = 0.0;

        foreach (DataPoint pt in chart.Series[srcSeriesName].Points)

            total += pt.YValues[0];

        // set the max value on the primary axis to total

        chart.ChartAreas[strChartArea].AxisY.Maximum = total;

        // create the destination series and add it to the chart

        Series destSeries = new Series(destSeriesName);

        chart.Series.Add(destSeries);

        // ensure that the destination series is either a Line or Spline chart type

        destSeries.ChartType = SeriesChartType.Line;

        destSeries.BorderWidth = 3;

        // assign the series to the same chart area as the column chart is assigned

        destSeries.ChartArea = chart.Series[srcSeriesName].ChartArea;

        // assign this series to use the secondary axis and set it maximum to be 100%

        //destSeries.YAxisType = AxisType.Secondary;

        //chart.ChartAreas[strChartArea].AxisY.Maximum = 100;

        // locale specific percentage format with no decimals

        chart.ChartAreas[strChartArea].AxisY.LabelStyle.Format = "{0:0}%";


        // turn off the end point values of the primary X axis

        chart.ChartAreas[strChartArea].AxisX.LabelStyle.IsEndLabelVisible = true;

        //double percentage = 0.0;

        //foreach (DataPoint pt in chart.Series[srcSeriesName].Points)
        //{

        //    percentage += (pt.YValues[0] / total * 100.0);

        //    destSeries.Points.Add(Math.Round(percentage, 2));

        //}
        double percentage = 58;

        foreach (DataPoint pt in chart.Series[srcSeriesName].Points)
        {

            destSeries.Points.Add(percentage);

        }


    }

    public void GenerateChart3(string year, string indicator, string shift, string fromdate, string todate,string unit, string mchn, Series series, int numOfPoints)
    {
        Random rand;
        rand = new Random(20);
        DBServer db = new DBServer();
        DataSet dss = new DataSet();
        dss = db.labor_chart_year(year, shift, fromdate, todate,unit, mchn, db);
        lock (thisLock)
        {

            try
            {

                if (dss.Tables[0].Rows.Count > 0)
                {

                    Chart4.DataSource = dss.Tables[0];

                    int row = 0;
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        string[] x = new string[dss.Tables[0].Rows.Count];
                        string[] y = new string[dss.Tables[0].Rows.Count];
                        for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                        {

                            row += 1;
                            x[i] = Convert.ToString(row);
                            y[i] = Convert.ToString(dss.Tables[0].Rows[i]["ttl"]);
                            Chart4.Series[0].Points.AddY(Convert.ToString(dss.Tables[0].Rows[i]["ttl"]));
                            // Chart4.Series["Default4"].Points.DataBindXY(x, y);
                        }

                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('No Record found !');", true);

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }


    public void AfterLoad3()
    {

        // Number of data points

        int numOfPoints = 20;
        string shift = ddl_shiftchart.Value.ToString();
        string indicator = ddl_indicator.Text.ToString();
        string fromdate = txt_fromdate_chart.Value.ToString();
        string todate = txt_todate_chart.Value.ToString();
        string year = drp_yr.Text.ToString();
        string unit = ddl_unit_eff.Text.ToString();
        string machn = Slct_machine_eff.Value.ToString();

        // Generate rundom data

        GenerateChart3(year,indicator, shift, fromdate, todate, unit, machn, Chart4.Series["Default4"], numOfPoints);

        // Make Pareto Chart

        MakeParetoChart3(Chart4, "Default4", "Paretochart");

        // Set chart types for output data

        Chart4.Series["Paretochart"].ChartType = SeriesChartType.Line;

        // set the markers for each point of the Pareto Line

        Chart4.Series["Paretochart"].IsValueShownAsLabel = true;

        Chart4.Series["Paretochart"].MarkerColor = System.Drawing.Color.Red;

        Chart4.Series["Paretochart"].MarkerBorderColor = System.Drawing.Color.Black;

        Chart4.Series["Paretochart"].MarkerStyle = MarkerStyle.Circle;

        Chart4.Series["Paretochart"].MarkerSize = 10;

        Chart4.Series["Paretochart"].LabelFormat = "0.#";  // format with one decimal and leading zero

        // Set Color of line Pareto chart

        Chart4.Series["Paretochart"].Color = System.Drawing.Color.FromArgb(252, 180, 65);
        System.Web.UI.DataVisualization.Charting.Series series = new System.Web.UI.DataVisualization.Charting.Series();

        //for (int i = 0; i < dowtime.Length; i++)
        //{
        //   series.Points.AddXY(dowtime[i].ToString(), 0);
        //}
        //Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 100;
        //Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 10;
        //Chart1.ChartAreas["ChartArea1"].AxisY.Interval = 10;


    }
    void MakeParetoChart3(Chart chart, string srcSeriesName, string destSeriesName)
    {

        // get name of the ChartAre of the source series

        string strChartArea = chart.Series[srcSeriesName].ChartArea;

        // ensure that the source series is a column chart type

        chart.Series[srcSeriesName].ChartType = SeriesChartType.Column;

        // sort the data in all series by their values in descending order

        chart.DataManipulator.Sort(PointSortOrder.Descending, srcSeriesName);

        // find the total of all points in the source series

        double total = 0.0;

        foreach (DataPoint pt in chart.Series[srcSeriesName].Points)

            total += pt.YValues[0];

        // set the max value on the primary axis to total

        chart.ChartAreas[strChartArea].AxisY.Maximum = total;

        // create the destination series and add it to the chart

        Series destSeries = new Series(destSeriesName);

        chart.Series.Add(destSeries);

        // ensure that the destination series is either a Line or Spline chart type

        destSeries.ChartType = SeriesChartType.Line;

        destSeries.BorderWidth = 3;

        // assign the series to the same chart area as the column chart is assigned

        destSeries.ChartArea = chart.Series[srcSeriesName].ChartArea;

        // assign this series to use the secondary axis and set it maximum to be 100%

        //destSeries.YAxisType = AxisType.Secondary;

        //chart.ChartAreas[strChartArea].AxisY.Maximum = 100;

        // locale specific percentage format with no decimals

        chart.ChartAreas[strChartArea].AxisY.LabelStyle.Format = "{0:0}%";


        // turn off the end point values of the primary X axis

        chart.ChartAreas[strChartArea].AxisX.LabelStyle.IsEndLabelVisible = true;
        double percentage = 58;

        foreach (DataPoint pt in chart.Series[srcSeriesName].Points)
        {

            destSeries.Points.Add(percentage);

        }
      

    }


    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {
        string shift;
        string indicator;
        string year;
        string unit_Eff;
        string machn;

        Series series = Chart1.Series["Default"];
        Series series1 = Chart2.Series["Default1"];
        Series series3 = Chart3.Series["Default3"];
        Series series4 = Chart4.Series["Default4"];
        shift = ddl_shiftchart.Value.ToString();
        indicator = ddl_indicator.Text.ToString();
        year = drp_yr.Text.ToString();
        unit_Eff = ddl_unit_eff.Text.ToString();
        machn = Slct_machine_eff.Value.ToString();
        DateTime frm = Convert.ToDateTime(txt_fromdate_chart.Value.ToString());
        string from = frm.ToString("MM/dd/yyyy");
        DateTime to = Convert.ToDateTime(txt_todate_chart.Value.ToString());
        string tp = to.ToString("MM/dd/yyyy");
        //DateTime from = txt_fromdate_chart.Value.ToString();
        //DateTime fromdate = from.ToShortDateString("MM/dd/yyyy");
        //string to = txt_todate_chart.Value.ToString();
        //string todate = to.ToString("MM-dd-yyyy");
        //GenerateChart(shift, from, tp, series,numOfPoints);
        if (indicator == "OPE")
        {
            AfterLoad();
            div_TRS.Visible = false;
            div_trg.Visible = true;
            div_labor.Visible = false;
        }
        else if(indicator == "OEE")
        {
            AfterLoad1();
            div_trg.Visible = false;
            div_TRS.Visible = true;
            div_labor.Visible = false;
            div1_year.Visible = false;

        }
        else if (indicator == "LaborEfficiency/year")
        {
                AfterLoad3();
                div_trg.Visible = false;
                div_TRS.Visible = false;
                div_labor.Visible = false;
                div1_year.Visible = true;
            }
        else if (indicator == "LaborEfficiency/DateWise")
            {
                AfterLoad2();
                div_trg.Visible = false;
                div_TRS.Visible = false;
                div_labor.Visible = true;
                div1_year.Visible = false;

                
            }

           
        
    }

   
    protected void OnSelectedIndexChanged_dll_indicator(object sender, EventArgs e)
    {
         string indicator = ddl_indicator.Text.ToString();
         if (indicator == "OPE")
         {
             div_trg.Visible = true;
             drp_yr.Enabled = false;
             txt_fromdate_chart.Disabled = false;
             txt_todate_chart.Disabled = false;
             drp_yr.SelectedItem.Value = "-Select-";
        
         }
         else if (indicator == "OEE")
         {
             div_TRS.Visible = true;
             drp_yr.Enabled = false;
             txt_fromdate_chart.Disabled = false;
             txt_todate_chart.Disabled = false;
             drp_yr.SelectedItem.Value = "-Select-";
            
         }
         else if (indicator == "LaborEfficiency/DateWise")
         {
             div_labor.Visible = true;
             drp_yr.Enabled = false;
             txt_fromdate_chart.Disabled = false;
             txt_todate_chart.Disabled = false;
             drp_yr.SelectedItem.Value= "-Select-";
        
         }
         else if (indicator == "LaborEfficiency/year")
         {
             div1_year.Visible = true;
             drp_yr.Enabled = true;
             txt_fromdate_chart.Disabled = true;
             txt_todate_chart.Disabled = true;
             drp_yr.SelectedItem.Value = "-Select-";
            
         }

    }
    protected void onselectedindexchanged_eff(object sender, EventArgs e)
    {
        string unit = ddl_unit_eff.Text.ToString();
        if (unit == "MBU")
        {
            ds = objserver.GetDateset("select '-Select-' MBU,'-Select-' MBU union select distinct MBU,MBU from Machine_rpt_tble order by 1 asc");

            Slct_machine_eff.DataSource = ds.Tables[0];

            Slct_machine_eff.DataValueField = "MBU";
            Slct_machine_eff.DataTextField = "MBU";
            Slct_machine_eff.DataBind();
        }
        else if (unit == "ABU")
        {
            ds = objserver.GetDateset("select '-Select-' ABU,'-Select-' ABU union select distinct ABU,ABU from Machine_rpt_tble order by 1 asc");

            Slct_machine_eff.DataSource = ds.Tables[0];

            Slct_machine_eff.DataValueField = "ABU";
            Slct_machine_eff.DataTextField = "ABU";
            Slct_machine_eff.DataBind();
        }
        else if (unit == "ALL")
        {
            ds = objserver.GetDateset("SELECT '-Select-' ALLRPT,'-Select-' ALLRPT union select distinct MBU,MBU  as ALLRPT FROM Machine_rpt_tble where MBU<>'' UNION ALL SELECT '-Select-' ALLRPT,'-Select-' ALLRPT  union select distinct ABU,ABU  as ALLRPT   FROM Machine_rpt_tble where ABU<>'' ");

            Slct_machine_eff.DataSource = ds.Tables[0];

            Slct_machine_eff.DataValueField = "ALLRPT";
            Slct_machine_eff.DataTextField = "ALLRPT";
            Slct_machine_eff.DataBind();
        }
    }
}

