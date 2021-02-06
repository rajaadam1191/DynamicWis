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
using Microsoft.Office.Interop.Excel;
using Microsoft.Office;
//using Microsoft.Office.Interop.Word;

public partial class Userpage : System.Web.UI.Page
{
    private String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
    DBServer objserver = new DBServer();
    DataSet ds;
    public static Object thisLock = new Object();
    public string strPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            BindProcess();
            if (Session["User_Role"] != null && Session["User_Role"].ToString() != "")
            {
                if (Session["User_Role"].ToString().ToLower() == "user")
                {
                    //drp_user();
                    loadpagedata();
                    div_usermenu.Visible = false;
                }
                if (Session["User_Role"].ToString().ToLower() == "admin")
                {
                    //drp_admin();
                    div_usermenu.Visible = false;

                }
            }
            else
            {
                Response.Redirect("../Home.aspx");
            }
        }
    }
    public void loadpagedata()
    {
        div_DropPart.Attributes.Add("Disabled", "");
        DropPart.SelectedValue = Session["PartNo"].ToString();
        DropPart.Enabled = false;
        string oper = "";
        lock (thisLock)
        {

            try
            {
                if (Session["Operation"].ToString() == "1" || Session["Operation"].ToString() == "2")
                {
                    if (Session["Operation"].ToString() == "1")
                    {
                        oper = "OP1";
                    }
                    if (Session["Operation"].ToString() == "2")
                    {
                        oper = "OP2";
                    }
                }
                else
                {
                    oper = Session["Operation"].ToString();
                }
                DropProcess.SelectedItem.Text = oper;
                hdn_process.Value = oper;
                DropProcess.Enabled = false;

                DBServer db = new DBServer();
                DataSet ds = new DataSet();
                db.PartNo = Session["PartNo"].ToString();
                ds = db.ViewDescriptionbyPartNO(db);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    TxtDescription.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    TxtDescription.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }
    private void BindData()
    {
        lock (thisLock)
        {

            try
            {
                ds = objserver.GetDateset("select '-Select-' Partno,'-Select-' Partno union select distinct partno,Partno from tbl_PartNo order by 1 desc");
                DropPart.DataValueField = "Partno";
                DropPart.DataTextField = "Partno";
                DropPart.DataSource = ds.Tables[0];
                DropPart.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }
    private void BindProcess()
    {
        lock (thisLock)
        {

            try
            {
                ds = objserver.GetDateset("select '0' PID,'-Select-' Process union select distinct PID,Process from tbl_Process order by PID");
                DropProcess.DataValueField = "PID";
                DropProcess.DataTextField = "Process";
                DropProcess.DataSource = ds.Tables[0];
                DropProcess.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }
    //    private string WordToHTML(string filePath)
    //    {
    //        string returnPath = String.Empty;
    //        Microsoft.Office.Interop.Word.Document doc = null;
    //        object missing = System.Reflection.Missing.Value;
    //        Microsoft.Office.Interop.Word.Application wordApp = null;

    //        try
    //        {
    //            // Initialise
    //            string serverFolderPath = Path.GetDirectoryName(strPath);
    //            string fileToOpen = filePath;
    //            string FileToSave = Path.GetFileNameWithoutExtension(fileToOpen) + ".html";

    //            // Open Word
    //            wordApp = new Microsoft.Office.Interop.Word.Application();

    //            // Get Doc
    //            //doc = wordApp.Documents.Open(fileToOpen, ref missing, true, ref missing,
    //            //                             ref missing, ref missing, ref missing,
    //            //                             ref missing, ref missing, ref missing,
    //            //                             ref missing, false, ref missing, ref missing,
    //            //                             ref missing, ref missing);
    //            Microsoft.Office.Interop.Word.Document doc = WordApp.Documents.Open(ref file,
    //ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj,
    //ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj,
    //ref nullobj); 
    //            // If html file already exists, delete it 
    //            returnPath = String.Format("{0}\\{1}", serverFolderPath, FileToSave);
    //            if (File.Exists(returnPath))
    //                File.Delete(returnPath);

    //            // Save as HTML document
    //            doc.SaveAs(returnPath, 10, ref missing, ref missing,
    //                       ref missing, ref missing, ref missing, ref missing,
    //                       ref missing, ref missing, ref missing, ref missing,
    //                       ref missing, ref missing, ref missing, ref missing);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            doc.Close(ref nullobj, ref nullobj, ref nullobj);
    //            WordApp.Quit(ref nullobj, ref nullobj, ref nullobj);
    //        }
    //        return returnPath;
    //    }
    private string ReturnExtension(string fileExtension)
    {
        switch (fileExtension)
        {
            case ".htm":
            case ".html":
            case ".log":
                return "text/HTML";
            case ".txt":
                return "text/plain";
            case ".doc":
                return "application/ms-word";
            case ".tiff":
            case ".tif":
                return "image/tiff";
            case ".asf":
                return "video/x-ms-asf";
            case ".avi":
                return "video/avi";
            case ".zip":
                return "application/zip";
            case ".xls":
            case ".csv":
                return "application/vnd.ms-excel";
            case ".gif":
                return "image/gif";
            case ".jpg":
            case "jpeg":
                return "image/jpeg";
            case ".bmp":
                return "image/bmp";
            case ".wav":
                return "audio/wav";
            case ".mp3":
                return "audio/mpeg3";
            case ".mpg":
            case "mpeg":
                return "video/mpeg";
            case ".rtf":
                return "application/rtf";
            case ".asp":
                return "text/asp";
            case ".pdf":
                return "application/pdf";
            case ".fdf":
                return "application/vnd.fdf";
            case ".ppt":
                return "application/mspowerpoint";
            case ".dwg":
                return "image/vnd.dwg";
            case ".msg":
                return "application/msoutlook";
            case ".xml":
            case ".sdxl":
                return "application/xml";
            case ".xdp":
                return "application/vnd.adobe.xdp+xml";
            default:
                return "application/octet-stream";
        }
    }
    protected void Save()
    {
        lock (thisLock)
        {

            try
            {

                //rootDir = Common.GetCUFileServerRoot().Trim();
                if (div_user.Visible == true)
                {
                    if (grid_viewresult.Rows.Count > 0)
                    {
                        for (int i = 0; i < grid_viewresult.Rows.Count; i++)
                        {
                            System.Web.UI.WebControls.CheckBox ch_view = (System.Web.UI.WebControls.CheckBox)grid_viewresult.Rows[i].FindControl("ch_view");
                            System.Web.UI.WebControls.Label lbl_filename = (System.Web.UI.WebControls.Label)grid_viewresult.Rows[i].FindControl("lbl_filename");
                            System.Web.UI.WebControls.Label lbl_path = (System.Web.UI.WebControls.Label)grid_viewresult.Rows[i].FindControl("lbl_path");
                            if (ch_view != null)
                            {
                                if (ch_view.Checked == true)
                                {
                                    if (DropType.Text == "1")
                                    {
                                        DataSet ds = new DataSet();

                                        //ds = objserver.GetDateset("select * from tbl_WIPart where partno='" + DropPart.SelectedItem + "' and type='" + DropType.SelectedItem + "' and process='" + DropProcess.SelectedItem + "' ");

                                        //if (ds.Tables[0].Rows.Count > 0)
                                        //{

                                        //    strPath = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                                        //    // Get the physical Path of the file(test.doc)
                                        //    string filepath = strPath;
                                        //    string FullFilePath = strPath;
                                        FileInfo file = new FileInfo(lbl_path.Text.ToString());
                                        //    if (file.Exists)
                                        //    {
                                        Response.Clear();
                                        Response.AddHeader("Content-Disposition", "inline; filename=" + file.Name);
                                        Response.AddHeader("Content-Length", file.Length.ToString());
                                        //   Response.ContentType = "application/vnd.ms-word";
                                        Response.ContentType = "application/octet-stream";
                                        Response.WriteFile(file.FullName);
                                        Response.End();
                                        //    }
                                        //}
                                    }
                                    else
                                    {
                                        DataSet ds = new DataSet();

                                        //ds = objserver.GetDateset("select * from tbl_WIPart where partno='" + DropPart.SelectedItem + "' and type='" + DropType.SelectedItem + "'");

                                        //if (ds.Tables[0].Rows.Count > 0)
                                        //{

                                        //    strPath = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                                        //    // Get the physical Path of the file(test.doc)
                                        //    string filepath = strPath;
                                        //    string FullFilePath = strPath;
                                        FileInfo file = new FileInfo(lbl_path.Text.ToString());
                                        //    if (file.Exists)
                                        //    {
                                        Response.Clear();
                                        Response.AddHeader("Content-Disposition", "inline; filename=" + file.Name);
                                        Response.AddHeader("Content-Length", file.Length.ToString());
                                        //   Response.ContentType = "application/vnd.ms-word";
                                        Response.ContentType = "application/octet-stream";
                                        Response.WriteFile(file.FullName);
                                        Response.End();
                                        //    }

                                        //}
                                        //else
                                        //{
                                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('File Not Exist');", true);
                                        //}
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Must select File name !');", true);
                                }
                            }
                        }
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No Record Found !');", true);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }



            //object missingType = Type.Missing;
            //object readOnly = true;
            //object isVisible = false;
            //object documentFormat = 8;
            //string randomName = DateTime.Now.Ticks.ToString();
            //object htmlFilePath = Server.MapPath("~/Temp/") + randomName + ".htm";
            //string directoryPath = Server.MapPath("~/Temp/") + randomName + "_files";

            ////Upload the word document and save to Temp folder
            //FileUpload1.SaveAs(Server.MapPath("~/Temp/") + Path.GetFileName(FileUpload1.PostedFile.FileName));
            //object fileName = FileUpload1.PostedFile.FileName;

            ////Open the word document in background
            //Microsoft.Office.Interop.Word.Document appss = new Microsoft.Office.Interop.Word.Document();

            

            //appss.Documents.Open(ref fileName,
            //                                ref readOnly,
            //                                ref missingType, ref missingType, ref missingType,
            //                                ref missingType, ref missingType, ref missingType,
            //                                ref missingType, ref missingType, ref isVisible,
            //                                ref missingType, ref missingType, ref missingType,
            //                                ref missingType, ref missingType);
            //appss.Visible = false;
            //Document document =appss ;

            ////Save the word document as HTML file
            //document.SaveAs(ref htmlFilePath, ref documentFormat, ref missingType,
            //                ref missingType, ref missingType, ref missingType,
            //                ref missingType, ref missingType, ref missingType,
            //                ref missingType, ref missingType, ref missingType,
            //                ref missingType, ref missingType, ref missingType,
            //                ref missingType);

            ////Close the word document
            //document.Close(ref missingType, ref missingType, ref missingType);

            ////Delete the Uploaded Word File
            //File.Delete(Server.MapPath("~/Temp/") + Path.GetFileName(FileUpload1.PostedFile.FileName));

            ////Read the Html File as Byte Array and Display it on browser
            //byte[] bytes;
            //using (FileStream fs = new FileStream(htmlFilePath.ToString(), FileMode.Open, FileAccess.Read))
            //{
            //    BinaryReader reader = new BinaryReader(fs);
            //    bytes = reader.ReadBytes((int)fs.Length);
            //    fs.Close();
            //}
            //Response.BinaryWrite(bytes);
            //Response.Flush();

            ////Delete the Html File
            //File.Delete(htmlFilePath.ToString());
            //foreach (string file in Directory.GetFiles(directoryPath))
            //{
            //    File.Delete(file);
            //}
            //Directory.Delete(directoryPath);
            //Response.End();
            // Create New instance of FileInfo class to get the properties of the file being downloaded
            //FileInfo file = new FileInfo(filepath);

            //// Checking if file exists
            //if (file.Exists)
            //{
            //    // Clear the content of the response
            //    Response.ClearContent();

            //    // LINE1: Add the file name and attachment, which will force the open/cance/save dialog to show, to the header


            //    // Add the file size into the response header
            //    Response.AddHeader("Content-Disposition", "inline; filename=" + file.Name);
            //    // Set the ContentType
            //    Response.ContentType = ReturnExtension(file.Extension.ToLower());

            //    // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
            //    Response.TransmitFile(file.FullName);

            //    // End the response
            //    Response.End();
 //           Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
 //           object missingType = Type.Missing;
 //           object readOnly = true;
 //           object isVisible = false;
 //           object documentFormat = 8;
 //           string randomName = DateTime.Now.Ticks.ToString();
 //           object htmlFilePath = "D:\\PHWIS\\uploads\\000350850J\\Work Instruction\\Lapping\\Lapping.htm";
 //         //  string directoryPath = Server.MapPath("~/Temp/") + randomName + "_files";
 //           object file = strPath;
 //           object nullobj = System.Reflection.Missing.Value;

 //           Microsoft.Office.Interop.Word.Document doc = WordApp.Documents.Open(ref file,
 //ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj,
 //ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj,
 //ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj);

 //           doc.ActiveWindow.Selection.WholeStory();
 //           doc.ActiveWindow.Selection.Copy();
 //           doc.SaveAs(ref htmlFilePath, ref documentFormat, ref missingType,
 //                          ref missingType, ref missingType, ref missingType,
 //                          ref missingType, ref missingType, ref missingType,
 //                          ref missingType, ref missingType, ref missingType,
 //                          ref missingType, ref missingType, ref missingType,
 //                          ref missingType);




 //           //Read the Html File as Byte Array and Display it on browser
 //           byte[] bytes;
 //           using (FileStream fs = new FileStream(htmlFilePath.ToString(), FileMode.Open, FileAccess.Read))
 //           {
 //               BinaryReader reader = new BinaryReader(fs);
 //               bytes = reader.ReadBytes((int)fs.Length);
 //               fs.Close();
 //           }
 //           Response.BinaryWrite(bytes);
 //           Response.Flush();

            //IDataObject data = Clipboard.GetDataObject();

            ////Do whatever with the text.
            ////  string text = data.GetData(DataFormats.Text).ToString();

            //string text1 = doc.Content.Text;
            //string text = text1;
            //doc.Close(ref nullobj, ref nullobj, ref nullobj);
            //WordApp.Quit(ref nullobj, ref nullobj, ref nullobj);
            //if (!string.IsNullOrEmpty(strPath))
            //{



            //    Response.ContentType = "application/vnd.ms-word";
            //    Response.AddHeader("Content-Disposition", "inline; filename=\"" + file.Name + "\"");
            //    Response.AddHeader("Content-Length", file.Length.ToString());
            //    Response.TransmitFile(file.FullName);
            //}
                //WebClient client = new WebClient();
                //Byte[] buffer = client.DownloadData(strPath);

                //if (buffer != null)
                //// FileInfo file = new FileInfo(strPath);
                //// if (file.Exists)
                //{
                //    Response.ContentType = "application/msword";
                //    Response.AddHeader("content-length", buffer.Length.ToString());
                //    Response.BinaryWrite(buffer);
                //   Response.Write("<script>window.print();window.close()</script>");


                //correct working 
 protected void DropType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (DropType.SelectedItem.Text == "Work Instruction")
        //{
        //   // DropProcess.Enabled = true;
        //    get_gridresult();
        //}
        //else
        //{
        //   // BindProcess();
        //    //DropProcess.Text= "-Select-";
        //    DropProcess.Enabled = false;
        //    get_gridresult();

        //}
        if (Session["User_Role"] != null && Session["User_Role"].ToString() != "")
        {
            if (Session["User_Role"].ToString().ToLower() == "user")
            {
                drp_user();
               
                div_usermenu.Visible = false;
            }
            if (Session["User_Role"].ToString().ToLower() == "admin")
            {
                drp_admin();
                div_usermenu.Visible = false;

            }
            if (Session["User_Role"].ToString().ToLower() == "super admin")
            {
                drp_admin();
                div_usermenu.Visible = false;

            }
        }
    }
 private void drp_user()
 {
     lock (thisLock)
     {

         try
         {
             if (DropType.SelectedItem.Text == "Work Instruction")
             {
                 // DropProcess.Enabled = true;
                 get_gridresult();
             }
             else
             {
                 // BindProcess();
                 //DropProcess.Text= "-Select-";
                 DropProcess.Enabled = false;
                 get_gridresult();

             }

         }
         catch (Exception ex)
         {
             ExceptionLogging.SendExcepToDB(ex);

         }
     }
 }
 private void drp_admin()
 {
     lock (thisLock)
     {

         try
         {
             if (DropType.SelectedItem.Text == "Work Instruction")
             {
                 DropProcess.Enabled = true;
                 get_gridresult();
             }
             else
             {
                 //DropProcess.Enabled = true;

                 //BindProcess();
                 //DropProcess.Text = "-Select-";
                 get_gridresult();

             }
         }
         catch (Exception ex)
         {
             ExceptionLogging.SendExcepToDB(ex);

         }

     }
 }
   
    protected void DropPart_SelectedIndexChanged(object sender, EventArgs e)
    {
        lock (thisLock)
        {

            try
            {

                DBServer db = new DBServer();
                DataSet ds = new DataSet();
                db.PartNo = DropPart.SelectedItem.Text;
                ds = db.ViewDescriptionbyPartNO(db);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    TxtDescription.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    if (DropPart.SelectedItem.Text != "-Select-" && DropType.SelectedItem.Text != "-Select-" && DropProcess.SelectedItem.Text != "-Select-")
                    {
                        get_gridresult();
                    }
                    else
                    {
                        div_user.Visible = false;
                        DropType.SelectedValue = "0";
                        BindProcess();

                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }

    }
    public void get_gridresult()
    {
        lock (thisLock)
        {

            try
            {

                ds = objserver.GetDateset("select * from tbl_WIPart where partno='" + DropPart.SelectedItem + "' and type='" + DropType.SelectedItem + "' and process='" + DropProcess.SelectedItem + "' ");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grid_viewresult.DataSource = ds.Tables[0];
                    grid_viewresult.DataBind();
                    div_error.Visible = false;
                    div_user.Visible = true;
                }
                else
                {
                    div_error.Visible = true;
                    div_user.Visible = false;
                    spn_error.InnerText = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }
    protected void DropProcess_SelectedIndexChanged(object sender, EventArgs e)
    {
        lock (thisLock)
        {

            try
            {
                hdn_process.Value = DropProcess.SelectedItem.Text.ToString();
                if (DropPart.SelectedItem.Text.ToString() == "-Select'" || DropType.SelectedValue.ToString() == "0")
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "checkvalues();", true);
                }
                else
                {
                    get_gridresult();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

            }
        }
    }


    protected void Save(object sender, ImageClickEventArgs e)
    {
        Save();
    }
}
    


        

    

    





        
    
    

