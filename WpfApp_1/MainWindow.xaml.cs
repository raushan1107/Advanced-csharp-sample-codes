using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp_1.Services;

namespace WpfApp_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEmployeeService _employeeService;
        private readonly App _app;


        public MainWindow()
        {
            InitializeComponent();
            _app = (App)Application.Current;
            _employeeService = _app.Services.GetService<IEmployeeService>()!;

        }

        // ----------------------------
        // 1. A long-running function
        // ----------------------------
        private void LongRunningWork()
        {
            Debug.WriteLine($"[LongRunningWork] START — Thread: {Environment.CurrentManagedThreadId}");

            // Simulate heavy blocking work (5 seconds)
            Thread.Sleep(5000);

            Debug.WriteLine($"[LongRunningWork] END   — Thread: {Environment.CurrentManagedThreadId}");
        }


        // ----------------------------
        // 2. Synchronous call (UI freezes)
        // ----------------------------
        private void Sync_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"[Sync_Click] UI Thread: {Environment.CurrentManagedThreadId}");
            MessageBox.Show("UI WILL FREEZE for 5 seconds");

            LongRunningWork();

            MessageBox.Show("Sync Work Completed");
        }


        // ----------------------------
        // 3. Async call (UI stays free)
        // ----------------------------
        private async void Async_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"[Async_Click] UI Thread: {Environment.CurrentManagedThreadId}");
            MessageBox.Show("UI is FREE — Click other buttons freely!");

            // This releases UI thread immediately
            await Task.Run(() =>
            {
                Debug.WriteLine($"[Task.Run] Running in background thread: {Environment.CurrentManagedThreadId}");
                LongRunningWork();
            });

            Debug.WriteLine($"[Async_Click] Work completed back on UI thread: {Environment.CurrentManagedThreadId}");
            MessageBox.Show("Async Work Completed");
        }


        // ----------------------------
        // 4. UI responsiveness test
        // ----------------------------
        private void Ping_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"[Ping] UI still responsive — Thread: {Environment.CurrentManagedThreadId}");
            MessageBox.Show("UI is responsive!");
        }
        private async void AsyncWithoutThread_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("==============================");
            Debug.WriteLine("ASYNC WITHOUT THREAD DEMO");

            Debug.WriteLine($"UI Thread BEFORE await: {Environment.CurrentManagedThreadId}");

            MessageBox.Show("Starting 5-second async delay.\n\nUI WILL NOT FREEZE.\nNo new thread will be created.");

            // This does NOT create a new thread.
            // It simply tells the runtime: "resume after 5 seconds".
            await Task.Delay(5000);

            Debug.WriteLine($"UI Thread AFTER await: {Environment.CurrentManagedThreadId}");

            MessageBox.Show("Async delay DONE.\nThread ID did NOT change.\nUI stayed responsive.");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var emp = _employeeService.GetEmployee();
            MessageBox.Show($"ID: {emp.Id}\nName: {emp.Name}\nSalary: {emp.Salary}\nDept: {emp.Department}");
        }
    }
}