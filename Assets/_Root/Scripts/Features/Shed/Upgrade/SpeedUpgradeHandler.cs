using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Features.Shed.Upgrade
{
    internal class SpeedUpgradeHandler : IUpgradeHandler
    {
        private readonly float speed;
        public SpeedUpgradeHandler(float speed)
        {
            this.speed = speed;
        }

        public void Upgrade(IUpgradable upgradable)
        {
            upgradable.Speed += speed;
        }
    }
}
