using System.Data;
using System.Data.SqlClient;
using crud_demo.Areas.Branch.Models;

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
    public Branch GetBranchByID(int? BranchID)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_MST_Branch_Select_By_PK";
        cmd.Parameters.AddWithValue("@BranchID", BranchID);
        SqlDataReader reader = cmd.ExecuteReader();
        Branch branch = new Branch();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                branch.BranchId = Convert.ToInt32(reader["BranchID"]);
                branch.BranchName = reader["BranchName"].ToString();
                branch.BranchCode = reader["BranchCode"].ToString();
                branch.Created = Convert.ToDateTime(reader["Created"]);
                branch.Modified = Convert.ToDateTime(reader["Modified"]);
            }
        }

        _connection.Close();
        return branch;
    }

     public bool AddBranch(Branch branch)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_MST_Branch_Insert"; 

        // Add parameters for the stored procedure.
        cmd.Parameters.AddWithValue("BranchName", branch.BranchName);
        cmd.Parameters.AddWithValue("BranchCode", branch.BranchCode);
        cmd.Parameters.AddWithValue("Created", branch.Created);

        bool isAdded = Convert.ToBoolean(cmd.ExecuteNonQuery());
        _connection.Close();
        // check for is Branch added or not
        if (isAdded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool UpdateBranch(Branch branch)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_MST_Branch_UpdateByPK";

        // Add parameters for the stored procedure.
        cmd.Parameters.AddWithValue("BranchID", branch.BranchId);
        cmd.Parameters.AddWithValue("BranchName", branch.BranchName);
        cmd.Parameters.AddWithValue("BranchCode", branch.BranchCode);
        cmd.Parameters.AddWithValue("Created", branch.Created);

        bool isUpdated = Convert.ToBoolean(cmd.ExecuteNonQuery());
        _connection.Close();
        if (isUpdated)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeleteBranch(int branchID)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_MST_Branch_DeleteByPK"; 

        // Add the parameter for the stored procedure to specify the BranchID to be deleted.
        cmd.Parameters.AddWithValue("BranchID", branchID);

        bool isDeleted = Convert.ToBoolean(cmd.ExecuteNonQuery());
        _connection.Close();
        if (isDeleted)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}