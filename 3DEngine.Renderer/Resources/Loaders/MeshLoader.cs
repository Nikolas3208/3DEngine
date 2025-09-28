using Assimp;

namespace _3DEngine.Renderer.Resources.Loaders
{
    public class MeshLoader
    {
        public static Mesh LoadFromFile(string path)
        {
            var context = new AssimpContext();
            Scene scene = context.ImportFile(path, PostProcessSteps.Triangulate | PostProcessSteps.GenerateNormals);

            foreach (var mesh in scene.Meshes)
            {
                Console.WriteLine($"Mesh: {mesh.Name}");
                Console.WriteLine($"Vertices: {mesh.VertexCount}");

                for (int i = 0; i < mesh.VertexCount; i++)
                {
                    var vertex = mesh.Vertices[i];
                    Console.WriteLine($"Vertex {i}: X={vertex.X}, Y={vertex.Y}, Z={vertex.Z}");
                }

                for (int i = 0; i < mesh.FaceCount; i++)
                {
                    var face = mesh.Faces[i];
                    Console.WriteLine($"Face {i}: Indices={string.Join(",", face.Indices)}");
                }
            }

            return null;
        }
    }
}
