using EMS.Entities;
using EMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repositories.Implementations
{
    public class DeptRepo : IDeptRepo
    {
        private readonly ApplicationDbContext _context;

        public DeptRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Edit(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.Find(id);
        }

        public void RemoveData(Department department)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public void Save(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }
    }
}