using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class GameController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float jumpForce;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float gravityScale = 1;
       
        private GameObject target;

        private float velocity;

        private GroundCheckOverlapWithSnapping groundCheck;

        private void Start()
        {
            target = new Player().PlayerGameObject;
            groundCheck = new GroundCheckOverlapWithSnapping(target.transform);
        }

        // Update is called once per frame
        void Update()
        {
            groundCheck.Update();

            velocity += gravity * gravityScale * Time.deltaTime;
            if (groundCheck.IsGrounded && velocity < 0)
            {
                velocity = 0;
                target.transform.position = new Vector3(
                    target.transform.position.x,
                    groundCheck.SurfacePosition.y + target.transform.localScale.y/2,
                    target.transform.position.z);

            }


            if (Input.GetKeyDown(KeyCode.UpArrow))
                velocity = jumpForce;

            target.transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);

        }
    }
}