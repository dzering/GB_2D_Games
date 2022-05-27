using MyGame.Scripts.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MyGame.Features.Inventory.Items
{
    internal interface IItemView
    {
        void DeInit();
        void Init(IItem item, UnityAction clickAction);
        void Select();
        void Unselect();
    }

    internal class ItemView : MonoBehaviour, IItemView
    {
        [Header("Components")]
        [SerializeField] private CustomText text;
        [SerializeField] private Image icon;
        [SerializeField] private Button button;

        [Header("Backgrounds")]
        [SerializeField] GameObject selectedBackground;
        [SerializeField] GameObject unselectedBackground;

        public void Init(IItem item, UnityAction clickAction)
        {
            text.Text = item.ItemInfo.Title;
            icon.sprite = item.ItemInfo.Icon;
            button.onClick.AddListener(clickAction);
        }


        public void Select() => SetSelected(true);
        public void Unselect() => SetSelected(false);
        public void DeInit()
        {
            text.Text = string.Empty;
            icon.sprite = null;
            button.onClick.RemoveAllListeners();
        }

        private void SetSelected(bool isSelected)
        {
            selectedBackground.SetActive(isSelected);
            unselectedBackground.SetActive(!isSelected);
        }
        private void OnDestroy() => DeInit();

    }
}