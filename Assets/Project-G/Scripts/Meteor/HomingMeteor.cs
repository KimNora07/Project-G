using UnityEngine;
using System.Collections;

public class HomingMeteor : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // 운석의 이동 속도

    private Transform player; // 플레이어의 Transform

    private void Start()
    {
        // "Player" 태그를 가진 객체를 찾아 플레이어로 설정
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // 플레이어를 향해 이동
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        Destroy(this.gameObject, 5f);
    }
}