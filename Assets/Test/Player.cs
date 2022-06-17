using System;
using UnityEngine;

namespace Test
{
    internal class Player
    {
        public GameObject PlayerGameObject { get; private set; }

        public Player()
        {
            PlayerGameObject = CreatePlayer();
        }

        private GameObject CreatePlayer()
        {
            PlayerGameObject = new GameObject();
            SpriteRenderer spriteRenderer = PlayerGameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = CreateSprite();

            return PlayerGameObject;
        }

        private Sprite CreateSprite()
        {
            Texture2D txt = new Texture2D(1, 1);
            txt.SetPixel(0, 0, Color.red);
            txt.Apply();

            return Sprite.Create(txt, new Rect(0, 0, 1, 1), Vector2.one * 0.5f, 1, 0, SpriteMeshType.FullRect);
        }
    }
}
