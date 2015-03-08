using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Uddi;
using Microsoft.Uddi.Extensions;
using Microsoft.Uddi.Services;
using Microsoft.Uddi.Businesses;
using System.Xml;
using System.Text.RegularExpressions;
using System.Collections;

public partial class Default2 : System.Web.UI.Page
{
    ArrayList al = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        
       if (!IsPostBack)
       {
           try
           {
               UddiConnection myConn = new UddiConnection
               ("http://localhost/uddi/inquire.asmx",
                "https://localhost/uddi/publish.asmx",
                "http://localhost/uddi/extension.asmx");

               FindService fs = new FindService();
               fs.Names.Add("%");
               ServiceList found = fs.Send(myConn);

               
               for (int j = 0; j < found.ServiceInfos.Count; j++)
               {
                   
                   ListItem listItmTemp = new ListItem();
                   listItmTemp.Text = found.ServiceInfos[j].Names[0].Text;
                   listItmTemp.Value = found.ServiceInfos[j].Names[0].Text;
                   DropDownList1.Items.Add(listItmTemp);
                   DropDownList1.DataBind();
               }
           }
           catch 
           {
               
           }
       }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

            switch (DropDownList1.Text)
            {
                case "showTimings":
                    Response.Redirect("http://localhost:4981/WebSite5/DropST.aspx");
                    break;
                case "theater":
                    Response.Redirect("http://localhost:4981/WebSite5/DropTH.aspx");
                    break;
                case "movie_details":
                    Response.Redirect("http://localhost:4981/WebSite5/DropST.aspx");
                    break;
                case "theater_details":
                    Response.Redirect("http://localhost:4981/WebSite5/DropTH.aspx");
                    break;

            }
                 
    }

}
