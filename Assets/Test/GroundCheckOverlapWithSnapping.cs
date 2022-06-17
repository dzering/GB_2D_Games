using System;
using UnityEngine;

namespace Test
{
    internal class GroundCheckOverlapWithSnapping : IGroundCheckOverlapWithSnapping
    {
        private Collider2D[] colliders = new Collider2D[1];
        private ContactFilter2D contactFilter2D;
        private Transform transform;
        public bool IsGrounded { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 SurfacePosition { get; private set; }

        public GroundCheckOverlapWithSnapping(Transform transform)
        {
            this.transform = transform;
        }

        public void Update()
        {

            SpriteRenderer spriteRenderer = transform.GetComponent<SpriteRenderer>();

            Vector2 point = transform.position;
            Size = spriteRenderer.size;

            if (Physics2D.OverlapBox(point, Size, 0, contactFilter2D.NoFilter(), colliders) > 0)
            {
                IsGrounded = true;
                SurfacePosition = Physics2D.ClosestPoint(transform.position, colliders[0]);
            }
            else
            {
                IsGrounded = false;
            }

        }
    }
}
