using _3DEngine.Core.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace _3DEngine.Core.Resources
{
    public class MetaData
    {
        public Dictionary<string, string> Propertis;

        public AssetType Type { get; set; }

        public string Name { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;

        public Guid Id;

        public MetaData()
        {
            Propertis = new Dictionary<string, string>();

            Id = Guid.NewGuid();
        }

        public MetaData(Asset asset)
        {
            Id = asset.Id;
            Type = asset.Type;
            Name = asset.Name;
            FilePath = asset.FilePath;

            Propertis = new Dictionary<string, string>();

            SaveProperties(asset);
        }

        private void SaveProperties(Asset asset)
        {
            var members = SerializeUtils.GetInspectableMembers(asset.GetType());

            foreach (var member in members)
            {
                object? value = member switch
                {
                    FieldInfo field => field.GetValue(asset),
                    PropertyInfo prop => prop.GetValue(asset),
                    _ => null
                };

                if (value == null)
                    continue;

                if(value is not Asset)
                {
                    AddProperties(member.Name, value);
                }
                else if(value is Asset refAsset)
                {
                    AddProperties(member.Name, refAsset.Id);
                }
            }
        }

        public void AddProperties<T>(string name, T obj)
        {
            Propertis[name] = JsonSerializer.Serialize(obj);
        }

        public T? GetPropertie<T>(string name)
        {
            if(Propertis.TryGetValue(name, out var value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }

            return default(T);
        }

        public object? GetPropertie(string name, Type type)
        {
            if (Propertis.TryGetValue(name, out var value))
            {
                return JsonSerializer.Deserialize(value, type);
            }

            return null;
        }
    }
}
