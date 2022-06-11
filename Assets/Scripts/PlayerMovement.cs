using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private BoxCollider2D playerCollider;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState
    {
        idle, running, jumping, falling
    }

    [SerializeField] private AudioSource jumpSoundEffect;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(dirX * moveSpeed, playerRb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            jumpSoundEffect.Play();
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState() {
        MovementState state;

        if (dirX > 0) {
            state = MovementState.running;
            sprite.flipX = false;
            
        } else if (dirX < 0) {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else {
            state = MovementState.idle;
        }

        if (playerRb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        } else if (playerRb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        //create a box on the Player to verify the jump
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
