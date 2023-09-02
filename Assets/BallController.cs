using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 300f;
    public float maxSpeed = 500f;
    public float accelerationRate = 10f;
    public float maxBounceAngle = 45f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitializeBall();
    }

    void FixedUpdate()
    {
        AccelerateBall();
    }

    public void InitializeBall()
    {
        Vector2 initialDirection = Random.insideUnitCircle.normalized;
        rb.velocity = initialDirection * initialSpeed;
        rb.sharedMaterial.bounciness = 1.0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Paddle"))
        {
            float randomAngle = Random.Range(-maxBounceAngle, maxBounceAngle);
            rb.velocity = Quaternion.Euler(0f, 0f, randomAngle) * rb.velocity;
        }
        else if (collision.gameObject.CompareTag("DeathBarrier"))
        {
            // Ball hit the death barrier, reset the scene.
            ResetScene();
        }
    }

    void AccelerateBall()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.velocity += rb.velocity.normalized * accelerationRate * Time.fixedDeltaTime;
        }
    }

    void ResetScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}