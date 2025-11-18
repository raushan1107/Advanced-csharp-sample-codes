namespace LoopsAndIteratorsLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Let's explore loops and iterators in C#
            // What is the difference between these loops?
            // For loop is used when the number of iterations is known.
            // While loop is used when the number of iterations is not known and depends on a condition.
            // Do-While loop is similar to While loop but guarantees at least one execution.
            // Foreach loop is used to iterate over collections or arrays.
            Console.WriteLine("For Loop:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Iteration {i}");
            }
            Console.WriteLine("\nWhile Loop:");
            int j = 0;
            while (j < 5)
            {
                Console.WriteLine($"Iteration {j}");
                j++;
            }
            Console.WriteLine("\nDo-While Loop:");
            int k = 0;
            do
            {
                Console.WriteLine($"Iteration {k}");
                k++;
            } while (k < 5);

            Console.WriteLine("\nForeach Loop:");
            string[] fruits = { "Apple", "Banana", "Cherry" };
            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

        }
    }
}
