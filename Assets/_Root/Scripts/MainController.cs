using MyGame;
using MyGame.UI;
using MyGame.Profile;
using MyGame.Game;
using UnityEngine;

internal class MainController : BaseController
{
    private readonly ProfilePlayer profilePlayer;
    private readonly Transform placeForUI;

    private MainMenuController mainMenuController;
    private GameController gameController;
    private SettingMenuController settingMenuController;

    public MainController(Transform placeForUI, ProfilePlayer profilePlayer)
    {
        this.profilePlayer = profilePlayer;
        this.placeForUI = placeForUI;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(profilePlayer.CurrentState.Value);
    }

    private void OnChangeGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.None:
                break;

            case GameState.Start:
                gameController?.Dispose();
                settingMenuController?.Dispose();
                mainMenuController = new MainMenuController(placeForUI, profilePlayer);
                break;

            case GameState.Game:
                mainMenuController?.Dispose();
                settingMenuController?.Dispose();
                gameController = new GameController(profilePlayer);
                break;

            case GameState.Setting:
                mainMenuController?.Dispose();
                settingMenuController = new SettingMenuController(placeForUI, profilePlayer);
                break;

            default:
                break;
        }
    }

    protected override void OnDispose()
    {
        mainMenuController?.Dispose();
        gameController?.Dispose();


        profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }

}