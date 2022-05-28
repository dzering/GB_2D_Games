using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace MyGame.Services.Ads.UnityAds
{
    internal abstract class UnityAdsPlayer : IAdsPlayer, IUnityAdsListener
    {
        public event Action Started;
        public event Action Finished;
        public event Action Failed;
        public event Action Skipped;
        public event Action BecomeReady;

        protected readonly string id;

        protected UnityAdsPlayer(string id)
        {
            this.id = id;
            Advertisement.AddListener(this);
        }
        public void Play()
        {
            Load();
            OnPlaying();
            Load();

        }
        protected abstract void OnPlaying();

        protected abstract void Load();

        private bool IsIdMy(string _id) => id == _id;
        public void OnUnityAdsReady(string placementId)
        {
            if (IsIdMy(placementId) == false)
                return;

            Log("Ready");
            BecomeReady?.Invoke();

        }

        public void OnUnityAdsDidError(string message)
        {

            Log($"Error: {message}");
        }
        public void OnUnityAdsDidStart(string placementId)
        {
            if (IsIdMy(placementId) == false)
                return;
            Log("Started");
            Started?.Invoke();
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (IsIdMy(placementId) == false)
                return;
            switch (showResult)
            {
                case ShowResult.Failed:
                    Log("Failed");
                    Failed?.Invoke();
                    break;
                case ShowResult.Skipped:
                    Log("Skipped");
                    Skipped?.Invoke();
                    break;
                case ShowResult.Finished:
                    Log("Finished");
                    Finished?.Invoke();
                    break;
            }
        }



        private void Log(string message) => Debug.Log(WrapMessage(message));
        private void Error(string message) => Debug.LogError(WrapMessage(message));
        private string WrapMessage(string message) => $"[{GetType().Name}] {message}";

    }
}
