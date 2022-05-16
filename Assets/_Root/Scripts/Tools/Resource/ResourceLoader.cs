using UnityEngine;

namespace MyGame.Tools
{
    internal static class ResourceLoader
    {
        public static GameObject LoadPref(ResourcePath path)
        {
            return Resources.Load<GameObject>(path.Path);
        }

        public static Sprite LoadSprite(ResourcePath path)
        {
            return Resources.Load<Sprite>(path.Path);
        }
        
    }
}
