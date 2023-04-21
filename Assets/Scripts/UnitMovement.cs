using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private Rigidbody2D rigidbody2d;
    private Vector3 moveDirection;
    private Vector3 movePosition;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        movePosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        moveDirection = (movePosition - transform.position).normalized;
        
        if (Vector3.Distance(movePosition, transform.position) < 0f)
        {
            moveDirection = Vector3.zero;
        }   
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = moveDirection * speed;
    }

    public void SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
    }
}
