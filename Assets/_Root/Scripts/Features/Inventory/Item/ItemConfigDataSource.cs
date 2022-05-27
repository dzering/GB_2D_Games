using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Features.Inventory.Items
{
    [CreateAssetMenu(fileName = nameof(ItemConfigDataSource), menuName = "Configs/" + nameof(ItemConfigDataSource))]
    internal class ItemConfigDataSource : ScriptableObject
    {
        [SerializeField] private ItemConfig[] itemConfigs;
        public IReadOnlyList<ItemConfig> ItemConfigs => itemConfigs;
    }
}
