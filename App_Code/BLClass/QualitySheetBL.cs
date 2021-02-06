using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using System.Threading;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
/// <summary>
/// Summary description for QualitySheetBL
/// </summary>
public class QualitySheetBL
{
    public SqlConnection strConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
    public DBServer objserver = new DBServer();
    public SqlCommand cmd;
    public DataSet ds;
    public QualitySheetDL objqualitysheetdl = new QualitySheetDL();

    public void update_changesBL(decimal max, decimal min,decimal maxd2,decimal mind2, decimal maxd3,decimal mind3,decimal maxd4,decimal mind4, string mode,string Pid,string date,string shift)
    {
        objqualitysheetdl.updatechangesDA(max, min,maxd2, mind2,maxd3, mind3, maxd4,mind4, mode,Pid,date,shift);
    }
    public void updatechangesBL(decimal max, decimal min, decimal maxd2, decimal mind2, decimal maxd3, decimal mind3, decimal maxd4, decimal mind4, string mode, string Pid, string date, string shift)
    {
        objqualitysheetdl.updatechanges_DA(max, min, maxd2, mind2, maxd3, mind3, maxd4, mind4, mode, Pid, date, shift);
    }
    public string save_registrationBL(string username, string password, string role, string date, string repassword)
    {
        string result = "";
        objqualitysheetdl.Username = username.ToString();
        objqualitysheetdl.Password = password.ToString();
        objqualitysheetdl.Role = role.ToString();
        objqualitysheetdl.Date = date.ToString();
        result = objqualitysheetdl.save_registrationDA(objqualitysheetdl.Username, objqualitysheetdl.Password, objqualitysheetdl.Role, objqualitysheetdl.Date, repassword);
        return result.ToString();
    }
    public void save_regpagesBL(string regid, string page, string role, string pageref)
    {
        objqualitysheetdl.RegID = regid;
        objqualitysheetdl.Pagename = page;
        objqualitysheetdl.Role = role.ToString();
        objqualitysheetdl.Reff = pageref.ToString();
        objqualitysheetdl.save_regpagesDA(objqualitysheetdl.RegID, objqualitysheetdl.Pagename, objqualitysheetdl.Role, objqualitysheetdl.Reff);

    }
    public void show_Access_RightsBL( HtmlAnchor link_24q,  HtmlAnchor link_6j, HtmlAnchor  link_1c, HtmlAnchor  link_8n, HtmlAnchor  link_3u, HtmlAnchor  link_process, HtmlAnchor  link_part,  HtmlAnchor link_work, HtmlAnchor  link_userpage,   HtmlAnchor link_time,  HtmlAnchor link_laping24,  HtmlAnchor link_opt24, HtmlAnchor  link_poli24,  HtmlAnchor   link_register, HtmlAnchor  link_dmttemp, HtmlAnchor   link_opt2j, HtmlAnchor  link_poliJ,  HtmlAnchor link_polc,  HtmlAnchor link_polu,  HtmlAnchor link_poln, HtmlAnchor  link_planned, HtmlAnchor  link_barcode,  HtmlAnchor  link_addpages, string userid)
    {
        objqualitysheetdl.show_Access_RightsDA(link_24q, link_6j, link_1c, link_8n, link_3u, link_process, link_part, link_work, link_userpage, link_time, link_laping24, link_opt24, link_poli24,  link_register, link_dmttemp, link_opt2j, link_poliJ, link_polc, link_polu, link_poln, link_planned, link_barcode, link_addpages, userid);
    }
    public void Login_userBL(string username, string password,string shift)
    {
        objqualitysheetdl.Login_userDA(username, password, shift);
    }
    public DataSet get_qualitysheetdataBL(string mode)
    {
        ds = new DataSet();
        ds = objqualitysheetdl.get_qualitysheetdataDA(mode);
        return ds;
    }
    public void insertupdatereportsBL(string filename, string filepath, int createdby, DateTime createdon, string shift, string operat)
    {
        objqualitysheetdl.insertupdatereportsDA(filename, filepath, createdby, createdon, shift, operat);
    }
    public string generate_excelBL(string shift, string prodn_no1, string operation, string pidno)
    {
        string restult = "";
        restult = objqualitysheetdl.generate_excelDA(shift, prodn_no1, operation, pidno);
        return restult.ToString();
    }
    public void load_pidBL( string prodn_no, string operation)
    {
    }
    public void load_shtBL(HtmlSelect txt_mchn, string shift)
    {
        objqualitysheetdl.load_shtDA(txt_mchn, shift);
    }
    public void load_userBL(HtmlSelect ddl_operator)
    {
        objqualitysheetdl.load_userDA(ddl_operator);
    }
    public void show_pagesBL(HtmlAnchor link_user, HtmlAnchor link_admin,string user)
    {
        objqualitysheetdl.show_pagesDA(link_user, link_admin, user);
    }
    public void getuserdetailsBL(string pidno)
    {
        objqualitysheetdl.getuserdetailsDA(pidno);
    }
    public void showprodataBL(HtmlAnchor link_data,string username,string partno,string operation)
    {
        objqualitysheetdl.showprodataDA(link_data, username, partno, operation);
    }
    public void showprodataBL1(HtmlAnchor link_data, string username, string partno, string operation)
    {
        objqualitysheetdl.showprodataDA1(link_data, username, partno, operation);
    }
}
