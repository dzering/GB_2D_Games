using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MyGame.UI 
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button buttonStart;

        public void Init(UnityAction startGame)
        {
            buttonStart.onClick.AddListener(startGame);
        }

        private void OnDestroy()
        {
            buttonStart.onClick.RemoveAllListeners();
        }

    }
}
