using System;
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
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;

using System.Collections.Generic;



public partial class PartNoMaster : System.Web.UI.Page 
{
    QualitySheetdclassDataContext conLinq = new QualitySheetdclassDataContext("Data Source=HOME;Initial Catalog=DBWIS;Integrated Security=true");

    BL_Machine objBL_Mac;
    DL_Machine objDL_Mac;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            objBL_Mac = new BL_Machine();
            objDL_Mac = new DL_Machine();
            string FullPath = Server.MapPath(FileUpload1.FileName);
            string MyPath = System.IO.Path.GetDirectoryName(FullPath);
            string myFilename = System.IO.Path.GetFileName(FullPath);
             string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FullPath +
              ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\""; 
            int SQlResult = objDL_Mac.BulkInsert(objBL_Mac);

            string query = "SELECT [Partno] FROM [Sheet1$]";
            OleDbConnection conn = new OleDbConnection(connString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            objBL_Mac.Mode = "ExcelUpload";
            objBL_Mac.ByExcel = ds.GetXml();
            grdMac.DataSource = ds.Tables[0];
            grdMac.DataBind();
           
            da.Dispose();
            conn.Close();
            conn.Dispose();
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        //try
        //{
        //    objBL_Mac = new BL_Machine();
        //    objDL_Mac = new DL_Machine();
        //    //string connString = "";
          
           
        //    //
        //    //string FullPath = "C:\\Users\\System06\\Desktop\\Machinecode.xlsx";
        //    if (FileUpload1.HasFile)
        //    {
        //        string FullPath = Server.MapPath(FileUpload1.FileName);
        //        string MyPath = System.IO.Path.GetDirectoryName(FullPath);
        //        string myFilename = System.IO.Path.GetFileName(FullPath);
        //        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FullPath +
        //          ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
               

        //        string query = "SELECT [Machine Code] FROM [Sheet1$]";
        //        OleDbConnection conn = new OleDbConnection(connString);
        //        //if (conn.State == ConnectionState.Closed)
        //        OleDbCommand cmd = new OleDbCommand(query, conn);
        //        conn.Open();
        //        OleDbDataAdapter da = new OleDbDataAdapter(cmd);

        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        objBL_Mac.Mode = "ExcelUpload";
        //        objBL_Mac.ByExcel = ds.GetXml();
        //        grdMac.DataSource = ds.Tables[0];
        //        grdMac.DataBind();

        //        int SQlResult = objDL_Mac.BulkInsert(objBL_Mac);

        //        da.Dispose();
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Ofarticle file !');", true);
        //    }
        //}
        //catch (Exception ex)
        //{

        //}
        //finally
        //{

        //}
        string fileName = FileUpload1.ResolveClientUrl(FileUpload1.PostedFile.FileName);
        int count = 0;
        QualitySheetdclassDataContext conLinq = new QualitySheetdclassDataContext("Data Source=HOME;Initial Catalog=DBWIS;Integrated Security=true");
        try
        {
            DataTable dtExcel = new DataTable();
            string SourceConstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName + "';Extended Properties= 'Excel 8.0;HDR=Yes;IMEX=1'";
            OleDbConnection con = new OleDbConnection(SourceConstr);
            string query = "Select Partno,Description from [Sheet1$]";
            OleDbDataAdapter data = new OleDbDataAdapter(query, con);
            data.Fill(dtExcel);
            for (int i = 1; i < dtExcel.Rows.Count; i++)
            {
                try
                {
                    count += conLinq.ExecuteCommand("insert into tbl_PartNo(PartNo,Description)values(" + dtExcel.Rows[i]["PartNo"] + "," + dtExcel.Rows[i]["Description"] + ") ");
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            if (count == dtExcel.Rows.Count)
            {

            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conLinq.Dispose();
        }

    }

}
