using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
public class spwner : MonoBehaviour
{
    [SerializeField]
    private stageData stageData;
    [SerializeField]
    private GameObject alertLinePregab;
    [SerializeField]
    private GameObject meteoritePregab;
    [SerializeField]
    private float minSpawnTime = 0.2f;
    [SerializeField]
    private float maxSpawnTime = 1.5f;

    private void Awake()
    {
        StartCoroutine("SpawnMeteorite");
    }

    private IEnumerator SpawnMeteorite()
    {
        while (true)
        {
            var angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            var dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            var spawnPos = dir * 10;
            var meteor = Instantiate(meteoritePregab, spawnPos, Quaternion.identity).GetComponent<movement>();
            meteor.MoveTo(-dir);


            //float pisutionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
           // Vector3 meteoritePosition = new Vector3(pisutionX, stageData.LimitMax.y + 1.0f, 0);
            //Instantiate(meteoritePregab, meteoritePosition, Quaternion.identity);
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}