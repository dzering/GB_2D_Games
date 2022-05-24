using UnityEngine;
using MyGame.Tools;

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
