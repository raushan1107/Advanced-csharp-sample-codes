using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLearning
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
    }
    public class Program2
    {
        public void ex2()
        {
            // Extracting specific fields using Select
            List<Person> people = new()
            {
                new Person { Name = "Ritu", Age = 25, Department = "HR" },
                new Person { Name = "Raushan", Age = 27, Department = "IT" },
                new Person { Name = "Rajeev", Age = 29, Department = "IT" },
                new Person { Name = "Shiv", Age = 30, Department = "Admin" }
            };
            var names = people.Select(p => p.Name);
            Console.WriteLine("Names:");
            foreach (var name in names)
                Console.WriteLine(name);
        }

        public void ex2_query()
        {
            // Extracting specific fields using Select with query syntax
            List<Person> people = new()
            {
                new Person { Name = "Ritu", Age = 25, Department = "HR" },
                new Person { Name = "Raushan", Age = 27, Department = "IT" },
                new Person { Name = "Rajeev", Age = 29, Department = "IT" },
                new Person { Name = "Shiv", Age = 30, Department = "Admin" }
            };
            var namesQuery = from p in people
                             select p.Name;
            Console.WriteLine("Names (Query Syntax):");
            foreach (var name in namesQuery)
                Console.WriteLine(name);
        }
        public void ex3_query()
        {
            // Combining Where and Select with query syntax
            List<Person> people = new()
            {
                new Person { Name = "Ritu", Age = 25, Department = "HR" },
                new Person { Name = "Raushan", Age = 27, Department = "IT" },
                new Person { Name = "Rajeev", Age = 29, Department = "IT" },
                new Person { Name = "Shiv", Age = 30, Department = "Admin" }
            };
            var itNamesQuery = from p in people
                               where p.Department == "IT"
                               select p.Name;
            Console.WriteLine("Names in IT Department (Query Syntax):");
            foreach (var name in itNamesQuery)
                Console.WriteLine(name);
        }
        public void ex4()
        {
            // Combining Where and Select
            List<Person> people = new()
            {
                new Person { Name = "Ritu", Age = 25, Department = "HR" },
                new Person { Name = "Raushan", Age = 27, Department = "IT" },
                new Person { Name = "Rajeev", Age = 29, Department = "IT" },
                new Person { Name = "Shiv", Age = 30, Department = "Admin" }
            };
            var itNames = people.Where(p => p.Department == "IT")
                                .Select(p => p.Name);
            Console.WriteLine("Names in IT Department:");
            foreach (var name in itNames)
                Console.WriteLine(name);
        }

        public void ex5()
        {
            // Using anonymous types with Select
            List<Person> people = new()
            {
                new Person { Name = "Ritu", Age = 25, Department = "HR" },
                new Person { Name = "Raushan", Age = 27, Department = "IT" },
                new Person { Name = "Rajeev", Age = 29, Department = "IT" },
                new Person { Name = "Shiv", Age = 30, Department = "Admin" }
            };
            var nameAges = people.Select(p => new { p.Name, p.Age });
            Console.WriteLine("Names and Ages:");
            foreach (var na in nameAges)
                Console.WriteLine($"Name: {na.Name}, Age: {na.Age}");
        }

        public void ex6()
        {
            // Sorting using OrderBy
            List<Person> people = new()
                {
                    new Person { Name = "Ritu", Age = 25, Department = "HR" },
                    new Person { Name = "Raushan", Age = 27, Department = "IT" },
                    new Person { Name = "Rajeev", Age = 29, Department = "IT" },
                    new Person { Name = "Shiv", Age = 30, Department = "Admin" }
                };
            var sorted = people.OrderBy(p => p.Age);
            Console.WriteLine("Sorted by Age:");
            foreach (var p in sorted)
                Console.WriteLine($"{p.Name} - {p.Age}");
        }
        public void ex6_query()
        {
            // Sorting using OrderBy with query syntax
            List<Person> people = new()
                {
                    new Person { Name = "Ritu", Age = 25, Department = "HR" },
                    new Person { Name = "Raushan", Age = 27, Department = "IT" },
                    new Person { Name = "Rajeev", Age = 29, Department = "IT" },
                    new Person { Name = "Shiv", Age = 30, Department = "Admin" }
                };
            var sortedQuery = from p in people
                              orderby p.Age
                              select p;
            Console.WriteLine("Sorted by Age (Query Syntax):");
            foreach (var p in sortedQuery)
                Console.WriteLine($"{p.Name} - {p.Age}");
        }
        public void ex7()
        {
            // Grouping using GroupBy and aggregating results with Count and Select 
            // to project group members. 
            // Displaying the department name, count of members, and member names.
            List<Person> people = new()
                {
                    new Person { Name = "Ritu", Age = 25, Department = "HR" },
                    new Person { Name = "Raushan", Age = 29, Department = "IT" },
                    new Person { Name = "Rajeev", Age = 28, Department = "IT" },
                    new Person { Name = "Shiv", Age = 30, Department = "Admin" }
                };
            var grouped =
                from p in people
                group p by p.Department into g
                select new
                {
                    Department = g.Key,
                    Count = g.Count(),
                    Members = g.Select(x => x.Name)
                };
            // what is meaning of into g? 
            // 'into g' creates a new identifier 'g' that represents each group formed by the grouping operation.
            // Is this same as when we use where condition without select which actually returns object from which we select properties to return?
            // Yes, both 'into' in grouping and using 'where' without 'select' create a new context for further operations.

            // What is g.Key here?
            // 'g.Key' represents the key of the group, which in this case is the Department name.
            // It allows access to the value used for grouping.

            foreach (var g in grouped)
            {
                Console.WriteLine($"{g.Department} ({g.Count})");
                foreach (var name in g.Members)
                    Console.WriteLine(" - " + name);
            }
        }

        public void ex7_method()
        {
            // Grouping using GroupBy and aggregating results with Count and Select 
            // to project group members. 
            // Displaying the department name, count of members, and member names.
            List<Person> people = new()
                {
                    new Person { Name = "Ritu", Age = 25, Department = "HR" },
                    new Person { Name = "Raushan", Age = 29, Department = "IT" },
                    new Person { Name = "Rajeev", Age = 28, Department = "IT" },
                    new Person { Name = "Shiv", Age = 30, Department = "Admin" }
                };
            var grouped = people.GroupBy(p => p.Department)
                                .Select(g => new
                                {
                                    Department = g.Key,
                                    Count = g.Count(),
                                    Members = g.Select(x => x.Name)
                                });
            foreach (var g in grouped)
            {
                Console.WriteLine($"{g.Department} ({g.Count})");
                foreach (var name in g.Members)
                    Console.WriteLine(" - " + name);
            }
        }
        public void ex8()
        {
            // Using aggregation functions like Max, Min, Average, and Count
            List<Person> people = new()
                {
                    new Person { Name = "Ritu", Age = 25, Department = "HR" },
                    new Person { Name = "Raushan", Age = 29, Department = "IT" },
                    new Person { Name = "Rajeev", Age = 28, Department = "IT" },
                    new Person { Name = "Shiv", Age = 30, Department = "Admin" }
                };
            var ages = people.Select(p => p.Age);

            Console.WriteLine("Max Age: " + ages.Max());
            Console.WriteLine("Min Age: " + ages.Min());
            Console.WriteLine("Average Age: " + ages.Average());
            Console.WriteLine("Total People: " + ages.Count());

            // Using First and FirstOrDefault 
            // to retrieve single elements based on conditions. 
            // Demonstrating handling of cases where no elements match the condition.
            var firstIT = people.First(p => p.Department == "IT");
            Console.WriteLine("First person in IT: " + firstIT.Name);

            // This will throw an exception if no match is found
            Console.Write("Enter the age of Employee searching for: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Searching for person with Age {0}:", age);
            var maybe = people.FirstOrDefault(p => p.Age == age);
            Console.WriteLine(maybe == null ? "Not found" : maybe.Name);
        }

        // Deferred Execution and Immediate Execution Demonstration
        public void ex9()
        {
            List<Person> people = new()
                {
                    new Person { Name = "Ritu", Age = 25, Department = "HR" },
                    new Person { Name = "Raushan", Age = 29, Department = "IT" },
                    new Person { Name = "Rajeev", Age = 28, Department = "IT" },
                    new Person { Name = "Shiv", Age = 30, Department = "Admin" }
                };
            var query = people.Where(p => p.Age > 26);
            // Modifying the source collection before executing the query
            people.Add(new Person { Name = "Anita", Age = 27, Department = "Finance" });
            Console.WriteLine("People older than 26:");
            foreach (var person in query)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

            var immediateList = people.Where(p => p.Age > 26).ToList();
            // Modifying the source collection after executing the query
            people.Add(new Person { Name = "Vikram", Age = 28, Department = "Marketing" });
            Console.WriteLine("Immediate List of People older than 26:");
            foreach (var person in immediateList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}
