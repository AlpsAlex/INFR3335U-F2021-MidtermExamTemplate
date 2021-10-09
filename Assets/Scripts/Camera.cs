using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target; //player
    public float rotatespeed = 5.0f;
    Vector3 offset;


    // Use this for initialization
    void Start()
    {
        //get the distance between the camera and the target(player)
        offset = target.transform.position - transform.position;
    }

    // LateUpdate is called after update function so after we've calculated player movement
    void LateUpdate()
    {
        //rotate the player based on mouse input
        float horizontal = Input.GetAxis("Mouse X") * rotatespeed;
        target.transform.Rotate(0, horizontal, 0);

        //CAMERA MOVEMENT
        //angle that the target is looking at
        float desiredAngle = target.transform.eulerAngles.y;

        //Create a quaternion that holds the angle that we want the camera to be looking at
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);

        //update the position of the camera so it follows the player
        transform.position = target.transform.position - (rotation * offset);

        //rotates the transform of the camera so the forward vector points at the target's current position
        transform.LookAt(target.transform);

    }
}
