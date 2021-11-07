using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] float breakingPower = 0.1f;
    [SerializeField] float maxForwardSpeed = 35f;
    [SerializeField] float maxBackwardSpeed = 10f;
    [SerializeField] float acceleration = 0.075f; //How fast will object reach a maximum speed
    [SerializeField] float deceleration = 0.05f; //How fast will object reach a speed of 0


    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost") {
            moveSpeed = 50f;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (moveSpeed > 10f) {
            moveSpeed = 10f;
        }
    }

    void Update()
    {
        // if pressing forward
        if (Input.GetAxis("Vertical") > 0f) {
            if (moveSpeed < maxForwardSpeed) {
                moveSpeed = moveSpeed + acceleration;
            }
        }
        // if pressing backwards
        else if (Input.GetAxis("Vertical") < 0f) {
            if (moveSpeed > 0) {
                // increasing break strength brings car to stop faster
                moveSpeed = moveSpeed - breakingPower;
            }
            else if (moveSpeed > -maxBackwardSpeed) {
                // reverse at half acceleration speed
                moveSpeed = moveSpeed - (acceleration * 0.5f); 
            }
        }
        // natural speed decay with no acceleration
        else {
            if (moveSpeed > deceleration) {
                moveSpeed = moveSpeed - deceleration;
            }
            else {
                moveSpeed = 0f;
            }
        }

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;

        // move the game object
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }
}
