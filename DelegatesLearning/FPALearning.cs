using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesLearning
{
    internal class FPALearning
    {
        public void funcActionPredicate()
        {
            // Examples of Func, Action, Predicate
            
            // Func example
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine($"Func Add: {add(3, 5)}"); 
            
            // Action example
            Action<string> greet = name => Console.WriteLine($"Hello, {name}!");
            greet("Raushan"); 

            // Predicate example
            Predicate<int> isEven = n => n % 2 == 0;
            Console.WriteLine($"Predicate isEven(4): {isEven(4)}"); 
            Console.WriteLine($"Predicate isEven(5): {isEven(5)}"); 
        }

        public void funcLearning()
        {
            // Func example with no parameters
            Func<int> getRandom = () => new Random().Next(1, 100);
            Console.WriteLine(getRandom());

            // Func with ONE INPUT
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));

            // Func with TWO INPUTS
            Func<int, int, int> multiply = (x, y) => x * y;
            Console.WriteLine(multiply(4, 6));

            // Func with THREE INPUTS
            Func<int, int, int, int> sumThree = (x, y, z) => x + y + z;
            Console.WriteLine(sumThree(2, 3, 4));

            // Func with FOUR INPUTS
            Func<int, int, int, int, int> sumFour = (a, b, c, d) => a + b + c + d;
            Console.WriteLine(sumFour(1, 2, 3, 4));

            // Func with FIVE INPUTS
            Func<int, int, int, int, int, int> sumFive = (a, b, c, d, e) => a + b + c + d + e;
            Console.WriteLine(sumFive(1, 2, 3, 4, 5));

            // Max: Func with 16 input parameters
            Func< int, int, int, int, int, int, int, int,
                  int, int, int, int, int, int, int, int,
                  int> maxOf16 = (a1, a2, a3, a4, a5, a6, a7, a8,
                                  a9, a10, a11, a12, a13, a14, a15, a16) =>
            {
                return new List<int> { a1, a2, a3, a4, a5, a6, a7, a8,
                                       a9, a10, a11, a12, a13, a14, a15, a16 }.Max();
            };

        }
    }
}



//“Delegates are long. C# created shortcuts.”

//✔ Func = function with return
//Func<int, int, int>    // takes 2 ints, returns int

//✔ Action = function without return
//Action<string>    // takes 1 string, void return

//✔ Predicate = function returning bool
//Predicate<int>    // checks true/false for an int


//LINQ methods like:

//Where(x => x > 10)
//Select(x => x * 2)
//OrderBy(x => x)


//They are using:
//Func<T, bool> for Where
//Func < T, TResult > for Select


//Delegate = mechanism to pass methods
//Func = delegate with return value
//Action = delegate with no return
//Predicate = delegate that returns bool
//Lambda = shorthand method body
//LINQ = collection of methods that depend on these delegates