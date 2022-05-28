using System.Collections.Generic;
namespace MyGame.Services.Analitics
{
    internal interface IAnaliticsService
    {
        void SendEvent(string alias);
        void SendEvent(string alias, Dictionary<string, object> eventData);

    }
}
