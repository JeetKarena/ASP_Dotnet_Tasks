using System.Data;
using crud_demo.Areas.Branch.Models;
using crud_demo.Areas.CIty.Models;
using crud_demo.Areas.Student.Models;
using crud_demo.Database;
using crud_demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud_demo.Areas.Student.Controllers;

[Area("Student")]
public class StudentController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly DbHelperStudent _dbHelperStudent;
    private readonly DbHelperCountry _dbHelperCountry;
    private readonly DbHelperState _dbHelperState;
    private readonly DbHelperCity _dbHelperCity;
    private readonly DbHelperBranch _dbHelperBranch;

    public StudentController(IConfiguration configuration)
    {
        this._configuration = configuration;
        string connStr = this._configuration.GetConnectionString("myString");
        _dbHelperStudent = new DbHelperStudent(connStr);
        _dbHelperCountry = new DbHelperCountry(connStr);
        _dbHelperState = new DbHelperState(connStr);
        _dbHelperCity = new DbHelperCity(connStr);
        _dbHelperBranch = new DbHelperBranch(connStr);
    }

    // GET: Index
    public IActionResult Index()
    {
        return View(_dbHelperStudent.GetAllStudents());
    }

    // POST: Index/Create_Edit
    public IActionResult Add_Edit(int? StudentId)
    {
        List<CountryDropdownModel> countryList = new List<CountryDropdownModel>();
        List<StateDropdownModel> stateList = new List<StateDropdownModel>();
        List<CityDropdownModel> cityList = new List<CityDropdownModel>();

        foreach (DataRow row in _dbHelperCountry.GetAllCountry().Rows)
        {
            CountryDropdownModel cn = new CountryDropdownModel();
            cn.CountryID = Convert.ToInt32(row["CountryID"]);
            cn.CountryName = row["CountryName"].ToString();
            countryList.Add(cn);
        }

        

        ViewBag.CountryList = countryList;
        ViewBag.StateList = stateList;
        ViewBag.CityList = cityList;
        ViewBag.BranchList = SelectBranch();

        if (StudentId != null)
        {
            return View(_dbHelperStudent.GetStudentById(StudentId));
        }
        else
        {
            return View();
        }
    }

    [HttpPost]
    public IActionResult Save(Models.Student student)
    {
        if (student.StudentId != 0)
        {
            _dbHelperStudent.UpdateCountry(student);
        }
        else
        {
            _dbHelperStudent.AddStudent(student);
        }

        return RedirectToAction("Index");
    }

    // GET: Index/Delete/5
    public ActionResult Delete(int StudentID)
    {
        _dbHelperStudent.DeleteStudent(StudentID);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public ActionResult SelectState(int CountryID)
    {
        List<StateDropdownModel> stateList = new List<StateDropdownModel>();
        foreach (DataRow row in _dbHelperState.GetStateDropDown(CountryID).Rows)
        {
            StateDropdownModel st = new StateDropdownModel();
            st.StateID = Convert.ToInt32(row["StateId"]);
            st.StateName = row["StateName"].ToString();
            stateList.Add(st);
        }

        return Json(stateList);
    }

    [HttpPost]
    public ActionResult SelectCity(int StateID)
    {
        List<CityDropdownModel> cityList = new List<CityDropdownModel>();
        foreach (DataRow row in _dbHelperCity.GetCityDropDown(StateID).Rows)
        {
            CityDropdownModel ct = new CityDropdownModel();
            ct.CityID = Convert.ToInt32(row["CityID"]);
            ct.CityName = row["CityName"].ToString();
            cityList.Add(ct);
        }

        return Json(cityList);
    }

    public List<BranchDropdownModel> SelectBranch()
    {
        List<BranchDropdownModel> branchList = new List<BranchDropdownModel>();
        foreach (DataRow row in _dbHelperBranch.GetBranchDropDown().Rows)
        {
            BranchDropdownModel br = new BranchDropdownModel();
            br.BranchID = Convert.ToInt32(row["BranchID"]);
            br.BranchName = row["BranchName"].ToString();
            branchList.Add(br);
        }

        return branchList;
    }
}