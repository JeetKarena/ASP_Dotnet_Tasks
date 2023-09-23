using System.Data;
using System.Data.SqlClient;
using crud_demo.Areas.CIty.Models;

namespace crud_demo.Database;

public class DbHelperCity
{
    private static SqlConnection _connection;

    public DbHelperCity(string connString)
    {
        _connection = new SqlConnection(connString);
    }

    public DataTable GetAllCity()
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_City_SelectAll";
        DataTable dt = new DataTable();
        SqlDataReader sdr = cmd.ExecuteReader();
        dt.Load(sdr);
        _connection.Close();
        return dt;
    }

    public City GetCityByID(int? CityID)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_City_Select_By_PK";
        cmd.Parameters.AddWithValue("@CityId", CityID);
        SqlDataReader sdr = cmd.ExecuteReader();
        City ct = new City();
        if (sdr.HasRows)
        {
            while (sdr.Read())
            {
                ct.CityID = Convert.ToInt32(sdr["CityID"]);
                ct.StateID = Convert.ToInt32(sdr["StateID"]);
                ct.CountryID = Convert.ToInt32(sdr["CountryID"]);
                ct.CityName = sdr["CityName"].ToString();
                ct.StateName = sdr["StateName"].ToString();
                ct.CountryName = sdr["CountryName"].ToString();
                ct.CityCode = sdr["CityCode"].ToString();
                ct.Created = Convert.ToDateTime(sdr["Created"]);
                ct.Modified = Convert.ToDateTime(sdr["Modified"]);
            }
        }

        return ct;
    }

    public DataTable GetCityDropDown(int StateID)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_City_Select_DropDownList";
        cmd.Parameters.AddWithValue("@StateID", StateID);
        DataTable dt = new DataTable();
        SqlDataReader sdr = cmd.ExecuteReader();
        dt.Load(sdr);
        _connection.Close();
        return dt;
    }

    public bool AddCity(City ct)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_City_Insert";
        cmd.Parameters.AddWithValue("@StateID", ct.StateID);
        cmd.Parameters.AddWithValue("@CountryID", ct.CountryID);
        cmd.Parameters.AddWithValue("@CityName", ct.CityName);
        cmd.Parameters.AddWithValue("@CityCode", ct.CityCode);
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

    public bool UpdateCity(City ct)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_City_UpdateByPK";
        cmd.Parameters.AddWithValue("@CityID", ct.CityID);
        cmd.Parameters.AddWithValue("@CityName", ct.CityName);
        cmd.Parameters.AddWithValue("@CityCode", ct.CityCode);
        cmd.Parameters.AddWithValue("@StateID", ct.StateID);
        cmd.Parameters.AddWithValue("@CountryID", ct.CountryID);
        cmd.Parameters.AddWithValue("@Created", ct.Created);
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

    public bool DeleteCity(int CityID)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_City_DeleteByPK";
        cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;
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