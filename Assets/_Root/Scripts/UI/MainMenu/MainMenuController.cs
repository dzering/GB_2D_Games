using MyGame.Profile;
using MyGame;
using UnityEngine;
using MyGame.UI;
using MyGame.Tools;

namespace MyGame.UI
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath path = new ResourcePath("Prefabs/ui/MainMenu");
        private readonly MainMenuView view;
        private readonly ProfilePlayer profilePlayer;

        public MainMenuController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            this.profilePlayer = profilePlayer;
            view = LoadView(placeForUI);
            view.Init(StartGame);
        }

        private MainMenuView LoadView(Transform placeForUI)
        {
            GameObject viewPref = ResourceLoader.LoadPref(path);
            GameObject view = GameObject.Instantiate(viewPref, placeForUI, false);

            AddGameObject(view);

            return view.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            profilePlayer.CurrentState.Value = GameState.Game;
        }
    }
}
