using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MyGame.Features.Shed
{
    internal interface IShedView
    {
        void Init(UnityAction applyButton, UnityAction backButton);
        void Deinit();
    }
    internal class ShedView : MonoBehaviour, IShedView
    {
        [SerializeField] private Button applyButton;
        [SerializeField] private Button backButton;
        public void Deinit()
        {
            applyButton.onClick.RemoveAllListeners();
            backButton.onClick.RemoveAllListeners();
        }

        public void Init(UnityAction apply, UnityAction back)
        {
            applyButton.onClick.AddListener(apply);
            backButton.onClick.AddListener(back);
        }

        private void OnDestroy() => Deinit();
    }
}
