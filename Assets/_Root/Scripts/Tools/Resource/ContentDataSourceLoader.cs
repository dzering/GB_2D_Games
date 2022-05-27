using MyGame.Features.Inventory.Items;
using System;
using System.Linq;
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
    }
}
