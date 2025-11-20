using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
namespace SecurityLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //DoEncryption();
            DoHashChecking();
            
        }

        public static void DoHashing()
        {
            string input = "Hello, World!";
            using SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            string hash = Convert.ToBase64String(hashBytes);
            Console.WriteLine($"SHA256 Hash: {hash}");
        }

        public static void DoEncryption()
        {
            string text = "Raushan@Ranjan";
            using Aes aes = Aes.Create();
            aes.GenerateKey();
            aes.GenerateIV();

            byte[] encrypted = Encrypt(text, aes.Key, aes.IV);
            string decrypted = Decrypt(encrypted, aes.Key, aes.IV);

            Console.WriteLine("Encrypted: " + Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted: " + decrypted);

        }
        public static byte[] Encrypt(string plain, byte[] key, byte[] iv)
        {
            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using var encryptor = aes.CreateEncryptor();
            return encryptor.TransformFinalBlock(
                Encoding.UTF8.GetBytes(plain), 0, plain.Length);
        }

        public static string Decrypt(byte[] cipher, byte[] key, byte[] iv)
        {
            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            byte[] result = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);

            return Encoding.UTF8.GetString(result);
        }

        public static void DoHashChecking()
        {
            string folder = @"C:\Users\raush\Downloads\Csharp-Sample-Codes\CSharpSampleCodes\SecurityLearning\DataFiles";
            string db = "HashDatabase.json";


            // auto-create folder if missing
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                Console.WriteLine($"[INFO] Created folder: {folder}");
            }

            // create some test files
            //CreateTestFiles(folder, 15);

            // initialize database (auto-create JSON file)
            var store = new HashStore(db);
            var integrity = new FileIntegrityService(store);

            Console.WriteLine("1. Generate hash database");
            Console.WriteLine("2. Verify integrity");
            Console.Write("Choose option: ");

            var key = Console.ReadLine();

            if (key == "1")
            {
                Console.WriteLine("Generating initial hash signatures...");
                integrity.GenerateHashes(folder);
            }
            else if (key == "2")
            {
                Console.WriteLine("Verifying files...");
                integrity.VerifyIntegrity(folder);
            }

            Console.WriteLine("Completed.");
        }
        public static void CreateTestFiles(string folder, int count)
        {
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                string path = Path.Combine(folder, $"testfile_{i}.txt");
                File.WriteAllText(path, $"Random data: {random.Next()}");
            }
        }
    }
}
