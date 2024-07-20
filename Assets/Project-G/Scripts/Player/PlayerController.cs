using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerController : MonoBehaviour
{
    private Movement2D Movement2D;

    public Transform arrowPos;

    public Vector3 newArrowPos;

    [SerializeField] private float rotSpeed;

    [SerializeField] private ParticleSystem[] zPackBoostParticle;

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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var particle in zPackBoostParticle)
            {


                particle.Play();
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            

            Movement2D.MoveTo(arrowPos.position, true);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            foreach (var particle in zPackBoostParticle)
            {
                particle.Stop();
            }
            Movement2D.MoveTo(arrowPos.position, false);
        }        
    }

}
