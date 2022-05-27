using MyGame.Features.Inventory.Items;
using System;
using UnityEngine;
using MyGame.Tools;

namespace MyGame.Features.Inventory
{
    internal interface IInventoryController { }

    internal class InventoryController : BaseController, IInventoryController
    {
        private readonly ResourcePath dataSourcePath = new ResourcePath("Configs/ItemConfigDataSource");
        private readonly ResourcePath viewSourcePath = new ResourcePath("Prefabs/Inventory/InventoryView");

        private readonly IInventoryModel model;
        private readonly IInventoryView view;
        private readonly IItemsRepository repository;

        public InventoryController(Transform placeForUI, IInventoryModel model)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(InventoryModel));
            repository = CreateRepository();
            view = LoadView(placeForUI);

            view.Display(repository.Items.Values, OnItemClicked);

            foreach (var itemID in model.EquippedItems)
            {
                view.Select(itemID);
            }
        }

        private IItemsRepository CreateRepository()
        {
            ItemConfig[] itemConfigs = ContentDataSourceLoader.LoadItemConfigs(dataSourcePath);
            var repository = new ItemRepository(itemConfigs);
            AddRepository(repository);
            return repository;
            
        }

        private IInventoryView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourceLoader.LoadPref(viewSourcePath);
            GameObject objectView = GameObject.Instantiate(prefab, placeForUI);
            AddGameObject(objectView);

            return objectView.GetComponent<InventoryView>();
        }

        private void OnItemClicked(string itemID)
        {
            bool equipped = model.IsEquipped(itemID);

            if (equipped)
                Unequipped(itemID);
            else
                Equipped(itemID);

        }

        private void Equipped(string itemID)
        {
            view.Select(itemID);
            model.EquipItem(itemID);
        }

        private void Unequipped(string itemID)
        {
            view.Unselect(itemID);
            model.UnEquipItem(itemID);
        }
    }
}
