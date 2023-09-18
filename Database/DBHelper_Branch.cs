using System.Data;
using System.Data.SqlClient;

namespace crud_demo.Database;

public class DbHelperBranch
{
    private static SqlConnection _connection;

    public DbHelperBranch(string connString)
    {
        _connection = new SqlConnection(connString);
    }
    
    public DataTable GetAllBranch()
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "[dbo].[PR_MST_Branch_Selectall]";
        DataTable dt = new DataTable();
        SqlDataReader sdr = cmd.ExecuteReader();
        dt.Load(sdr);
        _connection.Close();
        return dt;
    }
}