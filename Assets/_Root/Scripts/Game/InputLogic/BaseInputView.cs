using UnityEngine;
using MyGame.Tools;
using JoostenProductions;

namespace MyGame.Game.InputLogic
{
    internal abstract class BaseInputView : MonoBehaviour
    {
        private SubscriptionProperty<float> leftMove;
        private SubscriptionProperty<float> rightMove;

        protected float speed;

        public void Init(
            SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove,
            float speed)
        {
            this.leftMove = leftMove;
            this.rightMove = rightMove;
            this.speed = speed;
        }
        private void Start()
        {
            UpdateManager.SubscribeToUpdate(Move);
        }
        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }
        protected abstract void Move();

        protected virtual void OnLeftMove(float value)
        {
            leftMove.Value = value;
        }

        protected virtual void OnRightMove(float value)
        {
            rightMove.Value = value;
        }
    }
}
