using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_DataBindingLearning.Models;
using WpfApp_DataBindingLearning.Models;

namespace WpfAppLearning.ViewModels
{
    public class DataTemplateDemoViewModel
    {
        public ObservableCollection<Person> People { get; set; }
        public ObservableCollection<Department> Departments { get; set; }

        public DataTemplateDemoViewModel()
        {
            // List demo data
            People = new ObservableCollection<Person>()
            {
                new Person { Name="Ritu", Age=25, Email="ritu@example.com" },
                new Person { Name="Raushan", Age=29, Email="raushan@example.com" },
                new Person { Name="Aarav", Age=32, Email="aarav@example.com" }
            };

            // Hierarchical data example
            Departments = new ObservableCollection<Department>()
            {
                new Department
                {
                    DeptName = "IT Department",
                    Employees = new ObservableCollection<Employee>()
                    {
                        new Employee { Name="Raushan", Role="Developer"},
                        new Employee { Name="Aarav", Role="Tester"}
                    }
                },
                new Department
                {
                    DeptName = "HR Department",
                    Employees = new ObservableCollection<Employee>()
                    {
                        new Employee { Name="Ananya", Role="HR Manager"},
                        new Employee { Name="Priya", Role="Recruiter"}
                    }
                }
            };
        }
    }
}
