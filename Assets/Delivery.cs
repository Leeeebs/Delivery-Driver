using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collided with: " + other.gameObject.name);
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collided with: " + other.gameObject.name);

        if (other.tag == "Package"){
            Debug.Log("Hit a package");

        }
        else {
            Debug.Log("Hit a customer");

        }
        
    }
}
