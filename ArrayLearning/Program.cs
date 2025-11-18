namespace ArrayLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Let's explore arrays in C#
            Console.WriteLine("Array Learning in C#");
            // Declaring and initializing an array
            int[] numbers = { 10, 200, 36, 401, 150 };
            Console.WriteLine("Array Elements:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Element at index {i}: {numbers[i]}");
            }

            // Modifying an array element
            numbers[2] = 99;
            Console.WriteLine("\nAfter modifying the element at index 2:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Element at index {i}: {numbers[i]}");
            }

            // Multi-dimensional array
            int[,] matrix = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            Console.WriteLine("\nMulti-dimensional Array (Matrix):");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Jagged array
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2 };
            jaggedArray[1] = new int[] { 3, 4, 5 };
            jaggedArray[2] = new int[] { 6, 7, 8, 9 };
            Console.WriteLine("\nJagged Array:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write("Row " + i + ": ");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            // Array methods
            Console.WriteLine("\nArray Methods:");
            Array.Sort(numbers);
            Console.WriteLine("Sorted Array:");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
            Array.Reverse(numbers);
            Console.WriteLine("\nReversed Array:");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
            Array.Resize(ref numbers, 7); // Resize array to hold 7 elements
            // Note: New elements will have default value i.e., 0 for int.
            numbers[5] = 60;
            numbers[6] = 70;
            Console.WriteLine("\nResized Array:");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
            Array.Clear(numbers, 0, numbers.Length); // Clear all elements and set to default value i.e., 0 for int.
            // Syntax: Array.Clear(array, startIndex, length);
            
            Console.WriteLine("\nCleared Array:");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }

        }
    }
}
