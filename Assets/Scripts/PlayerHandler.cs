using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private GameView gameView;
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float playerJumpForce = 10f;
    [SerializeField] private Transform playerJumpAngle;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform angle;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject playerProjectile = null;

    private AudioSource audioSource = null;
    private Animator playerAnim;
    private float speed = 0;
    private float localScaleX;
    private bool isGrounded = false;
    private Vector3 direction;
    private bool firstControlHit = false;

    private bool canPlayerMove = true;

    void Start()
    {
        direction = angle.localPosition;
        localScaleX = transform.localScale.x;
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //StartPlayerBounce();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);
        if (isGrounded)
        {
            Move();
        }
    }

    private void CheckFTUE()
    {
        if (!firstControlHit)
        {
            gameView.StopControlAnimation();
            firstControlHit = true;
            Invoke("StopPlayerMovement", 1f);
        }
    }
    #region ---------------- Public Methods ----------------------
    public void IdlePlayer()
    {
        audioSource.Stop();
        playerAnim.SetTrigger("idle");
        // playerAnim.SetBool("isIdle", true);
        Debug.Log("Idle");
        speed = 0;
    }

    private void Move()
    {
        if (canPlayerMove)
        {
            transform.position = new Vector2(
                transform.position.x + speed * Time.deltaTime,
                transform.position.y
            );
        }
    }

    public void MoveLeft()
    {
        if (canPlayerMove)
        {
            CheckFTUE();

            PlaySoundEffect(0);
            // SetAnimations(false, true, false);
            playerAnim.SetTrigger("run");
            direction = new Vector2(-angle.localPosition.x, angle.localPosition.y);
            Debug.Log("MoveLeft");
            transform.localScale = new Vector2(-localScaleX, transform.localScale.y);
            speed = -playerSpeed;
        }
    }

    public void MoveRight()
    {
        if (canPlayerMove)
        {
            CheckFTUE();

            PlaySoundEffect(0);
            // SetAnimations(false, true, false);
            playerAnim.SetTrigger("run");
            direction = angle.localPosition;
            Debug.Log("MoveRight");
            transform.localScale = new Vector2(localScaleX, transform.localScale.y);
            speed = playerSpeed;
        }
    }


    public void Jump()
    {
        Debug.Log("Jump");

        if (canPlayerMove)
        {
            CheckFTUE();

            if (isGrounded)
            {
                isGrounded = false;
                PlaySoundEffect(1);
                playerAnim.SetTrigger("jump");
                Debug.Log("Jump");
                GetComponent<Rigidbody2D>().AddForce(direction * playerJumpForce);
                // Invoke("SetToIdle", 0.750f); // 0.750 = length of animation
            }
        }
    }

    public void PlaySoundEffect(int soundIndex)
    {
        audioSource.clip = AudioManager.Instance.soundClips[soundIndex];
        audioSource.Play();
    }

    public void StopPlayerMovement()
    {
        Debug.LogWarning("start playing girl intro");
        canPlayerMove = false;
        StartCoroutine(gameView.StartGirlIntroAnimation());
    }

    public void StartPlayerMovement()
    {
        canPlayerMove = true;
    }

    public void StartPlayerBounce(Transform endTransform)
    {
        PlayerBounce(endTransform);
    }

    public void PlayerBounce(Transform endTransform)
    {
        Debug.LogError("Starting Player Bounce!");
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        playerProjectile.transform.parent = transform.parent;
        playerProjectile.GetComponent<Projectile>().targetTransform = endTransform;
        playerProjectile.SetActive(true);
    }

    public void PlayerBounceComplete(Vector2 endPosition)
    {
        Debug.LogError("Player bounce complete!");
        playerProjectile.SetActive(false);
        this.gameObject.transform.position = endPosition;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    #endregion --------------------------------------------
}
