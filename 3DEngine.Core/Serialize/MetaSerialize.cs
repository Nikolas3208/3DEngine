using _3DEngine.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _3DEngine.Core.Serialize
{
    public static class MetaSerialize
    {
        public static void SaveToFile(MetaData data, string path)
        {
            var json = SaveToJson(data);

            File.WriteAllText(path, json);
        }

        public static async Task SaveToFileAsync(MetaData data, string path)
        {
            using var stream = File.OpenWrite(path);

            await JsonSerializer.SerializeAsync(stream, data, new JsonSerializerOptions() { IncludeFields = true, WriteIndented = true });

            stream.Close();
        }

        public static string SaveToJson(MetaData data)
        {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions() { IncludeFields = true, WriteIndented = true });
        }

        public static MetaData? LoadFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File {path} not found!");

            var json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<MetaData>(json, new JsonSerializerOptions() { IncludeFields = true, WriteIndented = true });
        }

        public static async Task<MetaData?> LoadFromFileAsync(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File {path} not found!");

            using (var stream = File.OpenRead(path))
            {
                return await JsonSerializer.DeserializeAsync<MetaData>(stream, new JsonSerializerOptions() { IncludeFields = true, WriteIndented = true });
            } 
        }
    }
}
