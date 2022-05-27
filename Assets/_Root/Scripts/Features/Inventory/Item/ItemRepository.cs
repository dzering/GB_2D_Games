using System;
using System.Collections.Generic;
using MyGame.Features.Inventory.Items;
using MyGame;

namespace MyGame.Features.Inventory
{
    internal interface IItemsRepository
    {
        IReadOnlyDictionary<string, IItem> Items { get; }
    }


    internal class ItemRepository : Repository<string, IItem, ItemConfig>, IItemsRepository
    {
        public ItemRepository(IEnumerable<ItemConfig> configs) : base(configs)
        {
        }
        protected override string GetKey(ItemConfig config) => config.Id;

        protected override IItem CreateItem(ItemConfig config) =>
            new Item
            (config.Id,
                new ItemInfo
                (
                    config.Title,
                    config.Icon
                    
                    )
                
                );

    }
}
