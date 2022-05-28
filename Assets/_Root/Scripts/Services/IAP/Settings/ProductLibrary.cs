using UnityEngine;

namespace MyGame.Services.IAP.Settings
{
    internal class ProductLibrary : ScriptableObject
    {
        [field: SerializeField] public Product[] Products { get; private set; }
    }
}