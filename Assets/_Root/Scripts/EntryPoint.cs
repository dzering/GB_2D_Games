using UnityEngine;
using MyGame.Profile;
using MyGame.Services.Analitics;

namespace MyGame
{
    internal class EntryPoint : MonoBehaviour
    {
        private const float SpeedCar = 15f;
        private const GameState InitiialState = GameState.Start;
        private const CarType carType = CarType.SpeedCar;


        [SerializeField] private Transform PlaceForUI;
        [SerializeField] private AnaliticsManager analiticsManager;

        private MainController mainController;

        private void Start()
        {
            ProfilePlayer profilePlayer = new ProfilePlayer(InitiialState, SpeedCar, carType);
            mainController = new MainController(PlaceForUI, profilePlayer, analiticsManager);

            analiticsManager.GameLaunched();
        }

        private void OnDestroy()
        {
            mainController.Dispose();
        }
    }
}