using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D Movement2D;

    public Transform arrowPos;

    public Vector3 newArrowPos;

    [SerializeField] private float rotSpeed;

    [SerializeField] private ParticleSystem[] zPackBoostParticle;

    public PlayerUi playerUi;

    private void Start()
    {
        foreach (var particle in zPackBoostParticle)
        {
            particle.Stop();
        }
        Movement2D = GetComponent<Movement2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (playerUi.state == PlayerState.GageLeft) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var particle in zPackBoostParticle)
                {
                    particle.Play();
                }
                playerUi.TickGage(5, false);
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                foreach (var particle in zPackBoostParticle)
                {
                    particle.Play();
                }
                Movement2D.MoveTo(arrowPos.position, true);
                playerUi.TickGage(5, false);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                foreach (var particle in zPackBoostParticle)
                {
                    particle.Stop();
                }
                Movement2D.MoveTo(arrowPos.position, false);
            }
            else
            {
                playerUi.TickGage(0.5f, true);
            }
        }
        else
        {
            playerUi.TickGage(0.5f, true);
            Movement2D.MoveTo(arrowPos.position, false);

            foreach (var particle in zPackBoostParticle)
            {
                particle.Stop();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteor"))
        {
            playerUi.Damaged(10f);
            Destroy(collision.gameObject);
        }
    }
}
