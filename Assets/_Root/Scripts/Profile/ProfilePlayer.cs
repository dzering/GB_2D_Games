using MyGame.Tools;

namespace MyGame.Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly CarModel CarModel;

        public ProfilePlayer(GameState initialState, float speed) : this(speed)
        {
            CurrentState.Value = initialState;
        }

        public ProfilePlayer(float speed)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CarModel = new CarModel(speed);
        }
    }
}