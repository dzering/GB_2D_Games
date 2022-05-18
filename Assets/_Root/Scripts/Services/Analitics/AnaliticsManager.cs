using MyGame.Services.Analitics.UnityAnalitics;
using System;
using UnityEngine;


namespace MyGame.Services.Analitics
{
    internal class AnaliticsManager : MonoBehaviour 
    {
        private IAnaliticsService[] services;

        private void Awake()
        {
            services = new IAnaliticsService[]
            {
                new UnityAnaliticsService()
            };
        }

        public void SendMainMenuOpend()
        {
            SendEvent("MainMenuOpend");
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
