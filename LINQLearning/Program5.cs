using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LINQLearning
{
    // 1. LINQ on files using File.ReadLines
    // 2. Query syntax and Method syntax
    // 3. Batch processing using Chunk extension method
    // 4. Use Parallel.ForEach for multi-core speedup
    // 5. For extremely huge files → Use FileStream + BufferedReader
    // Note: Ensure to include 'using System.IO;' and 'using System.Threading.Tasks;' at the top of your file
    public class Program5
    {
        public void LinqOnFiles()
        {
            string path = @"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\LINQLearning\data.txt";

            // File.ReadLines() streams the file lazily (line by line)
            var longLines = File.ReadLines(path)
                                .Where(line => line.Contains("last line"))
                                .Select(line => line.ToUpper());

            foreach (var line in longLines)
                Console.WriteLine(line);
        }
        public void LinqOnFiles_query()
        {
            string path = @"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\LINQLearning\data.txt";
            var longLinesQuery = from line in File.ReadLines(path)
                                 where line.Contains("last line")
                                 select line.ToUpper();
            foreach (var line in longLinesQuery)
                Console.WriteLine(line);
        }
        public void LinqOnFiles_BatchProcessing()
        {
            string path = @"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\LINQLearning\data.txt";
            int batchSize = 10000;
            var lines = File.ReadLines(path);
            foreach (var batch in lines.Chunk(batchSize))
            {
                var filtered = batch.Where(l => l.Contains("LINQ exercises"));
                Console.WriteLine(filtered.Count()); 
                // This count is just an example of processing.
                // What value it is returning?
                // As output, it will return number of lines in each batch that contain "LINQ exercises"
                // In real scenario, you might want to save to DB, or process
            }
        }
        public void LinqOnFiles_BatchProcessing_query()
        {
            string path = @"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\LINQLearning\data.txt";
            int batchSize = 10000;
            var lines = File.ReadLines(path);
            foreach (var batch in lines.Chunk(batchSize))
            {
                var filteredQuery = from l in batch
                                    where l.Contains("LINQ exercises")
                                    select l;
                Console.WriteLine(filteredQuery.Count());
                // This count is just an example of processing.
                // What value it is returning?
                // As output, it will return number of lines in each batch that contain "LINQ exercises"
                // In real scenario, you might want to save to DB, or process
            }
        }
        // Using Parallel Linq (PLINQ) for parallel processing
        // Note: Be cautious with PLINQ when dealing with I/O operations
        // as it may lead to contention and reduced performance. 
        // Always benchmark and test in your specific scenario.
        // Here, we demonstrate a simple parallel processing example

        public void LinqOnFiles_ParallelProcessing()
        {
            string path = @"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\LINQLearning\data.txt";
            Parallel.ForEach(File.ReadLines(path), line =>
            {
                if (line.Contains("file123"))
                    Console.WriteLine(line);
            });
            // Note: The order of output lines may vary due to parallel execution
        }

        public void LinqOnFiles_ParallelProcessing_query()
        {
            string path = @"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\LINQLearning\data.txt";
            var parallelLinesQuery = from line in File.ReadLines(path).AsParallel()
                                     where line.Contains("file123")
                                     select line;
            foreach (var line in parallelLinesQuery)
                Console.WriteLine(line);
        }
        public void LinqOnFiles_LargeFileHandling()
        {
            // For extremely large files, consider using FileStream with BufferedReader
            // This is a more advanced topic and requires careful resource management
            // ✔ Fastest possible reading
            // ✔ No memory spike
            // ✔ Suitable for crores of lines
            // Here is a simplified example
            string path = @"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\LINQLearning\largefile.log";
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            using (var reader = new StreamReader(fileStream))
            {
                string? line;
                while ((line = reader.ReadLine()) != null) 
                {
                    if (line.Contains("[ERROR]"))
                    {
                        Console.WriteLine(line);
                    }
                }
                // how else it can be written? 
                //while (!reader.EndOfStream)
                //{
                //    var currentLine = reader.ReadLine();
                //    if (currentLine != null && currentLine.Contains("[ERROR]"))
                //    {
                //        Console.WriteLine(currentLine);
                //    }
                //}
            }
        }

        public void LinqOnFiles_LargeFileHandling_query()
        {
            // Similar to above, but using query syntax where applicable
            string path = @"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\LINQLearning\largefile.log";
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            using (var reader = new StreamReader(fileStream))
            {
                List<string> lines = new();
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                var filteredLinesQuery = from l in lines
                                         where l.Contains("Error")
                                         select l;
                foreach (var filteredLine in filteredLinesQuery)
                {
                    Console.WriteLine(filteredLine);
                }
            }
        }

        public void LinqOnXML()
        {
            // Sample XML processing using LINQ to XML
            XDocument doc = XDocument.Load(@"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\LINQLearning\people.xml");

            var result = doc.Descendants("Person")
                           .Select(p => new
                           {
                               Name = (string)p.Element("Name")!,
                               Age = (int)p.Element("Age")!,
                               IsAdult = (int)p.Element("Age")! >= 18
                           });

            foreach (var r in result)
                Console.WriteLine($"{r.Name} - {r.Age} - Adult: {r.IsAdult}");
        }
        
        public void LinqOnXML_query()
        {
            // Sample XML processing using LINQ to XML
            XDocument doc = XDocument.Load(@"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\LINQLearning\people.xml");

            var names =
                from person in doc.Descendants("Person")
                where (int)person.Element("Age")! > 25
                select person.Element("Name")!.Value;
            
            foreach (var n in names)
                Console.WriteLine(n);
            // Note: The '!' operator is used to suppress nullable warnings for simplicity
            // In production code, proper null checks should be implemented
            // it is similar to string? name = person.Element("Name")?.Value; 
            // But here we are sure that Name element exists, so we use '!' to tell compiler that it won't be null 
            // However, be cautious with this approach to avoid runtime exceptions. 
            // In above code, we can not use '?' operator because if Name element is null, then the whole select will return null and we want to avoid that.
            // So '?' vs '!' depends on the context and what you want to achieve.
            // '?' is for safe navigation when you expect possible nulls and want to handle them gracefully.
            // '!' is for asserting non-null when you are certain the value won't be null. 
            // It is used with objects that are nullable reference types or nullable value types. 
            // Example: string? name = person.Element("Name")?.Value; if name is null, then we can handle it accordingly.
        }
        // XML files with millions of nodes CANNOT be loaded with:
        // XDocument.Load()
        // because:
        //❌ It loads ENTIRE XML into memory
        //❌ It will crash or freeze on very large files
        //✔ Best approach: Use XmlReader(forward-only streaming)

        public void LinqOnXML_LargeFileHandling()
        {
            using XmlReader reader = XmlReader.Create("big.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Person")
                {
                    var personXml = reader.ReadOuterXml();
                    ProcessPerson(personXml);
                }
            }
        }
        static void ProcessPerson(string xml)
        {
            var element = XElement.Parse(xml);

            string name = element.Element("Name")!.Value;
            int age = (int)element.Element("Age")!;

            if (age > 25)
                Console.WriteLine($"{name} - {age}");
        }
        public void Execute()
        {
            LinqOnFiles();
            LinqOnFiles_query();
            LinqOnFiles_BatchProcessing();
            LinqOnFiles_BatchProcessing_query();
            LinqOnFiles_ParallelProcessing();
            LinqOnFiles_ParallelProcessing_query();
            LinqOnFiles_LargeFileHandling();
            LinqOnFiles_LargeFileHandling_query();
            LinqOnXML();
        }



    }
}
