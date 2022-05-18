using UnityEngine;

namespace MyGame.Tools
{
    internal class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            if (enabled)
                DontDestroyOnLoad(this.gameObject);
        }
    }
}
