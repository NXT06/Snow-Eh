using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team22;
using UnityEngine.InputSystem.iOS;

namespace team22
{
    public class PlayerController : MicrogameInputEvents
    {
        [Header("Movement Values")]
        Vector2 currentSpeed = Vector2.zero;
        public float AccelerationTime = 1.5f;
        public float DecelerationTime = 5f;
        public float MaxSpeed = 7f;
        public float RotationSpeed = 360;

        // joystick directions
        Vector2 idle = new Vector2(0f, 0f);
        Vector2 up = new Vector2(0f, 1f);
        Vector2 upRight = new Vector2(0.7f, 0.7f);
        Vector2 right = new Vector2(1f, 0f);
        Vector2 downRight = new Vector2(0.7f, -0.7f);
        Vector2 down = new Vector2(0f, -1f);
        Vector2 downLeft = new Vector2(-0.7f, -0.7f);
        Vector2 left = new Vector2(-1f, 0f);
        Vector2 upLeft = new Vector2(-0.7f, 0.7f);

        Vector2 direction;

        void Start()
        {
            // get the direction of the joystick
            direction = stick.normalized;
        }

        void Update()
        {
            Move();
        }

        public void Move()
        {
            // if there is an input
            if (direction != idle)
            {
                // Use the speed and calculate the metres/second or acceleration until the maximum speed is reached
                currentSpeed.x = Mathf.Clamp(currentSpeed.x + (MaxSpeed / AccelerationTime) * Time.deltaTime * direction.x, -MaxSpeed, MaxSpeed);
                currentSpeed.y = Mathf.Clamp(currentSpeed.y + (MaxSpeed / AccelerationTime) * Time.deltaTime * direction.y, -MaxSpeed, MaxSpeed);

                RotationCalculations();

            }
            // if there is no input
            else
            {
                // application of friction/deceleration depending on the stored direction
                if (currentSpeed.x > 0) // for moving right
                {
                    currentSpeed.x = Mathf.Clamp(currentSpeed.x - (MaxSpeed / DecelerationTime) * Time.deltaTime, 0, MaxSpeed);
                }
                if (currentSpeed.x < 0) // for moving left
                {
                    currentSpeed.x = Mathf.Clamp(currentSpeed.x + (MaxSpeed / DecelerationTime) * Time.deltaTime, -MaxSpeed, 0);
                }
                if (currentSpeed.y > 0) // for going down
                {
                    currentSpeed.y = Mathf.Clamp(currentSpeed.y - (MaxSpeed / DecelerationTime) * Time.deltaTime, 0, MaxSpeed);
                }
                if (currentSpeed.y < 0) // for going up
                {
                    currentSpeed.y = Mathf.Clamp(currentSpeed.y + (MaxSpeed / DecelerationTime) * Time.deltaTime, -MaxSpeed, 0);
                }
            }

            // Update the transform of the player
            transform.position = new Vector2(transform.position.x + currentSpeed.x * Time.deltaTime, transform.position.y + currentSpeed.y * Time.deltaTime);

        }

        public void RotationCalculations()
        {
            // get the looking rotation/moving direction of the player
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);

            // update the rotation of this object
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);
        }
    }
}
