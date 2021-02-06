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
using System.Windows.Forms;

public partial class Master_DynMasterDel : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public DBServer objserver = new DBServer();
    public DataSet ds;
    public Object thisLock = new Object();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "")
            {
                BindPartNO();
                BindOperation();
                BindCell();
            }
            else
            {
                HttpContext.Current.Response.Write("else part");
                Response.Redirect("../Home.aspx", false);
            }

        }
    }
    private void BindPartNO()
    {
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        ds = objserver.GetDateset("select '-Select-' PartNo union select distinct PartNo from tbl_PartNo order by PartNo asc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            dy_del_partno.DataSource = ds.Tables[0];
            dy_del_partno.DataValueField = "partNo";
            dy_del_partno.DataTextField = "partNo";
            dy_del_partno.DataBind();
        }
    }
    private void BindOperation()
    {
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        ds = objserver.GetDateset("select 0 PID ,'-Select-' Process union select distinct PID,Process from tbl_Process order by PID asc");

        dy_del_operation.DataSource = ds.Tables[0];
        dy_del_operation.DataValueField = "Process";
        dy_del_operation.DataTextField = "Process";
        dy_del_operation.DataBind();

    }
    private void BindCell()
    {
        //ds = objserver.GetDateset("select '-Select-' partno,'-Select-' partno union select distinct partno,partno from tbl_PartNo order by 1 asc");
        ds = new DataSet();
        ds.Tables.Clear();
        ds.Clear();
        ds.Reset();
        ds = objserver.GetDateset("select 0 Id ,'-Select-' Cell union select distinct Id,Cell from Cell order by Id asc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            dy_del_cell.DataSource = ds.Tables[0];
            dy_del_cell.DataValueField = "Cell";
            dy_del_cell.DataTextField = "Cell";
            dy_del_cell.DataBind();
        }
    }
    public void btn_Del_Click(object sender, EventArgs e)
    {
        lock (thisLock)
        {
            //if (MessageBox.Show("Are you sure you want to delete this event?", "Confirm delete", MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.ServiceNotification) == DialogResult.Yes)
            //{
                string Cell = dy_del_cell.Value.ToString();
                string Partno = dy_del_partno.Value.ToString();
                string Operation = string.Empty;
                if (dy_del_operation.Value.ToString() == "OP1")
                {
                    Operation = "1";
                }
                else if (dy_del_operation.Value.ToString() == "OP2")
                {
                    Operation = "2";
                }
                else
                {
                    Operation = dy_del_operation.Value.ToString();
                }
                try
                {
                    strConnString.Close();
                    strConnString.Open();

                    string CheckTabName = "QualitySheet_" + Cell + "_" + Partno.ToString() + "_" + Operation.ToString() + "";

                    string str11 = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + CheckTabName + "'";
                    SqlCommand myCommand = new SqlCommand(str11, strConnString);
                    SqlDataReader myReader = null;
                    int count = 0;

                    try
                    {
                        //if (strConnString.State == ConnectionState.Open)
                        //{
                        //    strConnString.Close();
                        //}
                        //strConnString.Open();
                        strConnString.Close();
                        strConnString.Open();
                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                            count++;

                        myReader.Close();
                        strConnString.Close();

                    }
                    catch (Exception ex) { }
                    if (count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Quality Sheet not created for " + Partno.ToString() + "_" + Operation.ToString() + "_" + Cell.ToString() + " ');", true);
                        clear();
                    }
                    else
                    {
                        ds = objserver.GetDateset("Select * from Dynmaster where partno='" + Partno.ToString() + "' and Operation='" + Operation.ToString() + "' and Cell='" + Cell.ToString() + "'; Select * from DynmasterValues where partno='" + Partno.ToString() + "' and Operation='" + Operation.ToString() + "' and Cell='" + Cell.ToString() + "';Select * from " + CheckTabName.ToString() + " ");
                        if (ds.Tables[2].Rows.Count == 0)
                        {
                            //ds = objserver.GetDateset("delete from Dynmaster where partno='" + Partno.ToString() + "' and Operation='" + Operation.ToString() + "' and Cell='" + Cell.ToString() + "' ");
                            //ds = objserver.GetDateset("delete from DynmasterValues where partno='" + Partno.ToString() + "' and Operation='" + Operation.ToString() + "' and Cell='" + Cell.ToString() + "' ");

                            SqlCommand valcmd = new SqlCommand("savedroptable", strConnString);
                            valcmd.CommandType = CommandType.StoredProcedure;

                            valcmd.Parameters.Add("@Partno", SqlDbType.VarChar, -1).Value = Partno.ToString();
                            valcmd.Parameters.Add("@Operation", SqlDbType.VarChar, -1).Value = Operation.ToString();
                            valcmd.Parameters.Add("@Cell", SqlDbType.VarChar, -1).Value = Cell.ToString();
                            valcmd.Parameters.Add("@TableName", SqlDbType.VarChar, -1).Value = CheckTabName.ToString();
                            valcmd.Parameters.Add("@username", SqlDbType.VarChar, -1).Value = HttpContext.Current.Session["User_Name"].ToString();
                            strConnString.Open();
                            valcmd.ExecuteNonQuery();
                            strConnString.Close();

                            ds = objserver.GetDateset("drop table " + CheckTabName.ToString() + " ");
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Deleted Succesfully');", true);
                            clear();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Cannot Delete the " + Partno.ToString() + "_" + Operation.ToString() + "_" + Cell.ToString() + "- Quality Sheet has so many Entries');", true);
                            clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    strConnString.Close();
                }
            //}
        }
    }

    public void clear()
    {
        dy_del_partno.Value = "-Select-";
        dy_del_operation.Value = "-Select-";
        dy_del_cell.Value = "-Select-";
    }
}
