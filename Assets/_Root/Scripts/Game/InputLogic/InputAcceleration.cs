using System;
using UnityEngine;

namespace MyGame.Game.InputLogic
{
    internal class InputAcceleration : BaseInputView
    {
        [SerializeField] private float inputMultiplier = 0.05f;

        protected override void Move()
        {
            Vector3 direction = CalcDirection();
            float moveValue = speed * Time.deltaTime * inputMultiplier * direction.x;

            float abs = MathF.Abs(moveValue);
            float sigh = MathF.Sign(moveValue);

            if (sigh > 0)
                OnRightMove(abs);
            else
                OnLeftMove(abs);
        }

        private Vector3 CalcDirection()
        {
            const float normalizedMagnitude = 1;

            Vector3 direction = Vector3.zero;
            direction.x = -Input.acceleration.y;
            direction.z = Input.acceleration.x;

            if(direction.sqrMagnitude > normalizedMagnitude)
            {
                direction.Normalize();
            }

            return direction;
        }
    }
}
