using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 250;
    [SerializeField] float moveSpeed = 10;

    void Start()
    {

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
