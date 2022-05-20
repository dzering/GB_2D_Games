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
        [SerializeField] private AnaliticsManager analiticsManager;
        [SerializeField] private UnityAdsService unityAdsService;

        private MainController mainController;

        private void Start()
        {
            ProfilePlayer profilePlayer = new ProfilePlayer(InitiialState, SpeedCar, carType);
            mainController = new MainController(PlaceForUI, profilePlayer, analiticsManager, unityAdsService);

            analiticsManager.GameLaunched();
            if (unityAdsService.IsInitialized) OnAdsInitialized();
            else
                unityAdsService.Initialized.AddListener(OnAdsInitialized);

        }
        private void OnAdsInitialized() => unityAdsService.InterstitialPlayer.Play();


        private void OnDestroy()
        {
            mainController.Dispose();
        }
    }
}