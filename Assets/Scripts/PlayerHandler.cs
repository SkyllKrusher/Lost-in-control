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
    private AudioSource audioSource = null;
    private Animator playerAnim;
    private float speed = 0;
    private float localScaleX;
    private bool isGrounded = false;
    private Vector3 direction;
    void Start()
    {
        direction = angle.localPosition;
        localScaleX = transform.localScale.x;
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        Debug.Log(isGrounded);
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
        PlaySoundEffect(0);
        SetAnimations(false, true, false);
        direction = new Vector2(-angle.localPosition.x, angle.localPosition.y);
        Debug.Log("MoveLeft");
        transform.localScale = new Vector2(-localScaleX, transform.localScale.y);
        speed = -playerSpeed;
    }

    public void MoveRight()
    {
        PlaySoundEffect(0);
        SetAnimations(false, true, false);
        direction = angle.localPosition;
        Debug.Log("MoveRight");
        transform.localScale = new Vector2(localScaleX, transform.localScale.y);
        speed = playerSpeed;
    }
    public void IdlePlayer()
    {
        audioSource.Stop();
        playerAnim.SetBool("isRunning", false);
        playerAnim.SetBool("isIdle", true);
        Debug.Log("Idle");
        speed = 0;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            PlaySoundEffect(1);
            playerAnim.SetBool("isJumping", true);
            GetComponent<Rigidbody2D>().AddForce(direction * playerJumpForce);
            Debug.Log("Jump");
        }
    }

    public void PlaySoundEffect(int soundIndex)
    {
        audioSource.clip = AudioManager.Instance.soundClips[soundIndex];
        audioSource.Play();
    }

    public void SetAnimations(bool isIdle, bool isRunning, bool isJumping)
    {
        playerAnim.SetBool("isIdle", isIdle);
        playerAnim.SetBool("isRunning", isRunning);
        playerAnim.SetBool("isJumping", isJumping);
    }
}
