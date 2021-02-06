using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for BL_Machine
/// </summary>
public class BL_Machine
{

    private string _Mode;
    private string _ByExcel;

    public string ByExcel
    {
        get { return _ByExcel; }
        set { _ByExcel = value; }
    }

    public string Mode
    {
        get { return _Mode; }
        set { _Mode = value; }
    }

	public BL_Machine()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
