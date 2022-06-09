using UnityEngine;
using MyGame.Game.Transport;
using MyGame.Game.TapeBackground;
using MyGame.Profile;
using MyGame.Tools;
using MyGame.Game.InputLogic;
using System;
using MyGame.Features.AbilitySystem;

namespace MyGame.Game
{
    internal class GameController : BaseController
    {
        private readonly ProfilePlayer profilePlayer;
        private readonly AbilityController abilityController;
        public GameController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            this.profilePlayer = profilePlayer;
            SubscriptionProperty<float> leftMoveDiff = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMoveDiff = new SubscriptionProperty<float>();

            BackgroundController backgroundController = new BackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(backgroundController);

            InputGameController inputController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentTransport);

            TransportController transportController = CreateTransport();
            AddController(transportController);

            abilityController = new AbilityController(placeForUI, transportController);

        }

        private TransportController CreateTransport()
        {
            TransportController transportController =
                profilePlayer.CurrentTransport.TransportType switch
                {
                    TransportType.Truck => new TruckController(),
                    TransportType.SpeedCar => new CarController(),
                    _=> throw new ArgumentException(nameof(TransportType))
                };
            AddController(transportController);
            return transportController;
        }
    }
}