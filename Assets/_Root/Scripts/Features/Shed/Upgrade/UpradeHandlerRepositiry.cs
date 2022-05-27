using System;
using System.Collections.Generic;

namespace MyGame.Features.Shed.Upgrade
{
    internal interface IUpgradeHandlerRepository : IRepository
    {
        public IReadOnlyDictionary<string, IUpgradeHandler> items { get; }
    }


    internal class UpradeHandlerRepositiry : Repository<string, IUpgradeHandler, UpgradeItemConfig>, IUpgradeHandlerRepository
    {

        public IReadOnlyDictionary<string, IUpgradeHandler> Items => throw new NotImplementedException();

        public UpradeHandlerRepositiry(IEnumerable<UpgradeItemConfig> upgradeItemConfigs) : base(upgradeItemConfigs)
        {
            
        }





        protected override IUpgradeHandler CreateItem(UpgradeItemConfig config)
        {
            config.UpgradeType switch
            {
                UpgradeType.Speed => new SpeedUpgradeHandler(config.Value),
                UpgradeType.None => throw new NotImplementedException()
            }
        }
        

        protected override string GetKey(UpgradeItemConfig config)
        {
            throw new NotImplementedException();
        }
    }
}
