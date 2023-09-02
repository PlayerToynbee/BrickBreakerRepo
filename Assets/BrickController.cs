using UnityEngine;

public class BrickController : MonoBehaviour
{
    public int health = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            health--;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}