using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLearning
{
    public class Program4
    {
        public void ex1()
        {
            // Grouping using GroupBy
            List<string> fruits = new() { "Apple", "Banana", "Apricot", "Blueberry", "Avocado", "Blackberry" };
            var groupedFruits = fruits.GroupBy(f => f[0]); // Group by first letter
            Console.WriteLine("Fruits grouped by first letter:");
            foreach (var group in groupedFruits)
            {
                Console.WriteLine($"Fruits starting with '{group.Key}':");
                foreach (var fruit in group)
                {
                    Console.WriteLine(fruit);
                }
            }
        }
        public void ex1_query()
        {
            // Grouping using GroupBy with query syntax
            List<string> fruits = new() { "Apple", "Banana", "Apricot", "Blueberry", "Avocado", "Blackberry" };
            var groupedFruitsQuery = from f in fruits
                                     group f by f[0] into fruitGroup
                                     select fruitGroup;
            Console.WriteLine("Fruits grouped by first letter (Query Syntax):");
            foreach (var group in groupedFruitsQuery)
            {
                Console.WriteLine($"Fruits starting with '{group.Key}':");
                foreach (var fruit in group)
                {
                    Console.WriteLine(fruit);
                }
            }
        }

        public void ex2()
        {
            Dictionary<int, string> data = new()
                {
                    { 1, "One" },
                    { 2, "Two" },
                    { 3, "Three" }
                };

            var result = data.Where(kv => kv.Key > 1);

            foreach (var item in result)
                Console.WriteLine($"{item.Key} - {item.Value}");

        }
    }
}
