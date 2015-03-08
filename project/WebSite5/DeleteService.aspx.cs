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
using System.Collections.Specialized;
using Microsoft.Uddi;
using Microsoft.Uddi.Extensions;
using Microsoft.Uddi.Services;
using Microsoft.Uddi.Businesses;
using System.Collections.Generic;
using Microsoft.Uddi.TModels;
using System.Text.RegularExpressions;
 

public partial class DeleteService : System.Web.UI.Page
{
    ArrayList names = new ArrayList();
   ArrayList serviceKey = new ArrayList();

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        if (!IsPostBack)
        {
            try
            {
                UddiConnection myConn = new UddiConnection
                ("http://localhost/uddi/inquire.asmx",
                 "https://localhost/uddi/publish.asmx",
                 "http://localhost/uddi/extension.asmx");

                //Finding all the service registered on uddi.
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
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        string temp1 = DropDownList1.Text;
       string[] name = Regex.Split(temp1, "\r\n");
       string temp2 = name[0].ToString();


      

          string Username ="Administrator";
          string Password = "";

           
           UddiConnection myConn = new UddiConnection
           ("http://localhost/uddi/inquire.asmx",
            "http://localhost/uddi/publish.asmx",
            "http://localhost/uddi/extension.asmx");

            FindService fs = new FindService();
           fs.Names.Add("%");
           ServiceList found = fs.Send(myConn);
           for (int i = 0; i < found.ServiceInfos.Count; i++)
           {
               names.Add(found.ServiceInfos[i].Names[0].Text);
               serviceKey.Add(found.ServiceInfos[i].ServiceKey.ToString());
           
           }
           myConn.Username = Username;
           myConn.Password = Password;
           myConn.AuthenticationMode = AuthenticationMode.WindowsAuthentication;

           int index = names.IndexOf(temp2);
           Microsoft.Uddi.DeleteService ds = new Microsoft.Uddi.DeleteService();
           ds.ServiceKeys.Add(serviceKey[index].ToString());
           DispositionReport dispRep = ds.Send(myConn);

           Label1.Visible = true;
           Label1.Text = "Service Sucessfully Deleted";
           fs.Names.Add("%");
           ServiceList found1 = fs.Send(myConn);

           // Result added to the dropdown
           DropDownList1.Items.Clear();
           DropDownList1.Items.Add(new ListItem("Select Webservice", "Select"));
           for (int j = 0; j < found1.ServiceInfos.Count; j++)
           {

               ListItem listItmTemp = new ListItem();
               listItmTemp.Text = found1.ServiceInfos[j].Names[0].Text;
               listItmTemp.Value = found1.ServiceInfos[j].Names[0].Text;
               DropDownList1.Items.Add(listItmTemp);
               DropDownList1.DataBind();
           }

      }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
}
