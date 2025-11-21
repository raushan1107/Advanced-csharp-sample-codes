using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_DataBindingLearning.Models;

namespace WpfApp_DataBindingLearning.ViewModels
{
    public class BindingDemoViewModel
    {
        public BindingDemoModel Person { get; set; }

        public BindingDemoViewModel()
        {
            Person = new BindingDemoModel();
        }
    }
}
