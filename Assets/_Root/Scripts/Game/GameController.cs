using MyGame;
using MyGame.Game.Car;
using MyGame.Game.TapeBackground;
using MyGame.Profile;
using MyGame.Tools;
using MyGame.Game.InputLogic;
using System;

namespace MyGame.Game
{
    internal class GameController : BaseController
    {
        private readonly ProfilePlayer profilePlayer;
        public GameController(ProfilePlayer profilePlayer)
        {
            SubscriptionProperty<float> leftMoveDiff = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMoveDiff = new SubscriptionProperty<float>();

            BackgroundController backgroundController = new BackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(backgroundController);

            InputGameController inputController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CarModel);

            CarController carController = LoadCar(profilePlayer.currentCar);
            AddController(carController);

        }

        private CarController LoadCar(CarType carType)
        {
            CarController car = null;
            switch (carType)
            {
                case CarType.Truck:
                    car = new CarController();
                    break;
                case CarType.SpeedCar:
                    car = new SpeedCarController();
                    break;
                default:
                    break;
            }
            return car;
        }
    }
}