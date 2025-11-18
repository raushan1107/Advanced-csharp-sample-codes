namespace FunctionsLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Let's explore functions in C#
            Console.WriteLine("Functions Learning in C#");
            int result1 = Add(10, 20);
            Console.WriteLine($"Add(10, 20) = {result1}");
            int result2 = Multiply(5, 4);
            Console.WriteLine($"Multiply(5, 4) = {result2}");

            PrintMessage("Hello from a void function!");

            // Using function with default parameter
            int result3 = Subtract(15);
            Console.WriteLine($"Subtract(15) = {result3}");
            int result4 = Subtract(15, 3);
            Console.WriteLine($"Subtract(15, 3) = {result4}");

            // Using function with multiple return values
            var (sum, product) = Calculate(6, 7);
            Console.WriteLine($"Calculate(6, 7) => Sum: {sum}, Product: {product}");

            // Using overloaded function
            double result5 = Add(2.5, 3.5);
            Console.WriteLine($"Add(2.5, 3.5) = {result5}");

            //// Calling non-static function
            //Program programInstance = new Program();
            //programInstance.MakeTea();

            //// Call by Reference
            //int x = 10;
            //int y = 20;
            //Console.WriteLine($"Before Swap: x = {x}, y = {y}");
            //SwapValues(ref x, ref y);
            //Console.WriteLine($"After Swap: x = {x}, y = {y}");

            // call by value example
            int a = 30;
            int b = 40;
            Console.WriteLine($"Before Call by Value: a = {a}, b = {b}");
            CallByValue(a, b);
            Console.WriteLine($"After Call by Value: a = {a}, b = {b}");


            // What is ref/out keyword in C#?
            // ref keyword is used to pass a parameter
            // by reference, allowing the function to modify
            // the original variable's value.
            // out keyword is used to indicate that a parameter
            // will be initialized within the function and
            // passed back to the caller.

            // Example of out keyword
           // int divisionResult;
            bool isSuccess = TryDivide(20, 4, out int divisionResult);
            if (isSuccess)
            {
                Console.WriteLine($"Division Result: {divisionResult}");
            }
            else
            {
                Console.WriteLine("Division by zero is not allowed.");
            }

            // what is in keyword in C#? 
            // // The in keyword is used to pass a parameter
            // by reference, but it is read-only within the function.
            // This means that the function cannot modify the value of the parameter.
            

        }
        // Function to add two integers
        static int Add(int a, int b)
        {
            return a + b;
        }
        // Function to multiply two integers
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        // Void function example
        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Function with default parameter
        static int Subtract(int a, int b = 5)
        {
            return a - b;
        }

        // function with multiple return values using tuples
        static (int sum, int product) Calculate(int a, int b)
        {
            int sum = a + b;
            int product = a * b;
            return (sum, product);
        }

        // funtions can be overloaded
        static double Add(double a, double b)
        {
            return a + b;
        }
        void MakeTea()
        {
            Console.WriteLine("Boiling water...");
            Console.WriteLine("Adding tea...");
        }
        // Call by Value vs Call by Reference
        static void SwapValues(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        // Call by Value example
        static void CallByValue(int a, int b)
        {
            a = a + 10;
            b = b + 10;
            Console.WriteLine($"Inside CallByValue: a = {a}, b = {b}");
        }

        // Example of out keyword
        static bool TryDivide(int numerator, int denominator, out int result)
        {
            if (denominator == 0)
            {
                result = 0;
                return false;
            }
            result = numerator / denominator;
            return true;
        }

        // Example of in keyword
        static void DisplayPoint(in System.Drawing.Point p)
        {
            Console.WriteLine($"Point Coordinates: X = {p.X}, Y = {p.Y}");
            // p.X = 10; // This would cause a compile-time error
        }


    }

}
