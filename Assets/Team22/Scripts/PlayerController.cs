using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team22;
using UnityEngine.InputSystem.iOS;
using UnityEngine.InputSystem;

namespace team22
{
    public class PlayerController : MicrogameInputEvents
    {
        // movement variables
        Vector2 currentSpeed = Vector2.zero;
        public float AccelerationTime = 1.5f;
        public float DecelerationTime = 5f;
        public float MaxSpeed = 7f;
        public float RotationSpeed = 360f;
        public int playerNum; 
        // boundary variables
        public float upperBound = 1;
        public float lowerBound = -1;
        public float leftBound = -1;
        public float rightBound = 1;

        // joystick directions
        Vector2 idle = Vector2.zero;

        Vector2 direction;

        void Update()
        {
            direction = stick.normalized;
            Move();
            PlayerBounds();
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

        public void PlayerBounds()
        {
            
            // clamp calculations
            float verticalClamp = Mathf.Clamp(transform.position.y, lowerBound, upperBound);
            float horizontalClamp = Mathf.Clamp(transform.position.x, leftBound, rightBound);

            // apply these bounds
            transform.position = new Vector3(horizontalClamp, verticalClamp, transform.position.z);

            // if the left or right bound is reached
            if (transform.position.x >= rightBound || transform.position.x <= leftBound)
            {
                // cancel deceleration
                currentSpeed.x = 0;
            }
            // if the upper or lower bound is reached
            if (transform.position.y >= upperBound || transform.position.y <= lowerBound)
            {
                // cancel deceleration
                currentSpeed.y = 0;
            }
        }

        protected override void OnButton1Released(InputAction.CallbackContext context)
        {
            Shovel.canThrow = true;
           
        }

    }
}
