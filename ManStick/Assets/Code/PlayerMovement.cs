using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] int moveSpeed = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
            rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocityY);
    }

}
