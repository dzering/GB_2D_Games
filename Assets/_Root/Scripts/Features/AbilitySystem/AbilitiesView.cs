using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace MyGame.Features.AbilitySystem
{
    internal interface IAbilityView
    {
        void Display(IReadOnlyList<IAbilityItem> abilities, Action<string> action);
        void Clear();
    }
    internal class AbilitiesView : MonoBehaviour, IAbilityView
    {
        [SerializeField] private GameObject ButtonViewPref;
        [SerializeField] private Transform placeForButtons;

        private readonly Dictionary<string, AbilityButtonView> buttonViews = new Dictionary<string, AbilityButtonView>();

        public void Display(IReadOnlyList<IAbilityItem> abilityItems, Action<string> action)
        {
            Clear();

            foreach (IAbilityItem abilityItem in abilityItems)
            {
                buttonViews[abilityItem.ID] = CreateButton(abilityItem, action);
            }

        }

        private AbilityButtonView CreateButton(IAbilityItem abilityItem, Action<string> clicked)
        {
            GameObject objectView = UnityEngine.Object.Instantiate(ButtonViewPref, placeForButtons, false);
            AbilityButtonView buttonView = objectView.GetComponent<AbilityButtonView>();

            buttonView.Init(
                abilityItem.Icon,
                () => clicked?.Invoke(abilityItem.ID)
                );

            return buttonView;
        }

        public void Clear()
        {
            foreach (AbilityButtonView buttonView in buttonViews.Values)
                DestroyButtonView(buttonView);

            buttonViews.Clear();
        }

        private void DestroyButtonView(AbilityButtonView buttonView)
        {
            buttonView.Deinit();
            Destroy(buttonView.gameObject);
            
        }

        private void OnDestroy() => Clear();
    }
}
