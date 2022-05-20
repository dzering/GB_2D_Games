using UnityEngine;

namespace MyGame.Services.Ads.UnityAds.Settings
{
    [CreateAssetMenu(fileName = nameof(UnityAdsPlayer), menuName = "Services/Ads/" + nameof(UnityAdsSettings))]
    internal class UnityAdsSettings : ScriptableObject
    {
        [Header("Game ID")]
        [SerializeField] private string androidGameId;
        [SerializeField] private string iosGameID;

        [field: Header("Players")]
        [field: SerializeField] public AdsPlayerSettings Interstitial { get; private set; }
        [field: SerializeField] public AdsPlayerSettings Rewarded { get; private set; }


        [field: Header("Settings")]
        [field: SerializeField] public bool TestMode { get; private set; } = true;
        [field: SerializeField] public bool EnablePerPlacementMode { get; private set; } = true;




        public string GameId =>
#if UNITY_EDITOR
                androidGameId;
#else
            Application.platform switch
            {
                RuntimePlatform.Android => androidGameId,
                RuntimePlatform.IPhonePlayer => iOsGameId,
                _ => ""
            };
#endif


    }
}
