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
using System.Text;

//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

//using Excel = Microsoft.Office.Interop.Excel;
//using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;

public partial class ABU_ToolChange : System.Web.UI.Page
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
    public Abu_Master objabu = new Abu_Master();
    public StringBuilder sb = new StringBuilder();
    ReportDocument rpt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadgrid();
            //loadexcelgrid(rpt);
        }
        else
        {
            //To solve the error:
            //Failed to export using the options you specified. Please check your options and try again.
            if (Request.Form["__EVENTTARGET"] == CRV.UniqueID)
            {
                loadexcelgrid(rpt);
            }
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void loadgrid()
    {
        da = new SqlDataAdapter("select ROW_NUMBER() over (order by b.ToolNumber) as IndexNo,a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Inactive'", strConnString);
        ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds);
        da.Fill(dt);
        if (ds.Tables[0].Rows.Count > 0)
        {
            paging.DataSource = dt.DefaultView;
            if (ds.Tables[0].Rows.Count > 8)
            {
                paging.AllowPaging = true;
                paging.PageSize = 8;
                paging.CurrentPageIndex = CurrentPage;
                ViewState["totalpage"] = paging.PageCount;
                link_previous.Enabled = !paging.IsFirstPage;
                link_next.Enabled = !paging.IsLastPage;
            }
            else
            {
                div_paging.Visible = false;
            }
            grid_abumaster.DataSource = paging;
            grid_abumaster.DataBind();
            createpaging();
        }
        else
        {
        }
    }
    private void createpaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");
        findex = CurrentPage - 10;
        if (CurrentPage >= 9)
        {
            lindex = CurrentPage + 10;
        }
        else
        {
            lindex = 10;
        }
        if (lindex > Convert.ToInt32(ViewState["totalpage"]))
        {
            lindex = Convert.ToInt32(ViewState["totalpage"]);
            findex = lindex - 10;
        }
        if (findex < 0)
        {
            findex = 0;
        }
        for (int i = findex; i < lindex; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }
        DataListPaging.DataSource = dt;
        DataListPaging.DataBind();
    }
    public int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] != null)

                return Convert.ToInt32(ViewState["CurrentPage"]);
            else
                return 0;
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }
    protected void DataListPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        LinkButton lnkPage = (LinkButton)e.Item.FindControl("link_pagebtn");
        if (lnkPage.CommandArgument.ToString() == CurrentPage.ToString())
        {
            lnkPage.Enabled = false;
            lnkPage.Font.Bold = true;
            lnkPage.Attributes.Add("class", "square_selected");
        }
        else
        {
            lnkPage.Attributes.Add("class", "square");
        }
    }
    protected void DataListPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("newpage"))
        {
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            loadgrid();
        }

    }
    protected void link_previous_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        loadgrid();
    }
    protected void link_next_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        loadgrid();
    }
    protected void grid_abumaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label ID = e.Row.FindControl("lbl_id") as Label;
            System.Web.UI.WebControls.Image image = e.Row.FindControl("ph_image") as System.Web.UI.WebControls.Image;
            TableCell cell = e.Row.Cells[2];
            Label lbl_retine = e.Row.FindControl("lbl_retine") as Label;
            Label lbl_remarks = e.Row.FindControl("lbl_remarks") as Label;
            Label lbl_maintain = e.Row.FindControl("lbl_maintain") as Label;
            if (ID.Text != "" && ID.Text != null)
            {
                da = new SqlDataAdapter("select * from Abu_Master where ID='" + Convert.ToInt32(ID.Text.ToString()) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select ROW_NUMBER() over (order by min(ToolNumber)) as IndexNo,min(SID) as SID,min(ToolNumber)as ToolNumber,min(Maximum)as Maximum,min(Minimum) as Minimum,min(CurrentStock) as TotalCount,min(Tool) as Tool  from SpareView  where Toolnumber='" + Convert.ToInt32(ds.Tables[0].Rows[0]["ToolNumber"].ToString()) + "' group by Toolnumber", strConnString);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        lbl_maintain.Text = ds1.Tables[0].Rows[0]["TotalCount"].ToString();
                    }

                    //image.ImageUrl = "~/ABU/Tools/" + ds.Tables[0].Rows[0]["Photo"].ToString();
                    if (ds.Tables[0].Rows[0]["Photo"] != null && ds.Tables[0].Rows[0]["Photo"].ToString() != "")
                    {
                        image.ImageUrl = "~/ABU/Tools/" + ds.Tables[0].Rows[0]["Photo"].ToString();
                    }
                    else
                    {
                        image.ImageUrl = "~/Menu_image/noimage.png";
                    }

                    if (ds.Tables[0].Rows[0]["LifeExtend"] != null && ds.Tables[0].Rows[0]["LifeExtend"].ToString() != "" && ds.Tables[0].Rows[0]["LifeExtend"].ToString() != "0")
                    {
                        int from = Convert.ToInt32(ds.Tables[0].Rows[0]["Rentime"].ToString());
                        int to = Convert.ToInt32(ds.Tables[0].Rows[0]["LifeExtend"].ToString());
                        int tot = from + to;
                        lbl_retine.Text = tot.ToString();
                        lbl_remarks.Text = "Life Extended";
                    }
                    else
                    {
                        lbl_retine.Text = ds.Tables[0].Rows[0]["Rentime"].ToString();
                        if (ds.Tables[0].Rows[0]["Spare"].ToString() == "Yes")
                        {
                            lbl_remarks.Text = "Spare Replaced";
                        }
                        else if (ds.Tables[0].Rows[0]["Spare"].ToString() == "No")
                        {
                            lbl_remarks.Text = "Life Extended";
                        }
                        else
                        {
                            lbl_remarks.Text = "";
                        }
                    }
                    string setColorClass = string.Empty;
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenTo"].ToString()))
                    {
                        setColorClass = "Green";
                    }
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowTo"].ToString()))
                    {
                        setColorClass = "Yellow";
                    }
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                    {
                        setColorClass = "Red";
                    }
                    else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                    {
                        setColorClass = "Red";
                    }
                    cell.CssClass = setColorClass;
                }
                else
                {
                }
            }
            else
            {
            }

        }


    }
    protected void OnDataBound(object sender, EventArgs e)
    {
        if (grid_abumaster.Rows.Count > 0)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            for (int i = 1; i < grid_abumaster.Columns.Count; i++)
            {
                TableHeaderCell cell = new TableHeaderCell();
                TextBox txtSearch = new TextBox();
                txtSearch.Attributes["placeholder"] = "Filter";
                txtSearch.CssClass = "search_textbox";
                cell.Controls.Add(txtSearch);
                row.Controls.Add(cell);
            }
            grid_abumaster.HeaderRow.Parent.Controls.AddAt(1, row);
        }
    }

    protected void btn_excel_Click(object sender, ImageClickEventArgs e)
    {
        ReportDocument rpt = new ReportDocument();
        loadexcelgrid(rpt);
        ExportFormatType formatType = ExportFormatType.NoFormat;
        switch ("PDF")
        {
            case "Word":
                formatType = ExportFormatType.WordForWindows;
                break;
            case "PDF":
                formatType = ExportFormatType.PortableDocFormat;
                break;
            case "Excel":
                formatType = ExportFormatType.Excel;
                break;
        }
        rpt.ExportToHttpResponse(formatType, Response, true, "ToolChange");
        Response.End();


        //ReportDocument cryRpt = new ReportDocument();
        //cryRpt.Load(@"D:\CrystalReport1.rpt");
        //CRV.ReportSource = cryRpt;
        //CRV.Refresh();
        //CRV.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ASD.pdf");
        //MessageBox.Show("Exported Successful");

        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition",
        // "attachment;filename=GridViewExport.doc");
        //Response.Charset = "";
        //Response.ContentType = "application/ms-word";
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //GridView1.AllowPaging = false;
        ////GridView1.DataBind();
        ////for (int i = 0; i < GridView1.Rows.Count; i++)
        ////{
        ////    GridViewRow row = GridView1.Rows[i];
        ////    //Apply text style to each Row
        ////    row.Attributes.Add("class", "textmode");
        ////}
        //GridView1.RenderControl(hw);

        //style to format numbers to string
        //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        //Response.Write(style);
        //string s = sw.ToString();
        //Response.Output.Write(sw.ToString());
        //Response.Flush();
        //Response.End();

        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition",
        //    "attachment;filename=GridViewExport.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //GridView1.AllowPaging = false;
        //GridView1.DataBind();
        //GridView1.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End(); 

        //Response.ContentType = "application/vnd.ms-excel";
        //Response.AddHeader("Content-Disposition", "attachment; filename=test.xls;");
        //StringWriter stringWrite = new StringWriter();
        //HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        ////dgrExport.DataSource = dtExport;
        ////dgrExport.DataBind();
        ////dgrExport.RenderControl(htmlWrite);
        //string headerTable = @"<Table><tr><td style='width:10px;height:10px;'><img src=""C:\\Users\\Public\\Pictures\\Sample Pictures\\Hydrangeas.jpg"" style='width:10px;height:10px;' \></td></tr></Table>";
        //Response.Write(headerTable);
        //Response.Write(stringWrite.ToString());
        //Response.End();

        //Response.Clear();
        //Response.AddHeader("content-disposition", "attachment;filename=ToolChange.xls");
        //Response.Charset = "";
        //Response.ContentType = "application/excel";
        //StringWriter StringWriter = new System.IO.StringWriter();
        //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        //grid_abumaster.RenderControl(HtmlTextWriter);
        //string s = StringWriter.ToString();
        //Response.Write(StringWriter.ToString());
        ////File.AppendAllText("E:\\", StringWriter.ToString());
        //Response.End();

        //loadexcelgrid();
        //Response.ClearContent();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Employees.xls"));
        //Response.ContentType = "application/ms-excel";
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter htw = new HtmlTextWriter(sw);
        //GridView1.AllowPaging = false;
        
        ////Change the Header Row back to white color
        //GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
        ////Applying stlye to gridview header cells
        //for (int i = 0; i < grid_abumaster.HeaderRow.Cells.Count; i++)
        //{
        //    GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
        //}
        //GridView1.RenderControl(htw);
        //Response.Write(sw.ToString());
        //Response.End();

        //loadexcelgrid();
        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition",
        // "attachment;filename=GridViewExport.xls");
        //Response.Charset = "";
        //Response.ContentType = "application/excel";
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //GridView1.AllowPaging = false;
        ////GridView1.DataBind();
        ////for (int i = 0; i < GridView1.Rows.Count; i++)
        ////{
        ////    GridViewRow row = GridView1.Rows[i];
        ////    //Apply text style to each Row
        ////    row.Attributes.Add("class", "textmode");
        ////}
        //GridView1.RenderControl(hw);

        ////style to format numbers to string
        ////string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        ////Response.Write(style);
        //string s = sw.ToString();
        //Response.Output.Write(sw.ToString());
        //Response.Flush();
        //Response.End();

        //loadexcelgrid();
        //DataTable dt = new DataTable("GridView_Data");
        //foreach (TableCell cell in GridView1.HeaderRow.Cells)
        //{
        //    dt.Columns.Add(cell.Text);
        //}
        //foreach (GridViewRow row in GridView1.Rows)
        //{
        //    dt.Rows.Add();
        //    for (int i = 0; i < row.Cells.Count; i++)
        //    {
        //        dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
        //    }
        //}
        //using (XLWorkbook wb = new XLWorkbook())
        //{
        //    wb.Worksheets.Add(dt);

        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //    Response.AddHeader("content-disposition", "attachment;filename=GridView.xlsx");
        //    using (MemoryStream MyMemoryStream = new MemoryStream())
        //    {
        //        wb.SaveAs(MyMemoryStream);
        //        MyMemoryStream.WriteTo(Response.OutputStream);
        //        Response.Flush();
        //        Response.End();
        //    }
        //}

//          Response.Clear();
//    Response.Buffer = true;
//    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
//    Response.Charset = "";
//    Response.ContentType = "application/vnd.ms-excel";
//    using (StringWriter sw = new StringWriter())
//    {
//        HtmlTextWriter hw = new HtmlTextWriter(sw);

//        //To Export all pages
//        GridView1.AllowPaging = false;
//        //this.BindGrid();

//        //GridView1.HeaderRow.BackColor = Color.White;
//        foreach (TableCell cell in GridView1.HeaderRow.Cells)
//        {
//            cell.BackColor = GridView1.HeaderStyle.BackColor;
//        }
//        foreach (GridViewRow row in GridView1.Rows)
//        {
//            //row.BackColor = Color.White;
//            foreach (TableCell cell in row.Cells)
//            {
//                if (row.RowIndex % 2 == 0)
//                {
//                    cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
//                }
//                else
//                {
//                    cell.BackColor = GridView1.RowStyle.BackColor;
//                }
//                cell.Width = 10;
//                cell.Height = 10;
//                cell.CssClass = "textmode";
//            }
//        }

//        GridView1.RenderControl(hw);
//        GridView1.Caption = "Your caption";
//GridView1.Style.Add("width", "400px");
//GridView1.HeaderRow.Style.Add("font-size", "12px");
//GridView1.HeaderRow.Style.Add("font-weight", "bold");
//GridView1.Style.Add("border", "1px solid black");
//GridView1.Style.Add("text-decoration", "none");
//GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
//GridView1.Style.Add("class", "img");

//        //style to format numbers to string
//        string style = @"<style> .textmode { mso-number-format:\@; text-align:center;} </style>";
//        Response.Write(style);
//        string ss = sw.ToString();
//        Response.Output.Write(sw.ToString());
//        Response.Flush();
//        Response.End();
//    }
        //// ADD A WORKBOOK USING THE EXCEL APPLICATION.
        //Excel.Application xlAppToExport = new Excel.Application();
        //xlAppToExport.Workbooks.Add("");

        //// ADD A WORKSHEET.
        //Excel.Worksheet xlWorkSheetToExport = default(Excel.Worksheet);
        //xlWorkSheetToExport = (Excel.Worksheet)xlAppToExport.Sheets["Sheet1"];

        //// ROW ID FROM WHERE THE DATA STARTS SHOWING.
        //int iRowCnt = 4;

        //// SHOW THE HEADER.
        //xlWorkSheetToExport.Cells[1, 1] = "Employee Details";

        //Excel.Range range = xlWorkSheetToExport.Cells[1, 1] as Excel.Range;
        //range.EntireRow.Font.Name = "Calibri";
        //range.EntireRow.Font.Bold = true;
        //range.EntireRow.Font.Size = 20;

        //xlWorkSheetToExport.Range["A1:L1"].MergeCells = true;       // MERGE CELLS OF THE HEADER.

        //// SHOW COLUMNS ON THE TOP.
        //xlWorkSheetToExport.Cells[iRowCnt - 1, 1] = "Employee Name";
        //xlWorkSheetToExport.Cells[iRowCnt - 1, 2] = "Mobile No.";
        //xlWorkSheetToExport.Cells[iRowCnt - 1, 3] = "PresentAddress";
        //xlWorkSheetToExport.Cells[iRowCnt - 1, 4] = "Email Address";


        //int i;
        //for (i = 0; i <= dt.Rows.Count - 1; i++)
        //{
        //    xlWorkSheetToExport.Cells[iRowCnt, 1] = dt.Rows[i].Field("ToolNumber");
        //    xlWorkSheetToExport.Cells[iRowCnt, 2] = dt.Rows[i].Field("");
        //    xlWorkSheetToExport.Cells[iRowCnt, 3] = dt.Rows[i].Field("");
        //    xlWorkSheetToExport.Cells[iRowCnt, 4] = dt.Rows[i].Field("Photo");

        //    iRowCnt = iRowCnt + 1;
        //}

        //// FINALLY, FORMAT THE EXCEL SHEET USING EXCEL'S AUTOFORMAT FUNCTION.
        //Excel.Range range1 = xlAppToExport.ActiveCell.Worksheet.Cells[4, 1] as Excel.Range;
        //range1.AutoFormat(ExcelAutoFormat.xlRangeAutoFormatList3);

        //// SAVE THE FILE IN A FOLDER.
        //xlWorkSheetToExport.SaveAs("D:\\" + "EmployeeDetails.xlsx");

        //// CLEAR.
        //xlAppToExport.Workbooks.Close();
        //xlAppToExport.Quit();
        //xlAppToExport = null;
        //xlWorkSheetToExport = null;

    }

    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        MemoryStream ms = new MemoryStream();
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        return ms.ToArray();
    }
    public void loadexcelgrid(ReportDocument rpt)
    {

        da = new SqlDataAdapter("select a.* ,b.ToolNumber as Tool from Abu_Master  a inner join AbuToolMaster b on cast(a.ToolNumber as int)=b.ID where a.ToolStatus='Inactive'", strConnString);
        ds = new DataSet();
        DataTable dt = new DataTable("Abu_Master");
        dt.Clear();
        da.Fill(ds);
        da.Fill(dt);
        dt.Columns.Add("PhotoImg", System.Type.GetType("System.Byte[]"));
        dt.Columns.Add("Remarks");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                FileStream fs;
                BinaryReader br;

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "ABU\\Tools\\" + dt.Rows[i]["Photo"].ToString()))
                {
                    // open image in file stream
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "ABU\\Tools\\" + dt.Rows[i]["Photo"].ToString(), FileMode.Open);
                }
                else
                {
                    // if photo does not exist show the nophoto.jpg file
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Menu_image\\noimage.png", FileMode.Open);
                }
                br = new BinaryReader(fs);
                // define the byte array of file length
                byte[] imgbyte = new byte[fs.Length + 1];
                // read the bytes from the binary reader
                imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));
                dt.Rows[i]["PhotoImg"] = imgbyte;
                //drow[0] = br.Read(imgbyte, 0, imgbyte.Length);
                dt.AcceptChanges();
                // add row into the data table
                br.Close();
                // close the binary reader
                fs.Close();
                if (dt.Rows[i]["Spare"].ToString() == "Yes")
                {
                    dt.Rows[i]["Remarks"] = "Spare Replaced";
                }
                else if (dt.Rows[i]["Spare"].ToString() == "No")
                {
                    dt.Rows[i]["Remarks"] = "Life Extended";
                }
                else
                {
                    dt.Rows[i]["Remarks"] = "";
                }

            }
            
            //ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("~/ABU/ToolChangeRpt.rpt"));
            rpt.SetDataSource(dt);
            CRV.ReportSource = rpt;

            //CRV.Refresh();
            //CRV.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ASD.pdf");
            //MessageBox.Show("Exported Successful");

            //foreach (DataRow row in dt.Rows)
            //{
            //    if (row["Photo"].ToString() == "")
            //    {
            //        string path = GetUrl("Menu_image/noimage.png");
            //        row.SetField("Photo", path);
            //    }
            //    else
            //    {
            //        string path = GetUrl("ABU/Tools/" + ds.Tables[0].Rows[0]["Photo"].ToString());
            //        row.SetField("Photo", path);
            //    }
            //}

            //sb.Append("<div><table style='width:100%;'><tr style='background-color:#105fe0;height:35px;'><td style='text-align:center; color:#fff;width:150px;'><span>Tool No</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Availability</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Station</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Spare</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Retension Time</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Issued On</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Next Due</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Photo</span></td></tr>");
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    sb.Append("<tr><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;background-color:red;'><span>" + ds.Tables[0].Rows[i]["Tool"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Availability"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Station"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Maintained"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Rentime"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Issuedon"].ToString() + "</span></td><td style='text-align:center; color:#000;width:150px;border:solid 1px #000;'><span>" + ds.Tables[0].Rows[i]["Nextdueon"].ToString() + "</span></td><td style='text-align:center; width:150px;border:solid 1px #000;'><div><table><tr><td><img src='" + dt.Rows[i]["Photo"].ToString() + "<'/></td></tr></table></div></td></tr>");

            //}
            //sb.Append("</table></div>");

            //string savepath = Server.MapPath("~/ABU/ToolChange/");
            //if (!Directory.Exists(savepath))
            //{
            //    Directory.CreateDirectory(savepath);
            //}
            //using (StringWriter sw = new StringWriter(sb))
            //{
            //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            //    {
            //        StreamWriter writer = File.AppendText(savepath + "Tools.xls");
            //        hw.BeginRender();
            //        string html = sb.ToString();
            //        writer.WriteLine(html);
            //        writer.Close();
            //    }
            //}
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=ToolChange.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/excel";
            //StringWriter StringWriter = new System.IO.StringWriter();
            //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
            ////grid_abumaster.RenderControl(HtmlTextWriter);
            //string s = sb.ToString();
            //Response.Write(sb.ToString());
            ////File.AppendAllText("E:\\", StringWriter.ToString());
            //Response.End();

            //GridView1.DataSource = dt.DefaultView;
            //GridView1.DataBind();
        }
        else
        {
        }
    }
    protected string GetUrl(string imagepath)
    {
        //imagepath = "Menu_image/noimage.png";
        string[] splits = Request.Url.AbsoluteUri.Split('/');
        if (splits.Length >= 2)
        {
            string url = splits[0] + "//";
            for (int i = 2; i < splits.Length - 2; i++)
            {
                url += splits[i];
                url += "/";
            }
            return url + imagepath;
        }
        return imagepath;
    }

    //private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
    //{
    //    using (var image = System.Web.UI.WebControls.Image.FromStream(sourcePath))
    //    {
    //        var newWidth = (int)(image.Width * scaleFactor);
    //        var newHeight = (int)(image.Height * scaleFactor);
    //        var thumbnailImg = new Bitmap(newWidth, newHeight);
    //        var thumbGraph = Graphics.FromImage(thumbnailImg);
    //        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
    //        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
    //        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
    //        thumbGraph.DrawImage(image, imageRectangle);
    //        thumbnailImg.Save(targetPath, image.RawFormat);
    //    }
    //}

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label ID1 = e.Row.FindControl("lbl_id1") as Label;
            System.Web.UI.WebControls.Image image1 = e.Row.FindControl("ph_image1") as System.Web.UI.WebControls.Image;
            TableCell cell = e.Row.Cells[2];
            Label lbl_retine1 = e.Row.FindControl("lbl_retine1") as Label;
            Label lbl_remarks1 = e.Row.FindControl("lbl_remarks1") as Label;
            if (ID1.Text != "" && ID1.Text != null)
            {
                da = new SqlDataAdapter("select * from Abu_Master where ID='" + Convert.ToInt32(ID1.Text.ToString()) + "'", strConnString);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //image.ImageUrl = "~/ABU/Tools/" + ds.Tables[0].Rows[0]["Photo"].ToString();
                    if (ds.Tables[0].Rows[0]["Photo"] != null && ds.Tables[0].Rows[0]["Photo"].ToString() != "")
                    {
                        //string targetPath = "~/ABU/ToolChange/" + ds.Tables[0].Rows[0]["Photo"].ToString();
                        //string ppath="~/ABU/Tools/" + ds.Tables[0].Rows[0]["Photo"].ToString();
                        //GenerateThumbnails(0.5, ppath,targetPath);
                        image1.ImageUrl =GetUrl("ABU/Tools/" + ds.Tables[0].Rows[0]["Photo"].ToString()); 
                    }
                    else
                    {
                        image1.ImageUrl = GetUrl("Menu_image/noimage.png"); 
                    }

                    if (ds.Tables[0].Rows[0]["LifeExtend"] != null && ds.Tables[0].Rows[0]["LifeExtend"].ToString() != "")
                    {
                        int from = Convert.ToInt32(ds.Tables[0].Rows[0]["Rentime"].ToString());
                        int to = Convert.ToInt32(ds.Tables[0].Rows[0]["LifeExtend"].ToString());
                        int tot = from + to;
                        lbl_retine1.Text = tot.ToString();
                        lbl_remarks1.Text = "Life Extended";
                    }
                    else
                    {
                        lbl_retine1.Text = ds.Tables[0].Rows[0]["Rentime"].ToString();
                        lbl_remarks1.Text = "Spare Replaced";
                    }
                    string setColorClass = string.Empty;
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["GreenTo"].ToString()))
                    {
                        setColorClass = "Green";
                    }
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["YellowTo"].ToString()))
                    {
                        setColorClass = "Yellow";
                    }
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedFrom"].ToString()) && Convert.ToDateTime(DateTime.Now.ToShortDateString()) <= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                    {
                        setColorClass = "Red";
                    }
                    else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime(ds.Tables[0].Rows[0]["RedTo"].ToString()))
                    {
                        setColorClass = "Red";
                    }
                    cell.CssClass = setColorClass;
                }
                else
                {
                }
            }
            else
            {
            }

        }


    }
}
