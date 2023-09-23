using System.Data;
using System.Data.SqlClient;
using crud_demo.Areas.State.Models;

namespace crud_demo.Database;

public class DbHelperState
{
    private static SqlConnection _connection;

    public DbHelperState(string connString)
    {
        _connection = new SqlConnection(connString);
    }

    public DataTable GetAllState()
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_State_SelectAll";
        DataTable dt = new DataTable();
        SqlDataReader sdr = cmd.ExecuteReader();
        dt.Load(sdr);
        _connection.Close();
        return dt;
    }

    public State GetStateByID(int? stateID)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_State_Select_By_PK";
        cmd.Parameters.AddWithValue("StateID", stateID);
        SqlDataReader sdr = cmd.ExecuteReader();
        State state = new State();
        if (sdr.HasRows)
        {
            while (sdr.Read())
            {
                state.StateID = Convert.ToInt32(sdr["StateID"]);
                state.StateName = sdr["StateName"].ToString();
                state.StateCode = sdr["StateCode"].ToString();
                state.CountryID = Convert.ToInt32(sdr["CountryID"]);
                state.CountryName = sdr["CountryName"].ToString();
                state.Created = Convert.ToDateTime(sdr["Created"]);
                state.Modified = Convert.ToDateTime(sdr["Modified"]);
            }
        }

        return state;
    }
    
    public DataTable GetStateDropDown(int CountryID)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_State_Select_DropDownList";
        cmd.Parameters.AddWithValue("@CountryID", CountryID);
        DataTable dt = new DataTable();
        SqlDataReader sdr = cmd.ExecuteReader();
        dt.Load(sdr);
        _connection.Close();
        return dt;
    }

    public bool AddState(State state)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_State_Insert";
        cmd.Parameters.AddWithValue("StateName", state.StateName);
        cmd.Parameters.AddWithValue("StateCode", state.StateCode);
        cmd.Parameters.AddWithValue("CountryID", state.CountryID);
        bool isAdded = Convert.ToBoolean(cmd.ExecuteNonQuery());
        _connection.Close();
        if (isAdded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool UpdateState(State state)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_State_UpdateByPK";
        cmd.Parameters.AddWithValue("StateID", state.StateID);
        cmd.Parameters.AddWithValue("StateName", state.StateName);
        cmd.Parameters.AddWithValue("StateCode", state.StateCode);
        cmd.Parameters.AddWithValue("CountryID", state.CountryID);
        cmd.Parameters.AddWithValue("Created", state.Created);
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


    public bool DeleteState(int stateID)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_State_DeleteByPK";
        cmd.Parameters.Add("StateID", SqlDbType.Int).Value = stateID;
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