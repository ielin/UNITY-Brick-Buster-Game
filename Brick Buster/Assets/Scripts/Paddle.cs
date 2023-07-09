using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rb;
    public float sidewaysForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
