using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnRate = 1f;
    public float meteorSpeed = 5f;
    public float destroyDelay = 5f;

    private float screenWidth;
    private float screenHeight;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        CalculateScreenBounds();
        StartCoroutine(SpawnMeteors());
    }

    void CalculateScreenBounds()
    {
        screenHeight = 2f * mainCamera.orthographicSize;
        screenWidth = screenHeight * mainCamera.aspect;
    }

    IEnumerator SpawnMeteors()
    {
        while (true)
        {
            SpawnMeteor();
            yield return new WaitForSeconds(1f / spawnRate);
        }
    }

    void SpawnMeteor()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);

        Vector3 direction = (GetRandomTargetPosition() - spawnPosition).normalized;
        meteor.GetComponent<Rigidbody>().velocity = direction * meteorSpeed;

        Destroy(meteor, destroyDelay);
    }

    Vector3 GetRandomSpawnPosition()
    {
        int side = Random.Range(0, 4);
        float x, y, z = 10f; // z is set to 10 to ensure meteors spawn in front of the camera

        switch (side)
        {
            case 0: // Top
                x = Random.Range(-screenWidth / 2, screenWidth / 2);
                y = screenHeight / 2;
                break;
            case 1: // Right
                x = screenWidth / 2;
                y = Random.Range(-screenHeight / 2, screenHeight / 2);
                break;
            case 2: // Bottom
                x = Random.Range(-screenWidth / 2, screenWidth / 2);
                y = -screenHeight / 2;
                break;
            default: // Left
                x = -screenWidth / 2;
                y = Random.Range(-screenHeight / 2, screenHeight / 2);
                break;
        }

        return mainCamera.ViewportToWorldPoint(new Vector3(x, y, z));
    }

    Vector3 GetRandomTargetPosition()
    {
        float x = Random.Range(-screenWidth / 2, screenWidth / 2);
        float y = Random.Range(-screenHeight / 2, screenHeight / 2);
        float z = 10f;

        return mainCamera.ViewportToWorldPoint(new Vector3(x, y, z));
    }
}