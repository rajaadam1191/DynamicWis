using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DL_Machine
/// </summary>
public class DL_Machine
{
    public static string Constr = System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ToString();
    SqlConnection con = new SqlConnection(Constr);

    public int BulkInsert(BL_Machine objBL_Mac)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Machine", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mode", SqlDbType.NVarChar, 100).Value = objBL_Mac.Mode;
            cmd.Parameters.Add("@ByExcel", SqlDbType.NVarChar, 8000).Value = objBL_Mac.ByExcel;
            int res=cmd.ExecuteNonQuery();
            return res;
            con.Close();
        }
        catch (Exception ex)
        {
            return 0;
        }
        
    }
    public DataSet BulkInsert1(BL_Machine objBL_Mac)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Machine1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mode", SqlDbType.NVarChar, 100).Value = objBL_Mac.Mode;
            cmd.Parameters.Add("@ByExcel", SqlDbType.NVarChar, 8000).Value = objBL_Mac.ByExcel;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            //int res = cmd.ExecuteNonQuery();
            return ds;
            con.Close();
        }
        catch (Exception ex)
        {
            return null;
        }

    }
    public DataSet getMacRecords(BL_Machine objBL_Mac)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Machine", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mode", SqlDbType.NVarChar, 100).Value = objBL_Mac.Mode;
            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds1);
            return ds1;
        }
        catch (Exception ex)
        {
            return null;
        }
       
    }

	public DL_Machine()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
