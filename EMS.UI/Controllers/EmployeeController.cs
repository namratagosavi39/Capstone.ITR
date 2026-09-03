using EMS.Entities;
using EMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.CodeAnalysis.Operations;

namespace EMS.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IBranchRepo _branchRepo;
        private readonly IDeptRepo _deptRepo;
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeController(IBranchRepo branchRepo, IDeptRepo deptRepo, IEmployeeRepo employeeRepo)
        {
            _branchRepo = branchRepo;
            _deptRepo = deptRepo;
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var branchlist = _branchRepo.GetAll();
            ViewBag.BranchList = new SelectList(branchlist, "BranchName", "BranchName");

            var deptlist = _deptRepo.GetAll();
            ViewBag.DeptList = new SelectList(deptlist, "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Employee employee)
        {

            _employeeRepo.RegisterEmployee(employee);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(EmployeeLogin user)
        {
            var userInfo = _employeeRepo.GetUserInfo(user.Email, user.Password);
            if (userInfo != null)
            {
                HttpContext.Session.SetInt32("userId", userInfo.Id);
                HttpContext.Session.SetString("userName", userInfo.Name);
                return RedirectToAction("Profile");

            }
            else
            {
                ViewData["Message"] = "Invalid Login";
                return View();
            }



        }

        [HttpGet]
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Home");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                var branchlist = _branchRepo.GetAll();
                ViewBag.BranchList = new SelectList(branchlist, "BranchName", "BranchName");

                var deptlist = _deptRepo.GetAll();
                ViewBag.DeptList = new SelectList(deptlist, "Name", "Name");

                int empId = (int)HttpContext.Session.GetInt32("userId");
                var employee = _employeeRepo.GetById(empId);
                return View(employee);

            }
            return RedirectToAction("Login");

        }

        [HttpPost]
        public IActionResult Profile(Employee employee)
        {
            _employeeRepo.UpdateEmployee(employee);
            return View();
        }

        [HttpGet]
        public IActionResult Application()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Application(LeaveApplication leaveApplication)
        {
            leaveApplication.EmployeeId = (int)HttpContext.Session.GetInt32("userId");
            leaveApplication.Status = "Submitted";
            leaveApplication.ApplicationDate = DateTime.Now;
            _employeeRepo.SubmitApplication(leaveApplication);
            return RedirectToAction("AppList");
        }

        public IActionResult AppList()
        {

            var leaveApps = _employeeRepo.GetApplications((int)HttpContext.Session.GetInt32("userId"));
            return View(leaveApps);
        }

        public IActionResult Home()
        {
            return View();
        }
    }
}