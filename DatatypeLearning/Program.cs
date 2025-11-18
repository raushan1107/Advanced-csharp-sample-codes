namespace DatatypeLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"R:\Csharp";
            Console.WriteLine("Hello, World!");
            // Let's explore data types in C#
            int integerExample = 42;
            double doubleExample = 3.14;
            string stringExample = "Hello, C#";
            bool boolExample = true;
            Console.WriteLine(
                $"Integer: {integerExample}, " +
                $"Double: {doubleExample}, " +
                $"String: {stringExample}, " +
                $"Boolean: {boolExample}"
                );

            // Different ways to print variables in Console.WriteLine
            Console.WriteLine("Using concatenation: " + integerExample + ", " + doubleExample + ", "+ stringExample + ", " + boolExample);
            Console.WriteLine("Using formatted string: {0}, {1}, {2}, {3}", integerExample, doubleExample, stringExample, boolExample);
            Console.WriteLine($"Using interpolated string: {integerExample}, {doubleExample}, {stringExample}, {boolExample}");

            // Demonstrating value types vs reference types
            int valueType1 = 10;
            int valueType2 = valueType1; // Copying value

            Console.WriteLine(object.ReferenceEquals(valueType1, valueType2));
            valueType2 = 20;
            Console.WriteLine($"Value Types - valueType1: {valueType1}, valueType2: {valueType2}");
            string referenceType1 = "Hello";
            string referenceType2 = referenceType1; // Copying reference
            Console.WriteLine(object.ReferenceEquals(referenceType1, referenceType2));
            
            referenceType2 += "World";
            Console.WriteLine(object.ReferenceEquals(referenceType1, referenceType2)); 
            
            Console.WriteLine($"referenceType1: {referenceType1}, referenceType2: {referenceType2}");
            
            
            
            // with arrays as well it's more evident
            int[] array1 = { 1, 2, 3 };
            int[] array2 = array1; // Copying reference
            array2[0] = 99;
            Console.WriteLine($"Arrays - array1[0]: {array1[0]}, array2[0]: {array2[0]}");

            // Boxing and Unboxing
            int num = 123; // Value type
            object boxedNum = num; // Boxing
            int unboxedNum = (int)boxedNum; // Unboxing
            Console.WriteLine($"Boxed Number: {boxedNum}, Unboxed Number: {unboxedNum}");


        }
    }
}
