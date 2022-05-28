﻿using MyGame.Features.Inventory.Items;
using System;
using System.Linq;
using MyGame.Features.Shed.Upgrade;
using UnityEngine;

namespace MyGame.Tools
{
    internal class ContentDataSourceLoader
    {
        public static ItemConfig[] LoadItemConfigs(ResourcePath path)
        {
            ItemConfigDataSource dataConfig = ResourceLoader.LoadObject<ItemConfigDataSource>(path);
            return dataConfig == null ? Array.Empty<ItemConfig>() : dataConfig.ItemConfigs.ToArray();
        } 

        public static UpgradeItemConfig[] LoadUpgradeItemConfigs(ResourcePath path)
        {
            UpgradeItemConfigDataSource dataSource = ResourceLoader.LoadObject<UpgradeItemConfigDataSource>(path);
            return dataSource == null ? Array.Empty<UpgradeItemConfig>() : dataSource.UpgradeItemConfigs.ToArray();
        }
    }
}
