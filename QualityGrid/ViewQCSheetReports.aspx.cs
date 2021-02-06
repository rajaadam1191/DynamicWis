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
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.Excel;
//using Microsoft.Office;
//using Microsoft.Office.Interop.Word;

public partial class ViewQCSheetReports : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public SqlCommand cmd;
    public DataSet ds;
    public SqlDataAdapter da;
    public int rowcount = 0;
    public string strPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User_ID"] != null && Session["User_ID"].ToString() != "")
            {
                loadcell();
                load_operator();
                BindPart();
                BindProcess();
                txt_fromdate.Value = DateTime.Now.ToShortDateString().ToString();
                txt_todate.Value = DateTime.Now.ToShortDateString().ToString();
            }
            else
            {
                Response.Redirect("../Home.aspx");
            }

        }

    }
    protected void ddl_prodn_no_SelectedIndexChanged(object sender, EventArgs e)
    {

        string prodn_no = ddl_prodn_no.SelectedValue.ToString();
        if (ddl_prodn_no.SelectedValue.ToString() == "A17724Q" || ddl_prodn_no.SelectedValue.ToString() == "A22916J" || ddl_prodn_no.SelectedValue.ToString() == "A44908N" || ddl_prodn_no.SelectedValue.ToString() == "A44983U" || ddl_prodn_no.SelectedValue.ToString() == "A32271C")
        {
            if (ddl_prodn_no.SelectedValue.ToString() == "A17724Q")
            {
                prodn_no = "17724";
            }
            if (ddl_prodn_no.SelectedValue.ToString() == "A22916J")
            {
                prodn_no = "22916";
            }
            if (ddl_prodn_no.SelectedValue.ToString() == "A44908N")
            {
                prodn_no = "44908";
            }
            if (ddl_prodn_no.SelectedValue.ToString() == "A44983U")
            {
                prodn_no = "44983";
            }
            if (ddl_prodn_no.SelectedValue.ToString() == "A32271C")
            {
                prodn_no = "32271";
            }

        }
        string operation = ddl_operation.SelectedValue.ToString();
        if (ddl_operation.SelectedValue.ToString() == "OP1")
        {
            operation = "1";
        }
        if (ddl_operation.SelectedValue.ToString() == "OP2")
        {
            operation = "2";
        }
        if (ddl_operation.SelectedValue.ToString() == "Lapping")
        {
            operation = "3";
        }
        if (ddl_operation.SelectedValue.ToString() == "Polishing")
        {
            operation = "4";
        }
    }
    public void load_operator()
    {
    }
    private void BindPart()
    {
        ds = objserver.GetDateset("select '-Select-' PartNo,'-Select-' PartNo union select distinct PartNo,PartNo from tbl_PartNo order by 1 asc");
        ddl_prodn_no.DataValueField = "PartNo";
        ddl_prodn_no.DataTextField = "PartNo";
        ddl_prodn_no.DataSource = ds.Tables[0];
        ddl_prodn_no.DataBind();
    }
    private void BindProcess()
    {
        ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");

        ddl_operation.DataSource = ds.Tables[0];

        ddl_operation.DataValueField = "process";
        ddl_operation.DataTextField = "process";
        ddl_operation.DataBind();
    }
    protected void btn_viewreports_Click(object sender, ImageClickEventArgs e)
    {
        string operation;
        DateTime fromdate = Convert.ToDateTime(txt_fromdate.Value.ToString().Trim());
        DateTime todate = Convert.ToDateTime(txt_todate.Value.ToString().Trim());

        //strConnString.Open();
        //cmd = new SqlCommand("get_uploadedexcelList", strConnString);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@prdno", ddl_prodn_no.SelectedValue.ToString().Trim());
        //cmd.Parameters.AddWithValue("@operation", ddl_operation.SelectedValue.ToString().Trim());
        //cmd.Parameters.AddWithValue("@shift", ddl_shift.Value.ToString().Trim());
        //cmd.Parameters.AddWithValue("@machinename", Slct_machine_QC.Value.ToString().Trim());
        //cmd.Parameters.AddWithValue("@unit", ddl_unit_QC.Text.ToString().Trim());
        //cmd.Parameters.AddWithValue("@fromdate", fromdate);
        //cmd.Parameters.AddWithValue("@todate", todate);
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    grid_viewresult.DataSource = ds.Tables[0];
        //    grid_viewresult.DataBind();
        //    div_result.Visible = true;
        //    div_error.Visible = false;
        //}
        //else
        //{
        //    div_result.Visible = false;
        //    div_error.Visible = true;
        //}

        if (ddl_operation.SelectedValue.ToString() == "OP1")
        {
            operation = "1";
        }
        else if (ddl_operation.SelectedValue.ToString() == "OP1")
        {
            operation = "2";
        }
        else
        {
            operation = ddl_operation.SelectedValue.ToString();
        }
        string Tablename = "QualitySheet_" + Slct_Cell_QC.SelectedValue.ToString() + "_" + ddl_prodn_no.SelectedValue.ToString() + "_" + operation.ToString();

        string str11 = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + Tablename + "'";
        SqlCommand myCommand = new SqlCommand(str11, strConnString);
        SqlDataReader myReader = null;
        int count = 0;
        try
        {
            if (strConnString.State == ConnectionState.Open)
            {
                strConnString.Close();
            }
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Quality Sheet not Created for " + ddl_prodn_no.SelectedValue.ToString() + "_" + operation.ToString() + "_" + Slct_Cell_QC.SelectedValue.ToString() + " ');", true);
        }
        else
        {
            string datetime = fromdate.Day.ToString() + "." + fromdate.Month.ToString() + "." + fromdate.Year.ToString();
            
            SqlDataAdapter dda;
            //if (ddl_shift.Value.ToString() == "O")
            //{
            //    dda = new SqlDataAdapter("select distinct Prdn_Name as ProductPN,CONVERT(VARCHAR,Qdate,103) as PID_No,Qdate,QShift as Shift,MachineName,'QS_Report_'+ Replace(CONVERT(VARCHAR,Qdate,101),'/','-')+'_'+Prdn_Name+QShift+'_'+MachineName+'.xls' as FileName,'C:\\Inetpub\\wwwroot\\DynamicWIS\\Document\\'+Prdn_Name+'\\'+ RIGHT('' + CAST(DAY(Qdate) AS VARCHAR(2)), 2)+'.'+RIGHT('' + CAST(MONTH(Qdate) AS VARCHAR(2)), 2)+'.'+cast(YEAR(Qdate) as CHAR(4)) +'\\' +'QS_Report_'+ Replace(CONVERT(VARCHAR,Qdate,101),'/','-')+'_'+Prdn_Name+QShift+'_'+MachineName+'.xls' as FilePath from " + Tablename + " where Qdate >='" + fromdate.ToString("MM/dd/yyyy") + "' and Qdate <='" + todate.ToString("MM/dd/yyyy") + "' ", strConnString);
            //}
            //else
            //{
            //    dda = new SqlDataAdapter("select distinct Prdn_Name as ProductPN,CONVERT(VARCHAR,Qdate,103) as PID_No,Qdate,QShift as Shift,MachineName,'QS_Report_'+ Replace(CONVERT(VARCHAR,Qdate,101),'/','-')+'_'+Prdn_Name+QShift+'_'+MachineName+'.xls' as FileName,'C:\\Inetpub\\wwwroot\\DynamicWIS\\Document\\'+Prdn_Name+'\\'+ RIGHT('' + CAST(DAY(Qdate) AS VARCHAR(2)), 2)+'.'+RIGHT('' + CAST(MONTH(Qdate) AS VARCHAR(2)), 2)+'.'+cast(YEAR(Qdate) as CHAR(4)) +'\\' +'QS_Report_'+ Replace(CONVERT(VARCHAR,Qdate,101),'/','-')+'_'+Prdn_Name+QShift+'_'+MachineName+'.xls' as FilePath from " + Tablename + " where Qdate >='" + fromdate.ToString("MM/dd/yyyy") + "' and Qdate <='" + todate.ToString("MM/dd/yyyy") + "' and QShift='" + ddl_shift.Value.ToString() + "' ", strConnString);
            //}
            if (ddl_shift.Value.ToString() == "O")
            {
                dda = new SqlDataAdapter("select distinct Prdn_Name as ProductPN,CONVERT(VARCHAR,Qdate,103) as PID_No,Qdate,QShift as Shift,MachineName,Prdn_Name+'\\'+ RIGHT('' + CAST(DAY(Qdate) AS VARCHAR(2)), 2)+'.'+RIGHT('' + CAST(MONTH(Qdate) AS VARCHAR(2)), 2)+'.'+cast(YEAR(Qdate) as CHAR(4)) as FilePathExists from " + Tablename + " where Qdate >='" + fromdate.ToString("MM/dd/yyyy") + "' and Qdate <='" + todate.ToString("MM/dd/yyyy") + "' and MachineName='" + Slct_machine_QC.Value.ToString() + "' ", strConnString);
            }
            else
            {
                dda = new SqlDataAdapter("select distinct Prdn_Name as ProductPN,CONVERT(VARCHAR,Qdate,103) as PID_No,Qdate,QShift as Shift,MachineName,Prdn_Name+'\\'+ RIGHT('' + CAST(DAY(Qdate) AS VARCHAR(2)), 2)+'.'+RIGHT('' + CAST(MONTH(Qdate) AS VARCHAR(2)), 2)+'.'+cast(YEAR(Qdate) as CHAR(4)) as FilePathExists from " + Tablename + " where Qdate >='" + fromdate.ToString("MM/dd/yyyy") + "' and Qdate <='" + todate.ToString("MM/dd/yyyy") + "' and QShift='" + ddl_shift.Value.ToString() + "' and MachineName='" + Slct_machine_QC.Value.ToString() + "' ", strConnString);
            }
            DataSet qcds = new DataSet();
            dda.Fill(qcds);
            System.Data.DataTable dt = new System.Data.DataTable();
            DataView view = new DataView(qcds.Tables[0]);
            dt = view.ToTable(true, "ProductPN", "Pid_No", "Qdate", "MachineName", "FilePathExists");
            qcds.Tables.Clear();
            qcds.Clear();
            qcds.Reset();
            qcds.Tables.Add(dt);
            System.Data.DataTable qcdt = new System.Data.DataTable();
            System.Data.DataRow qcdr;
            qcdt.Columns.Add("ProductPN");
            qcdt.Columns.Add("Pid_No");
            qcdt.Columns.Add("Qdate");
            qcdt.Columns.Add("Shift");
            qcdt.Columns.Add("MachineName");
            qcdt.Columns.Add("FileName");
            qcdt.Columns.Add("FilePath");
            if (qcds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < qcds.Tables[0].Rows.Count; i++)
                {
                    string path = Server.MapPath("~/Document/" + qcds.Tables[0].Rows[i]["FilePathExists"].ToString()).ToString();
                    if (Directory.Exists(path))
                    {
                        string[] fileEntries = Directory.GetFiles(path);
                        foreach (string fileName in fileEntries)
                        {
                            DateTime d1 = Convert.ToDateTime(qcds.Tables[0].Rows[i]["Qdate"].ToString());
                            DateTime d2 = new DateTime(2017, 2, 24);
                            string[] arrayfilename = fileName.Split('\\');
                            string strfilename = arrayfilename[arrayfilename.Length - 1].ToString();
                            string[] arrayfilename1 = strfilename.Split('_','.');
                            string strfilename_shift = arrayfilename1[3].ToString();
                            string strfilename_shift1 = strfilename_shift[strfilename_shift.Length - 1].ToString();
                            string stroperation = arrayfilename1[arrayfilename1.Length - 2].ToString();
                            if (ddl_shift.Value.ToString() == "O" )
                            {
                                if (d1 < d2)
                                {
                                    qcdr = qcdt.NewRow();
                                    qcdr["ProductPN"] = qcds.Tables[0].Rows[i]["ProductPN"].ToString();
                                    qcdr["Pid_No"] = qcds.Tables[0].Rows[i]["Pid_No"].ToString();
                                    qcdr["Qdate"] = qcds.Tables[0].Rows[i]["Qdate"].ToString();
                                    qcdr["Shift"] = strfilename_shift1.ToString();
                                    qcdr["MachineName"] = qcds.Tables[0].Rows[i]["MachineName"].ToString();

                                    qcdr["FileName"] = strfilename.ToString();
                                    qcdr["FilePath"] = fileName.ToString();
                                    qcdt.Rows.Add(qcdr);
                                }
                                else if (ddl_shift.Value.ToString() == "O" && strfilename.Contains(Slct_machine_QC.Value.ToString()) && stroperation.ToString() == operation.ToString())
                                {
                                    qcdr = qcdt.NewRow();
                                    qcdr["ProductPN"] = qcds.Tables[0].Rows[i]["ProductPN"].ToString();
                                    qcdr["Pid_No"] = qcds.Tables[0].Rows[i]["Pid_No"].ToString();
                                    qcdr["Qdate"] = qcds.Tables[0].Rows[i]["Qdate"].ToString();
                                    qcdr["Shift"] = strfilename_shift1.ToString();
                                    qcdr["MachineName"] = qcds.Tables[0].Rows[i]["MachineName"].ToString();

                                    qcdr["FileName"] = strfilename.ToString();
                                    qcdr["FilePath"] = fileName.ToString();
                                    qcdt.Rows.Add(qcdr);
                                }
                            }
                            else if ((strfilename_shift1 == ddl_shift.Value.ToString()) && strfilename.Contains(Slct_machine_QC.Value.ToString()) && stroperation.ToString()== operation.ToString())
                            {
                                qcdr = qcdt.NewRow();
                                qcdr["ProductPN"] = qcds.Tables[0].Rows[i]["ProductPN"].ToString();
                                qcdr["Pid_No"] = qcds.Tables[0].Rows[i]["Pid_No"].ToString();
                                qcdr["Qdate"] = qcds.Tables[0].Rows[i]["Qdate"].ToString();
                                qcdr["Shift"] = strfilename_shift1.ToString();
                                qcdr["MachineName"] = qcds.Tables[0].Rows[i]["MachineName"].ToString();

                                qcdr["FileName"] = strfilename.ToString();
                                qcdr["FilePath"] = fileName.ToString();
                                qcdt.Rows.Add(qcdr);
                            }
                            else
                            { }
                        }
                    }
                }
                if (qcdt.Rows.Count > 0)
                {
                    //grid_viewresult.DataSource = qcds.Tables[0];
                    grid_viewresult.DataSource = qcdt;
                    grid_viewresult.DataBind();
                    div_result.Visible = true;
                    div_error.Visible = false;
                }
                else
                {
                    div_result.Visible = false;
                    div_error.Visible = true;
                }
            }
            else
            {
                div_result.Visible = false;
                div_error.Visible = true;
            }

            //string date = fromdate.ToString("MM-dd-yyyy");
            //string Tablename = "QualitySheet_" + Slct_Cell_QC.SelectedValue.ToString() + "_" + ddl_prodn_no.SelectedValue.ToString() +"_" + Slct_machine_QC.Value.ToString() ;
            //string datetime = fromdate.Day.ToString() + "." + fromdate.Month.ToString() + "." + fromdate.Year.ToString();
            //string f_name1 = "QS_Report_" + date.ToString() + "_" + ddl_prodn_no.SelectedValue.ToString() + ddl_shift.Value.ToString() + "_" + Slct_machine_QC.Value.ToString() + ".xls";
            //string excelpath = Server.MapPath("~/Document/" + ddl_prodn_no.SelectedValue.ToString() + "\\" + datetime.ToString() + "\\" + f_name1);
            //FileInfo file = new FileInfo(excelpath);
            //if (file.Exists)
            //{
            //    Response.Clear();
            //    Response.ContentType = @"application\octet-stream";
            //    //    System.IO.FileInfo file = new System.IO.FileInfo(FullFilePath);
            //    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            //    Response.AddHeader("Content-Length", file.Length.ToString());
            //    Response.ContentType = "application/octet-stream";
            //    Response.WriteFile(file.FullName, true);
            //    Response.Flush();
            //}
        }
    }
    protected void grid_viewresult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            //System.Web.UI.WebControls.Label lbl_rowid = (System.Web.UI.WebControls.Label)grid_viewresult.Rows[index].FindControl("lbl_rowid");
            System.Web.UI.WebControls.Label lbl_filepath = (System.Web.UI.WebControls.Label)grid_viewresult.Rows[index].FindControl("lbl_path");
            //System.Web.UI.WebControls.Label Product_PN = (System.Web.UI.WebControls.Label)grid_viewresult.Rows[index].FindControl("lbl_prtno");
            //System.Web.UI.WebControls.Label lbl_opertaion = (System.Web.UI.WebControls.Label)grid_viewresult.Rows[index].FindControl("lbl_opertaion");
            //System.Web.UI.WebControls.Label lbl_shift = (System.Web.UI.WebControls.Label)grid_viewresult.Rows[index].FindControl("lbl_shift");
            //System.Web.UI.WebControls.Label lbl_pidno = (System.Web.UI.WebControls.Label)grid_viewresult.Rows[index].FindControl("lbl_pidno");
           //// objqualitysheetbl = new QualitySheetBL();

           //// objqualitysheetbl.generate_excelBL(lbl_shift.Text, Product_PN.Text, lbl_opertaion.Text, lbl_pidno.Text);
           // strConnString.Open();
           // cmd = new SqlCommand("sp_getqualityreports", strConnString);
           // cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.Add("@pidno", SqlDbType.VarChar,50).Value = lbl_pidno.Text.ToString();
           // cmd.Parameters.Add("@shift", SqlDbType.VarChar,3).Value = lbl_shift.Text.ToString();
           // cmd.Parameters.Add("@prodn", SqlDbType.VarChar,50).Value = Product_PN.Text.ToString();
           // cmd.Parameters.Add("@operation", SqlDbType.VarChar,20).Value = lbl_opertaion.Text.ToString();
           // da = new SqlDataAdapter(cmd);
           // ds = new DataSet();
           // da.Fill(ds);
           // if (ds.Tables[0].Rows.Count > 0)
           // {

           //     strPath = ds.Tables[0].Rows[0].ItemArray[0].ToString();
           //     string filepath = strPath;
           //     string FullFilePath = strPath;
           //     FileInfo file = new FileInfo(FullFilePath);
           //     if (file.Exists)
           //     {
           //         //Response.Clear();
           //         //Response.AddHeader("Content-Disposition", "inline; filename=" + file.Name);
           //         //Response.AddHeader("Content-Length", file.Length.ToString());
           //         //Response.ContentType = "application/octet-stream";
           //         //Response.WriteFile(file.FullName,true);
           //         //Response.End();

           //         Response.Clear();
           //         Response.ContentType = @"application\octet-stream";
           //         //    System.IO.FileInfo file = new System.IO.FileInfo(FullFilePath);
           //         Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
           //         Response.AddHeader("Content-Length", file.Length.ToString());
           //         Response.ContentType = "application/octet-stream";
           //         Response.WriteFile(file.FullName, true);
           //         Response.Flush();
           //     }
           //     else
           //     {
           //     }
           // }
           // else
           // {
           // }

            strPath = lbl_filepath.Text;
            string filepath = strPath;
            string FullFilePath = strPath;
            FileInfo file = new FileInfo(FullFilePath);
            if (file.Exists)
            {
                //Response.Clear();
                //Response.AddHeader("Content-Disposition", "inline; filename=" + file.Name);
                //Response.AddHeader("Content-Length", file.Length.ToString());
                //Response.ContentType = "application/octet-stream";
                //Response.WriteFile(file.FullName,true);
                //Response.End();

                Response.Clear();
                Response.ContentType = @"application\octet-stream";
                //    System.IO.FileInfo file = new System.IO.FileInfo(FullFilePath);
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName, true);
                Response.Flush();
            }
            else
            {
            }
        }
        
    }
    protected void onselectedindexchanged_Cell(object sender, EventArgs e)
    {
        string cell = Slct_Cell_QC.Text.ToString();
        if (cell.ToString() == "Valve")
        {
            ds = objserver.GetDateset("select '0','-Select-' Valve union select Id,Valve from Unit_table ");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Slct_machine_QC.DataSource = ds.Tables[0];

                Slct_machine_QC.DataValueField = "Valve";
                Slct_machine_QC.DataTextField = "Valve";
                Slct_machine_QC.DataBind();
            }

        }
        else if (cell.ToString() == "Block")
        {
            ds = objserver.GetDateset("select '0','-Select-' Block union select Id,Block from Unit_table");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Slct_machine_QC.DataSource = ds.Tables[0];

                Slct_machine_QC.DataValueField = "Block";
                Slct_machine_QC.DataTextField = "Block";
                Slct_machine_QC.DataBind();
            }

        }
        else if (cell.ToString() == "Shaft")
        {
            ds = objserver.GetDateset("select '0','-Select-' Shaft union select Id,Shaft from Unit_table");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Slct_machine_QC.DataSource = ds.Tables[0];

                Slct_machine_QC.DataValueField = "Shaft";
                Slct_machine_QC.DataTextField = "Shaft";
                Slct_machine_QC.DataBind();
            }

        }
        else if (cell.ToString() == "Cover")
        {
            ds = objserver.GetDateset("select '0','-Select-' Cover union select Id,Cover from Unit_table");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Slct_machine_QC.DataSource = ds.Tables[0];

                Slct_machine_QC.DataValueField = "Cover";
                Slct_machine_QC.DataTextField = "Cover";
                Slct_machine_QC.DataBind();
            }
        }
    }
    public void loadcell()
    {
        ds = objserver.GetDateset("select '0','-Select-' Cell union select Id,Cell from Cell ");

        Slct_Cell_QC.DataSource = ds.Tables[0];

        Slct_Cell_QC.DataValueField = "Cell";
        Slct_Cell_QC.DataTextField = "Cell";
        Slct_Cell_QC.DataBind();
    }
    protected void onselectedindexchanged_QC(object sender, EventArgs e)
    {
        string unit = ddl_unit_QC.Text.ToString();
        if (unit == "MBU")
        {
            //ds = objserver.GetDateset("select '-Select-' MBU,'-Select-' MBU union select distinct MBU,MBU from Machine_rpt_tble order by 1 asc");

            //Slct_machine_QC.DataSource = ds.Tables[0];

            //Slct_machine_QC.DataValueField = "MBU";
            //Slct_machine_QC.DataTextField = "MBU";
            //Slct_machine_QC.DataBind();

            ds = objserver.GetDateset("select '0','-Select-' Cell union select Id,Cell from Cell ");

            Slct_Cell_QC.DataSource = ds.Tables[0];

            Slct_Cell_QC.DataValueField = "Cell";
            Slct_Cell_QC.DataTextField = "Cell";
            Slct_Cell_QC.DataBind();

        }
        else if (unit == "ABU")
        {
            //ds = objserver.GetDateset("select '-Select-' ABU,'-Select-' ABU union select distinct ABU,ABU from Machine_rpt_tble order by 1 asc");

            //Slct_machine_QC.DataSource = ds.Tables[0];

            //Slct_machine_QC.DataValueField = "ABU";
            //Slct_machine_QC.DataTextField = "ABU";
            //Slct_machine_QC.DataBind();
        }
        else if (unit == "ALL")
        {
            //ds = objserver.GetDateset("SELECT '-Select-' ALLRPT,'-Select-' ALLRPT union select distinct MBU,MBU  as ALLRPT FROM Machine_rpt_tble where MBU<>'' UNION ALL SELECT '-Select-' ALLRPT,'-Select-' ALLRPT  union select distinct ABU,ABU  as ALLRPT   FROM Machine_rpt_tble where ABU<>'' ");

            //Slct_machine_QC.DataSource = ds.Tables[0];

            //Slct_machine_QC.DataValueField = "ALLRPT";
            //Slct_machine_QC.DataTextField = "ALLRPT";
            //Slct_machine_QC.DataBind();
        }
    }
}
