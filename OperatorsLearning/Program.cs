namespace OperatorsLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's Understand Operators in c#");
            int a = 10;
            int b = 20;
            // Arithmetic Operators
            Console.WriteLine($"Addition: {a} + {b} = {a + b}"); // Explain: The + operator adds two operands. In this case, it adds the values of a and b.
            Console.WriteLine($"Subtraction: {b} - {a} = {b - a}");
            Console.WriteLine($"Multiplication: {a} * {b} = {a * b}");
            Console.WriteLine($"Division: {b} / {a} = {b / a}");
            Console.WriteLine($"Modulus: {b} % {a} = {b % a}");

            // Comparison Operators
            Console.WriteLine($"Equal: {a} == {b} : {a == b}");
            Console.WriteLine($"Not Equal: {a} != {b} : {a != b}");
            Console.WriteLine($"Greater Than: {b} > {a} : {b > a}");
            Console.WriteLine($"Less Than: {a} < {b} : {a < b}");
            Console.WriteLine($"Greater Than or Equal: {a} >= {b} : {a >= b}");
            Console.WriteLine($"Less Than or Equal: {a} <= {b} : {a <= b}");

            // Logical Operators
            bool x = true;
            bool y = false;
            Console.WriteLine($"Logical AND: {x} && {y} : {x && y}");
            Console.WriteLine($"Logical OR: {x} || {y} : {x || y}");
            Console.WriteLine($"Logical NOT: !{x} : {!x}");

            // Assignment Operators
            int c = a; // Simple assignment
            c += b; // c = c + b
            Console.WriteLine($"After c += b, c = {c}");
            c -= a; // c = c - a
            Console.WriteLine($"After c -= a, c = {c}");
            c *= 2; // c = c * 2
            Console.WriteLine($"After c *= 2, c = {c}");
            c /= 2; // c = c / 2
            Console.WriteLine($"After c /= 2, c = {c}");
            c %= 3; // c = c % 3
            Console.WriteLine($"After c %= 3, c = {c}");

            // Increment and Decrement Operators
            Console.WriteLine($"Initial a: {a}");
            Console.WriteLine($"Post-increment a++: {a++} (a is now {a})");
            a = 10; // Resetting a
            Console.WriteLine($"Pre-increment ++a: {++a} (a is now {a})");
            a = 10; // Resetting a
            Console.WriteLine($"Initial b: {b}");
            Console.WriteLine($"Post-decrement b--: {b--} (b is now {b})");
            b = 20; // Resetting b
            Console.WriteLine($"Pre-decrement --b: {--b} (b is now {b})");

            // Ternary Operator
            int max = (a > b) ? a : b;
            Console.WriteLine($"Ternary Operator: Max of {a} and {b} is {max}");

            // Bitwise Operators
            Console.WriteLine($"Bitwise AND: {a} & {b} = {a & b}");
            Console.WriteLine($"Bitwise OR: {a} | {b} = {a | b}");
            Console.WriteLine($"Bitwise XOR: {a} ^ {b} = {a ^ b}");
            Console.WriteLine($"Bitwise NOT: ~{a} = {~a}");
            Console.WriteLine($"Left Shift: {a} << 1 = {a << 1}");
            Console.WriteLine($"Right Shift: {b} >> 1 = {b >> 1}");

            // Null-coalescing Operator
            string? str = null;
            string result = str ?? "Default Value";
            // What is ??: The null-coalescing operator (??) is used to define a default value for nullable types. If the value on the left side is null, it returns the value on the right side.
            // In this case, since str is null, result will be "Default Value"
            // If str had a value, result would be that value instead.
            Console.WriteLine($"Null-coalescing Operator: str is null, so result = '{result}'");

            // Null-coalescing Assignment Operator
            str ??= "Assigned Value";
            Console.WriteLine($"Null-coalescing Assignment Operator: str = '{str}'");
            Console.WriteLine("End of Operators demonstration.");
        }
    }
}
