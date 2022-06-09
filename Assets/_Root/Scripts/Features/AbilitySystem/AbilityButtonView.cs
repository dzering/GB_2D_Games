using MyGame.Tools;
using MyGame.Features.AbilitySystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

namespace MyGame.Features.AbilitySystem
{
    internal class AbilityButtonView : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Button button;

        private void OnDestroy() => Deinit();


        public void Init(Sprite icon, UnityAction action)
        {
            this.icon.sprite = icon;
            button.onClick.AddListener(action);
        }
        public void Deinit()
        {
            this.icon = null;
            button.onClick.RemoveAllListeners();
        }
        
    }
}
