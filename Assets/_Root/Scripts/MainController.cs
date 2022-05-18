using MyGame;
using MyGame.UI;
using MyGame.Profile;
using MyGame.Game;
using UnityEngine;
using MyGame.Services.Analitics;

internal class MainController : BaseController
{
    private readonly ProfilePlayer profilePlayer;
    private readonly Transform placeForUI;
    private readonly AnaliticsManager analiticsManager;

    private MainMenuController mainMenuController;
    private GameController gameController;
    private SettingMenuController settingMenuController;



    public MainController(Transform placeForUI, ProfilePlayer profilePlayer, AnaliticsManager analiticsManager)
    {
        this.profilePlayer = profilePlayer;
        this.placeForUI = placeForUI;
        this.analiticsManager = analiticsManager;

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
                analiticsManager.GameStarted();
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