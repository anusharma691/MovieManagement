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

public partial class DropST : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (DropDownList1.Text)
        {
            case "Show time choosing movie name":
                Response.Redirect("http://localhost:4981/WebSite5/inputMovieName.aspx");
                break;
            case "Show time choosing cinema name":
                Response.Redirect("http://localhost:4981/WebSite5/CinemaName.aspx");
                break;
            

        }
    }
}
