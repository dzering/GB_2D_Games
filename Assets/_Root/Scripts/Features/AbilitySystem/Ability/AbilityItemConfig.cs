using MyGame.Features.Inventory.Items;
using UnityEngine;

namespace MyGame.Features.AbilitySystem
{
    internal interface IAbilityItem
    {
        string ID { get; }
        Sprite Icon { get; }
        AbilityType Type { get; }
        GameObject Projectile { get; }
        float Value { get; }
    }

    [CreateAssetMenu(fileName = nameof(AbilityItemConfig), menuName = "Configs/" + nameof(AbilityItemConfig))]
    internal class AbilityItemConfig : ScriptableObject, IAbilityItem
    {
        [SerializeField] private ItemConfig itemConfig;
        [field: SerializeField] public AbilityType Type { get; private set; }

        [field: SerializeField] public GameObject Projectile { get; private set; }

        [field: SerializeField] public float Value { get; private set; }
        public string ID => itemConfig.Id;

        public Sprite Icon => itemConfig.Icon;
    }
}
