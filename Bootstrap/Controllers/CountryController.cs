using crud_demo.Database;
using Microsoft.AspNetCore.Mvc;
using crud_demo.Models;

namespace crud_demo.Controllers;

public class CountryController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly DbHelperCountry _db;


    public CountryController(IConfiguration configuration)
    {
        this._configuration = configuration;
        string connStr = this._configuration.GetConnectionString("myString");
        _db = new DbHelperCountry(connStr);
    }


    public IActionResult Add_Edit(int? countryId)
    {
        if (countryId!=null)
        {
            return View(_db.GetCountryById(countryId));
        }

        return View();
    }

    [HttpPost]
    public IActionResult AddCountry(Country c)
    {
        if (c.CountryId!=null)
        {
            _db.UpdateCountry(c);
        }
        else
        {
            _db.AddCountry(c);
        }
        return RedirectToAction("Index");
    }

    public IActionResult Index()
    {
        return View(_db.GetAllCountry());
    }

    public IActionResult Delete(int countryId)
    {
        _db.DeleteCountry(countryId);
        return RedirectToAction("Index");
    }

}