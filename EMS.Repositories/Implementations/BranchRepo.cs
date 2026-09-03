using EMS.Entities;
using EMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repositories.Implementations
{
    public class BranchRepo : IBranchRepo
    {
        private readonly ApplicationDbContext _context;

        public BranchRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Edit(Branch branch)
        {
            _context.Branches.Update(branch);
            _context.SaveChanges();
        }

        public IEnumerable<Branch> GetAll()
        {
            return _context.Branches.ToList();
        }

        public Branch GetById(int id)
        {
            return _context.Branches.Find(id);
        }

        public void RemoveData(Branch branch)
        {
            _context.Branches.Remove(branch);
            _context.SaveChanges();
        }

        public void Save(Branch branch)
        {
            _context.Branches.Add(branch);
            _context.SaveChanges();
        }
    }
}