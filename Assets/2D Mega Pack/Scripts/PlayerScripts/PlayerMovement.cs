using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private AudioClip jumpSound;

    // ----- NEW STUFF TESTING ------ //
    public float runspeed = 7f;
    Vector2 moveInput;
    public bool _IsFacingRight = true;
    public float jumpForce = 10f;

    public bool IsFacingRight { get { return _IsFacingRight; } private set {
            if(_IsFacingRight != value)
            {
                //flip the local scale to make the player face the opposite direction
                transform.localScale *= new Vector2(-1, 1);
            }
            
            _IsFacingRight = value;


    } }
    [SerializeField]
    private bool _isJumping = false;
    [SerializeField]
    private bool _isMoving = false;

    public bool IsMoving { get
        {
            return _isMoving;
        }
    private set
        {
            _isMoving = value;
            anim.SetBool("isMoving", value);
        }
    }

    public bool IsJumping { get
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

    private void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
   

    private bool isJumping = false;
    //private bool hasSpawned = false; // Add a flag to track if the spawn animation has played


    private void Start()
    {
        
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            SoundManager.instance.PlaySound(jumpSound);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            IsJumping = true; // Set the IsJumping property to trigger the jump animation
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
        rb.velocity = new Vector2(moveInput.x * runspeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if(IsAlive)
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
        if(moveInput.x > 0 && !IsFacingRight)
        {
            // face right
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            //face right
            IsFacingRight = false;
        }
    }
    public bool IsAlive
    {
        get
        {
            return anim.GetBool("isAlive");
        }
    }
    
}
