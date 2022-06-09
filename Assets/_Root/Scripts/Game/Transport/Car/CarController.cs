using UnityEngine;
using MyGame.Tools;

namespace MyGame.Game.Transport
{
    internal class CarController : TransportController
    {
        private readonly ResourcePath path = new ResourcePath("Prefabs/Cars/SpeedCar");
        private readonly CarView view;
        public override GameObject ViewGameObject => view.gameObject;

        public CarController()
        {
            view = LoadView();
        }


        private CarView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPref(path);
            GameObject car = UnityEngine.Object.Instantiate(prefab);
            AddGameObject(car);

            return car.GetComponent<CarView>();
        }
    }
}