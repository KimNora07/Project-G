using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackMeteor : MonoBehaviour
{
    [SerializeField]
    private float knockBackForce = 10f; // �˹� �� ����
    [SerializeField]
    private float knockBackDuration = 0.5f; // �˹� ���� �ð�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                StartCoroutine(ApplyKnockBack(rb));
            }
        }
    }

    private IEnumerator ApplyKnockBack(Rigidbody2D rb)
    {
        Vector2 direction = (rb.transform.position - transform.position).normalized;
        Vector2 knockBack = direction * knockBackForce;
        float elapsed = 0f;

        while (elapsed < knockBackDuration)
        {
            rb.velocity = knockBack;
            elapsed += Time.deltaTime;
            yield return null;
        }

        rb.velocity = Vector2.zero; // �˹� �� �ӵ� �ʱ�ȭ
    }
}
