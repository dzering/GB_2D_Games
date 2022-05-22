
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;
using MyGame.Services.IAP.Settings;

namespace MyGame.Services.IAP
{
    internal class IAPService : MonoBehaviour, IIAPService, IStoreListener
    {
        [Header("Components")]

        [SerializeField] private ProductLibrary productLibrary;

        [field: Header("Events")]

        [field:SerializeField] public UnityEvent Initialized { get; private set; }

        [field: SerializeField] public UnityEvent PurchaseSucceed { get; private set; }

        [field: SerializeField] public UnityEvent PurchaseFailed { get; private set; }

        public bool IsInitialized { get; private set; }

        private IStoreController storeController;
        private IExtensionProvider extensionsProvider;
        private PurchaseValidator purchaseValidator;
        private PurchaseRestorer purchaseRestorer;



        private void Awake()
        {
            InitializeProducts();

        }
        private void InitializeProducts()
        {
            StandardPurchasingModule purchasingModule = StandardPurchasingModule.Instance();
            ConfigurationBuilder builder = ConfigurationBuilder.Instance(purchasingModule);

            foreach (Settings.Product product in productLibrary.Products)
                builder.AddProduct(product.Id, product.ProductType);

            Log("Products initialized");
            UnityPurchasing.Initialize(this, builder);
        }
        void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            IsInitialized = true;
            storeController = controller;
            extensionsProvider = extensions;
            purchaseValidator = new PurchaseValidator();
            purchaseRestorer = new PurchaseRestorer(extensionsProvider);

            Log("Initialized");
            Initialized?.Invoke();
        }

        void IStoreListener.OnInitializeFailed(InitializationFailureReason error)
        {
            IsInitialized = false;
            Error("Initialization Failed");   
        }

        PurchaseProcessingResult IStoreListener.ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            //if (purchaseValidator.Validate(purchaseEvent))
            //    PurchaseSucceed.Invoke();
            //else
            //    OnPurchaseFailed(purchaseEvent.purchasedProduct.definition.id, "NonValid");

            return PurchaseProcessingResult.Complete;

        }
        void IStoreListener.OnPurchaseFailed(UnityEngine.Purchasing.Product product, PurchaseFailureReason failureReason)
        {
            
        }

        public string GetPrice(string productID)
        {
            return "";
        }


        public void Buy(string id)
        {
           
        }

        public void RestorePurchases()
        {
        }


        private void Log(string message) => Debug.Log(WrapMessage(message));
        private void Error(string message) => Debug.LogError($"Error: {WrapMessage(message)}");
        private string WrapMessage(string message) => $"[{GetType().Name}] {message}";

        public void OnPurchaseFailed(UnityEngine.Purchasing.Product product, PurchaseFailureReason failureReason)
        {
            throw new System.NotImplementedException();
        }
    }
}
