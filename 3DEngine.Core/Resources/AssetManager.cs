using _3DEngine.Core.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Core.Resources
{
    public static class AssetManager
    {
        private static Dictionary<Guid, Asset> assets = new();

        public static string RootPath = string.Empty;
        public static string AssetPath = "Assets\\";
        public static string MetaPath = "Meta\\";

        public static string[] GetAssetFiles(string searchPattern = "*", SearchOption searchOption = SearchOption.AllDirectories)
        {
            var assets = Directory.GetFiles(AssetPath, searchPattern, searchOption);

            Array.Sort(assets);

            return assets;
        }


        public static string[] GetMetaFiles(string searchPattern = "*", SearchOption searchOption = SearchOption.AllDirectories)
        {
            var metas = Directory.GetFiles(MetaPath, searchPattern, searchOption);

            Array.Sort(metas);

            return metas;
        }

        public static bool AddAsset(Guid id, Asset asset)
        {
            if(assets.ContainsKey(id))
            {
                throw new Exception($"A asset with this id {id} already exists.");
            }

            if(!ContainsAsset(asset.FilePath))
            {
                assets.Add(id, asset);
                AssetDataBase.AddAsset(id, asset.FilePath);

                Console.WriteLine($"Load asset {asset.Name}");

                return true;
            }

            return false;
        }

        public static bool ContainsAsset(Guid id)
        {
            return assets.ContainsKey(id);
        }

        public static bool ContainsAsset(string path)
        {
            var assetPaths = AssetDataBase.GetAllAssetPaths();
            return assetPaths.FirstOrDefault(p => p.ToLower() == path.ToLower()) != null;
        }

        public static Asset? GetAsset(Guid id)
        {
            return GetAsset<Asset>(id);
        }

        public static T? GetAsset<T>(Guid id) where T : Asset
        {
            if (assets.TryGetValue(id, out var asset))
            {
                if(asset is T tAsset)
                {
                    return tAsset;
                }
                throw new InvalidCastException($"Asset with id {id} is not of type {typeof(T).Name}");
            }

            return default(T);
        }

        public static MetaData? GetAssetData(Guid id)
        {
            var files = Directory.GetFiles(MetaPath, "*");

            var path = files.First(f => f.ToLower().Contains(id.ToString().ToLower()));

            if (path == null)
                return null;

            return MetaSerialize.LoadFromFile(path);
        }

        public static async Task<MetaData?> GetAssetDataAsync(Guid id)
        {
            var files = Directory.GetFiles(MetaPath, "*");

            var path = files.First(f => f.ToLower().Contains(id.ToString().ToLower()));

            if (path == null)
                return null;

            return await MetaSerialize.LoadFromFileAsync(path);
        }

        public static void SaveAssetData(Asset asset)
        {
            var extension = Path.GetExtension(asset.FilePath);

            MetaSerialize.SaveToFile(new MetaData(asset), MetaPath + asset.Id + ".meta");
        }

        public static async Task SaveAssetDataAsync(Asset asset)
        {
            var extension = Path.GetExtension(asset.FilePath);

            await MetaSerialize.SaveToFileAsync(new MetaData(asset), MetaPath + asset.Id + ".meta");
        }
    }
}
