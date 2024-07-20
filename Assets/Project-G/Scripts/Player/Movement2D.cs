using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private Vector3 moveDir = Vector3.zero;
    [SerializeField] private Transform currentDir;

    //private Rigidbody2D rb;

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;



        //rb.AddForce(moveDir * moveSpeed, ForceMode2D.Force);
    }

    public void MoveTo(Vector3 dir, bool isMove = false)
    {
        switch (isMove)
        {
            case false: moveDir = Vector3.zero; break;

            case true: moveDir = dir - transform.position; break;
        }

        float angle = AngleBetweenPoints(this.transform.position, currentDir.position);

        angle += 90;

        var targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

        moveDir.Normalize();
    }

    private float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
