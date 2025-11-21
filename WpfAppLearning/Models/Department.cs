using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_DataBindingLearning.Models
{
    public class Department
    {
        public string DeptName { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
    }
}
