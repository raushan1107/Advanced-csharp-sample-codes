using System.Windows;
using WpfApp_DataBindingLearning;
using WpfApp_DataBindingLearning.ViewModels;

namespace WpfAppLearning
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); // Set the DataContext to the MainViewModel (Connects UI to ViewModel)
                                               // Pass ViewModel to Page
        }
        private void OpenBindingDemo_Click(object sender, RoutedEventArgs e)
        {
            BindingDemoWindow win = new BindingDemoWindow();
            win.Show();
        }
        private void OpenDataTemplateDemo_Click(object sender, RoutedEventArgs e)
        {
            new DataTemplateDemoWindow().Show();
        }
        private void OpenControlTemplateDemo_Click(object sender, RoutedEventArgs e)
        {
            new ControlTemplateDemoWindow().Show();
        }
        private void OpenVSLayout_Click(object sender, RoutedEventArgs e)
        {
            new VSLayoutWindow().Show();
        }
        private void OpenNotesPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new NotesPage());
        }
        private void DispatcherDemo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DispatcherDemoPage());
        }


    }
}