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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//using System.Web;
using Lab;
using System.IO;
public partial class _Default : System.Web.UI.Page
{
    public static bool f;
    public String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    Lab.Keyfile key = new Lab.Keyfile();
    DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheet = new QualitySheetBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {

        txt_date.Text = System.DateTime.Now.ToShortDateString();

        DateTime Ffrom = Convert.ToDateTime("06:00:00");
        DateTime Fto = Convert.ToDateTime("14:00:00");
        DateTime Sfrom = Convert.ToDateTime("14:00:00");
        DateTime Sto = Convert.ToDateTime("22:00:00");
        DateTime Tfrom = Convert.ToDateTime("22:00:00");
        DateTime Tto = Convert.ToDateTime("06:00:00").AddDays(1);
        string Current = DateTime.Now.ToShortTimeString().ToString();

        TimeSpan start = new TimeSpan(0, 0, 0); //0 o'clock
        TimeSpan end = new TimeSpan(6, 0, 0); //6 o'clock
        TimeSpan now = DateTime.Now.TimeOfDay;

        if ((now > start) && (now < end))
        {
            ddl_shift.Value = "C";
        }
        else
        {
            if (Convert.ToDateTime(Current) >= Ffrom && Convert.ToDateTime(Current) < Fto)
            {
                ddl_shift.Value = "A";
            }
            if (Convert.ToDateTime(Current) >= Sfrom && Convert.ToDateTime(Current) < Sto)
            {
                ddl_shift.Value = "B";
            }
            if (Convert.ToDateTime(Current) >= Tfrom && Convert.ToDateTime(Current) < Tto)
            {
                ddl_shift.Value = "C";
            }
        }

        



        //DateTime dt;
        //f = false;
        //dt = Convert.ToDateTime("06/25/2014");
        //if (DateTime.Today > dt)
        //{

        //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Contact PentaNodes');", true);
        //    //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        //   // Page.RegisterClientScriptBlock("close", "<sc.ript language=javascript>self.close();</script>");
        //    f = true;
        //}




        //if (Lab.SerialClass.CheckSerialNoExist() == false)
        //{

        //    Response.Redirect("ProjectSerialNoForm.aspx");


        //}
        //else
        //{
        //    bindkey();
        //    DateTime dt, dt1;
        //    dt = DateTime.Today;
        //    dt1 = Convert.ToDateTime(txtPassword0.Text);
        //    TimeSpan t = dt - dt1;
        //    int td = Convert.ToInt32(t.TotalDays);
        //    //DateDifference diff = new DateDifference(dt1, dt);
        //    //int diff1 = diff.Days;
        //    if (td >= 365)
        //    {

        //        string filetodelete = Server.MapPath(@"/serialNo.txt");
        //        if (System.IO.File.Exists(filetodelete) == true)
        //        {
        //            System.IO.File.Delete(filetodelete);
        //        }
        //        deleteins();
        //        Response.Redirect("ProjectSerialNoForm.aspx");
        //    }
        //}

    }
    //public void deleteins()
    //{
    //    Lab.Keyfile key = new Lab.Keyfile();
    //    key.prdate = txtPassword0.Text;
    //    key.DeleteIns(key);
    //}


    //protected void ImageButton1_Click(object sender, EventArgs e)
    //{

    //    try
    //    {
    //       objqualitysheet.Login_userBL(txtName.Text.ToString(), txtPassword.Text.ToString());
    //        //if ((txtName.Text == "admin") && (txtPassword.Text == "admin"))
    //        //{
    //        //    Response.Redirect("Workinstruction.aspx");
    //        //}

    //        //else if ((txtName.Text == "user") && (txtPassword.Text == "user"))
    //        //{
    //        //    Response.Redirect("Userpage.aspx");

    //        //}
    //        //if (f == true)
    //        //{
    //        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Contact PentaNodes');", true);
    //        //}

    //        //else
    //        //{
    //        //    ds = objserver.GetDateset("Usercreationselect");
    //        //    Boolean f1 = false;


    //        //    if ((txtName.Text == "") || (txtPassword.Text == ""))
    //        //    {

    //        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Fill all values');", true);


    //        //    }

    //        //    else if ((ds.Tables[0].Rows.Count != 0))
    //        //    {
    //        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        //        {
    //        //            f1 = false;
    //        //            if ((txtName.Text == ds.Tables[0].Rows[i].ItemArray[0].ToString()) && (txtPassword.Text == ds.Tables[0].Rows[i].ItemArray[1].ToString()))
    //        //            {

    //        //                Response.Redirect("MasterPage1.aspx");
    //        //                //Mainform frm = new Mainform(txtName.Text, txtPassword.Text);
    //        //                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
    //        //                //this.Hide();
    //        //                //frm.Show();
    //        //                f1 = true;
    //        //                break;
    //        //            }
    //        //            else
    //        //            {

    //        //            }

    //        //        }
    //        //        if (f1 == false)
    //        //        {
    //        //            txtName.Text = "";
    //        //            txtPassword.Text = "";

    //        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Username and Password');", true);
    //        //        }
    //        //    }

    //        }
        
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    

    //}
    public void bindkey()
    {
        Lab.Keyfile key = new Lab.Keyfile();
        DataSet ds1 = new DataSet();
        ds1 = key.bindins();
        if (ds1.Tables[0].Rows.Count < 1)
        {

            bindkey1();
        }
        else
        {
            txtPassword0.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        }
    }
    public void bindkey1()
    {
        Lab.Keyfile key = new Lab.Keyfile();

        DataSet ds1 = new DataSet();
        ds1 = key.bindins();
        txtPassword0.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
    }


    private void Usercreationselect()
    {
        ds = objserver.GetDateset("Usercreationselect");



    }
    //protected void txtPassword_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {


    //        ds = objserver.GetDateset("Usercreationselect");

    //        Boolean f1 = false;

    //        if ((txtPassword.Value == "") || (txtName.Text == ""))
    //        {
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Fill All The Values');", true);

    //        }

    //        else if ((ds.Tables[0].Rows.Count != 0))
    //        {
    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {
    //                f1 = false;
    //                if ((txtName.Text == ds.Tables[0].Rows[i].ItemArray[0].ToString()) && (txtPassword.Value == ds.Tables[0].Rows[i].ItemArray[1].ToString()))
    //                {


    //                    Response.Redirect("Visitors.aspx");
    //                    Session["Username"] = txtName.Text;
    //                    Session["password"] = txtPassword.Value;
    //                    f1 = true;
    //                    break;
    //                }
    //                else
    //                {

    //                }

    //            }
    //            if (f1 == false)
    //            {
    //                txtName.Text = "";
    //                txtPassword.Value = "";
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid UserName and Password');", true);
    //            }
    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    protected void btn_login_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);

            //foreach (string filePath in Directory.GetFiles(tempPath, "*.*", SearchOption.AllDirectories))
            //{
            //    try
            //    {
            //        FileInfo currentFile = new FileInfo(filePath);
            //        currentFile.Delete();
            //    }
            //    catch (Exception ex)
            //    {
            //        //Debug.WriteLine("Error on file: {0}\r\n   {1}", filePath, ex.Message);
            //    }
            //}

            objqualitysheet.Login_userBL(txtName.Text.ToString(), txtPassword.Value.ToString(),ddl_shift.Value.ToString());
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
    protected void txtName_TextChanged(object sender, EventArgs e)
    {

    }
}
