using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(dirX * moveSpeed, playerRb.velocity.y);
        
        if (Input.GetButtonDown("Jump")) {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState() {
        if (dirX > 0) {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;

        } else if (dirX < 0) {
            anim.SetBool("isRunning", true);
            sprite.flipX = true;
        }
        else {
            anim.SetBool("isRunning", false);
        }
    }
}
