namespace CollectionsLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== LIST<T> (Ordered, Duplicates Allowed) =====");

            List<int> numbers = new() { 10, 20, 30 };
            numbers.Add(20);   // duplicates allowed

            foreach (var n in numbers)
                Console.WriteLine(n);
            Console.WriteLine("List preserves order and allows duplicates.\n");


            Console.WriteLine("===== DICTIONARY<TKey, TValue> (Key-Value Pair) =====");

            Dictionary<string, string> phoneBook = new();
            phoneBook["Ritu"] = "9999";
            phoneBook["Raushan"] = "8888";

            foreach (var kv in phoneBook)
                Console.WriteLine($"{kv.Key} : {kv.Value}");

            Console.WriteLine("Dictionary searches by KEY (O(1) lookup).\n");


            Console.WriteLine("===== HASHSET<T> (Unique Values Only) =====");

            HashSet<int> uniqueNumbers = new() { 1, 2, 2, 3, 3, 3 };

            foreach (var n in uniqueNumbers)
                Console.WriteLine(n);

            Console.WriteLine("HashSet removes duplicates automatically.\n");


            Console.WriteLine("===== QUEUE<T> (FIFO) =====");

            Queue<string> queue = new();
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            while (queue.Count > 0)
                Console.WriteLine(queue.Dequeue());

            Console.WriteLine("Queue = First-In First-Out (like ticket line).\n");


            Console.WriteLine("===== STACK<T> (LIFO) =====");

            Stack<string> stack = new();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");

            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());

            Console.WriteLine("Stack = Last-In First-Out (plates in a stack).\n");
        }
    }
}
