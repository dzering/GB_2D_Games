using UnityEngine;
using MyGame.Features.Shed;
using MyGame.Features.Inventory;
using MyGame.Tools;
using MyGame.Profile;
using MyGame.Features.Shed.Upgrade;
using System;

namespace MyGame.Features.Shed
{
    internal class ShedController : BaseController
    {
        private readonly ResourcePath pathView = new ResourcePath("Prefabs/Shed/ShedMenu");
        private readonly ResourcePath pathConfig = new ResourcePath("Configs/UpgradeItemConfigDataSource");

        private readonly ShedView shedView;
        private readonly InventoryController inventoryController;
        private readonly UpgradeHandlerRepository upgradeHandlerRepository;
        private readonly ProfilePlayer profilePlayer;

        public ShedController(Transform placeForUI, ProfilePlayer profile)
        {
            profilePlayer = profile;
            shedView = LoadView(placeForUI);
            upgradeHandlerRepository = CreateRepository();
            inventoryController = CreateInventory(placeForUI, profile.InventoryModel);

        }
        private ShedView LoadView(Transform placeForUI)
        {
            GameObject pref = ResourceLoader.LoadPref(pathView);
            GameObject view = GameObject.Instantiate(pref, placeForUI);
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
            profilePlayer.CarModel.Restor();


            
            
        }



    }
}
