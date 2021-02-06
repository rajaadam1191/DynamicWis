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
public partial class DYNSheets_RunChartView : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "")
            {
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
                //string DynValueid = Request.QueryString["DynValueid"].ToString();
                //getchartvalue(Partno, Operation, Dimenssion, From, To, Shift, Mach, Unit, Cell, Mean, Dynrefid, DynValueid);

                //Request.Form
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
                string DynValueid = Request.Form["DynValueid"].ToString();
                getchartvalue(Partno, Operation, Dimenssion, From, To, Shift, Mach, Unit, Cell, Mean, Dynrefid, DynValueid);

            }
            else
            {
                HttpContext.Current.Response.Redirect("../Home.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
    }
    public void GenerateChart(string part, string Tablename, string fromdate, string todate, string shift, string mchn, string unit, string cell, string operation, string Dimension, string Mean, string Dynrefid,string DynValueid)
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
        ds = db.RunViewdimension(part, Tablename, fromdate, todate, shift, mchn, unit, cell, operation, Dimension, Mean, Dynrefid, DynValueid);
        if (ds != null)
        {
            QC_Chart.DataSource = ds.Tables[0];
            QC_Chart.DataBind();
            int row = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                string[] x = new string[ds.Tables[0].Rows.Count];
                decimal[] y = new decimal[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    row += 1;
                    x[i] = Convert.ToString(row);
                    y[i] = Convert.ToDecimal(ds.Tables[0].Rows[i][0]);
                    QC_Chart.Series[0].Points.AddY(Convert.ToDecimal(ds.Tables[0].Rows[i][0]));
                }

                QC_Chart.Series["Series1"].Points.DataBindXY(x, y);

                //***********MoveHOVER

                //QC_Chart.Series["Series1"].ToolTip = "#VALY, #VALX";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    QC_Chart.Series["Series1"].Points[i].ToolTip = "#VALY" +","+ ds.Tables[0].Rows[i][1].ToString();
                }

                QC_Chart.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                QC_Chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                QC_Chart.Series["Series3"].YValueMembers = ds.Tables[0].Columns[8].ColumnName;
                QC_Chart.Series["Series4"].YValueMembers = ds.Tables[0].Columns[9].ColumnName;
                QC_Chart.Series["Series5"].YValueMembers = ds.Tables[0].Columns[7].ColumnName;
                QC_Chart.Series["Series6"].YValueMembers = ds.Tables[0].Columns[2].ColumnName;
                QC_Chart.Series["Series7"].YValueMembers = ds.Tables[0].Columns[3].ColumnName;
                //QC_Chart.Series["Series8"].YValueMembers = ds.Tables[0].Columns[6].ColumnName;
                //QC_Chart.Series["Series9"].YValueMembers = ds.Tables[0].Columns[7].ColumnName;
                QC_Chart.Series["Series10"].YValueMembers = ds.Tables[0].Columns[4].ColumnName;

                sp_usl.InnerText = ds.Tables[0].Rows[0][8].ToString();
                sp_lsl.InnerText = ds.Tables[0].Rows[0][9].ToString();
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
                sp_CP.InnerText = ds.Tables[0].Rows[0][2].ToString();
                sp_CPK.InnerText = ds.Tables[0].Rows[0][3].ToString();
                QC_Chart.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(ds.Tables[0].Rows[0][5].ToString());
                QC_Chart.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(ds.Tables[0].Rows[0][6].ToString());
                //QC_Chart.ChartAreas["ChartArea1"].AxisY.Interval = Convert.ToDouble(ds.Tables[0].Rows[0][10].ToString());
                QC_Chart.ChartAreas["ChartArea1"].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

                //QC_Chart.ChartAreas["ChartArea1"].AxisY.Maximum = Double.NaN; // sets the Maximum to NaN
                //QC_Chart.ChartAreas["ChartArea1"].AxisY.Minimum = Double.NaN; // sets the Minimum to NaN
                //QC_Chart.ChartAreas["ChartArea1"].RecalculateAxesScale();

                div_chart.Visible = true;
                div_error.Visible = false;

                //RUN Values
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "RunvaluesFunc(" + ds.Tables[0].Rows[0][8].ToString() + "," + ds.Tables[0].Rows[0][9].ToString() + "," + ds.Tables[0].Rows[0][7].ToString() + "," + ds.Tables[0].Rows[0][2].ToString() + "," + ds.Tables[0].Rows[0][3].ToString() + "," + ds.Tables[0].Rows[0][4].ToString() + ")", true);

            }
            else
            {
                div_chart.Visible = false;
                div_error.Visible = true;
                spn_error.InnerText = "SPC Chart are not available for " + part;
            }

        }
        else
        {
            div_chart.Visible = false;
            div_error.Visible = true;
            spn_error.InnerText = "SPC Chart are not available for " + part;
        }
    }
    public void getchartvalue(string Partno, string Operation, string Dimenssion, string From, string To, string Shift, string Mach, string Unit, string Cell, string Mean, string Dynrefid, string DynValueid)
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

        GenerateChart(part, tableName, from, tp, shift, mchn, unit, cell, operation, Dimension, Mean, Dynrefid, DynValueid);
    }
}
