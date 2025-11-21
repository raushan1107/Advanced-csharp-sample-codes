using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp_DataBindingLearning.ViewModels;

namespace WpfApp_DataBindingLearning
{
    /// <summary>
    /// Interaction logic for BindingDemoWindow.xaml
    /// </summary>
    public partial class BindingDemoWindow : Window
    {
        public BindingDemoWindow()
        {
            InitializeComponent();
            DataContext = new BindingDemoViewModel();
        }
    }
}
