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
using System.IO;

public partial class Default2 : System.Web.UI.Page
{
   public  string DownloadFileType;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAddImage_Click(object sender, EventArgs e)
    {
        byte[] buffer;
        DownloadFileType = DListFileType.SelectedValue.ToString();
        string strFileName;
        HtmlInputFile htmlFile = (HtmlInputFile)ImageFile;
        if (htmlFile1.HasFile && htmlFile.PostedFile != null && htmlFile1.PostedFile.FileName != "")
        {
            HttpPostedFile file = htmlFile1.PostedFile;//retrieve the HttpPostedFile object
            buffer = new byte[file.ContentLength];
            int bytesReaded = file.InputStream.Read(buffer, 0, htmlFile1.PostedFile.ContentLength);
            if (htmlFile.PostedFile.ContentLength > 0)
            {
                string sFormat = String.Format("{0:#.##}", (float)htmlFile.PostedFile.ContentLength / 2048);
                ViewState["ImageName"] = htmlFile.PostedFile.FileName.Substring(htmlFile.PostedFile.FileName.LastIndexOf("\\") + 1);
                strFileName = ViewState["ImageName"].ToString();
                string sExtension = strFileName.Substring(strFileName.LastIndexOf(".") + 1);

                if (checkFileType(sExtension))  //Check for file types
                {
                    if (DownloadFileType == "Image")
                    {
                        htmlFile.PostedFile.SaveAs(Server.MapPath("~/Images/" + strFileName));
                    }
                    else if (DownloadFileType == "Video")
                    {
                        htmlFile.PostedFile.SaveAs(Server.MapPath("~/Videos/" + strFileName));
                    }
                    lblError.Visible = false;
                    //System.Threading.Thread.Sleep(8000);
                    Label1.Visible = true;
                    Label1.Text = "Upload successfull!";
                    ShowImage();
                    ShowVideo();
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Please Check your file";
                }
            }

            else
            {
                lblError.Visible = true;
                lblError.Text = "Please Select any file to upload";
            }
        }
    
    }
    private bool checkFileType(string FileExtension)
    {
        if (DownloadFileType == "Video")
        {
            switch (FileExtension.ToLower())
            {
                case "mp4":
                    return true;
                case "wmv":
                    return true;
                case "avi":
                    return true;
                case "mpg":
                    return true;
                case "wav":
                    return true;
                case "mid":
                    return true;
                case "asf":
                    return true;
                case "mpeg":
                    return true;
                case "dat":
                    return true;
                default:
                    return false;
            }
        }
        else if (DownloadFileType == "Image")
        {
            switch (FileExtension.ToLower())
            {
                case "gif":
                    return true;
                case "png":
                    return true;
                case "jpg":
                    return true;
                case "jpeg":
                    return true;
                default:
                    return false;
            }
        }
        return false;
    }

    protected void btnShowImage_Click(object sender, EventArgs e)
    {
        ShowImage();
    }

    public void ShowImage()
    {
        DirectoryInfo myImageDir = new DirectoryInfo(MapPath("~/Images/"));
        try
        {
            dlImageList.DataSource = myImageDir.GetFiles();
            dlImageList.DataBind();
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Response.Write("<script language =Javascript> alert('Upload File(s) First!');</script>");
        }
    }

    protected void btnShowVideo_Click(object sender, EventArgs e)
    {
        ShowVideo();
    }

    public void ShowVideo()
    {
        DirectoryInfo myVideoDir = new DirectoryInfo(MapPath("~/Videos/"));
        try
        {
            DataListVideo.DataSource = myVideoDir.GetFiles();
            DataListVideo.DataBind();
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Response.Write("<script language =Javascript> alert('Upload File(s) First!');</script>");
        }
    }
  
}
