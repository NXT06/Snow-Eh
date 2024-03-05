using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team22;
using UnityEngine.InputSystem.iOS;

namespace team22
{
    public class PlayerController : MicrogameInputEvents
    {
        Vector2 currentSpeed = Vector2.zero;
        public float acceleration = 1500f;
        public float rotateSpeed = 90;

        Vector2 up = new Vector2(0f, 1f);
        Vector2 upRight = new Vector2(0.7f, 0.7f);
        Vector2 right = new Vector2(1f, 0f);
        Vector2 downRight = new Vector2(0.7f, -0.7f);
        Vector2 down = new Vector2(0f, -1f);
        Vector2 downLeft = new Vector2(-0.7f, -0.7f);
        Vector2 left = new Vector2(-1f, 0f);
        Vector2 upLeft = new Vector2(-0.7f, 0.7f);

        Rigidbody2D body;

        // Start is called before the first frame update
        void Start()
        {
            body = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            SetSpeed();
            SetRotation();
            Move();
        }

        void SetSpeed()
        {
            currentSpeed = stick.normalized * acceleration;
        }

        void SetRotation()
        {
            if (stick.normalized != Vector2.zero)
            {
                if (stick.normalized == up)
                {
                    
                }
                else if (stick.normalized == upRight)
                {

                } else if(stick.normalized == right)
                {
                } else if(stick.normalized == downRight)
                {

                } else if(stick.normalized == down)
                {

                } else if(stick.normalized == downLeft)
                {

                } else if(stick.normalized == left)
                {

                } else if(stick.normalized == upLeft)
                {

                }
                transform.rotation = Quaternion.Slerp(transform.rotation, )
            }
        }

        void Move()
        {
            body.AddForce(currentSpeed * Time.deltaTime);
        }
    }
}
