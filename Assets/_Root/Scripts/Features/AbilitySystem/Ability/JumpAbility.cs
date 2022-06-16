using UnityEngine;
using System;
using Test;
using JoostenProductions;

namespace MyGame.Features.AbilitySystem
{
    internal class JumpAbility : IAbility
    {
        private float jumpForce;
        private float gravity = -9.81f;
        private float gravityScale = 1;
        private float velocity;

        private readonly AbilityItemConfig config;
        private GroundCheckOverlapWithSnapping groundCheck;
        private Transform targetTransform;
        private Transform activatorTransform;

        public JumpAbility(AbilityItemConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            jumpForce = config.Value;
        }

        public void Apply(IAbilityActivator activator)
        {
            Transform[] transforms = activator.ViewGameObject.GetComponentsInChildren<Transform>();
            activatorTransform = transforms[0];
            targetTransform = transforms[1];

            groundCheck = new GroundCheckOverlapWithSnapping(targetTransform);

            velocity = jumpForce;

            UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            groundCheck.Update();

            if (groundCheck.IsGrounded && velocity < 0)
            {
                velocity = 0;
                targetTransform.position = new Vector3(
                    targetTransform.position.x,
                    groundCheck.SurfacePosition.y + groundCheck.Size.y/2,
                    targetTransform.position.z
                    );
                UpdateManager.UnsubscribeFromUpdate(Update);
            }

            velocity += gravity * gravityScale * Time.deltaTime;
            targetTransform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);

            activatorTransform.position = targetTransform.position - targetTransform.localPosition;
            Debug.Log($"Target: {targetTransform.position}, Parant{activatorTransform.position}");

        }

    }
}
