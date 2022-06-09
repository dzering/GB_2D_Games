
namespace MyGame.Features.AbilitySystem
{
    internal class StrubAbility : IAbility
    {
        public static readonly IAbility Default = new StrubAbility();
        public void Apply(IAbilityActivator activator) 
        { }
    }
}
