using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackMeteor : MonoBehaviour
{
    [SerializeField]
    private float knockBackForce = 10f; // ³Ë¹é Èû ¼³Á¤
    [SerializeField]
    private float knockBackDuration = 0.5f; // ³Ë¹é Áö¼Ó ½Ã°£

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

        rb.velocity = Vector2.zero; // ³Ë¹é ÈÄ ¼Óµµ ÃÊ±âÈ­
    }
}
