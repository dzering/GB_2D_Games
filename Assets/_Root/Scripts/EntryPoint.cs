using UnityEngine;
using MyGame.Profile;

namespace MyGame
{
    internal class EntryPoint : MonoBehaviour
    {
        private const float SpeedCar = 15f;
        private const GameState InitiialState = GameState.Start;
        private const CarType carType = CarType.SpeedCar;


        [SerializeField] private Transform PlaceForUI;
        private MainController mainController;

        private void Start()
        {
            ProfilePlayer profilePlayer = new ProfilePlayer(InitiialState, SpeedCar, carType);
            mainController = new MainController(PlaceForUI, profilePlayer);
        }

        private void OnDestroy()
        {
            mainController.Dispose();
        }
    }
}