namespace DelegatesLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MathOperation op;
            op = Add;
            Console.WriteLine(op(5, 3)); // Called Add method
            op = Multiply;
            Console.WriteLine(op(5, 3)); // Called Multiply method

        }
        public delegate int MathOperation(int x, int y);
        // defining a delegate that takes two integers and returns an integer
        // for example, we can use this delegate to point to methods that perform addition, subtraction, multiplication, etc.

        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Multiply(int a, int b) => a * b;

    }
}
