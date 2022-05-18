using System.Collections.Generic;
using MyGame.Services.Analitics;
using UnityEngine;

namespace MyGame.Services.Analitics.UnityAnalitics
{
    internal class UnityAnaliticsService : IAnaliticsService
    {
        public void SendEvent(string alias)
        {
            UnityEngine.Analytics.Analytics.CustomEvent(alias);
            Debug.Log("UnityAnalitics SendEvent");
        }

        public void SendEvent(string alias, Dictionary<string, object> eventData)
        {
            UnityEngine.Analytics.Analytics.CustomEvent(alias, eventData);
        }
    }
}
