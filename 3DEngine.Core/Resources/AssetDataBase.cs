using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Core.Resources
{
    public class AssetDataBase
    {
        public static Dictionary<Guid, string> AssetPaths = new();
        public static Dictionary<string, Guid> AssetGuids = new();

        public static void AddAsset(Guid guid, string path)
        {
            if (!AssetPaths.ContainsKey(guid))
            {
                AssetPaths.Add(guid, path);
            }
            if (!AssetGuids.ContainsKey(path))
            {
                AssetGuids.Add(path, guid);
            }
        }

        public static string GetAssetPath(Guid guid)
        {
            if (AssetPaths.TryGetValue(guid, out var path))
            {
                return path;
            }

            return string.Empty;
        }

        public static Guid GetAssetGuid(string path)
        {
            if (AssetGuids.TryGetValue(path, out var guid))
            {
                return guid;
            }

            return Guid.Empty;
        }

        public static bool HasAsset(Guid guid)
        {
            return AssetPaths.ContainsKey(guid);
        }

        public static bool HasAsset(string path)
        {
            return AssetGuids.ContainsKey(path);
        }

        public static string[] GetAllAssetPaths()
        {
            return AssetPaths.Values.ToArray();
        }

        public static Guid[] GetAllAssetGuids()
        {
            return AssetPaths.Keys.ToArray();
        }

        public static void Clear()
        {
            AssetPaths.Clear();
            AssetGuids.Clear();
        }
    }
}
