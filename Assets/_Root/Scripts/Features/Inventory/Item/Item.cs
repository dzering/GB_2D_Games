using UnityEngine;

namespace MyGame.Features.Inventory.Items
{
    internal interface IItem
    {
        string Id { get; }
        ItemInfo ItemInfo { get; }
    }


    internal class Item : IItem
    {
        public string Id { get; }
        public ItemInfo ItemInfo { get; }
        public Item(string id, ItemInfo itemInfo)
        {
            Id = id;
            ItemInfo = itemInfo;
        }
    }

    public readonly struct ItemInfo
    {
        public string Title { get; }
        public Sprite Icon { get; }

        public ItemInfo(string title, Sprite icon)
        {
            Title = title;
            Icon = icon;
        }
    }
}
