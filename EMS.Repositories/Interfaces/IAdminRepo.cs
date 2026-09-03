using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repositories.Interfaces
{
    public interface IAdminRepo
    {
        IEnumerable<Employee> GetAll();

        IEnumerable<LeaveApplication> GetAllApplications();

        LeaveApplication GetById(int id);

        void UpdateApplication(int id, string status);
    }
}