using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] meteoritePrefabs; // 여러 종류의 적 프리팹을 저장할 배열
    [SerializeField]
    private float minSpawnTime = 0.2f;
    [SerializeField]
    private float maxSpawnTime = 1.5f;

    private float currentMinSpawnTime;
    private float currentMaxSpawnTime;

    public PlayerUi playerUi;

    private void Awake()
    {
        currentMinSpawnTime = minSpawnTime;
        currentMaxSpawnTime = maxSpawnTime;
        StartCoroutine(SpawnMeteorite());
    }

    private void Update()
    {
        AdjustSpawnTimeBasedOnScore();
    }

    private IEnumerator SpawnMeteorite()
    {
        while (true)
        {
            var angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            var dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            Vector2 curPos = this.transform.position;
            var spawnPos = curPos + dir * 10;

            // 랜덤한 적 프리팹 선택
            var randomIndex = Random.Range(0, meteoritePrefabs.Length);
            var selectedPrefab = meteoritePrefabs[randomIndex];

            var meteor = Instantiate(selectedPrefab, spawnPos, Quaternion.identity).GetComponent<movement>();
            float meteorAngle = AngleBetweenPoints(meteor.gameObject.transform.position, this.transform.position);
            meteorAngle += 90;
            var targetRotation = Quaternion.Euler(new Vector3(0f, 0f, meteorAngle));
            meteor.transform.rotation = targetRotation;
            meteor.MoveTo(-dir);

            float spawnTime = Random.Range(currentMinSpawnTime, currentMaxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void AdjustSpawnTimeBasedOnScore()
    {
        int score = playerUi.score;

        if (score > 100)
        {
            currentMinSpawnTime = minSpawnTime * 0.8f;
            currentMaxSpawnTime = maxSpawnTime * 0.8f;
        }
        else if (score > 500)
        {
            currentMinSpawnTime = minSpawnTime * 0.6f;
            currentMaxSpawnTime = maxSpawnTime * 0.6f;
        }
        else if (score > 1000)
        {
            currentMinSpawnTime = minSpawnTime * 0.4f;
            currentMaxSpawnTime = maxSpawnTime * 0.4f;
        }
        else
        {
            currentMinSpawnTime = minSpawnTime;
            currentMaxSpawnTime = maxSpawnTime;
        }
    }

    private float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
