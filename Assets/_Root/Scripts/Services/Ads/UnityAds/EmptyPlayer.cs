using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Services.Ads.UnityAds
{
    internal class EmptyPlayer : UnityAdsPlayer
    {
        public EmptyPlayer(string id) : base(id)
        {
        }

        protected override void Load()
        {
        }

        protected override void OnPlaying()
        {
        }
    }
}
