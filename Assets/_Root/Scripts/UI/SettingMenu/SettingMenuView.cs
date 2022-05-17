using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace MyGame.UI
{
    class SettingMenuView : MonoBehaviour
    {
        [SerializeField] private Button backButton;

        public void Init(UnityAction backToMainMenu)
        {
            backButton.onClick.AddListener(backToMainMenu);
        }

        private void OnDestroy()
        {
            backButton.onClick.RemoveAllListeners();
        }
    }
}
