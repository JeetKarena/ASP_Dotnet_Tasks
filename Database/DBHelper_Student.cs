using System.Data;
using System.Data.SqlClient;
using crud_demo.Areas.Student.Models;

namespace crud_demo.Database;

public class DbHelperStudent
{
    private static SqlConnection _connection;

    public DbHelperStudent(string connString)
    {
        _connection = new SqlConnection(connString);
    }

    public DataTable GetAllStudents()
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "[dbo].[PR_MST_Student_SelectAll]";
        DataTable dt = new DataTable();
        SqlDataReader sdr = cmd.ExecuteReader();
        dt.Load(sdr);
        _connection.Close();
        return dt;
    }

    public Student GetStudentById(int? countryId)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_LOC_Country_Select_By_PK";
        cmd.Parameters.AddWithValue("CountryID", countryId);
        SqlDataReader sdr = cmd.ExecuteReader();
        Student student = new Student();
        if (sdr.HasRows)
        {
            while (sdr.Read())
            {
                student.StudentId = Convert.ToInt32(sdr["StudentID"]);
                student.BranchId = Convert.ToInt32(sdr["BranchID"]);
                student.CityId = Convert.ToInt32(sdr["CityID"]);
                student.StateId = Convert.ToInt32(sdr["StateID"]);
                student.CountryId = Convert.ToInt32(sdr["CountryID"]);
                student.StudentName = sdr["StudentName"].ToString();
                student.MobileNoStudent = sdr["MobileNoStudent"].ToString();
                student.Email = sdr["Email"].ToString();
                student.MobileNoFather = sdr["MobileNoFather"].ToString();
                student.Address = sdr["Address"].ToString();
                student.BirthDate = Convert.ToDateTime(sdr["BirthDate"]);
                student.Created = Convert.ToDateTime(sdr["Created"]);
                student.Modified = Convert.ToDateTime(sdr["Modified"]);
            }
        }

        _connection.Close();
        return student;
    }

    public bool AddStudent(Student student)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_MST_Student_Insert";
        // Add parameters for the stored procedure.
        cmd.Parameters.AddWithValue("BranchID", student.BranchId);
        cmd.Parameters.AddWithValue("CityID", student.CityId);
        cmd.Parameters.AddWithValue("StateID", student.StateId);
        cmd.Parameters.AddWithValue("CountryID", student.CountryId);
        cmd.Parameters.AddWithValue("StudentName", student.StudentName);
        cmd.Parameters.AddWithValue("MobileNoStudent", student.MobileNoStudent);
        cmd.Parameters.AddWithValue("Email", student.Email);
        cmd.Parameters.AddWithValue("MobileNoFather", student.MobileNoFather);
        cmd.Parameters.AddWithValue("Address", student.Address);
        cmd.Parameters.AddWithValue("BirthDate", student.BirthDate);
        cmd.Parameters.AddWithValue("Created", student.Created);
        cmd.Parameters.AddWithValue("Modified", student.Modified);
        bool isAdded = Convert.ToBoolean(cmd.ExecuteNonQuery());
        _connection.Close();
        // check for is student added or not
        if (isAdded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool UpdateCountry(Student student)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_MST_Student_UpdateByPK";
        // Add parameters for the stored procedure.
        cmd.Parameters.AddWithValue("StudentID", student.StudentId);
        cmd.Parameters.AddWithValue("BranchID", student.BranchId);
        cmd.Parameters.AddWithValue("CityID", student.CityId);
        cmd.Parameters.AddWithValue("StateID", student.StateId);
        cmd.Parameters.AddWithValue("CountryID", student.CountryId);
        cmd.Parameters.AddWithValue("StudentName", student.StudentName);
        cmd.Parameters.AddWithValue("MobileNoStudent", student.MobileNoStudent);
        cmd.Parameters.AddWithValue("Email", student.Email);
        cmd.Parameters.AddWithValue("MobileNoFather", student.MobileNoFather);
        cmd.Parameters.AddWithValue("Address", student.Address);
        cmd.Parameters.AddWithValue("BirthDate", student.BirthDate);
        cmd.Parameters.AddWithValue("Created", student.Created);
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

    public bool DeleteStudent(int studentID)
    {
        _connection.Open();
        SqlCommand cmd = _connection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PR_MST_Student_DeleteByPK";

        // Add the parameter for the stored procedure.
        cmd.Parameters.AddWithValue("@StudentID", studentID);

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