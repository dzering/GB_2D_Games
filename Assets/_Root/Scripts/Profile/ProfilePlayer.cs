using MyGame.Tools;
using MyGame.Features.Inventory;
using MyGame.Game.Transport;

namespace MyGame.Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly TransportModel CurrentTransport;
        public readonly InventoryModel InventoryModel;

        public ProfilePlayer(GameState initialState, float speed, TransportType transportType)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentTransport = new TransportModel(speed, transportType);
            CurrentState.Value = initialState;
            InventoryModel = new InventoryModel();
        }
    }
}