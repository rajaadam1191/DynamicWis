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
public partial class DYNSheets_ChartView : System.Web.UI.Page
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
                string Partno = Request.QueryString["Partno"].ToString();
                string Operation = Request.QueryString["Operation"].ToString();
                string Dimenssion = Request.QueryString["Dimenssion"].ToString();
                string From = Request.QueryString["From"].ToString();
                string To = Request.QueryString["To"].ToString();
                string Shift = Request.QueryString["Shift"].ToString();
                string Mach = Request.QueryString["Mach"].ToString();
              string Unit = Request.QueryString["Unit"].ToString();
                string Cell = Request.QueryString["Cell"].ToString();
                getchartvalue(Partno, Operation, Dimenssion, From, To, Shift, Mach, Unit, Cell);
            }
            else
            {
                Response.Redirect("../Home.aspx");
            }
        }
    }
    public void GenerateChart(string part, string Tablename, string fromdate, string todate, string shift, string mchn, string unit, string cell, string operation, string Dimension)
    {
        DBServer db = new DBServer();
        DataSet ds = new DataSet();
        ds = db.Viewdimension(part, Tablename, fromdate, todate, shift, mchn, unit, cell, operation, Dimension);
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
                    if (Convert.ToString(ds.Tables[0].Rows[i][4]).ToString() == "-")
                    { ds.Tables[0].Rows[i][4] = 0; }
                    y[i] = Convert.ToDecimal(ds.Tables[0].Rows[i][4]);
                    QC_Chart.Series[0].Points.AddY(Convert.ToDecimal(ds.Tables[0].Rows[i][4]));
                }
                QC_Chart.Series["Series1"].Points.DataBindXY(x, y);
                QC_Chart.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                QC_Chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                QC_Chart.Series["Series3"].YValueMembers = ds.Tables[0].Columns[5].ColumnName;
                QC_Chart.Series["Series4"].YValueMembers = ds.Tables[0].Columns[6].ColumnName;
                QC_Chart.Series["Series6"].YValueMembers = ds.Tables[0].Columns[7].ColumnName;
                QC_Chart.Series["Series7"].YValueMembers = ds.Tables[0].Columns[8].ColumnName;
                sp_usl.InnerText = ds.Tables[0].Rows[0][5].ToString();
                sp_lsl.InnerText = ds.Tables[0].Rows[0][6].ToString();
                QC_Chart.Series["Series1"].EmptyPointStyle.Color = System.Drawing.Color.Black;
                QC_Chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                QC_Chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                if (ds.Tables[0].Rows[0][3].ToString() == "" || ds.Tables[0].Rows[0][2] == null)
                {
                    sp_CP.InnerText = "0.00";
                }
                else
                {
                    sp_CP.InnerText = ds.Tables[0].Rows[0][3].ToString();
                }
                if (ds.Tables[0].Rows[0][3].ToString() == "" || ds.Tables[0].Rows[0][3] == null)
                {
                    sp_CPK.InnerText = "0.00";
                }
                else
                {
                    sp_CPK.InnerText = ds.Tables[0].Rows[0][3].ToString();
                }
                if (Convert.ToString(ds.Tables[0].Rows[0][5].ToString()).ToString() == "-")
                { ds.Tables[0].Rows[0][5] = 0; }
                if (Convert.ToString(ds.Tables[0].Rows[0][6].ToString()).ToString() == "-")
                { ds.Tables[0].Rows[0][6] = 0; }
                QC_Chart.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(ds.Tables[0].Rows[0][5].ToString());
                QC_Chart.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(ds.Tables[0].Rows[0][6].ToString());
                //QC_Chart.ChartAreas["ChartArea1"].AxisY.Interval = 00.002;
                QC_Chart.ChartAreas["ChartArea1"].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
                div_chart.Visible = true;
                div_error.Visible = false;
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
    public void getchartvalue(string Partno, string Operation, string Dimenssion, string From, string To, string Shift, string Mach, string Unit, string Cell)
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

        GenerateChart(part, tableName, from, tp, shift, mchn, unit, cell, operation, Dimension);
    }
}
