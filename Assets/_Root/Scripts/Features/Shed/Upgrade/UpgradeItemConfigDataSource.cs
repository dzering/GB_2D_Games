using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Features.Shed.Upgrade
{
    [CreateAssetMenu(fileName = nameof(UpgradeItemConfigDataSource), 
        menuName = "Configs/" + nameof(UpgradeItemConfigDataSource))]
    internal class UpgradeItemConfigDataSource : ScriptableObject
    {
        [SerializeField] private UpgradeItemConfig[] upgradeItemConfigs;
        public IReadOnlyList<UpgradeItemConfig> UpgradeItemConfigs => upgradeItemConfigs;
    }
}
