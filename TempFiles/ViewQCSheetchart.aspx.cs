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

public partial class ViewQCSheetchart : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public DBServer objserver = new DBServer();
    public SqlCommand cmd;
    public DataSet ds;
    public SqlDataAdapter da;
    public DataSet ds1;
    public string  max = "67.625";
    public string min = "67.575";
    public decimal CP;
    public decimal CPK;
    public decimal tolerance;
    public decimal points = 67;
    public decimal Standardeviation;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            get_standardeviation();
            GenerateChart();
        }
    }
    public void get_standardeviation()
    {
        try
        {
            cmd = new SqlCommand("SP_GetstanderdDeviation", strConnString);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@Standardeviation", SqlDbType.Decimal);
            cmd.Parameters.Add("@Range", SqlDbType.Decimal);
            cmd.Parameters.Add("@MValue", SqlDbType.Decimal);
            cmd.Parameters["@Standardeviation"].Direction = ParameterDirection.Output;
            cmd.Parameters["@Range"].Direction = ParameterDirection.Output;
            cmd.Parameters["@MValue"].Direction = ParameterDirection.Output;

            strConnString.Open();
            cmd.ExecuteNonQuery();
            strConnString.Close();

             Standardeviation = Convert.ToDecimal(cmd.Parameters["@Standardeviation"].Value);
            decimal Range = Convert.ToDecimal(cmd.Parameters["@Range"].Value);
            decimal Mvalue = Convert.ToDecimal(cmd.Parameters["@MValue"].Value);

            tolerance =(Convert.ToDecimal( max) -(Convert.ToDecimal( min)));
            CP = tolerance / Standardeviation * 6;

            CPK = Convert.ToDecimal( max) - Mvalue / 3 * Standardeviation;
        }
        catch
        {
        }
        finally
        {
        }
        save_chartdetails(CP, CPK, max, min,Standardeviation);

    }
    public void save_chartdetails( decimal CP, decimal CPK,string max,string min,decimal Standardeviation)
    {
        try
        {
            //try
            //{

            //    cmd = new SqlCommand("delete from tbl_QChart",strConnString);
            //}
            //catch (Exception ex)
            //{
            //}
            //finally
            //{
            //    strConnString.Open();
            //    cmd.ExecuteNonQuery();
            //    strConnString.Close();
            //}

                ds = objserver.GetDateset("select * from tbl_QChart");
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ds1 = objserver.GetDateset("select * from QualitySheet");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        cmd = new SqlCommand("SP_nsertChart", strConnString);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Chart_Max", SqlDbType.Decimal).Value = Convert.ToDecimal(max);
                        cmd.Parameters.Add("@Chart_Min", SqlDbType.Decimal).Value = Convert.ToDecimal(min);
                        cmd.Parameters.Add("@Chart_CP", SqlDbType.Decimal).Value = CP;
                        cmd.Parameters.Add("@Chart_CPK", SqlDbType.Decimal).Value = CPK;
                        cmd.Parameters.Add("@Chart_Deviation", SqlDbType.Decimal).Value = Standardeviation;
                        cmd.Parameters.Add("@Average", SqlDbType.Decimal).Value = ds1.Tables[0].Rows[i]["Average"];
                        strConnString.Open();
                        cmd.ExecuteNonQuery();
                        strConnString.Close();
                    }
                }
        }
        catch (Exception ex)
        {

        }
        finally
        {
          
        }

    }
    public void GenerateChart()
    {
        ds = objserver.GetDateset("select * from tbl_QChart");
        string[] x = new string[ds.Tables[0].Rows.Count];
        decimal[] y = new decimal[ds.Tables[0].Rows.Count];
        //QC_Chart.Series["Series1"].XValueMember = "QID".ToString();
       // QC_Chart.Series["Series1"].YValueMembers = "Average";
        QC_Chart.DataSource = ds;
        QC_Chart.DataBind();
        int row = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                row += 1;
                x[i] = Convert.ToString(row);
                y[i] = Convert.ToDecimal(ds.Tables[0].Rows[i]["Average"]);
                QC_Chart.Series[0].Points.AddY(Convert.ToDecimal(ds.Tables[0].Rows[i]["Average"]));
            }

            QC_Chart.Series["Series1"].Points.DataBindXY(x, y);
            QC_Chart.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            QC_Chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            QC_Chart.Series["Series3"].YValueMembers = "Chart_Max";
            QC_Chart.Series["Series4"].YValueMembers = "Chart_Min";
            QC_Chart.Series["Series1"].EmptyPointStyle.Color = System.Drawing.Color.Black;
            //ds1 = objserver.GetDateset("select * from tbl_QChart");
            //if (ds1.Tables[0].Rows.Count > 0)
            //{
            //    QC_Chart.Series["Series3"].Points.AddY(ds1.Tables[0].Rows[0]["Chart_Max"]);
            //    QC_Chart.Series["Series4"].Points.AddY(ds1.Tables[0].Rows[0]["Chart_Min"]);
            //}
        }
    }
}
