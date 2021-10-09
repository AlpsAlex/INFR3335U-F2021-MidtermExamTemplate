using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    int counter = 0;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
           
        }
    }
}
