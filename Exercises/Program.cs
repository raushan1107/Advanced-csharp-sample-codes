namespace Exercises
{
    class LogEntry
    {
        public DateTime Date { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise1();
            Exercise2();
        }

        static void Exercise1()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 60000 },
                new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 80000 },
                new Employee { Id = 3, Name = "Charlie", Department = "IT", Salary = 75000 },
                new Employee { Id = 4, Name = "Raushan", Department = "Developer", Salary = 90000 },
                new Employee { Id = 5, Name = "Eve", Department = "HR", Salary = 62000 },
                new Employee { Id = 1, Name = "Ritu", Department = "Developer", Salary = 85000 },
                new Employee { Id = 2, Name = "David", Department = "IT", Salary = 55000 },
                new Employee { Id = 3, Name = "Pratibha", Department = "IT", Salary = 60000 },
                new Employee { Id = 4, Name = "Shiv", Department = "Sales", Salary = 40000 }
            };

            // 1. Get all employees whose salary is greater than 50,000

            var highSalary = employees.Where(e => e.Salary > 50000);

            Console.WriteLine("Employees with Salary > 50,000:");
            foreach (var emp in highSalary)
                Console.WriteLine($"{emp.Name} - {emp.Salary}");
            Console.WriteLine();
            
            // 2. Get only the names of all employees from IT department

            var itNames = employees
                            .Where(e => e.Department == "IT")
                            .Select(e => e.Name);

            Console.WriteLine("Names of IT Department Employees:");
            foreach (var name in itNames)
                Console.WriteLine(name);
            Console.WriteLine();

            // 3. Sort employees by salary descending

            var sortedBySalary = employees
                                    .OrderByDescending(e => e.Salary);

            Console.WriteLine("Employees Sorted by Salary (Desc):");
            foreach (var emp in sortedBySalary)
                Console.WriteLine($"{emp.Name} - {emp.Salary}");
            Console.WriteLine();

            // 4. Group employees by department and display count in each

            var grouped = employees
                            .GroupBy(e => e.Department)
                            .Select(g => new
                            {
                                Department = g.Key,
                                Count = g.Count(),
                                Members = g.Select(e => e.Name)
                            });

            Console.WriteLine("Employees Grouped by Department:");
            foreach (var g in grouped)
            {
                Console.WriteLine($"{g.Department}: {g.Count} employees");
                foreach (var member in g.Members)
                    Console.WriteLine(" - " + member);
            }
            Console.WriteLine();

            // 5. Find employee with highest salary

            var highestSalaryEmployee = employees
                                            .OrderByDescending(e => e.Salary)
                                            .First();

            Console.WriteLine("Employee with Highest Salary:");
            Console.WriteLine($"{highestSalaryEmployee.Name} - {highestSalaryEmployee.Salary}");
        }
        static void Exercise2()
        {
            string path = @"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\Exercises\log.txt";

            // 1. Read file line-by-line (efficient for huge data)
            IEnumerable<string> lines = File.ReadLines(path);

            // 2. Convert each line to LogEntry using Select
            var logEntries = lines.Select(line =>
            {
                var parts = line.Split('|');

                return new LogEntry
                {
                    Date = DateTime.Parse(parts[0]),
                    Level = parts[1],
                    Message = parts[2]
                };
            });

            // 3. Filter only ERROR logs
            var errorLogs = logEntries.Where(e => e.Level == "ERROR");

            // 4. Count number of ERRORs per day
            var errorSummary = errorLogs
                .GroupBy(e => e.Date)
                .Select(g => new
                {
                    Date = g.Key.ToString("yyyy-MM-dd"),
                    ErrorCount = g.Count()
                })
                .OrderBy(r => r.Date);

            // 5. Print summary
            Console.WriteLine("Error Summary:");
            foreach (var item in errorSummary)
            {
                Console.WriteLine($"Date: {item.Date} | Errors: {item.ErrorCount}");
            }
        }
    }
}
