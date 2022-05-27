using UnityEngine;
using MyGame;
using MyGame.UI;
using MyGame.Profile;
using MyGame.Game;
using MyGame.Services.Analitics;
using MyGame.Features.Inventory;

internal class MainController : BaseController
{
    private readonly ProfilePlayer profilePlayer;
    private readonly Transform placeForUI;

    private MainMenuController mainMenuController;
    private GameController gameController;
    private SettingMenuController settingMenuController;
    private InventoryController inventoryController;



    public MainController(Transform placeForUI, ProfilePlayer profilePlayer)
    {
        this.profilePlayer = profilePlayer;
        this.placeForUI = placeForUI;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(profilePlayer.CurrentState.Value);
    }

    private void OnChangeGameState(GameState gameState)
    {
        DisposeControllers();

        switch (gameState)
        {
            case GameState.None:
                break;

            case GameState.Start:
                mainMenuController = new MainMenuController(placeForUI, profilePlayer);
                AddController(mainMenuController);
                break;

            case GameState.Game:
                gameController = new GameController(profilePlayer);
                AnaliticsManager.Instance.GameStarted();
                break;

            case GameState.Setting:
                settingMenuController = new SettingMenuController(placeForUI, profilePlayer);
                break;

            case GameState.Inventory:
                inventoryController = new InventoryController(placeForUI, profilePlayer.InventoryModel);
                break;

            default:
                break;
        }
    }

    private void DisposeControllers()
    {
        mainMenuController?.Dispose();
        settingMenuController?.Dispose();
        gameController?.Dispose();
        inventoryController?.Dispose();
    }

    protected override void OnDispose()
    {
        DisposeControllers();


        profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }

}