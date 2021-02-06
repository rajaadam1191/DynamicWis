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
using System.Web.UI.DataVisualization.Charting;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
public partial class DYNSheets_SPCChartView : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public SqlCommand cmd;
    public DataSet ds;
    public SqlDataAdapter da;
    public DataSet ds1;

    public string partno, operation, fromdate, todate, Type, shift, mchn, unit;
    public decimal CP;
    public decimal CPK;
    public decimal tolerance;
    public decimal points = 67;
    public decimal Standardeviation;


    public DYNSheets_SPCChartView()
    { 
   
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "")
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

                //string Partno = Request.QueryString["Partno"].ToString();
                //string Operation = Request.QueryString["Operation"].ToString();
                //string Dimenssion = Request.QueryString["Dimenssion"].ToString();
                //string From = Request.QueryString["From"].ToString();
                //string To = Request.QueryString["To"].ToString();
                //string Shift = Request.QueryString["Shift"].ToString();
                //string Mach = Request.QueryString["Mach"].ToString();
                //string Unit = Request.QueryString["Unit"].ToString();
                //string Cell = Request.QueryString["Cell"].ToString();
                //string Mean = Request.QueryString["Mean"].ToString();
                //string Dynrefid = Request.QueryString["Dynrefid"].ToString();
                //string Size = Request.QueryString["Size"].ToString();
                //string DynValueid = Request.QueryString["DynValueid"].ToString();
                //getchartvalue(Partno, Operation, Dimenssion, From, To, Shift, Mach, Unit, Cell, Mean, Dynrefid, Size, DynValueid);

                //REQUEST.FORM
                string Partno = Request.Form["Partno"].ToString();
                string Operation = Request.Form["Operation"].ToString();
                string Dimenssion = Request.Form["Dimenssion"].ToString();
                string From = Request.Form["From"].ToString();
                string To = Request.Form["To"].ToString();
                string Shift = Request.Form["Shift"].ToString();
                string Mach = Request.Form["Mach"].ToString();
                string Unit = Request.Form["Unit"].ToString();
                string Cell = Request.Form["Cell"].ToString();
                string Mean = Request.Form["Mean"].ToString();
                string Dynrefid = Request.Form["Dynrefid"].ToString();
                string Size = Request.Form["Size"].ToString();
                string DynValueid = Request.Form["DynValueid"].ToString();
                getchartvalue(Partno, Operation, Dimenssion, From, To, Shift, Mach, Unit, Cell, Mean, Dynrefid, Size, DynValueid);
            }
            else
            {
                HttpContext.Current.Response.Redirect("../Home.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
    }
    public void GenerateChart(string part, string Tablename, string fromdate, string todate, string shift, string mchn, string unit, string cell, string operation, string Dimension, string Mean, string Dynrefid, string Size, string DynValueid)
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

        DBServer db = new DBServer();
        DataSet ds = new DataSet();

        ds = db.SPCViewdimensionAllvalues(part, Tablename, fromdate, todate, shift, mchn, unit, cell, operation, Dimension, Mean, Dynrefid, Size, DynValueid);

        if (ds != null)
        {
            QC_Chart.DataSource = ds.Tables[0];
            QC_Chart.DataBind();
            QC_RChart.DataSource = ds.Tables[0];
            QC_RChart.DataBind();
            int row = 0;
            int row1 = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //this.QC_Chart.GetToolTipText += this.chart1_GetToolTipText;

                string[] x = new string[ds.Tables[0].Rows.Count];
                decimal[] y = new decimal[ds.Tables[0].Rows.Count];

                string[] x1 = new string[ds.Tables[0].Rows.Count];
                decimal[] y1 = new decimal[ds.Tables[0].Rows.Count];

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    row += 1;
                    x[i] = Convert.ToString(row);
                    y[i] = Convert.ToDecimal(ds.Tables[0].Rows[i][0]);
                    QC_Chart.Series[0].Points.AddY(Convert.ToDecimal(ds.Tables[0].Rows[i][0]));

                    //DataPoint dp = new DataPoint();
                    //dp.Label = ds.Tables[0].Rows[i][2].ToString();

                    //QC_Chart.Series[0].Points.AddY2(Convert.ToDecimal(ds.Tables[0].Rows[i][2]));

                    //QC_Chart.Series[i].ToolTip = ds.Tables[0].Rows[i][2].ToString();

                    //QC_Chart.Series["Series1"].Points[i].ToolTip = ds.Tables[0].Rows[i][2].ToString();


                    //QC_Chart.Series["Series1"].IsValueShownAsLabel = true;

                    //QC_Chart.Series["Series1"].LabelToolTip = ds.Tables[0].Rows[i][2].ToString();

                    // Set data point label
                    //QC_Chart.Series["Series1"].Points[i].Label = ds.Tables[0].Rows[i][2].ToString();

                    //*** R chart Points
                    row1 += 1;
                    x1[i] = Convert.ToString(row1);
                    y1[i] = Convert.ToDecimal(ds.Tables[0].Rows[i][1]);
                    QC_RChart.Series[0].Points.AddY(Convert.ToDecimal(ds.Tables[0].Rows[i][1]));

                }

                QC_Chart.Series["Series1"].Points.DataBindXY(x, y);

                //*** R chart Points Series
                QC_RChart.Series["Series1"].Points.DataBindXY(x1, y1);


                //***********MoveHOVER

                //QC_Chart.Series["Series1"].ToolTip = "#VALY, #VALX";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    QC_Chart.Series["Series1"].Points[i].ToolTip = "#VALY" + "," + ds.Tables[0].Rows[i][2].ToString();
                    QC_RChart.Series["Series1"].Points[i].ToolTip = "#VALY" + "," + ds.Tables[0].Rows[i][2].ToString();
                    //QC_Chart.Series["Series1"].Points[i].MapAreaAttributes = "onclick=\"window.opener.location=this.href;window.opener.focus();return false;\"";
                    //QC_Chart.Series["Series1"].Points[i].MapAreaAttributes = "onmouseover=\"'" + ds.Tables[0].Rows[i][2].ToString() + "'\"";
                }

                //foreach (DataPoint d in QC_Chart.Series[0].Points)
                //{
                //    d.Label = "somevalue";
                //}

                QC_Chart.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                QC_Chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                QC_Chart.Series["Series3"].YValueMembers = ds.Tables[0].Columns[6].ColumnName;
                QC_Chart.Series["Series4"].YValueMembers = ds.Tables[0].Columns[7].ColumnName;
                QC_Chart.Series["Series5"].YValueMembers = ds.Tables[0].Columns[5].ColumnName;
                QC_Chart.Series["Series6"].YValueMembers = ds.Tables[0].Columns[8].ColumnName;
                QC_Chart.Series["Series7"].YValueMembers = ds.Tables[0].Columns[9].ColumnName;
                //QC_Chart.Series["Series8"].YValueMembers = ds.Tables[0].Columns[6].ColumnName;
                //QC_Chart.Series["Series9"].YValueMembers = ds.Tables[0].Columns[7].ColumnName;
                QC_Chart.Series["Series10"].YValueMembers = ds.Tables[0].Columns[10].ColumnName;

                sp_usl.InnerText = ds.Tables[0].Rows[0][6].ToString();
                sp_lsl.InnerText = ds.Tables[0].Rows[0][7].ToString();
                QC_Chart.Series["Series1"].EmptyPointStyle.Color = System.Drawing.Color.Black;
                QC_Chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                QC_Chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                //if (ds.Tables[0].Rows[0][3].ToString() == "" || ds.Tables[0].Rows[0][2] == null)
                //{
                //    sp_CP.InnerText = "0.00";
                //}
                //else
                //{
                //    sp_CP.InnerText = ds.Tables[0].Rows[0][3].ToString();
                //}
                //if (ds.Tables[0].Rows[0][3].ToString() == "" || ds.Tables[0].Rows[0][3] == null)
                //{
                //    sp_CPK.InnerText = "0.00";
                //}
                //else
                //{
                //    sp_CPK.InnerText = ds.Tables[0].Rows[0][3].ToString();
                //}
                sp_CP.InnerText = ds.Tables[0].Rows[0][16].ToString();
                sp_CPK.InnerText = ds.Tables[0].Rows[0][17].ToString();
                QC_Chart.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString());
                QC_Chart.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(ds.Tables[0].Rows[0][4].ToString());

                //QC_Chart.ChartAreas["ChartArea1"].AxisY.Interval = Convert.ToDouble(ds.Tables[0].Rows[0][18].ToString()); 

                QC_Chart.ChartAreas["ChartArea1"].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

                //************SPC Values*************
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SPCvaluesFunc(" + ds.Tables[0].Rows[0][6].ToString() + "," + ds.Tables[0].Rows[0][7].ToString() + "," + ds.Tables[0].Rows[0][5].ToString() + "," + ds.Tables[0].Rows[0][8].ToString() + "," + ds.Tables[0].Rows[0][9].ToString() + "," + ds.Tables[0].Rows[0][10].ToString() + ")", true);


                // ********* R Chart ****************

                //string[] x1 = new string[ds.Tables[0].Rows.Count];
                //decimal[] y1 = new decimal[ds.Tables[0].Rows.Count];
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    row1 += 1;
                //    x1[i] = Convert.ToString(row1);
                //    y1[i] = Convert.ToDecimal(ds.Tables[0].Rows[i][1]);
                //    QC_RChart.Series[0].Points.AddY(Convert.ToDecimal(ds.Tables[0].Rows[i][1]));
                //}

                //QC_RChart.Series["Series1"].Points.DataBindXY(x1, y1);
                QC_RChart.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                QC_RChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                QC_RChart.Series["Series3"].YValueMembers = ds.Tables[0].Columns[14].ColumnName;
                QC_RChart.Series["Series4"].YValueMembers = ds.Tables[0].Columns[15].ColumnName;
                QC_RChart.Series["Series5"].YValueMembers = ds.Tables[0].Columns[13].ColumnName;
                //QC_RChart.Series["Series6"].YValueMembers = ds.Tables[0].Columns[7].ColumnName;
                //QC_RChart.Series["Series7"].YValueMembers = ds.Tables[0].Columns[8].ColumnName;
                //QC_RChart.Series["Series8"].YValueMembers = ds.Tables[0].Columns[6].ColumnName;
                //QC_RChart.Series["Series9"].YValueMembers = ds.Tables[0].Columns[7].ColumnName;

                //sp_usl1.InnerText = ds.Tables[0].Rows[0][9].ToString();
                //sp_lsl1.InnerText = ds.Tables[0].Rows[0][10].ToString();
                QC_RChart.Series["Series1"].EmptyPointStyle.Color = System.Drawing.Color.Black;
                QC_RChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                QC_RChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                //if (ds.Tables[0].Rows[0][3].ToString() == "" || ds.Tables[0].Rows[0][2] == null)
                //{
                //    sp_CP.InnerText = "0.00";
                //}
                //else
                //{
                //    sp_CP.InnerText = ds.Tables[0].Rows[0][3].ToString();
                //}
                //if (ds.Tables[0].Rows[0][3].ToString() == "" || ds.Tables[0].Rows[0][3] == null)
                //{
                //    sp_CPK.InnerText = "0.00";
                //}
                //else
                //{
                //    sp_CPK.InnerText = ds.Tables[0].Rows[0][3].ToString();
                //}
                sp_CP1.InnerText = ds.Tables[0].Rows[0][14].ToString();
                sp_CPK1.InnerText = ds.Tables[0].Rows[0][15].ToString();
                QC_RChart.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(ds.Tables[0].Rows[0][11].ToString());
                QC_RChart.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(ds.Tables[0].Rows[0][12].ToString());
                //QC_RChart.ChartAreas["ChartArea1"].AxisY.Interval = Convert.ToDouble(ds.Tables[0].Rows[0][19].ToString());// 00.001;
                QC_RChart.ChartAreas["ChartArea1"].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

                div_chart.Visible = true;
                div_Rchart.Visible = true;
                div_error.Visible = false;
                spn_error.Visible = false;
            }
            else
            {
                div_chart.Visible = false;
                div_Rchart.Visible = false;
                div_error.Visible = true;
                spn_error.InnerText = "SPC Chart are not available for " + part;
            }

        }
        else
        {
            div_chart.Visible = false;
            div_Rchart.Visible = false;
            div_error.Visible = true;
            spn_error.InnerText = "SPC Chart are not available for " + part;
        }
    }
    private void QC_Chart_MouseMove(object sender, MouseEventArgs e)
    {
        //HitTestResult result = QC_Chart.HitTest(e.X, e.Y);
        //System.Drawing.Point p = new System.Drawing.Point(e.X, e.Y);
        //QC_Chart.ChartAreas[0].AxisX.PixelPositionToValue(
        //QC_Chart.ChartAreas[0].CursorX.Interval = 0;
        //QC_Chart.ChartAreas[0].CursorX.SetCursorPixelPosition(p, true);
        //QC_Chart.ChartAreas[0].CursorY.SetCursorPixelPosition(p, true);

        //var pos = e.Location;
        //var result = QC_Chart.HitTest(pos.X, pos.Y, false,
        //                           ChartElementType.DataPoint);

        //        int k = result.PointIndex;
        //        if (k >= 0)
        //        {
        //            QC_Chart.Series[0].Points[k].ToolTip = "X=#VALX, Y=#VALY";
        //        }

    }

    protected void QC_Chart_Customize(object sender, EventArgs e)
    {
        foreach (CustomLabel label in QC_Chart.ChartAreas[0].AxisY.CustomLabels)
        {
            if (label.RowIndex == 0)
            {
                label.ToolTip = string.Format("This is my custom tooltip for the value: {0}", label.Text);
            }
        }
    }
    public void getchartvalue(string Partno, string Operation, string Dimenssion, string From, string To, string Shift, string Mach, string Unit, string Cell, string Mean, string Dynrefid, string Size, string DynValueid)
    {
        string part, operation, shift, type, cell, Dimension;
        part = Partno.ToString();
        operation = Operation.ToString();
        if (operation == "OP1")
        {
            operation = "1";
        }
        if (operation == "OP2")
        {
            operation = "2";
        }
        shift = Shift.ToString();
        mchn = Mach.ToString();
        unit = Unit.ToString();
        cell = Cell.ToString();
        string from = From.ToString();
        string tp = To.ToString();
        Dimension = Dimenssion.ToString();
        string tableName = "QualitySheet_" + cell + "_" + part + "_" + operation + "";

        GenerateChart(part, tableName, from, tp, shift, mchn, unit, cell, operation, Dimension, Mean, Dynrefid, Size, DynValueid);
    }
}
