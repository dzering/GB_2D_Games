using UnityEngine;
using MyGame.Profile;
using MyGame.Services.Analitics;
using MyGame.Services.Ads.UnityAds;
using MyGame.Game.Transport;

namespace MyGame
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GeneralSettings settings;
        [SerializeField] private Transform PlaceForUI;
        
        private MainController mainController;


        private void Start()
        {
            ProfilePlayer profilePlayer = new ProfilePlayer(settings.InitiialState, settings.SpeedCar, settings.carType);
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