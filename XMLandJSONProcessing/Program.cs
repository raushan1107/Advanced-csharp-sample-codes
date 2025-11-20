using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace XMLandJSONProcessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ReadXML();
            //WriteXML();
            //XMLSerialization();
            XMLDeserialization();
            //JSONSerialization();

        }

        static void ReadXML()
        {
            using XmlReader reader = XmlReader.Create(@"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\XMLandJSONProcessing\students.xml");

            while (reader.Read())
            {
                if (reader.IsStartElement() && reader.Name == "Student")
                {
                    // Move into <Student>
                    var studentXml = reader.ReadOuterXml();
                    Console.WriteLine(studentXml);
                }
            }
        }

        static void WriteXML()
        {
            using XmlWriter writer = XmlWriter.Create("students_output.xml");
            writer.WriteStartDocument();
            writer.WriteStartElement("Students");
            writer.WriteStartElement("Student");
            writer.WriteElementString("Name", "John Doe");
            writer.WriteElementString("Age", "21");
            writer.WriteEndElement(); // </Student>
            writer.WriteEndElement(); // </Students>
            writer.WriteEndDocument();

            writer.Flush(); // Optional, ensures all data is written to the file
            writer.Close();
            Console.WriteLine("XML file created successfully.");
            // we are using 'using' statement, so no need to explicitly close the writer here or flush.
        }

        static void XMLSerialization()
        {
            var student = new Student { Id = 11, Name = "Pratibha", Marks = 99 };

            var serializer = new XmlSerializer(typeof(Student));
            using var fs = File.OpenWrite(@"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\XMLandJSONProcessing\students.xml");

            serializer.Serialize(fs, student);
            Console.WriteLine("XML Serialization completed.");
        }

        public static void XMLDeserialization()
        {
            var serializer = new XmlSerializer(typeof(Student));
            using var fs = File.OpenRead(@"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\XMLandJSONProcessing\students.xml");
            var student = (Student)serializer.Deserialize(fs)!;
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Marks: {student.Marks}");
        }

        public static void JSONSerialization()
        {
            var student = new Student { Id = 1, Name = "Ritu", Marks = 90 };

            string json = JsonSerializer.Serialize(student);
            Console.WriteLine(json);

            Student obj = JsonSerializer.Deserialize<Student>(json)!;
            Console.WriteLine(obj.Name);

        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
    }
}
