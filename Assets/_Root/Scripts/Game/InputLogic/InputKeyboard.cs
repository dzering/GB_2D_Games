using MyGame.Game.InputLogic;
using UnityEngine;

namespace Assets._Root.Scripts.Game.InputLogic
{
    internal class InputKeyboard : BaseInputView
    {

        protected override void Move()
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
