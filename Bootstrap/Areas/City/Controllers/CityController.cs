using System.Data;
using crud_demo.Areas.CIty.Models;
using crud_demo.Areas.Student.Models;
using crud_demo.Database;
using crud_demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud_demo.Areas.CIty.Controllers;

[Area("City")]
public class CityController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly DbHelperCity _dbHelperCity;
    private readonly DbHelperState _dbHelperState;
    private readonly DbHelperCountry _dbHelperCountry;

    public CityController(IConfiguration configuration)
    {
        this._configuration = configuration;
        string connStr = this._configuration.GetConnectionString("myString");
        _dbHelperCity = new DbHelperCity(connStr);
        _dbHelperState = new DbHelperState(connStr);
        _dbHelperCountry = new DbHelperCountry(connStr);
    }

    // GET : Index
    public IActionResult Index()
    {
        return View(_dbHelperCity.GetAllCity());
    }

    // POST: Index/Create_Edit
    public IActionResult Add_Edit(int? CityId)
    {
        List<CountryDropdownModel> list = new List<CountryDropdownModel>();
        List<StateDropdownModel> stateList = new List<StateDropdownModel>();
        foreach (DataRow row in _dbHelperCountry.GetAllCountry().Rows)
        {
            CountryDropdownModel cn = new CountryDropdownModel();
            cn.CountryID = Convert.ToInt32(row["CountryID"]);
            cn.CountryName = row["CountryName"].ToString();
            list.Add(cn);
        }

        ViewBag.CountryList = list;
        ViewBag.StateList = stateList;
        if (CityId != null)
        {
            return View(_dbHelperCity.GetCityByID(CityId));
        }
        else
        {
            return View();
        }
    }
    
    [HttpPost]
    public IActionResult Save(Models.City ct)
    {
        if (ct.CityID != null)
        {
            _dbHelperCity.UpdateCity(ct);
        }
        else
        {
            _dbHelperCity.AddCity(ct);
        }

        return RedirectToAction("Index");
    }

    // GET: Index/Delete/5
    public ActionResult Delete(int CityID)
    {
        _dbHelperCity.DeleteCity(CityID);
        return RedirectToAction(nameof(Index));
    }

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
}