using UnityEngine;
using UnityEngine.UI;

namespace MyGame.Features.Inventory.Item
{
    [CreateAssetMenu(fileName = nameof(ItemConfig), menuName = "Configs/Inventory" + nameof(ItemConfig))]
    internal class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public Image Icon { get; private set; }
    }
}
