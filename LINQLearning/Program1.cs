using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLearning
{
    public class Program1
    {
        public void ex1()
        {
            //How to filter using Where
            List<int> numbers = new() { 5, 12, 19, 3, 42, 16 };
            var result = numbers.Where(n => n > 15);
            Console.WriteLine("Numbers > 15:");
            foreach (var n in result) { Console.WriteLine(n); }
        }
        public void ex1_query()
        {
            //How to filter using Where with query syntax
            List<int> numbers = new() { 5, 12, 19, 3, 42, 16 };
            var resultQuery = from n in numbers
                              where n > 15
                              select n;
            Console.WriteLine("Numbers > 15 (Query Syntax):");
            foreach (var n in resultQuery) { Console.WriteLine(n); }
        }
    }
}
