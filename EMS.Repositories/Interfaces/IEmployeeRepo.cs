using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repositories.Interfaces
{
    public interface IEmployeeRepo
    {
        void RegisterEmployee(Employee employee);

        void UpdateEmployee(Employee employee);


        //to check login
        Employee GetUserInfo(string email, string password);

        Employee GetById(int id);

        void SubmitApplication(LeaveApplication leaveApplication);

        IEnumerable<LeaveApplication> GetApplications(int id);
    }
}