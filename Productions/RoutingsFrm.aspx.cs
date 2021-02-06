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

public partial class RoutingsFrm : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
            //loadpagedata();
            BindPartNO();
            BindOperation();
           
            TxtDateTime.Text = DateTime.Now.ToShortDateString();
        }

    }
    //public void loadpagedata()
    //{
    //    TxtOperatorName.Value = Session["User_Name"].ToString();
    //    TxtOperatorName.Disabled = true;
    //}


    protected void TxtTr_TextChanged(object sender, EventArgs e)
    {
       

    }
    protected void TxtTu_TextChanged(object sender, EventArgs e)
    {
       

    }
    protected void TxtTo_TextChanged(object sender, EventArgs e)
    {


       
    }
    protected void TxtTt_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void TxtBatchQty_TextChanged(object sender, EventArgs e)
    {
       
    }


    private void BindPartNO()
    {
        ds = objserver.GetDateset("select '-Select-' partno,'-Select-' partno union select distinct partno,partno from tbl_PartNo order by 1 desc");


        DropPartNo.DataSource = ds.Tables[0];
        DropPartNo.DataValueField = "PartNo";
        DropPartNo.DataTextField = "PartNo";
        DropPartNo.DataBind();

       
    }
    private void BindOperation()
    {
        ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");

        DropOperation.DataSource = ds.Tables[0];
        DropOperation.DataValueField = "Process";
        DropOperation.DataTextField = "Process";
        DropOperation.DataBind();

       
    }

    protected void SAVE_Click(object sender, EventArgs e)
    {

    }
    private void ClearAll()
    {
        BindPartNO();
        BindOperation();
        TextTt.Text = "";
        TxtPlandClosing.Text = "";
        TxtOpenedTime.Text = "";
        TxtReqtime.Text = "";
        TxtDownTimeLoss.Text = "";
        TxtPlannedStops.Text = "";
        TxtFunctionTime.Text = "";
        TxtSpeedLoss.Text = "";
        TxtNetOpTime.Text = "";
        TxtQualityloss.Text = "";
        TxtUtileTime.Text = "";
        TxtTRS.Text = "";
        TxtTRG.Text = "";
        TxtTotalStop.Text = "";
        TxtTotalStophours.Text = "";
        TxtDateTime.Text = "";
        TxtOperatorName.Text = "";
        txt_machinename.Value = "";
        txt_speedstart.Value = "";
        txt_speedend.Value = "";
        TxtMinorBreakdown.Text = "";
        txt_botstart.Value = "";
        txt_botend.Value = "";
        TxtbottleNeckTime.Text = "";
        TXTPreventive.Text = "";
        Txtbreak.Text = "";
        TxtPlan.Text = "";
        TxtPlannedEngg.Text = "";
        TxtMeetings.Text = "";
        txt_shift.Text = "";
        txt_setup.Text = "";
        TxtProductionQty.Text = "";
        TxtRejection.Text = "";
        TxtCMMInspection.Text = "";
        txt_eqstarttime.Value = "";
        txt_eqendtime.Value = "";
        TxtEquipment.Text = "";
        txt_unstart.Value = "";
        txt_unend.Value = "";
        TxtUnplanned.Text = "";
        txt_setstart.Value = "";
        txt_setend.Value = "";
        TxtChangeOver.Text = "";
        txt_matstart.Value = "";
        txt_matend.Value = "";
        TxtDelay.Text = "";
        txt_opstart.Value = "";
        txt_opend.Value = "";
        TxtOpStortages.Text = "";
        txt_ntstart.Value = "";
        txt_ntend.Value = "";
        TxtNotPlanned.Text = "";
        txt_qstart.Value = "";
        txt_qend.Value = "";
        TxtQtyIssues.Text = "";
        TxtUtilTime.Text = "";
        DropShift.Text = "-Select-";
 
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        conn.Open();
        objefficiency = new EfficiencyReport();
        try
        {

                

            objefficiency.Partno = DropPartNo.SelectedValue.ToString();
            objefficiency.Operation = DropOperation.SelectedValue.ToString();
            objefficiency.EffDate = Convert.ToDateTime(TxtDateTime.Text.ToString());
            objefficiency.Shift = DropShift.SelectedItem.Text.ToString();
            //objefficiency.FromTo = TxtFromTo.Text.ToString();
            objefficiency.FromTo = ddl_fromtime.Value.ToString() + " " + ddl_fromampm.Value.ToString() + " To " + ddl_totime.Value.ToString() + " " + ddl_toampm.Value.ToString();
            objefficiency.OperatorName = TxtOperatorName.Text.ToString();
            objefficiency.MinorStart = txt_speedstart.Value.ToString();
            objefficiency.MinorEnd =txt_speedend.Value.ToString();
           
            string mtotal = TxtMinorBreakdown.Text.ToString();
            if (mtotal == "" || mtotal == null)
            {
                objefficiency.MinorTotal = Convert.ToDecimal(0.00);
            }
            else
            {
                mtotal = mtotal.Replace(":", ".");
                objefficiency.MinorTotal = Convert.ToDecimal(mtotal);
            }
            objefficiency.BottleNectStart = txt_botstart.Value.ToString();
            objefficiency.BottleNectEnd = txt_botend.Value.ToString();
            string btotal = TxtbottleNeckTime.Text.ToString();
            if (btotal == "" || btotal == null)
            {
                objefficiency.BottleNectTotal = Convert.ToDecimal(0.00);
            }
            else
            {
                btotal = btotal.Replace(":", ".");
                objefficiency.BottleNectTotal = Convert.ToDecimal(btotal.ToString());
            }
            if (TXTPreventive.Text.ToString() == "")
            {
                objefficiency.Mainteance = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.Mainteance = Convert.ToDecimal(TXTPreventive.Text.ToString());
            }
            if (Txtbreak.Text.ToString() == "")
            {
                objefficiency.LenchTea = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.LenchTea = Convert.ToDecimal(Txtbreak.Text.ToString());
            }
            if (TxtPlan.Text.ToString() == "")
            {
                objefficiency.NoPlan = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.NoPlan = Convert.ToDecimal(TxtPlan.Text.ToString());
            }
            if (TxtPlannedEngg.Text.ToString() == "")
            {
                objefficiency.Manufacturing = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.Manufacturing = Convert.ToDecimal(TxtPlannedEngg.Text.ToString());
            }
            if (TxtMeetings.Text.ToString() == "")
            {
                objefficiency.Meeting = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.Meeting = Convert.ToDecimal(TxtMeetings.Text.ToString());
            }
            if (txt_shift.Text.ToString() == "")
            {
                objefficiency.ShiftTime = "";
            }
            else
            {
                objefficiency.ShiftTime = txt_shift.Text.ToString();
            }
            if (txt_setup.Text.ToString() == "")
            {
                objefficiency.Setup = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.Setup = Convert.ToDecimal(txt_setup.Text.ToString());
            }
            if (TxtProductionQty.Text.ToString() == "")
            {
                objefficiency.ProdQty = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.ProdQty = Convert.ToDecimal(TxtProductionQty.Text.ToString());
            }
            if (TxtRejection.Text.ToString() == "")
            {
                objefficiency.Rejection = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.Rejection = Convert.ToDecimal(TxtRejection.Text.ToString());
            }
            if (TxtCMMInspection.Text.ToString() == "")
            {
                objefficiency.CMM = Convert.ToDecimal(0.00);
            }
            else
            {
                objefficiency.CMM = Convert.ToDecimal(TxtCMMInspection.Text.ToString());
            }
            objefficiency.EqupStart = txt_eqstarttime.Value.ToString();
            objefficiency.EqupEnd = txt_eqendtime.Value.ToString();
            string teq = TxtEquipment.Text.ToString();
            if (teq == "" || teq == null)
            {
                objefficiency.EqupTotal = Convert.ToDecimal(0.00);
            }
            else
            {
                teq = teq.Replace(":", ".");
                objefficiency.EqupTotal = Convert.ToDecimal(teq);
            }
            objefficiency.UnplannedStart = txt_unstart.Value.ToString();
            objefficiency.UnplannedEnd = txt_unend.Value.ToString();
            string tunplanned = TxtUnplanned.Text.ToString();
            if (tunplanned == "" || tunplanned == null)
            {
                objefficiency.UnplannedTotal = Convert.ToDecimal(0.00);
            }
            else
            {
                tunplanned = tunplanned.Replace(":", ".");
                objefficiency.UnplannedTotal = Convert.ToDecimal(tunplanned);
            }
            objefficiency.SetupStart = txt_setstart.Value.ToString();
            objefficiency.SetupEnd =txt_setend.Value.ToString();
            string tsetup = TxtChangeOver.Text.ToString();
            if (tsetup == "" || tsetup == null)
            {
                objefficiency.SetupTotal = Convert.ToDecimal(0.00);
            }
            else
            {
                tsetup = tsetup.Replace(":", ".");
                objefficiency.SetupTotal = Convert.ToDecimal(tsetup);
            }
            objefficiency.StoragStart = txt_matstart.Value.ToString();
            objefficiency.StoragEnd = txt_matend.Value.ToString();
            string tstorage = TxtDelay.Text.ToString();
            if (tstorage == "" || tstorage == null)
            {
                objefficiency.StoragTotal = Convert.ToDecimal(0.00);
            }
            else
            {
                tstorage = tstorage.Replace(":", ".");
                objefficiency.StoragTotal = Convert.ToDecimal(tstorage);
            }
            objefficiency.MaterialStart = txt_matstart.Value.ToString();
            objefficiency.MaterialEnd = txt_matend.Value.ToString();
            string tmaterial = TxtDelay.Text.ToString();
            if (tmaterial == "" || tmaterial == null)
            {
                objefficiency.MaterialTotal = Convert.ToDecimal(0.00);
            }
            else
            {
                tmaterial = tmaterial.Replace(":", ".");
                objefficiency.MaterialTotal = Convert.ToDecimal(tmaterial);
            }
            objefficiency.StoragStart = txt_opstart.Value.ToString();
            objefficiency.StoragEnd = txt_opend.Value.ToString();
            string tstorage1 = TxtOpStortages.Text.ToString();
            if (tstorage1 == "" || tstorage1 == null)
            {
                objefficiency.StoragTotal = Convert.ToDecimal(0.00);
            }
            else
            {
                tstorage1 = tstorage1.Replace(":", ".");
                objefficiency.StoragTotal = Convert.ToDecimal(tstorage1);
            }
            objefficiency.NTplannedStart =txt_ntstart.Value.ToString();
            objefficiency.NTplannedEnd =txt_ntend.Value.ToString();
            string ntotal = TxtNotPlanned.Text.ToString();
            if (ntotal == "" || ntotal == null)
            {
                objefficiency.NTplannedTotal = Convert.ToDecimal(0.00);
            }
            else
            {
                ntotal = ntotal.Replace(":", ".");
                objefficiency.NTplannedTotal = Convert.ToDecimal(ntotal);
            }
            objefficiency.QualityStart = txt_qstart.Value.ToString();
            objefficiency.QualityEnd = txt_qend.Value.ToString();
            string qtot = TxtQtyIssues.Text.ToString();
            if (qtot == "" || qtot == null)
            {
                objefficiency.QualityTotal = Convert.ToDecimal(0.00);
            }
            else
            {
                qtot = qtot.Replace(":", ".");
                objefficiency.QualityTotal = Convert.ToDecimal(qtot);
            }
            if (TxtUtilTime.Text.ToString() == "")
            {
                objefficiency.UtileTime = Convert.ToDecimal(0.00);
            }

            else
            {
                objefficiency.UtileTime = Convert.ToDecimal(TxtUtilTime.Text.ToString());
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
            ClearAll();
        }
        catch (Exception ex)
        {
        
        }
        finally
        {


           
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
       

    }
    protected void TxtMeetings_TextChanged(object sender, EventArgs e)
    {
        

    }
    protected void TxtQtyIssues_TextChanged(object sender, EventArgs e)
    {


       
    }
    protected void TxtQtyIssues_TextChanged1(object sender, EventArgs e)
    {
        //Calculation();
        if (TxtEquipment.Text != "" && TxtUnplanned.Text != "" && TxtChangeOver.Text != "" && TxtDelay.Text != "" && TxtOpStortages.Text != "" && TxtNotPlanned.Text != "" && TxtQtyIssues.Text != "")
        {
            double k, b, c, d, f, g, h, i;
            string equpment = TxtEquipment.Text.ToString();
            string planned = TxtUnplanned.Text.ToString();
            string changecover = TxtChangeOver.Text.ToString();
            string Delay = TxtDelay.Text.ToString();
            string Stortages = TxtOpStortages.Text.ToString();
            string NotPlanned = TxtNotPlanned.Text.ToString();
            string QtyIssues = TxtQtyIssues.Text.ToString();

            equpment = equpment.Replace(":", ".");
            planned = planned.Replace(":", ".");
            changecover = changecover.Replace(":", ".");
            Delay = Delay.Replace(":", ".");
            Stortages = Stortages.Replace(":", ".");
            NotPlanned = NotPlanned.Replace(":", ".");
            QtyIssues = QtyIssues.Replace(":", ".");

            k = Convert.ToDouble(equpment);
            b = Convert.ToDouble(planned);
            c = Convert.ToDouble(changecover);
            d = Convert.ToDouble(Delay);
            f = Convert.ToDouble(Stortages);
            g = Convert.ToDouble(NotPlanned);
            h = Convert.ToDouble(QtyIssues);
            i = k + b + c + d + f + g + h;
            j = i / 60;
            TxtDownTimeLoss.Text = Convert.ToString(j);
            TxtDownTimeLoss.Text = Math.Round(double.Parse(TxtDownTimeLoss.Text), 0).ToString();
        }
        Calc1();
    }
    protected void TxtbottleNeckTime_TextChanged(object sender, EventArgs e)
    {
       
        if (TxtMinorBreakdown.Text != "" && TxtbottleNeckTime.Text != "")
        {
            double a, b, c, d;
            string minor = TxtMinorBreakdown.Text.ToString();
            string bottle = TxtbottleNeckTime.Text.ToString();
            minor = minor.Replace(":", ".");
            bottle = bottle.Replace(":", ".");
            a = Convert.ToDouble(minor);
            b = Convert.ToDouble(bottle);
            c = a + b;
            d = c / 60;
            TxtSpeedLoss.Text = Convert.ToString(d);
            TxtSpeedLoss.Text = Math.Round(double.Parse(TxtSpeedLoss.Text), 0).ToString();
        }
        Calc1();

    }
    protected void TxtCMMInspection_TextChanged(object sender, EventArgs e)
    {
        
        if (TxtRejection.Text != "" && TxtCMMInspection.Text != "")
        {
            double a, b, c, d;
            a = Convert.ToDouble(TxtRejection.Text);
            b = Convert.ToDouble(TxtCMMInspection.Text);
            c = a + b;
            d = c / 60;
            TxtQualityloss.Text = Convert.ToString(d);
            TxtQualityloss.Text = Math.Round(double.Parse(TxtQualityloss.Text), 0).ToString();
        }
        Calc1();

    }
    protected void TxtUtileTime_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TxtReqtime_TextChanged(object sender, EventArgs e)
    {

        double a3, b3, c3;
        if (TxtUtileTime.Text != "" && TxtReqtime.Text != "")
        {

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

    }
    protected void TxtOpenedTime_TextChanged(object sender, EventArgs e)
    {
        double a, b, c;
        if (TxtUtileTime.Text != "" && TxtOpenedTime.Text != "")
        {

            a = Convert.ToDouble(TxtUtileTime.Text);
            b = Convert.ToDouble(TxtOpenedTime.Text);
            c = (a / b) * 100;
            TxtTRG.Text = Convert.ToString(c);
            TxtTRG.Text = Math.Round(double.Parse(TxtTRG.Text), 0).ToString();
        }
        else
        {
            // Response.Write("Please Enter The Values");
        }

    }

    protected void TxtTotalStop_TextChanged(object sender, EventArgs e)
    {
        Calc1();
      
        
    }

    protected void TxtProductionQty_TextChanged(object sender, EventArgs e)
    {

        if (TXTPreventive.Text != "" && Txtbreak.Text != "" && TxtPlan.Text != "" && TxtPlannedEngg.Text != "" && TxtMeetings.Text != "")
        {
            double a, b, c, d, f, g, h;
            a = Convert.ToDouble(TXTPreventive.Text);
            b = Convert.ToDouble(Txtbreak.Text);
            c = Convert.ToDouble(TxtPlan.Text);
            d = Convert.ToDouble(TxtPlannedEngg.Text);
            f = Convert.ToDouble(TxtMeetings.Text);
            g = a + b + c + d + f;
            h = g / 60;
            TxtPlannedStops.Text = Convert.ToString(h);
            TxtPlannedStops.Text = Math.Round(double.Parse(TxtPlannedStops.Text), 0).ToString();

        }
        double h1, f1, g1;
        if (TxtProductionQty.Text != "")
        {
            h1 = Convert.ToDouble(TxtProductionQty.Text);
            f1 = tt;
            g1 = h1 * f1 / 60;
            TxtUtilTime.Text = Convert.ToString(g1);
            TxtUtilTime.Text = Math.Round(double.Parse(TxtUtilTime.Text), 0).ToString();
        }
        else
        {

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter The Bottle Neck Time In Time Master');", true);
        }
        Calc1();
    }
    protected void DropOperation_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBServer Db = new DBServer();
        DataSet ds = new DataSet();
       
        Db.PartNo = DropPartNo.SelectedItem.Text;
        Db.Process = DropOperation.SelectedItem.Text;
        ds = Db.ViewTimeMasterByQry(Db);
        if (ds.Tables[0].Rows.Count > 0)
        {
            tt = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[0].ToString());

            s = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[1].ToString());
            TextTt.Text = Convert.ToString(s);
        }
            ds=new DataSet ();
        Db.PartNo = DropPartNo.SelectedItem.Text;
        Db.Process = DropOperation.SelectedItem.Value.ToString();
        ds = Db.ViewTimePlanned(Db);
        if (ds.Tables[0].Rows.Count > 0)
        {
            TXTPreventive.Text = ds.Tables[0].Rows[0]["Maintenance"].ToString();
            int tea = Convert.ToInt32(ds.Tables[0].Rows[0]["LunchTime"].ToString()) + Convert.ToInt32(ds.Tables[0].Rows[0]["TeaTime"].ToString());
            Txtbreak.Text = tea.ToString();
            TxtPlan.Text = ds.Tables[0].Rows[0]["PlanTime"].ToString();
            TxtPlannedEngg.Text = ds.Tables[0].Rows[0]["Manufacturing"].ToString();
            TxtMeetings.Text = ds.Tables[0].Rows[0]["Meeting"].ToString();
            txt_setup.Text = ds.Tables[0].Rows[0]["Setup"].ToString();
            txt_shift.Text = ds.Tables[0].Rows[0]["ShiftTime"].ToString();
          //  ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "getRejection();", true);
        }
        else
        {
            TXTPreventive.Text = "";
            Txtbreak.Text = "";
            TxtPlan.Text = "";
            TxtPlannedEngg.Text = "";
            TxtMeetings.Text = "";
            txt_setup.Text = "";
            txt_shift.Text = "";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter The Bottle Neck Time In Time Master');", true);
        }

    }
    protected void TxtUtilTime_TextChanged(object sender, EventArgs e)
    {
        Calculation();

    }

    private void Calc()
    {


    }
    protected void DropPartNo_SelectedIndexChanged(object sender, EventArgs e)
    {

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
        if (TxtTotalStop.Text != "" && TxtUtilTime.Text != "")
        {
            double d, f, g;

            d = Convert.ToDouble(TxtTotalStop.Text);
            f = Convert.ToDouble(TxtUtilTime.Text);
            g = (d + f);
            TxtTotalStophours.Text = Convert.ToString(g);
            TxtTotalStophours.Text = Math.Round(double.Parse(TxtTotalStophours.Text), 0).ToString();
        }

        if (TextTt.Text != "" && TxtUtilTime.Text != "")
        {
            double a, b, c;
            a = Convert.ToDouble(TextTt.Text);
            b = Convert.ToDouble(TxtUtilTime.Text);
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
        if (TxtUtilTime.Text != "" && TxtQualityloss.Text != "")
        {
            double a, b, c;
            a = Convert.ToDouble(TxtUtilTime.Text);
            b = Convert.ToDouble(TxtQualityloss.Text);
            c = a + b;
            TxtNetOpTime.Text = Convert.ToString(c);
            TxtNetOpTime.Text = Math.Round(double.Parse(TxtNetOpTime.Text), 0).ToString();

        }

        if (TxtUtilTime.Text != "")
        {
            TxtUtileTime.Text = Convert.ToString(TxtUtilTime.Text);
            TxtUtileTime.Text = Math.Round(double.Parse(TxtUtilTime.Text), 0).ToString();
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
            double a4, b4, c4;
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
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Calculation();
    }
    private void Calculation()
    {
        if (TXTPreventive.Text != "" && Txtbreak.Text != "" && TxtPlan.Text != "" && TxtPlannedEngg.Text != "" && TxtMeetings.Text != "")
        {
            double a, b, c, d, f, g, h;
            a = Convert.ToDouble(TXTPreventive.Text);
            b = Convert.ToDouble(Txtbreak.Text);
            c = Convert.ToDouble(TxtPlan.Text);
            d = Convert.ToDouble(TxtPlannedEngg.Text);
            f = Convert.ToDouble(TxtMeetings.Text);
            g = a + b + c + d + f;
            h = g / 60;
            TxtPlannedStops.Text = Convert.ToString(h);
            TxtPlannedStops.Text = Math.Round(double.Parse(TxtPlannedStops.Text), 0).ToString();

            //  TxtPlannedStops.Text = Convert.ToString(h);
            //TxtPlannedStops.Text = Math.Round(double.Parse(TxtPlannedStops.Text), 0).ToString();
            //  TxtPlannedStops.Text = Math.Round(h,3);

            // TxtPlannedStops.Text = Math.Pow(2, Convert.ToDouble(h));
        }

        if (TxtEquipment.Text != "" && TxtUnplanned.Text != "" && TxtChangeOver.Text != "" && TxtDelay.Text != "" && TxtOpStortages.Text != "" && TxtNotPlanned.Text != "" && TxtQtyIssues.Text != "")
        {
            double k, b, c, d, f, g, h, i;
            string equpment = TxtEquipment.Text.ToString();
            string planned = TxtUnplanned.Text.ToString();
            string changecover = TxtChangeOver.Text.ToString();
            string Delay = TxtDelay.Text.ToString();
            string Stortages = TxtOpStortages.Text.ToString();
            string NotPlanned = TxtNotPlanned.Text.ToString();
            string QtyIssues = TxtQtyIssues.Text.ToString();

            equpment = equpment.Replace(":", ".");
            planned = planned.Replace(":", ".");
            changecover = changecover.Replace(":", ".");
            Delay = Delay.Replace(":", ".");
            Stortages = Stortages.Replace(":", ".");
            NotPlanned = NotPlanned.Replace(":", ".");
            QtyIssues = QtyIssues.Replace(":", ".");

            k = Convert.ToDouble(equpment);
            b = Convert.ToDouble(planned);
            c = Convert.ToDouble(changecover);
            d = Convert.ToDouble(Delay);
            f = Convert.ToDouble(Stortages);
            g = Convert.ToDouble(NotPlanned);
            h = Convert.ToDouble(QtyIssues);
            i = k + b + c + d + f + g + h;
            j = i / 60;
            TxtDownTimeLoss.Text = Convert.ToString(j);
            TxtDownTimeLoss.Text = Math.Round(double.Parse(TxtDownTimeLoss.Text), 0).ToString();
        }

        if (TxtMinorBreakdown.Text != "" && TxtbottleNeckTime.Text != "")
        {
            double a, b, c, d;
            string minor = TxtMinorBreakdown.Text.ToString();
            string bottle = TxtbottleNeckTime.Text.ToString();
            minor = minor.Replace(":", ".");
            bottle = bottle.Replace(":", ".");
            a = Convert.ToDouble(minor);
            b = Convert.ToDouble(bottle);
            c = a + b;
            d = c / 60;
            TxtSpeedLoss.Text = Convert.ToString(d);
            TxtSpeedLoss.Text = Math.Round(double.Parse(TxtSpeedLoss.Text), 0).ToString();
        }

        if (TxtRejection.Text != "" && TxtCMMInspection.Text != "")
        {
            double a, b, c, d;
            a = Convert.ToDouble(TxtRejection.Text);
            b = Convert.ToDouble(TxtCMMInspection.Text);
            c = a + b;
            d = c / 60;
            TxtQualityloss.Text = Convert.ToString(d);
            TxtQualityloss.Text = Math.Round(double.Parse(TxtQualityloss.Text), 0).ToString();
        }

        double h1, f1, g1;
        if (TxtProductionQty.Text != "")
        {
            h1 = Convert.ToDouble(TxtProductionQty.Text);
            f1 = tt;
            g1 = h1 * f1 / 60;
            TxtUtilTime.Text = Convert.ToString(g1);
            TxtUtilTime.Text = Math.Round(double.Parse(TxtUtilTime.Text), 0).ToString();
        }
        else
        {

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter The Bottle Neck Time In Time Master');", true);
        }


        
        Calc1();

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Calculation();
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        Calculation();
    }
    protected void TextTt_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TxtTotalStophours_TextChanged(object sender, EventArgs e)
    {
        Calc1();
        
    }
    protected void TxtPlantClosing_TextChanged(object sender, EventArgs e)
    {
        Calc1();

    }
    protected void TxtPlannedStops_TextChanged(object sender, EventArgs e)
    {
        Calc1();
    }
    protected void TxtDownTimeLoss_TextChanged(object sender, EventArgs e)
    {
        Calc1();
    }
    protected void TxtFunctionTime_TextChanged(object sender, EventArgs e)
    {
        Calc1();
    }
    protected void TxtSpeedLoss_TextChanged(object sender, EventArgs e)
    {
        Calc1();
    }
    protected void TxtNetOpTime_TextChanged(object sender, EventArgs e)
    {
        Calc1();

    }
    protected void TxtQualityloss_TextChanged(object sender, EventArgs e)
    {
        Calc1();
    }
    protected void TxtTRS_TextChanged(object sender, EventArgs e)
    {
        Calc1();
    }
    protected void TxtTRG_TextChanged(object sender, EventArgs e)
    {
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
    protected void Button2_Click(object sender, EventArgs e)
    {
      
    }
    
    protected void DropShift_SelectedIndexChanged(object sender, EventArgs e)
    { 
    }
    protected void img_templage_Click(object sender, ImageClickEventArgs e)
    {
    }
}