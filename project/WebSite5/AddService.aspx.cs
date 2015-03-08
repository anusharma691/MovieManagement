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
using Microsoft.Uddi;
using Microsoft.Uddi.Extensions;
using Microsoft.Uddi.Services;
using Microsoft.Uddi.Businesses;
using System.Xml;
using System.Text.RegularExpressions;
using Microsoft.Uddi.TModels;

public partial class AddService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        if (!IsPostBack)
        {
            UddiConnection myConn = new UddiConnection("http://localhost/uddi/inquire.asmx",
                             "http://localhost/uddi/publish.asmx",
                            "http://localhost/uddi/extension.asmx");

            ArrayList tmodelkey = new ArrayList();
            ArrayList tmodelnames = new ArrayList();

            FindTModel findt = new FindTModel("%");
            TModelList bizList = findt.Send(myConn);

            bizList.TModelInfos[1].Name.ToString();
            for (int i = 0; i < bizList.TModelInfos.Count; i++)
            {
                tmodelnames.Add(bizList.TModelInfos[i].Name.Text);
                tmodelkey.Add(bizList.TModelInfos[i].TModelKey.ToString());
               
                ListItem listTemp = new ListItem();
                listTemp.Text = bizList.TModelInfos[i].Name.Text;
                listTemp.Value = bizList.TModelInfos[i].TModelKey.ToString();
                DropDownList1.Items.Add(listTemp);
                DropDownList1.DataBind();
            }

        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ArrayList tmodelkey = new ArrayList();
        ArrayList tmodelnames = new ArrayList();

        UddiConnection myConn1 = new UddiConnection("http://localhost/uddi/inquire.asmx",
                         "http://localhost/uddi/publish.asmx",
                        "http://localhost/uddi/extension.asmx");



        FindTModel findt = new FindTModel("%");
        TModelList bizList = findt.Send(myConn1);

        bizList.TModelInfos[1].Name.ToString();
        for (int i = 0; i < bizList.TModelInfos.Count; i++)
        {
            tmodelnames.Add(bizList.TModelInfos[i].Name.Text);
            tmodelkey.Add(bizList.TModelInfos[i].TModelKey.ToString());
        }

        String temp = DropDownList1.Text;

        UddiConnection myConn = new UddiConnection
                ("http://localhost/uddi/inquire.asmx",
                 "http://localhost/uddi/publish.asmx",
                 "http://localhost/uddi/extension.asmx");

        myConn.Username = "Administrator";
        myConn.Password = "";
        myConn.AuthenticationMode = Microsoft.Uddi.AuthenticationMode.WindowsAuthentication;

         //Creating a new business entry.
       SaveBusiness svb = new SaveBusiness();
       BusinessEntity be = new BusinessEntity(TextBox1.Text);
       svb.BusinessEntities.Add(be);

       //Creating a new business service.
       BusinessService bs = new BusinessService(TextBox2.Text);
       svb.BusinessEntities[0].BusinessServices.Add(bs);

       //Creating a new binding template.
       BindingTemplate bt = new BindingTemplate();
       bt.AccessPoint.Text = "http://localhost/WebSite/Service.asmx";
       bt.AccessPoint.UrlType = Microsoft.Uddi.UrlType.Http;
       svb.BusinessEntities[0].BusinessServices[0].BindingTemplates.Add(bt);
       
        
        // Creating a Tmodel and binding it with  the Service
       TModelInstanceInfo tmi = new TModelInstanceInfo();
       tmi.TModelKey = temp;
       svb.BusinessEntities[0].BusinessServices[0].BindingTemplates[0].TModelInstanceInfos.Add(tmi);
       try
       {
           BusinessDetail bd = svb.Send(myConn);
       }
       catch (UddiException ue)
       {
           Label1.Text = ue.Message;
       }
       catch (Exception ex)
       {
           Label1.Text = ex.Message;
       }
       Label1.Visible = true;
       Label1.Text = "Service Sucessfully Published";
       TextBox1.Text = "";
       TextBox2.Text = "";

       myConn = new UddiConnection("http://localhost/uddi/inquire.asmx",
                       "http://localhost/uddi/publish.asmx",
                      "http://localhost/uddi/extension.asmx");

       findt = new FindTModel("%");

       bizList = findt.Send(myConn);

       DropDownList1.Items.Clear();
       bizList.TModelInfos[1].Name.ToString();
       for (int i = 0; i < bizList.TModelInfos.Count; i++)
       {
           tmodelnames.Add(bizList.TModelInfos[i].Name.Text);
           tmodelkey.Add(bizList.TModelInfos[i].TModelKey.ToString());
           ListItem listTemp = new ListItem();
           listTemp.Text = bizList.TModelInfos[i].Name.Text;
           listTemp.Value = bizList.TModelInfos[i].TModelKey.ToString();
           DropDownList1.Items.Add(listTemp);
           DropDownList1.DataBind();
       }
 
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
