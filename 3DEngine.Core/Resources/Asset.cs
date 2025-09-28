using _3DEngine.Core.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Core.Resources
{
    public enum AssetType
    {
        Texture,
        Mesh,
        Material,
        Shader,
        Script
    }

    public class Asset
    {
        [HideSerialize]
        public Guid Id { get; }

        [HideSerialize]
        public string Name { get; internal set; } = string.Empty;

        [HideSerialize]
        public string FilePath { get; internal set; } = string.Empty;

        public AssetType Type { get; protected set; }

        public Asset()
        {
            Id = Guid.NewGuid();
        }

        public Asset(string name, string filePath)
        {
            Name = name;
            FilePath = filePath;

            Id = Guid.NewGuid();
        }

        public Asset(MetaData data)
        {
            Id = data.Id;
            Name = data.Name;
            FilePath = data.FilePath;
            Type = data.Type;

            var members = SerializeUtils.GetInspectableMembers(this.GetType());

            foreach (var member in members)
            {
                var memberType = SerializeUtils.GetMemberType(member);

                if(typeof(Asset).IsAssignableFrom(memberType))
                {
                    var id = data.GetPropertie<Guid>(member.Name);

                    var asset = AssetManager.GetAsset(id);

                    if (asset == null)
                        continue;

                    SerializeUtils.SetMemberValue(this, member, asset);
                    continue;
                }

                SerializeUtils.SetMemberValue(this, member, data.GetPropertie(member.Name, memberType)!);       
            }
        }
    }
}
