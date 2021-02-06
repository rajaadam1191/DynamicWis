using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.IO;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;


public partial class MC_REPORT : System.Web.UI.Page
{
    public String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    public DBServer objserver = new DBServer();
    public DataSet ds;
    public DataSet dss;
    public static Object thisLock = new Object();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtt_fromdate.Value = DateTime.Now.ToShortDateString().ToString();
            txtt_todate.Value = DateTime.Now.ToShortDateString().ToString();

            //BindPart();
            BindProcess();
          
            //Loadprocess();
        }
    }
    //private void ViewMachineReport1()
    //{

    //    DBServer db = new DBServer();
    //    //db.Machinename = txt_mchn.Value;
    //    //db.fromdate = txtt_fromdate.Value;
    //    //db.todate = txtt_todate.Value;
    //    ds = db.ViewMachineReport(db);
    ////    ReportDocument report = new ReportDocument();
    //    report.Load(Server.MapPath("DepartmentRPT.rpt"));
    //    report.SetDataSource(ds.Tables[0]);
    //    CrystalReportViewer1.ReportSource = report;


    //    //DepartmentRPT objRpt = new DepartmentRPT();
    //    //objRpt.SetDataSource(ds.Tables[0]);
    //    //CrystalReportViewer1.ReportSource = objRpt;
    //    //CrystalReportViewer1.Refresh();
       
    //}




    //private void BindPart()
    //{
    //    ds = objserver.GetDateset("select '-Select-' Partno,'-Select-' Partno union select distinct partno,Partno from tbl_PartNo order by 1 asc");
    //    ddl_partno.DataValueField = "Partno";
    //    ddl_partno.DataTextField = "Partno";
    //    ddl_partno.DataSource = ds.Tables[0];
    //    ddl_partno.DataBind();
    //}
    private void BindProcess()
    {
         lock (thisLock)
        {
try
        {
        ds = objserver.GetDateset("select '-Select-' Process,'-Select-' Process union select distinct Process,Process from tbl_Process order by 1 asc");

        ddl_process.DataSource = ds.Tables[0];

        ddl_process.DataValueField = "process";
        ddl_process.DataTextField = "process";
        ddl_process.DataBind();
        }
catch (Exception ex)
{
    ExceptionLogging.SendExcepToDB(ex);

}
finally
{
    
}
        }
    }
    private void ViewMachineReport1(string shift, string unit, string mchn, string process, DateTime frmtm, DateTime totm)
    {

        DBServer db = new DBServer();
        ds = db.departmentreport(shift, unit, mchn, process, frmtm, totm);
        DataSet ds1 = new DataSet();
        ds1 = db.machinereport(shift, unit, mchn, process, frmtm, totm);
        lock (thisLock)
        {
        try{

        if (ds.Tables[0].Rows.Count > 0)
        {
            grid_process.DataSource = ds.Tables[0];
            grid_process.DataBind();
            div_dept_error.Visible = false;
            DIV_DEPART.Visible = true;
            div_exceldept.Visible = true;
        }
        else
        {
          
            div_dept_error.Visible = true;
            DIV_DEPART.Visible = false;
            div_exceldept.Visible = false;
            lbl_dept.Text = "Record Not Found";

        }
        if (ds1.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds1.Tables[0];
            GridView1.DataBind();
            div_mchn_error.Visible = false;
            div_machine.Visible = true;
            div_excelmac.Visible = true;
        }
        else
        {
            div_mchn_error.Visible = true;
            div_machine.Visible = false;
            div_excelmac.Visible = false;

            lbl_mchn.Text = "Record Not Found";


        }
            } catch (Exception ex)
        {
             ExceptionLogging.SendExcepToDB(ex); 
           
        }
finally
{


}
}


    }
   //public void Loadprocess()
   //{
   //    DataSet ds = new DataSet();
   //    ds = objserver.GetDateset("select * from Department");
   //    if (ds.Tables[0].Rows.Count > 0)
   //    {
   //        grid_process.DataSource = ds.Tables[0];
   //        grid_process.DataBind();
   //    }

   //}


    protected void btn_excel_Click(object sender, ImageClickEventArgs e)
    {
       
  lock (thisLock)
        {


try
        {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Department.xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        grid_process.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Applying stlye to gridview header cells
        for (int i = 0; i < grid_process.HeaderRow.Cells.Count; i++)
        {
            grid_process.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
        }
        grid_process.AllowPaging = false;
        HtmlForm frm = new HtmlForm();
        grid_process.Parent.Controls.Add(frm);
        frm.Attributes["runat"] = "server";
        frm.Controls.Add(grid_process);
        frm.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
        //Change the Header Row back to white color
        
        //grid_process.RenderControl(htw);
        //Response.Write(sw.ToString());
        }
catch (Exception ex)
{
    ExceptionLogging.SendExcepToDB(ex);

}
finally
{
   

}
        }  //Response.End();

    }
    protected void img_btnmacexcel_Click(object sender, ImageClickEventArgs e)
    {
        
  lock (thisLock)
        {



        try
        {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Machine.xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Applying stlye to gridview header cells
        for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
        {
            GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
        }
        GridView1.AllowPaging = false;
        HtmlForm frm = new HtmlForm();
        GridView1.Parent.Controls.Add(frm);
        frm.Attributes["runat"] = "server";
        frm.Controls.Add(GridView1);
        frm.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
            } catch (Exception ex)
        {
             ExceptionLogging.SendExcepToDB(ex); 
           
        }
finally
{


}
}

    }
    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {

        string shift = ddl_shift.SelectedValue.ToString();
        string unit = ddl_unit.Text.ToString();
        string mchn = Slct_machine_rpt.Value.ToString();
        string process = ddl_process.Value.ToString();
        DateTime frmtm = Convert.ToDateTime(txtt_fromdate.Value.ToString());
        DateTime totm = Convert.ToDateTime(txtt_todate.Value.ToString());
        ViewMachineReport1(shift, unit, mchn, process, frmtm, totm);
        div_lbl.Visible = true;
        div_lbl_mchn.Visible = true;
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "getmachine_mcrpt();", true);

    }
    protected void onselectedindexchanged_mchn(object sender, EventArgs e)
    {
        string unit = ddl_unit.Text.ToString();
        if (unit == "MBU")
        {
            ds = objserver.GetDateset("select '-Select-' MBU,'-Select-' MBU union select distinct MBU,MBU from Machine_rpt_tble order by 1 asc");

            Slct_machine_rpt.DataSource = ds.Tables[0];

            Slct_machine_rpt.DataValueField = "MBU";
            Slct_machine_rpt.DataTextField = "MBU";
            Slct_machine_rpt.DataBind();
        }
        else if (unit == "ABU")
            {
                ds = objserver.GetDateset("select '-Select-' ABU,'-Select-' ABU union select distinct ABU,ABU from Machine_rpt_tble order by 1 asc");

            Slct_machine_rpt.DataSource = ds.Tables[0];

            Slct_machine_rpt.DataValueField = "ABU";
            Slct_machine_rpt.DataTextField = "ABU";
            Slct_machine_rpt.DataBind();
        }
        else if (unit == "ALL")
        {
            ds = objserver.GetDateset("SELECT '-Select-' ALLRPT,'-Select-' ALLRPT union select distinct MBU,MBU  as ALLRPT FROM Machine_rpt_tble where MBU<>'' UNION ALL SELECT '-Select-' ALLRPT,'-Select-' ALLRPT  union select distinct ABU,ABU  as ALLRPT   FROM Machine_rpt_tble where ABU<>'' ");
            Slct_machine_rpt.DataSource = ds.Tables[0];

            Slct_machine_rpt.DataValueField = "ALLRPT";
            Slct_machine_rpt.DataTextField = "ALLRPT";
            Slct_machine_rpt.DataBind();
        }
    }

}
