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

public partial class HourlyProduction : System.Web.UI.Page
{
    public static double b;
    public static double a;
    public static double c;
    public static double d;
    DBServer objserver = new DBServer();
    private String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindOperation();
            BindOperation1();
            BindPartNO();
            TxtDate.Text = System.DateTime.Now.ToString();
        }

    }

    private void BindOperation()
    {

        ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");

        DropFirstSetUp.DataSource = ds.Tables[0];
        DropFirstSetUp.DataValueField = "Process";
        DropFirstSetUp.DataTextField = "Process";
        DropFirstSetUp.DataBind();



    }
    private void BindOperation1()
    {

        ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");

        DropSecondSetUp.DataSource = ds.Tables[0];
        DropSecondSetUp.DataValueField = "Process";
        DropSecondSetUp.DataTextField = "Process";
        DropSecondSetUp.DataBind();


    }

    //private void BindPartNO()
    //{

    //    DBServer db = new DBServer();
    //    DataSet ds = new DataSet();
    //    ds = db.ViewAllPartNo(db);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {

    //        DropPartNo.DataSource = ds.Tables[0];
    //        DropPartNo.DataValueField = "partno";
    //        DropPartNo.DataTextField = "partno";
    //        DropPartNo.DataBind();
    //    }

    //}

    private void BindPartNO()
    {

        ds = objserver.GetDateset("select '-Select-' partno,'-Select-' partno union select distinct partno,partno from tbl_PartNo order by 1 desc");
        DropPartNo.DataSource = ds.Tables[0];
        DropPartNo.DataValueField = "partno";
        DropPartNo.DataTextField = "partno";
        DropPartNo.DataBind();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        conn.Open();
        try
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                if (TxtOperatorName.Text != "")
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Inserthourlyproduction";
                    cmd.Parameters.AddWithValue("@operatorname", TxtOperatorName.Text);
                    cmd.Parameters.AddWithValue("@shift", TxtShift.Text);
                    cmd.Parameters.AddWithValue("@date", TxtDate.Text);
                    cmd.Parameters.AddWithValue("@area", TxtArea.Text);
                    cmd.Parameters.AddWithValue("@from", TxtFrom.Text);
                    cmd.Parameters.AddWithValue("@to", TxtTo.Text);
                    cmd.Parameters.AddWithValue("@firstsetup", DropFirstSetUp.Text);
                    cmd.Parameters.AddWithValue("@secondsetuo", DropSecondSetUp.Text);
                    cmd.Parameters.AddWithValue("@producedqtyhour", TxtProducedQty.Text);
                    cmd.Parameters.AddWithValue("@producedqtytotal", TxtProducedQty1.Text);
                    cmd.Parameters.AddWithValue("@man", TxtMan.Text);
                    cmd.Parameters.AddWithValue("@material", TxtMaterial.Text);
                    cmd.Parameters.AddWithValue("@machine", TxtMachine.Text);
                    cmd.Parameters.AddWithValue("@environment", TxtEnvironment.Text);
                    cmd.Parameters.AddWithValue("@others", TxtOthers.Text);
                    cmd.Parameters.AddWithValue("@downtimedetails", TxtDownTimeDetails.Text);
                    cmd.Parameters.AddWithValue("@rejectionpartdetails", TxtRejectionPart.Text);
                    cmd.Parameters.AddWithValue("@specialcommunications", TxtCommunication.Text);
                    cmd.Parameters.AddWithValue("@sno", TxtSno.Text);
                    cmd.Parameters.AddWithValue("@PartNo", DropPartNo.Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Saved Successfully');", true);
                    ClearAll();



                    //ClearAll();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter The Details');", true);
                }
            }
        }
        catch (Exception ex)
        {
            lblresult.Text = ex.Message;
            if (lblresult.Text != "Please Enter The Correct Details")
            {

                //  lblresult.Text = "Please Enter The Correct Details";
                lblresult.Text = System.Drawing.Color.Bisque.ToString();
            }
        }
    }
    private void ClearAll()
    {
        TxtOperatorName.Text = "";
        TxtShift.Text = "";
        TxtDate.Text = System.DateTime.Now.ToString();
        TxtArea.Text = "";
        TxtFrom.Text = "";
        TxtTo.Text = "";
        TxtProducedQty.Text = "0.00";
        TxtProducedQty1.Text = "0";
        TxtMan.Text = "0.00";
        TxtMaterial.Text = "0.00";
        TxtMachine.Text = "0.00";
        TxtEnvironment.Text = "0.00";
        TxtOthers.Text = "0.00";
        TxtDownTimeDetails.Text = "";
        TxtRejectionPart.Text = "";
        TxtCommunication.Text = "";
        TxtSno.Text = "0";
        DropFirstSetUp.Text ="-Select-";
        DropSecondSetUp.Text = "-Select-";
        DropPartNo.Text = "-Select-";
        TxtShift.Text = "-Select-";
       
        a = '0';
        b = '0';
        c = '0';
        d = '0';


    }

    protected void DropPartNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewTotQTybyPartNO();

    }

    private void ViewTotQTybyPartNO()
    {
        a = '0';
        if (DropPartNo.Text != "")
        {
            DBServer Db = new DBServer();
            DataSet ds = new DataSet();
            Db.PartNo = DropPartNo.Text;
            ds = Db.ViewTotQtybyPartnos(Db);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
                {
                    a = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                    TxtProducedQty1.Text = Convert.ToString(a);
                }
                //b =  TxtProducedQty.Text;
                //c = a + b;
                else
                {
                    a = '0';
                    TxtProducedQty1.Text = "0";
                }

            }
            else
            {

            }
        }

    }

    protected void TxtProducedQty_TextChanged(object sender, EventArgs e)
    {
        if (TxtProducedQty.Text != "" && TxtProducedQty1.Text != "")
        {


            //b = Convert.ToDouble(TxtProducedQty.Text);
            //c = Convert.ToDouble(TxtProducedQty1.Text) + b;
            //c = a + b;
            //TxtProducedQty1.Text = Convert.ToString(c);

            b = Convert.ToDouble(TxtProducedQty.Text);
            c = Convert.ToDouble(TxtProducedQty1.Text);
            d = b + c;
            TxtProducedQty1.Text = Convert.ToString(d);
        }
    }
    protected void DropPartNo_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ViewTotQTybyPartNO();
    }
    protected void DropPartNo_TextChanged(object sender, EventArgs e)
    {
        ViewTotQTybyPartNO();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        conn.Open();
        try
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                if (TxtOperatorName.Text != "")
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Inserthourlyproduction";
                    cmd.Parameters.AddWithValue("@operatorname", TxtOperatorName.Text);
                    cmd.Parameters.AddWithValue("@shift", TxtShift.Text);
                    cmd.Parameters.AddWithValue("@date", TxtDate.Text);
                    cmd.Parameters.AddWithValue("@area", TxtArea.Text);
                    cmd.Parameters.AddWithValue("@from", TxtFrom.Text);
                    cmd.Parameters.AddWithValue("@to", TxtTo.Text);
                    cmd.Parameters.AddWithValue("@firstsetup", DropFirstSetUp.Text);
                    cmd.Parameters.AddWithValue("@secondsetuo", DropSecondSetUp.Text);
                    cmd.Parameters.AddWithValue("@producedqtyhour", TxtProducedQty.Text);
                    cmd.Parameters.AddWithValue("@producedqtytotal", TxtProducedQty1.Text);
                    cmd.Parameters.AddWithValue("@man", TxtMan.Text);
                    cmd.Parameters.AddWithValue("@material", TxtMaterial.Text);
                    cmd.Parameters.AddWithValue("@machine", TxtMachine.Text);
                    cmd.Parameters.AddWithValue("@environment", TxtEnvironment.Text);
                    cmd.Parameters.AddWithValue("@others", TxtOthers.Text);
                    cmd.Parameters.AddWithValue("@downtimedetails", TxtDownTimeDetails.Text);
                    cmd.Parameters.AddWithValue("@rejectionpartdetails", TxtRejectionPart.Text);
                    cmd.Parameters.AddWithValue("@specialcommunications", TxtCommunication.Text);
                    cmd.Parameters.AddWithValue("@sno", TxtSno.Text);
                    cmd.Parameters.AddWithValue("@partno", DropPartNo.Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Saved Successfully');", true);
                    ClearAll();



                    //ClearAll();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter The Details');", true);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }
}