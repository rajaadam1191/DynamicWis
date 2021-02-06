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
public partial class ABU_Videos : System.Web.UI.Page
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    DBServer objserver = new DBServer();
    public QualitySheetBL objqualitysheetbl = new QualitySheetBL();
    public DataSet ds;
    public SqlDataAdapter da;
    public SqlCommand cmd;
    public int findex, lindex, count = 0;
    public PagedDataSource paging = new PagedDataSource();
    public QualitySheetdclassDataContext objcontext = new QualitySheetdclassDataContext();
    public ToolVideofile objv = new ToolVideofile();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadgrid();

    }
    public void loadgrid()
    {
        da = new SqlDataAdapter("select * from ToolVideofiles", strConnString);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grid_abumaster.DataSource = ds.Tables[0];
            grid_abumaster.DataBind();
        }
        else
        {
        }
    }
    public void createfolder(string filepath, string date)
    {
        DirectoryInfo dirifo = new DirectoryInfo(filepath);
        dirifo.CreateSubdirectory(date);
    }
    protected void btn_submit_Click(object sender, ImageClickEventArgs e)
    {
        string path = "";
        string filename = "";
        if (f_videofile.HasFile)
        {

            path = Server.MapPath("~/ABU/");
            createfolder(path, "Videos");
            //filename = f_videofile.PostedFile.FileName.ToString();
            filename = System.IO.Path.GetFileName(f_videofile.PostedFile.FileName.ToString());
            // string f_name = path + "Tools" + '\\' + Path.GetFileName(up_photo.PostedFile.FileName);
            f_videofile.PostedFile.SaveAs(path + "Videos" + '\\' + filename);
            objcontext = new QualitySheetdclassDataContext();
            objv = new ToolVideofile()
            {
                FileName = filename.ToString()
            };
            objcontext.ToolVideofiles.InsertOnSubmit(objv);
            objcontext.SubmitChanges();
            loadgrid();
        }
    }
}
