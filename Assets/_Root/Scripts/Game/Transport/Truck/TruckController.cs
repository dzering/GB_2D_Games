using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MyGame.Tools;
using Object = UnityEngine.Object;

namespace MyGame.Game.Transport
{
    internal class TruckController : TransportController
    {
        protected virtual ResourcePath path => new ResourcePath("Prefabs/Cars/Truck");
        private readonly CarView view;
        public override GameObject ViewGameObject => view.gameObject;

        public TruckController()
        {
            view = LoadView();
        }

        private CarView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPref(path);
            GameObject car = Object.Instantiate(prefab);
            AddGameObject(car);

            return car.GetComponent<CarView>();
        }
    }
}
