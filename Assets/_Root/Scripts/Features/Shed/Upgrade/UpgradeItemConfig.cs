using UnityEngine;
using MyGame.Features.Inventory.Items;

namespace MyGame.Features.Shed.Upgrade
{
    [CreateAssetMenu(fileName = nameof(UpgradeItemConfig), menuName = "Configs/" + nameof(UpgradeItemConfig))]
    internal class UpgradeItemConfig : ScriptableObject
    {
        [SerializeField] private ItemConfig itemConfig;
        [field: SerializeField] public UpgradeType UpgradeType { get; private set; }
        [field: SerializeField] public float Value { get; private set; }

        public string ItemID => itemConfig.Id;

    }
}
