using MyGame;
using MyGame.Features.Inventory.Items;
using MyGame.Features.Inventory;
using System.Collections.Generic;
using System;

namespace MyGame.Features.AbilitySystem
{
    internal class AbilityRepository : Repository<string, IAbility, AbilityItemConfig>
    {
        public AbilityRepository(IEnumerable<AbilityItemConfig> configs) : base(configs)
        {
        }

        protected override string GetKey(AbilityItemConfig config) => config.ID;

        protected override IAbility CreateItem(AbilityItemConfig config) =>
            config.Type switch
            {
                AbilityType.Gun => new GunAbility(config),
                AbilityType.Jump => new JumpAbility(config),
                _ => new StrubAbility()
            };

    }
}
