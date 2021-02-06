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
using System.Data.SqlClient;
using System.Xml.Linq;

public partial class Productions_Downtimeloss : System.Web.UI.Page
{
    DBServer objserver = new DBServer();
    private String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    QualitySheetdclassDataContext objQualitySheetdclassDataContext = new QualitySheetdclassDataContext();
    DataSet ds;
    public EfficiencyReport objefficiency = new EfficiencyReport();
    public static double h;
    public static double j;
    public static double tt, s;
    public int d;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPartNO();
            BindOperation();
            txt_date.Value = DateTime.Now.ToShortDateString().ToString();
            if (Session["User_Name"] != null && Session["User_Name"].ToString() != "")
            {
                if (Session["User_Name"].ToString().ToLower() == "user")
                {
                    loadpagedata();
                }
            }
            else
            {
                Response.Redirect("../Home.aspx");
            }
        }
    }
    public void BindPartNO()
    {
        ds = objserver.GetDateset("select '-Select-' partno,'-Select-' partno union select distinct partno,partno from tbl_PartNo order by 1 desc");


        ddl_partno.DataSource = ds.Tables[0];
        ddl_partno.DataValueField = "PartNo";
        ddl_partno.DataTextField = "PartNo";
        ddl_partno.DataBind();
    }
    public void BindOperation()
    {
        ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");

        ddl_operation.DataSource = ds.Tables[0];
        ddl_operation.DataValueField = "Process";
        ddl_operation.DataTextField = "Process";
        ddl_operation.DataBind();
    }
    public void loadpagedata()
    {
        ddl_partno.Value = Session["PartNo"].ToString();
        ddl_partno.Disabled = true;
        string op = "";
        if (Session["Operation"].ToString() == "1" || Session["Operation"].ToString() == "2")
        {
            if (Session["Operation"].ToString() == "1")
            {
                op = "OP1";
            }
            if (Session["Operation"].ToString() == "2")
            {
                op = "OP2";
            }

        }
        else
        {
            op = Session["Operation"].ToString();
        }
        ddl_operation.Value = op.ToString();
        ddl_operation.Disabled = true;
        ddl_shift.Value = Session["Shift"].ToString();
        ddl_shift.Disabled = true;
        ddl_fromtime.Disabled = true;
        ddl_totime.Disabled = true;
        ddl_fromampm.Disabled = true;
        ddl_toampm.Disabled = true;
        txt_operatorname.Disabled = true;
        txt_operatorname.Value = Session["User_Name"].ToString();
        if (Session["Shift"].ToString() == "A")
        {
            ddl_fromtime.Value = "6";
            ddl_totime.Value = "2";
        }
        if (Session["Shift"].ToString() == "B")
        {
            ddl_fromtime.Value = "2";
            ddl_totime.Value = "10";
        }
        if (Session["Shift"].ToString() == "C")
        {
            ddl_fromtime.Value = "10";
            ddl_totime.Value = "6";
        }
        if (Session["MachineName"] != null && Session["MachineName"].ToString() != "")
        {
            txt_machinename.Value = Session["MachineName"].ToString();
            txt_machinename.Disabled = true;
        }
        txt_date.Disabled = true;
        txt_rejection.Disabled = true;
        loadplannedvalue();
        loadtt();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "getRejection1('" + Session["PartNo"].ToString() + "','" + Session["Shift"].ToString() + "','" + op + "','" + txt_date.Value.ToString() + "');", true);

    }
    public void loadtt()
    {
        string part = Session["PartNo"].ToString();
        string operation = "";

        if (Session["Operation"].ToString() == "1" || Session["Operation"].ToString() == "2")
        {
            if (Session["Operation"].ToString() == "1")
            {
                operation = "OP1";
            }
            if (Session["Operation"].ToString() == "2")
            {
                operation = "OP2";
            }

        }
        else
        {
            operation = Session["Operation"].ToString();
        }

        SqlDataAdapter da = new SqlDataAdapter("select * from TimeMaster where PartNo='" + part + "' and Operation='" + operation + "'", strConnString);
        DataSet ds1 = new DataSet();
        da.Fill(ds1);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            TextTt.Text = ds1.Tables[0].Rows[0]["tt"].ToString();
        }
        else
        {
            TextTt.Text = "0";
        }
    }
    public void loadplannedvalue()
    {
        DBServer Db = new DBServer();
        DataSet ds = new DataSet();
        string part = Session["PartNo"].ToString();
        string opertaion = "";
        if (Session["Operation"].ToString() == "1" || Session["Operation"].ToString() == "2")
        {
            if (Session["Operation"].ToString() == "1")
            {
                opertaion = "OP1";
            }
            if (Session["Operation"].ToString() == "2")
            {
                opertaion = "OP2";
            }

        }
        else
        {
            opertaion = Session["Operation"].ToString();
        }
        string shift = Session["Shift"].ToString();

        SqlDataAdapter da = new SqlDataAdapter("select * from PlaneedEntryDetails where PartNo='" + part + "' and Process='" + opertaion + "' and Shift='" + shift + "'", strConnString);
        DataSet ds1 = new DataSet();
        da.Fill(ds1);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            txt_maintenance.Value = ds1.Tables[0].Rows[0]["Maintenance"].ToString();
            int tea = Convert.ToInt32(ds1.Tables[0].Rows[0]["LunchTime"].ToString()) + Convert.ToInt32(ds1.Tables[0].Rows[0]["TeaTime"].ToString());
            txt_lunch.Value = tea.ToString();
            txt_noplan.Value = ds1.Tables[0].Rows[0]["PlanTime"].ToString();
            txt_manuf.Value = ds1.Tables[0].Rows[0]["Manufacturing"].ToString();
            txt_meeting.Value = ds1.Tables[0].Rows[0]["Meeting"].ToString();
            txt_fixed.Value = ds1.Tables[0].Rows[0]["Setup"].ToString();
            txt_shifttime.Value = "8";// ds1.Tables[0].Rows[0]["ShiftTime"].ToString();
            txt_maintenance.Disabled = true;
            txt_lunch.Disabled = true;
            txt_noplan.Disabled = true;
            txt_manuf.Disabled = true;
            txt_meeting.Disabled = true;
            txt_fixed.Disabled = true;
            txt_shifttime.Disabled = true;
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "getRejection();", true);
        }
        else
        {
            txt_maintenance.Value = "";
            txt_lunch.Value = "";
            txt_noplan.Value = "";
            txt_manuf.Value = "";
            txt_meeting.Value = "";
            txt_fixed.Value = "";
            txt_shifttime.Value = "";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter The Bottle Neck Time In Time Master');", true);
        }

    }
    protected void txt_prodqty_TextChanged(object sender, EventArgs e)
    {

        if (txt_maintenance.Value != "" && txt_lunch.Value != "" && txt_noplan.Value != "" && txt_manuf.Value != "" && txt_meeting.Value != "")
        {
            double a, b, c, d, f, g, h;
            a = Convert.ToDouble(txt_maintenance.Value);
            b = Convert.ToDouble(txt_lunch.Value);
            c = Convert.ToDouble(txt_noplan.Value);
            d = Convert.ToDouble(txt_manuf.Value);
            f = Convert.ToDouble(txt_meeting.Value);
            g = a + b + c + d + f;
            h = g / 60;
            TxtPlannedStops.Text = Convert.ToString(h);
            TxtPlannedStops.Text = Math.Round(double.Parse(TxtPlannedStops.Text), 0).ToString();

        }
        double h1, f1, g1;
        if (txt_prodqty.Text != "")
        {
            h1 = Convert.ToDouble(txt_prodqty.Text);
            f1 = tt;
            g1 = h1 * f1 / 60;
            Text_Util.Value = Convert.ToString(g1);
            Text_Util.Value = Math.Round(double.Parse(Text_Util.Value), 0).ToString();
        }
        else
        {

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter The Bottle Neck Time In Time Master');", true);
        }
        Calc1();
    }
    protected void txt_totdowntime_TextChanged(object sender, EventArgs e)
    {
        //Calculation();
        if (txt_downtype.Value != "")
        {
            double k, i, j;
            string downtype = txt_downtype.Value.ToString();


            downtype = downtype.Replace(":", ".");


            k = Convert.ToDouble(downtype);

            i = k;
            j = i / 60;
            TxtDownTimeLoss.Text = Convert.ToString(j);
            TxtDownTimeLoss.Text = Math.Round(double.Parse(TxtDownTimeLoss.Text), 0).ToString();
        }
        Calc1();
    }
    protected void txt_speedtype_TextChanged(object sender, EventArgs e)
    {

        if (txt_speedtype.Value != "")
        {
            double a, c, d;
            string speedtype = txt_speedtype.Value.ToString();
            speedtype = speedtype.Replace(":", ".");
            a = Convert.ToDouble(speedtype);
            c = a;
            d = c / 60;
            TxtSpeedLoss.Text = Convert.ToString(d);
            TxtSpeedLoss.Text = Math.Round(double.Parse(TxtSpeedLoss.Text), 0).ToString();
        }
        Calc1();

    }
    protected void TxtCMMInspection_TextChanged(object sender, EventArgs e)
    {

        if (txt_rejection.Value != "" && txt_cmm.Text != "")
        {
            double a, b, c, d;
            a = Convert.ToDouble(txt_rejection.Value);
            b = Convert.ToDouble(txt_cmm.Text);
            c = a + b;
            d = c / 60;
            TxtQualityloss.Text = Convert.ToString(d);
            TxtQualityloss.Text = Math.Round(double.Parse(TxtQualityloss.Text), 0).ToString();
        }
        Calc1();

    }

    protected void TxtUtilTime_TextChanged(object sender, EventArgs e)
    {
        Calculation();

    }

    private void Calc1()
    {

        if (TxtOpenedTime.Text != "" && TxtPlannedStops.Text != "")
        {
            double a21, b21, c21;
            a21 = Convert.ToDouble(TxtOpenedTime.Text);
            b21 = Convert.ToDouble(TxtPlannedStops.Text);
            c21 = a21 - b21;
            TxtPlandClosing.Text = Convert.ToString(c21);
            TxtPlandClosing.Text = Math.Round(double.Parse(TxtPlandClosing.Text), 0).ToString();
        }
        if (TxtTotalStop.Text != "" && Text_Util.Value != "")
        {
            double d, f, g;

            d = Convert.ToDouble(TxtTotalStop.Text);
            f = Convert.ToDouble(Text_Util.Value);
            g = (d + f);
            TxtTotalStophours.Text = Convert.ToString(g);
            TxtTotalStophours.Text = Math.Round(double.Parse(TxtTotalStophours.Text), 0).ToString();
        }

        if (TextTt.Text != "" && Text_Util.Value != "")
        {
            double a, b, c;
            a = Convert.ToDouble(TextTt.Text);
            b = Convert.ToDouble(Text_Util.Value);
            c = (a - b);
            TxtTotalStop.Text = Convert.ToString(c);
            TxtTotalStop.Text = Math.Round(double.Parse(TxtTotalStop.Text), 0).ToString();
        }
        if (TextTt.Text != "" && TxtPlannedStops.Text != "")
        {
            double a, b, c;
            a = Convert.ToDouble(TextTt.Text);
            b = Convert.ToDouble(TxtPlannedStops.Text);
            c = a - b;
            TxtOpenedTime.Text = Convert.ToString(c);
            TxtOpenedTime.Text = Math.Round(double.Parse(TxtOpenedTime.Text), 0).ToString();

        }

        if (TxtOpenedTime.Text != "" && TxtPlannedStops.Text != "")
        {
            double a, b, c;
            a = Convert.ToDouble(TxtOpenedTime.Text);
            b = Convert.ToDouble(TxtPlannedStops.Text);
            c = a - b;
            TxtReqtime.Text = Convert.ToString(c);
            TxtReqtime.Text = Math.Round(double.Parse(TxtReqtime.Text), 0).ToString();
        }
        if (TxtReqtime.Text != "" && TxtDownTimeLoss.Text != "")
        {
            double a, b, c;
            a = Convert.ToDouble(TxtReqtime.Text);
            b = Convert.ToDouble(TxtDownTimeLoss.Text);
            c = a - b;
            TxtFunctionTime.Text = Convert.ToString(c);
            TxtFunctionTime.Text = Math.Round(double.Parse(TxtFunctionTime.Text), 0).ToString();
        }
        if (Text_Util.Value != "" && TxtQualityloss.Text != "")
        {
            double a, b, c;
            a = Convert.ToDouble(Text_Util.Value);
            b = Convert.ToDouble(TxtQualityloss.Text);
            c = a + b;
            TxtNetOpTime.Text = Convert.ToString(c);
            TxtNetOpTime.Text = Math.Round(double.Parse(TxtNetOpTime.Text), 0).ToString();

        }

        if (Text_Util.Value != "")
        {
            TxtUtileTime.Text = Convert.ToString(Text_Util.Value);
            TxtUtileTime.Text = Math.Round(double.Parse(Text_Util.Value), 0).ToString();
        }

        if (TxtUtileTime.Text != "" && TxtReqtime.Text != "")
        {
            double a3, b3, c3;

            a3 = Convert.ToDouble(TxtUtileTime.Text);
            b3 = Convert.ToDouble(TxtReqtime.Text);
            c3 = (a3 / b3) * 100;
            TxtTRS.Text = Convert.ToString(c3);
            TxtTRS.Text = Math.Round(double.Parse(TxtTRS.Text), 0).ToString();
        }
        else
        {
            //  Response.Write("Please Enter The Values");
        }

        if (TxtUtileTime.Text != "" && TxtOpenedTime.Text != "")
        {
            double a4, b4, c4, d;
            a4 = Convert.ToDouble(TxtUtileTime.Text);
            b4 = Convert.ToDouble(TxtOpenedTime.Text);
            c4 = (a4 / b4) * 100;
            TxtTRG.Text = Convert.ToString(c4);
            TxtTRG.Text = Math.Round(double.Parse(TxtTRG.Text), 0).ToString();
            if (TxtTRG.Text != "")
            {
                d = Convert.ToInt32(TxtTRG.Text);
                if (d < 85)
                {


                    TxtTRG.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    TxtTRG.BackColor = System.Drawing.Color.Green;
                }
            }
        }
        else
        {
            //  Response.Write("Please Enter The Values");
        }
    }

    private void Calculation()
    {
        if (txt_maintenance.Value != "" && txt_lunch.Value != "" && txt_noplan.Value != "" && txt_manuf.Value != "" && txt_meeting.Value != "")
        {
            double a, b, c, d, f, g, h;
            a = Convert.ToDouble(txt_maintenance.Value);
            b = Convert.ToDouble(txt_lunch.Value);
            c = Convert.ToDouble(txt_noplan.Value);
            d = Convert.ToDouble(txt_manuf.Value);
            f = Convert.ToDouble(txt_meeting.Value);
            g = a + b + c + d + f;
            h = g / 60;
            TxtPlannedStops.Text = Convert.ToString(h);
            TxtPlannedStops.Text = Math.Round(double.Parse(TxtPlannedStops.Text), 0).ToString();

        }

        if (txt_downtype.Value != "")
        {
            double k, i;
            string downtype = txt_downtype.Value.ToString();


            downtype = downtype.Replace(":", ".");


            k = Convert.ToDouble(downtype);

            i = k;
            j = i / 60;
            TxtDownTimeLoss.Text = Convert.ToString(j);
            TxtDownTimeLoss.Text = Math.Round(double.Parse(TxtDownTimeLoss.Text), 0).ToString();
        }
        if (txt_speedtype.Value != "")
        {
            double a, b, c, d;
            string speedtype = txt_speedtype.Value.ToString();
            speedtype = speedtype.Replace(":", ".");
            a = Convert.ToDouble(speedtype);
            c = a;
            d = c / 60;
            TxtSpeedLoss.Text = Convert.ToString(d);
            TxtSpeedLoss.Text = Math.Round(double.Parse(TxtSpeedLoss.Text), 0).ToString();
        }

        if (txt_rejection.Value != "" && txt_cmm.Text != "")
        {
            double a, b, c, d;
            a = Convert.ToDouble(txt_rejection.Value);
            b = Convert.ToDouble(txt_cmm.Text);
            c = a + b;
            d = c / 60;
            TxtQualityloss.Text = Convert.ToString(d);
            TxtQualityloss.Text = Math.Round(double.Parse(TxtQualityloss.Text), 0).ToString();
        }

        double h1, f1, g1;
        if (txt_prodqty.Text != "")
        {
            h1 = Convert.ToDouble(txt_prodqty.Text);
            f1 = tt;
            g1 = h1 * f1 / 60;
            Text_Util.Value = Convert.ToString(g1);
            Text_Util.Value = Math.Round(double.Parse(Text_Util.Value), 0).ToString();
        }
        else
        {

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter The Bottle Neck Time In Time Master');", true);
        }



        Calc1();

    }
    protected void Button1_Click2(object sender, EventArgs e)
    {
        Calculation();
    }
    protected void TxtCMMInspection_Unload(object sender, EventArgs e)
    {
        Calculation();
    }
    protected void TxtCMMInspection_SelectedIndexChanged(object sender, EventArgs e)
    {
        Calculation();
        Calc1();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        conn.Open();
        objefficiency = new EfficiencyReport();
        try
        {



            objefficiency.Partno = ddl_partno.SelectedIndex.ToString();
            objefficiency.Operation = ddl_operation.SelectedIndex.ToString();
            objefficiency.EffDate = Convert.ToDateTime(txt_date.Value.ToString());
            objefficiency.Shift = ddl_shift.SelectedIndex.ToString();
            //objefficiency.FromTo = TxtFromTo.Text.ToString();
            objefficiency.FromTo = ddl_fromtime.Value.ToString() + " " + ddl_fromampm.Value.ToString() + " To " + ddl_totime.Value.ToString() + " " + ddl_toampm.Value.ToString();
            objefficiency.OperatorName = txt_operatorname.Value.ToString();
            objefficiency.MinorStart = txt_speedstart.Value.ToString();
            objefficiency.MinorEnd = txt_speedend.Value.ToString();

            string mtotal = txt_totspeed.Text.ToString();
            if (mtotal == "" || mtotal == null)
            {
                objefficiency.MinorTotal = Convert.ToDecimal(0.00);
            }
            else
            {
                mtotal = mtotal.Replace(":", ".");
                objefficiency.MinorTotal = Convert.ToDecimal(mtotal);
            }

            if (txt_maintenance.Value.ToString() == "")
            {
                objefficiency.Mainteance = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.Mainteance = Convert.ToDecimal(txt_maintenance.Value.ToString());
            }
            if (txt_lunch.Value.ToString() == "")
            {
                objefficiency.LenchTea = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.LenchTea = Convert.ToDecimal(txt_lunch.Value.ToString());
            }
            if (txt_noplan.Value.ToString() == "")
            {
                objefficiency.NoPlan = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.NoPlan = Convert.ToDecimal(txt_noplan.Value.ToString());
            }
            if (txt_manuf.Value.ToString() == "")
            {
                objefficiency.Manufacturing = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.Manufacturing = Convert.ToDecimal(txt_manuf.Value.ToString());
            }
            if (txt_meeting.Value.ToString() == "")
            {
                objefficiency.Meeting = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.Meeting = Convert.ToDecimal(txt_meeting.Value.ToString());
            }
            if (txt_shifttime.Value.ToString() == "")
            {
                objefficiency.ShiftTime = "";
            }
            else
            {
                objefficiency.ShiftTime = txt_shifttime.Value.ToString();
            }
            if (txt_fixed.Value.ToString() == "")
            {
                objefficiency.Setup = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.Setup = Convert.ToDecimal(txt_fixed.Value.ToString());
            }
            if (txt_prodqty.Text.ToString() == "")
            {
                objefficiency.ProdQty = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.ProdQty = Convert.ToDecimal(txt_prodqty.Text.ToString());
            }
            if (txt_rejection.Value.ToString() == "")
            {
                objefficiency.Rejection = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.Rejection = Convert.ToDecimal(txt_rejection.Value.ToString());
            }
            if (txt_cmm.Text.ToString() == "")
            {
                objefficiency.CMM = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.CMM = Convert.ToDecimal(txt_cmm.Text.ToString());
            }
            objefficiency.EqupStart = txt_startdown.Value.ToString();
            objefficiency.EqupEnd = txt_downend.Value.ToString();
            string teq = txt_totdowntime.Value.ToString();
            if (teq == "" || teq == null)
            {
                objefficiency.EqupTotal = Convert.ToDecimal(0.00);
            }
            else
            {
                teq = teq.Replace(":", ".");
                objefficiency.EqupTotal = Convert.ToDecimal(teq);
            }

            if (Text_Util.Value.ToString() == "")
            {
                objefficiency.UtileTime = Convert.ToDecimal(0.00);
            }

            else
            {
                objefficiency.UtileTime = Convert.ToDecimal(Text_Util.Value.ToString());
            }
            if (TextTt.Text.ToString() == "" || TextTt.Text == null)
            {
                objefficiency.TT = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.TT = Convert.ToDecimal(TextTt.Text.ToString());
            }

            if (TxtPlandClosing.Text == null || TxtPlandClosing.Text.ToString() == "")
            {
                objefficiency.Plantclosing = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.Plantclosing = Convert.ToDecimal(TxtPlandClosing.Text.ToString());
            }
            if (TxtOpenedTime.Text == null || TxtOpenedTime.Text.ToString() == "")
            {
                objefficiency.ToOpend = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.ToOpend = Convert.ToDecimal(TxtOpenedTime.Text.ToString());
            }
            if (TxtPlannedStops.Text == null || TxtPlannedStops.Text.ToString() == "")
            {
                objefficiency.PlannedStop = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.PlannedStop = Convert.ToDecimal(TxtPlannedStops.Text.ToString());
            }
            if (TxtReqtime.Text == null || TxtReqtime.Text.ToString() == "")
            {
                objefficiency.TrRequired = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.TrRequired = Convert.ToDecimal(TxtReqtime.Text.ToString());
            }
            if (TxtDownTimeLoss.Text == null || TxtDownTimeLoss.Text.ToString() == "")
            {
                objefficiency.DownTimeLoss = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.DownTimeLoss = Convert.ToDecimal(TxtDownTimeLoss.Text.ToString());
            }
            if (TxtFunctionTime.Text == null || TxtFunctionTime.Text.ToString() == "")
            {
                objefficiency.TfFunction = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.TfFunction = Convert.ToDecimal(TxtFunctionTime.Text.ToString());
            }
            if (TxtSpeedLoss.Text == null || TxtSpeedLoss.Text.ToString() == "")
            {
                objefficiency.TTtime = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.TTtime = Convert.ToDecimal(TxtSpeedLoss.Text.ToString());
            }
            if (TxtNetOpTime.Text == null || TxtNetOpTime.Text.ToString() == "")
            {
                objefficiency.EntOperating = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.EntOperating = Convert.ToDecimal(TxtNetOpTime.Text.ToString());
            }
            if (TxtQualityloss.Text == null || TxtQualityloss.Text.ToString() == "")
            {
                objefficiency.Qloss = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.Qloss = Convert.ToDecimal(TxtQualityloss.Text.ToString());
            }
            if (TxtUtileTime.Text == null || TxtUtileTime.Text.ToString() == "")
            {
                objefficiency.TuUtile = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.TuUtile = Convert.ToDecimal(TxtUtileTime.Text.ToString());
            }
            if (TxtTRS.Text == null || TxtTRS.Text.ToString() == "")
            {
                objefficiency.TRS = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.TRS = Convert.ToDecimal(TxtTRS.Text.ToString());
            }
            if (TxtTRG.Text == null || TxtTRG.Text.ToString() == "")
            {
                objefficiency.TRG = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.TRG = Convert.ToDecimal(TxtTRG.Text.ToString());
            }
            if (TxtTotalStop.Text == null || TxtTotalStop.Text.ToString() == "")
            {
                objefficiency.TotalStop = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.TotalStop = Convert.ToDecimal(TxtTotalStop.Text.ToString());
            }
            if (TxtTotalStophours.Text == null || TxtTotalStophours.Text.ToString() == "")
            {
                objefficiency.UtilTimeStop = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.UtilTimeStop = Convert.ToDecimal(TxtTotalStophours.Text.ToString());
            }
            objefficiency.MachineName = txt_machinename.Value.ToString();
            objefficiency.PID = Session["PID_ID"].ToString();
            objQualitySheetdclassDataContext.EfficiencyReports.InsertOnSubmit(objefficiency);
            objQualitySheetdclassDataContext.SubmitChanges();
            objQualitySheetdclassDataContext = null;
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Data Saved Successfuly !');", true);
            //ClearAll();
        }
        catch (Exception ex)
        {

        }
        finally
        {



        }
    }
}
