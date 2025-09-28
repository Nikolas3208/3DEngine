namespace _3DEngine
{
    public class Project
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;

        public string ProjectPath { get; set; } = string.Empty;

        public Guid StartSceneId { get; set; } = Guid.Empty;

        public Project(string name, string description, string projectPath)
        {
            Name = name;
            Description = description;
            ProjectPath = projectPath;
        }

        private void CreateProject()
        {
            var game = new Game();
        }
    }
}
