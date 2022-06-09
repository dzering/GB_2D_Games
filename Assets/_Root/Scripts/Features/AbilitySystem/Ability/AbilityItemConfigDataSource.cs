using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MyGame.Features.AbilitySystem
{
    [CreateAssetMenu(
        fileName = nameof(AbilityItemConfigDataSource),
        menuName ="Configs/" + nameof(AbilityItemConfigDataSource))]
    internal class AbilityItemConfigDataSource : ScriptableObject
    {
        [SerializeField] private AbilityItemConfig[] abilityConfigs;

        public IReadOnlyList<AbilityItemConfig> AbilityItemConfigs => abilityConfigs;

    }
}
