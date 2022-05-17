using UnityEngine;
using MyGame.Tools;

namespace MyGame.Game.Car
{
    internal class CarController : BaseController
    {
        protected virtual ResourcePath path => new ResourcePath("Prefabs/Cars/Car");
        private readonly CarView view;

        public CarController()
        {
            view = LoadView();
        }

        private CarView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPref(path);
            GameObject car = GameObject.Instantiate(prefab);
            AddGameObject(car);

            return car.GetComponent<CarView>();
        }
    }
}