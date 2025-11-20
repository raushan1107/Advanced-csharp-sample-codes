using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesLearning
{
    internal class lambda
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
        public int Square(int x)
        {
            return x * x;
        }
        public void ex1()
        {
            //Without lambda:
            var result1 = numbers.Select(Square);

            //With lambda:
            var result2 = numbers.Select(x => x * x);
        }

        public void ex2()
        {
            var greet = () => Console.WriteLine("Hello Lambda!");
            greet();
        }

        public void ex3()
        {
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine(add(3, 5));
        }

        public void ex4()
        {
            int factor = 10;
            Func<int, int> multiply = n => n * factor;

            Console.WriteLine(multiply(5)); // 50
        }

        public void ex5()
        {
            Predicate<int> isEven = n => n % 2 == 0;
            Console.WriteLine(isEven(4)); // True
            Console.WriteLine(isEven(5)); // False
        }

        public void ex6()
        {
            int countEven = numbers.Count(n => n % 2 == 0);
            Console.WriteLine($"Even: {countEven}");

            var evens = numbers.Where(n => n % 2 == 0).ToList();
            Console.WriteLine(string.Join(", ", evens)); // 2, 4
        }
    }
}
