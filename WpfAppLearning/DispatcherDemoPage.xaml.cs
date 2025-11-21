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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfAppLearning
{
    /// <summary>
    /// Interaction logic for DispatcherDemoPage.xaml
    /// </summary>
    public partial class DispatcherDemoPage : Page
    {
        public DispatcherDemoPage()
        {
            InitializeComponent();
        }
        private async void StartWork_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Starting work... UI stays responsive";

            // Heavy work on background thread
            await Task.Run(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    Thread.Sleep(1000);

                    DispatcherPriority
                    // Switch to UI thread
                    Dispatcher.Invoke(() =>
                    {
                        StatusText.Text = $"Working... step {i}/5";
                    });
                    //StatusText.Text = $"Working... step {i}/5";
                }
            });

            StatusText.Text = "Work Completed!";
        }
    }
}
