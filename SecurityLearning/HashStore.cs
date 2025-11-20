using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecurityLearning
{
    public class HashStore
    {
        private readonly string _dbPath;

        public Dictionary<string, string> Hashes { get; private set; }

        public HashStore(string dbPath)
        {
            _dbPath = dbPath;
            if (!File.Exists(dbPath))
            {
                Console.WriteLine($"[INFO] Creating new hash database: {dbPath}");
                File.WriteAllText(dbPath, "{}");
            }
            Hashes = Load();
        }

        private Dictionary<string, string> Load()
        {
            string json = File.ReadAllText(_dbPath);
            return JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                   ?? new Dictionary<string, string>();
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(Hashes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_dbPath, json);
        }

        public void SetHash(string path, string hash)
        {
            Hashes[path] = hash;
        }

        public string? GetHash(string path)
        {
            return Hashes.ContainsKey(path) ? Hashes[path] : null;
        }
    }
}
