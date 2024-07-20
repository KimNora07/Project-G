using UnityEngine;
using System.Collections;

public class HomingMeteor : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // ��� �̵� �ӵ�

    private Transform player; // �÷��̾��� Transform

    private void Start()
    {
        // "Player" �±׸� ���� ��ü�� ã�� �÷��̾�� ����
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
            // �÷��̾ ���� �̵�
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        Destroy(this.gameObject, 5f);
    }
}