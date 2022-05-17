using MyGame;
using MyGame.Game.Car;
using MyGame.Game.TapeBackground;
using MyGame.Profile;
using MyGame.Tools;
using MyGame.Game.InputLogic;

namespace MyGame.Game
{
    internal class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer)
        {
            SubscriptionProperty<float> leftMoveDiff = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMoveDiff = new SubscriptionProperty<float>();

            BackgroundController backgroundController = new BackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(backgroundController);

            InputGameController inputController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CarModel);

            CarController carController = new CarController();
            AddController(carController);

        }
    }
}