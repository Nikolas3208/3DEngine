using _3DEngine.Core.Resources;
using _3DEngine.Core.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _3DEngine.Renderer.Resources.Loaders
{
    public class MaterialLoader
    {
        public static Material LoadFromFile(string path)
        {
            return new Material(MetaSerialize.LoadFromFile(path)!);
        }

        public static void SaveToFile(Material material, string path)
        {
            var meta = new MetaData(material);
            MetaSerialize.SaveToFile(meta, path);
        }

        public static async Task SaveToFileAsync(Material material, string path)
        {
            using var stream = File.OpenWrite(path);
            await JsonSerializer.SerializeAsync(stream, material, new JsonSerializerOptions() { IncludeFields = true, WriteIndented = true });
            stream.Close();
        }
    }
}
