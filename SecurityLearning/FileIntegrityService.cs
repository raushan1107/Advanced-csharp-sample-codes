using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLearning
{
    internal class FileIntegrityService
    {
        private readonly HashStore _store;

        public FileIntegrityService(HashStore store)
        {
            _store = store;
        }

        public void GenerateHashes(string folder)
        {
            var files = Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories);

            Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, file =>
            {
                // DO NOT HASH THE DATABASE ITSELF
                if (Path.GetFileName(file).Equals("HashDatabase.json", StringComparison.OrdinalIgnoreCase))
                    return;

                string hash = HashChecking.ComputeSHA256(file);
                _store.SetHash(file, hash);
                Console.WriteLine($"[GEN] {file} → {hash}");
            });

            _store.Save();
        }

        public void VerifyIntegrity(string folder)
        {
            var files = Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories);

            Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, file =>
            {
                //// DO NOT HASH THE DATABASE ITSELF
                //if (Path.GetFileName(file).Equals("HashDatabase.json", StringComparison.OrdinalIgnoreCase))
                //    return;

                string newHash = HashChecking.ComputeSHA256(file);
                string? oldHash = _store.GetHash(file);

                if (oldHash == null)
                {
                    Console.WriteLine($"[NEW FILE] {file}");
                    return;
                }

                if (newHash != oldHash)
                {
                    Console.WriteLine($"[CORRUPTED] {file}");
                    Console.WriteLine($" OLD: {oldHash}");
                    Console.WriteLine($" NEW: {newHash}");
                }
                else
                {
                    Console.WriteLine($"[OK] {file}");
                }
            });

            // Check if any file was deleted
            foreach (var entry in _store.Hashes.Keys)
            {
                if (!File.Exists(entry))
                    Console.WriteLine($"[MISSING] {entry}");
            }
        }
    }
}
