using UnityEngine.Advertisements;
using UnityEngine;
using MyGame.Services.Ads.UnityAds.Settings;
using UnityEngine.Events;
using System;

namespace MyGame.Services.Ads.UnityAds
{
    internal class UnityAdsService : MonoBehaviour, IUnityAdsInitializationListener, IAdsService
    {
        [Header("Components")]
        [SerializeField] private UnityAdsSettings settings;

        [field: Header("Events")]
        [field: SerializeField] public UnityEvent Initialized { get; private set; }

        public IAdsPlayer InterstitialPlayer { get; private set; }

        public IAdsPlayer RewardedPlayer { get; private set; }

        public IAdsPlayer BannerPlayer { get; private set; }


        public bool IsInitialized => Advertisement.isInitialized;

        private void Awake()
        {
            InitializeAds();
            InitializePlayers();
        }

        private void InitializePlayers()
        {
            InterstitialPlayer = CreateInterstitial();
            RewardedPlayer = CreateRewardedPlayer();
            BannerPlayer = CreateBannerPlayer();
        }

        private IAdsPlayer CreateRewardedPlayer() =>
            settings.Rewarded.Enabled
            ? new RewardedPlayer(settings.Rewarded.Id)
            : (IAdsPlayer)new EmptyPlayer("");

        private IAdsPlayer CreateInterstitial() =>
             settings.Interstitial.Enabled
            ? new InterstitialPlayer(settings.Interstitial.Id)
            : new EmptyPlayer("");

        private IAdsPlayer CreateBannerPlayer() =>
                new EmptyPlayer("");

        private void InitializeAds()
        {
            Advertisement.Initialize(
                settings.GameId, 
                settings.TestMode,
                settings.EnablePerPlacementMode,
                this);
        }

        void IUnityAdsInitializationListener.OnInitializationComplete()
        {
            Log("Unity Ads initialization complete.");
            Initialized?.Invoke();
        }

        void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Error($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        }

        private void Log(string message) => Debug.Log(WrappMessage(message));
        private void Error(string message) => Debug.LogError(WrappMessage(message));
        private string WrappMessage(string message) => $"[{GetType().Name}] {message}";
    }
}
