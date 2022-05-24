using System;
using System.Collections.Generic;
using MyGame;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyGame
{
    internal abstract class BaseController
    {
        private List<GameObject> gameObjects;
        private List<BaseController> baseControllers;

        private bool isDisposed;

        public void Dispose()
        {
            if (isDisposed)
                return;

            isDisposed = true;

            DisposeBaseControllers();

            DisposeGameObjects();

            OnDispose();
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
    }
}
