using UnityEngine;
using MyGame.Tools;
using System;

namespace MyGame.Game.TapeBackground
{
    internal class TapeBackground : MonoBehaviour
    {
        [SerializeField] private Background[] backgrounds;
        private IReadonlySubscriptionProperty<float> diff;

        public void Init(IReadonlySubscriptionProperty<float> diff)
        {
            this.diff = diff;
            diff.SubscribeOnChange(Move);
        }

        private void OnDestroy()
        {
            diff?.UnSubscribeOnChange(Move);
        }

        private void Move(float value)
        {
            foreach (var background in backgrounds)
            {
                background.Move(-value);
            }
        }
    }
}
