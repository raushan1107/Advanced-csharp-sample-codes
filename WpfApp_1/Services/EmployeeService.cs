using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_1.Model;

namespace WpfApp_1.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Employee GetEmployee()
        {
            return new Model.Employee
            {
                Id = 1,
                Name = "Raushan",
                Department = "Developers",
                Salary = 90000
            };
        }
    }
}
