using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab;
    public int rows = 5;
    public int columns = 10;
    public float brickSpacing = 0.1f;
    public Vector3 spawnOffset = Vector3.zero;

    private int totalBricks;
    private int remainingBricks;

    void Start()
    {
        totalBricks = rows * columns;
        remainingBricks = totalBricks; // Initialize remainingBricks with the total number of bricks.
        SpawnBricksRandomly();
    }

    private void Update()
    {
        // Check if there are no remaining bricks by counting objects with the "Brick" tag.
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        remainingBricks = bricks.Length;

        if (remainingBricks <= 0)
        {
            ResetScene();
        }
    }

    void SpawnBricksRandomly()
    {
        Vector3 brickSize = brickPrefab.GetComponent<Renderer>().bounds.size;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float randomXOffset = Random.Range(-brickSpacing / 2, brickSpacing / 2);
                float randomYOffset = Random.Range(-brickSpacing / 2, brickSpacing / 2);

                float xPos = col * (brickSize.x + brickSpacing) + spawnOffset.x + randomXOffset;
                float yPos = row * (brickSize.y + brickSpacing) + spawnOffset.y + randomYOffset;
                Vector3 brickPosition = new Vector3(xPos, yPos, spawnOffset.z);

                GameObject brick = Instantiate(brickPrefab, transform.position + brickPosition, Quaternion.identity);
            }
        }
    }

    void ResetScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}