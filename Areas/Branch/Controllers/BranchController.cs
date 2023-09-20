using crud_demo.Database;
using Microsoft.AspNetCore.Mvc;

namespace crud_demo.Areas.Branch.Controllers
{
    [Area("Branch")]
    public class BranchController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DbHelperBranch _dbHelperBranch;

        public BranchController(IConfiguration configuration)
        {
            this._configuration = configuration;
            string connStr = this._configuration.GetConnectionString("myString");
            _dbHelperBranch = new DbHelperBranch(connStr);
        }

        public IActionResult Index()
        {
            return View(_dbHelperBranch.GetAllBranch());
        }
        
        public IActionResult Add_Edit(int? BranchID)
        {

            if (BranchID != null)
            {
                return View(_dbHelperBranch.GetBranchByID(BranchID));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Save(Models.Branch branch)
        {
            if (branch.BranchId != 0)
            {
                _dbHelperBranch.UpdateBranch(branch);
            }
            else
            {
                _dbHelperBranch.AddBranch(branch);
            }

            return RedirectToAction("Index");
        }
        
        // GET: Branch/Delete/5
        public ActionResult Delete(int BranchId)
        {
            _dbHelperBranch.DeleteBranch(BranchId);
            return RedirectToAction(nameof(Index));
        }
    }
}