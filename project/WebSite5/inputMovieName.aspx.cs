using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Configuration;



public partial class inputMovieName : System.Web.UI.Page
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
            localhost.Service appService = new localhost.Service();
            sGetValue = appService.ShowTimeMovieName(str);
            GridView1.DataSource = sGetValue;
            GridView1.DataBind();
        }
        catch
        {
            TextBox1.Text = "Movie name not found !! Enter again!!";
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    
}
