using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace MyGame.Features.AbilitySystem
{
    internal class GunAbility : IAbility
    {
        private readonly AbilityItemConfig config;

        public GunAbility(AbilityItemConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }


        public void Apply(IAbilityActivator activator)
        {
            Rigidbody2D rb = Object.Instantiate(config.Projectile).GetComponent<Rigidbody2D>();
            Vector3 force = activator.ViewGameObject.transform.right * config.Value;
            rb.AddForce(force, ForceMode2D.Force);
        }
    }
}
