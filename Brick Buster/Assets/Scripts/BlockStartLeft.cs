using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockStartLeft : MonoBehaviour
{
    bool moveLeft;
    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveLeft)
        {
            gameObject.transform.position += Vector3.left * speed * Time.deltaTime;

            if(gameObject.transform.position.x <= -8.05f)
            {
                moveLeft = false;
            }
        }
        else
        {
            gameObject.transform.position += Vector3.right * speed * Time.deltaTime;

            if (gameObject.transform.position.x >= +8.05f)
            {
                moveLeft = true;
            }
        }

    }
}
