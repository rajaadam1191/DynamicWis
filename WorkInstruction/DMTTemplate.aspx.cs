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

public partial class DMTTemplate : System.Web.UI.Page
{
    DBServer objserver = new DBServer();
    private String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    DataSet ds, ds1;
    public static Object thisLock = new Object();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BindData();
            BindPartNO();
            BindOperation();
            CreateDate.Text =DateTime.Now.ToShortDateString().ToString();
            RevisionDate.Text = DateTime.Now.ToShortDateString().ToString();

        }
    }

    private void BindData()
    {
        lock (thisLock)
        {

            try
            {
                ds = objserver.GetDateset("ViewAllDMTTemplate");

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }


    protected void Delete(object sender, EventArgs e)
    {
        lock (thisLock)
        {

            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    objserver.GetDateset("delete from tblVisitor where VID=" + Convert.ToDecimal(GridView1.DataKeys[row.DataItemIndex].Value) + "");
                }
                ds = objserver.GetDateset("SelectVisitor");
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
      //  popup.Show();
    }
    private void BindPartNO()
    {
        lock (thisLock)
        {

            try
            {
                //   ds = objserver.GetDateset("select '0' id,'-Select-' PartNo union select distinct id,PartNo from tbl_PartNo order by id");
                ds = objserver.GetDateset("select '-Select-' partno,'-Select-' partno union select distinct partno,partno from tbl_PartNo order by 1 desc");


                txtSpecificpartcommon.DataSource = ds.Tables[0];
                txtSpecificpartcommon.DataValueField = "PartNo";
                txtSpecificpartcommon.DataTextField = "PartNo";
                txtSpecificpartcommon.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }

            //DropPartNo.DataValueField = "id";
            //DropPartNo.DataTextField = "PartNo";
            //DropPartNo.DataBind();
        }
    }
    private void BindOperation()
    {
        lock (thisLock)
        {

            try
            {
                //ds = objserver.GetDateset("select '0' PID,'-Select-' Process union select distinct PID,Process from tbl_Process order by PID");
                ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");

                Operation.DataSource = ds.Tables[0];
                Operation.DataValueField = "Process";
                Operation.DataTextField = "Process";
                Operation.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }

            //DropOperation.DataValueField = "PID";
            //DropOperation.DataTextField = "Process";
            //DropOperation.DataBind();
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        conn.Open();
        lock (thisLock)
        {

            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    if (txtdocref.Text != "" && txtfunctioninchargeof.Text != "" && txtfunctioninchrge.Text != "" && txtauthorized.Text != "")
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dmttemplate";

                        cmd.Parameters.AddWithValue("@doc_ref", txtdocref.Text);


                        cmd.Parameters.AddWithValue("@rev", txtrev.Text);


                        cmd.Parameters.AddWithValue("@businessunit", txtBusiness.Text);


                        cmd.Parameters.AddWithValue("@parttype", Parttype.Text);
                        cmd.Parameters.AddWithValue("@operation", Operation.Text);
                        cmd.Parameters.AddWithValue("@specificpartorcommon", txtSpecificpartcommon.Text);
                        cmd.Parameters.AddWithValue("@typeofdocument", Typeofdocument.Text);
                        cmd.Parameters.AddWithValue("@creationdate", CreateDate.Text);
                        cmd.Parameters.AddWithValue("@revisiondate", RevisionDate.Text);
                        cmd.Parameters.AddWithValue("@status", Status.Text);
                        cmd.Parameters.AddWithValue("@comments", Comments.Text);
                        cmd.Parameters.AddWithValue("@functioninchargeoffilling", txtfunctioninchargeof.Text);
                        cmd.Parameters.AddWithValue("@paperfilling", paper.Text);

                        cmd.Parameters.AddWithValue("@durationoffilling", txtdurationoffilling.Text);


                        cmd.Parameters.AddWithValue("@storageplacefilling", txtstorageplace.Text);


                        cmd.Parameters.AddWithValue("@electronicsfilling", txtelectronic.Text);
                        cmd.Parameters.AddWithValue("@methodoffilling", methodoffilling.Text);
                        cmd.Parameters.AddWithValue("@protectagainstwaterfilling", txtmethodofwater.Text);
                        cmd.Parameters.AddWithValue("@functioninchargeof", txtfunctioninchargeof.Text);
                        cmd.Parameters.AddWithValue("@paper", txtpaper.Text);
                        cmd.Parameters.AddWithValue("@electronics", txtelectronics.Text);
                        cmd.Parameters.AddWithValue("@durationofarchiving", txtdurationofarchiving.Text);
                        cmd.Parameters.AddWithValue("@archivingplace", txtarchivingplace.Text);
                        //cmd.Parameters.AddWithValue("@protectagainstwaterfilling", methodofwater.Text);

                        cmd.Parameters.AddWithValue("@authorized", txtauthorized.Text);
                        cmd.Parameters.AddWithValue("@notauthorized", txtnotauthorized.Text);
                        cmd.Parameters.AddWithValue("@functioninchargeofdestruction", txtfunctioninchargeof.Text);
                        cmd.Parameters.AddWithValue("@methodofdestruction", txtmethodofdestruction.Text);
                        //GridView1.DataSource = this.GetData(cmd);

                        cmd.ExecuteNonQuery();
                        Clear();
                        GridView1.DataBind();
                        ds = objserver.GetDateset("ViewAllDMTTemplate");

                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Saved Successfully');", true);
                        popup.Hide();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter The Details');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                lblresult.Text = ex.Message;
                if (lblresult.Text == "An invalid parameter or option was specified for procedure 'MobileNo already Exists'.")
                {

                    lblresult.Text = "MobileNo already Exists";
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        popup.Show();
      
        
    }

    private void Clear()
    {
        txtdocref.Text = "";
        txtrev.Text = "";
        Parttype.Text = "";
        Operation.Text = "-Select-";
        txtSpecificpartcommon.Text = "-Select-";
        Typeofdocument.Text = "";
        Status.Text = "";
        Comments.Text = "";
        txtfunctionincharge.Text = "";
        txtfunctioninchargeof.Text = "";
        paper.Text = "";
        txtelectronic.Text = "";
        txtelectronics.Text = "";
        txtdurationoffilling.Text = "";
        txtstorageplace.Text = "";
        methodoffilling.Text = "";
        txtmethodofwater.Text = "";
        txtpaper.Text="";
        txtdurationofarchiving.Text = "";
        txtarchivingplace.Text = "";
        txtmethodofwater.Text = "";
        txtauthorized.Text = "";
        txtnotauthorized.Text = "";
        txtmethodofdestruction.Text = "";
        methodoffilling.Text = "";
        txtfunctionincharge.Text = "";
        txtmethodwater.Text = "";
        txtfunctioninchrge.Text = "";
        txtBusiness.Text = "";


    }
}
