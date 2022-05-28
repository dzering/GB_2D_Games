using MyGame.Services.Analitics.UnityAnalitics;
using System;
using UnityEngine;


namespace MyGame.Services.Analitics
{
    internal class AnaliticsManager : MonoBehaviour 
    {
        public static AnaliticsManager Instance { get; private set; }

        private IAnaliticsService[] services;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;

            services = new IAnaliticsService[]
            {
                new UnityAnaliticsService()
            };
        }

        public void GameLaunched()
        {
            SendEvent("Game Launched");
        }

        public void GameStarted()
        {
            SendEvent("Game Started");
        }

        private void SendEvent(string eventName)
        {
            for (int i = 0; i < services.Length; i++)
            {
                services[i].SendEvent(eventName);
            }
        }
    }
}
