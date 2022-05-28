using UnityEngine;
using MyGame.Profile;
using MyGame.Services.Analitics;
using MyGame.Services.Ads.UnityAds;

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

            AnaliticsManager.Instance.GameLaunched();

            if (UnityAdsService.Instance.IsInitialized) OnAdsInitialized();
            else
                UnityAdsService.Instance.Initialized.AddListener(OnAdsInitialized);

        }
        private void OnAdsInitialized() => UnityAdsService.Instance.InterstitialPlayer.Play();


        private void OnDestroy()
        {
            mainController.Dispose();
        }
    }
}