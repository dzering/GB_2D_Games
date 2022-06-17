using System;
using UnityEngine;

namespace Test
{
    internal class GroundCheckOverlap : IGroundCheck
    {
        public bool IsGrounded { get; set; }
        private Transform transform;

        public GroundCheckOverlap(GameObject target)
        {
            this.transform = target.transform;
        }

        public void Update()
        {
            Vector2 point = transform.position;
            Vector2 size = new Vector2(transform.localScale.x, transform.localScale.y);
            IsGrounded = Physics2D.OverlapBox(point, size, 0);
        }
    }
}
