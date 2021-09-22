using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    [SerializeField] private LayerMask layerMask;
    private Rigidbody2D rigidbody2D;
    public float dashForce = 1.0F;
    private Vector3 moveDir;
    bool isDashButtonDown;
    private RaycastHit2D hit;


    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = 0F;
        float moveY = 0F;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1F;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1F;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1F;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1F;
            transform.localScale = Vector3.one;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashButtonDown = true;
        }
        moveDir = new Vector3(moveX, moveY).normalized;
    }
    private void FixedUpdate()
    {
         rigidbody2D.velocity = moveDir;
        if (isDashButtonDown)
        {
            Vector3 dashPosition = transform.position + moveDir * dashForce;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, moveDir, dashForce, layerMask);
            if (raycastHit2D.collider != null)
            {
                dashPosition = raycastHit2D.point;
            }
            rigidbody2D.MovePosition(dashPosition);
            isDashButtonDown = false;
        }
        
    }

}
