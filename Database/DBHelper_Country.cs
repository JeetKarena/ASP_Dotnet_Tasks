using System.Data;
using System.Data.SqlClient;
using crud_demo.Models;

namespace crud_demo.Database;

public sealed class DbHelperCountry
{
    private static SqlConnection _connection;

    public DbHelperCountry(string connString)
    {
        _connection = new SqlConnection(connString);
    }

    public DataTable GetAllCountry()
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "[dbo].[PR_LOC_Country_SelectAll]";
        DataTable dt = new DataTable();
        SqlDataReader sdr = cmd.ExecuteReader();
        dt.Load(sdr);
        _connection.Close();
        return dt;
    }

    public Country GetCountryById(int? countryId)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_Country_Select_By_PK";
        cmd.Parameters.AddWithValue("CountryID", countryId);
        SqlDataReader sdr = cmd.ExecuteReader();
        // Console.WriteLine(sdr["CountryID"].ToString());
        Country country = new Country();
        if (sdr.HasRows)
        {
            while (sdr.Read())
            {
                country.CountryId = Convert.ToInt16(sdr["CountryID"]);
                country.CountryName = sdr["CountryName"].ToString();
                country.CountryCode = sdr["CountryCode"].ToString();
                country.Created = Convert.ToDateTime(sdr["Created"]);
                country.Modified = Convert.ToDateTime(sdr["Modified"]);
            }
        }

        _connection.Close();
        return country;
    }


    public bool AddCountry(Country c)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_Country_Insert";
        cmd.Parameters.AddWithValue("CountryName", c.CountryName);
        cmd.Parameters.AddWithValue("CountryCode", c.CountryCode);
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


    public bool UpdateCountry(Country c)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_Country_UpdateByPK";
        cmd.Parameters.AddWithValue("CountryID", c.CountryId);
        cmd.Parameters.AddWithValue("CountryName", c.CountryName);
        cmd.Parameters.AddWithValue("CountryCode", c.CountryCode);
        cmd.Parameters.AddWithValue("Created", c.Created);
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

    public bool DeleteCountry(int countryId)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_Country_DeleteByPK";
        cmd.Parameters.Add("CountryID", SqlDbType.Int).Value = countryId;
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