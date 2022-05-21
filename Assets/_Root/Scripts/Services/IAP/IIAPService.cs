using UnityEngine;
using UnityEngine.Events;

namespace MyGame.Services.IAP
{
    internal interface IIAPService
    {
        UnityEvent Initialized { get; }
        UnityEvent PurchaseSucceed { get; }
        UnityEvent PurchaseFailed { get; }

        bool IsInitialized { get; }

        void Buy(string id);
        string GetPrice(string productID);
        void RestorePurchases();

    }
}