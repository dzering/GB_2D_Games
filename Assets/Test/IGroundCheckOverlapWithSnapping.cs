using UnityEngine;

namespace Test
{
    internal interface IGroundCheckOverlapWithSnapping
    {
        bool IsGrounded { get; set; }
        Vector2 SurfacePosition { get; }

        void Update();
    }
}