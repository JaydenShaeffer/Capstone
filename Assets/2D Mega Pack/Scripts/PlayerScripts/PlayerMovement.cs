using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private PlayerHP playerHP;
    [SerializeField] private AudioClip jumpSound;
    private bool canMove = false;
    private bool isAnimationPlaying = false;
    [SerializeField] private float initialDelay = 1.5f; // Adjust the delay as needed

    // ----- NEW STUFF TESTING ------ //
    public float runspeed = 7f;
    Vector2 moveInput;
    public bool _IsFacingRight = true;
    public float jumpForce = 10f;

    public bool IsFacingRight
    {
        get { return _IsFacingRight; }
        private set
        {
            if (_IsFacingRight != value)
            {
                //flip the local scale to make the player face the opposite direction
                transform.localScale *= new Vector2(-1, 1);
            }

            _IsFacingRight = value;
        }
    }

    [SerializeField]
    private bool _isJumping = false;
    [SerializeField]
    private bool _isMoving = false;

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            anim.SetBool("isMoving", value);
        }
    }

    public bool IsJumping
    {
        get
        {
            return _isJumping;
        }
        private set
        {
            _isJumping = value;
            anim.SetBool("isJumping", value);
        }
    }
    // ----- NEW STUFF TESTING ------ // 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private bool isJumping = false;
    //private bool hasSpawned = false; // Add a flag to track if the spawn animation has played

    private void Start()
    {
        StartCoroutine(EnableMovementAfterDelay());
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerHP = GetComponent<PlayerHP>();
    }
     private IEnumerator EnableMovementAfterDelay()
    {
        yield return new WaitForSeconds(initialDelay);

        // Enable movement after the initial delay
        // You can add additional initialization code here if needed

        canMove = true;
    }

    private void Update()
    {
        // Check if the player is alive before allowing movement or jump input
        if (canMove && !playerHP.isDead && !isAnimationPlaying)
        {
            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                SoundManager.instance.PlaySound(jumpSound);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isJumping = true;
                IsJumping = true; // Set the IsJumping property to trigger the jump animation
           
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            IsJumping = false;
        }
    }

    private void FixedUpdate()
    {
        // Only allow movement if the player is alive
        if (canMove && !playerHP.isDead && !isAnimationPlaying)
        {
            rb.velocity = new Vector2(moveInput.x * runspeed, rb.velocity.y);
            
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (!playerHP.isDead)
        {
            IsMoving = moveInput != Vector2.zero;

            SetFacingDirection(moveInput);
        }
        else
        {
            IsMoving = false;
        }
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            // face right
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            // face left
            IsFacingRight = false;
        }
    }

     // Add a method to set the animation state
    public void SetAnimationState(bool state)
    {
        isAnimationPlaying = state;
    }
}
