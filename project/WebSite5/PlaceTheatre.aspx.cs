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
using System.Text;

public partial class PlaceTheatre : System.Web.UI.Page
{
    public static DataSet sGetValue;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string str = TextBox1.Text;
            localhost2.Service appService = new localhost2.Service();
            sGetValue = appService.getTheaters(str);
            GridView1.DataSource = sGetValue;
            GridView1.DataBind();
        }
        catch
        {
        }
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
