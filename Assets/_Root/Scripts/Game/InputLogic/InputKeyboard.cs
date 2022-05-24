using MyGame.Game.InputLogic;
using UnityEngine;
using JoostenProductions;

namespace Assets._Root.Scripts.Game.InputLogic
{
    internal class InputKeyboard : BaseInputView
    {

        private void Start()
        {
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            float direction = Input.GetAxis("Horizontal");
            float moveValue = speed * direction * Time.deltaTime;


            float abs = Mathf.Abs(moveValue);
            float sign = Mathf.Sign(moveValue);

            if (sign <= 0)
                OnLeftMove(abs);
            else
                OnRightMove(abs);
        }
    }
}
