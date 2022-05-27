using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Features.Inventory
{
    internal interface IInventoryModel
    {
        IReadOnlyList<string> EquippedItems { get; }
        void EquipItem(string item);
        void UnEquipItem(string item);
        bool IsEquipped(string item);
    }


    internal class InventoryModel : IInventoryModel
    {
        private List<string> equippedItems = new List<string>();
        public IReadOnlyList<string> EquippedItems => equippedItems;

        public void EquipItem(string item)
        {
            if (!IsEquipped(item))
                equippedItems.Add(item);
        }

        public void UnEquipItem(string item)
        {
            if (IsEquipped(item))
                equippedItems.Remove(item);
        }
        public bool IsEquipped(string item)
        {
            return equippedItems.Contains(item);
        }
    }
}
