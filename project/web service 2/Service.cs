using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

//[System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    [WebMethod]
    public DataSet ShowTimeMovieName(string name)
    {
        string connectionstring = "Server=(local);Database=movie_mgmt;Trusted_Connection=True";
        //string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString();

        SqlConnection connection = new SqlConnection(connectionstring);
        connection.Open();

        string query = "select movie_name,actor,cinema_name,address_street,address_city,address_state,show_date,show_time,seats,screen from show_view where movie_name = '" + name + "' ;";
        SqlCommand command = new SqlCommand(query, connection);
        command.CommandType = CommandType.Text;
        //connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        DataTable myTable = new DataTable("myTable");
        myTable.Columns.Add("MovieName", typeof(string));
        myTable.Columns.Add("Actor", typeof(string));
        myTable.Columns.Add("CinemaName", typeof(string));
        myTable.Columns.Add("Street", typeof(string));
        myTable.Columns.Add("City", typeof(string));
        myTable.Columns.Add("State", typeof(string));
        myTable.Columns.Add("Date", typeof(string));
        myTable.Columns.Add("ShowTime ", typeof(string));
        myTable.Columns.Add("Seats", typeof(string));
        myTable.Columns.Add("Screen", typeof(string));

        while (reader.Read())
        {
            myTable.Rows.Add(new object[]
                 {
                      reader["movie_name"].ToString(), reader["actor"].ToString(), 
                      reader["cinema_name"].ToString(), reader["address_street"], reader
                      ["address_city"], reader["address_state"], reader["show_date"], reader["show_time"], 
                      reader["seats"],reader["screen"] });
        }
        //myTable.Load(reader);
        myTable.AcceptChanges();
        DataSet ds = new DataSet();
        ds.Tables.Add(myTable);
        ds.AcceptChanges();
        return ds;
    }

    [WebMethod]
    public DataSet ShowTimeCinemaName(string name)
    {
        string connectionstring = "Server=(local);Database=movie_mgmt;Trusted_Connection=True";
        //string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString();

        SqlConnection connection = new SqlConnection(connectionstring);
        connection.Open();

        string query = "select movie_name,actor,cinema_name,address_street,address_city,address_state,show_date,show_time,seats,screen from show_view where cinema_name = '" + name + "' ;";
        SqlCommand command = new SqlCommand(query, connection);
        command.CommandType = CommandType.Text;
        //connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        DataTable myTable = new DataTable("myTable");
        myTable.Columns.Add("MovieName", typeof(string));
        myTable.Columns.Add("Actor", typeof(string));
        myTable.Columns.Add("CinemaName", typeof(string));
        myTable.Columns.Add("Street", typeof(string));
        myTable.Columns.Add("City", typeof(string));
        myTable.Columns.Add("State", typeof(string));
        myTable.Columns.Add("Date", typeof(string));
        myTable.Columns.Add("ShowTime ", typeof(string));
        myTable.Columns.Add("Seats", typeof(string));
        myTable.Columns.Add("Screen", typeof(string));

        while (reader.Read())
        {
            myTable.Rows.Add(new object[]
                 {
                      reader["movie_name"].ToString(), reader["actor"].ToString(), 
                      reader["cinema_name"].ToString(), reader["address_street"], reader
                      ["address_city"], reader["address_state"], reader["show_date"], reader["show_time"], 
                      reader["seats"],reader["screen"] });
        }
        //myTable.Load(reader);
        myTable.AcceptChanges();
        DataSet ds = new DataSet();
        ds.Tables.Add(myTable);
        ds.AcceptChanges();
        return ds;
    }


}


