using EMS.Entities;
using EMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repositories.Implementations
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext _Context;

        public EmployeeRepo(ApplicationDbContext dbContext)
        {
            _Context = dbContext;
        }

        public IEnumerable<LeaveApplication> GetApplications(int id)
        {
            return _Context.LeaveApplications.Where(x => x.EmployeeId == id).ToList();
        }

        public Employee GetById(int id)
        {
            return _Context.Employees.Find(id);
        }

        public Employee GetUserInfo(string email, string password)
        {
            return _Context.Employees.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public void RegisterEmployee(Employee employee)
        {
            _Context.Employees.Add(employee);
            _Context.SaveChanges();
        }

        public void SubmitApplication(LeaveApplication leaveApplication)
        {
            _Context.LeaveApplications.Add(leaveApplication);
            _Context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _Context.Employees.Update(employee);
            _Context.SaveChanges();
        }
    }
}