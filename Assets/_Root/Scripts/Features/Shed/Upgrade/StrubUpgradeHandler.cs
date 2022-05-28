using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Features.Shed.Upgrade
{
    internal class StrubUpgradeHandler: IUpgradeHandler
    {
        public static readonly IUpgradeHandler Default = new StrubUpgradeHandler();
        public void Upgrade(IUpgradable upgradable) { }
    }
}
