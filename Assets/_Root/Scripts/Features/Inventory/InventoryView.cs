using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MyGame.Features.Inventory.Items;
using UnityEngine.Events;

namespace MyGame.Features.Inventory
{

    internal interface IInventoryView
    {
        void Display(IEnumerable<IItem> itemsCollection, Action<string> clickAction);
        void Clear();
        void Select(string id);
        void Unselect(string id);
    }

    internal class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private GameObject itemViewPrefab;
        [SerializeField] private Transform placeForItems;

        private readonly Dictionary<string, ItemView> itemsView = new();
        public void Display(IEnumerable<IItem> itemsCollection, Action<string> itemClicked)
        {
            Clear();

            foreach (IItem item in itemsCollection)
            {
                itemsView[item.Id] = CreateItemView(item, itemClicked);                
            }
        }

        private ItemView CreateItemView(IItem item, Action<string> itemClicked)
        {
            GameObject itemObj = Instantiate(itemViewPrefab, placeForItems, false);
            ItemView itemView = itemObj.GetComponent<ItemView>();
            itemView.Init(
                item,
                () => itemClicked?.Invoke(item.Id)
                );
            return itemView;
        }

        public void Clear()
        {
            foreach (ItemView item in itemsView.Values)
            {
                item.DeInit();
                Destroy(item.gameObject);
            }

            itemsView.Clear();
        }

        public void Select(string id)
        {
            itemsView[id].Select();
        }

        public void Unselect(string id)
        {
            itemsView[id].Unselect();
        }

        private void OnDestroy() => Clear();


    }
}
