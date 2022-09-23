using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speed = 100f;
    [SerializeField] private PlayerAnimatorController animatorController;

    [Header("Ground Check")]
    [SerializeField] private LayerMask groundlayers;
    [SerializeField] private float groundCheckDistance = 0.01f;

    private float moveInput;
    private bool _isGrounded;
    /*private Rigidbody2D rb;*/

    private void Update()
    {
        CheckGround();

        SetAnimatorParameter();
    }

    private void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(force * transform.up, ForceMode2D.Impulse);
    }

    private void TryJumping()
    {
        if (!_isGrounded) return;

        Jump(jumpForce); 
    }

    private void FlipPlayerSprite()
    {
        if (moveInput < 0)
        {
            player.localScale = new Vector3(-1, 1, 1);
        }

        else if (moveInput > 0)
        {
            player.localScale = Vector3.one;
        }
    }

    private void CheckGround()
    {
        var playerBounds = playerCollider.bounds;

        RaycastHit2D raycastHit = 
        Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, groundCheckDistance, groundlayers);

        _isGrounded = raycastHit.collider != null;
    }

    private void SetAnimatorParameter()
    {
        animatorController.SetAnimatorParameter(rb.velocity, _isGrounded);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();

        FlipPlayerSprite();
    }   

    private void OnJump(InputValue value)
    {
        if (!value.isPressed) return;
        TryJumping();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }


}
