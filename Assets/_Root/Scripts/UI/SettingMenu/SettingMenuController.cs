using UnityEngine.Advertisements;
using MyGame.Profile;
using UnityEngine;
using MyGame.Tools;

namespace MyGame.UI
{
    internal class SettingMenuController : BaseController
    {
        private readonly ResourcePath path = new ResourcePath("Prefabs/UI/SettingMenu");

        private readonly ProfilePlayer profilePlayer;
        private readonly SettingMenuView view;

        public SettingMenuController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            view = LoadView(placeForUI);
            this.profilePlayer = profilePlayer;
            view.Init(BackToMenu);
        }


        private SettingMenuView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourceLoader.LoadPref(path);
            GameObject view = GameObject.Instantiate(prefab, placeForUI, false);
            AddGameObject(view);

            return view.GetComponent<SettingMenuView>();
        }

        private void BackToMenu()
        {
            profilePlayer.CurrentState.Value = GameState.Start;

        }
    }
}