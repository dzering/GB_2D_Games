using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Features.AbilitySystem
{
    internal interface IAbility
    {
        void Apply(IAbilityActivator activator);
    }
}
