using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speed = 100f;

    private float moveInput;
    /*private Rigidbody2D rb;*/

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddForce((jumpForce * transform.up), ForceMode2D.Impulse);
        }
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
    }   

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed * Time.fixedDeltaTime, rb.velocity.y);
    }

}
