using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float groundCheckInterval = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private PlayerHP playerHP;
    [SerializeField] private AudioClip jumpSound;
    private bool canMove = false;
    private bool isAnimationPlaying = false;
    [SerializeField] private float initialDelay = 1.5f; // Adjust the delay as needed

    public static bool isStunned = false;
    public float knockbackForce = 10f;
    /*// ----- NEW STUFF TESTING ------ //
    [Header("Knockback")]
    [SerializeField] private Transform center;
    [SerializeField] private float knockbackVelocity = 8f;
    [SerializeField] private bool knockbacked;
    */

    



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

    private void Reset()
    {
        Debug.Log("This will workP - jeff");
        GojoScript.domainExpansion = false;
    }
    private bool isJumping = false;
    //private bool hasSpawned = false; // Add a flag to track if the spawn animation has played

    private void Start()
    {
        StartCoroutine(CheckGroundCollisionPeriodically());

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
        if (canMove && !playerHP.isDead && !isAnimationPlaying && !Starplatinum.isPlayerFrozen && !isStunned)
        {
           
            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                SoundManager.instance.PlaySound(jumpSound);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isJumping = true;
                IsJumping = true; // Set the IsJumping property to trigger the jump animation
           
            }
        }

        if (Starplatinum.isPlayerFrozen)
        {
            Debug.Log("wow who wouldve thought");
           
        }
    }
    private IEnumerator CheckGroundCollisionPeriodically()
    {
        while (true)
        {
            //if (isJumping && IsJumping)
            //{
                 yield return new WaitForSeconds(groundCheckInterval);

                if (!IsTouchingGround())
                {
                    // Player is not touching the ground, handle accordingly
                Debug.Log("Player is not touching the ground!");
                }
            //}
           
        }
    }
    private bool IsTouchingGround()
    {
        // Perform a physics check to see if the player is touching the ground
        // You can adjust the size of the overlap circle as needed
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f); // Adjust the radius as needed
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Ground"))
            {
                return true; // Player is touching the ground
            }
        }
        isJumping = false;
        IsJumping = false;
        return false; // Player is not touching the ground
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            // Calculate knockback direction
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;

            // Apply knockback force
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            IsJumping = false;
        }
    }

    private void FixedUpdate()
    {
        // Only allow movement if the player is alive
        if (canMove && !playerHP.isDead && !isAnimationPlaying && !Starplatinum.isPlayerFrozen && !isStunned)
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

    /*public void Knockback(Transform t)
    {
        var dir = center.position - t.position;
        knockbacked = true;
        rb.velocity = dir.normalized * knockbackVelocity;
    }*/
}
