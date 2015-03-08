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

public partial class DDTheatre : System.Web.UI.Page
{
    public static DataSet sGetValue;
    public static string str1;
    public static string str2;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        
    }
    
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        
        
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
     
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        str1 = TextBox1.Text;
        str2 = TextBox2.Text;
        localhost2.Service appService = new localhost2.Service();
        sGetValue = appService.getTheaterDistance(str1, str2);
        GridView1.DataSource = sGetValue;
        GridView1.DataBind();
    }
}
