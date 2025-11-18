using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLearning
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string? Name { get; set; }
        public int DeptId { get; set; }
    }

    public class Department
    {
        public string? DepartmentHOD { get; set; }
        public string? DeptName { get; set; }
        public int DepartmentId { get; set; }
    }

    public class Program3
    {
        // Join two datasets
        public List<Employee> employees = new()
        {
            new Employee { EmpId = 1, Name = "Ritu", DeptId = 101 },
            new Employee { EmpId = 2, Name = "Raushan", DeptId = 102 },
            new Employee { EmpId = 3, Name = "Rajeev", DeptId = 102 },
            new Employee { EmpId = 4, Name = "Shiv", DeptId = 103 }
        };
        public List<Department> departments = new()
        {
            new Department { DepartmentHOD = "Anil", DeptName = "HR", DepartmentId = 101 },
            new Department { DepartmentHOD = "Sunil", DeptName = "IT", DepartmentId = 102 },
            new Department { DepartmentHOD = "Vijay", DeptName = "Admin", DepartmentId = 103 }
        };

        // Method to demonstrate Join
        public void ex1_query()
        {
            var empDept = from e in employees
                          join d in departments
                          on e.DeptId equals d.DepartmentId
                          select new
                          {
                              e.EmpId,
                              e.Name,
                              d.DeptName,
                              d.DepartmentHOD
                          };
            Console.WriteLine("Employee Details with Department Info:");
            foreach (var item in empDept)
            {
                Console.WriteLine($"EmpId: {item.EmpId}, Name: {item.Name}, DeptName: {item.DeptName}, DepartmentHOD: {item.DepartmentHOD}");
            }
        }
        public void ex1_method()
        {
            var empDept = employees.Join(departments,
                                         e => e.DeptId,
                                         d => d.DepartmentId,
                                         (e, d) => new
                                         {
                                             e.EmpId,
                                             e.Name,
                                             d.DeptName,
                                             d.DepartmentHOD
                                         });
            Console.WriteLine("Employee Details with Department Info:");
            foreach (var item in empDept)
            {
                Console.WriteLine($"EmpId: {item.EmpId}, Name: {item.Name}, DeptName: {item.DeptName}, DepartmentHOD: {item.DepartmentHOD}");
            }
        }
    }
}
