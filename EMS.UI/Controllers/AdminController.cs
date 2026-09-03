using EMS.Entities;
using EMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMS.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDeptRepo _deptRepo;
        private readonly IBranchRepo _branchRepo;
        private readonly IAdminRepo _adminRepo;
        public AdminController(IDeptRepo deptRepo, IBranchRepo branchRepo, IAdminRepo adminRepo)
        {
            _deptRepo = deptRepo;
            _branchRepo = branchRepo;
            _adminRepo = adminRepo;
        }

        public IActionResult Index()
        {
            var employeeList = _adminRepo.GetAll();
            return View(employeeList);
        }

        public IActionResult ApplicationList()
        {

            var applications = _adminRepo.GetAllApplications();

            return View(applications);
        }

        public IActionResult Edit(int id)
        {
            var app = _adminRepo.GetById(id);
            return View(app);
        }

        [HttpPost]
        public IActionResult ApproveApp(LeaveApplication application)
        {
            _adminRepo.UpdateApplication(application.Id, "Approved");
            return RedirectToAction("ApplicationList");

        }
        [HttpPost]
        public IActionResult RejectApp(LeaveApplication application)
        {
            _adminRepo.UpdateApplication(application.Id, "Rejected");
            return RedirectToAction("ApplicationList");

        }

        public IActionResult BranchList()
        {
            var branches = _branchRepo.GetAll();
            return View(branches);
        }

        [HttpGet]
        public IActionResult CreateBranch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBranch(Branch branch)
        {
            _branchRepo.Save(branch);
            TempData["Message"] = "True";
            return RedirectToAction("BranchList");
        }

        [HttpGet]
        public IActionResult EditBranch(int id)
        {
            var branch = _branchRepo.GetById(id);
            return View(branch);
        }

        [HttpPost]
        public IActionResult EditBranch(Branch branch)
        {
            _branchRepo.Edit(branch);
            return RedirectToAction("BranchList");
        }

        [HttpGet]
        public IActionResult DeleteBranch(int id)
        {
            var branch = _branchRepo.GetById(id);
            _branchRepo.RemoveData(branch);
            return RedirectToAction("BranchList");
        }

        public IActionResult DeptList()
        {
            var departments = _deptRepo.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult CreateDept()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDept(Department dept)
        {
            _deptRepo.Save(dept);
            TempData["Message"] = "True";
            return RedirectToAction("DeptList");
        }

        [HttpGet]
        public IActionResult EditDept(int id)
        {
            var dept = _deptRepo.GetById(id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult EditDept(Department dept)
        {
            _deptRepo.Edit(dept);
            return RedirectToAction("DeptList");
        }

        [HttpGet]
        public IActionResult DeleteDept(int id)
        {
            var dept = _deptRepo.GetById(id);
            _deptRepo.RemoveData(dept);
            return RedirectToAction("DeptList");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            if (admin.UserName == "admin" && admin.Password == "admin")
            {
                HttpContext.Session.SetString("Admin", "True");
                return RedirectToAction("BranchList");
            }
            else
            {
                ViewData["Message"] = "Invalid Login";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}