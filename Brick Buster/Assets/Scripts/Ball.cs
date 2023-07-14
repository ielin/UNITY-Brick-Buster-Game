using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float startSpeed;
    public AudioSource hitSFX, brickBreak, ballFall;
    private ParticleSystem particle;
    private SpriteRenderer blockSprite;
    private BoxCollider2D blockCollider;

    public StartMenu startMenuScript;
    public Score scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    //Restart a scene
    public IEnumerator Restart()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(5);
        startMenuScript.startMenuActive = true;
        Score.currentScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(2);
        MoveBall(new Vector2(0, -1));
    }

    //Ball Movement
    void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        rb.velocity = direction * startSpeed;
    }

    //Detection of Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Paddle")
        {
            hitSFX.Play();
            Bounce(collision);
        }

        if(collision.collider.CompareTag("Block"))
        {
            brickBreak.time = 0.4f;
            brickBreak.Play();

            scoreScript.UpdateScore();
            StartCoroutine(Break(collision.collider));
           
        }

        if (collision.collider.CompareTag("BottomBorder"))
        {
            ballFall.Play();
            StartCoroutine(Restart());
        }
    }
    
    //Ball Break
    private IEnumerator Break(Collider2D collision)
    {
        particle = collision.gameObject.GetComponent<ParticleSystem>();
        particle.Play();
        blockSprite = collision.gameObject.GetComponent<SpriteRenderer>();
        blockSprite.enabled = false;

        blockCollider = collision.gameObject.GetComponent<BoxCollider2D>();
        blockCollider.enabled = false;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);

        Destroy(collision.gameObject);
    }

    //Ball Bounce 
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
