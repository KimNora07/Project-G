using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

            
            Vector2 curPos = this.transform.position;
            var spawnPos = curPos + dir * 10;
            var meteor = Instantiate(meteoritePregab, spawnPos, Quaternion.identity).GetComponent<movement>();
            float meteorAngle = AngleBetweenPoints(meteor.gameObject.transform.position, this.transform.position);
            meteorAngle += 90;
            var targetRotation = Quaternion.Euler(new Vector3(0f, 0f, meteorAngle));
            meteor.transform.rotation = targetRotation;
            meteor.MoveTo(-dir);


            //float pisutionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
           // Vector3 meteoritePosition = new Vector3(pisutionX, stageData.LimitMax.y + 1.0f, 0);
            //Instantiate(meteoritePregab, meteoritePosition, Quaternion.identity);
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
        }

    }
    private float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}