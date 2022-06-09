using MyGame.Tools;
using UnityEngine;
using MyGame.Features.AbilitySystem;


namespace MyGame.Game.Transport
{
    internal abstract class TransportController : BaseController, IAbilityActivator
    {
        public abstract GameObject ViewGameObject { get; }
    }
}
