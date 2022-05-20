using MyGame.Profile;
using MyGame;
using UnityEngine;
using MyGame.UI;
using MyGame.Tools;
using MyGame.Services.Ads;

namespace MyGame.UI
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath path = new ResourcePath("Prefabs/ui/MainMenu");
        private readonly MainMenuView view;
        private readonly ProfilePlayer profilePlayer;
        private readonly IAdsService adsService;

        public MainMenuController(Transform placeForUI, ProfilePlayer profilePlayer,  IAdsService adsService)
        {
            this.profilePlayer = profilePlayer;
            view = LoadView(placeForUI);
            this.adsService = adsService;

            view.Init(StartGame, SettingMenu, OnAdsInitialize);
        }

        private MainMenuView LoadView(Transform placeForUI)
        {
            GameObject viewPref = ResourceLoader.LoadPref(path);
            GameObject view = Object.Instantiate(viewPref, placeForUI, false);

            AddGameObject(view);

            return view.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            profilePlayer.CurrentState.Value = GameState.Game;
        }

        private void SettingMenu()
        {
            profilePlayer.CurrentState.Value = GameState.Setting;
        }

        private void OnAdsInitialize()
        {
            if(adsService.IsInitialized)
                adsService.InterstitialPlayer.Play();
        }
    }
}
