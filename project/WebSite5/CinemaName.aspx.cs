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

public partial class CinemaName : System.Web.UI.Page
{

    public static DataSet sGetValue;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            
            string str = TextBox1.Text;
            localhost.Service appService = new localhost.Service();
            sGetValue = appService.ShowTimeCinemaName(str);
            GridView1.DataSource = sGetValue;
            GridView1.DataBind();
            
        }
        catch(Exception gen)
        {
            Label1.Visible = true;
            Label1.Text = "Cinema name not found !! Enter again!!";
        }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
