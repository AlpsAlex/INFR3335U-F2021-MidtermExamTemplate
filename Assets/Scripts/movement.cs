using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    Rigidbody rigidbody;
    Animator anim;

    public float movementSpeed = 10.0f;
    public float turningSpeed = 5.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        float mouseRotate = Input.GetAxis("Mouse X") * turningSpeed;
        transform.Rotate(0, mouseRotate, 0);
        
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);
        
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0)
        {
            anim.SetInteger("AnimatorState", 1);
        }
        else
            anim.SetInteger("AnimatorState", 0);


        if (!GameObject.FindGameObjectWithTag("coin"))
        {
            SceneManager.LoadScene("End");
        }

    }

}

