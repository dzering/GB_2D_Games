using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class GroundCheckRaycast : IGroundCheck
    {
        private readonly float distanceToCheck;
        private readonly Transform transform;
        public bool IsGrounded { get; set; }

        public GroundCheckRaycast(GameObject target)
        {
            transform = target.transform;
            SpriteRenderer spriteRenderer = target.GetComponent<SpriteRenderer>();
            distanceToCheck = spriteRenderer.size.y/2;
            Debug.Log($"SpriteRender y: {distanceToCheck}");
        }

        public void Update()
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, distanceToCheck))
                IsGrounded = true;
            else
                IsGrounded = false;
        }
    }
}