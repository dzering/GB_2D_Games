using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MyGame.UI 
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button gameButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button getRewardButton;

        public void Init(UnityAction startGame, UnityAction settingMenu, UnityAction getReward)
        {
            gameButton.onClick.AddListener(startGame);
            settingButton.onClick.AddListener(settingMenu);
            getRewardButton.onClick.AddListener(getReward);
        }

        private void OnDestroy()
        {
            gameButton.onClick.RemoveAllListeners();
            settingButton.onClick.RemoveAllListeners();
            getRewardButton.onClick.RemoveAllListeners();
        }

    }
}
