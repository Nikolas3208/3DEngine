using _3DEngine.Core.Serialize;

namespace _3DEngine.Core
{
    public enum SceneState
    { 
        Edit,
        Play,
        Pause
    }

    public class Scene
    {
        private SceneState state;
        private SceneData? sceneData;

        protected List<GameObject> gameObjects;
        
        public SceneState State { get => state; set { UpdateState(value); } }

        public Guid Id { get; private set; }

        public Scene()
        {
            gameObjects = new List<GameObject>();

            Id = Guid.NewGuid();
        }

        private void UpdateState(SceneState state)
        {
            if(this.state == state) return;

            switch (state)
            {
                case SceneState.Edit:
                    LoadScene(sceneData);
                    break;
                case SceneState.Play:
                    if(this.state == SceneState.Edit)
                    {
                        sceneData = SaveScene();
                        Start();
                    }
                    break;
                case SceneState.Pause:
                    break;
            }

            this.state = state;
        }

        private SceneData SaveScene() => new SceneData(this);
        private void LoadScene(SceneData? sceneData)
        {
            if (sceneData == null)
                return;
        }

        public virtual void Start()
        {
            gameObjects.ForEach(g => g.Start());
        }

        public virtual void Update(float dt)
        {
            if (state != SceneState.Play)
                return;

            gameObjects.ForEach(g => g.Update(dt));
        }

        public virtual void Draw()
        {
            gameObjects.ForEach(g => g.Draw());
        }

        public void AddGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public GameObject GetGameObject(Guid id)
        {
            return gameObjects.Find(gameObject => gameObject.Id == id)!;
        }

        public GameObject RemoveGameObject(Guid id)
        {
            var go = gameObjects.Find(gameObject => gameObject.Id == id)!;

            gameObjects.Remove(go);

            return go;
        }

        public bool RemoveGameObject(GameObject gameObject)
        {
            return gameObjects.Remove(gameObject);
        }
    }
}
