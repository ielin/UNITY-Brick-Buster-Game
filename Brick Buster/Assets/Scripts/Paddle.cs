using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rb;
    public float sidewaysForce;


    private void FixedUpdate()
    {
        if(Input.GetKey("a"))
        {
            rb.AddForce(Vector2.left * sidewaysForce);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(Vector2.right * sidewaysForce);
        }
    }
}
