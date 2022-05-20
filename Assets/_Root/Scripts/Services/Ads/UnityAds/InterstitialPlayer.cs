using UnityEngine.Advertisements;

namespace MyGame.Services.Ads.UnityAds
{
    internal sealed class InterstitialPlayer : UnityAdsPlayer
    {
        public InterstitialPlayer(string id) : base(id)
        {
        }

        protected override void OnPlaying() => Advertisement.Show(id);

        protected override void Load() => Advertisement.Load(id);
    }
}