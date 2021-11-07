using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }

    void OnCollisionEnter2D(Collision2D other) {
        // Debug.Log("Collided with: " + other.gameObject.name);
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage){
            Debug.Log("Hit a package");
            hasPackage = true;
            spriteRenderer.color = other.gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(other.gameObject, destroyDelay);
        }
        
        if (other.tag == "Customer" && hasPackage) {
            Debug.Log("Hit a customer");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        
    }
}
