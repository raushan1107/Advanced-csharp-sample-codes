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
using WpfAppLearning.ViewModels;

namespace WpfAppLearning
{
    /// <summary>
    /// Interaction logic for DataTemplateDemoWindow.xaml
    /// </summary>
    public partial class DataTemplateDemoWindow : Window
    {
        public DataTemplateDemoWindow()
        {
            InitializeComponent();
            DataContext = new DataTemplateDemoViewModel();
        }
    }
}
