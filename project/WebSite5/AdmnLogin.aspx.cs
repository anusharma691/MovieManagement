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
using System.Collections.Generic;
using System.Data.SqlClient;


public partial class AdmnLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void  Login1_Authenticate1(object sender, AuthenticateEventArgs e)
{


        try
        {
            string uname = Login1.UserName.Trim();
            string password = Login1.Password.Trim();

            bool flag = AuthenticateUser(uname, password);
            if (flag == true)
            {
                e.Authenticated = true;
                //Login1.DestinationPageUrl = "http://localhost:53188/WebSite4/Service.asmx";
                Response.Redirect("http://localhost:4981/WebSite5/AddDeletePage.aspx");
            }
            else
                e.Authenticated = false;
        }
        catch (Exception)
        {
            e.Authenticated = false;
        }
    }


    private bool AuthenticateUser(string uname, string password)
    {
        bool bflag = false;
        string connString = "Server=(local);Database=movie_mgmt;Trusted_Connection=True";
        using (SqlConnection connection = new SqlConnection(connString))
        {       
            string strSQL = "Select * from dbo.administrator where adminname ='" + uname + "' and password ='" + password + "'";
            DataSet userDS = new DataSet();
            SqlConnection m_conn;
            SqlDataAdapter m_dataAdapter;
            
            try
            {
                m_conn = new SqlConnection(connString);
                m_conn.Open();
                m_dataAdapter = new SqlDataAdapter(strSQL, m_conn);
                m_dataAdapter.Fill(userDS);
                m_conn.Close();
            }
            catch (Exception)
            {
                userDS = null;
            }

            if (userDS != null)
            {
                if (userDS.Tables[0].Rows.Count > 0)
                    bflag = true;
            }
            return bflag;

        }
    }

}

