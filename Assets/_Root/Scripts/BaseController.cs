using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyGame
{
    internal abstract class BaseController : IDisposable
    {
        private List<GameObject> gameObjects;
        private List<IDisposable> disposables;

        private bool isDisposed;

        public void Dispose()
        {
            if (isDisposed)
                return;

            isDisposed = true;


            DisposeGameObjects();
            DisposeDisposabl();

            OnDispose();
        }

        private void DisposeDisposabl()
        {
            if (disposables == null)
                return;
            foreach (IDisposable disposable in disposables)
            {
                disposable.Dispose();
            }
            disposables.Clear();
        }

        private void DisposeGameObjects()
        {
            if (gameObjects == null)
                return;

            foreach (GameObject gameObject in gameObjects)
                Object.Destroy(gameObject);

            gameObjects.Clear();
        }

        protected void AddGameObject(GameObject gameObject)
        {
            gameObjects ??= new List<GameObject>();
            gameObjects.Add(gameObject);
        }

        protected void AddController(BaseController controller) => AddDisposable(controller);

        protected void AddRepository(IRepository repository) => AddDisposable(repository);
        protected virtual void OnDispose()
        {
        }

        private void AddDisposable(IDisposable disposable)
        {
            disposables ??= new List<IDisposable>();
            disposables.Add(disposable);
        } 
    }
}
