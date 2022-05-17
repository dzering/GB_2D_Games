using UnityEngine;

namespace MyGame.Game.TapeBackground
{
    [RequireComponent(typeof(SpriteRenderer))]
    internal class Background : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float relativeSpeedRate;

        private Vector2 size;
        private Vector3 cashPosition;

        private float LeftBorder => cashPosition.x - size.x / 2;
        private float RightBorder => cashPosition.x + size.x / 2;

        private void Awake()
        {
            cashPosition = transform.position;
            size = spriteRenderer.size;
        }


        public void Move(float value)
        {
            Vector3 position = transform.position;
            position += Vector3.right * value * relativeSpeedRate;

            if (position.x <= LeftBorder)
                position.x = RightBorder - (LeftBorder - position.x);

            if (position.x >= RightBorder)
                position.x = LeftBorder + (RightBorder - position.x);

            transform.position = position;
        }
    }
}
