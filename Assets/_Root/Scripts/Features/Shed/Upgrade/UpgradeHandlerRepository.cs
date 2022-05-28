using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Features.Shed.Upgrade
{
    internal interface IUpdateHandlerRepository : IRepository
    {
        IReadOnlyDictionary<string,  IUpgradeHandler> Items { get; }
    }


    internal class UpgradeHandlerRepository :
        Repository<string, IUpgradeHandler, UpgradeItemConfig>, IUpdateHandlerRepository
    {
        public UpgradeHandlerRepository(IEnumerable<UpgradeItemConfig> configs) : base(configs) { }

        protected override IUpgradeHandler CreateItem(UpgradeItemConfig config) =>
            config.UpgradeType switch
            {
                UpgradeType.Speed => new SpeedUpgradeHandler(config.Value),
                _ => StrubUpgradeHandler.Default
            };
        

        protected override string GetKey(UpgradeItemConfig config) => config.ItemID;
    }
}
