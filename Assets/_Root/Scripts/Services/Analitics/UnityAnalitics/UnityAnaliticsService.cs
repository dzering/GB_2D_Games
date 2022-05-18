using System.Collections.Generic;
using MyGame.Services.Analitics;

namespace MyGame.Services.Analitics.UnityAnalitics
{
    internal class UnityAnaliticsService : IAnaliticsService
    {
        public void SendEvent(string alias)
        {
            UnityEngine.Analytics.Analytics.CustomEvent(alias);
        }

        public void SendEvent(string alias, Dictionary<string, object> eventData)
        {
            UnityEngine.Analytics.Analytics.CustomEvent(alias, eventData);
        }
    }
}
