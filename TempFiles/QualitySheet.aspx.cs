using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QualitySheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txtmmax2_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void txtmax1_TextChanged(object sender, EventArgs e)
    {
        //TextBox1.Style.Add("BackColor", "Green");
        //TextBox1.BackColor = System.Drawing.Color.Red;
        if (Convert.ToDouble(txtmax1.Text.ToString()) > 67.623)
        {
            string hex = "#ff0000";
            txtmax1.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
            hex = string.Empty;
        }
        else
        {
            string hex = "#0F7FC7";
            txtmax1.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
            hex = string.Empty;
        }
    }
    protected void txtmin1_TextChanged(object sender, EventArgs e)
    {
         if (Convert.ToDouble(txtmin1.Text.ToString()) < 67.577)
        {
            string hex = "#fbbf01";
            txtmin1.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
            hex = string.Empty;
        }
        else
        {
            string hex = "#0F7FC7";
            txtmin1.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
            hex = string.Empty;
        }
    }
}