using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MyGame.UI 
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button gameButton;
        [SerializeField] private Button settingButton;

        public void Init(UnityAction startGame, UnityAction settingMenu)
        {
            gameButton.onClick.AddListener(startGame);
            settingButton.onClick.AddListener(settingMenu);
        }

        private void OnDestroy()
        {
            gameButton.onClick.RemoveAllListeners();
            settingButton.onClick.RemoveAllListeners();
        }

    }
}
