using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyGame
{
    internal abstract class BaseController
    {
        private List<GameObject> gameObjects;
        private List<BaseController> baseControllers;
        private List<IRepository> repositories;

        private bool isDisposed;

        public void Dispose()
        {
            if (isDisposed)
                return;

            isDisposed = true;

            DisposeBaseControllers();

            DisposeGameObjects();
            DisposeRepositories();

            OnDispose();
        }

        private void DisposeRepositories()
        {
            if (repositories == null)
                return;
            foreach (var repository in repositories)
            {
                repository.Dispose();
            }
            repositories.Clear();
        }

        private void DisposeGameObjects()
        {
            if (gameObjects == null)
                return;

            foreach (GameObject gameObject in gameObjects)
                Object.Destroy(gameObject);

            gameObjects.Clear();
        }

        private void DisposeBaseControllers()
        {
            if (baseControllers == null)
                return;

            foreach (BaseController baseController in baseControllers)
                baseController.Dispose();

            baseControllers.Clear();
        }

        protected virtual void OnDispose()
        {

        }
        protected void AddGameObject(GameObject gameObject)
        {
            gameObjects ??= new List<GameObject>();
            gameObjects.Add(gameObject);
        }

        protected void AddController(BaseController controller)
        {
            baseControllers ??= new List<BaseController>();
            baseControllers.Add(controller);
        }

        protected void AddRepository(IRepository repository)
        {
            repositories ??= new List<IRepository>();
            repositories.Add(repository);

        }
    }
}
