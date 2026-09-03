using EMS.Entities;
using EMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repositories.Implementations
{
    public class AdminRepo : IAdminRepo
    {
        private readonly ApplicationDbContext _context;

        public AdminRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public IEnumerable<LeaveApplication> GetAllApplications()
        {
            return _context.LeaveApplications.Include(x => x.Employee).ToList();
        }

        public LeaveApplication GetById(int id)
        {
            return _context.LeaveApplications.
                Include(x => x.Employee).
                FirstOrDefault(x => x.Id == id);
        }

        public void UpdateApplication(int id, string status)
        {
            var app = _context.LeaveApplications.Find(id);
            app.Status = status;
            _context.SaveChanges();
        }
    }
}