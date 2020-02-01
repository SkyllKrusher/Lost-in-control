using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float playerJumpForce = 10f;
    [SerializeField] private Transform playerJumpAngle;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform angle;
    [SerializeField] private LayerMask groundLayer;
    private float speed = 0;
    private float localScaleX;
    private bool isGrounded = false;
    private Vector3 direction;
    void Start()
    {
        direction = angle.localPosition;
        localScaleX = transform.localScale.x;
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);
        if (isGrounded)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }

    public void MoveLeft()
    {
        direction = new Vector2(-angle.localPosition.x, angle.localPosition.y);
        Debug.Log("MoveLeft");
        transform.localScale = new Vector2(-localScaleX, transform.localScale.y);
        speed = -playerSpeed;
    }

    public void MoveRight()
    {
        direction = angle.localPosition;
        Debug.Log("MoveRight");
        transform.localScale = new Vector2(localScaleX, transform.localScale.y);
        speed = playerSpeed;
    }
    public void IdlePlayer()
    {
        Debug.Log("Idle");
        speed = 0;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(direction * playerJumpForce);
            Debug.Log("Jump");
        }
    }
}
