using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;


    public ParticleSystem bomb;
    public MateorState state;

    private void Start()
    {
        bomb.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.InGame)
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 diretion)
    {
        moveDirection = diretion;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            switch (state)
            {
                case MateorState.None:
                    this.state = MateorState.In;
                    break;
                case MateorState.In:
                    this.state = MateorState.Out;
                    break;
            }
        }

        if (collision.CompareTag("Player"))
        {
            bomb.gameObject.SetActive(true);
            bomb.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            switch (state)
            {
                case MateorState.Out:
                    Destroy(this.gameObject);
                    break;
            }
        }
    }


}
