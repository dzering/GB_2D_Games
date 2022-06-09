using UnityEngine;
using MyGame.Features.Shed;
using MyGame.Features.Inventory;
using MyGame.Tools;
using MyGame.Profile;
using MyGame.Features.Shed.Upgrade;
using System;
using System.Collections.Generic;

namespace MyGame.Features.Shed
{
    internal class ShedController : BaseController
    {
        private readonly ResourcePath pathView = new ResourcePath("Prefabs/Shed/ShedView");
        private readonly ResourcePath pathConfig = new ResourcePath("Configs/UpgradeItemConfigDataSource");

        private readonly ShedView shedView;
        private readonly InventoryController inventoryController;
        private readonly UpgradeHandlerRepository upgradeHandlerRepository;
        private readonly ProfilePlayer profilePlayer;

        public ShedController(Transform placeForUI, ProfilePlayer profile)
        {
            profilePlayer = profile;
            upgradeHandlerRepository = CreateRepository();
            inventoryController = CreateInventory(placeForUI, profile.InventoryModel);
            shedView = LoadView(placeForUI);
            shedView.Init(Apply, Back);

        }
        private ShedView LoadView(Transform placeForUI)
        {
            GameObject pref = ResourceLoader.LoadPref(pathView);
            GameObject view = UnityEngine.Object.Instantiate(pref, placeForUI);
            AddGameObject(view);

            return view.GetComponent<ShedView>();
        }
        private InventoryController CreateInventory(Transform placeForUI, IInventoryModel model)
        {
            InventoryController inventoryController = new InventoryController(placeForUI, model);
            AddController(inventoryController);

            return inventoryController;
        }

        private UpgradeHandlerRepository CreateRepository()
        {
            UpgradeHandlerRepository repository = new UpgradeHandlerRepository
                (ContentDataSourceLoader.LoadUpgradeItemConfigs(pathConfig));
            AddRepository(repository);

            return repository;
        }

        private void Apply()
        {
            profilePlayer.CurrentTransport.Restor();
            UpgradeWithEquippedItems(
                profilePlayer.CurrentTransport,
                profilePlayer.InventoryModel.EquippedItems,
                upgradeHandlerRepository.Items);

            profilePlayer.CurrentState.Value = GameState.Start;
            Log($"Apply. Current Speed: { profilePlayer.CurrentTransport.Speed}");
        }

        private void Back()
        {
            profilePlayer.CurrentState.Value = GameState.Start;
            Log($"Back. Current Speed: {profilePlayer.CurrentTransport.Speed}");
        }

        private void Log(string message)
        {
            Debug.Log($"[{GetType().Name}] {message }");
        }

        private void UpgradeWithEquippedItems(
            IUpgradable upgradable,
            IReadOnlyList<string> equippedItemId,
            IReadOnlyDictionary<string, IUpgradeHandler> upgradeHandler)
        {
            foreach (var itemId in equippedItemId)
            {
                if (upgradeHandler.TryGetValue(itemId, out IUpgradeHandler handler))
                    handler.Upgrade(upgradable);
            }
        }
    }
}
