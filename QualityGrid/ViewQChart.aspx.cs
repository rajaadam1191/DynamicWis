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

public partial class ViewQChart : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public SqlCommand cmd;
    public DataSet ds;
    public SqlDataAdapter da;
    public DataSet ds1;

    public string partno, operation, fromdate, todate, Type, shift,mchn,unit;
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
                BindPartNO();
                BindOperation();
                txt_fromdate.Value = DateTime.Now.ToShortDateString().ToString();
                txt_todate.Value = DateTime.Now.ToShortDateString().ToString();
            }
            else
            {
                Response.Redirect("../Home.aspx");
            }
        }
    }
    private void BindPartNO()
    {
        ds = objserver.GetDateset("select '-Select-' partno,'-Select-' partno union select distinct partno,partno from tbl_PartNo order by 1 desc");


        ddl_partno.DataSource = ds.Tables[0];
        ddl_partno.DataValueField = "PartNo";
        ddl_partno.DataTextField = "PartNo";
        ddl_partno.DataBind();

    }
    private void BindOperation()
    {
        ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");

        ddl_operation.DataSource = ds.Tables[0];
        ddl_operation.DataValueField = "Process";
        ddl_operation.DataTextField = "Process";
        ddl_operation.DataBind();

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
                    y[i] = Convert.ToDecimal(ds.Tables[0].Rows[i][4]);
                    QC_Chart.Series[0].Points.AddY(Convert.ToDecimal(ds.Tables[0].Rows[i][4]));
                }
                QC_Chart.Series["Series1"].Points.DataBindXY(x, y);
                QC_Chart.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                QC_Chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                QC_Chart.Series["Series3"].YValueMembers = ds.Tables[0].Columns[5].ColumnName;
                QC_Chart.Series["Series4"].YValueMembers = ds.Tables[0].Columns[6].ColumnName;
                //QC_Chart.Series["Series5"].YValueMembers = "Ranget";
                //QC_Chart.Series["Series6"].YValueMembers = ds.Tables[0].Columns[9].ColumnName;
                //QC_Chart.Series["Series7"].YValueMembers = ds.Tables[0].Columns[10].ColumnName;
                //QC_Chart.Series["Series8"].YValueMembers = ds.Tables[0].Columns[7].ColumnName;
                //QC_Chart.Series["Series9"].YValueMembers = ds.Tables[0].Columns[8].ColumnName;
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
                QC_Chart.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(ds.Tables[0].Rows[0][5].ToString());
                QC_Chart.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(ds.Tables[0].Rows[0][6].ToString());
                QC_Chart.ChartAreas["ChartArea1"].AxisY.Interval = 00.002;
                div_chart.Visible = true;
            }
            else
            {
                div_chart.Visible = false;
            }

        }
    }
    protected void img_view_Click(object sender, ImageClickEventArgs e)
    {
        string part, operation, shift, type, cell,Dimension;
       // type = ddl_type.Value.ToString();
        part = ddl_partno.Value.ToString();
        operation = ddl_operation.Value.ToString();
        if (operation == "OP1")
        {
            operation = "1";
        }
        if (operation == "OP2")
        {
            operation = "2";
        }
        shift = ddl_shift.Value.ToString();
        mchn = hdn_mach.Value.ToString();
        //Session["mchn"].ToString();
        unit = hdn_unit1.Value.ToString();
        cell = hdn_cell.Value.ToString();
        //   QC_chart_D1(unit);
        //part = ddl_partno.Value.ToString();
        //operation = ddl_operation.Value.ToString();
        //shift = ddl_shift.Value.ToString();
        string  from = txt_fromdate.Value.ToString();
        string  tp = txt_todate.Value.ToString();
        Dimension = hdn_dimesion.Value.ToString();
        string tableName = "QualitySheet_" + cell + "_" + part + "_" + operation + "";

        GenerateChart(part, tableName, from, tp, shift, mchn, unit, cell, operation, Dimension);
        ddl_cell.Value = hdn_cell.Value.ToString();
        Slct_machine_QC_chart.Value = hdn_mach.Value.ToString();
    }
    protected void onselectedindexchanged_QC_chart(object sender, EventArgs e)
    {
        string unit = ddl_cell.Value.ToString();
        QC_chart_D1(unit);
        
    }
    public void QC_chart_D1(string unit)
    {
      
        if (unit == "MBU")
        {
            ds = objserver.GetDateset("select '-Select-' MBU,'-Select-' MBU union select distinct MBU,MBU from Machine_rpt_tble order by 1 asc");

            Slct_machine_QC_chart.DataSource = ds.Tables[0];

            Slct_machine_QC_chart.DataValueField = "MBU";
            Slct_machine_QC_chart.DataTextField = "MBU";
            Slct_machine_QC_chart.DataBind();
        }
        else if (unit == "ABU")
        {
            ds = objserver.GetDateset("select '-Select-' ABU,'-Select-' ABU union select distinct ABU,ABU from Machine_rpt_tble order by 1 asc");

            Slct_machine_QC_chart.DataSource = ds.Tables[0];

            Slct_machine_QC_chart.DataValueField = "ABU";
            Slct_machine_QC_chart.DataTextField = "ABU";
            Slct_machine_QC_chart.DataBind();
        }
        else if (unit == "ALL")
        {
            ds = objserver.GetDateset("SELECT '-Select-' ALLRPT,'-Select-' ALLRPT union select distinct MBU,MBU  as ALLRPT FROM Machine_rpt_tble where MBU<>'' UNION ALL SELECT '-Select-' ALLRPT,'-Select-' ALLRPT  union select distinct ABU,ABU  as ALLRPT   FROM Machine_rpt_tble where ABU<>'' ");

            Slct_machine_QC_chart.DataSource = ds.Tables[0];

            Slct_machine_QC_chart.DataValueField = "ALLRPT";
            Slct_machine_QC_chart.DataTextField = "ALLRPT";
            Slct_machine_QC_chart.DataBind();
        }
        if (Session["Machine"] != null && Session["Machine"].ToString()!="")
        {
            Slct_machine_QC_chart.Value = Session["Machine"].ToString();

        }
        else
        {
        }
    }

}
