using _3DEngine.Core.Resources;
using _3DEngine.Renderer.Resources.Loaders;

namespace _3DEngine.Renderer.Resources
{
    public static class AssetsLoader
    {
        public static void LoadAssets()
        {
            var metaFiles = AssetManager.GetMetaFiles();

            foreach (var metaFile in metaFiles)
            {
                var extension = Path.GetExtension(metaFile);
                var name = Path.GetFileNameWithoutExtension(metaFile);

                var metaData = AssetManager.GetAssetDataAsync(new Guid(name)).Result;

                if (metaData == null)
                    continue;

                var assetType = metaData.Type;

                switch (assetType)
                {
                    case AssetType.Texture:
                        var textureAsset = TextureLoader.LoadFromMeta(metaData);
                        AssetManager.AddAsset(metaData.Id, textureAsset);
                        break;

                    default:
                        break;
                }
            }

            var files = AssetManager.GetAssetFiles();

            foreach (var file in files)
            {
                if(AssetManager.ContainsAsset(file))
                    continue;

                var extension = Path.GetExtension(file);
                var name = Path.GetFileNameWithoutExtension(file);

                switch (extension)
                {
                    case ".png":
                    case ".jpg":
                        var textureAsset = TextureLoader.LoadFromFile(file);
                        if (AssetManager.AddAsset(textureAsset.Id, textureAsset))
                            AssetManager.SaveAssetDataAsync(textureAsset);
                        break;
                    case ".obj":
                        MeshLoader.LoadFromFile(file);
                        break;
                }
            }
        }
    }
}
