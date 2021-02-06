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
using System.Drawing.Imaging;
using System.IO;


public partial class index1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getdate();
    }

    public void getdate()
    {
        //System.DateTime date1 = new System.DateTime(1996, 6, 3, 22, 15, 0);
        //System.DateTime date2 = new System.DateTime(1996, 12, 6, 13, 2, 0);
        //System.DateTime date3 = new System.DateTime(1996, 10, 12, 8, 42, 0);

        //// diff1 gets 185 days, 14 hours, and 47 minutes.
        //System.TimeSpan diff1 = date2.Subtract(date1);

        //// date4 gets 4/9/1996 5:55:00 PM.
        //System.DateTime date4 = date3.Subtract(diff1);

        //// diff2 gets 55 days 4 hours and 20 minutes.
        //System.TimeSpan diff2 = date2 - date3;

        //// date5 gets 4/9/1996 5:55:00 PM.
        //System.DateTime date5 = date1 - diff2;

        string date = System.DateTime.Now.ToShortTimeString();
        string date1 = System.DateTime.Now.ToShortTimeString();
        DateTime dt = Convert.ToDateTime(date);
        DateTime dt1 = Convert.ToDateTime(date1);

        System.TimeSpan diff1 = dt.Subtract(dt1);

        string total = diff1.TotalDays.ToString();
        string total1 = diff1.TotalHours.ToString();
        string total2 = diff1.TotalMinutes.ToString();
        string total3 = diff1.TotalSeconds.ToString();
    }

}
