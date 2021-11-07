using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;

    // LateUpdate ensures that the camera pos is amongst the last things to be updated
    // and the thingToFollow & camera won't be fighting for position
    // car will always update first - prevents camera "jitter"
    void LateUpdate()
    {
        // set camera position to car position (z pos needs to move out so its not in the ground)
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
