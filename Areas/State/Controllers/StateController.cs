using System.Data;
using crud_demo.Database;
using crud_demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud_demo.Areas.State.Controllers
{
    [Area("State")]
    public class StateController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DbHelperState _db;

        public StateController(IConfiguration configuration)
        {
            this._configuration = configuration;
            string connStr = this._configuration.GetConnectionString("myString");
            _db = new DbHelperState(connStr);
        }

        // GET: State
        public ActionResult Index()
        {
            return View(_db.GetAllState());
        }


        // POST: State/Create_Edit
        public IActionResult Add_Edit(int? stateId)
        {
            string connStr = this._configuration.GetConnectionString("myString");
            DbHelperCountry helperCountry = new DbHelperCountry(connStr);
            List<Country> list = new List<Country>();
            foreach (DataRow row in helperCountry.GetAllCountry().Rows)
            {
                Country cn = new Country();
                cn.CountryId = Convert.ToInt32(row["CountryID"]);
                cn.CountryName = row["CountryName"].ToString();
                list.Add(cn);
            }

            ViewBag.CountryList = list;
            if (stateId != null)
            {
                return View(_db.GetStateByID(stateId));
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult Save(Models.State s)
        {
            if (s.StateID != 0)
            {
                _db.UpdateState(s);
            }
            else
            {
                _db.AddState(s);
            }

            return RedirectToAction("Index");
        }


        // GET: State/Delete/5
        public ActionResult Delete(int stateId)
        {
            _db.DeleteState(stateId);
            return RedirectToAction(nameof(Index));
        }
    }
}