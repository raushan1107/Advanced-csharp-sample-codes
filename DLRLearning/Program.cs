using IronPython.Hosting;

namespace DLRLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic a = 10;
            Console.WriteLine(a);
            a = "Raushan";
            Console.WriteLine(a);

            Console.WriteLine("--------------------------------------\n");
            var pythonrt = Python.CreateRuntime();
            dynamic pythonScript = pythonrt.UseFile(@"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\DLRLearning\pythonfile.py");
            var result = pythonScript.getname();
            Console.WriteLine("Result is : {0}", result);

            // Calling TempCalculation function
            Console.WriteLine("Temp in Cel: {0}", pythonScript.fahrenheit_to_celsius(98.6)); 

            // We need Runtime to hold the script and execute it.
            // We can create runtime using Python.CreateRuntime() method. Coming from IronPython.Hosting namespace.
            // For other languages that generates unmanaged code, we have other CreateRuntime methods.
            // For example, for IronRuby, we have Ruby.CreateRuntime() method.
            // For Java, we have Java.CreateRuntime() method. And Package name is IronJava.Hosting.
            // Similarly, for PHP, we have Php.CreateRuntime() method. And Package name is IronPhp.Hosting.

            // can we use 



            // why we used var for runtime and dynamic for script?
            // Because runtime is a static object and script is a dynamic object.
            // Always remember that dynamic objects are resolved at runtime, not at compile time.
            // So, we need to use dynamic keyword for script object.

            // In LINQ, we use var keyword to hold the result of a query because the result type is not known at compile time.
            // We don't use dynamic keyword in LINQ because LINQ queries are resolved at compile time.
            // So, we use var keyword to hold the result of a LINQ query.
            // But that expression of query is resolved at runtime. We just know the result type at compile time.
        }
    }
}
