using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ContactFilter2D groundFilter;
    [SerializeField] private float jumpHeight = 7f;
    [SerializeField] private float moveSpeed = 10f;

    public int maxJumps = 0;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private int extraJumps;
    private bool isGrounded;

    void Awake()
    {
        Debug.Log("awake");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(moveInput);
        rb.linearVelocity = moveInput * moveSpeed;
        if (isGrounded)
        {
            extraJumps = maxJumps;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = rb.IsTouching(groundFilter);
    }

    void OnMove(InputValue value)
    {
        Debug.Log("Move");
        moveInput = value.Get<Vector2>();
    }
    private void OnJump()
    {
        Debug.Log("Jump");
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
        else
        {
            if (extraJumps > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x * 1, rb.linearVelocity.y * 0);
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                extraJumps--;
            }
        }
    }
}
