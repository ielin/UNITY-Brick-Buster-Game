using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float startSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(2);
        MoveBall(new Vector2(0, -1));
    }

    void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        rb.velocity = direction * startSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle")
        {
            Bounce(collision);
        }
    }

    private void Bounce(Collision2D collision)
    {
        Vector2 ballPosition = transform.position;
        Vector2 paddlePosition = collision.collider.transform.position;
        float paddleLength = collision.collider.bounds.size.x;

        float directionX = (ballPosition.x - paddlePosition.x) / paddleLength;
        float directionY = 1;

        MoveBall(new Vector2(directionX*2, directionY));
    }
}
