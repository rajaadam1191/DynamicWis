using System;
using System.Collections; 
using System.Collections.Generic;
using System.Configuration; 
using System.Data; 
using System.Linq; 
using System.Web;
using System.Web.Security;
using System.Web.UI; 
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls; 
using System.Web.UI.WebControls.WebParts;
using System.Net; 
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_excel_Click(object sender, EventArgs e)
    {
       // saveURLToImage("http://converter.telerik.com");
        WebRequest hwr = HttpWebRequest.Create("http://localhost:52753/Dynamic/Default.aspx");
        WebResponse Wresponse = hwr.GetResponse(); 
        Stream pageData = Wresponse.GetResponseStream();
        StreamWriter sw = new StreamWriter(@"E:\ppdf\a.html", false, System.Text.Encoding.Default);
        StreamReader sr = new StreamReader(pageData);
        sw.Write(sr.ReadToEnd());
        sw.Close();
        sw.Dispose(); 
        sr.Close(); 
        sr.Dispose();
        string filepath = @"E:\ppdf\a.html";
        string text = GetPageText("http://localhost:52753/Dynamic/Default.aspx");
        StreamWriter writer = new StreamWriter(filepath);
        writer.Write(text);
        writer.Close();

        htmltopdf();

    }
    public string GetPageText(string url)
    {
        string htmlText = string.Empty;
        string FILE_NAME = @"E:\ppdf\a.html"; //"c:\\test.xml";

        try
        {

            HttpWebRequest requestIP = (HttpWebRequest)WebRequest.Create(url);
            requestIP.Timeout = 10000;
            using (HttpWebResponse responseIP = (HttpWebResponse)requestIP.GetResponse())
            {
                using (Stream streamIP = responseIP.GetResponseStream())
                {
                    using (StreamReader readerText = new StreamReader(streamIP))
                    {
                        htmlText = readerText.ReadToEnd();
                        string text = htmlText;

                        StreamWriter writer = new StreamWriter(FILE_NAME);
                        writer.Write(text);
                        writer.Close();
                    }
                }
            }
        }
        finally
        {
        }
        return htmlText;
    }
    public void htmltopdf()
    {
        SautinSoft.PdfVision v = new SautinSoft.PdfVision();
        v.ConvertHtmlFileToPDFFile(@"http://stackoverflow.com/questions/3270417/how-to-save-current-aspx-page-as-html", @"E:\ppdf\a.pdf");
        Document doc = new Document();
        //PdfWriter.GetInstance(doc, new FileStream(@"E:\ppdf\a.pdf", System.IO.FileMode.Create));
        //HtmlParser.Parse(doc, @"E:\ppdf\a.html");
        ////XmlParser.Parse(doc, Server.MapPath("image\\test.xml"));
        ////ITextHandler h = new ITextHandler(doc, new TagMap("c:\\test.xml"));
        ////h.Parse("c:\\test.xml");

        //if (File.Exists(@"E:\ppdf\a.html"))
        //    File.Delete(@"E:\ppdf\a.html");
        //if (File.Exists(@"E:\ppdf\a.html"))
        //    File.Delete(@"E:\ppdf\a.html");
    }


    private void saveURLToImage(string url)
    {
        

        if (!string.IsNullOrEmpty(url))
        {
            string content = "";

            System.Net.WebRequest webRequest__1 = System.Net.WebRequest.Create(url);
            System.Net.WebResponse webResponse = webRequest__1.GetResponse();
            System.IO.StreamReader sr = new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8"));
            content = sr.ReadToEnd();
            //save to file
            byte[] b = Convert.FromBase64String(content);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(b, 0, b.Length);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            img.Save("c:\\pic.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            img.Dispose();
            ms.Close();
        }
    }




}
