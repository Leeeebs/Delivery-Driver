using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 30f;
    


    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost") {
            moveSpeed = boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }

    void Update()
    {
        // direction * speed * frame duration (to standardise movement across all frame rates)
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // when reversing: invert crontrols & half speed
        if (moveAmount < 0) {
            moveAmount = moveAmount * 0.5f;
            steerAmount = steerAmount * 0.5f;
            steerAmount = steerAmount * -1;
        }

        // move the game object
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
